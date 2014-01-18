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
	public class StoCon : Messages
	{
		public StoCon()
		{		}
		/// <summary>
		/// 架位增加。
		/// </summary>
		/// <param name="myStoConData">StoConData:	部门数据集。</param>
		/// <returns>bool:	增加成功返回true，失败返回false。</returns>
		public bool Add(StoConData myStoConData)
		{
			bool isValid = true;
			//数据检验。
			if (myStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count > 0)
			{
				DataRow myRow = myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0];
				//检查字段值的合法性,所有需要加以判断的字段的入口
				isValid = InputCheck.IsValidField(myRow,StoConData.DESCRIPTION_FIELD,StoConData.DESCRIPTION_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				if (isValid)
				{	//判断架位名称是否重复。
					if (!IsValidNewDescription(myRow[StoConData.STOCODE_FIELD].ToString(),myRow[StoConData.DESCRIPTION_FIELD].ToString()))
					{
						this.Message = StoConData.DESCRIPTION_NOT_UNIQUE;
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
				this.Message = StoConData.NO_ROW ;
				isValid = false;
			}
			//数据添加。
			if (isValid)
			{
				StoCons myStoCons = new StoCons();

				isValid = myStoCons.Add(myStoConData);
				this.Message = myStoCons.Message;
			}
			return isValid;
		}

		/// <summary>
		/// 架位更改。
		/// </summary>
		/// <param name="myStoConData">StoConData:	部门数据集。</param>
		/// <returns>bool:	更改成功返回true，失败返回false。</returns>
		public bool Update(StoConData myStoConData)
		{
			bool isValid = true;
			//数据检验。
			if (myStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count > 0)
			{
				DataRow myRow = myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0];
				//检查字段值的合法性,所有需要加以判断的字段的入口
				isValid = InputCheck.IsValidField(myRow,StoConData.DESCRIPTION_FIELD,StoConData.DESCRIPTION_NOT_NULL,true,InputCheck.Enum_Input_Format.Format_Char,20) && isValid;
				if (isValid)
				{	//判断架位名称是否重复。
					if ( !IsValidDescription(int.Parse(myRow[StoConData.CODE_FIELD].ToString()),myRow[StoConData.STOCODE_FIELD].ToString(),myRow[StoConData.DESCRIPTION_FIELD].ToString()) )
					{
						isValid = false;
						this.Message = StoConData.DESCRIPTION_NOT_UNIQUE;
					}
				}
				else
				{
					this.Message = InputCheck.ErrorInfo;
				}
			}
			else
			{
				this.Message = StoConData.NO_ROW;
				isValid = false;
			}
			//数据更改。
			if (isValid)
			{
				StoCons myStoCons = new StoCons();
				isValid = myStoCons.Update(myStoConData);
				this.Message = myStoCons.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 架位删除。
		/// </summary>
		/// <param name="myStoConData">StoConData:	架位数据实体。</param>
		/// <returns>bool:	架位删除成功返回true，失败返回false。</returns>
		public bool Delete(StoConData myStoConData)
		{
			bool isValid = true;
			if (myStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count > 0)
			{
				StoCons myStoCons = new StoCons();
				isValid = myStoCons.Delete(myStoConData);
				this.Message = myStoCons.Message;
			}
			else
			{	
				this.Message = StoConData.NO_ROW;	
				isValid = false;
			}
			return isValid;
		}
		/// <summary>
		/// 根据传入的架位编号串进行架位的删除。
		/// </summary>
		/// <param name="Codes">string:	架位编号串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string Codes)
		{
			bool isValid = true;
			if (Codes == null || Codes =="")
			{
				this.Message = StoConData.NO_ROW;
				isValid = false;
			}
			else
			{
				StoCons myStoCons = new StoCons();
				isValid = myStoCons.Delete(Codes);
				this.Message = myStoCons.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 架位增加时，判断架位名称的有效性。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="Description">string:	架位名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewDescription(string StoCode, string Description)
		{
			StoCons myStoCons = new StoCons();
			return myStoCons.GetStoConByStoCodeAndDescription(StoCode, Description).Tables[StoConData.STOCON_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 架位更改时，判断架位名称是否有效。
		/// </summary>
		/// <param name="Code">int:	架位编号。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="Description">string:	架位名称。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidDescription(int Code, string StoCode, string Description)
		{
			StoConData myStoConData;
			StoCons myStoCons = new StoCons();
			myStoConData = myStoCons.GetStoConByStoCodeAndDescription(StoCode,Description);
			//如果根据仓库编号和架位名称查询，没有结果。说明是有效的。
			if ( myStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//如果有结果集，但是结果集就是本身也是有效的。
			{
				return int.Parse(myStoConData.Tables[StoConData.STOCON_TABLE].Rows[0][StoConData.CODE_FIELD].ToString())==Code?true:false;
			}
		}
	}
}
