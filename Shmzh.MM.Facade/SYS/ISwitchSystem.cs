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


namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// ISwitchSystem ��ժҪ˵����
	/// </summary>
	public interface ISwitchSystem
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
		/// �Ƿ����Ʋɹ�����������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		bool IsOrdNumLimit();
		/// <summary>
		/// �Ƿ����Ʋɹ����ϵ������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		bool IsBorItemLimit();
		/// <summary>
		/// �Ƿ����Ʋɹ����ϵ��������������
		/// </summary>
		/// <returns>bool:	���Ʒ���true�������Ʒ���false��</returns>
		bool IsBorNumLimit();
		#endregion
	}
}
