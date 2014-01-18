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
	/// ί��ӹ����뵥������ʵ�壬������DocBaseData��InItemData�����ԡ�
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WTOWData:DataSet
	{
		#region ��Ա����
		public const string ADD_FAILED = "ί��ӹ����뵥�½�ʧ�ܣ�";
		public const string ADD_SUCCESSED = "ί��ӹ����뵥�½��ɹ���";
		public const string UPDATE_FAILED = "ί��ӹ����뵥�޸�ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "ί��ӹ����뵥�޸ĳɹ���";
		public const string DELETE_FAILED = "ί��ӹ����뵥ɾ��ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "ί��ӹ����뵥ɾ���ɹ���";
		public const string UPDATESTATE_FAILED = "ί��ӹ����뵥�޸�״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "ί��ӹ����뵥�޸�״̬�ɹ���";
		public const string FIRSTAUDIT_FAILED = "ί��ӹ����뵥һ������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "ί��ӹ����뵥һ�������ɹ���";
		public const string SECONDAUDIT_FAILED = "ί��ӹ����뵥��������ʧ�ܣ�";
		public const string SECONDAUDIT_SUCCESSED = "ί��ӹ����뵥���������ɹ���";
		public const string THIRDAUDIT_FAILED = "ί��ӹ����뵥��������ʧ�ܣ�";
		public const string THIRDAUDIT_SUCCESSED = "ί��ӹ����뵥���������ɹ���";
		public const string PRESENT_FAILED = "ί��ӹ����뵥�ύʧ�ܣ�";
		public const string PRESENT_SUCCESSED = "ί��ӹ����뵥�ύ�ɹ���";
		public const string CANCEL_FAILED = "ί��ӹ����뵥����ʧ�ܣ�";
		public const string CANCEL_SUCCESSED = "ί��ӹ����뵥���ϳɹ���";
		public const string NOOBJECT = "�ն���";
		public const string OUT_FAILED= "ί��ӹ����뵥����ʧ�ܣ�";
		public const string OUT_SUCCESSED = "ί��ӹ����뵥���ϳɹ���";
		public const string Refuse_Failed = "ί��ӹ����뵥�ܷ�ʧ�ܣ�";
		public const string Refuse_Success = "ί��ӹ����뵥�ܷ��ɹ���";
		public const string NoStorage = "ί��ӹ����뵥����Ҫָ�����ϲֿ⣡";
		public const string NoPurpose = "ί��ӹ����뵥����Ҫָ����;��";
		public const string NoDept = "ί��ӹ����뵥����Ҫָ�����ò��ţ�";
		public const string NoProposer = "ί��ӹ����뵥����Ҫָ�������ˣ�";
		public const string XUpdate = "ί��ӹ����뵥�޸ĵ�ǰ���ǣ����ݴ����½������ϡ�������ͨ����״̬��";
		public const string XCancel = "ί��ӹ����뵥�޸ĵ�ǰ���ǣ����ݴ����½���������ͨ����״̬��";
		public const string XDelete = "ί��ӹ����뵥ɾ����ǰ���ǣ����ݴ������ϵ�״̬��";
		public const string XPresent = "ί��ӹ����뵥�ύ��ǰ���ǣ����ݴ����½������ϡ�������ͨ����״̬��";
		public const string XFirstAudit = "ί��ӹ����뵥һ��������ǰ���ǣ����ݴ����ύ��״̬��";
		public const string XSecondAudit = "ί��ӹ����뵥����������ǰ���ǣ����ݴ���һ������ͨ����״̬��";
		public const string XThirdAudit = "ί��ӹ����뵥����������ǰ���ǣ����ݴ��ڶ�������ͨ����״̬��";
		public const string XRefuse = "ί��ӹ����뵥�ܾ���ǰ���ǣ����ݴ�������ͨ����״̬��";
		/// <value>��������ʵ��</value>
		public const string WTOW_TABLE           = "WTOW";					//������
		public const string REQDEPT_FIELD		 = "ReqDept";
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";
		public const string PROPOSERNAME_FIELD	 = "ProposerName";			//�����ˡ�	
		public const string PROPOSERCODE_FIELD	 = "ProposerCode";			//�����˱�š�
		public const string STOMANAGERCODE_FIELD = "StoManagerCode";		//�ֿ����Ա����
		public const string STOMANAGER_FIELD     = "StoManager";			//�ֿ����Ա
		public const string DRAWDATE_FIELD       = "DrawDate";				//��������
//		public const string SOURCEENTRY_FIELD    = "SourceEntry";			//Դ������ˮ��
//		public const string SOURCEDOCCODE_FIELD  = "SourceDocCode";			//Դ��������
//		public const string SOURCESERIALNO_FIELD = "SourceSerialNo";		//Դ����˳��š�
		public const string REQREASONCODE_FIELD  = "ReqReasonCode";			//��;���
		public const string REQREASON_FIELD      = "ReqReason";				//��;����
		public const string PLANNUM_FIELD        = "PlanNum";				//��������
		public const string STOCKNUM_FIELD       = "StockNum";				//��ǰ��档
//		public const string ITEMSUMMARY_FIELD	 = "ItemSummary";			//����ժҪ��
		public const string TERM_FIELD			 = "Term";
		public const string DRAWINGCOUNT_FIELD   = "DrawingCount";
		public const string PROSPECTUSCOUNT_FIELD= "ProspectusCount";
		public const string PROCESSCONTENT_FIELD = "ProcessContent";
		public const string PARENTENTRYNO_FIELD	 = "ParentEntryNo";
		#endregion

		#region ����
		/// <summary>
		/// ί��ӹ����뵥���������������
		/// </summary>
		public int Count
		{
			get { return this.Tables[WTOWData.WTOW_TABLE].Rows.Count;}
		}
		
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ�����ί��ӹ����뵥�����ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table = new DataTable(WTOW_TABLE);
			InItemData oItemData = new InItemData(table);
			DataColumnCollection columns = table.Columns;
			columns.Add(STOMANAGERCODE_FIELD,typeof(System.String));	//�ֿ����Ա����
			columns.Add(STOMANAGER_FIELD,typeof(System.String));		//�ֿ����Ա
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));		//��������
//			columns.Add(SOURCEENTRY_FIELD,typeof(System.String));		//Դ������ˮ��
//			columns.Add(SOURCEDOCCODE_FIELD,typeof(System.String));		//Դ��������
//			columns.Add(SOURCESERIALNO_FIELD, typeof(System.String));	//Դ����˳��š�
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//���첿�š�
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//���첿�����ơ�
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//�����ˡ�
			columns.Add(PROPOSERNAME_FIELD, typeof(System.String));			//���������ơ�
			columns.Add(REQREASONCODE_FIELD,typeof(System.String));		//��;���
			columns.Add(REQREASON_FIELD,typeof(System.String));			//��;����
			columns.Add(PLANNUM_FIELD,typeof(System.String));			//��������
			columns.Add(STOCKNUM_FIELD, typeof(System.String));			//��ǰ��档
//			columns.Add(ITEMSUMMARY_FIELD, typeof(System.String));		//����ժҪ��
			columns.Add(TERM_FIELD, typeof(System.DateTime));
			columns.Add(DRAWINGCOUNT_FIELD, typeof(System.Int32));
			columns.Add(PROSPECTUSCOUNT_FIELD, typeof(System.Int32));
			columns.Add(PROCESSCONTENT_FIELD, typeof(System.String));
			columns.Add(PARENTENTRYNO_FIELD, typeof(System.Int32));		//���ָ����ݺš�

			this.Tables.Add(table);
		}
		#endregion

		#region ���캯��
		private WTOWData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WTOWData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
