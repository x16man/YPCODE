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

	#region public class WDRWs
	/// <summary>
	/// WDRWs ��ժҪ˵����
	/// </summary>
	public class WDRWs : Messages,IInItems
	{
		#region ���캯��
		public WDRWs()
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
		/// <param name="oEntry">WDRWData:	���ϵ�ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(WDRWData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[WDRWData.WDRW_TABLE].Rows[0];
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
			oHT.Add("@ParentEntryNo",	oRow[WDRWData.PARENTENTRYNO_FIELD]);				//���ָ����ݺš�
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//������ϸ����˳��š�
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//���ϱ�š�
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//�������ơ�
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//���Ϲ��
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//���ϵ��ۡ�
			//oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//����������
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			//���ϵ������ֶΡ�
			//oHT.Add("@StoManagerCode",  oRow[WDRWData.STOMANAGERCODE_FIELD]);  //�ֿ����Ա����
			//oHT.Add("@StoManager",      oRow[WDRWData.STOMANAGER_FIELD]);      //�ֿ����Ա
			//oHT.Add("@DrawDate",        oRow[WDRWData.DRAWDATE_FIELD]);        //��������
			oHT.Add("@SourceEntryList",     oRow[WDRWData.SOURCEENTRY_FIELD]);     //Դ������ˮ�š�
			oHT.Add("@SourceDocCodeList",   oRow[WDRWData.SOURCEDOCCODE_FIELD]);   //Դ�������͡�
			oHT.Add("@SourceSerialNoList",  oRow[WDRWData.SOURCESERIALNO_FIELD]);	//Դ����˳��š�
			oHT.Add("@ReqDept",				oRow[WDRWData.REQDEPT_FIELD]);
			oHT.Add("@ReqDeptName",			oRow[WDRWData.REQDEPTNAME_FIELD]);
			oHT.Add("@Proposer",			oRow[WDRWData.PROPOSER_FIELD]);
			oHT.Add("@ProposerCode",		oRow[WDRWData.PROPOSERCODE_FIELD]);
			oHT.Add("@ReqReasonCode",   oRow[WDRWData.REQREASONCODE_FIELD]);   //��;���
			oHT.Add("@ReqReason",       oRow[WDRWData.REQREASON_FIELD]);       //��;����
			oHT.Add("@StoCode",         oRow[WDRWData.STOCODE_FIELD]);         //�ֿ���
			oHT.Add("@StoName",         oRow[WDRWData.STONAME_FIELD]);         //�ֿ�����
			oHT.Add("@ConCode",			oRow[WDRWData.CONCODE_FIELD]);		   //��λ��š�
			oHT.Add("@ConName",			oRow[WDRWData.CONNAME_FIELD]);		   //��λ���ơ�
			oHT.Add("@PlanNumList",     oRow[WDRWData.PLANNUM_FIELD]);         //��������
			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա

		/// <summary>
		/// ���ϵ����ӡ�
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WDRWData oEntry = (WDRWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_DRWInsert",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.ADD_FAILED;
			}
			else
			{
				this.Message = WDRWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ���ϵ����Ӳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WDRWData oEntry = (WDRWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_DRWInsertAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.ADD_FAILED;
			}
			else
			{
				this.Message = WDRWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ���ϵ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{

			bool ret = true;
			WDRWData oEntry = (WDRWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_DRWUpdate",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WDRWData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ���ϵ��޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WDRWData oEntry = (WDRWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_DRWUpdateAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WDRWData.UPDATE_SUCCESSED;
			}
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
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_DRWDelete", oHT);
			if(ret == false)
			{
				this.Message = WDRWData.DELETE_FAILED;
			}
			else
			{
				this.Message = WDRWData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �������ϵ�״̬��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="EntryState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Sto_DRWUpdateState", oHT);
			if(ret == false)
			{
				this.Message = WDRWData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = WDRWData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ���ϵ�һ��������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WDRWData oEntry = (WDRWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WDRWData.WDRW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_DRWFirstAudit",oHT);

			if(ret == false)
			{
				this.Message = WDRWData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = WDRWData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�����������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WDRWData oEntry= (WDRWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WDRWData.WDRW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_DRWSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = WDRWData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�����������
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WDRWData oEntry= (WDRWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WDRWData.WDRW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Sto_DRWThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = WDRWData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
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

			ret = oSQLServer.ExecSP("Sto_DRWPresent",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.PRESENT_FAILED;
			}
			else
			{
				this.Message = WDRWData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			ret = oSQLServer.ExecSP("Sto_DRWCancel",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WDRWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
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
			
			ret = oSQLServer.ExecSP("Sto_DRWCancel",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WDRWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByEntryNo",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}

        /// <summary>
        /// ���ݵ�����ˮ�Ż�ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>object:	���ϵ�ʵ�塣</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            WDRWData oWDRWData = new WDRWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_DRWOldGetByEntryNo", oHT, oWDRWData.Tables[WDRWData.WDRW_TABLE]);
            return oWDRWData;
        }

		/// <summary>
		/// ����״̬��ȡ���ϵ���
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryByState(string EntryState)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryState",EntryState);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByState",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// ���ݵ��ݱ�źŻ�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ݱ�š�</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByEntryCode",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// ��ȡ���е��ݡ�
		/// </summary>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryAll()
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_DRWGetAll",oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// �����û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

            oSQLServer.ExecSPReturnDS("Sto_DRWGetAll", oHT, oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}

        /// <summary>
        /// �����û���ȡ���е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>object:	���ϵ�ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WDRWData oWDRWData = new WDRWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Sto_DRWGetByPerson", oHT, oWDRWData.Tables[WDRWData.WDRW_TABLE]);
            return oWDRWData;
        }

		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByDeptCode",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		#endregion

		#region ר�з���
		/// <summary>
		/// ����ģʽ�¸������ϵ���ˮ�Ż�ȡ���ϵ���Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ��.</param>
		/// <returns>object:	���ϵ�ʵ��.</returns>
		public object GetEntryByEntryNoOutMode(int EntryNo)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetByEntryNoOutMode",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// �������벿�ű�Ż�ȡ���ϵ�����Դ�����б�
		/// </summary>
		/// <param name="DeptCode">string:	���벿�š�</param>
		/// <returns>WDRWData:	���ϵ�����ʵ�塣</returns>
		public WDRWData GetSourceEntryLisByDeptCode(string DeptCode)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@DeptCode",DeptCode);

			oSQLServer.ExecSPReturnDS("Sto_DRWSListGetByDeptCode",oHT,oWDRWData.Tables[WDRWData.WDS_VIEW]);
			return oWDRWData;
		}
		/// <summary>
		/// ����Դ���ݺţ���ȡԴ���ݵĿ�����ϸ���ݡ�
		/// </summary>
		/// <param name="PKIDs">string:	Դ���ݺŴ���</param>
		/// <returns>WDRWData:	���ϵ�����ʵ�塣</returns>
		public WDRWData GetSourceEntryDetailByEntryNos(string PKIDs)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);

			oSQLServer.ExecSPReturnDS("Sto_DRWSourceDetailGetByPKIDs",oHT,oWDRWData.Tables[WDRWData.WDSD_VIEW]);
			return oWDRWData;
		}
		/// <summary>
		/// ���ϵ�����ʱ�򣬽��п��ѡ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="ItemCodeList">string:	���ϵ����ϱ�Ŵ���</param>
		/// <param name="ItemNumList">string:	ʵ����������</param>
		/// <returns>StockChoiceData:	�ɹ�ѡ��Ŀ��ʵ�塣</returns>
		public StockChoiceData GetStockChoice(int DocCode,int EntryNo, string SerialNoList, string ItemCodeList, string ItemNumList)
		{
			StockChoiceData oStockChoiceData = new StockChoiceData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@DocCode", DocCode);
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@SerialNoList",SerialNoList);
			oHT.Add("@ItemCodeList",ItemCodeList);
			oHT.Add("@ItemNumList",ItemNumList);

			oSQLServer.ExecSPReturnDS("Sto_DRWGetStockChoice",oHT,oStockChoiceData.Tables[StockChoiceData.StockChoice_Table]);
			return oStockChoiceData;
		}
		/// <summary>
		/// ���ϵ�����.
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ��.</param>
		/// <param name="SerialNoList">string:	˳��Ŵ�.</param>
		/// <param name="ItemNumList">string:	���ϵ���������.</param>
		/// <param name="PKIDList">string:	��������</param>
		/// <param name="ItemDrawNumList">string:	��淢������.</param>
		/// <param name="UserCode">string:	�û����.</param>
		/// <param name="UserName">string:	�û����ơ�</param>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DrawOutStock(int EntryNo, string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@SerialNoList", SerialNoList);
			oHT.Add("@ItemNumList", ItemNumList);
			oHT.Add("@PKIDList", PKIDList);
			oHT.Add("@ItemDrawNumList", ItemDrawNumList);
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@UserName",UserName);
			oHT.Add("@UserLoginId",UserLoginId);

			ret = oSQLServer.ExecSP("Sto_DRWStockOut",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.OUT_FAILED;
			}
			else
			{
				this.Message = WDRWData.OUT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ��ܷ���
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="UserLoginID">string:	�û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DrawRefuse(int EntryNo,string UserLoginId)
		{
			bool ret = false;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@UserLoginId",UserLoginId);

			ret = oSQLServer.ExecSP("Sto_DRWRefuse",oHT);
			if(ret == false)
			{
				this.Message = WDRWData.Refuse_Failed;
			}
			else
			{
				this.Message = WDRWData.Refuse_Success;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ�ת�ɹ����뵥��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ��š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Draw2Pros(int EntryNo)
		{
			bool ret = false;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@WDRW_EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_DRW2PROS",oHT);
			if(ret == false)
			{
				this.Message = "�����ϵ������빺��ʧ�ܣ�";
			}
			else
			{
				this.Message = "�����ϵ������빺���ɹ���";
			}
			return ret;
		}
		/// <summary>
		/// ���ݸ����ݱ�Ż�ȡ���ֵ���
		/// </summary>
		/// <param name="EntryNo">int:	��������ˮ�š�</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object	 GetEntryRedByEntryNo(int EntryNo)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("Sto_DRWRed",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		/// <summary>
		/// ������Ϣ������ѡ��ļ�¼���������ϵ������ݡ�
		/// </summary>
		/// <param name="PKIDs">string:	��Ϣ������ѡ�еļ�¼ID����</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryByFeedbackPKIDs(string PKIDs)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@FeedbackPKIDs", PKIDs);
			oSQLServer.ExecSPReturnDS("Sto_DRWGetBySelectedFeedback",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		#endregion
		
		#region ͨ�ò�ѯ
		/// <summary>
		/// ����SQL�����в�ѯ��
		/// </summary>
		/// <param name="Sql_Statement"></param>
		/// <returns></returns>
		public object GetEntryBySQL(string Sql_Statement)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}		  
		public object GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate, DateTime EndDate)
		{
			WDRWData oWDRWData = new WDRWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Sto_DRWGetByDeptAndAuthorAndAuditResult",oHT,oWDRWData.Tables[WDRWData.WDRW_TABLE]);
			return oWDRWData;
		}
		#endregion
	}
	#endregion public class WDRWs
}
