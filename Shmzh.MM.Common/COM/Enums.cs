#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
namespace Shmzh.MM.Common
{
	/// <summary>
	/// 单据类型枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class DocType 
	{
		/// <summary>
		/// 采购申请单。
		/// </summary>
		public const int ROS = 1;
		/// <summary>
		/// 物料需求单。
		/// </summary>
		public const int MRP = 2;
		/// <summary>
		/// 采购订单。
		/// </summary>
		public const int PO = 3;
		/// <summary>
		/// 领料单。
		/// </summary>
		public const int DRW = 4;
		/// <summary>
		/// 采购计划。
		/// </summary>
		public const int PP = 5;
		/// <summary>
		/// 采购收料单。
		/// </summary>
		public const int BOR = 6;
		/// <summary>
		/// 采购退料单。
		/// </summary>
		public const int RTV = 7;
		/// <summary>
		/// 生产退料单。
		/// </summary>
		public const int RTS = 8;
		/// <summary>
		/// 收料验收单。
		/// </summary>
		public const int CBR = 9;
		/// <summary>
		/// 转库单。
		/// </summary>
		public const int TRF = 10;
		/// <summary>
		/// 报废单.
		/// </summary>
		public const int SCR = 11;
		/// <summary>
		/// 架位调整单
		/// </summary>
		public const int ADJ = 12;
		/// <summary>
		/// 批次进货单。
		/// </summary>
		public const int BRB = 13;
		/// <summary>
		/// 付款单。
		/// </summary>
		public const int PAY = 14;
		/// <summary>
		/// 委外加工申请单。
		/// </summary>
		public const int WTOW = 16;
		/// <summary>
		/// 委外加工收料单。
		/// </summary>
		public const int WINW = 17;
        /// <summary>
        /// 新物料申请。
        /// </summary>
        public const int WITR = 18;

	    public const int INVENTRYPROFIT = 19;

	    public const int INVENTORYSHORTAGE = 20;
		/// <summary>
		/// 采购撤销单。
		/// </summary>
		public const int CANCEL = 21;

		private DocType() {}
	}
	/// <summary>
	/// 单据的状态枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class DocStatus
	{
		/// <summary>
		/// 新建状态。
		/// </summary>
		public const string New = "N";
		/// <summary>
		/// 提交审批状态。
		/// </summary>
		public const string Present = "P";
		/// <summary>
		/// 已指派。
		/// </summary>
		public const string Assigned = "A";
		/// <summary>
		/// 已作废状态。
		/// </summary>
		public const string Cancel  = "C";
		/// <summary>
		/// 一级审批通过状态。
		/// </summary>
		public const string FstPass = "F";
		/// <summary>
		/// 二级审批通过状态。
		/// </summary>
		public const string SecPass = "S";
        /// <summary>
        /// 三级审批通过状态。这个状态目前只有紧急申购单使用。
        /// </summary>
	    public const string WZPass = "L";
        /// <summary>
        /// 物资审核未通过。
        /// </summary>
	    public const string WZNoPass = "W";
		/// <summary>
		/// 审批通过状态。
		/// </summary>
		public const string TrdPass = "T";
		/// <summary>
		/// 一级审批不通过状态。
		/// </summary>
		public const string FstNoPass = "X";
		/// <summary>
		/// 二级审批不通过状态。
		/// </summary>
		public const string SecNoPass = "Y";
		/// <summary>
		/// 三级审批不通过状态。
		/// </summary>
		public const string TrdNoPass = "Z";
		/// <summary>
		/// 已确认订单状态。
		/// </summary>
		public const string OrdExec = "E";
		/// <summary>
		/// 采购员拒绝采购订单。仓库管理员拒发领料单。
		/// </summary>
		public const string OrdReject = "R";
		/// <summary>
		/// 订单已退回状态。
		/// </summary>
		public const string OrdBack = "B";
		/// <summary>
		/// 已收料状态。
		/// </summary>
		public const string Received = "I";
		/// <summary>
		/// 已付款状态。
		/// </summary>
		public const string Pay = "J";
		/// <summary>
		/// 已发料状态。
		/// </summary>
		public const string Drawed = "O";
		/// <summary>
		/// 已报废状态
		/// </summary>
		public const string Discard ="D";
		/// <summary>
		/// 订单已经完成。
		/// </summary>
		public const string OrdOver = "V";
		/// <summary>
		/// 已生成验收单.
		/// </summary>
		public const string Checked = "K";
		/// <summary>
		/// 已生成收料单.
		/// </summary>
		public const string BOR = "G";
		/// <summary>
		/// 退回状态(采购退货单).
		/// </summary>
		public const string RTV = "H";
		private DocStatus() {}
	}
	/// <summary>
	/// 字段绑定模式枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class ColumnScheme
	{
		/// <summary>
		/// 领料单的字段模式。
		/// </summary>
		public const string DRAW = "DRAW";
		/// <summary>
		/// 领料单制单的绑定模式.
		/// </summary>
		public const string DRAWAuthor = "DRAWAuthor";
		/// <summary>
		/// 委外加工申请单制单模式。
		/// </summary>
		public const string WTOWAuthor = "WTOWAuthor";
		/// <summary>
		/// 委外加工申请单的发料模式。
		/// </summary>
		public const string WTOW = "WTOW";
		/// <summary>
		/// 委外加工收料单。
		/// </summary>
		public const string WINW = "WINW";
		/// <summary>
		/// 委外加工收料单制单模式。
		/// </summary>
		public const string WINWAuthor = "WINWAuthor";
		/// <summary>
		/// 发料时库存架位选择。
		/// </summary>
		public const string CONCHOOSER = "CONCHOOSER";
		/// <summary>
		/// 转库时库存架位选择。
		/// </summary>
		public const string TRANSCHOOSER = "TRANSCHOOSER";
		///<summary>
		///生产退料单模式
		///</summary>
		public const string RTS = "RTS";
		/// <summary>
		/// 生产退料单收料模式
		/// </summary>
		public const string RTSRECEIVE = "RTSRECEIVE";
		/// <summary>
		/// 收料单的字段模式。
		/// </summary>
		public const string BOR = "BOR";
		/// <summary>
		/// 收料单收料的字段模式。
		/// </summary>
		public const string BORRECEIVE = "BORRECEIVE";
		/// <summary>
		/// 采购计划的字段模式。
		/// </summary>
		public const string PP = "PP";
		/// <summary>
		/// 采购订单的字段模式。
		/// </summary>
		public const string PO = "PO";
		/// <summary>
		/// 采购订单数据源。
		/// </summary>
		public const string POS = "POS";
		/// <summary>
		/// 收料单数据源。
		/// </summary>
		public const string PBSA = "PBSA";
		/// <summary>
		/// 收料验收单。
		/// </summary>
		public const string PCBR = "PCBR";
		/// <summary>
		/// 采购申请单。
		/// </summary>
		public const string ROS = "ROS";
		public const string ROSAuthor = "ROSAuthor";
		/// <summary>
		/// 转库单
		/// </summary>
		public const string TRF = "TRF";
		/// <summary>
		/// 报废单
		/// </summary>
		public const string SCR = "SCR";
		/// <summary>
		/// 转库单收料时
		/// </summary>
		public const string TRFIn = "TRFIn";
		/// <summary>
		/// 采购退货单子段绑定模式.
		/// </summary>
		public const string RTV = "RTV";
		/// <summary>
		/// 架位调整模式
		/// </summary>
		public const string ADJ = "ADJ";
		/// <summary>
		/// 采购退货单退货模式.
		/// </summary>
		public const string RTVRECEIVE = "RTVRECEIVE";
		/// <summary>
		/// 批次进料单。
		/// </summary>
		public const string BRB = "BRB";
		/// <summary>
		/// 申请理由和用途
		/// </summary>
		public const string USING = "USING";
		/// <summary>
		/// 采购撤销单。
		/// </summary>
		public const string Cancel = "Cancel";
		private ColumnScheme() {}
	}
	/// <summary>
	/// 下拉列表类型枚举。
	/// </summary>
	public enum SDDLTYPE 
	{
		PURMAK = 1,			//制购
		CATEGORY = 2,		//目录
		ITEMSTATE = 3,		//物料状态
		UNIT = 4,			//单位
		ABC = 5,			//ABC分类
		ACCOUNT = 6,		//科目
		STORAGE = 7,		//仓库
		CONTAINER = 8,		//架位
		CHECKREPORT = 9,	//检验报告
		VENDOR = 10,		//供应商
		VCTYPE = 11,		//供应商客户类别
		VCSTATUS = 12,		//供应商客户状态
		VCAPPROVE = 13,		//供应商客户已核准
		CURRENCY = 14,		//货币代码
		PAYSTYLE = 15,		//付款方式
		USER = 16,			//用户
		PURPOSE = 17,		//用途
		PSLP = 18,			//采购员
		DEPT = 19,			//部门
		ITEMQUERY = 20,		//物料查询条件。
		ACAT = 21,			//不包含未分类的分类列表。
		ENTRYSTATE = 22,	//单据状态。
		YEAR = 23,			//年份。
		MONTH = 24,			//月份。
		TAX = 25,           //税码。
		//***DXJ增加***
		CPTY = 26,			//合同付款性质。
		CPMM = 27,			//合同付款阶段。
		CPMS = 28,			//合同阶段付款标志。
		CTYP = 29,			//合同类型。
       
