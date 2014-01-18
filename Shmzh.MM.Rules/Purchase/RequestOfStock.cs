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

namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;
    /// <summary>
	/// RequestOfStock 的摘要说明。
	/// </summary>
	public class RequestOfStock:Messages,IInItem
	{

        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Grant();
        private IList<GrantInfo> grantinfo;

		#region 构造函数
		public RequestOfStock()
		{
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 采购申请单录入。
		/// </summary>
		/// <param name="Entry">object:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			bool ret=true;
			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)Entry;
			//检查用途。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="-1" ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="")//未指定用途。
			{
				this.Message = RequestOfStockData.NoPurpose;
				ret = false;
				return ret;
			}
			//检查申请部门。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			{
				this.Message = RequestOfStockData.NoReqDept;
				ret = false;
				return ret;
			}
			//检查申请人。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			{
				this.Message = RequestOfStockData.NoProposer;
				ret = false;
				return ret;
			}
			//检验通过进行保存操作。
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();

			if (oRequestOfStocks.InsertEntry(Entry) == false)
			{
				this.Message = oRequestOfStocks.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 新建并马上提交采购申请单.
		/// </summary>
		/// <param name="Entry">object:	采购申请单。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  添加 RequestOfStock.Insert 实现
			bool ret=true;
			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)Entry;
			//检查用途。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="-1" ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="")//未指定用途。
			{
				this.Message = RequestOfStockData.NoPurpose;
				ret = false;
				return ret;
			}
			//检查申请部门。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			{
				this.Message = RequestOfStockData.NoReqDept;
				ret = false;
				return ret;
			}
			//检查申请人。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			{
				this.Message = RequestOfStockData.NoProposer;
				ret = false;
				return ret;
			}
			//检验通过进行保存操作。
			RequestOfStocks oRequestOfStocks=new RequestOfStocks();

			if (oRequestOfStocks.InsertAndPresentEntry(Entry)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单修改。
		/// </summary>
		/// <param name="Entry">object:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			bool ret=true;
			int EntryNo;
			string UserLoginId;
		    var oROSData = (RequestOfStockData)Entry;
			EntryNo = Convert.ToInt32(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

//			oROSData = (RequestOfStockData)new RequestOfStocks().GetEntryByEntryNo(EntryNo);
//			//修改的前提是新建，作废，审批不通过．
//			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = RequestOfStockData.XUpdate;
//				return false;
//			}
			//判断操作的前提条件.
			if (!this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				this.Message = "您无权进行此操作!";
				return false;
			}
			oROSData = (RequestOfStockData)Entry;//重新赋值。
			//检查用途。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="-1" ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="")//未指定用途。
			{
				this.Message = RequestOfStockData.NoPurpose;
				ret = false;
				return ret;
			}
			//检查申请部门。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			{
				this.Message = RequestOfStockData.NoReqDept;
				ret = false;
				return ret;
			}
			//检查申请人。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			{
				this.Message = RequestOfStockData.NoProposer;
				ret = false;
				return ret;
			}
			//检验通过进行保存操作。
			RequestOfStocks oRequestOfStocks=new RequestOfStocks();

			if (oRequestOfStocks.UpdateEntry(Entry)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 修改并且提交采购申请单.
		/// </summary>
		/// <param name="Entry">object:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 RequestOfStock.Update 实现
			bool ret=true;
			int EntryNo;
			string UserLoginId;

			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)Entry;
			EntryNo = Convert.ToInt32(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			
//			RequestOfStocks oROSs = new RequestOfStocks();
//			oROSData = (RequestOfStockData)oROSs.GetEntryByEntryNo(int.Parse(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
//			//修改的前提是新建，作废，审批不通过．
//			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
//			{
//				this.Message = RequestOfStockData.XUpdate;
//				return false;
//			}
			if (!this.CheckPreCondition(EntryNo,OP.Edit, UserLoginId))
			{
				this.Message = "您无权进行此操作!";
				return false;
			}

			oROSData = (RequestOfStockData)Entry;  //重新赋值。
			//检查用途。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="-1" ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQREASONCODE_FIELD].ToString() =="")//未指定用途。
			{
				this.Message = RequestOfStockData.NoPurpose;
				ret = false;
				return ret;
			}
			//检查申请部门。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.REQDEPT_FIELD].ToString() =="-1")//未指定申请部门。
			{
				this.Message = RequestOfStockData.NoReqDept;
				ret = false;
				return ret;
			}
			//检查申请人。
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][RequestOfStockData.PROPOSER_FIELD].ToString().Trim() =="")//未指定申请人。
			{
				this.Message = RequestOfStockData.NoProposer;
				ret = false;
				return ret;
			}
			//检验通过进行保存操作。
			RequestOfStocks oRequestOfStocks=new RequestOfStocks();

			if (oRequestOfStocks.UpdateAndPresentEntry(Entry)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单删除。
		/// </summary>
		/// <param name="EntryNo">int:	 采购申请单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  添加 RequestOfStock.Delete 实现
			bool ret=true;
			RequestOfStockData oROSData;

			RequestOfStocks oRequestOfStocks=new RequestOfStocks();
			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
			if (oROSData != null && oROSData.Count > 0)
			{
				//如果单据是作废状态才允许删除．
				if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oRequestOfStocks.DeleteEntry(EntryNo)==false)
					{
						this.Message=oRequestOfStocks.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = RequestOfStockData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}
		/// <summary>
		/// 采购申请单删除。
		/// </summary>
		/// <param name="EntryNo">int:	 采购申请单流水号。</param>
		/// <param name="UserLoginId">string:	用户.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			// TODO:  添加 RequestOfStock.Delete 实现
			bool ret=true;
			RequestOfStocks oRequestOfStocks=new RequestOfStocks();
			if (!this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				this.Message = "您无权进行此操作!";
				return false;
			}
			if (oRequestOfStocks.DeleteEntry(EntryNo)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
								
			return ret;
		}
		/// <summary>
		/// 修改单据状态.
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号.</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 RequestOfStock.UpdateEntryState 实现
			bool ret=true;

			RequestOfStocks oRequestOfStocks=new RequestOfStocks();

			if (oRequestOfStocks.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oRequestOfStocks.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			var ret=true;

			var oRequestOfStocks=new RequestOfStocks();
            var entryNo = (int)((RequestOfStockData)Entry).Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD];
			var oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(entryNo);
			
            if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				if (oRequestOfStocks.FirstAudit(Entry) == false)
				{
					this.Message = oRequestOfStocks.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;

			var oRequestOfStocks=new RequestOfStocks();
		    var oROSData = (RequestOfStockData)Entry;
			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(int.Parse(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//采购申请单二级审批的前提条件是一级审批通过．
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.WZPass)
			{
				if (oRequestOfStocks.SecondAudit(Entry) == false)
				{
					this.Message=oRequestOfStocks.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XSecondAudit;
				ret =false;
			}
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	采购申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)Entry;
			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(int.Parse(oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//采购申请单二级审批的前提条件是一级审批通过．
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{
				if (oRequestOfStocks.ThirdAudit(Entry) == false)
				{
					this.Message=oRequestOfStocks.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XThirdAudit;
				ret = false;
			}
			return ret;
		}
        /// <summary>
        /// 物资审核。
        /// </summary>
        /// <param name="entryNo">紧急申购单号。</param>
        /// <param name="entryState">状态</param>
        /// <param name="audit4">审核结果</param>
        /// <param name="assessor4">审核人</param>
        /// <param name="auditSuggest4">审核意见</param>
        /// <param name="itemCodes">物料编号串。</param>
        /// <param name="loginId">审批人登录名</param>
        /// <returns>bool</returns>
        public bool WZAudit(int entryNo, string entryState,string audit4,string assessor4,string auditSuggest4,string itemCodes,string loginId)
        {
            bool ret = true;
            var oRequestOfStocks = new RequestOfStocks();
            var oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(entryNo);
            //采购申请单二级审批的前提条件是一级审批通过．
            if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
            {
                if (oRequestOfStocks.WZAudit(entryNo,entryState,audit4,assessor4,auditSuggest4,itemCodes,loginId) == false)
                {
                    this.Message = oRequestOfStocks.Message;
                    ret = false;
                }
            }
            else
            {
                this.Message = RequestOfStockData.XWZAudit;
                ret = false;
            }
            return ret;
        }
		/// <summary>
		/// 采购申请单提交。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
//			RequestOfStockData oROSData;
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
//			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过的才允许提交．
//			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId))
			{
				if (oRequestOfStocks.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oRequestOfStocks.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XPresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
			RequestOfStockData oROSData;
			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过允许作废．
			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oRequestOfStocks.Cancel(EntryNo, newState) == false)
				{
					this.Message = oRequestOfStocks.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginID">string:	操作人.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;

			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
//			RequestOfStockData oROSData;
//			oROSData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
//			//单据状态为新建或审批不通过允许作废．
//			if (oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oROSData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginID))
			{
				if (oRequestOfStocks.Cancel(EntryNo, newState, UserLoginID) == false)
				{
					this.Message = oRequestOfStocks.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = RequestOfStockData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据采购申请单流水号获取采购申请单完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <returns>object:	采购申请单数据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
		    var oRequestOfStocks = new RequestOfStocks();
			var oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);
			return oRequestOfStockData;
		}
		/// <summary>
		/// 根据采购申请单编号获取采购申请单完整信息。
		/// </summary>
		/// <param name="EntryCode">string:	采购申请单编号。</param>
		/// <returns>object:	采购申请单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
		    var oRequestOfStocks = new RequestOfStocks();
			var oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryCode(EntryCode);
			return oRequestOfStockData;
		}
		/// <summary>
		/// 获取所有采购申请单。
		/// </summary>
		/// <returns>object:	采购申请单数据实体。</returns>
		public object GetEntryAll()
		{
		    var oRequestOfStocks = new RequestOfStocks();
			var oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryAll();
			return oRequestOfStockData;
		}
		/// <summary>
		/// 获取指定申请部门的采购申请单。
		/// </summary>
		/// <param name="DeptCode">string:	申请部门编号。</param>
		/// <returns>object:	采购申请单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
		    var oRequestOfStocks = new RequestOfStocks();
			var oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryByDept(DeptCode);
			return oRequestOfStockData;
		}

		#endregion

		#region 专用方法
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	采购申请单流水号。</param>
		/// <param name="Operation">string:	操作代码。</param>
		/// <param name="UserLoginID">string:	当前操作人.</param>
		/// <returns>bool:	符合前提条件返回true,不符合返回false。</returns>
		public bool CheckPreCondition(int EntryNo, string Operation, string UserLoginID)
		{
			bool ret = false;
			string EntryState;
			string AuthorLoginID;
			
			if (Operation == OP.New)
			{
				return true;
			}
			RequestOfStockData oRequestOfStockData;
			RequestOfStocks oRequestOfStocks = new RequestOfStocks();
			oRequestOfStockData = (RequestOfStockData)oRequestOfStocks.GetEntryByEntryNo(EntryNo);   

			if (oRequestOfStockData.Count > 0)
			{
				EntryState = oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oRequestOfStockData.Tables[RequestOfStockData.PROS_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
				switch (Operation)
				{
						#region 编辑
					case OP.Edit://编辑。
						if (EntryState == DocStatus.New || 
							EntryState == DocStatus.Cancel || 
							EntryState == DocStatus.FstNoPass || 
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
                            EntryState == DocStatus.WZNoPass ||
							EntryState == DocStatus.OrdReject
							)
						{

                            grantinfo = grant.GetAllAvalibleByEmbracer(AuthorLoginID);
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
                                for (int i = 0; i < grantinfo.Count; i++)
								{
                                    if (grantinfo[i].Embracer == UserLoginID)
									{
										return true;
									}
								}
								return false;
							}
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region 提交
					case OP.Submit://提交。
                        if (EntryState == DocStatus.New ||
                            EntryState == DocStatus.Cancel ||
                            EntryState == DocStatus.FstNoPass ||
                            EntryState == DocStatus.SecNoPass ||
                            EntryState == DocStatus.TrdNoPass ||
                            EntryState == DocStatus.WZNoPass ||
                            EntryState == DocStatus.OrdReject
                            )
						{
							ret = AuthorLoginID == UserLoginID;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region 一级审批
					case OP.FirstAudit://一级审批。
						ret = EntryState == DocStatus.Present;
						break;
						#endregion
                    #region 物资审批
                    case OP.WZAudit://物资审批
                        ret = EntryState == DocStatus.FstPass;
				        break;
                    #endregion
                    #region 二级审批
                    case OP.SecondAudit://二级审批。
						ret = EntryState == DocStatus.WZPass;
						break;
						#endregion
						#region 三级审批
					case OP.ThirdAudit://三级审批。		
						ret = EntryState == DocStatus.SecPass;
						break;
						#endregion 
						#region 红字
					case OP.Red://红字。
						ret = EntryState == DocStatus.Drawed;
						break;
						#endregion
						#region 发料
					case OP.O://发料。
						ret = EntryState == DocStatus.TrdPass;
						break;
						#endregion
						#region 作废
					case OP.Cancel://作废。
						if (EntryState == DocStatus.New ||
							EntryState == DocStatus.FstNoPass ||
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
                            EntryState == DocStatus.WZNoPass ||
							EntryState == DocStatus.OrdReject)
						{
							ret = AuthorLoginID == UserLoginID;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region 删除
					case OP.Delete://删除。
						if (EntryState == DocStatus.Cancel)
						{
							ret = AuthorLoginID == UserLoginID;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
					default:
						ret = false;
						break;
				}
				return ret;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
