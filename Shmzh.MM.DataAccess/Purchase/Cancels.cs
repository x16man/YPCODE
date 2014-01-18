#region ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved

#region �ĵ���Ϣ
/******************************************************************************
**		�ļ�: 
**		����: 
**		����: 
**
**              
**		����: �ź�
**		����: 
*******************************************************************************
**		�޸���ʷ
*******************************************************************************
**		����:		����:		����:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion �ĵ���Ϣ


namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
	using System.Collections;
	using MZHCommon.Database;
    using Shmzh.MM.Common;
	/// <summary>
	/// Cancels ��ժҪ˵����
	/// </summary>
	public class Cancels : Messages
	{
		#region ��Ա����
		//
		//TODO: �ڴ˴���ӳ�Ա������
		//
		#endregion

		#region ����
		//
		//TODO: �ڴ˴�������ԡ�
		//
		#endregion
		
		#region ˽�з���
		private Hashtable FillHashTable(CancelData oEntry)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;
			oRow = oEntry.Tables[CancelData.PCOR_Table].Rows[0];
			//����ģʽ�����ֶΡ�
			oHT.Add("@EntryNo", oRow[CancelData.EntryNo_Field]); //������ˮ�š�
			oHT.Add("@EntryCode", oRow[CancelData.EntryCode_Field]); //���ݱ�š�
			oHT.Add("@DocCode", oRow[CancelData.DocCode_Field]); //�������͡�
			oHT.Add("@DocName", oRow[CancelData.DocName_Field]); //�����������ơ�
			oHT.Add("@DocNo", oRow[CancelData.DocNo_Field]); //���������ĵ���š�
			oHT.Add("@EntryState", oRow[CancelData.EntryState_Field]); //����״̬��
			oHT.Add("@EntryDate", oRow[CancelData.EntryDate_Field]); //�Ƶ����ڡ�
			oHT.Add("@AuthorCode", oRow[CancelData.AuthorCode_Field]); //�Ƶ��˱�š�
			oHT.Add("@AuthorName", oRow[CancelData.AuthorName_Field]); //�Ƶ������ơ�
			oHT.Add("@AuthorLoginID", oRow[CancelData.AuthorLoginID_Field]); //�Ƶ��˵�¼����
			oHT.Add("@AuthorDept", oRow[CancelData.AuthorDept_Field]); //�Ƶ��˲��š�
			oHT.Add("@AuthorDeptName", oRow[CancelData.AuthorDeptName_Field]); //�Ƶ��˲������ơ�
			oHT.Add("@Remark", oRow[CancelData.Remark_Field]); //��ע��

			oHT.Add("@SerialNoList", oRow[CancelData.SerialNo_Field]); //������ϸ����˳��š�
			oHT.Add("@SourceEntryList", oRow[CancelData.SourceEntry_Field]); //
			oHT.Add("@SourceDocCodeList", oRow[CancelData.SourceDocCode_Field]); //
			oHT.Add("@SourceSerialNoList", oRow[CancelData.SourceSerialNo_Field]); //
			oHT.Add("@ItemCodeList", oRow[CancelData.ItemCode_Field]); //���ϵ��ۡ�
			oHT.Add("@ItemNameList", oRow[CancelData.ItemName_Field]); //����������
			oHT.Add("@ItemSpecList", oRow[CancelData.ItemSpec_Field]); //���Ͻ�
			oHT.Add("@ItemUnitList", oRow[CancelData.ItemUnit_Field]); //���ϵ�λ��
			oHT.Add("@ItemUnitNameList", oRow[CancelData.ItemUnitName_Field]); //���ϵ�λ������
			oHT.Add("@ItemPriceList", oRow[CancelData.ItemPrice_Field]);
			oHT.Add("@ItemNumList", oRow[CancelData.ItemNum_Field]);
			oHT.Add("@ItemMoneyList", oRow[CancelData.ItemMoney_Field]);
			return oHT;
		}
		#endregion

		#region ��������
		public bool InsertEntry(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = this.FillHashTable(Entry);

				ret = oSQLServer.ExecSP("Pur_CancelInsert", oHT);
				if (ret == false)
				{
					this.Message = "�ɹ��������½�ʧ�ܣ�";
				}
				else
				{
					this.Message = "�ɹ��������½��ɹ���";
				}
			}
			else
			{
				ret = false;
				this.Message = "�ն���";
			}
			return ret;
		}
		public bool InsertAndPresentEntry(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = this.FillHashTable(Entry);

				ret = oSQLServer.ExecSP("Pur_CancelInsertAndPresent", oHT);
				if (ret == false)
				{
					this.Message = "�ɹ��������½�ʧ�ܣ�";
				}
				else
				{
					this.Message = "�ɹ��������½��ɹ���";
				}
			}
			else
			{
				ret = false;
				this.Message = "�ն���";
			}
			return ret;
		}
		public bool UpdateEntry(CancelData Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(Entry);

			ret = oSQLServer.ExecSP("Pur_CancelUpdate", oHT);
			if (ret == false)
			{
				this.Message = "�ɹ��������޸�ʧ�ܣ�";
			}
			else
			{
				this.Message = "�ɹ��������޸ĳɹ���";
			}
			return ret;
		}
		public bool UpdateAndPresentEntry(CancelData Entry)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = this.FillHashTable(Entry);

			ret = oSQLServer.ExecSP("Pur_CancelUpdateAndPresent", oHT);
			if (ret == false)
			{
				this.Message = "�ɹ��������޸�ʧ��!";
			}
			else
			{
				this.Message = "�ɹ��������޸ĳɹ�!";
			}
			return ret;
		}
		public bool DeleteEntry(int EntryNo)
		{
			bool ret = true;
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			ret = oSQLServer.ExecSP("Pur_CancelDelete", oHT);
			if (ret == false)
			{
				this.Message = "�ɹ�������ɾ��ʧ�ܣ�";
			}
			else
			{
				this.Message = "�ɹ�������ɾ���ɹ���";
			}
			return ret;
		}
		public bool FirstAudit(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				DataRow oRow;
				oRow = Entry.Tables[CancelData.PCOR_Table].Rows[0];

				oHT.Add("@EntryNo", oRow[CancelData.EntryNo_Field]);
				oHT.Add("@EntryState", oRow[CancelData.EntryState_Field]);
				oHT.Add("@Audit1", oRow[CancelData.Audit1_Field]);
				oHT.Add("@Assessor1", oRow[CancelData.Assessor1_Field]);
				oHT.Add("@AuditSuggest1", oRow[CancelData.AuditSuggest1_Field]);
				oHT.Add("@UserLoginId", oRow[CancelData.AuthorLoginID_Field]);

				ret = oSQLServer.ExecSP("Pur_CancelFirstAudit", oHT);
				if (ret == false)
				{
					this.Message = "�ɹ�������һ������ʧ�ܣ�";
				}
				else
				{
					this.Message = "�ɹ�������һ�������ɹ���"  ;
				}
			}
			else
			{
				ret = false;
				this.Message = "�ն���!";
			}
			return ret;
		}
		public bool SecondAudit(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				DataRow oRow;
				oRow = Entry.Tables[CancelData.PCOR_Table].Rows[0];

				oHT.Add("@EntryNo", oRow[CancelData.EntryNo_Field]);
				oHT.Add("@EntryState", oRow[CancelData.EntryState_Field]);
				oHT.Add("@Audit2", oRow[CancelData.Audit2_Field]);
				oHT.Add("@Assessor2", oRow[CancelData.Assessor2_Field]);
				oHT.Add("@AuditSuggest2", oRow[CancelData.AuditSuggest2_Field]);
				oHT.Add("@UserLoginId", oRow[CancelData.AuthorLoginID_Field]);

				ret = oSQLServer.ExecSP("Pur_CancelSecondAudit", oHT);
				if (ret == false)
				{
					this.Message = "�ɹ���������������ʧ�ܣ�";
				}
				else
				{
					this.Message = "�ɹ����������������ɹ���"  ;
				}
			}
			else
			{
				ret = false;
				this.Message = "�ն���!";
			}
			return ret;
		}
		public bool ThirdAudit(CancelData Entry)
		{
			bool ret = true;
			if (Entry != null)
			{
				SQLServer oSQLServer = new SQLServer();
				Hashtable oHT = new Hashtable();
				DataRow oRow;
				oRow = Entry.Tables[CancelData.PCOR_Table].Rows[0];

				oHT.Add("@EntryNo", oRow[CancelData.EntryNo_Field]);
				oHT.Add("@EntryState", oRow[CancelData.EntryState_Field]);
				oHT.Add("@Audit3", oRow[CancelData.Audit3_Field]);
				oHT.Add("@Assessor3", oRow[CancelData.Assessor3_Field]);
				oHT.Add("@AuditSuggest3", oRow[CancelData.AuditSuggest3_Field]);
				oHT.Add("@UserLoginId", oRow[CancelData.AuthorLoginID_Field]);

				ret = oSQLServer.ExecSP("Pur_CancelThirdAudit", oHT);
				if (ret == false)
				{
					this.Message = "�ɹ���������������ʧ�ܣ�";
				}
				else
				{
					this.Message = "�ɹ����������������ɹ���";
				}
			}
			else
			{
				ret = false;
				this.Message = "�ն���!";
			}
			return ret;
		}
		public bool Present(int EntryNo, string newState, string UserLoginId)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginId", UserLoginId);

			ret = oSQLServer.ExecSP("Pur_CancelPresent", oHT);
			if (ret == false)
			{
				this.Message = "�ɹ��������ύʧ�ܣ�";
			}
			else
			{
				this.Message = "�ɹ��������ύ�ɹ���";
			}
			return ret;
		}
		public bool Cancel(int EntryNo, string newState, string UserLoginID)
		{
			bool ret = true;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@EntryState", newState);
			oHT.Add("@UserLoginID", UserLoginID);
			ret = oSQLServer.ExecSP("Pur_CancelCancel", oHT);
			if (ret == false)
			{
				this.Message = "�ɹ�����������ʧ�ܣ�";
			}
			else
			{
				this.Message = "�ɹ����������ϳɹ�";
			}
			return ret;
		}
		public CancelData GetEntryByEntryNo(int EntryNo)
		{
			CancelData oCancelData = new CancelData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);

			oSQLServer.ExecSPReturnDS("Pur_CancelGetByEntryNo", oHT, oCancelData.Tables[CancelData.PCOR_Table]);
			return oCancelData;
		}
		public CancelData GetEntryAll(string UserLoginId)
		{
			CancelData oCancelData = new CancelData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId", UserLoginId);

			oSQLServer.ExecSPReturnDS("Pur_CancelGetAll", oHT, oCancelData.Tables[CancelData.PCOR_Table]);
			return oCancelData;
		}

        public CancelData GetEntryByPerson(string EmpCode)
        {
            CancelData oCancelData = new CancelData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@EmpCode", EmpCode);

            oSQLServer.ExecSPReturnDS("Pur_CancelGetByPerson", oHT, oCancelData.Tables[CancelData.PCOR_Table]);
            return oCancelData;
        }

		public CancelData GetEntryBySQL(string Sql_Statement)
		{
			CancelData oCancelData = new CancelData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement", Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL", oHT, oCancelData.Tables[CancelData.PCOR_Table]);
			return oCancelData;
		}
		#endregion

		#region ���캯��
		public Cancels()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
