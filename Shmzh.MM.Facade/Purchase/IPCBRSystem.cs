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
	/// 收料验收单的业务外观层需要实现的接口。
	/// </summary>
	public interface IPCBRSystem
	{
		/// <summary>
		/// 收料验收单的增加。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddPCBR(PCBRData oEntry);
		/// <summary>
		/// 收料验收单的修改。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdatePCBR(PCBRData oEntry);
		/// <summary>
		/// 收料验收单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeletePCBR(int EntryNo);
		/// <summary>
		/// 收料验收单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:用户名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentPCBR(int EntryNo, string UserLoginId);
		/// <summary>
		/// 收料验收单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelPCBR(int EntryNo);
		/// <summary>
		/// 收料验收单的部门审批。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditPCBR(PCBRData oEntry);
		/// <summary>
		/// 收料验收单的财务审批。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditPCBR(PCBRData oEntry);
		/// <summary>
		/// 收料验收单的厂长审批。
		/// </summary>
		/// <param name="oEntry">PCBRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditPCBR(PCBRData oEntry);
		/// <summary>
		/// 获取所有收料验收单。
		/// </summary>
		/// <returns>PCBRData:	单据实体。</returns>
		PCBRData GetPCBRAll();
		/// <summary>
		/// 根据流水号获取收料验收单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>PCBRData:	单据实体。</returns>
		PCBRData GetPCBRByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取收料验收单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>PCBRData:	单据实体。</returns>
		PCBRData GetPCBRByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取收料验收单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>PCBRData:	单据实体。</returns>
		PCBRData GetPCBRByDept(string DeptCode);
		/// <summary>
		/// 根据供应商获取已入库的收料单。
		/// </summary>
		/// <param name="PrvCode">string:	供应商编号。</param>
		/// <returns>CBRSData:	验收单来源实体。</returns>
		CBRSData GetCBRSByPrvCode(string PrvCode);
		/// <summary>
		/// 根据供应商在指定的日期范围内获取已入库的收料单
		/// </summary>
		/// <param name="PrvCode">string:	供应商编号。</param>
		/// <param name="StartDate">DateTime :	开始日期。</param>
		/// <param name="EndDate">DateTime:	结束日期。</param>
		/// <returns>CBRSData:	验收单来源实体。</returns>
		CBRSData GetCBRSByPrvCodeAndDate(string PrvCode, DateTime StartDate, DateTime EndDate);
	}
}
