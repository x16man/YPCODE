// <copyright file="EntryDept.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;

    /// <summary>
	/// EntryDept 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class EntryDept : DataSet
	{
		/// <summary>
		/// 表名
		/// </summary>
		public const string MYSYSTEMDEPT_TABLE = "mySystemDept";		//.
		/// <summary>
		/// 部门编号
		/// </summary>
		public const string DEPTCODE_FIELD = "DeptCode";		//。
		/// <summary>
		/// 公司编号
		/// </summary>
		public const string DEPTCO_FIELD = "DeptCo";		//编号。
		/// <summary>
		/// 部门中文名称
		/// </summary>
		public const string DEPTCNNAME_FIELD = "DeptCnName";
		/// <summary>
		/// 部门英文名称
		/// </summary>
		public const string DEPTENNAME_FIELD = "DeptEnName";
		/// <summary>
		/// 上级部门
		/// </summary>
		public const string PARENTDEPT_FIELD = "ParentDept";
		/// <summary>
		/// 上级部门名称
		/// </summary>
		public const string PARENTDEPTNAME_FIELD = "ParentDeptName";
		/// <summary>
		/// 部门主管
		/// </summary>
		public const string DEPTMGR_FIELD = "DeptMgr";
		/// <summary>
		/// 创建日期
		/// </summary>
		public const string CREATEDATE_FIELD = "CreateDate";
		/// <summary>
		/// 是否有效
		/// </summary>
		public const string ISVALID_FIELD = "IsValid";
		/// <summary>
		/// 级别
		/// </summary>
		public const string DEPTLEVEL_FIELD = "DeptLevel";
		/// <summary>
		/// 描述
		/// </summary>
		public const string REMARK_FIELD = "Remark";
		/// <summary>
		/// 序号
		/// </summary>
		public const string SERIAL_FIELD = "Serial";
		/// <summary>
		/// 类型ID
		/// </summary>
		public const string TYPEID_FIELD = "TypeID";
		/// <summary>
		/// 类型名称
		/// </summary>
		public const string TYPENAME_FIELD = "TypeName";
		/// <summary>
		/// 部门主管用户名
		/// </summary>
		public const string DEPTMGRNAME_FIELD = "DeptMgrName";
		/// <summary>
		/// 成本中心
		/// </summary>
		public const string COSTCENTER_FIELD = "CostCenter";

		/// <summary>
		/// 成本中心
		/// </summary>
		public const string SHOWINOTHERSYS_FIELD = "ShowInOtherSys";

		/// <summary>
		/// 构造函数
		/// </summary>
		public EntryDept()
		{
			this.BuildDataTable();
		}
		/// <summary>
		/// 创建数据表
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　Sto 表．
			var table   = new DataTable(MYSYSTEMDEPT_TABLE);
			
            //添加字段。
			table.Columns.Add(DEPTCODE_FIELD, typeof(string));
			table.Columns.Add(DEPTCO_FIELD, typeof(string));
			table.Columns.Add(DEPTCNNAME_FIELD,typeof(string));
			table.Columns.Add(DEPTENNAME_FIELD, typeof(string));
			table.Columns.Add(PARENTDEPT_FIELD, typeof(string));
			table.Columns.Add(PARENTDEPTNAME_FIELD, typeof(string));
			table.Columns.Add(DEPTMGR_FIELD, typeof(string));

			table.Columns.Add(CREATEDATE_FIELD, typeof(DateTime));
			table.Columns.Add(ISVALID_FIELD, typeof(string));
			table.Columns.Add(DEPTLEVEL_FIELD, typeof(short));
			table.Columns.Add(REMARK_FIELD, typeof(string));
			table.Columns.Add(SERIAL_FIELD, typeof(short));
			table.Columns.Add(TYPEID_FIELD, typeof(string));
			table.Columns.Add(TYPENAME_FIELD, typeof(string));
			table.Columns.Add(DEPTMGRNAME_FIELD, typeof(string));
			table.Columns.Add(COSTCENTER_FIELD, typeof(string));
			table.Columns.Add(SHOWINOTHERSYS_FIELD, typeof(int));

			//向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
