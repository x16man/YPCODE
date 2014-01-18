using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shmzh.Components.WorkFlow.Model;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Components.WorkFlow.SQLServerDAL
{
    public class Task :IDAL.ITask
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string SQL_SELECT_FROM_MM = @"
SELECT	Task_Id as TaskId,
        Task_Name as TaskName,
        case when dbo.GetPriOfDoc(Entity_ID,DocCode)='一般' Then 0 else 1 end  As Importance,
        Entity_Id,
        DocCode,
        AuthorCode,
        AuthorName,
        AuthorLoginId,
        Proc_Id,
	    Task_Url,
        Case When Date_Accepted is null Then Date_Created else Date_Accepted End
FROM	TO_DO_TASK_LIST 
WHERE	GRANTOR_ID=@UserName ";

        private const string SQL_SELECT_FROM_DLFLO = @"
SELECT 	WFI_TASK.TaskId,
	WFI_TASK.TaskName,
	WFI_TASK.Importance,
	WFI_TASK.PostUserID,
	TB_USERSPOST.UserDspName As PosterName,
	WFI_PROC.ProcID,
	TB_WFNODES.GenStepName as ProcName,
    WFI_PROC.NodeID,
	WFI_TASK.PostTime,
	WFI_PROC.RecTime,
	WFI_TASK.WFID,
	WFI_PROC.RSID,
	WFI_TASK.STATUS,
    TB_WF.WFCD
    
FROM  	WFI_TASK INNER JOIN WFI_PROC 			  
ON 	WFI_TASK.TASKID = WFI_PROC.TASKID 			  
INNER JOIN TB_WFNODES 			  
ON 	WFI_PROC.NODEID = TB_WFNODES.NODEID 		

INNER JOIN TB_WF 			  
ON 	WFI_TASK.WFID = TB_WF.WFID 			  
INNER JOIN TB_WFCAT 			  
ON 	TB_WF.WFCATID = TB_WFCAT.WFCATID 			  
INNER JOIN TB_USERS TB_USERSPOST
ON 	WFI_TASK.POSTUSERID = TB_USERSPOST.USERID 		
WHERE 	WFI_TASK.ENABLE=1 AND 			  
	WFI_TASK.FINISHED=0 AND 			  
	WFI_TASK.STATUS<>2 AND 			  
	WFI_PROC.USERID=@UserId AND 			  
	WFI_PROC.FINISHED=0 AND 			  
	WFI_PROC.CANFORWARD=1
 ";
        #endregion

        #region Priviat Method
        /// <summary>
        /// 将DataRow转换成工作流的TaskInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>访问记录实体。</returns>
        private static TaskInfo ConvertToDLFloTaskInfo(IDataRecord dr)
        {
            var obj = new TaskInfo();
            obj.Id = string.Format("0|{0}", dr.GetInt32(5));
            obj.TaskId = dr.GetInt32(0);
            obj.TaskName = dr.GetString(1);
            obj.ProcId = dr.GetInt32(5);
            obj.ProcName = dr.GetString(6);
            obj.Poster = dr.GetString(4);
            obj.Priority = dr.GetInt32(2);
            obj.RecTime = dr.GetDateTime(9);
            obj.WFID = dr.GetInt32(10);
            obj.RSID = dr.GetInt32(11);
            obj.Type = 0;
            obj.HasURL = true;
            obj.URL = string.Format("../Workflow/binx/Process/WFFrame.aspx?pid={0}", dr.GetInt32(5));
            obj.WFCD = dr.GetString(13);
            return obj;
        }
        /// <summary>
        /// 将DataRow转换成物料的TaskInfo。
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>访问记录实体。</returns>
        private static TaskInfo ConvertToMMTaskInfo(IDataRecord dr)
        {
            var obj = new TaskInfo();
            obj.Id = string.Format("1|{0}", dr.GetInt32(0));
            obj.TaskId = dr.GetInt32(0);
            obj.TaskName = dr.GetString(1);
            obj.ProcId = dr.GetInt32(8);
            obj.ProcName = obj.TaskName.IndexOf("待") > 0
                               ? obj.TaskName.Substring(obj.TaskName.IndexOf("待") + 1)
                               : string.Empty;
            obj.Poster = dr.GetString(6);
            obj.Priority = dr.GetInt32(2);
            obj.RecTime = dr.GetDateTime(10);
            obj.WFID = dr.GetInt16(4);
            obj.WFCD = obj.WFID.ToString();
            obj.RSID = dr.GetInt32(3);
            obj.Type = 1;
            obj.HasURL = true;
            obj.URL = string.Format("{0}{1}", ConfigurationManager.AppSettings["WebMMBaseURL"], dr.GetString(9));
            return obj;
        }
        #endregion

        #region ITask 成员

        public IList<Shmzh.Components.WorkFlow.Model.TaskInfo> GetFromMM(string userName)
        {
            var parms = new[] { new SqlParameter("@UserName", SqlDbType.NVarChar, 20) { Value = userName } };
            var objs = new List<TaskInfo>();
            var dr = SqlHelper.ExecuteReader(ConnectionString.MM, CommandType.Text, SQL_SELECT_FROM_MM, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToMMTaskInfo(dr));
            }
            dr.Close();
            return objs;
            
        }

        public IList<Shmzh.Components.WorkFlow.Model.TaskInfo> GetFromDLFlo(int userId)
        {
            var parms = new[] {new SqlParameter("@UserId", SqlDbType.Int) {Value = userId},};
            var dr = SqlHelper.ExecuteReader(ConnectionString.DLFLODB, CommandType.Text, SQL_SELECT_FROM_DLFLO, parms);
            var objs = new List<TaskInfo>();
            while (dr.Read())
            {
                objs.Add(ConvertToDLFloTaskInfo(dr));
            }
            dr.Close();
            return objs;
        }

        public IList<Shmzh.Components.WorkFlow.Model.TaskInfo> GetFromMZH(string userName)
        {
            var todo = new ToDoListProvider();
            var lists = todo.GetToDoLists(userName);
            var tasks = new ListBase<Shmzh.Components.WorkFlow.Model.TaskInfo>();
            foreach (ToDoList objTask in lists)
            {
                var objTaskInfo = new Shmzh.Components.WorkFlow.Model.TaskInfo
                {
                    Id = string.Format("2|{0}", objTask.Guid),
                    TaskName = objTask.Name,
                    Priority = ((int)objTask.Priority),
                    Poster = objTask.Refer,
                    RecTime = objTask.SubmitDate,
                    TaskId = objTask.TaskID,
                    ProcId = objTask.TaskID,
                    ProcName = objTask.Description,
                    HasURL = true,
                    URL = objTask.URL,
                    Type = 2,
                    WFID = 0,
                    WFCD = "0",
                    RSID = objTask.TaskID,
                };
                tasks.Add(objTaskInfo);
            }
            return tasks;
        }
        #endregion
            
    }
}
