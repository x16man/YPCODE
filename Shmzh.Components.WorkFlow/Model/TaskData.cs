using System.Data;

namespace Shmzh.Components.WorkFlow
{
	/// <summary>
	/// TaskData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[System.Serializable] 
	public class TaskData:DataSet
    {
        #region Field
        public const string TODOTASKLIST_TABLE = "To_Do_Task_List";		//表名.

		public const string TASK_ID_FIELD = "TASK_ID";					//任务编号。
		public const string TASK_NAME_FIELD = "TASK_NAME";				//任务名称。
		public const string TASK_URL_FIELD = "TASK_URL";				//任务URL。
		public const string SERIAL_NO_FIELD = "SERIAL_NO";				//序号。
		public const string ENTITY_ID_FIELD = "ENTITY_ID";				//单据ID。

		public const string PRE_ACT_ID_FIELD = "PRE_ACT_ID";			//前序操作ID。
		public const string CURR_ACT_ID_FIELD = "CURR_ACT_ID";			//当前操作ID。
		public const string STAFF_ID_FIELD = "STAFF_ID";				//实际操作人。
		public const string GRANTOR_ID_FIELD = "GRANTOR_ID";			//安排操作人。
		public const string DATE_CREATED_FIELD = "DATE_CREATED";		//任务创建日期。

		public const string TASK_STATUS_FIELD = "TASK_STATUS";			//任务状态。
		public const string DATE_ACCEPTED_FIELD = "DATE_ACCEPTED";		//接受日期。
		public const string DOCCODE_FIELD = "DocCode";					//单据类型。
		public const string AUTHORCODE_FIELD = "AuthorCode";			//制单人编号。
		public const string AUTHORNAME_FIELD = "AuthorName";			//制单人名称。
		public const string AUTHORLOGINID_FIELD = "AuthorLoginId";		//制单人登录名。
		public const string ENTRYSTATE_FIELD = "EntryState";			//单据状态ID。
		public const string ENTRYSTATENAME_FIELD = "EntryStateName";	//单据状态名称。
		public const string Pri_Field = "Pri";							//紧急程度。
		public const string ReqDeptName_Field = "ReqDeptName";			//申请部门。
		public const string ReqReason_Field = "ReqReason";				//用途.
		public const string Assessor1_Field = "Assessor1";				//部门审批.
		public const string Assessor2_Field = "Assessor2";				//财务审批.
		public const string SubTotal_Field = "SubTotal";				//单据合计金额.
		public const string TitleString_Field = "TitleString";			//TitleString.
		public const string DocName_Field = "DocName";					//单据类型名称。
		public const string TODOTASKLIST_DocName_TABLE = "DocName";		//父表名称。
        #endregion

        #region CTOR
        public TaskData()
		{
			BuildDataTable();
        }
        #endregion

        #region private method
        private void BuildDataTable()
		{
			// 创建　Sto 表．
			var table   = new DataTable(TODOTASKLIST_TABLE);
			//添加字段。
			table.Columns.Add(TASK_ID_FIELD, typeof(System.Int32));
			table.Columns.Add(TASK_NAME_FIELD, typeof(System.String));
			table.Columns.Add(TASK_URL_FIELD,typeof(System.String));
			table.Columns.Add(SERIAL_NO_FIELD, typeof(System.Int16));
			table.Columns.Add(ENTITY_ID_FIELD, typeof(System.Int32));

			table.Columns.Add(PRE_ACT_ID_FIELD, typeof(System.Int16));
			table.Columns.Add(CURR_ACT_ID_FIELD, typeof(System.Int16));
			table.Columns.Add(STAFF_ID_FIELD, typeof(System.String));
			table.Columns.Add(GRANTOR_ID_FIELD, typeof(System.String));
			table.Columns.Add(DATE_CREATED_FIELD, typeof(System.DateTime));

			table.Columns.Add(TASK_STATUS_FIELD, typeof(System.String));
			table.Columns.Add(DATE_ACCEPTED_FIELD, typeof(System.DateTime));
			table.Columns.Add(DOCCODE_FIELD, typeof(System.Int16));
			table.Columns.Add(AUTHORCODE_FIELD, typeof(System.String));
			table.Columns.Add(AUTHORNAME_FIELD, typeof(System.String));
			table.Columns.Add(AUTHORLOGINID_FIELD, typeof(System.String));
			table.Columns.Add(ENTRYSTATE_FIELD, typeof(System.String));
			table.Columns.Add(ENTRYSTATENAME_FIELD, typeof(System.String));
			//后增加部分.
			table.Columns.Add(Pri_Field, typeof(System.String));
			table.Columns.Add(ReqDeptName_Field, typeof(System.String));
			table.Columns.Add(ReqReason_Field, typeof(System.String));
			table.Columns.Add(Assessor1_Field, typeof(System.String));
			table.Columns.Add(Assessor2_Field, typeof(System.String));
			table.Columns.Add(SubTotal_Field, typeof(System.Decimal));
			table.Columns.Add(TitleString_Field, typeof(System.String));
			//向数据集中增加DataTable。
			this.Tables.Add(table);

			var PTable = new DataTable(TODOTASKLIST_DocName_TABLE); 
			PTable.Columns.Add(DOCCODE_FIELD, typeof(System.Int16));
			PTable.Columns.Add(DocName_Field, typeof(System.String));

			this.Tables.Add(PTable);
        }
        #endregion
    }
}
