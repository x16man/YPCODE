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
	/// 批量进货单的数据实体，沿用了DocBaseData和InItemData的属性。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PBRBData:DataSet
	{
		#region 成员变量
		public const string ADD_FAILED = "批量进货单新建失败！";
		public const string ADD_SUCCESSED = "批量进货单新建失败！";
		public const string UPDATE_FAILED = "批量进货单修改失败！";
		public const string UPDATE_SUCCESSED = "批量进货单修改成功！";
		public const string DELETE_FAILED = "批量进货单删除失败！";
		public const string DELETE_SUCCESSED = "批量进货单删除成功！";
		public const string UPDATESTATE_FAILED = "批量进货单修改状态失败！";
		public const string UPDATESTATE_SUCCESSED = "批量进货单修改状态成功！";
		public const string FIRSTAUDIT_FAILED = "批量进货单一级审批失败！";
		public const string FIRSTAUDIT_SUCCESSED = "批量进货单一级审批成功！";
		public const string SECONDAUDIT_FAILED = "批量进货单二级审批失败！";
		public const string SECONDAUDIT_SUCCESSED = "批量进货单二级审批成功！";
		public const string THIRDAUDIT_FAILED = "批量进货单三级审批失败！";
		public const string THIRDAUDIT_SUCCESSED = "批量进货单三级审批成功！";
		public const string PRESENT_FAILED = "批量进货单提交失败！";
		public const string PRESENT_SUCCESSED = "批量进货单提交成功！";
		public const string CANCEL_FAILED = "批量进货单作废失败！";
		public const string CANCEL_SUCCESSED = "批量进货单作废成功！";
		public const string NOOBJECT = "空对象！";
		public const string NOSTORAGE = "没有指定仓库！";
		public const string NOCON = "没有指定架位！";
		public const string NOVENDOR = "没有指定供应商！";
		public const string NOORDER = "没有指定订单！";
		public const string XORDER = "错误的订单号！";
		public const string XCancel = "单据作废的前提是在单据处于新建，审批不通过的状态下！";
		public const string XDelete = "只有在作废的状态下才允许删除！";
		public const string XPresent = "只有在新建或者审批不通过的前提下，才允许对单据进行提交操作！";
		public const string XFirstAudit = "只有在单据已经提交的状态下，才允许对单据进行一级审批！";
		public const string XSecondAudit = "只有在单据一级审批通过的前提下，才允许对单据进行二级审批！";
		public const string XThirdAudit = "只有在单据二级审批通过的前提下，才允许对单据进行三级审批！";
		public const string XUpdate = "只有在单据在新建,作废,审批不通过的前提下，才允许对单据进行修改！";
		/// <value>单据描述实体</value>
		public const string PBRB_TABLE = "PBRB";						//批量进货表。
		//主表信息。
		public const string PRVCODE_FIELD = "PrvCode";					//供应商代码。
		public const string PRVNAME_FIELD = "PrvName";					//供应商名称。
		public const string STOCODE_FIELD = "StoCode";					//仓库编号。
		public const string STONAME_FIELD = "StoName";					//仓库名称。
		public const string CONCODE_FIELD = "ConCode";					//架位编号。
		public const string CONNAME_FIELD = "ConName";					//架位名称。
		public const string CONAREA_FIELD = "ConArea";					//面积。
		public const string ORDERNO_FIELD = "OrderNo";					//订单流水号。
		public const string ORDERCODE_FIELD = "OrderCode";				//订单编号。
		public const string BUYERCODE_FIELD = "BuyerCode";				//采购员编号。
		public const string BUYERNAME_FIELD = "BuyerName";				//采购员名称。
		public const string TOTALHEIGHT_FIELD = "TotalHeight";			//总高度。
		public const string TOTALVOLUMN_FIELD = "TotalVolumn";			//总体积数。
		public const string THICKNESS_FIELD = "Thickness";				//氧化铝浓度。
		public const string DENSITY_FIELD = "Density";					//相对密度。
		public const string AMOUNTTO_FIELD = "AmountTo";				//折固数。
		public const string BATCHCODE_FIELD = "BatchCode";				//批号。
		//批量进料从表信息。
		public const string SHIPNO_FIELD = "ShipNo";					//船名。
		public const string STARTTIME_FIELD = "StartTime";				//开工时间。
		public const string ENDTIME_FIELD = "EndTime";					//完工时间。
		public const string IMPORTTIME_FIELD = "ImportTime";			//进港时间。
		public const string EXPORTTIME_FIELD = "ExportTime";			//出港时间。
		public const string STARTVOLUMN_FIELD = "StartVolumn";			//抽驳前液位。
		public const string ENDVOLUMN_FIELD = "EndVolumn";				//抽驳后液位。
		public const string ITEMVOLUMN_FIELD = "ItemVolumn";			//体积。
		public const string PRODUCTCAT_FIELD = "ProductCat";			//货别。
		public const string DANGERCAT_FIELD = "DangerCat";				//危险品类别。
		#endregion

		#region 属性
		/// <summary>
		/// 记录数。
		/// </summary>
		public int Count
		{
			get { return this.Tables[PBRBData.PBRB_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 在InItemData的基础上，创建批量进料单的数据表。
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PBRBData.PBRB_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			//批量进料单表主表字段增加。
			columns.Add(PBRBData.PRVCODE_FIELD, typeof(System.String));
			columns.Add(PBRBData.PRVNAME_FIELD, typeof(System.String));
			columns.Add(PBRBData.STOCODE_FIELD, typeof(System.String));
			columns.Add(PBRBData.STONAME_FIELD, typeof(System.String));
			columns.Add(PBRBData.CONCODE_FIELD, typeof(System.Int32));
			columns.Add(PBRBData.CONNAME_FIELD, typeof(System.String));
			columns.Add(PBRBData.CONAREA_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.ORDERNO_FIELD, typeof(System.Int32));
			columns.Add(PBRBData.ORDERCODE_FIELD, typeof(System.String));
			columns.Add(PBRBData.BUYERCODE_FIELD, typeof(System.String));
			columns.Add(PBRBData.BUYERNAME_FIELD, typeof(System.String));
			columns.Add(PBRBData.TOTALHEIGHT_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.TOTALVOLUMN_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.THICKNESS_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.DENSITY_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.AMOUNTTO_FIELD, typeof(System.Decimal));
			columns.Add(PBRBData.BATCHCODE_FIELD, typeof(System.String));
			//批量进货表从表字段增加。
			columns.Add(PBRBData.SHIPNO_FIELD, typeof(System.String));
			columns.Add(PBRBData.STARTTIME_FIELD, typeof(System.String));
			columns.Add(PBRBData.ENDTIME_FIELD, typeof(System.String));
			columns.Add(PBRBData.IMPORTTIME_FIELD, typeof(System.String));
			columns.Add(PBRBData.EXPORTTIME_FIELD, typeof(System.String));
			columns.Add(PBRBData.STARTVOLUMN_FIELD, typeof(System.String));
			columns.Add(PBRBData.ENDVOLUMN_FIELD, typeof(System.String));
			columns.Add(PBRBData.ITEMVOLUMN_FIELD, typeof(System.String));
			columns.Add(PBRBData.PRODUCTCAT_FIELD, typeof(System.String));
			columns.Add(PBRBData.DANGERCAT_FIELD, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private PBRBData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public PBRBData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
