#region 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion 版权 (c) 2004-2005 MZH, Inc. All Rights Reserved

#region 文档信息
/******************************************************************************
**		文件: IOs.cs
**		名称: IOs
**		描述: 收发明细表的数据访问层。
**
**              
**		作者: 张豪
**		日期: 2005-10-11
*******************************************************************************
**		修改历史
*******************************************************************************
**		日期:		作者:		描述:
**		--------	--------	-----------------------------------------------
**    
*******************************************************************************/
#endregion 文档信息


namespace Shmzh.MM.DataAccess
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
	using System.Collections;
	using MZHCommon.Database;
    using System.Data.SqlClient;
    using System.Data.Common;
	/// <summary>
	/// IOs 的摘要说明。
	/// </summary>
	public class IOs
	{
		#region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion

		#region 属性
		//
		//TODO: 在此处添加属性。
		//
		#endregion
		
		#region 私有方法
		//
		//TODO: 在这此处加私有方法。
		//
		#endregion

		#region 公开方法
		/// <summary>
		/// 返回指定物料的收发明细记录。
		/// </summary>
		/// <param name="ItemCode">string:	物料编号。</param>
		/// <returns>IOData:	收发明细表实体。</returns>
		public IOData GetIOByItemCode(string ItemCode)
		{
			IOData oIOData = new IOData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode", ItemCode);
			new SQLServer().ExecSPReturnDS("Sto_ItemIODetail",oHT,oIOData.Tables[IOData.IO_Table]);

			return oIOData;
		}
		public IOData GetIOByItemCodeAndDate(string ItemCode,DateTime StartDate, DateTime EndDate)
		{
			IOData   oIOData = new IOData();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ItemCode",ItemCode);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			new SQLServer().ExecSPReturnDS("Sto_ItemIOGetDetailByDate",oHT,oIOData.Tables[IOData.IO_Table]);
			return oIOData;
		}
        public bool Insert(DbTransaction trans, int entryNo,short docCode)
        {
            var parms = new[]
                            {
                                new SqlParameter("@EntryNo", SqlDbType.Int) {Value = entryNo},
                                new SqlParameter("@DocCode", SqlDbType.SmallInt) {Value = docCode}
                            };
            try
            {
                SqlHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.StoredProcedure, "Sto_IOInsert", parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
		#endregion

		#region 构造函数
		public IOs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
