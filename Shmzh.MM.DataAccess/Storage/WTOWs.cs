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

	#region public class WTOWs
	/// <summary>
	/// WTOWs 的摘要说明。
	/// </summary>
	public class WTOWs : Messages,IInItems
	{
		#region 构造函数
		public WTOWs()
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
		/// <param name="oEntry">WTOWData:	委外加工申请单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(WTOWData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[WTOWData.WTOW_TABLE].Rows[0];
			//委外加工申请单模式公用字段。
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
			oHT.Add("@ParentEntryNo",	oRow[WTOWData.PARENTENTRYNO_FIELD]);				//红字父单据号。

			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//物料编号。
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//物料名称。
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//物料规格。
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//物料单价。
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			//委外加工申请单特有字段。
//			oHT.Add("@SourceEntryList",     oRow[WTOWData.SOURCEENTRY_FIELD]);     //源单据流水号。
//			oHT.Add("@SourceDocCodeList",   oRow[WTOWData.SOURCEDOCCODE_FIELD]);   //源单据类型。
//			oHT.Add("@SourceSerialNoList",  oRow[WTOWData.SOURCESERIALNO_FIELD]);	//源单据顺序号。
			oHT.Add("@StoManagerCode",	oRow[WTOWData.STOMANAGERCODE_FIELD]);
			oHT.Add("@StoManager",		oRow[WTOWData.STOMANAGER_FIELD]);
			oHT.Add("@ReqDept",				oRow[WTOWData.REQDEPT_FIELD]);
			oHT.Add("@ReqDeptName",			oRow[WTOWData.REQDEPTNAME_FIELD]);
			oHT.Add("@ProposerName",		oRow[WTOWData.PROPOSERNAME_FIELD]);
			oHT.Add("@ProposerCode",		oRow[WTOWData.PROPOSERCODE_FIELD]);
			oHT.Add("@ReqReasonCode",		oRow[WTOWData.REQREASONCODE_FIELD]);	//用途编号
			oHT.Add("@ReqReason",			oRow[WTOWData.REQREASON_FIELD]);		//用途名称
			oHT.Add("@DrawingCount",        oRow[WTOWData.DRAWINGCOUNT_FIELD]);		//图纸。
		    oHT.Add("@ProspectusCount",     oRow[WTOWData.PROSPECTUSCOUNT_FIELD]);	//样纸。
			oHT.Add("@ProcessContent",      oRow[WTOWData.PROCESSCONTENT_FIELD]);	//加工内容。
			oHT.Add("@Term",                oRow[WTOWData.TERM_FIELD]);				//限期。
			oHT.Add("@PlanNumList",			oRow[WTOWData.PLANNUM_FIELD]);          //请领数量
			oHT.Add("@ItemNumList",         oRow[InItemData.ITEMNUM_FIELD]);		//实发数量。
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员
		/// <summary>
		/// 委外加工申请单增加。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWInsert",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.ADD_FAILED;
			}
			else
			{
				this.Message = WTOWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 委外加工申请单增加并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWInsertAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.ADD_FAILED;
			}
			else
			{
				this.Message = WTOWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 委外加工申请单修改。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{

			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWUpdate",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WTOWData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 委外加工申请单修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWUpdateAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WTOWData.UPDATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 发料。
		/// </summary>
		/// <param name="Entry"></param>
		/// <returns></returns>
		public bool StockOut(object Entry)
		{
			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWStockOut",oHT);
			if(ret == false)
			{
				this.Message = "发料失败！";
			}
			else
			{
				this.Message = "发料成功！";
			}
			return ret;
		}
		/// <summary>
		/// 更改委外加工申请单状态。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <param name="EntryState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Sto_WTOWUpdateState", oHT);
			if(ret == false)
			{
				this.Message = WTOWData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = WTOWData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单删除。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_WTOWDelete", oHT);
			if(ret == false)
			{
				this.Message = WTOWData.DELETE_FAILED;
			}
			else
			{
				this.Message = WTOWData.DELETE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单一级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WTOWData oEntry = (WTOWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTOWData.WTOW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_WTOWFirstAudit",oHT);

			if(ret == false)
			{
				this.Message = WTOWData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = WTOWData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单二级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WTOWData oEntry= (WTOWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTOWData.WTOW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_WTOWSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = WTOWData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单三级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WTOWData oEntry= (WTOWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTOWData.WTOW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_WTOWThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = WTOWData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单提交。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
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

			ret = oSQLServer.ExecSP("Sto_WTOWPresent",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.PRESENT_FAILED;
			}
			else
			{
				this.Message = WTOWData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			ret = oSQLServer.ExecSP("Sto_WTOWCancel",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WTOWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
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
			
			ret = oSQLServer.ExecSP("Sto_WTOWCancel",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WTOWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	委外加工申请单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByEntryNo",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}


        /// <summary>
        /// 根据单据流水号获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>object:	委外加工申请单实体。</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            WTOWData oWTOWData = new WTOWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_WTOWOldGetByEntryNo", oHT, oWTOWData.Tables[WTOWData.WTOW_TABLE]);
            return oWTOWData;
        }

        /// <summary>
        /// 根据单据流水号获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>object:	委外加工申请单实体。</returns>
        public object GetEntryRedByEntryNo(int EntryNo)
        {
            WTOWData oWTOWData = new WTOWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_WTOWRedGetByEntryNo", oHT, oWTOWData.Tables[WTOWData.WTOW_TABLE]);
            return oWTOWData;
        }

		/// <summary>
		/// 根据状态获取委外加工申请单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>object:	委外加工申请单实体。</returns>
		public object GetEntryByState(string EntryState)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryState",EntryState);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByState",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// 根据单据编号号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据编号。</param>
		/// <returns>object:	委外加工申请单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByEntryCode",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// 获取所有单据。
		/// </summary>
		/// <returns>object:	委外加工申请单实体。</returns>
		public object GetEntryAll()
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetAll",oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// 根据用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>object:	委外加工申请单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetAll",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}

        /// <summary>
        /// 根据用户获取所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>object:	委外加工申请单实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WTOWData oWTOWData = new WTOWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Sto_WTOWGetByPerson", oHT, oWTOWData.Tables[WTOWData.WTOW_TABLE]);
            return oWTOWData;
        }

		/// <summary>
		/// 根据指定的制单部门获取委外加工申请单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	委外加工申请单实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByDeptCode",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		#endregion

		#region 专有方法
		/// <summary>
		/// 发料模式下根据委外加工申请单流水号获取委外加工申请单信息。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号.</param>
		/// <returns>object:	委外加工申请单实体.</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByEntryNoOutMode",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// 获取有效的委外加工申请单列表。
		/// 委外加工收料单使用。
		/// </summary>
		/// <returns>object:	委外加工申请单列表.</returns>
		public object GetWTOWValidData()
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("Sto_WTOWGetValidData",oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// 委外加工申请单拒发。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <param name="UserLoginID">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DrawRefuse(int EntryNo,string UserLoginId)
		{
			bool ret = false;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@UserLoginId",UserLoginId);

			ret = oSQLServer.ExecSP("Sto_WTOWRefuse",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.Refuse_Failed;
			}
			else
			{
				this.Message = WTOWData.Refuse_Success;
			}
			return ret;
		}
        ///// <summary>
        ///// 根据父单据编号获取红字单。
        ///// </summary>
        ///// <param name="EntryNo">int:	父单据流水号。</param>
        ///// <returns>object:	委外加工申请单实体。</returns>
        //public object GetEntryRedByEntryNo(int EntryNo)
        //{
        //    WTOWData oWTOWData = new WTOWData();
        //    SQLServer oSQLServer = new SQLServer();
        //    Hashtable oHT = new Hashtable();
        //    oHT.Add("@EntryNo",EntryNo);
        //    oSQLServer.ExecSPReturnDS("Sto_WTOWRed",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
        //    return oWTOWData;
        //}

		#endregion
		
		#region 通用查询
		/// <summary>
		/// 根据SQL语句进行查询。
		/// </summary>
		/// <param name="Sql_Statement"></param>
		/// <returns></returns>
		public object GetEntryBySQL(string Sql_Statement)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		public object GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode", AuthorCode);
			oHT.Add("@AuditResult", AuditResult);
			oHT.Add("@StartDate",StartDate);
			oHT.Add("@EndDate", EndDate);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByDeptAndAuthorAndAuditResult",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		#endregion
	}
	#endregion public class WTOWs
}
