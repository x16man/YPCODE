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
	/// PslpData 是采购员表的数据实体层，负责创建一个PSLP的数据集。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PslpData : DataSet
	{
		//数据输入检验报错信息。
		public const string NO_OBJECT = "没有采购员数据对象！";
		public const string NO_ROW = "没有采购员数据行！";
		public const string CODE_LABEL = "采购员代码";
		public const string DESCRIPTION_LABEL = "采购员名称";
		public const string LOCKED_LABEL = "锁定";
		//唯一性检验报错信息。
		public const string CODE_NOT_UNIQUE = "采购员代码不唯一！";
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索采购员数据失败！";
		public const string ADD_FAILED = "添加采购员数据失败！";
		public const string ADD_SUCCESSED = "添加采购员数据成功！";
		public const string UPDATE_FAILED = "更改采购员数据失败！";
		public const string UPDATE_SUCCESSED = "更改采购员数据成功！";
		public const string DELETE_FAILED = "删除采购员数据失败！";
		public const string DELETE_SUCCESSED = "删除采购员数据成功！";
		//表结构。
		public const string PSLP_TABLE = "PSLP";//采购员表名.
		public const string OLDCODE_FIELD = "OLDCODE";//采购员旧代码。
		public const string CODE_FIELD = "CODE";//采购员代码。
		public const string DESCRIPTION_FIELD = "DESCRIPTION";//采购员姓名。
		public const string LOCKED_FIELD = "LOCKED";//是否锁定。
		/// <summary>
		/// PslpData类的构造函数，new一个PslpData类的时候，就创建一个数据集。
		/// </summary>
		public PslpData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private PslpData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 创建与数据库中PSLP表对应的一个DataTable。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　PSLP 表．
			DataTable table   = new DataTable(PSLP_TABLE);
			//添加字段。
			table.Columns.Add(OLDCODE_FIELD, typeof(System.String));
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(LOCKED_FIELD, typeof(System.String));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
