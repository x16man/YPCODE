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
	/// �������ϵ���ҵ����۲���Ҫʵ�ֵĽӿڡ�
	/// </summary>
	public interface IWRTSSystem
	{
		/// <summary>
		/// �������ϵ������ӡ�
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddWRTS(WRTSData oEntry);
		/// <summary>
		/// �������ϵ������Ӳ��������ύ��
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddAndPresentWRTS(WRTSData oEntry);
		/// <summary>
		/// �������ϵ����޸ġ�
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateWRTS(WRTSData oEntry);
		/// <summary>
		/// �������ϵ����޸Ĳ��������ύ��
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateAndPresentWRTS(WRTSData oEntry);
		/// <summary>
		/// �������ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteWRTS(int EntryNo);
		/// <summary>
		/// �������ϵ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentWRTS(int EntryNo,string UserLoginId);
		/// <summary>
		/// �������ϵ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelWRTS(int EntryNo);
		/// <summary>
		/// �������ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditWRTS(WRTSData oEntry);
		/// <summary>
		/// �������ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditWRTS(WRTSData oEntry);
		/// <summary>
		/// �������ϵ��ĳ���������
		/// </summary>
		/// <param name="oEntry">WRTSData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditWRTS(WRTSData oEntry);
		/// <summary>
		/// ��ȡ�����������ϵ���
		/// </summary>
		/// <returns>WRTSData:	����ʵ�塣</returns>
		WRTSData GetWRTSAll();
		/// <summary>
		/// ������ˮ�Ż�ȡ�������ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WRTSData:	����ʵ�塣</returns>
		WRTSData GetWRTSByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ�������ϵ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>WRTSData:	����ʵ�塣</returns>
		WRTSData GetWRTSByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�������ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WRTSData:	����ʵ�塣</returns>
		WRTSData GetWRTSByDept(string DeptCode);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="oEntry">WRTSData:	����ʵ�塣</param>
        /// <returns></returns>
		bool Check(WRTSData oEntry);
	}
}
