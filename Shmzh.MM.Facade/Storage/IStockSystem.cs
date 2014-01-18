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
	/// IStockSystem 的摘要说明。
	/// </summary>
	public interface IStockSystem
	{
		/// <summary>
		/// 获取指定仓库的库存。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <returns>StockData:	库存实体。</returns>
		StockData GetStockByStoCode(string StoCode);
		/// <summary>
		/// 获得报警库存。
		/// </summary>
		/// <returns>StockData:	库存实体。</returns>
		StockData GetStockByWarning();
		/// <summary>
		/// 获取仓库的物料合计库存。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <returns>StockData:	库存实体。</returns>
		StockData GetStockSumByStoCode(string StoCode);
		/// <summary>
		/// 根据物料编号和架位编号获取该物料在该架位的总的库存数。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="ConCode">int:	架位编号。</param>
		/// <returns>StockData:	库存数据实体．</returns>
		StockData GetStockSumByItemCodeAndConCode(string ItemCode, int ConCode);
		/// <summary>
		/// 发料时获取可选择的库存实体。
		/// </summary>
		/// <param name="DocCode">int:	单据类型号。</param>
		/// <param name="EntryNo">int:	单据流水号。</param>
		/// <param name="SerialNoList">string:	单据明细顺序号。</param>
		/// <param name="ItemCodeList">string:	单据明细物料编号。</param>
		/// <param name="ItemNumList">string:	单据明细发料数量。</param>
		/// <returns>StockChoiceData:	库存选择清单实体。</returns>
		StockChoiceData GetStockChoice(int DocCode, int EntryNo,string SerialNoList, string ItemCodeList, string ItemNumList);
		/// <summary>
		/// 库存发料。
		/// </summary>
		/// <param name="EntryNo">int:	领料单流水号。</param>
		/// <param name="SerialNoList">string:	领料单明细顺序号。</param>
		/// <param name="ItemNumList">string:	领料单明细发料数。</param>
		/// <param name="PKIDList">string:	库存ID串。</param>
		/// <param name="ItemDrawNumList">string:	库存扣除数串。</param>
		/// <returns>bool:	发料成功返回true，失败返回false。</returns>
		bool DrawOutStock(int EntryNo,string SerialNoList, string ItemNumList, string PKIDList, string ItemDrawNumList, string UserCode, string UserName, string UserLoginId);
	}
}
