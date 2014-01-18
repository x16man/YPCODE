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
	/// IPOSystem 的摘要说明。
	/// </summary>
	public interface IPOSystem
	{
		/// <summary>
		/// 采购订单的增加。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddPO(PurchaseOrderData oEntry);
		/// <summary>
		/// 采购订单的修改。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdatePO(PurchaseOrderData oEntry);
		/// <summary>
		/// 采购订单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeletePO(int EntryNo);
		/// <summary>
		/// 采购订单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:	用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentPO(int EntryNo, string UserLoginId);
		/// <summary>
		/// 采购订单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelPO(int EntryNo);
		/// <summary>
		/// 采购订单的部门审批。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditPO(PurchaseOrderData oEntry);
		/// <summary>
		/// 采购订单的财务审批。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditPO(PurchaseOrderData oEntry);
		/// <summary>
		/// 采购订单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditPO(PurchaseOrderData oEntry);
		/// <summary>
		/// 获取所有采购订单。
		/// </summary>
		/// <returns>PurchaseOrderData:	单据实体。</returns>
		PurchaseOrderData GetPOAll();
		/// <summary>
		/// 根据流水号获取采购订单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PurchaseOrderData:	单据实体。</returns>
		PurchaseOrderData GetPOByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取采购订单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PurchaseOrderData:	单据实体。</returns>
		PurchaseOrderData GetPOByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取采购订单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PurchaseOrderData:	单据实体。</returns>
		PurchaseOrderData GetPOByDept(string DeptCode);
		/// <summary>
		/// 获取所有采购订单的数据源。
		/// </summary>
		/// <returns>POSData:	订单来源实体。</returns>
		POSData GetPOSAll(string UserLoginId);
		/// <summary>
		/// 获取指定采购订单的数据源。
		/// </summary>
		/// <param name="PKIDs">string:	选中的订单来源PKID串。</param>
		/// <returns>POSData:	订单来源实体。</returns>
		POSData GetPOSByPKIDs(string PKIDs);
		/// <summary>
		/// 采购订单确认
		/// </summary>
		/// <param name="EntryNo">int:	订单流水号。</param>
		/// <param name="EntryState">string:	单据状态。</param>
		/// <param name="UserLoginId">string:	操作用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AffirmPO(int EntryNo,string EntryState, string UserLoginId);
	}
}
