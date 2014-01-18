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

namespace Shmzh.MM.DataAccess
{
	using System;
    using System.Configuration;
	using System.Data;
    using System.Data.SqlClient;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;
	/// <summary>
	/// PurchaseOrders 的摘要说明。
	/// </summary>
	public class PurchaseOrders : Messages,IInItems
    {
        #region Property
        /// <summary>
        /// 数据库连接字符串。
        /// </summary>
        public string ConnString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
        #endregion

        #region 构造函数
        public PurchaseOrders()
		{
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(PurchaseOrderData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];
			//收料模式公用字段。
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//单据流水号。
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//单据编号。
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//单据类型。
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//单据类型名称。
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//单据类型文档编号。
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//单据状态。
			oHT.Add("@EntryDate",		oRow[InItemData.ENTRYDATE_FIELD]);					//制单日期。
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//制单人编号。
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//制单人名称。
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//制单人登录名。
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//制单人部门。
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//制单人部门名称。
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);					//申请总金额。
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//备注。
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//物料编号。
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//物料名称。
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//物料规格。
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//物料单价。
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//物料数量。
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			//采购订单单特有字段。
			oHT.Add("@SourceEntryList",		oRow[PurchaseOrderData.SOURCEENTRY_FIELD]);			//源单据编号。
			oHT.Add("@SourceDocCodeList",	oRow[PurchaseOrderData.SOURCEDOCCODE_FIELD]);		//源单据类型编号。
			oHT.Add("@SourceSerialNoList",  oRow[PurchaseOrderData.SOURCESERIALNO_FIELD]);   //源单据顺序号。
			oHT.Add("@DeliveryDate",	oRow[PurchaseOrderData.DELIVERYDATE_FIELD]);		//交货日期。
			oHT.Add("@PrvCode",			oRow[PurchaseOrderData.PRVCODE_FIELD]);				//供应商编号。
			oHT.Add("@PrvName",			oRow[PurchaseOrderData.PRVNAME_FIELD]);				//供应商名称。
			oHT.Add("@PrvAdd",			oRow[PurchaseOrderData.PRVADD_FIELD]);				//供应商地址。
			oHT.Add("@PrvZip",			oRow[PurchaseOrderData.PRVZIP_FIELD]);				//供应商邮编。
			oHT.Add("@PrvTel",			oRow[PurchaseOrderData.PRVTEL_FIELD]);				//联系电话。
			oHT.Add("@PrvFax",			oRow[PurchaseOrderData.PRVFAX_FIELD]);				//传真。
			oHT.Add("@PrvLicence",		oRow[PurchaseOrderData.PRVLICENCE_FIELD]);			//营业执照号。
			oHT.Add("@PrvBank",			oRow[PurchaseOrderData.PRVBANK_FIELD]);				//开户银行。
			oHT.Add("@PrvAccount",		oRow[PurchaseOrderData.PRVACCOUNT_FIELD]);			//开户银行。
			oHT.Add("@PrvTaxNo",		oRow[PurchaseOrderData.PRVTAXNO_FIELD]);			//税务登记号。
			oHT.Add("@CurrencyCode",	oRow[PurchaseOrderData.CURRENCYCODE_FIELD]);		//币种。
			oHT.Add("@PayStyle",		oRow[PurchaseOrderData.PAYSTYLE_FIELD]);			//付款方式。
			oHT.Add("@Payment",			oRow[PurchaseOrderData.PAYMENT_FIELD]);				//付款条款。
			oHT.Add("@TransType",		oRow[PurchaseOrderData.TRANSTYPE_FIELD]);			//运输方式。
			oHT.Add("@SendTo",			oRow[PurchaseOrderData.SENDTO_FIELD]);				//送到。
			oHT.Add("@InvoiceTo",		oRow[PurchaseOrderData.INVOICETO_FIELD]);			//开票到。
			oHT.Add("@PscCode",			oRow[PurchaseOrderData.PSCCODE_FIELD]);				//购方编号。
			oHT.Add("@PscName",			oRow[PurchaseOrderData.PSCNAME_FIELD]);				//购方名称。
			oHT.Add("@TotalMoney",		oRow[PurchaseOrderData.TOTALMONEY_FIELD]);			//总金额。
			oHT.Add("@TotalTax",		oRow[PurchaseOrderData.TOTALTAX_FIELD]);			//总税额。
			oHT.Add("@TotalDiscount",	oRow[PurchaseOrderData.TOTALDISCOUNT_FIELD]);		//总折扣额。
			oHT.Add("@TotalFee",		oRow[PurchaseOrderData.TOTALFEE_FIELD]);			//总费用额。
			oHT.Add("@BuyerCode",		oRow[PurchaseOrderData.BUYERCODE_FIELD]);			//采购员编号。
			oHT.Add("@BuyerName",		oRow[PurchaseOrderData.BUYERNAME_FIELD]);			//采购员名称。
			oHT.Add("@TaxCodeList",			oRow[PurchaseOrderData.TAXCODE_FIELD]);				//税码。
			oHT.Add("@TaxRateList",			oRow[PurchaseOrderData.TAXRATE_FIELD]);				//税率。
			oHT.Add("@ItemTaxList",			oRow[PurchaseOrderData.ITEMTAX_FIELD]);				//物料税额。
			oHT.Add("@DiscountRateList",	oRow[PurchaseOrderData.DISCOUNTRATE_FIELD]);		//物料折扣率。
			oHT.Add("@ItemDiscountList",	oRow[PurchaseOrderData.ITEMDISCOUNT_FIELD]);		//物料折扣.
			oHT.Add("@ItemFeeList",			oRow[PurchaseOrderData.ITEMFEE_FIELD]);				//物料费用。
			oHT.Add("@ItemSumList",			oRow[PurchaseOrderData.ITEMSUM_FIELD]);				//物料总金额。
			oHT.Add("@ItemLackNum",		oRow[PurchaseOrderData.ITEMLACKNUM_FIELD]);			//物料欠交数量。
			oHT.Add("@ItemInvNum",		oRow[PurchaseOrderData.ITEMINVNUM_FIELD]);			//物料开票数量。
            oHT.Add("@ParentEntryNo", oRow[PurchaseOrderData.ParentEntryNo_Field]);
		
