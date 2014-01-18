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

	#region public class PCBRs
	/// <summary>
	/// PCBRs 的摘要说明。
	/// </summary>
	public class PCBRs : Messages,IInItems
	{
		#region 构造函数
		public PCBRs()
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
		/// <param name="oEntry">PCBRData:	收料验收单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(PCBRData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PCBRData.PCBR_TABLE].Rows[0];
			//收料模式公用字段。
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//单据流水号。
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//单据编号。
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//单据类型。
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//单据类型名称。
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//单据类型文档编号。
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//单据状态。
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//制单人编号。
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//制单人名称。
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//制单人登录名。
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//制单人部门。
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//制单人部门名称。
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//备注。
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。

			//收料验收单特有字段。
			oHT.Add("@RecvDate",		oRow[PCBRData.RECVDATE_FIELD]);
			oHT.Add("@SourceEntry",		oRow[PCBRData.SOURCEENTRY_FIELD]);
			oHT.Add("@SourceDocCode",	oRow[PCBRData.SOURCEDOCCODE_FIELD]);
			oHT.Add("@BatchCode",		oRow[PCBRData.BATCHCODE_FIELD]);
			oHT.Add("@PrvCode",			oRow[PCBRData.PRVCODE_FIELD]);
			oHT.Add("@PrvName",			oRow[PCBRData.PRVNAME_FIELD]);
			oHT.Add("@PrvAdd",			oRow[PCBRData.PRVADD_FIELD]);
			oHT.Add("@PrvZip",			oRow[PCBRData.PRVZIP_FIELD]);
			oHT.Add("@PrvTel",			oRow[PCBRData.PRVTEL_FIELD]);
			oHT.Add("@PrvFax",			oRow[PCBRData.PRVFAX_FIELD]);
			oHT.Add("@ChkDept",			oRow[PCBRData.CHKDEPT_FIELD]);
			oHT.Add("@ChkDeptName",		oRow[PCBRData.CHKDEPTNAME_FIELD]);
			oHT.Add("@CitmCodeList",	oRow[PCBRData.CITMCODE_FIELD]);
			oHT.Add("@CitmNameList",	oRow[PCBRData.CITMNAME_FIELD]);
			oHT.Add("@CitmUnitList",	oRow[PCBRData.CITMUNIT_FIELD]);
			oHT.Add("@CitmValueList",	oRow[PCBRData.CITMVALUE_FIELD]);

			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员

		/// <summary>
		/// 收料验收单增加。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret=true;
			PCBRData oEntry= (PCBRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PCBRInsert", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.ADD_FAILED;
			}
			else
			{
				this.Message = PCBRData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单增加并且提交。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret=true;
			PCBRData oEntry= (PCBRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PCBRInsertAndPresent", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.ADD_FAILED;
			}
			else
			{
				this.Message = PCBRData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单修改。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret=true;
			PCBRData oEntry= (PCBRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PCBRUpdate", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PCBRData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 收料验收单修改。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret=true;
			PCBRData oEntry= (PCBRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PCBRUpdateAndPresent", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PCBRData.UPDATE_SUCCESSED;
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
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_PCBRDelete", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.DELETE_FAILED;
			}
			else
			{
				this.Message = PCBRData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 更改收料验收单状态。
		/// </summary>
		/// <param name="EntryNo">int:	收料验收单流水号。</param>
		/// <param name="EntryState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Pur_PCBRUpdateState", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PCBRData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// 收料验收单一级审批。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PCBRData oEntry= (PCBRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PCBRData.PCBR_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PCBRFirstAudit",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = PCBRData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单二级审批。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PCBRData oEntry= (PCBRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PCBRData.PCBR_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);
			
			ret = oSQLServer.ExecSP("Pur_PCBRSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = PCBRData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单三级审批。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PCBRData oEntry= (PCBRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PCBRData.PCBR_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);
			
			ret = oSQLServer.ExecSP("Pur_PCBRThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PCBRData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单提交。
		/// </summary>
		/// <param name="EntryNo">int:	收料验收单流水号。</param>
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

			ret = oSQLServer.ExecSP("Pur_PCBRPresent",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PCBRData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 收料验收单作废。
		/// </summary>
		/// <param name="EntryNo">int:	收料验收单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			ret = oSQLServer.ExecSP("Pur_PCBRCancel",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PCBRData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	收料验收单实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PCBRData oPCBRData = new PCBRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_PCBRGetByEntryNo",oHT,oPCBRData.Tables[PCBRData.PCBR_TABLE]);
			return oPCBRData;
		}
		/// <summary>
		/// 根据单据编号号获取单据。
		/// </summary>
		/// <param name="EntryCode">int:	单据编号。</param>
		/// <returns>object:	收料验收单实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PCBRData oPCBRData = new PCBRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Pur_PCBRGetByEntryCode",oHT,oPCBRData.Tables[PCBRData.PCBR_TABLE]);
			return oPCBRData;
		}
		/// <summary>
		/// 获取所有单据。
		/// </summary>
		/// <returns>object:	收料验收单实体。</returns>
		public object GetEntryAll()
		{
			PCBRData oPCBRData = new PCBRData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_PCBRGetAll",oPCBRData.Tables[PCBRData.PCBR_TABLE]);
			return oPCBRData;
		}
		/// <summary>
		/// 根据指定的制单部门获取收料验收单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	收料验收单实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PCBRData oPCBRData = new PCBRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_PCBRGetByDeptCode",oHT,oPCBRData.Tables[PCBRData.PCBR_TABLE]);
			return oPCBRData;
		}
		#endregion

		#region 专用方法
		/// <summary>
		/// 根据供应商获取所有验收单的来源。
		/// </summary>
		/// <param name="PrvCode">string:	供应商编号。</param>
		/// <returns>CBRSData:	验收单的来源实体。</returns>
		public CBRSData GetCBRSByPrvCode(string PrvCode)
		{
			CBRSData oCBRSData = new CBRSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PrvCode", PrvCode);

			oSQLServer.ExecSPReturnDS("Pur_CBRSGetByPrvCode",oHT,oCBRSData.Tables[CBRSData.CBRS_VIEW]);
			return oCBRSData;
		}
		/// <summary>
		/// 根据供应商以及日期范围获取所有验收单的来源。
		/// </summary>
		/// <param name="PrvCode">string:	供应商编号。</param>
		/// <param name="StartDate">DateTime:	开始日期。</param>
		/// <param name="EndDate">DateTime:	结束日期。</param>
		/// <returns>CBRSData:	验收单的来源实体。</returns>
		public CBRSData GetCBRSByPrvCodeAndDate(string PrvCode,DateTime StartDate,DateTime EndDate)
		{
			CBRSData oCBRSData = new CBRSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PrvCode", PrvCode);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Pur_CBRSGetByPrvCodeAndDate",oHT,oCBRSData.Tables[CBRSData.CBRS_VIEW]);
			return oCBRSData;
		}
		#endregion
	}
	#endregion public class PCBRs
}