		//***END***
		STOMANAGER = 30,	//仓库管理员。
		OWNDEPT = 31,       //有权操作的部门。
		QRYSLT = 32,        //查询方案。
		UCLIST = 33,        //申请理由及用途的分类。
		YLORDER=34,			//液铝相关的订单列表。
		CheckResult=35,		//验收结果。
		Drawer=36,			//领料人。
		Classify=37,		//用途分类.
		YCL=38,				//治水原材料
		VendorType = 39,	//供应商分类。
        CMPT = 40,           //资金性质
        SingningLocation = 41,          //签约地点
		Performance = 42,      //履约情况
        AllDept = 43        //所有有效部门

	};
	/// <summary>
	/// 供应商类型。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class PprnType
	{
		/// <summary>
		/// 供应商。
		/// </summary>
		public const string Vendor = "V";//供应商。
		/// <summary>
		/// 本单位。
		/// </summary>
		public const string Self = "I";//本单位.
		/// <summary>
		/// OTA供应商。
		/// </summary>
		public const string OTAVendor = "O";//OTA供应商。
		private PprnType() {}
	}

    /*
	/// <summary>
	/// 供应商状态枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class PprnStatus
	{
		/// <summary>
		/// 活动的。
		/// </summary>
		public const string Active = "A";//活动的。
		/// <summary>
		/// 不活动的。
		/// </summary>
		public const string NoActive = "I";//不活动的。
		/// <summary>
		/// 逐步淘汰的。
		/// </summary>
		public const string DisUse = "P";//逐步淘汰的。
		private PprnStatus() {}
	}*/
	/// <summary>
	/// 单据操作动作的枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class OP
	{
        public const string View = "View";//查看。
		/// <summary>
		/// 新建。
		/// </summary>
		public const string New = "New";//新建。

        public const string Copy = "Copy";//复制。
		/// <summary>
		/// 新建并提交。
		/// </summary>
		public const string NewAndPresent = "NP";//新建并提交。
		/// <summary>
		/// 新建并指派。
		/// </summary>
		public const string NewAndAssign = "NA";//新建并指派。
		/// <summary>
		/// 修改。
		/// </summary>
		public const string Edit = "Edit";//修改。
		/// <summary>
		/// 修改并提交。
		/// </summary>
		public const string EditAndPresent = "EP";//修改并提交。
		/// <summary>
		/// 修改并指派。
		/// </summary>
		public const string EditAndAssign = "EA";//修改并指派。
		/// <summary>
		/// 提交。
		/// </summary>
		public const string Submit = "Submit";//提交。
		/// <summary>
		/// 指派。
		/// </summary>
		public const string Assigned = "Assigned";//指派。
		/// <summary>
		/// //作废。
		/// </summary>
		public const string Cancel = "Cancel";//作废。
		/// <summary>
		/// 一级审批。
		/// </summary>
		public const string FirstAudit = "FirstAudit";//一级审批。
		/// <summary>
		/// 二级审批。
		/// </summary>
		public const string SecondAudit = "SecondAudit";//二级审批。
		/// <summary>
		/// 三级审批。
		/// </summary>
		public const string ThirdAudit = "ThirdAudit";//三级审批。
        /// <summary>
        /// 物资审核
        /// </summary>
	    public const string WZAudit = "WZAudit";//物资审核。
		/// <summary>
		/// 检验。
		/// </summary>
		public const string Check = "Check";//检验。
		/// <summary>
		/// 生成采购收料单。
		/// </summary>
		public const string Bor = "Bor";//生成采购收料单。
		/// <summary>
		/// 确认。
		/// </summary>
		public const string Affirm = "Affirm";//确认。
		/// <summary>
		/// 拒绝。
		/// </summary>
		public const string Reject = "Reject";//拒绝。
		/// <summary>
		/// 收料。
		/// </summary>
		public const string I = "In";//收料。
		/// <summary>
		/// 发料。
		/// </summary>
		public const string O = "Out";//发料。
		/// <summary>
		/// 转库。
		/// </summary>
		public const string Trans = "Trans";//转库。		
		/// <summary>
		/// 报废。
		/// </summary>
		public const string Discard ="Discard";//报废。
		/// <summary>
		/// 架位调整。
		/// </summary>
		public const string Adjust = "Adjust";//架位调整。
		/// <summary>
		/// 红字。
		/// </summary>
		public const string Red = "Red";//红字。
		/// <summary>
		/// 删除。
		/// </summary>
		public const string Delete = "Del";//删除.
		/// <summary>
		/// 付款。
		/// </summary>
		public const string Pay = "Pay";
		/// <summary>
		/// 拒绝付款。
		/// </summary>
		public const string NoPay ="NoPay";
		private OP() {}
	}
	/// <summary>
	/// 单据的操作按钮的显示名称枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class OPName
	{
		/// <summary>
		/// 新建。
		/// </summary>
		public const string New = "保存";
		/// <summary>
		/// 编辑。
		/// </summary>
		public const string Edit = "保存";
		/// <summary>
		/// 提交。
		/// </summary>
		public const string Submit = "提交";
		/// <summary>
		/// 指派。
		/// </summary>
		public const string Assigned = "指派";
		/// <summary>
		/// 作废。
		/// </summary>
		public const string Cancel = "作废";
		/// <summary>
		/// 一级审批。
		/// </summary>
		public const string FirstAudit = "确定";
		/// <summary>
		/// 二级审批。
		/// </summary>
		public const string SecondAudit = "确定";
		/// <summary>
		/// 三级审批。
		/// </summary>
		public const string ThirdAudit = "确定";
		/// <summary>
		/// 收料。
		/// </summary>
		public const string I = "收料";
		/// <summary>
		/// 发料。
		/// </summary>
		public const string O = "发料";
		/// <summary>
		/// 报废。
		/// </summary>
		public const string Discard = "报废";
		/// <summary>
		/// 转库。
		/// </summary>
		public const string Trans = "转库";
		/// <summary>
		/// 确认。
		/// </summary>
		public const string Affirm = "确认";
		/// <summary>
		/// 拒绝。
		/// </summary>
		public const string Reject = "拒绝";
		/// <summary>
		/// 生成验收单。
		/// </summary>
		public const string Check = "生成验收单";
		/// <summary>
		/// 生成收料单。
		/// </summary>
		public const string Bor = "生成收料单";

        /// <summary>
        /// 物资审核。
        /// </summary>
	    public const string WZAudit = "确定";
		private OPName() {}
	}
	/// <summary>
	/// Session结构枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class MySession
	{
       
		/// <summary>
		/// User对象。
		/// </summary>
		public const string User = "User";
		/// <summary>
		/// 用户工号。
		/// </summary>
		public const string UserCode = "USERCODE";
		/// <summary>
		/// 用户姓名。
		/// </summary>
		public const string UserName = "USERNAME";
		/// <summary>
		/// 用户登录名。
		/// </summary>
		public const string UserLoginId = "LOGINID";
		/// <summary>
		/// 用户所属部门编号。
		/// </summary>
		public const string DeptCode = "USERDEPTCODE";
		/// <summary>
		/// 用户所述部门名称。
		/// </summary>
		public const string DeptName = "USERDEPTNAME";
         
		/// <summary>
		/// 采购收料单的DT。
		/// </summary>
		public const string BOR_DT = "BOR_DT";
		/// <summary>
		/// 领料单的DT。
		/// </summary>
		public const string DRW_DT = "DRW_DT";
		/// <summary>
		/// 采购申请单的DT。
		/// </summary>
		public const string ROS_DT = "ROS_DT";
		/// <summary>
		/// 物料需求单的DT。
		/// </summary>
		public const string MRP_DT = "MRP_DT";
		/// <summary>
		/// 采购计划的DT。
		/// </summary>
		public const string PP_DT  = "PP_DT";
		/// <summary>
		/// 采购订单的DT。
		/// </summary>
		public const string ORD_DT = "ORD_DT";
		/// <summary>
		/// 批次进货单的DT。
		/// </summary>
		public const string BRB_DT = "BRB_DT";
		/// <summary>
		/// 收料验收单的DT。
		/// </summary>
		public const string CBR_DT = "CBR_DT";
		/// <summary>
		/// 采购退货单的DT。
		/// </summary>
		public const string RTV_DT = "RTV_DT";
		/// <summary>
		/// 生产退料单的DT。
		/// </summary>
		public const string RTS_DT = "RTS_DT";
		/// <summary>
		/// 报废单的DT。
		/// </summary>
		public const string SCR_DT = "SCR_DT";
		/// <summary>
		/// 转库单的DT。
		/// </summary>
		public const string TRF_DT = "TRF_DT";
		/// <summary>
		/// 转库单转入的DT.
		/// </summary>
		public const string TRFIN_DT = "TRFIN_DT";
		/// <summary>
		/// 架位调整单的DT。
		/// </summary>
		public const string ADJ_DT = "ADJ_DT";
		/// <summary>
		/// 架位选择。
		/// </summary>
		public const string CONCHOOSER_DT = "CONCHOOSE";
		/// <summary>
		/// 发料单的静态数据表。
		/// </summary>
		public const string DrawDt = "DrawDt";
		/// <summary>
		/// 收料单的静态数据表。
		/// </summary>
		public const string ReceiveDt = "ReceiveDt";
		//		public const string TransDt = "TransDt";
		public const string Help = "HelpCode";
		/// <summary>
		/// 委外加工申请单静态数据表。
		/// </summary>
		public const string WTOW_DT = "WTOWDt";
		/// <summary>
		/// 委外加工收料单收料表静态数据表。
		/// </summary>
		public const string WDIW_DT = "WDIWDt";
		/// <summary>
		/// 委外加工收料单消耗表静态数据表
		/// </summary>
		public const string WRES_DT = "WRESDt";
		public const string Cancel_DT = "Cancel";
		private MySession() {}
	}
	/// <summary>
	/// 审批结果的枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class AuditResult
	{
		/// <summary>
		/// 审批通过。
		/// </summary>
		public const string Passed = "Y";
		/// <summary>
		/// 审批不通过。
		/// </summary>
		public const string NoPassed = "N";
		/// <summary>
		/// AuditResult的构造函数。
		/// </summary>
		private AuditResult() {}
	}
	/// <summary>
	/// 查询方案参数枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class QryParam
	{
		/// <summary>
		/// 下拉列表对象，例如：部门，仓库等。
		/// </summary>
		public const string ModuleTag = "ModuleTag";
		/// <summary>
		/// 用户登录名。
		/// </summary>
		public const string UserCode = "UserCode";
		/// <summary>
		/// 是否每次页面刷新时清空下拉列表。
		/// </summary>
		public const string IsClear = "IsClear";
		/// <summary>
		/// 单据类型。
		/// </summary>
		public const string DocType = "DocType";
	}

