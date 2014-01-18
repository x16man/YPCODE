namespace Shmzh.MM.DataAccess
{
	using System;
    using System.Configuration;
	using System.Data;
    using System.Data.SqlClient;
	using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;
	/// <summary>
	/// ���ϵ������ݷ��ʲ㡣
	/// 
	/// </summary>
	public class BillOfReceives :IInItems
	{
		#region ���캯��
		public BillOfReceives()
		{}
		#endregion ���캯��
		#region ˽�б��� 
		/// <summary>
		/// SQLServer ����
		/// </summary>
		private SQLServer oSQLServer = new SQLServer();
		#endregion

		#region ����
		/// <summary>
		/// �쳣��Ϣ��
		/// </summary>
		public string Message
		{
			get {return this.oSQLServer.ExceptionMessage;}
		}
        /// <summary>
        /// ���ݿ������ַ�����
        /// </summary>
        public string ConnString {get {return ConfigurationManager.AppSettings["ConnectionString"];}}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ����ϣ��
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	���ϵ�ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(BillOfReceiveData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];
			//����ģʽ�����ֶΡ�
			//�������ֶΡ�
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//������ˮ�š�
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//���ݱ�š�
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//�������͡�
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//�����������ơ�
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//���������ĵ���š�
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//����״̬��
			oHT.Add("@EntryDate",		oRow[InItemData.ENTRYDATE_FIELD]);					//�Ƶ����ڡ�
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//�Ƶ��˱�š�
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//�Ƶ������ơ�
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//�Ƶ��˵�¼����
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//�Ƶ��˲��š�
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//�Ƶ��˲������ơ�
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);			//�����ܼơ�
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);				      //��ע��
			//�ӱ����ֶΡ�
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//������ϸ����˳��š�
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//���ϱ�š�
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//�������ơ�
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//���Ϲ��
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//���ϵ��ۡ�
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//����������
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",	oRow[InItemData.ITEMUNITNAME_FIELD]);			//���ϵ�λ������
			//���ϵ����������ֶΡ�
			oHT.Add("@PrvCode",			oRow[BillOfReceiveData.PRVCODE_FIELD]);				//��Ӧ�̱�š�
			oHT.Add("@PrvName",			oRow[BillOfReceiveData.PRVNAME_FIELD]);				//��Ӧ�����ơ�
			oHT.Add("@PrvBank",			oRow[BillOfReceiveData.PRVBANK_FIELD]);				//��Ӧ�̿������С�
			oHT.Add("@PrvAccount",		oRow[BillOfReceiveData.PRVACCOUNT_FIELD]);			//��Ӧ���˺š�
			oHT.Add("@PrvRegNo",		oRow[BillOfReceiveData.PRVREGNO_FIELD]);			//��Ӧ��˰��ǼǺš�
			oHT.Add("@PrvTel",			oRow[BillOfReceiveData.PRVTEL_FIELD]);				//��Ӧ�̵绰��
			oHT.Add("@PrvFax",			oRow[BillOfReceiveData.PRVFAX_FIELD]);				//��Ӧ�̴��档
			oHT.Add("@PayStyle",		oRow[BillOfReceiveData.PAYSTYLE_FIELD]);			//���ʽ��
			oHT.Add("@InvoiceNo",		oRow[BillOfReceiveData.INVOICENO_FIELD]);			//��Ʊ���롣
			oHT.Add("@ChkNo",			oRow[BillOfReceiveData.CHKNO_FIELD]);				//���յ��š�
			oHT.Add("@ChkResult",		oRow[BillOfReceiveData.CHKRESULT_FIELD]);			//���������
			oHT.Add("@CurrencyCode",	oRow[BillOfReceiveData.CURRENCYCODE_FIELD]);		//���Ҵ��롣
			oHT.Add("@UsedFor",			oRow[BillOfReceiveData.USEDFOR_FIELD]);				//���ڡ�
			oHT.Add("@BuyerCode",		oRow[BillOfReceiveData.BUYERCODE_FIELD]);			//�ɹ�Ա��š�
			oHT.Add("@BuyerName",		oRow[BillOfReceiveData.BUYERNAME_FIELD]);			//�ɹ�Ա���ơ�
			oHT.Add("@StoCode",			oRow[BillOfReceiveData.STOCODE_FIELD]);				//�ֿ��š�
			oHT.Add("@StoName",			oRow[BillOfReceiveData.STONAME_FIELD]);				//�ֿ����ơ�
			oHT.Add("@AcceptCode",		oRow[BillOfReceiveData.ACCEPTCODE_FIELD]);			//�����˱�š�
			oHT.Add("@AcceptName",		oRow[BillOfReceiveData.ACCEPTNAME_FIELD]);			//���������ơ�
			oHT.Add("@AcceptDate",		oRow[BillOfReceiveData.ACCEPTDATE_FIELD]);			//�������ڡ�
			oHT.Add("@PcsCode",			oRow[BillOfReceiveData.PCSCODE_FIELD]);				//������š�
			oHT.Add("@PcsName",			oRow[BillOfReceiveData.PCSNAME_FIELD]);				//�������ơ�
			oHT.Add("@TotalMoney",		oRow[BillOfReceiveData.TOTALMONEY_FIELD]);			//�ܼۡ�
			oHT.Add("@TotalTax",		oRow[BillOfReceiveData.TOTALTAX_FIELD]);			//��˰�
			oHT.Add("@TotalFee",		oRow[BillOfReceiveData.TOTALFEE_FIELD]);			//�ܷ��á�
			oHT.Add("@TotalDiscount",	oRow[BillOfReceiveData.TOTALDISCOUNT_FIELD]);		//���ۿۡ�
			oHT.Add("@JFKM",			oRow[BillOfReceiveData.JFKM_FIELD]);				//��ƿ�Ŀ��
			oHT.Add("@ContractCode",	oRow[BillOfReceiveData.CONTRACTCODE_FIELD]);		//��ͬ�š�
			oHT.Add("@ParentEntryNo",	oRow[BillOfReceiveData.PARENTENTRYNO_FIELD]);		//��Ӧ�����ݺš�
			//���ϵ��ӱ������ֶΡ�
			oHT.Add("@SourceEntryList",	oRow[BillOfReceiveData.SOURCEENTRY_FIELD]);				//Դ���ݺš�
			oHT.Add("@SourceDocCodeList",	oRow[BillOfReceiveData.SOURCEDOCCODE_FIELD]);		//Դ�������͡�
			oHT.Add("@SourceSerialNoList",	oRow[BillOfReceiveData.SOURCESERIALNO_FIELD]);		//Դ�������кš�
			oHT.Add("@BatchCodeList",       oRow[BillOfReceiveData.BATCHCODE_FIELD]);			//���š�
			oHT.Add("@PlanNumList",		oRow[BillOfReceiveData.PLANNUM_FIELD]);					//Ӧ��������
			oHT.Add("@TaxCodeList",		oRow[BillOfReceiveData.TAXCODE_FIELD]);					//˰�롣
			oHT.Add("@TaxRateList",		oRow[BillOfReceiveData.TAXRATE_FIELD]);					//˰�ʡ�
			oHT.Add("@ItemTaxList",		oRow[BillOfReceiveData.ITEMTAX_FIELD]);					//˰�
			oHT.Add("@ItemFeeList",		oRow[BillOfReceiveData.ITEMFEE_FIELD]);					//���á�
			oHT.Add("@DiscountRateList",	oRow[BillOfReceiveData.DISCOUNTRATE_FIELD]);		//�ۿ��ʡ�
			oHT.Add("@ItemDiscountList",	oRow[BillOfReceiveData.ITEMDISCOUNT_FIELD]);		//�ۿ۶
			oHT.Add("@ItemSumList",			oRow[BillOfReceiveData.ITEMSUM_FIELD]);				//�����ܽ�
			oHT.Add("@ItemNoInvoiceNumList",oRow[BillOfReceiveData.ITEMNOINVOICENUM_FIELD]);	//��Ʊδ��������
			oHT.Add("@ConCodeList",			oRow[BillOfReceiveData.CONCODE_FIELD]);					//��λ��š�
			oHT.Add("@ConNameList",			oRow[BillOfReceiveData.CONNAME_FIELD]);					//��λ���ơ�
			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա
		/// <summary>
		/// �������ϵ���
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret=true;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = this.oSQLServer.ExecSP("Pur_BillOfReceiveInsert", oHT);
//			if(ret == false)
//			{
//				//this.Message = BillOfReceiveData.ADD_FAILED;
//				this.Message = oSQLServer.ExceptionMessage;
//			}
//			else
//			{
//				this.Message = BillOfReceiveData.ADD_SUCCESSED;
//			}
			return ret;
		}
		/// <summary>
		/// ���Ӳ����ύ���ϵ���
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret=true;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveInsertAndPresent", oHT);
			return ret;
		}
		/// <summary>
		/// ���ϵ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret=true;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveUpdate", oHT);
			return ret;
		}
		/// <summary>
		/// ���ϵ��޸Ĳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret=true;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveUpdateAndPresent", oHT);
			return ret;
		}
		/// <summary>
		/// ���ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveDelete", oHT);
			return ret;
		}
		/// <summary>
		/// �������ϵ�״̬��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ��š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@newState",newState);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveUpdateEntryState", oHT);
			return ret;
		}
		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object: �ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveFirstAudit", oHT);
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object: �ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];
			//ѹ������
			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveSecondAudit", oHT);
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object: �ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_BillOfReceiveThirdAudit", oHT);
			
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_BillOfReceivePresent", oHT);
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			ret = oSQLServer.ExecSP("Pur_BillOfReceiveCancel", oHT);
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginID">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginID", UserLoginID);
			ret = oSQLServer.ExecSP("Pur_BillOfReceiveCancel", oHT);
			
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginID">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Pay(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginID", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_BillOfReceivePay", oHT);
			return ret;
		}
		/// <summary>
		/// �������ϵ���ˮ�Ż�����ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{

			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByEntryNo", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);

			return oEntry;
		}

        /// <summary>
        /// �������ϵ���ˮ�Ż�����ϵ���
        /// </summary>
        /// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
        /// <returns>object:	���ϵ�ʵ�塣</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {

            BillOfReceiveData oEntry = new BillOfReceiveData();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);
            oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetOldByEntryNo", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);

            return oEntry;
        }

		/// <summary>
		/// �������ϵ���Ż�ȡ���ϵ���������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	���ϵ���š�</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryCode);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByEntryCode", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);

			return oEntry;
		}

        public bool BRInvoiceNoUpdate(int EntryNo, string strInvoiceNo)
        {
            bool ret = true;
            Hashtable oHT = new Hashtable();

            oHT.Add("@EntryNo", EntryNo);
            oHT.Add("@InvoiceNo", strInvoiceNo);

            ret = oSQLServer.ExecSP("Pur_BillOfReceiveGetByEntryNoUpdate", oHT);
            return ret;
        }


		/// <summary>
		/// �������ϵ��������Ż�ȡ���ϵ��Ļ�����Ϣ��
		/// </summary>
		/// <param name="DeptCode">string:	�������Ϣ��</param>
		/// <returns>object:	���ϵ�����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept", DeptCode);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByDept", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		/// <summary>
		/// ��ȡ�������ϵ���
		/// </summary>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryAll()
		{
			return null;
		}
		/// <summary>
		/// ��ȡ�ض��û����������ϵ���
		/// </summary>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			BillOfReceiveData oEntry = new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetAll",oHT,oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}

        /// <summary>
        /// ��ȡ�ض��û����������ϵ���
        /// </summary>
        /// <returns>object:	���ϵ�ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            BillOfReceiveData oEntry = new BillOfReceiveData();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);
            oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByPerson", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
            return oEntry;
        }
		/// <summary>
		/// ���ݷ�Ʊ�ź����ϱ�Ż�ȡ�ɹ����ϵ���Ϣ.
		/// </summary>
		/// <param name="InvoiceNo">string:	��Ʊ��.</param>
		/// <param name="ItemCode">string:	���ϱ��.</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryByInvoiceNoAndItemCode(string InvoiceNo, string ItemCode)
		{
			BillOfReceiveData oEntry = new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@InvoiceNo",InvoiceNo);
			oHT.Add("@ItemCode", ItemCode);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByInvoiceNoAndItemCode",oHT,oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		#endregion

		#region ���ϵ�ר�з��� 
		/// <summary>
		/// ���ݹ�Ӧ�̴���������Դ��
		/// </summary>
		/// <param name="PrvCode">string:	��Ӧ�̴��롣</param>
		/// <returns>object:	����Դʵ�塣</returns>
		public object GetEntryByPrvCode(string PrvCode)
		{
			PBSData oEntry = new PBSData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PrvCode", PrvCode);
			oSQLServer.ExecSPReturnDS("Pur_PBSGetByPrvCode", oHT, oEntry.Tables[PBSData.VPBS_VIEW]);
			return oEntry;
		}
		/// <summary>
		/// ����ģʽ�»�ȡ�ɹ����ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <remarks >��ʼ�����������ʹ�ż�λ��</remarks>
		/// <returns>object:	�ɹ����ϵ�ʵ�塣</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByEntryNoInMode", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		/// <summary>
		/// ����״̬��ȡ���ݡ�
		/// </summary>
		/// <param name="EntryState">string:	����״̬��</param>
		/// <returns>object:	���ϵ����ݼ���</returns>
		public object GetEntryByState(string EntryState)
		{
			BillOfReceiveData oBORData = new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryState", EntryState);
			oSQLServer.ExecSPReturnDS("Pur_BORGetByState", oHT, oBORData.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oBORData;
		}
		/// <summary>
		/// ����ָ���������ݺŻ�ȡ���ֵ��ݳ�ʼ��Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryRedByEntryNo(int EntryNo)
		{
			BillOfReceiveData oBORData = new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveRed",oHT,oBORData.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oBORData;
		}
		/// <summary>
		/// ����Pkid�б�������Դ��ϸ���ݡ�
		/// </summary>
		/// <param name="List">string:	����Դ��ϸPKID��</param>
		/// <returns>object:	����Դ��ϸ���ݡ�</returns>
		public object GetPBSDByList(string List)
		{
			PBSDData oEntry = new PBSDData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@List", List);
			oSQLServer.ExecSPReturnDS("Pur_PBSDGetByEntry", oHT, oEntry.Tables[PBSDData.PBSD_VIEW]);
			return oEntry;
		}
		/// <summary>
		/// ���ϵ����Ϸ�����
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Receive( object Entry)
		{
			bool ret = false;
			BillOfReceiveData oEntry= (BillOfReceiveData)Entry;
            Hashtable oHT = this.FillHashTable(oEntry);
            ret = oSQLServer.ExecSP("Pur_BillOfReceiveReceive", oHT);
			return ret;
		}
        public bool Reject(int EntryNo, string UserLoginId)
        {
            bool ret = false;
            
            Hashtable oHT = new Hashtable();

            oHT.Add("@EntryNo", EntryNo);
            oHT.Add("@UserLoginId", UserLoginId);
			
            ret = oSQLServer.ExecSP("Pur_BillOfReceiveRefuse", oHT);
            return ret;
        }
        /// <summary>
        /// ��ȡ��;��š�
        /// </summary>
        /// <param name="entryNo">���ϵ��š�</param>
        /// <param name="serialNo">���</param>
        /// <returns>��;��š�</returns>
        public string GetReqReasonCode(int entryNo,  int serialNo)
        {
            var sqlStatement = "Select dbo.GetRequisitionInfo(@EntryNo,@DocCode,@SerialNo,@RequestObject)";
            var parms = new[]{
                new SqlParameter("@EntryNo",DbType.Int32){Value=entryNo},
                new SqlParameter("@DocCode",DbType.Int16){Value = 6},
                new SqlParameter("@SerialNo",DbType.Int32){Value=serialNo},
                new SqlParameter("@RequestObject",SqlDbType.NVarChar,20){Value="ReqReasonCode"},
            };

            var obj = SqlHelper.ExecuteScalar(this.ConnString,CommandType.Text,sqlStatement,parms);
            return obj == null ? string.Empty : obj.ToString();
        }
		#endregion

		#region ͨ�ò�ѯ
		/// <summary>
		/// ����ָ��SQL�����в�ѯ��
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL ��䡣</param>
		/// <returns>BillOfReceiveData:	���ϵ�ʵ�塣</returns>
		public BillOfReceiveData GetEntryBySQL(string Sql_Statement)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		/// <summary>
		/// �����Ƶ����š��Ƶ��ˡ�������������زɹ����ϵ��嵥��
		/// </summary>
		/// <param name="AuthorDept">string:	�Ƶ����š�</param>
		/// <param name="AuthorCode">string:	�Ƶ��ˡ�</param>
		/// <param name="AuditResult">int:	���������</param>
		/// <returns>BillOfReceiveData:	���ϵ�ʵ�塣</returns>
		public BillOfReceiveData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult, DateTime StartDate, DateTime EndDate)
		{
			BillOfReceiveData oEntry= new BillOfReceiveData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Pur_BillOfReceiveGetByDeptAndAuthorAndAuditResult", oHT, oEntry.Tables[BillOfReceiveData.PBOR_TABLE]);
			return oEntry;
		}
		#endregion
	}
}
