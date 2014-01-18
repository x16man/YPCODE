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
	/// PPAYs 的摘要说明。
	/// </summary>
	public class PPAYs :Messages
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
		private Hashtable FillHashTable(PPAYData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[PPAYData.PPAY_Table].Rows[0];
			//委外加工收料单模式公用字段。
			oHT.Add("@EntryNo", oRow[PPAYData.EntryNo_Field]);
			oHT.Add("@EntryCode", oRow[PPAYData.EntryCode_Field]);
			oHT.Add("@DocCode", oRow[PPAYData.DocCode_Field]);
			oHT.Add("@DocName", oRow[PPAYData.DocName_Field]);
			oHT.Add("@DocNo", oRow[PPAYData.DocNo_Field]);
			oHT.Add("@EntryState", oRow[PPAYData.EntryState_Field]);
			oHT.Add("@EntryDate", oRow[PPAYData.EntryDate_Field]);
			oHT.Add("@PresentDate", oRow[PPAYData.PresentDate_Field]);
			oHT.Add("@CancelDate", oRow[PPAYData.CancelDate_Field]);
			oHT.Add("@PayDate", oRow[PPAYData.PayDate_Field]);
			oHT.Add("@PayerCode", oRow[PPAYData.PayerCode_Field]);
			oHT.Add("@PayerName", oRow[PPAYData.PayerName_Field]);
			oHT.Add("@PayerLoginId", oRow[PPAYData.PayerLoginId_Field]);
			oHT.Add("@PrvCode", oRow[PPAYData.PrvCode_Field]);
			oHT.Add("@PrvName", oRow[PPAYData.PrvName_Field]);
			oHT.Add("@PrvBank", oRow[PPAYData.PrvBank_Field]);
			oHT.Add("@PrvAccount", oRow[PPAYData.PrvAccount_Field]);
			oHT.Add("@PrvRegNo", oRow[PPAYData.PrvRegNo_Field]);
			oHT.Add("@PrvTel", oRow[PPAYData.PrvTel_Field]);
			oHT.Add("@PrvFax", oRow[PPAYData.PrvFax_Field]);
			oHT.Add("@PayStyle", oRow[PPAYData.PayStyle_Field]);
			oHT.Add("@InvoiceNo", oRow[PPAYData.InvoiceNo_Field]);
			oHT.Add("@AuthorCode", oRow[PPAYData.AuthorCode_Field]);
			oHT.Add("@AuthorName", oRow[PPAYData.AuthorName_Field]);
			oHT.Add("@AuthorLoginId", oRow[PPAYData.AuthorLoginId_Field]);
			oHT.Add("@AuthorDept", oRow[PPAYData.AuthorDept_Field]);
			oHT.Add("@AuthorDeptName", oRow[PPAYData.AuthorDeptName_Field]);
			oHT.Add("@SourceAuthorDept", oRow[PPAYData.SourceAuthorDept_Field]);
			oHT.Add("@SourceAuthorDeptName", oRow[PPAYData.SourceAuthorDeptName_Field]);
			oHT.Add("@Audit1", oRow[PPAYData.Audit1_Field]);
			oHT.Add("@Assessor1", oRow[PPAYData.Assessor1_Field]);
			oHT.Add("@AuditDate1", oRow[PPAYData.AuditDate1_Field]);
			oHT.Add("@AuditSuggest1", oRow[PPAYData.AuditSuggest1_Field]);
			oHT.Add("@Audit2", oRow[PPAYData.Audit2_Field]);
			oHT.Add("@Assessor2", oRow[PPAYData.Assessor2_Field]);
			oHT.Add("@AuditDate2", oRow[PPAYData.AuditDate2_Field]);
			oHT.Add("@AuditSuggest2", oRow[PPAYData.AuditSuggest2_Field]);
			oHT.Add("@Audit3", oRow[PPAYData.Audit3_Field]);
			oHT.Add("@Assessor3", oRow[PPAYData.Assessor3_Field]);
			oHT.Add("@AuditDate3", oRow[PPAYData.AuditDate3_Field]);
			oHT.Add("@AuditSuggest3", oRow[PPAYData.AuditSuggest3_Field]);
			oHT.Add("@TotalMoney", oRow[PPAYData.TotalMoney_Field]);
			oHT.Add("@TotalFee", oRow[PPAYData.TotalFee_Field]);
			oHT.Add("@SubTotal", oRow[PPAYData.SubTotal_Field]);
			////////////////////////////////////////////////////////////////////
			Col2List MyList = new Col2List(oEntry.Tables[PPAYData.PDPY_Table]);
			oHT.Add("@SourceEntryNoList",MyList.GetList(PPAYData.SourceEntryNo_Field));
			oHT.Add("@SourceDocCodeList",MyList.GetList(PPAYData.SourceDocCode_Field));
			oHT.Add("@SourceSerialNoList",MyList.GetList(PPAYData.SourceSerialNo_Field));
			oHT.Add("@SerialNoList", MyList.GetList());
			oHT.Add("@ItemCodeList", MyList.GetList(PPAYData.ItemCode_Field));
			oHT.Add("@ItemNameList", MyList.GetList(PPAYData.ItemName_Field));
			oHT.Add("@ItemSpecialList", MyList.GetList(PPAYData.ItemSpecial_Field));
			oHT.Add("@ItemUnitList", MyList.GetList(PPAYData.ItemUnit_Field));
			oHT.Add("@ItemUnitNameList", MyList.GetList(PPAYData.ItemUnitName_Field));
			oHT.Add("@ItemNumList", MyList.GetList(PPAYData.ItemNum_Field));
			oHT.Add("@ItemPriceList", MyList.GetList(PPAYData.ItemPrice_Field));
			oHT.Add("@ItemMoneyList", MyList.GetList(PPAYData.ItemMoney_Field));
			oHT.Add("@ItemFeeList", MyList.GetList(PPAYData.ItemFee_Field));
			oHT.Add("@ItemSumList", MyList.GetList(PPAYData.ItemSum_Field));
			oHT.Add("@AuthorCodeList", MyList.GetList(PPAYData.AuthorCode_Field));
			oHT.Add("@AuthorNameList", MyList.GetList(PPAYData.AuthorName_Field));
			oHT.Add("@BuyerCodeList", MyList.GetList(PPAYData.BuyerCode_Field));			
			oHT.Add("@BuyerNameList", MyList.GetList(PPAYData.BuyerName_Field));			
			oHT.Add("@AcceptCodeList", MyList.GetList(PPAYData.AcceptCode_Field));
			oHT.Add("@AcceptNameList", MyList.GetList(PPAYData.AcceptName_Field));
			oHT.Add("@AcceptDateList", MyList.GetList(PPAYData.AcceptDate_Field));
			oHT.Add("@StoCodeList", MyList.GetList(PPAYData.StoCode_Field));
			oHT.Add("@StoNameList", MyList.GetList(PPAYData.StoName_Field));
			oHT.Add("@ContractCodeList", MyList.GetList(PPAYData.ContractCode_Field));
			return oHT;
		}
		#endregion

		#region 公开方法
		/// <summary>
		/// 采购收料付款明细清单新建.
		/// </summary>
		/// <param name="oEntry">PPAYData: 采购收料付款明细清单实体.</param>
		/// <returns>bool:	成功返回true,失败返回false.</returns>
		public bool Insert(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYInsert",oHT);
			if(ret == false) this.Message = "采购收料付款清单新建失败!";
			return ret;
		}
		/// <summary>
		/// 采购收料付款明细清单更新.
		/// </summary>
		/// <param name="oEntry">PPAYData: 采购收料付款明细清单实体.</param>
		/// <returns>bool:	成功返回true,失败返回false.</returns>
		public bool Update(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYUpdate",oHT);
			if(ret == false) this.Message = "采购收料付款清单更新失败!";
			return ret;
		}
		/// <summary>
		/// 采购收料付款明细清单提交。
		/// </summary>
		/// <param name="oEntry">PPAYData: 采购收料付款明细清单实体.</param>
		/// <returns>bool:	成功返回true,失败返回false.</returns>
		public bool Present(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYPresent",oHT);
			if(ret == false) this.Message = "采购收料付款清单提交失败!";
			return ret;
		}

		public bool InsertAndPresent(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYInsertAndPresent",oHT);
			if(ret == false) this.Message = "采购收料付款清单马上提交失败!";
			return ret;
		}
		public bool UpdateAndPresent(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYUpdateAndPresent",oHT);
			if(ret == false) this.Message = "采购收料付款清单马上提交失败!";
			return ret;
		}
		/// <summary>
		/// 采购收料付款明细清单作废.
		/// </summary>
		/// <param name="oEntry">PPAYData: 采购收料付款明细清单实体.</param>
		/// <returns>bool:	成功返回true,失败返回false.</returns>
		public bool Cancel(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYCancel",oHT);
			if(ret == false) this.Message = "采购收料付款清单作废失败!";
			return ret;	
		}
		/// <summary>
		/// 采购收料付款明细清单删除.
		/// </summary>
		/// <param name="oEntry">PPAYData: 采购收料付款明细清单实体.</param>
		/// <returns>bool:	成功返回true,失败返回false.</returns>
		public bool Delete(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYDelete",oHT);
			if(ret == false) this.Message = "采购收料付款清单删除失败!";
			return ret;
		}
		/// <summary>
		/// 采购收料付款明细清单厂长审批.
		/// </summary>
		/// <param name="oEntry">PPAYData: 采购收料付款明细清单实体.</param>
		/// <returns>bool:	成功返回true,失败返回false.</returns>
		public bool ThirdAudit(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYThirdAudit",oHT);
			if(ret == false) this.Message = "采购收料付款清单厂长审批失败!";
			return ret;
		}
		/// <summary>
		/// 采购收料付款明细清单付款.
		/// </summary>
		/// <param name="oEntry">PPAYData: 采购收料付款明细清单实体.</param>
		/// <returns>bool:	成功返回true,失败返回false.</returns>
		public bool PAY(PPAYData oEntry)
		{
			bool ret = true;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PPAYPay",oHT);
			if(ret == false) this.Message = "采购收料付款清单付款失败!";
			return ret;
		}
		/// <summary>
		/// 获取所有付款清单。
		/// </summary>
		/// <returns>PPAYData:	付款清单实体。</returns>
		public PPAYData GetPAYAll()
		{
			PPAYData oEntry = new PPAYData();
			new SQLServer().ExecSPReturnDS("Pur_PPAYGetAll",oEntry.Tables[PPAYData.PPAY_Table]);
			return oEntry;
		}


        public PPAYData GetPAYByDept(string strDeptCode)
        {
            PPAYData oEntry = new PPAYData();
            Hashtable oHT = new Hashtable();
            oHT.Add("@DeptCode", strDeptCode);
            new SQLServer().ExecSPReturnDS("Pur_PPAYGetByDept",oHT, oEntry.Tables[PPAYData.PPAY_Table]);
            return oEntry;
        }

        /// <summary>
        /// 获取所有付款清单。
        /// </summary>
        /// <returns>PPAYData:	付款清单实体。</returns>
        public PPAYData GetPAYByPerson(string EmpCode)
        {
            PPAYData oEntry = new PPAYData();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);
            new SQLServer().ExecSPReturnDS("Pur_PPAYGetByPerson",oHT, oEntry.Tables[PPAYData.PPAY_Table]);
            return oEntry;
        }

		/// <summary>
		/// 根据编号获取付款清单。
		/// </summary>
		/// <param name="EntryNo">int:	单据编号。</param>
		/// <returns>PPAYData:	付款清单实体。</returns>
		public PPAYData GetPAYByEntryNo(int EntryNo)
		{
			PPAYData oEntry = new PPAYData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			SQLServer mySQLServer = new SQLServer();
			mySQLServer.ExecSPReturnDS("Pur_PPAYGetByEntryNo",oHT,oEntry.Tables[PPAYData.PPAY_Table]);
			mySQLServer.ExecSPReturnDS("Pur_PDPYGetByEntryNo",oHT,oEntry.Tables[PPAYData.PDPY_Table]);
			return oEntry;
		}
		public PPAYData GetPAYByInvoiceNo(string InvoiceNo)
		{
			PPAYData oEntry = new PPAYData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@InvoiceNo",InvoiceNo);
			SQLServer mySQLServer = new SQLServer();
			mySQLServer.ExecSPReturnDS("Pur_PPAYGetByInvoiceNo",oHT,oEntry.Tables[PPAYData.PPAY_Table]);
			mySQLServer.ExecSPReturnDS("Pur_PDPYGetByInvoiceNo",oHT,oEntry.Tables[PPAYData.PDPY_Table]);
			return oEntry;
		}
		/// <summary>
		/// 通用查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL语句。</param>
		/// <returns>PPAYData:	付款清单实体。</returns>
		public PPAYData GetEntryBySQL(string Sql_Statement)
		{
			PPAYData oEntry= new PPAYData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oEntry.Tables[PPAYData.PPAY_Table]);
			return oEntry;
		}
		#endregion

		#region 构造函数
		public PPAYs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
