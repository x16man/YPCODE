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
	/// YCLData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class YCLData : DataSet
	{
		#region 成员变量
		public const string YCL_Table = "WYCL";//表名.
		public const string PKID_Field = "PKID";
		public const string PrvCode_Field = "PrvCode";//编号。
		public const string PrvName_Field = "PrvName";//名称。
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string UnitCode_Field = "UnitCode";
		public const string UnitName_Field = "UnitName";
		public const string InVolNum_Field = "InVolNum";
		public const string InItemNum_Field = "InItemNum";
		public const string OutVolNum_Field = "OutVolNum";
		public const string OutItemNum_Field = "OutItemNum";
		public const string EndVolNum_Field = "EndVolNum";
		public const string EndItemNum_Field = "EndItemNum";
		public const string OpDate_Field = "OpDate";
		#endregion

		#region 属性
		//
		//TODO: 在此处添加属性。
		//
		#endregion
		
		#region 私有方法
		private void BuildDataTable()
		{
			// 创建　Sto 表．
			DataTable table   = new DataTable(YCL_Table);
			//添加字段。
			table.Columns.Add(PKID_Field, typeof(System.String));
			table.Columns.Add(PrvCode_Field, typeof(System.String));
			table.Columns.Add(PrvName_Field, typeof(System.String));
			table.Columns.Add(ItemCode_Field, typeof(System.String));
			table.Columns.Add(ItemName_Field, typeof(System.String));
			table.Columns.Add(UnitCode_Field, typeof(System.Int16));
			table.Columns.Add(UnitName_Field, typeof(System.String));
			table.Columns.Add(InVolNum_Field, typeof(System.Decimal));
			table.Columns.Add(InItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(OutVolNum_Field, typeof(System.Decimal));
			table.Columns.Add(OutItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(EndVolNum_Field, typeof(System.Decimal));
			table.Columns.Add(EndItemNum_Field, typeof(System.Decimal));
			table.Columns.Add(OpDate_Field, typeof(System.DateTime));
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
		public YCLData()
		{   
			this.BuildDataTable();
		}
		private YCLData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		#endregion
	}
}
