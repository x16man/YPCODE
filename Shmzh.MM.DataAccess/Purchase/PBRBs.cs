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

	#region public class PBRBs
	/// <summary>
	/// 批量进货单的公共数据访问层。
	/// </summary>
	public class PBRBs:Messages,IInItems
	{
		#region 构造函数
		public PBRBs()
		{}
		#endregion 构造函数

		#region 私有方法
		/// <summary>
		/// 填充哈希表。
		/// </summary>
		/// <param name="oEntry">PBRBData:	采购申请单实体。</param>
		/// <returns>Hashtable:	填充好数据的哈希表。</returns>
		private Hashtable FillHashTable(PBRBData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PBRBData.PBRB_TABLE].Rows[0];
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//单据流水号。
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//单据编号。
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//单据类型。
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//单据类型名称。
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//单据类型文档编号。
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//单据状态。
			oHT.Add("@EntryDate",		oRow[InItemData.ENTRYDATE_FIELD]);					//制单日期。
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//制单人编号。
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//制单人名称。
			oHT.Add("@AuthorLoginId",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//制单人登录名。
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//制单人部门。
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//制单人部门名称。
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//备注。
			oHT.Add("@PrvCode",			oRow[PBRBData.PRVCODE_FIELD]);
			oHT.Add("@PrvName",			oRow[PBRBData.PRVNAME_FIELD]);
			oHT.Add("@StoCode",			oRow[PBRBData.STOCODE_FIELD]);
			oHT.Add("@StoName",			oRow[PBRBData.STONAME_FIELD]);
			oHT.Add("@ConCode",			oRow[PBRBData.CONCODE_FIELD]);
			oHT.Add("@ConName",			oRow[PBRBData.CONNAME_FIELD]);
			oHT.Add("@ConArea",			oRow[PBRBData.CONAREA_FIELD]);
			oHT.Add("@OrderNo",			oRow[PBRBData.ORDERNO_FIELD]);
			oHT.Add("@OrderCode",		oRow[PBRBData.ORDERCODE_FIELD]);
			oHT.Add("@BuyerCode",		oRow[PBRBData.BUYERCODE_FIELD]);
			oHT.Add("@BuyerName",		oRow[PBRBData.BUYERNAME_FIELD]);
			oHT.Add("@TotalHeight",		oRow[PBRBData.TOTALHEIGHT_FIELD]);
			oHT.Add("@TotalVolumn",		oRow[PBRBData.TOTALVOLUMN_FIELD]);
			oHT.Add("@Thickness",		oRow[PBRBData.THICKNESS_FIELD]);
			oHT.Add("@Density",			oRow[PBRBData.DENSITY_FIELD]);
			oHT.Add("@BatchCode",		oRow[PBRBData.BATCHCODE_FIELD]);
			oHT.Add("@AmountTo",		oRow[PBRBData.AMOUNTTO_FIELD]);
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//单据明细内容顺序号。
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//物料编号。
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//物料名称。
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//物料规格。
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//物料单位。
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//物料单位描述。
			oHT.Add("@ShipNoList",		oRow[PBRBData.SHIPNO_FIELD]);
			oHT.Add("@StartTimeList",	oRow[PBRBData.STARTTIME_FIELD]);
			oHT.Add("@EndTimeList",		oRow[PBRBData.ENDTIME_FIELD]);
			oHT.Add("@ImportTimeList",	oRow[PBRBData.IMPORTTIME_FIELD]);
			oHT.Add("@ExportTimeList",	oRow[PBRBData.EXPORTTIME_FIELD]);
			oHT.Add("@StartVolumnList",	oRow[PBRBData.STARTVOLUMN_FIELD]);
			oHT.Add("@EndVolumnList",	oRow[PBRBData.ENDVOLUMN_FIELD]);
			oHT.Add("@ItemVolumnList",	oRow[PBRBData.ITEMVOLUMN_FIELD]);
			oHT.Add("@ProductCatList",	oRow[PBRBData.PRODUCTCAT_FIELD]);
			oHT.Add("@DangerCatList",	oRow[PBRBData.DANGERCAT_FIELD]);
			return oHT;
		}
		#endregion 私有方法

		#region IInItems 成员
		/// <summary>
		/// 单据增加。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			PBRBData oEntry = (PBRBData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PBRBInsert",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_PBRBInsert,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 新建并马上提交单据。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			PBRBData oEntry = (PBRBData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PBRBInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_PBRBInsertAndPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 单据修改。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret = true;
			PBRBData oEntry = (PBRBData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PBRBUpdate",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_PBRBUpdate,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 修改并马上提交采购申请单。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			PBRBData oEntry = (PBRBData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PBRBUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,Pur_PBRBUpdateAndPresent,Please look the log file!";
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
			if((new SQLServer()).ExecSP("Pur_PBRBDelete",oHT) == false)
			{
				this.Message="Error,Pur_PBRBDelete,Please look the log file!";
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
			if((new SQLServer()).ExecSP("Pur_PBRBUpdateState",oHT) == false)
			{
				this.Message="Error,Pur_PBRBUpdateState,Please look the log file!";
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
			PBRBData oEntry= (PBRBData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PBRBData.PBRB_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Pur_PBRBFirstAudit",oHT) == false)
			{
				this.Message="Error,Pur_PBRBFirstAduit,Please look the log file!";
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
			PBRBData oEntry= (PBRBData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PBRBData.PBRB_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Pur_PBRBSecondAudit",oHT) == false)
			{
				this.Message="Error,Pur_PBRBSecondAduit,Please look the log file!";
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
			PBRBData oEntry= (PBRBData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PBRBData.PBRB_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("Pur_PBRBThirdAudit",oHT) == false)
			{
				this.Message="Error,Pur_PBRBThirdAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 批量进货单提交。
		/// </summary>
		/// <param name="EntryNo">int:	批量进货单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo,string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId",UserLoginId);
			
			if((new SQLServer()).ExecSP("Pur_PBRBPresent",oHT) == false)
			{
				this.Message="Error,Pur_PBRBPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 批量进货单作废。
		/// </summary>
		/// <param name="EntryNo">int:	批量进货单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo,string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			if((new SQLServer()).ExecSP("Pur_PBRBCancel",oHT) == false)
			{
				this.Message="Error,Pur_PBRBCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 批量进货单作废。
		/// </summary>
		/// <param name="EntryNo">int:	批量进货单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginId">string:	操作人。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo,string newState,string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID",UserLoginID);

			if((new SQLServer()).ExecSP("Pur_PBRBCancel",oHT) == false)
			{
				this.Message="Error,Pur_PBRBCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 根据单据流水号获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	批量进货单。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PBRBData oPBRBData = new PBRBData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_PBRBGetByEntryNo",oHT,oPBRBData.Tables[PBRBData.PBRB_TABLE]);
			return oPBRBData;
		}
		/// <summary>
		/// 根据单据编号获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	批量进货单。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PBRBData oPBRBData = new PBRBData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryCode);
			oSQLServer.ExecSPReturnDS("Pur_PBRBGetByEntryCode",oHT,oPBRBData.Tables[PBRBData.PBRB_TABLE]);
			return oPBRBData;
		}
		/// <summary>
		/// 获取所有请购单。
		/// </summary>
		/// <returns>object:	批量进货单。</returns>
		public object GetEntryAll()
		{
			PBRBData oPBRBData = new PBRBData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Pur_PBRBGetAll",oPBRBData.Tables[PBRBData.PBRB_TABLE]);
			return oPBRBData;
		}
		/// <summary>
		/// 根据指定的制单部门获取批量进货单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	批量进货单。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PBRBData oPBRBData = new PBRBData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_PBRBGetByDeptCode",oHT,oPBRBData.Tables[PBRBData.PBRB_TABLE]);
			return oPBRBData;
		}
		/// <summary>
		/// 返回当前可用批号。
		/// </summary>
		/// <param name="YYMM">string:	当前的年月字符串。</param>
		/// <returns>string:	批号。</returns>
		public string GetBatchCode(string YYMM)
		{
			string BatchCode = "12345678";
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@YYMM",YYMM);
			oHT.Add("@BatchCode",BatchCode);
			oSQLServer.ExecSP("Pur_PBRBGetBatchCode",oHT);
			BatchCode = oHT["@BatchCode"].ToString();
			return BatchCode;
		}
		#endregion
	
		#region 通用查询
		/// <summary>
		/// 用户默认的查询方案。
		/// </summary>
		/// <returns>object:	请购单实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			PBRBData oPBRBData = new PBRBData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("Pur_PBRBGetAll",oHT,oPBRBData.Tables[PBRBData.PBRB_TABLE]);
			return oPBRBData;
		}
		/// <summary>
		/// 根据查询方案获取结果集。
		/// </summary>
		/// <param name="Sql_statement"></param>
		/// <returns></returns>
		public PBRBData GetEntryBySQL(string Sql_Statement)
		{
			PBRBData oPBRBData = new PBRBData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oPBRBData.Tables[PBRBData.PBRB_TABLE]);
			return oPBRBData;
		}
		#endregion
	}
	#endregion public class PBRBs
}
