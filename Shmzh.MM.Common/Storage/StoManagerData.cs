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
	/// 仓库管理员数据实体层。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class StoManagerData : DataSet
	{
		//数据检验报错信息。
		public const string NO_OBJECT = "没有仓库管理员数据对象！";
		public const string NO_ROW = "没有仓库仓库管理员数据行！";
		public const string STOCODE_LABEL = "仓库编号";
		public const string USERCODE_LABEL = "仓库名称";
		public const string DEPTCODE_LABEL = "部门编号";
		public const string STONAME_LABEL = "仓库名称";
		public const string USERNAME_LABEL = "管理员名称";
		public const string DEPTNAME_LABEL = "部门名称";
		public const string STOCODEUSERCODE_NOT_UNIQUE = "数据不唯一！";
		
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索仓库管理员数据失败！";
		public const string ADD_FAILED = "添加仓库管理员数据失败！";
		public const string UPDATE_FAILED = "更改仓库管理员数据失败！";
		public const string DELETE_FAILED = "删除仓库管理员数据失败！";
		public const string ADD_SUCCESSED = "添加仓库管理员数据成功！";
		public const string UPDATE_SUCCESSED = "更改仓库管理员数据成功！";
		public const string DELETE_SUCCESSED = "删除仓库管理员数据成功！";
		//表结构。
		public const string STOMANAGER_TABLE = "ViewStoManager";//表名.
		public const string PKID_FIELD = "PKID";//主键。
		public const string STOCODE_FIELD  = "StoCode";//仓库编号。
		public const string STONAME_FIELD  = "StoName";//仓库名称。
		public const string USERCODE_FIELD = "UserCode";//管理员编号。
		public const string USERNAME_FIELD = "UserName";//管理员名称。
		public const string DEPTCODE_FIELD = "DeptCode";//部门代码。
		public const string DEPTNAME_FIELD = "DeptName";//部门名称。
		/// <summary>
		/// StoManagerData类的构造函数，new一个StoManagerData类的时候，就创建一个数据集。
		/// </summary>
		public StoManagerData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private StoManagerData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 创建与数据库中ViewStoManager视图对应的一个DataTable。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建仓库管理员表．
			DataTable table   = new DataTable(STOMANAGER_TABLE);
			//添加字段。
			table.Columns.Add(PKID_FIELD, typeof(System.Int32));
			table.Columns.Add(STOCODE_FIELD, typeof(System.String));
			table.Columns.Add(STONAME_FIELD, typeof(System.String));
			table.Columns.Add(USERCODE_FIELD,typeof(System.String));
			table.Columns.Add(USERNAME_FIELD, typeof(System.String));
			table.Columns.Add(DEPTCODE_FIELD, typeof(System.String));
			table.Columns.Add(DEPTNAME_FIELD, typeof(System.String));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
