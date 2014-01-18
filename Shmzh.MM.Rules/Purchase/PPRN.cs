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
	/// Dept 的摘要说明。
	/// </summary>
	public class PPRN : Messages
	{
		/// <summary>
		/// 供应商/客户 增加。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(PPRNData myPPRNData)
		{
			bool isValid = true;
			//判断传入的数据实体是否为空。
			if (myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
			{
				this.Message = PPRNData.NO_ROW ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0];
			//检查字段值的合法性,所有需要加以判断的字段的入口
			isValid = InputCheck.IsValidField(myRow,PPRNData.CODE_FIELD,PPRNData.CODE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,6) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CNNAME_FIELD,PPRNData.CNNAME_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ENNAME_FIELD,PPRNData.ENNAME_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TYPE_FIELD,PPRNData.TYPE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.STATUS_FIELD,PPRNData.STATUS_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.APPROVE_FIELD,PPRNData.APPROVE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CURRENCY_FIELD,PPRNData.CURRENCY_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,5) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.PAYSTYLE_FIELD,PPRNData.PAYSTYLE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TEL_FIELD,PPRNData.TEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.FAX_FIELD,PPRNData.FAX_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.EMAIL_FIELD,PPRNData.EMAIL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKMAN_FIELD,PPRNData.LINKMAN_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKTEL_FIELD,PPRNData.LINKTEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKMAIL_FIELD,PPRNData.LINKMAIL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCLINK_FIELD,PPRNData.ACCLINK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCLINKTEL_FIELD,PPRNData.ACCLINKTEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ADDRESS_FIELD,PPRNData.ADDRESS_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ZIP_FIELD,PPRNData.ZIP_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,12) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LICENCE_FIELD,PPRNData.LICENCE_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.REGMONEY_FIELD,PPRNData.REGMONEY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TURNOVER_FIELD,PPRNData.TURNOVER_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.DEPUTY_FIELD,PPRNData.DEPUTY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.BANK_FIELD,PPRNData.BANK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCOUNT_FIELD,PPRNData.ACCOUNT_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.BANK_FIELD,PPRNData.BANK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCOUNT_FIELD,PPRNData.ACCOUNT_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TAXNO_FIELD,PPRNData.TAXNO_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.COUNTRY_FIELD,PPRNData.COUNTRY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.STATE_FIELD,PPRNData.STATE_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CITY_FIELD,PPRNData.CITY_FIELD,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.PURCHASEACC_FIELD,PPRNData.PURCHASEACC_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.APACC_FIELD,PPRNData.APACC_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.REMARK_FIELD,PPRNData.REMARK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,100) && isValid;
			if ( !isValid)//如果输入检验不通过，则直接返回。
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//判断供应商客户编号是否有效，无效直接返回。
			if ( !IsValidNewCode(myRow[PPRNData.CODE_FIELD].ToString()))//供应商/客户编号有效。
			{
				this.Message = PPRNData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//判断供应商客户中文名称是否有效，无效直接返回。
			if ( !IsValidNewCNName(myRow[PPRNData.CNNAME_FIELD].ToString()))//供应商/客户中文名称有效。
			{
				this.Message = PPRNData.CNNAME_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//判断供应商英文名称是否有效，无效直接返回。
			if ( !IsValidNewENName(myRow[PPRNData.ENNAME_FIELD].ToString()) )//供应商/客户英文名称无效。
			{
				this.Message = PPRNData.ENNAME_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//判断OTA类型的有效性，无效直接返回。

			//前面的数据检查都通过了。						
			//进行数据添加操作。
			{
				PPRNs myPPRNs = new PPRNs();
				isValid = myPPRNs.Add(myPPRNData);
				this.Message = myPPRNs.Message;
				return isValid;
			}
		}

		/// <summary>
		/// 供应商/客户 修改。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(PPRNData myPPRNData)
		{
			bool isValid = true;
			//判断传入的数据实体是否为空。
			if (myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
			{
				this.Message = PPRNData.NO_ROW ;
				isValid = false;
				return isValid;
			}

			DataRow myRow = myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0];
			//检查字段值的合法性,所有需要加以判断的字段的入口
			isValid = InputCheck.IsValidField(myRow,PPRNData.CODE_FIELD,PPRNData.CODE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,6) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CNNAME_FIELD,PPRNData.CNNAME_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ENNAME_FIELD,PPRNData.ENNAME_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TYPE_FIELD,PPRNData.TYPE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.STATUS_FIELD,PPRNData.STATUS_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.APPROVE_FIELD,PPRNData.APPROVE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CURRENCY_FIELD,PPRNData.CURRENCY_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,5) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.PAYSTYLE_FIELD,PPRNData.PAYSTYLE_LABEL,true, InputCheck.Enum_Input_Format.Format_Char,1) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TEL_FIELD,PPRNData.TEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.FAX_FIELD,PPRNData.FAX_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.EMAIL_FIELD,PPRNData.EMAIL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKMAN_FIELD,PPRNData.LINKMAN_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKTEL_FIELD,PPRNData.LINKTEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LINKMAIL_FIELD,PPRNData.LINKMAIL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCLINK_FIELD,PPRNData.ACCLINK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCLINKTEL_FIELD,PPRNData.ACCLINKTEL_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ADDRESS_FIELD,PPRNData.ADDRESS_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ZIP_FIELD,PPRNData.ZIP_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,12) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.LICENCE_FIELD,PPRNData.LICENCE_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.REGMONEY_FIELD,PPRNData.REGMONEY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TURNOVER_FIELD,PPRNData.TURNOVER_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.DEPUTY_FIELD,PPRNData.DEPUTY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.BANK_FIELD,PPRNData.BANK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCOUNT_FIELD,PPRNData.ACCOUNT_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.BANK_FIELD,PPRNData.BANK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.ACCOUNT_FIELD,PPRNData.ACCOUNT_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,30) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.TAXNO_FIELD,PPRNData.TAXNO_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.COUNTRY_FIELD,PPRNData.COUNTRY_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.STATE_FIELD,PPRNData.STATE_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.CITY_FIELD,PPRNData.CITY_FIELD,false, InputCheck.Enum_Input_Format.Format_Char,15) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.PURCHASEACC_FIELD,PPRNData.PURCHASEACC_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.APACC_FIELD,PPRNData.APACC_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
			isValid = InputCheck.IsValidField(myRow,PPRNData.REMARK_FIELD,PPRNData.REMARK_LABEL,false, InputCheck.Enum_Input_Format.Format_Char,100) && isValid;
			//如果输入数据不符合数据库要求，则直接返回。
			if (!isValid)
			{
				this.Message = InputCheck.ErrorInfo;
				return isValid;
			}
			//判断供应商/客户编号的有效性，无效直接返回。
			if ( !IsValidCode(myRow[PPRNData.OLDCODE_FIELD].ToString(),myRow[PPRNData.CODE_FIELD].ToString()))//供应商/客户编号有效。
			{
				this.Message = PPRNData.CODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//判断供应商/客户中文名称的有效性，无效直接返回。
			if ( !IsValidCNName(myRow[PPRNData.OLDCODE_FIELD].ToString(),myRow[PPRNData.CNNAME_FIELD].ToString()))//供应商/客户中文名称有效。
			{
				this.Message = PPRNData.CNNAME_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//判断供应商/客户英文名称的有效性，无效直接返回。
			if ( !IsValidENName(myRow[PPRNData.OLDCODE_FIELD].ToString(),myRow[PPRNData.ENNAME_FIELD].ToString()))//供应商/客户英文名称无效。
			{
				this.Message = PPRNData.ENNAME_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//判断OTA属性的有效性，无效直接返回。
			if ( !IsValidType( myRow[PPRNData.TYPE_FIELD].ToString()) )
			{
				this.Message = PPRNData.OTA_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//数据修改。
			{
				PPRNs myPPRNs = new PPRNs();
				isValid = myPPRNs.Update(myPPRNData);
				this.Message = myPPRNs.Message;
				return isValid;
			}
		}
		/// <summary>
		/// 供应商/客户 删除。
		/// </summary>
		/// <param name="myPPRNData">PPRNData:	供应商/客户数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(PPRNData myPPRNData)
		{
			bool isValid = true;
			if (myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count > 0)
			{
				PPRNs myPPRNs = new PPRNs();
				isValid = myPPRNs.Delete(myPPRNData);
				this.Message = myPPRNs.Message;
			}
			else
			{	
				this.Message = PPRNData.NO_ROW;	
			}
			return isValid;
		}
		/// <summary>
		/// 根据传入的供应商代码串进行供应商删除。
		/// </summary>
		/// <param name="Codes">string:	供应商代码字符串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string Codes)
		{
			bool isValid = true;
			if (Codes != null && Codes != "")
			{
				PPRNs myPPRNs = new PPRNs();
				isValid = myPPRNs.Delete(Codes);
				this.Message = myPPRNs.Message;
			}
			else
			{	
				this.Message = PPRNData.NO_ROW;	
			}
			return isValid;
		}
		/// <summary>
		/// 供应商/客户 增加时判断 编号是否有效。
		/// </summary>
		/// <param name="Code">string:	供应商/客户编号。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewCode(string Code)
		{
			PPRNs myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByCode(Code).Tables[PPRNData.PPRN_TABLE].Rows.Count > 0 ? false:true;
		}
		
		/// <summary>
		/// 供应商/客户 修改时判断 编号是否有效。
		/// </summary>
		/// <param name="OldCode">string:	修改前编号。</param>
		/// <param name="Code">string:	修改后编号。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidCode(string OldCode, string Code)
		{
			PPRNData myPPRNData;
			PPRNs myPPRNs = new PPRNs();
			myPPRNData = myPPRNs.GetPPRNByCode(Code);
			if ( myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else
			{
				return OldCode==Code?true:false;
			}
		}
		/// <summary>
		/// 供应商/客户 增加时判断名称是否有效。
		/// </summary>
		/// <param name="CNName">string:	供应商/客户中文名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewCNName(string CNName)
		{
			PPRNs myPPRNs = new PPRNs();
			return myPPRNs.GetPPRNByCNName(CNName).Tables[PPRNData.PPRN_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 供应商/客户 修改时判断中文名称是否有效。
		/// </summary>
		/// <param name="OldCode">string:	修改前供应商/客户编号。</param>
		/// <param name="CCName">string:	修改后的供应商/客户中文名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidCNName(string OldCode, string CCName)
		{
			PPRNData myPPRNData;
			PPRNs myPPRNs = new PPRNs();
			myPPRNData = myPPRNs.GetPPRNByCNName(CCName);
			if ( myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else
			{
				return OldCode==myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString()?true:false;
			}
		}
		/// <summary>
		/// 供应商/客户 增加时判断英文名称是否有效。
		/// </summary>
		/// <param name="ENName">string:	供应商/客户英文名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewENName(string ENName)
		{
			PPRNs myPPRNs = new PPRNs();
			if (ENName == null || ENName == "")
				return true;
			else
				return myPPRNs.GetPPRNByENName(ENName).Tables[PPRNData.PPRN_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 供应商/客户 修改时判断英文名称是否有效。
		/// </summary>
		/// <param name="OldCode">string:	修改前供应商/客户编号。</param>
		/// <param name="ENName">string:	修改后供应商/客户英文名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidENName(string OldCode, string ENName)
		{
			PPRNData myPPRNData;
			if (ENName == null || ENName == "")
				return true;
			else
			{
				PPRNs myPPRNs = new PPRNs();
				myPPRNData = myPPRNs.GetPPRNByENName(ENName);
				if ( myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows.Count == 0)
				{
					return true;
				}
				else
				{
					return OldCode==myPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString()?true:false;
				}
			}
		}
		//类型判断主要是判断，用户是否选用了OTA类型。
		//OTA类型，是系统默认记录使用的类型。
		//只能有一条记录是OTA类型的。
		//所以要进行类型的检查。
		private bool IsValidType(string Type)
		{
			if ( Type == "O")//供应商/客户的类型如果是"O",表示是OTA类型供应商。
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
