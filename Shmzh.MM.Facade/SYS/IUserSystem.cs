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
	/// IDeptSystem 接口的摘要说明。
	/// </summary>
	public interface IUserSystem
	{
		/// <summary>
		/// 获取所有用户。
		/// </summary>
		/// <returns>UserData:	用户实体。</returns>
		UserData GetUserAll();
		/// <summary>
		/// 获取所有开放用户。
		/// </summary>
		/// <returns>UserData:	用户实体。</returns>
		UserData GetUserEnable();
		/// <summary>
		/// 根据用户编号获取用户。
		/// </summary>
		/// <param name="Code">string:	用户编号。</param>
		/// <returns>UserData:	用户实体。</returns>
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
