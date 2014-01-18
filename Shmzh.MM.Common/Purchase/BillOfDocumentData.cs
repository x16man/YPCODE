using System;
using System.Data;
using System.Runtime.Serialization;

namespace Shmzh.MM.Common
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class BillOfDocumentData:DataSet
	{
		//
		// SBOD table constants
		//
		public const String SBOD_TABLE        = "SBOD";
		/// <value>���ݱ�ʶ��</value>
		public const String DOCCODE_FIELD        = "DocCode";
		/// <value>��������</value>
		public const String DOCNAME_FIELD   = "DocName";
		/// <value>�����ĵ����</value>
		public const String DOCNO_FIELD = "DocNo";
		/// <value>���ݱ������</value>
		public const String CODERULE_FIELD     = "CodeRule";
		/// <value>���ݿ�ʼ���</value>
		public const String STARTNO_FIELD     = "StartNo";
		/// <value>������һ���</value>
		public const String NEXTNO_FIELD     = "NextNo";
		/// <value>�Ƿ���һ��һ��</value>
		public const String ONEITEM_FIELD     = "OneItem";
		/// <value>��������</value>
		public const String AUDITLEVEL_FIELD     = "AuditLevel";
		/// <value>���� 1</value>
		public const String ISAUDIT1_FIELD     = "IsAudit1";
		/// <value>���� 2</value>
		public const String ISAUDIT2_FIELD     = "IsAudit2";
		/// <value>���� 3</value>
		public const String ISAUDIT3_FIELD     = "IsAudit3";
        /// <summary>
        /// �Ƿ�ʹ���ļ�������
        /// </summary>
	    public const string ISAUDIT4_FIELD = "IsAudit4";
		/// <value>�Ƿ���ƾ֤</value>
		public const String ISACCOUNT_FIELD     = "Account";

		public const String AUDITNAME1_FIELD     = "AuditName1";
		public const String AUDITNAME2_FIELD     = "AuditName2";
		public const String AUDITNAME3_FIELD     = "AuditName3";
	    public const string AUDITNAME4_FIELD = "AuditName4";

		public BillOfDocumentData()
		{
			BuildDataTables();
		}

		private BillOfDocumentData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		private void BuildDataTables()
		{
			var table   = new DataTable(SBOD_TABLE);
			
			var columns = table.Columns;
        
			columns.Add(DOCCODE_FIELD, typeof(System.Int16));
			columns.Add(DOCNAME_FIELD, typeof(System.String));
			columns.Add(DOCNO_FIELD, typeof(System.String));
			columns.Add(CODERULE_FIELD, typeof(System.String));
			columns.Add(STARTNO_FIELD, typeof(System.Int32));
			columns.Add(NEXTNO_FIELD, typeof(System.Int32));
			columns.Add(ONEITEM_FIELD, typeof(System.String));
			columns.Add(AUDITLEVEL_FIELD, typeof(System.Int16));
			columns.Add(ISAUDIT1_FIELD, typeof(System.String));
			columns.Add(ISAUDIT2_FIELD, typeof(System.String));
			columns.Add(ISAUDIT3_FIELD, typeof(System.String));
		    columns.Add(ISAUDIT4_FIELD, typeof (System.String));
			columns.Add(ISACCOUNT_FIELD, typeof(System.String));

			columns.Add(AUDITNAME1_FIELD, typeof(System.String));
			columns.Add(AUDITNAME2_FIELD, typeof(System.String));
			columns.Add(AUDITNAME3_FIELD, typeof(System.String));
            columns.Add(AUDITNAME4_FIELD, typeof(System.String));

			this.Tables.Add(table);
		}

	}
}

       

