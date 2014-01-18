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
	/// UsrData ���û�������ʵ��㣬���𴴽�һ��USR�����ݼ���
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class UserData : DataSet
	{
		//���ݼ�鱨����Ϣ��
		public const string NO_OBJECT = "û���û����ݶ���";
		public const string NO_ROW = "û���û������У�";
		public const string CODE_NOT_NULL = "�û����Ų�����Ϊ�գ�";
		public const string LOGIN_NOT_NULL = "�û���¼��������Ϊ�գ�";
		public const string DESCRIPTION_NOT_NULL = "�û�����������Ϊ�գ�";
		public const string DEPT_NOT_NULL = "�û��������Ų�����Ϊ�գ�";
		public const string ENABLE_NOT_NULL = "���ñ�־����Ϊ�գ�";
		public const string CODE_NOT_UNIQUE = "�û����Ų�Ψһ��";
		public const string LOGIN_NOT_UNIQUE  = "�û���¼����Ψһ��";
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "�����û�����ʧ�ܣ�";
		public const string ADD_FAILED = "����û�����ʧ�ܣ�";
		public const string UPDATE_FAILED = "�����û�����ʧ�ܣ�";
		public const string UPTPWD_FAILED = "�����û�����ʧ�ܣ�";
		public const string DELETE_FAILED = "ɾ���û�����ʧ�ܣ�";
		public const string ENABLE_FAILED = "�����û�ʧ�ܣ�";
		public const string DISABLE_FAILED = "�����û�ʧ�ܣ�";
		public const string ADD_SUCCESSED = "����û����ݳɹ���";
		public const string UPDATE_SUCCESSED = "�����û����ݳɹ���";
		public const string UPTPWD_SUCCESSED = "�����û�����ɹ���";
		public const string DELETE_SUCCESSED = "ɾ���û����ݳɹ���";
		public const string ENABLE_SUCCESSED = "�����û��ɹ���";
		public const string DISABLE_SUCCESSED = "�����û��ɹ���";
		//��ṹ��
		public const string User_Table = "USER";  //USR������
		public const string OldCode_Field = "OldCode";//�ɴ��롣
		public const string Code_Field = "Code";//�û����š�
		public const string LoginName_Field = "LoginName";//��¼���ơ�
		public const string Description_Field = "Description";//�û�������
		public const string PWD_Field = "PWD";  //�û����
		public const string DeptCode_Field = "DeptCode";//�������ű�š�
		public const string DeptName_Field = "DeptName";//�����������ơ�
		public const string Enable_Field = "Enable";//���á�
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
		/// ����USR�����ݱ�����ӵ����ݼ��С�
		/// </summary>
		private void BuildTable()
		{
			DataTable table = new DataTable(User_Table);//�û���
			//�ֶ���ӡ�
			table.Columns.Add ( OldCode_Field, typeof(System.String));
			table.Columns.Add ( Code_Field, typeof(System.String));
			table.Columns.Add ( LoginName_Field, typeof(System.String));
			table.Columns.Add ( Description_Field, typeof(System.String));
			table.Columns.Add ( PWD_Field,  typeof(System.Byte[]));
			table.Columns.Add ( DeptCode_Field, typeof(System.String));
			table.Columns .Add (DeptName_Field, typeof(System.String ));
			table.Columns .Add (Enable_Field, typeof(System.Int32));
			//������ݱ����ݼ���
			this.Tables .Add (table);
			
		}
	}
}
