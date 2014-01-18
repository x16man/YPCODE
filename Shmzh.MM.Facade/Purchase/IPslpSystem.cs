//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------

namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IPslpSystem �ӿڵ�ժҪ˵����
	/// </summary>
	public interface IPslpSystem
	{
		/// <summary>
		/// ��ȡ���вɹ�Ա��
		/// </summary>
		/// <returns>PslpData:	�ɹ�Ա����ʵ�塣</returns>
		PslpData GetPslpAll();
		/// <summary>
		/// ���ݲɹ�Ա�����ȡ�ɹ�Ա��
		/// </summary>
		/// <param name="Code">string:	�ɹ�Ա���롣</param>
		/// <returns>PslpData:	�ɹ�Ա����ʵ�塣</returns>
		PslpData GetPslpByCode(string Code);
		/// <summary>
		/// �ɹ�Ա���ӡ�
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool AddPslp(PslpData myPslpData);
		/// <summary>
		/// �ɹ�Ա�޸ġ�
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool UpdatePslp(PslpData myPslpData);
		/// <summary>
		/// �ɹ�Ա������¼ɾ����
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeletePslp(PslpData myPslpData);
		/// <summary>
		/// �ɹ�Ա������¼ɾ����
		/// </summary>
		/// <param name="Codes">string:	�ɹ�Ա�����ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		bool DeletePslp(string Codes);
	}
}
