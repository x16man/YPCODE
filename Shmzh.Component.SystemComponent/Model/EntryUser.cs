// <copyright file="EntryUser.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;

    /// <summary>
	/// EntryUser 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class EntryUser : DataSet
	{
		/// <summary>
		/// 表名
		/// </summary>
		public const string MYSYSTEMUSERINFO_TABLE = "mySystemUserInfo";
		/// <summary>
		/// PKID
		/// </summary>
		public const string PKID_FIELD = "PKID";			
		/// <summary>
		/// 工号
		/// </summary>
		public const string EMPCODE_FIELD = "EmpCode";		
		/// <summary>
		/// 公司
		/// </summary>
		public const string EMPCO_FIELD = "EmpCo";			
		/// <summary>
		/// 部门
		/// </summary>
		public const string EMPDEPT_FIELD = "EmpDept";		
		/// <summary>
		/// 部门名称
		/// </summary>
		public const string DEPTCNNAME_FIELD = "DeptCnName";
		/// <summary>
		/// 部门英文名称
		/// </summary>
		public const string DEPTENNAME_FIELD = "DeptEnName";
		/// <summary>
		/// 用户中文姓名
		/// </summary>
		public const string EMPCNNAME_FIELD = "EmpCnName";	
		/// <summary>
		/// 用户英文姓名
		/// </summary>
		public const string EMPENNAME_FIELD = "EmpEnName";	
		/// <summary>
		/// 性别
		/// </summary>
		public const string GENDER_FIELD = "Gender";		
		/// <summary>
		/// 生日
		/// </summary>
		public const string BIRTHDAY_FIELD = "Birthday";	
		/// <summary>
		/// 用户名
		/// </summary>
		public const string LOGINNAME_FIELD = "LoginName";	
		/// <summary>
		/// 口令1
		/// </summary>
		public const string PASSWORD1_FIELD = "Password1";	
		/// <summary>
		/// 口令2
		/// </summary>
		public const string PASSWORD2_FIELD = "Password2";	
		/// <summary>
		/// 附加码
		/// </summary>
		public const string APPANDCODE_FIELD = "AppandCode";
		/// <summary>
		/// 员工状态
		/// </summary>
		public const string EMPSTATE_FIELD = "EmpState";	
		/// <summary>
		/// 职称编号
		/// </summary>
		public const string DUTYCODE_FIELD = "DutyCode";	
		/// <summary>
		/// 职称中文名称
		/// </summary>
		public const string DUTYCNNAME_FIELD = "DutyCnName";
		/// <summary>
		/// 职称英文名称
		/// </summary>
		public const string DUTYENNAME_FIELD = "DutyEnName";
		/// <summary>
		/// 身份证号
		/// </summary>
		public const string IDCARD_FIELD = "IDCard";
		/// <summary>
		/// 办公电话
		/// </summary>
		public const string OFFICECALL_FIELD = "OfficeCall";
		/// <summary>
		/// 办公电话分机
		/// </summary>
		public const string OFFICESUBCALL_FIELD = "OfficeSubCall";
		/// <summary>
		/// 移动电话
		/// </summary>
		public const string MOBILE_FIELD = "Mobile";
		/// <summary>
		/// 传真
		/// </summary>
		public const string OFFICEFAX_FIELD = "OfficeFax";
		/// <summary>
		/// 电邮
		/// </summary>
		public const string EMAIL_FIELD = "Email";	
		/// <summary>
		/// 是否是用户
		/// </summary>
		public const string ISUSER_FIELD = "IsUser";
		/// <summary>
		/// 用户状态
		/// </summary>
		public const string USERSTATE_FIELD = "UserState";
		/// <summary>
		/// 是否是员工
		/// </summary>
		public const string ISEMP_FIELD = "IsEmp";	
		/// <summary>
		/// 进公司日期
		/// </summary>
		public const string INDATE_FIELD = "InDate";		
		/// <summary>
		/// 是否离职
		/// </summary>
		public const string ISLEAVE_FIELD = "IsLeave";	
		/// <summary>
		/// 离职日期
		/// </summary>
		public const string LEAVEDATE_FIELD = "LeaveDate";	

		/// <summary>
		/// 构造函数
		/// </summary>
		public EntryUser()
		{
			this.BuildDataTable();
		}
		/// <summary>
		/// 创建数据表
		/// </summary>
		private void BuildDataTable()
		{
			// 创建　Sto 表．
			var table   = new DataTable(MYSYSTEMUSERINFO_TABLE);
			
            //添加字段。
			table.Columns.Add(PKID_FIELD, typeof(string));
			table.Columns.Add(EMPCODE_FIELD, typeof(string));
			table.Columns.Add(EMPCO_FIELD,typeof(string));
			table.Columns.Add(EMPDEPT_FIELD, typeof(string));
			table.Columns.Add(DEPTCNNAME_FIELD, typeof(string));

			table.Columns.Add(DEPTENNAME_FIELD, typeof(string));
			table.Columns.Add(EMPCNNAME_FIELD, typeof(string));
			table.Columns.Add(EMPENNAME_FIELD, typeof(string));
			table.Columns.Add(GENDER_FIELD, typeof(string));
			table.Columns.Add(BIRTHDAY_FIELD, typeof(DateTime));

			table.Columns.Add(LOGINNAME_FIELD, typeof(string));
			table.Columns.Add(PASSWORD1_FIELD, typeof(string));
			table.Columns.Add(PASSWORD2_FIELD, typeof(string));
			table.Columns.Add(APPANDCODE_FIELD, typeof(string));
			table.Columns.Add(EMPSTATE_FIELD, typeof(string));

			table.Columns.Add(DUTYCODE_FIELD, typeof(string));
			table.Columns.Add(DUTYCNNAME_FIELD, typeof(string));
			table.Columns.Add(DUTYENNAME_FIELD, typeof(string));
			table.Columns.Add(IDCARD_FIELD, typeof(string));
			table.Columns.Add(OFFICECALL_FIELD, typeof(string));

			table.Columns.Add(OFFICESUBCALL_FIELD, typeof(string));
			table.Columns.Add(MOBILE_FIELD, typeof(string));
			table.Columns.Add(OFFICEFAX_FIELD, typeof(string));
			table.Columns.Add(EMAIL_FIELD, typeof(string));
			table.Columns.Add(ISUSER_FIELD, typeof(string));

			table.Columns.Add(USERSTATE_FIELD, typeof(string));
			table.Columns.Add(ISEMP_FIELD, typeof(string));

			table.Columns.Add(INDATE_FIELD, typeof(DateTime));
			table.Columns.Add(ISLEAVE_FIELD, typeof(string));
			table.Columns.Add(LEAVEDATE_FIELD, typeof(DateTime));
			
            //向数据集中增加DataTable。
			this.Tables.Add(table);
		}
	}
}
