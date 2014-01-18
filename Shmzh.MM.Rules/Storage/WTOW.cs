
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	/// <summary>
	/// 委外加工申请单的业务规则层。
	/// </summary>
	public class WTOW :Messages,IInItem
	{
		#region 构造函数
		public WTOW()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 委外加工申请单的增加。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			// TODO:  添加 WTOW.Insert 实现
			bool ret = true;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
//			//判断有没有指定领料仓库。
//			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.STOCODE_FIELD].ToString() == "-1")
//			{
//				this.Message = WTOWData.NoStorage;
//				return false;
//			}
			//判断有没有指定用途。
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = WTOWData.NoPurpose;
				return false;
			}
			//判断有没有指定领用部门。
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
			{
				this.Message = WTOWData.NoDept;
				return false;
			}
			//判断有没有指定领用人。
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
			{
				this.Message = WTOWData.NoProposer;
				return false;
			}
			//执行委外加工申请单的新建操作。
			ret = oWTOWs.InsertEntry(Entry);
			this.Message = oWTOWs.Message;
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的新建并且马上提交。。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  添加 WTOW.Insert 实现
			bool ret = true;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
//			//判断有没有指定领料仓库。
//			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.STOCODE_FIELD].ToString() == "-1")
//			{
//				this.Message = WTOWData.NoStorage;
//				return false;
//			}
			//判断有没有指定用途。
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = WTOWData.NoPurpose;
				return false;
			}
			//判断有没有指定领用部门。
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
			{
				this.Message = WTOWData.NoDept;
				return false;
			}
			//判断有没有指定领用人。
			if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
			{
				this.Message = WTOWData.NoProposer;
				return false;
			}
			//执行委外加工申请单的新建并且马上提交操作。
			ret = oWTOWs.InsertAndPresentEntry(Entry);
			this.Message = oWTOWs.Message;
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的修改。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			// TODO:  添加 WTOW.Update 实现
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//判断委外加工申请单修改的前提条件。
			if ( this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId) )
			{
//				//判断有没有指定领料仓库。
//				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.STOCODE_FIELD].ToString() == "-1")
//				{
//					this.Message = WTOWData.NoStorage;
//					return false;
//				}
				//判断有没有指定用途。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WTOWData.NoPurpose;
					return false;
				}
				//判断有没有指定领用部门。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = WTOWData.NoDept;
					return false;
				}
				//判断有没有指定领用人。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
				{
					this.Message = WTOWData.NoProposer;
					return false;
				}
				//执行委外加工申请单的新建操作。
				ret = oWTOWs.UpdateEntry(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XUpdate;
				ret = false;
			}
			return ret;
		}
		public bool StockOut(object Entry)
		{
			// TODO:  添加 WTOW.Update 实现
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//判断委外加工申请单发料的前提条件。
			if ( this.CheckPreCondition(EntryNo, OP.O, UserLoginId) )
			{
				//判断有没有指定用途。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WTOWData.NoPurpose;
					return false;
				}
				//判断有没有指定领用部门。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = WTOWData.NoDept;
					return false;
				}
				//判断有没有指定领用人。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
				{
					this.Message = WTOWData.NoProposer;
					return false;
				}
				//执行委外加工申请单的新建操作。
				ret = oWTOWs.StockOut(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;			
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的修改并且马上提交。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 WTOW.Update 实现
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

			//判断委外加工申请单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
//				//判断有没有指定领料仓库。
//				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.STOCODE_FIELD].ToString() == "-1")
//				{
//					this.Message = WTOWData.NoStorage;
//					
//					return false;
//				}
				//判断有没有指定用途。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = WTOWData.NoPurpose;
					return false;
				}
				//判断有没有指定领用部门。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = WTOWData.NoDept;
					return false;
				}
				//判断有没有指定领用人。
				if (oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][WTOWData.PROPOSERNAME_FIELD].ToString().Trim() == "")
				{
					this.Message = WTOWData.NoProposer;
					return false;
				}
				//执行委外加工申请单的新建操作。
				ret = oWTOWs.UpdateAndPresentEntry(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XUpdate;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			bool ret = true;
			WTOWs oWTOWs = new WTOWs();
			//判断委外加工申请单删除的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.Delete))
			{
				ret =  oWTOWs.DeleteEntry(EntryNo);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XDelete;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="UserLoginId">string:	用户。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			bool ret = true;
			WTOWs oWTOWs = new WTOWs();
			//判断委外加工申请单删除的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				ret =  oWTOWs.DeleteEntry(EntryNo);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的状态改变。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态 。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 WTOW.UpdateEntryState 实现
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();

			ret = oWTOWs.UpdateEntryState(EntryNo,newState);
			this.Message=oWTOWs.Message;
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的一级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  添加 WTOW.FirstAduit 实现
			bool ret = true;
			int EntryNo;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//判断委外加工申请单一级审批的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.FirstAudit))
			{
				ret = oWTOWs.FirstAudit(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XFirstAudit;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的二级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  添加 WTOW.SecondAduit 实现
			bool ret = true;
			int EntryNo;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//判断委外加工申请单二级审批的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.SecondAudit) )
			{
				ret = oWTOWs.SecondAudit(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XSecondAudit ;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单的三级审批。
		/// </summary>
		/// <param name="Entry">object:	委外加工申请单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  添加 WTOW.ThirdAduit 实现
			bool ret = true;
			int EntryNo;
			WTOWs oWTOWs = new WTOWs();
			WTOWData oWTOWData = (WTOWData)Entry;
			EntryNo = Convert.ToInt32(oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			//判断委外加工申请单修改的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.ThirdAudit) )
			{
				ret = oWTOWs.ThirdAudit(Entry);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XThirdAudit;
				ret = false;
			}
			return ret;
		}
		
		/// <summary>
		/// 委外加工申请单提交。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();
			
			//判断委外加工申请单修改的前提条件。
			if (this.CheckPreCondition(EntryNo,OP.Submit, UserLoginId) )
			{
				ret = oWTOWs.Present(EntryNo, newState, UserLoginId);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();
			
			//判断委外加工申请单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Cancel) )
			{
				ret = oWTOWs.Cancel(EntryNo, newState);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XCancel;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单作废。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();
			
			//判断委外加工申请单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginId) )
			{
				ret = oWTOWs.Cancel(EntryNo, newState,UserLoginId);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = "您无权进行此操作！";
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 委外加工申请单拒发。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
		/// <param name="UserLoginId">string:	用户登录名。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Refuse(int EntryNo, string UserLoginId)
		{
			bool ret = true;

			WTOWs oWTOWs = new WTOWs();
			
			//判断委外加工申请单修改的前提条件。
			if (this.CheckPreCondition(EntryNo, OP.O) )
			{
				ret = oWTOWs.DrawRefuse(EntryNo, UserLoginId);
				this.Message=oWTOWs.Message;
			}
			else
			{
				this.Message = WTOWData.XRefuse;
				ret = false;
			}
			return ret;
		}
		/// <summary>
		/// 根据委外加工申请单的流水号来获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  添加 WTOW.GetEntryByEntryNo 实现
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryNo(EntryNo);
			return oWTOWData;
		}

        /// <summary>
        /// 根据委外加工申请单的流水号来获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>object:	单据实体。</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            // TODO:  添加 WTOW.GetEntryByEntryNo 实现
            WTOWData oWTOWData;
            WTOWs oWTOWs = new WTOWs();
            oWTOWData = (WTOWData)oWTOWs.GetEntryOldByEntryNo(EntryNo);
            return oWTOWData;
        }

        /// <summary>
        /// 根据委外加工申请单的流水号来获取单据。
        /// </summary>
        /// <param name="EntryNo">int:	单据流水号。</param>
        /// <returns>object:	单据实体。</returns>
        public object GetEntryRedByEntryNo(int EntryNo)
        {
            // TODO:  添加 WTOW.GetEntryByEntryNo 实现
            WTOWData oWTOWData;
            WTOWs oWTOWs = new WTOWs();
            oWTOWData = (WTOWData)oWTOWs.GetEntryRedByEntryNo(EntryNo);
            return oWTOWData;
        }
		/// <summary>
		/// 根据委外加工申请单的编号来获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  添加 WTOW.GetEntryByEntryCode 实现
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryCode(EntryCode);
			return oWTOWData;
		}
		/// <summary>
		/// 获取所有委外加工申请单。
		/// </summary>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryAll()
		{
			// TODO:  添加 WTOW.GetEntryAll 实现
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryAll();
			return oWTOWData;
		}
		public object GetEntryAll(string UserLoginId)
		{
			WTOWData oWTOWData;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryAll(UserLoginId);
			return oWTOWData;
		}

        public object GetEntryByPerson(string Empcode)
        {
            WTOWData oWTOWData;
            WTOWs oWTOWs = new WTOWs();
            oWTOWData = (WTOWData)oWTOWs.GetEntryByPerson(Empcode);
            return oWTOWData;
        }

		/// <summary>
		/// 获取指定制单部门的委外加工申请单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  添加 WTOW.GetEntryByDept 实现
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByDept(DeptCode);
			return oWTOWData;
		}

		#endregion

		#region 专有方法
		/// <summary>
		/// 发料模式下获取委外加工申请单的内容。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WTOWData oWTOWData ;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryNoOutMode(EntryNo);
			return oWTOWData;
		}
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
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
			WTOWData oWTOWData;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryNo(EntryNo);	//2005-10-21修改,修改前错误的引用了.GetEntryByEntryNoOutMode方法。

			if (oWTOWData.Count > 0)
			{
				EntryState = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
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
							ret = true;
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
		/// <param name="EntryNo">int:	委外加工申请单流水号。</param>
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
			WTOWData oWTOWData;
			WTOWs oWTOWs = new WTOWs();
			oWTOWData = (WTOWData)oWTOWs.GetEntryByEntryNo(EntryNo);   

			if (oWTOWData.Count > 0)
			{
				EntryState = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oWTOWData.Tables[WTOWData.WTOW_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
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