			return oHT;
		}
		#endregion 

		#region IInItems 成员
		/// <summary>
		/// 单据增加。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			PurchaseOrderData oEntry = (PurchaseOrderData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_OrderInsert",oHT);
			
			if(ret == false)
			{
				//this.Message = PurchaseOrderData.ADD_FAILED;
                this.SetError(oSQLServer.ExceptionMessage, PurchaseOrderData.ADD_FAILED);
			}
			else
			{
				this.Message = PurchaseOrderData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 单据增加并且提交。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			PurchaseOrderData oEntry = (PurchaseOrderData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_OrderInsertAndPresent",oHT);
			
			if(ret == false)
			{
				//this.Message = PurchaseOrderData.ADD_FAILED;
                this.SetError(oSQLServer.ExceptionMessage, PurchaseOrderData.ADD_FAILED);
				
			}
			else
			{
				this.Message = PurchaseOrderData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单修改。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret=true;
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_OrderUpdate", oHT);
			if(ret == false)
			{
				//this.Message = PurchaseOrderData.UPDATE_FAILED;
                this.SetError(oSQLServer.ExceptionMessage, PurchaseOrderData.UPDATE_FAILED);
				
			}
			else
			{
				this.Message = PurchaseOrderData.UPDATE_SUCCESSED;
			}
			return ret;
		}

        /// <summary>
        /// 根据抱错的信息内容（去掉\r\n 有可能得到2,3,1)
        /// </summary>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        private void SetError(string strMessage, string strDefaultError)
        {
            string strTemp = strMessage.Replace("\r\n", "");
            if (strTemp == "-2")
            {
                this.Message = PurchaseOrderData.NumberInsufficient;
            }
            else if (strTemp == "-3")
            {
                this.Message = PurchaseOrderData.NumberCompareZero;
            }
            else
            {
                try
                {
                    int i = Int32.Parse(strTemp);
                    if (i > 0)
                    {
                        this.Message = string.Format(PurchaseOrderData.NumberGreatZero, strTemp);
                    }
                }
                catch
                {
                    this.Message = strDefaultError;
                }

            }
        }


		/// <summary>
		/// 采购订单修改并且提交。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret=true;
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_OrderUpdateAndPresent", oHT);
			if(ret == false)
			{
				//this.Message = PurchaseOrderData.UPDATE_FAILED;
                this.SetError(oSQLServer.ExceptionMessage, PurchaseOrderData.UPDATE_FAILED);
				
			}
			else
			{
				this.Message = PurchaseOrderData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_OrderDelete", oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.DELETE_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 更改采购订单状态。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="EntryState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Pur_OrderUpdateState", oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单一级审批。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_OrderFirstAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单二级审批。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_OrderSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单三级审批。
		/// </summary>
		/// <param name="Entry">object:采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_OrderThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单指派。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);
			oHT.Add("@UserLoginId",     UserLoginId);

			ret = oSQLServer.ExecSP("Pur_OrderPresent",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.PRESENT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);

						
			ret = oSQLServer.ExecSP("Pur_OrderCancel",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);
			oHT.Add("@UserLoginID", UserLoginID);

						
			ret = oSQLServer.ExecSP("Pur_OrderCancel",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 根据单据流水号获取采购订单。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <returns>object:	采购订单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByEntryNo",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

        /// <summary>
        /// 根据单据流水号获取采购订单。
        /// </summary>
        /// <param name="EntryNo">int:	采购订单流水号。</param>
        /// <returns>object:	采购订单实体。</returns>
        public object GetPORepealEntryNo(int EntryNo)
        {
            PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Pur_OrderGetRepealEntryNo", oHT, oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
            return oPurchaseOrderData;
        } 

		/// <summary>
		/// 获取液铝确认执行采购，尚未完成的订单清单。
		/// </summary>
		/// <returns>object:	采购订单实体。</returns>
		public object GetYLExecOrder()
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByExec",oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}
		/// <summary>
		/// 根据单据流水号和物料编号获取采购订单。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <returns>object:	采购订单实体。</returns>
		public object GetEntryByEntryNoAndItemCode(int EntryNo, string ItemCode)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@ItemCode", ItemCode);
			oSQLServer.ExecSPReturnDS("Pur_OrderGetByEntryNoAndItemCode",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		/// <summary>
		/// 根据单据编号和物料编号获取采购订单。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单编号。</param>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <returns>object:	采购订单实体。</returns>
		public object GetEntryByEntryCodeAndItemCode(string EntryCode, string ItemCode)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode", EntryCode);
			oHT.Add("@ItemCode", ItemCode);
			oSQLServer.ExecSPReturnDS("Pur_OrderGetByEntryCodeAndItemCode",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		/// <summary>
		/// 根据单据编号号获取采购订单。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单编号。</param>
		/// <returns>object:	采购订单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByEntryCode",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		/// <summary>
		/// 获取所有单据。
		/// </summary>
		/// <returns>object:	采购订单实体。</returns>
		public object GetEntryAll()
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_OrderGetAll",oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		/// <summary>
		/// 获取指定用户的所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>object:	采购订单实体。</returns>
        public object GetEntryAll(string UserLoginId)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetAll",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

        /// <summary>
        /// 获取指定用户的所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>object:	采购订单实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Pur_OrderGetByPerson", oHT, oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
            return oPurchaseOrderData;
        }
		/// <summary>
		/// 根据指定的制单部门获取采购订单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	采购订单实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByDeptCode",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		#endregion

		#region 采购订单专有方法
		/// <summary>
		/// 获取采购订单的所有数据源。
		/// </summary>
		/// <returns>POSData:	采购订单数据源数据实体。</returns>
		public POSData GetPOSAll(string UserLoginId)
		{
			POSData oPOSData = new POSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId", UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_POSGetAll",oHT,oPOSData.Tables[POSData.VPOS_VIEW]);
			return oPOSData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo",		EntryNo);
			oHT.Add("@EntryState",	newState);
			oHT.Add("@UserLoginId", UserLoginId);
			ret = oSQLServer.ExecSP("Pur_OrderAffirm",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.AFFIRM_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.ADD_SUCCESSED;
			}
			return ret;

		}

		public POSData GetPOSByPKIDs(string PKIDs)
		{
			POSData oPOSData = new POSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);
			oSQLServer.ExecSPReturnDS("Pur_POSGetByPKIDS",oHT,oPOSData.Tables[POSData.VPOS_VIEW]);
			return oPOSData;
		}
        /// <summary>
        /// 获取用途编号。
        /// </summary>
        /// <param name="entryNo">采购订单号</param>
        /// <param name="serialNo">序号</param>
        /// <returns>用途编号。</returns>
        public string GetReqReasonCode(int entryNo, int serialNo)
        {
            var sqlStatement = "Select dbo.GetRequisitionInfo(@EntryNo,@DocCode,@SerialNo,@RequestObject)";
            var parms = new[]{
                new SqlParameter("@EntryNo",DbType.Int32){Value=entryNo},
                new SqlParameter("@DocCode",DbType.Int16){Value = 3},
                new SqlParameter("@SerialNo",DbType.Int32){Value=serialNo},
                new SqlParameter("@RequestObject",SqlDbType.NVarChar,20){Value="ReqReasonCode"},
            };

            var obj = SqlHelper.ExecuteScalar(this.ConnString, CommandType.Text, sqlStatement, parms);
            return obj == null ? string.Empty : obj.ToString();
        }
		#endregion 

		#region 通用查询
		public PurchaseOrderData GetEntryBySQL(string Sql_Statement)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}
		public PurchaseOrderData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByDeptAndAuthorAndAuditResult",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}
		#endregion
	}
}
