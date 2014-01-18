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
	/// MAIOData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class MAIOData : DataSet
	{
		#region 成员变量
		public const string MAIO_Table = "MAIO";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpec";
		public const string UnitCode_Field = "UnitCode";
		public const string UnitName_Field = "UnitName";
		public const string StoCode_Field = "StoCode";
		public const string StoName_Field = "StoName";
		public const string ConCode_Field = "ConCode";
		public const string ConName_Field = "ConName";
		public const string BookNum_Field = "BookNum";
		public const string BookPrice_Field = "BookPrice";
		public const string BookValue_Field = "BookValue";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemValue_Field = "ItemValue";
		public const string AcceptDate_Field = "AcceptDate";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorDate_Field = "AuthorDate";
		#endregion

		#region 属性
		/// <summary>
		/// 物料编号。
		/// </summary>
		public string ItemCode
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemCode_Field].ToString();}
		}
		/// <summary>
		/// 物料名称。
		/// </summary>
		public string ItemName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemName_Field].ToString();}
		}
		/// <summary>
		/// 规格型号。
		/// </summary>
		public string ItemSpec
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemSpec_Field].ToString();}
		}
		/// <summary>
		/// 单位编号。
		/// </summary>
		public int UnitCode
		{
			get { return int.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.UnitCode_Field].ToString());}
		}
		/// <summary>
		/// 单位名称。
		/// </summary>
		public string UnitName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.UnitName_Field].ToString();}
		}
		/// <summary>
		/// 仓库编号。
		/// </summary>
		public string StoCode
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.StoCode_Field].ToString();}
		}
		/// <summary>
		/// 仓库名称。
		/// </summary>
		public string StoName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.StoName_Field].ToString();}
		}
		/// <summary>
		/// 架位编号。
		/// </summary>
//		public int ConCode
//		{
//			get { return int.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ConCode_Field].ToString());}
//		}
		/// <summary>
		/// 架位名称。
		/// </summary>
		public string ConName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ConName_Field].ToString();}
		}
		/// <summary>
		/// 帐外数量。
		/// </summary>
		public decimal BookNum
		{
			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.BookNum_Field].ToString());}
		}
		/// <summary>
		/// 账面单价。
		/// </summary>
		public decimal BookPrice
		{
			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.BookPrice_Field].ToString());}
		}
		/// <summary>
		/// 账面金额。
		/// </summary>
//		public decimal BookValue
//		{
//			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.BookValue_Field].ToString());}
//		}
		/// <summary>
		/// 实际数量。
		/// </summary>
		public decimal ItemNum
		{
			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemNum_Field].ToString());}
		}
		/// <summary>
		/// 实际单价。
		/// </summary>
//		public decimal ItemPrice
//		{
//			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemPrice_Field].ToString());}
//		}
		/// <summary>
		/// 实际金额。
		/// </summary>
//		public decimal ItemValue
//		{
//			get { return decimal.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.ItemValue_Field].ToString());}
//		}
		/// <summary>
		/// 接收日期。
		/// </summary>
//		public DateTime AcceptDate
//		{
//			get { return DateTime.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.AcceptDate_Field].ToString());}
//		}
		/// <summary>
		/// 填写人编号。
		/// </summary>
		public string AuthorCode
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.AuthorCode_Field].ToString();}
		}
		/// <summary>
		/// 填写人名称。
		/// </summary>
		public string AuthorName
		{
			get { return this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.AuthorName_Field].ToString();}
		}
		/// <summary>
		/// 填写日期。
		/// </summary>
//		public DateTime AuthorDate
//		{
//			get { return DateTime.Parse(this.Tables[MAIOData.MAIO_Table].Rows[0][MAIOData.AuthorDate_Field].ToString());}
//		}
		/// <summary>
		/// 记录数。
		/// </summary>
		public int Count
		{
			get {return this.Tables[MAIOData.MAIO_Table].Rows.Count;}
		}
		#endregion
		
		#region 私有方法
		private void BuildDataTable() 
		{
			// 创建　Sto 表．
			DataTable table   = new DataTable(MAIOData.MAIO_Table);
			//添加字段。
			table.Columns.Add(MAIOData.ItemCode_Field, typeof(System.String));
			table.Columns.Add(MAIOData.ItemName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.ItemSpec_Field,typeof(System.String));
			table.Columns.Add(MAIOData.UnitCode_Field, typeof(System.Int16));
			table.Columns.Add(MAIOData.UnitName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.StoCode_Field, typeof(System.String));
			table.Columns.Add(MAIOData.StoName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.ConCode_Field, typeof(System.Int32));
			table.Columns.Add(MAIOData.ConName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.BookNum_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.BookPrice_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.BookValue_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.ItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.ItemPrice_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.ItemValue_Field, typeof(System.Decimal));
			table.Columns.Add(MAIOData.AcceptDate_Field, typeof(System.DateTime));
			table.Columns.Add(MAIOData.AuthorCode_Field, typeof(System.String));
			table.Columns.Add(MAIOData.AuthorName_Field, typeof(System.String));
			table.Columns.Add(MAIOData.AuthorDate_Field, typeof(System.DateTime));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
		#endregion

		#region 公开方法
		//
		//TODO: 在此处添加公开方法.
		//
		#endregion

		#region 构造函数
		private MAIOData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public MAIOData()
		{
			this.BuildDataTable();
		}
		#endregion
	}
}
