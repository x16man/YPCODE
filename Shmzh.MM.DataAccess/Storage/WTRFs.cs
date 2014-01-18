namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
	using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;

	#region public class WTRFs
	/// <summary>
	/// 收料型单据的公共数据访问层。
	/// </summary>
	public class WTRFs:Messages,IInItems
	{
		#region 构造函数
		public WTRFs()
		{}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">WTRFData:	转库单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(WTRFData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[WTRFData.WTRF_TABLE].Rows[0];
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
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);					//单据合计金额。
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//备注。
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//物料编号。
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//物料名称。
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//物料规格。
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//物料单价。

			oHT.Add("@PlanNumList",		oRow[WTRFData.PLANNUM_FIELD]);					//应转数量。

			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			//物料需求单特有字段。
			oHT.Add("@TgtStoName",			oRow[WTRFData.TGTSTONAME_FIELD]);				//转入仓库名称。
			oHT.Add("@TgtStoCode",		oRow[WTRFData.TGTSTOCODE_FIELD]);					//转入仓库编号。
			oHT.Add("@SrcStoCode",		oRow[WTRFData.SRCSTOCODE_FIELD]);					//发出仓库编号。
			oHT.Add("@SrcStoName",	oRow[WTRFData.SRCSTONAME_FIELD]);						//发出仓库名称。
			oHT.Add("@TransferDate",	oRow[WTRFData.TRANSFERDATE_FIELD]);					//转库日期。
			oHT.Add("@SrcStoManagerCode",		oRow[WTRFData.SRCSTOMANAGERCODE_FIELD]);	//发出仓库管理员编号。
			oHT.Add("@SrcStoManager",		oRow[WTRFData.SRCSTOMANAGER_FIELD]);			//发出仓库管理员名称。
			oHT.Add("@TgtStoManagerCode",	oRow[WTRFData.TGTSTOMANAGERCODE_FIELD]);		//转入仓库管理员编号。
			oHT.Add("@TgtStoManager",		oRow[WTRFData.TGTSTOMANAGER_FIELD]);			//转入仓库管理员名称。
