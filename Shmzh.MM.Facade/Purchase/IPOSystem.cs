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
	/// IPOSystem ��ժҪ˵����
	/// </summary>
	public interface IPOSystem
	{
		/// <summary>
		/// �ɹ����������ӡ�
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddPO(PurchaseOrderData oEntry);
		/// <summary>
		/// �ɹ��������޸ġ�
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdatePO(PurchaseOrderData oEntry);
		/// <summary>
		/// �ɹ�������ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeletePO(int EntryNo);
		/// <summary>
		/// �ɹ��������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:	�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentPO(int EntryNo, string UserLoginId);
		/// <summary>
		/// �ɹ����������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelPO(int EntryNo);
		/// <summary>
		/// �ɹ������Ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditPO(PurchaseOrderData oEntry);
		/// <summary>
		/// �ɹ������Ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditPO(PurchaseOrderData oEntry);
		/// <summary>
		/// �ɹ������ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchaseOrderData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditPO(PurchaseOrderData oEntry);
		/// <summary>
		/// ��ȡ���вɹ�������
		/// </summary>
		/// <returns>PurchaseOrderData:	����ʵ�塣</returns>
		PurchaseOrderData GetPOAll();
		/// <summary>
		/// ������ˮ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PurchaseOrderData:	����ʵ�塣</returns>
		PurchaseOrderData GetPOByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PurchaseOrderData:	����ʵ�塣</returns>
		PurchaseOrderData GetPOByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PurchaseOrderData:	����ʵ�塣</returns>
		PurchaseOrderData GetPOByDept(string DeptCode);
		/// <summary>
		/// ��ȡ���вɹ�����������Դ��
		/// </summary>
		/// <returns>POSData:	������Դʵ�塣</returns>
		POSData GetPOSAll(string UserLoginId);
		/// <summary>
		/// ��ȡָ���ɹ�����������Դ��
		/// </summary>
		/// <param name="PKIDs">string:	ѡ�еĶ�����ԴPKID����</param>
		/// <returns>POSData:	������Դʵ�塣</returns>
		POSData GetPOSByPKIDs(string PKIDs);
		/// <summary>
		/// �ɹ�����ȷ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="EntryState">string:	����״̬��</param>
		/// <param name="UserLoginId">string:	�����û���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AffirmPO(int EntryNo,string EntryState, string UserLoginId);
	}
}
