//----------------------------------------------------------------
// Copyright (C) 2004-2004 Shanghai MZH Corporation
// All rights reserved.
//----------------------------------------------------------------
namespace Shmzh.MM.BusinessRules
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
    using Shmzh.MM.DataAccess;
	using MZHCommon.Input;

	/// <summary>
	/// Dept 的摘要说明。
	/// </summary>
	public class PPRC : Messages
	{
		/// <summary>
		/// 供应商分类 增加。
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	供应商分类数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(PPRCData myPPRCData)
		{
			bool isValid = true;
			//判断传入的数据实体是否为空。
			if (myPPRCData.Tables[PPRCData.PPRC_Table].Rows.Count == 0)
			{
				this.Message = "数据体为空！";
				return false;
			}
			//进行数据添加操作。
			{
				PPRCs myPPRCs = new PPRCs();
				isValid = myPPRCs.Add(myPPRCData);
				this.Message = myPPRCs.Message;
				return isValid;
			}
		}

		/// <summary>
		/// 供应商分类 修改。
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	供应商分类数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(PPRCData myPPRCData)
		{
			bool isValid = true;
			//判断传入的数据实体是否为空。
			if (myPPRCData.Tables[PPRCData.PPRC_Table].Rows.Count == 0)
			{
				this.Message = "数据体为空！" ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPPRCData.Tables[PPRCData.PPRC_Table].Rows[0];
			
			//数据修改。
			{
				PPRCs myPPRCs = new PPRCs();
				isValid = myPPRCs.Update(myPPRCData);
				this.Message = myPPRCs.Message;
				return isValid;
			}
		}
		/// <summary>
		/// 供应商分类 删除。
		/// </summary>
		/// <param name="myPPRCData">PPRCData:	供应商分类数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(PPRCData myPPRCData)
		{
			bool isValid = true;
			if (myPPRCData.Tables[PPRCData.PPRC_Table].Rows.Count > 0)
			{
				PPRCs myPPRCs = new PPRCs();
				isValid = myPPRCs.Delete(myPPRCData);
				this.Message = myPPRCs.Message;
			}
			else
			{	
				this.Message = "数据体为空！";	
			}
			return isValid;
		}
	}
}
