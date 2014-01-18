using System.Collections;
using MZHCommon.Database;
using Shmzh.MM.Common;
//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// Stos 的摘要说明。
	/// </summary>
	public class Stos : Messages
	{
		public Stos()
		{		}
		/// <summary>
		/// 获得所有仓库。
		/// </summary>
		/// <returns>StoData:	仓库数据实体。</returns>
		public StoData GetStoAll()
		{
			StoData myDS = new StoData ();

			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoGetAll", myDS.Tables [StoData.STO_TABLE]))
			{
				this.Message = StoData.QUERY_FAILED;
			}
			return myDS;
		}

        /// <summary>
        /// 获得所有仓库。
        /// </summary>
        /// <returns>StoData:	仓库数据实体。</returns>
        public StoData GetStoAllCode()
        {
            StoData myDS = new StoData();

            SQLServer mySP = new SQLServer();
            if (!mySP.ExecSPReturnDS("Sto_StoGetAllCode", myDS.Tables[StoData.STO_TABLE]))
            {
                this.Message = StoData.QUERY_FAILED;
            }
            return myDS;
        }

		/// <summary>
		/// 根据仓库编号获得仓库信息。
		/// </summary>
		/// <param name="Code">string:	仓库编号。</param>
		/// <returns>StoData:	仓库数据实体。</returns>
		public StoData GetStoByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			StoData myDS = new StoData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoGetByCode", myHT, myDS.Tables [StoData.STO_TABLE]))
			{
				this.Message = StoData.QUERY_FAILED;
			}
			return myDS;
		}

        public StockData GetQueryStock(string LoginName)
        {
            StockData oStockData = new StockData();
            SQLServer oSQLServer = new SQLServer();
            Hashtable oHT = new Hashtable();
            oHT.Add("@UserLoginId", LoginName);


            oSQLServer.ExecSPReturnDS("Sto_StockQueryGetByItem", oHT, oStockData.Tables[StockData.WSTK_TABLE]);
            return oStockData;
        }

		/// <summary>
		/// 根据仓库名称查找仓库信息。
		/// </summary>
		/// <param name="Description">string:	仓库名称。</param>
		/// <returns>StoData:	仓库数据实体。</returns>
		public StoData GetStoByDescription(string Description)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			StoData myDS = new StoData ();

			myHT.Add ("@Description",Description);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoGetByDescription", myHT, myDS.Tables [StoData.STO_TABLE]))
			{
				this.Message = StoData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 仓库增加。
		/// </summary>
		/// <param name="myStoData">StoData:	架位数据实体。</param>
		/// <returns>bool:	增加成功返回true,失败返回false.</returns>
		public bool Add(StoData myStoData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@Code",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@Locked",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.LOCKED_FIELD].ToString());
			myHT.Add ("@StorageAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.STOACC_FIELD].ToString());
			myHT.Add ("@TransferAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.TRFACC_FIELD].ToString());
			myHT.Add ("@ReturnAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.RETURNACC_FIELD].ToString());
			myHT.Add ("@Address",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.ADDRESS_FIELD].ToString());
			myHT.Add ("@Relation",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.RELATION_FIELD].ToString());
			

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoInsert",myHT))
			{
				this.Message = StoData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// 仓库修改。
		/// </summary>
		/// <param name="myStoData">StoData:	仓库数据实体。</param>
		/// <returns>bool:	修改成功返回true，失败返回false。</returns>
		public bool Update(StoData myStoData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@Code",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@Locked",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.LOCKED_FIELD].ToString());
			myHT.Add ("@StorageAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.STOACC_FIELD].ToString());
			myHT.Add ("@TransferAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.TRFACC_FIELD].ToString());
			myHT.Add ("@ReturnAcc",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.RETURNACC_FIELD].ToString());
			myHT.Add ("@Address",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.ADDRESS_FIELD].ToString());
			myHT.Add ("@Relation",myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.RELATION_FIELD].ToString());
			
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoUpdate",myHT))
			{
				this.Message = StoData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 仓库删除。
		/// </summary>
		/// <param name="myStoData">StoData:	仓库数据实体。</param>
		/// <returns>bool:	删除成功返回true，失败返回false。</returns>
		public bool Delete(StoData myStoData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();
			myHT.Add ("@Code", myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoDelete",myHT))
			{
				this.Message = StoData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 根据传入的仓库代码串进行删除。
		/// </summary>
		/// <param name="Codes">string:	仓库代码字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable();
            myHT.Add("@Code", Codes);
			SQLServer mySP = new SQLServer ();
            if (mySP.ExecSP("Sto_StoDelete", myHT))
			{
				this.Message = StoData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = mySP.ExceptionMessage;
				retValue = false;
			}
			return retValue;
		}
	}
}
