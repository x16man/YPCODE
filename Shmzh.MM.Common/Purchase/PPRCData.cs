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
	public class PPRCData : DataSet
	{
		//表结构。
		public const string PPRC_Table = "PPRC";
		public const string Code_Field = "Code";
		public const string CnName_Field = "CNName";
		public const string EnName_Field = "ENName";
		public const string Locked_Field = "Locked";
		public const string Desc_Field = "Desc";

		
		public PPRCData()
		{
			this.BuildDataTable ();//创建数据表。
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private PPRCData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 创建与数据库中DEPT表对应的一个DataTable。
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　DEPT 表．
			DataTable table   = new DataTable(PPRC_Table);
			//添加字段。
			table.Columns.Add(Code_Field, typeof(System.Int32));
			table.Columns.Add(CnName_Field, typeof(System.String));
			table.Columns.Add(EnName_Field, typeof(System.String));
			table.Columns.Add(Locked_Field, typeof(System.String));
			table.Columns.Add(Desc_Field, typeof(System.String));
			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
