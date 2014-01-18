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
	/// 领料单的数据实体，沿用了DocBaseData和InItemData的属性。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WDRWData:DataSet
	{
		#region 成员变量
		public const string ADD_FAILED = "领料单新建失败！";
		public const string ADD_SUCCESSED = "领料单新建成功！";
		public const string UPDATE_FAILED = "领料单修改失败！";
		public const string UPDATE_SUCCESSED = "领料单修改成功！";
		public const string DELETE_FAILED = "领料单删除失败！";
		public const string DELETE_SUCCESSED = "领料单删除成功！";
		public const string UPDATESTATE_FAILED = "领料单修改状态失败！";
		public const string UPDATESTATE_SUCCESSED = "领料单修改状态成功！";
		public const string FIRSTAUDIT_FAILED = "领料单一级审批失败！";
		public const string FIRSTAUDIT_SUCCESSED = "领料单一级审批成功！";
		public const string SECONDAUDIT_FAILED = "领料单二级审批失败！";
		public const string SECONDAUDIT_SUCCESSED = "领料单二级审批成功！";
		public const string THIRDAUDIT_FAILED = "领料单三级审批失败！";
		public const string THIRDAUDIT_SUCCESSED = "领料单三级审批成功！";
		public const string PRESENT_FAILED = "领料单提交失败！";
		public const string PRESENT_SUCCESSED = "领料单提交成功！";
		public const string CANCEL_FAILED = "领料单作废失败！";
		public const string CANCEL_SUCCESSED = "领料单作废成功！";
		public const string NOOBJECT = "空对象！";
		public const string OUT_FAILED= "领料单发料失败！";
		public const string OUT_SUCCESSED = "领料单发料成功！";
		public const string Refuse_Failed = "领料单拒发失败！";
		public const string Refuse_Success = "领料单拒发成功！";
		public const string NoStorage = "领料单必须要指定领料仓库！";
		public const string NoPurpose = "领料单必须要指定用途！";
		public const string NoDept = "领料单必须要指定领用部门！";
		public const string NoProposer = "领料单必须要指定领用人！";
		public const string XUpdate = "领料单修改的前提是，单据处于新建、作废、审批不通过的状态。";
		public const string XCancel = "领料单修改的前提是，单据处于新建、审批不通过的状态。";
		public const string XDelete = "领料单删除的前提是，单据处于作废的状态。";
		public const string XPresent = "领料单提交的前提是，单据处于新建、作废、审批不通过的状态。";
		public const string XFirstAudit = "领料单一级审批的前提是，单据处于提交的状态。";
		public const string XSecondAudit = "领料单二级审批的前提是，单据处于一级审批通过的状态。";
		public const string XThirdAudit = "领料单三级审批的前提是，单据处于二级审批通过的状态。";
		public const string XRefuse = "领料单拒绝的前提是，单据处于审批通过的状态。";
		/// <value>单据描述实体</value>
		public const string WDRW_TABLE           = "WDRW";					//表名。
		public const string WDS_VIEW             = "ViewDrawSource";		//领料单的数据来源列表视图。
		public const string WDSD_VIEW            = "ViewDrawSourceDetail";	//领料单的数据来源视图。
		public const string REQDEPT_FIELD		 = "ReqDept";
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";
		public const string PROPOSER_FIELD		 = "Proposer";				//领料人。	
		public const string PROPOSERCODE_FIELD	 = "ProposerCode";			//领料人编号。
		public const string STOMANAGERCODE_FIELD = "StoManagerCode";		//仓库管理员代码
		public const string STOMANAGER_FIELD     = "StoManager";			//仓库管理员
		public const string DRAWDATE_FIELD       = "DrawDate";				//发料日期
		public const string SOURCEENTRY_FIELD    = "SourceEntry";			//源单据流水号
		public const string SOURCEDOCCODE_FIELD  = "SourceDocCode";			//源单据类型
		public const string SOURCESERIALNO_FIELD = "SourceSerialNo";		//源单据顺序号。
		public const string REQREASONCODE_FIELD  = "ReqReasonCode";			//用途编号
		public const string REQREASON_FIELD      = "ReqReason";				//用途名称
		public const string STOCODE_FIELD        = "StoCode";				//仓库编号
		public const string STONAME_FIELD        = "StoName";				//仓库名称
		public const string CONCODE_FIELD		 = "CONCODE";				//架位编号。
		public const string CONNAME_FIELD		 = "CONNAME";				//架位名称。
		public const string PLANNUM_FIELD        = "PlanNum";				//请领数量
		public const string STOCKNUM_FIELD       = "StockNum";				//当前库存。
		public const string ITEMSUMMARY_FIELD	 = "ItemSummary";			//物料摘要。
		public const string PARENTENTRYNO_FIELD	 = "ParentEntryNo";
		//领料单来源明细视图的字段常量。
		public const string SourceEntry_Field	= "SourceEntry";
		public const string SourceDocCode_Field = "SourceDocCode";
		public const string SourceDocName_Field = "SourceDocName";
		public const string SourceSerialNo_Field = "SourceSerialNo";
		public const string ItemCode_Field		= "ItemCode";
		public const string ItemName_Field		= "ItemName";
		public const string ItemSpec_Field		= "ItemSpecial";
		public const string ItemUnit_Field		= "ItemUnit";
		public const string ItemUnitName_Field	= "ItemUnitName";
		public const string ItemPrice_Field		= "ItemPrice";
		public const string PlanNum_Field		= "PlanNum";
		public const string ItemMoney_Field     = "ItemMoney";
		//领料单来源列表视图的字段常量。
		public const string EntryNo_Field = "EntryNo";
		public const string EntryCode_Field = "EntryCode";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string EntryState_Field = "EntryState";
		public const string EntryStateName_Field = "EntryStateName";
		public const string EntryDate_Field = "EntryDate";
		public const string ReqDept_Field = "ReqDept";
		public const string ReqDeptName_Field = "ReqDeptName";
		public const string Proposer_Field = "Proposer";
		public const string ProposerCode_Field = "ProposerCode";

		#endregion

		#region 属性
		/// <summary>
		/// 领料单本体的数据行数。
		/// </summary>
		public int Count
		{
			get { return this.Tables[WDRWData.WDRW_TABLE].Rows.Count;}
		}
		/// <summary>
		/// 领料单来源单据清单的数量。
		/// </summary>
		public int SourceListCount
		{
			get { return this.Tables[WDRWData.WDS_VIEW].Rows.Count;}
		}
		/// <summary>
		/// 领料单来源单据明细的数量。
		/// </summary>
		public int SourceDetailCount
		{
			get { return this.Tables[WDRWData.WDSD_VIEW].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建领料单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table = new DataTable(WDRW_TABLE);
			InItemData oItemData = new InItemData(table);
			DataColumnCollection columns = table.Columns;
			columns.Add(STOMANAGERCODE_FIELD,typeof(System.String));	//仓库管理员代码
			columns.Add(STOMANAGER_FIELD,typeof(System.String));		//仓库管理员
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));		//发料日期
			columns.Add(SOURCEENTRY_FIELD,typeof(System.String));		//源单据流水号
			columns.Add(SOURCEDOCCODE_FIELD,typeof(System.String));		//源单据类型
			columns.Add(SOURCESERIALNO_FIELD, typeof(System.String));	//源单据顺序号。
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//申领部门。
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//申领部门名称。
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//申领人。
			columns.Add(PROPOSER_FIELD, typeof(System.String));			//申领人名称。
			columns.Add(REQREASONCODE_FIELD,typeof(System.String));		//用途编号
			columns.Add(REQREASON_FIELD,typeof(System.String));			//用途名称
			columns.Add(STOCODE_FIELD,typeof(System.String));			//仓库编号
			columns.Add(STONAME_FIELD,typeof(System.String));			//仓库名称
			columns.Add(CONCODE_FIELD, typeof(System.Int32));			//架位编号。
			columns.Add(CONNAME_FIELD, typeof(System.String));			//架位名称。
			columns.Add(PLANNUM_FIELD,typeof(System.String));			//请领数量
			columns.Add(STOCKNUM_FIELD, typeof(System.String));			//当前库存。
			columns.Add(ITEMSUMMARY_FIELD, typeof(System.String));		//物料摘要。
			columns.Add(PARENTENTRYNO_FIELD, typeof(System.Int32));		//红字父单据号。
			this.Tables.Add(table);

			DataTable SourceDetailTable = new DataTable(WDRWData.WDSD_VIEW);
			DataColumnCollection SourceColumns = SourceDetailTable.Columns;
			SourceColumns.Add(WDRWData.SourceEntry_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.SourceDocCode_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.SourceDocName_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.REQREASONCODE_FIELD, typeof(System.String));
			SourceColumns.Add(WDRWData.REQREASON_FIELD, typeof(System.String));
			SourceColumns.Add(WDRWData.SourceSerialNo_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemCode_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemName_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemSpec_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemUnit_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemUnitName_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemPrice_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.PlanNum_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemMoney_Field, typeof(System.String));

			this.Tables.Add(SourceDetailTable);

			DataTable SourceTable = new DataTable(WDRWData.WDS_VIEW);
			DataColumnCollection ListColumns = SourceTable.Columns;
			ListColumns.Add(WDRWData.EntryNo_Field, typeof(System.Int32));
			ListColumns.Add(WDRWData.EntryCode_Field, typeof(System.String));
			ListColumns.Add(WDRWData.DocCode_Field, typeof(System.Int16));
			ListColumns.Add(WDRWData.DocName_Field, typeof(System.String));
			ListColumns.Add(WDRWData.EntryState_Field, typeof(System.String));
			ListColumns.Add(WDRWData.EntryStateName_Field, typeof(System.String));
			ListColumns.Add(WDRWData.EntryDate_Field, typeof(System.String));
			ListColumns.Add(WDRWData.ReqDept_Field, typeof(System.String));
			ListColumns.Add(WDRWData.ReqDeptName_Field, typeof(System.String));
			ListColumns.Add(WDRWData.Proposer_Field, typeof(System.String));
			ListColumns.Add(WDRWData.ProposerCode_Field, typeof(System.String));

			this.Tables.Add(SourceTable);

		}
		#endregion

		#region 构造函数
		private WDRWData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WDRWData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
