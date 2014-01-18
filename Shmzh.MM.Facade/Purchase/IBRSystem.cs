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
	/// IBRSystem 的摘要说明。
	/// </summary>
	public interface IBRSystem
	{
		/// <summary>
		/// 收料单的增加。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddBR(BillOfReceiveData oEntry);
		/// <summary>
		/// 收料单的修改。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateBR(BillOfReceiveData oEntry);
		/// <summary>
		/// 收料单收料。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ReceiveBR(BillOfReceiveData oEntry);
		/// <summary>
		/// 收料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteBR(int EntryNo);
		/// <summary>
		/// 收料单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentBR(int EntryNo, string UserLoginId);
		/// <summary>
		/// 收料单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelBR(int EntryNo);
		/// <summary>
		/// 收料单的部门审批。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditBR(BillOfReceiveData oEntry);
		/// <summary>
		/// 收料单的财务审批。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditBR(BillOfReceiveData oEntry);
		/// <summary>
		/// 收料单的厂长审批。
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditBR(BillOfReceiveData oEntry);
		/// <summary>
		/// 获取所有收料单。
		/// </summary>
		/// <returns>BillOfReceiveData:	单据实体。</returns>
		BillOfReceiveData GetBRAll();
		/// <summary>
		/// 根据状态获取收料单清单。
		/// </summary>
		/// <param name="EntryState">string:	收料单状态。</param>
		/// <returns>BillOfReceiveData:	收料单数据实体。</returns>
		BillOfReceiveData GetBRByState(string EntryState);
		/// <summary>
		/// 根据流水号获取收料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>BillOfReceiveData:	单据实体。</returns>
		BillOfReceiveData GetBRByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取收料单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>BillOfReceiveData:	单据实体。</returns>
		BillOfReceiveData GetBRByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取收料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>BillOfReceiveData:	单据实体。</returns>
		BillOfReceiveData GetBRByDept(string DeptCode);
	}
}
