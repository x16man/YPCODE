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
	/// �������󵥵�ҵ����۲���Ҫʵ�ֵĽӿڡ�
	/// </summary>
	public interface IPMRPSystem
	{
		/// <summary>
		/// �������󵥵����ӡ�
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddPMRP(PMRPData oEntry);
		/// <summary>
		/// �������󵥵��޸ġ�
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdatePMRP(PMRPData oEntry);
		/// <summary>
		/// �������󵥵�ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeletePMRP(int EntryNo);
		/// <summary>
		/// �������󵥵��ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentPMRP(int EntryNo, String UserLoginId);
		/// <summary>
		/// �������󵥵����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelPMRP(int EntryNo);
		/// <summary>
		/// �������󵥵Ĳ���������
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditPMRP(PMRPData oEntry);
		/// <summary>
		/// �������󵥵Ĳ���������
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditPMRP(PMRPData oEntry);
		/// <summary>
		/// �������󵥵ĳ���������
		/// </summary>
		/// <param name="oEntry">PMRPData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditPMRP(PMRPData oEntry);
		/// <summary>
		/// ��ȡ�����������󵥡�
		/// </summary>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		PMRPData GetPMRPAll();
		/// <summary>
		/// ������ˮ�Ż�ȡ�������󵥡�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		PMRPData GetPMRPByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ�������󵥡�
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		PMRPData GetPMRPByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�������󵥡�
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PMRPData:	����ʵ�塣</returns>
		PMRPData GetPMRPByDept(string DeptCode);
	}
}
