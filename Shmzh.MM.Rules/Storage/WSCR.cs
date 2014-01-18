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
* penalties.  Any violations of this copyright will be WSCRecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// WSCR 的摘要说明。
	/// </summary>
	public class WSCR:Messages,IInItem
	{
		#region 构造函数
		public WSCR()
		{
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 报废单录入。
		/// </summary>
		/// <param name="Entry">object:	报废单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			bool ret=true;
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//检查用途。
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() =="-1")//未指定用途。
//			{
//				this.Message = WSCRData.NoPurpose;
//				ret = false;
//				return ret;
//			}
			//检查申请部门。
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			{
				this.Message = WSCRData.NoReqDept;
				ret = false;
				return ret;
			}
			//检查申请人。
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			{
				this.Message = WSCRData.NoProposer;
				ret = false;
				return ret;
			}
			//检验通过进行保存操作。
			WSCRs oWSCRs = new WSCRs();

			if (oWSCRs.InsertEntry(Entry) == false)
			{
				this.Message = oWSCRs.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 新建并马上提交报废单.
		/// </summary>
		/// <param name="Entry">object:	报废单。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  添加 WSCR.Insert 实现
			bool ret=true;
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//检查用途。
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() =="-1")//未指定用途。
//			{
//				this.Message = WSCRData.NoPurpose;
//				ret = false;
//				return ret;
//			}
			//检查申请部门。
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			{
				this.Message = WSCRData.NoReqDept;
				ret = false;
				return ret;
			}
			//检查申请人。
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			{
				this.Message = WSCRData.NoProposer;
				ret = false;
				return ret;
			}
			//检验通过进行保存操作。
			WSCRs oWSCRs=new WSCRs();

			if (oWSCRs.InsertAndPresentEntry(Entry)==false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 报废单修改。
		/// </summary>
		/// <param name="Entry">object:	报废单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			// TODO:  添加 WSCR.Update 实现
			bool ret=true;
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//修改的前提是新建，作废，审批不通过．
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = WSCRData.XUpdate;
//				return false;
//			}
			//检查用途。
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() =="-1")//未指定用途。
//			{
//				this.Message = WSCRData.NoPurpose;
//				ret = false;
//				return ret;
//			}
			//检查申请部门。
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			{
				this.Message = WSCRData.NoReqDept;
				ret = false;
				return ret;
			}
			//检查申请人。
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			{
				this.Message = WSCRData.NoProposer;
				ret = false;
				return ret;
			}
			//检验通过进行保存操作。
			WSCRs oWSCRs=new WSCRs();

			if (oWSCRs.UpdateEntry(Entry)==false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 修改并且提交报废单.
		/// </summary>
		/// <param name="Entry">object:	报废单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 WSCR.Update 实现
			bool ret=true;
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//修改的前提是新建，作废，审批不通过．
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = WSCRData.XUpdate;
//				return false;
//			}
			//检查用途。
//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQREASONCODE_FIELD].ToString() =="-1")//未指定用途。
//			{
//				this.Message = WSCRData.NoPurpose;
//				ret = false;
//				return ret;
//			}
			//检查申请部门。
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			{
				this.Message = WSCRData.NoReqDept;
				ret = false;
				return ret;
			}
			//检查申请人。
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][WSCRData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			{
				this.Message = WSCRData.NoProposer;
				ret = false;
				return ret;
			}
			//检验通过进行保存操作。
			WSCRs oWSCRs=new WSCRs();

			if (oWSCRs.UpdateAndPresentEntry(Entry)==false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 报废单删除。
		/// </summary>
		/// <param name="EntryNo">int:	 报废单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  添加 WSCR.Delete 实现
			bool ret=true;
			WSCRData oROSData;

			WSCRs oWSCRs=new WSCRs();
			oROSData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			if (oROSData != null && oROSData.Count > 0)
			{
				//如果单据是作废状态才允许删除．
				if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oWSCRs.DeleteEntry(EntryNo)==false)
					{
						this.Message=oWSCRs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = WSCRData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}
		/// <summary>
		/// 修改单据状态.
		/// </summary>
		/// <param name="EntryNo">int:	报废单流水号.</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 WSCR.UpdateEntryState 实现
			bool ret=true;

			WSCRs oWSCRs=new WSCRs();

			if (oWSCRs.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	报废单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  添加 WSCR.FirstAduit 实现
			bool ret=true;

			WSCRs oWSCRs=new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;

			//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			//			{
			if (oWSCRs.FirstAudit(Entry) == false)
			{
				this.Message = oWSCRs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WSCRData.XFirstAudit;
			//				ret = false;
			//			}
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	报废单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  添加 WSCR.SecondAduit 实现
			bool ret=true;

			WSCRs oWSCRs=new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//报废单二级审批的前提条件是一级审批通过．
			//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			//			{
			if (oWSCRs.SecondAudit(Entry) == false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WSCRData.XSecondAudit;
			//				ret =false;
			//			}
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	报废单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  添加 WSCR.ThirdAduit 实现
			bool ret = true;

			WSCRs oWSCRs = new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)Entry;
			//报废单二级审批的前提条件是一级审批通过．
			//			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			//			{
			if (oWSCRs.ThirdAudit(Entry) == false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			//			}
			//			else
			//			{
			//				this.Message = WSCRData.XThirdAudit;
			//				ret = false;
			//			}
			return ret;
		}
		/// <summary>
		/// 报废单提交。
		/// </summary>
		/// <param name="EntryNo">int:	报废单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			WSCRData oROSData;
			WSCRs oWSCRs = new WSCRs();
			oROSData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过的才允许提交．
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWSCRs.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oWSCRs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = WSCRData.XPresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 报废单作废。
		/// </summary>
		/// <param name="EntryNo">int:	报废单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WSCRs oWSCRs = new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过允许作废．
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWSCRs.Cancel(EntryNo, newState,UserLoginId) == false)
				{
					this.Message = oWSCRs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WSCRData.XCancel;
				ret = false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			WSCRs oWSCRs = new WSCRs();
			WSCRData oROSData;
			oROSData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过允许作废．
			if (oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oROSData.Tables[WSCRData.WSCR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oWSCRs.Cancel(EntryNo, newState) == false)
				{
					this.Message = oWSCRs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = WSCRData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据报废单流水号获取报废单完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	报废单流水号。</param>
		/// <returns>object:	报废单数据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryByEntryNo(EntryNo);
			return oWSCRData;
		}
		/// <summary>
		/// 根据报废单编号获取报废单完整信息。
		/// </summary>
		/// <param name="EntryCode">string:	报废单编号。</param>
		/// <returns>object:	报废单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryByEntryCode(EntryCode);
			return oWSCRData;
		}
		/// <summary>
		/// 获取所有报废单。
		/// </summary>
		/// <returns>object:	报废单数据实体。</returns>
		public object GetEntryAll()
		{
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryAll();
			return oWSCRData;
		}
		/// <summary>
		/// 获取指定申请部门的报废单。
		/// </summary>
		/// <param name="DeptCode">string:	申请部门编号。</param>
		/// <returns>object:	报废单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryByDept(DeptCode);
			return oWSCRData;
		}

		#endregion

		#region 报废单专有方法
		public WSCRData GetWSCRSAll()
		{
			WSCRData oWSCRData;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = oWSCRs.GetWSCRAll();
			return oWSCRData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			WSCRs oWSCRs = new WSCRs();

			if (oWSCRs.Affirm(EntryNo, newState, UserLoginId) == false)
			{
				this.Message=oWSCRs.Message;
				ret=false;
			}
			return ret;
		}
		public WSCRData GetWSCRSByPKIDs(string PKIDs)
		{
			WSCRData oWSCRData;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = oWSCRs.GetWSCRByPKIDs(PKIDs);
			return oWSCRData;
		}
		public WSCRData GetEntryByEntryNoDiscardMode(int EntryNo)
		{
			// TODO:  添加 WSCR.GetEntryByEntryNo 实现
			WSCRData oWSCRData ;
			WSCRs oWSCRs = new WSCRs();
			oWSCRData = (WSCRData)oWSCRs.GetEntryByEntryNoDiscardMode(EntryNo);
			return oWSCRData;
		}
					   
					   
		#endregion
	}
}
