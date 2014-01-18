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
	/// INV_CD �� �� �� ��.
	/// </summary>
	[SerializableAttribute]
	public class INV_CD
	{
		public static string  OWN_CODE
		{
			get {return "O";}
		}
		public static string  OWN_DESCRIPTION
		{
			get {return "����";}
		}
		public static string HIDE_CODE
		{
			get{return "H";}
		}
		public static string HIDE_DESCRIPTION
		{
			get{return "���";}
		}
		public static string SEND_CODE
		{
			get{return "S";}
		}
		public static string SEND_DESCRIPTION
		{
			get{return "����";}
		}
		public static string INCHECK_CODE
		{
			get{return "I";}
		}
		public static string INCHECK_DESCRIPTION
		{
			get{return "�ڼ�";}
		}
		public static string ALL_CODE
		{
			get{return "A";}
		}
		public static string ALL_DESCRIPTION
		{
			get{return "ȫ��";}
		}
		public static int Count
		{
			get{return 5;}
		}
	}
	/// <summary>
	/// StoConData �ǲֿ��λ�������ʵ��㣬���𴴽�һ��StoCon������ʵ�塣
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class StoConData : DataSet
	{
		#region ��Ա����
		//���ݼ��鱨����Ϣ��
		public const string NO_OBJECT = "û�м�λ���ݶ���";
		public const string NO_ROW = "û�м�λ�����У�";
		public const string CODE_NOT_NULL = "��λ���";
		public const string DESCRIPTION_NOT_NULL = "��λ����";
		public const string CODE_NOT_UNIQUE = "��λ��Ų�Ψһ��";
		public const string DESCRIPTION_NOT_UNIQUE = "��λ���Ʋ�Ψһ��";
		public const string AREA_NOT_DECIMAL = "��λ���ҪΪ����";
		
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "������λ����ʧ�ܣ�";
		public const string ADD_FAILED = "��Ӽ�λ����ʧ�ܣ�";
		public const string UPDATE_FAILED = "���ļ�λ����ʧ�ܣ�";
		public const string DELETE_FAILED = "ɾ����λ����ʧ�ܣ�";
		public const string ADD_SUCCESSED = "��Ӽ�λ���ݳɹ���";
		public const string UPDATE_SUCCESSED = "���ļ�λ���ݳɹ���";
		public const string DELETE_SUCCESSED = "ɾ����λ���ݳɹ���";
		//��ṹ��
		public const string STOCON_TABLE = "StoCon";//����.
		public const string CODE_FIELD = "CODE";//��š�
		public const string STOCODE_FIELD = "StoCode";//�ֿ��š�
		public const string DESCRIPTION_FIELD = "DESCRIPTION";//���ơ�
		public const string STATUS_FIELD = "STATUS";//״̬��
		public const string LOCKED_FIELD = "LOCKED";//������
		public const string AREA_FIELD = "Area";    //�����
		#endregion

		#region ����
		/// <summary>
		/// ��λ�������Ӧ��ֻ�ڳ�λʱ�õ���
		/// </summary>
		public decimal Area
		{
			get {	return Convert.ToDecimal(this.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.AREA_FIELD].ToString());}
		}
		#endregion

		#region ���캯��
		/// <summary>
		/// DeptData��Ĺ��캯����newһ��DeptData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public StoConData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private StoConData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ���������ݿ���DEPT���Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// ������DEPT ��
			DataTable table   = new DataTable(STOCON_TABLE);
			//����ֶΡ�
			table.Columns.Add(CODE_FIELD, typeof(System.Int32));
			table.Columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			table.Columns.Add(STOCODE_FIELD, typeof(System.String));
			table.Columns.Add(STATUS_FIELD, typeof(System.String));
			table.Columns.Add(LOCKED_FIELD, typeof(System.String));
			table.Columns.Add(AREA_FIELD, typeof(System.Decimal));

			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
		#endregion
	}
}
