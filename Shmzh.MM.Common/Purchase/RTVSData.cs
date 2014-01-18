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
	/// CBRSData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class RTVSData :DataSet
	{
		#region 成员变量
		public const string RTVS_VIEW = "ViewRTVSource";
		public const string PKID_FIELD = "PKID";
		public const string ENTRYNO_FIELD = "EntryNo";
		public const string ENTRYCODE_FIELD = "EntryCode";
		public const string DOCCODE_FIELD = "DocCode";
		public const string DOCNAME_FIELD = "DocName";
		public const string ENTRYDATE_FIELD = "EntryDate";
		public const string ENTRYSTATE_FIELD = "EntryState";
		public const string PRVCODE_FIELD = "PrvCode";
		public const string PRVNAME_FIELD = "PrvName";
		public const string PRVBANK_FIELD = "PrvBank";
		public const string PRVACCOUNT_FIELD = "PrvAccount";
		public const string PRVREGNO_FIELD = "PrvRegNo";
		public const string PRVTEL_FIELD = "PrvTel";
		public const string PRVFAX_FIELD = "PrvFax";
		public const string CHKRESULT_FIELD = "ChkResult";
		public const string BUYERCODE_FIELD = "BuyerCode";
		public const string BUYERNAME_FIELD = "BuyerName";
		public const string ACCEPTDATE_FIELD = "AcceptDate";
		public const string SUBTOTAL_FIELD = "SubTotal";
		public const string STUNAME_FIELD = "StuName";
		public const string CURRENCYCODE_FIELD = "CurrencyCode";
		public const string STOCODE_FIELD = "StoCode";
		public const string STONAME_FIELD = "StoName";
		#endregion

		#region 属性
		/// <summary>
		/// 验收单数据源的记录数。
		/// </summary>
		public int Count
		{
			get { return this.Tables[CBRSData.CBRS_VIEW].Rows.Count;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 创建数据表。
		/// </summary>
		private void BuildDataTables()
		{
			//采购计划明细需求表。
			DataTable table   = new DataTable(RTVSData.RTVS_VIEW);
			DataColumnCollection columns = table.Columns;
			columns.Add( RTVSData.PKID_FIELD, typeof(System.String));
			columns.Add( RTVSData.ENTRYNO_FIELD, typeof(System.Int32));
			columns.Add( RTVSData.ENTRYCODE_FIELD, typeof(System.String));
			columns.Add( RTVSData.DOCCODE_FIELD, typeof(System.Int16));
			columns.Add( RTVSData.DOCNAME_FIELD, typeof(System.String));
			columns.Add( RTVSData.ENTRYDATE_FIELD, typeof(System.DateTime));
			columns.Add( RTVSData.ENTRYSTATE_FIELD, typeof(System.String));
			columns.Add( RTVSData.PRVCODE_FIELD, typeof(System.String));
			columns.Add( RTVSData.PRVNAME_FIELD, typeof(System.String));
			columns.Add( RTVSData.PRVACCOUNT_FIELD, typeof(System.String));
			columns.Add( RTVSData.PRVREGNO_FIELD, typeof(System.String));
			columns.Add( RTVSData.PRVTEL_FIELD, typeof(System.String));
			columns.Add( RTVSData.PRVFAX_FIELD, typeof(System.String));
			columns.Add( RTVSData.CHKRESULT_FIELD, typeof(System.String));
			columns.Add( RTVSData.BUYERCODE_FIELD, typeof(System.String));
			columns.Add( RTVSData.BUYERNAME_FIELD, typeof(System.String));
			columns.Add( RTVSData.ACCEPTDATE_FIELD, typeof(System.DateTime));
			columns.Add( RTVSData.SUBTOTAL_FIELD, typeof(System.Decimal));
			columns.Add( RTVSData.STUNAME_FIELD, typeof(System.String));
			columns.Add( RTVSData.CURRENCYCODE_FIELD, typeof(System.String));
			columns.Add( RTVSData.STOCODE_FIELD, typeof(System.String));
			columns.Add( RTVSData.STONAME_FIELD, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private RTVSData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public RTVSData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
