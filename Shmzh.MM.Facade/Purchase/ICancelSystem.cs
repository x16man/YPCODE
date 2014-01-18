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
	/// ICancelSystem 的摘要说明。
	/// </summary>
	public interface ICancelSystem
	{
		bool AddCancel(CancelData oEntry);
		bool UpdateCancel(CancelData oEntry);
		bool AddAndPresentCancel(CancelData oEntry);
		bool UpdateAndPresentCancel(CancelData oEntry);
		bool PresentCancel(int EntryNo, string UserLoginId);
		bool CancelCancel(int EntryNo, string UserLoginId);
		bool DeleteCancel(int EntryNo);
		bool FirstAuditCancel(CancelData oEntry);
		bool SecondAuditCacel(CancelData oEntry);
		bool ThirdAuditCancel(CancelData oEntry);
		CancelData GetCancelAll(string UserLoginID);
		CancelData GetCancelByEntryNo(int EntryNo);
	}
}
