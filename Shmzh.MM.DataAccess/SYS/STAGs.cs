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
**		文件: STAGs.cs
**		名称: 数据采集系统配置信息的数据访问层。
**		描述: 记录批量进货单涉及到的数据采集系统的配置信息和缺省物料信息和仓库
**			  信息。
**              
**		作者: 张豪
**		日期: 2005-05-09
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
	using System.Collections;
	using System.Data.SqlClient;
	using System.Configuration ;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	/// <summary>
	/// STAGs 的摘要说明。
	/// </summary>
	public class STAGs : Messages
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
		public STAGData GetSTAGInfo ()
		{
			STAGData ds = new STAGData ();
			SQLServer mysp = new SQLServer ();

			if (!mysp.ExecSPReturnDS("Sys_STAGGetInfo",ds.Tables [STAGData.STAG_Table]))
			{
				this.Message = STAGData.QUERY_FAILED;
			}
			return ds;
		}
		#endregion

		#region 构造函数
		public STAGs()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
