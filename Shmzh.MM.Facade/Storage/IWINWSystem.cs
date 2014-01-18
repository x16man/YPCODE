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

namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// ί��ӹ����뵥��ҵ����۲���Ҫʵ�ֵĽӿڡ�
	/// </summary>
	public interface IWINWSystem
	{
		/// <summary>
		/// ί��ӹ����뵥�����ӡ�
		/// </summary>
		/// <param name="oEntry">WINWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddWINW(WINWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥�����Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">WINWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddAndPresentWINW(WINWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥���޸ġ�
		/// </summary>
		/// <param name="oEntry">WINWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateWINW(WINWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥���޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">WINWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateAndPresentWINW(WINWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteWINW(int EntryNo, string UserLoginId);
		/// <summary>
		/// ί��ӹ����뵥���ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string: �û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentWINW(int EntryNo,string UserLoginId);
		/// <summary>
		/// ί��ӹ����뵥�����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelWINW(int EntryNo, string UserLoginId);
		/// <summary>
		/// ί��ӹ����뵥�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WINWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditWINW(WINWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WINWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditWINW(WINWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥�ĳ���������
		/// </summary>
		/// <param name="oEntry">WINWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditWINW(WINWData oEntry);
		/// <summary>
		/// ί��ӹ����ϵ����ϡ�
		/// </summary>
		/// <param name="oEntry">WINWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool StockInWINW(WINWData oEntry);
		/// <summary>
		/// ��ȡ����ί��ӹ����뵥��
		/// </summary>
		/// <returns>WINWData:	����ʵ�塣</returns>
		WINWData GetWINWAll(string UserLoginId);
		/// <summary>
		/// ������ˮ�Ż�ȡί��ӹ����뵥��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WINWData:	����ʵ�塣</returns>
		WINWData GetWINWByEntryNo(int EntryNo);
		/// <summary>
		/// ����SQL����ȡί��ӹ����ϵ���
		/// </summary>
		/// <param name="SQL_Statement">string:	SQL��䡣</param>
		/// <returns>WINWData:	����ʵ�塣</returns>
		WINWData GetWINWBySQL(string SQL_Statement);
	}
}
