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
	/// PslpData �ǲɹ�Ա�������ʵ��㣬���𴴽�һ��PSLP�����ݼ���
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PslpData : DataSet
	{
		//����������鱨����Ϣ��
		public const string NO_OBJECT = "û�вɹ�Ա���ݶ���";
		public const string NO_ROW = "û�вɹ�Ա�����У�";
		public const string CODE_LABEL = "�ɹ�Ա����";
		public const string DESCRIPTION_LABEL = "�ɹ�Ա����";
		public const string LOCKED_LABEL = "����";
		//Ψһ�Լ��鱨����Ϣ��
		public const string CODE_NOT_UNIQUE = "�ɹ�Ա���벻Ψһ��";
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "�����ɹ�Ա����ʧ�ܣ�";
		public const string ADD_FAILED = "��Ӳɹ�Ա����ʧ�ܣ�";
		public const string ADD_SUCCESSED = "��Ӳɹ�Ա���ݳɹ���";
		public const string UPDATE_FAILED = "���Ĳɹ�Ա����ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "���Ĳɹ�Ա���ݳɹ���";
		public const string DELETE_FAILED = "ɾ���ɹ�Ա����ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "ɾ���ɹ�Ա���ݳɹ���";
		//��ṹ��
		public const string PSLP_TABLE = "PSLP";//�ɹ�Ա����.
		public const string OLDCODE_FIELD = "OLDCODE";//�ɹ�Ա�ɴ��롣
		public const string CODE_FIELD = "CODE";//�ɹ�Ա���롣
		public const string DESCRIPTION_FIELD = "DESCRIPTION";//�ɹ�Ա������
		public const string LOCKED_FIELD = "LOCKED";//�Ƿ�������
		/// <summary>
		/// PslpData��Ĺ��캯����newһ��PslpData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public PslpData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private PslpData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// ���������ݿ���PSLP���Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// ������PSLP ��
			DataTable table   = new DataTable(PSLP_TABLE);
			//����ֶΡ�
			table.Columns.Add(OLDCODE_FIELD, typeof(System.String));
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(LOCKED_FIELD, typeof(System.String));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
