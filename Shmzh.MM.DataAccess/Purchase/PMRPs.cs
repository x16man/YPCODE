#define DEBUG
#undef DEBUG
using System.Collections;
using System.Data;
using MZHCommon.Database;
using System;
using Shmzh.MM.Common;
#if DEBUG 
using NUnit.Framework;
#endif

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

	#region public class PMRPs

	/// <summary>
	/// PMRPs 的摘要说明。
	/// </summary>
	#if DEBUG 
	[TestFixture]
	#endif
	public class PMRPs : Messages, IInItems
	{
		#region 构造函数

		public PMRPs()
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
		/// <param name="oEntry">PMRPData:	物料需求单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(PMRPData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[PMRPData.PMRP_TABLE].Rows[0];
			//收料模式公用字段。
			oHT.Add("@EntryNo", oRow[InItemData.ENTRYNO_FIELD]); //单据流水号。
			oHT.Add("@EntryCode", oRow[InItemData.ENTRYCODE_FIELD]); //单据编号。
			oHT.Add("@DocCode", oRow[InItemData.DOCCODE_FIELD]); //单据类型。
			oHT.Add("@DocName", oRow[InItemData.DOCNAME_FIELD]); //单据类型名称。
			oHT.Add("@DocNo", oRow[InItemData.DOCNO_FIELD]); //单据类型文档编号。
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]); //单据状态。
			oHT.Add("@EntryDate", oRow[InItemData.ENTRYDATE_FIELD]); //制单日期。
			oHT.Add("@AuthorCode", oRow[InItemData.AUTHORCODE_FIELD]); //制单人编号。
			oHT.Add("@AuthorName", oRow[InItemData.AUTHORNAME_FIELD]); //制单人名称。
			oHT.Add("@AuthorLoginID", oRow[InItemData.AUTHORLOGINID_FIELD]); //制单人登录名。
			oHT.Add("@AuthorDept", oRow[InItemData.AUTHORDEPT_FIELD]); //制单人部门。
			oHT.Add("@AuthorDeptName", oRow[InItemData.AUTHORDEPTNAME_FIELD]); //制单人部门名称。
			oHT.Add("@SubTotal", oRow[InItemData.SUBTOTAL_FIELD]); //申请总金额。
			oHT.Add("@Remark", oRow[InItemData.REMARK_FIELD]); //备注。
			oHT.Add("@SerialNoList", oRow[InItemData.SERIALNO_FIELD]); //单据明细内容顺序号。
			oHT.Add("@ItemCodeList", oRow[InItemData.ITEMCODE_FIELD]); //物料编号。
			oHT.Add("@ItemNameList", oRow[InItemData.ITEMNAME_FIELD]); //物料名称。
			oHT.Add("@ItemSpecialList", oRow[InItemData.ITEMSPECIAL_FIELD]); //物料规格。
			oHT.Add("@ItemPriceList", oRow[InItemData.ITEMPRICE_FIELD]); //物料单价。
			oHT.Add("@ItemNumList", oRow[InItemData.ITEMNUM_FIELD]); //物料数量。
			oHT.Add("@ItemMoneyList", oRow[InItemData.ITEMMONEY_FIELD]); //物料金额。
			oHT.Add("@ItemUnitList", oRow[InItemData.ITEMUNIT_FIELD]); //物料单位。
			oHT.Add("@ItemUnitNameList", oRow[InItemData.ITEMUNITNAME_FIELD]); //物料单位描述。
			//物料需求单特有字段。
			oHT.Add("@ReqDept", oRow[PMRPData.REQDEPT_FIELD]); //申请部门。
			oHT.Add("@ReqDeptName", oRow[PMRPData.REQDEPTNAME_FIELD]); //申请部门名称。
			oHT.Add("@Proposer", oRow[PMRPData.PROPOSER_FIELD]); //申请人。
			oHT.Add("@ProposerCode", oRow[PMRPData.PROPOSERCODE_FIELD]); //申请人编号。
			oHT.Add("@ReqReasonCode", oRow[PMRPData.REQREASONCODE_FIELD]); //申请理由编号。
			oHT.Add("@ReqReason", oRow[PMRPData.REQREASON_FIELD]); //申请理由。
			oHT.Add("@ReqDateList", oRow[PMRPData.REQDATE_FIELD]); //要求到货日期。
			return oHT;
		}

		#endregion 私有方法

		#region IInItems 成员

		/// <summary>
		/// 物料需求单增加。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
#if DEBUG 
		[Test]
