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
	using System.Collections;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// PurchasePlans ��ժҪ˵����
	/// </summary>
	public class PurchasePlans : Messages,IInItems
	{
        #region Property
        /// <summary>
        /// ���ݿ������ַ�����
        /// </summary>
        public string ConnString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
        #endregion

		#region ���캯��
		public PurchasePlans()
		{
		}
		#endregion

		#region ˽�з���
		private Hashtable FillHashTable(PurchasePlanData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow=oEntry.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];
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
			
			oHT.Add("@SerialNoList",	oRow[InItemData.SERIALNO_FIELD]);					//������ϸ����˳��š�
			oHT.Add("@ItemCodeList",	oRow[InItemData.ITEMCODE_FIELD]);					//���ϱ�š�
			oHT.Add("@ItemNameList",	oRow[InItemData.ITEMNAME_FIELD]);					//�������ơ�
			oHT.Add("@ItemSpecialList",	oRow[InItemData.ITEMSPECIAL_FIELD]);				//���Ϲ��
			oHT.Add("@ItemUnitList",	oRow[InItemData.ITEMUNIT_FIELD]);					//���ϵ�λ��
			oHT.Add("@ItemUnitNameList",oRow[InItemData.ITEMUNITNAME_FIELD]);				//���ϵ�λ������
			oHT.Add("@ItemPriceList",	oRow[InItemData.ITEMPRICE_FIELD]);					//���ϵ��ۡ�
			oHT.Add("@ItemNumList",		oRow[InItemData.ITEMNUM_FIELD]);					//����������
			oHT.Add("@ItemMoneyList",	oRow[InItemData.ITEMMONEY_FIELD]);					//���Ͻ�
			//�ɹ��ƻ������ֶΡ�
			oHT.Add("@SourceEntryList",		oRow[PurchasePlanData.SOURCEENTRY_FIELD]);			//Դ���ݱ�š�
			oHT.Add("@SourceDocCodeList",	oRow[PurchasePlanData.SOURCEDOCCODE_FIELD]);		//Դ�������ͱ�š�
			oHT.Add("@PlanDate",			oRow[PurchasePlanData.PLANDATE_FIELD]);				//�ƻ����ڡ�
			oHT.Add("@ItemLackNumList",		oRow[PurchasePlanData.ITEMLACKNUM_FIELD]);			//δ���ɶ���������
			oHT.Add("@ReqDeptList",			oRow[PurchasePlanData.REQDEPT_FIELD]);				//���벿�š�
			oHT.Add("@ReqDeptNameList",		oRow[PurchasePlanData.REQDEPTNAME_FIELD]);			//���벿�����ơ�
			oHT.Add("@ReqReasonCodeList",	oRow[PurchasePlanData.REQREASONCODE_FIELD]);		//��;��š�
			oHT.Add("@ReqReasonList",		oRow[PurchasePlanData.REQREASON_FIELD]);			//��;��
			oHT.Add("@ReqDateList",			oRow[PurchasePlanData.REQDATE_FIELD]);				//Ҫ�����ڡ�
			oHT.Add("@RemarkList",			oRow[InItemData.REMARK_FIELD]);						//��ע��
			return oHT;
		}
		#endregion

		#region IInItems ��Ա
		/// <summary>
		/// �ɹ��ƻ��Ĳ��롣
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			PurchasePlanData oEntry = (PurchasePlanData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PlanInsert",oHT);
			
			if(ret == false)
			{
				this.Message = PurchasePlanData.ADD_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ��ƻ����½������ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			PurchasePlanData oEntry = (PurchasePlanData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PlanInsertAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message = PurchasePlanData.ADD_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.ADD_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ��ƻ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{
			bool ret = true;
			PurchasePlanData oEntry = (PurchasePlanData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PlanUpdate",oHT);
			
			if(ret == false)
			{
				this.Message = PurchasePlanData.ADD_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ��޸Ĳ����ύ��
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			PurchasePlanData oEntry = (PurchasePlanData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);
			
			ret = oSQLServer.ExecSP("Pur_PlanUpdateAndPresent",oHT);
			
			if(ret == false)
			{
				this.Message = PurchasePlanData.ADD_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_PlanDelete", oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.DELETE_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.DELETE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ�״̬�޸ġ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ�������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntryState(int EntryNo, string newState)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState",newState);

			ret = oSQLServer.ExecSP("Pur_PlanUpdateState", oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.UPDATESTATE_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.UPDATESTATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ�һ��������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchasePlanData oEntry= (PurchasePlanData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit1",			oRow[InItemData.AUDIT1_FIELD]);
			oHT.Add("@Assessor1",		oRow[InItemData.ASSESSOR1_FIELD]);
			oHT.Add("@AuditSuggest1",	oRow[InItemData.AUDITSUGGEST1_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PlanFirstAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ�����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchasePlanData oEntry= (PurchasePlanData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit2",			oRow[InItemData.AUDIT2_FIELD]);
			oHT.Add("@Assessor2",		oRow[InItemData.ASSESSOR2_FIELD]);
			oHT.Add("@AuditSuggest2",	oRow[InItemData.AUDITSUGGEST2_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PlanSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// �ɹ��ƻ�����������
		/// </summary>
		/// <param name="Entry">object:	�ɹ��ƻ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			PurchasePlanData oEntry= (PurchasePlanData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[InItemData.ENTRYNO_FIELD]);
			oHT.Add("@EntryState",		oRow[InItemData.ENTRYSTATE_FIELD]);
			oHT.Add("@Audit3",			oRow[InItemData.AUDIT3_FIELD]);
			oHT.Add("@Assessor3",		oRow[InItemData.ASSESSOR3_FIELD]);
			oHT.Add("@AuditSuggest3",	oRow[InItemData.AUDITSUGGEST3_FIELD]);
			oHT.Add("@UserLoginId",     oRow[InItemData.AUTHORLOGINID_FIELD]);

			ret = oSQLServer.ExecSP("Pur_PlanThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_PlanPresent",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.PRESENT_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.PRESENT_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// �ɹ��ƻ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(int EntryNo, string newState)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			
			oHT.Add("@EntryNo",			EntryNo);
			oHT.Add("@EntryState",		newState);
						
			ret = oSQLServer.ExecSP("Pur_PlanCancel",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.CANCEL_SUCCESSED;
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
						
			ret = oSQLServer.ExecSP("Pur_PlanCancel",oHT);
			if(ret == false)
			{
				this.Message = PurchasePlanData.CANCEL_FAILED;
			}
			else
			{
				this.Message = PurchasePlanData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ݲɹ��ƻ���ˮ�Ż�òɹ��ƻ���
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>object:	�ɹ��ƻ�ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByEntryNo",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}
		/// <summary>
		/// ���ݲɹ��ƻ���ˮ�Ż�ȡ�ɹ��ƻ����ݳ�ȥ����Ϊ���ļ�¼��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ��ƻ���ˮ�š�</param>
		/// <returns>object:	�ɹ��ƻ�ʵ�塣</returns>
		public object GetEntryByEntryNoExceptZero(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByEntryNoExceptZero",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}
		/// <summary>
		/// ��ȡ���ݲ��ŷ�����͵Ĳɹ��ƻ����ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	�ƻ���ˮ�š�</param>
		/// <returns>object:	�ɹ��ƻ�ʵ�塣</returns>
		public object GetPPByEntryNoGroupByDep(int EntryNo)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByEntryNoGroupByDep",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

		/// <summary>
		/// ���ݲɹ��ƻ���Ż�òɹ��ƻ���
		/// </summary>
		/// <param name="EntryCode">string:	�ɹ��ƻ���š�</param>
		/// <returns>object:	�ɹ��ƻ�ʵ�塣</returns>
		public object GetEntryByEntryCode(string EntryCode)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryCode",EntryCode);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByEntryCode",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

		/// <summary>
		/// ������вɹ��ƻ���
		/// </summary>
		/// <returns>object:	�ɹ��ƻ�ʵ�塣</returns>
		public object GetEntryAll()
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_PlanGetAll",oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

		/// <summary>
		/// �����û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>object:	�ɹ��ƻ�ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetAll",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

        /// <summary>
        /// �����û���ȡ�������е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>object:	�ɹ��ƻ�ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            PurchasePlanData oPurchasePlanData = new PurchasePlanData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Pur_PlanGetByPerson", oHT, oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
            return oPurchasePlanData;
        }
		/// <summary>
		/// ��ȡָ���Ƶ����ŵĲɹ��ƻ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>object:	�ɹ��ƻ�ʵ�塣</returns>
		public object GetEntryByDept(string DeptCode)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",DeptCode);

			oSQLServer.ExecSPReturnDS("Pur_PlanGetByDeptCode",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}

		#endregion

		#region �ɹ��ƻ�ר�з���
		/// <summary>
		/// ��ȡ���еĲɹ��ƻ���Դ���ݡ�
		/// </summary>
		/// <returns>PPSData:	�ɹ��ƻ���Դ����ʵ�塣</returns>
		public PPSData GetPPSALL(string UserLoginId)
		{
			PPSData oPPSData = new PPSData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId", UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_PPSGetAll",oHT,oPPSData.Tables[PPSData.PPS_TABLE]);
			oSQLServer.ExecSPReturnDS("Pur_PlanNumGetAll",oHT,oPPSData.Tables[PPSData.PLANNUM_TABLE]);
			return oPPSData;
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
                new SqlParameter("@DocCode",DbType.Int16){Value = 5},
                new SqlParameter("@SerialNo",DbType.Int32){Value=serialNo},
                new SqlParameter("@RequestObject",SqlDbType.NVarChar,20){Value="ReqReasonCode"},
            };

            var obj = SqlHelper.ExecuteScalar(this.ConnString, CommandType.Text, sqlStatement, parms);
            return obj == null ? string.Empty : obj.ToString();
        }
		#endregion

		#region ͨ�ò�ѯ
		public PurchasePlanData GetEntryBySQL(string Sql_Statement)
		{
			PurchasePlanData oPurchasePlanData = new PurchasePlanData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]);
			return oPurchasePlanData;
		}
		#endregion
	}
}
