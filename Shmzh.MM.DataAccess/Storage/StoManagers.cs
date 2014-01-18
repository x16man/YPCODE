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
	/// 仓库管理员的数据访问层。
	/// </summary>
	public class StoManagers : Messages
	{
		public StoManagers()
		{}
		/// <summary>
		/// 根据仓库管理员主键获取管理员信息。
		/// </summary>
		/// <param name="PKID">int:	主键。</param>
		/// <returns>StoManagerData:	仓库管理员数据实体。</returns>
		public StoManagerData GetStoManagerByPKID(int PKID)
		{
			Hashtable myHT = new Hashtable();//存储过程参数的哈希表。
			StoManagerData myDS = new StoManagerData();

			myHT.Add ("@PKID", PKID);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoManagerGetByPKID", myHT, myDS.Tables[StoManagerData.STOMANAGER_TABLE]))
			{
				this.Message = StoManagerData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据管理员编号获得仓库管理员信息。
		/// </summary>
		/// <param name="UserCode">string:	管理员编号。</param>
		/// <returns>StoManagerData:	仓库管理员数据实体。</returns>
		public StoManagerData GetStoManagerByUserCode(string UserCode)
		{
			Hashtable myHT = new Hashtable();//存储过程参数的哈希表。
			StoManagerData myDS = new StoManagerData();

			myHT.Add ("@UserCode", UserCode);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoManagerGetByUserCode", myHT, myDS.Tables[StoManagerData.STOMANAGER_TABLE]))
			{
				this.Message = StoManagerData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据仓库编号获取仓库管理员。
		/// </summary>
		/// <param name="StoCode">string:	仓库代码。</param>
		/// <returns>StoManagerData:	仓库管理员数据实体。</returns>
		public StoManagerData GetStoManagerByStoCode(string StoCode)
		{
			Hashtable myHT = new Hashtable();//存储过程参数的哈希表。
			StoManagerData myDS = new StoManagerData();

			myHT.Add ("@StoCode", StoCode);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Sto_StoManagerGetByStoCode", myHT, myDS.Tables [StoManagerData.STOMANAGER_TABLE]))
			{
				this.Message = StoManagerData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据仓库编号和管理员编号返回仓库管理员数据。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="UserCode">string:	管理员编号。</param>
		/// <returns>StoManagerData:	仓库管理员数据实体。</returns>
		public StoManagerData GetStoManagerByStoCodeAndUserCode(string StoCode, string UserCode)
		{
			Hashtable myHT = new Hashtable();//存储过程参数的哈希表。
			StoManagerData myDS = new StoManagerData();

			myHT.Add ("@StoCode", StoCode);
			myHT.Add ("@UserCode", UserCode);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_StoManagerGetByStoCodeAndUserCode", myHT, myDS.Tables[StoManagerData.STOMANAGER_TABLE]))
			{
				this.Message = StoManagerData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 仓库管理员增加。
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	增加成功返回true,失败返回false.</returns>
		public bool Add(StoManagerData myStoManagerData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable();

			myHT.Add ("@StoCode",myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0][StoManagerData.STOCODE_FIELD].ToString());
			myHT.Add ("@UserCode",myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0][StoManagerData.USERCODE_FIELD].ToString());
			
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoManagerInsert",myHT))
			{
				this.Message = StoManagerData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoManagerData.ADD_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 仓库管理员修改。
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	修改成功返回true，失败返回false。</returns>
		public bool Update(StoManagerData myStoManagerData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();
			myHT.Add("@PKID",myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0][StoManagerData.PKID_FIELD].ToString());
			myHT.Add ("@StoCode",myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0][StoManagerData.STOCODE_FIELD].ToString());
			myHT.Add ("@UserCode",myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0][StoManagerData.USERCODE_FIELD].ToString());
			
			SQLServer mySP = new SQLServer ();

			if (mySP.ExecSP("Sto_StoManagerUpdate",myHT))
			{
				this.Message = StoManagerData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoManagerData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 仓库管理员删除。
		/// </summary>
		/// <param name="StoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	删除成功返回true，失败返回false。</returns>
		public bool Delete(StoManagerData myStoManagerData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();
			myHT.Add ("@PKID", int.Parse(myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0][StoManagerData.PKID_FIELD].ToString()));

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoManagerDelete",myHT))
			{
				this.Message = StoManagerData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoManagerData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 根据传入的仓库管理员主键串进行删除。
		/// </summary>
		/// <param name="PKIDs">string:	仓库管理员主键串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string PKIDs)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();
			myHT.Add ("@PKIDs", PKIDs);

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_StoManagerDeleteByPKIDs",myHT))
			{
				this.Message = StoManagerData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = StoManagerData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
	}
}
