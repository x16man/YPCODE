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
	/// PurchaseOrders ��ժҪ˵����
	/// </summary>
	public class PurchaseOrders : Messages,IInItems
    {
        #region Property
        /// <summary>
        /// ���ݿ������ַ�����
        /// </summary>
        public string ConnString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
        #endregion

        #region ���캯��
        public PurchaseOrders()
		{
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// ����ϣ��
		/// </summary>
		/// <param name="oEntry">RequestOfStockData:	�ɹ����뵥ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(PurchaseOrderData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];
			//����ģʽ�����ֶΡ�
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
			oHT.Add("@SubTotal",		oRow[InItemData.SUBTOTAL_FIELD]);					//�����ܽ�
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//��ע��
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//������ϸ����˳��š�
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//���ϱ�š�
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//�������ơ�
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//���Ϲ��
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//���ϵ��ۡ�
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//����������
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			//�ɹ������������ֶΡ�
			oHT.Add("@SourceEntryList",		oRow[PurchaseOrderData.SOURCEENTRY_FIELD]);			//Դ���ݱ�š�
			oHT.Add("@SourceDocCodeList",	oRow[PurchaseOrderData.SOURCEDOCCODE_FIELD]);		//Դ�������ͱ�š�
			oHT.Add("@SourceSerialNoList",  oRow[PurchaseOrderData.SOURCESERIALNO_FIELD]);   //Դ����˳��š�
			oHT.Add("@DeliveryDate",	oRow[PurchaseOrderData.DELIVERYDATE_FIELD]);		//�������ڡ�
			oHT.Add("@PrvCode",			oRow[PurchaseOrderData.PRVCODE_FIELD]);				//��Ӧ�̱�š�
			oHT.Add("@PrvName",			oRow[PurchaseOrderData.PRVNAME_FIELD]);				//��Ӧ�����ơ�
			oHT.Add("@PrvAdd",			oRow[PurchaseOrderData.PRVADD_FIELD]);				//��Ӧ�̵�ַ��
			oHT.Add("@PrvZip",			oRow[PurchaseOrderData.PRVZIP_FIELD]);				//��Ӧ���ʱࡣ
			oHT.Add("@PrvTel",			oRow[PurchaseOrderData.PRVTEL_FIELD]);				//��ϵ�绰��
			oHT.Add("@PrvFax",			oRow[PurchaseOrderData.PRVFAX_FIELD]);				//���档
			oHT.Add("@PrvLicence",		oRow[PurchaseOrderData.PRVLICENCE_FIELD]);			//Ӫҵִ�պš�
			oHT.Add("@PrvBank",			oRow[PurchaseOrderData.PRVBANK_FIELD]);				//�������С�
			oHT.Add("@PrvAccount",		oRow[PurchaseOrderData.PRVACCOUNT_FIELD]);			//�������С�
			oHT.Add("@PrvTaxNo",		oRow[PurchaseOrderData.PRVTAXNO_FIELD]);			//˰��ǼǺš�
			oHT.Add("@CurrencyCode",	oRow[PurchaseOrderData.CURRENCYCODE_FIELD]);		//���֡�
			oHT.Add("@PayStyle",		oRow[PurchaseOrderData.PAYSTYLE_FIELD]);			//���ʽ��
			oHT.Add("@Payment",			oRow[PurchaseOrderData.PAYMENT_FIELD]);				//�������
			oHT.Add("@TransType",		oRow[PurchaseOrderData.TRANSTYPE_FIELD]);			//���䷽ʽ��
			oHT.Add("@SendTo",			oRow[PurchaseOrderData.SENDTO_FIELD]);				//�͵���
			oHT.Add("@InvoiceTo",		oRow[PurchaseOrderData.INVOICETO_FIELD]);			//��Ʊ����
			oHT.Add("@PscCode",			oRow[PurchaseOrderData.PSCCODE_FIELD]);				//������š�
			oHT.Add("@PscName",			oRow[PurchaseOrderData.PSCNAME_FIELD]);				//�������ơ�
			oHT.Add("@TotalMoney",		oRow[PurchaseOrderData.TOTALMONEY_FIELD]);			//�ܽ�
			oHT.Add("@TotalTax",		oRow[PurchaseOrderData.TOTALTAX_FIELD]);			//��˰�
			oHT.Add("@TotalDiscount",	oRow[PurchaseOrderData.TOTALDISCOUNT_FIELD]);		//���ۿ۶
			oHT.Add("@TotalFee",		oRow[PurchaseOrderData.TOTALFEE_FIELD]);			//�ܷ��ö
			oHT.Add("@BuyerCode",		oRow[PurchaseOrderData.BUYERCODE_FIELD]);			//�ɹ�Ա��š�
			oHT.Add("@BuyerName",		oRow[PurchaseOrderData.BUYERNAME_FIELD]);			//�ɹ�Ա���ơ�
			oHT.Add("@TaxCodeList",			oRow[PurchaseOrderData.TAXCODE_FIELD]);				//˰�롣
			oHT.Add("@TaxRateList",			oRow[PurchaseOrderData.TAXRATE_FIELD]);				//˰�ʡ�
			oHT.Add("@ItemTaxList",			oRow[PurchaseOrderData.ITEMTAX_FIELD]);				//����˰�
			oHT.Add("@DiscountRateList",	oRow[PurchaseOrderData.DISCOUNTRATE_FIELD]);		//�����ۿ��ʡ�
			oHT.Add("@ItemDiscountList",	oRow[PurchaseOrderData.ITEMDISCOUNT_FIELD]);		//�����ۿ�.
			oHT.Add("@ItemFeeList",			oRow[PurchaseOrderData.ITEMFEE_FIELD]);				//���Ϸ��á�
			oHT.Add("@ItemSumList",			oRow[PurchaseOrderData.ITEMSUM_FIELD]);				//�����ܽ�
			oHT.Add("@ItemLackNum",		oRow[PurchaseOrderData.ITEMLACKNUM_FIELD]);			//����Ƿ��������
			oHT.Add("@ItemInvNum",		oRow[PurchaseOrderData.ITEMINVNUM_FIELD]);			//���Ͽ�Ʊ������
            oHT.Add("@ParentEntryNo", oRow[PurchaseOrderData.ParentEntryNo_Field]);
		
			return oHT;
		}
		#endregion 

		#region IInItems ��Ա
		/// <summary>
		/// �������ӡ�
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			PurchaseOrderData oEntry = (PurchaseOrderData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_OrderInsert",oHT);
			
			if(ret == false)
			{
				//this.Message = PurchaseOrderData.ADD_FAILED;
                this.SetError(oSQLServer.ExceptionMessage, PurchaseOrderData.ADD_FAILED);
			}
			else
			{
				this.Message = PurchaseOrderData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������Ӳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			PurchaseOrderData oEntry = (PurchaseOrderData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_OrderInsertAndPresent",oHT);
			
			if(ret == false)
			{
				//this.Message = PurchaseOrderData.ADD_FAILED;
                this.SetError(oSQLServer.ExceptionMessage, PurchaseOrderData.ADD_FAILED);
				
			}
			else
			{
				this.Message = PurchaseOrderData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ������޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret=true;
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_OrderUpdate", oHT);
			if(ret == false)
			{
				//this.Message = PurchaseOrderData.UPDATE_FAILED;
                this.SetError(oSQLServer.ExceptionMessage, PurchaseOrderData.UPDATE_FAILED);
				
			}
			else
			{
				this.Message = PurchaseOrderData.UPDATE_SUCCESSED;
			}
			return ret;
		}

        /// <summary>
        /// ���ݱ������Ϣ���ݣ�ȥ��\r\n �п��ܵõ�2,3,1)
        /// </summary>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        private void SetError(string strMessage, string strDefaultError)
        {
            string strTemp = strMessage.Replace("\r\n", "");
            if (strTemp == "-2")
            {
                this.Message = PurchaseOrderData.NumberInsufficient;
            }
            else if (strTemp == "-3")
            {
                this.Message = PurchaseOrderData.NumberCompareZero;
            }
            else
            {
                try
                {
                    int i = Int32.Parse(strTemp);
                    if (i > 0)
                    {
                        this.Message = string.Format(PurchaseOrderData.NumberGreatZero, strTemp);
                    }
                }
                catch
                {
                    this.Message = strDefaultError;
                }

            }
        }


		/// <summary>
		/// �ɹ������޸Ĳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret=true;
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_OrderUpdateAndPresent", oHT);
			if(ret == false)
			{
				//this.Message = PurchaseOrderData.UPDATE_FAILED;
                this.SetError(oSQLServer.ExceptionMessage, PurchaseOrderData.UPDATE_FAILED);
				
			}
			else
			{
				this.Message = PurchaseOrderData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ�����ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_OrderDelete", oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.DELETE_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ���Ĳɹ�����״̬��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="EntryState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Pur_OrderUpdateState", oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ�����һ��������
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_OrderFirstAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ���������������
		/// </summary>
		/// <param name="Entry">object:	�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_OrderSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ���������������
		/// </summary>
		/// <param name="Entry">object:�ɹ�����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchaseOrderData oEntry= (PurchaseOrderData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_OrderThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ�����ָ�ɡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);
			oHT.Add("@UserLoginId",     UserLoginId);

			ret = oSQLServer.ExecSP("Pur_OrderPresent",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.PRESENT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);

						
			ret = oSQLServer.ExecSP("Pur_OrderCancel",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);
			oHT.Add("@UserLoginID", UserLoginID);

						
			ret = oSQLServer.ExecSP("Pur_OrderCancel",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <returns>object:	�ɹ�����ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByEntryNo",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

        /// <summary>
        /// ���ݵ�����ˮ�Ż�ȡ�ɹ�������
        /// </summary>
        /// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
        /// <returns>object:	�ɹ�����ʵ�塣</returns>
        public object GetPORepealEntryNo(int EntryNo)
        {
            PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Pur_OrderGetRepealEntryNo", oHT, oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
            return oPurchaseOrderData;
        } 

		/// <summary>
		/// ��ȡҺ��ȷ��ִ�вɹ�����δ��ɵĶ����嵥��
		/// </summary>
		/// <returns>object:	�ɹ�����ʵ�塣</returns>
		public object GetYLExecOrder()
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByExec",oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}
		/// <summary>
		/// ���ݵ�����ˮ�ź����ϱ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <returns>object:	�ɹ�����ʵ�塣</returns>
		public object GetEntryByEntryNoAndItemCode(int EntryNo, string ItemCode)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@ItemCode", ItemCode);
			oSQLServer.ExecSPReturnDS("Pur_OrderGetByEntryNoAndItemCode",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		/// <summary>
		/// ���ݵ��ݱ�ź����ϱ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������š�</param>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <returns>object:	�ɹ�����ʵ�塣</returns>
		public object GetEntryByEntryCodeAndItemCode(string EntryCode, string ItemCode)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode", EntryCode);
			oHT.Add("@ItemCode", ItemCode);
			oSQLServer.ExecSPReturnDS("Pur_OrderGetByEntryCodeAndItemCode",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		/// <summary>
		/// ���ݵ��ݱ�źŻ�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������š�</param>
		/// <returns>object:	�ɹ�����ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByEntryCode",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		/// <summary>
		/// ��ȡ���е��ݡ�
		/// </summary>
		/// <returns>object:	�ɹ�����ʵ�塣</returns>
		public object GetEntryAll()
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_OrderGetAll",oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		/// <summary>
		/// ��ȡָ���û������е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>object:	�ɹ�����ʵ�塣</returns>
        public object GetEntryAll(string UserLoginId)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetAll",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

        /// <summary>
        /// ��ȡָ���û������е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>object:	�ɹ�����ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Pur_OrderGetByPerson", oHT, oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
            return oPurchaseOrderData;
        }
		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	�ɹ�����ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByDeptCode",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}

		#endregion

		#region �ɹ�����ר�з���
		/// <summary>
		/// ��ȡ�ɹ���������������Դ��
		/// </summary>
		/// <returns>POSData:	�ɹ���������Դ����ʵ�塣</returns>
		public POSData GetPOSAll(string UserLoginId)
		{
			POSData oPOSData = new POSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId", UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_POSGetAll",oHT,oPOSData.Tables[POSData.VPOS_VIEW]);
			return oPOSData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo",		EntryNo);
			oHT.Add("@EntryState",	newState);
			oHT.Add("@UserLoginId", UserLoginId);
			ret = oSQLServer.ExecSP("Pur_OrderAffirm",oHT);
			if(ret == false)
			{
				this.Message = PurchaseOrderData.AFFIRM_FAILED;
			}
			else
			{
				this.Message = PurchaseOrderData.ADD_SUCCESSED;
			}
			return ret;

		}

		public POSData GetPOSByPKIDs(string PKIDs)
		{
			POSData oPOSData = new POSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);
			oSQLServer.ExecSPReturnDS("Pur_POSGetByPKIDS",oHT,oPOSData.Tables[POSData.VPOS_VIEW]);
			return oPOSData;
		}
        /// <summary>
        /// ��ȡ��;��š�
        /// </summary>
        /// <param name="entryNo">�ɹ�������</param>
        /// <param name="serialNo">���</param>
        /// <returns>��;��š�</returns>
        public string GetReqReasonCode(int entryNo, int serialNo)
        {
            var sqlStatement = "Select dbo.GetRequisitionInfo(@EntryNo,@DocCode,@SerialNo,@RequestObject)";
            var parms = new[]{
                new SqlParameter("@EntryNo",DbType.Int32){Value=entryNo},
                new SqlParameter("@DocCode",DbType.Int16){Value = 3},
                new SqlParameter("@SerialNo",DbType.Int32){Value=serialNo},
                new SqlParameter("@RequestObject",SqlDbType.NVarChar,20){Value="ReqReasonCode"},
            };

            var obj = SqlHelper.ExecuteScalar(this.ConnString, CommandType.Text, sqlStatement, parms);
            return obj == null ? string.Empty : obj.ToString();
        }
		#endregion 

		#region ͨ�ò�ѯ
		public PurchaseOrderData GetEntryBySQL(string Sql_Statement)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}
		public PurchaseOrderData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			PurchaseOrderData oPurchaseOrderData = new PurchaseOrderData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);

			oSQLServer.ExecSPReturnDS("Pur_OrderGetByDeptAndAuthorAndAuditResult",oHT,oPurchaseOrderData.Tables[PurchaseOrderData.PORD_TABLE]);
			return oPurchaseOrderData;
		}
		#endregion
	}
}
