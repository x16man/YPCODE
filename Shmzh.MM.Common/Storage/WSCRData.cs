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
* penalties.  Any violations of this copyright will be WSCRecuted       *
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
	/// WSCRData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WSCRData:DataSet
	{
		#region 返回信息
		public const string NOOBJECT = "";
		public const string ADD_FAILED = "";
		public const string ROLL_FAILED ="";
		public const string ADD_SUCCESSED = "";
		public const string UPDATE_FAILED = "";
		public const string UPDATE_SUCCESSED = "";
		public const string DELETE_FAILED = "";
		public const string DELETE_SUCCESSED = "";
		public const string UPDATESTATE_FAILED = "";
		public const string UPDATESTATE_SUCCESSED = "";
		public const string FIRSTAUDIT_FAILED = "";
		public const string FIRSTAUDIT_SUCCESSED = "";
		public const string SECONDAUDIT_FAILED = "";
		public const string SECONDAUDIT_SUCCESSED = "";
		public const string THIRDAUDIT_FAILED = "";
		public const string THIRDAUDIT_SUCCESSED = "";
		public const string PRESENT_FAILED = "";
		public const string PRESENT_SUCCESSED = "";
		public const string CANCEL_FAILED = "";
		public const string CANCEL_SUCCESSED = "";
		public const string AFFIRM_SUCCESSED = "";
		public const string AFFIRM_FAILED = "";
		#endregion

		#region 成员变量
		/// <value>单据描述实体</value>
		public const string WSCR_TABLE  = "WSCR";						//表名。
		public const string PROPOSER_FIELD		= "Proposer";			//申请人。
		public const string PROPOSERCODE_FIELD  = "ProposerCode";		//申请人编号。
		public const string REQDEPT_FIELD		= "ReqDept";			//申请部门。
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";		//申请部门名称。
		public const string REQREASONCODE_FIELD = "ReqReasonCode";		//申请理由代码。
		public const string REQREASON_FIELD     = "ReqReason";			//申请理由。
		public const string PLANNUM_FIELD			= "PlanNum";		//应废数量
		public const string STOCKNUM_FIELD       = "StockNum";				//当前库存。
		public const string STONAME_FIELD		= "StoName";
		public const string	STOCODE_FIELD		= "StoCode";
		public const string NoPurpose = "采购申请单必须要指定用途！";
		public const string NoReqDept = "采购申请单必须指定申请部门！";
		public const string NoProposer = "采购申请单必须指定申请人！";
		public const string XDelete = "只有在作废的状态下才允许删除！";
		public const string XCancel = "只有在新建或者审批不通过的前提下，才允许对单据进行作废操作！";
		public const string XPresent = "只有在新建或者审批不通过的前提下，才允许对单据进行提交操作！";
		public const string XFirstAudit = "只有在单据已经提交的状态下，才允许对单据进行一级审批！";
		public const string XSecondAudit = "只有在单据一级审批通过的前提下，才允许对单据进行二级审批！";
		public const string XThirdAudit = "只有在单据二级审批通过的前提下，才允许对单据进行三级审批！";
		public const string XUpdate = "只有在单据在新建,作废,审批不通过的前提下，才允许对单据进行修改！";
		#endregion

		#region 属性
		/// <summary>
		/// 采购申请单的记录数。
		/// </summary>
		public int Count
		{
			get { return this.Tables[WSCRData.WSCR_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建采购申请单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(WSCR_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;

			columns.Add(PROPOSER_FIELD, typeof(System.String));			//申请人。
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//申请人编号。
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//申请部门。
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//申请部门名称。
			columns.Add(REQREASONCODE_FIELD, typeof(System.String));	//申请理由。
			columns.Add(REQREASON_FIELD, typeof(System.String));		//申请理由。
			columns.Add(PLANNUM_FIELD, typeof(System.String));			//应废数量。
			columns.Add(STOCKNUM_FIELD, typeof(System.String));
			columns.Add(STONAME_FIELD, typeof(System.String));
			columns.Add(STOCODE_FIELD, typeof(System.String ));
				
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private WSCRData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WSCRData()
		{
			BuildDataTables();
		}
		#endregion
		
		
	}
}
