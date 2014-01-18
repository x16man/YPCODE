#define DEBUG
#undef DEBUG
using System.Collections;
using System.Data;
using MZHCommon.Database;
using System;
using Shmzh.MM.Common;
#if DEBUG 
using NUnit.Framework;
#endif

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

	#region public class PMRPs

	/// <summary>
	/// PMRPs ��ժҪ˵����
	/// </summary>
	#if DEBUG 
	[TestFixture]
	#endif
	public class PMRPs : Messages, IInItems
	{
		#region ���캯��

		public PMRPs()
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
		/// <param name="oEntry">PMRPData:	��������ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(PMRPData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[PMRPData.PMRP_TABLE].Rows[0];
			//����ģʽ�����ֶΡ�
			oHT.Add("@EntryNo", oRow[InItemData.ENTRYNO_FIELD]); //������ˮ�š�
			oHT.Add("@EntryCode", oRow[InItemData.ENTRYCODE_FIELD]); //���ݱ�š�
			oHT.Add("@DocCode", oRow[InItemData.DOCCODE_FIELD]); //�������͡�
			oHT.Add("@DocName", oRow[InItemData.DOCNAME_FIELD]); //�����������ơ�
			oHT.Add("@DocNo", oRow[InItemData.DOCNO_FIELD]); //���������ĵ���š�
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]); //����״̬��
			oHT.Add("@EntryDate", oRow[InItemData.ENTRYDATE_FIELD]); //�Ƶ����ڡ�
			oHT.Add("@AuthorCode", oRow[InItemData.AUTHORCODE_FIELD]); //�Ƶ��˱�š�
			oHT.Add("@AuthorName", oRow[InItemData.AUTHORNAME_FIELD]); //�Ƶ������ơ�
			oHT.Add("@AuthorLoginID", oRow[InItemData.AUTHORLOGINID_FIELD]); //�Ƶ��˵�¼����
			oHT.Add("@AuthorDept", oRow[InItemData.AUTHORDEPT_FIELD]); //�Ƶ��˲��š�
			oHT.Add("@AuthorDeptName", oRow[InItemData.AUTHORDEPTNAME_FIELD]); //�Ƶ��˲������ơ�
			oHT.Add("@SubTotal", oRow[InItemData.SUBTOTAL_FIELD]); //�����ܽ�
			oHT.Add("@Remark", oRow[InItemData.REMARK_FIELD]); //��ע��
			oHT.Add("@SerialNoList", oRow[InItemData.SERIALNO_FIELD]); //������ϸ����˳��š�
			oHT.Add("@ItemCodeList", oRow[InItemData.ITEMCODE_FIELD]); //���ϱ�š�
			oHT.Add("@ItemNameList", oRow[InItemData.ITEMNAME_FIELD]); //�������ơ�
			oHT.Add("@ItemSpecialList", oRow[InItemData.ITEMSPECIAL_FIELD]); //���Ϲ��
			oHT.Add("@ItemPriceList", oRow[InItemData.ITEMPRICE_FIELD]); //���ϵ��ۡ�
			oHT.Add("@ItemNumList", oRow[InItemData.ITEMNUM_FIELD]); //����������
			oHT.Add("@ItemMoneyList", oRow[InItemData.ITEMMONEY_FIELD]); //���Ͻ�
			oHT.Add("@ItemUnitList", oRow[InItemData.ITEMUNIT_FIELD]); //���ϵ�λ��
			oHT.Add("@ItemUnitNameList", oRow[InItemData.ITEMUNITNAME_FIELD]); //���ϵ�λ������
			//�������������ֶΡ�
			oHT.Add("@ReqDept", oRow[PMRPData.REQDEPT_FIELD]); //���벿�š�
			oHT.Add("@ReqDeptName", oRow[PMRPData.REQDEPTNAME_FIELD]); //���벿�����ơ�
			oHT.Add("@Proposer", oRow[PMRPData.PROPOSER_FIELD]); //�����ˡ�
			oHT.Add("@ProposerCode", oRow[PMRPData.PROPOSERCODE_FIELD]); //�����˱�š�
			oHT.Add("@ReqReasonCode", oRow[PMRPData.REQREASONCODE_FIELD]); //�������ɱ�š�
			oHT.Add("@ReqReason", oRow[PMRPData.REQREASON_FIELD]); //�������ɡ�
			oHT.Add("@ReqDateList", oRow[PMRPData.REQDATE_FIELD]); //Ҫ�󵽻����ڡ�
			return oHT;
		}

		#endregion ˽�з���

		#region IInItems ��Ա

		/// <summary>
		/// �����������ӡ�
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
#if DEBUG 
		[Test]
