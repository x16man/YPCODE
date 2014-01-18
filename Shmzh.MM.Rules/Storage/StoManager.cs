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
	/// �ֿ����Աҵ�����㡣
	/// </summary>
	public class StoManager : Messages
	{
		/// <summary>
		/// �ֿ����Ա���ӡ�
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Add(StoManagerData myStoManagerData)
		{
			bool isValid = true;
			//�ж��Ƿ��ǿ����ݡ�
			if (myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count == 0)
			{
				this.Message = StoData.NO_ROW ;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0];
			
			//�жϲֿ���\�ֿ����Ա�Ƿ��ظ���
			if ( !IsValidNewStoCodeUserCode(myRow[StoManagerData.STOCODE_FIELD].ToString(),myRow[StoManagerData.USERCODE_FIELD].ToString()))
			{
				this.Message = StoManagerData.STOCODEUSERCODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//������ӡ�
			if (isValid)
			{
				StoManagers myStoManagers = new StoManagers();

				isValid = myStoManagers.Add(myStoManagerData);
				this.Message = myStoManagers.Message;
			}
			return isValid;
		}
		/// <summary>
		/// �ֿ����Ա�޸ġ�
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	�޸ĳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(StoManagerData myStoManagerData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count == 0)
			{
				this.Message = StoData.NO_ROW;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0];
			//�жϲֿ����Ա�����Ƿ��ظ���
			if ( !IsValidStoCodeUserCode(	int.Parse(myRow[StoManagerData.PKID_FIELD].ToString()),
											myRow[StoManagerData.STOCODE_FIELD].ToString(),
											myRow[StoManagerData.USERCODE_FIELD].ToString()) 
				)
			{
				this.Message = StoManagerData.STOCODEUSERCODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//���ݸ��ġ�
			if (isValid)
			{
				StoManagers myStoManagers = new StoManagers();
				isValid = myStoManagers.Update(myStoManagerData);
				this.Message = myStoManagers.Message;
			}
			return isValid;
		}
		/// <summary>
		/// �ֿ����Աɾ����
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	�ֿ����Ա����ʵ�塣</param>
		/// <returns>bool:	ɾ���ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(StoManagerData myStoManagerData)
		{
			bool isValid = true;
			if (myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count == 0)
			{
				this.Message = StoManagerData.NO_ROW;	
				isValid = false;
				return isValid;
			}
			if (isValid)
			{
				StoManagers myStoManagers = new StoManagers();
				isValid = myStoManagers.Delete(myStoManagerData);
				this.Message = myStoManagers.Message;
			}
			return isValid;
		}
		/// <summary>
		/// ���ݴ���Ĳֿ����Ա����������ɾ����
		/// </summary>
		/// <param name="PKIDs">string:	�ֿ����Ա��������</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string PKIDs)
		{
			bool isValid = true;
			if (PKIDs == null && PKIDs == "")
			{
				this.Message = StoManagerData.NO_ROW;	
				isValid = false;
				return isValid;
			}
			if (isValid)
			{
				StoManagers myStoManagers = new StoManagers();
				isValid = myStoManagers.Delete(PKIDs);
				this.Message = myStoManagers.Message;
			}
			return isValid;
		}
		/// <summary>
		/// �ֿ����Ա����ʱ�жϲֿ����Ա��Ųֿ����Ƿ���Ч��
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="UserCode">string:	����Ա��š�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewStoCodeUserCode(string StoCode,string UserCode)
		{
			StoManagers myStoManagers = new StoManagers();
			return myStoManagers.GetStoManagerByStoCodeAndUserCode(StoCode, UserCode).Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// �ֿ����Ա�޸�ʱ�жϲֿ����Ա��Ųֿ����Ƿ���Ч��
		/// </summary>
		/// <param name="OldStoCode">string:	�ɲֿ��š�</param>
		/// <param name="OldUserCode">string:	�ɹ���Ա��š�</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="UserCode">string:	����Ա���</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidStoCodeUserCode(int PKID, string StoCode, string UserCode)
		{
			StoManagerData myStoManagerData;
			StoManagers myStoManagers = new StoManagers();
			myStoManagerData = myStoManagers.GetStoManagerByStoCodeAndUserCode(StoCode, UserCode);
			//������ݲֿ��š�����Ա��Ų�ѯ��û�н����˵������Ч�ġ�
			if ( myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//����н���������ǽ�������Ǳ���Ҳ����Ч�ġ�
			{
				return int.Parse(myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0][StoManagerData.PKID_FIELD].ToString())==PKID ? true:false;
			}
		}
	}
}
