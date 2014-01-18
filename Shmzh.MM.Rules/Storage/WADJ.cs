
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// WADJ 的摘要说明。
	/// </summary>
	public class WADJ:Messages,IInItem
	{
		#region 构造函数
		public WADJ()
		{
			
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 转库单录入。
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			bool ret=true;
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			
			//检验通过进行保存操作。
			WADJs oWADJs = new WADJs();

			if (oWADJs.InsertEntry(Entry) == false)
			{
				this.Message = oWADJs.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 新建并马上提交转库单.
		/// </summary>
		/// <param name="Entry">object:	转库单。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  添加 WADJ.Insert 实现
			bool ret=true;
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			
			//检验通过进行保存操作。
			WADJs oWADJs=new WADJs();

			if (oWADJs.InsertAndPresentEntry(Entry)==false)
			{
				this.Message=oWADJs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 转库单修改。
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			// TODO:  添加 WADJ.Update 实现
			bool ret=true;
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			//修改的前提是新建，作废，审批不通过．
			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			{
				this.Message = WADJData.XUpdate;
				return false;
			}
			
			//检验通过进行保存操作。
			WADJs oWADJs=new WADJs();

			if (oWADJs.UpdateEntry(Entry)==false)
			{
				this.Message=oWADJs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 修改并且提交转库单.
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 WADJ.Update 实现
			bool ret=true;
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			//			//修改的前提是新建，作废，审批不通过．
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
			//				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
			//				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
			//				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
			//				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			//			{
//			this.Message = WADJData.XUpdate;
//			return false;
			//			}
			//			//检查用途。
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][WADJData.REQREASONCODE_FIELD].ToString() =="-1")//未指定用途。
			//			{
			//				this.Message = WADJData.NoPurpose;
			//				ret = false;
			//				return ret;
			//			}
			//			//检查申请部门。
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][WADJData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			//			{
			//				this.Message = WADJData.NoReqDept;
			//				ret = false;
			//				return ret;
			//			}
			//			//检查申请人。
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][WADJData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			//			{
			//				this.Message = WADJData.NoProposer;
			//				ret = false;
			//				return ret;
			//			}
			//检验通过进行保存操作。
			WADJs oWADJs=new WADJs();

			if (oWADJs.UpdateAndPresentEntry(Entry)==false)
			{
				this.Message=oWADJs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 转库单删除。
		/// </summary>
		/// <param name="EntryNo">int:	 转库单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  添加 WADJ.Delete 实现
			bool ret=true;
			WADJData oWADJData;

			WADJs oWADJs=new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNo(EntryNo);
			if (oWADJData != null && oWADJData.Count > 0)
			{
				//如果单据是作废状态才允许删除．
				if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oWADJs.DeleteEntry(EntryNo)==false)
					{
						this.Message=oWADJs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WADJData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}
		/// <summary>
		/// 修改单据状态.
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号.</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 WADJ.UpdateEntryState 实现
			bool ret=true;

			WADJs oWADJs=new WADJs();

			if (oWADJs.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oWADJs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  添加 WADJ.FirstAduit 实现
			bool ret=true;

			WADJs oWADJs=new WADJs();
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;

			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			//			{
			if (oWADJs.FirstAudit(Entry) == false)
			{
				this.Message = oWADJs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WADJData.XFirstAudit;
			//				ret = false;
			//			}
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  添加 WADJ.SecondAduit 实现
			bool ret=true;

			WADJs oWADJs=new WADJs();
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			//转库单二级审批的前提条件是一级审批通过．
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			//			{
			if (oWADJs.SecondAudit(Entry) == false)
			{
				this.Message=oWADJs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WADJData.XSecondAudit;
			//				ret =false;
			//			}
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	转库单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  添加 WADJ.ThirdAduit 实现
			bool ret = true;

			WADJs oWADJs = new WADJs();
			WADJData oWADJData;
			oWADJData = (WADJData)Entry;
			//转库单二级审批的前提条件是一级审批通过．
			//			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			//			{
			if (oWADJs.ThirdAudit(Entry) == false)
			{
				this.Message=oWADJs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WADJData.XThirdAudit;
			//				ret = false;
			//			}
			return ret;
		}
		/// <summary>
		/// 转库单提交。
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			WADJData oWADJData;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过的才允许提交．
			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWADJs.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oWADJs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = WADJData.XPresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 转库单作废。
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			WADJs oWADJs = new WADJs();
			WADJData oWADJData;
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过允许作废．
			if (oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWADJData.Tables[WADJData.WADJ_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWADJs.Cancel(EntryNo, newState) == false)
				{
					this.Message = oWADJs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WADJData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据转库单流水号获取转库单完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	转库单流水号。</param>
		/// <returns>object:	转库单数据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNo(EntryNo);
			return oWADJData;
		}
		/// <summary>
		/// 根据转库单编号获取转库单完整信息。
		/// </summary>
		/// <param name="EntryCode">string:	转库单编号。</param>
		/// <returns>object:	转库单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryCode(EntryCode);
			return oWADJData;
		}
		/// <summary>
		/// 获取所有转库单。
		/// </summary>
		/// <returns>object:	转库单数据实体。</returns>
		public object GetEntryAll()
		{
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryAll();
			return oWADJData;
		}
		/// <summary>
		/// 获取指定申请部门的转库单。
		/// </summary>
		/// <param name="DeptCode">string:	申请部门编号。</param>
		/// <returns>object:	转库单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByDept(DeptCode);
			return oWADJData;
		}

		#endregion

		#region 转库单专有方法
		public WADJData GetWADJSAll()
		{
			WADJData oWADJData;
			WADJs oWADJs = new WADJs();
			oWADJData = oWADJs.GetWADJAll();
			return oWADJData;
		}
		public WADJData GetWADJSByPKIDs(string PKIDs)
		{
			WADJData oWADJData;
			WADJs oWADJs = new WADJs();
			oWADJData = oWADJs.GetWADJByPKIDs(PKIDs);
			return oWADJData;
		}
		
					   
					   
		#endregion

		#region 转库专有方法
		/// <summary>
		/// 转库模式下获取转库单的内容。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			// TODO:  添加 WADJ.GetEntryByEntryNo 实现
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNoOutMode(EntryNo);
			return oWADJData;
		}
		/// <summary>
		/// 转库模式下获取转库单的内容。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			// TODO:  添加 WADJ.GetEntryByEntryNo 实现
			WADJData oWADJData ;
			WADJs oWADJs = new WADJs();
			oWADJData = (WADJData)oWADJs.GetEntryByEntryNoInMode(EntryNo);
			return oWADJData;
		}
		/// <summary>
		/// 转库收料单收料操作。
		/// </summary>
		/// <param name="Entry">object:	收料单对象。</param>
		/// <returns>bool:	收料成功返回true，失败返回false。</returns>
		
		#endregion
	}
}

