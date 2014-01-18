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
	/// ί��ӹ����ϵ�������ʵ�壬������DocBaseData��InItemData�����ԡ�
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class WINWData:DataSet
	{
		#region ��Ա����
		public const string ADD_FAILED = "ί��ӹ����ϵ��½�ʧ�ܣ�";
		public const string ADD_SUCCESSED = "ί��ӹ����ϵ��½��ɹ���";
		public const string UPDATE_FAILED = "ί��ӹ����ϵ��޸�ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "ί��ӹ����ϵ��޸ĳɹ���";
		public const string DELETE_FAILED = "ί��ӹ����ϵ�ɾ��ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "ί��ӹ����ϵ�ɾ���ɹ���";
		public const string UPDATESTATE_FAILED = "ί��ӹ����ϵ��޸�״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "ί��ӹ����ϵ��޸�״̬�ɹ���";
		public const string FIRSTAUDIT_FAILED = "ί��ӹ����ϵ�һ������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "ί��ӹ����ϵ�һ�������ɹ���";
		public const string SECONDAUDIT_FAILED = "ί��ӹ����ϵ���������ʧ�ܣ�";
		public const string SECONDAUDIT_SUCCESSED = "ί��ӹ����ϵ����������ɹ���";
		public const string THIRDAUDIT_FAILED = "ί��ӹ����ϵ���������ʧ�ܣ�";
		public const string THIRDAUDIT_SUCCESSED = "ί��ӹ����ϵ����������ɹ���";
		public const string PRESENT_FAILED = "ί��ӹ����ϵ��ύʧ�ܣ�";
		public const string PRESENT_SUCCESSED = "ί��ӹ����ϵ��ύ�ɹ���";
		public const string CANCEL_FAILED = "ί��ӹ����ϵ�����ʧ�ܣ�";
		public const string CANCEL_SUCCESSED = "ί��ӹ����ϵ����ϳɹ���";
		public const string NOOBJECT = "�ն���";
		public const string XUpdate = "ί��ӹ����ϵ��޸ĵ�ǰ���ǣ����ݴ����½������ϡ�������ͨ����״̬��";
		public const string XCancel = "ί��ӹ����ϵ��޸ĵ�ǰ���ǣ����ݴ����½���������ͨ����״̬��";
		public const string XDelete = "ί��ӹ����ϵ�ɾ����ǰ���ǣ����ݴ������ϵ�״̬��";
		public const string XPresent = "ί��ӹ����ϵ��ύ��ǰ���ǣ����ݴ����½������ϡ�������ͨ����״̬��";
		public const string XFirstAudit = "ί��ӹ����ϵ�һ��������ǰ���ǣ����ݴ����ύ��״̬��";
		public const string XSecondAudit = "ί��ӹ����ϵ�����������ǰ���ǣ����ݴ���һ������ͨ����״̬��";
		public const string XThirdAudit = "ί��ӹ����ϵ�����������ǰ���ǣ����ݴ��ڶ�������ͨ����״̬��";
		
		//WINW
		public const string WINW_TABLE = "WINW";					//������
		public const string EntryNo_Field = "EntryNo";
		public const string EntryCode_Field = "EntryCode";
		public const string DocCode_Field = "DocCode";
		public const string DocName_Field = "DocName";
		public const string DocNo_Field	= "DocNo";
		public const string EntryState_Field = "EntryState";
		public const string EntryDate_Field	= "EntryDate";
		public const string AuthorCode_Field = "AuthorCode";
		public const string AuthorName_Field = "AuthorName";
		public const string AuthorLoginID_Field = "AuthorLoginID";
		public const string AuthorDept_Field = "AuthorDept";
		public const string AuthorDeptName_Field = "AuthorDeptName";
		public const string ReqReasonCode_Field = "ReqReasonCode";
		public const string ReqReason_Field = "ReqReason";
		public const string PresentDate_Field = "PresentDate";
		public const string CancelDate_Field = "CancelDate";
		public const string AcceptDate_Field = "AcceptDate";
		public const string StoCode_Field = "StoCode";
		public const string StoName_Field = "StoName";
		public const string StoManagerCode_Field = "StoManagerCode";
		public const string StoManager_Field = "StoManager";
		public const string Audit1_Field = "Audit1";
		public const string Assessor1_Field = "Assessor1";
		public const string AuditSuggest1_Field = "AuditSuggest1";
		public const string AuditDate1_Field = "AuditDate1";
		public const string Audit2_Field = "Audit2";
		public const string Assessor2_Field = "Assessor2";
		public const string AuditSuggest2_Field = "AuditSuggest2";
		public const string AuditDate2_Field = "AuditDate2";
		public const string Audit3_Field = "Audit3";
		public const string Assessor3_Field = "Assessor3";
		public const string AuditSuggest3_Field = "AuditSuggest3";
		public const string AuditDate3_Field = "AuditDate3";
		public const string ResTotal_Field = "ResTotal";
		public const string FeeTotal_Field = "FeeTotal";
		public const string SubTotal_Field = "SubTotal";
		public const string ProcessContent_Field = "ProcessContent";
		public const string Remark_Field = "Remark";
		public const string ParentEntryNo_Field = "ParentEntryNo";      
		public const string InvoiceNo_Field = "InvoiceNo";
		public const string BuyerCode_Field = "BuyerCode";
		public const string BuyerName_Field = "BuyerName";
		public const string PrvCode_Field = "PrvCode";
		public const string PrvName_Field = "PrvName";
	    public const string ContractCode_Field = "ContractCode";
		public const string PayStyle_Field = "PayStyle";
		public const string ChkNo_Field = "ChkNo";
		public const string ChkResult_Field = "ChkResult";
		public const string PayDate_Field = "PayDate";
		public const string Payer_Field = "Payer";

		public const string ItemSummary_Field = "ItemSummary";
		//WDIW
		public const string WDIW_TABLE = "WDIW";		
		//public const string EntryNo_Field = "EntryNo";
		public const string SerialNo_Field = "SerialNo";
		public const string ItemCode_Field = "ItemCode";
		public const string ItemName_Field = "ItemName";
		public const string ItemSpec_Field = "ItemSpecial";
		public const string ItemUnit_Field = "ItemUnit";
		public const string ItemUnitName_Field = "ItemUnitName";
		public const string PlanNum_Field = "PlanNum";
		public const string ItemNum_Field = "ItemNum";
		public const string ItemPrice_Field = "ItemPrice";
		public const string ItemFee_Field = "ItemFee";
		public const string ItemMoney_Field = "ItemMoney";
		public const string ItemSum_Field = "ItemSum";
		public const string ConCode_Field = "ConCode";
		public const string ConName_Field = "ConName";
		//WRES
		public const string WRES_TABLE = "WRES";
		//public const string EntryNo_Field = "EntryNo";
		public const string SourceEntryNo_Field = "SourceEntryNo";
		public const string SourceDocCode_Field = "SourceDocCode";
		public const string SouceSerialNo_Field = "SourceSerialNo";
		public const string PSerialNo_Field  = "PSerialNo";
		public const string ResSerialNo_Field = "ResSerialNo";
		public const string ResCode_Field = "ResCode";
		public const string ResName_Field = "ResName";
		public const string ResSpecial_Field = "ResSpecial";
		public const string ResUnit_Field = "ResUnit";
		public const string ResUnitName_Field = "ResUnitName";
        public const string ResNum_Field = "ResNum";
		public const string ResPrice_Field = "ResPrice";
		public const string ResMoney_Field = "ResMoney";

		#endregion

		#region ����
		/// <summary>
		/// ί��ӹ����ϵ����������������
		/// </summary>
		public int Count
		{
			get { return this.Tables[WINWData.WINW_TABLE].Rows.Count;}
		}
		public int ItemCount
		{
			get { return this.Tables[WINWData.WINW_TABLE].Rows.Count;}
		}
		public int ResCount
		{
			get { return this.Tables[WINWData.WRES_TABLE].Rows.Count;}
		}
		
		#endregion

		#region ˽�з���
		
		private void BuildDataTables()
		{
			DataTable DT_WINW = new DataTable(WINW_TABLE);
			DataTable DT_WDIW = new DataTable(WDIW_TABLE);
			DataTable DT_WRES = new DataTable(WRES_TABLE);
            //WINW
			DT_WINW.Columns.Add(WINWData.EntryNo_Field, typeof(System.Int32));
			DT_WINW.Columns.Add(WINWData.EntryCode_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.DocCode_Field, typeof(System.Int16));
			DT_WINW.Columns.Add(WINWData.DocName_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.DocNo_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.EntryState_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.EntryDate_Field, typeof(System.DateTime));
			DT_WINW.Columns.Add(WINWData.AuthorCode_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuthorName_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuthorLoginID_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuthorDept_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuthorDeptName_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.ReqReasonCode_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.ReqReason_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.PresentDate_Field, typeof(System.DateTime));
			DT_WINW.Columns.Add(WINWData.CancelDate_Field, typeof(System.DateTime));
			DT_WINW.Columns.Add(WINWData.AcceptDate_Field, typeof(System.DateTime));
			DT_WINW.Columns.Add(WINWData.PrvCode_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.PrvName_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.StoCode_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.StoName_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.StoManagerCode_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.StoManager_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.Audit1_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.Assessor1_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuditSuggest1_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuditDate1_Field, typeof(System.DateTime));
			DT_WINW.Columns.Add(WINWData.Audit2_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.Assessor2_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuditSuggest2_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuditDate2_Field, typeof(System.DateTime));
			DT_WINW.Columns.Add(WINWData.Audit3_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.Assessor3_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuditSuggest3_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.AuditDate3_Field, typeof(System.DateTime));
			DT_WINW.Columns.Add(WINWData.ResTotal_Field, typeof(System.Decimal));
			DT_WINW.Columns.Add(WINWData.FeeTotal_Field, typeof(System.Decimal));
			DT_WINW.Columns.Add(WINWData.SubTotal_Field, typeof(System.Decimal));
			DT_WINW.Columns.Add(WINWData.ProcessContent_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.Remark_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.ParentEntryNo_Field, typeof(System.Int32));
			DT_WINW.Columns.Add(WINWData.InvoiceNo_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.ContractCode_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.BuyerCode_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.BuyerName_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.PayStyle_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.ChkNo_Field, typeof(System.Int16));
			DT_WINW.Columns.Add(WINWData.ChkResult_Field, typeof(System.String));
			DT_WINW.Columns.Add(WINWData.PayDate_Field, typeof(System.DateTime));
			DT_WINW.Columns.Add(WINWData.Payer_Field, typeof(System.String));

			DT_WINW.Columns.Add(WINWData.ItemSummary_Field, typeof(System.String));
			this.Tables.Add(DT_WINW);
			//WDIW
			DT_WDIW.Columns.Add(EntryNo_Field, typeof(System.Int32));
			DT_WDIW.Columns.Add(SerialNo_Field, typeof(System.Int16));
			DT_WDIW.Columns.Add(ItemCode_Field, typeof(System.String));
			DT_WDIW.Columns.Add(ItemName_Field, typeof(System.String));
			DT_WDIW.Columns.Add(ItemSpec_Field, typeof(System.String));
			DT_WDIW.Columns.Add(ItemUnit_Field, typeof(System.Int16));
			DT_WDIW.Columns.Add(ItemUnitName_Field, typeof(System.String));
			DT_WDIW.Columns.Add(PlanNum_Field, typeof(System.Decimal));
			DT_WDIW.Columns.Add(ItemNum_Field, typeof(System.Decimal));
			DT_WDIW.Columns.Add(ItemPrice_Field, typeof(System.Decimal));
			DT_WDIW.Columns.Add(ItemFee_Field, typeof(System.Decimal));
			DT_WDIW.Columns.Add(ItemMoney_Field, typeof(System.Decimal));
			DT_WDIW.Columns.Add(ItemSum_Field, typeof(System.Decimal));
			DT_WDIW.Columns.Add(StoCode_Field, typeof(System.String));
			DT_WDIW.Columns.Add(StoName_Field, typeof(System.String));
			DT_WDIW.Columns.Add(ConCode_Field, typeof(System.Int32));
			DT_WDIW.Columns.Add(ConName_Field, typeof(System.String));
			this.Tables.Add(DT_WDIW);
			//WRES
			DT_WRES.Columns.Add(EntryNo_Field, typeof(System.Int32));
			DT_WRES.Columns.Add(SourceEntryNo_Field, typeof(System.Int32));
			DT_WRES.Columns.Add(SourceDocCode_Field, typeof(System.Int16));
			DT_WRES.Columns.Add(SouceSerialNo_Field, typeof(System.Int16));
			DT_WRES.Columns.Add(PSerialNo_Field, typeof(System.Int16));
			DT_WRES.Columns.Add(ResSerialNo_Field, typeof(System.Int16));
			DT_WRES.Columns.Add(ResCode_Field, typeof(System.String));
			DT_WRES.Columns.Add(ResName_Field, typeof(System.String));
			DT_WRES.Columns.Add(ResSpecial_Field, typeof(System.String));
			DT_WRES.Columns.Add(ResUnit_Field, typeof(System.Int16));
			DT_WRES.Columns.Add(ResUnitName_Field, typeof(System.String));
			DT_WRES.Columns.Add(ResNum_Field, typeof(System.Decimal));
			DT_WRES.Columns.Add(ResPrice_Field, typeof(System.Decimal));
			DT_WRES.Columns.Add(ResMoney_Field, typeof(System.Decimal));
			this.Tables.Add(DT_WRES);
		}
		#endregion

		#region ���캯��
		private WINWData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public WINWData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
