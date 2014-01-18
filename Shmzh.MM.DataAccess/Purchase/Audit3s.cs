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
	/// Audit3s ��ժҪ˵����
	/// </summary>
	public class Audit3s
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
		/// ��ȡ�������������ĵ���ʵ�塣
		/// </summary>
		/// <returns>Audit3Data:���������ĵ���ʵ�塣	</returns>
		public Audit3Data GetAudit3DataToAudit(string UserLoginId)
		{
			Audit3Data oAudit3Data = new Audit3Data();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("Pur_Audit3GetByToAudit",oHT,oAudit3Data.Tables[Audit3Data.Audit3_Talbe]);
			return oAudit3Data;
		}
		/// <summary>
		/// ����SQL������������������ĵ���������
		/// </summary>
		/// <param name="SQL">string:	SQL��䡣</param>
		/// <returns>Audit3Data:���������ĵ���ʵ�塣</returns>
		public Audit3Data GetAudit3DataBySQL(string Sql_Statement)
		{
			Audit3Data oAudit3Data = new Audit3Data();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oAudit3Data.Tables[Audit3Data.Audit3_Talbe]);
			return oAudit3Data;
		}
		#endregion

		#region ���캯��
		public Audit3s()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
