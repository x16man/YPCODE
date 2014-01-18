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
**		文件: OutData.cs
**		名称: OutData
**		描述: 发料单据清单的实体层。包括：领料单、转库单、生产退料单。
**
**              
**		作者: 张豪
**		日期: 2005-07-27
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
	using System.Runtime.Serialization;   
	/// <summary>
	/// OutData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class OutData : DataSet
	{
		#region 成员变量
		public const string ViewOUT_Table = "ViewOUT";
		public const string PKID_Field = "PKID";
		public const string EntryNo_Field = "EntryNo";
		public const string EntryCode_Field = "EntryCode";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string EntryState_Field = "EntryState";
		public const string EntryStateName_Field = "EntryStateName";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorDept_Field = "AuthorDept";
		public const string AuthorDeptName_Field = "AuthorDeptName";
		public const string EntryDate_Field = "EntryDate";
		public const string ReqReasonCode_Field = "ReqReasonCode";
		public const string ReqReason_Field = "ReqReason";
		public const string StoCode_Field = "StoCode";
		public const string StoName_Field = "StoName";
		public const string SubTotal_Field = "SubTotal";
		public const string DrawDate_Field = "DrawDate";
		public const string ItemSummary_Field = "ItemSummary";
		#endregion

		#region 属性
		/// <summary>
		/// 记录数。
		/// </summary>
		public int Count
		{
			get {	return this.Tables[OutData.ViewOUT_Table].Rows.Count;	}
		}
		#endregion
		
		#region 私有方法
		private void BuildDataTables()
		{
			DataTable table = new DataTable(ViewOUT_Table);
			DataColumnCollection columns = table.Columns;
			columns.Add(PKID_Field,typeof(System.String));	//拼接主键。
			columns.Add(EntryNo_Field,typeof(System.Int32));//单据流水号。
			columns.Add(EntryCode_Field,typeof(System.String));		//单据编号。
			columns.Add(DocCode_Field,typeof(System.Int16));		//单据类型编号。
			columns.Add(DocName_Field,typeof(System.String));		
			columns.Add(EntryState_Field, typeof(System.String));	
			columns.Add(EntryStateName_Field, typeof(System.String));
			columns.Add(AuthorCode_Field, typeof(System.String));	
			columns.Add(AuthorName_Field, typeof(System.String));	
			columns.Add(AuthorDept_Field, typeof(System.String));	
			columns.Add(AuthorDeptName_Field,typeof(System.String));
			columns.Add(EntryDate_Field,typeof(System.DateTime));	
			columns.Add(ReqReasonCode_Field,typeof(System.String));	
			columns.Add(ReqReason_Field,typeof(System.String));		
			columns.Add(StoCode_Field, typeof(System.String));		
			columns.Add(StoName_Field, typeof(System.String));		
			columns.Add(SubTotal_Field,typeof(System.Decimal));		
			columns.Add(DrawDate_Field, typeof(System.DateTime));	
			columns.Add(ItemSummary_Field, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region 公开方法
		//
		//TODO: 在此处添加公开方法.
		//
		#endregion

		#region 构造函数
		private OutData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public OutData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
