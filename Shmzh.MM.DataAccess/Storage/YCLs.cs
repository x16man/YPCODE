#region 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved

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

#endregion 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved

#region 文档信息

/******************************************************************************
**		文件: 
**		名称: 
**		描述: 
**
**              
**		作者: 张豪
**		日期: 
*******************************************************************************
**		修改历史
*******************************************************************************
**		日期:		作者:		描述:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/

#endregion 文档信息

using System;
using System.Collections;
using MZHCommon.Database;
using Shmzh.MM.Common;
using log4net;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// YCLs 的摘要说明。
	/// </summary>
	public class YCLs : Messages
	{
       // private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      

		#region 成员变量

		//
		//TODO: 在此处添加成员变量。
		//

		#endregion

		#region 属性

		//
		//TODO: 在此处添加属性。
		//

		#endregion

		#region 私有方法

		//
		//TODO: 在这此处加私有方法。
		//

		#endregion

		#region 公开方法

		public YCLGroupData GetYCLGroupByDate(DateTime StartDate, DateTime EndDate)
		{
			YCLGroupData oYCLGroupData = new YCLGroupData();
			SQLServer mySQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			mySQLServer.ExecSPReturnDS("Sto_YCLGetGroupByDate", oHT, oYCLGroupData.Tables[YCLGroupData.YCLGroup_Table]);
			mySQLServer.ExecSPReturnDS("Sto_YCLGetByDate", oHT, oYCLGroupData.Tables[YCLGroupData.YCL_Table]);
			return oYCLGroupData;
		}

		public YCLData GetYCLNow()
		{
			YCLData oYCLData = new YCLData();

			SQLServer mySQLServer = new SQLServer();
			mySQLServer.ExecSPReturnDS("Sto_YCLGetNow", oYCLData.Tables[YCLData.YCL_Table]);
			return oYCLData;
		}

		public YCLData GetYCLByDate(DateTime StartDate, DateTime EndDate)
		{
			YCLData oYCLData = new YCLData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);

			SQLServer mySQLServer = new SQLServer();
			mySQLServer.ExecSPReturnDS("Sto_YCLGetByDate", oHT, oYCLData.Tables[YCLData.YCL_Table]);
			return oYCLData;
		}

		public YCLData GetYCLALL()
		{
			YCLData oYCLData = new YCLData();

			SQLServer mySQLServer = new SQLServer();
			mySQLServer.ExecSPReturnDS("Sto_YCLGetTop50", oYCLData.Tables[YCLData.YCL_Table]);
			return oYCLData;
		}

		public YCLData GetYCLByPKID(int PKID)
		{
			YCLData oYCLData = new YCLData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID", PKID);
			SQLServer mySQLServer = new SQLServer();
			mySQLServer.ExecSPReturnDS("Sto_YCLGetByPKID", oHT, oYCLData.Tables[YCLData.YCL_Table]);
			return oYCLData;
		}

		/// <summary>
		/// 根据物料编号和时间范围获取原材料收发记录
		/// </summary>
		/// <param name="itemCode">物料编号</param>
		/// <param name="startDate">开始日期</param>
		/// <param name="endDate">结束日期</param>
		/// <returns>YCLData实体.</returns>
		public YCLData GetYCLByItemAndDate(string itemCode, DateTime startDate, DateTime endDate)
		{
			YCLData oYCLData = new YCLData();
			Hashtable oHT = new Hashtable();
           // Logger.Info(startDate);
			oHT.Add("@ItemCode", itemCode);
           // Logger.Info("startDate="+startDate);
			oHT.Add("@StartDate", startDate);
           // Logger.Info("EndDate=" + endDate);
			oHT.Add("@EndDate", endDate);

			SQLServer mySQLServer = new SQLServer();
			mySQLServer.ExecSPReturnDS("Sto_YCLGetByItemAndDate", oHT, oYCLData.Tables[YCLData.YCL_Table]);
			return oYCLData;
		}

		public bool Add(YCLData oYCLData)
		{
			bool retValue;

			Hashtable oHT = new Hashtable();
			//oHT.Add("@PrvCode",oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.PrvCode_Field].ToString());
			//oHT.Add("@PrvName",oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.PrvName_Field].ToString());
			oHT.Add("@ItemCode", oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.ItemCode_Field].ToString());
			oHT.Add("@ItemName", oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.ItemName_Field].ToString());
			//oHT.Add("@UnitCode", int.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.UnitCode_Field].ToString()));
			//oHT.Add("@UnitName", oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.UnitName_Field].ToString());
			oHT.Add("@InVolNum", decimal.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.InVolNum_Field].ToString()));
			oHT.Add("@InItemNum", decimal.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.InItemNum_Field].ToString()));
			oHT.Add("@OutVolNum", decimal.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.OutVolNum_Field].ToString()));
			oHT.Add("@OutItemNum", decimal.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.OutItemNum_Field].ToString()));
			oHT.Add("@OpDate", oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.OpDate_Field].ToString());
			SQLServer mySP = new SQLServer();
			if (mySP.ExecSP("Sto_YCLInsert", oHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "数据添加失败！";
				retValue = false;
			}

			return retValue;
		}

		public bool Update(YCLData oYCLData)
		{
			bool retValue;

			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID", int.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.PKID_Field].ToString()));
			//oHT.Add("@PrvCode",oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.PrvCode_Field].ToString());
			//oHT.Add("@PrvName",oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.PrvName_Field].ToString());
			oHT.Add("@ItemCode", oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.ItemCode_Field].ToString());
			oHT.Add("@ItemName", oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.ItemName_Field].ToString());
			//oHT.Add("@UnitCode", int.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.UnitCode_Field].ToString()));
			//oHT.Add("@UnitName", oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.UnitName_Field].ToString());
			oHT.Add("@InVolNum", decimal.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.InVolNum_Field].ToString()));
			oHT.Add("@InItemNum", decimal.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.InItemNum_Field].ToString()));
			oHT.Add("@OutVolNum", decimal.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.OutVolNum_Field].ToString()));
			oHT.Add("@OutItemNum", decimal.Parse(oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.OutItemNum_Field].ToString()));
			oHT.Add("@OpDate", oYCLData.Tables[YCLData.YCL_Table].Rows[0][YCLData.OpDate_Field].ToString());
			SQLServer mySP = new SQLServer();
			if (mySP.ExecSP("Sto_YCLUpdate", oHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "数据修改失败！";
				retValue = false;
			}

			return retValue;
		}

		public bool Delete(int PKID)
		{
			bool retValue;
			Hashtable oHT = new Hashtable();
			oHT.Add("@PKID", PKID);

			SQLServer mySP = new SQLServer();
			if (mySP.ExecSP("Sto_YCLDelete", oHT))
			{
				retValue = true;
			}
			else
			{
				this.Message = "数据删除失败！";
				retValue = false;
			}
			return retValue;
		}

		#endregion

		#region 构造函数

		public YCLs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#endregion
	}
}