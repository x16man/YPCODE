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
* penalties.  Any violations of this copyright will be WSCRecuted       *
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

	#region public class WSCRs
	/// <summary>
	/// �����͵��ݵĹ������ݷ��ʲ㡣
	/// </summary>
	public class WSCRs:Messages,IInItems
	{
		#region ���캯��
		public WSCRs()
		{}
		#endregion ���캯��

		#region ˽�з���
		/// <summary>
		/// ����ϣ��
		/// </summary>
		/// <param name="oEntry">WSCRData:	���ϵ�ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(WSCRData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[WSCRData.WSCR_TABLE].Rows[0];
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
			
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			//�������������ֶΡ�
			oHT.Add("@PlanNumList",		oRow[WSCRData.PLANNUM_FIELD]);					//����Ӧ��������
			oHT.Add("@ReqDept",			oRow[WSCRData.REQDEPT_FIELD]);			//���벿�š�
			oHT.Add("@ReqDeptName",		oRow[WSCRData.REQDEPTNAME_FIELD]);		//���벿�����ơ�
			oHT.Add("@Proposer",		oRow[WSCRData.PROPOSER_FIELD]);			//�����ˡ�
			oHT.Add("@ProposerCode",	oRow[WSCRData.PROPOSERCODE_FIELD]);		//�����˱�š�
			oHT.Add("@ReqReasonCode",	oRow[WSCRData.REQREASONCODE_FIELD]);		//�������ɱ�š�
			oHT.Add("@ReqReason",		oRow[WSCRData.REQREASON_FIELD]);			//�������ɡ�
			oHT.Add("@StoName",			oRow[WSCRData.STONAME_FIELD]);
			oHT.Add("@StoCode",			oRow[WSCRData.STOCODE_FIELD]);
			
			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա
		/// <summary>
		/// �������ӡ�
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WSCRData oEntry = (WSCRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WSCRInsert",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WSCRInsert,Please look the log file!";
				ret=false;
			}
			return ret;
		}

		/// <summary>
		/// �½��������ύ���ݡ�
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WSCRData oEntry = (WSCRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WSCRInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WSCRInsertAndPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �����޸ġ�
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret = true;
			WSCRData oEntry = (WSCRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WSCRUpdate",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WSCRUpdate,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// �޸Ĳ������ύ���ϵ���
		/// </summary>
		/// <param name="Entry">object:	���ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WSCRData oEntry = (WSCRData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("WSCRUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message="Error,WSCRUpdateAndPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			if((new SQLServer()).ExecSP("WSCRDelete",oHT) == false)
			{
				this.Message="Error,WSCRDelete,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����״̬���ġ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	������״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState",EntryState);
			if((new SQLServer()).ExecSP("WSCRUpdateState",oHT) == false)
			{
				this.Message="Error,WSCRUpdateState,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// һ��������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			WSCRData oEntry= (WSCRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WSCRData.WSCR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WSCRFirstAudit",oHT) == false)
			{
				this.Message="Error,WSCRFirstAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			Hashtable oHT=new Hashtable();
			WSCRData oEntry= (WSCRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WSCRData.WSCR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WSCRSecondAudit",oHT) == false)
			{
				this.Message="Error,WSCRSecondAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			WSCRData oEntry= (WSCRData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WSCRData.WSCR_TABLE].Rows[0];

			oHT.Add("@EntryNo",oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",oRow[InItemData.AUTHORLOGINID_FIELD]);

			if((new SQLServer()).ExecSP("WSCRThirdAudit",oHT) == false)
			{
				this.Message="Error,WSCRThirdAduit,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo,string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId",UserLoginId);
			
			if((new SQLServer()).ExecSP("WSCRPresent",oHT) == false)
			{
				this.Message="Error,WSCRPresent,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo,string newState)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			
			if((new SQLServer()).ExecSP("WSCRCancel",oHT) == false)
			{
				this.Message="Error,WSCRCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		public bool Cancel(int EntryNo,string newState,string UserLoginID)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID",UserLoginID);
			
			if((new SQLServer()).ExecSP("WSCRCancel",oHT) == false)
			{
				this.Message="Error,WSCRCancel,Please look the log file!";
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);
			oSQLServer.ExecSPReturnDS("WSCRGetByEntryNo",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		/// <summary>
		/// ���ݵ��ݱ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryCode);
			oSQLServer.ExecSPReturnDS("WSCRGetByEntryCode",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		/// <summary>
		/// ��ȡ�����빺����
		/// </summary>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryAll()
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("WSCRGetAll",oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);
			oSQLServer.ExecSPReturnDS("WSCRGetByDeptCode",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		#endregion
	
		#region ͨ�ò�ѯ
		/// <summary>
		/// �û�Ĭ�ϵĲ�ѯ������
		/// </summary>
		/// <returns>object:	�빺��ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("WSCRGetAll",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}

        /// <summary>
        /// �û�Ĭ�ϵĲ�ѯ������
        /// </summary>
        /// <returns>object:	�빺��ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WSCRData oWSCRData = new WSCRData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);
            oSQLServer.ExecSPReturnDS("WSCRGetByPerson", oHT, oWSCRData.Tables[WSCRData.WSCR_TABLE]);
            return oWSCRData;
        }
		/// <summary>
		/// ���ݲ�ѯ������ȡ�������
		/// </summary>
		/// <param name="Sql_statement"></param>
		/// <returns></returns>
		public WSCRData GetEntryBySQL(string Sql_Statement)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		#endregion

		#region ���ϵ�ר�з���
		/// <summary>
		/// ��ȡ���ϵ�����������Դ��
		/// </summary>
		/// <returns>WSCRData:	���ϵ�����Դ����ʵ�塣</returns>
		public WSCRData GetWSCRAll()
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("WSCRGetAll",oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		public bool Affirm(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();

			oHT.Add("@EntryNo",		EntryNo);
			oHT.Add("@EntryState",	newState);
			oHT.Add("@UserLoginId", UserLoginId);
			ret = oSQLServer.ExecSP("OrderAffirm",oHT);
			if(ret == false)
			{
				this.Message = WSCRData.AFFIRM_FAILED;
			}
			else
			{
				this.Message = WSCRData.ADD_SUCCESSED;
			}
			return ret;

		}
		public WSCRData GetWSCRByPKIDs(string PKIDs)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKIDs",PKIDs);
			oSQLServer.ExecSPReturnDS("WSCRGetByPKIDS",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		/// <summary>
		/// ����״̬��ȡ���ϵ���
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>object:	���ϵ�ʵ�塣</returns>
		public object GetEntryByState()
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("WSCRGetByState",oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}
		public WSCRData GetEntryByEntryNoDiscardMode(int EntryNo)
		{
			WSCRData oWSCRData = new WSCRData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("WSCRGetByEntryNoDiscardMode",oHT,oWSCRData.Tables[WSCRData.WSCR_TABLE]);
			return oWSCRData;
		}

		public bool DiscardWSCR( int EntryNo,string SerialNoList,string ItemNumList,string PKIDList,string ItemDrawNumList,string UserCode, string UserName, string UserLoginId)
		{
			bool ret = false;
			
			int output=0;

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

			ret = oSQLServer.ExecSP("WSCRDiscard", oHT); 
			if(ret == false)
			{
				this.Message = WSCRData.ADD_FAILED;
			}
			else if(output == -1)
			{
				this.Message = WSCRData.ROLL_FAILED;
			}
			else
			{
				this.Message = WSCRData.ADD_SUCCESSED;
			}
			return ret;
		}
		#endregion 
	}
	#endregion public class WSCRs
}
