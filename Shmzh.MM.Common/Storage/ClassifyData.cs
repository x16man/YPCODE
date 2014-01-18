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
	public class ClassifyData : DataSet
	{
		//���ݼ��鱨����Ϣ��
		public const string NO_OBJECT = "û����;�������ݶ���";
		public const string NO_ROW = "û����;���������У�";
		public const string CODE_LABEL = "��;����";
		public const string DESCRIPTION_LABEL = "��������";
		public const string LOCKED_LABEL = "����";
		public const string TARGETACC_LABEL = "Ŀ���Ŀ";
		public const string ENABLE_LABEL = "�Ƿ���Ч";
		public const string CODE_NOT_UNIQUE = "��;������벻Ψһ��";
		public const string DESCRIPTION_NOT_UNIQUE = "��;�������Ʋ�Ψһ��";
		public const string HAS_CHILD_CLASSIFY = "����;ӵ������;������ɾ��������;��";
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "������;��������ʧ�ܣ�";
		public const string ADD_FAILED = "�����;��������ʧ�ܣ�";
		public const string UPDATE_FAILED = "������;��������ʧ�ܣ�";
		public const string DELETE_FAILED = "ɾ����;��������ʧ�ܣ�";
		public const string ADD_SUCCESSED = "�����;�������ݳɹ���";
		public const string UPDATE_SUCCESSED = "������;�������ݳɹ���";
		public const string DELETE_SUCCESSED = "ɾ����;�������ݳɹ���";
		//��ṹ��
		public const string CLASSFIY_TABLE = "WCLS";//��;����.
		public const string OLDCODE_FIELD = "OldClassifyID";//����;���롣
		public const string CODE_FIELD = "ClassifyID";//��;���롣
		public const string DESCRIPTION_FIELD = "Description";//��;���ơ�
		public const string PARENT_CODE_FIELD = "ParentID";//����;ID
		public const string ENABLE_FIELD = "Enable";//�Ƿ���Ч��
		public const string LOCKED_FIELD = "Locked";//������

		/// <summary>
		/// UseData��Ĺ��캯����newһ��UseData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public ClassifyData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		public int Count
		{
			get { return this.Tables[0].Rows.Count;}
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private ClassifyData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// ���������ݿ���WUSE���Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// ��������; ��
			DataTable table   = new DataTable(CLASSFIY_TABLE);
			//����ֶΡ�
			table.Columns.Add(OLDCODE_FIELD, typeof(System.String));
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(PARENT_CODE_FIELD,typeof(System.String));
			table.Columns.Add(ENABLE_FIELD, typeof(System.Int32));
			table.Columns.Add(LOCKED_FIELD,typeof(System.String));

			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
