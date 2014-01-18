//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Data.SqlClient;
	using System.Configuration ;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// 采购员数据访问层。
	/// </summary>
	public class Pslps : Messages
	{
		public Pslps()
		{		}
		/// <summary>
		///  获得所有采购员信息。
		/// </summary>
		/// <returns>PslpData:	采购员数据实体。</returns>
		public PslpData GetPslpAll ()
		{
			PslpData ds = new PslpData ();
			SQLServer mysp = new SQLServer ();

			if (!mysp.ExecSPReturnDS("Pur_PslpGetAll",ds.Tables [PslpData.PSLP_TABLE]))
			{
				this.Message = PPRNData.QUERY_FAILED;
			}
			return ds;
		}

        /// <summary>
        ///  获得所有采购员信息。
        /// </summary>
        /// <returns>PslpData:	采购员数据实体。</returns>
        public PslpData GetPslpAllCode()
        {
            PslpData ds = new PslpData();
            SQLServer mysp = new SQLServer();

            if (!mysp.ExecSPReturnDS("Pur_PslpGetAllCode", ds.Tables[PslpData.PSLP_TABLE]))
            {
                this.Message = PPRNData.QUERY_FAILED;
            }
            return ds;
        }

		/// <summary>
		/// 根据采购员代码获得采购员信息。
		/// </summary>
		/// <param name="Code">string:	采购员代码。</param>
		/// <returns>PslpData:	采购员数据集。</returns>
		public PslpData GetPslpByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PslpData myDS = new PslpData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Pur_PslpGetByCode", myHT, myDS.Tables [PslpData.PSLP_TABLE]))
			{
				this.Message = PslpData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 采购员 增加。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Add(PslpData myPslpData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Code",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.CODE_FIELD].ToString());				//采购员代码。
			myHT.Add ("@Description",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.DESCRIPTION_FIELD].ToString());			//采购员姓名。
			myHT.Add ("@Locked",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.LOCKED_FIELD].ToString());			//锁定。

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PslpInsert",myHT))
			{
				this.Message = PslpData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PslpData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// 采购员 修改。
		/// </summary>
		/// <param name="myPPRNData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(PslpData myPslpData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@OldCode", myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.OLDCODE_FIELD].ToString());			//修改前的代码。
			myHT.Add ("@Code",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.CODE_FIELD].ToString());					//修改后的代码。
			myHT.Add ("@Description",myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.DESCRIPTION_FIELD].ToString());	//采购员姓名。
			
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PslpUpdate",myHT))
			{
				this.Message = PslpData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PslpData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 采购员 删除。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(PslpData myPslpData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Code", myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0][PslpData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PslpDelete",myHT))
			{
				this.Message = PslpData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PslpData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 根据采购员代码字符串进行供应商删除。
		/// </summary>
		/// <param name="Codes">string:	采购员字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Codes", Codes);

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PslpDeleteByCodes",myHT))
			{
				this.Message = PslpData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PslpData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
	}
}
