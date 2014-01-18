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
	using System.Data;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;

	#region public class WRTSs
	/// <summary>
	/// WRTSs 的摘要说明。
	/// </summary>
	public class WRTSs : Messages,IInItems
	{
		#region 构造函数
		public WRTSs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">WRTSData:	生产退料单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(WRTSData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];
			//领料模式公用字段。
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
			//oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);				//物料数量。
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			//生产退料单特有字段。
			//oHT.Add("@StoManagerCode",  oRow[WRTSData.STOMANAGERCODE_FIELD]);				//仓库管理员代码
			//oHT.Add("@StoManager",      oRow[WRTSData.STOMANAGER_FIELD]);					//仓库管理员
			//oHT.Add("@DrawDate",        oRow[WRTSData.DRAWDATE_FIELD]);					//发料日期
			oHT.Add("@SourceEntryList",   oRow[WRTSData.SOURCEENTRY_FIELD]);				//源单据流水号
			oHT.Add("@SourceDocCodeList", oRow[WRTSData.SOURCEDOCCODE_FIELD]);			//源单据类型
			oHT.Add("@SourceSerialNoList",oRow[WRTSData.SOURCESERIALNO_FIELD]);			//源单据序号。
			oHT.Add("@ReqReasonCode",	oRow[WRTSData.REQREASONCODE_FIELD]);				//用途编号
			oHT.Add("@ReqReason",       oRow[WRTSData.REQREASON_FIELD]);					//用途名称
			oHT.Add("@StoCode",         oRow[WRTSData.STOCODE_FIELD]);						//仓库编号
			oHT.Add("@StoName",         oRow[WRTSData.STONAME_FIELD]);						//仓库名称
			oHT.Add("@PlanNumList",     oRow[WRTSData.PLANNUM_FIELD]);						//请退数量

			oHT.Add("@ReqDept",			oRow[WRTSData.REQDEPT_FIELD]);						//申请部门。
			oHT.Add("@ReqDeptName",		oRow[WRTSData.REQDEPTNAME_FIELD]);		//申请部门名称。
			oHT.Add("@Proposer",		oRow[WRTSData.PROPOSER_FIELD]);			//申请人。
			oHT.Add("@ProposerCode",	oRow[WRTSData.PROPOSERCODE_FIELD]);		//申请人编号。
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员

		/// <summary>
		/// 生产退料单增加。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_RTSInsert",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.ADD_FAILED;
			}
			else
			{
				this.Message = WRTSData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 生产退料单增加并且提交。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_RTSInsertAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.ADD_FAILED;
			}
			else
			{
				this.Message = WRTSData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 生产退料单修改。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{

			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_RTSUpdate",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WRTSData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 生产退料单修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_RTSUpdateAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WRTSData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 生产退料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	生产退料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_RTSDelete", oHT);
			if(ret == false)
			{
				this.Message = WRTSData.DELETE_FAILED;
			}
			else
			{
				this.Message = WRTSData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 更改生产退料单状态。
		/// </summary>
		/// <param name="EntryNo">int:	生产退料单流水号。</param>
		/// <param name="EntryState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Sto_RTSUpdateState", oHT);
			if(ret == false)
			{
				this.Message = WRTSData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = WRTSData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 生产退料单一级审批。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WRTSData oEntry = (WRTSData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_RTSFirstAudit",oHT);

			if(ret == false)
			{
				this.Message = WRTSData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = WRTSData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单二级审批。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WRTSData oEntry= (WRTSData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_RTSSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = WRTSData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单三级审批。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WRTSData oEntry= (WRTSData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_RTSThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = WRTSData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	生产退料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Sto_RTSPresent",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.PRESENT_FAILED;
			}
			else
			{
				this.Message = WRTSData.PRESENT_SUCCESSED;
			}
			return ret;
		}

		public bool Cancel(int EntryNo, string newState,string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID", UserLoginID);
			
			ret = oSQLServer.ExecSP("Sto_RTSCancel",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WRTSData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 生产退料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	生产退料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);

			ret = oSQLServer.ExecSP("Sto_RTSCancel",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WRTSData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	生产退料单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_RTSGetByEntryNo",oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_RTSGetByEntryNoInMode",oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}
		/// <summary>
		/// 根据单据编号号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据编号。</param>
		/// <returns>object:	生产退料单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Sto_RTSGetByEntryCode",oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}
		/// <summary>
		/// 获取所有单据。
		/// </summary>
		/// <returns>object:	生产退料单实体。</returns>
		public object GetEntryAll()
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_RTSGetAll",oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}


        /// <summary>
        /// 获取所有单据。
        /// </summary>
        /// <returns>object:	生产退料单实体。</returns>
        public object GetEntryByDept(string strDeptCode)
        {
            WRTSData oWRTSData = new WRTSData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@AuthorDept", strDeptCode);

            oSQLServer.ExecSPReturnDS("Sto_RTSGetByDept", oHT, oWRTSData.Tables[WRTSData.WRTS_TABLE]);
            return oWRTSData;
        }


        /// <summary>
        /// 获取所有单据。
        /// </summary>
        /// <returns>object:	生产退料单实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WRTSData oWRTSData = new WRTSData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);


            oSQLServer.ExecSPReturnDS("Sto_RTSGetByPerson", oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
            return oWRTSData;
        }
		#endregion

		#region 退料单特殊成员
		/// <summary>
		/// 退料验收
		/// </summary>
		/// <param name="Entry">退料单</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Check(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			WRTSData oEntry = (WRTSData)Entry;
			DataRow oRow;
			oRow = oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];

			oHT.Add("@EntryNo",         oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@ChkResult",       oRow[WRTSData.CHKRESULT_FIELD]);
			oHT.Add("@ChkManCode",      oRow[WRTSData.CHKMANCODE_FIELD]);
			oHT.Add("@ChkManName",      oRow[WRTSData.CHKMANNAME_FIELD]);


			ret = oSQLServer.ExecSP("Sto_RTSCheck",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.CHECK_FAILED;
			}
			else
			{
				this.Message = WRTSData.CHKCK_SUCCESSED;
			}
			return ret;
		}
		
		/// <summary>
		/// 生产退料单收料
		/// </summary>
		/// <param name="Entry"></param>
		/// <returns></returns>
		public bool Receive( object Entry)
		{
			bool ret = false;
			WRTSData oEntry= (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			oHT.Add("@ConCodeList",oEntry.Tables[0].Rows[0][WRTSData.CONCODE_FIELD]);	//架位代码
			oHT.Add("@ConNameList",oEntry.Tables[0].Rows[0][WRTSData.CONNAME_FIELD]);	//架位名称
			oHT.Add("@ItemNumList",oEntry.Tables[0].Rows[0][InItemData.ITEMNUM_FIELD]);	//物料数量。
			oHT.Add("@StoManagerCode",  oEntry.Tables[0].Rows[0][WRTSData.STOMANAGERCODE_FIELD]);  //仓库管理员代码
			oHT.Add("@StoManager",      oEntry.Tables[0].Rows[0][WRTSData.STOMANAGER_FIELD]);      //仓库管理员
			ret = oSQLServer.ExecSP("Sto_RTSReceive", oHT);
			if(ret == false)
			{
				this.Message = WRTSData.RECEIVE_FAILED;
			}
			else
			{
				this.Message = WRTSData.RECEIVE_SUCCESSED;
			}
			return ret;
		}
		#endregion 退料单特殊成员

		#region 通用查询
		public WRTSData GetEntryBySQL(string Sql_Statement)
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}
		#endregion
	}
	#endregion public class WRTSs
}
