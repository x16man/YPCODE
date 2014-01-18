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
	/// ���ϵ�������ʵ�壬������DocBaseData��InItemData�����ԡ�
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WDRWData:DataSet
	{
		#region ��Ա����
		public const string ADD_FAILED = "���ϵ��½�ʧ�ܣ�";
		public const string ADD_SUCCESSED = "���ϵ��½��ɹ���";
		public const string UPDATE_FAILED = "���ϵ��޸�ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "���ϵ��޸ĳɹ���";
		public const string DELETE_FAILED = "���ϵ�ɾ��ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "���ϵ�ɾ���ɹ���";
		public const string UPDATESTATE_FAILED = "���ϵ��޸�״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "���ϵ��޸�״̬�ɹ���";
		public const string FIRSTAUDIT_FAILED = "���ϵ�һ������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "���ϵ�һ�������ɹ���";
		public const string SECONDAUDIT_FAILED = "���ϵ���������ʧ�ܣ�";
		public const string SECONDAUDIT_SUCCESSED = "���ϵ����������ɹ���";
		public const string THIRDAUDIT_FAILED = "���ϵ���������ʧ�ܣ�";
		public const string THIRDAUDIT_SUCCESSED = "���ϵ����������ɹ���";
		public const string PRESENT_FAILED = "���ϵ��ύʧ�ܣ�";
		public const string PRESENT_SUCCESSED = "���ϵ��ύ�ɹ���";
		public const string CANCEL_FAILED = "���ϵ�����ʧ�ܣ�";
		public const string CANCEL_SUCCESSED = "���ϵ����ϳɹ���";
		public const string NOOBJECT = "�ն���";
		public const string OUT_FAILED= "���ϵ�����ʧ�ܣ�";
		public const string OUT_SUCCESSED = "���ϵ����ϳɹ���";
		public const string Refuse_Failed = "���ϵ��ܷ�ʧ�ܣ�";
		public const string Refuse_Success = "���ϵ��ܷ��ɹ���";
		public const string NoStorage = "���ϵ�����Ҫָ�����ϲֿ⣡";
		public const string NoPurpose = "���ϵ�����Ҫָ����;��";
		public const string NoDept = "���ϵ�����Ҫָ�����ò��ţ�";
		public const string NoProposer = "���ϵ�����Ҫָ�������ˣ�";
		public const string XUpdate = "���ϵ��޸ĵ�ǰ���ǣ����ݴ����½������ϡ�������ͨ����״̬��";
		public const string XCancel = "���ϵ��޸ĵ�ǰ���ǣ����ݴ����½���������ͨ����״̬��";
		public const string XDelete = "���ϵ�ɾ����ǰ���ǣ����ݴ������ϵ�״̬��";
		public const string XPresent = "���ϵ��ύ��ǰ���ǣ����ݴ����½������ϡ�������ͨ����״̬��";
		public const string XFirstAudit = "���ϵ�һ��������ǰ���ǣ����ݴ����ύ��״̬��";
		public const string XSecondAudit = "���ϵ�����������ǰ���ǣ����ݴ���һ������ͨ����״̬��";
		public const string XThirdAudit = "���ϵ�����������ǰ���ǣ����ݴ��ڶ�������ͨ����״̬��";
		public const string XRefuse = "���ϵ��ܾ���ǰ���ǣ����ݴ�������ͨ����״̬��";
		/// <value>��������ʵ��</value>
		public const string WDRW_TABLE           = "WDRW";					//������
		public const string WDS_VIEW             = "ViewDrawSource";		//���ϵ���������Դ�б���ͼ��
		public const string WDSD_VIEW            = "ViewDrawSourceDetail";	//���ϵ���������Դ��ͼ��
		public const string REQDEPT_FIELD		 = "ReqDept";
		public const string REQDEPTNAME_FIELD    = "ReqDeptName";
		public const string PROPOSER_FIELD		 = "Proposer";				//�����ˡ�	
		public const string PROPOSERCODE_FIELD	 = "ProposerCode";			//�����˱�š�
		public const string STOMANAGERCODE_FIELD = "StoManagerCode";		//�ֿ����Ա����
		public const string STOMANAGER_FIELD     = "StoManager";			//�ֿ����Ա
		public const string DRAWDATE_FIELD       = "DrawDate";				//��������
		public const string SOURCEENTRY_FIELD    = "SourceEntry";			//Դ������ˮ��
		public const string SOURCEDOCCODE_FIELD  = "SourceDocCode";			//Դ��������
		public const string SOURCESERIALNO_FIELD = "SourceSerialNo";		//Դ����˳��š�
		public const string REQREASONCODE_FIELD  = "ReqReasonCode";			//��;���
		public const string REQREASON_FIELD      = "ReqReason";				//��;����
		public const string STOCODE_FIELD        = "StoCode";				//�ֿ���
		public const string STONAME_FIELD        = "StoName";				//�ֿ�����
		public const string CONCODE_FIELD		 = "CONCODE";				//��λ��š�
		public const string CONNAME_FIELD		 = "CONNAME";				//��λ���ơ�
		public const string PLANNUM_FIELD        = "PlanNum";				//��������
		public const string STOCKNUM_FIELD       = "StockNum";				//��ǰ��档
		public const string ITEMSUMMARY_FIELD	 = "ItemSummary";			//����ժҪ��
		public const string PARENTENTRYNO_FIELD	 = "ParentEntryNo";
		//���ϵ���Դ��ϸ��ͼ���ֶγ�����
		public const string SourceEntry_Field	= "SourceEntry";
		public const string SourceDocCode_Field = "SourceDocCode";
		public const string SourceDocName_Field = "SourceDocName";
		public const string SourceSerialNo_Field = "SourceSerialNo";
		public const string ItemCode_Field		= "ItemCode";
		public const string ItemName_Field		= "ItemName";
		public const string ItemSpec_Field		= "ItemSpecial";
		public const string ItemUnit_Field		= "ItemUnit";
		public const string ItemUnitName_Field	= "ItemUnitName";
		public const string ItemPrice_Field		= "ItemPrice";
		public const string PlanNum_Field		= "PlanNum";
		public const string ItemMoney_Field     = "ItemMoney";
		//���ϵ���Դ�б���ͼ���ֶγ�����
		public const string EntryNo_Field = "EntryNo";
		public const string EntryCode_Field = "EntryCode";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string EntryState_Field = "EntryState";
		public const string EntryStateName_Field = "EntryStateName";
		public const string EntryDate_Field = "EntryDate";
		public const string ReqDept_Field = "ReqDept";
		public const string ReqDeptName_Field = "ReqDeptName";
		public const string Proposer_Field = "Proposer";
		public const string ProposerCode_Field = "ProposerCode";

		#endregion

		#region ����
		/// <summary>
		/// ���ϵ����������������
		/// </summary>
		public int Count
		{
			get { return this.Tables[WDRWData.WDRW_TABLE].Rows.Count;}
		}
		/// <summary>
		/// ���ϵ���Դ�����嵥��������
		/// </summary>
		public int SourceListCount
		{
			get { return this.Tables[WDRWData.WDS_VIEW].Rows.Count;}
		}
		/// <summary>
		/// ���ϵ���Դ������ϸ��������
		/// </summary>
		public int SourceDetailCount
		{
			get { return this.Tables[WDRWData.WDSD_VIEW].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ��InItemData�Ļ����ϣ��������ϵ������ݱ�
		/// </summary>
		private void BuildDataTables()
		{
			DataTable table = new DataTable(WDRW_TABLE);
			InItemData oItemData = new InItemData(table);
			DataColumnCollection columns = table.Columns;
			columns.Add(STOMANAGERCODE_FIELD,typeof(System.String));	//�ֿ����Ա����
			columns.Add(STOMANAGER_FIELD,typeof(System.String));		//�ֿ����Ա
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));		//��������
			columns.Add(SOURCEENTRY_FIELD,typeof(System.String));		//Դ������ˮ��
			columns.Add(SOURCEDOCCODE_FIELD,typeof(System.String));		//Դ��������
			columns.Add(SOURCESERIALNO_FIELD, typeof(System.String));	//Դ����˳��š�
			columns.Add(REQDEPT_FIELD, typeof(System.String));			//���첿�š�
			columns.Add(REQDEPTNAME_FIELD, typeof(System.String));		//���첿�����ơ�
			columns.Add(PROPOSERCODE_FIELD, typeof(System.String));		//�����ˡ�
			columns.Add(PROPOSER_FIELD, typeof(System.String));			//���������ơ�
			columns.Add(REQREASONCODE_FIELD,typeof(System.String));		//��;���
			columns.Add(REQREASON_FIELD,typeof(System.String));			//��;����
			columns.Add(STOCODE_FIELD,typeof(System.String));			//�ֿ���
			columns.Add(STONAME_FIELD,typeof(System.String));			//�ֿ�����
			columns.Add(CONCODE_FIELD, typeof(System.Int32));			//��λ��š�
			columns.Add(CONNAME_FIELD, typeof(System.String));			//��λ���ơ�
			columns.Add(PLANNUM_FIELD,typeof(System.String));			//��������
			columns.Add(STOCKNUM_FIELD, typeof(System.String));			//��ǰ��档
			columns.Add(ITEMSUMMARY_FIELD, typeof(System.String));		//����ժҪ��
			columns.Add(PARENTENTRYNO_FIELD, typeof(System.Int32));		//���ָ����ݺš�
			this.Tables.Add(table);

			DataTable SourceDetailTable = new DataTable(WDRWData.WDSD_VIEW);
			DataColumnCollection SourceColumns = SourceDetailTable.Columns;
			SourceColumns.Add(WDRWData.SourceEntry_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.SourceDocCode_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.SourceDocName_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.REQREASONCODE_FIELD, typeof(System.String));
			SourceColumns.Add(WDRWData.REQREASON_FIELD, typeof(System.String));
			SourceColumns.Add(WDRWData.SourceSerialNo_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemCode_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemName_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemSpec_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemUnit_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemUnitName_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemPrice_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.PlanNum_Field, typeof(System.String));
			SourceColumns.Add(WDRWData.ItemMoney_Field, typeof(System.String));

			this.Tables.Add(SourceDetailTable);

			DataTable SourceTable = new DataTable(WDRWData.WDS_VIEW);
			DataColumnCollection ListColumns = SourceTable.Columns;
			ListColumns.Add(WDRWData.EntryNo_Field, typeof(System.Int32));
			ListColumns.Add(WDRWData.EntryCode_Field, typeof(System.String));
			ListColumns.Add(WDRWData.DocCode_Field, typeof(System.Int16));
			ListColumns.Add(WDRWData.DocName_Field, typeof(System.String));
			ListColumns.Add(WDRWData.EntryState_Field, typeof(System.String));
			ListColumns.Add(WDRWData.EntryStateName_Field, typeof(System.String));
			ListColumns.Add(WDRWData.EntryDate_Field, typeof(System.String));
			ListColumns.Add(WDRWData.ReqDept_Field, typeof(System.String));
			ListColumns.Add(WDRWData.ReqDeptName_Field, typeof(System.String));
			ListColumns.Add(WDRWData.Proposer_Field, typeof(System.String));
			ListColumns.Add(WDRWData.ProposerCode_Field, typeof(System.String));

			this.Tables.Add(SourceTable);

		}
		#endregion

		#region ���캯��
		private WDRWData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WDRWData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
