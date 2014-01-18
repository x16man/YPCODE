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
	/// IPPRCSystem �ӿڵ�ժҪ˵����
	/// </summary>
	public interface IPPRCSystem
	{
		PPRCData GetPPRCAll();
		PPRCData GetPPRCByCode(int Code);
		bool AddPPRC(PPRCData myPPRCData);
		bool UpdatePPRC(PPRCData myPPRCData);
		bool DeletePPRC(PPRCData myPPRCData);
	}
}
