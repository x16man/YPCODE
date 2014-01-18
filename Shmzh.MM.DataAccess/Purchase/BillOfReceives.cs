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
	/// 收料单的数据访问层。
	/// 
	/// </summary>
	public class BillOfReceives :IInItems
	{
		#region 构造函数
		public BillOfReceives()
		{}
		#endregion 构造函数
		#region 私有变量 
		/// <summary>
		/// SQLServer 对象。
		/// </summary>
		private SQLServer oSQLServer = new SQLServer();
		#endregion

		#region 属性
		/// <summary>
		/// 异常消息。
		/// </summary>
		public string Message
		{
			get {return this.oSQLServer.ExceptionMessage;}
		}
        /// <summary>
        /// 数据库连接字符串。
        /// </summary>
        public string ConnString {get {return ConfigurationManager.AppSettings["ConnectionString"];}}
		#endregion

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	收料单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(BillOfReceiveData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];
			//收料模式公用字段。
			//主表公用字段。
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
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);			//单据总计。
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);				      //备注。
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
			//收料单主表特有字段。
			oHT.Add("@PrvCode",			oRow[BillOfReceiveData.PRVCODE_FIELD]);				//供应商编号。
			oHT.Add("@PrvName",			oRow[BillOfReceiveData.PRVNAME_FIELD]);				//供应商名称。
			oHT.Add("@PrvBank",			oRow[BillOfReceiveData.PRVBANK_FIELD]);				//供应商开户银行。
			oHT.Add("@PrvAccount",		oRow[BillOfReceiveData.PRVACCOUNT_FIELD]);			//供应商账号。
			oHT.Add("@PrvRegNo",		oRow[BillOfReceiveData.PRVREGNO_FIELD]);			//供应商税务登记号。
			oHT.Add("@PrvTel",			oRow[BillOfReceiveData.PRVTEL_FIELD]);				//供应商电话。
			oHT.Add("@PrvFax",			oRow[BillOfReceiveData.PRVFAX_FIELD]);				//供应商传真。
			oHT.Add("@PayStyle",		oRow[BillOfReceiveData.PAYSTYLE_FIELD]);			//付款方式。
			oHT.Add("@InvoiceNo",		oRow[BillOfReceiveData.INVOICENO_FIELD]);			//发票号码。
			oHT.Add("@ChkNo",			oRow[BillOfReceiveData.CHKNO_FIELD]);				//验收单号。
			oHT.Add("@ChkResult",		oRow[BillOfReceiveData.CHKRESULT_FIELD]);			//验收情况。
			oHT.Add("@CurrencyCode",	oRow[BillOfReceiveData.CURRENCYCODE_FIELD]);		//货币代码。
			oHT.Add("@UsedFor",			oRow[BillOfReceiveData.USEDFOR_FIELD]);				//用于。
			oHT.Add("@BuyerCode",		oRow[BillOfReceiveData.BUYERCODE_FIELD]);			//采购员编号。
			oHT.Add("@BuyerName",		oRow[BillOfReceiveData.BUYERNAME_FIELD]);			//采购员名称。
			oHT.Add("@StoCode",			oRow[BillOfReceiveData.STOCODE_FIELD]);				//仓库编号。
			oHT.Add("@StoName",			oRow[BillOfReceiveData.STONAME_FIELD]);				//仓库名称。
			oHT.Add("@AcceptCode",		oRow[BillOfReceiveData.ACCEPTCODE_FIELD]);			//收料人编号。
			oHT.Add("@AcceptName",		oRow[BillOfReceiveData.ACCEPTNAME_FIELD]);			//收料人名称。
			oHT.Add("@AcceptDate",		oRow[BillOfReceiveData.ACCEPTDATE_FIELD]);			//收料日期。
			oHT.Add("@PcsCode",			oRow[BillOfReceiveData.PCSCODE_FIELD]);				//购方编号。
			oHT.Add("@PcsName",			oRow[BillOfReceiveData.PCSNAME_FIELD]);				//购方名称。
			oHT.Add("@TotalMoney",		oRow[BillOfReceiveData.TOTALMONEY_FIELD]);			//总价。
			oHT.Add("@TotalTax",		oRow[BillOfReceiveData.TOTALTAX_FIELD]);			//总税额。
			oHT.Add("@TotalFee",		oRow[BillOfReceiveData.TOTALFEE_FIELD]);			//总费用。
			oHT.Add("@TotalDiscount",	oRow[BillOfReceiveData.TOTALDISCOUNT_FIELD]);		//总折扣。
			oHT.Add("@JFKM",			oRow[BillOfReceiveData.JFKM_FIELD]);				//会计科目。
			oHT.Add("@ContractCode",	oRow[BillOfReceiveData.CONTRACTCODE_FIELD]);		//合同号。
			oHT.Add("@ParentEntryNo",	oRow[BillOfReceiveData.PARENTENTRYNO_FIELD]);		//对应蓝单据号。
			//收料单从表特有字段。
			oHT.Add("@SourceEntryList",	oRow[BillOfReceiveData.SOURCEENTRY_FIELD]);				//源单据号。
			oHT.Add("@SourceDocCodeList",	oRow[BillOfReceiveData.SOURCEDOCCODE_FIELD]);		//源单据类型。
			oHT.Add("@SourceSerialNoList",	oRow[BillOfReceiveData.SOURCESERIALNO_FIELD]);		//源单据序列号。
			oHT.Add("@BatchCodeList",       oRow[BillOfReceiveData.BATCHCODE_FIELD]);			//批号。
			oHT.Add("@PlanNumList",		oRow[BillOfReceiveData.PLANNUM_FIELD]);					//应收数量。
			oHT.Add("@TaxCodeList",		oRow[BillOfReceiveData.TAXCODE_FIELD]);					//税码。
			oHT.Add("@TaxRateList",		oRow[BillOfReceiveData.TAXRATE_FIELD]);					//税率。
			oHT.Add("@ItemTaxList",		oRow[BillOfReceiveData.ITEMTAX_FIELD]);					//税额。
			oHT.Add("@ItemFeeList",		oRow[BillOfReceiveData.ITEMFEE_FIELD]);					//费用。
			oHT.Add("@DiscountRateList",	oRow[BillOfReceiveData.DISCOUNTRATE_FIELD]);		//折扣率。
			oHT.Add("@ItemDiscountList",	oRow[BillOfReceiveData.ITEMDISCOUNT_FIELD]);		//折扣额。
			oHT.Add("@ItemSumList",			oRow[BillOfReceiveData.ITEMSUM_FIELD]);				//物料总金额。
			oHT.Add("@ItemNoInvoiceNumList",oRow[BillOfReceiveData.ITEMNOINVOICENUM_FIELD]);	//发票未到数量。
			oHT.Add("@ConCodeList",			oRow[BillOfReceiveData.CONCODE_FIELD]);					//架位编号。
			oHT.Add("@ConNameList",			oRow[BillOfReceiveData.CONNAME_FIELD]);					//架位名称。
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员
		/// <summary>
		/// 增加收料单。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret=true;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = this.oSQLServer.ExecSP("Pur_BillOfReceiveInsert", oHT);
