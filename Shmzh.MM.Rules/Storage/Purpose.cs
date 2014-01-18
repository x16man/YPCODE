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
	/// ��;ҵ�����㡣
	/// </summary>
	public class Purpose : Messages
	{
		/// <summary>
		/// ��;���ӡ�
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	��;����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Add(PurposeData myPurposeData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count == 0)
			{
				this.Message = StoData.NO_ROW ;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0];
			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε���ڡ�
			isValid = InputCheck.IsValidField(myRow,PurposeData.CODE_FIELD,PurposeData.CODE_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PurposeData.DESCRIPTION_FIELD,PurposeData.DESCRIPTION_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PurposeData.TARGETACC_FIELD,PurposeData.TARGETACC_LABEL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PurposeData.ENABLE_FIELD,PurposeData.ENABLE_LABEL,true,InputCheck.Enum_Input_Format.Format_Int,-1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PurposeData.PROJECT_CODE_FIELD,PurposeData.CODE_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			isValid = myRow[PurposeData.DESCRIPTION_FIELD].ToString().IndexOf(",")>=0?false:true;
			if (!isValid)
			{
				this.Message = "��;�����в�������ڶ���!";
				return isValid;
			}
			//�ж���;�����Ƿ��ظ���
			if (!IsValidNewCode(myRow[PurposeData.CODE_FIELD].ToString()))
			{
				this.Message = PurposeData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�ж���;�����Ƿ��ظ���
            //2012-01-09 Ӧ�ų�Ҫ��������;�����ظ���
            //if ( !IsValidNewDescription(myRow[PurposeData.DESCRIPTION_FIELD].ToString()) )
            //{
            //    this.Message = PurposeData.DESCRIPTION_NOT_UNIQUE;
            //    isValid = false;
            //    return isValid;
            //}
				
			//������ӡ�
			if (true)
			{
				Purposes myPurposes = new Purposes();

				isValid = myPurposes.Add(myPurposeData);
				this.Message = myPurposes.Message;
			}
			return isValid;
		}
		/// <summary>
		/// ��;�޸ġ�
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	��;����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(PurposeData myPurposeData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count == 0)
			{
				this.Message = PurposeData.NO_ROW;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0];
			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε���ڡ�
			isValid = InputCheck.IsValidField(myRow,PurposeData.CODE_FIELD,PurposeData.CODE_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PurposeData.DESCRIPTION_FIELD,PurposeData.DESCRIPTION_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PurposeData.TARGETACC_FIELD,PurposeData.TARGETACC_LABEL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PurposeData.ENABLE_FIELD,PurposeData.ENABLE_LABEL,true,InputCheck.Enum_Input_Format.Format_Int,-1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PurposeData.PROJECT_CODE_FIELD,PurposeData.CODE_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			isValid = myRow[PurposeData.DESCRIPTION_FIELD].ToString().IndexOf(",")>=0?false:true;
			if (!isValid)
			{
				this.Message = "��;�����в�������ڶ���!";
				return isValid;
			}
			//�ж���;����Ƿ��ظ���
			if ( !IsValidCode(myRow[PurposeData.OLDCODE_FIELD].ToString(),myRow[PurposeData.CODE_FIELD].ToString()) )
			{
				this.Message = PurposeData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//�ж���;�����Ƿ��ظ���
            //2012-01-09 Ӧ�ų�Ҫ��������;�����ظ���
            //if ( !IsValidDescription(myRow[PurposeData.OLDCODE_FIELD].ToString(),myRow[PurposeData.DESCRIPTION_FIELD].ToString()) )
            //{
            //    this.Message = PurposeData.DESCRIPTION_NOT_UNIQUE;
            //    isValid = false;
            //    return isValid;
            //}
			//���ݸ��ġ�
			if (true)
			{
				Purposes myPurposes = new Purposes();
				isValid = myPurposes.Update(myPurposeData);
				this.Message = myPurposes.Message;
			}
			return isValid;
		}
		/// <summary>
		/// ��;ɾ����
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	��;����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(PurposeData myPurposeData)
		{
			bool isValid = true;
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count > 0)
			{
				
				Purposes myPurposes = new Purposes();

				isValid = myPurposes.Delete(myPurposeData);
				this.Message = myPurposes.Message;
			}
			else
			{	
				this.Message = PurposeData.NO_ROW;	
				isValid = false;
			}
			return isValid;
		}
		/// <summary>
		/// ���ݴ������;���봮������;ɾ����
		/// </summary>
		/// <param name="Codes">string:	��;���봮��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete (string Codes)
		{
			bool isValid = true;
			if (Codes != null && Codes != "")
			{
				Purposes myPurposes = new Purposes();
				isValid = myPurposes.Delete(Codes);
				this.Message = myPurposes.Message;
			}
			else
			{
				this.Message = PurposeData.NO_OBJECT;
				isValid = false;
			}
			return isValid;
		}
		/// <summary>
		/// ��;����ʱ�ж���;�����Ƿ���Ч��
		/// </summary>
		/// <param name="Code">string:	��;���롣</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewCode(string Code)
		{
			Purposes myPurposes = new Purposes();
			return myPurposes.GetPurposeByCode(Code).Tables[PurposeData.USE_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// ��;����ʱ�ж���;�����Ƿ���Ч��
		/// </summary>
		/// <param name="Description">string:	��;���ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewDescription(string Description)
		{
			Purposes myPurposes = new Purposes();
			return myPurposes.GetPurposeByDescription(Description).Tables[PurposeData.USE_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// ��;�޸�ʱ�ж���;�������Ч�ԡ�
		/// </summary>
		/// <param name="OldCode">string:	�޸�ǰ�Ĵ��롣</param>
		/// <param name="Code">string:	�޸ĺ�Ĵ��롣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		private bool IsValidCode(string OldCode, string Code)
		{
			PurposeData myPurposeData;
			Purposes myPurposes = new Purposes();
			myPurposeData = myPurposes.GetPurposeByCode(Code);
			//���������;���Ʋ�ѯ��û�н����˵������Ч�ġ�
			if ( myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//����н���������ǽ�������Ǳ���Ҳ����Ч�ġ�
			{
				return myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString() == OldCode?true:false;
			}
		}
		/// <summary>
		/// ��;�޸�ʱ�ж���;�����Ƿ���Ч��
		/// </summary>
		/// <param name="Code">string:	��;���롣</param>
		/// <param name="Description">string:	��;���ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidDescription(string OldCode, string Description)
		{
			PurposeData myPurposeData;
			Purposes myPurposes = new Purposes();
			myPurposeData = myPurposes.GetPurposeByDescription(Description);
			//���������;���Ʋ�ѯ��û�н����˵������Ч�ġ�
			if ( myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//����н���������ǽ�������Ǳ���Ҳ����Ч�ġ�
			{
				return myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString() == OldCode?true:false;
			}
		}
	}
}
