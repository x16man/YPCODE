using System;
using System.Data;
using System.Runtime.Serialization;

namespace Shmzh.Components.WorkFlow
{
	/// <summary>
	/// EntryUser 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class DoneTaskData:DataSet
    {
        #region Field
        public const string HAVEDONETASKS_TABLE = "HAVE_DONE_TASKS";		//表名.

		public const string TASK_ID_FIELD = "TASK_ID";		
		public const string TASK_URL_FIELD = "TASK_URL";		
		public const string TASK_NAME_FIELD = "TASK_NAME";	
		public const string SERIAL_NO_FIELD = "SERIAL_NO";
		public const string ENTITY_ID_FIELD = "ENTITY_ID";

		public const string PRE_ACT_ID_FIELD = "PRE_ACT_ID";
		public const string CURR_ACT_ID_FIELD = "CURR_ACT_ID";
		public const string STAFF_ID_FIELD = "STAFF_ID";
		public const string GRANTOR_ID_FIELD = "GRANTOR_ID";
		public const string COMPLETION_FLAG_FIELD = "COMPLETION_FLAG";

		public const string DATE_COMPLETED_FIELD = "DATE_COMPLETED";
		public const string DATE_CREATED_FIELD = "DATE_CREATED";
		public const string DATE_ACCEPTED_FIELD = "DATE_ACCEPTED";
		public const string DOCCODE_FIELD = "Doc_Code";
		public const string AUTHORCODE_FIELD = "AuthorCode";
		public const string AUTHORNAME_FIELD = "AuthorName";
		public const string AUTHORLOGINID_FIELD = "AuthorLoginId";
		public const string ENTRYSTATE_FIELD = "EntryState";
		public const string ENTRYSTATENAME_FIELD = "EntryStateName";
        #endregion

        #region CTOR
        public DoneTaskData()
		{
			
			BuildDataTable();
        }
        #endregion

        #region privat method
        private void BuildDataTable()
		{
			// 创建　Sto 表．
			DataTable table   = new DataTable(HAVEDONETASKS_TABLE);
			//添加字段。
			table.Columns.Add(TASK_ID_FIELD, typeof(System.Int32));
			table.Columns.Add(TASK_URL_FIELD, typeof(System.String));
			table.Columns.Add(TASK_NAME_FIELD,typeof(System.String));
			table.Columns.Add(SERIAL_NO_FIELD, typeof(System.Int16));
			table.Columns.Add(ENTITY_ID_FIELD, typeof(System.Int32));

			table.Columns.Add(PRE_ACT_ID_FIELD, typeof(System.Int16));
			table.Columns.Add(CURR_ACT_ID_FIELD, typeof(System.Int16));
			table.Columns.Add(STAFF_ID_FIELD, typeof(System.String));
			table.Columns.Add(GRANTOR_ID_FIELD, typeof(System.String));
			table.Columns.Add(COMPLETION_FLAG_FIELD, typeof(System.String));

			table.Columns.Add(DATE_COMPLETED_FIELD, typeof(System.DateTime));
			table.Columns.Add(DATE_CREATED_FIELD, typeof(System.DateTime));
			table.Columns.Add(DATE_ACCEPTED_FIELD, typeof(System.DateTime));
			table.Columns.Add(DOCCODE_FIELD, typeof(System.Int16));
			table.Columns.Add(AUTHORCODE_FIELD, typeof(System.String));
			table.Columns.Add(AUTHORNAME_FIELD, typeof(System.String));
			table.Columns.Add(AUTHORLOGINID_FIELD, typeof(System.String));
			table.Columns.Add(ENTRYSTATE_FIELD, typeof(System.String));
			table.Columns.Add(ENTRYSTATENAME_FIELD, typeof(System.String));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
        }
        #endregion
    }
}