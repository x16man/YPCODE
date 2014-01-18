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
	/// IPslpSystem 接口的摘要说明。
	/// </summary>
	public interface IPslpSystem
	{
		/// <summary>
		/// 获取所有采购员。
		/// </summary>
		/// <returns>PslpData:	采购员数据实体。</returns>
		PslpData GetPslpAll();
		/// <summary>
		/// 根据采购员代码获取采购员。
		/// </summary>
		/// <param name="Code">string:	采购员代码。</param>
		/// <returns>PslpData:	采购员数据实体。</returns>
		PslpData GetPslpByCode(string Code);
		/// <summary>
		/// 采购员增加。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool AddPslp(PslpData myPslpData);
		/// <summary>
		/// 采购员修改。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool UpdatePslp(PslpData myPslpData);
		/// <summary>
		/// 采购员单条记录删除。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeletePslp(PslpData myPslpData);
		/// <summary>
		/// 采购员多条记录删除。
		/// </summary>
		/// <param name="Codes">string:	采购员代码字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		bool DeletePslp(string Codes);
	}
}
