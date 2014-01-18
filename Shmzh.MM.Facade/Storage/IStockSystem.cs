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


namespace Shmzh.MM.Facade
{
	using System;
	using Shmzh.MM.Common;
	using Shmzh.MM.DataAccess;
	using Shmzh.MM.BusinessRules;
	/// <summary>
	/// IStockSystem ��ժҪ˵����
	/// </summary>
	public interface IStockSystem
	{
		/// <summary>
		/// ��ȡָ���ֿ�Ŀ�档
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <returns>StockData:	���ʵ�塣</returns>
		StockData GetStockByStoCode(string StoCode);
		/// <summary>
		/// ��ñ�����档
		/// </summary>
		/// <returns>StockData:	���ʵ�塣</returns>
		StockData GetStockByWarning();
		/// <summary>
		/// ��ȡ�ֿ�����Ϻϼƿ�档
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <returns>StockData:	���ʵ�塣</returns>
		StockData GetStockSumByStoCode(string StoCode);
		/// <summary>
		/// �������ϱ�źͼ�λ��Ż�ȡ�������ڸü�λ���ܵĿ������
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ConCode">int:	��λ��š�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
		StockData GetStockSumByItemCodeAndConCode(string ItemCode, int ConCode);
		/// <summary>
		/// ����ʱ��ȡ��ѡ��Ŀ��ʵ�塣
		/// </summary>
		/// <param name="DocCode">int:	�������ͺš�</param>
		/// <param name="EntryNo">int:	������ˮ�š�</param>
		/// <param name="SerialNoList">string:	������ϸ˳��š�</param>
		/// <param name="ItemCodeList">string:	������ϸ���ϱ�š�</param>
		/// <param name="ItemNumList">string:	������ϸ����������</param>
		/// <returns>StockChoiceData:	���ѡ���嵥ʵ�塣</returns>
		StockChoiceData GetStockChoice(int DocCode, int EntryNo,string SerialNoList, string ItemCodeList, string ItemNumList);
		/// <summary>
		/// ��淢�ϡ�
		/// </summary>
		/// <param name="EntryNo">int:	���ϵ���ˮ�š�</param>
		/// <param name="SerialNoList">string:	���ϵ���ϸ˳��š�</param>
		/// <param name="ItemNumList">string:	���ϵ���ϸ��������</param>
		/// <param name="PKIDList">string:	���ID����</param>
		/// <param name="ItemDrawNumList">string:	���۳�������</param>
		/// <returns>bool:	���ϳɹ�����true��ʧ�ܷ���false��</returns>
		bool DrawOutStock(int EntryNo,string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId);
	}
}
