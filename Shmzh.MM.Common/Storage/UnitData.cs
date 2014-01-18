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
			get {return "长度";}
		}
		public static string SQUARE
		{
			get{return "面积";}
		}
		public static string WEIGHT
		{
			get{return "重量";}
		}
		public static string CAPACITY
		{
			get{return "容积";}
		}
		public static string NULL
		{
			get{return"";}
		}
	}

	/// <summary>
	/// CatalogData 的摘要说明。
	/// <remarks>
	///		允许对象序列化
	/// </remarks>
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class UnitData:DataSet
	{
		//
		// Categories table constants
		//
		/// <value>物资目录实体</value>
		public const String UNIT_TABLE  = "WUNT";
		/// <value>类别代码</value>
		public const String CODE_FIELD        = "Code";
		/// <value>类别名称</value>
		public const String DESCRIPTION_FIELD   = "Description";
		/// <value>是否锁定</value>
		public const String ABBREVIATE_FIELD = "Abbreviate";
		/// <value>库存科目</value>
		public const String EQUIVALENCE_FIELD     = "Equivalence";
		/// <value>转帐科目</value>
		public const String CONVERSION_FIELD     = "Conversion";
		/// <value>退货科目</value>
		public const String CONUNIT_FIELD     = "ConUnit";
		/// <value>备注</value>
		public const String UNITTYPE_FIELD     = "UnitType";

		public const String LOCKED_FIELD     = "Locked";
		
		//
		// Error messages
		//
		public const String CODE_NOT_NULL="单位编码不能为空";
		public const String DESCRIPTION_NOT_NULL="单位名称不能为空";
		public const String CODE_NOT_UNIQUE="单位编码必须唯一";

		public const String CONUNIT_LABEL="换算单位";
		public const String EQUIVALENCE_LABEL="等值转换";
		public const String CONVERSION_LABEL="中国式换算";
		public const String ABBREVIATE_LABEL="单位缩写";

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
			// TODO: 在此处添加构造函数逻辑
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

       

