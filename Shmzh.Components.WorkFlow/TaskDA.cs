using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Components.WorkFlow
{
	/// <summary>
	/// TaskDA 的摘要说明。
	/// </summary>
	public class TaskDA
	{
		#region 构造函数。
		public TaskDA()
		{
			
		}
		#endregion

		#region 公开方法
		/// <summary>
		/// 获取用户的所有待办事宜。
		/// </summary>
		/// <param name="ds">代办事宜实体。</param>
		/// <param name="thisGrantorID">授予者Id。</param>
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
		/// 获取三级审批的待办事宜。
		/// </summary>
		/// <param name="thisGrantorID">string:	用户。</param>
		/// <returns>Task3Data:	三级审批的待办事宜实体。</returns>
		public Task3Data GetAllTasksByUser(string thisGrantorID)
		{
			var oTask3Data = new Task3Data();
		    var parms = new[] {new SqlParameter("@GrantorID", SqlDbType.NVarChar, 20) {Value = thisGrantorID}};
            SqlHelper.FillDataset(ConnectionString.MM, CommandType.StoredProcedure, "wf_GetAll3OrderTasksByUser", oTask3Data, new[] { Task3Data.Task3_Table }, parms);

			return oTask3Data;
		}
		/// <summary>
		/// 获取某一单据的操作过程。
		/// </summary>
		/// <param name="ds">DoneTaskData:	操作实体.</param>
		/// <param name="thisDocID">int:	单据ID.</param>
		/// <param name="DocCode">int:	单据类型.</param>
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
		/// 获取用户的已办事宜.
		/// </summary>
		/// <param name="ds">已办事宜实体。</param>
		/// <param name="thisGrantorID">string:	用户ID.</param>
		/// <returns>DoneTaskData:	已办事宜实体.</returns>
		public void GetLatestDoneTasksByUser(DoneTaskData ds, string thisGrantorID)
		{
		    var parms = new[] {new SqlParameter("@StaffID", SqlDbType.NVarChar, 20) {Value = thisGrantorID}};
            SqlHelper.FillDataset(ConnectionString.MM, CommandType.StoredProcedure, "wf_GetLatestDoneTasksByUser", ds, new[] { DoneTaskData.HAVEDONETASKS_TABLE }, parms);
            
		}
        
		#endregion
	}
}
