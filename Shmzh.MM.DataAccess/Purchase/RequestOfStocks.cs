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

	#region public class RequestOfStocks
	/// <summary>
	/// 收料型单据的公共数据访问层。
	/// </summary>
	public class RequestOfStocks:Messages,IInItems
    {
private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Property
        /// <summary>
        /// 数据库连接字符串。
        /// </summary>
        public string ConnString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
        #endregion

        #region 构造函数
        public RequestOfStocks()
		{}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	采购申请单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(RequestOfStockData oEntry)
		{
			var oHT = new Hashtable();

		    var oRow = oEntry.Tables[RequestOfStockData.PROS_TABLE].Rows[0];
			//收料模式公用字段。
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//单据流水号。
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//单据编号。
            oHT.Add("@DocCode",         oRow[InItemData.DOCCODE_FIELD]);					//单据类型。
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
			//物料需求单特有字段。
			oHT.Add("@ReqDept",			oRow[RequestOfStockData.REQDEPT_FIELD]);			//申请部门。
			oHT.Add("@ReqDeptName",		oRow[RequestOfStockData.REQDEPTNAME_FIELD]);		//申请部门名称。
			oHT.Add("@Proposer",		oRow[RequestOfStockData.PROPOSER_FIELD]);			//申请人。
			oHT.Add("@ProposerCode",	oRow[RequestOfStockData.PROPOSERCODE_FIELD]);		//申请人编号。
			oHT.Add("@ReqReasonCode",	oRow[RequestOfStockData.REQREASONCODE_FIELD]);		//申请理由编号。
			oHT.Add("@ReqReason",		oRow[RequestOfStockData.REQREASON_FIELD]);			//申请理由。
			oHT.Add("@ReqDateList",		oRow[RequestOfStockData.REQDATE_FIELD]);			//要求到货日期。
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
		    var oEntry = (RequestOfStockData)Entry;
			var oSQLServer = new SQLServer();
			var oHT = this.FillHashTable(oEntry);
			
			var ret = oSQLServer.ExecSP("Pur_RequestOfStockInsert",oHT);
			
			if(!ret)
			{
				this.Message="Error,Pur_RequestOfStockInsert,Please look the log file!";
			}
			return ret;
		}

		/// <summary>
		/// 新建并马上提交单据。
		/// </summary>
		/// <param name="Entry">object:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
		    var oEntry = (RequestOfStockData)Entry;
			var oSQLServer = new SQLServer();
			var oHT = this.FillHashTable(oEntry);
			
			var ret = oSQLServer.ExecSP("Pur_RequestOfStockInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_RequestOfStockInsertAndPresent,Please look the log file!";
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
		    var oEntry = (RequestOfStockData)Entry;
			var oSQLServer = new SQLServer();
			var oHT = this.FillHashTable(oEntry);
			
			var ret = oSQLServer.ExecSP("Pur_RequestOfStockUpdate",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_RequestOfStockUpdate,Please look the log file!";
			}
			return ret;
		}
		/// <summary>
		/// 修改并马上提交采购申请单。
		/// </summary>
		/// <param name="Entry">object:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
		    var oEntry = (RequestOfStockData)Entry;
			var oSQLServer = new SQLServer();
			var oHT = this.FillHashTable(oEntry);
			
			var ret = oSQLServer.ExecSP("Pur_RequestOfStockUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_RequestOfStockUpdateAndPresent,Please look the log file!";
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
			var ret = true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}};
		    if((new SQLServer()).ExecSP("Pur_RequestOfStockDelete",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 单据状态更改。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
        /// <param name="EntryState">string:	单据新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			var ret = true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}, {"@EntryState", EntryState}};
		    if((new SQLServer()).ExecSP("Pur_RequestOfStockUpdateState",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockUpdateState,Please look the log file!";
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
			var ret = true;
			var oHT=new Hashtable();
			var oEntry= (RequestOfStockData)Entry;
		    var oRow = oEntry.Tables[RequestOfStockData.PROS_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

            Logger.Info("exec Pur_RequestOfStockFirstAudit");
			if((new SQLServer()).ExecSP("Pur_RequestOfStockFirstAudit",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockFirstAduit,Please look the log file!";
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
			var ret = true;
			var oHT=new Hashtable();
			var oEntry= (RequestOfStockData)Entry;
		    var oRow = oEntry.Tables[RequestOfStockData.PROS_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Pur_RequestOfStockSecondAudit",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockSecondAduit,Please look the log file!";
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
			var ret=true;
			var oHT=new Hashtable();
			var oEntry= (RequestOfStockData)Entry;
		    var oRow = oEntry.Tables[RequestOfStockData.PROS_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Pur_RequestOfStockThirdAudit",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockThirdAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
        /// <summary>
        /// 物资审核。
        /// </summary>
        /// <param name="entryNo">紧急申购单号。</param>
        /// <param name="entryState">状态</param>
        /// <param name="audit4">审核结果</param>
        /// <param name="assessor4">审核人</param>
        /// <param name="auditSuggest4">审核意见</param>
        /// <param name="itemCodes">物料编号串。</param>
        /// <param name="loginId">审批人登录名</param>
        /// <returns>bool</returns>
        public bool WZAudit(int entryNo, string entryState, string audit4,string assessor4,string auditSuggest4,string itemCodes,string loginId)
        {
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo},
                                new SqlParameter("@EntryState",SqlDbType.Char,1){Value = entryState},
                                new SqlParameter("@Audit4",SqlDbType.Char,1){Value = audit4},
                                new SqlParameter("@Assessor4",SqlDbType.NVarChar,20){Value = assessor4},
                                new SqlParameter("@AuditSuggest4",SqlDbType.NVarChar,50){Value = auditSuggest4},
                                new SqlParameter("@ItemCodes",SqlDbType.NVarChar,4000){Value = itemCodes},
                                new SqlParameter("@UserLoginId",SqlDbType.NVarChar,20){Value = loginId},
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnString, "Pur_RequestOfStockWZAudit", parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                this.Message = ex.Message;
                return false;
            }
        }
		/// <summary>
		/// 三级审批批量处理。
		/// </summary>
		/// <param name="TaskIDs">string:	任务ID串。</param>
		/// <param name="Assessor">string;	审批人。</param>
		/// <param name="UserLoginId">string:	登陆名。</param>
		/// <param name="EntryState">string:	单据状态。(T/Z)</param>
		/// <param name="Flag">string:	审批结果。(Y/N)</param>
		/// <returns>成功返回true，失败返回false。</returns>
		public bool BatchThirdAudit(string TaskIDs,string Assessor,string UserLoginId,string EntryState,string Flag)
		{
		    var oHT=new Hashtable {{"@Task_IDs", TaskIDs}, {"@Assessor", Assessor}, {"@UserLoginId", UserLoginId}, {"@EntryState", EntryState}, {"@Flag", Flag}};
		    var ret = new SQLServer().ExecSP("WF_BatchThirdAudit", oHT);
		    if (!ret)
			{
				this.Message = "批量审批出错！";
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单提交。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginId">用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo,string newState, string UserLoginId)
		{
			var ret=true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}, {"@EntryState", newState}, {"@UserLoginId", UserLoginId}};

		    if((new SQLServer()).ExecSP("Pur_RequestOfStockPresent",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo,string newState)
		{
			var ret=true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}, {"@EntryState", newState}};

		    if((new SQLServer()).ExecSP("Pur_RequestOfStockCancel",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
        /// <param name="UserLoginID">string:	操作人。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo,string newState,string UserLoginID)
		{
			var ret=true;
			var oHT=new Hashtable {{"@EntryNo", EntryNo}, {"@EntryState", newState}, {"@UserLoginID", UserLoginID}};

		    if((new SQLServer()).ExecSP("Pur_RequestOfStockCancel",oHT) == false)
			{
				this.Message="Error,Pur_RequestOfStockCancel,Please look the log file!";
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
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			var oHT = new Hashtable {{"@EntryNo", EntryNo}};
		    oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByEntryNo",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		/// <summary>
		/// 根据单据编号获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			var oHT = new Hashtable {{"@EntryNo", EntryCode}};
		    oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByEntryCode",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		/// <summary>
		/// 获取所有请购单。
		/// </summary>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryAll()
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetAll",oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		/// <summary>
		/// 根据指定的制单部门获取采购申请单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			var oHT = new Hashtable {{"@AuthorDept", DeptCode}};
		    oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByDeptCode",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		#endregion

        /// <summary>
        /// 获取用途编号。
        /// </summary>
        /// <param name="entryNo">采购订单号</param>
        /// <param name="serialNo">序号</param>
        /// <returns>用途编号。</returns>
        public string GetReqReasonCode(int entryNo, int serialNo)
        {
            var sqlStatement = "Select ReqReasonCode From PROS Where EntryNo=@EntryNo";
            var parms = new[]{
                new SqlParameter("@EntryNo",DbType.Int32){Value=entryNo},
            };

            var obj = SqlHelper.ExecuteScalar(this.ConnString, CommandType.Text, sqlStatement, parms);
            return obj == null ? string.Empty : obj.ToString();
        }
		#region 通用查询
		/// <summary>
		/// 用户默认的查询方案。
		/// </summary>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			var oRequestOfStockData = new RequestOfStockData();
			var oSQLServer = new SQLServer();
			var oHT = new Hashtable {{"@UserLoginId", UserLoginId}};
		    
            oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetAll",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			
            return oRequestOfStockData;
		}

        public object GetEntryByPerson(string EmpCode)
        {
            RequestOfStockData oRequestOfStockData = new RequestOfStockData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);
            oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByPerson", oHT, oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
            return oRequestOfStockData;
        }

		/// <summary>
		/// 根据查询方案获取结果集。
		/// </summary>
		/// <param name="Sql_statement"></param>
		/// <returns></returns>
		public RequestOfStockData GetEntryBySQL(string Sql_Statement)
		{
			RequestOfStockData oRequestOfStockData = new RequestOfStockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		public RequestOfStockData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept,string AuthorCode,int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			RequestOfStockData oRequestOfStockData = new RequestOfStockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode", AuthorCode);
			oHT.Add("@AuditResult", AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Pur_RequestOfStockGetByDeptAndAuthorAndAuditResult",oHT,oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE]);
			return oRequestOfStockData;
		}
		#endregion
	}
	#endregion public class RequestOfStocks
}
