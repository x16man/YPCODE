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
    using System.Collections.Generic;
 
	/// <summary>
	/// PurchaseOrder 的摘要说明。
	/// </summary>
	public class BillOfReceive :Messages,IInItem
	{
        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Shmzh.Components.SystemComponent.SQLServerDAL.Grant();
        private IList<GrantInfo> grantinfo;
		#region 构造函数
		public BillOfReceive()
		{
		}
		#endregion


        private bool CheckInvoice(string strInvoiceNo)
        {
            if (strInvoiceNo != null && strInvoiceNo != "")
            {
                if (strInvoiceNo.IndexOf("，") > 0)
                    return false;
               
            }
            return true;
        }

		#region IInItem 成员
		/// <summary>
		/// 收料单录入。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			bool ret = true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			//判断收料仓库是否为空。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = BillOfReceiveData.NoStorage;
				return false;
			}
			//判断采购员是否为空。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "-1"||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "空")
			{
				this.Message = BillOfReceiveData.NoBuyer;
				return false;
			}
			//判断制单人和采购员是否为同一个人。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString())
			{
				this.Message = "采购员不能同时为制单人！";
				return false;
			}
			//判断发票号是否为空.
            if (!CheckInvoice(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0]["InvoiceNo"].ToString()))
			{
				this.Message = "发票号不能有中文逗号！";
				return false;
			}
			//执行采购收料单新建操作。
			if (oBillOfReceives.InsertEntry(Entry) == false)
			{
				this.Message = oBillOfReceives.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单录入并且提交。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			//判断收料仓库是否为空。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = BillOfReceiveData.NoStorage;
				return false;
			}
			//判断采购员是否为空。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "-1"||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "空")

			{
				this.Message = BillOfReceiveData.NoBuyer;
				return false;
			}
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString())
			{
				this.Message = "采购员不能同时为制单人！";
				return false;
			}
			//判断发票号是否为空.
			if (!CheckInvoice(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0]["InvoiceNo"].ToString()))
			{
                this.Message = "发票号不能有中文逗号！";
				return false;
			}
			//执行采购收料单新建操作。
			if (oBillOfReceives.InsertAndPresentEntry(Entry) == false)
			{
				this.Message = oBillOfReceives.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单修改。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			EntryNo = Convert.ToInt32(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			//判断采购收料单的修改的前提条件。
//			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				//判断收料仓库是否为空。
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString() == "-1")
				{
					this.Message = BillOfReceiveData.NoStorage;
					return false;
				}
				//判断采购员是否为空。
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "-1"||
					oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "空")
				{
					this.Message = BillOfReceiveData.NoBuyer;
					return false;
				}
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
					oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString())
				{
					this.Message = "采购员不能同时为制单人！";
					return false;
				}
				//判断发票号是否为空.
				if (!CheckInvoice(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0]["InvoiceNo"].ToString().Trim()))
				{
                    this.Message = "发票号不能有中文逗号！";
					return false;
				}
				//执行采购收料单新建操作。
				if (oBillOfReceives.UpdateEntry(Entry) == false)
				{
					this.Message = oBillOfReceives.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "您无权进行此操作。";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单修改并且提交。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			EntryNo = Convert.ToInt32(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(int.Parse(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断采购收料单的修改并且提交的前提条件。
//			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				oBORData = (BillOfReceiveData)Entry;
				//判断收料仓库是否为空。
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString() == "-1")
				{
					this.Message = BillOfReceiveData.NoStorage;
					return false;
				}
				//判断采购员是否为空。
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "-1"||
					oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == "空")
				{
					this.Message = BillOfReceiveData.NoBuyer;
					return false;
				}
				if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
					oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString())
				{
					this.Message = "采购员不能同时为制单人！";
					return false;
				}
				//判断发票号是否为空.
				if (!CheckInvoice(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0]["InvoiceNo"].ToString().Trim()))
				{
                    this.Message = "发票号不能有中文逗号！";
					return false;
				}
				//执行采购收料单新建操作。
				if (oBillOfReceives.UpdateAndPresentEntry(Entry) == false)
				{
					this.Message = oBillOfReceives.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			//判断采购收料单的删除的前提条件。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel )
			{
				if (oBillOfReceives.DeleteEntry(EntryNo) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XDelete;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			//BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);

			//判断采购收料单的删除的前提条件。
			//if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel )
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				if (oBillOfReceives.DeleteEntry(EntryNo) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单状态修改。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();

			if (oBillOfReceives.UpdateEntryState(EntryNo,newState) == false)
			{
				this.Message=oBillOfReceives.Message;
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 一级审批。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
            //页面所取数据
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
            //数据库原来的数据
            BillOfReceiveData oBORTempData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(int.Parse(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断审批人和制单人或采购员是否是同一个人。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ASSESSOR1_FIELD].ToString() ==
                oBORTempData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERNAME_FIELD].ToString())
			{
				this.Message = "审批人不能同时为采购员！";
				return false;
			}
			else if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ASSESSOR1_FIELD].ToString() ==
                    oBORTempData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORNAME_FIELD].ToString())
			{
				this.Message = "审批人不能同时为制单人！";
				return false;
			}

			//判断采购收料单的一级审批的前提条件。
            if (oBORTempData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				if (oBillOfReceives.FirstAudit(Entry) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 二级审批。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(int.Parse(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断采购收料单的二级审批的前提条件。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oBillOfReceives.SecondAudit(Entry) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XSecondAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 三级审批。
		/// </summary>
		/// <param name="Entry">object:	收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)Entry;
			oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(int.Parse(oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断采购收料单的三级审批的前提条件。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oBillOfReceives.ThirdAudit(Entry) == false)
				{
					this.Message = oBillOfReceives.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XThirdAudit;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 收料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			//判断采购收料单的提交的前提条件。
//			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId))
			{
				if (oBillOfReceives.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "您无权进行此操作!";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 收料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			//判断采购收料单的作废的前提条件。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			{
				if (oBillOfReceives.Cancel(EntryNo, newState) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购收料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	状态。</param>
		/// <param name="UserLoginID">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);

			//判断采购收料单的作废的前提条件。
//			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass )
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginID))
			{
				if (oBillOfReceives.Cancel(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购收料单财务付款。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginID">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Pay(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			//判断采购收料单的付款的前提条件。
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Received )
			{
				if (oBillOfReceives.Pay(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oBillOfReceives.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = BillOfReceiveData.XPay;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据收料单流水号获取收料单完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>object:	收料单数据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNo(EntryNo);
			return oBillOfReceiveData;
		}


        /// <summary>
        /// 根据收料单流水号获取收料单完整信息。
        /// </summary>
        /// <param name="EntryNo">int:	收料单流水号。</param>
        /// <returns>object:	收料单数据实体。</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            BillOfReceiveData oBillOfReceiveData;
            BillOfReceives oBillOfReceives = new BillOfReceives();
            oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryOldByEntryNo(EntryNo);
            return oBillOfReceiveData;
        }


      

        public bool BRInvoiceUpdate(int EntryNo,string strInvoiceNo)
        {
            BillOfReceives oBillOfReceives = new BillOfReceives();
            return oBillOfReceives.BRInvoiceNoUpdate(EntryNo, strInvoiceNo);
       }
		/// <summary>
		/// 根据收料单流水号获取收料单完整信息，收料模式。
		/// </summary>
		/// <param name="EntryNo">int:	收料单流水号。</param>
		/// <returns>object:	收料单数据实体。</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryNoInMode(EntryNo);
			return oBillOfReceiveData;
		}
		/// <summary>
		/// 根据收料单编号获取收料单信息。
		/// </summary>
		/// <param name="EntryCode">string:	收料单编号。</param>
		/// <returns>object:	收料单数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryByEntryCode(EntryCode);
			return oBillOfReceiveData;
		}
		/// <summary>
		/// 获取所有收料单。
		/// </summary>
		/// <returns>object:	收料单数据实体。</returns>
		public object GetEntryAll()
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryAll();
			return oBillOfReceiveData;
		}
		/// <summary>
		/// 根据收料单制单部门编号获取收料单信息。
		/// </summary>
		/// <param name="DeptCode">string:	收料单制单部门编号。</param>
		/// <returns>object:	收料单数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			BillOfReceiveData oBillOfReceiveData ;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oBillOfReceiveData = (BillOfReceiveData)oBillOfReceives.GetEntryByDept(DeptCode);
			return oBillOfReceiveData;
		}

		#endregion

		#region 收料单专有方法 
		/// <summary>
		/// 根据供应商代码获得源订单。
		/// </summary>
		/// <param name="PrvCode"></param>
		/// <returns></returns>
		public object GetEntryByPrvCode(string PrvCode)
		{
			PBSData oPBSData;
            BillOfReceives oBillOfReceives = new BillOfReceives();
			oPBSData = (PBSData)oBillOfReceives.GetEntryByPrvCode(PrvCode);
			return oPBSData;
		}
		/// <summary>
		/// 根据pkid列表获得明细。
		/// </summary>
		/// <param name="List"></param>
		/// <returns></returns>
		public object GetPBSDByList(string List)
		{
			PBSDData oPBSData;
			BillOfReceives oBillOfReceives = new BillOfReceives();
			oPBSData = (PBSDData)oBillOfReceives.GetPBSDByList(List);
			return oPBSData;
		}
		/// <summary>
		/// 采购收料单收料操作。
		/// </summary>
		/// <param name="Entry">object:	收料单对象。</param>
		/// <returns>bool:	收料成功返回true，失败返回false。</returns>
		public bool Receive(object Entry)
		{
			bool ret = true;

			BillOfReceives oBillOfReceives = new BillOfReceives();
			BillOfReceiveData oBORData = Entry as BillOfReceiveData;
			/*
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORCODE_FIELD].ToString() == 
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.ACCEPTCODE_FIELD].ToString())
			{
				this.Message = "收料人不能同时为制单人！";
				return false;
			}
			if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString() == 
				oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.ACCEPTCODE_FIELD].ToString())
			{
				this.Message = "收料人不能同时为采购员！";
				return false;
			}  */
			if (oBillOfReceives.Receive(Entry) == false)
			{
				this.Message = oBillOfReceives.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	采购收料单流水号。</param>
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
			BillOfReceiveData oBorData;
			BillOfReceives oBors = new BillOfReceives();
			oBorData = (BillOfReceiveData)oBors.GetEntryByEntryNo(EntryNo);   

			if (oBorData.Count > 0)
			{
				EntryState = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
				switch (Operation)
				{
						#region 编辑
					case OP.Edit://编辑。
						if (EntryState == DocStatus.New || 
							EntryState == DocStatus.Cancel || 
							EntryState == DocStatus.FstNoPass || 
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
							EntryState == DocStatus.OrdReject
							)
						{
                            grant = new Shmzh.Components.SystemComponent.SQLServerDAL.Grant();
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
                          EntryState == DocStatus.OrdReject
                          )
                        {
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
								ret = false;
							}
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region 一级审批
					case OP.FirstAudit://一级审批。
						if (EntryState == DocStatus.Present)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region 二级审批
					case OP.SecondAudit://二级审批。
						if (EntryState == DocStatus.FstPass)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region 三级审批
					case OP.ThirdAudit://三级审批。		
						if (EntryState == DocStatus.SecPass)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion 
						#region 红字
					case OP.Red://红字。
						if (EntryState == DocStatus.Drawed)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region 发料
					case OP.O://发料。
						if (EntryState == DocStatus.TrdPass)
						{
							ret = true;
						}
						else
						{
							ret = false;
						}
						break;
						#endregion
						#region 作废
					case OP.Cancel://作废。
						if (EntryState == DocStatus.New ||
							EntryState == DocStatus.FstNoPass ||
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
							EntryState == DocStatus.OrdReject)
						{
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
								ret = false;
							}
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
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
								ret = false;
							}
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
