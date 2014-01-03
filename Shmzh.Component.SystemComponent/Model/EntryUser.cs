// <copyright file="EntryUser.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Data;

    /// <summary>
	/// EntryUser ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class EntryUser : DataSet
	{
		/// <summary>
		/// ����
		/// </summary>
		public const string MYSYSTEMUSERINFO_TABLE = "mySystemUserInfo";
		/// <summary>
		/// PKID
		/// </summary>
		public const string PKID_FIELD = "PKID";			
		/// <summary>
		/// ����
		/// </summary>
		public const string EMPCODE_FIELD = "EmpCode";		
		/// <summary>
		/// ��˾
		/// </summary>
		public const string EMPCO_FIELD = "EmpCo";			
		/// <summary>
		/// ����
		/// </summary>
		public const string EMPDEPT_FIELD = "EmpDept";		
		/// <summary>
		/// ��������
		/// </summary>
		public const string DEPTCNNAME_FIELD = "DeptCnName";
		/// <summary>
		/// ����Ӣ������
		/// </summary>
		public const string DEPTENNAME_FIELD = "DeptEnName";
		/// <summary>
		/// �û���������
		/// </summary>
		public const string EMPCNNAME_FIELD = "EmpCnName";	
		/// <summary>
		/// �û�Ӣ������
		/// </summary>
		public const string EMPENNAME_FIELD = "EmpEnName";	
		/// <summary>
		/// �Ա�
		/// </summary>
		public const string GENDER_FIELD = "Gender";		
		/// <summary>
		/// ����
		/// </summary>
		public const string BIRTHDAY_FIELD = "Birthday";	
		/// <summary>
		/// �û���
		/// </summary>
		public const string LOGINNAME_FIELD = "LoginName";	
		/// <summary>
		/// ����1
		/// </summary>
		public const string PASSWORD1_FIELD = "Password1";	
		/// <summary>
		/// ����2
		/// </summary>
		public const string PASSWORD2_FIELD = "Password2";	
		/// <summary>
		/// ������
		/// </summary>
		public const string APPANDCODE_FIELD = "AppandCode";
		/// <summary>
		/// Ա��״̬
		/// </summary>
		public const string EMPSTATE_FIELD = "EmpState";	
		/// <summary>
		/// ְ�Ʊ��
		/// </summary>
		public const string DUTYCODE_FIELD = "DutyCode";	
		/// <summary>
		/// ְ����������
		/// </summary>
		public const string DUTYCNNAME_FIELD = "DutyCnName";
		/// <summary>
		/// ְ��Ӣ������
		/// </summary>
		public const string DUTYENNAME_FIELD = "DutyEnName";
		/// <summary>
		/// ���֤��
		/// </summary>
		public const string IDCARD_FIELD = "IDCard";
		/// <summary>
		/// �칫�绰
		/// </summary>
		public const string OFFICECALL_FIELD = "OfficeCall";
		/// <summary>
		/// �칫�绰�ֻ�
		/// </summary>
		public const string OFFICESUBCALL_FIELD = "OfficeSubCall";
		/// <summary>
		/// �ƶ��绰
		/// </summary>
		public const string MOBILE_FIELD = "Mobile";
		/// <summary>
		/// ����
		/// </summary>
		public const string OFFICEFAX_FIELD = "OfficeFax";
		/// <summary>
		/// ����
		/// </summary>
		public const string EMAIL_FIELD = "Email";	
		/// <summary>
		/// �Ƿ����û�
		/// </summary>
		public const string ISUSER_FIELD = "IsUser";
		/// <summary>
		/// �û�״̬
		/// </summary>
		public const string USERSTATE_FIELD = "UserState";
		/// <summary>
		/// �Ƿ���Ա��
		/// </summary>
		public const string ISEMP_FIELD = "IsEmp";	
		/// <summary>
		/// ����˾����
		/// </summary>
		public const string INDATE_FIELD = "InDate";		
		/// <summary>
		/// �Ƿ���ְ
		/// </summary>
		public const string ISLEAVE_FIELD = "IsLeave";	
		/// <summary>
		/// ��ְ����
		/// </summary>
		public const string LEAVEDATE_FIELD = "LeaveDate";	

		/// <summary>
		/// ���캯��
		/// </summary>
		public EntryUser()
		{
			this.BuildDataTable();
		}
		/// <summary>
		/// �������ݱ�
		/// </summary>
		private void BuildDataTable()
		{
			// ������Sto ��
			var table   = new DataTable(MYSYSTEMUSERINFO_TABLE);
			
            //����ֶΡ�
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
			
            //�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
