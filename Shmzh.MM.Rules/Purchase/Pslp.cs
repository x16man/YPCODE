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
	/// 采购员 业务规则层。
	/// </summary>
	public class Pslp : Messages
	{
		/// <summary>
		/// 采购员 增加。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(PslpData myPslpData)
		{
			bool isValid = true;
			//判断传入的数据实体是否为空。
			if (myPslpData.Tables[PslpData.PSLP_TABLE].Rows.Count == 0)
			{
				this.Message = PslpData.NO_ROW ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0];
			//检查字段值的合法性,所有需要加以判断的字段的入口
			isValid = InputCheck.IsValidField(myRow,PslpData.CODE_FIELD,PslpData.CODE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,5) && isValid;
			isValid = InputCheck.IsValidField(myRow,PslpData.DESCRIPTION_FIELD,PslpData.DESCRIPTION_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			
			if ( !isValid)//如果输入检验不通过，则直接返回。
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//判断采购员代码是否有效，无效直接返回。
			if ( !IsValidNewCode(myRow[PslpData.CODE_FIELD].ToString()))//采购员代码有效。
			{
				this.Message = PslpData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//前面的数据检查都通过了。						
			//进行数据添加操作。
			{
				Pslps myPslps = new Pslps();
				isValid = myPslps.Add(myPslpData);
				this.Message = myPslps.Message;
				return isValid;
			}
		}

		/// <summary>
		/// 采购员 修改。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(PslpData myPslpData)
		{
			bool isValid = true;
			//判断传入的数据实体是否为空。
			if (myPslpData.Tables[PslpData.PSLP_TABLE].Rows.Count == 0)
			{
				this.Message = PslpData.NO_ROW ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPslpData.Tables[PslpData.PSLP_TABLE].Rows[0];
			//检查字段值的合法性,所有需要加以判断的字段的入口
			isValid = InputCheck.IsValidField(myRow,PslpData.CODE_FIELD,PslpData.CODE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,5) && isValid;
			isValid = InputCheck.IsValidField(myRow,PslpData.DESCRIPTION_FIELD,PslpData.DESCRIPTION_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			//如果输入数据不符合数据库要求，则直接返回。
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//判断采购员代码的有效性，无效直接返回。
			if ( !IsValidCode(myRow[PslpData.OLDCODE_FIELD].ToString(),myRow[PslpData.CODE_FIELD].ToString()))//采购员代码有效。
			{
				this.Message = PslpData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			
			//数据修改。
			{
				Pslps myPslps = new Pslps();
				isValid = myPslps.Update(myPslpData);
				this.Message = myPslps.Message;
				return isValid;
			}
		}
		/// <summary>
		/// 采购员 删除。
		/// </summary>
		/// <param name="myPslpData">PslpData:	采购员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 根据传入的采购员代码串进行采购员删除。
		/// </summary>
		/// <param name="Codes">string:	采购员代码字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
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
		/// 采购员 增加时判断代码是否有效。
		/// </summary>
		/// <param name="Code">string:	采购员编号。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewCode(string Code)
		{
			Pslps myPslps = new Pslps();
			return myPslps.GetPslpByCode(Code).Tables[PslpData.PSLP_TABLE].Rows.Count > 0 ? false:true;
		}
		
		/// <summary>
		/// 采购员 修改时判断 代码是否有效。
		/// </summary>
		/// <param name="OldCode">string:	修改前编号。</param>
		/// <param name="Code">string:	修改后编号。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
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
