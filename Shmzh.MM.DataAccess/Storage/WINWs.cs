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

	#region public class WINWs
	/// <summary>
	/// 委外加工收料单的数据访问层。
	/// </summary>
	public class WINWs : Messages
	{
		#region 构造函数
		/// <summary>
		/// 构造函数。
		/// </summary>
		public WINWs()
		{
		}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 将委外加工收料单的数据填充到哈希表，用来作为调用存储过程的参数列表。
		/// </summary>
		/// <param name="oEntry">WINWData:	委外加工收料单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(WINWData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[WINWData.WINW_TABLE].Rows[0];
			//委外加工收料单模式公用字段。
			oHT.Add("@EntryNo",	oRow[WINWData.EntryNo_Field]);					//单据流水号。
			oHT.Add("@EntryCode", oRow[WINWData.EntryCode_Field]);				//单据编号。
			oHT.Add("@DocCode",	oRow[WINWData.DocCode_Field]);					//单据类型。
			oHT.Add("@DocName", oRow[WINWData.DocName_Field]);					//单据类型名称。
			oHT.Add("@DocNo", oRow[WINWData.DocNo_Field]);						//单据类型文档编号。
			oHT.Add("@EntryState", oRow[WINWData.EntryState_Field]);			//单据状态。
			oHT.Add("@EntryDate", oRow[WINWData.EntryDate_Field]);				//制单日期。
			oHT.Add("@AuthorCode", oRow[WINWData.AuthorCode_Field]);			//制单人编号。
			oHT.Add("@AuthorName", oRow[WINWData.AuthorName_Field]);			//制单人名称。
			oHT.Add("@AuthorLoginID", oRow[WINWData.AuthorLoginID_Field]);		//制单人登录名。
			oHT.Add("@AuthorDept", oRow[WINWData.AuthorDept_Field]);			//制单人部门。
			oHT.Add("@AuthorDeptName", oRow[WINWData.AuthorDeptName_Field]);	//制单人部门名称。
			oHT.Add("@ReqReasonCode", oRow[WINWData.ReqReasonCode_Field]);
			oHT.Add("@ReqReason", oRow[WINWData.ReqReason_Field]);
			oHT.Add("@ProcessContent", oRow[WINWData.ProcessContent_Field]);
			oHT.Add("@PresentDate", oRow[WINWData.PresentDate_Field]);
			oHT.Add("@CancelDate", oRow[WINWData.CancelDate_Field]);
			oHT.Add("@AcceptDate", oRow[WINWData.AcceptDate_Field]);
			oHT.Add("@StoCode", oRow[WINWData.StoCode_Field]);
			oHT.Add("@StoName", oRow[WINWData.StoName_Field]);
			oHT.Add("@StoManagerCode", oRow[WINWData.StoManagerCode_Field]);
			oHT.Add("@StoManager", oRow[WINWData.StoManager_Field]);
			oHT.Add("@Audit1", oRow[WINWData.Audit1_Field]);
			oHT.Add("@Assessor1", oRow[WINWData.Assessor1_Field]);
			oHT.Add("@AuditSuggest1", oRow[WINWData.AuditSuggest1_Field]);
			oHT.Add("@AuditDate1", oRow[WINWData.AuditDate1_Field]);
			oHT.Add("@Audit2", oRow[WINWData.Audit2_Field]);
			oHT.Add("@Assessor2", oRow[WINWData.Assessor2_Field]);
			oHT.Add("@AuditSuggest2", oRow[WINWData.AuditSuggest2_Field]);
			oHT.Add("@AuditDate2", oRow[WINWData.AuditDate2_Field]);
			oHT.Add("@Audit3", oRow[WINWData.Audit3_Field]);
			oHT.Add("@Assessor3", oRow[WINWData.Assessor3_Field]);
			oHT.Add("@AuditSuggest3", oRow[WINWData.AuditSuggest3_Field]);
			oHT.Add("@AuditDate3", oRow[WINWData.AuditDate3_Field]);
			oHT.Add("@ResTotal", oRow[WINWData.ResTotal_Field]);
			oHT.Add("@FeeTotal", oRow[WINWData.FeeTotal_Field]);
			oHT.Add("@SubTotal", oRow[WINWData.SubTotal_Field]);				
			oHT.Add("@Remark", oRow[WINWData.Remark_Field]);					
			oHT.Add("@ParentEntryNo", oRow[WINWData.ParentEntryNo_Field]);		
			oHT.Add("@InvoiceNo", oRow[WINWData.InvoiceNo_Field]);
			oHT.Add("@ContractCode", oRow[WINWData.ContractCode_Field]);
			oHT.Add("@PrvCode", oRow[WINWData.PrvCode_Field]);
			oHT.Add("@PrvName", oRow[WINWData.PrvName_Field]);
			oHT.Add("@PayDate", oRow[WINWData.PayDate_Field]);
			oHT.Add("@Payer", oRow[WINWData.Payer_Field]);
			oHT.Add("@BuyerCode", oRow[WINWData.BuyerCode_Field]);
			oHT.Add("@BuyerName", oRow[WINWData.BuyerName_Field]);
			oHT.Add("@PayStyle", oRow[WINWData.PayStyle_Field]);
			oHT.Add("@ChkNo", oRow[WINWData.ChkNo_Field]);
			oHT.Add("@ChkResult", oRow[WINWData.ChkResult_Field]);
			////////////////////////////////////////////////////////////////////
			Col2List MyList = new Col2List(oEntry.Tables[WINWData.WDIW_TABLE]);
			oHT.Add("@SerialNoList", MyList.GetList(WINWData.SerialNo_Field));
			oHT.Add("@ItemCodeList", MyList.GetList(WINWData.ItemCode_Field));
			oHT.Add("@ItemNameList", MyList.GetList(WINWData.ItemName_Field));
			oHT.Add("@ItemSpecialList", MyList.GetList(WINWData.ItemSpec_Field));
			oHT.Add("@ItemUnitList", MyList.GetList(WINWData.ItemUnit_Field));
			oHT.Add("@ItemUnitNameList", MyList.GetList(WINWData.ItemUnitName_Field));
			oHT.Add("@PlanNumList", MyList.GetList(WINWData.PlanNum_Field));
			oHT.Add("@ItemNumList", MyList.GetList(WINWData.ItemNum_Field));
			oHT.Add("@ItemPriceList", MyList.GetList(WINWData.ItemPrice_Field));
			oHT.Add("@ItemMoneyList", MyList.GetList(WINWData.ItemMoney_Field));
			oHT.Add("@ItemFeeList", MyList.GetList(WINWData.ItemFee_Field));
			oHT.Add("@ItemSumList", MyList.GetList(WINWData.ItemSum_Field));
			oHT.Add("@ConCodeList", MyList.GetList(WINWData.ConCode_Field));
			oHT.Add("@ConNameList", MyList.GetList(WINWData.ConName_Field));
			////////////////////////////////////////////////////////////////////
			MyList = new Col2List(oEntry.Tables[WINWData.WRES_TABLE]);
			oHT.Add("@SourceEntryNoList", MyList.GetList(WINWData.SourceEntryNo_Field));
			oHT.Add("@SourceDocCodeList", MyList.GetList(WINWData.SourceDocCode_Field));
			oHT.Add("@SourceSerialNoList", MyList.GetList(WINWData.SouceSerialNo_Field));
			oHT.Add("@PSerialNoList", MyList.GetList(WINWData.PSerialNo_Field));
			oHT.Add("@ResSerialNoList", MyList.GetList(WINWData.ResSerialNo_Field));
			oHT.Add("@ResCodeList", MyList.GetList(WINWData.ResCode_Field));
			oHT.Add("@ResNameList", MyList.GetList(WINWData.ResName_Field));
			oHT.Add("@ResSpecialList", MyList.GetList(WINWData.ResSpecial_Field));
			oHT.Add("@ResUnitList", MyList.GetList(WINWData.ResUnit_Field));
			oHT.Add("@ResUnitNameList", MyList.GetList(WINWData.ResUnitName_Field));
			oHT.Add("@ResNumList", MyList.GetList(WINWData.ResNum_Field));
			oHT.Add("@ResPriceList", MyList.GetList(WINWData.ResPrice_Field));
			oHT.Add("@ResMoneyList", MyList.GetList(WINWData.ResMoney_Field));
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员
		/// <summary>
		/// 委外加工收料单增加。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWInsert",oHT);
			if(ret == false) this.Message = WINWData.ADD_FAILED;
			
			return ret;
		}

		/// <summary>
		/// 委外加工收料单增加并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWInsertAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WINWData.ADD_FAILED;
			}
			else
			{
				this.Message = WINWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 委外加工收料单修改。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{

			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWUpdate",oHT);
			if(ret == false)
			{
				this.Message = WINWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WINWData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 委外加工收料单修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWUpdateAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WINWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WINWData.UPDATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 发料。
		/// </summary>
		/// <param name="Entry"></param>
		/// <returns></returns>
		public bool StockIn(object Entry)
		{
			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWStockIn",oHT);
			if(ret == false)
			{
				this.Message = "收料失败！";
			}
			else
			{
				this.Message = "收料成功！";
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工收料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_WINWDelete", oHT);
			if(ret == false)
			{
				this.Message = WINWData.DELETE_FAILED;
			}
			else
			{
				this.Message = WINWData.DELETE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单一级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WINWData oEntry = (WINWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WINWData.WINW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[WINWData.EntryNo_Field]);
			oHT.Add("@EntryState",		oRow[WINWData.EntryState_Field]);
			oHT.Add("@Audit1",			oRow[WINWData.Audit1_Field]);
			oHT.Add("@Assessor1",		oRow[WINWData.Assessor1_Field]);
			oHT.Add("@AuditSuggest1",	oRow[WINWData.AuditSuggest1_Field]);
			oHT.Add("@UserLoginId",     oRow[WINWData.AuthorLoginID_Field]);

			ret = oSQLServer.ExecSP("Sto_WINWFirstAudit",oHT);

			if(ret == false)
			{
				this.Message = WINWData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = WINWData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单二级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WINWData oEntry= (WINWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WINWData.WINW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[WINWData.EntryNo_Field]);
			oHT.Add("@EntryState",		oRow[WINWData.EntryState_Field]);
			oHT.Add("@Audit2",			oRow[WINWData.Audit2_Field]);
			oHT.Add("@Assessor2",		oRow[WINWData.Assessor2_Field]);
			oHT.Add("@AuditSuggest2",	oRow[WINWData.AuditSuggest2_Field]);
			oHT.Add("@UserLoginId",     oRow[WINWData.AuthorLoginID_Field]);

			ret = oSQLServer.ExecSP("Sto_WINWSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = WINWData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = WINWData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单三级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WINWData oEntry= (WINWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WINWData.WINW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[WINWData.EntryNo_Field]);
			oHT.Add("@EntryState",		oRow[WINWData.EntryState_Field]);
			oHT.Add("@Audit3",			oRow[WINWData.Audit3_Field]);
			oHT.Add("@Assessor3",		oRow[WINWData.Assessor3_Field]);
			oHT.Add("@AuditSuggest3",	oRow[WINWData.AuditSuggest3_Field]);
			oHT.Add("@UserLoginId",     oRow[WINWData.AuthorLoginID_Field]);

			ret = oSQLServer.ExecSP("Sto_WINWThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = WINWData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = WINWData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Sto_WINWPresent",oHT);
			if(ret == false)
			{
				this.Message = WINWData.PRESENT_FAILED;
			}
			else
			{
				this.Message = WINWData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工收料单流水号。</param>
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
			
			ret = oSQLServer.ExecSP("Sto_WINWCancel",oHT);
			if(ret == false)
			{
				this.Message = WINWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WINWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	委外加工收料单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_WINWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
			oSQLServer.ExecSPReturnDS("Sto_WDIWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WDIW_TABLE]);
			oSQLServer.ExecSPReturnDS("Sto_WRESGetByEntryNo", oHT, oWINWData.Tables[WINWData.WRES_TABLE]);
			return oWINWData;
		}

        /// <summary>
        /// 根据单据流水号获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>object:	委外加工收料单实体。</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            WINWData oWINWData = new WINWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_WINWOldGetByEntryNo", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
           return oWINWData;
        }


        public object GetEntryRedByEntryNo(int EntryNo)
        {
            WINWData oWINWData = new WINWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_WINWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
            oSQLServer.ExecSPReturnDS("Sto_WDIWRedGetByEntryNo", oHT, oWINWData.Tables[WINWData.WDIW_TABLE]);
            oSQLServer.ExecSPReturnDS("Sto_WRESRedGetByEntryNo", oHT, oWINWData.Tables[WINWData.WRES_TABLE]);
            return oWINWData;
        }

		/// <summary>
		/// 根据用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>object:	委外加工收料单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

			oSQLServer.ExecSPReturnDS("Sto_WINWGetAll",oHT,oWINWData.Tables[WINWData.WINW_TABLE]);
			return oWINWData;
		}

        /// <summary>
        /// 根据用户获取所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>object:	委外加工收料单实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WINWData oWINWData = new WINWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Sto_WINWGetByPerson", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
            return oWINWData;
        }
		#endregion

		#region 专有方法
        ///// <summary>
        ///// 根据父单据编号获取红字单。
        ///// </summary>
        ///// <param name="EntryNo">int:	父单据流水号。</param>
        ///// <returns>object:	委外加工收料单实体。</returns>
        //public object GetEntryRedByEntryNo(int EntryNo)
        //{
        //    WINWData oWINWData = new WINWData();
        //    SQLServer oSQLServer = new SQLServer();
        //    Hashtable oHT = new Hashtable();
        //    oHT.Add("@EntryNo",EntryNo);
        //    oSQLServer.ExecSPReturnDS("Sto_WINWRed",oHT,oWINWData.Tables[WINWData.WINW_TABLE]);
        //    return oWINWData;
        //}
		/// <summary>
		/// 获取有用的委外申请单数据源。
		/// </summary>
		/// <param name="EntryNos">string:	流水号串。</param>
		/// <param name="PSerialNo">int:	针对记录号。</param>
		/// <returns>object：	实体。</returns>
		public object GetWTOWValidDataByEntryNos(string EntryNos,int PSerialNo)
		{
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNos", EntryNos);
			oHT.Add("@PSerialNo", PSerialNo);
			//oSQLServer.ExecSPReturnDS("Sto_WINWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
			//oSQLServer.ExecSPReturnDS("Sto_WDIWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WDIW_TABLE]);
			oSQLServer.ExecSPReturnDS("Sto_WTOWGetValidDataByEntryNos", oHT, oWINWData.Tables[WINWData.WRES_TABLE]);
			return oWINWData;
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
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWINWData.Tables[WINWData.WINW_TABLE]);
			return oWINWData;
		}
		public object GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult", AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);

			oSQLServer.ExecSPReturnDS("Sto_WINWGetByDeptAndAuthorAndAuditResult",oHT,oWINWData.Tables[WINWData.WINW_TABLE]);
			return oWINWData;
		}
		#endregion
	}
	#endregion public class WINWs
}
