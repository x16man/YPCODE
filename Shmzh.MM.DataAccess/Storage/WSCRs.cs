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
* penalties.  Any violations of this copyright will be WSCRecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;

	#region public class WSCRs
	/// <summary>
	/// 收料型单据的公共数据访问层。
	/// </summary>
	public class WSCRs:Messages,IInItems
	{
		#region 构造函数
		public WSCRs()
		{}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">WSCRData:	报废单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(WSCRData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[WSCRData.WSCR_TABLE].Rows[0];
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
			
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			//物料需求单特有字段。
			oHT.Add("@PlanNumList",		oRow[WSCRData.PLANNUM_FIELD]);					//物料应废数量。
			oHT.Add("@ReqDept",			oRow[WSCRData.REQDEPT_FIELD]);			//申请部门。
			oHT.Add("@ReqDeptName",		oRow[WSCRData.REQDEPTNAME_FIELD]);		//申请部门名称。
			oHT.Add("@Proposer",		oRow[WSCRData.PROPOSER_FIELD]);			//申请人。
			oHT.Add("@ProposerCode",	oRow[WSCRData.PROPOSERCODE_FIELD]);		//申请人编号。
			oHT.Add("@ReqReasonCode",	oRow[WSCRData.REQREASONCODE_FIELD]);		//申请理由编号。
			oHT.Add("@ReqReason",		oRow[WSCRData.REQREASON_FIELD]);			//申请理由。
			oHT.Add("@StoName",			oRow[WSCRData.STONAME_FIELD]);
			oHT.Add("@StoCode",			oRow[WSCRData.STOCODE_FIELD]);
			
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
			WSCRData oEntry = (WSCRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WSCRInsert",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WSCRInsert,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 新建并马上提交单据。
		/// </summary>
		/// <param name="Entry">object:	报废单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WSCRData oEntry = (WSCRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WSCRInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WSCRInsertAndPresent,Please look the log file!";
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
			WSCRData oEntry = (WSCRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WSCRUpdate",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WSCRUpdate,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 修改并马上提交报废单。
		/// </summary>
		/// <param name="Entry">object:	报废单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WSCRData oEntry = (WSCRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WSCRUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WSCRUpdateAndPresent,Please look the log file!";
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
			if((new SQLServer()).ExecSP("WSCRDelete",oHT) == false)
			{
				this.Message="Error,WSCRDelete,Please look the log file!";
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
			if((new SQLServer()).ExecSP("WSCRUpdateState",oHT) == false)
			{
				this.Message="Error,WSCRUpdateState,Please look the log file!";
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
			WSCRData oEntry= (WSCRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WSCRData.WSCR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WSCRFirstAudit",oHT) == false)
			{
				this.Message="Error,WSCRFirstAduit,Please look the log file!";
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
			WSCRData oEntry= (WSCRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WSCRData.WSCR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WSCRSecondAudit",oHT) == false)
			{
				this.Message="Error,WSCRSecondAduit,Please look the log file!";
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
			WSCRData oEntry= (WSCRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WSCRData.WSCR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WSCRThirdAudit",oHT) == false)
			{
				this.Message="Error,WSCRThirdAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 报废单提交。
		/// </summary>
		/// <param name="EntryNo">int:	报废单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo,string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId",UserLoginId);
			
			if((new SQLServer()).ExecSP("WSCRPresent",oHT) == false)
			{
				this.Message="Error,WSCRPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 报废单作废。
		/// </summary>
		/// <param name="EntryNo">int:	报废单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo,string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			if((new SQLServer()).ExecSP("WSCRCancel",oHT) == false)
			{
				this.Message="Error,WSCRCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo,string newState,string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID",UserLoginID);
			
			if((new SQLServer()).ExecSP("WSCRCancel",oHT) == false)
			{
				this.Message="Error,WSCRCancel,Please look the log file!";
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
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("WSCRGetByEntryNo",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		/// <summary>
		/// 根据单据编号获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryCode);
			oSQLServer.ExecSPReturnDS("WSCRGetByEntryCode",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		/// <summary>
		/// 获取所有请购单。
		/// </summary>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryAll()
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("WSCRGetAll",oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		/// <summary>
		/// 根据指定的制单部门获取报废单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);
			oSQLServer.ExecSPReturnDS("WSCRGetByDeptCode",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		#endregion
	
		#region 通用查询
		/// <summary>
		/// 用户默认的查询方案。
		/// </summary>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("WSCRGetAll",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}

        /// <summary>
        /// 用户默认的查询方案。
        /// </summary>
        /// <returns>object:	请购单实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WSCRData oWSCRData = new WSCRData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);
            oSQLServer.ExecSPReturnDS("WSCRGetByPerson", oHT, oWSCRData.Tables[WSCRData.WSCR_TABLE]);
            return oWSCRData;
        }
		/// <summary>
		/// 根据查询方案获取结果集。
		/// </summary>
		/// <param name="Sql_statement"></param>
		/// <returns></returns>
		public WSCRData GetEntryBySQL(string Sql_Statement)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		#endregion

		#region 报废单专有方法
		/// <summary>
		/// 获取报废单的所有数据源。
		/// </summary>
		/// <returns>WSCRData:	报废单数据源数据实体。</returns>
		public WSCRData GetWSCRAll()
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("WSCRGetAll",oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
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
				this.Message = WSCRData.AFFIRM_FAILED;
			}
			else
			{
				this.Message = WSCRData.ADD_SUCCESSED;
			}
			return ret;

		}
		public WSCRData GetWSCRByPKIDs(string PKIDs)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);
			oSQLServer.ExecSPReturnDS("WSCRGetByPKIDS",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		/// <summary>
		/// 根据状态获取报废单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>object:	报废单实体。</returns>
		public object GetEntryByState()
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("WSCRGetByState",oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		public WSCRData GetEntryByEntryNoDiscardMode(int EntryNo)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("WSCRGetByEntryNoDiscardMode",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}

		public bool DiscardWSCR( int EntryNo,string SerialNoList,string ItemNumList,string PKIDList,string ItemDrawNumList,string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			
			int output=0;

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

			ret = oSQLServer.ExecSP("WSCRDiscard", oHT); 
			if(ret == false)
			{
				this.Message = WSCRData.ADD_FAILED;
			}
			else if(output == -1)
			{
				this.Message = WSCRData.ROLL_FAILED;
			}
			else
			{
				this.Message = WSCRData.ADD_SUCCESSED;
			}
			return ret;
		}
		#endregion 
	}
	#endregion public class WSCRs
}
