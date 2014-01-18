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
	/// PurchaseOrderData ��ժҪ˵����
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PurchaseOrderData : DataSet
	{
		#region ������Ϣ
		public const string NOOBJECT = "�ն���";
		public const string ADD_FAILED = "�ɹ������½�ʧ�ܣ�����ԭ���п����ǲɹ������������ˡ�";
		public const string ADD_SUCCESSED = "�ɹ������½��ɹ���";
		public const string UPDATE_FAILED = "�ɹ������޸�ʧ�ܣ�����ԭ���п����ǲɹ������������ˡ�";
		public const string UPDATE_SUCCESSED = "�ɹ������޸ĳɹ���";
		public const string DELETE_FAILED = "�ɹ�����ɾ��ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "�ɹ�����ɾ���ɹ���";
		public const string UPDATESTATE_FAILED = "�ɹ������޸�״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "�ɹ������޸�״̬�ɹ���";
		public const string FIRSTAUDIT_FAILED = "�ɹ�����һ������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "�ɹ�����һ�������ɹ���";
		public const string SECONDAUDIT_FAILED = "�ɹ�������������ʧ�ܣ�";
		public const string SECONDAUDIT_SUCCESSED = "�ɹ��������������ɹ���";
		public const string THIRDAUDIT_FAILED = "�ɹ�������������ʧ�ܣ�";
		public const string THIRDAUDIT_SUCCESSED = "�ɹ��������������ɹ���";
		public const string PRESENT_FAILED = "�ɹ������ύʧ�ܣ�";
		public const string PRESENT_SUCCESSED = "�ɹ������ύ�ɹ���";
		public const string CANCEL_FAILED = "�ɹ���������ʧ�ܣ�";
		public const string CANCEL_SUCCESSED = "�ɹ��������ϳɹ���";
		public const string AFFIRM_SUCCESSED = "�ɹ�����ȷ�ϳɹ���";
		public const string AFFIRM_FAILED = "�ɹ�����ȷ��ʧ�ܣ�";
		public const string NoPrvider = "�ɹ���������Ҫָ����Ӧ�̣�";
		public const string NoBuyer = "�ɹ���������Ҫָ���ɹ�Ա��";
		public const string XUpdate = "�ɹ������޸ĵ�ǰ�ᣬ����״̬�����½���������ͨ�������ϵ�״̬��";
		public const string XUpdatePresent = "�ɹ������޸Ĳ���ָ�ɵ�ǰ�ᣬ����״̬�����½���������ͨ�������ϵ�״̬��";
		public const string XAssign = "�ɹ�����ָ�ɵ�ǰ���ǣ����ݴ����½������ϵ�״̬��";
		public const string XFirstAudit = "�ɹ�����һ��������ǰ���ǣ����ݴ����ύ��״̬��";
		public const string XSecondAudit = "�ɹ���������������ǰ���ǣ����ݴ���һ������ͨ����״̬��";
		public const string XThirdAudit = "�ɹ���������������ǰ���ǣ����ݴ��ڶ�������ͨ����״̬��";
		public const string XDelete = "�ɹ�����ɾ����ǰ���ǣ����ݴ������ϵ�״̬��";
		public const string XCancel = "�ɹ��������ϵ�ǰ���ǣ����ݴ����½���������ͨ����״̬��";
        public const string XConfirm = "�ɹ�����ȷ�ϵ�ǰ���ǣ����ݴ��������ɵ�״̬,���ҵ�ǰȷ�����ǵ���ָ���Ĳɹ�Ա��";
        public const string NumberInsufficient = "Ҫ�������������ڶ���Ƿȱ������";
        public const string NumberCompareZero = "Ҫ����������ӦС��0 ��";
        public const string NumberGreatZero = "Ҫ�������������Ϊ{0}";

        #endregion

		#region ��Ա����
		public const string PORD_TABLE = "PORD";					//������
		public const string SOURCEENTRY_FIELD = "SourceEntry";		//Դ���ݡ�
		public const string SOURCEDOCCODE_FIELD = "SourceDocCode";	//Դ�������͡�
		public const string SOURCESERIALNO_FIELD = "SourceSerialNo"; //Դ����˳��š�
		public const string DELIVERYDATE_FIELD = "DeliveryDate";	//�������ڡ�
		public const string PRVCODE_FIELD = "PrvCode";				//��Ӧ�̱�š�
		public const string PRVNAME_FIELD = "PrvName";				//��Ӧ�����ơ�
		public const string PRVADD_FIELD = "PrvAdd";				//��Ӧ�̵�ַ��
		public const string PRVZIP_FIELD = "PrvZip";				//��Ӧ���ʱࡣ
		public const string PRVTEL_FIELD = "PrvTel";				//��Ӧ����ϵ�绰��
		public const string PRVFAX_FIELD = "PrvFax";				//��Ӧ�̴��档
		public const string PRVLICENCE_FIELD = "PrvLicence";		//Ӫҵִ�պš�
		public const string PRVBANK_FIELD = "PrvBank";				//�������С�
		public const string PRVACCOUNT_FIELD = "PrvAccount";		//�����ʻ���
		public const string PRVTAXNO_FIELD = "PrvTaxNo";			//˰��ǼǺš�
		public const string TRANSTYPE_FIELD = "TransType";			//���䷽ʽ��
		public const string CURRENCYCODE_FIELD = "CurrencyCode";	//���֡�
		public const string PAYSTYLE_FIELD = "PayStyle";			//���ʽ��
		public const string PAYMENT_FIELD = "Payment";				//�������
		public const string SENDTO_FIELD = "SendTo";				//�͵���
		public const string INVOICETO_FIELD = "InvoiceTo";			//��Ʊ����
		public const string TOTALMONEY_FIELD = "TotalMoney";		//�ܽ�
		public const string TOTALTAX_FIELD = "TotalTax";			//��˰�
		public const string TOTALDISCOUNT_FIELD = "TotalDiscount";	//���ۿۡ�
		public const string TOTALFEE_FIELD = "TotalFee";			//�ܷ��á�
	    
		public const string BUYERCODE_FIELD = "BuyerCode";			//�ɹ�Ա��š�
		public const string BUYERNAME_FIELD = "BuyerName";			//�ɹ�Ա���ơ�
        public const string PSCCODE_FIELD = "PscCode";				//������š�
		public const string PSCNAME_FIELD = "PscName";				//�������ơ�
		public const string TAXCODE_FIELD = "TaxCode";				//˰�롣
		public const string TAXRATE_FIELD = "TaxRate";				//����˰�ʡ�
		public const string ITEMTAX_FIELD = "ItemTax";				//����˰�
		public const string DISCOUNTRATE_FIELD = "DiscountRate";	//�����ۿ��ʡ�
		public const string ITEMDISCOUNT_FIELD = "ItemDiscount";	//�����ۿ۶
		public const string ITEMFEE_FIELD = "ItemFee";				//���Ϸ��á�
		public const string ITEMSUM_FIELD = "ItemSum";				//�����ܽ�
		public const string ITEMLACKNUM_FIELD = "ItemLackNum";		//����Ƿ��������
		public const string ITEMINVNUM_FIELD = "ItemInvNum";		//���Ͽ�Ʊ������
		public const string PKID_FIELD = "PKID";                    //PKIFD
		public const string Proposer_Field = "Proposer";			//��������Ϣ��
		public const string CatCode_Field = "CatCode";				//��Ӧ�̷��ࡣ
		public const string CatName_Field = "CatName";				//��Ӧ�̷������ơ�
        public const string ParentEntryNo_Field = "ParentEntryNo";		//ParentEntryNo
		
		#endregion

		#region ����
		public int Count
		{
			get { return this.Tables[PurchaseOrderData.PORD_TABLE].Rows.Count;}
		}
		#endregion

		#region ˽�з���
		private void BuildDataTables()
		{
			DataTable table   = new DataTable(PORD_TABLE);
			InItemData oItemData=new InItemData(table);
			DataColumnCollection columns = table.Columns;
			
			columns.Add(SOURCEENTRY_FIELD, typeof(System.String));
			columns.Add(SOURCEDOCCODE_FIELD, typeof(System.String));
			columns.Add(SOURCESERIALNO_FIELD,typeof(System.String));
			columns.Add(DELIVERYDATE_FIELD, typeof(System.DateTime));			
			columns.Add(PRVCODE_FIELD, typeof(System.String));
			columns.Add(PRVNAME_FIELD, typeof(System.String));
			columns.Add(PRVADD_FIELD, typeof(System.String));
			columns.Add(PRVZIP_FIELD, typeof(System.String));
			columns.Add(PRVTEL_FIELD, typeof(System.String));
			columns.Add(PRVFAX_FIELD, typeof(System.String));
			columns.Add(PRVLICENCE_FIELD, typeof(System.String));
			columns.Add(PRVBANK_FIELD, typeof(System.String));
			columns.Add(PRVACCOUNT_FIELD, typeof(System.String));
			columns.Add(PRVTAXNO_FIELD, typeof(System.String));
			columns.Add(TRANSTYPE_FIELD, typeof(System.Int16));
			columns.Add(CURRENCYCODE_FIELD, typeof(System.String));
			columns.Add(PAYSTYLE_FIELD, typeof(System.String));
			columns.Add(PAYMENT_FIELD, typeof(System.String));
			columns.Add(SENDTO_FIELD, typeof(System.String));
			columns.Add(INVOICETO_FIELD, typeof(System.String));
			columns.Add(TOTALMONEY_FIELD, typeof(System.Decimal));
			columns.Add(TOTALTAX_FIELD, typeof(System.Decimal));
			columns.Add(TOTALDISCOUNT_FIELD, typeof(System.Decimal));
			columns.Add(TOTALFEE_FIELD, typeof(System.Decimal));
			columns.Add(BUYERCODE_FIELD, typeof(System.String));
			columns.Add(BUYERNAME_FIELD, typeof(System.String));
			columns.Add(PSCCODE_FIELD,  typeof(System.String));
			columns.Add(PSCNAME_FIELD,  typeof(System.String));
			columns.Add(TAXCODE_FIELD,  typeof(System.Int16));
			columns.Add(TAXRATE_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMTAX_FIELD,  typeof(System.Decimal));
			columns.Add(DISCOUNTRATE_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMDISCOUNT_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMFEE_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMSUM_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMLACKNUM_FIELD,  typeof(System.Decimal));
			columns.Add(ITEMINVNUM_FIELD,  typeof(System.Decimal));
			columns.Add(PKID_FIELD, typeof(System.String));
			columns.Add(Proposer_Field, typeof(System.String));
			columns.Add(CatCode_Field, typeof(System.Int32));
			columns.Add(CatName_Field, typeof(System.String));
            columns.Add(ParentEntryNo_Field, typeof(System.Int32));
		    
			this.Tables.Add(table);
		}
		
		#endregion

		#region ���캯��
		private PurchaseOrderData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}
		public PurchaseOrderData()
		{
			BuildDataTables();
		}
		#endregion
	}
}
