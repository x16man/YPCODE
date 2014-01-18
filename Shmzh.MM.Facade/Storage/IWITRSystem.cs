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
	/// IWITRSystem 的摘要说明。
	/// </summary>
	public interface IWITRSystem
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
		bool Insert(WITRData oData);
		bool InsertAndPresent(WITRData oData);
		bool Update(WITRData oData);
		bool UpdateAndPresent(WITRData oData);
		bool Cancel(WITRData oData);
		bool Delete(WITRData oData);
		bool Affirm(WITRData oData);
		bool Refuse(WITRData oData);
		bool ToPROS(WITRData oData);
		bool ToMRP(WITRData oData);
		WITRData GetWITRAll();
		WITRData GetWITRByPKID(int PKID);
		#endregion

		#region 构造函数
		
		#endregion
	}
}
