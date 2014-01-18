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
	/// Switchs ��ժҪ˵����
	/// </summary>
	public class Switchs
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
		/// <summary>
		/// �Ƿ��������ƹ��ܿ顣
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		private bool FunctionEnable(string FunctionID)
		{
			SwitchData oData = new SwitchData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@FunctionID",FunctionID);
			oSQLServer.ExecSPReturnDS("Sys_SwitchGetByFunctionID",oHT,oData.Tables[SwitchData.Switch_Table]);
			if (oData.Count > 0)
			{
				if (Convert.ToInt32(oData.Tables[SwitchData.Switch_Table].Rows[0][SwitchData.Enable_Field].ToString()) == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		#endregion

		#region ��������
		/// <summary>
		/// �Ƿ����Ʋɹ�������������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		public bool OrdNumEnable()
		{
			return this.FunctionEnable("OrdNum");
		}
		/// <summary>
		/// �Ƿ����Ʋɹ����ϵ��������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		public bool BorItemEnable()
		{
			return this.FunctionEnable("BorItem");
		}
		/// <summary>
		/// �Ƿ����Ʋɹ����ϵ���������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		public bool BorNumEnable()
		{
			return this.FunctionEnable("BorNum");
		}
		#endregion

		#region ���캯��
		public Switchs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
