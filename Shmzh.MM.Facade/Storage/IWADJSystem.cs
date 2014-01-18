namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IWADJSystem 的摘要说明。
	/// </summary>
	public interface IWADJSystem
	{
		/// <summary>
		/// 转库单的增加。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddWADJ(WADJData oEntry);
		/// <summary>
		/// 转库单的修改。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateWADJ(WADJData oEntry);
		/// <summary>
		/// 转库单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteWADJ(int EntryNo);
		/// <summary>
		/// 转库单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentWADJ(int EntryNo, string UserLoginId);
		/// <summary>
		/// 转库单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelWADJ(int EntryNo);
		/// <summary>
		/// 转库单的部门审批。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditWADJ(WADJData oEntry);
		/// <summary>
		/// 转库单的财务审批。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditWADJ(WADJData oEntry);
		/// <summary>
		/// 转库单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WADJData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditWADJ(WADJData oEntry);
		/// <summary>
		/// 获取所有转库单。
		/// </summary>
		/// <returns>WADJData:	单据实体。</returns>
		WADJData GetWADJAll();
		/// <summary>
		/// 根据流水号获取转库单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WADJData:	单据实体。</returns>
		WADJData GetWADJByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取转库单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>WADJData:	单据实体。</returns>
		WADJData GetWADJByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取转库单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WADJData:	单据实体。</returns>
		WADJData GetWADJByDept(string DeptCode);
		/// <summary>
		/// 获取所有转库单的数据源。
		/// </summary>
		/// <returns></returns>
		WADJData GetWADJSAll();
		/// <summary>
		/// 获取指定转库单的数据源。
		/// </summary>
		/// <param name="PKIDs"></param>
		/// <returns></returns>
		WADJData GetWADJSByPKIDs(string PKIDs);

		/// <summary>
		/// 根据流水号获取转库模式下的转库单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WADJData:	单据实体。</returns>
		WADJData GetWADJByEntryNoOutMode(int EntryNo);		
		
	}
}
