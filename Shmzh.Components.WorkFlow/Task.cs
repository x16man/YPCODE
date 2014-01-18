using System;

namespace Shmzh.Components.WorkFlow
{
	/// <summary>
	/// Task ��ժҪ˵����
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
		/// ��ȡ�û���Todolist��
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
				oDataRow["AuthorName"] = "��";
				oDataRow["EntryStateName"] = "��";
				oDataRow["Task_URL"] = "������";
				oDataRow["Task_Name"]= "������";
				ds.Tables[0].Rows.Add(oDataRow);
			}
			return ds;
		}
        /// <summary>
        /// ��ȡ�û���Todolist��
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
				oDataRow["AuthorName"] = "��";
				oDataRow["EntryStateName"] = "��";
				oDataRow["Task_URL"] = "������";
				oDataRow["Task_Name"]= "������";
				ds.Tables[0].Rows.Add(oDataRow);	
			}
			return ds;
		}
		/// <summary>
		/// ��ȡĳһ�����ݵĲ������̡�
		/// </summary>
		/// <param name="thisDocID">int:	����ID��</param>
		/// <param name="DocCode">�������ͱ�š�</param>
		/// <returns>DoneTaskData:	����ɲ�����ʵ��.</returns>
		public DoneTaskData GetAllDoneTasksByDocID(int thisDocID,int DocCode)
		{
			var ds = new DoneTaskData();
			var objTaskDA=new TaskDA();

			objTaskDA.GetAllDoneTasksByDocID(ds,thisDocID, DocCode);
			if (ds.Tables[0].Rows.Count == 0)
			{
				var oDataRow = ds.Tables[0].NewRow();
				oDataRow["Date_Completed"] = DateTime.Now;
				oDataRow["AuthorName"] = "��";
				oDataRow["EntryStateName"] = "��";
				oDataRow["ViewURL"] = "������";
				oDataRow["Task_Name"]= "������";
				ds.Tables[0].Rows.Add(oDataRow);
			}

		    return ds;
		}
		/// <summary>
		/// ��ȡ�û�������ɲ���.
		/// </summary>
		/// <param name="thisStaffID">string:	�û�ID.</param>
		/// <returns>DoneTaskData:	����ɲ�����ʵ��.</returns>
		public DoneTaskData GetLatestDoneTasksByUser(string thisStaffID)
		{
			var ds = new DoneTaskData();
			var objTaskDA=new TaskDA();

			objTaskDA.GetLatestDoneTasksByUser(ds, thisStaffID);
			if (ds.Tables[0].Rows.Count == 0)
			{
				var oDataRow = ds.Tables[0].NewRow();
				oDataRow["Date_Completed"] = DateTime.Now;
				oDataRow["AuthorName"] = "��";
				oDataRow["EntryStateName"] = "��";
				oDataRow["ViewURL"] = "������";
				oDataRow["Task_Name"]= "������";
				ds.Tables[0].Rows.Add(oDataRow);
			}
		    return ds;
        }
        #endregion
    }
}
