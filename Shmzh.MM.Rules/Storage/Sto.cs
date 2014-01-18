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
	public class Sto : Messages
	{
		
		public bool Add(StoData myStoData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myStoData.Tables[StoData.STO_TABLE].Rows.Count > 0)
			{
				DataRow myRow = myStoData.Tables[StoData.STO_TABLE].Rows[0];
				//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε���ڡ�
				isValid = InputCheck.IsValidField(myRow,StoData.CODE_FIELD,StoData.CODE_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,10) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.DESCRIPTION_FIELD,StoData.DESCRIPTION_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.STOACC_FIELD,StoData.STOACC_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.TRFACC_FIELD,StoData.TRFACC_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.RETURNACC_FIELD,StoData.RETURNACC_FIELD,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.ADDRESS_FIELD,StoData.ADDRESS_NULL,false,InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.RELATION_FIELD,StoData.RELATION_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				
				if (isValid)
				{	//�жϲֿ����Ƿ��ظ���
					if (IsValidNewCode(myRow[StoData.CODE_FIELD].ToString()))
					{	//�жϲֿ������Ƿ��ظ���
						if ( !IsValidNewDescription(myRow[StoData.DESCRIPTION_FIELD].ToString()) )
						{
							this.Message = StoData.DESCRIPTION_NOT_UNIQUE;
							isValid = false;
						}
					}
					else
					{
						this.Message = StoData.CODE_NOT_UNIQUE;
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
				this.Message = StoData.NO_ROW ;
				isValid = false;
			}
			//������ӡ�
			if (isValid)
			{
				Stos myStos = new Stos();

				isValid = myStos.Add(myStoData);
				this.Message = myStos.Message;
			}
			return isValid;
		}
		/// <summary>
		/// �ֿ��޸ġ�
		/// </summary>
		/// <param name="myStoData">StoData:	�ֿ�����ʵ�塣</param>
		/// <returns>bool:	�޸ĳɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(StoData myStoData,string strOldName)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myStoData.Tables[StoData.STO_TABLE].Rows.Count > 0)
			{
				DataRow myRow = myStoData.Tables[StoData.STO_TABLE].Rows[0];
				//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε���ڡ�
				isValid = InputCheck.IsValidField(myRow,StoData.CODE_FIELD,StoData.CODE_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,10) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.DESCRIPTION_FIELD,StoData.DESCRIPTION_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.STOACC_FIELD,StoData.STOACC_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.TRFACC_FIELD,StoData.TRFACC_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.RETURNACC_FIELD,StoData.RETURNACC_FIELD,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.ADDRESS_FIELD,StoData.ADDRESS_NULL,false,InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.RELATION_FIELD,StoData.RELATION_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				if (isValid)
				{
                    if (strOldName != myRow[StoData.DESCRIPTION_FIELD].ToString())
                    {
                        //�жϲֿ������Ƿ��ظ���
                        if (!IsValidDescription(myRow[StoData.CODE_FIELD].ToString(), myRow[StoData.DESCRIPTION_FIELD].ToString()))
                        {
                            this.Message = StoData.DESCRIPTION_NOT_UNIQUE;
                            isValid = false;
                        }
                    }
				}
				else
				{
					this.Message = InputCheck.ErrorInfo;
				}
			}
			else
			{
				this.Message = StoData.NO_ROW;
				isValid = false;
			}
			//���ݸ��ġ�
			if (isValid)
			{
				Stos myStos = new Stos();
				isValid = myStos.Update(myStoData);
				this.Message = myStos.Message;
			}
			return isValid;
		}
		/// <summary>
		/// �ֿ�ɾ����
		/// </summary>
		/// <param name="myStoData">StoData:	�ֿ�����ʵ�塣</param>
		/// <returns>bool:	ɾ���ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(StoData myStoData)
		{
			bool isValid = true;
			if (myStoData.Tables[StoData.STO_TABLE].Rows.Count > 0)
			{
				
				Stos myStos = new Stos();

				isValid = myStos.Delete(myStoData);
				this.Message = myStos.Message;
			}
			else
			{	
				this.Message = StoData.NO_ROW;	
			}
			return isValid;
		}
		/// <summary>
		/// ���ݴ���Ĳֿ���봮���вֿ�ɾ����
		/// </summary>
		/// <param name="Codes">string:	�ֿ���봮��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete (string Codes)
		{
			bool isValid = true;
			Stos myStos = new Stos();
			isValid = myStos.Delete(Codes);
			this.Message = myStos.Message;
			return isValid;
		}
		/// <summary>
		/// �ֿ�����ʱ�жϲֿ����Ƿ���Ч��
		/// </summary>
		/// <param name="Code">string:	�ֿ��š�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewCode(string Code)
		{
			Stos myStos = new Stos();
			return myStos.GetStoByCode(Code).Tables[StoData.STO_TABLE].Rows.Count > 0 ? false:true;
		}

		/// <summary>
		/// �ֿ�����ʱ�жϲֿ������Ƿ���Ч��
		/// </summary>
		/// <param name="Description">string:	�ֿ����ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewDescription(string Description)
		{
			Stos myStos = new Stos();
			return myStos.GetStoByDescription(Description).Tables[StoData.STO_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// �ֿ��޸�ʱ�жϲֿ������Ƿ���Ч��
		/// </summary>
		/// <param name="Code">string:	�ֿ��š�</param>
		/// <param name="Description">string:	�ֿ����ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidDescription(string Code, string Description)
		{
			StoData myStoData;
			Stos myStos = new Stos();
			myStoData = myStos.GetStoByDescription(Description);
			//������ݲֿ����Ʋ�ѯ��û�н����˵������Ч�ġ�
			if ( myStoData.Tables[StoData.STO_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//����н���������ǽ�������Ǳ���Ҳ����Ч�ġ�
			{
				return myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.DESCRIPTION_FIELD].ToString()==Code?true:false;
			}
		}
	}
}
