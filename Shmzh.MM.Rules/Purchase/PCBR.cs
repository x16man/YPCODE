
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// 收料验收单的业务规则层。
	/// </summary>
	public class PCBR :Messages,IInItem
	{
		#region 构造函数
		public PCBR()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 收料验收单的增加。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			// TODO:  添加 PCBR.Insert 实现
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.InsertEntry(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单的增加并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.InsertAndPresentEntry(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单的修改。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			// TODO:  添加 PCBR.Update 实现
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.UpdateEntry(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单的修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 PCBR.Update 实现
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.UpdateAndPresentEntry(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  添加 PCBR.Delete 实现
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.DeleteEntry(EntryNo);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单的状态改变。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态 。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 PCBR.UpdateEntryState 实现
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.UpdateEntryState(EntryNo,newState);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单的一级审批。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  添加 PCBR.FirstAduit 实现
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.FirstAudit(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单的二级审批。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  添加 PCBR.SecondAduit 实现
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.SecondAudit(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单的三级审批。
		/// </summary>
		/// <param name="Entry">object:	收料验收单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  添加 PCBR.ThirdAduit 实现
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.ThirdAudit(Entry);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单提交。
		/// </summary>
		/// <param name="EntryNo">int:	收料验收单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.Present(EntryNo, newState, UserLoginId);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 收料验收单作废。
		/// </summary>
		/// <param name="EntryNo">int:	收料验收单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			PCBRs oPCBRs = new PCBRs();

			ret = oPCBRs.Cancel(EntryNo, newState);
			this.Message=oPCBRs.Message;
			return ret;
		}
		/// <summary>
		/// 根据收料验收单的流水号来获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  添加 PCBR.GetEntryByEntryNo 实现
			PCBRData oPCBRData ;
			PCBRs oPCBRs = new PCBRs();
			oPCBRData = (PCBRData)oPCBRs.GetEntryByEntryNo(EntryNo);
			return oPCBRData;
		}
		/// <summary>
		/// 根据收料验收单的编号来获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  添加 PCBR.GetEntryByEntryCode 实现
			PCBRData oPCBRData ;
			PCBRs oPCBRs = new PCBRs();
			oPCBRData = (PCBRData)oPCBRs.GetEntryByEntryCode(EntryCode);
			return oPCBRData;
		}
		/// <summary>
		/// 获取所有收料验收单。
		/// </summary>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryAll()
		{
			// TODO:  添加 PCBR.GetEntryAll 实现
			PCBRData oPCBRData ;
			PCBRs oPCBRs = new PCBRs();
			oPCBRData = (PCBRData)oPCBRs.GetEntryAll();
			return oPCBRData;
		}
		/// <summary>
		/// 获取指定制单部门的收料验收单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  添加 PCBR.GetEntryByDept 实现
			PCBRData oPCBRData ;
			PCBRs oPCBRs = new PCBRs();
			oPCBRData = (PCBRData)oPCBRs.GetEntryByDept(DeptCode);
			return oPCBRData;
		}

		#endregion

		#region 专有成员
		public CBRSData GetCBRSByPrvCode(string PrvCode)
		{
			CBRSData oCBRSData;
			PCBRs oPCBRs = new PCBRs();
			oCBRSData = oPCBRs.GetCBRSByPrvCode(PrvCode);
			return oCBRSData;
		}
		public CBRSData GetCBRSByPrvCodeAndDate(string PrvCode,DateTime StartDate,DateTime EndDate)
		{
			CBRSData oCBRSData;
			PCBRs oPCBRs = new PCBRs();
			oCBRSData = oPCBRs.GetCBRSByPrvCodeAndDate(PrvCode,StartDate,EndDate);
			return oCBRSData;
		}
		#endregion
	}
}