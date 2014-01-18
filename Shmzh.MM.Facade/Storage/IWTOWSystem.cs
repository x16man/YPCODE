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
	public interface IWTOWSystem
	{
		/// <summary>
		/// 委外加工申请单的增加。
		/// </summary>
		/// <param name="oEntry">WTOWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddWTOW(WTOWData oEntry);
		/// <summary>
		/// 委外加工申请单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">WTOWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddAndPresentWTOW(WTOWData oEntry);
		/// <summary>
		/// 委外加工申请单的修改。
		/// </summary>
		/// <param name="oEntry">WTOWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateWTOW(WTOWData oEntry);
		/// <summary>
		/// 委外加工申请单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">WTOWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateAndPresentWTOW(WTOWData oEntry);
		/// <summary>
		/// 委外加工申请单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteWTOW(int EntryNo);
		/// <summary>
		/// 委外加工申请单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string: 用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentWTOW(int EntryNo,string UserLoginId);
		/// <summary>
		/// 委外加工申请单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelWTOW(int EntryNo);
		/// <summary>
		/// 委外加工申请单的部门审批。
		/// </summary>
		/// <param name="oEntry">WTOWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditWTOW(WTOWData oEntry);
		/// <summary>
		/// 委外加工申请单的财务审批。
		/// </summary>
		/// <param name="oEntry">WTOWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditWTOW(WTOWData oEntry);
		/// <summary>
		/// 委外加工申请单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WTOWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditWTOW(WTOWData oEntry);
		/// <summary>
		/// 获取所有委外加工申请单。
		/// </summary>
		/// <returns>WTOWData:	单据实体。</returns>
		WTOWData GetWTOWAll();
		/// <summary>
		/// 根据流水号获取委外加工申请单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WTOWData:	单据实体。</returns>
		WTOWData GetWTOWByEntryNo(int EntryNo);
		/// <summary>
		/// 根据状态获取委外加工申请单清单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>WTOWData:	委外加工申请单实体。</returns>
		WTOWData GetWTOWByState(string EntryState);
		/// <summary>
		/// 发料模式下的根据流水号获取委外加工申请单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WTOWData:	单据实体。</returns>
		WTOWData GetWTOWByEntryNoOutMode(int EntryNo);
		/// <summary>
		/// 根据编号获取委外加工申请单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>WTOWData:	单据实体。</returns>
		WTOWData GetWTOWByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取委外加工申请单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WTOWData:	单据实体。</returns>
		WTOWData GetWTOWByDept(string DeptCode);
		/// <summary>
		/// 获取有效的委外加工申请单列表。
		/// </summary>
		/// <returns>WTOWData:	单据实体。</returns>
		WTOWData GetWTOWValidData();
	}
}
