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
	/// �ֿ����Ա����ʵ��㡣
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class StoManagerData : DataSet
	{
		//���ݼ��鱨����Ϣ��
		public const string NO_OBJECT = "û�вֿ����Ա���ݶ���";
		public const string NO_ROW = "û�вֿ�ֿ����Ա�����У�";
		public const string STOCODE_LABEL = "�ֿ���";
		public const string USERCODE_LABEL = "�ֿ�����";
		public const string DEPTCODE_LABEL = "���ű��";
		public const string STONAME_LABEL = "�ֿ�����";
		public const string USERNAME_LABEL = "����Ա����";
		public const string DEPTNAME_LABEL = "��������";
		public const string STOCODEUSERCODE_NOT_UNIQUE = "���ݲ�Ψһ��";
		
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "�����ֿ����Ա����ʧ�ܣ�";
		public const string ADD_FAILED = "��Ӳֿ����Ա����ʧ�ܣ�";
		public const string UPDATE_FAILED = "���Ĳֿ����Ա����ʧ�ܣ�";
		public const string DELETE_FAILED = "ɾ���ֿ����Ա����ʧ�ܣ�";
		public const string ADD_SUCCESSED = "��Ӳֿ����Ա���ݳɹ���";
		public const string UPDATE_SUCCESSED = "���Ĳֿ����Ա���ݳɹ���";
		public const string DELETE_SUCCESSED = "ɾ���ֿ����Ա���ݳɹ���";
		//��ṹ��
		public const string STOMANAGER_TABLE = "ViewStoManager";//����.
		public const string PKID_FIELD = "PKID";//������
		public const string STOCODE_FIELD  = "StoCode";//�ֿ��š�
		public const string STONAME_FIELD  = "StoName";//�ֿ����ơ�
		public const string USERCODE_FIELD = "UserCode";//����Ա��š�
		public const string USERNAME_FIELD = "UserName";//����Ա���ơ�
		public const string DEPTCODE_FIELD = "DeptCode";//���Ŵ��롣
		public const string DEPTNAME_FIELD = "DeptName";//�������ơ�
		/// <summary>
		/// StoManagerData��Ĺ��캯����newһ��StoManagerData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public StoManagerData()
		{
			this.BuildDataTable ();//�������ݱ�
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
		/// ���������ݿ���ViewStoManager��ͼ��Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// �����ֿ����Ա��
			DataTable table   = new DataTable(STOMANAGER_TABLE);
			//����ֶΡ�
			table.Columns.Add(PKID_FIELD, typeof(System.Int32));
			table.Columns.Add(STOCODE_FIELD, typeof(System.String));
			table.Columns.Add(STONAME_FIELD, typeof(System.String));
			table.Columns.Add(USERCODE_FIELD,typeof(System.String));
			table.Columns.Add(USERNAME_FIELD, typeof(System.String));
			table.Columns.Add(DEPTCODE_FIELD, typeof(System.String));
			table.Columns.Add(DEPTNAME_FIELD, typeof(System.String));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
