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
	/// IPPSystem ��ժҪ˵����
	/// </summary>
	public interface IPPSystem
	{
		/// <summary>
		/// �ɹ��ƻ������ӡ�
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddPP(PurchasePlanData oEntry);
		/// <summary>
		/// �ɹ��������޸ġ�
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdatePP(PurchasePlanData oEntry);
		/// <summary>
		/// �ɹ�������ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeletePP(int EntryNo);
		/// <summary>
		/// �ɹ��������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentPP(int EntryNo, string UserLoginId);
		/// <summary>
		/// �ɹ����������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelPP(int EntryNo);
		/// <summary>
		/// �ɹ������Ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditPP(PurchasePlanData oEntry);
		/// <summary>
		/// �ɹ������Ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditPP(PurchasePlanData oEntry);
		/// <summary>
		/// �ɹ������ĳ���������
		/// </summary>
		/// <param name="oEntry">PurchasePlanData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditPP(PurchasePlanData oEntry);
		/// <summary>
		/// ��ȡ���вɹ�������
		/// </summary>
		/// <returns>PurchasePlanData:	����ʵ�塣</returns>
		PurchasePlanData GetPPAll();
		/// <summary>
		/// ������ˮ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PurchaseOrderData:	����ʵ�塣</returns>
		PurchasePlanData GetPPByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PurchasePlanData:	����ʵ�塣</returns>
		PurchasePlanData GetPPByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ�ɹ�������
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PurchasePlanData:	����ʵ�塣</returns>
		PurchasePlanData GetPPByDept(string DeptCode);
		/// <summary>
		/// ��ȡ���вɹ�����������Դ��
		/// </summary>
		/// <returns></returns>
		PPSData GetPPSAll(string UserLoginId);
	}
}
