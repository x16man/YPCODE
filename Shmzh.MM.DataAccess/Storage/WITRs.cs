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
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;
	/// <summary>
	/// WITRs ��ժҪ˵����
	/// </summary>
	public class WITRs :Messages
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
		private Hashtable FillHashTable(WITRData oData)
		{
			Hashtable oHT = new Hashtable();
			DataRow oRow;
			
			oRow = oData.Tables[WITRData.WITR_Table].Rows[0];
			oHT.Add("@PKID", oRow[WITRData.PKID_Field]);
			oHT.Add("@AuthorCode", oRow[WITRData.AuthorCode_Field]);
			oHT.Add("@AuthorName", oRow[WITRData.AuthorName_Field]);
			oHT.Add("@AuthorLoginID", oRow[WITRData.AuthorLoginID_Field]);
			oHT.Add("@AuthorDept", oRow[WITRData.AuthorDept_Field]);
			oHT.Add("@AuthorDeptName", oRow[WITRData.AuthorDeptName_Field]);
			oHT.Add("@ProposerCode", oRow[WITRData.ProposerCode_Field]);
			oHT.Add("@Proposer", oRow[WITRData.Proposer_Field]);
			oHT.Add("@ReqReasonCode", oRow[WITRData.ReqReasonCode_Field]);
			oHT.Add("@ReqReason", oRow[WITRData.ReqReason_Field]);
			oHT.Add("@ReqDate", oRow[WITRData.ReqDate_Field]);
			oHT.Add("@ItemCode", oRow[WITRData.ItemCode_Field]);
			oHT.Add("@ItemName", oRow[WITRData.ItemName_Field]);
			oHT.Add("@ItemSpec", oRow[WITRData.ItemSpec_Field]);
			oHT.Add("@UnitCode", oRow[WITRData.UnitCode_Field]);
			oHT.Add("@UnitName", oRow[WITRData.UnitName_Field]);
			oHT.Add("@ItemPrice", oRow[WITRData.ItemPrice_Field]);
			oHT.Add("@ItemNum", oRow[WITRData.ItemNum_Field]);
			oHT.Add("@ItemMoney", oRow[WITRData.ItemMoney_Field]);
			oHT.Add("@EntryState", oRow[WITRData.EntryState_Field]);
			oHT.Add("@Remark", oRow[WITRData.Remark_Field]);
			oHT.Add("@FeedBack", oRow[WITRData.FeedBack_Field]);
			oHT.Add("@DocCode", oRow[WITRData.DocCode_Field]);
			return oHT;
		}
		#endregion

		#region ��������
		/// <summary>
		/// �����������½���
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRInsert", oHT);
			if (ret == false)
			{
				this.Message = "�������ļ�������������ʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// �����������޸ġ�
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool	Update(WITRData oData) 
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRUpdate", oHT);
			if (ret == false)
			{
				this.Message = "�������ļ�������������ʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// �������ύ.
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Present(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRPresent", oHT);
			if (ret == false)
			{
				this.Message = "�������ļ����������ύʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// �����������½��������ύ.
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool InsertAndPresent(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRInsertAndPresent", oHT);
			if (ret == false)
			{
				this.Message = "�������ļ������������������ύʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// �����������޸Ĳ������ύ��
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool UpdateAndPresent(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRUpdateAndPresent", oHT);
			if (ret == false)
			{
				this.Message = "������������༭�����ύʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// �������������롣
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Cancel(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRCancel", oHT);
			if (ret == false)
			{
				this.Message = "����������������ʧ�ܣ�";
			}
			return ret;
		}  
		/// <summary>
		/// ɾ�����������롣
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRDelete", oHT);
			if (ret == false)
			{
				this.Message = "�������ļ���������ɾ��ʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// ����������ȷ�ϡ�
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Affirm(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRAffirm", oHT);
			if (ret == false)
			{
				this.Message = "�������ļ���������ȷ��ʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// ����������ܾ�.
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Refuse(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITRRefuse", oHT);
			if (ret == false)
			{
				this.Message = "�������ļ����������˻�ʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// ����������ת�ɲɹ����뵥.
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ToPros(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);
			SQLServer oSQLServer = new SQLServer();

			ret = oSQLServer.ExecSP("Sto_WITR2PROS", oHT);
			if (ret == false)
			{
				this.Message = "�������ļ���������ת�����깺��ʧ�ܣ�";
			}
			return ret;
		}
		/// <summary>
		/// ����������ת���¶ȼƻ�����
		/// </summary>
		/// <param name="oData">WITRData:	��������������ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool ToMRP(WITRData oData)
		{
			bool ret = true;
			Hashtable oHT = this.FillHashTable(oData);

			SQLServer oSQLServer = new SQLServer();
			ret = oSQLServer.ExecSP("Sto_WITR2PMRP", oHT);
			if (ret==false)
			{
				this.Message = "�������ļ���������ת�¶ȼƻ�����ʧ��";
			}
			return ret;
		}
		/// <summary>
		/// ��ȡ������������.
		/// </summary>
		/// <returns>WITRData:	��������������ʵ�塣</returns>
		public WITRData GetWITRALL()
		{
			WITRData oData = new WITRData();

			new SQLServer().ExecSPReturnDS("Sto_WITRGetALL",oData.Tables[WITRData.WITR_Table]);
			return oData;
		}
		/// <summary>
		/// ����PKID ��ȡ��������.
		/// </summary>
		/// <param name="PKID">��������ID.</param>
		/// <returns>WITRData:	��������������ʵ�塣</returns>
		public WITRData GetWITRByPKID(Int64 PKID)
		{
			WITRData oData = new WITRData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID", PKID);
			new SQLServer().ExecSPReturnDS("Sto_WITRGetByPKID",oHT,oData.Tables[WITRData.WITR_Table]);	
			return oData;
		}

		#endregion

		#region ���캯��
		public WITRs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
