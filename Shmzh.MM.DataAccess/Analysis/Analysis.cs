#region ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved
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
#endregion ��Ȩ (c) 2004-2005 MZH, Inc. All Rights Reserved

#region �ĵ���Ϣ
/******************************************************************************
**		�ļ�: 
**		����: 
**		����: 
**
**              
**		����: �ź�
**		����: 
*******************************************************************************
**		�޸���ʷ
*******************************************************************************
**		����:		����:		����:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion �ĵ���Ϣ


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
	/// Analysis ��ժҪ˵����
	/// </summary>
	public class Analysis  : Messages
	{
		#region ��Ա����
		//
		//TODO: �ڴ˴���ӳ�Ա������
		//
		#endregion

		#region ����
		//
		//TODO: �ڴ˴�������ԡ�
		//
		#endregion
		
		#region ˽�з���
		//
		//TODO: ����˴���˽�з�����
		//
		#endregion

		#region ��������
		/// <summary>
		/// ������;����ķ��ϡ�
		/// </summary>
		/// <param name="Year">int:	��ݡ�</param>
		/// <param name="Month">int:	�·ݡ�</param>
		/// <returns>CurrentMonth_WithdrawData:	���Ͻ����</returns>
		public CurrentMonth_WithdrawData Get_CurentMonth_Withdraw(int Year, int Month)
		{
			Hashtable oHT = new Hashtable();
			CurrentMonth_WithdrawData myDS = new CurrentMonth_WithdrawData ();
			oHT.Add("@Year", Year);
			oHT.Add("@Month", Month);

			SQLServer mySP = new SQLServer ();
			if (!mySP.ExecSPReturnDS("Analysis_CurrentMonth_Withdraw",oHT, myDS.Tables[CurrentMonth_WithdrawData.CurrentMonth_Withdraw_Table]))
			{
				this.Message = "��ѯʧ�ܣ�";
			}
			return myDS;
		}
		/// <summary>
		/// ��ȡ��ǰ����ABC�ֲ������
		/// </summary>
		/// <returns></returns>
		public CurrentABCStockData Get_CurrentABCStock()
		{
			CurrentABCStockData myDS = new CurrentABCStockData();
			SQLServer mySP = new SQLServer();
			if (!mySP.ExecSPReturnDS("Analysis_CurrentStock", myDS.Tables[CurrentABCStockData.ABC_Table]))
			{
				this.Message = "��ѯʧ�ܣ�";
			}
			return myDS;			
		}
		/// <summary>
		/// ��ȡ���µĹ�Ӧ�̹��������
		/// </summary>
		/// <param name="Year">int:	��ݡ�</param>
		/// <param name="Month">int:	�·ݡ�</param>
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
				this.Message = "��ѯʧ�ܣ�";
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
				this.Message = "��ѯʧ�ܣ�";
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
				this.Message = "��ѯʧ�ܣ�";
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
				this.Message = "��ѯʧ�ܣ�";
			}
			return myDS;
		}
		/// <summary>
		/// ��ȡ������ϸ�������
		/// </summary>
		/// <param name="ClassifyName">string:	��;���ࡣ</param>
		/// <param name="ReqReason">string:	��;��</param>
		/// <param name="AuthorDeptName">string:	�Ƶ�����.</param>
		/// <param name="StartDate">DateTime:	��ʼ���ڡ�</param>
		/// <param name="EndDate">DateTime:	�������ڡ�</param>
		/// <returns>WithDrawDetailData: ������ϸ��</returns>
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
				this.Message = "��ѯʧ�ܣ�";
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
				this.Message = "��ѯʧ�ܣ�";
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
				this.Message = "��ѯʧ�ܣ�";
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
				this.Message = "��ѯʧ�ܣ�";
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
				this.Message = "��ѯʧ�ܣ�";
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
				this.Message = "��ѯʧ�ܣ�";
			}
			return myDS;
		}
		/// <summary>
		///	��ѯ������ĳһ�����ϵ���ת���̡�
		/// </summary>
		/// <param name="EntryNo">������ˮ�š�</param>
		/// <param name="DocCode">�������͡�</param>
		/// <param name="SerialNo">��š�</param>
		/// <param name="ItemCode">���ϱ�š�</param>
		/// <returns>������������ת��������ʵ�塣</returns>
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

		#region ���캯��
		public Analysis()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
	}
}
