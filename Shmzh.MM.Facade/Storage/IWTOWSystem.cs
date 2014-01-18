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
	public interface IWTOWSystem
	{
		/// <summary>
		/// ί��ӹ����뵥�����ӡ�
		/// </summary>
		/// <param name="oEntry">WTOWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddWTOW(WTOWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥�����Ӳ����ύ��
		/// </summary>
		/// <param name="oEntry">WTOWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddAndPresentWTOW(WTOWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥���޸ġ�
		/// </summary>
		/// <param name="oEntry">WTOWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateWTOW(WTOWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥���޸Ĳ����ύ��
		/// </summary>
		/// <param name="oEntry">WTOWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateAndPresentWTOW(WTOWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥��ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeleteWTOW(int EntryNo);
		/// <summary>
		/// ί��ӹ����뵥���ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string: �û���¼����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentWTOW(int EntryNo,string UserLoginId);
		/// <summary>
		/// ί��ӹ����뵥�����ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelWTOW(int EntryNo);
		/// <summary>
		/// ί��ӹ����뵥�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WTOWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditWTOW(WTOWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥�Ĳ���������
		/// </summary>
		/// <param name="oEntry">WTOWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditWTOW(WTOWData oEntry);
		/// <summary>
		/// ί��ӹ����뵥�ĳ���������
		/// </summary>
		/// <param name="oEntry">WTOWData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditWTOW(WTOWData oEntry);
		/// <summary>
		/// ��ȡ����ί��ӹ����뵥��
		/// </summary>
		/// <returns>WTOWData:	����ʵ�塣</returns>
		WTOWData GetWTOWAll();
		/// <summary>
		/// ������ˮ�Ż�ȡί��ӹ����뵥��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WTOWData:	����ʵ�塣</returns>
		WTOWData GetWTOWByEntryNo(int EntryNo);
		/// <summary>
		/// ����״̬��ȡί��ӹ����뵥�嵥��
		/// </summary>
		/// <param name="EntryState">string:	״̬��</param>
		/// <returns>WTOWData:	ί��ӹ����뵥ʵ�塣</returns>
		WTOWData GetWTOWByState(string EntryState);
		/// <summary>
		/// ����ģʽ�µĸ�����ˮ�Ż�ȡί��ӹ����뵥��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>WTOWData:	����ʵ�塣</returns>
		WTOWData GetWTOWByEntryNoOutMode(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡί��ӹ����뵥��
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>WTOWData:	����ʵ�塣</returns>
		WTOWData GetWTOWByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡί��ӹ����뵥��
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>WTOWData:	����ʵ�塣</returns>
		WTOWData GetWTOWByDept(string DeptCode);
		/// <summary>
		/// ��ȡ��Ч��ί��ӹ����뵥�б�
		/// </summary>
		/// <returns>WTOWData:	����ʵ�塣</returns>
		WTOWData GetWTOWValidData();
	}
}
