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
	/// 委外加工申请单的数据实体，沿用了DocBaseData和InItemData的属性。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WTOWData:DataSet
	{
		#region 成员变量
		public const string ADD_FAILED = "委外加工申请单新建失败！";
		public const string ADD_SUCCESSED = "委外加工申请单新建成功！";
		public const string UPDATE_FAILED = "委外加工申请单修改失败！";
		public const string UPDATE_SUCCESSED = "委外加工申请单修改成功！";
		public const string DELETE_FAILED = "委外加工申请单删除失败！";
		public const string DELETE_SUCCESSED = "委外加工申请单删除成功！";
		public const string UPDATESTATE_FAILED = "委外加工申请单修改状态失败！";
		public const string UPDATESTATE_SUCCESSED = "委外加工申请单修改状态成功！";
		public const string FIRSTAUDIT_FAILED = "委外加工申请单一级审批失败！";
		public const string FIRSTAUDIT_SUCCESSED = "委外加工申请单一级审批成功！";
		public const string SECONDAUDIT_FAILED = "委外加工申请单二级审批失败！";
		public const string SECONDAUDIT_SUCCESSED = "委外加工申请单二级审批成功！";
		public const string THIRDAUDIT_FAILED = "委外加工申请单三级审批失败！";
		public const string THIRDAUDIT_SUCCESSED = "委外加工申请单三级审批成功！";
		public const string PRESENT_FAILED = "委外加工申请单提交失败！";
		public const string PRESENT_SUCCESSED = "委外加工申请单提交成功！";
		public const string CANCEL_FAILED = "委外加工申请单作废失败！";
		public const string CANCEL_SUCCESSED = "委外加工申请单作废成功！";
		public const string NOOBJECT = "空对象！";
		public const string OUT_FAILED= "委外加工申请单发料失败！";
		public const string OUT_SUCCESSED = "委外加工申请单发料成功！";
		public const string Refuse_Failed = "委外加工申请单拒发失败！";
		public const string Refuse_Success = "委外加工申请单拒发成功！";
		public const string NoStorage = "委外加工申请单必须要指定领料仓库！";
		public const string NoPurpose = "委外加工申请单必须要指定用途！";
		public const string NoDept = "委外加工申请单必须要指定领用部门！";
		public const string NoProposer = "委外加工申请单必须要指定领用人！";
		public const string XUpdate = "委外加工申请单修改的前提是，单据处于新建、作废、审批不通过的状态。";
		public const string XCancel = "委外加工申请单修改的前提是，单据处于新建、审批不通过的状态。";
		public const string XDelete = "委外加工申请单删除的前提是，单据处于作废的状态。";
		public const string XPresent = "委外加工申请单提交的前提是，单据处于新建、作废、审批不通过的状态。";
		public const string XFirstAudit = "委外加工申请单一级审批的前提是，单据处于提交的状态。";
		public const string XSecondAudit = "委外加工申请单二级审批的前提是，单据处于一级审批通过的状态。";
		public const string XThirdAudit = "委外加工申请单三级审批的前提是，单据处于二级审批通过的状态。";
		public const string XRefuse = "委外加工申请单拒绝的前提是，单据处于审批通过的状态。";
		/// <value>单据描述实体</value>
		public const string WTOW_TABLE           = "WTOW";					//表名。
		public const string REQDEPT_FIELD		 = "ReqDept";
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";
		public const string PROPOSERNAME_FIELD	 = "ProposerName";			//申请人。	
		public const string PROPOSERCODE_FIELD	 = "ProposerCode";			//申请人编号。
		public const string STOMANAGERCODE_FIELD = "StoManagerCode";		//仓库管理员代码
		public const string STOMANAGER_FIELD     = "StoManager";			//仓库管理员
		public const string DRAWDATE_FIELD       = "DrawDate";				//发料日期
//		public const string SOURCEENTRY_FIELD    = "SourceEntry";			//源单据流水号
//		public const string SOURCEDOCCODE_FIELD  = "SourceDocCode";			//源单据类型
//		public const string SOURCESERIALNO_FIELD = "SourceSerialNo";		//源单据顺序号。
		public const string REQREASONCODE_FIELD  = "ReqReasonCode";			//用途编号
		public const string REQREASON_FIELD      = "ReqReason";				//用途名称
		public const string PLANNUM_FIELD        = "PlanNum";				//请领数量
		public const string STOCKNUM_FIELD       = "StockNum";				//当前库存。
//		public const string ITEMSUMMARY_FIELD	 = "ItemSummary";			//物料摘要。
		public const string TERM_FIELD			 = "Term";
		public const string DRAWINGCOUNT_FIELD   = "DrawingCount";
		public const string PROSPECTUSCOUNT_FIELD= "ProspectusCount";
		public const string PROCESSCONTENT_FIELD = "ProcessContent";
		public const string PARENTENTRYNO_FIELD	 = "ParentEntryNo";
		#endregion

		#region 属性
		/// <summary>
		/// 委外加工申请单本体的数据行数。
		/// </summary>
		public int Count
		{
			get { return this.Tables[WTOWData.WTOW_TABLE].Rows.Count;}
		}
		
		#endregion

		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建委外加工申请单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table = new DataTable(WTOW_TABLE);
			InItemData oItemData = new InItemData(table);
			DataColumnCollection columns = table.Columns;
			columns.Add(STOMANAGERCODE_FIELD,typeof(System.String));	//仓库管理员代码
			columns.Add(STOMANAGER_FIELD,typeof(System.String));		//仓库管理员
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));		//发料日期
//			columns.Add(SOURCEENTRY_FIELD,typeof(System.String));		//源单据流水号
//			columns.Add(SOURCEDOCCODE_FIELD,typeof(System.String));		//源单据类型
//			columns.Add(SOURCESERIALNO_FIELD, typeof(System.String));	//源单据顺序号。
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//申领部门。
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//申领部门名称。
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//申领人。
			columns.Add(PROPOSERNAME_FIELD, typeof(System.String));			//申领人名称。
			columns.Add(REQREASONCODE_FIELD,typeof(System.String));		//用途编号
			columns.Add(REQREASON_FIELD,typeof(System.String));			//用途名称
			columns.Add(PLANNUM_FIELD,typeof(System.String));			//请领数量
			columns.Add(STOCKNUM_FIELD, typeof(System.String));			//当前库存。
//			columns.Add(ITEMSUMMARY_FIELD, typeof(System.String));		//物料摘要。
			columns.Add(TERM_FIELD, typeof(System.DateTime));
			columns.Add(DRAWINGCOUNT_FIELD, typeof(System.Int32));
			columns.Add(PROSPECTUSCOUNT_FIELD, typeof(System.Int32));
			columns.Add(PROCESSCONTENT_FIELD, typeof(System.String));
			columns.Add(PARENTENTRYNO_FIELD, typeof(System.Int32));		//红字父单据号。

			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private WTOWData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WTOWData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
