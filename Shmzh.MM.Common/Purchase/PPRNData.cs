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
	public class PPRNData : DataSet
	{
		//����������鱨����Ϣ��
		public const string NO_OBJECT = "û�й�Ӧ��/�ͻ����ݶ���";
		public const string NO_ROW = "û�й�Ӧ��/�ͻ������У�";
		public const string CODE_LABEL = "���";
		public const string CNNAME_LABEL = "��������";
		public const string ENNAME_LABEL = "Ӣ������";
		public const string TYPE_LABEL = "���";
		public const string STATUS_LABEL = "״̬";
		public const string APPROVE_LABEL = " �Ѻ�׼";
		public const string CURRENCY_LABEL = "���Ҵ���";
		public const string PAYSTYLE_LABEL = "���ʽ";
		public const string TEL_LABEL = "�绰";
		public const string FAX_LABEL = "����";
		public const string EMAIL_LABEL = "E-MAIL";
		public const string LINKMAN_LABEL = "��ϵ��";
		public const string LINKTEL_LABEL = "��ϵ�˵绰";
		public const string LINKMAIL_LABEL = "��ϵ��E-MAIL";
		public const string ACCLINK_LABEL = "�����ϵ��";
		public const string ACCLINKTEL_LABEL = "�����ϵ�˵绰";
		public const string ADDRESS_LABEL = "��ַ";
		public const string ZIP_LABEL = "�ʱ�";
		public const string LICENCE_LABEL = "Ӫҵִ�պ�";
		public const string REGMONEY_LABEL = "ע���ʽ�";
		public const string TURNOVER_LABEL = "��Ӫҵ��";
		public const string DEPUTY_LABEL = "���˴���";
		public const string BANK_LABEL = "��������";
		public const string ACCOUNT_LABEL = "�˻�";
		public const string TAXNO_LABEL = "˰��ǼǺ�";
		public const string COUNTRY_LABEL = "����";
		public const string STATE_LABEL = "ʡ";
		public const string CITY_LABEL = "����";
		public const string PURCHASEACC_LABEL = "�ɹ��˻�";
		public const string APACC_LABEL = "Ӧ���˻�";
		public const string REMARK_LABEL = "��ע";
		
		//Ψһ�Լ��鱨����Ϣ��
		public const string CODE_NOT_UNIQUE = "��Ӧ��/�ͻ���Ų�Ψһ��";
		public const string CNNAME_NOT_UNIQUE = "��Ӧ��/�ͻ��������Ʋ�Ψһ��";
		public const string ENNAME_NOT_UNIQUE = "��Ӧ��/�ͻ�Ӣ�����Ʋ�Ψһ��";
		public const string OTA_NOT_UNIQUE = "ϵͳ�Ѿ���һ��OTA���͹�Ӧ�̣�";
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "������Ӧ��/�ͻ�����ʧ�ܣ�";
		public const string ADD_FAILED = "��ӹ�Ӧ��/�ͻ�����ʧ�ܣ�";
		public const string ADD_SUCCESSED = "��ӹ�Ӧ��/�ͻ����ݳɹ���";
		public const string UPDATE_FAILED = "���Ĺ�Ӧ��/�ͻ�����ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "���Ĺ�Ӧ��/�ͻ����ݳɹ���";
		public const string DELETE_FAILED = "ɾ����Ӧ��/�ͻ�����ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "ɾ����Ӧ��/�ͻ����ݳɹ���";
		//��ṹ��
		public const string PPRN_TABLE = "PPRN";//��Ӧ��/�ͻ�����.
		public const string OLDCODE_FIELD = "OLDCODE";//��Ӧ��/�ͻ��ɱ�š�
		public const string CODE_FIELD = "CODE";//��Ӧ��/�ͻ���š�
		public const string CNNAME_FIELD = "CNNAME";//��Ӧ��/�ͻ��������ơ�
		public const string ENNAME_FIELD = "ENNAME";//��Ӧ��/�ͻ�Ӣ�����ơ�
		public const string TYPE_FIELD = "TYPE";//��Ӧ��/�ͻ����
		public const string STATUS_FIELD = "STATUS";//��Ӧ��/�ͻ�״̬��
		public const string APPROVE_FIELD = "APPROVE";//��Ӧ��/�ͻ� �Ѻ�׼��
		public const string CURRENCY_FIELD = "CURRENCY";//��Ӧ��/�ͻ� ���Ҵ��롣
		public const string PAYSTYLE_FIELD = "PAYSTYLE";//��Ӧ��/�ͻ� �������͡�
		public const string TEL_FIELD = "TEL";//��Ӧ��/�ͻ� �绰��
		public const string FAX_FIELD = "FAX";//��Ӧ��/�ͻ� ���档
        public const string EMAIL_FIELD = "EMAIL";//��Ӧ��/�ͻ� EMAIL��
		public const string LINKMAN_FIELD = "LINKMAN";//��Ӧ��/�ͻ� ��ϵ�ˡ�
		public const string LINKTEL_FIELD = "LINKTEL";//��Ӧ��/�ͻ� ��ϵ�˵绰��
		public const string LINKMAIL_FIELD = "LINKMAIL";//��Ӧ��/�ͻ� ��ϵ��EMAIL��
		public const string ACCLINK_FIELD = "ACCLINK";//��Ӧ��/�ͻ� �����ϵ�ˡ�
		public const string ACCLINKTEL_FIELD = "ACCLINKTEL";//��Ӧ��/�ͻ� �����ϵ�˵绰��
		public const string ADDRESS_FIELD = "ADDRESS";//��Ӧ��/�ͻ� ��ַ��
		public const string ZIP_FIELD = "ZIP";//��Ӧ��/�ͻ� �ʱࡣ
		public const string LICENCE_FIELD = "LICENCE";//��Ӧ��/�ͻ� Ӫҵִ�պ��롣
		public const string REGMONEY_FIELD = "REGMONEY";//��Ӧ��/�ͻ� ע���ʽ�
		public const string TURNOVER_FIELD = "TURNOVER";//��Ӧ��/�ͻ� ��Ӫҵ�
		public const string DEPUTY_FIELD = "DEPUTY";//��Ӧ��/�ͻ� ���˴���
		public const string BANK_FIELD = "BANK";//��Ӧ��/�ͻ� �������С�
		public const string ACCOUNT_FIELD = "ACCOUNT";////��Ӧ��/�ͻ� �˻���
		public const string TAXNO_FIELD = "TAXNO";//��Ӧ��/�ͻ� ˰��ǼǺš�
		public const string COUNTRY_FIELD = "COUNTRY";//��Ӧ��/�ͻ� ���ҡ�
		public const string STATE_FIELD = "STATE";//��Ӧ��/�ͻ� ʡ��
		public const string CITY_FIELD = "CITY";//��Ӧ��/�ͻ� ���С�
		public const string PURCHASEACC_FIELD = "PURCHASEACC";//��Ӧ��/�ͻ� �ɹ��˻���
		public const string APACC_FIELD = "APACC";//��Ӧ��/�ͻ� Ӧ���˻���
		public const string REMARK_FIELD = "REMARK";//��Ӧ��/�ͻ� ��ע��
		public const string CatCode_Field = "CatCode";//��Ӧ�̷���
		public const string CatName_Field = "CatName";//��Ӧ�̷������� 
		/// <summary>
		/// DeptData��Ĺ��캯����newһ��DeptData���ʱ�򣬾ʹ���һ�����ݼ���
		/// </summary>
		public PPRNData()
		{
			this.BuildDataTable ();//�������ݱ�
		}
		/// <summary>
		///     Constructor to support serialization.
		///     <remarks>Constructor that supports serialization.</remarks> 
		///     <param name="info">The SerializationInfo object to read from.</param>
		///     <param name="context">Information on who is calling this method.</param>
		/// </summary>
		private PPRNData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		/// <summary>
		/// ���������ݿ���DEPT���Ӧ��һ��DataTable��
		/// </summary>
		private void BuildDataTable()
		{
			// ������DEPT ��
			DataTable table   = new DataTable(PPRN_TABLE);
			//����ֶΡ�
			table.Columns.Add(OLDCODE_FIELD, typeof(System.String));
			table.Columns.Add(CODE_FIELD, typeof(System.String));
			table.Columns.Add(CNNAME_FIELD, typeof(System.String));
			table.Columns.Add(ENNAME_FIELD, typeof(System.String));
			table.Columns.Add(TYPE_FIELD, typeof(System.String));
			table.Columns.Add(STATUS_FIELD, typeof(System.String));
			table.Columns.Add(APPROVE_FIELD, typeof(System.String));
			table.Columns.Add(CURRENCY_FIELD, typeof(System.String));
			table.Columns.Add(PAYSTYLE_FIELD, typeof(System.String));
			table.Columns.Add(TEL_FIELD, typeof(System.String));
			table.Columns.Add(FAX_FIELD, typeof(System.String));
			table.Columns.Add(EMAIL_FIELD, typeof(System.String));
			table.Columns.Add(LINKMAN_FIELD, typeof(System.String));
			table.Columns.Add(LINKTEL_FIELD, typeof(System.String));
			table.Columns.Add(LINKMAIL_FIELD, typeof(System.String));
			table.Columns.Add(ACCLINK_FIELD, typeof(System.String));
			table.Columns.Add(ACCLINKTEL_FIELD, typeof(System.String));
			table.Columns.Add(ADDRESS_FIELD, typeof(System.String));
			table.Columns.Add(ZIP_FIELD, typeof(System.String));
			table.Columns.Add(LICENCE_FIELD, typeof(System.String));
			table.Columns.Add(REGMONEY_FIELD, typeof(System.String));
			table.Columns.Add(TURNOVER_FIELD, typeof(System.String));
			table.Columns.Add(DEPUTY_FIELD, typeof(System.String));
			table.Columns.Add(BANK_FIELD, typeof(System.String));
			table.Columns.Add(ACCOUNT_FIELD, typeof(System.String));
			table.Columns.Add(TAXNO_FIELD, typeof(System.String));
			table.Columns.Add(COUNTRY_FIELD, typeof(System.String));
			table.Columns.Add(STATE_FIELD, typeof(System.String));
			table.Columns.Add(CITY_FIELD, typeof(System.String));
			table.Columns.Add(PURCHASEACC_FIELD, typeof(System.String));
			table.Columns.Add(APACC_FIELD, typeof(System.String));
			table.Columns.Add(REMARK_FIELD, typeof(System.String));
			table.Columns.Add(CatCode_Field, typeof(System.Int32));
			table.Columns.Add(CatName_Field, typeof(System.String));
			//�����ݼ�������DataTable��
			this.Tables.Add(table);
		}
	}
}
