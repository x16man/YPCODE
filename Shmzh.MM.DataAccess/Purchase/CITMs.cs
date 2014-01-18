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

namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;

	/// <summary>
	/// CITMs 的摘要说明。
	/// </summary>
	public class CITMs
	{
		public CITMs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public object GetByRepCode(int RepCode)
		{
			CITMData oEntry = new CITMData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@RepCode", RepCode);
			oSQLServer.ExecSPReturnDS("Pur_CITMGetByRepCode", oHT, oEntry.Tables[CITMData.CITM_TABLE]);
			return oEntry;
		}
	}
}
