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
	/// 物料需求单的业务外观层需要实现的接口。
	/// </summary>
	public interface IPMRPSystem
	{
		/// <summary>
		/// 物料需求单的增加。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddPMRP(PMRPData oEntry);
		/// <summary>
		/// 物料需求单的修改。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdatePMRP(PMRPData oEntry);
		/// <summary>
		/// 物料需求单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeletePMRP(int EntryNo);
		/// <summary>
		/// 物料需求单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentPMRP(int EntryNo, String UserLoginId);
		/// <summary>
		/// 物料需求单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelPMRP(int EntryNo);
		/// <summary>
		/// 物料需求单的部门审批。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditPMRP(PMRPData oEntry);
		/// <summary>
		/// 物料需求单的财务审批。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditPMRP(PMRPData oEntry);
		/// <summary>
		/// 物料需求单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PMRPData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditPMRP(PMRPData oEntry);
		/// <summary>
		/// 获取所有物料需求单。
		/// </summary>
		/// <returns>PMRPData:	单据实体。</returns>
		PMRPData GetPMRPAll();
		/// <summary>
		/// 根据流水号获取物料需求单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PMRPData:	单据实体。</returns>
		PMRPData GetPMRPByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取物料需求单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PMRPData:	单据实体。</returns>
		PMRPData GetPMRPByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取物料需求单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PMRPData:	单据实体。</returns>
		PMRPData GetPMRPByDept(string DeptCode);
	}
}
