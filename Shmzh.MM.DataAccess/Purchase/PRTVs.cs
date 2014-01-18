using System;
using System.Collections;
using System.Data;
using MZHCommon.Database;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// 采购退料单的数据访问层。
	/// </summary>
	public class PRTVs :Messages, IInItems
	{
		#region 构造函数
		public PRTVs()
		{}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">PRTVData:	采购退料单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(PRTVData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PRTVData.PRTV_TABLE].Rows[0];
			//收料模式公用字段。
			//主表公用字段。
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//单据流水号。
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//单据编号。
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//单据类型。
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//单据类型名称。
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//单据类型文档编号。
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//单据状态。
		//	oHT.Add("@EntryDate",		oRow[InItemData.ENTRYDATE_FIELD]);					//制单日期。
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//制单人编号。
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//制单人名称。
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//制单人登录名。
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//制单人部门。
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//制单人部门名称。
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);			        //单据总计。
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);				        //备注。
			//从表公用字段。
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//物料编号。
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//物料名称。
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//物料规格。
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//物料单价。
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//物料数量。
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",	oRow[InItemData.ITEMUNITNAME_FIELD]);			//物料单位描述。
			//采购退料单主表特有字段。
			oHT.Add("@PrvCode",			oRow[PRTVData.PRVCODE_FIELD]);				//供应商编号。
			oHT.Add("@PrvName",			oRow[PRTVData.PRVNAME_FIELD]);				//供应商名称。
			oHT.Add("@PrvBank",			oRow[PRTVData.PRVBANK_FIELD]);				//供应商开户银行。
			oHT.Add("@PrvAccount",		oRow[PRTVData.PRVACCOUNT_FIELD]);			//供应商账号。
			oHT.Add("@PrvRegNo",		oRow[PRTVData.PRVREGNO_FIELD]);			//供应商税务登记号。
			oHT.Add("@PrvTel",			oRow[PRTVData.PRVTEL_FIELD]);				//供应商电话。
			oHT.Add("@PrvFax",			oRow[PRTVData.PRVFAX_FIELD]);				//供应商传真。
			oHT.Add("@PayStyle",		oRow[PRTVData.PAYSTYLE_FIELD]);			//付款方式。
			oHT.Add("@InvoiceNo",		oRow[PRTVData.INVOICENO_FIELD]);			//发票号码。
			oHT.Add("@ChkNo",			oRow[PRTVData.CHKNO_FIELD]);				//验收单号。
			oHT.Add("@ChkResult",		oRow[PRTVData.CHKRESULT_FIELD]);			//验收情况。
			oHT.Add("@CurrencyCode",	oRow[PRTVData.CURRENCYCODE_FIELD]);		//货币代码。
			oHT.Add("@UsedFor",			oRow[PRTVData.USEDFOR_FIELD]);				//用于。
			oHT.Add("@BuyerCode",		oRow[PRTVData.BUYERCODE_FIELD]);			//采购员编号。
			oHT.Add("@BuyerName",		oRow[PRTVData.BUYERNAME_FIELD]);			//采购员名称。
			oHT.Add("@StoCode",			oRow[PRTVData.STOCODE_FIELD]);				//仓库编号。
			oHT.Add("@StoName",			oRow[PRTVData.STONAME_FIELD]);				//仓库名称。
			oHT.Add("@AcceptCode",		oRow[PRTVData.ACCEPTCODE_FIELD]);			//收料人编号。
			oHT.Add("@AcceptName",		oRow[PRTVData.ACCEPTNAME_FIELD]);			//收料人名称。
			oHT.Add("@AcceptDate",		oRow[PRTVData.ACCEPTDATE_FIELD]);			//收料日期。
			oHT.Add("@PcsCode",			oRow[PRTVData.PCSCODE_FIELD]);				//购方编号。
			oHT.Add("@PcsName",			oRow[PRTVData.PCSNAME_FIELD]);				//购方名称。
			oHT.Add("@TotalMoney",		oRow[PRTVData.TOTALMONEY_FIELD]);			//总价。
			oHT.Add("@TotalTax",		oRow[PRTVData.TOTALTAX_FIELD]);			//总税额。
			oHT.Add("@TotalFee",		oRow[PRTVData.TOTALFEE_FIELD]);			//总费用。
			oHT.Add("@TotalDiscount",	oRow[PRTVData.TOTALDISCOUNT_FIELD]);		//总折扣。
			oHT.Add("@JFKM",			oRow[BillOfReceiveData.JFKM_FIELD]);				//会计科目。
		
			
			//采购退料单从表特有字段。
			oHT.Add("@SourceEntryList",	oRow[PRTVData.SOURCEENTRY_FIELD]);			//源单据号。
			oHT.Add("@SourceDocCodeList",	oRow[PRTVData.SOURCEDOCCODE_FIELD]);		//源单据类型。
			oHT.Add("@SourceSerialNoList",	oRow[PRTVData.SOURCESERIALNO_FIELD]);		//源单据序列号。
			oHT.Add("@BatchCodeList", oRow[PRTVData.BATCHCODE_FIELD]);               //批号。
			oHT.Add("@PlanNumList",		oRow[PRTVData.PLANNUM_FIELD]);				//应收数量。
			oHT.Add("@TaxCodeList",		oRow[PRTVData.TAXCODE_FIELD]);				//税码。
			oHT.Add("@TaxRateList",		oRow[PRTVData.TAXRATE_FIELD]);				//税率。
			oHT.Add("@ItemTaxList",		oRow[PRTVData.ITEMTAX_FIELD]);				//税额。
			oHT.Add("@ItemFeeList",		oRow[PRTVData.ITEMFEE_FIELD]);				//费用。
			oHT.Add("@DiscountRateList",	oRow[PRTVData.DISCOUNTRATE_FIELD]);		//折扣率。
			oHT.Add("@ItemDiscountList",	oRow[PRTVData.ITEMDISCOUNT_FIELD]);		//折扣额。
			oHT.Add("@ItemSumList",			oRow[PRTVData.ITEMSUM_FIELD]);				//物料总金额。
			oHT.Add("@ItemNoInvoiceNumList",oRow[PRTVData.ITEMNOINVOICENUM_FIELD]);	//发票未到数量。
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员
		/// <summary>
		/// 增加采购退料单。
		/// </summary>
		/// <param name="Entry">object:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret=true;
			PRTVData oEntry= (PRTVData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			ret = oSQLServer.ExecSP("Pur_PRTVInsert", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.ADD_FAILED;
			}
			else
			{
				this.Message = PRTVData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 新建并且马上提交采购退料单。
		/// </summary>
		/// <param name="Entry">object:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			PRTVData oEntry = (PRTVData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			ret = oSQLServer.ExecSP("Pur_PRTVInsertAndPresent", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.ADD_FAILED;
			}
			else
			{
				this.Message = PRTVData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单修改。
		/// </summary>
		/// <param name="Entry">object:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret=true;
			PRTVData oEntry= (PRTVData)Entry;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			ret = oSQLServer.ExecSP("Pur_PRTVUpdate", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PRTVData.UPDATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	采购退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret=true;
			PRTVData oEntry= (PRTVData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			ret = oSQLServer.ExecSP("Pur_PRTVUpdateAndPresent", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PRTVData.UPDATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购退料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			ret = oSQLServer.ExecSP("Pur_PRTVDelete", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.DELETE_FAILED;
			}
			else
			{
				this.Message = PRTVData.DELETE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 更改采购退料单状态。
		/// </summary>
		/// <param name="EntryNo">int:	采购退料单号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@newState",newState);
			ret = oSQLServer.ExecSP("Pur_PRTVUpdateEntryState", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PRTVData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	采购退货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			PRTVData oEntry= (PRTVData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PRTVData.PRTV_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PRTVFirstAudit", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = PRTVData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	采购退货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			PRTVData oEntry= (PRTVData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PRTVData.PRTV_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PRTVSecondAudit", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = PRTVData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	采购退货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			PRTVData oEntry= (PRTVData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PRTVData.PRTV_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PRTVThirdAudit", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PRTVData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	采购采购退料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginID",UserLoginId);

			ret = oSQLServer.ExecSP("Pur_PRTVPresent", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PRTVData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购退料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购退料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			ret = oSQLServer.ExecSP("Pur_PRTVCancel", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PRTVData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginID", UserLoginId);
			ret = oSQLServer.ExecSP("Pur_PRTVCancel", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PRTVData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 根据采购退料单流水号获得采购退料单。
		/// </summary>
		/// <param name="EntryNo">int:	采购退料单流水号。</param>
		/// <returns>object:	采购退料单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{

			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByEntryNo", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);

			return oEntry;
		}
		/// <summary>
		/// 在发料模式下根据采购退料单流水号获得采购退料单。
		/// </summary>
		/// <param name="EntryNo">int:	采购退料单流水号。</param>
		/// <returns>object:	采购退料单实体。</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{

			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByEntryNoInMode", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);

			return oEntry;
		}
		/// <summary>
		/// 根据采购退料单编号获取采购退料单的完整信息。
		/// </summary>
		/// <param name="EntryCode">string:	采购退料单编号。</param>
		/// <returns>object:	采购退料单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{

			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode", EntryCode);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByEntryCode", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);

			return oEntry;
		}
		/// <summary>
		/// 根据采购退料单开出部门获取采购退料单的基本信息。
		/// </summary>
		/// <param name="DeptCode">string:	填单部门信息。</param>
		/// <returns>object:	采购退料单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept", DeptCode);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByDeptCode", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);
			return oEntry;
		}
		/// <summary>
		/// 获取所有采购退料单。
		/// </summary>
		/// <returns>object:	采购退料单实体。</returns>
		public object GetEntryAll()
		{
			PRTVData oEntry = new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetAll",oEntry.Tables[PRTVData.PRTV_TABLE]);
			return oEntry;
		}

        /// <summary>
        /// 获取所有采购退料单。
        /// </summary>
        /// <returns>object:	采购退料单实体。</returns>
        public object GetEntryByPerson(string strEmpCode)
        {
            PRTVData oEntry = new PRTVData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", strEmpCode);
            oSQLServer.ExecSPReturnDS("Pur_PRTVGetByPerson", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);
            return oEntry;
        }

       
		#endregion

		#region 采购退料单专有方法 
//		/// <summary>
//		/// 根据供应商代码获得数据源。
//		/// </summary>
//		/// <param name="PrvCode"></param>
//		/// <returns></returns>
//		public object GetEntryByPrvCode(string PrvCode)
//		{
//			PBSData oEntry = new PBSData();
//			SQLServer oSQLServer = new SQLServer();
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@PrvCode", PrvCode);
//			oSQLServer.ExecSPReturnDS("Pur_PBSGetByPrvCode", oHT, oEntry.Tables[PBSData.VPBS_VIEW]);
//			return oEntry;
//		}
//
//		/// <summary>
//		/// 根据Pkid获得数据源明细内容。
//		/// </summary>
//		/// <param name="List"></param>
//		/// <returns></returns>
//		public object GetPBSDByList(string List)
//		{
//			PBSDData oEntry = new PBSDData();
//			SQLServer oSQLServer = new SQLServer();
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@List", List);
//			oSQLServer.ExecSPReturnDS("Pur_PBSDGetByEntry", oHT, oEntry.Tables[PBSDData.PBSD_VIEW]);
//			return oEntry;
//		}

//		public object GetCBRSByPKID(string PKID)
//		{
//			CBRSData oEntry = new CBRSData();
//			SQLServer oSQLServer = new SQLServer();
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@PKID",PKID);
//			oSQLServer.ExecSPReturnDS("Pur_CBRSGetByPKID",oHT,oEntry.Tables[CBRSData.CBRS_VIEW]);
//			return oEntry;
//		}
		/// <summary>
		/// 根据PKID获取采购退料单数据来源非明细信息。
		/// </summary>
		/// <param name="PKID">string:	PKID.</param>
		/// <returns>object:	采购退料单数据来源非明细信息实体。</returns>
		public object GetRTVSByPKID(string PKID)
		{
			RTVSData oEntry = new RTVSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID",PKID);
			oSQLServer.ExecSPReturnDS("Pur_RTVSGetByPKID",oHT,oEntry.Tables[RTVSData.RTVS_VIEW]);
			return oEntry;
		}

//		public object GetCBRSDetailByPKID(string PKID)
//		{
//			CBRSDetailData oEntry = new CBRSDetailData();
//			SQLServer oSQLServer = new SQLServer();
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@PKID",PKID);
//			oSQLServer.ExecSPReturnDS("Pur_CBRSDetailGetByPKID",oHT,oEntry.Tables[CBRSDetailData.CBRSD_VIEW]);
//			return oEntry;
//		}
		/// <summary>
		/// 根据指定的PKID获取数据来源的明细。
		/// </summary>
		/// <param name="PKID">string:	PKID.</param>
		/// <returns>object:	数据来源的明细实体。</returns>
		public object GetRTVSDetailByPKID(string PKID)
		{
			RTVSDetailData oEntry = new RTVSDetailData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID",PKID);
			oSQLServer.ExecSPReturnDS("Pur_RTVSDetailGetByPKID",oHT,oEntry.Tables[RTVSDetailData.RTVSD_VIEW]);
			return oEntry;
		}
		/// <summary>
		/// 生产退料单收料
		/// </summary>
		/// <param name="EntryNo">退料单单据流水号</param>
		/// <param name="SerialNoList">单据明细内容顺序号列表，以","分隔</param>
		/// <param name="ItemNumList">退料单物料发料数列表，以","分隔</param>
		/// <param name="PKIDList">仓库物料的PKID列表，以","分隔</param>
		/// <param name="ItemDrawNumList">具体从仓库选择后得到的发料数列表，以","分隔</param>
		/// <param name="UserCode">用户</param>
		/// <param name="UserName">用户名</param>
		/// <param name="UserLoginId">登陆ID</param>
		/// <returns></returns>
		public bool RTVReceive( int EntryNo,string SerialNoList,string ItemNumList,string PKIDList,string ItemDrawNumList,string UserCode, string UserName, string UserLoginId,string ItemPriceList)
		{
			bool ret = false;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);			
			oHT.Add("@SerialNoList",SerialNoList);
			oHT.Add("@ItemNumList",ItemNumList);
			oHT.Add("@PKIDList",PKIDList);
			oHT.Add("@ItemDrawNumList",ItemDrawNumList);
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@UserName",UserName);			
			oHT.Add("@UserLoginId",UserLoginId);
			oHT.Add("@ItemPriceList",ItemPriceList);

			ret = oSQLServer.ExecSP("Pur_RTVReceive", oHT); 
			if(ret == false)
			{
				this.Message = PRTVData.DRAW_FAILED;
			}
			return ret;
		}		   
		#endregion

		#region 通用查询
		public PRTVData GetEntryBySQL(string Sql_Statement)
		{
			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);
			return oEntry;
		}
		public PRTVData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByDeptAndAuthorAndAuditResult", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);
			return oEntry;
		}
		#endregion
	}
}
