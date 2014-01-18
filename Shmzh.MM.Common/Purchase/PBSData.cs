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
	/// PBSData 的摘要说明。ViewAllValidOrder试图。
	/// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    public class PBSData : DataSet
	{
		#region 成员变量
		public const string VPBS_VIEW = "ViewAllValidOrder";
		public const string PKID_FIELD ="PKID";
		public const string ENTRYNO_FIELD = "EntryNo";
		public const string ENTRYCODE_FIELD = "EntryCode";
		public const string DOCCODE_FIELD = "DocCode";
		public const string DOCNO_FIELD = "DocNo";
		public const string PRVCODE_FIELD = "PrvCode";
		public const string PRVNAME_FIELD = "PrvName";
		public const string BUYERCODE_FIELD = "BuyerCode";
		public const string BUYERNAME_FIELD = "BuyerName";
		public const string TOTALMONEY_FIELD = "TotalMoney";
		public const string ENTRYDATE_FIELD = "ENTRYDATE";
		#endregion

		#region 私有方法
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(VPBS_VIEW);
			
			DataColumnCollection columns = table.Columns;
			
			columns.Add( PKID_FIELD, typeof(System.String));
			columns.Add( ENTRYNO_FIELD, typeof(System.Int32));
			columns.Add( ENTRYCODE_FIELD, typeof(System.String));
			columns.Add( DOCCODE_FIELD, typeof(System.Int16));
			columns.Add( DOCNO_FIELD, typeof(System.String));
			columns.Add( PRVCODE_FIELD, typeof(System.String));
			columns.Add( PRVNAME_FIELD, typeof(System.String));
			columns.Add( BUYERCODE_FIELD, typeof(System.String));
			columns.Add( BUYERNAME_FIELD, typeof(System.String));
			columns.Add( TOTALMONEY_FIELD, typeof(System.Decimal));
			columns.Add( ENTRYDATE_FIELD, typeof(System.DateTime));
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private PBSData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PBSData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
