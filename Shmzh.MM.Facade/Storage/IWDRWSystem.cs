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
	/// 领料单的业务外观层需要实现的接口。
	/// </summary>
	public interface IWDRWSystem
	{
		/// <summary>
		/// 领料单的增加。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddWDRW(WDRWData oEntry);
		/// <summary>
		/// 领料单的增加并且提交。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddAndPresentWDRW(WDRWData oEntry);
		/// <summary>
		/// 领料单的修改。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateWDRW(WDRWData oEntry);
		/// <summary>
		/// 领料单的修改并且提交。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateAndPresentWDRW(WDRWData oEntry);
		/// <summary>
		/// 领料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteWDRW(int EntryNo);
		/// <summary>
		/// 领料单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentWDRW(int EntryNo,string UserLoginId);
		/// <summary>
		/// 领料单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelWDRW(int EntryNo);
		/// <summary>
		/// 领料单的部门审批。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditWDRW(WDRWData oEntry);
		/// <summary>
		/// 领料单的财务审批。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditWDRW(WDRWData oEntry);
		/// <summary>
		/// 领料单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WDRWData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditWDRW(WDRWData oEntry);
		/// <summary>
		/// 获取所有领料单。
		/// </summary>
		/// <returns>WDRWData:	单据实体。</returns>
		WDRWData GetWDRWAll();
		/// <summary>
		/// 根据流水号获取领料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		WDRWData GetWDRWByEntryNo(int EntryNo);
		/// <summary>
		/// 根据状态获取领料单清单。
		/// </summary>
		/// <param name="EntryState">string:	状态。</param>
		/// <returns>WDRWData:	领料单实体。</returns>
		WDRWData GetWDRWByState(string EntryState);
		/// <summary>
		/// 发料模式下的根据流水号获取领料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		WDRWData GetWDRWByEntryNoOutMode(int EntryNo);
		/// <summary>
		/// 根据编号获取领料单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		WDRWData GetWDRWByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取领料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WDRWData:	单据实体。</returns>
		WDRWData GetWDRWByDept(string DeptCode);
		/// <summary>
		/// 根据申请部门获取领料单源单据列表。
		/// </summary>
		/// <param name="DeptCode">string:	申请部门编号。</param>
		/// <returns>WDRWData:	领料单数据源实体。</returns>
		WDRWData GetWDRWSourceListByDeptCode(string DeptCode);
		/// <summary>
		/// 根据所选来源单据获取该单据的可用明细内容。
		/// </summary>
		/// <param name="PKIDs">string:	PKIDs</param>
		/// <returns>WDRWData:	领料单数据实体。</returns>
		WDRWData GetWDRWSourceDetailByPKIDs(string PKIDs);
		/// <summary>
		/// 根据信息反馈的ID串返回领料单实体。
		/// </summary>
		/// <param name="PKIDs">string:	信息反馈IDs。</param>
		/// <returns>WDRWData:	领料单数据实体。</returns>
		WDRWData GetWDRWByFeedbackIDs(string PKIDs);
	}
}
