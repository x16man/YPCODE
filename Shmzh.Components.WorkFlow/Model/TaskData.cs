using System.Data;

namespace Shmzh.Components.WorkFlow
{
	/// <summary>
	/// TaskData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[System.Serializable] 
	public class TaskData:DataSet
    {
        #region Field
        public const string TODOTASKLIST_TABLE = "To_Do_Task_List";		//����.

		public const string TASK_ID_FIELD = "TASK_ID";					//�����š�
		public const string TASK_NAME_FIELD = "TASK_NAME";				//�������ơ�
		public const string TASK_URL_FIELD = "TASK_URL";				//����URL��
		public const string SERIAL_NO_FIELD = "SERIAL_NO";				//��š�
		public const string ENTITY_ID_FIELD = "ENTITY_ID";				//����ID��

		public const string PRE_ACT_ID_FIELD = "PRE_ACT_ID";			//ǰ�����ID��
		public const string CURR_ACT_ID_FIELD = "CURR_ACT_ID";			//��ǰ����ID��
		public const string STAFF_ID_FIELD = "STAFF_ID";				//ʵ�ʲ����ˡ�
		public const string GRANTOR_ID_FIELD = "GRANTOR_ID";			//���Ų����ˡ�
		public const string DATE_CREATED_FIELD = "DATE_CREATED";		//���񴴽����ڡ�

		public const string TASK_STATUS_FIELD = "TASK_STATUS";			//����״̬��
		public const string DATE_ACCEPTED_FIELD = "DATE_ACCEPTED";		//�������ڡ�
		public const string DOCCODE_FIELD = "DocCode";					//�������͡�
		public const string AUTHORCODE_FIELD = "AuthorCode";			//�Ƶ��˱�š�
		public const string AUTHORNAME_FIELD = "AuthorName";			//�Ƶ������ơ�
		public const string AUTHORLOGINID_FIELD = "AuthorLoginId";		//�Ƶ��˵�¼����
		public const string ENTRYSTATE_FIELD = "EntryState";			//����״̬ID��
		public const string ENTRYSTATENAME_FIELD = "EntryStateName";	//����״̬���ơ�
		public const string Pri_Field = "Pri";							//�����̶ȡ�
		public const string ReqDeptName_Field = "ReqDeptName";			//���벿�š�
		public const string ReqReason_Field = "ReqReason";				//��;.
		public const string Assessor1_Field = "Assessor1";				//��������.
		public const string Assessor2_Field = "Assessor2";				//��������.
		public const string SubTotal_Field = "SubTotal";				//���ݺϼƽ��.
		public const string TitleString_Field = "TitleString";			//TitleString.
		public const string DocName_Field = "DocName";					//�����������ơ�
		public const string TODOTASKLIST_DocName_TABLE = "DocName";		//�������ơ�
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
			// ������Sto ��
			var table   = new DataTable(TODOTASKLIST_TABLE);
			//����ֶΡ�
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
			//�����Ӳ���.
			table.Columns.Add(Pri_Field, typeof(System.String));
			table.Columns.Add(ReqDeptName_Field, typeof(System.String));
			table.Columns.Add(ReqReason_Field, typeof(System.String));
			table.Columns.Add(Assessor1_Field, typeof(System.String));
			table.Columns.Add(Assessor2_Field, typeof(System.String));
			table.Columns.Add(SubTotal_Field, typeof(System.Decimal));
			table.Columns.Add(TitleString_Field, typeof(System.String));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);

			var PTable = new DataTable(TODOTASKLIST_DocName_TABLE); 
			PTable.Columns.Add(DOCCODE_FIELD, typeof(System.Int16));
			PTable.Columns.Add(DocName_Field, typeof(System.String));

			this.Tables.Add(PTable);
        }
        #endregion
    }
}