	/// <summary>
	/// 查询方案中的参数枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class MyParm
	{
		/// <summary>
		/// 空的SQL语句。
		/// </summary>
		public const string  NON_SQL = "-1";
	}
	/// <summary>
	/// 查询模块。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class QRYModule
	{
		/// <summary>
		/// 采购申请单。
		/// </summary>
		public const int ROS = 101;
		/// <summary>
		/// 物料需求单。
		/// </summary>
		public const int MRP = 102;
		/// <summary>
		/// 采购计划
		/// </summary>
		public const int PP = 103;
		/// <summary>
		/// 采购订单
		/// </summary>
		public const int PO = 104;
		/// <summary>
		/// 采购收料
		/// </summary>
		public const int PBOR = 105;
		/// <summary>
		/// 采购退货
		/// </summary>
		public const int PRTV = 106;
		/// <summary>
		/// 采购合同
		/// </summary>
		public const int PCTR = 107;
		/// <summary>
		/// 采购撤销单
		/// </summary>
		public const int Cancel = 108;
		/// <summary>
		/// 供应商主文件
		/// </summary>
		public const int PPRN = 201;
		/// <summary>
		/// 物料主文件
		/// </summary>
		public const int ITEM = 301;
		/// <summary>
		/// 领料单
		/// </summary>
		public const int DRW = 302;
		/// <summary>
		/// 收料
		/// </summary>
		public const int PIN = 303;
		/// <summary>
		/// 发料
		/// </summary>
		public const int OUT = 304;
		/// <summary>
		/// 库存查询
		/// </summary>
		public const int STOCK = 305;
		/// <summary>
		/// 架位调整
		/// </summary>
		public const int ADJ = 306;
		/// <summary>
		/// 转库
		/// </summary>
		public const int TRF = 306;
		/// <summary>
		/// 生产退料单
		/// </summary>
		public const int RTS = 309;
		/// <summary>
		/// 报废单
		/// </summary>
		public const int SCR = 310;
		/// <summary>
		/// 批量进货单
		/// </summary>
		public const int BRB = 320;
		/// <summary>
		/// 批量出货单。
		/// </summary>
		public const int BDB = 330;
		/// <summary>
		/// 用途。
		/// </summary>
		public const int USE = 340;
		/// <summary>
		/// 原材料。
		/// </summary>
		public const int YCL = 350;
		/// <summary>
		/// 委外加工申请单。
		/// </summary>
		public const int WTOW = 360;
		/// <summary>
		/// 委外加工收料单。
		/// </summary>
		public const int WINW = 370;
		/// <summary>
		/// 付款。
		/// </summary>
		public const int PPAY = 380;
	}
	/// <summary>
	/// 报表类型。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class ReportType
	{
		private ReportType() {}
		/// <summary>
		/// 期初库存盘点报表。
		/// </summary>
		public const string StartMAIO_Report = "StartKCPD";
		/// <summary>
		/// 期初库存盘点表按账册方式。
		/// </summary>
		public const string StartMAIOByCat_Report = "StartMAIOByCat";
		/// <summary>
		/// 期初库存盘点的盘盈盘亏数据分布报表。
		/// </summary>
		public const string StartMAIO_Chart = "StartKCPDChart";
		/// <summary>
		/// 6月底库存盘点对照表。
		/// </summary>
		public const string StartMAIO_Compare = "Cat6value";
		/// <summary>
		/// 物料库存清单
		/// </summary>
		public const string Stock_Report = "Stock";
		/// <summary>
		/// 物料收发明细表
		/// </summary>
		public const string Material_IO_Detail_Report = "Material_IO_Detail";
		/// <summary>
		/// 仓库期末收发存报表。
		/// </summary>
		public const string StockSIOE_Report = "StockSIOE";
		/// <summary>
		/// 账本的收发汇总表。
		/// </summary>
		public const string ZBSIOETotal_Report = "ZBSIOETotal";
		/// <summary>
		/// 材料收发存汇总表(赵雅芳)
		/// </summary>
		public const string ZBGroupSIOETotal_Report = "ZBGroupSIOETotal_Report";
		/// <summary>
		/// 发出材料分级明细表。
		/// </summary>
		public const string Fin_OutFJHZB_Report = "Fin_OutFJHZB";
		/// <summary>
		/// 发出材料分级汇总表。
		/// </summary>
		public const string Fin_OutFJHZB_Group_Report = "Fin_OutFJHZB_Group";
		/// <summary>
		/// 发票明细。
		/// </summary>
		public const string InvDetail_Report = "BorDetailByInvoice";
		/// <summary>
		/// 多余库存分析报表。
		/// </summary>
		public const string StockQuestion_Report = "StockQuestion";
		/// <summary>
		/// 新版库存分析。
		/// </summary>
		public const string StockQuestionNew_Report = "StockQuestionNew";
		/// <summary>
		/// 合同
		/// </summary>
		public const string Contract_Report = "Contracts";
		/// <summary>
		/// 超期库存。
		/// </summary>
		public const string ExtendedStock_Report = "ExtendedStock";
		/// <summary>
		/// 大宗物品的采购跟踪报表。
		/// </summary>
		public const string BigItemTrace_Report = "BigItemTrace";
		/// <summary>
		/// 项目采购物料分析报表。
		/// </summary>
		public const string ProjectItemAnalysis_Report="ProjectItemAnalysis";
        /// <summary>
        /// 项目采购物料分析报表。
        /// </summary>
        public const string ProjectStuffAnalysis_Report = "ProjecStuffAnalysis";
	
		/// <summary>
		/// 低值易耗品的领用分布报表。
		/// </summary>
		public const string LEECDist_Report = "LEECDistReport";
	}
	/// <summary>
	/// 报表路径。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class ReportPath
	{
		private ReportPath() {}
		/// <summary>
		/// 期初库存盘点报表的路径。
		/// </summary>
		public const string StartMAIO_ReportPath = "/MMReports/MAIOResult";
		/// <summary>
		/// 期初库存盘点报表的路径。(账册方式)
		/// </summary>
		public const string StartMAIOByCat_ReportPath = "/MMReports/MAIOResultByCat";
		/// <summary>
		/// 仓库期末收发存报表的路径。
		/// </summary>
		public const string StockSIOE_ReportPath = "/MMReports/StockSIOE";

        public const string StockSIOE_ReportZeroPath = "/MMReports/StockSIOEZero";
		/// <summary>
		/// 库存盘点盘盈盘亏数据分布图报表的路径。
		/// </summary>
		public const string StartMAIO_ChartPath = "/MMReports/MAIOYKRecord"; 
		/// <summary>
		/// 6月底库存盘点对照表。
		/// </summary>
		public const string StartMAIO_ComparePath = "/MMReports/Cat6Value";
		/// <summary>
		/// 物料库存清单。
		/// </summary>
		public const string Stock_ReportPath = "/MMReports/Stock";
		/// <summary>
		/// 物料收发明细表。
		/// </summary>
		public const string Material_IO_Detail_ReportPath = "/MMReports/Material_IO_Detail_Report";
		/// <summary>
		/// 账本的收发汇总表。
		/// </summary>
		public const string ZBSIOETotal_ReportPath = "/MMReports/ZBSIOETotal";
		/// <summary>
		/// 材料收发存汇总表。(赵雅芳)
		/// </summary>
		public const string ZBGroupSIOETotal_ReportPath = "/MMReports/ZBGroupSIOETotal";
		/// <summary>
		/// 发出材料分级明细表。
		/// </summary>
		public const string Fin_OutFJHZB_ReportPath = "/MMReports/Fin_OutFJHZBNew";
		/// <summary>
		/// 发出材料分级汇总表。
		/// </summary>
		public const string Fin_OutFJHZB_Group_ReportPath = "/MMReports/Fin_OutFJHZB_GroupNew";
		/// <summary>
		/// 发票明细清单。
		/// </summary>
		public const string InvDetail_ReportPath = "/MMReports/BorDetailByInvoice";
		/// <summary>
		/// 多余库存分析。
		/// </summary>
		public const string StockQuestion_ReportPath = "/MMReports/StockQuestion";
		/// <summary>
		/// 新版库存分析。
		/// </summary>
		public const string StockQuestionNew_ReportPath = "/MMReports/StockQuestionNew";
		/// <summary>
		/// 合同。
		/// </summary>
		public const string Contract_ReportPath = "/MMReports/Contracts";
		/// <summary>
		/// 超期库存。
		/// </summary>
		public const string ExtendedStock_ReportPath = "/MMReports/ExtendedStock";
		/// <summary>
		/// 大宗物品采购跟踪分析报表。
		/// </summary>
		public const string BigItemTrace_ReportPath = "/MMReports/BigItemTrace";
		/// <summary>
		/// 项目采购物料分析报表。
		/// </summary>
		public const string ProjectItemAnalysis_ReportPath = "/MMReports/ProjectItemAnalysis";

        /// <summary>
        /// 采购收料分析表。
        /// </summary>
        public const string ProjectStuffAnalysis_ReportPath = "/MMReports/ProjecStuffAnalysis";
		

		/// <summary>
		/// 低值易耗品的领用分布报表。
		/// </summary>
		public const string LEECDist_ReportPath = "/MMReports/LEECDistReport";
	}
    /*
	/// <summary>
	/// 有关权限的枚举。
	/// </summary>
	public sealed class SysRight
	{
		/// <summary>
		/// 无权操作的警告信息．
		/// </summary>
		public const string NoRight = "对不起，您无权进行此操作！";
		/// <summary>
		/// 物料分类浏览
		/// </summary>
		public const int CategoryBrowser = 300;
		/// <summary>
		/// 物料分类新增
		/// </summary>
		public const int CategoryAdd = 310;
		/// <summary>
		/// 物料分类修改
		/// </summary>
		public const int CategoryEdit = 320;
		/// <summary>
		/// 物料分类复制
		/// </summary>
		public const int CategoryCopy = 330;
		/// <summary>
		/// 物料分类删除
		/// </summary>
		public const int CategoryDelete = 340;
		/// <summary>
		/// 物料浏览
		/// </summary>
		public const int ItemBrowser = 350;
		/// <summary>
		/// 物料新增
		/// </summary>
		public const int ItemAdd = 360;
		/// <summary>
		/// 物料修改
		/// </summary>
		public const int ItemEdit = 370;
		/// <summary>
		/// 物料删除
		/// </summary>
		public const int ItemDelete = 380;
		/// <summary>
		/// 物料复制
		/// </summary>
		public const int ItemCopy = 390;
		/// <summary>
		/// 采购申请单浏览
		/// </summary>
		public const int ROSBrowser = 400;
		/// <summary>
		/// 采购申请单新建
		/// </summary>
		public const int ROSAdd = 410;
		/// <summary>
		/// 采购申请单修改
		/// </summary>
		public const int ROSEdit = 420;
		/// <summary>
		/// 采购申请单删除
		/// </summary>
		public const int ROSDelete = 430;
		/// <summary>
		/// 采购申请单作废
		/// </summary>
		public const int ROSCancel = 440;
		/// <summary>
		/// 采购申请单提交
		/// </summary>
		public const int ROSPresent = 450;
		/// <summary>
		/// 采购申请单一级审批
		/// </summary>
		public const int ROSFirstAudit = 460;
		/// <summary>
		/// 采购申请单二级审批
		/// </summary>
		public const int ROSSecondAudit = 470;
		/// <summary>
		/// 采购申请单三级审批
		/// </summary>
		public const int ROSThirdAudit = 480;
		/// <summary>
		/// 物料需求单浏览
		/// </summary>
		public const int MRPBrowser = 490;
		/// <summary>
		/// 物料需求单新建
		/// </summary>
		public const int MRPAdd = 500;
		/// <summary>
		/// 物料需求单修改
		/// </summary>
		public const int MRPEdit = 510;
		/// <summary>
		/// 物料需求单删除
		/// </summary>
		public const int MRPDelete = 520;
		/// <summary>
		/// 物料需求单作废
		/// </summary>
		public const int MRPCancel = 530;
		/// <summary>
		/// 物料需求单提交
		/// </summary>
		public const int MRPPresent = 540;
		/// <summary>
		/// 物料需求单一级审批
		/// </summary>
		public const int MRPFirstAudit = 550;
		/// <summary>
		/// 物料需求单二级审批
		/// </summary>
		public const int MRPSecondAudit = 560;
		/// <summary>
		/// 物料需求单三级审批
		/// </summary>
		public const int MRPThirdAudit = 570;
		/// <summary>
		/// 采购计划浏览
		/// </summary>
		public const int PPBrowser = 580;
		/// <summary>
		/// 采购计划新建
		/// </summary>
		public const int PPAdd = 590;
		/// <summary>
		/// 采购计划修改
		/// </summary>
		public const int PPEdit = 600;
		/// <summary>
		/// 采购计划删除
		/// </summary>
		public const int PPDelete = 610;
		/// <summary>
		/// 采购计划作废
		/// </summary>
		public const int PPCancel = 620;
		/// <summary>
		/// 采购计划提交
		/// </summary>
		public const int PPPresent = 630;
		/// <summary>
		/// 采购计划一级审批
		/// </summary>
		public const int PPFirstAudit = 640;
		/// <summary>
		/// 采购计划二级审批
		/// </summary>
		public const int PPSecondAudit = 650;
		/// <summary>
		/// 采购计划三级审批
		/// </summary>
		public const int PPThirdAudit = 660;
		/// <summary>
		/// 采购订单浏览
		/// </summary>
		public const int POBrowser = 670;
		/// <summary>
		/// 采购订单新建
		/// </summary>
		public const int POAdd = 680;
		/// <summary>
		/// 采购订单修改
		/// </summary>
		public const int POEdit = 690;
		/// <summary>
		/// 采购订单删除
		/// </summary>
		public const int PODelete = 700;
		/// <summary>
		/// 采购订单作废
		/// </summary>
		public const int POCancel = 710;
		/// <summary>
		/// 采购订单提交
		/// </summary>
		public const int POPresent = 720;
		/// <summary>
		/// 采购订单指派
		/// </summary>
		public const int POAssign = 730;
		/// <summary>
		/// 采购订单采购确认
		/// </summary>
		public const int POConfirm = 740;
		/// <summary>
		/// 采购订单一级审批
		/// </summary>
		public const int POFirstAudit = 750;
		/// <summary>
		/// 采购订单二级审批
		/// </summary>
		public const int POSecondAudit = 760;
		/// <summary>
		/// 采购订单三级审批
		/// </summary>
		public const int POThirdAudit = 770;
		/// <summary>
		/// 采购收料单浏览
		/// </summary>
		public const int BORBrowser = 780;
		/// <summary>
		/// 采购收料单新建
		/// </summary>
		public const int BORAdd = 790;
		/// <summary>
		/// 采购收料单修改
		/// </summary>
		public const int BOREdit = 800;
		/// <summary>
		/// 采购收料单删除
		/// </summary>
		public const int BORDelete = 810;
		/// <summary>
		/// 采购收料单作废
		/// </summary>
		public const int BORCancel = 820;
		/// <summary>
		/// 采购收料单提交
		/// </summary>
		public const int BORPresent = 830;
		/// <summary>
		/// 采购收料单一级审批
		/// </summary>
		public const int BORFirstAudit = 840;
		/// <summary>
		/// 采购收料单二级审批
		/// </summary>
		public const int BORSecondAudit = 850;
		/// <summary>
		/// 采购收料单三级审批
		/// </summary>
		public const int BORThirdAudit = 860;
		/// <summary>
		/// 领料单浏览
		/// </summary>
		public const int DRWBrowser = 870;
		/// <summary>
		/// 领料单新建
		/// </summary>
		public const int DRWAdd = 880;
		/// <summary>
		/// 领料单修改
		/// </summary>
		public const int DRWEdit = 890;
		/// <summary>
		/// 领料单删除
		/// </summary>
		public const int DRWDelete = 900;
		/// <summary>
		/// 领料单作废
		/// </summary>
		public const int DRWCancel = 910;
		/// <summary>
		/// 领料单提交
		/// </summary>
		public const int DRWPresent = 920;
		/// <summary>
		/// 领料单一级审批
		/// </summary>
		public const int DRWFirstAudit = 930;
		/// <summary>
		/// 领料单二级审批
		/// </summary>
		public const int DRWSecondAudit = 940;
		/// <summary>
		/// 领料单三级审批
		/// </summary>
		public const int DRWThirdAudit = 950;
		/// <summary>
		/// 收料
		/// </summary>
		public const int StockIn = 960;
		/// <summary>
		/// 发料
		/// </summary>
		public const int StockOut = 970;
		/// <summary>
		/// 库存查询
		/// </summary>
		public const int StockBrowser = 980;
		/// <summary>
		/// 合同台帐浏览
		/// </summary>
		public const int ContractBrowser = 990;
		/// <summary>
		/// 合同台帐新建
		/// </summary>
		public const int ContractAdd = 1000;
		/// <summary>
		/// 合同台帐修改
		/// </summary>
		public const int ContractEdit = 1010;
		/// <summary>
		/// 合同台帐作废
		/// </summary>
		public const int ContractCancel = 1020;
		/// <summary>
		/// 供应商浏览
		/// </summary>
		public const int VendorBrowser = 1030;
		/// <summary>
		/// 供应商新建
		/// </summary>
		public const int VendorAdd = 1040;
		/// <summary>
		/// 供应商修改
		/// </summary>
		public const int VendorEdit = 1050;
		/// <summary>
		/// 供应商删除
		/// </summary>
		public const int VendorDelete = 1060;
		/// <summary>
		/// 验收单浏览
		/// </summary>
		public const int CBRBrowser = 1070;
		/// <summary>
		/// 验收单新建
		/// </summary>
		public const int CBRAdd = 1080;
		/// <summary>
		/// 验收单提交
		/// </summary>
		public const int CBRPresent = 1090;
		/// <summary>
		/// 验收单修改
		/// </summary>
		public const int CBREdit = 1100;
		/// <summary>
		/// 验收单删除
		/// </summary>
		public const int CBRDelete = 1110;
		/// <summary>
		/// 验收单作废
		/// </summary>
		public const int CBRCancel = 1120;
		/// <summary>
		/// 验收单一级审批
		/// </summary>
		public const int CBRFirstAudit = 1130;
		/// <summary>
		/// 验收单二级审批
		/// </summary>
		public const int CBRSecondAudit = 1140;
		/// <summary>
		/// 验收单三级审批
		/// </summary>
		public const int CBRThirdAudit = 1150;
		/// <summary>
		/// 采购退货单浏览
		/// </summary>
		public const int RTVBrowser = 1160;
		/// <summary>
		/// 采购退货单新建
		/// </summary>
		public const int RTVAdd = 1170;
		/// <summary>
		/// 采购退货单提交
		/// </summary>
		public const int RTVPresent = 1180;
		/// <summary>
		/// 采购退货单修改
		/// </summary>
		public const int RTVEdit = 1190;
		/// <summary>
		/// 采购退货单删除
		/// </summary>
		public const int RTVDelete = 1200;
		/// <summary>
		/// 采购退货单作废
		/// </summary>
		public const int RTVCancel = 1210;
		/// <summary>
		/// 采购退货单一级审批
		/// </summary>
		public const int RTVFirstAudit = 1220;
		/// <summary>
		/// 采购退货单二级审批
		/// </summary>
		public const int RTVSecondAudit = 1230;
		/// <summary>
		/// 采购退货单三级审批
		/// </summary>
		public const int RTVThirdAudit = 1240;
		/// <summary>
		/// 生产退料单浏览
		/// </summary>
		public const int RTSBrowser = 1250;
		/// <summary>
		/// 生产退料单新建
		/// </summary>
		public const int RTSAdd = 1260;
		/// <summary>
		/// 生产退料单提交
		/// </summary>
		public const int RTSPresent = 1270;
		/// <summary>
		/// 生产退料单修改
		/// </summary>
		public const int RTSEdit = 1280;
		/// <summary>
		/// 生产退料单删除
		/// </summary>
		public const int RTSDelete = 1290;
		/// <summary>
		/// 生产退料单作废
		/// </summary>
		public const int RTSCancel = 1300;
		/// <summary>
		/// 生产退料单一级审批
		/// </summary>
		public const int RTSFirstAudit = 1310;
		/// <summary>
		/// 生产退料单二级审批
		/// </summary>
		public const int RTSSecondAudit = 1320;
		/// <summary>
		/// 生产退料单三级审批
		/// </summary>
		public const int RTSThirdAudit = 1330;
		/// <summary>
		/// 转库单浏览
		/// </summary>
		public const int TRFBrowser = 1340;
		/// <summary>
		/// 转库单新建
		/// </summary>
		public const int TRFAdd = 1350;
		/// <summary>
		/// 转库单提交
		/// </summary>
		public const int TRFPresent = 1360;
		/// <summary>
		/// 转库单修改
		/// </summary>
		public const int TRFEdit = 1370;
		/// <summary>
		/// 转库单删除
		/// </summary>
		public const int TRFDelete = 1380;
		/// <summary>
		/// 转库单作废
		/// </summary>
		public const int TRFCancel = 1390;
		/// <summary>
		/// 转库单一级审批
		/// </summary>
		public const int TRFFirstAudit = 1400;
		/// <summary>
		/// 转库单二级审批
		/// </summary>
		public const int TRFSecondAudit = 1410;
		/// <summary>
		/// 转库单三级审批
		/// </summary>
		public const int TRFThirdAudit = 1420;
		/// <summary>
		/// 报废单浏览
		/// </summary>
		public const int SCRBrowser = 1430;
		/// <summary>
		/// 报废单新建
		/// </summary>
		public const int SCRAdd = 1440;
		/// <summary>
		/// 报废单提交
		/// </summary>
		public const int SCRPresent = 1450;
		/// <summary>
		/// 报废单修改
		/// </summary>
		public const int SCREdit = 1460;
		/// <summary>
		/// 报废单删除
		/// </summary>
		public const int SCRDelete = 1470;
		/// <summary>
		/// 报废单作废
		/// </summary>
		public const int SCRCancel = 1480;
		/// <summary>
		/// 报废单一级审批
		/// </summary>
		public const int SCRFirstAudit = 1490;
		/// <summary>
		/// 报废单二级审批
		/// </summary>
		public const int SCRSecondAudit = 1500;
		/// <summary>
		/// 报废单三级审批
		/// </summary>
		public const int SCRThirdAudit = 1510;
		/// <summary>
		/// 用途浏览
		/// </summary>
		public const int PurposeBrowser = 1520;
		/// <summary>
		/// 用途新建
		/// </summary>
		public const int PurposeAdd = 1530;
		/// <summary>
		/// 用途修改
		/// </summary>
		public const int PurposeEdit = 1540;
		/// <summary>
		/// 用途复制
		/// </summary>
		public const int PurposeCopy = 1550;
		/// <summary>
		/// 用途删除
		/// </summary>
		public const int PurposeDelete = 1560;
		/// <summary>
		/// 仓库浏览
		/// </summary>
		public const int StoBrowser = 1570;
		/// <summary>
		/// 仓库新建
		/// </summary>
		public const int StoAdd = 1580;
		/// <summary>
		/// 仓库修改
		/// </summary>
		public const int StoEdit = 1590;
		/// <summary>
		/// 仓库复制
		/// </summary>
		public const int StoCopy = 1600;
		/// <summary>
		/// 仓库删除
		/// </summary>
		public const int StoDelete = 1610;
		/// <summary>
		/// 架位浏览
		/// </summary>
		public const int ConBrowser = 1620;
		/// <summary>
		/// 架位新建
		/// </summary>
		public const int ConAdd = 1630;
		/// <summary>
		/// 架位修改
		/// </summary>
		public const int ConEdit = 1640;
		/// <summary>
		/// 架位复制
		/// </summary>
		public const int ConCopy = 1650;
		/// <summary>
		/// 架位删除
		/// </summary>
		public const int ConDelete = 1660;
		/// <summary>
		/// 仓库管理员浏览
		/// </summary>
		public const int StoManagerBrowser = 1670;
		/// <summary>
		/// 仓库管理员新建
		/// </summary>
		public const int StoManagerAdd = 1680;
		/// <summary>
		/// 仓库管理员修改
		/// </summary>
		public const int StoManagerEdit = 1690;
		/// <summary>
		/// 仓库管理员复制
		/// </summary>
		public const int StoManagerCopy = 1700;
		/// <summary>
		/// 仓库管理员删除
		/// </summary>
		public const int StoManagerDelete = 1710;
		/// <summary>
		/// 计量单位浏览
		/// </summary>
		public const int UnitBrowser = 1720;
		/// <summary>
		/// 计量单位新建
		/// </summary>
		public const int UnitAdd = 1730;
		/// <summary>
		/// 计量单位修改
		/// </summary>
		public const int UnitEdit = 1740;
		/// <summary>
		/// 计量单位复制
		/// </summary>
		public const int UnitCopy = 1750;
		/// <summary>
		/// 计量单位删除
		/// </summary>
		public const int UnitDelete = 1760;
		/// <summary>
		/// 采购员浏览
		/// </summary>
		public const int BuyerBrowser = 1770;
		/// <summary>
		/// 采购员新建
		/// </summary>
		public const int BuyerAdd = 1780;
		/// <summary>
		/// 采购员修改
		/// </summary>
		public const int BuyerEdit = 1790;
		/// <summary>
		/// 采购员复制
		/// </summary>
		public const int BuyerCopy = 1800;
		/// <summary>
		/// 采购员删除
		/// </summary>
		public const int BuyerDelete = 1810;
		/// <summary>
		/// 合同类型浏览
		/// </summary>
		public const int ContractTypeBrowser = 1820;
		/// <summary>
		/// 合同类型新建
		/// </summary>
		public const int ContractTypeAdd = 1830;
		/// <summary>
		/// 合同类型修改
		/// </summary>
		public const int ContractTypeEdit = 1840;
		/// <summary>
		/// 合同类型删除
		/// </summary>
		public const int ContractTypeDelete = 1850;
		/// <summary>
		/// 合同付款性质浏览
		/// </summary>
		public const int ContractPaymentPropertyBrowser = 1860;
		/// <summary>
		/// 合同付款性质新建
		/// </summary>
		public const int ContractPaymentPropertyAdd = 1870;
		/// <summary>
		/// 合同付款性质修改
		/// </summary>
		public const int ContractPaymentPropertyEdit = 1880;
		/// <summary>
		/// 合同付款性质删除
		/// </summary>
		public const int ContractPaymentPropertyDelete = 1890;
		/// <summary>
		/// 合同付款阶段浏览
		/// </summary>
		public const int ContractPaymentStepBrowser = 1900;
		/// <summary>
		/// 合同付款性质新建
		/// </summary>
		public const int ContractPaymentStepAdd = 1910;
		/// <summary>
		/// 合同付款性质修改
		/// </summary>
		public const int ContractPaymentStepEdit = 1920;
		/// <summary>
		/// 合同付款性质删除
		/// </summary>
		public const int ContractPaymentStepDelete = 1930;
		/// <summary>
		/// 合同付款阶段标志浏览
		/// </summary>
		public const int ContractPaymentStepSignBrowser = 1940;
		/// <summary>
		/// 合同付款阶段标志新建
		/// </summary>
		public const int ContractPaymentStepSignAdd = 1950;
		/// <summary>
		/// 合同付款阶段标志修改
		/// </summary>
		public const int ContractPaymentStepSignEdit = 1960;
		/// <summary>
		/// 合同付款阶段标志删除
		/// </summary>
		public const int ContractPaymentStepSignDelete = 1970;
		/// <summary>
		/// 系统用户管理
		/// </summary>
		public const int UserManage = 1980;
		/// <summary>
		/// 系统口令修改
		/// </summary>
		public const int PWDChange = 1990;
		/// <summary>
		/// 角色权限维护
		/// </summary>
		public const int RoleRightManage = 2000;
		/// <summary>
		/// 角色管理
		/// </summary>
		public const int RoleManage = 2010;
		/// <summary>
		/// 用户角色管理
		/// </summary>
		public const int UserRoleManage = 2020;
		/// <summary>
		/// 用户单据部门管理
		/// </summary>
		public const int UDDManage = 2030;
		/// <summary>
		/// 查询方案管理
		/// </summary>
		public const int QuerySchemeManage = 2040;
		/// <summary>
		/// 批量进货单浏览
		/// </summary>
		public const int BRBBrowser = 2050;
		/// <summary>
		/// 批量进货单新建
		/// </summary>
		public const int BRBAdd = 2060;
		/// <summary>
		/// 批量进货单修改
		/// </summary>
		public const int BRBEdit = 2070;
		/// <summary>
		/// 批量进货单提交
		/// </summary>
		public const int BRBPresent = 2080;
		/// <summary>
		/// 批量进货单作废
		/// </summary>
		public const int BRBCancel = 2090;
		/// <summary>
		/// 批量进货单删除
		/// </summary>
		public const int BRBDelete = 2100;
		/// <summary>
		/// 批量进货单一级审批
		/// </summary>
		public const int BRBFirstAudit = 2110;
		/// <summary>
		/// 批量进货单二级审批
		/// </summary>
		public const int BRBSecondAudit = 2120;
		/// <summary>
		/// 批量进货单三级审批
		/// </summary>
		public const int BRBThirdAudit = 2130;
		/// <summary>
		/// 批量出货单浏览
		/// </summary>
		public const int BDBBrowser = 2140;
		/// <summary>
		/// 批量出货单新建
		/// </summary>
		public const int BDBAdd = 2150;
		/// <summary>
		/// 批量出货单修改
		/// </summary>
		public const int BDBEdit = 2160;
		/// <summary>
		/// 批量出货单提交
		/// </summary>
		public const int BDBPresent = 2170;
		/// <summary>
		/// 批量出货单作废
		/// </summary>
		public const int BDBCancel = 2180;
		/// <summary>
		/// 批量出货单删除
		/// </summary>
		public const int BDBDelete = 2190;
		/// <summary>
		/// 批量出货单一级审批
		/// </summary>
		public const int BDBFirstAudit = 2200;
		/// <summary>
		/// 批量出货单二级审批
		/// </summary>
		public const int BDBSecondAudit = 2210;
		/// <summary>
		/// 批量出货单三级审批
		/// </summary>
		public const int BDBThirdAudit = 2220;
		/// <summary>
		/// 财务付款权限
		/// </summary>
		public const int FinPay = 2230;
		/// <summary>
		/// 委外加工申请单浏览
		/// </summary>
		public const int WTOWBrowser = 2240;
		/// <summary>
		/// 委外加工申请单新建
		/// </summary>
		public const int WTOWAdd = 2250;
		/// <summary>
		/// 委外加工申请单编辑
		/// </summary>
		public const int WTOWEdit = 2260;
		/// <summary>
		/// 委外加工申请单提交
		/// </summary>
		public const int WTOWPresent = 2270;
		/// <summary>
		/// 委外加工申请单作废
		/// </summary>
		public const int WTOWCancel = 2280;
		/// <summary>
		/// 委外加工申请单删除
		/// </summary>
		public const int WTOWDelete = 2290;
		/// <summary>
		/// 委外加工申请单一级审批
		/// </summary>
		public const int WTOWFirstAudit = 2300;
		/// <summary>
		/// 委外加工申请单二级审批
		/// </summary>
		public const int WTOWSecondAudit = 2310;
		/// <summary>
		/// 委外加工申请单三级审批
		/// </summary>
		public const int WTOWThirdAudit = 2320;
		/// <summary>
		/// 委外加工收料单浏览
		/// </summary>
		public const int WINWBrowser = 2330;
		/// <summary>
		/// 委外加工收料单新建
		/// </summary>
		public const int WINWAdd = 2340;
		/// <summary>
		/// 委外加工收料单编辑
		/// </summary>
		public const int WINWEdit = 2350;
		/// <summary>
		/// 委外加工收料单提交
		/// </summary>
		public const int WINWPresent = 2360;
		/// <summary>
		/// 委外加工收料单作废
		/// </summary>
		public const int WINWCancel = 2370;
		/// <summary>
		/// 委外加工收料单删除
		/// </summary>
		public const int WINWDelete = 2380;
		/// <summary>
		/// 委外加工收料单一级审批
		/// </summary>
		public const int WINWFirstAudit = 2390;
		/// <summary>
		/// 委外加工收料单二级审批
		/// </summary>
		public const int WINWSecondAudit = 2400;
		/// <summary>
		/// 委外加工收料单三级审批
		/// </summary>
		public const int WINWThirdAudit = 2410;
		/// <summary>
		/// 库存统计查看
		/// </summary>
		public const int StockAnalysis = 2420;
		/// <summary>
		/// 发料统计查看
		/// </summary>
		public const int WithDrawAnalysis = 2430;
		/// <summary>
		/// 申购统计查看
		/// </summary>
		public const int ROSAnalysis = 2440;
		/// <summary>
		/// 供应商统计查看
		/// </summary>
		public const int VendorAnalysis = 2450;
		/// <summary>
		/// 付款查看
		/// </summary>
		public const int PayBrowser = 2460;
		/// <summary>
		/// 付款新建
		/// </summary>
		public const int PayAdd = 2470;
		/// <summary>
		/// 付款提交
		/// </summary>
		public const int PayPresent = 2480;
		/// <summary>
		/// 付款审批
		/// </summary>
		public const int PayThirdAudit = 2490;
		/// <summary>
		/// 付款确认
		/// </summary>
		public const int PayConfirm = 2500;
		/// <summary>
		/// 付款作废
		/// </summary>
		public const int PayCancel = 2510;
		/// <summary>
		/// 付款删除
		/// </summary>
		public const int PayDelete = 2520;
		/// <summary>
		/// 原材料收发维护
		/// </summary>
		public const int YCLIO = 2530;
		/// <summary>
		/// 审批模块
		/// </summary>
		public const int Audit = 2540;
		/// <summary>
		/// 供应商分类维护
		/// </summary>
		public const int PPRCMaintain = 2550;
		/// <summary>
		/// 采购撤销单查看
		/// </summary>
		public const int CancelBrowser = 2560;
		/// <summary>
		/// 采购撤销单新建
		/// </summary>
		public const int CancelAdd = 2570;
		/// <summary>
		/// 采购撤销单编辑
		/// </summary>
		public const int CancelEdit = 2580;
		/// <summary>
		/// 采购撤销单提交
		/// </summary>
		public const int CancelPresent = 2590;
		/// <summary>
		/// 采购撤销单作废
		/// </summary>
		public const int CancelCancel = 2600;
		/// <summary>
		/// 采购撤销单删除
		/// </summary>
		public const int CancelDelete = 2610;
		/// <summary>
		/// 采购撤销单一级审批
		/// </summary>
		public const int CancelFirstAudit = 2620;
		/// <summary>
		/// 采购撤销单二级审批
		/// </summary>
		public const int CancelSecondAudit = 2630;
		/// <summary>
		/// 采购撤销单三级审批
		/// </summary>
		public const int CancelThirdAudit = 2640;
		private SysRight() {}
	}*/

