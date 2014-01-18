using System;
using System.Data;
using System.Runtime.Serialization;   

namespace Shmzh.MM.Common
{
	
	[SerializableAttribute]
	public class UnitTypeEnum
	{
		public static string  LINEAR
		{
			get {return "����";}
		}
		public static string SQUARE
		{
			get{return "���";}
		}
		public static string WEIGHT
		{
			get{return "����";}
		}
		public static string CAPACITY
		{
			get{return "�ݻ�";}
		}
		public static string NULL
		{
			get{return"";}
		}
	}

	/// <summary>
	/// CatalogData ��ժҪ˵����
	/// <remarks>
	///		����������л�
	/// </remarks>
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class UnitData:DataSet
	{
		//
		// Categories table constants
		//
		/// <value>����Ŀ¼ʵ��</value>
		public const String UNIT_TABLE  = "WUNT";
		/// <value>������</value>
		public const String CODE_FIELD        = "Code";
		/// <value>�������</value>
		public const String DESCRIPTION_FIELD   = "Description";
		/// <value>�Ƿ�����</value>
		public const String ABBREVIATE_FIELD = "Abbreviate";
		/// <value>����Ŀ</value>
		public const String EQUIVALENCE_FIELD     = "Equivalence";
		/// <value>ת�ʿ�Ŀ</value>
		public const String CONVERSION_FIELD     = "Conversion";
		/// <value>�˻���Ŀ</value>
		public const String CONUNIT_FIELD     = "ConUnit";
		/// <value>��ע</value>
		public const String UNITTYPE_FIELD     = "UnitType";

		public const String LOCKED_FIELD     = "Locked";
		
		//
		// Error messages
		//
		public const String CODE_NOT_NULL="��λ���벻��Ϊ��";
		public const String DESCRIPTION_NOT_NULL="��λ���Ʋ���Ϊ��";
		public const String CODE_NOT_UNIQUE="��λ�������Ψһ";

		public const String CONUNIT_LABEL="���㵥λ";
		public const String EQUIVALENCE_LABEL="��ֵת��";
		public const String CONVERSION_LABEL="�й�ʽ����";
		public const String ABBREVIATE_LABEL="��λ��д";

		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private UnitData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		/// <summary>
		///     Constructor for UnitData.  
		///     <remarks>Initialize a UnitData instance by building the table schema.</remarks> 
		/// </summary>
		public UnitData()
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
			DataTable table   = new DataTable(UNIT_TABLE);
			DataColumnCollection columns = table.Columns;
        
			columns.Add(CODE_FIELD, typeof(System.Int16));
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			columns.Add(ABBREVIATE_FIELD, typeof(System.String));
			columns.Add(EQUIVALENCE_FIELD, typeof(System.Decimal));
			columns.Add(CONVERSION_FIELD, typeof(System.Decimal));
			columns.Add(CONUNIT_FIELD, typeof(System.String));
			columns.Add(UNITTYPE_FIELD, typeof(System.String)).DefaultValue=UnitTypeEnum.LINEAR;
			columns.Add(LOCKED_FIELD, typeof(System.String)).DefaultValue="N";

			this.Tables.Add(table);
		}
	}
}

       

