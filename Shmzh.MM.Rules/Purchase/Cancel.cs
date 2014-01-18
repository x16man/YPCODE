#region 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved

#region 文档信息
/******************************************************************************
**		文件: 
**		名称: 
**		描述: 
**
**              
**		作者: 张豪
**		日期: 
*******************************************************************************
**		修改历史
*******************************************************************************
**		日期:		作者:		描述:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion 文档信息


namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// Cancel 的摘要说明。
	/// </summary>
	public class Cancel	 : Messages
	{
		#region 成员变量
		//
		//TODO: 在此处添加成员变量。
		//
		#endregion

		#region 属性
		//
		//TODO: 在此处添加属性。
		//
		#endregion
		
		#region 私有方法
		//
		//TODO: 在这此处加私有方法。
		//
		#endregion

		#region 公开方法
		public bool Insert(CancelData Entry)
		{
			bool ret = true;

			Cancels oCancels = new Cancels();
			//执行采购订单的新建。
			if (oCancels.InsertEntry(Entry) == false)
			{
				this.Message = oCancels.Message;
				ret = false;
			}
			return ret;
		}
		public bool InsertAndPresent(CancelData Entry)
		{
			bool ret = true;

			Cancels oCancels = new Cancels();
			if (oCancels.InsertAndPresentEntry(Entry) == false)
			{
				this.Message = oCancels.Message;
				ret = false;
			}
			return ret;
		}
		public bool Update(CancelData Entry)
		{
			bool ret = true;
	
			Cancels oCancels = new Cancels();
			//判断修改的前提条件。
			if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
				Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
				Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
				Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
				Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass 
				)
			{
				if (oCancels.UpdateEntry(Entry) == false)
				{
					this.Message = oCancels.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "采购撤销单不符合修改的前提条件！";
				ret = false;
			}
			return ret;
		}
		public bool UpdateAndPresent(CancelData Entry)
		{
			bool ret = true;

			Cancels oCancels = new Cancels();
			CancelData oCancelData = oCancels.GetEntryByEntryNo(int.Parse(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryNo_Field].ToString()));
			
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass 
				)
			{
				if (oCancels.UpdateAndPresentEntry(Entry) == false)
				{
					this.Message = oCancels.Message;
					ret = false;
				}
			}
			else
			{
				this.Message = "采购撤销单不符合修改的前提条件!";
				ret = false;
			}
			return ret;
		}
		public bool Delete(int EntryNo)
		{
			bool ret=true;

			Cancels oCancels = new Cancels();
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//判断采购订单删除的前提条件。
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel)
			{
				if (oCancels.DeleteEntry(EntryNo) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "采购撤销单不符合删除的前提条件!";
				ret = false;
			}
			return ret;
		}
		public bool FirstAudit(CancelData Entry)
		{
			bool ret=true;
			int EntryNo;
			Cancels oCancels = new Cancels();
			EntryNo = int.Parse(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryNo_Field].ToString());
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//判断一级审批的前提条件。查看审批之前的单据状态是否已指派。
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Present)
			{
				//如果没有进行审核确定。进行报错。
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit1_Field].ToString() != "Y" &&
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit1_Field].ToString() != "N")
				{
					this.Message = "请确定是审核通过还是不通过！";
					ret = false;
				}
				//如果审批不通过但是又没有写原因。
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit1_Field].ToString() == "N" &&
					(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest1_Field] == null ||
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest1_Field].ToString().Trim() == "") )
				{
					this.Message = "请写明审批不通过的原因！";
					return false;
				}
				if (oCancels.FirstAudit(Entry) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "采购撤销单不符合一级审批的前提条件！";
				ret = false;
			}
			return ret;
		}
		public bool SecondAudit(CancelData Entry)
		{
			bool ret=true;
			int EntryNo;
			Cancels oCancels = new Cancels();
			EntryNo = int.Parse(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryNo_Field].ToString());
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//判断一级审批的前提条件。查看审批之前的单据状态是否已指派。
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstPass)
			{
				//如果没有进行审核确定。进行报错。
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit2_Field].ToString() != "Y" &&
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit2_Field].ToString() != "N")
				{
					this.Message = "请确定是审核通过还是不通过！";
					ret = false;
				}
				//如果审批不通过但是又没有写原因。
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit2_Field].ToString() == "N" &&
					(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest2_Field] == null ||
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest2_Field].ToString().Trim() == "") )
				{
					this.Message = "请写明审批不通过的原因！";
					return false;
				}
				if (oCancels.SecondAudit(Entry) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "采购撤销单不符合二级审批的前提条件！";
				ret = false;
			}
			return ret;
		}
		public bool ThirdAudit(CancelData Entry)
		{
			bool ret=true;
			int EntryNo;
			Cancels oCancels = new Cancels();
			EntryNo = int.Parse(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryNo_Field].ToString());
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//判断一级审批的前提条件。查看审批之前的单据状态是否已指派。
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecPass)
			{
				//如果没有进行审核确定。进行报错。
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit3_Field].ToString() != "Y" &&
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit3_Field].ToString() != "N")
				{
					this.Message = "请确定是审核通过还是不通过！";
					ret = false;
				}
				//如果审批不通过但是又没有写原因。
				if (Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.Audit3_Field].ToString() == "N" &&
					(Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest3_Field] == null ||
					Entry.Tables[CancelData.PCOR_Table].Rows[0][CancelData.AuditSuggest3_Field].ToString().Trim() == "") )
				{
					this.Message = "请写明审批不通过的原因！";
					return false;
				}
				if (oCancels.ThirdAudit(Entry) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "采购撤销单不符合三级审批的前提条件！";
				ret = false;
			}
			return ret;
		}
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Cancels oCancels = new Cancels();
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//判断一级审批的前提条件。
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.Cancel ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass)
			{
				if (oCancels.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "采购撤销单不符合提交的前提条件！";
				ret = false;
			}
			return ret;
		}
		public bool XCancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;

			Cancels oCancels = new Cancels();
			CancelData oCancelData = oCancels.GetEntryByEntryNo(EntryNo);
			//判断一级审批的前提条件。
			if (oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.New ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.FstNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.SecNoPass ||
				oCancelData.Tables[CancelData.PCOR_Table].Rows[0][CancelData.EntryState_Field].ToString() == DocStatus.TrdNoPass)
			{
				if (oCancels.Cancel(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oCancels.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = "采购撤销单不符合作废的前提条件！";
				ret = false;
			}
			return ret;
		}
		#endregion

		#region 构造函数
		public Cancel()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
