
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// 委外加工收料单的业务规则层。
	/// </summary>
	public class WINW :Messages
	{
		#region 构造函数
		public WINW()
		{
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 委外加工收料单的增加。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			bool ret = true;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			//判断有没有指定供应商。
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.PrvCode_Field].ToString() == "-1" )
			{
				this.Message = "您没有指定供应商！";
				return false;
			}
			//判断有没有指定收料仓库。
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.StoCode_Field].ToString() == "-1")
			{
				this.Message = "您没有指定收料仓库！";
				return false;
			}
			//判断有没有指定采购员。
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.BuyerCode_Field].ToString() == "-1")
			{
				this.Message = "您没有指定采购员！";
				return false;
			}
			//判断有没有指定用途。
//			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//				oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//			{
//				this.Message = "您没有指定用途！";
//				return false;
//			}
			//执行委外加工收料单的新建操作。
			ret = oWINWs.InsertEntry(Entry);
			this.Message = oWINWs.Message;
			return ret;
		}
		/// <summary>
		/// 委外加工收料单的新建并且马上提交。。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			bool ret = true;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			//判断有没有指定供应商。
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.PrvCode_Field].ToString() == "-1" )
			{
				this.Message = "您没有指定供应商！";
				return false;
			}
			//判断有没有指定收料仓库。
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.StoCode_Field].ToString() == "-1")
			{
				this.Message = "您没有指定收料仓库！";
				return false;
			}
			//判断有没有指定采购员。
			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.BuyerCode_Field].ToString() == "-1")
			{
				this.Message = "您没有指定采购员！";
				return false;
			}
//			//判断有没有指定用途。
//			if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//				oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//			{
//				this.Message = "您没有指定用途！";
//				return false;
//			}
			//执行委外加工收料单的新建并且马上提交操作。
			ret = oWINWs.InsertAndPresentEntry(Entry);
			this.Message = oWINWs.Message;
			return ret;
		}
		/// <summary>
		/// 委外加工收料单的修改。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			UserLoginId = Convert.ToString(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.AuthorLoginID_Field].ToString());

			//判断委外加工收料单修改的前提条件。
			if ( this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId) )
			{
				//判断有没有指定供应商。
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.PrvCode_Field].ToString() == "-1" )
				{
					this.Message = "您没有指定供应商！";
					return false;
				}
				//判断有没有指定领料仓库。
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.StoCode_Field].ToString() == "-1")
				{
					this.Message = "您没有指定收料仓库！";
					return false;
				}
				//判断有没有指定采购员。
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.BuyerCode_Field].ToString() == "-1")
				{
					this.Message = "您没有指定采购员！";
					return false;
				}
//				//判断有没有指定用途。
//				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//					oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//				{
//					this.Message = "您没有指定用途！";
//					return false;
//				}
				//执行委外加工收料单的新建操作。
				ret = oWINWs.UpdateEntry(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XUpdate;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单收料。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool StockIn(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			UserLoginId = Convert.ToString(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.AuthorLoginID_Field].ToString());

			//判断委外加工收料单发料的前提条件。
			if ( this.CheckPreCondition(EntryNo, OP.I, UserLoginId) )
			{
				//判断有没有指定用途。
//				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//					oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//				{
//					this.Message = "您没有指定用途！";
//					return false;
//				}
				//执行委外加工收料单的新建操作。
				ret = oWINWs.StockIn(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
                this.Message = oWINWs.Message;
				ret = false;			
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单的修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			UserLoginId = Convert.ToString(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.AuthorLoginID_Field].ToString());

			//判断委外加工收料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				//判断有没有指定供应商。
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.PrvCode_Field].ToString() == "-1" )
				{
					this.Message = "您没有指定供应商！";
					return false;
				}
				//判断有没有指定收料仓库。
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.StoCode_Field].ToString() == "-1")
				{
					this.Message = "您没有指定收料仓库！";
					
					return false;
				}
				//判断有没有指定采购员。
				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.BuyerCode_Field].ToString() == "-1")
				{
					this.Message = "您没有指定采购员！";
					return false;
				}
