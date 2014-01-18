namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IWSCRSystem 的摘要说明。
	/// </summary>
	public interface IWSCRSystem
	{
		/// <summary>
		/// 报废单的增加。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddWSCR(WSCRData oEntry);
		/// <summary>
		/// 报废单的修改。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateWSCR(WSCRData oEntry);
		/// <summary>
		/// 报废单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteWSCR(int EntryNo);
		/// <summary>
		/// 报废单的提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool PresentWSCR(int EntryNo, string UserLoginId);
		/// <summary>
		/// 报废单的作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool CancelWSCR(int EntryNo);
		/// <summary>
		/// 报废单的部门审批。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAuditWSCR(WSCRData oEntry);
		/// <summary>
		/// 报废单的财务审批。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAuditWSCR(WSCRData oEntry);
		/// <summary>
		/// 报废单的厂长审批。
		/// </summary>
		/// <param name="oEntry">WSCRData:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAuditWSCR(WSCRData oEntry);
		/// <summary>
		/// 获取所有报废单。
		/// </summary>
		/// <returns>WSCRData:	单据实体。</returns>
		WSCRData GetWSCRAll();
		/// <summary>
		/// 根据流水号获取报废单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>WSCRData:	单据实体。</returns>
		WSCRData GetWSCRByEntryNo(int EntryNo);
		/// <summary>
		/// 根据编号获取报废单。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>WSCRData:	单据实体。</returns>
		WSCRData GetWSCRByEntryCode(string EntryCode);
		/// <summary>
		/// 根据制单部门编号获取报废单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>WSCRData:	单据实体。</returns>
		WSCRData GetWSCRByDept(string DeptCode);
		/// <summary>
		/// 获取所有报废单的数据源。
		/// </summary>
		/// <returns></returns>
		WSCRData GetWSCRSAll();
		/// <summary>
		/// 获取指定报废单的数据源。
		/// </summary>
		/// <param name="PKIDs"></param>
		/// <returns></returns>
		WSCRData GetWSCRSByPKIDs(string PKIDs);
		/// <summary>
		/// 报废单确认
		/// </summary>
		/// <param name="EntryNo"></param>
		/// <returns></returns>
		bool AffirmWSCR(int EntryNo, string UserLoginId);
	}
}
