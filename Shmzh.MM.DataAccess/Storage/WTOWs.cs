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
	using System.Data;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;

	#region public class WTOWs
	/// <summary>
	/// WTOWs ��ժҪ˵����
	/// </summary>
	public class WTOWs : Messages,IInItems
	{
		#region ���캯��
		public WTOWs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion ���캯��

		#region ˽�з���
		/// <summary>
		/// ����ϣ��
		/// </summary>
		/// <param name="oEntry">WTOWData:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(WTOWData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[WTOWData.WTOW_TABLE].Rows[0];
			//ί��ӹ����뵥ģʽ�����ֶΡ�
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
			oHT.Add("@ParentEntryNo",	oRow[WTOWData.PARENTENTRYNO_FIELD]);				//���ָ����ݺš�

			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//������ϸ����˳��š�
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//���ϱ�š�
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//�������ơ�
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//���Ϲ��
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//���ϵ��ۡ�
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			//ί��ӹ����뵥�����ֶΡ�
//			oHT.Add("@SourceEntryList",     oRow[WTOWData.SOURCEENTRY_FIELD]);     //Դ������ˮ�š�
//			oHT.Add("@SourceDocCodeList",   oRow[WTOWData.SOURCEDOCCODE_FIELD]);   //Դ�������͡�
//			oHT.Add("@SourceSerialNoList",  oRow[WTOWData.SOURCESERIALNO_FIELD]);	//Դ����˳��š�
			oHT.Add("@StoManagerCode",	oRow[WTOWData.STOMANAGERCODE_FIELD]);
			oHT.Add("@StoManager",		oRow[WTOWData.STOMANAGER_FIELD]);
			oHT.Add("@ReqDept",				oRow[WTOWData.REQDEPT_FIELD]);
			oHT.Add("@ReqDeptName",			oRow[WTOWData.REQDEPTNAME_FIELD]);
			oHT.Add("@ProposerName",		oRow[WTOWData.PROPOSERNAME_FIELD]);
			oHT.Add("@ProposerCode",		oRow[WTOWData.PROPOSERCODE_FIELD]);
			oHT.Add("@ReqReasonCode",		oRow[WTOWData.REQREASONCODE_FIELD]);	//��;���
			oHT.Add("@ReqReason",			oRow[WTOWData.REQREASON_FIELD]);		//��;����
			oHT.Add("@DrawingCount",        oRow[WTOWData.DRAWINGCOUNT_FIELD]);		//ͼֽ��
		    oHT.Add("@ProspectusCount",     oRow[WTOWData.PROSPECTUSCOUNT_FIELD]);	//��ֽ��
			oHT.Add("@ProcessContent",      oRow[WTOWData.PROCESSCONTENT_FIELD]);	//�ӹ����ݡ�
			oHT.Add("@Term",                oRow[WTOWData.TERM_FIELD]);				//���ڡ�
			oHT.Add("@PlanNumList",			oRow[WTOWData.PLANNUM_FIELD]);          //��������
			oHT.Add("@ItemNumList",         oRow[InItemData.ITEMNUM_FIELD]);		//ʵ��������
			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա
		/// <summary>
		/// ί��ӹ����뵥���ӡ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWInsert",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.ADD_FAILED;
			}
			else
			{
				this.Message = WTOWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ί��ӹ����뵥���Ӳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWInsertAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.ADD_FAILED;
			}
			else
			{
				this.Message = WTOWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ί��ӹ����뵥�޸ġ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{

			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWUpdate",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WTOWData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ί��ӹ����뵥�޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWUpdateAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WTOWData.UPDATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ϡ�
		/// </summary>
		/// <param name="Entry"></param>
		/// <returns></returns>
		public bool StockOut(object Entry)
		{
			bool ret = true;
			WTOWData oEntry = (WTOWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WTOWStockOut",oHT);
			if(ret == false)
			{
				this.Message = "����ʧ�ܣ�";
			}
			else
			{
				this.Message = "���ϳɹ���";
			}
			return ret;
		}
		/// <summary>
		/// ����ί��ӹ����뵥״̬��
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="EntryState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Sto_WTOWUpdateState", oHT);
			if(ret == false)
			{
				this.Message = WTOWData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = WTOWData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_WTOWDelete", oHT);
			if(ret == false)
			{
				this.Message = WTOWData.DELETE_FAILED;
			}
			else
			{
				this.Message = WTOWData.DELETE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥һ��������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WTOWData oEntry = (WTOWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTOWData.WTOW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_WTOWFirstAudit",oHT);

			if(ret == false)
			{
				this.Message = WTOWData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = WTOWData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥����������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WTOWData oEntry= (WTOWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTOWData.WTOW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_WTOWSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = WTOWData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥����������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����뵥ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WTOWData oEntry= (WTOWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WTOWData.WTOW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_WTOWThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = WTOWData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥�ύ��
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Sto_WTOWPresent",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.PRESENT_FAILED;
			}
			else
			{
				this.Message = WTOWData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			ret = oSQLServer.ExecSP("Sto_WTOWCancel",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WTOWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����뵥���ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID", UserLoginId);
			
			ret = oSQLServer.ExecSP("Sto_WTOWCancel",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WTOWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByEntryNo",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}


        /// <summary>
        /// ���ݵ�����ˮ�Ż�ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            WTOWData oWTOWData = new WTOWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_WTOWOldGetByEntryNo", oHT, oWTOWData.Tables[WTOWData.WTOW_TABLE]);
            return oWTOWData;
        }

        /// <summary>
        /// ���ݵ�����ˮ�Ż�ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
        public object GetEntryRedByEntryNo(int EntryNo)
        {
            WTOWData oWTOWData = new WTOWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_WTOWRedGetByEntryNo", oHT, oWTOWData.Tables[WTOWData.WTOW_TABLE]);
            return oWTOWData;
        }

		/// <summary>
		/// ����״̬��ȡί��ӹ����뵥��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
		public object GetEntryByState(string EntryState)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryState",EntryState);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByState",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// ���ݵ��ݱ�źŻ�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ݱ�š�</param>
		/// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByEntryCode",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// ��ȡ���е��ݡ�
		/// </summary>
		/// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
		public object GetEntryAll()
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetAll",oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// �����û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetAll",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}

        /// <summary>
        /// �����û���ȡ���е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WTOWData oWTOWData = new WTOWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Sto_WTOWGetByPerson", oHT, oWTOWData.Tables[WTOWData.WTOW_TABLE]);
            return oWTOWData;
        }

		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡί��ӹ����뵥��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByDeptCode",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		#endregion

		#region ר�з���
		/// <summary>
		/// ����ģʽ�¸���ί��ӹ����뵥��ˮ�Ż�ȡί��ӹ����뵥��Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ��.</param>
		/// <returns>object:	ί��ӹ����뵥ʵ��.</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByEntryNoOutMode",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// ��ȡ��Ч��ί��ӹ����뵥�б�
		/// ί��ӹ����ϵ�ʹ�á�
		/// </summary>
		/// <returns>object:	ί��ӹ����뵥�б�.</returns>
		public object GetWTOWValidData()
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("Sto_WTOWGetValidData",oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		/// <summary>
		/// ί��ӹ����뵥�ܷ���
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����뵥��ˮ�š�</param>
		/// <param name="UserLoginID">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DrawRefuse(int EntryNo,string UserLoginId)
		{
			bool ret = false;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@UserLoginId",UserLoginId);

			ret = oSQLServer.ExecSP("Sto_WTOWRefuse",oHT);
			if(ret == false)
			{
				this.Message = WTOWData.Refuse_Failed;
			}
			else
			{
				this.Message = WTOWData.Refuse_Success;
			}
			return ret;
		}
        ///// <summary>
        ///// ���ݸ����ݱ�Ż�ȡ���ֵ���
        ///// </summary>
        ///// <param name="EntryNo">int:	��������ˮ�š�</param>
        ///// <returns>object:	ί��ӹ����뵥ʵ�塣</returns>
        //public object GetEntryRedByEntryNo(int EntryNo)
        //{
        //    WTOWData oWTOWData = new WTOWData();
        //    SQLServer oSQLServer = new SQLServer();
        //    Hashtable oHT = new Hashtable();
        //    oHT.Add("@EntryNo",EntryNo);
        //    oSQLServer.ExecSPReturnDS("Sto_WTOWRed",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
        //    return oWTOWData;
        //}

		#endregion
		
		#region ͨ�ò�ѯ
		/// <summary>
		/// ����SQL�����в�ѯ��
		/// </summary>
		/// <param name="Sql_Statement"></param>
		/// <returns></returns>
		public object GetEntryBySQL(string Sql_Statement)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		public object GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			WTOWData oWTOWData = new WTOWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode", AuthorCode);
			oHT.Add("@AuditResult", AuditResult);
			oHT.Add("@StartDate",StartDate);
			oHT.Add("@EndDate", EndDate);

			oSQLServer.ExecSPReturnDS("Sto_WTOWGetByDeptAndAuthorAndAuditResult",oHT,oWTOWData.Tables[WTOWData.WTOW_TABLE]);
			return oWTOWData;
		}
		#endregion
	}
	#endregion public class WTOWs
}
