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

namespace  Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// 物料需求单的数据实体，沿用了DocBaseData和InItemData的属性。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PMRPData:DataSet
	{
		#region 成员变量
		public const string ADD_FAILED = "物料需求单新增失败！";
		public const string ADD_SUCCESSED = "物料需求单新增成功！";
		public const string UPDATE_FAILED = "物料需求单修改失败！";
		public const string UPDATE_SUCCESSED = "物料需求单修改成功！";
		public const string DELETE_FAILED = "物料需求单删除失败！";
		public const string DELETE_SUCCESSED = "物料需求单删除成功！";
		public const string UPDATESTATE_FAILED = "物料需求单修改状态失败！";
		public const string UPDATESTATE_SUCCESSED = "物料需求单修改状态成功！";
		public const string FIRSTAUDIT_FAILED = "物料需求单一级审批失败！";
		public const string FIRSTAUDIT_SUCCESSED = "物料需求单一级审批成功！";
		public const string SECONDAUDIT_FAILED = "物料需求单二级审批失败！";
		public const string SECONDAUDIT_SUCCESSED = "物料需求单二级审批成功！";
		public const string THIRDAUDIT_FAILED = "物料需求单三级审批失败！";
		public const string THIRDAUDIT_SUCCESSED = "物料需求单三级审批成功！";
		public const string PRESENT_FAILED = "物料需求单提交失败！";
		public const string PRESENT_SUCCESSED = "物料需求单提交成功！";
		public const string CANCEL_FAILED = "物料需求单作废失败！";
		public const string CANCEL_SUCCESSED = "物料需求单作废成功！";
		public const string NOOBJECT = "空对象！";
		public const string NoPurpose = "物料需求单必须要填写用途！";
		public const string NoReqDept = "物料需求单必须要填写申请部门！";
		public const string NoProposer = "物料需求单必须要填写申请人！";
		public const string XUpdate = "物料需求单修改的前提是在单据处于新建，审批不通过，作废的状态下！";
		public const string XPresent = "物料需求单提交的前提是在单据处于新建，审批不通过，作废的状态下！";
		public const string XCancel = "物料需求单作废的前提是在单据处于新建，审批不通过的状态下！";
		public const string XDelete = "物料需求单删除的前提是在单据处于作废的状态下！";
		public const string XFirstAudit = "物料需求单一级审批的前提是在单据处于已提交审批的状态下！";
		public const string XSecondAudit = "物料需求单二级审批的前提是在单据处于一级审批通过的状态下！";
		public const string XThirdAudit = "物料需求单三级审批的前提是在单据处于二级审批通过的状态下！";
		/// <value>单据描述实体</value>
		public const string PMRP_TABLE  = "PMRP";						//表名。
		public const string PROPOSER_FIELD		= "Proposer";			//申请人。
		public const string PROPOSERCODE_FIELD  = "ProposerCode";		//申请人编号。
		public const string REQDEPT_FIELD		= "ReqDept";			//申请部门。
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";		//申请部门名称。
		public const string REQREASONCODE_FIELD = "ReqReasonCode";		//申请理由代码。
		public const string REQREASON_FIELD     = "ReqReason";			//申请理由。
		public const string REQDATE_FIELD       = "ReqDate";			//要求到货日期。
		#endregion

		#region 属性
		public int Count
		{
			get { return this.Tables[PMRPData.PMRP_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建物料需求单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PMRP_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			columns.Add(PROPOSER_FIELD, typeof(System.String));			//申请人。
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//申请人编号。
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//申请部门。
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//申请部门名称。
			columns.Add(REQREASONCODE_FIELD, typeof(System.String));	//申请理由。
			columns.Add(REQREASON_FIELD, typeof(System.String));		//申请理由。
			columns.Add(REQDATE_FIELD, typeof(System.String));			//要求到货日期。
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private PMRPData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public PMRPData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