//				//判断有没有指定用途。
//				if (oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "-1" ||
//					oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.ReqReasonCode_Field].ToString() == "")
//				{
//					this.Message = "您没有指定用途！";
//					return false;
//				}
				//执行委外加工收料单的新建操作。
				ret = oWINWs.UpdateAndPresentEntry(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XUpdate;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			WINWs oWINWs = new WINWs();
			//判断委外加工收料单删除的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				ret =  oWINWs.DeleteEntry(EntryNo);
				this.Message=oWINWs.Message;
			}
			else
			{
                //this.Message = WINWData.DELETE_FAILED
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单的一级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			int EntryNo;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			//判断委外加工收料单一级审批的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.FirstAudit))
			{
				ret = oWINWs.FirstAudit(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单的二级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			int EntryNo;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			//判断委外加工收料单二级审批的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.SecondAudit) )
			{
				ret = oWINWs.SecondAudit(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XSecondAudit ;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单的三级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工收料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			int EntryNo;
			WINWs oWINWs = new WINWs();
			WINWData oWINWData = (WINWData)Entry;
			EntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][WINWData.EntryNo_Field].ToString());
			//判断委外加工收料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.ThirdAudit) )
			{
				ret = oWINWs.ThirdAudit(Entry);
				this.Message=oWINWs.Message;
			}
			else
			{
				this.Message = WINWData.XThirdAudit;
				ret = false;
			}
			return ret;
		}
		
		/// <summary>
		/// 委外加工收料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WINWs oWINWs = new WINWs();
			
			//判断委外加工收料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.Submit, UserLoginId) )
			{
				ret = oWINWs.Present(EntryNo, newState, UserLoginId);
				this.Message=oWINWs.Message;
			}
			else
			{
                //this.Message = oWINWs.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工收料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工收料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WINWs oWINWs = new WINWs();
			
			//判断委外加工收料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginId) )
			{
				ret = oWINWs.Cancel(EntryNo, newState,UserLoginId);
				this.Message=oWINWs.Message;
			}
			else
			{
                //this.Message = th.Message;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据委外加工收料单的流水号来获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WINWData oWINWData ;
			WINWs oWINWs = new WINWs();
			oWINWData = (WINWData)oWINWs.GetEntryByEntryNo(EntryNo);
			return oWINWData;
		}


        public object GetEntryOldByEntryNo(int EntryNo)
        {
            WINWData oWINWData;
            WINWs oWINWs = new WINWs();
            oWINWData = (WINWData)oWINWs.GetEntryOldByEntryNo(EntryNo);
            return oWINWData;
        }

        public object GetEntryRedByEntryNo(int EntryNo)
        {
            WINWData oWINWData;
            WINWs oWINWs = new WINWs();
            oWINWData = (WINWData)oWINWs.GetEntryRedByEntryNo(EntryNo);
            return oWINWData;
        }

		/// <summary>
		/// 获取所有委外加工收料单。
		/// </summary>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WINWData oWINWData;
			WINWs oWINWs = new WINWs();
			oWINWData = (WINWData)oWINWs.GetEntryAll(UserLoginId);
			return oWINWData;
		}

        /// <summary>
        /// 获取所有委外加工收料单。
        /// </summary>
        /// <param name="UserLoginId">string:	用户。</param>
        /// <returns>object:	单据实体。</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WINWData oWINWData;
            WINWs oWINWs = new WINWs();
            oWINWData = (WINWData)oWINWs.GetEntryByPerson(EmpCode);
            return oWINWData;
        }
		#endregion

		#region 专有方法
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工收料单流水号。</param>
		/// <param name="Operation">string:	操作代码。</param>
		/// <returns>bool:	符合前提条件返回true,不符合返回false。</returns>
		public bool CheckPreCondition(int EntryNo, string Operation)
		{
			bool ret = false;
			string EntryState;
			
			if (Operation == OP.New)
			{
				return true;
			}
			WINWData oWINWData;
			WINWs oWINWs = new WINWs();
			oWINWData = (WINWData)oWINWs.GetEntryByEntryNo(EntryNo);	//2005-10-21修改,修改前错误的引用了.GetEntryByEntryNoOutMode方法。

			if (oWINWData.Count > 0)
			{
				EntryState = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
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
							ret = true;
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
							ret = true;
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
						#region 收料
					case OP.I://收料。
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
							ret = true;
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
							ret = true;
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
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工收料单流水号。</param>
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
			WINWData oWINWData;
			WINWs oWINWs = new WINWs();
			oWINWData = (WINWData)oWINWs.GetEntryByEntryNo(EntryNo);   

			if (oWINWData.Count > 0)
			{
				EntryState = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oWINWData.Tables[WINWData.WINW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
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
							if (AuthorLoginID == UserLoginID)
							{
								ret = true;
							}
							else
							{
                                this.Message = "您无权进行此操作！";
                                ret = false;
							}
						}
						else
						{
                            this.Message = "只有在单据新建,作废,审批不通过的前提下，才允许对单据进行修改！";
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
                                this.Message = "您无权进行此操作！";
								ret = false;
							}
						}
						else
						{
                            this.Message = "只有在新建或者审批不通过的前提下，才允许对单据进行提交操作！";
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
                            this.Message = "只有在单据已经提交的状态下，才允许对单据进行一级审批！";
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
                            this.Message = "只有在单据一级审批通过的前提下，才允许对单据进行二级审批！";
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
                            this.Message = "只有在单据二级审批通过的前提下，才允许对单据进行三级审批！";
							ret = false;
						}
						break;
						#endregion
						#region 红字
					case OP.Red://红字。
						if (EntryState == DocStatus.Received)
						{
							ret = true;
						}
						else
						{
                            this.Message = "只有在单据已收料的前提下，才允许对单据进行红字！";
							ret = false;
						}
						break;
						#endregion
						#region 收料
					case OP.I:
						if (EntryState == DocStatus.TrdPass)
						{
							ret = true;
						}
						else
						{
                            this.Message = "只有在单据三级审批通过的前提下，才允许对单据进行收料！";
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
                                this.Message = "您无权进行此操作！";
                                ret = false;
							}
							}
						else
						{
                            this.Message = "只有在新建或者审批不通过的前提下，才允许对单据进行作废操作！";
								
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
                                this.Message = "您无权进行此操作！";
								ret = false;
							}
						}
						else
						{
                            this.Message = "只有在作废的状态下才允许删除！";
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
