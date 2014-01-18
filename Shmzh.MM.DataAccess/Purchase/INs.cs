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
	/// INs 的摘要说明。
	/// </summary>
	public class INs : Messages
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
		/// 获取所有等待入库的单据清单。
		/// </summary>
		/// <returns>InData:	待收料单据清单实体。</returns>
		public InData GetInDataAll()
		{
			InData oInData = new InData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_InDataGetAll",oInData.Tables["ViewIN"]);
			return oInData;
		}
		/// <summary>
		/// 根据仓库管理员获取待收料清单。
		/// </summary>
		/// <param name="UserCode">string:	仓库管理员编号。</param>
		/// <returns>InData:	待收料单据清单实体。</returns>
		public InData GetInDataByStoManager(string UserCode)
		{
			InData oInData = new InData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserCode",		UserCode);
			oSQLServer.ExecSPReturnDS("Pur_InDataGetByStoManager",oHT, oInData.Tables["ViewIN"]);
			return oInData;
		}
		/// <summary>
		/// 根据仓库管理员和制定单据状态获取收料单据清单。
		/// </summary>
		/// <param name="UserCode">string:	用户编号。</param>
		/// <param name="EntryState">string:	单据状态。</param>
		/// <returns>InData:	待收料单据清单实体。</returns>
		public InData GetInDataByStoManagerAndEntryState(string UserCode, string EntryState)
		{
			InData oInData = new InData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserCode", UserCode);
			oHT.Add("@EntryState",EntryState );
			oSQLServer.ExecSPReturnDS("Pur_InDataGetByStoManagerAndEntryState",oHT, oInData.Tables["ViewIn"]);
			return oInData;
		}
		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public INs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
