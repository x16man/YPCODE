using System;
using System.Collections;
using System.Data;
using MZHCommon.Database;
using Shmzh.MM.Common;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// �ɹ����ϵ������ݷ��ʲ㡣
	/// </summary>
	public class PRTVs :Messages, IInItems
	{
		#region ���캯��
		public PRTVs()
		{}
		#endregion ���캯��

		#region ˽�з���
		/// <summary>
		/// ����ϣ��
		/// </summary>
		/// <param name="oEntry">PRTVData:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(PRTVData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PRTVData.PRTV_TABLE].Rows[0];
			//����ģʽ�����ֶΡ�
			//�������ֶΡ�
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//������ˮ�š�
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//���ݱ�š�
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//�������͡�
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//�����������ơ�
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//���������ĵ���š�
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//����״̬��
		//	oHT.Add("@EntryDate",		oRow[InItemData.ENTRYDATE_FIELD]);					//�Ƶ����ڡ�
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//�Ƶ��˱�š�
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//�Ƶ������ơ�
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//�Ƶ��˵�¼����
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//�Ƶ��˲��š�
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//�Ƶ��˲������ơ�
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);			        //�����ܼơ�
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);				        //��ע��
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
			//�ɹ����ϵ����������ֶΡ�
			oHT.Add("@PrvCode",			oRow[PRTVData.PRVCODE_FIELD]);				//��Ӧ�̱�š�
			oHT.Add("@PrvName",			oRow[PRTVData.PRVNAME_FIELD]);				//��Ӧ�����ơ�
			oHT.Add("@PrvBank",			oRow[PRTVData.PRVBANK_FIELD]);				//��Ӧ�̿������С�
			oHT.Add("@PrvAccount",		oRow[PRTVData.PRVACCOUNT_FIELD]);			//��Ӧ���˺š�
			oHT.Add("@PrvRegNo",		oRow[PRTVData.PRVREGNO_FIELD]);			//��Ӧ��˰��ǼǺš�
			oHT.Add("@PrvTel",			oRow[PRTVData.PRVTEL_FIELD]);				//��Ӧ�̵绰��
			oHT.Add("@PrvFax",			oRow[PRTVData.PRVFAX_FIELD]);				//��Ӧ�̴��档
			oHT.Add("@PayStyle",		oRow[PRTVData.PAYSTYLE_FIELD]);			//���ʽ��
			oHT.Add("@InvoiceNo",		oRow[PRTVData.INVOICENO_FIELD]);			//��Ʊ���롣
			oHT.Add("@ChkNo",			oRow[PRTVData.CHKNO_FIELD]);				//���յ��š�
			oHT.Add("@ChkResult",		oRow[PRTVData.CHKRESULT_FIELD]);			//���������
			oHT.Add("@CurrencyCode",	oRow[PRTVData.CURRENCYCODE_FIELD]);		//���Ҵ��롣
			oHT.Add("@UsedFor",			oRow[PRTVData.USEDFOR_FIELD]);				//���ڡ�
			oHT.Add("@BuyerCode",		oRow[PRTVData.BUYERCODE_FIELD]);			//�ɹ�Ա��š�
			oHT.Add("@BuyerName",		oRow[PRTVData.BUYERNAME_FIELD]);			//�ɹ�Ա���ơ�
			oHT.Add("@StoCode",			oRow[PRTVData.STOCODE_FIELD]);				//�ֿ��š�
			oHT.Add("@StoName",			oRow[PRTVData.STONAME_FIELD]);				//�ֿ����ơ�
			oHT.Add("@AcceptCode",		oRow[PRTVData.ACCEPTCODE_FIELD]);			//�����˱�š�
			oHT.Add("@AcceptName",		oRow[PRTVData.ACCEPTNAME_FIELD]);			//���������ơ�
			oHT.Add("@AcceptDate",		oRow[PRTVData.ACCEPTDATE_FIELD]);			//�������ڡ�
			oHT.Add("@PcsCode",			oRow[PRTVData.PCSCODE_FIELD]);				//������š�
			oHT.Add("@PcsName",			oRow[PRTVData.PCSNAME_FIELD]);				//�������ơ�
			oHT.Add("@TotalMoney",		oRow[PRTVData.TOTALMONEY_FIELD]);			//�ܼۡ�
			oHT.Add("@TotalTax",		oRow[PRTVData.TOTALTAX_FIELD]);			//��˰�
			oHT.Add("@TotalFee",		oRow[PRTVData.TOTALFEE_FIELD]);			//�ܷ��á�
			oHT.Add("@TotalDiscount",	oRow[PRTVData.TOTALDISCOUNT_FIELD]);		//���ۿۡ�
			oHT.Add("@JFKM",			oRow[BillOfReceiveData.JFKM_FIELD]);				//��ƿ�Ŀ��
		
			
			//�ɹ����ϵ��ӱ������ֶΡ�
			oHT.Add("@SourceEntryList",	oRow[PRTVData.SOURCEENTRY_FIELD]);			//Դ���ݺš�
			oHT.Add("@SourceDocCodeList",	oRow[PRTVData.SOURCEDOCCODE_FIELD]);		//Դ�������͡�
			oHT.Add("@SourceSerialNoList",	oRow[PRTVData.SOURCESERIALNO_FIELD]);		//Դ�������кš�
			oHT.Add("@BatchCodeList", oRow[PRTVData.BATCHCODE_FIELD]);               //���š�
			oHT.Add("@PlanNumList",		oRow[PRTVData.PLANNUM_FIELD]);				//Ӧ��������
			oHT.Add("@TaxCodeList",		oRow[PRTVData.TAXCODE_FIELD]);				//˰�롣
			oHT.Add("@TaxRateList",		oRow[PRTVData.TAXRATE_FIELD]);				//˰�ʡ�
			oHT.Add("@ItemTaxList",		oRow[PRTVData.ITEMTAX_FIELD]);				//˰�
			oHT.Add("@ItemFeeList",		oRow[PRTVData.ITEMFEE_FIELD]);				//���á�
			oHT.Add("@DiscountRateList",	oRow[PRTVData.DISCOUNTRATE_FIELD]);		//�ۿ��ʡ�
			oHT.Add("@ItemDiscountList",	oRow[PRTVData.ITEMDISCOUNT_FIELD]);		//�ۿ۶
			oHT.Add("@ItemSumList",			oRow[PRTVData.ITEMSUM_FIELD]);				//�����ܽ�
			oHT.Add("@ItemNoInvoiceNumList",oRow[PRTVData.ITEMNOINVOICENUM_FIELD]);	//��Ʊδ��������
			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա
		/// <summary>
		/// ���Ӳɹ����ϵ���
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret=true;
			PRTVData oEntry= (PRTVData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			ret = oSQLServer.ExecSP("Pur_PRTVInsert", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.ADD_FAILED;
			}
			else
			{
				this.Message = PRTVData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �½����������ύ�ɹ����ϵ���
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			PRTVData oEntry = (PRTVData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			ret = oSQLServer.ExecSP("Pur_PRTVInsertAndPresent", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.ADD_FAILED;
			}
			else
			{
				this.Message = PRTVData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret=true;
			PRTVData oEntry= (PRTVData)Entry;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			ret = oSQLServer.ExecSP("Pur_PRTVUpdate", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PRTVData.UPDATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ��޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret=true;
			PRTVData oEntry= (PRTVData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			ret = oSQLServer.ExecSP("Pur_PRTVUpdateAndPresent", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PRTVData.UPDATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			ret = oSQLServer.ExecSP("Pur_PRTVDelete", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.DELETE_FAILED;
			}
			else
			{
				this.Message = PRTVData.DELETE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���Ĳɹ����ϵ�״̬��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ��š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@newState",newState);
			ret = oSQLServer.ExecSP("Pur_PRTVUpdateEntryState", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PRTVData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��˻���ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			PRTVData oEntry= (PRTVData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PRTVData.PRTV_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PRTVFirstAudit", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = PRTVData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��˻���ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			PRTVData oEntry= (PRTVData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PRTVData.PRTV_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PRTVSecondAudit", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = PRTVData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��˻���ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			PRTVData oEntry= (PRTVData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PRTVData.PRTV_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PRTVThirdAudit", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PRTVData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ����ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ɹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginID",UserLoginId);

			ret = oSQLServer.ExecSP("Pur_PRTVPresent", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PRTVData.PRESENT_SUCCESSED;
			}
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
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			ret = oSQLServer.ExecSP("Pur_PRTVCancel", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PRTVData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",newState);
			oHT.Add("@UserLoginID", UserLoginId);
			ret = oSQLServer.ExecSP("Pur_PRTVCancel", oHT);
			if(ret == false)
			{
				this.Message = PRTVData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PRTVData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ݲɹ����ϵ���ˮ�Ż�òɹ����ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <returns>object:	�ɹ����ϵ�ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{

			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByEntryNo", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);

			return oEntry;
		}
		/// <summary>
		/// �ڷ���ģʽ�¸��ݲɹ����ϵ���ˮ�Ż�òɹ����ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����ϵ���ˮ�š�</param>
		/// <returns>object:	�ɹ����ϵ�ʵ�塣</returns>
		public object GetEntryByEntryNoInMode(int EntryNo)
		{

			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByEntryNoInMode", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);

			return oEntry;
		}
		/// <summary>
		/// ���ݲɹ����ϵ���Ż�ȡ�ɹ����ϵ���������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	�ɹ����ϵ���š�</param>
		/// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{

			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode", EntryCode);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByEntryCode", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);

			return oEntry;
		}
		/// <summary>
		/// ���ݲɹ����ϵ��������Ż�ȡ�ɹ����ϵ��Ļ�����Ϣ��
		/// </summary>
		/// <param name="DeptCode">string:	�������Ϣ��</param>
		/// <returns>object:	�ɹ����ϵ�����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept", DeptCode);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByDeptCode", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);
			return oEntry;
		}
		/// <summary>
		/// ��ȡ���вɹ����ϵ���
		/// </summary>
		/// <returns>object:	�ɹ����ϵ�ʵ�塣</returns>
		public object GetEntryAll()
		{
			PRTVData oEntry = new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetAll",oEntry.Tables[PRTVData.PRTV_TABLE]);
			return oEntry;
		}

        /// <summary>
        /// ��ȡ���вɹ����ϵ���
        /// </summary>
        /// <returns>object:	�ɹ����ϵ�ʵ�塣</returns>
        public object GetEntryByPerson(string strEmpCode)
        {
            PRTVData oEntry = new PRTVData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", strEmpCode);
            oSQLServer.ExecSPReturnDS("Pur_PRTVGetByPerson", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);
            return oEntry;
        }

       
		#endregion

		#region �ɹ����ϵ�ר�з��� 
//		/// <summary>
//		/// ���ݹ�Ӧ�̴���������Դ��
//		/// </summary>
//		/// <param name="PrvCode"></param>
//		/// <returns></returns>
//		public object GetEntryByPrvCode(string PrvCode)
//		{
//			PBSData oEntry = new PBSData();
//			SQLServer oSQLServer = new SQLServer();
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@PrvCode", PrvCode);
//			oSQLServer.ExecSPReturnDS("Pur_PBSGetByPrvCode", oHT, oEntry.Tables[PBSData.VPBS_VIEW]);
//			return oEntry;
//		}
//
//		/// <summary>
//		/// ����Pkid�������Դ��ϸ���ݡ�
//		/// </summary>
//		/// <param name="List"></param>
//		/// <returns></returns>
//		public object GetPBSDByList(string List)
//		{
//			PBSDData oEntry = new PBSDData();
//			SQLServer oSQLServer = new SQLServer();
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@List", List);
//			oSQLServer.ExecSPReturnDS("Pur_PBSDGetByEntry", oHT, oEntry.Tables[PBSDData.PBSD_VIEW]);
//			return oEntry;
//		}

//		public object GetCBRSByPKID(string PKID)
//		{
//			CBRSData oEntry = new CBRSData();
//			SQLServer oSQLServer = new SQLServer();
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@PKID",PKID);
//			oSQLServer.ExecSPReturnDS("Pur_CBRSGetByPKID",oHT,oEntry.Tables[CBRSData.CBRS_VIEW]);
//			return oEntry;
//		}
		/// <summary>
		/// ����PKID��ȡ�ɹ����ϵ�������Դ����ϸ��Ϣ��
		/// </summary>
		/// <param name="PKID">string:	PKID.</param>
		/// <returns>object:	�ɹ����ϵ�������Դ����ϸ��Ϣʵ�塣</returns>
		public object GetRTVSByPKID(string PKID)
		{
			RTVSData oEntry = new RTVSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID",PKID);
			oSQLServer.ExecSPReturnDS("Pur_RTVSGetByPKID",oHT,oEntry.Tables[RTVSData.RTVS_VIEW]);
			return oEntry;
		}

//		public object GetCBRSDetailByPKID(string PKID)
//		{
//			CBRSDetailData oEntry = new CBRSDetailData();
//			SQLServer oSQLServer = new SQLServer();
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@PKID",PKID);
//			oSQLServer.ExecSPReturnDS("Pur_CBRSDetailGetByPKID",oHT,oEntry.Tables[CBRSDetailData.CBRSD_VIEW]);
//			return oEntry;
//		}
		/// <summary>
		/// ����ָ����PKID��ȡ������Դ����ϸ��
		/// </summary>
		/// <param name="PKID">string:	PKID.</param>
		/// <returns>object:	������Դ����ϸʵ�塣</returns>
		public object GetRTVSDetailByPKID(string PKID)
		{
			RTVSDetailData oEntry = new RTVSDetailData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID",PKID);
			oSQLServer.ExecSPReturnDS("Pur_RTVSDetailGetByPKID",oHT,oEntry.Tables[RTVSDetailData.RTVSD_VIEW]);
			return oEntry;
		}
		/// <summary>
		/// �������ϵ�����
		/// </summary>
		/// <param name="EntryNo">���ϵ�������ˮ��</param>
		/// <param name="SerialNoList">������ϸ����˳����б���","�ָ�</param>
		/// <param name="ItemNumList">���ϵ����Ϸ������б���","�ָ�</param>
		/// <param name="PKIDList">�ֿ����ϵ�PKID�б���","�ָ�</param>
		/// <param name="ItemDrawNumList">����Ӳֿ�ѡ���õ��ķ������б���","�ָ�</param>
		/// <param name="UserCode">�û�</param>
		/// <param name="UserName">�û���</param>
		/// <param name="UserLoginId">��½ID</param>
		/// <returns></returns>
		public bool RTVReceive( int EntryNo,string SerialNoList,string ItemNumList,string PKIDList,string ItemDrawNumList,string UserCode, string UserName, string UserLoginId,string ItemPriceList)
		{
			bool ret = false;
			
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);			
			oHT.Add("@SerialNoList",SerialNoList);
			oHT.Add("@ItemNumList",ItemNumList);
			oHT.Add("@PKIDList",PKIDList);
			oHT.Add("@ItemDrawNumList",ItemDrawNumList);
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@UserName",UserName);			
			oHT.Add("@UserLoginId",UserLoginId);
			oHT.Add("@ItemPriceList",ItemPriceList);

			ret = oSQLServer.ExecSP("Pur_RTVReceive", oHT); 
			if(ret == false)
			{
				this.Message = PRTVData.DRAW_FAILED;
			}
			return ret;
		}		   
		#endregion

		#region ͨ�ò�ѯ
		public PRTVData GetEntryBySQL(string Sql_Statement)
		{
			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);
			return oEntry;
		}
		public PRTVData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			PRTVData oEntry= new PRTVData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Pur_PRTVGetByDeptAndAuthorAndAuditResult", oHT, oEntry.Tables[PRTVData.PRTV_TABLE]);
			return oEntry;
		}
		#endregion
	}
}
