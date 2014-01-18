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
	/// PBRB 的摘要说明。
	/// </summary>
	public class PBRB:Messages,IInItem
	{
		#region 构造函数
		public PBRB()
		{
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 批量进货单录入。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			bool ret=true;
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			//检查仓库。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOSTORAGE;
				ret = false;
				return ret;
			}
			//检查供应商。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.PRVCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOVENDOR;
				ret = false;
				return ret;
			}
			//检查订单。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString().Trim().Length == 0)
			{
				this.Message = PBRBData.NOORDER;
				ret = false;
				return ret;
			}
			else
			{
				PurchaseOrderData oPOData;
				PurchaseOrders oPurchaseOrders = new PurchaseOrders();
				string OrderCode;
				string ItemCode;
				OrderCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString();
				ItemCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString().Split(',')[0];

				oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCodeAndItemCode(OrderCode,ItemCode);
				
				if (oPOData.Count == 0)
				{
					this.Message = PBRBData.XORDER;
					ret = false;
					return ret;
				}
				else
				{
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERCODE_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERNAME_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				}
			}
			//检验通过进行保存操作。
			
			PBRBs oPBRBs = new PBRBs();

			if (oPBRBs.InsertEntry(oPBRBData) == false)
			{
				this.Message = oPBRBs.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 新建并马上提交批量进货单.
		/// </summary>
		/// <param name="Entry">object:	批量进货单。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  添加 PBRB.Insert 实现
			bool ret=true;
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			//检查仓库。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOSTORAGE;
				ret = false;
				return ret;
			}
			//检查供应商。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.PRVCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOVENDOR;
				ret = false;
				return ret;
			}
			//检查订单。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString().Trim().Length == 0)
			{
				this.Message = PBRBData.NOORDER;
				ret = false;
				return ret;
			}
			else
			{
				PurchaseOrderData oPOData;
				PurchaseOrders oPurchaseOrders = new PurchaseOrders();
				string OrderCode;
				string ItemCode;
				OrderCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString();
				ItemCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString().Split(',')[0];

				oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCodeAndItemCode(OrderCode,ItemCode);
				if (oPOData.Count == 0)
				{
					this.Message = PBRBData.XORDER;
					ret = false;
					return ret;
				}
				else
				{
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERCODE_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERNAME_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				}
			}
			//检验通过进行保存操作。
			PBRBs oPBRBs=new PBRBs();

			if (oPBRBs.InsertAndPresentEntry(oPBRBData)==false)
			{
				this.Message=oPBRBs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 批量进货单修改。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			// TODO:  添加 PBRB.Update 实现
			bool ret=true;
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));

			//修改的前提是新建，作废，审批不通过．
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			{
				this.Message = PBRBData.XUpdate;
				return false;
			}
			oPBRBData = (PBRBData)Entry;
			//检查仓库。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOSTORAGE;
				ret = false;
				return ret;
			}
			//检查供应商。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.PRVCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOVENDOR;
				ret = false;
				return ret;
			}
			//检查订单。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString().Trim().Length == 0)
			{
				this.Message = PBRBData.NOORDER;
				ret = false;
				return ret;
			}
			else
			{
				PurchaseOrderData oPOData;
				PurchaseOrders oPurchaseOrders = new PurchaseOrders();

				string OrderCode;
				string ItemCode;
				OrderCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString();
				ItemCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString().Split(',')[0];

				oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCodeAndItemCode(OrderCode,ItemCode);
				
				if (oPOData.Count == 0)
				{
					this.Message = PBRBData.XORDER;
					ret = false;
					return ret;
				}
				else
				{
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERCODE_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERNAME_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				}
			}
			//检验通过进行保存操作。
			PBRBs oPBRBs=new PBRBs();

			if (oPBRBs.UpdateEntry(oPBRBData)==false)
			{
				this.Message=oPBRBs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 修改并且提交批量进货单.
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 PBRB.Update 实现
			bool ret=true;
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));

			//修改的前提是新建，作废，审批不通过．
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.New &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Cancel &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.FstNoPass &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.SecNoPass &&
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdNoPass )
			{
				this.Message = PBRBData.XUpdate;
				return false;
			}
			oPBRBData = (PBRBData)Entry;
			//检查仓库。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOSTORAGE;
				ret = false;
				return ret;
			}
			//检查供应商。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.PRVCODE_FIELD].ToString() == "-1")
			{
				this.Message = PBRBData.NOVENDOR;
				ret = false;
				return ret;
			}
			//检查订单。
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString().Trim().Length == 0)
			{
				this.Message = PBRBData.NOORDER;
				ret = false;
				return ret;
			}
			else
			{
				PurchaseOrderData oPOData;
				PurchaseOrders oPurchaseOrders = new PurchaseOrders();

				string OrderCode;
				string ItemCode;
				OrderCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERCODE_FIELD].ToString();
				ItemCode = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD].ToString().Split(',')[0];

				oPOData = (PurchaseOrderData)oPurchaseOrders.GetEntryByEntryCodeAndItemCode(OrderCode,ItemCode);

				if (oPOData.Count == 0)
				{
					this.Message = PBRBData.XORDER;
					ret = false;
					return ret;
				}
				else
				{
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERCODE_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
					oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BUYERNAME_FIELD] = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				}
			}
			//检验通过进行保存操作。
			PBRBs oPBRBs=new PBRBs();

			if (oPBRBs.UpdateAndPresentEntry(oPBRBData)==false)
			{
				this.Message=oPBRBs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 批量进货单删除。
		/// </summary>
		/// <param name="EntryNo">int:	 批量进货单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  添加 PBRB.Delete 实现
			bool ret=true;
			PBRBData oPBRBData;

			PBRBs oPBRBs=new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			if (oPBRBData != null && oPBRBData.Count > 0)
			{
				//如果单据是作废状态才允许删除．
				if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
				{
					if (oPBRBs.DeleteEntry(EntryNo)==false)
					{
						this.Message=oPBRBs.Message;
						ret=false;
					}
				}
				else
				{
					this.Message = PBRBData.XDelete;
					ret = false;
				}
			}
			
			return ret;
		}
		/// <summary>
		/// 修改单据状态.
		/// </summary>
		/// <param name="EntryNo">int:	批量进货单流水号.</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 PBRB.UpdateEntryState 实现
			bool ret=true;

			PBRBs oPBRBs=new PBRBs();

			if (oPBRBs.UpdateEntryState(EntryNo, newState)==false)
			{
				this.Message=oPBRBs.Message;
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  添加 PBRB.FirstAduit 实现
			bool ret=true;

			PBRBs oPBRBs=new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));

			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				if (oPBRBs.FirstAudit(Entry) == false)
				{
					this.Message = oPBRBs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PBRBData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  添加 PBRB.SecondAduit 实现
			bool ret=true;

			PBRBs oPBRBs=new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//批量进货单二级审批的前提条件是一级审批通过．
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oPBRBs.SecondAudit(Entry) == false)
				{
					this.Message=oPBRBs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PBRBData.XSecondAudit;
				ret =false;
			}
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	批量进货单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  添加 PBRB.ThirdAduit 实现
			bool ret = true;

			PBRBs oPBRBs = new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)Entry;
			oPBRBData = (PBRBData)new PBRBs().GetEntryByEntryNo(Convert.ToInt32(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//批量进货单二级审批的前提条件是一级审批通过．
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{
				if (oPBRBs.ThirdAudit(Entry) == false)
				{
					this.Message=oPBRBs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PBRBData.XThirdAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 批量进货单提交。
		/// </summary>
		/// <param name="EntryNo">int:	批量进货单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			PBRBData oPBRBData;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过的才允许提交．
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oPBRBs.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oPBRBs.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PBRBData.XPresent;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 批量进货单作废。
		/// </summary>
		/// <param name="EntryNo">int:	批量进货单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			PBRBs oPBRBs = new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过允许作废．
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oPBRBs.Cancel(EntryNo, newState) == false)
				{
					this.Message = oPBRBs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = PBRBData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 批量进货单作废。
		/// </summary>
		/// <param name="EntryNo">int:	批量进货单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginID">string:	操作人.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;

			PBRBs oPBRBs = new PBRBs();
			PBRBData oPBRBData;
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			//单据状态为新建或审批不通过允许作废．
			if (oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oPBRBs.Cancel(EntryNo, newState, UserLoginID) == false)
				{
					this.Message = oPBRBs.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = PBRBData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据批量进货单流水号获取批量进货单完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	批量进货单流水号。</param>
		/// <returns>object:	批量进货单数据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryNo(EntryNo);
			return oPBRBData;
		}
		/// <summary>
		/// 根据批量进货单编号获取批量进货单完整信息。
		/// </summary>
		/// <param name="EntryCode">string:	批量进货单编号。</param>
		/// <returns>object:	批量进货单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByEntryCode(EntryCode);
			return oPBRBData;
		}
		/// <summary>
		/// 获取所有批量进货单。
		/// </summary>
		/// <returns>object:	批量进货单数据实体。</returns>
		public object GetEntryAll()
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryAll();
			return oPBRBData;
		}
		/// <summary>
		/// 获取所有批量进货单。
		/// </summary>
		/// <param name="UserLoginId">string:	用户ID。</param>
		/// <returns>object:	批量进货单数据实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryAll(UserLoginId);
			return oPBRBData;
		}
		/// <summary>
		/// 获取指定申请部门的批量进货单。
		/// </summary>
		/// <param name="DeptCode">string:	申请部门编号。</param>
		/// <returns>object:	批量进货单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PBRBData oPBRBData ;
			PBRBs oPBRBs = new PBRBs();
			oPBRBData = (PBRBData)oPBRBs.GetEntryByDept(DeptCode);
			return oPBRBData;
		}

		#endregion
	}
}