#endif
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				PMRPData oEntry = (PMRPData) Entry;
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = this.FillHashTable(oEntry);

				ret = oSQLServer.ExecSP("Pur_MRPInsert", oHT);
				if (ret == false)
				{
					this.Message = PMRPData.ADD_FAILED;
				}
				else
				{
					this.Message = PMRPData.ADD_SUCCESSED;
				}
			}
			else
			{
				ret = false;
				this.Message = PMRPData.NOOBJECT;
			}
			return ret;
		}

		/// <summary>
		/// �����������Ӳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				PMRPData oEntry = (PMRPData) Entry;
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = this.FillHashTable(oEntry);

				ret = oSQLServer.ExecSP("Pur_MRPInsertAndPresent", oHT);
				if (ret == false)
				{
					this.Message = PMRPData.ADD_FAILED;
				}
				else
				{
					this.Message = PMRPData.ADD_SUCCESSED;
				}
			}
			else
			{
				ret = false;
				this.Message = PMRPData.NOOBJECT;
			}
			return ret;
		}

		/// <summary>
		/// ���������޸ġ�
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret = true;
			PMRPData oEntry = (PMRPData) Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_MRPUpdate", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PMRPData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �޸Ĳ����ύ�������󵥡�
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			PMRPData oEntry = (PMRPData) Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Pur_MRPUpdateAndPresent", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.UPDATE_FAILED;
			}
			else
			{
				this.Message = PMRPData.UPDATE_SUCCESSED;
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
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_MRPDelete", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.DELETE_FAILED;
			}
			else
			{
				this.Message = PMRPData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ������������״̬��
		/// </summary>
		/// <param name="EntryNo">int:	����������ˮ�š�</param>
		/// <param name="EntryState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string EntryState)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", EntryState);

			ret = oSQLServer.ExecSP("Pur_MRPUpdateState", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PMRPData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strEmpCode"></param>
        /// <param name="strEntryNo"></param>
        /// <returns></returns>
        public bool IsAuditDept(string strEmpCode, int EntryNo)
        {
            PMRPData oPMRPData = new PMRPData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", strEmpCode);
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Pur_MRPAuditDept", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
            if (oPMRPData.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

		/// <summary>
		/// ��������һ��������
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				PMRPData oEntry = (PMRPData) Entry;
				DataRow oRow;
				oRow = oEntry.Tables[PMRPData.PMRP_TABLE].Rows[0];

				oHT.Add("@EntryNo", oRow[InItemData.ENTRYNO_FIELD]);
				oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
				oHT.Add("@Audit1", oRow[InItemData.AUDIT1_FIELD]);
				oHT.Add("@Assessor1", oRow[InItemData.ASSESSOR1_FIELD]);
				oHT.Add("@AuditSuggest1", oRow[InItemData.AUDITSUGGEST1_FIELD]);
				oHT.Add("@UserLoginId", oRow[InItemData.AUTHORLOGINID_FIELD]);

				ret = oSQLServer.ExecSP("Pur_MRPFirstAudit", oHT);
				if (ret == false)
				{
					this.Message = PMRPData.FIRSTAUDIT_FAILED;
				}
				else
				{
					this.Message = PMRPData.FIRSTAUDIT_SUCCESSED;
				}
			}
			else
			{
				ret = false;
				this.Message = PMRPData.NOOBJECT;
			}
			return ret;
		}

		/// <summary>
		/// �������󵥶���������
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				PMRPData oEntry = (PMRPData) Entry;
				DataRow oRow;
				oRow = oEntry.Tables[PMRPData.PMRP_TABLE].Rows[0];

				oHT.Add("@EntryNo", oRow[InItemData.ENTRYNO_FIELD]);
				oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
				oHT.Add("@Audit2", oRow[InItemData.AUDIT2_FIELD]);
				oHT.Add("@Assessor2", oRow[InItemData.ASSESSOR2_FIELD]);
				oHT.Add("@AuditSuggest2", oRow[InItemData.AUDITSUGGEST2_FIELD]);
				oHT.Add("@UserLoginId", oRow[InItemData.AUTHORLOGINID_FIELD]);

				ret = oSQLServer.ExecSP("Pur_MRPSecondAudit", oHT);
				if (ret == false)
				{
					this.Message = PMRPData.SECONDAUDIT_FAILED;
				}
				else
				{
					this.Message = PMRPData.SECONDAUDIT_SUCCESSED;
				}
			}
			else
			{
				ret = false;
				this.Message = PMRPData.NOOBJECT;
			}
			return ret;
		}

		/// <summary>
		/// ������������������
		/// </summary>
		/// <param name="Entry">object:	��������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			PMRPData oEntry = (PMRPData) Entry;
			DataRow oRow;
			oRow = oEntry.Tables[PMRPData.PMRP_TABLE].Rows[0];

			oHT.Add("@EntryNo", oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState", oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3", oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3", oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3", oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId", oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_MRPThirdAudit", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PMRPData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ���������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	����������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_MRPPresent", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PMRPData.PRESENT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �����������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	����������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);

			ret = oSQLServer.ExecSP("Pur_MRPCancel", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PMRPData.CANCEL_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �����������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	����������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginID">string:	operator.</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID", UserLoginID);
			ret = oSQLServer.ExecSP("Pur_MRPCancel", oHT);
			if (ret == false)
			{
				this.Message = PMRPData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PMRPData.CANCEL_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	��������ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_MRPGetByEntryNo", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

		/// <summary>
		/// ���ݵ��ݱ�źŻ�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryCode">int:	���ݱ�š�</param>
		/// <returns>object:	��������ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode", EntryCode);

			oSQLServer.ExecSPReturnDS("Pur_MRPGetByEntryCode", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

		/// <summary>
		/// ��ȡ���е��ݡ�
		/// </summary>
		/// <returns>object:	��������ʵ�塣</returns>
		public object GetEntryAll()
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_MRPGetAll", oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

		/// <summary>
		/// �����û����ڲ��ŵ�Ȩ�޻�ȡ�����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>object:	��������ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId", UserLoginId);
            
			oSQLServer.ExecSPReturnDS("Pur_MRPGetAll", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

        /// <summary>
        /// �����û����ڱ��˵�Ȩ�޻�ȡ�����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���</param>
        /// <returns>object:	��������ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            PMRPData oPMRPData = new PMRPData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Pur_MRPGetByPerson", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
            return oPMRPData;
        }

		/// <summary>
		/// ����ָ�����Ƶ����Ż�ȡ�ɹ����뵥��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	��������ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept", DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_MRPGetByDeptCode", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}

		#endregion

		#region ͨ�ò�ѯ

		public PMRPData GetEntryBySQL(string Sql_Statement)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement", Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}
		public PMRPData GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult, DateTime StartDate, DateTime EndDate)
		{
			PMRPData oPMRPData = new PMRPData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept", AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult",AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);

			oSQLServer.ExecSPReturnDS("Pur_MRPGetByDeptAndAuthorAndAuditResult", oHT, oPMRPData.Tables[PMRPData.PMRP_TABLE]);
			return oPMRPData;
		}
		#endregion
	}

	#endregion public class PMRPs
}