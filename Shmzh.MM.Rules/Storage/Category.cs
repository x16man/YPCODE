using System;
using System.Data;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Common;
using MZHCommon.Input;

namespace Shmzh.MM.BusinessRules
{
	/// <summary>
	/// Category 的摘要说明。
	/// </summary>
	public class Category:Messages
	{
		/// <summary>
		/// 插入目录
		/// </summary>
		/// <param name="oCategoryData">目录实体</param>
		/// <returns>true or false</returns>
		public bool Insert(CategoryData oCategoryData)
		{
			bool isValid=true;

			DataRow aRow=oCategoryData.Tables[CategoryData.CATEGORIES_TABLE].Rows[0];

			//检查字段值的合法性,所有需要加以判断的字段的入口
            isValid = InputCheck.IsValidField(aRow, CategoryData.CODE_FIELD, CategoryData.CODE_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Int16, -1) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.DESCRIPTION_FIELD, CategoryData.DESCRIPTION_NOT_NULL, true, InputCheck.Enum_Input_Format.Format_Char, 30) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.SERIAL_FIELD,CategoryData.SERIAL_LABEL, true, InputCheck.Enum_Input_Format.Format_Int16, -1) && isValid;

			isValid = InputCheck.IsValidField(aRow, CategoryData.STORAGEACC_FIELD,CategoryData.STORAGEACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.TRANSFERACC_FIELD,CategoryData.TRANSFERACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;
			isValid = InputCheck.IsValidField(aRow, CategoryData.RETURNACC_FIELD,CategoryData.RETURNACC_LABEL, false, InputCheck.Enum_Input_Format.Format_Char, 20) && isValid;

			if (isValid)
			{
				//判断编码是否已经存在
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
		/// 更新目录，主要有名称、科目
		/// </summary>
		/// <param name="oCategoryData">目录实体</param>
		/// <returns>true or false</returns>
		public bool Update(CategoryData oCategoryData)
		{
			bool isValid=true;

			DataRow aRow=oCategoryData.Tables[CategoryData.CATEGORIES_TABLE].Rows[0];

			//检查字段值的合法性,所有需要加以判断的字段的入口
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
		/// 删除
		/// </summary>
		/// <param name="Code">编号列表</param>
		/// <returns></returns>
		public bool Delete(string Code)
		{
			//1.分解Code串
			//2.对每一个Code进行判断，是否已经存在关联的物料主数据
			//3.已经关联的放在列表中返回,可以删除的删除
			//4.
			string CanNotDelte="";
			string CanDelete;

			CanDelete=DoWithDeleteCode(Code,CanNotDelte);

			if (CanNotDelte=="") this.Message=CanNotDelte;

			return (new Categories()).DeleteCategoryByCode(CanDelete);
			
		}

		//对每一个Code进行判断，是否已经存在关联的物料主数据
		private string DoWithDeleteCode(string Code,string CanNotDelte)
		{
			return Code;
		}

		/// <summary>
		/// 得到目录
		/// </summary>
		/// <param name="Code"></param>
		/// <returns></returns>
		public CategoryData GetCategoryByCode(int Code)
		{
			return (new Categories()).GetCategoryByCode(Code);
		}	//End GetCategoryByCode


		/// <summary>
		/// 得到所有目录
		/// </summary>
		/// <returns>目录实体</returns>
		public CategoryData GetCategories()
		{
			return (new Categories()).GetCategoryByCode(-1);
		}	//End GetCategories
		
		/// <summary>
		/// 获取有效的目录。
		/// </summary>
		/// <returns>目录实体</returns>
		public CategoryData GetAvailableCategories()
		{
			return (new Categories()).GetCategoryByCode(-2);
		}
		
		/// <summary>
		/// 判断目录是否已经存在
		/// </summary>
		/// <param name="Code">目录编号</param>
		/// <returns>存在或不存在</returns>
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
