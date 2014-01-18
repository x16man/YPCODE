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
	/// Switchs 的摘要说明。
	/// </summary>
	public class Switchs
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
		/// <summary>
		/// 是否启用限制功能块。
		/// </summary>
		/// <returns>bool:	限制返回true，不限制返回false。</returns>
		private bool FunctionEnable(string FunctionID)
		{
			SwitchData oData = new SwitchData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@FunctionID",FunctionID);
			oSQLServer.ExecSPReturnDS("Sys_SwitchGetByFunctionID",oHT,oData.Tables[SwitchData.Switch_Table]);
			if (oData.Count > 0)
			{
				if (Convert.ToInt32(oData.Tables[SwitchData.Switch_Table].Rows[0][SwitchData.Enable_Field].ToString()) == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		#endregion

		#region 公开方法
		/// <summary>
		/// 是否限制采购订单的数量。
		/// </summary>
		/// <returns>bool:	限制返回true，不限制返回false。</returns>
		public bool OrdNumEnable()
		{
			return this.FunctionEnable("OrdNum");
		}
		/// <summary>
		/// 是否限制采购收料单的物料项。
		/// </summary>
		/// <returns>bool:	限制返回true，不限制返回false。</returns>
		public bool BorItemEnable()
		{
			return this.FunctionEnable("BorItem");
		}
		/// <summary>
		/// 是否限制采购收料单的数量。
		/// </summary>
		/// <returns>bool:	限制返回true，不限制返回false。</returns>
		public bool BorNumEnable()
		{
			return this.FunctionEnable("BorNum");
		}
		#endregion

		#region 构造函数
		public Switchs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
