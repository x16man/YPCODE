
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// 生产退料单的业务规则层。
	/// </summary>
	public class WRTS :Messages,IInItem
	{
		#region 构造函数
		public WRTS()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 生产退料单的增加。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			// TODO:  添加 WRTS.Insert 实现
			bool ret = false;
			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oWRTSs.InsertEntry(Entry);
			this.Message = oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单的增加并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  添加 WRTS.Insert 实现
			bool ret = false;
			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oWRTSs.InsertAndPresentEntry(Entry);
			this.Message = oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单的修改。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			// TODO:  添加 WRTS.Update 实现
			bool ret = false;

			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oWRTSs.UpdateEntry(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单的修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 WRTS.Update 实现
			bool ret = false;

			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.New) )
				return ret;
			ret = oWRTSs.UpdateAndPresentEntry(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  添加 WRTS.Delete 实现
			bool ret = true;
			WRTSs oWRTSs = new WRTSs();
			WRTSData oWRTSData;
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNo(EntryNo);
			if (oWRTSData != null && oWRTSData.Count > 0)
			{
				//如果单据是作废状态才允许删除．
				if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oWRTSs.DeleteEntry(EntryNo) == false)
					{
						this.Message=oWRTSs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WRTSData.XDelete;
					ret = false;
				}
			}
			else
				ret = false;
			
			return ret;
		}
		/// <summary>
		/// 生产退料单的状态改变。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态 。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 WRTS.UpdateEntryState 实现
			bool ret = true;

			WRTSs oWRTSs = new WRTSs();

			ret = oWRTSs.UpdateEntryState(EntryNo,newState);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单的一级审批。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  添加 WRTS.FirstAduit 实现
			bool ret = false;

			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.FirstAudit) )
				return ret;
			ret = oWRTSs.FirstAudit(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单的二级审批。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  添加 WRTS.SecondAduit 实现
			bool ret = false;

			WRTSs oWRTSs = new WRTSs();
			if( !IsValied(Entry,OP.SecondAudit) )
				return ret;
			ret = oWRTSs.SecondAudit(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单的三级审批。
		/// </summary>
		/// <param name="Entry">object:	生产退料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  添加 WRTS.ThirdAduit 实现
			bool ret = false;
			if( !IsValied(Entry,OP.ThirdAudit) )
				return ret;
			WRTSs oWRTSs = new WRTSs();

			ret = oWRTSs.ThirdAudit(Entry);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	生产退料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WRTSs oWRTSs = new WRTSs();

			ret = oWRTSs.Present(EntryNo, newState, UserLoginId);
			this.Message=oWRTSs.Message;
			return ret;
		}
		/// <summary>
		/// 生产退料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	生产退料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;
			WRTSs oWRTSs = new WRTSs();
			WRTSData oWRTSData;
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNo(EntryNo);
			if(oWRTSData!=null && oWRTSData.Count>0)
			{
				if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
				{
					if (oWRTSs.Cancel(EntryNo, newState) == false)
					{
						this.Message=oWRTSs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WRTSData.XCancel;
					ret = false;
				}

			}
			else
				ret = false;
			return ret;
		}
		public bool Cancel(int EntryNo, string newState,string UserLoginId)
		{

			bool ret = true;
			WRTSs oWRTSs = new WRTSs();
			WRTSData oWRTSData;
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNo(EntryNo);
			if(oWRTSData!=null && oWRTSData.Count>0)
			{
				if (oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
					oWRTSData.Tables[WRTSData.WRTS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
				{
					if (oWRTSs.Cancel(EntryNo, newState,UserLoginId) == false)
					{
						this.Message=oWRTSs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WRTSData.XCancel;
					ret = false;
				}

			}
			else
				ret = false;
			return ret;
		}
		/// <summary>
		/// 根据生产退料单的流水号来获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  添加 WRTS.GetEntryByEntryNo 实现
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNo(EntryNo);
			return oWRTSData;
		}
		/// <summary>
		/// 收料模式下，根据流水号获取生产退料单。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryNoInMode(EntryNo);
			return oWRTSData;

		}
		/// <summary>
		/// 根据生产退料单的编号来获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  添加 WRTS.GetEntryByEntryCode 实现
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryByEntryCode(EntryCode);
			return oWRTSData;
		}
		/// <summary>
		/// 获取所有生产退料单。
		/// </summary>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryAll()
		{
			// TODO:  添加 WRTS.GetEntryAll 实现
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryAll();
			return oWRTSData;
		}

        /// <summary>
        /// 获取所有生产退料单。
        /// </summary>
        /// <returns>object:	单据实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            // TODO:  添加 WRTS.GetEntryAll 实现
            WRTSData oWRTSData;
            WRTSs oWRTSs = new WRTSs();
            oWRTSData = (WRTSData)oWRTSs.GetEntryByPerson(EmpCode);
            return oWRTSData;
        }
		/// <summary>
		/// 获取指定制单部门的生产退料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  添加 WRTS.GetEntryByDept 实现
			WRTSData oWRTSData ;
			WRTSs oWRTSs = new WRTSs();
			oWRTSData = (WRTSData)oWRTSs.GetEntryByDept(DeptCode);
			return oWRTSData;
		}
		/// <summary>
		/// 生产退料单收料
		/// </summary>
		/// <param name="Entry"></param>
		/// <returns></returns>
		public bool Receive(object Entry)
		{
			bool ret = true;

			WRTSs oWRTSs = new WRTSs();

			if (oWRTSs.Receive(Entry) == false)
			{
				this.Message = oWRTSs.Message;
				ret = false;
			}
			return ret;
		}
		#endregion

		#region 退料单特殊成员
		public bool Check(object Entry)
		{
			bool ret = true;
			WRTSs oWRTSs = new WRTSs();
			ret = oWRTSs.Check(Entry);
			this.Message = oWRTSs.Message;
			return ret;
		}
		#endregion

		#region WRTSData 校验函数
		public bool IsValied(object Entry,string strTarget)
		{
			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			switch (strTarget)
			{
				case OP.New:
					if(oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0][WRTSData.STOCODE_FIELD].ToString() =="-1" )
					{
						ret = false;
						this.Message = WRTSData.NO_STO;
					}
					break;

				case OP.FirstAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT1_FIELD].ToString().Length == 0)
					{
						ret = false;
						this.Message = WRTSData.NO_AUDIT_VALUE;
					}
					break;
				case OP.SecondAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT2_FIELD].ToString().Length == 0)
					{
						ret = false;
						this.Message = WRTSData.NO_AUDIT_VALUE;
					}
					break;
				case OP.ThirdAudit:
					if(oEntry.Tables[0].Rows[0][InItemData.AUDIT3_FIELD].ToString().Length == 0)
					{
						ret = false;
						this.Message = WRTSData.NO_AUDIT_VALUE;
					}
					break;
			}
			return ret;


			}
		#endregion
	}
}
