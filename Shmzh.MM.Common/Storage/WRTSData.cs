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

namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	using System.Runtime.Serialization;   
	/// <summary>
	/// �������ϵ�������ʵ�壬������DocBaseData��InItemData�����ԡ�
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WRTSData:DataSet
	{
		#region ��Ա����
		public const string ADD_FAILED = "�������ϵ��½�ʧ�ܣ�";
		public const string ADD_SUCCESSED = "�������ϵ��½�ʧ�ܣ�";
		public const string UPDATE_FAILED = "�������ϵ��޸�ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "�������ϵ��޸�ʧ�ܣ�";
		public const string DELETE_FAILED = "�������ϵ�ɾ��ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "�������ϵ�ɾ��ʧ�ܣ�";
		public const string UPDATESTATE_FAILED = "�������ϵ�����״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "�������ϵ�����״̬ʧ�ܣ�";
		public const string FIRSTAUDIT_FAILED = "�������ϵ���������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "�������ϵ���������ʧ�ܣ�";
		public const string SECONDAUDIT_FAILED = "�������ϵ���������ʧ�ܣ�";
		public const string SECONDAUDIT_SUCCESSED = "�������ϵ���������ʧ�ܣ�";
		public const string THIRDAUDIT_FAILED = "�������ϵ���������ʧ�ܣ�";
		public const string THIRDAUDIT_SUCCESSED = "�������ϵ���������ʧ�ܣ�";
		public const string PRESENT_FAILED = "�������ϵ��ύʧ�ܣ�";
		public const string PRESENT_SUCCESSED = "�������ϵ��ύʧ�ܣ�";
		public const string CANCEL_FAILED = "�������ϵ�����ʧ�ܣ�";
		public const string CANCEL_SUCCESSED = "�������ϵ�����ʧ�ܣ�";
		public const string CHKCK_SUCCESSED = "�������ϵ�����ʧ�ܣ�";
        public const string CHECK_FAILED = "�������ϵ�����ʧ�ܣ�";
		public const string NOOBJECT = "�ն���";
		public const string XUpdate = "�������ϵ��޸�ǰ���ǣ����ݴ����½���������ͨ�������ϵ�״̬��";
		public const string XPresent = "�������ϵ��ύ��ǰ���ǣ����ݴ����½���������ͨ�������ϵ�״̬��";
		public const string XCancel = "�������ϵ����ϵ�ǰ���ǣ����ݴ����½���������ͨ����״̬��";
		public const string XDelete = "�������ϵ�ɾ����ǰ���ǣ����ݴ������ϵ�״̬��";
		public const string XFirstAudit = "�������ϵ�һ��������ǰ���ǣ����ݴ����ύ��״̬��";
		public const string XSecondAudit = "�������ϵ�����������ǰ���ǣ����ݴ���һ������ͨ����״̬��";
		public const string XThirdAudit = "�������ϵ�����������ǰ���ǣ����ݴ��ڶ�������ͨ����״̬��";
		public const string XReceive= "�������ϵ����ϵ�ǰ���ǣ����ݴ�������ͨ����״̬��";
		public const string RECEIVE_FAILED = "�������ϵ�����ʧ��";
		public const string RECEIVE_SUCCESSED ="�������ϵ����ϳɹ�";
		public const string NO_STO = "�������ϵ�����Ҫѡ��ֿ⣡";
		public const string NO_AUDIT_VALUE = "��ѡ��ͨ��������ͨ��������Ҳ����ѡ��ȡ��������";

		/// <value>��������ʵ��</value>
		public const string WRTS_TABLE           = "WRTS";            //������
		public const string STOMANAGERCODE_FIELD = "StoManagerCode";  //�ֿ����Ա����
		public const string STOMANAGER_FIELD     = "StoManager";      //�ֿ����Ա
		public const string DRAWDATE_FIELD       = "DrawDate";        //��������
		
		public const string SOURCEENTRY_FIELD    = "SourceEntry";     //Դ������ˮ��
		public const string SOURCEDOCCODE_FIELD  = "SourceDocCode";   //Դ��������
		public const string SOURCESERIALNO_FIELD = "SourceSerialNo";  //Դ��š�
		
		public const string REQREASONCODE_FIELD  = "ReqReasonCode";   //��;���
		public const string REQREASON_FIELD      = "ReqReason";       //��;����
		public const string STOCODE_FIELD        = "StoCode";         //�ֿ���
		public const string STONAME_FIELD        = "StoName";         //�ֿ�����
		public const string PLANNUM_FIELD        = "PlanNum";         //��������

		public const string PROPOSER_FIELD       = "Proposer";        //������
		public const string PROPOSERCODE_FIELD   = "ProposerCode";    //�����˱��
		public const string REQDEPT_FIELD        = "ReqDept";         //���벿�ű��
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";     //���벿�ű��
		public const string JFKM_FIELD           = "JFKM";            //�跽��Ŀ
		public const string CHKNO_FIELD          = "ChkNo";           //���յ����
		public const string CHKRESULT_FIELD      = "ChkResult";       //���ս��
		public const string CHKDATE_FIELD        = "ChkDate";         //��������
		public const string CHKMANCODE_FIELD     = "ChkManCode";      //�����˴���
		public const string CHKMANNAME_FIELD	 = "ChkMan";		  //������
		public const string CONCODE_FIELD		 = "ConCode";		  //��λ�š�
		public const string CONNAME_FIELD		 = "ConName";		  //��λ���ơ�
		
		#endregion

		#region ����
		/// <summary>
		/// �������ԡ�
		/// </summary>
		public int Count
		{
			get { return this.Tables[WRTSData.WRTS_TABLE].Rows.Count;}
		}
		#endregion
		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ������������ϵ������ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table = new DataTable(WRTS_TABLE);
			InItemData oItemData = new InItemData(table);

			DataColumnCollection columns = table.Columns;
			columns.Add(STOMANAGERCODE_FIELD,typeof(System.String));  //�ֿ����Ա����
			columns.Add(STOMANAGER_FIELD,typeof(System.String));      //�ֿ����Ա
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));      //��������
			
			columns.Add(SOURCEENTRY_FIELD,typeof(System.String));      //Դ������ˮ��
			columns.Add(SOURCEDOCCODE_FIELD,typeof(System.String));    //Դ��������
			columns.Add(SOURCESERIALNO_FIELD, typeof(System.String));  //Դ������š�
			
			columns.Add(REQREASONCODE_FIELD,typeof(System.String));   //��;���
			columns.Add(REQREASON_FIELD,typeof(System.String));       //��;����
			columns.Add(STOCODE_FIELD,typeof(System.String));         //�ֿ���
			columns.Add(STONAME_FIELD,typeof(System.String));         //�ֿ�����
			columns.Add(PLANNUM_FIELD,typeof(System.String));         //��������

			columns.Add(PROPOSER_FIELD,typeof(System.String));        //������
			columns.Add(PROPOSERCODE_FIELD,typeof(System.String));    //�����˱��
			columns.Add(REQDEPT_FIELD,typeof(System.String));		  //���벿�ű��
			columns.Add(REQDEPTNAME_FIELD,typeof(System.String));     //���벿������
			columns.Add(JFKM_FIELD,typeof(System.String));            //�跽��Ŀ
			columns.Add(CHKNO_FIELD,typeof(System.String));           //���յ����
			columns.Add(CHKRESULT_FIELD,typeof(System.String));       //���ս��
			columns.Add(CHKDATE_FIELD,typeof(System.DateTime));       //��������
			columns.Add(CHKMANCODE_FIELD,typeof(System.String));      //�����˱��
			columns.Add(CHKMANNAME_FIELD,typeof(System.String));	  //������
			columns.Add(CONCODE_FIELD, typeof(System.String));		  //��λ�š�
			columns.Add(CONNAME_FIELD, typeof(System.String));		  //��λ���ơ�
			
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private WRTSData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WRTSData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
