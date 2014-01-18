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
	/// 仓库管理员业务规则层。
	/// </summary>
	public class StoManager : Messages
	{
		/// <summary>
		/// 仓库管理员增加。
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Add(StoManagerData myStoManagerData)
		{
			bool isValid = true;
			//判断是否是空数据。
			if (myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count == 0)
			{
				this.Message = StoData.NO_ROW ;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0];
			
			//判断仓库编号\仓库管理员是否重复。
			if ( !IsValidNewStoCodeUserCode(myRow[StoManagerData.STOCODE_FIELD].ToString(),myRow[StoManagerData.USERCODE_FIELD].ToString()))
			{
				this.Message = StoManagerData.STOCODEUSERCODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//数据添加。
			if (isValid)
			{
				StoManagers myStoManagers = new StoManagers();

				isValid = myStoManagers.Add(myStoManagerData);
				this.Message = myStoManagers.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 仓库管理员修改。
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	修改成功返回true，失败返回false。</returns>
		public bool Update(StoManagerData myStoManagerData)
		{
			bool isValid = true;
			//数据检验。
			if (myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count == 0)
			{
				this.Message = StoData.NO_ROW;
				isValid = false;
				return isValid;
			}
			DataRow myRow = myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0];
			//判断仓库管理员数据是否重复。
			if ( !IsValidStoCodeUserCode(	int.Parse(myRow[StoManagerData.PKID_FIELD].ToString()),
											myRow[StoManagerData.STOCODE_FIELD].ToString(),
											myRow[StoManagerData.USERCODE_FIELD].ToString()) 
				)
			{
				this.Message = StoManagerData.STOCODEUSERCODE_NOT_UNIQUE;
				isValid = false;
				return isValid;
			}
			//数据更改。
			if (isValid)
			{
				StoManagers myStoManagers = new StoManagers();
				isValid = myStoManagers.Update(myStoManagerData);
				this.Message = myStoManagers.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 仓库管理员删除。
		/// </summary>
		/// <param name="myStoManagerData">StoManagerData:	仓库管理员数据实体。</param>
		/// <returns>bool:	删除成功返回true，失败返回false。</returns>
		public bool Delete(StoManagerData myStoManagerData)
		{
			bool isValid = true;
			if (myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count == 0)
			{
				this.Message = StoManagerData.NO_ROW;	
				isValid = false;
				return isValid;
			}
			if (isValid)
			{
				StoManagers myStoManagers = new StoManagers();
				isValid = myStoManagers.Delete(myStoManagerData);
				this.Message = myStoManagers.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 根据传入的仓库管理员主键串进行删除。
		/// </summary>
		/// <param name="PKIDs">string:	仓库管理员主键串。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(string PKIDs)
		{
			bool isValid = true;
			if (PKIDs == null && PKIDs == "")
			{
				this.Message = StoManagerData.NO_ROW;	
				isValid = false;
				return isValid;
			}
			if (isValid)
			{
				StoManagers myStoManagers = new StoManagers();
				isValid = myStoManagers.Delete(PKIDs);
				this.Message = myStoManagers.Message;
			}
			return isValid;
		}
		/// <summary>
		/// 仓库管理员增加时判断仓库管理员编号仓库编号是否有效。
		/// </summary>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="UserCode">string:	管理员编号。</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidNewStoCodeUserCode(string StoCode,string UserCode)
		{
			StoManagers myStoManagers = new StoManagers();
			return myStoManagers.GetStoManagerByStoCodeAndUserCode(StoCode, UserCode).Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count > 0 ? false:true;
		}
		/// <summary>
		/// 仓库管理员修改时判断仓库管理员编号仓库编号是否有效。
		/// </summary>
		/// <param name="OldStoCode">string:	旧仓库编号。</param>
		/// <param name="OldUserCode">string:	旧管理员编号。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="UserCode">string:	管理员编号</param>
		/// <returns>bool:	有效返回true，无效返回false。</returns>
		private bool IsValidStoCodeUserCode(int PKID, string StoCode, string UserCode)
		{
			StoManagerData myStoManagerData;
			StoManagers myStoManagers = new StoManagers();
			myStoManagerData = myStoManagers.GetStoManagerByStoCodeAndUserCode(StoCode, UserCode);
			//如果根据仓库编号、管理员编号查询，没有结果。说明是有效的。
			if ( myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Count == 0)
			{
				return true;
			}
			else//如果有结果集，但是结果集就是本身也是有效的。
			{
				return int.Parse(myStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0][StoManagerData.PKID_FIELD].ToString())==PKID ? true:false;
			}
		}
	}
}
