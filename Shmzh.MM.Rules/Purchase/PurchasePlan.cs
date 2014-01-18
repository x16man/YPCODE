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
    using Shmzh.MM.Common;
    using Shmzh.MM.DataAccess;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;
    
		/// <summary>
	/// PurchasePlan 的摘要说明。
	/// </summary>
	public class PurchasePlan :Messages,IInItem  
	{

        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Grant();
        private IList<GrantInfo> grantinfo;

		#region 构造函数
		public PurchasePlan()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 采购计划插入。
		/// </summary>
		/// <param name="Entry">object:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			bool ret = true;

			PurchasePlans oPurchasePlans = new PurchasePlans();

			if (oPurchasePlans.InsertEntry(Entry) == false)
			{
				this.Message = oPurchasePlans.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划插入并且提交。
		/// </summary>
		/// <param name="Entry">object:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;

			PurchasePlans oPurchasePlans = new PurchasePlans();

			if (oPurchasePlans.InsertAndPresentEntry(Entry) == false)
			{
				this.Message = oPurchasePlans.Message;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划修改。
		/// </summary>
		/// <param name="Entry">object:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			EntryNo = Convert.ToInt32(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			//判断修改的前提条件。
//			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				if (oPurchasePlans.UpdateEntry(Entry) == false)
				{
					this.Message = oPurchasePlans.Message;
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
		/// 采购计划修改并且提交。
		/// </summary>
		/// <param name="Entry">object:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			EntryNo = Convert.ToInt32(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(int.Parse(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断修改的前提条件。
//			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				if (oPurchasePlans.UpdateAndPresentEntry(Entry) == false)
				{
					this.Message = oPurchasePlans.Message;
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
		/// 采购计划删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//判断修改的前提条件。
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
			{
				if (oPurchasePlans.DeleteEntry(EntryNo) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XDelete;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划删除。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <param name="UserLoginId">string:	用户.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo,string UserLoginId)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			//PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//判断修改的前提条件。
			//if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				if (oPurchasePlans.DeleteEntry(EntryNo) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
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
		/// 采购计划更改状态。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();

			if (oPurchasePlans.UpdateEntryState(EntryNo,newState) == false)
			{
				this.Message=oPurchasePlans.Message;
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划一级审批。
		/// </summary>
		/// <param name="Entry">object:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(int.Parse(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断修改的前提条件。
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				if (oPurchasePlans.FirstAudit(Entry) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XFirstAudit;
				ret =false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划二级审批。
		/// </summary>
		/// <param name="Entry">object:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(int.Parse(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断修改的前提条件。
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				if (oPurchasePlans.SecondAudit(Entry) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XSecondAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 采购计划三级审批。
		/// </summary>
		/// <param name="Entry">object:	采购计划数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)Entry;
			oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(int.Parse(oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断修改的前提条件。
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{
				if (oPurchasePlans.ThirdAudit(Entry) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XThirdAudit;
				ret = false;
			}
			return ret;
		}

		/// <summary>
		/// 采购计划提交。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			//PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//判断修改的前提条件。
//			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId))
			{
				if (oPurchasePlans.Present(EntryNo, newState, UserLoginId) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
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
		/// 采购计划作废。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//判断修改的前提条件。
			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			{
				if (oPurchasePlans.Cancel(EntryNo, newState) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
				}
			}
			else
			{
				this.Message = PurchasePlanData.XCancel;
				ret = false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState,string UserLoginID)
		{
			bool ret=true;

			PurchasePlans oPurchasePlans = new PurchasePlans();
			//PurchasePlanData oPPData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			//判断修改的前提条件。
//			if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginID))
			{
				if (oPurchasePlans.Cancel(EntryNo, newState,UserLoginID) == false)
				{
					this.Message=oPurchasePlans.Message;
					ret=false;
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
		/// 根据采购计划流水号获取采购计划完整信息。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
		/// <returns>object:	采购计划数据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);
			return oPurchasePlanData;
		}
		
		public object GetPPByEntryNoGroupByDep(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetPPByEntryNoGroupByDep(EntryNo);
			return oPurchasePlanData;
		}
		/// <summary>
		/// 根据采购计划编号获取采购计划完整信息。
		/// </summary>
		/// <param name="EntryNo">string:	采购计划编号。</param>
		/// <returns>object:	采购计划数据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryCode(EntryCode);
			return oPurchasePlanData;
		}
		/// <summary>
		/// 获取所有采购计划。
		/// </summary>
		/// <returns>object:	采购计划数据实体。</returns>
		public object GetEntryAll()
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryAll();
			return oPurchasePlanData;
		}
		/// <summary>
		/// 根据采购计划制单部门编号获取采购计划信息。
		/// </summary>
		/// <param name="DeptCode">string:	采购计划制单部门编号。</param>
		/// <returns>object:	采购计划数据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PurchasePlanData oPurchasePlanData ;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryByDept(DeptCode);
			return oPurchasePlanData;
		}

		#endregion

		#region 采购计划专用方法
		/// <summary>
		/// 获取所有采购计划的数据来源。
		/// </summary>
		/// <returns></returns>
		public PPSData GetPPSAll(string UserLoginId)
		{
			int RepeatItemCount = 0;
			int Count = 0;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			PPSData oPPSData;
			oPPSData = oPurchasePlans.GetPPSALL(UserLoginId);
			Count = oPPSData.Count;//采购计划明细内容的记录数。
			RepeatItemCount = oPPSData.RepeatItemCount;//采购计划中重复物料的数量。
			//如果采购计划内容中存在着重复内容,则对于每条重复物料的计划记录重新分配计划数量.
			if (RepeatItemCount > 0)
			{
				string itemcode;
				decimal price,plannum;
				int count;
				decimal itemlacknum = 0;
				for (int i = 0; i < RepeatItemCount; i++)
				{
					int lowstockindex = -1;//低库存记录的行号初始化为-1。
					//物料编号。
					itemcode = oPPSData.Tables[PPSData.PLANNUM_TABLE].Rows[i][PPSData.ITEMCODE_FIELD].ToString();
					//采购计划数量。
					plannum = Convert.ToDecimal(oPPSData.Tables[PPSData.PLANNUM_TABLE].Rows[i][PPSData.ITEMNUM_FIELD].ToString());
					//该物料在采购计划中的重复次数。
					count = Convert.ToInt32(oPPSData.Tables[PPSData.PLANNUM_TABLE].Rows[i][PPSData.COUNT_FIELD].ToString());
					
					for (int j = 0; j < Count; j++)
					{
						if (count > 0 && oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMCODE_FIELD].ToString() == itemcode)
						{
							itemlacknum = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMLACKNUM_FIELD].ToString());
							if ( itemlacknum > 0)//如果不是低库存记录，低库存记录的itemlacknum = 0;
							{
								if ( itemlacknum >= plannum)
								{
									oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = plannum;
									price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
									oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = plannum*price;
									plannum = 0;
									count = count -1;//表示已处理完一个。
									if (count == 0)//如果该重复物料已经处理完毕，则跳出循环。
									{ break; }
								}
								else//如果需求数量，小于采购计划数量。
								{
									count = count - 1;//表示已处理完一个。

									/*如果已经是最后一条重复记录，并且之前没有低库存记录。
									 * 而且剩余的计划数量大于需求数量，那么就是由采购批量造成的。
									 * 这时候，就将所剩余的采购计划数量，都加到这最后一条需求记录上。
									 */
									if (count == 0 && lowstockindex == -1)
									{
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = plannum;
										price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = plannum*price;
										break;//跳出循环。
									}
									/*如果是最后一条记录，但是之前有过一条低库存的记录。
									* 而且剩余的数量大于本需求记录的需求量，那么就本条
									* 需求记录只承担自身的需求数量，多余的采购计划数量
									* 由低库存那条记录来承担。
									*/ 
									if (count == 0 && lowstockindex > -1)
									{
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = itemlacknum;
										price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = itemlacknum*price;
										plannum = plannum - itemlacknum;
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[lowstockindex][PPSData.ITEMNUM_FIELD] = plannum;
										break;//跳出循环。
									}
									/*如果不是最后一需求记录，而且之前也没有过低库存记录。
									 * 而且剩余的采购计划数量大于本条的需求数量。
									 * 则本条记录只承担自身的需求数量。
									 */ 
									if (count > 0 && lowstockindex == -1)
									{
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = itemlacknum;
										price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = itemlacknum*price;
										plannum = plannum - itemlacknum;
									}
									/*如果不是最后一条需求记录，但是之前已经出现过一条低库存记录。
									 * 而且剩余的采购计划数量大于本条的需求数量。
									 * 则本条记录只承担自身的需求数量。
									 */
									if (count > 0 && lowstockindex > -1)
									{
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = itemlacknum;
										price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
										oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = itemlacknum*price;
										plannum = plannum - itemlacknum;
									}
									
								}
							}
							else//是低库存记录。低库存记录放在最后进行计算。
							{
								lowstockindex = j;//该物料低库存记录的行号。
								count = count - 1;
								/*如果这条低库存记录是重复物料的最后一条记录。
								 * 则承担所有的剩余采购计划数量。否则，不进行
								 * 任何处理，仅仅记录下他的行号。留在最后再处理。
								 */ 
								if (count == 0)
								{
									oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMNUM_FIELD] = plannum;
									price = Convert.ToDecimal(oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMPRICE_FIELD].ToString());
									oPPSData.Tables[PPSData.PPS_TABLE].Rows[j][PPSData.ITEMMONEY_FIELD] = plannum*price;
									break;//跳出循环。
								}
							}
							
						}
					}
				}
				//End Of如果采购计划内容中存在着重复内容,则对于每条重复物料的计划记录重新分配计划数量.
			}
			return oPPSData;
		}
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	采购计划流水号。</param>
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
			PurchasePlanData oPurchasePlanData;
			PurchasePlans oPurchasePlans = new PurchasePlans();
			oPurchasePlanData = (PurchasePlanData)oPurchasePlans.GetEntryByEntryNo(EntryNo);   

			if (oPurchasePlanData.Count > 0)
			{
				EntryState = oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
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
                            grant = new Grant();
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
						if (EntryState == DocStatus.New)
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
