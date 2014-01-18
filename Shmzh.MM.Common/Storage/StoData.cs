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
	public class StoData : DataSet
	{
		//数据检验报错信息。
		public const string NO_OBJECT = "没有仓库数据对象！";
		public const string NO_ROW = "没有仓库数据行！";
		public const string CODE_NOT_NULL = "仓库编号";
		public const string DESCRIPTION_NOT_NULL = "仓库名称";
		public const string LOCKED_NOT_NULL = "锁定";
		public const string STOACC_NULL = "库存科目";
		public const string TRFACC_NULL = "转帐科目";
		public const string RETURNACC_NULL = "退货科目";
		public const string ADDRESS_NULL = "地址";
		public const string RELATION_NULL = "联系人";
		public const string CODE_NOT_UNIQUE = "仓库编号不唯一！";
		public const string DESCRIPTION_NOT_UNIQUE = "仓库名称不唯一！";
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索仓库数据失败！";
		public const string ADD_FAILED = "添加仓库数据失败！";
		public const string UPDATE_FAILED = "更改仓库数据失败！";
		public const string DELETE_FAILED = "删除仓库数据失败！";
		public const string ADD_SUCCESSED = "添加仓库数据成功！";
		public const string UPDATE_SUCCESSED = "更改仓库数据成功！";
		public const string DELETE_SUCCESSED = "删除仓库数据成功！";
		//表结构。
		public const string STO_TABLE = "StoCon";//表名.
		public const string CODE_FIELD = "Code";//编号。
		public const string DESCRIPTION_FIELD = "Description";//名称。
		public const string LOCKED_FIELD = "Locked";//锁定。
		public const string STOACC_FIELD = "StorageAcc";//存货科目.
		public const string TRFACC_FIELD = "TransferAcc";//转帐科目.
		public const string RETURNACC_FIELD = "ReturnAcc";//退货科目。
        public const string ADDRESS_FIELD = "Address";//地址。
		public const string RELATION_FIELD = "Relation";//联系。

		/// <summary>
		/// StoData类的构造函数，new一个StoData类的时候，就创建一个数据集。
		/// </summary>
		public StoData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private StoData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 创建与数据库中DEPT表对应的一个DataTable。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　Sto 表．
			DataTable table   = new DataTable(STO_TABLE);
			//添加字段。
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(LOCKED_FIELD,typeof(System.String));
            table.Columns.Add(STOACC_FIELD, typeof(System.String));
			table.Columns.Add(TRFACC_FIELD, typeof(System.String));
			table.Columns.Add(RETURNACC_FIELD, typeof(System.String));
			table.Columns.Add(ADDRESS_FIELD, typeof(System.String));
			table.Columns.Add(RELATION_FIELD, typeof(System.String));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
