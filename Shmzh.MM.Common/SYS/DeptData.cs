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
	/// DeptData 是部门表的数据实体层，负责创建一个DEPT的数据集。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class DeptData : DataSet
	{
		//数据检验报错信息。
		public const string NO_OBJECT = "没有部门数据对象！";
		public const string NO_ROW = "没有部门数据行！";
		public const string CODE_NOT_NULL = "部门编号不允许为空！";
		public const string DESCRIPTION_NOT_NULL = "部门名称不允许为空！";
		public const string CODE_NOT_UNIQUE = "部门编号不唯一！";
		public const string DESCRIPTION_NOT_UNIQUE = "部门名称不唯一！";
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索部门数据失败！";
		public const string ADD_FAILED = "添加部门数据失败！";
		public const string UPDATE_FAILED = "更改部门数据失败！";
		public const string DELETE_FAILED = "删除部门数据失败！";
		public const string ADD_SUCCESSED = "添加部门数据成功！";
		public const string UPDATE_SUCCESSED = "更改部门数据成功！";
		public const string DELETE_SUCCESSED = "删除部门数据成功！";
		//表结构。
		public const string Dept_Table = "DEPT";//表名.
		public const string OldCode_Field = "OldCode";//旧编号。
		public const string Code_Field = "CODE";//CODE字段。
		public const string Description_Field = "DESCRIPTION";//Description字段。
		/// <summary>
		/// DeptData类的构造函数，new一个DeptData类的时候，就创建一个数据集。
		/// </summary>
		public DeptData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private DeptData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 创建与数据库中DEPT表对应的一个DataTable。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　DEPT 表．
			DataTable table   = new DataTable(Dept_Table);
			//添加字段。
			table.Columns.Add(OldCode_Field, typeof(System.String));
			table.Columns.Add(Code_Field, typeof(System.String));
			table.Columns.Add(Description_Field, typeof(System.String));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
