
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;
	/// <summary>
	/// 领料单的业务规则层。
	/// </summary>
	public class WDRW :Messages,IInItem
	{
        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Grant();
        private IList<GrantInfo> grantinfo;

		#region 构造函数
		public WDRW()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 领料单的增加。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			// TODO:  添加 WDRW.Insert 实现
			bool ret = true;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			//判断有没有指定领料仓库。
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = WDRWData.NoStorage;
				return false;
			}
			//判断有没有指定用途。
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = WDRWData.NoPurpose;
				return false;
			}
			//判断有没有指定领用部门。
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.ReqDept_Field].ToString() == "-1")
			{
				this.Message = WDRWData.NoDept;
				return false;
			}
			//判断有没有指定领用人。
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PROPOSER_FIELD].ToString().Trim() == "")
			{
				this.Message = WDRWData.NoProposer;
				return false;
			}
			//执行领料单的新建操作。
			ret = oWDRWs.InsertEntry(Entry);
			this.Message = oWDRWs.Message;
			return ret;
		}
		/// <summary>
		/// 领料单的新建并且马上提交。。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  添加 WDRW.Insert 实现
			bool ret = true;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			//判断有没有指定领料仓库。
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.STOCODE_FIELD].ToString() == "-1")
			{
				this.Message = WDRWData.NoStorage;
				return false;
			}
			//判断有没有指定用途。
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = WDRWData.NoPurpose;
				return false;
			}
			//判断有没有指定领用部门。
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.ReqDept_Field].ToString() == "-1")
			{
				this.Message = WDRWData.NoDept;
				return false;
			}
			//判断有没有指定领用人。
			if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PROPOSER_FIELD].ToString().Trim() == "")
			{
				this.Message = WDRWData.NoProposer;
				return false;
			}
			//执行领料单的新建并且马上提交操作。
			ret = oWDRWs.InsertAndPresentEntry(Entry);
			this.Message = oWDRWs.Message;
			return ret;
		}
		/// <summary>
		/// 领料单的修改。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			// TODO:  添加 WDRW.Update 实现
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			//判断领料单修改的前提条件。
			if ( this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId) )
			{
				//判断有没有指定领料仓库。
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.STOCODE_FIELD].ToString() == "-1")
				{
					this.Message = WDRWData.NoStorage;
					return false;
				}
				//判断有没有指定用途。
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WDRWData.NoPurpose;
					return false;
				}
				//判断有没有指定领用部门。
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.ReqDept_Field].ToString() == "-1")
				{
					this.Message = WDRWData.NoDept;
					return false;
				}
				//判断有没有指定领用人。
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PROPOSER_FIELD].ToString().Trim() == "")
				{
					this.Message = WDRWData.NoProposer;
					return false;
				}
				//执行领料单的新建操作。
				ret = oWDRWs.UpdateEntry(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 WDRW.Update 实现
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());
			//判断领料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				//判断有没有指定领料仓库。
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.STOCODE_FIELD].ToString() == "-1")
				{
					this.Message = WDRWData.NoStorage;
					return false;
				}
				//判断有没有指定用途。
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WDRWData.NoPurpose;
					return false;
				}
				//判断有没有指定领用部门。
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.ReqDept_Field].ToString() == "-1")
				{
					this.Message = WDRWData.NoDept;
					return false;
				}
				//判断有没有指定领用人。
				if (oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][WDRWData.PROPOSER_FIELD].ToString().Trim() == "")
				{
					this.Message = WDRWData.NoProposer;
					return false;
				}
				//执行领料单的新建操作。
				ret = oWDRWs.UpdateAndPresentEntry(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			bool ret = true;
			WDRWs oWDRWs = new WDRWs();
			//判断领料单删除的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.Delete))
			{
				ret =  oWDRWs.DeleteEntry(EntryNo);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XDelete;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo,string UserLoginId)
		{
			 bool ret = true;
			WDRWs oWDRWs = new WDRWs();
			//判断领料单删除的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.Delete,UserLoginId))
			{
				ret = oWDRWs.DeleteEntry(EntryNo);
				this.Message = oWDRWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的状态改变。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态 。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 WDRW.UpdateEntryState 实现
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();

			ret = oWDRWs.UpdateEntryState(EntryNo,newState);
			this.Message=oWDRWs.Message;
			return ret;
		}
		/// <summary>
		/// 领料单的一级审批。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  添加 WDRW.FirstAduit 实现
			bool ret = true;
			int EntryNo;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//判断领料单一级审批的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.FirstAudit))
			{
				ret = oWDRWs.FirstAudit(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的二级审批。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  添加 WDRW.SecondAduit 实现
			bool ret = true;
			int EntryNo;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//判断领料单二级审批的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.SecondAudit) )
			{
				ret = oWDRWs.SecondAudit(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XSecondAudit ;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单的三级审批。
		/// </summary>
		/// <param name="Entry">object:	领料单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  添加 WDRW.ThirdAduit 实现
			bool ret = true;
			int EntryNo;
			WDRWs oWDRWs = new WDRWs();
			WDRWData oWDRWData = (WDRWData)Entry;
			EntryNo = Convert.ToInt32(oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//判断领料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.ThirdAudit) )
			{
				ret = oWDRWs.ThirdAudit(Entry);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XThirdAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单提交。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//判断领料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId) )
			{
				ret = oWDRWs.Present(EntryNo, newState, UserLoginId);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//判断领料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Cancel) )
			{
				ret = oWDRWs.Cancel(EntryNo, newState);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单作废。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//判断领料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginId) )
			{
				ret = oWDRWs.Cancel(EntryNo, newState,UserLoginId);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 领料单拒发。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Refuse(int EntryNo, string UserLoginId)
		{
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//判断领料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.O) )
			{
				ret = oWDRWs.DrawRefuse(EntryNo, UserLoginId);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = WDRWData.XRefuse;
				ret = false;
			}
			return ret;
		}
		public bool DRW2PROS(int EntryNo)
		{
			bool ret = true;

			WDRWs oWDRWs = new WDRWs();
			
			//判断领料单修改的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.O) )
			{
				ret = oWDRWs.Draw2Pros(EntryNo);
				this.Message=oWDRWs.Message;
			}
			else
			{
				this.Message = "单据不附和生成请购单条件！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据领料单的流水号来获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  添加 WDRW.GetEntryByEntryNo 实现
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryNo(EntryNo);
			return oWDRWData;
		}

        /// <summary>
        /// 根据领料单的流水号来获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>object:	单据实体。</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            // TODO:  添加 WDRW.GetEntryByEntryNo 实现
            WDRWData oWDRWData;
            WDRWs oWDRWs = new WDRWs();
            oWDRWData = (WDRWData)oWDRWs.GetEntryOldByEntryNo(EntryNo);
            return oWDRWData;
        }

		/// <summary>
		/// 根据领料单的编号来获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  添加 WDRW.GetEntryByEntryCode 实现
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryCode(EntryCode);
			return oWDRWData;
		}
		/// <summary>
		/// 获取所有领料单。
		/// </summary>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryAll()
		{
			// TODO:  添加 WDRW.GetEntryAll 实现
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryAll();
			return oWDRWData;
		}
		/// <summary>
		/// 获取指定制单部门的领料单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  添加 WDRW.GetEntryByDept 实现
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByDept(DeptCode);
			return oWDRWData;
		}

		#endregion

		#region 专有方法
		/// <summary>
		/// 发料模式下获取领料单的内容。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			// TODO:  添加 WDRW.GetEntryByEntryNo 实现
			WDRWData oWDRWData ;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryNoOutMode(EntryNo);
			return oWDRWData;
		}
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
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
			WDRWData oWDRWData;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryNo(EntryNo);	//2005-10-21修改,修改前错误的引用了.GetEntryByEntryNoOutMode方法。
			
			if (oWDRWData.Count > 0)
			{
				EntryState = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				switch (Operation)
				{
					case OP.Edit://编辑。
						if (EntryState == DocStatus.New || 
							EntryState == DocStatus.Cancel || 
							EntryState == DocStatus.FstNoPass || 
							EntryState == DocStatus.SecNoPass ||
							EntryState == DocStatus.TrdNoPass ||
							EntryState == DocStatus.OrdReject
							)
						{
							return true;
						}
						else
						{
							ret = false;
						}
						break;
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
		/// <param name="EntryNo">int:	领料单流水号。</param>
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
			WDRWData oWDRWData;
			WDRWs oWDRWs = new WDRWs();
			oWDRWData = (WDRWData)oWDRWs.GetEntryByEntryNo(EntryNo);   //2005-10-21修改,修改前错误的引用了.GetEntryByEntryNoOutMode方法。

			if (oWDRWData.Count > 0)
			{
				EntryState = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oWDRWData.Tables[WDRWData.WDRW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
				switch (Operation)
				{
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
