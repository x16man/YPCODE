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
	/// 生产退料单的业务外观层需要实现的接口。
	/// </summary>
	public interface IWRTSSystem
	{
		/// <summary>
		/// 生产退料单的增加。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddWRTS(WRTSData oEntry);
		/// <summary>
		/// 生产退料单的增加并且马上提交。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddAndPresentWRTS(WRTSData oEntry);
		/// <summary>
		/// 生产退料单的修改。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateWRTS(WRTSData oEntry);
		/// <summary>
		/// 生产退料单的修改并且马上提交。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateAndPresentWRTS(WRTSData oEntry);
		/// <summary>
		/// 生产退料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteWRTS(int EntryNo);
		/// <summary>
		/// 生产退料单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentWRTS(int EntryNo,string UserLoginId);
		/// <summary>
		/// 生产退料单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelWRTS(int EntryNo);
		/// <summary>
		/// 生产退料单的部门审批。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditWRTS(WRTSData oEntry);
		/// <summary>
		/// 生产退料单的财务审批。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditWRTS(WRTSData oEntry);
		/// <summary>
		/// 生产退料单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WRTSData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditWRTS(WRTSData oEntry);
		/// <summary>
		/// 获取所有生产退料单。
		/// </summary>
		/// <returns>WRTSData:	单据实体。</returns>
		WRTSData GetWRTSAll();
		/// <summary>
		/// 根据流水号获取生产退料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WRTSData:	单据实体。</returns>
		WRTSData GetWRTSByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取生产退料单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>WRTSData:	单据实体。</returns>
		WRTSData GetWRTSByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取生产退料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WRTSData:	单据实体。</returns>
		WRTSData GetWRTSByDept(string DeptCode);
        /// <summary>
        /// 验收
        /// </summary>
        /// <param name="oEntry">WRTSData:	单据实体。</param>
        /// <returns></returns>
		bool Check(WRTSData oEntry);
	}
}
