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
	/// IPPSystem 的摘要说明。
	/// </summary>
	public interface IPPSystem
	{
		/// <summary>
		/// 采购计划的增加。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddPP(PurchasePlanData oEntry);
		/// <summary>
		/// 采购订单的修改。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdatePP(PurchasePlanData oEntry);
		/// <summary>
		/// 采购订单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeletePP(int EntryNo);
		/// <summary>
		/// 采购订单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentPP(int EntryNo, string UserLoginId);
		/// <summary>
		/// 采购订单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelPP(int EntryNo);
		/// <summary>
		/// 采购订单的部门审批。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditPP(PurchasePlanData oEntry);
		/// <summary>
		/// 采购订单的财务审批。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditPP(PurchasePlanData oEntry);
		/// <summary>
		/// 采购订单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditPP(PurchasePlanData oEntry);
		/// <summary>
		/// 获取所有采购订单。
		/// </summary>
		/// <returns>PurchasePlanData:	单据实体。</returns>
		PurchasePlanData GetPPAll();
		/// <summary>
		/// 根据流水号获取采购订单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PurchaseOrderData:	单据实体。</returns>
		PurchasePlanData GetPPByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取采购订单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PurchasePlanData:	单据实体。</returns>
		PurchasePlanData GetPPByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取采购订单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PurchasePlanData:	单据实体。</returns>
		PurchasePlanData GetPPByDept(string DeptCode);
		/// <summary>
		/// 获取所有采购订单的数据源。
		/// </summary>
		/// <returns></returns>
		PPSData GetPPSAll(string UserLoginId);
	}
}