//			if(ret == false)
//			{
//				//this.Message = BillOfReceiveData.ADD_FAILED;
//				this.Message = oSQLServer.ExceptionMessage;
//			}
//			else
//			{
//				this.Message = BillOfReceiveData.ADD_SUCCESSED;
//			}
			return ret;
		}
		/// <summary>
		/// 增加并且提交收料单。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret=true;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveInsertAndPresent", oHT);
			return ret;
		}
		/// <summary>
		/// 收料单修改。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret=true;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveUpdate", oHT);
			return ret;
		}
		/// <summary>
		/// 收料单修改并且提交。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret=true;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveUpdateAndPresent", oHT);
			return ret;
		}
		/// <summary>
		/// 收料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveDelete", oHT);
			return ret;
		}
		/// <summary>
		/// 更改收料单状态。
		/// </summary>
		/// <param name="EntryNo">int:	收料单号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@newState",newState);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveUpdateEntryState", oHT);
			return ret;
		}
		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object: 采购收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveFirstAudit", oHT);
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object: 采购收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];
			//压参数。
			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveSecondAudit", oHT);
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object: 采购收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveThirdAudit", oHT);
			
			return ret;
		}
		/// <summary>
		/// 采购收料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	采购收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_BillOfReceivePresent", oHT);
			return ret;
		}
		/// <summary>
		/// 采购收料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			ret = oSQLServer.ExecSP("Pur_BillOfReceiveCancel", oHT);
			return ret;
		}
		/// <summary>
		/// 采购收料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginID">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginID", UserLoginID);
			ret = oSQLServer.ExecSP("Pur_BillOfReceiveCancel", oHT);
			
			return ret;
		}
		/// <summary>
		/// 采购收料单付款。
		/// </summary>
		/// <param name="EntryNo">int:	采购收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginID">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Pay(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginID", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_BillOfReceivePay", oHT);
			return ret;
		}
		/// <summary>
		/// 根据收料单流水号获得收料单。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>object:	收料单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{

			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByEntryNo", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);

			return oEntry;
		}

        /// <summary>
        /// 根据收料单流水号获得收料单。
        /// </summary>
        /// <param name="EntryNo">int:	收料单流水号。</param>
        /// <returns>object:	收料单实体。</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {

            BillOfReceiveData oEntry = new BillOfReceiveData();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);
            oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetOldByEntryNo", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);

            return oEntry;
        }

		/// <summary>
		/// 根据收料单编号获取收料单的完整信息。
		/// </summary>
		/// <param name="EntryCode">string:	收料单编号。</param>
		/// <returns>object:	收料单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryCode);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByEntryCode", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);

			return oEntry;
		}

        public bool BRInvoiceNoUpdate(int EntryNo, string strInvoiceNo)
        {
            bool ret = true;
            Hashtable oHT = new Hashtable();

            oHT.Add("@EntryNo", EntryNo);
            oHT.Add("@InvoiceNo", strInvoiceNo);

            ret = oSQLServer.ExecSP("Pur_BillOfReceiveGetByEntryNoUpdate", oHT);
            return ret;
        }


		/// <summary>
		/// 根据收料单开出部门获取收料单的基本信息。
		/// </summary>
		/// <param name="DeptCode">string:	填单部门信息。</param>
		/// <returns>object:	收料单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept", DeptCode);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByDept", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		/// <summary>
		/// 获取所有收料单。
		/// </summary>
		/// <returns>object:	收料单实体。</returns>
		public object GetEntryAll()
		{
			return null;
		}
		/// <summary>
		/// 获取特定用户的所有收料单。
		/// </summary>
		/// <returns>object:	收料单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			BillOfReceiveData oEntry = new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetAll",oHT,oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}

        /// <summary>
        /// 获取特定用户的所有收料单。
        /// </summary>
        /// <returns>object:	收料单实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            BillOfReceiveData oEntry = new BillOfReceiveData();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);
            oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByPerson", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
            return oEntry;
        }
		/// <summary>
		/// 根据发票号和物料编号获取采购收料单信息.
		/// </summary>
		/// <param name="InvoiceNo">string:	发票号.</param>
		/// <param name="ItemCode">string:	物料编号.</param>
		/// <returns>object:	收料单实体。</returns>
		public object GetEntryByInvoiceNoAndItemCode(string InvoiceNo, string ItemCode)
		{
			BillOfReceiveData oEntry = new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@InvoiceNo",InvoiceNo);
			oHT.Add("@ItemCode", ItemCode);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByInvoiceNoAndItemCode",oHT,oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		#endregion

		#region 收料单专有方法 
		/// <summary>
		/// 根据供应商代码获得数据源。
		/// </summary>
		/// <param name="PrvCode">string:	供应商代码。</param>
		/// <returns>object:	数据源实体。</returns>
		public object GetEntryByPrvCode(string PrvCode)
		{
			PBSData oEntry = new PBSData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PrvCode", PrvCode);
			oSQLServer.ExecSPReturnDS("Pur_PBSGetByPrvCode", oHT, oEntry.Tables[PBSData.VPBS_VIEW]);
			return oEntry;
		}
		/// <summary>
		/// 收料模式下获取采购收料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <remarks >初始化收料数量和存放架位。</remarks>
		/// <returns>object:	采购收料单实体。</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByEntryNoInMode", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		/// <summary>
		/// 根据状态获取单据。
		/// </summary>
		/// <param name="EntryState">string:	单据状态。</param>
		/// <returns>object:	收料单数据集。</returns>
		public object GetEntryByState(string EntryState)
		{
			BillOfReceiveData oBORData = new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryState", EntryState);
			oSQLServer.ExecSPReturnDS("Pur_BORGetByState", oHT, oBORData.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oBORData;
		}
		/// <summary>
		/// 根据指定的蓝单据号获取红字单据初始信息。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>object:	收料单实体。</returns>
		public object GetEntryRedByEntryNo(int EntryNo)
		{
			BillOfReceiveData oBORData = new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveRed",oHT,oBORData.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oBORData;
		}
		/// <summary>
		/// 根据Pkid列表获得数据源明细内容。
		/// </summary>
		/// <param name="List">string:	数据源明细PKID。</param>
		/// <returns>object:	数据源明细内容。</returns>
		public object GetPBSDByList(string List)
		{
			PBSDData oEntry = new PBSDData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@List", List);
			oSQLServer.ExecSPReturnDS("Pur_PBSDGetByEntry", oHT, oEntry.Tables[PBSDData.PBSD_VIEW]);
			return oEntry;
		}
		/// <summary>
		/// 收料单收料方法。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Receive( object Entry)
		{
			bool ret = false;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
            Hashtable oHT = this.FillHashTable(oEntry);
            ret = oSQLServer.ExecSP("Pur_BillOfReceiveReceive", oHT);
			return ret;
		}
        public bool Reject(int EntryNo, string UserLoginId)
        {
            bool ret = false;
            
            Hashtable oHT = new Hashtable();

            oHT.Add("@EntryNo", EntryNo);
            oHT.Add("@UserLoginId", UserLoginId);
			
            ret = oSQLServer.ExecSP("Pur_BillOfReceiveRefuse", oHT);
            return ret;
        }
        /// <summary>
        /// 获取用途编号。
        /// </summary>
        /// <param name="entryNo">收料单号。</param>
        /// <param name="serialNo">序号</param>
        /// <returns>用途编号。</returns>
        public string GetReqReasonCode(int entryNo,  int serialNo)
        {
            var sqlStatement = "Select dbo.GetRequisitionInfo(@EntryNo,@DocCode,@SerialNo,@RequestObject)";
            var parms = new[]{
                new SqlParameter("@EntryNo",DbType.Int32){Value=entryNo},
                new SqlParameter("@DocCode",DbType.Int16){Value = 6},
                new SqlParameter("@SerialNo",DbType.Int32){Value=serialNo},
                new SqlParameter("@RequestObject",SqlDbType.NVarChar,20){Value="ReqReasonCode"},
            };

            var obj = SqlHelper.ExecuteScalar(this.ConnString,CommandType.Text,sqlStatement,parms);
            return obj == null ? string.Empty : obj.ToString();
        }
		#endregion

		#region 通用查询
		/// <summary>
		/// 根据指定SQL来进行查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL 语句。</param>
		/// <returns>BillOfReceiveData:	收料单实体。</returns>
		public BillOfReceiveData GetEntryBySQL(string Sql_Statement)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		/// <summary>
		/// 根据制单部门、制单人、审批结果来返回采购收料单清单。
		/// </summary>
		/// <param name="AuthorDept">string:	制单部门。</param>
		/// <param name="AuthorCode">string:	制单人。</param>
		/// <param name="AuditResult">int:	审批结果。</param>
		/// <returns>BillOfReceiveData:	收料单实体。</returns>
		public BillOfReceiveData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult, DateTime StartDate, DateTime EndDate)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByDeptAndAuthorAndAuditResult", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		#endregion
	}
}
