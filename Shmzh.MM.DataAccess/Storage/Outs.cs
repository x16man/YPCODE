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
**		�ļ�:	Outs.cs 
**		����:	Outs
**		����:	���ϵ����嵥�����ݷ��ʲ㡣	���������ϵ���ת�ⵥ���˿ⵥ��
**
**              
**		����: �ź�
**		����: 2005-07-27
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
	/// ���ϵ����嵥�����ݷ��ʲ㡣	���������ϵ���ת�ⵥ���˿ⵥ��
	/// </summary>
	public class Outs	: Messages
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
		/// ��ȡ���д����Ϻ��ѷ��ϵĵ��ݡ�
		/// </summary>
		/// <returns>OutData:	���ϵ����嵥������ʵ�塣</returns>
		public OutData GetOutDataAll()
		{
			OutData oOutData = new OutData();
			SQLServer oSQLServer = new SQLServer();

			oSQLServer.ExecSPReturnDS("Sto_OutDataGetAll",oOutData.Tables["ViewOUT"]);
			return oOutData;
		}
		/// <summary>
		/// ���ݲֿ����Ա��ȡ�����Ϻ��ѷ��ϵĵ��ݡ�
		/// </summary>
		/// <param name="UserCode">string:	��ǰ�û���š�</param>
		/// <returns>OutData:	���ϵ����嵥������ʵ�塣</returns>
		public OutData GetOutDataByStoManager(string UserCode)
		{
			OutData oOutData = new OutData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserCode",UserCode);

			oSQLServer.ExecSPReturnDS("Sto_OutDataGetByUserCode",oHT,oOutData.Tables["ViewOUT"]);
			return oOutData;
		}
		/// <summary>
		/// ���ݲֿ����Ա��ָ����״̬��ȡ���ϵ��ݵ��嵥��
		/// </summary>
		/// <param name="UserCode">string:	�û���š�</param>
		/// <param name="EntryState">string:	����״̬��</param>
		/// <returns>OutData:	���ϵ����嵥������ʵ�塣</returns>
		public OutData GetOutDataByStoManagerAndEntryState(string UserCode,string EntryState)
		{
			OutData oOutData = new OutData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserCode",UserCode);
			oHT.Add("@EntryState",EntryState);

			oSQLServer.ExecSPReturnDS("Sto_OutDataGetByUserCodeAndEntryState",oHT,oOutData.Tables["ViewOUT"]);
			return oOutData;
		}
		#endregion

		#region ���캯��
		public Outs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
