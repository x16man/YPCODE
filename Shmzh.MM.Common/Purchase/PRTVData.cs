using System;
using System.Data;
using System.Runtime.Serialization;

namespace Shmzh.MM.Common
{
	/// <summary>
	/// �ɹ����ϵ�������ʵ��㡣
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	public class PRTVData:DataSet
	{
		#region ��Ա����
		//����������鱨����Ϣ��
		public const string NO_OBJECT = "û�й�Ӧ��/�ͻ����ݶ���";
		public const string NO_ROW = "û�й�Ӧ��/�ͻ����������У�";
		//�洢����ִ�����������Ϣ��
		public const string QUERY_FAILED = "�����ɹ����ϵ�����ʧ�ܣ�";
		public const string ADD_FAILED = "��Ӳɹ����ϵ�����ʧ�ܣ�";
		public const string ADD_SUCCESSED = "��Ӳɹ����ϵ����ݳɹ���";
		public const string UPDATE_FAILED = "���Ĳɹ����ϵ�����ʧ�ܣ�";
		public const string UPDATE_SUCCESSED = "���Ĳɹ����ϵ����ݳɹ���";
		public const string DELETE_FAILED = "ɾ���ɹ����ϵ�����ʧ�ܣ�";
		public const string DELETE_SUCCESSED = "ɾ���ɹ����ϵ����ݳɹ���";
		public const string UPDATESTATE_FAILED = "���Ĳɹ����ϵ�״̬ʧ�ܣ�";
		public const string UPDATESTATE_SUCCESSED = "���Ĳɹ����ϵ�״̬�ɹ���";
		public const string FIRSTAUDIT_FAILED = "һ������ʧ�ܣ�";
		public const string SECONDAUDIT_FAILED = "��������ʧ�ܣ�";
		public const string THIRDAUDIT_FAILED = "��������ʧ�ܣ�";
		public const string FIRSTAUDIT_SUCCESSED = "һ�������ɹ���";
		public const string SECONDAUDIT_SUCCESSED = "���������ɹ���";
		public const string THIRDAUDIT_SUCCESSED = "���������ɹ���";
		public const string PRESENT_FAILED = "";
		public const string PRESENT_SUCCESSED = "";
		public const string CANCEL_FAILED = "���ϲ������ɹ�";
		public const string CANCEL_SUCCESSED = "";
		public const string NO_STO = "�������ϵ�����Ҫѡ��ֿ⣡";
		public const string NO_AUDIT_VALUE = "��ѡ��ͨ��������ͨ��������Ҳ����ѡ��ȡ��������";
		public const string DRAW_FAILED = "�˻�ʧ�ܣ�";
		public const string XCancel = "�ɹ����ϵ����ϵ�ǰ�����ڵ��ݴ����½���������ͨ����״̬�£�";
		public const string XDelete = "ֻ�������ϵ�״̬�²�����ɾ����";
		public const string XPresent = "ֻ�����½�����������ͨ����ǰ���£�������Ե��ݽ����ύ������";
		public const string XFirstAudit = "ֻ���ڵ����Ѿ��ύ��״̬�£�������Ե��ݽ���һ��������";
		public const string XSecondAudit = "ֻ���ڵ���һ������ͨ����ǰ���£�������Ե��ݽ��ж���������";
		public const string XThirdAudit = "ֻ���ڵ��ݶ�������ͨ����ǰ���£�������Ե��ݽ�������������";
		public const string XUpdate = "ֻ���ڵ������½�,����,������ͨ����ǰ���£�������Ե��ݽ����޸ģ�";

		public const string PRTV_TABLE  = "PRTV";							//������
		//������Ϣ��
		
		public const string PRVCODE_FIELD			= "PrvCode";		//��Ӧ�̴��롣
		public const string PRVNAME_FIELD			= "PrvName";		//��Ӧ�����ơ�
		public const string PRVBANK_FIELD			= "PrvBank";		//��Ӧ�̿������С�
		public const string PRVACCOUNT_FIELD		= "PrvAccount";		//��Ӧ���˺š�
		public const string PRVREGNO_FIELD			= "PrvRegNo";		//��Ӧ��˰��ǼǺš�
		public const string PRVTEL_FIELD			= "PrvTel";			//��Ӧ����ϵ�绰��
		public const string PRVFAX_FIELD			= "PrvFax";			//��Ӧ�̴��档
		public const string PAYSTYLE_FIELD			= "PayStyle";		//���ʽ��
		public const string INVOICENO_FIELD			= "InvoiceNo";		//��Ʊ�š�
		public const string CHKNO_FIELD				= "ChkNo";			//���յ��š�
		public const string CHKRESULT_FIELD			= "ChkResult";		//���ս����
		public const string CURRENCYCODE_FIELD		= "CurrencyCode";	//���Ҵ��롣
		public const string USEDFOR_FIELD			= "UsedFor";		//���ڡ�
		public const string BUYERCODE_FIELD			= "BuyerCode";		//�ɹ�Ա��š�
		public const string BUYERNAME_FIELD			= "BuyerName";		//�ɹ�Ա���ơ�
		public const string STOCODE_FIELD			= "StoCode";		//�ֿ��š�
		public const string STONAME_FIELD			= "StoName";		//�ֿ����ơ�
		public const string ACCEPTCODE_FIELD		= "AcceptCode";		//�����˱�š�
		public const string ACCEPTNAME_FIELD		= "AccepttName";	//���������ơ�
		public const string ACCEPTDATE_FIELD		= "AcceptDate";		//�������ڡ�
		public const string PCSCODE_FIELD			= "PcsCode";		//��������š�
		public const string PCSNAME_FIELD			= "PcsName";		//���������ơ�
		public const string TOTALMONEY_FIELD		= "TotalMoney";		//�ܼۡ�
		public const string TOTALTAX_FIELD			= "TotalTax";		//��˰�
		public const string TOTALFEE_FIELD			= "TotalFee";		//�ܷ��á�
		public const string TOTALDISCOUNT_FIELD		= "TotalDiscount";	//���ۿۡ�
		public const string JFKM_FIELD				= "JFKM";			//��ƿ�Ŀ��

		//�ӱ���Ϣ��
		public const string SOURCEENTRY_FIELD		= "SourceEntry";	//Դ���ݺš�
		public const string SOURCEDOCCODE_FIELD		= "SourceDocCode";	//Դ�������͡�
		public const string SOURCESERIALNO_FIELD	= "SourceSerialNo";	//Դ˳��š�
		public const string PLANNUM_FIELD			= "PlanNum";		//Ӧ��������
		public const string TAXCODE_FIELD			= "TaxCode";		//˰�մ��롣
		public const string TAXRATE_FIELD			= "TaxRate";		//˰�ʡ�
		public const string ITEMTAX_FIELD			= "ItemTax";		//˰�
		public const string ITEMFEE_FIELD			= "ItemFee";		//���á�
		public const string DISCOUNTRATE_FIELD		= "DiscountRate";	//�ۿ��ʡ�
		public const string ITEMDISCOUNT_FIELD		= "ItemDiscount";	//�ۿ۽�
		public const string ITEMSUM_FIELD			= "ItemSum";		//���Ͻ��ϼơ�
		public const string CONCODE_FIELD			= "ConCode";		//��λ�š�
		public const string CONNAME_FIELD			= "ConName";		//��λ���ơ�
		public const string ITEMNOINVOICENUM_FIELD  = "ItemNoInvoiceNum";//��Ʊδ��������
		public const string BATCHCODE_FIELD			= "BatchCode";		//���š�
		#endregion

		#region ����
		/// <summary>
		/// ��¼����
		/// </summary>
		public int Count
		{
			get { return this.Tables[PRTVData.PRTV_TABLE].Rows.Count;}
		}
		/// <summary>
		/// ������ˮ�š�
		/// </summary>
		public int EntryNo
		{
			get
			{
				if (this.Count >0)
					return Convert.ToInt32(this.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				else
					return -1;
			}
		}
		/// <summary>
		/// ����״̬��
		/// </summary>
		public string EntryState
		{
			get
			{	if (this.Count > 0)
					return this.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();
				else
					return null;
			}
		}
		#endregion
		private PRTVData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public PRTVData()
		{
			BuildDataTables();
		}

		private void BuildDataTables()
		{
			
			DataTable table   = new DataTable(PRTV_TABLE);

			InItemData oItemData=new InItemData(table);

			DataColumnCollection columns = table.Columns;
			//�����ֶ����ӡ�
			columns.Add(PRVCODE_FIELD, typeof(System.String));				//��Ӧ�̴��롣
			columns.Add(PRVNAME_FIELD, typeof(System.String));				//��Ӧ�����ơ�
			columns.Add(PRVBANK_FIELD, typeof(System.String));				//��Ӧ�̿������С�
			columns.Add(PRVACCOUNT_FIELD, typeof(System.String));			//��Ӧ���ʻ���			
			columns.Add(PRVREGNO_FIELD, typeof(System.String));				//��Ӧ��˰��ǼǺš�
			columns.Add(PRVTEL_FIELD, typeof(System.String));				//��Ӧ�̵绰��
			columns.Add(PRVFAX_FIELD, typeof(System.String));				//��Ӧ�̴��档
			columns.Add(PAYSTYLE_FIELD, typeof(System.String));				//���ʽ��
			columns.Add(INVOICENO_FIELD, typeof(System.String));			//��Ʊ���롣
			columns.Add(CHKNO_FIELD, typeof(System.Int32));					//���ձ��档
			columns.Add(CHKRESULT_FIELD, typeof(System.String));			//���������
			columns.Add(CURRENCYCODE_FIELD, typeof(System.String));			//���Ҵ��롣
			columns.Add(USEDFOR_FIELD, typeof(System.String));				//���ڡ�
			columns.Add(BUYERCODE_FIELD, typeof(System.String));			//�ɹ�Ա��š�
			columns.Add(BUYERNAME_FIELD, typeof(System.String));			//�ɹ�Ա���ơ�
			columns.Add(STOCODE_FIELD, typeof(System.String));				//�ֿ��š�
			columns.Add(STONAME_FIELD, typeof(System.String));				//�ֿ����ơ�
			columns.Add(ACCEPTCODE_FIELD, typeof(System.String));			//�����˱�š�
			columns.Add(ACCEPTNAME_FIELD, typeof(System.String));			//���������ơ�
			columns.Add(ACCEPTDATE_FIELD, typeof(System.DateTime));			//�������ڡ�
			columns.Add(PCSCODE_FIELD,typeof(System.String));				//������š�
			columns.Add(PCSNAME_FIELD,typeof(System.String));				//�������ơ�
			columns.Add(TOTALMONEY_FIELD, typeof(System.Decimal));			//�ܼۡ�
			columns.Add(TOTALTAX_FIELD, typeof(System.Decimal));			//��˰�
			columns.Add(TOTALFEE_FIELD, typeof(System.Decimal));			//�ܷ��á�
			columns.Add(TOTALDISCOUNT_FIELD, typeof(System.Decimal));		//���ۿۡ�
			columns.Add(JFKM_FIELD,typeof(string));							//��ƿ�Ŀ��
			//�ӱ��ֶ����ӡ�
			columns.Add(SOURCEENTRY_FIELD, typeof(System.String));			//Դ���ݺš�
			columns.Add(SOURCEDOCCODE_FIELD, typeof(System.String));		//Դ�������͡�
			columns.Add(SOURCESERIALNO_FIELD, typeof(System.String));		//Դ˳��š�
			columns.Add(PLANNUM_FIELD, typeof(System.String));				//Ӧ��������
			columns.Add(TAXCODE_FIELD, typeof(System.String));				//˰�롣
			columns.Add(TAXRATE_FIELD, typeof(System.String));				//����˰�ʡ�
			columns.Add(ITEMTAX_FIELD, typeof(System.String));				//����˰�
			columns.Add(ITEMFEE_FIELD, typeof(System.String));				//������á�
			columns.Add(DISCOUNTRATE_FIELD, typeof(System.String));			//�ۿ��ʡ�
			columns.Add(ITEMDISCOUNT_FIELD, typeof(System.String));			//�����ۿۡ�
			columns.Add(ITEMSUM_FIELD, typeof(System.String));				//�����ܽ�
			columns.Add(CONCODE_FIELD, typeof(System.String));				//��λ�š�
			columns.Add(CONNAME_FIELD, typeof(System.String));				//��λ���ơ�
			columns.Add(ITEMNOINVOICENUM_FIELD, typeof(System.String));		//��Ʊδ��������
			columns.Add(BATCHCODE_FIELD, typeof(System.String));			//���š�
			this.Tables.Add(table);
		}
	}
}
