using System;
using System.Data;
using System.Collections;
using MZHCommon.Database;
using Shmzh.MM.Common;
using System.Data.Common;
using System.Data.SqlClient;

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
	/// <summary>
	/// Stocks 的摘要说明。
	/// </summary>
	public class Stocks : Messages
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region 方法
		/// <summary>
		/// 根据仓库号获得库存．
		/// </summary>
		/// <param name="StoCode">string:	仓库编号．</param>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetStockByStoCode(string  StoCode)
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@StoCode",StoCode);

			oSQLServer.ExecSPReturnDS("Sto_StockGetByStoCode",oHT,oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}
		/// <summary>
		/// 根据架位号获取库存记录。
		/// </summary>
		/// <param name="ConCode">int:	架位号。</param>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetStockByConCode(int ConCode)
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ConCode",ConCode);

			oSQLServer.ExecSPReturnDS("Sto_StockGetByConCode",oHT,oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}
		/// <summary>
		/// 获取低库存报警的清单。
		/// </summary>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetWarningStock()
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("Sto_StockGetWarning",oStockData.Tables[StockData.WSTKWARNING_TABLE]);
			return oStockData;
		}
		/// <summary>
		/// 获取高库存报警的清单。
		/// </summary>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetUppWarningStock()
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("Sto_StockGetUppWarning",oStockData.Tables[StockData.WSTKWARNING_TABLE]);
			return oStockData;
		}
		/// <summary>
		/// 获得某一个仓库的物料的合计库存。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetStockSumByStoCode(string StoCode)
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@StoCode",StoCode);

			oSQLServer.ExecSPReturnDS("Sto_StockSumGetByStoCode",oHT,oStockData.Tables[StockData.WSTKWARNING_TABLE]);
			return oStockData;
		}
		
		/// <summary>
		/// 根据物料的使用频度来获取库存数据。
		/// </summary>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetStockByUseCount()
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			

			oSQLServer.ExecSPReturnDS("Sto_StockGetByUseCount",oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}

        /// <summary>
        /// 月结科目保存
        /// </summary>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>bool</returns>
        public bool YJKM(DateTime beginDate, DateTime endDate)
        {
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@BeginDate", beginDate);
            oHT.Add("@EndDate", endDate);
            //string str=oSQLServer.ToString();
            //			oSQLServer.ExecSPReturnDS("Fin_OutFJHZB_SetKM",);
            return oSQLServer.ExecSP("Fin_OutFJHZB_SetKM", oHT);

        }

        /// <summary>
        /// 增量保存
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool YJKMNoNull(DateTime beginDate, DateTime endDate)
        {
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@BeginDate", beginDate);
            oHT.Add("@EndDate", endDate);
            //string str=oSQLServer.ToString();
            //			oSQLServer.ExecSPReturnDS("Fin_OutFJHZB_SetKM",);
            return oSQLServer.ExecSP("Fin_OutFJHZB_SetKM_KM1NoNull", oHT);

        }

		/// <summary>
		/// 根据物料编号和架位编号获取该物料在该架位的总的库存数。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="ConCode">int:	架位编号。</param>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetStockSumByItemCodeAndConCode(string ItemCode,int ConCode)
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			oHT.Add("@ConCode", ConCode);

			oSQLServer.ExecSPReturnDS("Sto_StockGetSumByItemCodeAndConCode",oHT,oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}
		/// <summary>
		/// 根据指定仓库和物料信息获取库存数据。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="ItemName">string :	物料名称。</param>
		/// <param name="ItemSpec">string:	规格型号。</param>
		/// <returns>StockData:	库存数据实体．</returns>
		public StockData GetStockSumByStoCodeAndItem(string StoCode, string ItemCode, string ItemName, string ItemSpec)
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@StoCode", StoCode);
			oHT.Add("@ItemCode", ItemCode);
			oHT.Add("@ItemName", ItemName);
			oHT.Add("@ItemSpec", ItemSpec);

			oSQLServer.ExecSPReturnDS("Sto_StockGetSumByStoCodeAndItem",oHT,oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}
		/// <summary>
		/// 获取物料的总库存。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <param name="ItemName">string:	物料名称。</param>
		/// <param name="ItemSpec"></param>
		/// <returns></returns>
		
		public StockData GetStockSumByItem(string ItemCode,string ItemName, string ItemSpec)
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			oHT.Add("@ItemName", ItemName);
			oHT.Add("@ItemSpec", ItemSpec);

			oSQLServer.ExecSPReturnDS("Sto_StockGetSumByItem",oHT,oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}

		/// <summary>
		/// 月结.
		/// </summary>
		/// <param name="Year">int:年</param>
		/// <param name="Month">int:月</param>
		/// <returns>bool:	月结成功返回true,失败返回false.</returns>
		public bool YJ(int Year, int Month)
		{
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Year", Year);
			oHT.Add("@Month", Month);

			return oSQLServer.ExecSP("Sto_SMRInsert",oHT);
		}

        public bool DeleteZeroStock(DbTransaction trans)
        {
            var sqlStatement = "Delete From WSTK Where ItemNum = 0 And ItemMoney=0";
            try
            {
                SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.Text, sqlStatement);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
		#endregion 

		#region 通用查询
		public StockData GetStockBySQL(string  Sql_Statement)
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}
		public StockData GetStockByTop(int top)
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@top",top);

			oSQLServer.ExecSPReturnDS("Sto_StockGetByTop",oHT,oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}
		#endregion

		#region 构造函数
		public Stocks()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

	}
}
