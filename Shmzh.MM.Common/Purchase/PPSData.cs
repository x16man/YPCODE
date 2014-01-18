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
	/// 采购计划数据来源数据实体层。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PPSData :DataSet
	{
		#region 成员变量
		public const string PPS_TABLE = "PurchasePlanSource";
		public const string PKID_FIELD = "PKID";
		//public const string ENTRYNO_FIELD = "EntryNo";
		public const string ENTRYNO_FIELD = "SourceEntry";
		public const string ENTRYCODE_FIELD = "EntryCode";
		//public const string DOCCODE_FIELD = "DocCode";
		public const string DOCCODE_FIELD = "SourceDocCode";

		public const string DOCNAME_FIELD = "DocName";
		public const string ENTRYSTATE_FIELD = "EntryState";
		public const string ENTRYDATE_FIELD = "EntryDate";
		public const string ENTRYSTATENAME_FIELD = "EntryStateName";
		public const string REQDEPT_FIELD = "ReqDept";
		public const string REQDEPTNAME_FIELD = "ReqDeptName";
		public const string PROPOSERCODE_FIELD = "ProposerCode";
		public const string PROPOSER_FIELD = "Proposer";
		public const string REQREASONCODE_FIELD = "ReqReasonCode";
		public const string REQREASON_FIELD = "ReqReason";
		public const string SERIALNO_FIELD = "SerialNo";
	    public const string NEWCODE_FIELD = "NEWCODE";
		public const string ITEMCODE_FIELD = "ItemCode";
		public const string ITEMNAME_FIELD = "ItemName";
		public const string ITEMSPECIAL_FIELD = "ItemSpecial";
		public const string ITEMUNIT_FIELD = "ItemUnit";
		public const string ITEMUNITNAME_FIELD = "ItemUnitName";
		public const string ITEMPRICE_FIELD = "ItemPrice";
		public const string ITEMREQNUM_FIELD = "ItemReqNum";
		public const string ITEMREQMONEY_FIELD = "ItemReqMoney";
		public const string ITEMLACKNUM_FIELD = "ItemLackNum";
		public const string ITEMNUM_FIELD = "ItemNum";
		public const string ITEMMONEY_FIELD = "ItemMoney";
		public const string REQDATE_FIELD = "ReqDate";
		public const string ReqEntryDate_Field = "ReqEntryDate";
		public const string REMARK_FIELD = "Remark";
		public const string COUNT_FIELD = "Count";
		public const string PLANNUM_TABLE = "PLANNUM";//计划数量表。
		
		#endregion

		#region 属性
		/// <summary>
		/// 采购计划明细内容的记录数量。
		/// </summary>
		public int Count
		{
			get { return this.Tables[PPSData.PPS_TABLE].Rows.Count;}
		}
		/// <summary>
		/// 采购计划中重复物料的数量。
		/// </summary>
		public int RepeatItemCount
		{
			get { return this.Tables[PPSData.PLANNUM_TABLE].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 创建数据表。
		/// </summary>
		private void BuildDataTables()
		{
			//采购计划明细需求表。
			DataTable table   = new DataTable(PPS_TABLE);
			DataColumnCollection columns = table.Columns;
			columns.Add( PKID_FIELD, typeof(System.String));
			columns.Add( ENTRYNO_FIELD, typeof(System.Int32));
			columns.Add( ENTRYCODE_FIELD, typeof(System.String));
			columns.Add( DOCCODE_FIELD, typeof(System.Int16));
			columns.Add( DOCNAME_FIELD, typeof(System.String));
			columns.Add( ENTRYSTATE_FIELD, typeof(System.String));
			columns.Add( ENTRYDATE_FIELD, typeof(System.DateTime));
			columns.Add( ENTRYSTATENAME_FIELD, typeof(System.String));
			columns.Add( REQDEPT_FIELD, typeof(System.String));
			columns.Add( REQDEPTNAME_FIELD, typeof(System.String));
			columns.Add( PROPOSERCODE_FIELD, typeof(System.String));
			columns.Add( PROPOSER_FIELD, typeof(System.String));
			columns.Add( REQREASONCODE_FIELD, typeof(System.String));
			columns.Add( REQREASON_FIELD, typeof(System.String));
			columns.Add( SERIALNO_FIELD, typeof(System.Int16));
		    columns.Add(NEWCODE_FIELD, typeof (String));
			columns.Add( ITEMCODE_FIELD, typeof(System.String));
			columns.Add( ITEMNAME_FIELD, typeof(System.String));
			columns.Add( ITEMSPECIAL_FIELD, typeof(System.String));
			columns.Add( ITEMUNIT_FIELD, typeof(System.Int16));
			columns.Add( ITEMUNITNAME_FIELD, typeof(System.String));
            columns.Add( ITEMPRICE_FIELD, typeof(System.Decimal));
			columns.Add( ITEMREQNUM_FIELD, typeof(System.Decimal));
			columns.Add( ITEMREQMONEY_FIELD, typeof(System.Decimal));		
			columns.Add( ITEMLACKNUM_FIELD, typeof(System.Decimal));	//需求数量。
			columns.Add( ITEMNUM_FIELD, typeof(System.Decimal));	//采购计划数量。
			columns.Add( ITEMMONEY_FIELD, typeof(System.Decimal));	//采购计划金额．
			columns.Add( REQDATE_FIELD, typeof(System.DateTime));		//要求日期。
			columns.Add( ReqEntryDate_Field, typeof(System.DateTime));
			columns.Add( REMARK_FIELD, typeof(System.String));			//备注。
			columns.Add( COUNT_FIELD, typeof(System.Int32));			//重复量。
			this.Tables.Add(table);
			//-----------重复物料表-------------------------------------
			DataTable table1   = new DataTable(PLANNUM_TABLE);
			DataColumnCollection columns1 = table1.Columns;
			columns1.Add( ITEMCODE_FIELD, typeof(System.String));
			columns1.Add( ITEMNUM_FIELD, typeof(System.Decimal));
			columns1.Add( COUNT_FIELD, typeof(System.Int32));			//重复量。
			this.Tables.Add(table1);
			//-----------采购计划明细需求视图---------------------------
			//DataView myView = new DataView(table,"",PPSData.REQDEPT_FIELD+","+PPSData.ITEMCODE_FIELD,DataViewRowState.CurrentRows);
			//this.Tables.
			
		}
		
		#endregion

		#region 构造函数
		private PPSData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PPSData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
