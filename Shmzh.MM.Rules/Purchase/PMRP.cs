
namespace Shmzh.MM.BusinessRules
{
	using System;
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;

	/// <summary>
	/// 物料需求单的业务规则层。
	/// </summary>
	public class PMRP :Messages,IInItem
	{
        private IList<GrantInfo> grantinfo;
        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grant = new Grant();
		#region 构造函数
		public PMRP()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region IInItem 成员
		/// <summary>
		/// 物料需求单的增加。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(object Entry)
		{
			// TODO:  添加 PMRP.Insert 实现
			bool ret = true;
			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)Entry;
			//判断是否填写了用途。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = PMRPData.NoPurpose;
				return false;
			}
			//判断是否填写了申请部门。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQDEPT_FIELD].ToString() == "-1")
			{
				this.Message = PMRPData.NoReqDept;
				return false;
			}
			//判断是否填写了申请人。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.PROPOSER_FIELD].ToString().Trim() == "")
			{
				this.Message = PMRPData.NoProposer;
				return false;
			}
			//执行新增操作。
			ret = oPMRPs.InsertEntry(Entry);
			this.Message=oPMRPs.Message;
			return ret;
		}
		/// <summary>
		/// 物料需求单的增加并且提交。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(object Entry)
		{
			// TODO:  添加 PMRP.Insert 实现
			bool ret = true;

			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)Entry;
			//判断是否填写了用途。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "-1" ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "")
			{
				this.Message = PMRPData.NoPurpose;
				return false;
			}
			//判断是否填写了申请部门。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQDEPT_FIELD].ToString() == "-1")
			{
				this.Message = PMRPData.NoReqDept;
				return false;
			}
			//判断是否填写了申请人。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.PROPOSER_FIELD].ToString().Trim() == "")
			{
				this.Message = PMRPData.NoProposer;
				return false;
			}
			//执行新增并且提交操作。
			ret = oPMRPs.InsertAndPresentEntry(Entry);
			this.Message=oPMRPs.Message;
			return ret;
		}
		/// <summary>
		/// 物料需求单的修改。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(object Entry)
		{
			// TODO:  添加 PMRP.Update 实现
			bool ret = true;
			int EntryNo;
			string UserLoginId;

			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)Entry;
			
			EntryNo = Convert.ToInt32(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

//			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				//判断是否填写了用途。
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = PMRPData.NoPurpose;
					return false;
				}
				//判断是否填写了申请部门。
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = PMRPData.NoReqDept;
					return false;
				}
				//判断是否填写了申请人。
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.PROPOSER_FIELD].ToString().Trim() == "")
				{
					this.Message = PMRPData.NoProposer;
					return false;
				}
				//执行修改操作。
				ret = oPMRPs.UpdateEntry(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "您无权进行此操作!";
				return false;
			}
		}
		/// <summary>
		/// 物料需求单的修改并且提交。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(object Entry)
		{
			// TODO:  添加 PMRP.Update 实现
			bool ret = true;
			int EntryNo;
			string UserLoginId;
			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)Entry;

			EntryNo = Convert.ToInt32(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
			UserLoginId = Convert.ToString(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString());

//			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
//			
//			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Edit, UserLoginId))
			{
				oPMRPData = (PMRPData)Entry;
				//判断是否填写了用途。
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "-1" ||
					oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString() == "")
				{
					this.Message = PMRPData.NoPurpose;
					return false;
				}
				//判断是否填写了申请部门。
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.REQDEPT_FIELD].ToString() == "-1")
				{
					this.Message = PMRPData.NoReqDept;
					return false;
				}
				//判断是否填写了申请人。
				if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][PMRPData.PROPOSER_FIELD].ToString().Trim() == "")
				{
					this.Message = PMRPData.NoProposer;
					return false;
				}
				//执行修改并且提交操作。
				ret = oPMRPs.UpdateAndPresentEntry(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "您无权进行此操作!";
				return false;
			}
		}
		/// <summary>
		/// 物料需求单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo)
		{
			// TODO:  添加 PMRP.Delete 实现
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
			//判断是否符合删除的条件，只有处于作废状态的单据才被允许删除。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel)
			{
				ret = oPMRPs.DeleteEntry(EntryNo);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XDelete;
				return false;
			}
		}
		/// <summary>
		/// 物料需求单的删除。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(int EntryNo, string UserLoginId)
		{
			// TODO:  添加 PMRP.Delete 实现
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
			//判断是否符合删除的条件，只有处于作废状态的单据才被允许删除。
			if (this.CheckPreCondition(EntryNo, OP.Delete, UserLoginId))
			{
				ret = oPMRPs.DeleteEntry(EntryNo);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "您无权进行此操作!";
				return false;
			}
		}
		/// <summary>
		/// 物料需求单的状态改变。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="newState">string:	新状态 。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			// TODO:  添加 PMRP.UpdateEntryState 实现
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			
			ret = oPMRPs.UpdateEntryState(EntryNo,newState);
			this.Message=oPMRPs.Message;
			return ret;
			
		}
		/// <summary>
		/// 物料需求单的一级审批。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool FirstAudit(object Entry)
		{
			// TODO:  添加 PMRP.FirstAduit 实现
			bool ret = true;
			
			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)Entry;
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断是否符合一级审批的条件，只有处于提交状态的单据才被允许一级审批。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
			{
				ret = oPMRPs.FirstAudit(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XFirstAudit;
				return false;
			}
		}

        public bool IsAuditDept(string strEmpCode, int EntryNo)
        {
            PMRPs oPMRPs = new PMRPs();
            return oPMRPs.IsAuditDept(strEmpCode, EntryNo);
        }
		/// <summary>
		/// 物料需求单的二级审批。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool SecondAudit(object Entry)
		{
			// TODO:  添加 PMRP.SecondAduit 实现
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)Entry;
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断是否符合二级审批的条件，只有处于一级审批通过状态的单据才被允许二级审批。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
			{
				ret = oPMRPs.SecondAudit(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XSecondAudit;
				return false;
			}
		}
		/// <summary>
		/// 物料需求单的三级审批。
		/// </summary>
		/// <param name="Entry">object:	物料需求单实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ThirdAudit(object Entry)
		{
			// TODO:  添加 PMRP.ThirdAduit 实现
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)Entry;
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString()));
			//判断是否符合三级审批的条件，只有处于二级审批通过状态的单据才被允许三级审批。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
			{
				ret = oPMRPs.ThirdAudit(Entry);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XThirdAudit;
				return false;
			}
		}
		/// <summary>
		/// 物料需求单提交。
		/// </summary>
		/// <param name="EntryNo">int:	物料需求单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
