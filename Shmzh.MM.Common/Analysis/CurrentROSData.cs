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
**		文件: CurrentROSData.cs
**		名称: CurrentROSData
**		描述: 本月采购申请审批状态分布图。
**
**              
**		作者: 张豪
**		日期: 2005-11-17
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
	public class CurrentROSData :DataSet
	{
		#region 成员变量
		public const string ROS_Table = "ROS";
		public const string ResultCode_Field = "ResultCode";
		public const string Result_Field = "Result";
		public const string Count_Field = "Count";
		public const string SubTotal_Field = "SubTotal";
		#endregion

		#region 属性
		public int Count
		{
			get {return this.Tables[0].Rows.Count;}
		}
		public int[] ResultCode
		{
			get
			{
				int[] myResultCode = new int[this.Count];
				for (int i = 0; i< this.Count; i ++)
				{
					myResultCode[i] = int.Parse(this.Tables[0].Rows[i][ResultCode_Field].ToString());
				}
				return myResultCode;
			}
		}
		public string[] Result
		{
			get
			{
				string[] myResult = new string[this.Count];
				for (int i = 0; i< this.Count; i ++)
				{
					myResult[i] = this.Tables[0].Rows[i][Result_Field].ToString();
				}
				return myResult;
			}
		}
		public int[] DocCount
		{
			get
			{
				int[] myCount = new int[this.Count];
				for (int i = 0; i< this.Count; i ++)
				{
					myCount[i] = int.Parse(this.Tables[0].Rows[i][Count_Field].ToString());
				}
				return myCount;
			}
		}
		public decimal[] SubTotal
		{
			get
			{
				decimal[] mySubTotal = new decimal[this.Count];
				for (int i = 0; i< this.Count; i ++)
				{
					try
					{
						mySubTotal[i] = decimal.Parse(this.Tables[0].Rows[i][SubTotal_Field].ToString());
					}
					catch
					{}
				}
				return mySubTotal;
			}
		}
		#endregion
		
		#region 私有方法
		private void BuildDataTable()
		{
			DataTable table   = new DataTable(ROS_Table);
			//添加字段。
			table.Columns.Add(ResultCode_Field, typeof(System.Int32));
			table.Columns.Add(Result_Field, typeof(System.String));
			table.Columns.Add(Count_Field, typeof(System.Decimal));
			table.Columns.Add(SubTotal_Field, typeof(System.Decimal));
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
		private CurrentROSData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public CurrentROSData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		#endregion
	}
}
