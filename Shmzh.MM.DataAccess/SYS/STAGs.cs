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
**		�ļ�: STAGs.cs
**		����: ���ݲɼ�ϵͳ������Ϣ�����ݷ��ʲ㡣
**		����: ��¼�����������漰�������ݲɼ�ϵͳ��������Ϣ��ȱʡ������Ϣ�Ͳֿ�
**			  ��Ϣ��
**              
**		����: �ź�
**		����: 2005-05-09
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
	/// STAGs ��ժҪ˵����
	/// </summary>
	public class STAGs : Messages
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
		public STAGData GetSTAGInfo ()
		{
			STAGData ds = new STAGData ();
			SQLServer mysp = new SQLServer ();

			if (!mysp.ExecSPReturnDS("Sys_STAGGetInfo",ds.Tables [STAGData.STAG_Table]))
			{
				this.Message = STAGData.QUERY_FAILED;
			}
			return ds;
		}
		#endregion

		#region ���캯��
		public STAGs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
