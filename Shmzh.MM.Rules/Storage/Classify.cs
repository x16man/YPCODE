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
	public class Classify : Messages
	{
		/// <summary>
		/// ��;���ӡ�
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	��;����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Add(ClassifyData myClassifyData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				this.Message = StoData.NO_ROW ;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0];
			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε���ڡ�
			isValid = InputCheck.IsValidField(myRow,ClassifyData.CODE_FIELD,ClassifyData.CODE_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,ClassifyData.DESCRIPTION_FIELD,ClassifyData.DESCRIPTION_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
	
			isValid = InputCheck.IsValidField(myRow,ClassifyData.ENABLE_FIELD,ClassifyData.ENABLE_LABEL,true,InputCheck.Enum_Input_Format.Format_Int,-1) && isValid;
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//�ж���;�����Ƿ��ظ���
			if (!IsValidNewCode(myRow[ClassifyData.CODE_FIELD].ToString()))
			{
				this.Message = ClassifyData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
//			//�ж���;�����Ƿ��ظ���
//			if ( !IsValidNewDescription(myRow[ClassifyData.DESCRIPTION_FIELD].ToString()) )
//			{
//				this.Message = ClassifyData.DESCRIPTION_NOT_UNIQUE;
//				isValid = false;
//				return isValid;
//			}
				
			//������ӡ�
			if (true)
			{
				Classifys myClassifys = new Classifys();

				isValid = myClassifys.Add(myClassifyData);
				this.Message = myClassifys.Message;
			}
			return isValid;
		}
		/// <summary>
		/// ��;�޸ġ�
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	��;����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Update(ClassifyData myClassifyData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				this.Message = ClassifyData.NO_ROW;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0];
			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε���ڡ�
			isValid = InputCheck.IsValidField(myRow,ClassifyData.CODE_FIELD,ClassifyData.CODE_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,ClassifyData.DESCRIPTION_FIELD,ClassifyData.DESCRIPTION_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			
			isValid = InputCheck.IsValidField(myRow,ClassifyData.ENABLE_FIELD,ClassifyData.ENABLE_LABEL,true,InputCheck.Enum_Input_Format.Format_Int,-1) && isValid;
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//�ж���;����Ƿ��ظ���
			if ( !IsValidCode(myRow[ClassifyData.OLDCODE_FIELD].ToString(),myRow[ClassifyData.CODE_FIELD].ToString()) )
			{
				this.Message = ClassifyData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
//			//�ж���;�����Ƿ��ظ���
//			if ( !IsValidDescription(myRow[ClassifyData.OLDCODE_FIELD].ToString(),myRow[ClassifyData.DESCRIPTION_FIELD].ToString()) )
//			{
//				this.Message = ClassifyData.DESCRIPTION_NOT_UNIQUE;
//				isValid = false;
//				return isValid;
//			}
			//���ݸ��ġ�
			if (true)
			{
				Classifys myClassifys = new Classifys();
				isValid = myClassifys.Update(myClassifyData);
				this.Message = myClassifys.Message;
			}
			return isValid;
		}
		/// <summary>
		/// ��;ɾ����
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	��;����ʵ�塣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete(ClassifyData myClassifyData)
		{
			bool isValid = true;
			//���ݼ��顣
			if (myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				this.Message = ClassifyData.NO_ROW;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0];
			//�ж���;����Ƿ����¼���;��š�
			if ( IsParentClassify(myRow[ClassifyData.CODE_FIELD].ToString()))
			{
				this.Message = ClassifyData.HAS_CHILD_CLASSIFY;
				isValid = false;
				return isValid;
			}

			Classifys myClassifys = new Classifys();
			isValid = myClassifys.Delete(myClassifyData);
			this.Message = myClassifys.Message;
			return isValid;
		}
		/// <summary>
		/// ���ݴ������;���봮������;ɾ����
		/// </summary>
		/// <param name="Codes">string:	��;���봮��</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		public bool Delete (string Code)
		{
			bool isValid = true;
			if (Code == null || Code == "")
			{
				this.Message = ClassifyData.NO_OBJECT;
				isValid = false;
				return isValid;
			}
			//�ж���;����Ƿ����¼���;��š�
			if ( IsParentClassify(Code))
			{
				this.Message = ClassifyData.HAS_CHILD_CLASSIFY;
				isValid = false;
				return isValid;
			}
			Classifys myClassifys = new Classifys();
			isValid = myClassifys.Delete(Code);
			this.Message = myClassifys.Message;
		

			return isValid;
		}
		/// <summary>
		/// ��;����ʱ�ж���;�����Ƿ���Ч��
		/// </summary>
		/// <param name="Code">string:	��;���롣</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewCode(string Code)
		{
			Classifys myClassifys = new Classifys();
			return myClassifys.GetClassifyByCode(Code).Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// ��;����ʱ�ж���;�����Ƿ���Ч��
		/// </summary>
		/// <param name="Description">string:	��;���ơ�</param>
		/// <returns>bool:	��Ч����true����Ч����false��</returns>
		private bool IsValidNewDescription(string Description)
		{
			Classifys myClassifys = new Classifys();
			return myClassifys.GetClassifyByDescription(Description).Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// ��;�޸�ʱ�ж���;�������Ч�ԡ�
		/// </summary>
		/// <param name="OldCode">string:	�޸�ǰ�Ĵ��롣</param>
		/// <param name="Code">string:	�޸ĺ�Ĵ��롣</param>
		/// <returns>bool:	�ɹ�����true��ʧ�ܷ���false��</returns>
		private bool IsValidCode(string OldCode, string Code)
		{
			ClassifyData myClassifyData;
			Classifys myClassifys = new Classifys();
			myClassifyData = myClassifys.GetClassifyByCode(Code);
			//���������;���Ʋ�ѯ��û�н����˵������Ч�ġ�
			if ( myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//����н���������ǽ�������Ǳ���Ҳ����Ч�ġ�
			{
				return myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.CODE_FIELD].ToString() == OldCode?true:false;
			}
		}
		/// <summary>
		/// �жϴ���;����Ƿ���������;�ĸ���;
		/// </summary>
		/// <param name="ClassifyID"></param>
		/// <returns></returns>
		private bool IsParentClassify(string ClassifyID)
		{
			ClassifyData myClassifyData;
			Classifys myClassifys = new Classifys();
			myClassifyData = myClassifys.GetParentClassifyByCode(ClassifyID);
			//���������;���Ʋ�ѯ��û�н����˵������Ч�ġ�
			if ( myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count > 0)
			{
				return true;
			}
			else//����н���������ǽ�������Ǳ���Ҳ����Ч�ġ�
			{
				return false;
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
			ClassifyData myClassifyData;
			Classifys myClassifys = new Classifys();
			myClassifyData = myClassifys.GetClassifyByDescription(Description);
			//���������;���Ʋ�ѯ��û�н����˵������Ч�ġ�
			if ( myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//����н���������ǽ�������Ǳ���Ҳ����Ч�ġ�
			{
				return myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.CODE_FIELD].ToString() == OldCode?true:false;
			}
		}
	}
}
