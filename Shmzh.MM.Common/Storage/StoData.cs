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
	/// StoConData �ǲֿ��λ�������ʵ��㣬���𴴽�һ��StoCon������ʵ�塣
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class StoData : DataSet
	{
		//���ݼ��鱨����Ϣ��
		public const string NO_OBJECT = "û�вֿ����ݶ���";
		public const string NO_ROW = "û�вֿ������У�";
		public const string CODE_NOT_NULL = "�ֿ���";
		public const string DESCRIPTION_NOT_NULL = "�ֿ�����";
		public const string LOCKED_NOT_NULL = "����";
		public const string STOACC_NULL = "����Ŀ";
		public const string TRFACC_NULL = "ת�ʿ�Ŀ";
		public const string RETURNACC_NULL = "�˻���Ŀ";
		public const string ADDRESS_NULL = "��ַ";
		public const string RELATION_NULL = "��ϵ��";
		public const string CODE_NOT_UNIQUE = "�ֿ��Ų�Ψһ��";
		public const string DESCRIPTION_NOT_UNIQUE = "�ֿ����Ʋ�Ψһ��";
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "�����ֿ�����ʧ�ܣ�";
		public const string ADD_FAILED = "��Ӳֿ�����ʧ�ܣ�";
		public const string UPDATE_FAILED = "���Ĳֿ�����ʧ�ܣ�";
		public const string DELETE_FAILED = "ɾ���ֿ�����ʧ�ܣ�";
		public const string ADD_SUCCESSED = "��Ӳֿ����ݳɹ���";
		public const string UPDATE_SUCCESSED = "���Ĳֿ����ݳɹ���";
		public const string DELETE_SUCCESSED = "ɾ���ֿ����ݳɹ���";
		//��ṹ��
		public const string STO_TABLE = "StoCon";//����.
		public const string CODE_FIELD = "Code";//��š�
		public const string DESCRIPTION_FIELD = "Description";//���ơ�
		public const string LOCKED_FIELD = "Locked";//������
		public const string STOACC_FIELD = "StorageAcc";//�����Ŀ.
		public const string TRFACC_FIELD = "TransferAcc";//ת�ʿ�Ŀ.
		public const string RETURNACC_FIELD = "ReturnAcc";//�˻���Ŀ��
        public const string ADDRESS_FIELD = "Address";//��ַ��
		public const string RELATION_FIELD = "Relation";//��ϵ��

		/// <summary>
		/// StoData��Ĺ��캯����newһ��StoData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public StoData()
		{
			this.BuildDataTable ();//�������ݱ�
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
		/// ���������ݿ���DEPT���Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// ������Sto ��
			DataTable table   = new DataTable(STO_TABLE);
			//����ֶΡ�
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(LOCKED_FIELD,typeof(System.String));
            table.Columns.Add(STOACC_FIELD, typeof(System.String));
			table.Columns.Add(TRFACC_FIELD, typeof(System.String));
			table.Columns.Add(RETURNACC_FIELD, typeof(System.String));
			table.Columns.Add(ADDRESS_FIELD, typeof(System.String));
			table.Columns.Add(RELATION_FIELD, typeof(System.String));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
