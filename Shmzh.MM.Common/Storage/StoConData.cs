//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	/// <summary>
	/// INV_CD 库 存 代 码.
	/// </summary>
	[SerializableAttribute]
	public class INV_CD
	{
		public static string  OWN_CODE
		{
			get {return "O";}
		}
		public static string  OWN_DESCRIPTION
		{
			get {return "现有";}
		}
		public static string HIDE_CODE
		{
			get{return "H";}
		}
		public static string HIDE_DESCRIPTION
		{
			get{return "封存";}
		}
		public static string SEND_CODE
		{
			get{return "S";}
		}
		public static string SEND_DESCRIPTION
		{
			get{return "待运";}
		}
		public static string INCHECK_CODE
		{
			get{return "I";}
		}
		public static string INCHECK_DESCRIPTION
		{
			get{return "在检";}
		}
		public static string ALL_CODE
		{
			get{return "A";}
		}
		public static string ALL_DESCRIPTION
		{
			get{return "全部";}
		}
		public static int Count
		{
			get{return 5;}
		}
	}
	/// <summary>
	/// StoConData 是仓库架位表的数据实体层，负责创建一个StoCon的数据实体。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class StoConData : DataSet
	{
		#region 成员变量
		//数据检验报错信息。
		public const string NO_OBJECT = "没有架位数据对象！";
		public const string NO_ROW = "没有架位数据行！";
		public const string CODE_NOT_NULL = "架位编号";
		public const string DESCRIPTION_NOT_NULL = "架位名称";
		public const string CODE_NOT_UNIQUE = "架位编号不唯一！";
		public const string DESCRIPTION_NOT_UNIQUE = "架位名称不唯一！";
		public const string AREA_NOT_DECIMAL = "池位面积要为数字";
		
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索架位数据失败！";
		public const string ADD_FAILED = "添加架位数据失败！";
		public const string UPDATE_FAILED = "更改架位数据失败！";
		public const string DELETE_FAILED = "删除架位数据失败！";
		public const string ADD_SUCCESSED = "添加架位数据成功！";
		public const string UPDATE_SUCCESSED = "更改架位数据成功！";
		public const string DELETE_SUCCESSED = "删除架位数据成功！";
		//表结构。
		public const string STOCON_TABLE = "StoCon";//表名.
		public const string CODE_FIELD = "CODE";//编号。
		public const string STOCODE_FIELD = "StoCode";//仓库编号。
		public const string DESCRIPTION_FIELD = "DESCRIPTION";//名称。
		public const string STATUS_FIELD = "STATUS";//状态。
		public const string LOCKED_FIELD = "LOCKED";//锁定。
		public const string AREA_FIELD = "Area";    //面积。
		#endregion

		#region 属性
		/// <summary>
		/// 架位的面积，应该只在池位时用到。
		/// </summary>
		public decimal Area
		{
			get {	return Convert.ToDecimal(this.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.AREA_FIELD].ToString());}
		}
		#endregion

		#region 构造函数
		/// <summary>
		/// DeptData类的构造函数，new一个DeptData类的时候，就创建一个数据集。
		/// </summary>
		public StoConData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private StoConData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 创建与数据库中DEPT表对应的一个DataTable。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　DEPT 表．
			DataTable table   = new DataTable(STOCON_TABLE);
			//添加字段。
			table.Columns.Add(CODE_FIELD, typeof(System.Int32));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(STOCODE_FIELD, typeof(System.String));
			table.Columns.Add(STATUS_FIELD, typeof(System.String));
			table.Columns.Add(LOCKED_FIELD, typeof(System.String));
			table.Columns.Add(AREA_FIELD, typeof(System.Decimal));

			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
		#endregion
	}
}