//			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
//			//判断是否符合提交的条件，只有处于新建、审批不通过、作废状态的单据才被允许提交。
//			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Submit, UserLoginId))
			{
				ret = oPMRPs.Present(EntryNo, newState, UserLoginId);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "您无权进行此操作!";
				return false;
			}
		}
		/// <summary>
		/// 物料需求单作废。
		/// </summary>
		/// <param name="EntryNo">int:	物料需求单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
			//判断是否符合作废的条件，只有处于新建、审批不通过、通过状态的单据才被允许二级审批。
			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			{
				ret = oPMRPs.Cancel(EntryNo, newState);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = PMRPData.XCancel;
				return false;
			}
		}
		/// <summary>
		/// 物料需求单作废。
		/// </summary>
		/// <param name="EntryNo">int:	物料需求单流水号。</param>
		/// <param name="newState">string:	新状态。</param>
		/// <param name="UserLoginID">string:	operator.</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;

			PMRPs oPMRPs = new PMRPs();
//			PMRPData oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
//			//判断是否符合作废的条件，只有处于新建、审批不通过、通过状态的单据才被允许二级审批。
//			if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
//				oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
			if (this.CheckPreCondition(EntryNo, OP.Cancel, UserLoginID))
			{
				ret = oPMRPs.Cancel(EntryNo, newState, UserLoginID);
				this.Message=oPMRPs.Message;
				return ret;
			}
			else
			{
				this.Message = "您无权进行此操作!";
				return false;
			}
		}
		/// <summary>
		/// 根据物料需求单的流水号来获取单据。
		/// </summary>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			// TODO:  添加 PMRP.GetEntryByEntryNo 实现
			PMRPData oPMRPData ;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);
			return oPMRPData;
		}
		/// <summary>
		/// 根据物料需求单的编号来获取单据。
		/// </summary>
		/// <param name="EntryCode">string:	单据编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			// TODO:  添加 PMRP.GetEntryByEntryCode 实现
			PMRPData oPMRPData ;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryCode(EntryCode);
			return oPMRPData;
		}
		/// <summary>
		/// 获取所有物料需求单。
		/// </summary>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryAll()
		{
			// TODO:  添加 PMRP.GetEntryAll 实现
			PMRPData oPMRPData ;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryAll();
			return oPMRPData;
		}
		/// <summary>
		/// 获取指定制单部门的物料需求单。
		/// </summary>
		/// <param name="DeptCode">string:	制单部门编号。</param>
		/// <returns>object:	单据实体。</returns>
		public object GetEntryByDept(string DeptCode)
		{
			// TODO:  添加 PMRP.GetEntryByDept 实现
			PMRPData oPMRPData ;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryByDept(DeptCode);
			return oPMRPData;
		}

		#endregion
		#region 专用方法
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="EntryNo">int:	物料需求单流水号。</param>
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
			PMRPData oPMRPData;
			PMRPs oPMRPs = new PMRPs();
			oPMRPData = (PMRPData)oPMRPs.GetEntryByEntryNo(EntryNo);   

			if (oPMRPData.Count > 0)
			{
				EntryState = oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				AuthorLoginID = oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString();
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
							//Grants oG = new Grants();
                           
							//oG.GetEmbracersByGrantor(AuthorLoginID);
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
