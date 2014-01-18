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
	/// �ɹ�Ա ҵ�����㡣
	/// </summary>
	public class Pslp : Messages
	{
		/// <summary>
		/// �ɹ�Ա ���ӡ�
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Insert(PslpData myPslpData)
		{
			bool isValid = true;
			//�жϴ��������ʵ���Ƿ�Ϊ�ա�
			if (myPslpData.Tables[PslpData.PSLP_TABLE].Rows.Count == 0)
			{
				this.Message = PslpData.NO_ROW ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0];
			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
			isValid = InputCheck.IsValidField(myRow,PslpData.CODE_FIELD,PslpData.CODE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,5) && isValid;
			isValid = InputCheck.IsValidField(myRow,PslpData.DESCRIPTION_FIELD,PslpData.DESCRIPTION_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			
			if ( !isValid)//���������鲻ͨ������ֱ�ӷ��ء�
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//�жϲɹ�Ա�����Ƿ���Ч����Чֱ�ӷ��ء�
			if ( !IsValidNewCode(myRow[PslpData.CODE_FIELD].ToString()))//�ɹ�Ա������Ч��
			{
				this.Message = PslpData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//ǰ������ݼ�鶼ͨ���ˡ�						
			//����������Ӳ�����
			{
				Pslps myPslps = new Pslps();
				isValid = myPslps.Add(myPslpData);
				this.Message = myPslps.Message;
				return isValid;
			}
		}

		/// <summary>
		/// �ɹ�Ա �޸ġ�
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(PslpData myPslpData)
		{
			bool isValid = true;
			//�жϴ��������ʵ���Ƿ�Ϊ�ա�
			if (myPslpData.Tables[PslpData.PSLP_TABLE].Rows.Count == 0)
			{
				this.Message = PslpData.NO_ROW ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0];
			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
			isValid = InputCheck.IsValidField(myRow,PslpData.CODE_FIELD,PslpData.CODE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,5) && isValid;
			isValid = InputCheck.IsValidField(myRow,PslpData.DESCRIPTION_FIELD,PslpData.DESCRIPTION_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			//����������ݲ��������ݿ�Ҫ����ֱ�ӷ��ء�
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//�жϲɹ�Ա�������Ч�ԣ���Чֱ�ӷ��ء�
			if ( !IsValidCode(myRow[PslpData.OLDCODE_FIELD].ToString(),myRow[PslpData.CODE_FIELD].ToString()))//�ɹ�Ա������Ч��
			{
				this.Message = PslpData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			
			//�����޸ġ�
			{
				Pslps myPslps = new Pslps();
				isValid = myPslps.Update(myPslpData);
				this.Message = myPslps.Message;
				return isValid;
			}
		}
		/// <summary>
		/// �ɹ�Ա ɾ����
		/// </summary>
		/// <param name="myPslpData">PslpData:	�ɹ�Ա����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(PslpData myPslpData)
		{
			bool isValid = true;
			if (myPslpData.Tables[PslpData.PSLP_TABLE].Rows.Count > 0)
			{
				Pslps myPslps = new Pslps();
				isValid = myPslps.Delete(myPslpData);
				this.Message = myPslps.Message;
			}
			else
			{	
				this.Message = PslpData.NO_ROW;	
			}
			return isValid;
		}
		/// <summary>
		/// ���ݴ���Ĳɹ�Ա���봮���вɹ�Աɾ����
		/// </summary>
		/// <param name="Codes">string:	�ɹ�Ա�����ַ�����</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(string Codes)
		{
			bool isValid = true;
			if (Codes != null && Codes != "")
			{
				Pslps myPslps = new Pslps();
				isValid = myPslps.Delete(Codes);
				this.Message = myPslps.Message;
			}
			else
			{	
				this.Message = PslpData.NO_ROW;	
			}
			return isValid;
		}
		/// <summary>
		/// �ɹ�Ա ����ʱ�жϴ����Ƿ���Ч��
		/// </summary>
		/// <param name="Code">string:	�ɹ�Ա��š�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewCode(string Code)
		{
			Pslps myPslps = new Pslps();
			return myPslps.GetPslpByCode(Code).Tables[PslpData.PSLP_TABLE].Rows.Count > 0 ? false:true;
		}
		
		/// <summary>
		/// �ɹ�Ա �޸�ʱ�ж� �����Ƿ���Ч��
		/// </summary>
		/// <param name="OldCode">string:	�޸�ǰ��š�</param>
		/// <param name="Code">string:	�޸ĺ��š�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidCode(string OldCode, string Code)
		{
			PslpData myPslpData;
			Pslps myPslps = new Pslps();
			myPslpData = myPslps.GetPslpByCode(Code);
			if ( myPslpData.Tables[PslpData.PSLP_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else
			{
				return OldCode==Code?true:false;
			}
		}
	}
}
