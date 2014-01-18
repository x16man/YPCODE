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

namespace Shmzh.MM.Common
{
	using System;
	using System.Data;
	/// <summary>
	/// Col2List 类，主要是提供将DataTable中的列进行字符串连接和求和的功能。
	/// </summary>
	public class Col2List
	{
		#region 成员变量
		private DataTable DT;
		#endregion

		#region 构造函数
		public Col2List()
		{}
		public Col2List( DataTable oDataTable )
		{
			DT = oDataTable;
		}
		#endregion

		#region 公开方法
		/// <summary>
		/// 将行号组织成一个字符串。
		/// </summary>
		/// <returns>string：	以逗号为分割符的行号的字符串。</returns>
		public string GetList()
		{
			string retList = "";
			if (DT != null)
			{
				for (int i = 0; i < DT.Rows.Count; i++)
				{
					retList += retList.Length == 0 ? i.ToString(): ","+i.ToString();
				}
			}
			return retList;
		}
		/// <summary>
		/// 将指定的列的值连成一个字符串。
		/// </summary>
		/// <param name="ColName">string:	列名。</param>
		/// <returns>string：	以逗号为分割符的列值的字符串。</returns>
		public string GetList(string ColName)
		{
			string retList = "";
			if (DT != null)
			{
				for (int i = 0; i < DT.Rows.Count; i++)
				{
					if (DT.Rows[i][ColName] == DBNull.Value)
					{
						retList += i == 0 ? "":",";
					}
					else
					{
						retList += i == 0 ? DT.Rows[i][ColName].ToString():","+DT.Rows[i][ColName].ToString();
					}
				}
			}
			return retList;
		}
		/// <summary>
		/// 取得某一列的总和值。
		/// </summary>
		/// <param name="ColName">string:	列名。</param>
		/// <returns>decimal:	某一列的求和值。</returns>
		public decimal GetSum(string ColName)
		{
			decimal retValue = 0;
			if (DT != null)
			{
				for (int i = 0; i < DT.Rows.Count; i++)
				{
					retValue += DT.Rows[i][ColName] == DBNull.Value ? 0:Convert.ToDecimal(DT.Rows[i][ColName].ToString());
				}
			}
			return retValue;
		}
		#endregion
	}
}
