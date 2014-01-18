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
**		文件:	Outs.cs 
**		名称:	Outs
**		描述:	发料单据清单的数据访问层。	包括：领料单、转库单，退库单。
**
**              
**		作者: 张豪
**		日期: 2005-07-27
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
	/// 发料单据清单的数据访问层。	包括：领料单、转库单，退库单。
	/// </summary>
	public class Outs	: Messages
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
		/// 获取所有待发料和已发料的单据。
		/// </summary>
		/// <returns>OutData:	发料单据清单的数据实体。</returns>
		public OutData GetOutDataAll()
		{
			OutData oOutData = new OutData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_OutDataGetAll",oOutData.Tables["ViewOUT"]);
			return oOutData;
		}
		/// <summary>
		/// 根据仓库管理员获取待发料和已发料的单据。
		/// </summary>
		/// <param name="UserCode">string:	当前用户编号。</param>
		/// <returns>OutData:	发料单据清单的数据实体。</returns>
		public OutData GetOutDataByStoManager(string UserCode)
		{
			OutData oOutData = new OutData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserCode",UserCode);

			oSQLServer.ExecSPReturnDS("Sto_OutDataGetByUserCode",oHT,oOutData.Tables["ViewOUT"]);
			return oOutData;
		}
		/// <summary>
		/// 根据仓库管理员和指定的状态获取发料单据的清单。
		/// </summary>
		/// <param name="UserCode">string:	用户编号。</param>
		/// <param name="EntryState">string:	单据状态。</param>
		/// <returns>OutData:	发料单据清单的数据实体。</returns>
		public OutData GetOutDataByStoManagerAndEntryState(string UserCode,string EntryState)
		{
			OutData oOutData = new OutData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@EntryState",EntryState);

			oSQLServer.ExecSPReturnDS("Sto_OutDataGetByUserCodeAndEntryState",oHT,oOutData.Tables["ViewOUT"]);
			return oOutData;
		}
		#endregion

		#region 构造函数
		public Outs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
