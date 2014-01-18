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
	/// IDeptSystem �ӿڵ�ժҪ˵����
	/// </summary>
	public interface IUserSystem
	{
		/// <summary>
		/// ��ȡ�����û���
		/// </summary>
		/// <returns>UserData:	�û�ʵ�塣</returns>
		UserData GetUserAll();
		/// <summary>
		/// ��ȡ���п����û���
		/// </summary>
		/// <returns>UserData:	�û�ʵ�塣</returns>
		UserData GetUserEnable();
		/// <summary>
		/// �����û���Ż�ȡ�û���
		/// </summary>
		/// <param name="Code">string:	�û���š�</param>
		/// <returns>UserData:	�û�ʵ�塣</returns>
		UserData GetUserByCode(string Code);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Dept"></param>
		/// <returns></returns>
		UserData GetUserByDept(string Dept);
		UserData GetUserByLoginName(string LoginName);
		
		bool AddUser(UserData myUserData);
		bool UpdateUser(UserData myUserData);
		bool DeleteUser(UserData myUserData);
		bool DeleteUser(string Codes);
		bool ChangePWD(UserData myUserData);
		bool EnableUser(UserData myUserData);
		bool DisableUser(UserData myUserData);
	}
}
