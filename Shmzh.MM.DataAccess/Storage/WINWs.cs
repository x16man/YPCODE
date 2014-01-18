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

	#region public class WINWs
	/// <summary>
	/// ί��ӹ����ϵ������ݷ��ʲ㡣
	/// </summary>
	public class WINWs : Messages
	{
		#region ���캯��
		/// <summary>
		/// ���캯����
		/// </summary>
		public WINWs()
		{
		}
		#endregion ���캯��

		#region ˽�з���
		/// <summary>
		/// ��ί��ӹ����ϵ���������䵽��ϣ��������Ϊ���ô洢���̵Ĳ����б�
		/// </summary>
		/// <param name="oEntry">WINWData:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>Hashtable:	�������ݵĹ�ϣ��</returns>
		private Hashtable FillHashTable(WINWData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;

			oRow = oEntry.Tables[WINWData.WINW_TABLE].Rows[0];
			//ί��ӹ����ϵ�ģʽ�����ֶΡ�
			oHT.Add("@EntryNo",	oRow[WINWData.EntryNo_Field]);					//������ˮ�š�
			oHT.Add("@EntryCode", oRow[WINWData.EntryCode_Field]);				//���ݱ�š�
			oHT.Add("@DocCode",	oRow[WINWData.DocCode_Field]);					//�������͡�
			oHT.Add("@DocName", oRow[WINWData.DocName_Field]);					//�����������ơ�
			oHT.Add("@DocNo", oRow[WINWData.DocNo_Field]);						//���������ĵ���š�
			oHT.Add("@EntryState", oRow[WINWData.EntryState_Field]);			//����״̬��
			oHT.Add("@EntryDate", oRow[WINWData.EntryDate_Field]);				//�Ƶ����ڡ�
			oHT.Add("@AuthorCode", oRow[WINWData.AuthorCode_Field]);			//�Ƶ��˱�š�
			oHT.Add("@AuthorName", oRow[WINWData.AuthorName_Field]);			//�Ƶ������ơ�
			oHT.Add("@AuthorLoginID", oRow[WINWData.AuthorLoginID_Field]);		//�Ƶ��˵�¼����
			oHT.Add("@AuthorDept", oRow[WINWData.AuthorDept_Field]);			//�Ƶ��˲��š�
			oHT.Add("@AuthorDeptName", oRow[WINWData.AuthorDeptName_Field]);	//�Ƶ��˲������ơ�
			oHT.Add("@ReqReasonCode", oRow[WINWData.ReqReasonCode_Field]);
			oHT.Add("@ReqReason", oRow[WINWData.ReqReason_Field]);
			oHT.Add("@ProcessContent", oRow[WINWData.ProcessContent_Field]);
			oHT.Add("@PresentDate", oRow[WINWData.PresentDate_Field]);
			oHT.Add("@CancelDate", oRow[WINWData.CancelDate_Field]);
			oHT.Add("@AcceptDate", oRow[WINWData.AcceptDate_Field]);
			oHT.Add("@StoCode", oRow[WINWData.StoCode_Field]);
			oHT.Add("@StoName", oRow[WINWData.StoName_Field]);
			oHT.Add("@StoManagerCode", oRow[WINWData.StoManagerCode_Field]);
			oHT.Add("@StoManager", oRow[WINWData.StoManager_Field]);
			oHT.Add("@Audit1", oRow[WINWData.Audit1_Field]);
			oHT.Add("@Assessor1", oRow[WINWData.Assessor1_Field]);
			oHT.Add("@AuditSuggest1", oRow[WINWData.AuditSuggest1_Field]);
			oHT.Add("@AuditDate1", oRow[WINWData.AuditDate1_Field]);
			oHT.Add("@Audit2", oRow[WINWData.Audit2_Field]);
			oHT.Add("@Assessor2", oRow[WINWData.Assessor2_Field]);
			oHT.Add("@AuditSuggest2", oRow[WINWData.AuditSuggest2_Field]);
			oHT.Add("@AuditDate2", oRow[WINWData.AuditDate2_Field]);
			oHT.Add("@Audit3", oRow[WINWData.Audit3_Field]);
			oHT.Add("@Assessor3", oRow[WINWData.Assessor3_Field]);
			oHT.Add("@AuditSuggest3", oRow[WINWData.AuditSuggest3_Field]);
			oHT.Add("@AuditDate3", oRow[WINWData.AuditDate3_Field]);
			oHT.Add("@ResTotal", oRow[WINWData.ResTotal_Field]);
			oHT.Add("@FeeTotal", oRow[WINWData.FeeTotal_Field]);
			oHT.Add("@SubTotal", oRow[WINWData.SubTotal_Field]);				
			oHT.Add("@Remark", oRow[WINWData.Remark_Field]);					
			oHT.Add("@ParentEntryNo", oRow[WINWData.ParentEntryNo_Field]);		
			oHT.Add("@InvoiceNo", oRow[WINWData.InvoiceNo_Field]);
			oHT.Add("@ContractCode", oRow[WINWData.ContractCode_Field]);
			oHT.Add("@PrvCode", oRow[WINWData.PrvCode_Field]);
			oHT.Add("@PrvName", oRow[WINWData.PrvName_Field]);
			oHT.Add("@PayDate", oRow[WINWData.PayDate_Field]);
			oHT.Add("@Payer", oRow[WINWData.Payer_Field]);
			oHT.Add("@BuyerCode", oRow[WINWData.BuyerCode_Field]);
			oHT.Add("@BuyerName", oRow[WINWData.BuyerName_Field]);
			oHT.Add("@PayStyle", oRow[WINWData.PayStyle_Field]);
			oHT.Add("@ChkNo", oRow[WINWData.ChkNo_Field]);
			oHT.Add("@ChkResult", oRow[WINWData.ChkResult_Field]);
			////////////////////////////////////////////////////////////////////
			Col2List MyList = new Col2List(oEntry.Tables[WINWData.WDIW_TABLE]);
			oHT.Add("@SerialNoList", MyList.GetList(WINWData.SerialNo_Field));
			oHT.Add("@ItemCodeList", MyList.GetList(WINWData.ItemCode_Field));
			oHT.Add("@ItemNameList", MyList.GetList(WINWData.ItemName_Field));
			oHT.Add("@ItemSpecialList", MyList.GetList(WINWData.ItemSpec_Field));
			oHT.Add("@ItemUnitList", MyList.GetList(WINWData.ItemUnit_Field));
			oHT.Add("@ItemUnitNameList", MyList.GetList(WINWData.ItemUnitName_Field));
			oHT.Add("@PlanNumList", MyList.GetList(WINWData.PlanNum_Field));
			oHT.Add("@ItemNumList", MyList.GetList(WINWData.ItemNum_Field));
			oHT.Add("@ItemPriceList", MyList.GetList(WINWData.ItemPrice_Field));
			oHT.Add("@ItemMoneyList", MyList.GetList(WINWData.ItemMoney_Field));
			oHT.Add("@ItemFeeList", MyList.GetList(WINWData.ItemFee_Field));
			oHT.Add("@ItemSumList", MyList.GetList(WINWData.ItemSum_Field));
			oHT.Add("@ConCodeList", MyList.GetList(WINWData.ConCode_Field));
			oHT.Add("@ConNameList", MyList.GetList(WINWData.ConName_Field));
			////////////////////////////////////////////////////////////////////
			MyList = new Col2List(oEntry.Tables[WINWData.WRES_TABLE]);
			oHT.Add("@SourceEntryNoList", MyList.GetList(WINWData.SourceEntryNo_Field));
			oHT.Add("@SourceDocCodeList", MyList.GetList(WINWData.SourceDocCode_Field));
			oHT.Add("@SourceSerialNoList", MyList.GetList(WINWData.SouceSerialNo_Field));
			oHT.Add("@PSerialNoList", MyList.GetList(WINWData.PSerialNo_Field));
			oHT.Add("@ResSerialNoList", MyList.GetList(WINWData.ResSerialNo_Field));
			oHT.Add("@ResCodeList", MyList.GetList(WINWData.ResCode_Field));
			oHT.Add("@ResNameList", MyList.GetList(WINWData.ResName_Field));
			oHT.Add("@ResSpecialList", MyList.GetList(WINWData.ResSpecial_Field));
			oHT.Add("@ResUnitList", MyList.GetList(WINWData.ResUnit_Field));
			oHT.Add("@ResUnitNameList", MyList.GetList(WINWData.ResUnitName_Field));
			oHT.Add("@ResNumList", MyList.GetList(WINWData.ResNum_Field));
			oHT.Add("@ResPriceList", MyList.GetList(WINWData.ResPrice_Field));
			oHT.Add("@ResMoneyList", MyList.GetList(WINWData.ResMoney_Field));
			return oHT;
		}
		#endregion ˽�з���

		#region IInItems ��Ա
		/// <summary>
		/// ί��ӹ����ϵ����ӡ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertEntry(object Entry)
		{
			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWInsert",oHT);
			if(ret == false) this.Message = WINWData.ADD_FAILED;
			
			return ret;
		}

		/// <summary>
		/// ί��ӹ����ϵ����Ӳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresentEntry(object Entry)
		{
			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWInsertAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WINWData.ADD_FAILED;
			}
			else
			{
				this.Message = WINWData.ADD_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ί��ӹ����ϵ��޸ġ�
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateEntry(object Entry)
		{

			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWUpdate",oHT);
			if(ret == false)
			{
				this.Message = WINWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WINWData.UPDATE_SUCCESSED;
			}
			return ret;
		}

		/// <summary>
		/// ί��ӹ����ϵ��޸Ĳ��������ύ��
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresentEntry(object Entry)
		{
			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWUpdateAndPresent",oHT);
			if(ret == false)
			{
				this.Message = WINWData.UPDATE_FAILED;
			}
			else
			{
				this.Message = WINWData.UPDATE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ϡ�
		/// </summary>
		/// <param name="Entry"></param>
		/// <returns></returns>
		public bool StockIn(object Entry)
		{
			bool ret = true;
			WINWData oEntry = (WINWData)Entry;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(oEntry);

			ret = oSQLServer.ExecSP("Sto_WINWStockIn",oHT);
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
		/// ί��ӹ����ϵ�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����ϵ���ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool DeleteEntry(int EntryNo)
		{
			bool ret=true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Sto_WINWDelete", oHT);
			if(ret == false)
			{
				this.Message = WINWData.DELETE_FAILED;
			}
			else
			{
				this.Message = WINWData.DELETE_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ�һ��������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool FirstAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WINWData oEntry = (WINWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WINWData.WINW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[WINWData.EntryNo_Field]);
			oHT.Add("@EntryState",		oRow[WINWData.EntryState_Field]);
			oHT.Add("@Audit1",			oRow[WINWData.Audit1_Field]);
			oHT.Add("@Assessor1",		oRow[WINWData.Assessor1_Field]);
			oHT.Add("@AuditSuggest1",	oRow[WINWData.AuditSuggest1_Field]);
			oHT.Add("@UserLoginId",     oRow[WINWData.AuthorLoginID_Field]);

			ret = oSQLServer.ExecSP("Sto_WINWFirstAudit",oHT);

			if(ret == false)
			{
				this.Message = WINWData.FIRSTAUDIT_FAILED;
			}
			else
			{
				this.Message = WINWData.FIRSTAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ�����������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool SecondAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WINWData oEntry= (WINWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WINWData.WINW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[WINWData.EntryNo_Field]);
			oHT.Add("@EntryState",		oRow[WINWData.EntryState_Field]);
			oHT.Add("@Audit2",			oRow[WINWData.Audit2_Field]);
			oHT.Add("@Assessor2",		oRow[WINWData.Assessor2_Field]);
			oHT.Add("@AuditSuggest2",	oRow[WINWData.AuditSuggest2_Field]);
			oHT.Add("@UserLoginId",     oRow[WINWData.AuthorLoginID_Field]);

			ret = oSQLServer.ExecSP("Sto_WINWSecondAudit",oHT);
			if(ret == false)
			{
				this.Message = WINWData.SECONDAUDIT_FAILED;
			}
			else
			{
				this.Message = WINWData.SECONDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ�����������
		/// </summary>
		/// <param name="Entry">object:	ί��ӹ����ϵ�ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ThirdAudit(object Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT=new Hashtable();
			WINWData oEntry= (WINWData)Entry;
			DataRow oRow;
			oRow=oEntry.Tables[WINWData.WINW_TABLE].Rows[0];

			oHT.Add("@EntryNo",			oRow[WINWData.EntryNo_Field]);
			oHT.Add("@EntryState",		oRow[WINWData.EntryState_Field]);
			oHT.Add("@Audit3",			oRow[WINWData.Audit3_Field]);
			oHT.Add("@Assessor3",		oRow[WINWData.Assessor3_Field]);
			oHT.Add("@AuditSuggest3",	oRow[WINWData.AuditSuggest3_Field]);
			oHT.Add("@UserLoginId",     oRow[WINWData.AuthorLoginID_Field]);

			ret = oSQLServer.ExecSP("Sto_WINWThirdAudit",oHT);
			if(ret == false)
			{
				this.Message = WINWData.THIRDAUDIT_FAILED;
			}
			else
			{
				this.Message = WINWData.THIRDAUDIT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����ϵ���ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <param name="UserLoginId">string:	�û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret=true;
			Hashtable oHT=new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo",EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Sto_WINWPresent",oHT);
			if(ret == false)
			{
				this.Message = WINWData.PRESENT_FAILED;
			}
			else
			{
				this.Message = WINWData.PRESENT_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ί��ӹ����ϵ����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	ί��ӹ����ϵ���ˮ�š�</param>
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
			
			ret = oSQLServer.ExecSP("Sto_WINWCancel",oHT);
			if(ret == false)
			{
				this.Message = WINWData.CANCEL_FAILED;
			}
			else
			{
				this.Message = WINWData.CANCEL_SUCCESSED;
			}
			return ret;
		}
		/// <summary>
		/// ���ݵ�����ˮ�Ż�ȡ���ݡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>object:	ί��ӹ����ϵ�ʵ�塣</returns>
		public object GetEntryByEntryNo(int EntryNo)
		{
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo",EntryNo);

			oSQLServer.ExecSPReturnDS("Sto_WINWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
			oSQLServer.ExecSPReturnDS("Sto_WDIWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WDIW_TABLE]);
			oSQLServer.ExecSPReturnDS("Sto_WRESGetByEntryNo", oHT, oWINWData.Tables[WINWData.WRES_TABLE]);
			return oWINWData;
		}

        /// <summary>
        /// ���ݵ�����ˮ�Ż�ȡ���ݡ�
        /// </summary>
        /// <param name="EntryNo">int:	������ˮ�š�</param>
        /// <returns>object:	ί��ӹ����ϵ�ʵ�塣</returns>
        public object GetEntryOldByEntryNo(int EntryNo)
        {
            WINWData oWINWData = new WINWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_WINWOldGetByEntryNo", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
           return oWINWData;
        }


        public object GetEntryRedByEntryNo(int EntryNo)
        {
            WINWData oWINWData = new WINWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EntryNo", EntryNo);

            oSQLServer.ExecSPReturnDS("Sto_WINWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
            oSQLServer.ExecSPReturnDS("Sto_WDIWRedGetByEntryNo", oHT, oWINWData.Tables[WINWData.WDIW_TABLE]);
            oSQLServer.ExecSPReturnDS("Sto_WRESRedGetByEntryNo", oHT, oWINWData.Tables[WINWData.WRES_TABLE]);
            return oWINWData;
        }

		/// <summary>
		/// �����û���ȡ���е����б�
		/// </summary>
		/// <param name="UserLoginId">string:	�û���¼����</param>
		/// <returns>object:	ί��ӹ����ϵ�ʵ�塣</returns>
		public object GetEntryAll(string UserLoginId)
		{
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);

			oSQLServer.ExecSPReturnDS("Sto_WINWGetAll",oHT,oWINWData.Tables[WINWData.WINW_TABLE]);
			return oWINWData;
		}

        /// <summary>
        /// �����û���ȡ���е����б�
        /// </summary>
        /// <param name="UserLoginId">string:	�û���¼����</param>
        /// <returns>object:	ί��ӹ����ϵ�ʵ�塣</returns>
        public object GetEntryByPerson(string EmpCode)
        {
            WINWData oWINWData = new WINWData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Sto_WINWGetByPerson", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
            return oWINWData;
        }
		#endregion

		#region ר�з���
        ///// <summary>
        ///// ���ݸ����ݱ�Ż�ȡ���ֵ���
        ///// </summary>
        ///// <param name="EntryNo">int:	��������ˮ�š�</param>
        ///// <returns>object:	ί��ӹ����ϵ�ʵ�塣</returns>
        //public object GetEntryRedByEntryNo(int EntryNo)
        //{
        //    WINWData oWINWData = new WINWData();
        //    SQLServer oSQLServer = new SQLServer();
        //    Hashtable oHT = new Hashtable();
        //    oHT.Add("@EntryNo",EntryNo);
        //    oSQLServer.ExecSPReturnDS("Sto_WINWRed",oHT,oWINWData.Tables[WINWData.WINW_TABLE]);
        //    return oWINWData;
        //}
		/// <summary>
		/// ��ȡ���õ�ί�����뵥����Դ��
		/// </summary>
		/// <param name="EntryNos">string:	��ˮ�Ŵ���</param>
		/// <param name="PSerialNo">int:	��Լ�¼�š�</param>
		/// <returns>object��	ʵ�塣</returns>
		public object GetWTOWValidDataByEntryNos(string EntryNos,int PSerialNo)
		{
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNos", EntryNos);
			oHT.Add("@PSerialNo", PSerialNo);
			//oSQLServer.ExecSPReturnDS("Sto_WINWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WINW_TABLE]);
			//oSQLServer.ExecSPReturnDS("Sto_WDIWGetByEntryNo", oHT, oWINWData.Tables[WINWData.WDIW_TABLE]);
			oSQLServer.ExecSPReturnDS("Sto_WTOWGetValidDataByEntryNos", oHT, oWINWData.Tables[WINWData.WRES_TABLE]);
			return oWINWData;
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
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oWINWData.Tables[WINWData.WINW_TABLE]);
			return oWINWData;
		}
		public object GetEntryByDeptAndAuthorAndAuditResult(string AuthorDept, string AuthorCode, int AuditResult,DateTime StartDate,DateTime EndDate)
		{
			WINWData oWINWData = new WINWData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@AuthorDept",AuthorDept);
			oHT.Add("@AuthorCode",AuthorCode);
			oHT.Add("@AuditResult", AuditResult);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);

			oSQLServer.ExecSPReturnDS("Sto_WINWGetByDeptAndAuthorAndAuditResult",oHT,oWINWData.Tables[WINWData.WINW_TABLE]);
			return oWINWData;
		}
		#endregion
	}
	#endregion public class WINWs
}
