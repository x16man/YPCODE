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
	/// StoConData 是仓库架位表的数据实体层，负责创建一个StoCon的数据实体。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class ClassifyData : DataSet
	{
		//数据检验报错信息。
		public const string NO_OBJECT = "没有用途分类数据对象！";
		public const string NO_ROW = "没有用途分类数据行！";
		public const string CODE_LABEL = "用途分类";
		public const string DESCRIPTION_LABEL = "分类名称";
		public const string LOCKED_LABEL = "锁定";
		public const string TARGETACC_LABEL = "目标科目";
		public const string ENABLE_LABEL = "是否有效";
		public const string CODE_NOT_UNIQUE = "用途分类代码不唯一！";
		public const string DESCRIPTION_NOT_UNIQUE = "用途分类名称不唯一！";
		public const string HAS_CHILD_CLASSIFY = "此用途拥有子用途，请先删除其子用途！";
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索用途分类数据失败！";
		public const string ADD_FAILED = "添加用途分类数据失败！";
		public const string UPDATE_FAILED = "更改用途分类数据失败！";
		public const string DELETE_FAILED = "删除用途分类数据失败！";
		public const string ADD_SUCCESSED = "添加用途分类数据成功！";
		public const string UPDATE_SUCCESSED = "更改用途分类数据成功！";
		public const string DELETE_SUCCESSED = "删除用途分类数据成功！";
		//表结构。
		public const string CLASSFIY_TABLE = "WCLS";//用途表名.
		public const string OLDCODE_FIELD = "OldClassifyID";//旧用途代码。
		public const string CODE_FIELD = "ClassifyID";//用途代码。
		public const string DESCRIPTION_FIELD = "Description";//用途名称。
		public const string PARENT_CODE_FIELD = "ParentID";//父用途ID
		public const string ENABLE_FIELD = "Enable";//是否有效。
		public const string LOCKED_FIELD = "Locked";//锁定。

		/// <summary>
		/// UseData类的构造函数，new一个UseData类的时候，就创建一个数据集。
		/// </summary>
		public ClassifyData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		public int Count
		{
			get { return this.Tables[0].Rows.Count;}
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private ClassifyData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 创建与数据库中WUSE表对应的一个DataTable。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　用途 表．
			DataTable table   = new DataTable(CLASSFIY_TABLE);
			//添加字段。
			table.Columns.Add(OLDCODE_FIELD, typeof(System.String));
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(PARENT_CODE_FIELD,typeof(System.String));
			table.Columns.Add(ENABLE_FIELD, typeof(System.Int32));
			table.Columns.Add(LOCKED_FIELD,typeof(System.String));

			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
