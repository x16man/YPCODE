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
	/// IBRSystem ��ժҪ˵����
	/// </summary>
	public interface IBRSystem
	{
		/// <summary>
		/// ���ϵ������ӡ�
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddBR(BillOfReceiveData oEntry);
		/// <summary>
		/// ���ϵ����޸ġ�
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateBR(BillOfReceiveData oEntry);
		/// <summary>
		/// ���ϵ����ϡ�
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ReceiveBR(BillOfReceiveData oEntry);
		/// <summary>
		/// ���ϵ���ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteBR(int EntryNo);
		/// <summary>
		/// ���ϵ����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentBR(int EntryNo, string UserLoginId);
		/// <summary>
		/// ���ϵ������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelBR(int EntryNo);
		/// <summary>
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditBR(BillOfReceiveData oEntry);
		/// <summary>
		/// ���ϵ��Ĳ���������
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditBR(BillOfReceiveData oEntry);
		/// <summary>
		/// ���ϵ��ĳ���������
		/// </summary>
		/// <param name="oEntry">BillOfReceiveData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditBR(BillOfReceiveData oEntry);
		/// <summary>
		/// ��ȡ�������ϵ���
		/// </summary>
		/// <returns>BillOfReceiveData:	����ʵ�塣</returns>
		BillOfReceiveData GetBRAll();
		/// <summary>
		/// ����״̬��ȡ���ϵ��嵥��
		/// </summary>
		/// <param name="EntryState">string:	���ϵ�״̬��</param>
		/// <returns>BillOfReceiveData:	���ϵ�����ʵ�塣</returns>
		BillOfReceiveData GetBRByState(string EntryState);
		/// <summary>
		/// ������ˮ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>BillOfReceiveData:	����ʵ�塣</returns>
		BillOfReceiveData GetBRByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>BillOfReceiveData:	����ʵ�塣</returns>
		BillOfReceiveData GetBRByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ���ϵ���
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>BillOfReceiveData:	����ʵ�塣</returns>
		BillOfReceiveData GetBRByDept(string DeptCode);
	}
}
