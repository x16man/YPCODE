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
	/// IPBRBSystem 的摘要说明。
	/// </summary>
	public interface IPBRBSystem
	{
		/// <summary>
		/// 批量进货单的增加。
		/// </summary>
		/// <param name="oEntry">PBRBData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddPBRB(PBRBData oEntry);
		/// <summary>
		/// 批量进货单的修改。
		/// </summary>
		/// <param name="oEntry">PBRBData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdatePBRB(PBRBData oEntry);
		/// <summary>
		/// 批量进货单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeletePBRB(int EntryNo);
		/// <summary>
		/// 批量进货单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentPBRB(int EntryNo, string UserLoginId);
		/// <summary>
		/// 批量进货单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelPBRB(int EntryNo, string UserLoginId);
		/// <summary>
		/// 批量进货单的部门审批。
		/// </summary>
		/// <param name="oEntry">PBRBData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditPBRB(PBRBData oEntry);
		/// <summary>
		/// 批量进货单的财务审批。
		/// </summary>
		/// <param name="oEntry">PBRBData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditPBRB(PBRBData oEntry);
		/// <summary>
		/// 批量进货单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PBRBData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditPBRB(PBRBData oEntry);
		/// <summary>
		/// 获取所有批量进货单。
		/// </summary>
		/// <returns>PBRBData:	单据实体。</returns>
		PBRBData GetPBRBAll(string UserLoginId);
		/// <summary>
		/// 根据流水号获取批量进货单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PBRBData:	单据实体。</returns>
		PBRBData GetPBRBByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取批量进货单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PBRBData:	单据实体。</returns>
		PBRBData GetPBRBByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取批量进货单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PBRBData:	单据实体。</returns>
		PBRBData GetPBRBByDept(string DeptCode);
	}
}
