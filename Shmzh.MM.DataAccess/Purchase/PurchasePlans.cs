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
	using System.Collections;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// PurchasePlans 的摘要说明。
	/// </summary>
	public class PurchasePlans : Messages,IInItems
	{
        #region Property
        /// <summary>
        /// 数据库连接字符串。
        /// </summary>
        public string ConnString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
        #endregion

		#region 构造函数
		public PurchasePlans()
		{
		}
		#endregion

		#region 私有方法
		private Hashtable FillHashTable(PurchasePlanData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];
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
			
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//物料编号。
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//物料名称。
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//物料规格。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//物料单价。
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//物料数量。
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//物料金额。
			//采购计划特有字段。
			oHT.Add("@SourceEntryList",		oRow[PurchasePlanData.SOURCEENTRY_FIELD]);			//源单据编号。
			oHT.Add("@SourceDocCodeList",	oRow[PurchasePlanData.SOURCEDOCCODE_FIELD]);		//源单据类型编号。
			oHT.Add("@PlanDate",			oRow[PurchasePlanData.PLANDATE_FIELD]);				//计划日期。
			oHT.Add("@ItemLackNumList",		oRow[PurchasePlanData.ITEMLACKNUM_FIELD]);			//未生成订单数量。
			oHT.Add("@ReqDeptList",			oRow[PurchasePlanData.REQDEPT_FIELD]);				//申请部门。
			oHT.Add("@ReqDeptNameList",		oRow[PurchasePlanData.REQDEPTNAME_FIELD]);			//申请部门名称。
			oHT.Add("@ReqReasonCodeList",	oRow[PurchasePlanData.REQREASONCODE_FIELD]);		//用途编号。
			oHT.Add("@ReqReasonList",		oRow[PurchasePlanData.REQREASON_FIELD]);			//用途。
			oHT.Add("@ReqDateList",			oRow[PurchasePlanData.REQDATE_FIELD]);				//要求日期。
			oHT.Add("@RemarkList",			oRow[InItemData.REMARK_FIELD]);						//备注。
			return oHT;
		}
		#endregion

		#region IInItems 成员
		/// <summary>
		/// 采购计划的插入。
		/// </summary>
		/// <param name="Entry">object:	采购计划实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			PurchasePlanData oEntry = (PurchasePlanData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PlanInsert",oHT);
			
			if(ret == false)
			{
				this.Message = PurchasePlanData.ADD_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划的新建并且提交。
		/// </summary>
		/// <param name="Entry">object:	采购计划实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			PurchasePlanData oEntry = (PurchasePlanData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PlanInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message = PurchasePlanData.ADD_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划修改。
		/// </summary>
		/// <param name="Entry">object:	采购计划实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret = true;
			PurchasePlanData oEntry = (PurchasePlanData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PlanUpdate",oHT);
			
			if(ret == false)
			{
				this.Message = PurchasePlanData.ADD_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划修改并且提交。
		/// </summary>
		/// <param name="Entry">object:	采购计划实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			PurchasePlanData oEntry = (PurchasePlanData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PlanUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message = PurchasePlanData.ADD_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_PlanDelete", oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.DELETE_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划状态修改。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",newState);

			ret = oSQLServer.ExecSP("Pur_PlanUpdateState", oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划一级审批。
		/// </summary>
		/// <param name="Entry">object:	采购计划实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchasePlanData oEntry= (PurchasePlanData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PlanFirstAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划二级审批。
		/// </summary>
		/// <param name="Entry">object:	采购计划实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchasePlanData oEntry= (PurchasePlanData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PlanSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划三级审批。
		/// </summary>
		/// <param name="Entry">object:	采购计划实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchasePlanData oEntry= (PurchasePlanData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PlanThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划提交。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_PlanPresent",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.PRESENT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);
						
			ret = oSQLServer.ExecSP("Pur_PlanCancel",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.CANCEL_SUCCESSED;
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
						
			ret = oSQLServer.ExecSP("Pur_PlanCancel",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 根据采购计划流水号获得采购计划。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>object:	采购计划实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByEntryNo",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}
		/// <summary>
		/// 根据采购计划流水号获取采购计划内容除去数量为０的记录。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>object:	采购计划实体。</returns>
		public object GetEntryByEntryNoExceptZero(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByEntryNoExceptZero",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}
		/// <summary>
		/// 获取根据部门分组求和的采购计划内容。
		/// </summary>
		/// <param name="EntryNo">int:	计划流水号。</param>
		/// <returns>object:	采购计划实体。</returns>
		public object GetPPByEntryNoGroupByDep(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByEntryNoGroupByDep",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

		/// <summary>
		/// 根据采购计划编号获得采购计划。
		/// </summary>
		/// <param name="EntryCode">string:	采购计划编号。</param>
		/// <returns>object:	采购计划实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByEntryCode",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

		/// <summary>
		/// 获得所有采购计划。
		/// </summary>
		/// <returns>object:	采购计划实体。</returns>
		public object GetEntryAll()
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_PlanGetAll",oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

		/// <summary>
		/// 根据用户获取所有单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>object:	采购计划实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetAll",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

        /// <summary>
        /// 根据用户获取本人所有单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户登录名。</param>
        /// <returns>object:	采购计划实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            PurchasePlanData oPurchasePlanData = new PurchasePlanData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Pur_PlanGetByPerson", oHT, oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
            return oPurchasePlanData;
        }
		/// <summary>
		/// 获取指定制单部门的采购计划。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	采购计划实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByDeptCode",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

		#endregion

		#region 采购计划专有方法
		/// <summary>
		/// 获取所有的采购计划来源数据。
		/// </summary>
		/// <returns>PPSData:	采购计划来源数据实体。</returns>
		public PPSData GetPPSALL(string UserLoginId)
		{
			PPSData oPPSData = new PPSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId", UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_PPSGetAll",oHT,oPPSData.Tables[PPSData.PPS_TABLE]);
			oSQLServer.ExecSPReturnDS("Pur_PlanNumGetAll",oHT,oPPSData.Tables[PPSData.PLANNUM_TABLE]);
			return oPPSData;
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
                new SqlParameter("@DocCode",DbType.Int16){Value = 5},
                new SqlParameter("@SerialNo",DbType.Int32){Value=serialNo},
                new SqlParameter("@RequestObject",SqlDbType.NVarChar,20){Value="ReqReasonCode"},
            };

            var obj = SqlHelper.ExecuteScalar(this.ConnString, CommandType.Text, sqlStatement, parms);
            return obj == null ? string.Empty : obj.ToString();
        }
		#endregion

		#region 通用查询
		public PurchasePlanData GetEntryBySQL(string Sql_Statement)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}
		#endregion
	}
}
