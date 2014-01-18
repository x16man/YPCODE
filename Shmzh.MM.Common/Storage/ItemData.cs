using System;
using System.Data;
using System.Runtime.Serialization;   

namespace Shmzh.MM.Common
{
	/// <summary>
	/// 物料的制购属性定义。
	/// </summary>
	[SerializableAttribute]
	public class ItemPurMak
	{
		/// <summary>
		/// 采购编号。
		/// </summary>
		public static string  PURCHASE_CODE
		{
			get {return "P";}
		}
		/// <summary>
		/// 采购名称。
		/// </summary>
		public static string  PURCHASE_DESCRIPTION
		{
			get {return "采购";}
		}
		/// <summary>
		/// 自制编号。
		/// </summary>
		public static string MAKESELF_CODE
		{
			get{return "M";}
		}
		/// <summary>
		/// 自制名称。
		/// </summary>
		public static string MAKESELF_DESCRIPTION
		{
			get{return "自制";}
		}
		/// <summary>
		/// 外协编号。
		/// </summary>
		public static string COOPERATE_CODE
		{
			get{return "C";}
		}
		/// <summary>
		/// 外协名称。
		/// </summary>
		public static string COOPERATE_DESCRIPTION
		{
			get{return "外协";}
		}
		/// <summary>
		/// 制购属性数目。
		/// </summary>
		public static int Count
		{
			get{return 3;}
		}
	}

	/// <summary>
	/// 物料状态定义。
	/// </summary>
	[SerializableAttribute]
	public class ItemState
	{
		/// <summary>
		/// 当前可用代码。
		/// </summary>
		public static string  ACTIVE_CODE
		{
			get {return "A";}
		}
		/// <summary>
		/// 当前可用名称。
		/// </summary>
		public static string  ACTIVE_DESCRIPTION
		{
			get {return "现用";}
		}
		/// <summary>
		/// 工程设计代码。
		/// </summary>
		public static string ENGINEER_CODE
		{
			get{return "E";}
		}
		/// <summary>
		/// 工程设计名称。
		/// </summary>
		public static string ENGINEER__DESCRIPTION
		{
			get{return "工程设计";}
		}
		/// <summary>
		/// 作废代码。
		/// </summary>
		public static string CANCEL_CODE
		{
			get{return "C";}
		}
		/// <summary>
		/// 作废名称。
		/// </summary>
		public static string CANCEL_DESCRITION
		{
			get{return "废弃";}
		}
		/// <summary>
		/// 逐步淘汰代码。
		/// </summary>
		public static string ELIMILATE_CODE
		{
			get{return "P";}
		}
		/// <summary>
		/// 逐步淘汰名称。
		/// </summary>
		public static string ELIMILATE_DESCRIPTION
		{
			get{return "逐步淘汰";}
		}
		/// <summary>
		/// 物料状态定义数目。
		/// </summary>
		public static int Count
		{
			get{return 4;}
		}

	}

	/// <summary>
	/// 物料的ABC等级分类。
	/// </summary>
	/// <remarks>替代枚举的作用。</remarks>
	[SerializableAttribute]
	public class ABC
	{
		/// <summary>
		/// A级编号。
		/// </summary>
		public static string  A_CODE
		{
			get {return "A";}
		}
		/// <summary>
		/// A级名称。
		/// </summary>
		public static string  A_DESCRIPTION
		{
			get {return "A类物资";}
		}
		/// <summary>
		/// B级编号。
		/// </summary>
		public static string B_CODE
		{
			get{return "B";}
		}
		/// <summary>
		/// B级名称 。
		/// </summary>
		public static string B_DESCRIPTION
		{
			get{return "B类物资";}
		}
		/// <summary>
		/// C级编号。
		/// </summary>
		public static string C_CODE
		{
			get{return "C";}
		}
		/// <summary>
		/// C级名称。
		/// </summary>
		public static string C_DESCRIPTION
		{
			get{return "C类物资";}
		}
		/// <summary>
		/// 等级数量。
		/// </summary>
		public static int Count
		{
			get{return 3;}
		}

	}

