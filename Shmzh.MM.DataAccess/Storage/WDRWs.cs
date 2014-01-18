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

	#region public class WDRWs
	/// <summary>
	/// WDRWs 的摘要说明。
	/// </summary>
	public class WDRWs : Messages,IInItems
	{
		#region 构造函数
		public WDRWs()
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
		/// <param name="oEntry">WDRWData:	领料单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(WDRWData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[WDRWData.WDRW_TABLE].Rows[0];
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
			oHT.Add("@ParentEntryNo",	oRow[WDRWData.PARENTENTRYNO_FIELD]);				//红字父单据号。
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//物料编号。
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//物料名称。
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//物料规格。
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//物料单价。
			//oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//物料数量。
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			//领料单特有字段。
			//oHT.Add("@StoManagerCode",  oRow[WDRWData.STOMANAGERCODE_FIELD]);  //仓库管理员代码
			//oHT.Add("@StoManager",      oRow[WDRWData.STOMANAGER_FIELD]);      //仓库管理员
			//oHT.Add("@DrawDate",        oRow[WDRWData.DRAWDATE_FIELD]);        //发料日期
			oHT.Add("@SourceEntryList",     oRow[WDRWData.SOURCEENTRY_FIELD]);     //源单据流水号。
			oHT.Add("@SourceDocCodeList",   oRow[WDRWData.SOURCEDOCCODE_FIELD]);   //源单据类型。
			oHT.Add("@SourceSerialNoList",  oRow[WDRWData.SOURCESERIALNO_FIELD]);	//源单据顺序号。
			oHT.Add("@ReqDept",				oRow[WDRWData.REQDEPT_FIELD]);
			oHT.Add("@ReqDeptName",			oRow[WDRWData.REQDEPTNAME_FIELD]);
			oHT.Add("@Proposer",			oRow[WDRWData.PROPOSER_FIELD]);
			oHT.Add("@ProposerCode",		oRow[WDRWData.PROPOSERCODE_FIELD]);
			oHT.Add("@ReqReasonCode",   oRow[WDRWData.REQREASONCODE_FIELD]);   //用途编号
			oHT.Add("@ReqReason",       oRow[WDRWData.REQREASON_FIELD]);       //用途名称
			oHT.Add("@StoCode",         oRow[WDRWData.STOCODE_FIELD]);         //仓库编号
			oHT.Add("@StoName",         oRow[WDRWData.STONAME_FIELD]);         //仓库名称
			oHT.Add("@ConCode",			oRow[WDRWData.CONCODE_FIELD]);		   //架位编号。
			oHT.Add("@ConName",			oRow[WDRWData.CONNAME_FIELD]);		   //架位名称。
			oHT.Add("@PlanNumList",     oRow[WDRWData.PLANNUM_FIELD]);         //请领数量
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员

		/// <summary>
		/// 领料单增加。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WDRWData oEntry = (WDRWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_DRWInsert",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.ADD_FAILED;
			}
			else
			{
				this.Message = WDRWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 领料单增加并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WDRWData oEntry = (WDRWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_DRWInsertAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.ADD_FAILED;
			}
			else
			{
				this.Message = WDRWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 领料单修改。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{

			bool ret = true;
			WDRWData oEntry = (WDRWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_DRWUpdate",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WDRWData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 领料单修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WDRWData oEntry = (WDRWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_DRWUpdateAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WDRWData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 领料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_DRWDelete", oHT);
			if(ret == false)
			{
				this.Message = WDRWData.DELETE_FAILED;
			}
			else
			{
				this.Message = WDRWData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 更改领料单状态。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="EntryState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Sto_DRWUpdateState", oHT);
			if(ret == false)
			{
				this.Message = WDRWData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = WDRWData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 领料单一级审批。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WDRWData oEntry = (WDRWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WDRWData.WDRW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_DRWFirstAudit",oHT);

			if(ret == false)
			{
				this.Message = WDRWData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = WDRWData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 领料单二级审批。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WDRWData oEntry= (WDRWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WDRWData.WDRW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_DRWSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = WDRWData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 领料单三级审批。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WDRWData oEntry= (WDRWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WDRWData.WDRW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_DRWThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = WDRWData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 领料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
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

			ret = oSQLServer.ExecSP("Sto_DRWPresent",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.PRESENT_FAILED;
			}
			else
			{
				this.Message = WDRWData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 领料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			ret = oSQLServer.ExecSP("Sto_DRWCancel",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WDRWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 领料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID", UserLoginId);
			
			ret = oSQLServer.ExecSP("Sto_DRWCancel",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WDRWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	领料单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByEntryNo",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}

        /// <summary>
        /// 根据单据流水号获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>object:	领料单实体。</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            WDRWData oWDRWData = new WDRWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_DRWOldGetByEntryNo", oHT, oWDRWData.Tables[WDRWData.WDRW_TABLE]);
            return oWDRWData;
        }

		/// <summary>
		/// 根据状态获取领料单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>object:	领料单实体。</returns>
		public object GetEntryByState(string EntryState)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryState",EntryState);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByState",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// 根据单据编号号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据编号。</param>
		/// <returns>object:	领料单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByEntryCode",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// 获取所有单据。
		/// </summary>
		/// <returns>object:	领料单实体。</returns>
		public object GetEntryAll()
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_DRWGetAll",oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// 根据用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>object:	领料单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

            oSQLServer.ExecSPReturnDS("Sto_DRWGetAll", oHT, oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}

        /// <summary>
        /// 根据用户获取所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>object:	领料单实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WDRWData oWDRWData = new WDRWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Sto_DRWGetByPerson", oHT, oWDRWData.Tables[WDRWData.WDRW_TABLE]);
            return oWDRWData;
        }

		/// <summary>
		/// 根据指定的制单部门获取领料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	领料单实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByDeptCode",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		#endregion

		#region 专有方法
		/// <summary>
		/// 发料模式下根据领料单流水号获取领料单信息。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号.</param>
		/// <returns>object:	领料单实体.</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByEntryNoOutMode",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// 根据申请部门编号获取领料单的来源单据列表。
		/// </summary>
		/// <param name="DeptCode">string:	申请部门。</param>
		/// <returns>WDRWData:	领料单数据实体。</returns>
		public WDRWData GetSourceEntryLisByDeptCode(string DeptCode)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@DeptCode",DeptCode);

			oSQLServer.ExecSPReturnDS("Sto_DRWSListGetByDeptCode",oHT,oWDRWData.Tables[WDRWData.WDS_VIEW]);
			return oWDRWData;
		}
		/// <summary>
		/// 根据源单据号，获取源单据的可用明细内容。
		/// </summary>
		/// <param name="PKIDs">string:	源单据号串。</param>
		/// <returns>WDRWData:	领料单数据实体。</returns>
		public WDRWData GetSourceEntryDetailByEntryNos(string PKIDs)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);

			oSQLServer.ExecSPReturnDS("Sto_DRWSourceDetailGetByPKIDs",oHT,oWDRWData.Tables[WDRWData.WDSD_VIEW]);
			return oWDRWData;
		}
		/// <summary>
		/// 领料单发料时候，进行库存选择。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="ItemCodeList">string:	领料单物料编号串。</param>
		/// <param name="ItemNumList">string:	实发数量串。</param>
		/// <returns>StockChoiceData:	可供选择的库存实体。</returns>
		public StockChoiceData GetStockChoice(int DocCode,int EntryNo, string SerialNoList, string ItemCodeList, string ItemNumList)
		{
			StockChoiceData oStockChoiceData = new StockChoiceData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@DocCode", DocCode);
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@SerialNoList",SerialNoList);
			oHT.Add("@ItemCodeList",ItemCodeList);
			oHT.Add("@ItemNumList",ItemNumList);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetStockChoice",oHT,oStockChoiceData.Tables[StockChoiceData.StockChoice_Table]);
			return oStockChoiceData;
		}
		/// <summary>
		/// 领料单发料.
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号.</param>
		/// <param name="SerialNoList">string:	顺序号串.</param>
		/// <param name="ItemNumList">string:	领料单发料数串.</param>
		/// <param name="PKIDList">string:	主键串。</param>
		/// <param name="ItemDrawNumList">string:	库存发料数串.</param>
		/// <param name="UserCode">string:	用户编号.</param>
		/// <param name="UserName">string:	用户名称。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DrawOutStock(int EntryNo, string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
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

			ret = oSQLServer.ExecSP("Sto_DRWStockOut",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.OUT_FAILED;
			}
			else
			{
				this.Message = WDRWData.OUT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 领料单拒发。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="UserLoginID">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DrawRefuse(int EntryNo,string UserLoginId)
		{
			bool ret = false;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@UserLoginId",UserLoginId);

			ret = oSQLServer.ExecSP("Sto_DRWRefuse",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.Refuse_Failed;
			}
			else
			{
				this.Message = WDRWData.Refuse_Success;
			}
			return ret;
		}
		/// <summary>
		/// 领料单转采购申请单。
		/// </summary>
		/// <param name="EntryNo">int:	领料单号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Draw2Pros(int EntryNo)
		{
			bool ret = false;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@WDRW_EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_DRW2PROS",oHT);
			if(ret == false)
			{
				this.Message = "由领料单生成请购单失败！";
			}
			else
			{
				this.Message = "由领料单生成请购单成功！";
			}
			return ret;
		}
		/// <summary>
		/// 根据父单据编号获取红字单。
		/// </summary>
		/// <param name="EntryNo">int:	父单据流水号。</param>
		/// <returns>object:	领料单实体。</returns>
		public object	 GetEntryRedByEntryNo(int EntryNo)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("Sto_DRWRed",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// 根据信息反馈中选择的记录来生成领料单的内容。
		/// </summary>
		/// <param name="PKIDs">string:	信息反馈中选中的记录ID串。</param>
		/// <returns>object:	领料单实体。</returns>
		public object GetEntryByFeedbackPKIDs(string PKIDs)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@FeedbackPKIDs", PKIDs);
			oSQLServer.ExecSPReturnDS("Sto_DRWGetBySelectedFeedback",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		#endregion
		
		#region 通用查询
		/// <summary>
		/// 根据SQL语句进行查询。
		/// </summary>
		/// <param name="Sql_Statement"></param>
		/// <returns></returns>
		public object GetEntryBySQL(string Sql_Statement)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}		  
		public object GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate, DateTime EndDate)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Sto_DRWGetByDeptAndAuthorAndAuditResult",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		#endregion
	}
	#endregion public class WDRWs
}
