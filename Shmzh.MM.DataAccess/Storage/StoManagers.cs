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
	/// �ֿ����Ա�����ݷ��ʲ㡣
	/// </summary>
	public class StoManagers : Messages
	{
		public StoManagers()
		{}
		/// <summary>
		/// ���ݲֿ����Ա������ȡ����Ա��Ϣ��
		/// </summary>
		/// <param name="PKID">int:	������</param>
		/// <returns>StoManagerData:	�ֿ����Ա����ʵ�塣</returns>
		public StoManagerData GetStoManagerByPKID(int PKID)
		{
			Hashtable myHT = new Hashtable();//�洢���̲����Ĺ�ϣ��
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
		/// ���ݹ���Ա��Ż�òֿ����Ա��Ϣ��
		/// </summary>
		/// <param name="UserCode">string:	����Ա��š�</param>
		/// <returns>StoManagerData:	�ֿ����Ա����ʵ�塣</returns>
		public StoManagerData GetStoManagerByUserCode(string UserCode)
		{
			Hashtable myHT = new Hashtable();//�洢���̲����Ĺ�ϣ��
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
		/// ���ݲֿ��Ż�ȡ�ֿ����Ա��
		/// </summary>
		/// <param name="StoCode">string:	�ֿ���롣</param>
		/// <returns>StoManagerData:	�ֿ����Ա����ʵ�塣</returns>
		public StoManagerData GetStoManagerByStoCode(string StoCode)
		{
			Hashtable myHT = new Hashtable();//�洢���̲����Ĺ�ϣ��
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
		/// ���ݲֿ��ź͹���Ա��ŷ��زֿ����Ա���ݡ�
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="UserCode">string:	����Ա��š�</param>
		/// <returns>StoManagerData:	�ֿ����Ա����ʵ�塣</returns>
		public StoManagerData GetStoManagerByStoCodeAndUserCode(string StoCode, string UserCode)
		{
			Hashtable myHT = new Hashtable();//�洢���̲����Ĺ�ϣ��
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
		/// �ֿ����Ա���ӡ�
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	���ӳɹ�����true,ʧ�ܷ���false.</returns>
		public bool Add(StoManagerData myStoManagerData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
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
		/// �ֿ����Ա�޸ġ�
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	�޸ĳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(StoManagerData myStoManagerData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
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
		/// �ֿ����Աɾ����
		/// </summary>
		/// <param name="StoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	ɾ���ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(StoManagerData myStoManagerData)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
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
		/// ���ݴ���Ĳֿ����Ա����������ɾ����
		/// </summary>
		/// <param name="PKIDs">string:	�ֿ����Ա��������</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string PKIDs)
		{
			bool retValue;
			//�洢���̲����Ĺ�ϣ��
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
