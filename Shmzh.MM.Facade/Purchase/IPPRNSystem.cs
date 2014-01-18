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
	/// IPPRNSystem 接口的摘要说明。
	/// </summary>
	public interface IPPRNSystem
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		PPRNData GetPPRNAll();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		PPRNData GetPPRNByCode(string Code);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="CNName"></param>
		/// <returns></returns>
		PPRNData GetPPRNByCNName(string CNName);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ENName"></param>
		/// <returns></returns>
		PPRNData GetPPRNByENName(string ENName);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Type"></param>
		/// <param name="Status"></param>
		/// <param name="Approve"></param>
		/// <returns></returns>
		PPRNData GetPPRNByTypeAndStatusAndApprove(string Type, string Status,string Approve);
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		PPRNData GetPPRNSelf();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="myPPRNData"></param>
		/// <returns></returns>
		bool AddPPRN(PPRNData myPPRNData);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="myPPRNData"></param>
		/// <returns></returns>
		bool UpdatePPRN(PPRNData myPPRNData);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="myPPRNData"></param>
		/// <returns></returns>
		bool DeletePPRN(PPRNData myPPRNData);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Codes"></param>
		/// <returns></returns>
		bool DeletePPRN(string Codes);
	}
}
