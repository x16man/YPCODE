using System;
using System.Data;
using System.Runtime.Serialization;   

namespace Shmzh.MM.Common
{
	/// <summary>
	/// CatalogData ��ժҪ˵����
	/// <remarks>
	///		����������л�
	/// </remarks>
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class CategoryData:DataSet
	{
		//
		// Categories table constants
		//
		/// <value>����Ŀ¼ʵ��</value>
		public const String CATEGORIES_TABLE  = "WCAT";
		/// <value>������</value>
		public const String CODE_FIELD        = "Code";
		/// <value>�������</value>
		public const String DESCRIPTION_FIELD   = "Description";
		/// <value>�Ƿ�����</value>
		public const String LOCKED_FIELD = "Locked";
		/// <value>����Ŀ</value>
		public const String STORAGEACC_FIELD     = "StorageAcc";
		/// <value>ת�ʿ�Ŀ</value>
		public const String TRANSFERACC_FIELD     = "TransferAcc";
		/// <value>�˻���Ŀ</value>
		public const String RETURNACC_FIELD     = "ReturnAcc";
		/// <value>��ע</value>
		public const String REMARK_FIELD     = "Remark";
		/// <value>��ʾ����</value>
		public const String SERIAL_FIELD     = "Serial";


		//
		// Error messages
		//
		public const String CODE_NOT_NULL="�����Ų���Ϊ��";
		public const String DESCRIPTION_NOT_NULL="������������Ϊ��";
		public const String CODE_NOT_UNIQUE="�����ű���Ψһ";

		public const String STORAGEACC_LABEL="����Ŀ";
		public const String TRANSFERACC_LABEL="ת�ʿ�Ŀ";
		public const String RETURNACC_LABEL="�˻���Ŀ";
		public const String SERIAL_LABEL="��ʾ����";

		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private CategoryData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		/// <summary>
		///     Constructor for CategoryData.  
		///     <remarks>Initialize a CategoryData instance by building the table schema.</remarks> 
		/// </summary>
		public CategoryData()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			BuildDataTables();
		}

		        
		//----------------------------------------------------------------
		// Sub BuildDataTables:
		//   Creates the following datatables:  Categories
		//----------------------------------------------------------------
		private void BuildDataTables()
		{
			//
			// Create the Categories table
			//
			DataTable table   = new DataTable(CATEGORIES_TABLE);
			DataColumnCollection columns = table.Columns;
        
			columns.Add(CODE_FIELD, typeof(System.Int16));
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			columns.Add(LOCKED_FIELD, typeof(System.String)).DefaultValue='N';
			columns.Add(STORAGEACC_FIELD, typeof(System.String));
        	columns.Add(TRANSFERACC_FIELD, typeof(System.String));
			columns.Add(RETURNACC_FIELD, typeof(System.String));
			columns.Add(REMARK_FIELD, typeof(System.String));
			columns.Add(SERIAL_FIELD, typeof(System.Int16));

			this.Tables.Add(table);
		}
	}
}

       
