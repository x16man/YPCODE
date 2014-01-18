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
	/// IPRTVSystem 的摘要说明。
	/// </summary>
	public interface IPRTVSystem
	{
		/// <summary>
		/// 采购退料单的增加。
		/// </summary>
		/// <param name="oEntry">PRTVData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddPRTV(PRTVData oEntry);
		/// <summary>
		/// 采购退料单的修改。
		/// </summary>
		/// <param name="oEntry">PRTVData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdatePRTV(PRTVData oEntry,string strEmpCode);
		/// <summary>
		/// 采购退料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeletePRTV(int EntryNo,string strEmpCode);
		/// <summary>
		/// 采购退料单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:	用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentPRTV(int EntryNo, string UserLoginId,string strEmpCode);
		/// <summary>
		/// 采购退料单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelPRTV(int EntryNo,string strAuthorLoginId,string strEmpCode);
		/// <summary>
		/// 采购退料单的部门审批。
		/// </summary>
		/// <param name="oEntry">PRTVData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditPRTV(PRTVData oEntry);
		/// <summary>
		/// 采购退料单的财务审批。
		/// </summary>
		/// <param name="oEntry">PRTVData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditPRTV(PRTVData oEntry);
		/// <summary>
		/// 采购退料单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PRTVData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditPRTV(PRTVData oEntry);
		/// <summary>
		/// 获取所有采购退料单。
		/// </summary>
		/// <returns>PRTVData:	单据实体。</returns>
		PRTVData GetPRTVAll();
		/// <summary>
		/// 根据流水号获取采购退料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PRTVData:	单据实体。</returns>
		PRTVData GetPRTVByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取采购退料单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PRTVData:	单据实体。</returns>
		PRTVData GetPRTVByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取采购退料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PRTVData:	单据实体。</returns>
		PRTVData GetPRTVByDept(string DeptCode);
	}
}
