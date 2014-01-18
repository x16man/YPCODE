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
	using System.Runtime.Serialization;  
	/// <summary>
	/// 仓库收料的实体层。
	/// 包括采购收料单、采购退货单、转库单。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class InData : DataSet
	{
		#region 成员变量
		public const string ViewIN_Table = "ViewIN";
		public const string PKID_Field = "PKID";
		public const string EntryNo_Field = "EntryNo";
		public const string EntryCode_Field = "EntryCode";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string EntryState_Field = "EntryState";
		public const string EntryStateName_Field = "EntryStateName";
		public const string EntryDate_Field = "EntryDate";
		public const string PrvCode_Field = "PrvCode";
		public const string PrvName_Field = "PrvName";
		public const string BuyerCode_Field = "BuyerCode";
		public const string BuyerName_Field = "BuyerName";
		public const string StoCode_Field = "StoCode";
		public const string StoName_Field = "StoName";
		public const string AcceptDate_Field = "AcceptDate";
		public const string SubTotal_Field = "SubTotal";
		public const string ItemSummary_Field = "ItemSummary";
		#endregion

		#region 属性
		public int Count
		{
			get { return this.Tables[InData.ViewIN_Table].Rows.Count;}
		}
		#endregion
		
		#region 私有方法
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(ViewIN_Table);
			
			DataColumnCollection columns = table.Columns;
			
			columns.Add(PKID_Field, typeof(System.String));
			columns.Add(EntryNo_Field, typeof(System.Int32));
			columns.Add(EntryCode_Field,typeof(System.String));
			columns.Add(DocCode_Field, typeof(System.Int16));			
			columns.Add(DocName_Field, typeof(System.String));
			columns.Add(EntryState_Field, typeof(System.String));
			columns.Add(EntryStateName_Field, typeof(System.String));
			columns.Add(EntryDate_Field, typeof(System.DateTime));
			columns.Add(PrvCode_Field, typeof(System.String));
			columns.Add(PrvName_Field, typeof(System.String));
			columns.Add(BuyerCode_Field, typeof(System.String));
			columns.Add(BuyerName_Field, typeof(System.String));
			columns.Add(StoCode_Field, typeof(System.String));
			columns.Add(StoName_Field, typeof(System.String));
			columns.Add(AcceptDate_Field, typeof(System.DateTime));
			columns.Add(SubTotal_Field, typeof(System.Decimal));
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
		public InData()
		{
			BuildDataTables();
		}
		private InData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		#endregion
	}
}
