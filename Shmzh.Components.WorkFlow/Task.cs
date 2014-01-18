using System;

namespace Shmzh.Components.WorkFlow
{
	/// <summary>
	/// Task 的摘要说明。
	/// </summary>
	public class Task
    {
        #region property
        private string _taskID;
		public string Task_ID
		{
			get {
			    return _taskID ?? "";
			}
		    set{_taskID=value;}

        }
        #endregion

        #region CTOR
        public Task()
		{
        }
        #endregion

        #region method
        /// <summary>
		/// 获取用户的Todolist。
		/// </summary>
		/// <param name="thisGrantorID"></param>
		/// <returns></returns>
		public TaskData GetAllTasksByUser(string thisGrantorID)
		{
			var ds=new TaskData();
			(new TaskDA()).GetAllTasksByUser(ds,thisGrantorID);
			if (ds.Tables[0].Rows.Count == 0)
			{
				var oDataRow = ds.Tables[0].NewRow();
				oDataRow["Date_Created"] = DateTime.Now;
				oDataRow["AuthorName"] = "无";
				oDataRow["EntryStateName"] = "无";
				oDataRow["Task_URL"] = "无任务";
				oDataRow["Task_Name"]= "无任务";
				ds.Tables[0].Rows.Add(oDataRow);
			}
			return ds;
		}
        /// <summary>
        /// 获取用户的Todolist。
        /// </summary>
        /// <param name="thisGrantorID"></param>
        /// <returns></returns>
        public TaskData GetAllTasksByUserForOAWeb(string thisGrantorID)
        {
            var ds = new TaskData();
            new TaskDA().GetAllTasksByUser(ds, thisGrantorID);
            return ds;
        }

        public TaskData GetAllTasksByUserGroupByDoc(string thisGrantorID)
		{
			var ds = new TaskData();
			new TaskDA().GetAllTasksByUserGroupByDoc(ds,thisGrantorID);
			if (ds.Tables[TaskData.TODOTASKLIST_TABLE].Rows.Count == 0)
			{
				var oDataRow = ds.Tables[0].NewRow();
				oDataRow["Date_Created"] = DateTime.Now;
				oDataRow["AuthorName"] = "无";
				oDataRow["EntryStateName"] = "无";
				oDataRow["Task_URL"] = "无任务";
				oDataRow["Task_Name"]= "无任务";
				ds.Tables[0].Rows.Add(oDataRow);	
			}
			return ds;
		}
		/// <summary>
		/// 获取某一个单据的操作流程。
		/// </summary>
		/// <param name="thisDocID">int:	单据ID。</param>
		/// <param name="DocCode">单据类型编号。</param>
		/// <returns>DoneTaskData:	已完成操作的实体.</returns>
		public DoneTaskData GetAllDoneTasksByDocID(int thisDocID,int DocCode)
		{
			var ds = new DoneTaskData();
			var objTaskDA=new TaskDA();

			objTaskDA.GetAllDoneTasksByDocID(ds,thisDocID, DocCode);
			if (ds.Tables[0].Rows.Count == 0)
			{
				var oDataRow = ds.Tables[0].NewRow();
				oDataRow["Date_Completed"] = DateTime.Now;
				oDataRow["AuthorName"] = "无";
				oDataRow["EntryStateName"] = "无";
				oDataRow["ViewURL"] = "无任务";
				oDataRow["Task_Name"]= "无任务";
				ds.Tables[0].Rows.Add(oDataRow);
			}

		    return ds;
		}
		/// <summary>
		/// 获取用户的已完成操作.
		/// </summary>
		/// <param name="thisStaffID">string:	用户ID.</param>
		/// <returns>DoneTaskData:	已完成操作的实体.</returns>
		public DoneTaskData GetLatestDoneTasksByUser(string thisStaffID)
		{
			var ds = new DoneTaskData();
			var objTaskDA=new TaskDA();

			objTaskDA.GetLatestDoneTasksByUser(ds, thisStaffID);
			if (ds.Tables[0].Rows.Count == 0)
			{
				var oDataRow = ds.Tables[0].NewRow();
				oDataRow["Date_Completed"] = DateTime.Now;
				oDataRow["AuthorName"] = "无";
				oDataRow["EntryStateName"] = "无";
				oDataRow["ViewURL"] = "无任务";
				oDataRow["Task_Name"]= "无任务";
				ds.Tables[0].Rows.Add(oDataRow);
			}
		    return ds;
        }
        #endregion
    }
}
