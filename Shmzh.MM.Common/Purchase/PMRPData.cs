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
	/// �������󵥵�����ʵ�壬������DocBaseData��InItemData�����ԡ�
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PMRPData:DataSet
	{
		#region ��Ա����
		public const string ADD_FAILED = "������������ʧ�ܣ�";
		public const string ADD_SUCCESSED = "�������������ɹ���";
		public const string UPDATE_FAILED = "���������޸�ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "���������޸ĳɹ���";
		public const string DELETE_FAILED = "��������ɾ��ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "��������ɾ���ɹ���";
		public const string UPDATESTATE_FAILED = "���������޸�״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "���������޸�״̬�ɹ���";
		public const string FIRSTAUDIT_FAILED = "��������һ������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "��������һ�������ɹ���";
		public const string SECONDAUDIT_FAILED = "�������󵥶�������ʧ�ܣ�";
		public const string SECONDAUDIT_SUCCESSED = "�������󵥶��������ɹ���";
		public const string THIRDAUDIT_FAILED = "����������������ʧ�ܣ�";
		public const string THIRDAUDIT_SUCCESSED = "�����������������ɹ���";
		public const string PRESENT_FAILED = "���������ύʧ�ܣ�";
		public const string PRESENT_SUCCESSED = "���������ύ�ɹ���";
		public const string CANCEL_FAILED = "������������ʧ�ܣ�";
		public const string CANCEL_SUCCESSED = "�����������ϳɹ���";
		public const string NOOBJECT = "�ն���";
		public const string NoPurpose = "�������󵥱���Ҫ��д��;��";
		public const string NoReqDept = "�������󵥱���Ҫ��д���벿�ţ�";
		public const string NoProposer = "�������󵥱���Ҫ��д�����ˣ�";
		public const string XUpdate = "���������޸ĵ�ǰ�����ڵ��ݴ����½���������ͨ�������ϵ�״̬�£�";
		public const string XPresent = "���������ύ��ǰ�����ڵ��ݴ����½���������ͨ�������ϵ�״̬�£�";
		public const string XCancel = "�����������ϵ�ǰ�����ڵ��ݴ����½���������ͨ����״̬�£�";
		public const string XDelete = "��������ɾ����ǰ�����ڵ��ݴ������ϵ�״̬�£�";
		public const string XFirstAudit = "��������һ��������ǰ�����ڵ��ݴ������ύ������״̬�£�";
		public const string XSecondAudit = "�������󵥶���������ǰ�����ڵ��ݴ���һ������ͨ����״̬�£�";
		public const string XThirdAudit = "������������������ǰ�����ڵ��ݴ��ڶ�������ͨ����״̬�£�";
		/// <value>��������ʵ��</value>
		public const string PMRP_TABLE  = "PMRP";						//������
		public const string PROPOSER_FIELD		= "Proposer";			//�����ˡ�
		public const string PROPOSERCODE_FIELD  = "ProposerCode";		//�����˱�š�
		public const string REQDEPT_FIELD		= "ReqDept";			//���벿�š�
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";		//���벿�����ơ�
		public const string REQREASONCODE_FIELD = "ReqReasonCode";		//�������ɴ��롣
		public const string REQREASON_FIELD     = "ReqReason";			//�������ɡ�
		public const string REQDATE_FIELD       = "ReqDate";			//Ҫ�󵽻����ڡ�
		#endregion

		#region ����
		public int Count
		{
			get { return this.Tables[PMRPData.PMRP_TABLE].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ������������󵥵����ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PMRP_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			columns.Add(PROPOSER_FIELD, typeof(System.String));			//�����ˡ�
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//�����˱�š�
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//���벿�š�
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//���벿�����ơ�
			columns.Add(REQREASONCODE_FIELD, typeof(System.String));	//�������ɡ�
			columns.Add(REQREASON_FIELD, typeof(System.String));		//�������ɡ�
			columns.Add(REQDATE_FIELD, typeof(System.String));			//Ҫ�󵽻����ڡ�
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private PMRPData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public PMRPData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
