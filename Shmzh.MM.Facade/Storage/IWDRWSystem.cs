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
	/// ���ϵ���ҵ����۲���Ҫʵ�ֵĽӿڡ�
	/// </summary>
	public interface IWDRWSystem
	{
		/// <summary>
		/// ���ϵ������ӡ�
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddWDRW(WDRWData oEntry);
		/// <summary>
		/// ���ϵ������Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddAndPresentWDRW(WDRWData oEntry);
		/// <summary>
		/// ���ϵ����޸ġ�
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateWDRW(WDRWData oEntry);
		/// <summary>
		/// ���ϵ����޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateAndPresentWDRW(WDRWData oEntry);
		/// <summary>
		/// ���ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteWDRW(int EntryNo);
		/// <summary>
		/// ���ϵ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentWDRW(int EntryNo,string UserLoginId);
		/// <summary>
		/// ���ϵ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelWDRW(int EntryNo);
		/// <summary>
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditWDRW(WDRWData oEntry);
		/// <summary>
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditWDRW(WDRWData oEntry);
		/// <summary>
		/// ���ϵ��ĳ���������
		/// </summary>
		/// <param name="oEntry">WDRWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditWDRW(WDRWData oEntry);
		/// <summary>
		/// ��ȡ�������ϵ���
		/// </summary>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		WDRWData GetWDRWAll();
		/// <summary>
		/// ������ˮ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		WDRWData GetWDRWByEntryNo(int EntryNo);
		/// <summary>
		/// ����״̬��ȡ���ϵ��嵥��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>WDRWData:	���ϵ�ʵ�塣</returns>
		WDRWData GetWDRWByState(string EntryState);
		/// <summary>
		/// ����ģʽ�µĸ�����ˮ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		WDRWData GetWDRWByEntryNoOutMode(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		WDRWData GetWDRWByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WDRWData:	����ʵ�塣</returns>
		WDRWData GetWDRWByDept(string DeptCode);
		/// <summary>
		/// �������벿�Ż�ȡ���ϵ�Դ�����б�
		/// </summary>
		/// <param name="DeptCode">string:	���벿�ű�š�</param>
		/// <returns>WDRWData:	���ϵ�����Դʵ�塣</returns>
		WDRWData GetWDRWSourceListByDeptCode(string DeptCode);
		/// <summary>
		/// ������ѡ��Դ���ݻ�ȡ�õ��ݵĿ�����ϸ���ݡ�
		/// </summary>
		/// <param name="PKIDs">string:	PKIDs</param>
		/// <returns>WDRWData:	���ϵ�����ʵ�塣</returns>
		WDRWData GetWDRWSourceDetailByPKIDs(string PKIDs);
		/// <summary>
		/// ������Ϣ������ID���������ϵ�ʵ�塣
		/// </summary>
		/// <param name="PKIDs">string:	��Ϣ����IDs��</param>
		/// <returns>WDRWData:	���ϵ�����ʵ�塣</returns>
		WDRWData GetWDRWByFeedbackIDs(string PKIDs);
	}
}
