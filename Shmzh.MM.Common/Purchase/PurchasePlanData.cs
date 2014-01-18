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
	/// �ɹ��ƻ���ʵ��㡣
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PurchasePlanData : DataSet
	{
		#region ������Ϣ
		public const string NOOBJECT = "�ն���";
		public const string ADD_FAILED = "�ɹ��ƻ��½�ʧ�ܣ�";
		public const string ADD_SUCCESSED = "�ɹ��ƻ��½��ɹ���";
		public const string UPDATE_FAILED = "�ɹ��ƻ��޸�ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "�ɹ��ƻ��޸ĳɹ���";
		public const string DELETE_FAILED = "�ɹ��ƻ�ɾ��ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "�ɹ��ƻ�ɾ���ɹ���";
		public const string UPDATESTATE_FAILED = "�ɹ��ƻ��޸�״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "�ɹ��ƻ��޸�״̬�ɹ���";
		public const string FIRSTAUDIT_FAILED = "�ɹ��ƻ�һ������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "�ɹ��ƻ�һ�������ɹ���";
		public const string SECONDAUDIT_FAILED = "�ɹ��ƻ���������ʧ�ܣ�";
		public const string SECONDAUDIT_SUCCESSED = "�ɹ��ƻ����������ɹ���";
		public const string THIRDAUDIT_FAILED = "�ɹ��ƻ���������ʧ�ܣ�";
		public const string THIRDAUDIT_SUCCESSED = "�ɹ��ƻ����������ɹ���";
		public const string PRESENT_FAILED = "�ɹ��ƻ��ύʧ�ܣ�";
		public const string PRESENT_SUCCESSED = "�ɹ��ƻ��ύ�ɹ���";
		public const string CANCEL_FAILED = "�ɹ��ƻ�����ʧ�ܣ�";
		public const string CANCEL_SUCCESSED = "�ɹ��ƻ����ϳɹ���";
		public const string XUpdate = "�ɹ��ƻ��޸ĵ�ǰ���ǣ��ɹ��ƻ������½���������ͨ�������ϵ�״̬��";
		public const string XPresent = "�ɹ��ƻ��ύ��ǰ���ǣ��ɹ��ƻ������½���������ͨ�������ϵ�״̬��";
		public const string XUpdatePresent = "�ɹ��ƻ��޸Ĳ����ύ��ǰ���ǣ��ɹ��ƻ����봦���½������ϡ�������ͨ����״̬��";
		public const string XDelete = "�ɹ��ƻ�ɾ����ǰ���ǣ��ɹ��ƻ���������״̬��";
		public const string XCancel = "�ɹ��ƻ����ϵ�ǰ���ǣ��ɹ��ƻ������½���������ͨ����״̬��";
		public const string XFirstAudit = "�ɹ��ƻ�һ��������ǰ���ǣ��ɹ��ƻ������ύ��״̬��";
		public const string XSecondAudit = "�ɹ��ƻ�����������ǰ���ǣ��ɹ��ƻ�����һ������ͨ����״̬��";
		public const string XThirdAudit = "�ɹ��ƻ�����������ǰ���ǣ��ɹ��ƻ����ڶ�������ͨ����״̬��";
		#endregion

		#region ��Ա����
		public const string PPLN_TABLE = "PPLN";//������
		public const string SOURCEENTRY_FIELD = "SourceEntry";		//Դ������ˮ�š�
		public const string SOURCEDOCCODE_FIELD = "SourceDocCode";	//Դ�������͡�
		public const string PLANDATE_FIELD = "PlanDate";			//�ƻ����ڡ�
		public const string ITEMLACKNUM_FIELD = "ItemLackNum";		//δ���ɲɹ�������������
		public const string REQDEPT_FIELD = "ReqDept";				//���벿�š�
		public const string REQDEPTNAME_FIELD = "ReqDeptName";		//���벿�����ơ�
		public const string REQREASONCODE_FIELD = "ReqReasonCode";	//��;��š�
		public const string REQREASON_FIELD = "ReqReason";			//��;��
		public const string REQDATE_FIELD = "ReqDate";				//Ҫ�����ڡ�
		public const string Proposer_Field = "Proposer";
		public const string ReqEntryDate_Field = "ReqEntryDate";
		#endregion

		#region ����
		public int Count
		{
			get { return this.Tables[PurchasePlanData.PPLN_TABLE].Rows.Count; }
		}
		#endregion

		#region ˽�з���
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PPLN_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			
			columns.Add(PurchasePlanData.SOURCEENTRY_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.SOURCEDOCCODE_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.PLANDATE_FIELD,	typeof(System.DateTime));
			columns.Add(PurchasePlanData.ITEMLACKNUM_FIELD, typeof(System.Decimal));
			columns.Add(PurchasePlanData.REQDEPT_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.REQDEPTNAME_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.REQREASONCODE_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.REQREASON_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.REQDATE_FIELD, typeof(System.String));
			columns.Add(PurchasePlanData.Proposer_Field, typeof(System.String));
			columns.Add(PurchasePlanData.ReqEntryDate_Field, typeof(System.DateTime));
			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private PurchasePlanData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PurchasePlanData()
		{
			this.BuildDataTables();
		}
		#endregion
	}
}
