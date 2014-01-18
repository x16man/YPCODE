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
	/// 供应商/客户数据实体层。
	/// </summary>
	public class PPRCs : Messages
	{
		public PPRCs()
		{		}
		/// <summary>
		///  获得所有供应商分类信息。
		/// </summary>
		/// <returns>PPRCData:	供应商分类数据实体。</returns>
		public PPRCData GetPPRCAll ()
		{
			PPRCData ds = new PPRCData ();
			SQLServer mysp = new SQLServer ();

			mysp.ExecSPReturnDS("Pur_PPRCGetAll",ds.Tables [PPRCData.PPRC_Table]);
			
			return ds;
		}
		/// <summary>
		/// 根据编号获取供应商分类。
		/// </summary>
		/// <param name="Code">int:	编号。</param>
		/// <returns>PPRCData:	供应商分类数据实体。</returns>
		public PPRCData GetPPRCByCode(int Code)
		{
			PPRCData ds = new PPRCData();
			SQLServer mysp = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Code", Code);

			mysp.ExecSPReturnDS("Pur_PPRCGetByCode",oHT,ds.Tables [PPRCData.PPRC_Table]);
			return ds;
		}
		/// <summary>
		/// 供应商分类增加。
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	供应商分类数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Add(PPRCData myPPRCData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			
			myHT.Add("@CnName",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.CnName_Field].ToString());			//中文名称。
			myHT.Add("@EnName",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.EnName_Field].ToString());			//英文名称。
			myHT.Add("@Desc", myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.Desc_Field].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRCInsert",myHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "供应商分类添加失败！";
				retValue = false;
			}

			return retValue;
		}
		/// <summary>
		/// 供应商分类修改。
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	供应商分类数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(PPRCData myPPRCData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。

			myHT.Add ("@Code",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.Code_Field].ToString());	
			myHT.Add("@CnName",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.CnName_Field].ToString());			//中文名称。
			myHT.Add("@EnName",myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.EnName_Field].ToString());			//英文名称。
			myHT.Add("@Desc", myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.Desc_Field].ToString());
			
			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRCUpdate",myHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "供应商分类修改失败！";
				retValue = false;
			}
			return retValue;
		}
		/// <summary>
		/// 供应商分类删除。
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	供应商分类数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(PPRCData myPPRCData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//存储过程参数的哈希表。
			myHT.Add ("@Code", myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0][PPRCData.Code_Field].ToString());

			SQLServer mySP = new SQLServer ();
			if (mySP.ExecSP("Pur_PPRCDelete",myHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "供应商分类删除失败！";
				retValue = false;
			}
			return retValue;
		}
	}
}
