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
	/// Analysis 的摘要说明。
	/// </summary>
	public class Analysis  : Messages
	{
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
		/// <summary>
		/// 根据用途大类的发料。
		/// </summary>
		/// <param name="Year">int:	年份。</param>
		/// <param name="Month">int:	月份。</param>
		/// <returns>CurrentMonth_WithdrawData:	发料结果。</returns>
		public CurrentMonth_WithdrawData Get_CurentMonth_Withdraw(int Year, int Month)
		{
			Hashtable oHT = new Hashtable();
			CurrentMonth_WithdrawData myDS = new CurrentMonth_WithdrawData ();
			oHT.Add("@Year", Year);
			oHT.Add("@Month", Month);

			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Analysis_CurrentMonth_Withdraw",oHT, myDS.Tables[CurrentMonth_WithdrawData.CurrentMonth_Withdraw_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		/// <summary>
		/// 获取当前库存的ABC分布结果。
		/// </summary>
		/// <returns></returns>
		public CurrentABCStockData Get_CurrentABCStock()
		{
			CurrentABCStockData myDS = new CurrentABCStockData();
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_CurrentStock", myDS.Tables[CurrentABCStockData.ABC_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;			
		}
		/// <summary>
		/// 获取当月的供应商供货情况。
		/// </summary>
		/// <param name="Year">int:	年份。</param>
		/// <param name="Month">int:	月份。</param>
		/// <returns></returns>
		public CurrentVendorINData Get_CurrentVendorIN(int Year, int Month)
		{
			Hashtable oHT = new Hashtable();
			CurrentVendorINData myDS = new CurrentVendorINData ();
			oHT.Add("@Year", Year);
			oHT.Add("@Month", Month);

			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Analysis_CurrentMonth_Vendor",oHT, myDS.Tables[CurrentVendorINData.CurrentVendorIN_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		public VendorInDetailData Get_VendorInDetail(string PrvCode,int Year,int Month)
		{
			Hashtable oHT = new Hashtable();
			VendorInDetailData myDS = new VendorInDetailData();
			oHT.Add("@PrvCode", PrvCode);
			oHT.Add("@Year", Year);
			oHT.Add("@Month", Month);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_GetVendorInDetail",oHT, myDS.Tables[VendorInDetailData.VendorInDetail_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		public VendorInDetailData Get_VendorInDetail(string PrvCode,DateTime StartDate,DateTime EndDate)
		{
			Hashtable oHT = new Hashtable();
			VendorInDetailData myDS = new VendorInDetailData();
			oHT.Add("@PrvCode", PrvCode);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_GetVendorInDetailByPrvCodeAndDate",oHT, myDS.Tables[VendorInDetailData.VendorInDetail_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		public WithDrawDetailData Get_WithDrawDetail(string Classify,int Year, int Month)
		{
			Hashtable oHT = new Hashtable();
			WithDrawDetailData myDS = new WithDrawDetailData();
			oHT.Add("@Classify", Classify);
			oHT.Add("@Year", Year);
			oHT.Add("@Month", Month);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_GetWithDrawDetail",oHT, myDS.Tables[WithDrawDetailData.WithDrawDetail_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		/// <summary>
		/// 获取发料明细的情况。
		/// </summary>
		/// <param name="ClassifyName">string:	用途分类。</param>
		/// <param name="ReqReason">string:	用途。</param>
		/// <param name="AuthorDeptName">string:	制单部门.</param>
		/// <param name="StartDate">DateTime:	开始日期。</param>
		/// <param name="EndDate">DateTime:	结束日期。</param>
		/// <returns>WithDrawDetailData: 发料明细表。</returns>
		public WithDrawDetailData Get_WithDrawDetail(string ClassifyName,string ReqReason, string AuthorDeptName,DateTime StartDate,DateTime EndDate)
		{
			Hashtable oHT = new Hashtable();
			WithDrawDetailData myDS = new WithDrawDetailData();
			oHT.Add("@ClassifyName", ClassifyName);
			oHT.Add("@ReqReason", ReqReason);
			oHT.Add("@AuthorDeptName", AuthorDeptName);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_GetWithDrawDetail",oHT,myDS.Tables[WithDrawDetailData.WithDrawDetail_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		public ROSDetailsData Get_ROSDetails(string ClassifyName,string ReqReason, string AuthorDeptName, DateTime StartDate, DateTime EndDate,int Flag)
		{
			Hashtable oHT = new Hashtable();
			ROSDetailsData myDS = new ROSDetailsData();
			oHT.Add("@ClassifyName", ClassifyName);
			oHT.Add("@ReqReason", ReqReason);
			oHT.Add("@AuthorDeptName", AuthorDeptName);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oHT.Add("@Flag", Flag);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_GetROSDetails",oHT,myDS.Tables[ROSDetailsData.ROSDetails_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		public CurrentStockData Get_CurrentStock(string ABC)
		{
			CurrentStockData myDS = new CurrentStockData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ABC",ABC);
			oHT.Add("@StoName", "");
			oHT.Add("@CatName", "");
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_GetStockDetail", oHT, myDS.Tables[CurrentStockData.CurrentStock_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		public CurrentStockData Get_CurrentStock(string ABC, string StoName, string CatName)
		{
			CurrentStockData myDS = new CurrentStockData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ABC",ABC);
			oHT.Add("@StoName", StoName);
			oHT.Add("@CatName", CatName);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_GetStockDetail", oHT, myDS.Tables[CurrentStockData.CurrentStock_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		public CurrentROSData Get_CurrentROS(int Year, int Month)
		{
			CurrentROSData myDS = new CurrentROSData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Year",Year);
			oHT.Add("@Month", Month);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_CurrentMonth_ROS", oHT, myDS.Tables[CurrentROSData.ROS_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		public CurrentROSData Get_CurrentROS(int ResultCode,int Year,int Month)
		{
			CurrentROSData myDS = new CurrentROSData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ResultCode",ResultCode);
			oHT.Add("@Year",Year);
			oHT.Add("@Month", Month);
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_CurrentMonth_ROS_Detail", oHT, myDS.Tables[CurrentROSData.ROS_Table]))
			{
				this.Message = "查询失败！";
			}
			return myDS;
		}
		/// <summary>
		///	查询单据上某一条物料的流转过程。
		/// </summary>
		/// <param name="EntryNo">单据流水号。</param>
		/// <param name="DocCode">单据类型。</param>
		/// <param name="SerialNo">序号。</param>
		/// <param name="ItemCode">物料编号。</param>
		/// <returns>单据物料项流转过程数据实体。</returns>
		public DocItemRouteData Get_DocItemRoute(int EntryNo,int DocCode, int SerialNo,string ItemCode)
		{
			DocItemRouteData oData = new DocItemRouteData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@EntryNo", EntryNo);
			oHT.Add("@DocCode", DocCode);
			if (DocCode == 2)
				oHT.Add("@SerialNo",null);
			else
				oHT.Add("@SerialNo", SerialNo);
			oHT.Add("@ItemCode", ItemCode);
			SQLServer oSQLServer = new SQLServer();
			oSQLServer.ExecSPReturnDS("Analysis_GetDocItemRoute",oHT,oData.Tables[DocItemRouteData.DocItemRoute_Table]);
			return oData;
		}
		#endregion

		#region 构造函数
		public Analysis()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
