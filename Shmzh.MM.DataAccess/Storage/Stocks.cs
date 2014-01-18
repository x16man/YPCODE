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
	/// Stocks ��ժҪ˵����
	/// </summary>
	public class Stocks : Messages
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region ����
		/// <summary>
		/// ���ݲֿ�Ż�ÿ�森
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��ţ�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
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
		/// ���ݼ�λ�Ż�ȡ����¼��
		/// </summary>
		/// <param name="ConCode">int:	��λ�š�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
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
		/// ��ȡ�Ϳ�汨�����嵥��
		/// </summary>
		/// <returns>StockData:	�������ʵ�壮</returns>
		public StockData GetWarningStock()
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("Sto_StockGetWarning",oStockData.Tables[StockData.WSTKWARNING_TABLE]);
			return oStockData;
		}
		/// <summary>
		/// ��ȡ�߿�汨�����嵥��
		/// </summary>
		/// <returns>StockData:	�������ʵ�壮</returns>
		public StockData GetUppWarningStock()
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			
			oSQLServer.ExecSPReturnDS("Sto_StockGetUppWarning",oStockData.Tables[StockData.WSTKWARNING_TABLE]);
			return oStockData;
		}
		/// <summary>
		/// ���ĳһ���ֿ�����ϵĺϼƿ�档
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
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
		/// �������ϵ�ʹ��Ƶ������ȡ������ݡ�
		/// </summary>
		/// <returns>StockData:	�������ʵ�壮</returns>
		public StockData GetStockByUseCount()
		{
			StockData oStockData = new StockData();
			SQLServer oSQLServer = new SQLServer();
			

			oSQLServer.ExecSPReturnDS("Sto_StockGetByUseCount",oStockData.Tables[StockData.WSTK_TABLE]);
			return oStockData;
		}

        /// <summary>
        /// �½��Ŀ����
        /// </summary>
        /// <param name="beginDate">��ʼ����</param>
        /// <param name="endDate">��������</param>
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
        /// ��������
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
		/// �������ϱ�źͼ�λ��Ż�ȡ�������ڸü�λ���ܵĿ������
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ConCode">int:	��λ��š�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
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
		/// ����ָ���ֿ��������Ϣ��ȡ������ݡ�
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ItemName">string :	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns>StockData:	�������ʵ�壮</returns>
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
		/// ��ȡ���ϵ��ܿ�档
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ItemName">string:	�������ơ�</param>
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
		/// �½�.
		/// </summary>
		/// <param name="Year">int:��</param>
		/// <param name="Month">int:��</param>
		/// <returns>bool:	�½�ɹ�����true,ʧ�ܷ���false.</returns>
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

		#region ͨ�ò�ѯ
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

		#region ���캯��
		public Stocks()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

	}
}