	/// <summary>
	/// 总帐方式。
	/// </summary>
	[SerializableAttribute]
	public class ItemAccountType
	{
		/// <summary>
		/// 根据分类记账代码。
		/// </summary>
		public static string  CATEGROY_CODE
		{
			get {return "C";}
		}
		/// <summary>
		/// 根据分类记账名称。
		/// </summary>
		public static string  CATEGROY_DESCRIPTION
		{
			get {return "物料分类";}
		}
		/// <summary>
		/// 根据仓库记账代码。
		/// </summary>
		public static string WAREHOUSE_CODE
		{
			get{return "W";}
		}
		/// <summary>
		/// 根据仓库记账名称。
		/// </summary>
		public static string WAREHOUSE_DESCRIPTION
		{
			get{return "存放仓库";}
		}
		/// <summary>
		/// 记账方式定义数目。
		/// </summary>
		public static int Count
		{
			get{return 2;}
		}

	}
	/// <summary>
	/// 物料分类的数据实体类。
	/// </summary>
	/// <remarks>强类型数据集，可序列化。</remarks>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class ItemData:DataSet
	{
		/// <summary>
		/// 物料主文件实体表名。
		/// </summary>
		public const string ITEM_TABLE = "WITM";
		/// <summary>
		/// 物料编号字段。
		/// </summary>
		public const string CODE_FIELD = "Code";

	    public const string NEWCODE_FIELD = "NewCode";
		/// <summary>
		/// 物料中文名称字段。
		/// </summary>
		public const string CNNAME_FIELD = "CnName";
		/// <summary>
		/// 物料英文名称字段。
		/// </summary>
		public const string ENNAME_FIELD = "EnName";
		/// <summary>
		/// 物料类别编号字段。
		/// </summary>
		public const string CATCODE_FIELD   = "CatCode";
		/// <summary>
		/// 物料类别名称字段。
		/// </summary>
		public const string CatName_Field   = "Cat_Des";
		/// <summary>
		/// 规格型号字段。
		/// </summary>
		public const string SPECIAL_FIELD = "Special";
		/// <summary>
		/// 制造商字段。
		/// </summary>
		public const string MACCODE_FIELD     = "MacCode";
		/// <summary>
		/// 制购属性字段。
		/// </summary>
		public const string PURMAK_FIELD     = "PurMak";
		/// <summary>
		/// 度量单位编号字段。
		/// </summary>
		public const string UNITCODE_FIELD     = "UnitCode";
		/// <summary>
		/// 度量单位名称字段。
		/// </summary>
		public const string UnitName_Field     = "Unit_Des";
		/// <summary>
		/// 物料状态字段。
		/// </summary>
		public const string STATE_FIELD     = "State";
		/// <summary>
		/// 是否批号跟踪字段。
		/// </summary>
		public const string BATCH_FIELD     = "Batch";
		/// <summary>
		/// 是否系号跟踪字段。
		/// </summary>
		public const string SERIALNO_FIELD     = "SerialNo";
		/// <summary>
		/// 是否需要检验字段。
		/// </summary>
		public const string CHECKED_FIELD     = "Checked";
		/// <summary>
		/// 检验报告字段。
		/// </summary>
		public const string CHKRPTCODE_FIELD     = "ChkRptCode";
		/// <summary>
		/// ABC等级字段。
		/// </summary>
		public const string ABC_FIELD     = "ABC";
		/// <summary>
		/// 移动均价字段。
		/// </summary>
		public const string CSTPRICE_FIELD     = "CstPrice";
		/// <summary>
		/// 评估价格字段。
		/// </summary>
		public const string EVAPRICE_FIELD     = "EvaPrice";
		/// <summary>
		/// 总帐方式字段。
		/// </summary>
		public const string ACCTYPE_FIELD     = "AccType";
		/// <summary>
		/// 最高库存字段。
		/// </summary>
		public const string UPPNUM_FIELD     = "UppNum";
		/// <summary>
		/// 最低库存字段。
		/// </summary>
		public const string LOWNUM_FIELD     = "LowNum";
		/// <summary>
		/// 安全库存字段。
		/// </summary>
		public const string SAFNUM_FIELD     = "SafNum";
		/// <summary>
		/// 订货点字段。
		/// </summary>
		public const string ORDNUM_FIELD     = "OrdNum";
		/// <summary>
		/// 最小订货批量。
		/// </summary>
		public const string ORDBAT_FIELD     = "OrdBat";
		/// <summary>
		/// 缺省存放仓库编号字段。
		/// </summary>
		public const string DEFSTO_FIELD     = "DefSto";
		/// <summary>
		/// 缺省存放仓库名称字段。
		/// </summary>
		public const string StoName_Field    = "Sto_Des";
		/// <summary>
		/// 缺省存放架位编号字段。
		/// </summary>
		public const string DEFCON_FIELD     = "DefCon";
		/// <summary>
		/// 缺省存放架位名称字段。
		/// </summary>
		public const string ConName_Field    = "Con_Des";
		/// <summary>
		/// 是否设置有效期字段。
		/// </summary>
		public const string SETENABLE_FIELD     = "SetEnable";
		/// <summary>
		/// 有效期开始日期字段。
		/// </summary>
		public const string ENFRMDATE_FIELD     = "EnFrmDate";
		/// <summary>
		/// 有效期结束日期字段。
		/// </summary>
		public const string ENENDDATE_FIELD     = "EnEndDate";
		/// <summary>
		/// 有效期备注字段。
		/// </summary>
		public const string ENREMARK_FIELD     = "EnRemark";
		/// <summary>
		/// 是否冻结字段。
		/// </summary>
		public const string SETFREEZED_FIELD     = "SetFreezed";
		/// <summary>
		/// 开始冻结日期字段。
		/// </summary>
		public const string FRFRMDATE_FIELD     = "FrFrmDate";
		/// <summary>
		/// 解除冻结日期字段。
		/// </summary>
		public const string FRENDDATE_FIELD     = "FrEndDate";
		/// <summary>
		/// 冻结备注字段。
		/// </summary>
		public const string FRREMARK_FIELD     = "FrRemark";
		/// <summary>
		/// 常规供应商字段。
		/// </summary>
		public const string PRVCODE_FIELD     = "PrvCode";
		/// <summary>
		/// 是否锁定字段。
		/// </summary>
		public const string LOCKED_FIELD	="Locked";
		/// <summary>
		/// 当前库存数．
		/// </summary>
		public const string ITEMNUM_FIELD = "ItemNum";

		
		/// <summary>
		/// 物资编码不能为空。
		/// </summary>
		public const string CODE_NOT_NULL="物资编码不能为空";
		/// <summary>
		/// 物资名称不能为空。
		/// </summary>
		public const string DESCRIPTION_NOT_NULL="物资名称不能为空";
		/// <summary>
		/// 物资编码必须唯一。
		/// </summary>
		public const string CODE_NOT_UNIQUE="物资编码必须唯一";
		/// <summary>
		/// 物料代码。
		/// </summary>
		public const string CODE_LABEL      = "物料代码";

	    public const string NEWCODE_LABEL = "新物料代码";
		/// <summary>
		/// 物料中文名称。
		/// </summary>
		public const string CNNAME_LABEL      = "物料中文名称";
		/// <summary>
		/// 物料英文名称。
		/// </summary>
		public const string ENNAME_LABEL     = "物料英文名称";
		/// <summary>
		/// 规格型号。
		/// </summary>
		public const string SPECIAL_LABEL = "规格型号";
		/// <summary>
		/// 移动均价。
		/// </summary>
		public const string CSTPRICE_LABEL = "移动均价";
		/// <summary>
		/// 评估价格。
		/// </summary>
		public const string EVAPRICE_LABEL = "评估价格";
		/// <summary>
		/// 订货批量。
		/// </summary>
		public const string ORDBAT_LABEL = "订货批量";
		/// <summary>
		/// 最低库存。
		/// </summary>
		public const string LOWNUM_LABEL = "最低库存";
		/// <summary>
		/// 订货点。
		/// </summary>
		public const string ORDNUM_LABEL = "订货点";
		/// <summary>
		/// 安全库存量。
		/// </summary>
		public const string SAFNUM_LABEL = "安全库存量";
		/// <summary>
		/// 最高库存。
		/// </summary>
		public const string UPPNUM_LABEL = "最高库存";
		/// <summary>
		/// 冻结说明。
		/// </summary>
		public const string FRREMARK_LABEL = "冻结说明";
		/// <summary>
		/// 有效期说明。
		/// </summary>
		public const string ENREMARK_LABEL = "有效期说明";
		/// <summary>
		/// 物料主文件数据实体中的记录数。
		/// </summary>
		public int Count
		{
			get {return this.Tables[ItemData.ITEM_TABLE].Rows.Count;}
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private ItemData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		/// <summary>
		///    ItemData类的构造函数。.  
		/// </summary>
		/// <remarks>通过创建WITM的数据表来初始化一个ItemData的实例。</remarks> 
		public ItemData()
		{
			BuildDataTables();
		}
		/// <summary>
		/// 创建数据表。
		/// </summary>
		private void BuildDataTables()
		{
			//
			// Create the Categories table
			//
			DataTable table   = new DataTable(ITEM_TABLE);
			DataColumnCollection columns = table.Columns;
        
			columns.Add(CODE_FIELD, typeof(System.String));
		    columns.Add(NEWCODE_FIELD, typeof (System.String));
			columns.Add(CNNAME_FIELD, typeof(System.String));
			columns.Add(ENNAME_FIELD, typeof(System.String));
			columns.Add(CATCODE_FIELD, typeof(System.Int16));

			//分类描述
			columns.Add(CatName_Field, typeof(System.String));

			columns.Add(SPECIAL_FIELD, typeof(System.String));
			columns.Add(MACCODE_FIELD, typeof(System.Int16));
			columns.Add(PURMAK_FIELD, typeof(System.String)).DefaultValue=ItemPurMak.PURCHASE_CODE;
			columns.Add(UNITCODE_FIELD, typeof(System.Int16));
			//单位描述	
			columns.Add(UnitName_Field, typeof(System.String));

			columns.Add(STATE_FIELD, typeof(System.String)).DefaultValue=ItemState.ACTIVE_CODE;
			columns.Add(BATCH_FIELD, typeof(System.String)).DefaultValue="N";

			columns.Add(SERIALNO_FIELD, typeof(System.String)).DefaultValue="N";
			columns.Add(CHECKED_FIELD, typeof(System.String)).DefaultValue="Y";
			columns.Add(CHKRPTCODE_FIELD, typeof(System.Int16));
			columns.Add(ABC_FIELD, typeof(System.String));
			columns.Add(CSTPRICE_FIELD, typeof(System.Decimal));
			columns.Add(EVAPRICE_FIELD, typeof(System.Decimal));
			columns.Add(ACCTYPE_FIELD, typeof(System.String)).DefaultValue=ItemAccountType.WAREHOUSE_CODE;
			columns.Add(UPPNUM_FIELD, typeof(System.Decimal));
			columns.Add(LOWNUM_FIELD, typeof(System.Decimal));
			columns.Add(SAFNUM_FIELD, typeof(System.Decimal));

			columns.Add(ORDNUM_FIELD, typeof(System.Decimal));
			columns.Add(ORDBAT_FIELD, typeof(System.Decimal));
			columns.Add(DEFSTO_FIELD, typeof(System.String));
			//仓库描述
			columns.Add(StoName_Field, typeof(System.String));

			columns.Add(DEFCON_FIELD, typeof(System.Int16));
			columns.Add(ConName_Field,typeof(System.String));
			columns.Add(SETENABLE_FIELD, typeof(System.String)).DefaultValue="N";
			columns.Add(ENFRMDATE_FIELD, typeof(System.DateTime));
			columns.Add(ENENDDATE_FIELD, typeof(System.DateTime));
			columns.Add(ENREMARK_FIELD, typeof(System.String));
			columns.Add(SETFREEZED_FIELD, typeof(System.String)).DefaultValue="N";
			columns.Add(FRFRMDATE_FIELD, typeof(System.DateTime));

			columns.Add(FRENDDATE_FIELD, typeof(System.DateTime));
			columns.Add(FRREMARK_FIELD, typeof(System.String));
			columns.Add(PRVCODE_FIELD, typeof(System.String));
			columns.Add(LOCKED_FIELD, typeof(System.String)).DefaultValue="N";
			columns.Add(ITEMNUM_FIELD, typeof(System.Decimal));

			this.Tables.Add(table);
		}
	}
}

       
