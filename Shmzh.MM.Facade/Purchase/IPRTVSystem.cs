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
	/// IPRTVSystem ��ժҪ˵����
	/// </summary>
	public interface IPRTVSystem
	{
		/// <summary>
		/// �ɹ����ϵ������ӡ�
		/// </summary>
		/// <param name="oEntry">PRTVData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddPRTV(PRTVData oEntry);
		/// <summary>
		/// �ɹ����ϵ����޸ġ�
		/// </summary>
		/// <param name="oEntry">PRTVData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdatePRTV(PRTVData oEntry,string strEmpCode);
		/// <summary>
		/// �ɹ����ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeletePRTV(int EntryNo,string strEmpCode);
		/// <summary>
		/// �ɹ����ϵ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentPRTV(int EntryNo, string UserLoginId,string strEmpCode);
		/// <summary>
		/// �ɹ����ϵ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelPRTV(int EntryNo,string strAuthorLoginId,string strEmpCode);
		/// <summary>
		/// �ɹ����ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">PRTVData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditPRTV(PRTVData oEntry);
		/// <summary>
		/// �ɹ����ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">PRTVData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditPRTV(PRTVData oEntry);
		/// <summary>
		/// �ɹ����ϵ��ĳ���������
		/// </summary>
		/// <param name="oEntry">PRTVData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditPRTV(PRTVData oEntry);
		/// <summary>
		/// ��ȡ���вɹ����ϵ���
		/// </summary>
		/// <returns>PRTVData:	����ʵ�塣</returns>
		PRTVData GetPRTVAll();
		/// <summary>
		/// ������ˮ�Ż�ȡ�ɹ����ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PRTVData:	����ʵ�塣</returns>
		PRTVData GetPRTVByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ�ɹ����ϵ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PRTVData:	����ʵ�塣</returns>
		PRTVData GetPRTVByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�ɹ����ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PRTVData:	����ʵ�塣</returns>
		PRTVData GetPRTVByDept(string DeptCode);
	}
}
