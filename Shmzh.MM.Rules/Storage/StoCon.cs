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
	/// ��λҵ�����㡣
	/// </summary>
	public class StoCon : Messages
	{
		public StoCon()
		{		}
		/// <summary>
		/// ��λ���ӡ�
		/// </summary>
		/// <param name="myStoConData">StoConData:	�������ݼ���</param>
		/// <returns>bool:	���ӳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Add(StoConData myStoConData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count > 0)
			{
				DataRow myRow = myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0];
				//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
				isValid = InputCheck.IsValidField(myRow,StoConData.DESCRIPTION_FIELD,StoConData.DESCRIPTION_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				if (isValid)
				{	//�жϼ�λ�����Ƿ��ظ���
					if (!IsValidNewDescription(myRow[StoConData.STOCODE_FIELD].ToString(),myRow[StoConData.DESCRIPTION_FIELD].ToString()))
					{
						this.Message = StoConData.DESCRIPTION_NOT_UNIQUE;
						isValid = false;
					}
				}
				else
				{
					this.Message = InputCheck.ErrorInfo;
				}
			}
			else
			{
				this.Message = StoConData.NO_ROW ;
				isValid = false;
			}
			//������ӡ�
			if (isValid)
			{
				StoCons myStoCons = new StoCons();

				isValid = myStoCons.Add(myStoConData);
				this.Message = myStoCons.Message;
			}
			return isValid;
		}

		/// <summary>
		/// ��λ���ġ�
		/// </summary>
		/// <param name="myStoConData">StoConData:	�������ݼ���</param>
		/// <returns>bool:	���ĳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(StoConData myStoConData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count > 0)
			{
				DataRow myRow = myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0];
				//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
				isValid = InputCheck.IsValidField(myRow,StoConData.DESCRIPTION_FIELD,StoConData.DESCRIPTION_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				if (isValid)
				{	//�жϼ�λ�����Ƿ��ظ���
					if ( !IsValidDescription(int.Parse(myRow[StoConData.CODE_FIELD].ToString()),myRow[StoConData.STOCODE_FIELD].ToString(),myRow[StoConData.DESCRIPTION_FIELD].ToString()) )
					{
						isValid = false;
						this.Message = StoConData.DESCRIPTION_NOT_UNIQUE;
					}
				}
				else
				{
					this.Message = InputCheck.ErrorInfo;
				}
			}
			else
			{
				this.Message = StoConData.NO_ROW;
				isValid = false;
			}
			//���ݸ��ġ�
			if (isValid)
			{
				StoCons myStoCons = new StoCons();
				isValid = myStoCons.Update(myStoConData);
				this.Message = myStoCons.Message;
			}
			return isValid;
		}
		/// <summary>
		/// ��λɾ����
		/// </summary>
		/// <param name="myStoConData">StoConData:	��λ����ʵ�塣</param>
		/// <returns>bool:	��λɾ���ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(StoConData myStoConData)
		{
			bool isValid = true;
			if (myStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count > 0)
			{
				StoCons myStoCons = new StoCons();
				isValid = myStoCons.Delete(myStoConData);
				this.Message = myStoCons.Message;
			}
			else
			{	
				this.Message = StoConData.NO_ROW;	
				isValid = false;
			}
			return isValid;
		}
		/// <summary>
		/// ���ݴ���ļ�λ��Ŵ����м�λ��ɾ����
		/// </summary>
		/// <param name="Codes">string:	��λ��Ŵ���</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool isValid = true;
			if (Codes == null || Codes =="")
			{
				this.Message = StoConData.NO_ROW;
				isValid = false;
			}
			else
			{
				StoCons myStoCons = new StoCons();
				isValid = myStoCons.Delete(Codes);
				this.Message = myStoCons.Message;
			}
			return isValid;
		}
		/// <summary>
		/// ��λ����ʱ���жϼ�λ���Ƶ���Ч�ԡ�
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="Description">string:	��λ���ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewDescription(string StoCode, string Description)
		{
			StoCons myStoCons = new StoCons();
			return myStoCons.GetStoConByStoCodeAndDescription(StoCode, Description).Tables[StoConData.STOCON_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// ��λ����ʱ���жϼ�λ�����Ƿ���Ч��
		/// </summary>
		/// <param name="Code">int:	��λ��š�</param>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="Description">string:	��λ���ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidDescription(int Code, string StoCode, string Description)
		{
			StoConData myStoConData;
			StoCons myStoCons = new StoCons();
			myStoConData = myStoCons.GetStoConByStoCodeAndDescription(StoCode,Description);
			//������ݲֿ��źͼ�λ���Ʋ�ѯ��û�н����˵������Ч�ġ�
			if ( myStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//����н���������ǽ�������Ǳ���Ҳ����Ч�ġ�
			{
				return int.Parse(myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.CODE_FIELD].ToString())==Code?true:false;
			}
		}
	}
}
