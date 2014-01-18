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

using System;
using System.Collections;
using MZHCommon.Database;
using Shmzh.MM.Common;
using log4net;

namespace Shmzh.MM.DataAccess
{
	/// <summary>
	/// YCLs ��ժҪ˵����
	/// </summary>
	public class YCLs : Messages
	{
       // private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      

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
		/// �������ϱ�ź�ʱ�䷶Χ��ȡԭ�����շ���¼
		/// </summary>
		/// <param name="itemCode">���ϱ��</param>
		/// <param name="startDate">��ʼ����</param>
		/// <param name="endDate">��������</param>
		/// <returns>YCLDataʵ��.</returns>
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
				this.Message = "�������ʧ�ܣ�";
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
				this.Message = "�����޸�ʧ�ܣ�";
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
				this.Message = "����ɾ��ʧ�ܣ�";
				retValue = false;
			}
			return retValue;
		}

		#endregion

		#region ���캯��

		public YCLs()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		#endregion
	}
}