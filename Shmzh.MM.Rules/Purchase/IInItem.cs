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

namespace Shmzh.MM.BusinessRules
{
	using System;
	/// <summary>
	/// IInItem ��ժҪ˵����
	/// </summary>
	public interface IInItem
	{
		/// <summary>
		/// ����¼�롣
		/// </summary>
		/// <param name="Entry">object:	����ʵ�� ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool Insert(object Entry);
		/// <summary>
		/// �����޸ġ�
		/// </summary>
		/// <param name="Entry">object:	����ʵ�� ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool Update(object Entry);
		/// <summary>
		/// ����ɾ����
		/// </summary>
		/// <param name="Entry">int:	������ˮ�� ��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool Delete(int EntryNo);
		/// <summary>
		/// �����޸�״̬��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdateEntryState(int EntryNo,string newState);
		/// <summary>
		/// ����һ��������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAudit(object Entry);
		/// <summary>
		/// ���ݶ���������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAudit(object Entry);
		/// <summary>
		/// ��������������
		/// </summary>
		/// <param name="Entry">object:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAudit(object Entry);
		/// <summary>
		/// �����ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool Present(int EntryNo, string newState, string UserLoginId);
		/// <summary>
		/// �������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="newState">string:	��״̬��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool Cancel(int EntryNo, string newState);
		/// <summary>
		/// ���ݲɹ����뵥��ˮ�ţ���ȡ�ɹ����뵥������Ϣ��
		/// </summary>
		/// <param name="EntryNo">int:	�ɹ����뵥��ˮ�š�</param>
		/// <returns>object:	�ɹ����뵥����ʵ�塣</returns>
		object GetEntryByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݲɹ����뵥��ţ���ȡ�ɹ����뵥������Ϣ��
		/// </summary>
		/// <param name="EntryCode">string:	�ɹ����뵥��š�</param>
		/// <returns>object:	�ɹ����뵥����ʵ�塣</returns>
		object GetEntryByEntryCode(string EntryCode);
		/// <summary>
		/// ��ȡ���вɹ����뵥����Ϣ������������Ĳ�����Ϣ��
		/// </summary>
		/// <returns>object:	�ɹ����뵥����ʵ�塣</returns>
		object GetEntryAll();
		/// <summary>
		/// ��ȡָ�����벿�ŵĲɹ����뵥����Ϣ������������Ĳ�����Ϣ��
		/// </summary>
		/// <param name="DeptCode">string:	���ű�š�</param>
		/// <returns>object:	�ɹ����뵥����ʵ�塣</returns>
		object GetEntryByDept(string DeptCode);
	}
}
