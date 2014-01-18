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
	public interface IDeptSystem
	{
		DeptData GetDeptAll();
		DeptData GetDeptByCode(string Code);
		DeptData GetDeptByDescription(string Description);
		bool AddDept(DeptData myDeptData);
		bool UpdateDept(DeptData myDeptData);
		bool DeleteDept(DeptData myDeptData);
	}
}
