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
	/// INs ��ժҪ˵����
	/// </summary>
	public class INs : Messages
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
		/// ��ȡ���еȴ����ĵ����嵥��
		/// </summary>
		/// <returns>InData:	�����ϵ����嵥ʵ�塣</returns>
		public InData GetInDataAll()
		{
			InData oInData = new InData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Pur_InDataGetAll",oInData.Tables["ViewIN"]);
			return oInData;
		}
		/// <summary>
		/// ���ݲֿ����Ա��ȡ�������嵥��
		/// </summary>
		/// <param name="UserCode">string:	�ֿ����Ա��š�</param>
		/// <returns>InData:	�����ϵ����嵥ʵ�塣</returns>
		public InData GetInDataByStoManager(string UserCode)
		{
			InData oInData = new InData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserCode",		UserCode);
			oSQLServer.ExecSPReturnDS("Pur_InDataGetByStoManager",oHT, oInData.Tables["ViewIN"]);
			return oInData;
		}
		/// <summary>
		/// ���ݲֿ����Ա���ƶ�����״̬��ȡ���ϵ����嵥��
		/// </summary>
		/// <param name="UserCode">string:	�û���š�</param>
		/// <param name="EntryState">string:	����״̬��</param>
		/// <returns>InData:	�����ϵ����嵥ʵ�塣</returns>
		public InData GetInDataByStoManagerAndEntryState(string UserCode, string EntryState)
		{
			InData oInData = new InData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserCode", UserCode);
			oHT.Add("@EntryState",EntryState );
			oSQLServer.ExecSPReturnDS("Pur_InDataGetByStoManagerAndEntryState",oHT, oInData.Tables["ViewIn"]);
			return oInData;
		}
		#endregion

		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		public INs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
