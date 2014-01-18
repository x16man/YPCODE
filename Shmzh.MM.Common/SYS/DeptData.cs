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
	/// DeptData �ǲ��ű������ʵ��㣬���𴴽�һ��DEPT�����ݼ���
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class DeptData : DataSet
	{
		//���ݼ��鱨����Ϣ��
		public const string NO_OBJECT = "û�в������ݶ���";
		public const string NO_ROW = "û�в��������У�";
		public const string CODE_NOT_NULL = "���ű�Ų�����Ϊ�գ�";
		public const string DESCRIPTION_NOT_NULL = "�������Ʋ�����Ϊ�գ�";
		public const string CODE_NOT_UNIQUE = "���ű�Ų�Ψһ��";
		public const string DESCRIPTION_NOT_UNIQUE = "�������Ʋ�Ψһ��";
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "������������ʧ�ܣ�";
		public const string ADD_FAILED = "��Ӳ�������ʧ�ܣ�";
		public const string UPDATE_FAILED = "���Ĳ�������ʧ�ܣ�";
		public const string DELETE_FAILED = "ɾ����������ʧ�ܣ�";
		public const string ADD_SUCCESSED = "��Ӳ������ݳɹ���";
		public const string UPDATE_SUCCESSED = "���Ĳ������ݳɹ���";
		public const string DELETE_SUCCESSED = "ɾ���������ݳɹ���";
		//��ṹ��
		public const string Dept_Table = "DEPT";//����.
		public const string OldCode_Field = "OldCode";//�ɱ�š�
		public const string Code_Field = "CODE";//CODE�ֶΡ�
		public const string Description_Field = "DESCRIPTION";//Description�ֶΡ�
		/// <summary>
		/// DeptData��Ĺ��캯����newһ��DeptData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public DeptData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private DeptData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// ���������ݿ���DEPT���Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// ������DEPT ��
			DataTable table   = new DataTable(Dept_Table);
			//����ֶΡ�
			table.Columns.Add(OldCode_Field, typeof(System.String));
			table.Columns.Add(Code_Field, typeof(System.String));
			table.Columns.Add(Description_Field, typeof(System.String));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
