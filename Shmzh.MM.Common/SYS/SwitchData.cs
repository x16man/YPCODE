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
	/// SwitchData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class SwitchData : DataSet
	{
		#region 成员变量
		public static string Switch_Table = "Switch";
		public static string FunctionID_Field = "FunctionID";
		public static string Enable_Field = "Enable";
		public static string Remark_Field = "Remark";
		#endregion

		#region 属性
		public int Count
		{
			get { return this.Tables[SwitchData.Switch_Table].Rows.Count;}
		}
		#endregion
		
		#region 私有方法
		/// <summary>
		/// 构建数据表。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　DEPT 表．
			DataTable table   = new DataTable(Switch_Table);
			//添加字段。
			table.Columns.Add(FunctionID_Field, typeof(System.String));
			table.Columns.Add(Enable_Field, typeof(System.Int32));
			table.Columns.Add(Remark_Field, typeof(System.String));
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
		private SwitchData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 构造函数。
		/// </summary>
		public SwitchData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		#endregion
	}
}
