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
	/// StoCons 的摘要说明。
	/// </summary>
	public class StoCons : Messages
	{
		public StoCons()
		{		}
		/// <summary>
		/// 根据架位编号获得架位信息。
		/// </summary>
		/// <param name="Code">string:	架位编号。</param>
		/// <returns>StoConData:	架位数据集。</returns>
		public StoConData GetStoConByCode(int Code)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			StoConData myDS = new StoConData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoConGetByCode", myHT, myDS.Tables [StoConData.STOCON_TABLE]))
			{
				this.Message = StoConData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据架位名称获得架位信息。
		/// </summary>
		/// <param name="Description">string:	架位名称。</param>
		/// <returns>StoConData:	架位数据集。</returns>
		public StoConData GetStoConByDescription(string Description)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			StoConData myDS = new StoConData ();

			myHT.Add ("@Description",Description);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoConGetByDescription", myHT, myDS.Tables [StoConData.STOCON_TABLE]))
			{
				this.Message = StoConData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据仓库编号获得架位数据实体。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <returns>StoConData:	仓库架位数据实体。</returns>
		public StoConData GetStoConByStoCode(string StoCode)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			StoConData myDS = new StoConData ();

			myHT.Add ("@StoCode",StoCode);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoConGetByStoCode", myHT, myDS.Tables [StoConData.STOCON_TABLE]))
			{
				this.Message = StoConData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据仓库编号和架位名称查找仓库。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="Description">string:	架位名称。</param>
		/// <returns>StoConData:	仓库架位数据实体。</returns>
		public StoConData GetStoConByStoCodeAndDescription(string StoCode,string Description)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			StoConData myDS = new StoConData ();

			myHT.Add ("@StoCode",StoCode);
			myHT.Add ("@Description",Description);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoConGetByStoCodeAndDescription", myHT, myDS.Tables [StoConData.STOCON_TABLE]))
			{
				this.Message = StoConData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 增加架位数据。
		/// </summary>
		/// <param name="myStoConData">StoConData:	架位数据实体。</param>
		/// <returns>bool:	增加成功返回true,失败返回false.</returns>
		public bool Add(StoConData myStoConData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			//myHT.Add ("@Code",int.Parse(myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.CODE_FIELD].ToString()));
			myHT.Add ("@Description",myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@StoCode",myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.STOCODE_FIELD].ToString());
			myHT.Add ("@Status",myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.STATUS_FIELD].ToString());
			myHT.Add ("@Locked", myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.LOCKED_FIELD].ToString());
			myHT.Add ("@Area", myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.AREA_FIELD].ToString());
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoConInsert",myHT))
			{
				this.Message = StoConData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoConData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// 修改仓库架位数据。
		/// </summary>
		/// <param name="myStoConData">StoConData:	架位数据实体。</param>
		/// <returns>bool:	修改成功返回true，失败返回false。</returns>
		public bool Update(StoConData myStoConData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Code", int.Parse(myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.CODE_FIELD].ToString()));
			myHT.Add ("@Description", myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@StoCode", myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.STOCODE_FIELD].ToString());
			myHT.Add ("@Status", myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.STATUS_FIELD].ToString());
			myHT.Add ("@Locked", myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.LOCKED_FIELD].ToString());
			myHT.Add ("@Area", myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.AREA_FIELD].ToString());
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoConUpdate",myHT))
			{
				this.Message = StoConData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoConData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 仓库架位数据删除。
		/// </summary>
		/// <param name="myStoConData">StoConData:	架位数据实体。</param>
		/// <returns>bool:	架位删除成功返回true，失败返回false。</returns>
		public bool Delete(StoConData myStoConData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Code", int.Parse(myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.CODE_FIELD].ToString()));

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoConDelete",myHT))
			{
				this.Message = StoConData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoConData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 根据传入的架位编号串进行架位的删除。
		/// </summary>
		/// <param name="Codes">string:	架位编号串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
            myHT.Add("@Code", Codes);

			SQLServer mySP = new SQLServer ();
            if (mySP.ExecSP("Sto_StoConDelete", myHT))
			{
				this.Message = StoConData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoConData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
	}
}
