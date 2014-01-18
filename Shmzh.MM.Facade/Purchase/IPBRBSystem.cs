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
	/// IPBRBSystem ��ժҪ˵����
	/// </summary>
	public interface IPBRBSystem
	{
		/// <summary>
		/// ���������������ӡ�
		/// </summary>
		/// <param name="oEntry">PBRBData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddPBRB(PBRBData oEntry);
		/// <summary>
		/// �������������޸ġ�
		/// </summary>
		/// <param name="oEntry">PBRBData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdatePBRB(PBRBData oEntry);
		/// <summary>
		/// ������������ɾ����
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeletePBRB(int EntryNo);
		/// <summary>
		/// �������������ύ��
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool PresentPBRB(int EntryNo, string UserLoginId);
		/// <summary>
		/// ���������������ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="UserLoginId">string:�û�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool CancelPBRB(int EntryNo, string UserLoginId);
		/// <summary>
		/// �����������Ĳ���������
		/// </summary>
		/// <param name="oEntry">PBRBData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool FirstAuditPBRB(PBRBData oEntry);
		/// <summary>
		/// �����������Ĳ���������
		/// </summary>
		/// <param name="oEntry">PBRBData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool SecondAuditPBRB(PBRBData oEntry);
		/// <summary>
		/// �����������ĳ���������
		/// </summary>
		/// <param name="oEntry">PBRBData:	����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool ThirdAuditPBRB(PBRBData oEntry);
		/// <summary>
		/// ��ȡ����������������
		/// </summary>
		/// <returns>PBRBData:	����ʵ�塣</returns>
		PBRBData GetPBRBAll(string UserLoginId);
		/// <summary>
		/// ������ˮ�Ż�ȡ������������
		/// </summary>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <returns>PBRBData:	����ʵ�塣</returns>
		PBRBData GetPBRBByEntryNo(int EntryNo);
		/// <summary>
		/// ���ݱ�Ż�ȡ������������
		/// </summary>
		/// <param name="EntryCode">string:	���ݱ�š�</param>
		/// <returns>PBRBData:	����ʵ�塣</returns>
		PBRBData GetPBRBByEntryCode(string EntryCode);
		/// <summary>
		/// �����Ƶ����ű�Ż�ȡ������������
		/// </summary>
		/// <param name="DeptCode">string:	�Ƶ����ű�š�</param>
		/// <returns>PBRBData:	����ʵ�塣</returns>
		PBRBData GetPBRBByDept(string DeptCode);
	}
}
