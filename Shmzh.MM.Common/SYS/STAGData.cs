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
**		文件: STAG.cs
**		名称: 数据采集系统配置信息的实体层。
**		描述: 记录批量进货单涉及到的数据采集系统的配置信息和缺省物料信息和仓库
**			  信息。
**              
**		作者: 张豪
**		日期: 2005-05-09
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
	/// STAGData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class STAGData:DataSet
	{
		#region 成员变量
		/// <summary>
		/// 查询失败出错信息 。
		/// </summary>
		public const string QUERY_FAILED = "数据采集系统配置信息查询失败！";
		/// <summary>
		/// 数据采集系统配置表。
		/// </summary>
		public const string STAG_Table = "STAG";
		/// <summary>
		/// 数据采集系统的服务器地址。
		/// </summary>
		public const string SvrADD_Field = "SvrAdd";
		/// <summary>
		/// 数据采集系统的数据库名称。
		/// </summary>
		public const string DBName_Field = "DBName";
		/// <summary>
		/// 数据采集系统的用户名。
		/// </summary>
		public const string UserName_Field = "UserName";
		/// <summary>
		/// 数据采集系统的口令。
		/// </summary>
		public const string PWD_Field = "PWD";
		/// <summary>
		/// 物料编号。
		/// </summary>
		public const string ItemCode_Field = "ItemCode";
		/// <summary>
		/// 仓库编号。
		/// </summary>
		public const string StoCode_Field = "StoCode";
		/// <summary>
		/// 实收体积。
		/// </summary>
		public const string VolumnItem_Field = "VolumnItem";
		/// <summary>
		/// 氧化铝浓度。
		/// </summary>
		public const string ThicknessItem_Field = "ThicknessItem";
		/// <summary>
		/// 相对密度。
		/// </summary>
		public const string DensityItem_Field = "DensityItem";
		/// <summary>
		/// 铁含量。
		/// </summary>
		public const string FeItem_Field = "FeItem";
		/// <summary>
		/// 折固数。
		/// </summary>
		public const string SolidItem_Field = "SolidItem";
		/// <summary>
		/// 待检池1。
		/// </summary>
		public const string ConCode1_Field = "ConCode1";
		/// <summary>
		/// 待检池2。
		/// </summary>
		public const string ConCode2_Field = "ConCode2";
		/// <summary>
		/// 待检池1的液位指标号。
		/// </summary>
		public const string TagCode1_Field = "TagCode1";
		/// <summary>
		/// 待检池2的液位指标号。
		/// </summary>
		public const string TagCode2_Field = "TagCode2";
		
		#endregion

		#region 属性
		/// <summary>
		/// 记录集数量。
		/// </summary>
		public int Count
		{
			get {	return this.Tables[STAGData.STAG_Table].Rows.Count;	}
		}
		/// <summary>
		/// 数据采集系统服务器地址。
		/// </summary>
		public string ServerAddress
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.SvrADD_Field].ToString():null;	}
		}
		/// <summary>
		/// 数据采集系统数据库名称。
		/// </summary>
		public string DBName
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.DBName_Field].ToString():null;	}
		}
		/// <summary>
		/// 数据采集系统用户登录名。
		/// </summary>
		public string UserName
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.UserName_Field].ToString():null;	}
		}
		/// <summary>
		/// 数据采集系统用户口令。
		/// </summary>
		public string PassWord
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.PWD_Field].ToString():null;	}
		}
		/// <summary>
		/// 缺省物料编号。
		/// </summary>
		public string ItemCode
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.ItemCode_Field].ToString():null;	}
		}
		/// <summary>
		/// 缺省仓库编号。
		/// </summary>
		public string StoCode
		{
			get {	return this.Count > 0 ? this.Tables[STAGData.STAG_Table].Rows[0][STAGData.StoCode_Field].ToString():null;	}
		}
		/// <summary>
		/// 实收体积。
		/// </summary>
		public int VolumnItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.VolumnItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// 氧化铝浓度。
		/// </summary>
		public int ThicknessItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.ThicknessItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// 相对密度。
		/// </summary>
		public int DensityItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.DensityItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// 铁含量。
		/// </summary>
		public int FeItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.FeItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// 折固数。
		/// </summary>
		public int SolidItem
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.SolidItem_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// 待检池1。
		/// </summary>
		public int ConCode1
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.ConCode1_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// 待检池2。
		/// </summary>
		public int ConCode2
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.ConCode2_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// 待检池1液位指标。
		/// </summary>
		public int TagCode1
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.TagCode1_Field].ToString()):Convert.ToInt32(null);	}
		}
		/// <summary>
		/// 待检池2液位指标。
		/// </summary>
		public int TagCode2
		{
			get {	return this.Count > 0 ? int.Parse(this.Tables[STAGData.STAG_Table].Rows[0][STAGData.TagCode2_Field].ToString()):Convert.ToInt32(null);	}
		}
		#endregion
		
		#region 私有方法
		private void BuildDataTable()
		{
			// 创建　STAG 表．
			DataTable table   = new DataTable(STAGData.STAG_Table);
			//添加字段。
			table.Columns.Add(STAGData.SvrADD_Field, typeof(System.String));
			table.Columns.Add(STAGData.DBName_Field, typeof(System.String));
			table.Columns.Add(STAGData.UserName_Field, typeof(System.String));
			table.Columns.Add(STAGData.PWD_Field, typeof(System.String));
			table.Columns.Add(STAGData.ItemCode_Field, typeof(System.String));
			table.Columns.Add(STAGData.StoCode_Field, typeof(System.String));
			table.Columns.Add(STAGData.VolumnItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.ThicknessItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.DensityItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.FeItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.SolidItem_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.ConCode1_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.ConCode2_Field, typeof(System.Int32));
			table.Columns.Add(STAGData.TagCode1_Field, typeof(System.String));
			table.Columns.Add(STAGData.TagCode2_Field, typeof(System.String));

			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
		#endregion

		#region 公开方法
		/// <summary>
		/// 获取PLC的指标刻度值。
		/// </summary>
		/// <param name="ConCode">int:	池位。</param>
		/// <param name="time">Datetime:	时间点。</param>
		/// <returns>decimal:	指标刻度值。</returns>
		public decimal GetPLCValue(int ConCode,DateTime time)
		{
			return 50;
		}
		#endregion

		#region 构造函数
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private STAGData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}	
		/// <summary>
		/// STAGData类的构造函数，new一个STAGData类的时候，就创建一个数据集。
		/// </summary>
		public STAGData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		#endregion
	}
}
