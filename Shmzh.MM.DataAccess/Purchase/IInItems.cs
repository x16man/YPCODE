using System;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// 收料型单据应该实现的公共接口。
	/// </summary>
	public interface IInItems 
	{
		/// <summary>
		/// 收料型单据输入。
		/// </summary>
		/// <param name="Entry">object:	单据对象。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool InsertEntry(object Entry);
		/// <summary>
		/// 收料型单据更改。
		/// </summary>
		/// <param name="Entry">object:	单据对象。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateEntry(object Entry);
		/// <summary>
		/// 收料型单据删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeleteEntry(int EntryNo);
		/// <summary>
		/// 更改收料型单据状态。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdateEntryState(int EntryNo,string newState);
		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool FirstAudit(object Entry);
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool SecondAudit(object Entry);
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	单据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool ThirdAudit(object Entry);
		/// <summary>
		/// 单据提交。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool Present(int EntryNo, string newState,string UserLoginId);
		/// <summary>
		/// 单据作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool Cancel(int EntryNo, string newState);
		/// <summary>
		/// 根据单据流水号获得单据信息。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据对象实体。</returns>
		object GetEntryByEntryNo(int EntryNo);
		/// <summary>
		/// 根据单据编号获得单据信息。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	单据对象实体。</returns>
		object GetEntryByEntryCode(string EntryCode);
		/// <summary>
		/// 获取所有单据。
		/// </summary>
		/// <returns>object:	单据对象实体。</returns></returns>
		object GetEntryAll();
		/// <summary>
		/// 根据申请部门编号，获取所有采购申请单。
		/// </summary>
		/// <param name="DeptCode">string:	部门编号。</param>
		/// <returns>object:	单据对象实体。</returns>
		object GetEntryByDept(string DeptCode);

	}
}
