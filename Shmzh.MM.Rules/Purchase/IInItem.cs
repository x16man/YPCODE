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

namespace Shmzh.MM.BusinessRules
{
	using System;
	/// <summary>
	/// IInItem 的摘要说明。
	/// </summary>
	public interface IInItem
	{
		/// <summary>
		/// 单据录入。
		/// </summary>
		/// <param name="Entry">object:	单据实体 。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool Insert(object Entry);
		/// <summary>
		/// 单据修改。
		/// </summary>
		/// <param name="Entry">object:	单据实体 。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool Update(object Entry);
		/// <summary>
		/// 单据删除。
		/// </summary>
		/// <param name="Entry">int:	单据流水号 。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool Delete(int EntryNo);
		/// <summary>
		/// 单据修改状态。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateEntryState(int EntryNo,string newState);
		/// <summary>
		/// 单据一级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAudit(object Entry);
		/// <summary>
		/// 单据二级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAudit(object Entry);
		/// <summary>
		/// 单据三级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAudit(object Entry);
		/// <summary>
		/// 单据提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool Present(int EntryNo, string newState, string UserLoginId);
		/// <summary>
		/// 单据作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool Cancel(int EntryNo, string newState);
		/// <summary>
		/// 根据采购申请单流水号，获取采购申请单完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <returns>object:	采购申请单数据实体。</returns>
		object GetEntryByEntryNo(int EntryNo);
		/// <summary>
		/// 根据采购申请单编号，获取采购申请单完整信息。
		/// </summary>
		/// <param name="EntryCode">string:	采购申请单编号。</param>
		/// <returns>object:	采购申请单数据实体。</returns>
		object GetEntryByEntryCode(string EntryCode);
		/// <summary>
		/// 获取所有采购申请单的信息，仅包括主表的部分信息。
		/// </summary>
		/// <returns>object:	采购申请单数据实体。</returns>
		object GetEntryAll();
		/// <summary>
		/// 获取指定申请部门的采购申请单的信息，仅包括主表的部分信息。
		/// </summary>
		/// <param name="DeptCode">string:	部门编号。</param>
		/// <returns>object:	采购申请单数据实体。</returns>
		object GetEntryByDept(string DeptCode);
	}
}
