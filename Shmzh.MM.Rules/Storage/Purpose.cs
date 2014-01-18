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
	public class Purpose : Messages
	{
		/// <summary>
		/// 用途增加。
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	用途数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Add(PurposeData myPurposeData)
		{
			bool isValid = true;
			//数据检验。
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count == 0)
			{
				this.Message = StoData.NO_ROW ;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0];
			//检查字段值的合法性,所有需要加以判断的字段的入口。
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
				this.Message = "用途名称中不允许存在逗号!";
				return isValid;
			}
			//判断用途代码是否重复。
			if (!IsValidNewCode(myRow[PurposeData.CODE_FIELD].ToString()))
			{
				this.Message = PurposeData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//判断用途名称是否重复。
            //2012-01-09 应张澄要求，允许用途名称重复。
            //if ( !IsValidNewDescription(myRow[PurposeData.DESCRIPTION_FIELD].ToString()) )
            //{
            //    this.Message = PurposeData.DESCRIPTION_NOT_UNIQUE;
            //    isValid = false;
            //    return isValid;
            //}
				
			//数据添加。
			if (true)
			{
				Purposes myPurposes = new Purposes();

				isValid = myPurposes.Add(myPurposeData);
				this.Message = myPurposes.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 用途修改。
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	用途数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(PurposeData myPurposeData)
		{
			bool isValid = true;
			//数据检验。
			if (myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count == 0)
			{
				this.Message = PurposeData.NO_ROW;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0];
			//检查字段值的合法性,所有需要加以判断的字段的入口。
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
				this.Message = "用途名称中不允许存在逗号!";
				return isValid;
			}
			//判断用途编号是否重复。
			if ( !IsValidCode(myRow[PurposeData.OLDCODE_FIELD].ToString(),myRow[PurposeData.CODE_FIELD].ToString()) )
			{
				this.Message = PurposeData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//判断用途名称是否重复。
            //2012-01-09 应张澄要求，允许用途名称重复。
            //if ( !IsValidDescription(myRow[PurposeData.OLDCODE_FIELD].ToString(),myRow[PurposeData.DESCRIPTION_FIELD].ToString()) )
            //{
            //    this.Message = PurposeData.DESCRIPTION_NOT_UNIQUE;
            //    isValid = false;
            //    return isValid;
            //}
			//数据更改。
			if (true)
			{
				Purposes myPurposes = new Purposes();
				isValid = myPurposes.Update(myPurposeData);
				this.Message = myPurposes.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 用途删除。
		/// </summary>
		/// <param name="myPurposeData">PurposeData:	用途数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 根据传入的用途代码串进行用途删除。
		/// </summary>
		/// <param name="Codes">string:	用途代码串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 用途增加时判断用途代码是否有效。
		/// </summary>
		/// <param name="Code">string:	用途代码。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewCode(string Code)
		{
			Purposes myPurposes = new Purposes();
			return myPurposes.GetPurposeByCode(Code).Tables[PurposeData.USE_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 用途增加时判断用途名称是否有效。
		/// </summary>
		/// <param name="Description">string:	用途名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewDescription(string Description)
		{
			Purposes myPurposes = new Purposes();
			return myPurposes.GetPurposeByDescription(Description).Tables[PurposeData.USE_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 用途修改时判断用途代码的有效性。
		/// </summary>
		/// <param name="OldCode">string:	修改前的代码。</param>
		/// <param name="Code">string:	修改后的代码。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		private bool IsValidCode(string OldCode, string Code)
		{
			PurposeData myPurposeData;
			Purposes myPurposes = new Purposes();
			myPurposeData = myPurposes.GetPurposeByCode(Code);
			//如果根据用途名称查询，没有结果。说明是有效的。
			if ( myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//如果有结果集，但是结果集就是本身也是有效的。
			{
				return myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString() == OldCode?true:false;
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
			PurposeData myPurposeData;
			Purposes myPurposes = new Purposes();
			myPurposeData = myPurposes.GetPurposeByDescription(Description);
			//如果根据用途名称查询，没有结果。说明是有效的。
			if ( myPurposeData.Tables[PurposeData.USE_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//如果有结果集，但是结果集就是本身也是有效的。
			{
				return myPurposeData.Tables[PurposeData.USE_TABLE].Rows[0][PurposeData.CODE_FIELD].ToString() == OldCode?true:false;
			}
		}
	}
}
