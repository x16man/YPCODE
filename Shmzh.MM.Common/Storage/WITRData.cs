#region 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved

#region 文档信息
/******************************************************************************
**		文件: 
**		名称: 
**		描述: 
**
**              
**		作者: 张豪
**		日期: 
*******************************************************************************
**		修改历史
*******************************************************************************
**		日期:		作者:		描述:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion 文档信息


namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	/// <summary>
	/// WITRData 的摘要说明。
	/// </summary>
	public class WITRData : DataSet
	{
		#region 成员变量
		public const string WITR_Table = "WITR";
		public const string PKID_Field = "PKID";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorLoginID_Field = "AuthorLoginID";
		public const string AuthorDept_Field = "AuthorDept";
		public const string AuthorDeptName_Field = "AuthorDeptName";
		public const string ProposerCode_Field = "ProposerCode";
		public const string Proposer_Field = "Proposer";
		public const string ReqReasonCode_Field = "ReqReasonCode";
		public const string ReqReason_Field = "ReqReason";
		public const string ReqDate_Field = "ReqDate";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string UnitCode_Field = "UnitCode";
		public const string UnitName_Field = "UnitName";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemMoney_Field = "ItemMoney";
		public const string EntryState_Field = "EntryState";
		public const string Remark_Field = "Remark";
		public const string FeedBack_Field = "FeedBack";
		public const string DocCode_Field = "DocCode";
		#endregion

		#region 属性
		public int Count
		{
			get {return this.Tables[0].Rows.Count;}
		}
		#endregion
		
		#region 私有方法
		private void BuildTable()
		{
			DataTable myDataTable = new DataTable(WITR_Table);
			myDataTable.Columns.Add(PKID_Field, typeof(System.Int64));
			myDataTable.Columns.Add(AuthorCode_Field, typeof(System.String));
			myDataTable.Columns.Add(AuthorName_Field, typeof(System.String));
			myDataTable.Columns.Add(AuthorLoginID_Field, typeof(System.String));
			myDataTable.Columns.Add(AuthorDept_Field, typeof(System.String));
			myDataTable.Columns.Add(AuthorDeptName_Field, typeof(System.String));
			myDataTable.Columns.Add(ProposerCode_Field, typeof(System.String));
			myDataTable.Columns.Add(Proposer_Field, typeof(System.String));
			myDataTable.Columns.Add(ReqReasonCode_Field, typeof(System.String));
			myDataTable.Columns.Add(ReqReason_Field, typeof(System.String));
			myDataTable.Columns.Add(ReqDate_Field, typeof(System.DateTime));
			myDataTable.Columns.Add(ItemCode_Field, typeof(System.String));
			myDataTable.Columns.Add(ItemName_Field, typeof(System.String));
			myDataTable.Columns.Add(ItemSpec_Field, typeof(System.String));
			myDataTable.Columns.Add(UnitCode_Field, typeof(System.Int16));
			myDataTable.Columns.Add(UnitName_Field, typeof(System.String));
			myDataTable.Columns.Add(ItemPrice_Field, typeof(System.Decimal));
			myDataTable.Columns.Add(ItemNum_Field, typeof(System.Decimal));
			myDataTable.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
			myDataTable.Columns.Add(EntryState_Field, typeof(System.String));
			myDataTable.Columns.Add(Remark_Field, typeof(System.String));
			myDataTable.Columns.Add(FeedBack_Field, typeof(System.String));
			myDataTable.Columns.Add(DocCode_Field, typeof(System.Int32));
			this.Tables.Add(myDataTable);
		}
		#endregion

		#region 公开方法
		//
		//TODO: 在此处添加公开方法.
		//
		#endregion

		#region 构造函数
		public WITRData()
		{
			this.BuildTable();
		}
		#endregion
	}
}
