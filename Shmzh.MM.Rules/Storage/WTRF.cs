
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// WTRF 的摘要说明。
	/// </summary>
	public class WTRF:Messages,IInItem
	{
		#region 构造函数
		public WTRF()
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
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			
			//检验通过进行保存操作。
			WTRFs oWTRFs = new WTRFs();

			if (oWTRFs.InsertEntry(Entry) == false)
			{
				this.Message = oWTRFs.Message;
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
			// TODO:  添加 WTRF.Insert 实现
			bool ret=true;
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			
			//检验通过进行保存操作。
			WTRFs oWTRFs=new WTRFs();

			if (oWTRFs.InsertAndPresentEntry(Entry)==false)
			{
				this.Message=oWTRFs.Message;
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
			// TODO:  添加 WTRF.Update 实现
			bool ret=true;
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			//修改的前提是新建，作废，审批不通过．
			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			{
				this.Message = WTRFData.XUpdate;
				return false;
			}
			
			//检验通过进行保存操作。
			WTRFs oWTRFs=new WTRFs();

			if (oWTRFs.UpdateEntry(Entry)==false)
			{
				this.Message=oWTRFs.Message;
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
			// TODO:  添加 WTRF.Update 实现
			bool ret=true;
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
//			//修改的前提是新建，作废，审批不通过．
//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = WTRFData.XUpdate;
//				return false;
//			}
//			//检查用途。
//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][WTRFData.REQREASONCODE_FIELD].ToString() =="-1")//未指定用途。
//			{
//				this.Message = WTRFData.NoPurpose;
//				ret = false;
//				return ret;
//			}
//			//检查申请部门。
//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][WTRFData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
//			{
//				this.Message = WTRFData.NoReqDept;
//				ret = false;
//				return ret;
//			}
//			//检查申请人。
//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][WTRFData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
//			{
//				this.Message = WTRFData.NoProposer;
//				ret = false;
//				return ret;
//			}
			//检验通过进行保存操作。
			WTRFs oWTRFs=new WTRFs();

			if (oWTRFs.UpdateAndPresentEntry(Entry)==false)
			{
				this.Message=oWTRFs.Message;
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
			// TODO:  添加 WTRF.Delete 实现
			bool ret=true;
			WTRFData oWTRFData;

			WTRFs oWTRFs=new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			if (oWTRFData != null && oWTRFData.Count > 0)
			{
				//如果单据是作废状态才允许删除．
				if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oWTRFs.DeleteEntry(EntryNo)==false)
					{
						this.Message=oWTRFs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WTRFData.XDelete;
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
			// TODO:  添加 WTRF.UpdateEntryState 实现
			bool ret=true;

			WTRFs oWTRFs=new WTRFs();

			if (oWTRFs.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oWTRFs.Message;
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
			// TODO:  添加 WTRF.FirstAduit 实现
			bool ret=true;

			WTRFs oWTRFs=new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;

			//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			//			{
			if (oWTRFs.FirstAudit(Entry) == false)
			{
				this.Message = oWTRFs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WTRFData.XFirstAudit;
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
			// TODO:  添加 WTRF.SecondAduit 实现
			bool ret=true;

			WTRFs oWTRFs=new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			//转库单二级审批的前提条件是一级审批通过．
			//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			//			{
			if (oWTRFs.SecondAudit(Entry) == false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WTRFData.XSecondAudit;
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
			// TODO:  添加 WTRF.ThirdAduit 实现
			bool ret = true;

			WTRFs oWTRFs = new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)Entry;
			//转库单二级审批的前提条件是一级审批通过．
			//			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			//			{
			if (oWTRFs.ThirdAudit(Entry) == false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WTRFData.XThirdAudit;
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
			WTRFData oWTRFData;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过的才允许提交．
			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWTRFs.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oWTRFs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = WTRFData.XPresent;
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

			WTRFs oWTRFs = new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过允许作废．
			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWTRFs.Cancel(EntryNo, newState) == false)
				{
					this.Message = oWTRFs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WTRFData.XCancel;
				ret = false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WTRFs oWTRFs = new WTRFs();
			WTRFData oWTRFData;
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过允许作废．
			if (oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oWTRFData.Tables[WTRFData.WTRF_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWTRFs.Cancel(EntryNo, newState,UserLoginId) == false)
				{
					this.Message = oWTRFs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WTRFData.XCancel;
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
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNo(EntryNo);
			return oWTRFData;
		}
		/// <summary>
		/// 根据转库单编号获取转库单完整信息。
		/// </summary>
		/// <param name="EntryCode">string:	转库单编号。</param>
		/// <returns>object:	转库单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryCode(EntryCode);
			return oWTRFData;
		}
		/// <summary>
		/// 获取所有转库单。
		/// </summary>
		/// <returns>object:	转库单数据实体。</returns>
		public object GetEntryAll()
		{
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryAll();
			return oWTRFData;
		}
		/// <summary>
		/// 获取指定申请部门的转库单。
		/// </summary>
		/// <param name="DeptCode">string:	申请部门编号。</param>
		/// <returns>object:	转库单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByDept(DeptCode);
			return oWTRFData;
		}

		#endregion

		#region 转库单专有方法
		public WTRFData GetWTRFSAll()
		{
			WTRFData oWTRFData;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = oWTRFs.GetWTRFAll();
			return oWTRFData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			WTRFs oWTRFs = new WTRFs();

			if (oWTRFs.Affirm(EntryNo, newState, UserLoginId) == false)
			{
				this.Message=oWTRFs.Message;
				ret=false;
			}
			return ret;
		}
		public WTRFData GetWTRFSByPKIDs(string PKIDs)
		{
			WTRFData oWTRFData;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = oWTRFs.GetWTRFByPKIDs(PKIDs);
			return oWTRFData;
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
			// TODO:  添加 WTRF.GetEntryByEntryNo 实现
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNoOutMode(EntryNo);
			return oWTRFData;
		}
		/// <summary>
		/// 转库模式下获取转库单的内容。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			// TODO:  添加 WTRF.GetEntryByEntryNo 实现
			WTRFData oWTRFData ;
			WTRFs oWTRFs = new WTRFs();
			oWTRFData = (WTRFData)oWTRFs.GetEntryByEntryNoInMode(EntryNo);
			return oWTRFData;
		}
		/// <summary>
		/// 转库收料单收料操作。
		/// </summary>
		/// <param name="Entry">object:	收料单对象。</param>
		/// <returns>bool:	收料成功返回true，失败返回false。</returns>
		
		#endregion
	}
	}