#endif
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				PMRPData oEntry = (PMRPData) Entry;
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = this.FillHashTable(oEntry);

				ret = oSQLServer.ExecSP("Pur_MRPInsert", oHT);
				if (ret == false)
				{
					this.Message = PMRPData.ADD_FAILED;
				}
				else
				{
					this.Message = PMRPData.ADD_SUCCESSED;
				}
			}
			else
			{
				ret = false;
				this.Message = PMRPData.NOOBJECT;
			}
			return ret;
		}

		/// <summary>
		/// 物料需求单增加并且提交。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				PMRPData oEntry = (PMRPData) Entry;
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = this.FillHashTable(oEntry);

				ret = oSQLServer.ExecSP("Pur_MRPInsertAndPresent", oHT);
				if (ret == false)
				{
					this.Message = PMRPData.ADD_FAILED;
				}
				else
				{
					this.Message = PMRPData.ADD_SUCCESSED;
				}
			}
			else
			{
				ret = false;
				this.Message = PMRPData.NOOBJECT;
			}
			return ret;
		}

		/// <summary>
		/// 物料需求单修改。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret = true;
			PMRPData oEntry = (PMRPData) Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_MRPUpdate", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PMRPData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 修改并且提交物料需求单。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			PMRPData oEntry = (PMRPData) Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_MRPUpdateAndPresent", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PMRPData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 收料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_MRPDelete", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.DELETE_FAILED;
			}
			else
			{
				this.Message = PMRPData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 更改物料需求单状态。
		/// </summary>
		/// <param name="EntryNo">int:	物料需求单流水号。</param>
		/// <param name="EntryState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", EntryState);

			ret = oSQLServer.ExecSP("Pur_MRPUpdateState", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PMRPData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strEmpCode"></param>
        /// <param name="strEntryNo"></param>
        /// <returns></returns>
        public bool IsAuditDept(string strEmpCode, int EntryNo)
        {
            PMRPData oPMRPData = new PMRPData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", strEmpCode);
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Pur_MRPAuditDept", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
            if (oPMRPData.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

		/// <summary>
		/// 物料需求单一级审批。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				PMRPData oEntry = (PMRPData) Entry;
				DataRow oRow;
				oRow = oEntry.Tables[PMRPData.PMRP_TABLE].Rows[0];

				oHT.Add("@EntryNo", oRow[InItemData.ENTRYNO_FIELD]);
				oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
				oHT.Add("@Audit1", oRow[InItemData.AUDIT1_FIELD]);
				oHT.Add("@Assessor1", oRow[InItemData.ASSESSOR1_FIELD]);
				oHT.Add("@AuditSuggest1", oRow[InItemData.AUDITSUGGEST1_FIELD]);
				oHT.Add("@UserLoginId", oRow[InItemData.AUTHORLOGINID_FIELD]);

				ret = oSQLServer.ExecSP("Pur_MRPFirstAudit", oHT);
				if (ret == false)
				{
					this.Message = PMRPData.FIRSTAUDIT_FAILED;
				}
				else
				{
					this.Message = PMRPData.FIRSTAUDIT_SUCCESSED;
				}
			}
			else
			{
				ret = false;
				this.Message = PMRPData.NOOBJECT;
			}
			return ret;
		}

		/// <summary>
		/// 物料需求单二级审批。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				PMRPData oEntry = (PMRPData) Entry;
				DataRow oRow;
				oRow = oEntry.Tables[PMRPData.PMRP_TABLE].Rows[0];

				oHT.Add("@EntryNo", oRow[InItemData.ENTRYNO_FIELD]);
				oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
				oHT.Add("@Audit2", oRow[InItemData.AUDIT2_FIELD]);
				oHT.Add("@Assessor2", oRow[InItemData.ASSESSOR2_FIELD]);
				oHT.Add("@AuditSuggest2", oRow[InItemData.AUDITSUGGEST2_FIELD]);
				oHT.Add("@UserLoginId", oRow[InItemData.AUTHORLOGINID_FIELD]);

				ret = oSQLServer.ExecSP("Pur_MRPSecondAudit", oHT);
				if (ret == false)
				{
					this.Message = PMRPData.SECONDAUDIT_FAILED;
				}
				else
				{
					this.Message = PMRPData.SECONDAUDIT_SUCCESSED;
				}
			}
			else
			{
				ret = false;
				this.Message = PMRPData.NOOBJECT;
			}
			return ret;
		}

		/// <summary>
		/// 物料需求单三级审批。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			PMRPData oEntry = (PMRPData) Entry;
			DataRow oRow;
			oRow = oEntry.Tables[PMRPData.PMRP_TABLE].Rows[0];

			oHT.Add("@EntryNo", oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3", oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3", oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3", oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId", oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_MRPThirdAudit", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PMRPData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 物料需求单提交。
		/// </summary>
		/// <param name="EntryNo">int:	物料需求单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_MRPPresent", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PMRPData.PRESENT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 物料需求单作废。
		/// </summary>
		/// <param name="EntryNo">int:	物料需求单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);

			ret = oSQLServer.ExecSP("Pur_MRPCancel", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PMRPData.CANCEL_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 物料需求单作废。
		/// </summary>
		/// <param name="EntryNo">int:	物料需求单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginID">string:	operator.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID", UserLoginID);
			ret = oSQLServer.ExecSP("Pur_MRPCancel", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PMRPData.CANCEL_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	物料需求单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_MRPGetByEntryNo", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

		/// <summary>
		/// 根据单据编号号获取单据。
		/// </summary>
		/// <param name="EntryCode">int:	单据编号。</param>
		/// <returns>object:	物料需求单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode", EntryCode);

			oSQLServer.ExecSPReturnDS("Pur_MRPGetByEntryCode", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

		/// <summary>
		/// 获取所有单据。
		/// </summary>
		/// <returns>object:	物料需求单实体。</returns>
		public object GetEntryAll()
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_MRPGetAll", oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

		/// <summary>
		/// 根据用户对于部门的权限获取单据列表。
		/// </summary>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>object:	物料需求单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId", UserLoginId);
            
			oSQLServer.ExecSPReturnDS("Pur_MRPGetAll", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

        /// <summary>
        /// 根据用户对于本人的权限获取单据列表。
        /// </summary>
        /// <param name="UserLoginId">string:	用户。</param>
        /// <returns>object:	物料需求单实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            PMRPData oPMRPData = new PMRPData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Pur_MRPGetByPerson", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
            return oPMRPData;
        }

		/// <summary>
		/// 根据指定的制单部门获取采购申请单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	物料需求单实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept", DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_MRPGetByDeptCode", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

		#endregion

		#region 通用查询

		public PMRPData GetEntryBySQL(string Sql_Statement)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement", Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}
		public PMRPData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult, DateTime StartDate, DateTime EndDate)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept", AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);

			oSQLServer.ExecSPReturnDS("Pur_MRPGetByDeptAndAuthorAndAuditResult", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}
		#endregion
	}

	#endregion public class PMRPs
}