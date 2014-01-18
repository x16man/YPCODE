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
	public class PurposeData : DataSet
	{
		//���ݼ��鱨����Ϣ��
		public const string NO_OBJECT = "û����;���ݶ���";
		public const string NO_ROW = "û����;�����У�";
		public const string CODE_LABEL = "��;����";
        public const string DESCRIPTION_LABEL = "��;����";
		public const string LOCKED_LABEL = "����";
		public const string TARGETACC_LABEL = "Ŀ���Ŀ";
		public const string ENABLE_LABEL = "�Ƿ���Ч";
		public const string CODE_NOT_UNIQUE = "��;���벻Ψһ��";
        public const string DESCRIPTION_NOT_UNIQUE = "��;������Ψһ��";
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "������;����ʧ�ܣ�";
		public const string ADD_FAILED = "�����;����ʧ�ܣ�";
		public const string UPDATE_FAILED = "������;����ʧ�ܣ�";
		public const string DELETE_FAILED = "ɾ����;����ʧ�ܣ�";
		public const string ADD_SUCCESSED = "�����;���ݳɹ���";
		public const string UPDATE_SUCCESSED = "������;���ݳɹ���";
		public const string DELETE_SUCCESSED = "ɾ����;���ݳɹ���";
		//��ṹ��
		public const string USE_TABLE = "WUSE";//��;����.
		public const string OLDCODE_FIELD = "OldCode";//����;���롣
		public const string CODE_FIELD = "Code";//��;���롣
		public const string DESCRIPTION_FIELD = "Description";//��;���ơ�
		public const string TARGETACC_FIELD = "TargetAcc";//Ŀ���Ŀ.
		public const string ENABLE_FIELD = "Enable";//�Ƿ���Ч��
		public const string LOCKED_FIELD = "Locked";//������
		public const string CLASSIFY_FIELD = "Classify";//��;���ࡣ
		public const string PROJECT_CODE_FIELD = "ProjectCode";//���̿�Ŀ�� 
		public const string FLAG_FIELD = "Flag";//ʹ�ñ�ǣ�0��ʾ������ʹ�ã�1��ʾ��������á�
		public const string thisYear_Field = "thisYear";//��ǰ��ݡ�
	    public const string Dev_ID_Field = "Dev_ID";
	    public const string Dev_Type_Field = "Dev_Type";
		/// <summary>
		/// UseData��Ĺ��캯����newһ��UseData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public PurposeData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private PurposeData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// ���������ݿ���WUSE���Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// ��������; ��
			DataTable table   = new DataTable(USE_TABLE);
			//����ֶΡ�
			table.Columns.Add(OLDCODE_FIELD, typeof(System.String));
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(TARGETACC_FIELD, typeof(System.String));
			table.Columns.Add(ENABLE_FIELD, typeof(System.Int32));
			table.Columns.Add(LOCKED_FIELD,typeof(System.String));
			table.Columns.Add(CLASSIFY_FIELD,typeof(System.String));
			table.Columns.Add(PROJECT_CODE_FIELD,typeof(System.String));
			table.Columns.Add(FLAG_FIELD, typeof(System.Int32));
			table.Columns.Add(thisYear_Field, typeof(System.Int32));
		    table.Columns.Add(Dev_ID_Field, typeof (System.Decimal));
		    table.Columns.Add(Dev_Type_Field, typeof (System.String));
			//�����ݼ�������DataTable��))
			this.Tables.Add(table);
		}
	}
}
