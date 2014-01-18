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

namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// 采购计划的实体层。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PurchasePlanData : DataSet
	{
		#region 返回信息
		public const string NOOBJECT = "空对象。";
		public const string ADD_FAILED = "采购计划新建失败！";
		public const string ADD_SUCCESSED = "采购计划新建成功！";
		public const string UPDATE_FAILED = "采购计划修改失败！";
		public const string UPDATE_SUCCESSED = "采购计划修改成功！";
		public const string DELETE_FAILED = "采购计划删除失败！";
		public const string DELETE_SUCCESSED = "采购计划删除成功！";
		public const string UPDATESTATE_FAILED = "采购计划修改状态失败！";
		public const string UPDATESTATE_SUCCESSED = "采购计划修改状态成功！";
		public const string FIRSTAUDIT_FAILED = "采购计划一级审批失败！";
		public const string FIRSTAUDIT_SUCCESSED = "采购计划一级审批成功！";
		public const string SECONDAUDIT_FAILED = "采购计划二级审批失败！";
		public const string SECONDAUDIT_SUCCESSED = "采购计划二级审批成功！";
		public const string THIRDAUDIT_FAILED = "采购计划三级审批失败！";
		public const string THIRDAUDIT_SUCCESSED = "采购计划三级审批成功！";
		public const string PRESENT_FAILED = "采购计划提交失败！";
		public const string PRESENT_SUCCESSED = "采购计划提交成功！";
		public const string CANCEL_FAILED = "采购计划作废失败！";
		public const string CANCEL_SUCCESSED = "采购计划作废成功！";
		public const string XUpdate = "采购计划修改的前提是，采购计划处于新建、审批不通过、作废的状态。";
		public const string XPresent = "采购计划提交的前提是，采购计划处于新建、审批不通过、作废的状态。";
		public const string XUpdatePresent = "采购计划修改并且提交的前提是，采购计划必须处于新建、作废、审批不通过的状态。";
		public const string XDelete = "采购计划删除的前提是，采购计划处于作废状态。";
		public const string XCancel = "采购计划作废的前提是，采购计划处于新建、审批不通过的状态。";
		public const string XFirstAudit = "采购计划一级审批的前提是，采购计划处于提交的状态。";
		public const string XSecondAudit = "采购计划二级审批的前提是，采购计划处于一级审批通过的状态。";
		public const string XThirdAudit = "采购计划三级审批的前提是，采购计划处于二级审批通过的状态。";
		#endregion

		#region 成员变量
		public const string PPLN_TABLE = "PPLN";//表名。
		public const string SOURCEENTRY_FIELD = "SourceEntry";		//源单据流水号。
		public const string SOURCEDOCCODE_FIELD = "SourceDocCode";	//源单据类型。
		public const string PLANDATE_FIELD = "PlanDate";			//计划日期。
		public const string ITEMLACKNUM_FIELD = "ItemLackNum";		//未生成采购订单的数量。
		public const string REQDEPT_FIELD = "ReqDept";				//申请部门。
		public const string REQDEPTNAME_FIELD = "ReqDeptName";		//申请部门名称。
		public const string REQREASONCODE_FIELD = "ReqReasonCode";	//用途编号。
		public const string REQREASON_FIELD = "ReqReason";			//用途。
		public const string REQDATE_FIELD = "ReqDate";				//要求日期。
		public const string Proposer_Field = "Proposer";
		public const string ReqEntryDate_Field = "ReqEntryDate";
		#endregion

		#region 属性
		public int Count
		{
			get { return this.Tables[PurchasePlanData.PPLN_TABLE].Rows.Count; }
		}
		#endregion

		#region 私有方法
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PPLN_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			
			columns.Add(PurchasePlanData.SOURCEENTRY_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.SOURCEDOCCODE_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.PLANDATE_FIELD,	typeof(System.DateTime));
			columns.Add(PurchasePlanData.ITEMLACKNUM_FIELD, typeof(System.Decimal));
			columns.Add(PurchasePlanData.REQDEPT_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.REQDEPTNAME_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.REQREASONCODE_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.REQREASON_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.REQDATE_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.Proposer_Field, typeof(System.String));
			columns.Add(PurchasePlanData.ReqEntryDate_Field, typeof(System.DateTime));
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private PurchasePlanData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PurchasePlanData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
