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

	#region public class WRTSs
	/// <summary>
	/// WRTSs ��ժҪ˵����
	/// </summary>
	public class WRTSs : Messages,IInItems
	{
		#region ���캯��
		public WRTSs()
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
		/// <param name="oEntry">WRTSData:	�������ϵ�ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(WRTSData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];
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
			//oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);				//����������
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			//�������ϵ������ֶΡ�
			//oHT.Add("@StoManagerCode",  oRow[WRTSData.STOMANAGERCODE_FIELD]);				//�ֿ����Ա����
			//oHT.Add("@StoManager",      oRow[WRTSData.STOMANAGER_FIELD]);					//�ֿ����Ա
			//oHT.Add("@DrawDate",        oRow[WRTSData.DRAWDATE_FIELD]);					//��������
			oHT.Add("@SourceEntryList",   oRow[WRTSData.SOURCEENTRY_FIELD]);				//Դ������ˮ��
			oHT.Add("@SourceDocCodeList", oRow[WRTSData.SOURCEDOCCODE_FIELD]);			//Դ��������
			oHT.Add("@SourceSerialNoList",oRow[WRTSData.SOURCESERIALNO_FIELD]);			//Դ������š�
			oHT.Add("@ReqReasonCode",	oRow[WRTSData.REQREASONCODE_FIELD]);				//��;���
			oHT.Add("@ReqReason",       oRow[WRTSData.REQREASON_FIELD]);					//��;����
			oHT.Add("@StoCode",         oRow[WRTSData.STOCODE_FIELD]);						//�ֿ���
			oHT.Add("@StoName",         oRow[WRTSData.STONAME_FIELD]);						//�ֿ�����
			oHT.Add("@PlanNumList",     oRow[WRTSData.PLANNUM_FIELD]);						//��������

			oHT.Add("@ReqDept",			oRow[WRTSData.REQDEPT_FIELD]);						//���벿�š�
			oHT.Add("@ReqDeptName",		oRow[WRTSData.REQDEPTNAME_FIELD]);		//���벿�����ơ�
			oHT.Add("@Proposer",		oRow[WRTSData.PROPOSER_FIELD]);			//�����ˡ�
			oHT.Add("@ProposerCode",	oRow[WRTSData.PROPOSERCODE_FIELD]);		//�����˱�š�
			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա

		/// <summary>
		/// �������ϵ����ӡ�
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_RTSInsert",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.ADD_FAILED;
			}
			else
			{
				this.Message = WRTSData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �������ϵ����Ӳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_RTSInsertAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.ADD_FAILED;
			}
			else
			{
				this.Message = WRTSData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �������ϵ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{

			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_RTSUpdate",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WRTSData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �������ϵ��޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WRTSData oEntry = (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_RTSUpdateAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WRTSData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �������ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�������ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_RTSDelete", oHT);
			if(ret == false)
			{
				this.Message = WRTSData.DELETE_FAILED;
			}
			else
			{
				this.Message = WRTSData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �����������ϵ�״̬��
		/// </summary>
		/// <param name="EntryNo">int:	�������ϵ���ˮ�š�</param>
		/// <param name="EntryState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Sto_RTSUpdateState", oHT);
			if(ret == false)
			{
				this.Message = WRTSData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = WRTSData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �������ϵ�һ��������
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WRTSData oEntry = (WRTSData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_RTSFirstAudit",oHT);

			if(ret == false)
			{
				this.Message = WRTSData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = WRTSData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������ϵ�����������
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WRTSData oEntry= (WRTSData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_RTSSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = WRTSData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������ϵ�����������
		/// </summary>
		/// <param name="Entry">object:	�������ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WRTSData oEntry= (WRTSData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_RTSThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = WRTSData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�������ϵ���ˮ�š�</param>
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

			ret = oSQLServer.ExecSP("Sto_RTSPresent",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.PRESENT_FAILED;
			}
			else
			{
				this.Message = WRTSData.PRESENT_SUCCESSED;
			}
			return ret;
		}

		public bool Cancel(int EntryNo, string newState,string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID", UserLoginID);
			
			ret = oSQLServer.ExecSP("Sto_RTSCancel",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WRTSData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�������ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);

			ret = oSQLServer.ExecSP("Sto_RTSCancel",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WRTSData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	�������ϵ�ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_RTSGetByEntryNo",oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}
		public object GetEntryByEntryNoInMode(int EntryNo)
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_RTSGetByEntryNoInMode",oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}
		/// <summary>
		/// ���ݵ��ݱ�źŻ�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ݱ�š�</param>
		/// <returns>object:	�������ϵ�ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Sto_RTSGetByEntryCode",oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}
		/// <summary>
		/// ��ȡ���е��ݡ�
		/// </summary>
		/// <returns>object:	�������ϵ�ʵ�塣</returns>
		public object GetEntryAll()
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_RTSGetAll",oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}


        /// <summary>
        /// ��ȡ���е��ݡ�
        /// </summary>
        /// <returns>object:	�������ϵ�ʵ�塣</returns>
        public object GetEntryByDept(string strDeptCode)
        {
            WRTSData oWRTSData = new WRTSData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@AuthorDept", strDeptCode);

            oSQLServer.ExecSPReturnDS("Sto_RTSGetByDept", oHT, oWRTSData.Tables[WRTSData.WRTS_TABLE]);
            return oWRTSData;
        }


        /// <summary>
        /// ��ȡ���е��ݡ�
        /// </summary>
        /// <returns>object:	�������ϵ�ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WRTSData oWRTSData = new WRTSData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);


            oSQLServer.ExecSPReturnDS("Sto_RTSGetByPerson", oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
            return oWRTSData;
        }
		#endregion

		#region ���ϵ������Ա
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="Entry">���ϵ�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Check(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			WRTSData oEntry = (WRTSData)Entry;
			DataRow oRow;
			oRow = oEntry.Tables[WRTSData.WRTS_TABLE].Rows[0];

			oHT.Add("@EntryNo",         oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@ChkResult",       oRow[WRTSData.CHKRESULT_FIELD]);
			oHT.Add("@ChkManCode",      oRow[WRTSData.CHKMANCODE_FIELD]);
			oHT.Add("@ChkManName",      oRow[WRTSData.CHKMANNAME_FIELD]);


			ret = oSQLServer.ExecSP("Sto_RTSCheck",oHT);
			if(ret == false)
			{
				this.Message = WRTSData.CHECK_FAILED;
			}
			else
			{
				this.Message = WRTSData.CHKCK_SUCCESSED;
			}
			return ret;
		}
		
		/// <summary>
		/// �������ϵ�����
		/// </summary>
		/// <param name="Entry"></param>
		/// <returns></returns>
		public bool Receive( object Entry)
		{
			bool ret = false;
			WRTSData oEntry= (WRTSData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			oHT.Add("@ConCodeList",oEntry.Tables[0].Rows[0][WRTSData.CONCODE_FIELD]);	//��λ����
			oHT.Add("@ConNameList",oEntry.Tables[0].Rows[0][WRTSData.CONNAME_FIELD]);	//��λ����
			oHT.Add("@ItemNumList",oEntry.Tables[0].Rows[0][InItemData.ITEMNUM_FIELD]);	//����������
			oHT.Add("@StoManagerCode",  oEntry.Tables[0].Rows[0][WRTSData.STOMANAGERCODE_FIELD]);  //�ֿ����Ա����
			oHT.Add("@StoManager",      oEntry.Tables[0].Rows[0][WRTSData.STOMANAGER_FIELD]);      //�ֿ����Ա
			ret = oSQLServer.ExecSP("Sto_RTSReceive", oHT);
			if(ret == false)
			{
				this.Message = WRTSData.RECEIVE_FAILED;
			}
			else
			{
				this.Message = WRTSData.RECEIVE_SUCCESSED;
			}
			return ret;
		}
		#endregion ���ϵ������Ա

		#region ͨ�ò�ѯ
		public WRTSData GetEntryBySQL(string Sql_Statement)
		{
			WRTSData oWRTSData = new WRTSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWRTSData.Tables[WRTSData.WRTS_TABLE]);
			return oWRTSData;
		}
		#endregion
	}
	#endregion public class WRTSs
}
