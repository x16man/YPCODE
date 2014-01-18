using System;
using System.Data;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;
using MZHCommon.Input;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// Category ��ժҪ˵����
	/// </summary>
	public class Category:Messages
	{
		/// <summary>
		/// ����Ŀ¼
		/// </summary>
		/// <param name="oCategoryData">Ŀ¼ʵ��</param>
		/// <returns>true or false</returns>
		public bool Insert(CategoryData oCategoryData)
		{
			bool isValid=true;

			DataRow aRow=oCategoryData.Tables[CategoryData.CATEGORIES_TABLE].Rows[0];

			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
            isValid = InputCheck.IsValidField(aRow, CategoryData.CODE_FIELD, CategoryData.CODE_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Int16, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.DESCRIPTION_FIELD, CategoryData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 30) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.SERIAL_FIELD,CategoryData.SERIAL_LABEL, true, InputCheck.Enum_Input_Format.Format_Int16, -1) && isValid;

			isValid = InputCheck.IsValidField(aRow, CategoryData.STORAGEACC_FIELD,CategoryData.STORAGEACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.TRANSFERACC_FIELD,CategoryData.TRANSFERACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.RETURNACC_FIELD,CategoryData.RETURNACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;

			if (isValid)
			{
				//�жϱ����Ƿ��Ѿ�����
				if (IsExistCategoryCode(int.Parse(aRow[CategoryData.CODE_FIELD].ToString())))
				{
					this.Message=CategoryData.CODE_NOT_UNIQUE;
					isValid=false;
				}
			}
			else
			{
				this.Message=InputCheck.ErrorInfo;
			}

			if(isValid)
			{
				Categories oCategories=new Categories();

				if (oCategories.InsertCategory(oCategoryData)==false)
				{
					this.Message=oCategories.Message;
					isValid=false;
				}
			}
			return isValid;
		}		//End Insert


		/// <summary>
		/// ����Ŀ¼����Ҫ�����ơ���Ŀ
		/// </summary>
		/// <param name="oCategoryData">Ŀ¼ʵ��</param>
		/// <returns>true or false</returns>
		public bool Update(CategoryData oCategoryData)
		{
			bool isValid=true;

			DataRow aRow=oCategoryData.Tables[CategoryData.CATEGORIES_TABLE].Rows[0];

			//����ֶ�ֵ�ĺϷ���,������Ҫ�����жϵ��ֶε����
			isValid = InputCheck.IsValidField(aRow, CategoryData.DESCRIPTION_FIELD, CategoryData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 30) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.SERIAL_FIELD,CategoryData.SERIAL_LABEL, true, InputCheck.Enum_Input_Format.Format_Int16, -1) && isValid;

			isValid = InputCheck.IsValidField(aRow, CategoryData.STORAGEACC_FIELD,CategoryData.STORAGEACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.TRANSFERACC_FIELD,CategoryData.TRANSFERACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.RETURNACC_FIELD,CategoryData.RETURNACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			
			if (!isValid)
			{
				this.Message=InputCheck.ErrorInfo;
			}

			if(isValid)
			{
				Categories oCategories=new Categories();

				if (oCategories.UpdateCategroy(oCategoryData)==false)
				{
					this.Message=oCategories.Message;
					isValid=false;
				}
			}
			return isValid;
		}		//End Update


		/// <summary>
		/// ɾ��
		/// </summary>
		/// <param name="Code">����б�</param>
		/// <returns></returns>
		public bool Delete(string Code)
		{
			//1.�ֽ�Code��
			//2.��ÿһ��Code�����жϣ��Ƿ��Ѿ����ڹ���������������
			//3.�Ѿ������ķ����б��з���,����ɾ����ɾ��
			//4.
			string CanNotDelte="";
			string CanDelete;

			CanDelete=DoWithDeleteCode(Code,CanNotDelte);

			if (CanNotDelte=="") this.Message=CanNotDelte;

			return (new Categories()).DeleteCategoryByCode(CanDelete);
			
		}

		//��ÿһ��Code�����жϣ��Ƿ��Ѿ����ڹ���������������
		private string DoWithDeleteCode(string Code,string CanNotDelte)
		{
			return Code;
		}

		/// <summary>
		/// �õ�Ŀ¼
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public CategoryData GetCategoryByCode(int Code)
		{
			return (new Categories()).GetCategoryByCode(Code);
		}	//End GetCategoryByCode


		/// <summary>
		/// �õ�����Ŀ¼
		/// </summary>
		/// <returns>Ŀ¼ʵ��</returns>
		public CategoryData GetCategories()
		{
			return (new Categories()).GetCategoryByCode(-1);
		}	//End GetCategories
		
		/// <summary>
		/// ��ȡ��Ч��Ŀ¼��
		/// </summary>
		/// <returns>Ŀ¼ʵ��</returns>
		public CategoryData GetAvailableCategories()
		{
			return (new Categories()).GetCategoryByCode(-2);
		}
		
		/// <summary>
		/// �ж�Ŀ¼�Ƿ��Ѿ�����
		/// </summary>
		/// <param name="Code">Ŀ¼���</param>
		/// <returns>���ڻ򲻴���</returns>
		public bool IsExistCategoryCode(int Code)
		{
			bool ret=true;

			if(Code!=-1)
			{
				if ((new Categories()).GetCategoryByCode(Code).Tables[CategoryData.CATEGORIES_TABLE].Rows.Count==0)
				{
					ret=false;
				}
			}
			return ret;
		}	//End IsExistCategoryCode
	
	}		//End class
}	//End namespace