//			oHT.Add("@PlanNum",		oRow[WTRFData.PLANNUM_FIELD]);							//应转数量。
//			oHT.Add("@ItemNum",	oRow[WTRFData.ITEMNUM_FIELD]);								//实转数量。
			oHT.Add("@JFKM",		oRow[WTRFData.JFKM_FIELD]);									//借方科目。
			
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员
		/// <summary>
		/// 单据增加。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WTRFData oEntry = (WTRFData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WTRFInsert",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WTRFInsert,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 新建并马上提交单据。
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WTRFData oEntry = (WTRFData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WTRFInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WTRFInsertAndPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 单据修改。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret = true;
			WTRFData oEntry = (WTRFData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WTRFUpdate",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WTRFUpdate,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 修改并马上提交转库单。
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WTRFData oEntry = (WTRFData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WTRFUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WTRFUpdateAndPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 单据删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			if((new SQLServer()).ExecSP("WTRFDelete",oHT) == false)
			{
				this.Message="Error,WTRFDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 单据状态更改。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	单据新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",EntryState);
			if((new SQLServer()).ExecSP("WTRFUpdateState",oHT) == false)
			{
				this.Message="Error,WTRFUpdateState,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			WTRFData oEntry= (WTRFData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTRFData.WTRF_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WTRFFirstAudit",oHT) == false)
			{
				this.Message="Error,WTRFFirstAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			WTRFData oEntry= (WTRFData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTRFData.WTRF_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WTRFSecondAudit",oHT) == false)
			{
				this.Message="Error,WTRFSecondAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			WTRFData oEntry= (WTRFData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTRFData.WTRF_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WTRFThirdAudit",oHT) == false)
			{
				this.Message="Error,WTRFThirdAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 转库单提交。
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo,string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId",UserLoginId);
			
			if((new SQLServer()).ExecSP("WTRFPresent",oHT) == false)
			{
				this.Message="Error,WTRFPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 转库单作废。
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo,string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			if((new SQLServer()).ExecSP("WTRFCancel",oHT) == false)
			{
				this.Message="Error,WTRFCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo,string newState, string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID",UserLoginID);
			
			if((new SQLServer()).ExecSP("WTRFCancel",oHT) == false)
			{
				this.Message="Error,WTRFCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("WTRFGetByEntryNo",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// 根据单据编号获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryCode);
			oSQLServer.ExecSPReturnDS("WTRFGetByEntryCode",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// 获取所有请购单。
		/// </summary>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryAll()
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("WTRFGetAll",oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// 根据指定的制单部门获取转库单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);
			oSQLServer.ExecSPReturnDS("WTRFGetByDeptCode",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		#endregion
	
		#region 通用查询
		/// <summary>
		/// 用户默认的查询方案。
		/// </summary>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("WTRFGetAll",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// 根据查询方案获取结果集。
		/// </summary>
		/// <param name="Sql_statement"></param>
		/// <returns></returns>
		public WTRFData GetEntryBySQL(string Sql_Statement)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		#endregion

		#region 转库单专有方法
		/// <summary>
		/// 获取转库单的所有数据源。
		/// </summary>
		/// <returns>WTRFData:	转库单数据源数据实体。</returns>
		public WTRFData GetWTRFAll()
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("WTRFGetAll",oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo",		EntryNo);
			oHT.Add("@EntryState",	newState);
			oHT.Add("@UserLoginId", UserLoginId);
			ret = oSQLServer.ExecSP("OrderAffirm",oHT);
			if(ret == false)
			{
				this.Message = WTRFData.AFFIRM_FAILED;
			}
			else
			{
				this.Message = WTRFData.ADD_SUCCESSED;
			}
			return ret;

		}
		public WTRFData GetWTRFByPKIDs(string PKIDs)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);
			oSQLServer.ExecSPReturnDS("WTRFGetByPKIDS",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		#endregion 

		#region 转库专有方法
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("WTRFGetByEntryNoOutMode",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}

		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("WTRFGetByEntryNoInMode",oHT,oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		/// <summary>
		/// 根据状态获取转库单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>object:	转库单实体。</returns>
		public object GetEntryByState()
		{
			WTRFData oWTRFData = new WTRFData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("WTRFGetByState",oWTRFData.Tables[WTRFData.WTRF_TABLE]);
			return oWTRFData;
		}
		public bool TransDrawOutStock(int EntryNo, string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			int output=0;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@SerialNoList", SerialNoList);
			oHT.Add("@ItemNumList", ItemNumList);
			oHT.Add("@PKIDList", PKIDList);
			oHT.Add("@ItemDrawNumList", ItemDrawNumList);
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@UserName",UserName);
			oHT.Add("@UserLoginId",UserLoginId);
			oHT.Add("@EntryState",DocStatus.Drawed);
			oHT.Add("@OutPut",output);

			ret = oSQLServer.ExecSP("WTRFTransStockOut",oHT);
			if(ret == false)
			{
				this.Message = WTRFData.OUT_FAILED;
			}
			else if(output == -1)
			{
				this.Message = WTRFData.ROLL_FAILED;
			}
			else
			{
				this.Message = WTRFData.OUT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 转库单收料方法。
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool TransDrawInStock( int EntryNo,string StoCode,string StoName, string SerialNoList,string ItemCodeList,string ConCodeList,string ConNameList,string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			
			int output=0;

			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@DocCode", DocType.TRF);
			oHT.Add("@StoCode", StoCode);
			oHT.Add("@StoName", StoName);
			oHT.Add("@SerialNoList",SerialNoList);
			oHT.Add("@ItemCodeList",ItemCodeList);
			oHT.Add("@ConCodeList",ConCodeList);
			oHT.Add("@ConNameList",ConNameList);
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@UserName",UserName);
			oHT.Add("@UserLoginId",UserLoginId);
			oHT.Add("@EntryState",DocStatus.Received);
			oHT.Add("@OutPut",output);

		ret = oSQLServer.ExecSP("WTRFTransStockIn", oHT); //undone
			if(ret == false)
			{
				this.Message = WTRFData.ADD_FAILED;
			}
			else if(output == -1)
			{
				this.Message = WTRFData.ROLL_FAILED;
			}
			else
			{
				this.Message = WTRFData.ADD_SUCCESSED;
			}
			return ret;
		}
		#endregion
	}
	#endregion public class WTRFs
}