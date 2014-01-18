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
	/// CurrentMonth_WithdrawData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class CurrentMonth_WithdrawData :DataSet
	{
		#region 成员变量
		public const string CurrentMonth_Withdraw_Table = "CurrentMonth_Withdraw";
		public const string Classify_Field = "Classify";
		public const string ItemMoney_Field = "ItemMoney";
		#endregion

		#region 属性
		public int Count
		{
			get {return this.Tables[0].Rows.Count;}
		}
		#endregion
		
		#region 私有方法
		private void BuildDataTable()
		{
			DataTable table   = new DataTable(CurrentMonth_Withdraw_Table);
			//添加字段。
			table.Columns.Add(Classify_Field, typeof(System.String));
			table.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
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
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private CurrentMonth_WithdrawData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public CurrentMonth_WithdrawData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		#endregion
	}
}
