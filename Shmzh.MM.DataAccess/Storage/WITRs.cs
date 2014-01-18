#region 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved

#region 文档信息
/******************************************************************************
**		文件: 
**		名称: 
**		描述: 
**
**              
**		作者: 张豪
**		日期: 
*******************************************************************************
**		修改历史
*******************************************************************************
**		日期:		作者:		描述:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion 文档信息


namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;
	/// <summary>
	/// WITRs 的摘要说明。
	/// </summary>
	public class WITRs :Messages
	{
		#region 成员变量
		//
		//TODO: 在此处添加成员变量。
		//
		#endregion

		#region 属性
		//
		//TODO: 在此处添加属性。
		//
		#endregion
		
		#region 私有方法
		private Hashtable FillHashTable(WITRData oData)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;
			
			oRow = oData.Tables[WITRData.WITR_Table].Rows[0];
			oHT.Add("@PKID", oRow[WITRData.PKID_Field]);
			oHT.Add("@AuthorCode", oRow[WITRData.AuthorCode_Field]);
			oHT.Add("@AuthorName", oRow[WITRData.AuthorName_Field]);
			oHT.Add("@AuthorLoginID", oRow[WITRData.AuthorLoginID_Field]);
			oHT.Add("@AuthorDept", oRow[WITRData.AuthorDept_Field]);
			oHT.Add("@AuthorDeptName", oRow[WITRData.AuthorDeptName_Field]);
			oHT.Add("@ProposerCode", oRow[WITRData.ProposerCode_Field]);
			oHT.Add("@Proposer", oRow[WITRData.Proposer_Field]);
			oHT.Add("@ReqReasonCode", oRow[WITRData.ReqReasonCode_Field]);
			oHT.Add("@ReqReason", oRow[WITRData.ReqReason_Field]);
			oHT.Add("@ReqDate", oRow[WITRData.ReqDate_Field]);
			oHT.Add("@ItemCode", oRow[WITRData.ItemCode_Field]);
			oHT.Add("@ItemName", oRow[WITRData.ItemName_Field]);
			oHT.Add("@ItemSpec", oRow[WITRData.ItemSpec_Field]);
			oHT.Add("@UnitCode", oRow[WITRData.UnitCode_Field]);
			oHT.Add("@UnitName", oRow[WITRData.UnitName_Field]);
			oHT.Add("@ItemPrice", oRow[WITRData.ItemPrice_Field]);
			oHT.Add("@ItemNum", oRow[WITRData.ItemNum_Field]);
			oHT.Add("@ItemMoney", oRow[WITRData.ItemMoney_Field]);
			oHT.Add("@EntryState", oRow[WITRData.EntryState_Field]);
			oHT.Add("@Remark", oRow[WITRData.Remark_Field]);
			oHT.Add("@FeedBack", oRow[WITRData.FeedBack_Field]);
			oHT.Add("@DocCode", oRow[WITRData.DocCode_Field]);
			return oHT;
		}
		#endregion

		#region 公开方法
		/// <summary>
		/// 新物料申请新建。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRInsert", oHT);
			if (ret == false)
			{
				this.Message = "物料主文件数据申请新增失败！";
			}
			return ret;
		}
		/// <summary>
		/// 新物料申请修改。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool	Update(WITRData oData) 
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRUpdate", oHT);
			if (ret == false)
			{
				this.Message = "物料主文件数据申请新增失败！";
			}
			return ret;
		}
		/// <summary>
		/// 新物料提交.
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRPresent", oHT);
			if (ret == false)
			{
				this.Message = "物料主文件数据申请提交失败！";
			}
			return ret;
		}
		/// <summary>
		/// 新物料申请新建并马上提交.
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRInsertAndPresent", oHT);
			if (ret == false)
			{
				this.Message = "物料主文件数据申请新增并且提交失败！";
			}
			return ret;
		}
		/// <summary>
		/// 新物料申请修改并马上提交。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRUpdateAndPresent", oHT);
			if (ret == false)
			{
				this.Message = "物料数据申请编辑并且提交失败！";
			}
			return ret;
		}
		/// <summary>
		/// 作废新物料申请。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRCancel", oHT);
			if (ret == false)
			{
				this.Message = "物料数据申请作废失败！";
			}
			return ret;
		}  
		/// <summary>
		/// 删除新物料申请。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRDelete", oHT);
			if (ret == false)
			{
				this.Message = "物料主文件数据申请删除失败！";
			}
			return ret;
		}
		/// <summary>
		/// 新物料申请确认。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Affirm(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRAffirm", oHT);
			if (ret == false)
			{
				this.Message = "物料主文件数据申请确认失败！";
			}
			return ret;
		}
		/// <summary>
		/// 新物料申请拒绝.
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Refuse(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRRefuse", oHT);
			if (ret == false)
			{
				this.Message = "物料主文件数据申请退回失败！";
			}
			return ret;
		}
		/// <summary>
		/// 新物料申请转成采购申请单.
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ToPros(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITR2PROS", oHT);
			if (ret == false)
			{
				this.Message = "物料主文件数据申请转紧急申购单失败！";
			}
			return ret;
		}
		/// <summary>
		/// 新物料申请转成月度计划需求单
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ToMRP(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);

			SQLServer oSQLServer = new SQLServer();
			ret = oSQLServer.ExecSP("Sto_WITR2PMRP", oHT);
			if (ret==false)
			{
				this.Message = "物料主文件数据申请转月度计划需求单失败";
			}
			return ret;
		}
		/// <summary>
		/// 获取所有物料申请.
		/// </summary>
		/// <returns>WITRData:	新物料申请数据实体。</returns>
		public WITRData GetWITRALL()
		{
			WITRData oData = new WITRData();

			new SQLServer().ExecSPReturnDS("Sto_WITRGetALL",oData.Tables[WITRData.WITR_Table]);
			return oData;
		}
		/// <summary>
		/// 根据PKID 获取物料申请.
		/// </summary>
		/// <param name="PKID">物料申请ID.</param>
		/// <returns>WITRData:	新物料申请数据实体。</returns>
		public WITRData GetWITRByPKID(Int64 PKID)
		{
			WITRData oData = new WITRData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID", PKID);
			new SQLServer().ExecSPReturnDS("Sto_WITRGetByPKID",oHT,oData.Tables[WITRData.WITR_Table]);	
			return oData;
		}

		#endregion

		#region 构造函数
		public WITRs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
