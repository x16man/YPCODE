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


namespace Shmzh.MM.Facade
{
	using System;
    using Shmzh.MM.Common;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IMAIOSystem 的摘要说明。
	/// </summary>
	public interface IMAIOSystem
	{
		/// <summary>
		/// 新增库存盘点数据。
		/// </summary>
		/// <param name="oMAIOData">MAIOData: 库存盘点数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddMAIO(MAIOData oMAIOData);
	}
}
