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
	public class CBRSData :DataSet
	{
		#region 成员变量
		public const string CBRS_VIEW = "ViewCBRSource";
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
			DataTable table   = new DataTable(CBRSData.CBRS_VIEW);
			DataColumnCollection columns = table.Columns;
			columns.Add( CBRSData.PKID_FIELD, typeof(System.String));
			columns.Add( CBRSData.ENTRYNO_FIELD, typeof(System.Int32));
			columns.Add( CBRSData.ENTRYCODE_FIELD, typeof(System.String));
			columns.Add( CBRSData.DOCCODE_FIELD, typeof(System.Int16));
			columns.Add( CBRSData.DOCNAME_FIELD, typeof(System.String));
			columns.Add( CBRSData.ENTRYDATE_FIELD, typeof(System.DateTime));
			columns.Add( CBRSData.ENTRYSTATE_FIELD, typeof(System.String));
			columns.Add( CBRSData.PRVCODE_FIELD, typeof(System.String));
			columns.Add( CBRSData.PRVNAME_FIELD, typeof(System.String));
			columns.Add( CBRSData.PRVACCOUNT_FIELD, typeof(System.String));
			columns.Add( CBRSData.PRVREGNO_FIELD, typeof(System.String));
			columns.Add( CBRSData.PRVTEL_FIELD, typeof(System.String));
			columns.Add( CBRSData.PRVFAX_FIELD, typeof(System.String));
			columns.Add( CBRSData.CHKRESULT_FIELD, typeof(System.String));
			columns.Add( CBRSData.BUYERCODE_FIELD, typeof(System.String));
			columns.Add( CBRSData.BUYERNAME_FIELD, typeof(System.String));
			columns.Add( CBRSData.ACCEPTDATE_FIELD, typeof(System.DateTime));
			columns.Add( CBRSData.SUBTOTAL_FIELD, typeof(System.Decimal));
			columns.Add( CBRSData.STUNAME_FIELD, typeof(System.String));
			columns.Add( CBRSData.CURRENCYCODE_FIELD, typeof(System.String));
			columns.Add( CBRSData.STOCODE_FIELD, typeof(System.String));
			columns.Add(CBRSData.STONAME_FIELD, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private CBRSData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public CBRSData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
