#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace  Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// �������յ�������������������ʵ�壬������DocBaseData��InItemData�����ԡ�
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PCBRData:DataSet
	{
		#region ��Ա����
		public const string ADD_FAILED = "";
		public const string ADD_SUCCESSED = "";
		public const string UPDATE_FAILED = "";
		public const string UPDATE_SUCCESSED = "";
		public const string DELETE_FAILED = "";
		public const string DELETE_SUCCESSED = "";
		public const string UPDATESTATE_FAILED = "";
		public const string UPDATESTATE_SUCCESSED = "";
		public const string FIRSTAUDIT_FAILED = "";
		public const string FIRSTAUDIT_SUCCESSED = "";
		public const string SECONDAUDIT_FAILED = "";
		public const string SECONDAUDIT_SUCCESSED = "";
		public const string THIRDAUDIT_FAILED = "";
		public const string THIRDAUDIT_SUCCESSED = "";
		public const string PRESENT_FAILED = "";
		public const string PRESENT_SUCCESSED = "";
		public const string CANCEL_FAILED = "";
		public const string CANCEL_SUCCESSED = "";
		public const string NOOBJECT = "";
		/// <value>��������ʵ��</value>
		public const string PCBR_TABLE  = "PCBR";						//������
		//������Ϣ��
		public const string RECVDATE_FIELD = "RecvDate";				//�������ڡ�
		public const string SOURCEENTRY_FIELD = "SourceEntry";			//Դ���ݡ�
		public const string SOURCEDOCCODE_FIELD = "SourceDocCode";		//Դ�ĵ����롣
		public const string PRVCODE_FIELD = "PrvCode";					//��Ӧ�̴��롣
		public const string PRVNAME_FIELD = "PrvName";					//��Ӧ�����ơ�
		public const string PRVADD_FIELD = "PrvAdd";					//��Ӧ�̵�ַ��
		public const string PRVZIP_FIELD = "PrvZip";					//�������롣
		public const string PRVTEL_FIELD = "PrvTel";					//�绰��
		public const string PRVFAX_FIELD = "PrvFax";					//���档
		public const string CHKDEPT_FIELD = "ChkDept";					//���鲿�š�
		public const string CHKDEPTNAME_FIELD = "ChkDeptName";			//���鲿�����ơ�
		public const string BATCHCODE_FIELD = "BatchCode";				//���š�
		//������ӱ���Ϣ��
		public const string CITMCODE_FIELD = "CitmCode";
		public const string CITMNAME_FIELD = "CitmName";
		public const string CITMUNIT_FIELD = "CitmUnit";
		public const string CITMVALUE_FIELD = "CitmValue";


		#endregion

		#region ����
		/// <summary>
		/// ��¼����
		/// </summary>
		public int Count
		{
			get {	return this.Tables[PCBRData.PCBR_TABLE].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ������������յ������ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PCBR_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			//���յ��������ֶ����ӡ�
			columns.Add(PCBRData.RECVDATE_FIELD, typeof(System.DateTime));
			columns.Add(PCBRData.SOURCEENTRY_FIELD, typeof(System.Int32));
			columns.Add(PCBRData.SOURCEDOCCODE_FIELD, typeof(System.Int16));
			columns.Add(PCBRData.PRVCODE_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVNAME_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVADD_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVZIP_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVTEL_FIELD, typeof(System.String));
			columns.Add(PCBRData.PRVFAX_FIELD, typeof(System.String));
			columns.Add(PCBRData.CHKDEPT_FIELD, typeof(System.String));
			columns.Add(PCBRData.CHKDEPTNAME_FIELD, typeof(System.String));
			columns.Add(PCBRData.BATCHCODE_FIELD, typeof(System.String));
			//���յ��ӱ��ֶ����ӡ�
			columns.Add(PCBRData.CITMCODE_FIELD, typeof(System.String));
			columns.Add(PCBRData.CITMNAME_FIELD, typeof(System.String));
			columns.Add(PCBRData.CITMUNIT_FIELD, typeof(System.String));
			columns.Add(PCBRData.CITMVALUE_FIELD, typeof(System.String));
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private PCBRData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public PCBRData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
