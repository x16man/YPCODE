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
	/// StockChoiceData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class StockChoiceData : DataSet
	{
		#region 成员变量
		public const string NoObject = "";
		public const string StockChoice_Table= "StockChoice";
		public const string PKID_Field = "PKID";
		public const string EntryNo_Field = "EntryNo";
		public const string EntryCode_Field = "EntryCode";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string PrvCode_Field = "PrvCode";
		public const string PrvName_Field = "PrvName";
		public const string AcceptCode_Field = "AcceptCode";
		public const string AcceptName_Field = "AcceptName";
		public const string AcceptDate_Field = "AcceptDate";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpecial";
		public const string ItemUnit_Field = "ItemUnit";
		public const string ItemUnitName_Field = "ItemUnitName";
		public const string StockNum_Field = "StockNum";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemMoney_Field = "ItemMoney";
		public const string BatchCode_Field = "BatchCode";
		public const string StoCode_Field = "StoCode";
		public const string StoName_Field = "StoName";
		public const string ConCode_Field = "ConCode";
		public const string ConName_Field = "ConName";
		public const string BuyerCode_Field = "BuyerCode";
		public const string BuyerName_Field = "BuyerName";
		#endregion

		#region 属性
		/// <summary>
		/// 记录数。
		/// </summary>
		public int Count
		{
			get { return this.Tables[StockChoiceData.StockChoice_Table].Rows.Count; }
		}
		#endregion

		#region 私有方法
		private void BuildDataTable() 
		{
			DataTable table   = new DataTable(StockChoiceData.StockChoice_Table);
			table.Columns.Add(StockChoiceData.PKID_Field, typeof(System.Int64));
			table.Columns.Add(StockChoiceData.EntryNo_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.EntryCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.DocCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.DocName_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.PrvCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.PrvName_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.AcceptCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.AcceptName_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.AcceptDate_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ItemCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ItemName_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ItemSpec_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ItemUnit_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ItemUnitName_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.StockNum_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ItemNum_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ItemPrice_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ItemMoney_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.BatchCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.StoCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.StoName_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ConCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.ConName_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.BuyerCode_Field,typeof(System.String));
			table.Columns.Add(StockChoiceData.BuyerName_Field,typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region 构造函数
		private StockChoiceData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
			
		}
		public StockChoiceData()
		{
			this.BuildDataTable();
		}
		#endregion
	}
}
