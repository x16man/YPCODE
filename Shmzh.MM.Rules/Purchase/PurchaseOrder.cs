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
	/// <summary>
	/// PurchaseOrder 的摘要说明。
	/// </summary>
	public class PurchaseOrder :Messages,IInItem
	{
		#region 构造函数
		public PurchaseOrder()
		{
		}
		#endregion

		#region IInItem 成员

		/// <summary>
		/// 采购订单录入。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			bool ret = true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			//判断有没有指定供应商。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
			{
				this.Message = PurchaseOrderData.NoPrvider;
				return false;
			}
			//执行采购订单的新建。
			if (oPurchaseOrders.InsertEntry(Entry) == false)
			{
				this.Message = oPurchaseOrders.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单录入并且提交。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			//判断有没有指定供应商。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" || 
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
			{
				this.Message = PurchaseOrderData.NoPrvider;
				return false;
			}
			//判断有没有指定采购员。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == "-1"||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() =="空")
			{
				this.Message = PurchaseOrderData.NoBuyer;
				return false;
			}
			if (oPurchaseOrders.InsertAndPresentEntry(Entry) == false)
			{
				this.Message = oPurchaseOrders.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单修改。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			bool ret = true;
	
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			//判断修改的前提条件。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject
				)
			{
				//判断有没有指定供应商。
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
				{
					this.Message = PurchaseOrderData.NoPrvider;
					return false;
				}
				if (oPurchaseOrders.UpdateEntry(Entry) == false)
				{
					this.Message = oPurchaseOrders.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XUpdate;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单修改并且提交。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject
				)
			{
				oPOData = (PurchaseOrderData)Entry;
				//判断有没有指定供应商。
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
				{
					this.Message = PurchaseOrderData.NoPrvider;
					return false;
				}
				//判断有没有指定采购员。
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == "-1" ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "空")
				{
					this.Message = PurchaseOrderData.NoBuyer;
					return false;
				}
				if (oPurchaseOrders.UpdateAndPresentEntry(Entry) == false)
				{
					this.Message = oPurchaseOrders.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XUpdatePresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			//判断采购订单删除的前提条件。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
			{
				if (oPurchaseOrders.DeleteEntry(EntryNo) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XDelete;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购订单状态修改。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();

			if (oPurchaseOrders.UpdateEntryState(EntryNo,newState) == false)
			{
				this.Message=oPurchaseOrders.Message;
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;
			int EntryNo;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = Entry as PurchaseOrderData;
			EntryNo = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			oPOData = oPurchaseOrders.GetEntryByEntryNo(EntryNo) as PurchaseOrderData;
			//判断一级审批的前提条件。查看审批之前的单据状态是否已指派。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Assigned)
			{
				oPOData = Entry as PurchaseOrderData;
				//如果没有进行审核确定。进行报错。
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
				{
					this.Message = "请确定是审核通过还是不通过！";
					ret = false;
				}
				//如果审批不通过但是又没有写原因。
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() == "N" &&
					(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDITSUGGEST1_FIELD] == null ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString().Trim() == "") )
				{
					this.Message = "请写明审批不通过的原因！";
					return false;
				}
				if (oPurchaseOrders.FirstAudit(Entry) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断二级审批的前提条件。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oPurchaseOrders.SecondAudit(Entry) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XSecondAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	采购订单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)Entry;
			oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断三级审批的前提条件。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{			
				if (oPurchaseOrders.ThirdAudit(Entry) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XThirdAudit;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单指派。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			//判断订单指派的前提条件。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			{
				//判断有没有指定供应商。
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "-1" ||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString() == "")
				{
					this.Message = PurchaseOrderData.NoPrvider;
					return false;
				}
				//判断有没有指定采购员。
				if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == "-1"||
					oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == "空")
				{
					this.Message = PurchaseOrderData.NoBuyer;
					return false;
				}
				if (oPurchaseOrders.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XAssign;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购订单作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			//判断作废的前提条件。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject)
			{
				if (oPurchaseOrders.Cancel(EntryNo, newState) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XCancel;
				ret = false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			//判断一级审批的前提条件。
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
				oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject)
			{
				if (oPurchaseOrders.Cancel(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据采购订单流水号获取采购订单完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <returns>object:	采购订单数据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			return oPurchaseOrderData;
		}

        /// <summary>
        /// 根据采购订单流水号获取采购订单完整信息。
        /// </summary>
        /// <param name="EntryNo">int:	采购订单流水号。</param>
        /// <returns>object:	采购订单数据实体。</returns>
        public object GetPORepealEntryNo(int EntryNo)
        {
         

            PurchaseOrderData oPurchaseOrderData;
            PurchaseOrders oPurchaseOrders = new PurchaseOrders();
            oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetPORepealEntryNo(EntryNo);
           // ((PurchaseOrderData)oPurchaseOrders).get
            return oPurchaseOrderData;
        }

		/// <summary>
		/// 根据采购订单流水号获取采购订单完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	采购订单流水号。</param>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <returns>object:	采购订单数据实体。</returns>
		public object GetEntryByEntryNoAndItemCode(int EntryNo, string ItemCode)
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNoAndItemCode(EntryNo, ItemCode);
			return oPurchaseOrderData;
		}
		/// <summary>
		/// 根据采购订单编号获取采购订单信息。
		/// </summary>
		/// <param name="EntryCode">string:	采购订单编号。</param>
		/// <returns>object:	采购订单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCode(EntryCode);
			return oPurchaseOrderData;
		}
		/// <summary>
		/// 获取所有采购订单。
		/// </summary>
		/// <returns>object:	采购订单数据实体。</returns>
		public object GetEntryAll()
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryAll();
			return oPurchaseOrderData;
		}
		/// <summary>
		/// 根据采购订单制单部门编号获取采购订单信息。
		/// </summary>
		/// <param name="DeptCode">string:	采购订单制单部门编号。</param>
		/// <returns>object:	采购订单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PurchaseOrderData oPurchaseOrderData ;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPurchaseOrderData = (PurchaseOrderData)oPurchaseOrders.GetEntryByDept(DeptCode);
			return oPurchaseOrderData;
		}

		#endregion

		#region 采购订单专有方法
		/// <summary>
		/// 获取所有的采购订单来源数据.
		/// </summary>
		/// <param name="UserLoginId">登录名</param>
		/// <returns>POSData</returns>
		public POSData GetPosAll(string UserLoginId)
		{
			POSData oPOSData;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPOSData = oPurchaseOrders.GetPOSAll(UserLoginId);
			return oPOSData;
		}
		/// <summary>
		/// 采购订单确认。
		/// </summary>
		/// <param name="EntryNo">采购订单编号</param>
		/// <param name="newState">新状态</param>
		/// <param name="UserLoginId">登录名</param>
		/// <returns>bool</returns>
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			PurchaseOrderData oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryNo(EntryNo);
			if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdPass )
			{
				if (oPurchaseOrders.Affirm(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oPurchaseOrders.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchaseOrderData.XConfirm;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据ID串获取采购订单来源的详细数据.
		/// </summary>
		/// <param name="PKIDs">采购订单来源ID串.</param>
		/// <returns>POSData</returns>
		public POSData GetPOSByPKIDs(string PKIDs)
		{
			POSData oPOSData;
			PurchaseOrders oPurchaseOrders = new PurchaseOrders();
			oPOSData = oPurchaseOrders.GetPOSByPKIDs(PKIDs);
			return oPOSData;
		}
		
					   
					   
		#endregion
	}
}
