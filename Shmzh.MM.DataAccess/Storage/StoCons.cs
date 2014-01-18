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
	/// StoCons ��ժҪ˵����
	/// </summary>
	public class StoCons : Messages
	{
		public StoCons()
		{		}
		/// <summary>
		/// ���ݼ�λ��Ż�ü�λ��Ϣ��
		/// </summary>
		/// <param name="Code">string:	��λ��š�</param>
		/// <returns>StoConData:	��λ���ݼ���</returns>
		public StoConData GetStoConByCode(int Code)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
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
		/// ���ݼ�λ���ƻ�ü�λ��Ϣ��
		/// </summary>
		/// <param name="Description">string:	��λ���ơ�</param>
		/// <returns>StoConData:	��λ���ݼ���</returns>
		public StoConData GetStoConByDescription(string Description)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
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
		/// ���ݲֿ��Ż�ü�λ����ʵ�塣
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <returns>StoConData:	�ֿ��λ����ʵ�塣</returns>
		public StoConData GetStoConByStoCode(string StoCode)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
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
		/// ���ݲֿ��źͼ�λ���Ʋ��Ҳֿ⡣
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="Description">string:	��λ���ơ�</param>
		/// <returns>StoConData:	�ֿ��λ����ʵ�塣</returns>
		public StoConData GetStoConByStoCodeAndDescription(string StoCode,string Description)
		{
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
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
		/// ���Ӽ�λ���ݡ�
		/// </summary>
		/// <param name="myStoConData">StoConData:	��λ����ʵ�塣</param>
		/// <returns>bool:	���ӳɹ�����true,ʧ�ܷ���false.</returns>
		public bool Add(StoConData myStoConData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
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
		/// �޸Ĳֿ��λ���ݡ�
		/// </summary>
		/// <param name="myStoConData">StoConData:	��λ����ʵ�塣</param>
		/// <returns>bool:	�޸ĳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(StoConData myStoConData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
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
		/// �ֿ��λ����ɾ����
		/// </summary>
		/// <param name="myStoConData">StoConData:	��λ����ʵ�塣</param>
		/// <returns>bool:	��λɾ���ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(StoConData myStoConData)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
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
		/// ���ݴ���ļ�λ��Ŵ����м�λ��ɾ����
		/// </summary>
		/// <param name="Codes">string:	��λ��Ŵ���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool retValue;
			Hashtable myHT = new Hashtable ();//�洢���̲����Ĺ�ϣ��
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
