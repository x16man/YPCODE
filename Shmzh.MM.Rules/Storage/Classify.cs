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
	/// 用途业务规则层。
	/// </summary>
	public class Classify : Messages
	{
		/// <summary>
		/// 用途增加。
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	用途数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Add(ClassifyData myClassifyData)
		{
			bool isValid = true;
			//数据检验。
			if (myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				this.Message = StoData.NO_ROW ;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0];
			//检查字段值的合法性,所有需要加以判断的字段的入口。
			isValid = InputCheck.IsValidField(myRow,ClassifyData.CODE_FIELD,ClassifyData.CODE_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,ClassifyData.DESCRIPTION_FIELD,ClassifyData.DESCRIPTION_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
	
			isValid = InputCheck.IsValidField(myRow,ClassifyData.ENABLE_FIELD,ClassifyData.ENABLE_LABEL,true,InputCheck.Enum_Input_Format.Format_Int,-1) && isValid;
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//判断用途代码是否重复。
			if (!IsValidNewCode(myRow[ClassifyData.CODE_FIELD].ToString()))
			{
				this.Message = ClassifyData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
//			//判断用途名称是否重复。
//			if ( !IsValidNewDescription(myRow[ClassifyData.DESCRIPTION_FIELD].ToString()) )
//			{
//				this.Message = ClassifyData.DESCRIPTION_NOT_UNIQUE;
//				isValid = false;
//				return isValid;
//			}
				
			//数据添加。
			if (true)
			{
				Classifys myClassifys = new Classifys();

				isValid = myClassifys.Add(myClassifyData);
				this.Message = myClassifys.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 用途修改。
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	用途数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(ClassifyData myClassifyData)
		{
			bool isValid = true;
			//数据检验。
			if (myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				this.Message = ClassifyData.NO_ROW;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0];
			//检查字段值的合法性,所有需要加以判断的字段的入口。
			isValid = InputCheck.IsValidField(myRow,ClassifyData.CODE_FIELD,ClassifyData.CODE_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,ClassifyData.DESCRIPTION_FIELD,ClassifyData.DESCRIPTION_LABEL,true,InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			
			isValid = InputCheck.IsValidField(myRow,ClassifyData.ENABLE_FIELD,ClassifyData.ENABLE_LABEL,true,InputCheck.Enum_Input_Format.Format_Int,-1) && isValid;
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//判断用途编号是否重复。
			if ( !IsValidCode(myRow[ClassifyData.OLDCODE_FIELD].ToString(),myRow[ClassifyData.CODE_FIELD].ToString()) )
			{
				this.Message = ClassifyData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
//			//判断用途名称是否重复。
//			if ( !IsValidDescription(myRow[ClassifyData.OLDCODE_FIELD].ToString(),myRow[ClassifyData.DESCRIPTION_FIELD].ToString()) )
//			{
//				this.Message = ClassifyData.DESCRIPTION_NOT_UNIQUE;
//				isValid = false;
//				return isValid;
//			}
			//数据更改。
			if (true)
			{
				Classifys myClassifys = new Classifys();
				isValid = myClassifys.Update(myClassifyData);
				this.Message = myClassifys.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 用途删除。
		/// </summary>
		/// <param name="myClassifyData">ClassifyData:	用途数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(ClassifyData myClassifyData)
		{
			bool isValid = true;
			//数据检验。
			if (myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				this.Message = ClassifyData.NO_ROW;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0];
			//判断用途编号是否还有下级用途编号。
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
		/// 根据传入的用途代码串进行用途删除。
		/// </summary>
		/// <param name="Codes">string:	用途代码串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete (string Code)
		{
			bool isValid = true;
			if (Code == null || Code == "")
			{
				this.Message = ClassifyData.NO_OBJECT;
				isValid = false;
				return isValid;
			}
			//判断用途编号是否还有下级用途编号。
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
		/// 用途增加时判断用途代码是否有效。
		/// </summary>
		/// <param name="Code">string:	用途代码。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewCode(string Code)
		{
			Classifys myClassifys = new Classifys();
			return myClassifys.GetClassifyByCode(Code).Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 用途增加时判断用途名称是否有效。
		/// </summary>
		/// <param name="Description">string:	用途名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewDescription(string Description)
		{
			Classifys myClassifys = new Classifys();
			return myClassifys.GetClassifyByDescription(Description).Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 用途修改时判断用途代码的有效性。
		/// </summary>
		/// <param name="OldCode">string:	修改前的代码。</param>
		/// <param name="Code">string:	修改后的代码。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		private bool IsValidCode(string OldCode, string Code)
		{
			ClassifyData myClassifyData;
			Classifys myClassifys = new Classifys();
			myClassifyData = myClassifys.GetClassifyByCode(Code);
			//如果根据用途名称查询，没有结果。说明是有效的。
			if ( myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//如果有结果集，但是结果集就是本身也是有效的。
			{
				return myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.CODE_FIELD].ToString() == OldCode?true:false;
			}
		}
		/// <summary>
		/// 判断此用途编号是否是其他用途的父用途
		/// </summary>
		/// <param name="ClassifyID"></param>
		/// <returns></returns>
		private bool IsParentClassify(string ClassifyID)
		{
			ClassifyData myClassifyData;
			Classifys myClassifys = new Classifys();
			myClassifyData = myClassifys.GetParentClassifyByCode(ClassifyID);
			//如果根据用途名称查询，没有结果。说明是有效的。
			if ( myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count > 0)
			{
				return true;
			}
			else//如果有结果集，但是结果集就是本身也是有效的。
			{
				return false;
			}
		}
		/// <summary>
		/// 用途修改时判断用途名称是否有效。
		/// </summary>
		/// <param name="Code">string:	用途代码。</param>
		/// <param name="Description">string:	用途名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidDescription(string OldCode, string Description)
		{
			ClassifyData myClassifyData;
			Classifys myClassifys = new Classifys();
			myClassifyData = myClassifys.GetClassifyByDescription(Description);
			//如果根据用途名称查询，没有结果。说明是有效的。
			if ( myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//如果有结果集，但是结果集就是本身也是有效的。
			{
				return myClassifyData.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0][ClassifyData.CODE_FIELD].ToString() == OldCode?true:false;
			}
		}
	}
}
