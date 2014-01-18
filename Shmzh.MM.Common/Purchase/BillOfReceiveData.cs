using System;
using System.Data;
using System.Runtime.Serialization;   

namespace  Shmzh.MM.Common
{
	/// <summary>
	/// 采购收料单的数据实体层。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class BillOfReceiveData:DataSet
	{
		#region 成员变量
		//数据输入检验报错信息。
		public const string NO_OBJECT = "没有供应商/客户数据对象！";
		public const string NO_ROW = "没有供应商/客户数据数据行！";
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索收料单数据失败！";
		public const string ADD_FAILED = "添加收料单数据失败！";
		public const string ADD_SUCCESSED = "添加收料单数据成功！";
		public const string RECEIVE_FAILED = "收料失败！";
		public const string RECEIVE_SUCCESSED = "收料成功！";
		public const string UPDATE_FAILED = "更改收料单数据失败！";
		public const string UPDATE_SUCCESSED = "更改收料单数据成功！";
		public const string DELETE_FAILED = "删除收料单数据失败！";
		public const string DELETE_SUCCESSED = "删除收料单数据成功！";
		public const string UPDATESTATE_FAILED = "更改收料单状态失败！";
		public const string UPDATESTATE_SUCCESSED = "更改收料单状态成功！";
		public const string FIRSTAUDIT_FAILED = "一级审批失败！";
		public const string SECONDAUDIT_FAILED = "二级审批失败！";
		public const string THIRDAUDIT_FAILED = "三级审批失败！";
		public const string FIRSTAUDIT_SUCCESSED = "一级审批成功！";
		public const string SECONDAUDIT_SUCCESSED = "二级审批成功！";
		public const string THIRDAUDIT_SUCCESSED = "三级审批成功！";
		public const string PRESENT_FAILED = "采购收料单提交失败！";
		public const string PRESENT_SUCCESSED = "采购收料单提交成功！";
		public const string CANCEL_FAILED = "采购收料单作废失败！";
		public const string CANCEL_SUCCESSED = "采购收料单作废成功！";
		public const string PAY_FAILED = "采购收料单付款失败！";
		public const string PAY_SUCCESSED = "采购收料单付款成功！";
		public const string XUpdate = "采购收料单修改的前提是，单据处于新建、作废、审批不通过的状态！";
		public const string XDelete = "采购收料单删除的前提是，单据处于作废的状态！";
		public const string XCancel = "采购收料单作废的前提是，单据处于新建、审批不通过的状态！";
		public const string XPay = "采购收料单的付款的前提是，单据处于已收料的状态！";
		public const string XPresent = "采购收料单提交的前提是，单据处于新建、审批不通过、作废的状态！";
		public const string XFirstAudit = "采购收料单的一级审批的前提是，单据处于已经提交的状态！";
		public const string XSecondAudit = "采购收料单二级审批的前提是，单据处于一级审批通过的状态！";
		public const string XThirdAudit = "采购收料单的三级审批的前提是，单据处于二级审批通过的状态！";
		public const string NoStorage = "采购收料单必须要指定收料仓库！";
		public const string NoBuyer = "采购收料单必须要指定采购员！";

		public const string PBOR_TABLE  = "PBOR";							//表名。
		//主表信息。
		
		public const string PRVCODE_FIELD			= "PrvCode";		//供应商代码。
		public const string PRVNAME_FIELD			= "PrvName";		//供应商名称。
		public const string PRVBANK_FIELD			= "PrvBank";		//供应商开户银行。
		public const string PRVACCOUNT_FIELD		= "PrvAccount";		//供应商账号。
		public const string PRVREGNO_FIELD			= "PrvRegNo";		//供应商税务登记号。
		public const string PRVTEL_FIELD			= "PrvTel";			//供应商联系电话。
		public const string PRVFAX_FIELD			= "PrvFax";			//供应商传真。
		public const string PAYSTYLE_FIELD			= "PayStyle";		//付款方式。
		public const string INVOICENO_FIELD			= "InvoiceNo";		//发票号。
		public const string CHKNO_FIELD				= "ChkNo";			//验收单号。
		public const string CHKRESULT_FIELD			= "ChkResult";		//验收结果。
		public const string CURRENCYCODE_FIELD		= "CurrencyCode";	//货币代码。
		public const string USEDFOR_FIELD			= "UsedFor";		//用于。
		public const string BUYERCODE_FIELD			= "BuyerCode";		//采购员编号。
		public const string BUYERNAME_FIELD			= "BuyerName";		//采购员名称。
		public const string STOCODE_FIELD			= "StoCode";		//仓库编号。
		public const string STONAME_FIELD			= "StoName";		//仓库名称。
		public const string ACCEPTCODE_FIELD		= "AcceptCode";		//收料人编号。
		public const string ACCEPTNAME_FIELD		= "AccepttName";	//收料人名称。
		public const string ACCEPTDATE_FIELD		= "AcceptDate";		//收料日期。
		public const string PCSCODE_FIELD			= "PcsCode";		//购货方编号。
		public const string PCSNAME_FIELD			= "PcsName";		//购货方名称。
		public const string TOTALMONEY_FIELD		= "TotalMoney";		//总价。
		public const string TOTALTAX_FIELD			= "TotalTax";		//总税额。
		public const string TOTALFEE_FIELD			= "TotalFee";		//总费用。
		public const string TOTALDISCOUNT_FIELD		= "TotalDiscount";	//总折扣。
		public const string JFKM_FIELD				= "JFKM";			//会计科目。
		public const string CONTRACTCODE_FIELD		= "ContractCode";	//合同编号。
		public const string PARENTENTRYNO_FIELD		= "ParentEntryNo";	//对应蓝单据编号。
		public const string ITEMSUMMARY_FIELD		= "ItemSummary";	//单据物料信息摘要。
		public const string PAYDATE_FIELD			= "PayDate";		//付款日期。
		//从表信息。
		public const string SOURCEENTRY_FIELD		= "SourceEntry";	//源单据号。
		public const string SOURCEDOCCODE_FIELD		= "SourceDocCode";	//源单据类型。
		public const string SOURCESERIALNO_FIELD	= "SourceSerialNo";	//源顺序号。
		public const string PLANNUM_FIELD			= "PlanNum";		//应收数量。
		public const string TAXCODE_FIELD			= "TaxCode";		//税收代码。
		public const string TAXRATE_FIELD			= "TaxRate";		//税率。
		public const string ITEMTAX_FIELD			= "ItemTax";		//税额。
		public const string ITEMFEE_FIELD			= "ItemFee";		//费用。
		public const string DISCOUNTRATE_FIELD		= "DiscountRate";	//折扣率。
		public const string ITEMDISCOUNT_FIELD		= "ItemDiscount";	//折扣金额。
		public const string ITEMSUM_FIELD			= "ItemSum";		//物料金额合计。
		public const string CONCODE_FIELD			= "ConCode";		//架位号。
		public const string CONNAME_FIELD			= "ConName";		//架位名称。
		public const string ITEMNOINVOICENUM_FIELD  = "ItemNoInvoiceNum";//发票未到数量。
		public const string BATCHCODE_FIELD         = "BatchCode";		//批号。
		public const string CatCode_Field			= "CatCode";		//供应商分类。
		public const string CatName_Field			= "CatName";		//供应商分类名称。
		#endregion

		#region 属性
		/// <summary>
		/// 收料单实体的行集数量。
		/// </summary>
		public int Count
		{
			get {	return this.Tables[BillOfReceiveData.PBOR_TABLE].Rows.Count;}
		}
		#endregion

		#region 构造函数
		private BillOfReceiveData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public BillOfReceiveData()
		{
			BuildDataTables();
		}
		#endregion

		#region 私有方法
		private void BuildDataTables()
		{
			
			DataTable table   = new DataTable(PBOR_TABLE);

			InItemData oItemData=new InItemData(table);

			DataColumnCollection columns = table.Columns;
			//主表字段增加。
			columns.Add(PRVCODE_FIELD, typeof(System.String));				//供应商代码。
			columns.Add(PRVNAME_FIELD, typeof(System.String));				//供应商名称。
			columns.Add(PRVBANK_FIELD, typeof(System.String));				//供应商开户银行。
			columns.Add(PRVACCOUNT_FIELD, typeof(System.String));			//供应商帐户。			
			columns.Add(PRVREGNO_FIELD, typeof(System.String));				//供应商税务登记号。
			columns.Add(PRVTEL_FIELD, typeof(System.String));				//供应商电话。
			columns.Add(PRVFAX_FIELD, typeof(System.String));				//供应商传真。
			columns.Add(PAYSTYLE_FIELD, typeof(System.String));				//付款方式。
			columns.Add(INVOICENO_FIELD, typeof(System.String));			//发票号码。
			columns.Add(CHKNO_FIELD, typeof(System.Int32));					//验收报告。
			columns.Add(CHKRESULT_FIELD, typeof(System.String));			//验收情况。
			columns.Add(CURRENCYCODE_FIELD, typeof(System.String));			//货币代码。
		    columns.Add(USEDFOR_FIELD, typeof(System.String));				//用于。
			columns.Add(BUYERCODE_FIELD, typeof(System.String));			//采购员编号。
			columns.Add(BUYERNAME_FIELD, typeof(System.String));			//采购员名称。
			columns.Add(STOCODE_FIELD, typeof(System.String));				//仓库编号。
			columns.Add(STONAME_FIELD, typeof(System.String));				//仓库名称。
			columns.Add(ACCEPTCODE_FIELD, typeof(System.String));			//收料人编号。
			columns.Add(ACCEPTNAME_FIELD, typeof(System.String));			//收料人名称。
			columns.Add(ACCEPTDATE_FIELD, typeof(System.DateTime));			//收料日期。
			columns.Add(PCSCODE_FIELD,typeof(System.String));				//购方编号。
			columns.Add(PCSNAME_FIELD,typeof(System.String));				//购方名称。
			columns.Add(TOTALMONEY_FIELD, typeof(System.Decimal));			//总价。
			columns.Add(TOTALTAX_FIELD, typeof(System.Decimal));			//总税额。
			columns.Add(TOTALFEE_FIELD, typeof(System.Decimal));			//总费用。
			columns.Add(TOTALDISCOUNT_FIELD, typeof(System.Decimal));		//总折扣。
			columns.Add(JFKM_FIELD,typeof(string));							//会计科目。
			columns.Add(CONTRACTCODE_FIELD, typeof(System.String));			//合同编号。
			columns.Add(PARENTENTRYNO_FIELD, typeof(System.Int32));			//对应的蓝单据号。
			columns.Add(ITEMSUMMARY_FIELD, typeof(System.String));			//单据物料信息摘要。
			//从表字段增加。
			columns.Add(SOURCEENTRY_FIELD, typeof(System.String));			//源单据号。
			columns.Add(SOURCEDOCCODE_FIELD, typeof(System.String));		//源单据类型。
			columns.Add(SOURCESERIALNO_FIELD, typeof(System.String));		//源顺序号。
			columns.Add(PLANNUM_FIELD, typeof(System.String));				//应收数量。
			columns.Add(TAXCODE_FIELD, typeof(System.String));				//税码。
			columns.Add(TAXRATE_FIELD, typeof(System.String));				//单项税率。
			columns.Add(ITEMTAX_FIELD, typeof(System.String));				//单项税额。
			columns.Add(ITEMFEE_FIELD, typeof(System.String));				//单项费用。
			columns.Add(DISCOUNTRATE_FIELD, typeof(System.String));			//折扣率。
			columns.Add(ITEMDISCOUNT_FIELD, typeof(System.String));			//单项折扣。
			columns.Add(ITEMSUM_FIELD, typeof(System.String));				//物料总金额。
			columns.Add(CONCODE_FIELD, typeof(System.String));				//架位号。
			columns.Add(CONNAME_FIELD, typeof(System.String));				//架位名称。
			columns.Add(ITEMNOINVOICENUM_FIELD, typeof(System.String));		//发票未到数量。
			columns.Add(BATCHCODE_FIELD, typeof(System.String));			//批号。
			columns.Add(CatCode_Field, typeof(System.Int32));				//供应商分类代码。
			columns.Add(CatName_Field, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion
	}
}