	/// <summary>
	/// 有关在线帮助码的枚举。
	/// </summary>
	/// <remarks>该类不允许被继承及实例化。</remarks>
	public sealed class HelpCode
	{
		/// <summary>
		/// 我的工作
		/// </summary>
		public const string MyJob = "MM_00";
		/// <summary>
		/// 基本信息
		/// </summary>
		public const string BaseInfo = "MM_01";
		/// <summary>
		/// 物料分类
		/// </summary>
		public const string Category = "MM_01_01";
		/// <summary>
		/// 计量单位
		/// </summary>
		public const string Unit = "MM_01_02";
		/// <summary>
		/// 仓库
		/// </summary>
		public const string Storage = "MM_01_03";
		/// <summary>
		/// 物料
		/// </summary>
		public const string Item = "MM_01_04";
		/// <summary>
		/// 用途
		/// </summary>
		public const string Purpose = "MM_01_05";
		/// <summary>
		/// 供应商
		/// </summary>
		public const string Vendor = "MM_01_06";
		/// <summary>
		/// 采购合同类型
		/// </summary>
		public const string ContactType = "MM_01_07";
		/// <summary>
		/// 采购合同付款阶段
		/// </summary>
		public const string ContactPayStep = "MM_01_08";
		/// <summary>
		/// 采购合同付款阶段标志
		/// </summary>
		public const string ContactPayStepTag = "MM_01_09";
		/// <summary>
		/// 采购合同付款性质
		/// </summary>
		public const string ContactPayQuality = "MM_01_10";
        /// <summary>
        /// 采购资金性质
        /// </summary>
        public const string ContractMoneyProperty = "MM_01_11";
		/// <summary>
		/// 采购管理
		/// </summary>
		public const string PurchaseManage = "MM_02";
		/// <summary>
		/// 采购申请单
		/// </summary>
		public const string ROS = "MM_02_01";
		/// <summary>
		/// 物料需求单
		/// </summary>
		public const string MRP = "MM_02_02";
		/// <summary>
		/// 采购计划
		/// </summary>
		public const string PP = "MM_02_03";
		/// <summary>
		/// 采购订单
		/// </summary>
		public const string PO = "MM_02_04";
		/// <summary>
		/// 采购收料单
		/// </summary>
		public const string BOR = "MM_02_05";
		/// <summary>
		/// 采购退货单
		/// </summary>
		public const string RTV = "MM_02_06";
		/// <summary>
		/// 采购合同
		/// </summary>
		public const string Contract = "MM_02_07";
		/// <summary>
		/// 批量进货单
		/// </summary>
		public const string BRB = "MM_02_08";
		/// <summary>
		/// 库存管理
		/// </summary>
		public const string StockManage = "MM_03";
		/// <summary>
		/// 领料单
		/// </summary>
		public const string DRW = "MM_03_01";
		/// <summary>
		/// 生产退料单
		/// </summary>
		public const string RTS = "MM_03_02";
		/// <summary>
		/// 转库单
		/// </summary>
		public const string TRF = "MM_03_03";
		/// <summary>
		/// 报废单
		/// </summary>
		public const string DAU = "MM_03_04";
		/// <summary>
		/// 架位调整
		/// </summary>
		public const string CAD = "MM_03_05";
		/// <summary>
		/// 收料
		/// </summary>
		public const string IN = "MM_03_06";
		/// <summary>
		/// 发料
		/// </summary>
		public const string OUT = "MM_03_07";
		/// <summary>
		/// 库存查询
		/// </summary>
		public const string StockQuery = "MM_03_08";
		/// <summary>
		/// 呆料查询
		/// </summary>
		public const string primness = "MM_03_09";
		/// <summary>
		/// 批量出货单
		/// </summary>
		public const string BDB = "MM_03_10";
		/// <summary>
		/// 报表管理
		/// </summary>
		public const string ReportManage = "MM_04";
		/// <summary>
		/// 系统管理
		/// </summary>
		public const string SystemManage = "MM_05";
		/// <summary>
		/// 用户管理
		/// </summary>
		public const string UserManage = "MM_05_01";
		/// <summary>
		/// 角色权限管理
		/// </summary>
		public const string RoleManage = "MM_05_02";
		/// <summary>
		/// 用户单据部门管理
		/// </summary>
		public const string UDD = "MM_05_03";
		/// <summary>
		/// 查询方案管理
		/// </summary>
		public const string QueryScheme = "MM_05_04";
		private HelpCode() {}
	}

}
