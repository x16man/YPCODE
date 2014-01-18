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
	/// Col2List �࣬��Ҫ���ṩ��DataTable�е��н����ַ������Ӻ���͵Ĺ��ܡ�
	/// </summary>
	public class Col2List
	{
		#region ��Ա����
		private DataTable DT;
		#endregion

		#region ���캯��
		public Col2List()
		{}
		public Col2List( DataTable oDataTable )
		{
			DT = oDataTable;
		}
		#endregion

		#region ��������
		/// <summary>
		/// ���к���֯��һ���ַ�����
		/// </summary>
		/// <returns>string��	�Զ���Ϊ�ָ�����кŵ��ַ�����</returns>
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
		/// ��ָ�����е�ֵ����һ���ַ�����
		/// </summary>
		/// <param name="ColName">string:	������</param>
		/// <returns>string��	�Զ���Ϊ�ָ������ֵ���ַ�����</returns>
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
		/// ȡ��ĳһ�е��ܺ�ֵ��
		/// </summary>
		/// <param name="ColName">string:	������</param>
		/// <returns>decimal:	ĳһ�е����ֵ��</returns>
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
