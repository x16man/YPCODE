using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Components.WorkFlow
{
	/// <summary>
	/// TaskDA ��ժҪ˵����
	/// </summary>
	public class TaskDA
	{
		#region ���캯����
		public TaskDA()
		{
			
		}
		#endregion

		#region ��������
		/// <summary>
		/// ��ȡ�û������д������ˡ�
		/// </summary>
		/// <param name="ds">��������ʵ�塣</param>
		/// <param name="thisGrantorID">������Id��</param>
		public void GetAllTasksByUser(TaskData ds,string thisGrantorID)
		{
            var parms = new[] {new SqlParameter("@GrantorID", SqlDbType.NVarChar, 20) {Value = thisGrantorID}};
            SqlHelper.FillDataset(ConnectionString.MM, CommandType.StoredProcedure, "wf_GetAllTasksByUser", ds, new[] { TaskData.TODOTASKLIST_TABLE }, parms);
		}
		public void GetAllTasksByUserGroupByDoc(TaskData ds, string thisGrantorID)
		{
		    var parms = new[] {new SqlParameter("@GrantorID", SqlDbType.NVarChar, 20) {Value = thisGrantorID}};

			SqlHelper.FillDataset(ConnectionString.MM,CommandType.StoredProcedure,"WF_GetAllTaskGroupByUser",ds,new[] {TaskData.TODOTASKLIST_DocName_TABLE},parms);
			SqlHelper.FillDataset(ConnectionString.MM,CommandType.StoredProcedure,"wf_GetAllTasksByUser",ds,new[] {TaskData.TODOTASKLIST_TABLE},parms);
		}
		/// <summary>
		/// ��ȡ���������Ĵ������ˡ�
		/// </summary>
		/// <param name="thisGrantorID">string:	�û���</param>
		/// <returns>Task3Data:	���������Ĵ�������ʵ�塣</returns>
		public Task3Data GetAllTasksByUser(string thisGrantorID)
		{
			var oTask3Data = new Task3Data();
		    var parms = new[] {new SqlParameter("@GrantorID", SqlDbType.NVarChar, 20) {Value = thisGrantorID}};
            SqlHelper.FillDataset(ConnectionString.MM, CommandType.StoredProcedure, "wf_GetAll3OrderTasksByUser", oTask3Data, new[] { Task3Data.Task3_Table }, parms);

			return oTask3Data;
		}
		/// <summary>
		/// ��ȡĳһ���ݵĲ������̡�
		/// </summary>
		/// <param name="ds">DoneTaskData:	����ʵ��.</param>
		/// <param name="thisDocID">int:	����ID.</param>
		/// <param name="DocCode">int:	��������.</param>
		public void GetAllDoneTasksByDocID(DoneTaskData ds,int thisDocID, int DocCode)
		{
		    var parms = new[]
		                    {
		                        new SqlParameter("@EntityID", SqlDbType.Int) {Value = thisDocID},
		                        new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = DocCode}
		                    };
            SqlHelper.FillDataset(ConnectionString.MM, CommandType.StoredProcedure, "wf_GetAllDoneTasksByDocID", ds, new[] { DoneTaskData.HAVEDONETASKS_TABLE }, parms);
		}
		/// <summary>
		/// ��ȡ�û����Ѱ�����.
		/// </summary>
		/// <param name="ds">�Ѱ�����ʵ�塣</param>
		/// <param name="thisGrantorID">string:	�û�ID.</param>
		/// <returns>DoneTaskData:	�Ѱ�����ʵ��.</returns>
		public void GetLatestDoneTasksByUser(DoneTaskData ds, string thisGrantorID)
		{
		    var parms = new[] {new SqlParameter("@StaffID", SqlDbType.NVarChar, 20) {Value = thisGrantorID}};
            SqlHelper.FillDataset(ConnectionString.MM, CommandType.StoredProcedure, "wf_GetLatestDoneTasksByUser", ds, new[] { DoneTaskData.HAVEDONETASKS_TABLE }, parms);
            
		}
        
		#endregion
	}
}
