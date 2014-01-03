//-----------------------------------------------------------------------
// <copyright file = "ToDoListProvider.cs" company = "Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    /// <summary>
    /// PubData数据库中待办事宜表的数据访问操作类.
    /// </summary>
    /// <remarks>提供了对于待办事宜的检索,增加,删除,置为已办状态等操作.</remarks>
    public class ToDoListProvider
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 构造函数
        /// </summary>
        public ToDoListProvider()
        {}
        /// <summary>
        /// 获取待办事宜列表
        /// </summary>
        /// <returns>ToDoLists</returns>
        public ToDoLists GetToDoLists()
        {
            var objs = new ToDoLists();

            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData ,CommandType.StoredProcedure,"mysys_GetToDoLists");
            while (dr.Read())
            {
                objs.Add(Convert2ToDoList(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据用户名获取待办事宜.
        /// </summary>
        /// <param name = "username">用户名</param>
        /// <returns>ToDoLists 对象</returns>
        public ToDoLists GetToDoLists(string username)
        {
            var objs = new ToDoLists();

            var parms = new[] {new SqlParameter("@UserName", SqlDbType.NVarChar, 50) {Value = username}};
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_GetToDoListsByUserName", parms);

            while (dr.Read())
            {
                objs.Add(Convert2ToDoList(dr));
            }
            dr.Close();

            return objs;
        }
        /// <summary>
        /// 根据GUID获取待办事宜。
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public ToDoLists GetByGUID(string guid)
        {
            var objs = new ToDoLists();
            var parms = new[] {new SqlParameter("@GUID", SqlDbType.NChar, 32) {Value = guid}};
            var sqlStatement = "Select * From ToDoList Where GUID = @GUID";
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement,parms);

            while (dr.Read())
            {
                objs.Add(Convert2ToDoList(dr));
            }

            dr.Close();

            return objs;
        }
        /// <summary>
        /// 根据文章代号获取待办事宜。
        /// </summary>
        /// <param name="code">文章代号。</param>
        /// <returns>待办事宜列表。</returns>
        public ToDoLists GetByArticleCode(string code)
        {
            var objs = new ToDoLists();
            
            var sqlStatement = string.Format("Select * From ToDoList Where GUID like '{0}%'",code);
            var dr = SqlHelper.ExecuteReader(ConnectionString.PubData, CommandType.Text, sqlStatement);
            while (dr.Read())
            {
                objs.Add(Convert2ToDoList(dr));
            }

            dr.Close();

            return objs;
        }
        /// <summary>
        /// 增加待办事宜
        /// </summary>
        /// <param name = "submitDate">提交日期</param>
        /// <param name = "referuserName">提交人用户名</param>
        /// <param name = "referName">提交人姓名</param>
        /// <param name = "name">待办事宜主题</param>
        /// <param name = "description">待办事宜描述</param>
        /// <param name = "url">URL地址</param>
        /// <param name = "handlername">处理人姓名</param>
        /// <param name = "handlerUserName">处理人用户名</param>
        /// <param name="taskTypeId">任务类型Id。</param>
        /// <returns>待办事宜ID</returns>
        public int AddToDoItem(DateTime submitDate,string referuserName,string referName,string name,string description,string url,string handlername,string handlerUserName,int taskTypeId)
        {
            var todoitem = new ToDoList
                           {
                               Description = description,
                               Refer = referName,
                               ReferUserName = referuserName,
                               Name = name,
                               URL = url,
                               HasUrl = string.IsNullOrEmpty(url) ? 0 : 1,
                               SubmitDate = submitDate,
                               Handler = handlername,
                               HandlerUserName = handlerUserName
                           };

            return this.AddToDoItem(todoitem);
        }
        /// <summary>
        /// 增加待办事宜
        /// </summary>
        /// <param name = "submitDate">提交日期</param>
        /// <param name = "referuserName">派发者用户名</param>
        /// <param name = "referName">派发者姓名</param>
        /// <param name = "name">待办事宜名称</param>
        /// <param name = "description">备注描述</param>
        /// <param name = "url">URL链接</param>
        /// <param name = "handlername">处理者姓名</param>
        /// <param name = "handlerUserName">处理者用户名</param>
        /// <param name = "awokeTime">提醒时间。</param>
        /// <param name = "invalidateTime">失效时间。</param>
        /// <param name="taskTypeId">任务类型Id。</param>
        /// <returns>int</returns>
        public int AddToDoItem(DateTime submitDate,string referuserName,string referName,string name,string description,string url,string handlername,string handlerUserName,DateTime awokeTime,DateTime invalidateTime,int taskTypeId)
        {
            var todoitem = new ToDoList
                           {
                               Description = description,
                               Refer = referName,
                               ReferUserName = referuserName,
                               Name = name,
                               URL = url,
                               HasUrl = string.IsNullOrEmpty(url) ? 0 : 1,
                               SubmitDate = submitDate,
                               Handler = handlername,
                               HandlerUserName = handlerUserName,
                               AwokeTime = awokeTime,
                               InvalidateTime = invalidateTime,
                               TaskTypeId = taskTypeId
                           };

            //if (url != string.Empty)
            //    todoitem.HasUrl = 1;
            return this.AddToDoItem(todoitem);
        }

        /// <summary>
        /// 增加待办事宜.
        /// </summary>
        /// <param name = "submitDate">提交日期</param>
        /// <param name = "referuserName">派发者用户名</param>
        /// <param name = "referName">派发者姓名</param>
        /// <param name = "name">待办事宜名称</param>
        /// <param name = "description">备注描述</param>
        /// <param name = "url">URL连接</param>
        /// <param name = "handlername">处理者姓名</param>
        /// <param name = "handlerUserName">处理者用户名</param>
        /// <param name = "guid">GUID</param>
        /// <param name="taskTypeId">任务类型Id。</param>
        /// <returns>int</returns>
        public int AddToDoItem(DateTime submitDate,string referuserName,string referName,string name,string description,string url,string handlername,string handlerUserName,string guid,int taskTypeId)
        {
            var todoitem = new ToDoList
                           {
                               Description = description,
                               Refer = referName,
                               ReferUserName = referuserName,
                               Name = name,
                               URL = url,
                               HasUrl = string.IsNullOrEmpty(url)?0:1,
                               SubmitDate = submitDate,
                               Handler = handlername,
                               HandlerUserName = handlerUserName,
                               Guid = guid,
                               TaskTypeId = taskTypeId
                           };

            //if (url != string.Empty) todoitem.HasUrl = 1;
            return this.AddToDoItem(todoitem);
        }

        /// <summary>
        /// 增加待办事宜
        /// </summary>
        /// <param name = "item">待办事宜项</param>
        /// <returns>待办事宜ID</returns>
        public int AddToDoItem(ToDoList item)
        {
            var arParms = new SqlParameter[17];
        
            arParms[0] = new SqlParameter("@ID", SqlDbType.Int)
                             {
                                 Value = item.ID,
                                 Direction = ParameterDirection.InputOutput
                             };

            arParms[1] = new SqlParameter("@TaskID", SqlDbType.Int) {Value = item.TaskID};

            arParms[2] = new SqlParameter("@Name", SqlDbType.NVarChar,50) {Value = item.Name};

            arParms[3] = new SqlParameter("@Priority", SqlDbType.Int) {Value = ((int) item.Priority)};

            arParms[4] = new SqlParameter("@Handler", SqlDbType.NVarChar,50) {Value = item.Handler};

            arParms[5] = new SqlParameter("@SubmitDate", SqlDbType.SmallDateTime) {Value = item.SubmitDate};

            arParms[6] = new SqlParameter("@ProcessID", SqlDbType.Int) {Value = item.ProcessID};

            arParms[7] = new SqlParameter("@Description", SqlDbType.NVarChar,255) {Value = item.Description};

            arParms[8] = new SqlParameter("@HasUrl", SqlDbType.Int) {Value = item.HasUrl};

            arParms[9] = new SqlParameter("@URL", SqlDbType.NVarChar,255) {Value = item.URL};

            arParms[10] = new SqlParameter("@Refer", SqlDbType.NVarChar,50) {Value = item.Refer};

            arParms[11] = new SqlParameter("@HandlerUserName", SqlDbType.NVarChar,20) {Value = item.HandlerUserName};

            arParms[12] = new SqlParameter("@ReferUserName", SqlDbType.NVarChar,20) {Value = item.ReferUserName};

            arParms[13] = new SqlParameter("@Guid", SqlDbType.NChar,32) {Value = item.Guid};

            arParms[14] = new SqlParameter("@AwokeTime", SqlDbType.SmallDateTime)
                              {
                                  Value =
                                      ((item.AwokeTime == DateTime.MinValue || item.AwokeTime == DateTime.MaxValue)
                                           ? DBNull.Value
                                           : ((object) item.AwokeTime))
                              };

            arParms[15] = new SqlParameter("@InvalidateTime", SqlDbType.SmallDateTime)
                              {
                                  Value =
                                      ((item.InvalidateTime == DateTime.MinValue || item.InvalidateTime == DateTime.MaxValue)
                                           ? DBNull.Value
                                           : ((object) item.InvalidateTime))
                              };

            arParms[16] = new SqlParameter("@TaskTypeId", SqlDbType.Int){Value = item.TaskTypeId};
            
            try
            {
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure,"mysys_AddToDoList",arParms);
                item.ID = (int) arParms[0].Value;
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return int.Parse(arParms[0].Value.ToString());
        }

        /// <summary>
        /// 已经完成待办事宜,设定为已办.
        /// </summary>
        /// <param name = "guid">待办事宜ID</param>
        /// <returns>bool</returns>
        public bool HasToDo(string guid)
        {
            var ret = true;
            try
            {
                var arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@Guid", SqlDbType.NChar,32) {Value = guid};
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_HasToDoList", arParms);
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                ret = false;
            }
            return ret;
        }
        /// <summary>
        /// 根据GUID删除待办事宜.
        /// </summary>
        /// <param name = "guid">GUID</param>
        /// <returns>bool</returns>
        public bool DeleteToDoList(string guid)
        {
            var ret = true;
            try
            {
                var arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@Guid", SqlDbType.NChar,32) {Value = guid};
                SqlHelper.ExecuteNonQuery(ConnectionString.PubData, CommandType.StoredProcedure, "mysys_DeleteToDoList", arParms);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                ret = false;
            }
            return ret;
        }

        #region private method
        /// <summary>
        /// 将DataReader转换为ToDoList对象。
        /// </summary>
        /// <param name="dr">DataReader对象。</param>
        /// <returns>ToDoList对象。</returns>
        private static ToDoList Convert2ToDoList(IDataRecord dr)
        {
            return new ToDoList
                       {
                           ID = int.Parse(dr["ID"].ToString()),
                           Description = dr["Description"].ToString(),
                           Handler = dr["Handler"]==DBNull.Value?string.Empty:dr["Handler"].ToString(),
                           HandlerUserName = ((string)dr["HandlerUserName"]),
                           HasTodo = int.Parse(dr["HasTodo"].ToString()),
                           HasUrl = int.Parse(dr["HasUrl"].ToString()),
                           Priority = ((PriorityEnum)dr["Priority"]),
                           ProcessID = int.Parse(dr["ProcessID"].ToString()),
                           Refer = (dr["Refer"] == DBNull.Value ? string.Empty : dr["Refer"].ToString()),
                           Name = ((string)dr["Name"]),
                           ReferUserName =
                               (dr["ReferUserName"] == DBNull.Value
                                    ? string.Empty
                                    : dr["ReferUserName"].ToString()),
                           SubmitDate =
                               (dr["SubmitDate"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : DateTime.Parse(dr["SubmitDate"].ToString())),
                           ToDoTime =
                               (dr["ToDoTime"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : DateTime.Parse(dr["ToDoTime"].ToString())),
                           URL = ((string)dr["URL"]),
                           TaskID = int.Parse(dr["TaskID"].ToString()),
                           AwokeTime =
                               (dr["AwokeTime"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : DateTime.Parse(dr["AwokeTime"].ToString())),
                           InvalidateTime =
                               (dr["InvalidateTime"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : DateTime.Parse(dr["InvalidateTime"].ToString())),
                           Guid = dr["GUID"].ToString(),
                           TaskTypeId = dr["TaskTypeId"]==DBNull.Value ?0:int.Parse(dr["TaskTypeId"].ToString()),
                       };
        }
        #endregion
    }
}
