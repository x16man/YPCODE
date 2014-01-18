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
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// PurchaseOrderData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PurchaseOrderData : DataSet
	{
		#region 返回信息
		public const string NOOBJECT = "空对象！";
		public const string ADD_FAILED = "采购订单新建失败！可能原因有可能是采购订单超数量了。";
		public const string ADD_SUCCESSED = "采购订单新建成功！";
		public const string UPDATE_FAILED = "采购订单修改失败！可能原因有可能是采购订单超数量了。";
		public const string UPDATE_SUCCESSED = "采购订单修改成功！";
		public const string DELETE_FAILED = "采购订单删除失败！";
		public const string DELETE_SUCCESSED = "采购订单删除成功！";
		public const string UPDATESTATE_FAILED = "采购订单修改状态失败！";
		public const string UPDATESTATE_SUCCESSED = "采购订单修改状态成功！";
		public const string FIRSTAUDIT_FAILED = "采购订单一级审批失败！";
		public const string FIRSTAUDIT_SUCCESSED = "采购订单一级审批成功！";
		public const string SECONDAUDIT_FAILED = "采购订单二级审批失败！";
		public const string SECONDAUDIT_SUCCESSED = "采购订单二级审批成功！";
		public const string THIRDAUDIT_FAILED = "采购订单三级审批失败！";
		public const string THIRDAUDIT_SUCCESSED = "采购订单三级审批成功！";
		public const string PRESENT_FAILED = "采购订单提交失败！";
		public const string PRESENT_SUCCESSED = "采购订单提交成功！";
		public const string CANCEL_FAILED = "采购订单作废失败！";
		public const string CANCEL_SUCCESSED = "采购订单作废成功！";
		public const string AFFIRM_SUCCESSED = "采购订单确认成功！";
		public const string AFFIRM_FAILED = "采购订单确认失败！";
		public const string NoPrvider = "采购订单必须要指定供应商！";
		public const string NoBuyer = "采购订单必须要指定采购员！";
		public const string XUpdate = "采购订单修改的前提，单据状态处于新建、审批不通过、作废的状态！";
		public const string XUpdatePresent = "采购订单修改并且指派的前提，单据状态处于新建、审批不通过、作废的状态！";
		public const string XAssign = "采购订单指派的前提是，单据处于新建、作废的状态！";
		public const string XFirstAudit = "采购订单一级审批的前提是，单据处于提交的状态！";
		public const string XSecondAudit = "采购订单二级审批的前提是，单据处于一级审批通过的状态！";
		public const string XThirdAudit = "采购订单三级审批的前提是，单据处于二级审批通过的状态！";
		public const string XDelete = "采购订单删除的前提是，单据处于作废的状态！";
		public const string XCancel = "采购订单作废的前提是，单据处于新建、审批不通过的状态！";
        public const string XConfirm = "采购订单确认的前提是，单据处于审核完成的状态,并且当前确认者是单据指定的采购员！";
        public const string NumberInsufficient = "要撤销的数量大于订单欠缺数量！";
        public const string NumberCompareZero = "要撤销的数量应小于0 ！";
        public const string NumberGreatZero = "要撤销的数量最大为{0}";

        #endregion

		#region 成员变量
		public const string PORD_TABLE = "PORD";					//表名。
		public const string SOURCEENTRY_FIELD = "SourceEntry";		//源单据。
		public const string SOURCEDOCCODE_FIELD = "SourceDocCode";	//源单据类型。
		public const string SOURCESERIALNO_FIELD = "SourceSerialNo"; //源单据顺序号。
		public const string DELIVERYDATE_FIELD = "DeliveryDate";	//交货日期。
		public const string PRVCODE_FIELD = "PrvCode";				//供应商编号。
		public const string PRVNAME_FIELD = "PrvName";				//供应商名称。
		public const string PRVADD_FIELD = "PrvAdd";				//供应商地址。
		public const string PRVZIP_FIELD = "PrvZip";				//供应商邮编。
		public const string PRVTEL_FIELD = "PrvTel";				//供应商联系电话。
		public const string PRVFAX_FIELD = "PrvFax";				//供应商传真。
		public const string PRVLICENCE_FIELD = "PrvLicence";		//营业执照号。
		public const string PRVBANK_FIELD = "PrvBank";				//开户银行。
		public const string PRVACCOUNT_FIELD = "PrvAccount";		//开户帐户。
		public const string PRVTAXNO_FIELD = "PrvTaxNo";			//税务登记号。
		public const string TRANSTYPE_FIELD = "TransType";			//运输方式。
		public const string CURRENCYCODE_FIELD = "CurrencyCode";	//币种。
		public const string PAYSTYLE_FIELD = "PayStyle";			//付款方式。
		public const string PAYMENT_FIELD = "Payment";				//付款条款。
		public const string SENDTO_FIELD = "SendTo";				//送到。
		public const string INVOICETO_FIELD = "InvoiceTo";			//开票到。
		public const string TOTALMONEY_FIELD = "TotalMoney";		//总金额。
		public const string TOTALTAX_FIELD = "TotalTax";			//总税额。
		public const string TOTALDISCOUNT_FIELD = "TotalDiscount";	//总折扣。
		public const string TOTALFEE_FIELD = "TotalFee";			//总费用。
	    
		public const string BUYERCODE_FIELD = "BuyerCode";			//采购员编号。
		public const string BUYERNAME_FIELD = "BuyerName";			//采购员名称。
        public const string PSCCODE_FIELD = "PscCode";				//购方编号。
		public const string PSCNAME_FIELD = "PscName";				//购方名称。
		public const string TAXCODE_FIELD = "TaxCode";				//税码。
		public const string TAXRATE_FIELD = "TaxRate";				//物料税率。
		public const string ITEMTAX_FIELD = "ItemTax";				//物料税额。
		public const string DISCOUNTRATE_FIELD = "DiscountRate";	//物料折扣率。
		public const string ITEMDISCOUNT_FIELD = "ItemDiscount";	//物料折扣额。
		public const string ITEMFEE_FIELD = "ItemFee";				//物料费用。
		public const string ITEMSUM_FIELD = "ItemSum";				//物料总金额。
		public const string ITEMLACKNUM_FIELD = "ItemLackNum";		//物料欠交数量。
		public const string ITEMINVNUM_FIELD = "ItemInvNum";		//物料开票数量。
		public const string PKID_FIELD = "PKID";                    //PKIFD
		public const string Proposer_Field = "Proposer";			//申请人信息。
		public const string CatCode_Field = "CatCode";				//供应商分类。
		public const string CatName_Field = "CatName";				//供应商分类名称。
        public const string ParentEntryNo_Field = "ParentEntryNo";		//ParentEntryNo
		
		#endregion

		#region 属性
		public int Count
		{
			get { return this.Tables[PurchaseOrderData.PORD_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PORD_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			
			columns.Add(SOURCEENTRY_FIELD, typeof(System.String));
			columns.Add(SOURCEDOCCODE_FIELD, typeof(System.String));
			columns.Add(SOURCESERIALNO_FIELD,typeof(System.String));
			columns.Add(DELIVERYDATE_FIELD, typeof(System.DateTime));			
			columns.Add(PRVCODE_FIELD, typeof(System.String));
			columns.Add(PRVNAME_FIELD, typeof(System.String));
			columns.Add(PRVADD_FIELD, typeof(System.String));
			columns.Add(PRVZIP_FIELD, typeof(System.String));
			columns.Add(PRVTEL_FIELD, typeof(System.String));
			columns.Add(PRVFAX_FIELD, typeof(System.String));
			columns.Add(PRVLICENCE_FIELD, typeof(System.String));
			columns.Add(PRVBANK_FIELD, typeof(System.String));
			columns.Add(PRVACCOUNT_FIELD, typeof(System.String));
			columns.Add(PRVTAXNO_FIELD, typeof(System.String));
			columns.Add(TRANSTYPE_FIELD, typeof(System.Int16));
			columns.Add(CURRENCYCODE_FIELD, typeof(System.String));
			columns.Add(PAYSTYLE_FIELD, typeof(System.String));
			columns.Add(PAYMENT_FIELD, typeof(System.String));
			columns.Add(SENDTO_FIELD, typeof(System.String));
			columns.Add(INVOICETO_FIELD, typeof(System.String));
			columns.Add(TOTALMONEY_FIELD, typeof(System.Decimal));
			columns.Add(TOTALTAX_FIELD, typeof(System.Decimal));
			columns.Add(TOTALDISCOUNT_FIELD, typeof(System.Decimal));
			columns.Add(TOTALFEE_FIELD, typeof(System.Decimal));
			columns.Add(BUYERCODE_FIELD, typeof(System.String));
			columns.Add(BUYERNAME_FIELD, typeof(System.String));
			columns.Add(PSCCODE_FIELD,  typeof(System.String));
			columns.Add(PSCNAME_FIELD,  typeof(System.String));
			columns.Add(TAXCODE_FIELD,  typeof(System.Int16));
			columns.Add(TAXRATE_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMTAX_FIELD,  typeof(System.Decimal));
			columns.Add(DISCOUNTRATE_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMDISCOUNT_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMFEE_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMSUM_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMLACKNUM_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMINVNUM_FIELD,  typeof(System.Decimal));
			columns.Add(PKID_FIELD, typeof(System.String));
			columns.Add(Proposer_Field, typeof(System.String));
			columns.Add(CatCode_Field, typeof(System.Int32));
			columns.Add(CatName_Field, typeof(System.String));
            columns.Add(ParentEntryNo_Field, typeof(System.Int32));
		    
			this.Tables.Add(table);
		}
		
		#endregion

		#region 构造函数
		private PurchaseOrderData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PurchaseOrderData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
