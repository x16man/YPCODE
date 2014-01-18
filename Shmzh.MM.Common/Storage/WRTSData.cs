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
	/// 生产退料单的数据实体，沿用了DocBaseData和InItemData的属性。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WRTSData:DataSet
	{
		#region 成员变量
		public const string ADD_FAILED = "生产退料单新建失败！";
		public const string ADD_SUCCESSED = "生产退料单新建失败！";
		public const string UPDATE_FAILED = "生产退料单修改失败！";
		public const string UPDATE_SUCCESSED = "生产退料单修改失败！";
		public const string DELETE_FAILED = "生产退料单删除失败！";
		public const string DELETE_SUCCESSED = "生产退料单删除失败！";
		public const string UPDATESTATE_FAILED = "生产退料单更新状态失败！";
		public const string UPDATESTATE_SUCCESSED = "生产退料单更新状态失败！";
		public const string FIRSTAUDIT_FAILED = "生产退料单部门审批失败！";
		public const string FIRSTAUDIT_SUCCESSED = "生产退料单部门审批失败！";
		public const string SECONDAUDIT_FAILED = "生产退料单财务审批失败！";
		public const string SECONDAUDIT_SUCCESSED = "生产退料单财务审批失败！";
		public const string THIRDAUDIT_FAILED = "生产退料单厂部审批失败！";
		public const string THIRDAUDIT_SUCCESSED = "生产退料单厂部审批失败！";
		public const string PRESENT_FAILED = "生产退料单提交失败！";
		public const string PRESENT_SUCCESSED = "生产退料单提交失败！";
		public const string CANCEL_FAILED = "生产退料单作废失败！";
		public const string CANCEL_SUCCESSED = "生产退料单作废失败！";
		public const string CHKCK_SUCCESSED = "生产退料单验收失败！";
        public const string CHECK_FAILED = "生产退料单验收失败！";
		public const string NOOBJECT = "空对象！";
		public const string XUpdate = "生产退料单修改前提是，单据处于新建、审批不通过、作废的状态！";
		public const string XPresent = "生产退料单提交的前提是，单据处于新建、审批不通过、作废的状态！";
		public const string XCancel = "生产退料单作废的前提是，单据处于新建、审批不通过的状态！";
		public const string XDelete = "生产退料单删除的前提是，单据处于作废的状态！";
		public const string XFirstAudit = "生产退料单一级审批的前提是，单据处于提交的状态！";
		public const string XSecondAudit = "生产退料单二级审批的前提是，单据处于一级审批通过的状态！";
		public const string XThirdAudit = "生产退料单三级审批的前提是，单据处于二级审批通过的状态！";
		public const string XReceive= "生产退料单收料的前提是，单据处于审批通过的状态！";
		public const string RECEIVE_FAILED = "生产退料单收料失败";
		public const string RECEIVE_SUCCESSED ="生产退料单收料成功";
		public const string NO_STO = "生产退料单必须要选择仓库！";
		public const string NO_AUDIT_VALUE = "请选择通过审批或不通过审批，也可以选择取消操作！";

		/// <value>单据描述实体</value>
		public const string WRTS_TABLE           = "WRTS";            //表名。
		public const string STOMANAGERCODE_FIELD = "StoManagerCode";  //仓库管理员代码
		public const string STOMANAGER_FIELD     = "StoManager";      //仓库管理员
		public const string DRAWDATE_FIELD       = "DrawDate";        //发料日期
		
		public const string SOURCEENTRY_FIELD    = "SourceEntry";     //源单据流水号
		public const string SOURCEDOCCODE_FIELD  = "SourceDocCode";   //源单据类型
		public const string SOURCESERIALNO_FIELD = "SourceSerialNo";  //源序号。
		
		public const string REQREASONCODE_FIELD  = "ReqReasonCode";   //用途编号
		public const string REQREASON_FIELD      = "ReqReason";       //用途名称
		public const string STOCODE_FIELD        = "StoCode";         //仓库编号
		public const string STONAME_FIELD        = "StoName";         //仓库名称
		public const string PLANNUM_FIELD        = "PlanNum";         //请领数量

		public const string PROPOSER_FIELD       = "Proposer";        //申请人
		public const string PROPOSERCODE_FIELD   = "ProposerCode";    //申请人编号
		public const string REQDEPT_FIELD        = "ReqDept";         //申请部门编号
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";     //申请部门编号
		public const string JFKM_FIELD           = "JFKM";            //借方科目
		public const string CHKNO_FIELD          = "ChkNo";           //验收单编号
		public const string CHKRESULT_FIELD      = "ChkResult";       //验收结果
		public const string CHKDATE_FIELD        = "ChkDate";         //验收日期
		public const string CHKMANCODE_FIELD     = "ChkManCode";      //验收人代码
		public const string CHKMANNAME_FIELD	 = "ChkMan";		  //验收人
		public const string CONCODE_FIELD		 = "ConCode";		  //架位号。
		public const string CONNAME_FIELD		 = "ConName";		  //架位名称。
		
		#endregion

		#region 属性
		/// <summary>
		/// 行数属性。
		/// </summary>
		public int Count
		{
			get { return this.Tables[WRTSData.WRTS_TABLE].Rows.Count;}
		}
		#endregion
		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建生产退料单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table = new DataTable(WRTS_TABLE);
			InItemData oItemData = new InItemData(table);

			DataColumnCollection columns = table.Columns;
			columns.Add(STOMANAGERCODE_FIELD,typeof(System.String));  //仓库管理员代码
			columns.Add(STOMANAGER_FIELD,typeof(System.String));      //仓库管理员
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));      //发料日期
			
			columns.Add(SOURCEENTRY_FIELD,typeof(System.String));      //源单据流水号
			columns.Add(SOURCEDOCCODE_FIELD,typeof(System.String));    //源单据类型
			columns.Add(SOURCESERIALNO_FIELD, typeof(System.String));  //源单据序号。
			
			columns.Add(REQREASONCODE_FIELD,typeof(System.String));   //用途编号
			columns.Add(REQREASON_FIELD,typeof(System.String));       //用途名称
			columns.Add(STOCODE_FIELD,typeof(System.String));         //仓库编号
			columns.Add(STONAME_FIELD,typeof(System.String));         //仓库名称
			columns.Add(PLANNUM_FIELD,typeof(System.String));         //请领数量

			columns.Add(PROPOSER_FIELD,typeof(System.String));        //申请人
			columns.Add(PROPOSERCODE_FIELD,typeof(System.String));    //申请人编号
			columns.Add(REQDEPT_FIELD,typeof(System.String));		  //申请部门编号
			columns.Add(REQDEPTNAME_FIELD,typeof(System.String));     //申请部门名称
			columns.Add(JFKM_FIELD,typeof(System.String));            //借方科目
			columns.Add(CHKNO_FIELD,typeof(System.String));           //验收单编号
			columns.Add(CHKRESULT_FIELD,typeof(System.String));       //验收结果
			columns.Add(CHKDATE_FIELD,typeof(System.DateTime));       //验收日期
			columns.Add(CHKMANCODE_FIELD,typeof(System.String));      //验收人编号
			columns.Add(CHKMANNAME_FIELD,typeof(System.String));	  //验收人
			columns.Add(CONCODE_FIELD, typeof(System.String));		  //架位号。
			columns.Add(CONNAME_FIELD, typeof(System.String));		  //架位名称。
			
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private WRTSData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WRTSData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
