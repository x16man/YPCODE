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
	/// 架位业务规则层。
	/// </summary>
	public class Sto : Messages
	{
		
		public bool Add(StoData myStoData)
		{
			bool isValid = true;
			//数据检验。
			if (myStoData.Tables[StoData.STO_TABLE].Rows.Count > 0)
			{
				DataRow myRow = myStoData.Tables[StoData.STO_TABLE].Rows[0];
				//检查字段值的合法性,所有需要加以判断的字段的入口。
				isValid = InputCheck.IsValidField(myRow,StoData.CODE_FIELD,StoData.CODE_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,10) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.DESCRIPTION_FIELD,StoData.DESCRIPTION_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.STOACC_FIELD,StoData.STOACC_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.TRFACC_FIELD,StoData.TRFACC_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.RETURNACC_FIELD,StoData.RETURNACC_FIELD,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.ADDRESS_FIELD,StoData.ADDRESS_NULL,false,InputCheck.Enum_Input_Format.Format_Char,50) && isValid;
				isValid = InputCheck.IsValidField(myRow,StoData.RELATION_FIELD,StoData.RELATION_NULL,false,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				
				if (isValid)
				{	//判断仓库编号是否重复。
					if (IsValidNewCode(myRow[StoData.CODE_FIELD].ToString()))
					{	//判断仓库名称是否重复。
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
			//数据添加。
			if (isValid)
			{
				Stos myStos = new Stos();

				isValid = myStos.Add(myStoData);
				this.Message = myStos.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 仓库修改。
		/// </summary>
		/// <param name="myStoData">StoData:	仓库数据实体。</param>
		/// <returns>bool:	修改成功返回true，失败返回false。</returns>
		public bool Update(StoData myStoData,string strOldName)
		{
			bool isValid = true;
			//数据检验。
			if (myStoData.Tables[StoData.STO_TABLE].Rows.Count > 0)
			{
				DataRow myRow = myStoData.Tables[StoData.STO_TABLE].Rows[0];
				//检查字段值的合法性,所有需要加以判断的字段的入口。
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
                        //判断仓库名称是否重复。
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
			//数据更改。
			if (isValid)
			{
				Stos myStos = new Stos();
				isValid = myStos.Update(myStoData);
				this.Message = myStos.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 仓库删除。
		/// </summary>
		/// <param name="myStoData">StoData:	仓库数据实体。</param>
		/// <returns>bool:	删除成功返回true，失败返回false。</returns>
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
		/// 根据传入的仓库代码串进行仓库删除。
		/// </summary>
		/// <param name="Codes">string:	仓库代码串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete (string Codes)
		{
			bool isValid = true;
			Stos myStos = new Stos();
			isValid = myStos.Delete(Codes);
			this.Message = myStos.Message;
			return isValid;
		}
		/// <summary>
		/// 仓库增加时判断仓库编号是否有效。
		/// </summary>
		/// <param name="Code">string:	仓库编号。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewCode(string Code)
		{
			Stos myStos = new Stos();
			return myStos.GetStoByCode(Code).Tables[StoData.STO_TABLE].Rows.Count > 0 ? false:true;
		}

		/// <summary>
		/// 仓库增加时判断仓库名称是否有效。
		/// </summary>
		/// <param name="Description">string:	仓库名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewDescription(string Description)
		{
			Stos myStos = new Stos();
			return myStos.GetStoByDescription(Description).Tables[StoData.STO_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 仓库修改时判断仓库名称是否有效。
		/// </summary>
		/// <param name="Code">string:	仓库编号。</param>
		/// <param name="Description">string:	仓库名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidDescription(string Code, string Description)
		{
			StoData myStoData;
			Stos myStos = new Stos();
			myStoData = myStos.GetStoByDescription(Description);
			//如果根据仓库名称查询，没有结果。说明是有效的。
			if ( myStoData.Tables[StoData.STO_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//如果有结果集，但是结果集就是本身也是有效的。
			{
				return myStoData.Tables[StoData.STO_TABLE].Rows[0][StoData.DESCRIPTION_FIELD].ToString()==Code?true:false;
			}
		}
	}
}
