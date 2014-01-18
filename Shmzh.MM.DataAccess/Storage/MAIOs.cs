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
	using System.Data.SqlClient;
	using System.Configuration ;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// MAIOs 的摘要说明。
	/// </summary>
	public class MAIOs : Messages
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
		//
		//TODO: 在这此处加私有方法。
		//
		#endregion

		#region 公开方法
		/// <summary>
		/// 新增库存盘点数据。
		/// </summary>
		/// <param name="oMAIOData">MAIOData:	库存盘点数据集。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Add( MAIOData oMAIOData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable oHT = new Hashtable ();
			SQLServer oSQLServer = new SQLServer ();
			oHT.Add("@ItemCode",	oMAIOData.ItemCode);
			oHT.Add("@ItemName",	oMAIOData.ItemName);
			oHT.Add("@ItemSpec",	oMAIOData.ItemSpec);
			oHT.Add("@UnitCode",	oMAIOData.UnitCode);
			oHT.Add("@UnitName",	oMAIOData.UnitName);
			oHT.Add("@StoCode",		oMAIOData.StoCode);
			oHT.Add("@StoName",		oMAIOData.StoName);
			oHT.Add("@ConName",		oMAIOData.ConName);
			oHT.Add("@BookNum",		oMAIOData.BookNum);
			oHT.Add("@BookPrice",	oMAIOData.BookPrice);
			//oHT.Add("@BookPrice",decimal.Parse(oMAIOData.Tables[0].Rows[0][MAIOData.BookPrice_Field].ToString()));
			oHT.Add("@ItemNum",		oMAIOData.ItemNum);
			oHT.Add("@AuthorCode",	oMAIOData.AuthorCode);
			oHT.Add("@AuthorName",	oMAIOData.AuthorName);

			if (oSQLServer.ExecSP("Sto_MAIOInsert",oHT))
			{
				this.Message = "保存成功！";
				retValue = true;
			}
			else
			{
				this.Message = "保存失败！";
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 库存盘点记录修改。
		/// </summary>
		/// <param name="oMAIOData">MAIOData：	库存盘点记录实体。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="ConName">string:	架位名称。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(MAIOData oMAIOData,string StoCode, string ConName)
		{
			bool retValue;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@ItemCode",	oMAIOData.ItemCode);
			oHT.Add("@ItemName",	oMAIOData.ItemName);
			oHT.Add("@ItemSpec",	oMAIOData.ItemSpec);
			oHT.Add("@UnitCode",	oMAIOData.UnitCode);
			oHT.Add("@UnitName",	oMAIOData.UnitName);
			oHT.Add("@StoCode",		oMAIOData.StoCode);
			oHT.Add("@StoName",		oMAIOData.StoName);
			oHT.Add("@ConName",		oMAIOData.ConName);
			oHT.Add("@BookNum",		oMAIOData.BookNum);
			oHT.Add("@BookPrice",	oMAIOData.BookPrice);
			//oHT.Add("@BookPrice",decimal.Parse(oMAIOData.Tables[0].Rows[0][MAIOData.BookPrice_Field].ToString()));
			oHT.Add("@ItemNum",		oMAIOData.ItemNum);
			oHT.Add("@AuthorCode",	oMAIOData.AuthorCode);
			oHT.Add("@AuthorName",	oMAIOData.AuthorName);
			oHT.Add("@OldStoCode",  StoCode);
			oHT.Add("@OldConName",	ConName);
			if (oSQLServer.ExecSP("Sto_MAIOUpdate",oHT))
			{
				this.Message = "保存成功！";
				retValue = true;
			}
			else
			{
				this.Message = "保存失败！";
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 根据物料编号仓库编号架位名称获取库存盘点记录。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="ConName">string:	架位名称。</param>
		/// <returns>MAIOData:	库存盘点数据实体。</returns>
		public MAIOData GetMAIOByItemCodeAndStoCodeAndConName(string ItemCode, string StoCode, string ConName)
		{
			MAIOData oMAIOData = new MAIOData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			oHT.Add("@StoCode", StoCode);
			oHT.Add("@ConName", ConName);
			oSQLServer.ExecSPReturnDS("Sto_MAIOGetByItemCodeAndStoCodeAndConName",oHT,oMAIOData.Tables[MAIOData.MAIO_Table]);
			return oMAIOData;
		}
		/// <summary>
		/// 根据物料编号获取盘点记录清单。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <returns>MAIOData:	库存盘点数据实体。</returns>
		public MAIOData GetMAIOByItemCode(string ItemCode)
		{
			MAIOData oMAIOData = new MAIOData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			oSQLServer.ExecSPReturnDS("Sto_MAIOGetByItemCode",oHT,oMAIOData.Tables[MAIOData.MAIO_Table]);
			return oMAIOData;
		}
		#endregion

		#region 构造函数
		public MAIOs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
