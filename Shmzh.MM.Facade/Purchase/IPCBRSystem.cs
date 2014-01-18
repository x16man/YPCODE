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
	/// �������յ���ҵ����۲���Ҫʵ�ֵĽӿڡ�
	/// </summary>
	public interface IPCBRSystem
	{
		/// <summary>
		/// �������յ������ӡ�
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddPCBR(PCBRData oEntry);
		/// <summary>
		/// �������յ����޸ġ�
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdatePCBR(PCBRData oEntry);
		/// <summary>
		/// �������յ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeletePCBR(int EntryNo);
		/// <summary>
		/// �������յ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentPCBR(int EntryNo, string UserLoginId);
		/// <summary>
		/// �������յ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelPCBR(int EntryNo);
		/// <summary>
		/// �������յ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditPCBR(PCBRData oEntry);
		/// <summary>
		/// �������յ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditPCBR(PCBRData oEntry);
		/// <summary>
		/// �������յ��ĳ���������
		/// </summary>
		/// <param name="oEntry">PCBRData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditPCBR(PCBRData oEntry);
		/// <summary>
		/// ��ȡ�����������յ���
		/// </summary>
		/// <returns>PCBRData:	����ʵ�塣</returns>
		PCBRData GetPCBRAll();
		/// <summary>
		/// ������ˮ�Ż�ȡ�������յ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PCBRData:	����ʵ�塣</returns>
		PCBRData GetPCBRByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ�������յ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PCBRData:	����ʵ�塣</returns>
		PCBRData GetPCBRByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�������յ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PCBRData:	����ʵ�塣</returns>
		PCBRData GetPCBRByDept(string DeptCode);
		/// <summary>
		/// ���ݹ�Ӧ�̻�ȡ���������ϵ���
		/// </summary>
		/// <param name="PrvCode">string:	��Ӧ�̱�š�</param>
		/// <returns>CBRSData:	���յ���Դʵ�塣</returns>
		CBRSData GetCBRSByPrvCode(string PrvCode);
		/// <summary>
		/// ���ݹ�Ӧ����ָ�������ڷ�Χ�ڻ�ȡ���������ϵ�
		/// </summary>
		/// <param name="PrvCode">string:	��Ӧ�̱�š�</param>
		/// <param name="StartDate">DateTime :	��ʼ���ڡ�</param>
		/// <param name="EndDate">DateTime:	�������ڡ�</param>
		/// <returns>CBRSData:	���յ���Դʵ�塣</returns>
		CBRSData GetCBRSByPrvCodeAndDate(string PrvCode, DateTime StartDate, DateTime EndDate);
	}
}
