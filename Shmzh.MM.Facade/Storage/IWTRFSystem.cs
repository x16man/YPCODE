namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IWTRFSystem 的摘要说明。
	/// </summary>
	public interface IWTRFSystem
	{
		/// <summary>
		/// 转库单的增加。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddWTRF(WTRFData oEntry);
		/// <summary>
		/// 转库单的修改。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateWTRF(WTRFData oEntry);
		/// <summary>
		/// 转库单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteWTRF(int EntryNo);
		/// <summary>
		/// 转库单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentWTRF(int EntryNo, string UserLoginId);
		/// <summary>
		/// 转库单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelWTRF(int EntryNo);
		/// <summary>
		/// 转库单的部门审批。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditWTRF(WTRFData oEntry);
		/// <summary>
		/// 转库单的财务审批。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditWTRF(WTRFData oEntry);
		/// <summary>
		/// 转库单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WTRFData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditWTRF(WTRFData oEntry);
		/// <summary>
		/// 获取所有转库单。
		/// </summary>
		/// <returns>WTRFData:	单据实体。</returns>
		WTRFData GetWTRFAll();
		/// <summary>
		/// 根据流水号获取转库单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WTRFData:	单据实体。</returns>
		WTRFData GetWTRFByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取转库单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>WTRFData:	单据实体。</returns>
		WTRFData GetWTRFByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取转库单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WTRFData:	单据实体。</returns>
		WTRFData GetWTRFByDept(string DeptCode);
		/// <summary>
		/// 获取所有转库单的数据源。
		/// </summary>
		/// <returns></returns>
		WTRFData GetWTRFSAll();
		/// <summary>
		/// 获取指定转库单的数据源。
		/// </summary>
		/// <param name="PKIDs"></param>
		/// <returns></returns>
		WTRFData GetWTRFSByPKIDs(string PKIDs);

		/// <summary>
		/// 根据流水号获取转库模式下的转库单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WTRFData:	单据实体。</returns>
		WTRFData GetWTRFByEntryNoOutMode(int EntryNo);		
		/// <summary>
		/// 转库单确认
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <returns></returns>
		bool AffirmWTRF(int EntryNo, string UserLoginId);
		}
	}
