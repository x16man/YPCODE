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
	using System.Collections;
	using MZHCommon.Database;
    using Shmzh.MM.Common;
	/// <summary>
	/// Cancels 的摘要说明。
	/// </summary>
	public class Cancels : Messages
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
		private Hashtable FillHashTable(CancelData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;
			oRow = oEntry.Tables[CancelData.PCOR_Table].Rows[0];
			//收料模式公用字段。
			oHT.Add("@EntryNo", oRow[CancelData.EntryNo_Field]); //单据流水号。
			oHT.Add("@EntryCode", oRow[CancelData.EntryCode_Field]); //单据编号。
			oHT.Add("@DocCode", oRow[CancelData.DocCode_Field]); //单据类型。
			oHT.Add("@DocName", oRow[CancelData.DocName_Field]); //单据类型名称。
			oHT.Add("@DocNo", oRow[CancelData.DocNo_Field]); //单据类型文档编号。
			oHT.Add("@EntryState", oRow[CancelData.EntryState_Field]); //单据状态。
			oHT.Add("@EntryDate", oRow[CancelData.EntryDate_Field]); //制单日期。
			oHT.Add("@AuthorCode", oRow[CancelData.AuthorCode_Field]); //制单人编号。
			oHT.Add("@AuthorName", oRow[CancelData.AuthorName_Field]); //制单人名称。
			oHT.Add("@AuthorLoginID", oRow[CancelData.AuthorLoginID_Field]); //制单人登录名。
			oHT.Add("@AuthorDept", oRow[CancelData.AuthorDept_Field]); //制单人部门。
			oHT.Add("@AuthorDeptName", oRow[CancelData.AuthorDeptName_Field]); //制单人部门名称。
			oHT.Add("@Remark", oRow[CancelData.Remark_Field]); //备注。

			oHT.Add("@SerialNoList", oRow[CancelData.SerialNo_Field]); //单据明细内容顺序号。
			oHT.Add("@SourceEntryList", oRow[CancelData.SourceEntry_Field]); //
			oHT.Add("@SourceDocCodeList", oRow[CancelData.SourceDocCode_Field]); //
			oHT.Add("@SourceSerialNoList", oRow[CancelData.SourceSerialNo_Field]); //
			oHT.Add("@ItemCodeList", oRow[CancelData.ItemCode_Field]); //物料单价。
			oHT.Add("@ItemNameList", oRow[CancelData.ItemName_Field]); //物料数量。
			oHT.Add("@ItemSpecList", oRow[CancelData.ItemSpec_Field]); //物料金额。
			oHT.Add("@ItemUnitList", oRow[CancelData.ItemUnit_Field]); //物料单位。
			oHT.Add("@ItemUnitNameList", oRow[CancelData.ItemUnitName_Field]); //物料单位描述。
			oHT.Add("@ItemPriceList", oRow[CancelData.ItemPrice_Field]);
			oHT.Add("@ItemNumList", oRow[CancelData.ItemNum_Field]);
			oHT.Add("@ItemMoneyList", oRow[CancelData.ItemMoney_Field]);
			return oHT;
		}
		#endregion

		#region 公开方法
		public bool InsertEntry(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = this.FillHashTable(Entry);

				ret = oSQLServer.ExecSP("Pur_CancelInsert", oHT);
				if (ret == false)
				{
					this.Message = "采购撤销单新建失败！";
				}
				else
				{
					this.Message = "采购撤销单新建成功！";
				}
			}
			else
			{
				ret = false;
				this.Message = "空对象！";
			}
			return ret;
		}
		public bool InsertAndPresentEntry(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = this.FillHashTable(Entry);

				ret = oSQLServer.ExecSP("Pur_CancelInsertAndPresent", oHT);
				if (ret == false)
				{
					this.Message = "采购撤销单新建失败！";
				}
				else
				{
					this.Message = "采购撤销单新建成功！";
				}
			}
			else
			{
				ret = false;
				this.Message = "空对象！";
			}
			return ret;
		}
		public bool UpdateEntry(CancelData Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(Entry);

			ret = oSQLServer.ExecSP("Pur_CancelUpdate", oHT);
			if (ret == false)
			{
				this.Message = "采购撤销单修改失败！";
			}
			else
			{
				this.Message = "采购撤销单修改成功！";
			}
			return ret;
		}
		public bool UpdateAndPresentEntry(CancelData Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(Entry);

			ret = oSQLServer.ExecSP("Pur_CancelUpdateAndPresent", oHT);
			if (ret == false)
			{
				this.Message = "采购撤销单修改失败!";
			}
			else
			{
				this.Message = "采购撤销单修改成功!";
			}
			return ret;
		}
		public bool DeleteEntry(int EntryNo)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_CancelDelete", oHT);
			if (ret == false)
			{
				this.Message = "采购撤销单删除失败！";
			}
			else
			{
				this.Message = "采购撤销单删除成功！";
			}
			return ret;
		}
		public bool FirstAudit(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				DataRow oRow;
				oRow = Entry.Tables[CancelData.PCOR_Table].Rows[0];

				oHT.Add("@EntryNo", oRow[CancelData.EntryNo_Field]);
				oHT.Add("@EntryState", oRow[CancelData.EntryState_Field]);
				oHT.Add("@Audit1", oRow[CancelData.Audit1_Field]);
				oHT.Add("@Assessor1", oRow[CancelData.Assessor1_Field]);
				oHT.Add("@AuditSuggest1", oRow[CancelData.AuditSuggest1_Field]);
				oHT.Add("@UserLoginId", oRow[CancelData.AuthorLoginID_Field]);

				ret = oSQLServer.ExecSP("Pur_CancelFirstAudit", oHT);
				if (ret == false)
				{
					this.Message = "采购撤销单一级审批失败！";
				}
				else
				{
					this.Message = "采购撤销单一级审批成功！"  ;
				}
			}
			else
			{
				ret = false;
				this.Message = "空对象!";
			}
			return ret;
		}
		public bool SecondAudit(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				DataRow oRow;
				oRow = Entry.Tables[CancelData.PCOR_Table].Rows[0];

				oHT.Add("@EntryNo", oRow[CancelData.EntryNo_Field]);
				oHT.Add("@EntryState", oRow[CancelData.EntryState_Field]);
				oHT.Add("@Audit2", oRow[CancelData.Audit2_Field]);
				oHT.Add("@Assessor2", oRow[CancelData.Assessor2_Field]);
				oHT.Add("@AuditSuggest2", oRow[CancelData.AuditSuggest2_Field]);
				oHT.Add("@UserLoginId", oRow[CancelData.AuthorLoginID_Field]);

				ret = oSQLServer.ExecSP("Pur_CancelSecondAudit", oHT);
				if (ret == false)
				{
					this.Message = "采购撤销单二级审批失败！";
				}
				else
				{
					this.Message = "采购撤销单二级审批成功！"  ;
				}
			}
			else
			{
				ret = false;
				this.Message = "空对象!";
			}
			return ret;
		}
		public bool ThirdAudit(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				DataRow oRow;
				oRow = Entry.Tables[CancelData.PCOR_Table].Rows[0];

				oHT.Add("@EntryNo", oRow[CancelData.EntryNo_Field]);
				oHT.Add("@EntryState", oRow[CancelData.EntryState_Field]);
				oHT.Add("@Audit3", oRow[CancelData.Audit3_Field]);
				oHT.Add("@Assessor3", oRow[CancelData.Assessor3_Field]);
				oHT.Add("@AuditSuggest3", oRow[CancelData.AuditSuggest3_Field]);
				oHT.Add("@UserLoginId", oRow[CancelData.AuthorLoginID_Field]);

				ret = oSQLServer.ExecSP("Pur_CancelThirdAudit", oHT);
				if (ret == false)
				{
					this.Message = "采购撤销单三级审批失败！";
				}
				else
				{
					this.Message = "采购撤销单三级审批成功！";
				}
			}
			else
			{
				ret = false;
				this.Message = "空对象!";
			}
			return ret;
		}
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_CancelPresent", oHT);
			if (ret == false)
			{
				this.Message = "采购撤销单提交失败！";
			}
			else
			{
				this.Message = "采购撤销单提交成功！";
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID", UserLoginID);
			ret = oSQLServer.ExecSP("Pur_CancelCancel", oHT);
			if (ret == false)
			{
				this.Message = "采购撤销单作废失败！";
			}
			else
			{
				this.Message = "采购撤销单作废成功";
			}
			return ret;
		}
		public CancelData GetEntryByEntryNo(int EntryNo)
		{
			CancelData oCancelData = new CancelData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_CancelGetByEntryNo", oHT, oCancelData.Tables[CancelData.PCOR_Table]);
			return oCancelData;
		}
		public CancelData GetEntryAll(string UserLoginId)
		{
			CancelData oCancelData = new CancelData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId", UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_CancelGetAll", oHT, oCancelData.Tables[CancelData.PCOR_Table]);
			return oCancelData;
		}

        public CancelData GetEntryByPerson(string EmpCode)
        {
            CancelData oCancelData = new CancelData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Pur_CancelGetByPerson", oHT, oCancelData.Tables[CancelData.PCOR_Table]);
            return oCancelData;
        }

		public CancelData GetEntryBySQL(string Sql_Statement)
		{
			CancelData oCancelData = new CancelData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement", Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oCancelData.Tables[CancelData.PCOR_Table]);
			return oCancelData;
		}
		#endregion

		#region 构造函数
		public Cancels()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
