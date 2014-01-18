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
	using System.Data.SqlClient;
	using System.Configuration ;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// MAIOs ��ժҪ˵����
	/// </summary>
	public class MAIOs : Messages
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
		//
		//TODO: ����˴���˽�з�����
		//
		#endregion

		#region ��������
		/// <summary>
		/// ��������̵����ݡ�
		/// </summary>
		/// <param name="oMAIOData">MAIOData:	����̵����ݼ���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Add( MAIOData oMAIOData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
			Hashtable oHT = new Hashtable ();
			SQLServer oSQLServer = new SQLServer ();
			oHT.Add("@ItemCode",	oMAIOData.ItemCode);
			oHT.Add("@ItemName",	oMAIOData.ItemName);
			oHT.Add("@ItemSpec",	oMAIOData.ItemSpec);
			oHT.Add("@UnitCode",	oMAIOData.UnitCode);
			oHT.Add("@UnitName",	oMAIOData.UnitName);
			oHT.Add("@StoCode",		oMAIOData.StoCode);
			oHT.Add("@StoName",		oMAIOData.StoName);
			oHT.Add("@ConName",		oMAIOData.ConName);
			oHT.Add("@BookNum",		oMAIOData.BookNum);
			oHT.Add("@BookPrice",	oMAIOData.BookPrice);
			//oHT.Add("@BookPrice",decimal.Parse(oMAIOData.Tables[0].Rows[0][MAIOData.BookPrice_Field].ToString()));
			oHT.Add("@ItemNum",		oMAIOData.ItemNum);
			oHT.Add("@AuthorCode",	oMAIOData.AuthorCode);
			oHT.Add("@AuthorName",	oMAIOData.AuthorName);

			if (oSQLServer.ExecSP("Sto_MAIOInsert",oHT))
			{
				this.Message = "����ɹ���";
				retValue = true;
			}
			else
			{
				this.Message = "����ʧ�ܣ�";
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// ����̵��¼�޸ġ�
		/// </summary>
		/// <param name="oMAIOData">MAIOData��	����̵��¼ʵ�塣</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ConName">string:	��λ���ơ�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(MAIOData oMAIOData,string StoCode, string ConName)
		{
			bool retValue;
			Hashtable oHT = new Hashtable();
			SQLServer oSQLServer = new SQLServer();
			oHT.Add("@ItemCode",	oMAIOData.ItemCode);
			oHT.Add("@ItemName",	oMAIOData.ItemName);
			oHT.Add("@ItemSpec",	oMAIOData.ItemSpec);
			oHT.Add("@UnitCode",	oMAIOData.UnitCode);
			oHT.Add("@UnitName",	oMAIOData.UnitName);
			oHT.Add("@StoCode",		oMAIOData.StoCode);
			oHT.Add("@StoName",		oMAIOData.StoName);
			oHT.Add("@ConName",		oMAIOData.ConName);
			oHT.Add("@BookNum",		oMAIOData.BookNum);
			oHT.Add("@BookPrice",	oMAIOData.BookPrice);
			//oHT.Add("@BookPrice",decimal.Parse(oMAIOData.Tables[0].Rows[0][MAIOData.BookPrice_Field].ToString()));
			oHT.Add("@ItemNum",		oMAIOData.ItemNum);
			oHT.Add("@AuthorCode",	oMAIOData.AuthorCode);
			oHT.Add("@AuthorName",	oMAIOData.AuthorName);
			oHT.Add("@OldStoCode",  StoCode);
			oHT.Add("@OldConName",	ConName);
			if (oSQLServer.ExecSP("Sto_MAIOUpdate",oHT))
			{
				this.Message = "����ɹ���";
				retValue = true;
			}
			else
			{
				this.Message = "����ʧ�ܣ�";
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// �������ϱ�Ųֿ��ż�λ���ƻ�ȡ����̵��¼��
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ConName">string:	��λ���ơ�</param>
		/// <returns>MAIOData:	����̵�����ʵ�塣</returns>
		public MAIOData GetMAIOByItemCodeAndStoCodeAndConName(string ItemCode, string StoCode, string ConName)
		{
			MAIOData oMAIOData = new MAIOData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			oHT.Add("@StoCode", StoCode);
			oHT.Add("@ConName", ConName);
			oSQLServer.ExecSPReturnDS("Sto_MAIOGetByItemCodeAndStoCodeAndConName",oHT,oMAIOData.Tables[MAIOData.MAIO_Table]);
			return oMAIOData;
		}
		/// <summary>
		/// �������ϱ�Ż�ȡ�̵��¼�嵥��
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <returns>MAIOData:	����̵�����ʵ�塣</returns>
		public MAIOData GetMAIOByItemCode(string ItemCode)
		{
			MAIOData oMAIOData = new MAIOData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			oSQLServer.ExecSPReturnDS("Sto_MAIOGetByItemCode",oHT,oMAIOData.Tables[MAIOData.MAIO_Table]);
			return oMAIOData;
		}
		#endregion

		#region ���캯��
		public MAIOs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
