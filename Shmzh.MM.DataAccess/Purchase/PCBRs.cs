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

	#region public class PCBRs
	/// <summary>
	/// PCBRs ��ժҪ˵����
	/// </summary>
	public class PCBRs : Messages,IInItems
	{
		#region ���캯��
		public PCBRs()
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
		/// <param name="oEntry">PCBRData:	�������յ�ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(PCBRData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PCBRData.PCBR_TABLE].Rows[0];
			//����ģʽ�����ֶΡ�
			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);					//������ˮ�š�
			oHT.Add("@EntryCode",		oRow[InItemData.ENTRYCODE_FIELD]);					//���ݱ�š�
			oHT.Add("@DocCode",			oRow[InItemData.DOCCODE_FIELD]);					//�������͡�
			oHT.Add("@DocName",			oRow[InItemData.DOCNAME_FIELD]);					//�����������ơ�
			oHT.Add("@DocNo",			oRow[InItemData.DOCNO_FIELD]);						//���������ĵ���š�
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);					//����״̬��
			oHT.Add("@AuthorCode",		oRow[InItemData.AUTHORCODE_FIELD]);					//�Ƶ��˱�š�
			oHT.Add("@AuthorName",		oRow[InItemData.AUTHORNAME_FIELD]);					//�Ƶ������ơ�
			oHT.Add("@AuthorLoginID",	oRow[InItemData.AUTHORLOGINID_FIELD]);				//�Ƶ��˵�¼����
			oHT.Add("@AuthorDept",		oRow[InItemData.AUTHORDEPT_FIELD]);					//�Ƶ��˲��š�
			oHT.Add("@AuthorDeptName",	oRow[InItemData.AUTHORDEPTNAME_FIELD]);				//�Ƶ��˲������ơ�
			oHT.Add("@Remark",			oRow[InItemData.REMARK_FIELD]);						//��ע��
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//������ϸ����˳��š�

			//�������յ������ֶΡ�
			oHT.Add("@RecvDate",		oRow[PCBRData.RECVDATE_FIELD]);
			oHT.Add("@SourceEntry",		oRow[PCBRData.SOURCEENTRY_FIELD]);
			oHT.Add("@SourceDocCode",	oRow[PCBRData.SOURCEDOCCODE_FIELD]);
			oHT.Add("@BatchCode",		oRow[PCBRData.BATCHCODE_FIELD]);
			oHT.Add("@PrvCode",			oRow[PCBRData.PRVCODE_FIELD]);
			oHT.Add("@PrvName",			oRow[PCBRData.PRVNAME_FIELD]);
			oHT.Add("@PrvAdd",			oRow[PCBRData.PRVADD_FIELD]);
			oHT.Add("@PrvZip",			oRow[PCBRData.PRVZIP_FIELD]);
			oHT.Add("@PrvTel",			oRow[PCBRData.PRVTEL_FIELD]);
			oHT.Add("@PrvFax",			oRow[PCBRData.PRVFAX_FIELD]);
			oHT.Add("@ChkDept",			oRow[PCBRData.CHKDEPT_FIELD]);
			oHT.Add("@ChkDeptName",		oRow[PCBRData.CHKDEPTNAME_FIELD]);
			oHT.Add("@CitmCodeList",	oRow[PCBRData.CITMCODE_FIELD]);
			oHT.Add("@CitmNameList",	oRow[PCBRData.CITMNAME_FIELD]);
			oHT.Add("@CitmUnitList",	oRow[PCBRData.CITMUNIT_FIELD]);
			oHT.Add("@CitmValueList",	oRow[PCBRData.CITMVALUE_FIELD]);

			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա

		/// <summary>
		/// �������յ����ӡ�
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret=true;
			PCBRData oEntry= (PCBRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PCBRInsert", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.ADD_FAILED;
			}
			else
			{
				this.Message = PCBRData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������յ����Ӳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret=true;
			PCBRData oEntry= (PCBRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PCBRInsertAndPresent", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.ADD_FAILED;
			}
			else
			{
				this.Message = PCBRData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������յ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret=true;
			PCBRData oEntry= (PCBRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PCBRUpdate", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PCBRData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �������յ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret=true;
			PCBRData oEntry= (PCBRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_PCBRUpdateAndPresent", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PCBRData.UPDATE_SUCCESSED;
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

			ret = oSQLServer.ExecSP("Pur_PCBRDelete", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.DELETE_FAILED;
			}
			else
			{
				this.Message = PCBRData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �����������յ�״̬��
		/// </summary>
		/// <param name="EntryNo">int:	�������յ���ˮ�š�</param>
		/// <param name="EntryState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",EntryState);

			ret = oSQLServer.ExecSP("Pur_PCBRUpdateState", oHT);
			if(ret == false)
			{
				this.Message = PCBRData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PCBRData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �������յ�һ��������
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PCBRData oEntry= (PCBRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PCBRData.PCBR_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PCBRFirstAudit",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = PCBRData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������յ�����������
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PCBRData oEntry= (PCBRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PCBRData.PCBR_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);
			
			ret = oSQLServer.ExecSP("Pur_PCBRSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = PCBRData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������յ�����������
		/// </summary>
		/// <param name="Entry">object:	�������յ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PCBRData oEntry= (PCBRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PCBRData.PCBR_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);
			
			ret = oSQLServer.ExecSP("Pur_PCBRThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PCBRData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������յ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�������յ���ˮ�š�</param>
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

			ret = oSQLServer.ExecSP("Pur_PCBRPresent",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PCBRData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �������յ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�������յ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			ret = oSQLServer.ExecSP("Pur_PCBRCancel",oHT);
			if(ret == false)
			{
				this.Message = PCBRData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PCBRData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	�������յ�ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PCBRData oPCBRData = new PCBRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_PCBRGetByEntryNo",oHT,oPCBRData.Tables[PCBRData.PCBR_TABLE]);
			return oPCBRData;
		}
		/// <summary>
		/// ���ݵ��ݱ�źŻ�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">int:	���ݱ�š�</param>
		/// <returns>object:	�������յ�ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PCBRData oPCBRData = new PCBRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Pur_PCBRGetByEntryCode",oHT,oPCBRData.Tables[PCBRData.PCBR_TABLE]);
			return oPCBRData;
		}
		/// <summary>
		/// ��ȡ���е��ݡ�
		/// </summary>
		/// <returns>object:	�������յ�ʵ�塣</returns>
		public object GetEntryAll()
		{
			PCBRData oPCBRData = new PCBRData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_PCBRGetAll",oPCBRData.Tables[PCBRData.PCBR_TABLE]);
			return oPCBRData;
		}
		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡ�������յ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	�������յ�ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PCBRData oPCBRData = new PCBRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_PCBRGetByDeptCode",oHT,oPCBRData.Tables[PCBRData.PCBR_TABLE]);
			return oPCBRData;
		}
		#endregion

		#region ר�÷���
		/// <summary>
		/// ���ݹ�Ӧ�̻�ȡ�������յ�����Դ��
		/// </summary>
		/// <param name="PrvCode">string:	��Ӧ�̱�š�</param>
		/// <returns>CBRSData:	���յ�����Դʵ�塣</returns>
		public CBRSData GetCBRSByPrvCode(string PrvCode)
		{
			CBRSData oCBRSData = new CBRSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PrvCode", PrvCode);

			oSQLServer.ExecSPReturnDS("Pur_CBRSGetByPrvCode",oHT,oCBRSData.Tables[CBRSData.CBRS_VIEW]);
			return oCBRSData;
		}
		/// <summary>
		/// ���ݹ�Ӧ���Լ����ڷ�Χ��ȡ�������յ�����Դ��
		/// </summary>
		/// <param name="PrvCode">string:	��Ӧ�̱�š�</param>
		/// <param name="StartDate">DateTime:	��ʼ���ڡ�</param>
		/// <param name="EndDate">DateTime:	�������ڡ�</param>
		/// <returns>CBRSData:	���յ�����Դʵ�塣</returns>
		public CBRSData GetCBRSByPrvCodeAndDate(string PrvCode,DateTime StartDate,DateTime EndDate)
		{
			CBRSData oCBRSData = new CBRSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PrvCode", PrvCode);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oSQLServer.ExecSPReturnDS("Pur_CBRSGetByPrvCodeAndDate",oHT,oCBRSData.Tables[CBRSData.CBRS_VIEW]);
			return oCBRSData;
		}
		#endregion
	}
	#endregion public class PCBRs
}
