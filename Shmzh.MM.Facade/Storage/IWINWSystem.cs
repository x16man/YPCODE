#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// 委外加工申请单的业务外观层需要实现的接口。
	/// </summary>
	public interface IWINWSystem
	{
		/// <summary>
		/// 委外加工申请单的增加。
		/// </summary>
		/// <param name="oEntry">WINWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddWINW(WINWData oEntry);
		/// <summary>
		/// 委外加工申请单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">WINWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddAndPresentWINW(WINWData oEntry);
		/// <summary>
		/// 委外加工申请单的修改。
		/// </summary>
		/// <param name="oEntry">WINWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateWINW(WINWData oEntry);
		/// <summary>
		/// 委外加工申请单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">WINWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateAndPresentWINW(WINWData oEntry);
		/// <summary>
		/// 委外加工申请单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteWINW(int EntryNo, string UserLoginId);
		/// <summary>
		/// 委外加工申请单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string: 用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentWINW(int EntryNo,string UserLoginId);
		/// <summary>
		/// 委外加工申请单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelWINW(int EntryNo, string UserLoginId);
		/// <summary>
		/// 委外加工申请单的部门审批。
		/// </summary>
		/// <param name="oEntry">WINWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditWINW(WINWData oEntry);
		/// <summary>
		/// 委外加工申请单的财务审批。
		/// </summary>
		/// <param name="oEntry">WINWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditWINW(WINWData oEntry);
		/// <summary>
		/// 委外加工申请单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WINWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditWINW(WINWData oEntry);
		/// <summary>
		/// 委外加工收料单收料。
		/// </summary>
		/// <param name="oEntry">WINWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool StockInWINW(WINWData oEntry);
		/// <summary>
		/// 获取所有委外加工申请单。
		/// </summary>
		/// <returns>WINWData:	单据实体。</returns>
		WINWData GetWINWAll(string UserLoginId);
		/// <summary>
		/// 根据流水号获取委外加工申请单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WINWData:	单据实体。</returns>
		WINWData GetWINWByEntryNo(int EntryNo);
		/// <summary>
		/// 根据SQL语句获取委外加工收料单。
		/// </summary>
		/// <param name="SQL_Statement">string:	SQL语句。</param>
		/// <returns>WINWData:	单据实体。</returns>
		WINWData GetWINWBySQL(string SQL_Statement);
	}
}
