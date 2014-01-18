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
**		文件: 
**		名称: 
**		描述: 
**
**              
**		作者: 张豪
**		日期: 
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
	/// <summary>
	/// Audit3s 的摘要说明。
	/// </summary>
	public class Audit3s
	{
		#region 成员变量
		//
		//TODO: 在此处添加成员变量。
		//
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
		/// 获取所有三级审批的单据实体。
		/// </summary>
		/// <returns>Audit3Data:三级审批的单据实体。	</returns>
		public Audit3Data GetAudit3DataToAudit(string UserLoginId)
		{
			Audit3Data oAudit3Data = new Audit3Data();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@UserLoginId",UserLoginId);
			oSQLServer.ExecSPReturnDS("Pur_Audit3GetByToAudit",oHT,oAudit3Data.Tables[Audit3Data.Audit3_Talbe]);
			return oAudit3Data;
		}
		/// <summary>
		/// 根据SQL语句来返回三级审批的单据审批。
		/// </summary>
		/// <param name="SQL">string:	SQL语句。</param>
		/// <returns>Audit3Data:三级审批的单据实体。</returns>
		public Audit3Data GetAudit3DataBySQL(string Sql_Statement)
		{
			Audit3Data oAudit3Data = new Audit3Data();
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Sql_Statement",Sql_Statement);
			oSQLServer.ExecSPReturnDS("Qry_ExecSQL",oHT,oAudit3Data.Tables[Audit3Data.Audit3_Talbe]);
			return oAudit3Data;
		}
		#endregion

		#region 构造函数
		public Audit3s()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
