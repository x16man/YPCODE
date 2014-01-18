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
	/// UsrData 是用户的数据实体层，负责创建一个USR的数据集。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class UserData : DataSet
	{
		//数据检查报错信息。
		public const string NO_OBJECT = "没有用户数据对象！";
		public const string NO_ROW = "没有用户数据行！";
		public const string CODE_NOT_NULL = "用户工号不允许为空！";
		public const string LOGIN_NOT_NULL = "用户登录名不允许为空！";
		public const string DESCRIPTION_NOT_NULL = "用户姓名不允许为空！";
		public const string DEPT_NOT_NULL = "用户所属部门不允许为空！";
		public const string ENABLE_NOT_NULL = "禁用标志不能为空！";
		public const string CODE_NOT_UNIQUE = "用户工号不唯一！";
		public const string LOGIN_NOT_UNIQUE  = "用户登录名不唯一！";
		//存储过程执行情况反馈信息。
		public const string QUERY_FAILED = "检索用户数据失败！";
		public const string ADD_FAILED = "添加用户数据失败！";
		public const string UPDATE_FAILED = "更改用户数据失败！";
		public const string UPTPWD_FAILED = "更改用户口令失败！";
		public const string DELETE_FAILED = "删除用户数据失败！";
		public const string ENABLE_FAILED = "开放用户失败！";
		public const string DISABLE_FAILED = "禁用用户失败！";
		public const string ADD_SUCCESSED = "添加用户数据成功！";
		public const string UPDATE_SUCCESSED = "更改用户数据成功！";
		public const string UPTPWD_SUCCESSED = "更改用户口令成功！";
		public const string DELETE_SUCCESSED = "删除用户数据成功！";
		public const string ENABLE_SUCCESSED = "开放用户成功！";
		public const string DISABLE_SUCCESSED = "禁用用户成功！";
		//表结构。
		public const string User_Table = "USER";  //USR表名。
		public const string OldCode_Field = "OldCode";//旧代码。
		public const string Code_Field = "Code";//用户工号。
		public const string LoginName_Field = "LoginName";//登录名称。
		public const string Description_Field = "Description";//用户姓名。
		public const string PWD_Field = "PWD";  //用户口令。
		public const string DeptCode_Field = "DeptCode";//所属部门编号。
		public const string DeptName_Field = "DeptName";//所属部门名称。
		public const string Enable_Field = "Enable";//禁用。
		public UserData()
		{
			this.BuildTable ();
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private UserData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// 创建USR的数据表，并添加到数据集中。
		/// </summary>
		private void BuildTable()
		{
			DataTable table = new DataTable(User_Table);//用户表。
			//字段添加。
			table.Columns.Add ( OldCode_Field, typeof(System.String));
			table.Columns.Add ( Code_Field, typeof(System.String));
			table.Columns.Add ( LoginName_Field, typeof(System.String));
			table.Columns.Add ( Description_Field, typeof(System.String));
			table.Columns.Add ( PWD_Field,  typeof(System.Byte[]));
			table.Columns.Add ( DeptCode_Field, typeof(System.String));
			table.Columns .Add (DeptName_Field, typeof(System.String ));
			table.Columns .Add (Enable_Field, typeof(System.Int32));
			//添加数据表到数据集。
			this.Tables .Add (table);
			
		}
	}
}
