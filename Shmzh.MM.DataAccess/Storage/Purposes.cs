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
	/// 用途的数据访问层。
	/// </summary>
	public class Purposes : Messages
	{
		public Purposes()
		{}
		/// <summary>
		/// 获得所有用途。
		/// </summary>
		/// <returns>PurposeData:	用途数据实体。</returns>
		public PurposeData GetPurposeAll()
		{
			PurposeData myDS = new PurposeData ();

			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetAll", myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 获取所有有效的用途。
		/// </summary>
		/// <returns>PurposeData:	用途数据实体。</returns>
		public PurposeData GetPurposeAvalible()
		{
			PurposeData myDS = new PurposeData();

			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetAvalible", myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据用途代码获得用途信息。
		/// </summary>
		/// <param name="Code">string:	用途代码。</param>
		/// <returns>PurposeData:	用途数据实体。</returns>
		public PurposeData GetPurposeByCode(string Code)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PurposeData myDS = new PurposeData ();

			myHT.Add ("@Code",Code);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByCode", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据用途名称查找用途信息。
		/// </summary>
		/// <param name="Description">string:	用途名称。</param>
		/// <returns>PurposeData:	用途数据实体。</returns>
		public PurposeData GetPurposeByDescription(string Description)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PurposeData myDS = new PurposeData ();

			myHT.Add ("@Description",Description);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByDescription", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 根据分类获取用途。
		/// </summary>
		/// <param name="strClassify">string:	用途分类编号。</param>
		/// <returns>PurposeData： 用途实体。</returns>
		public PurposeData GetPurposeByClassify(string strClassify)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PurposeData myDS = new PurposeData ();

			myHT.Add ("@Classify",strClassify);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByClassify", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		public PurposeData GetPurposeByClassifyWithFlag(string strClassify,int Flag)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PurposeData myDS = new PurposeData ();

			myHT.Add ("@Classify",strClassify);
			myHT.Add ("@Flag", Flag);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByClassifyWithFlag", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		public PurposeData GetAvailablePurposeByPYWithFlag(string Classify,string PY, int Flag)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PurposeData myDS = new PurposeData ();
			myHT.Add("@Classify",Classify);
			myHT.Add ("@PYZM",PY);
			myHT.Add ("@Flag", Flag);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByPYWithFlag", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		public PurposeData GetAvailablePurposeByPY(string Classify,string PY)
		{
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			PurposeData myDS = new PurposeData ();
		    myHT.Add("@Classify",Classify);
			myHT.Add ("@PYZM",PY);
			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Sto_PurposeGetByPY", myHT, myDS.Tables [PurposeData.USE_TABLE]))
			{
				this.Message = PurposeData.QUERY_FAILED;
			}
			return myDS;
		}
		/// <summary>
		/// 用途增加。
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	用途数据实体。</param>
		/// <returns>bool:	增加成功返回true,失败返回false.</returns>
		public bool Add(PurposeData myPurposeData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@Code",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@TargetAcc",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.TARGETACC_FIELD].ToString());
			myHT.Add ("@Enable",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.ENABLE_FIELD].ToString());
			myHT.Add ("@Classify",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CLASSIFY_FIELD].ToString());
			myHT.Add ("@ProjectCode",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.PROJECT_CODE_FIELD].ToString());
			myHT.Add ("@Flag", int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.FLAG_FIELD].ToString()));
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.thisYear_Field] == null)
				myHT.Add("@thisYear", null);
			else 
				myHT.Add("@thisYear", int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.thisYear_Field].ToString()));

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_PurposeInsert",myHT))
			{
				this.Message = PurposeData.ADD_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PurposeData.ADD_FAILED;
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// 用途修改。
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	用途数据实体。</param>
		/// <returns>bool:	修改成功返回true，失败返回false。</returns>
		public bool Update(PurposeData myPurposeData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();

			myHT.Add ("@OldCode",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.OLDCODE_FIELD].ToString());
			myHT.Add ("@Code",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString());
			myHT.Add ("@Description",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.DESCRIPTION_FIELD].ToString());
			myHT.Add ("@TargetAcc",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.TARGETACC_FIELD].ToString());
			myHT.Add ("@Enable",int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.ENABLE_FIELD].ToString()));
			myHT.Add ("@Classify",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CLASSIFY_FIELD].ToString());
			myHT.Add ("@ProjectCode",myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.PROJECT_CODE_FIELD].ToString());
			myHT.Add ("@Flag", int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.FLAG_FIELD].ToString()) );
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.thisYear_Field] == null)
				myHT.Add("@thisYear",null);
			else
				myHT.Add("@thisYear",int.Parse(myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.thisYear_Field].ToString()));

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_PurposeUpdate",myHT))
			{
				this.Message = PurposeData.UPDATE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PurposeData.UPDATE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 用途删除。
		/// </summary>
		/// <param name="myStoData">PurposeData:	用途数据实体。</param>
		/// <returns>bool:	删除成功返回true，失败返回false。</returns>
		public bool Delete(PurposeData myPurposeData)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable ();
			myHT.Add ("@Code", myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_PurposeDelete",myHT))
			{
				this.Message = PurposeData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PurposeData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 根据传入的用途代码串进行删除。
		/// </summary>
		/// <param name="Codes">string:	用途代码字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			//存储过程参数的哈希表。
			Hashtable myHT = new Hashtable();
			myHT.Add("@Codes",Codes);
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Sto_PurposeDeleteByCodes",myHT))
			{
				this.Message = PurposeData.DELETE_SUCCESSED;
				retValue = true;
			}
			else
			{
				this.Message = PurposeData.DELETE_FAILED;
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		///	根据SQL来进行查询。
		/// </summary>
		/// <param name="Sql_Statement">string:	SQL 语句。</param>
		/// <returns>PurposeData:	用途数据实体。</returns>
		public PurposeData GetPurposeBySQL(string Sql_Statement)
		{
			PurposeData oPurposeData = new PurposeData();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);

			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oPurposeData.Tables[PurposeData.USE_TABLE]);
			return oPurposeData;
		}
	}
}
