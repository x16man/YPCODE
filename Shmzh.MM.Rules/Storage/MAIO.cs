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


namespace Shmzh.MM.BusinessRules
{
	using System;
	using System.Data;
    using Shmzh.MM.Common;
    using Shmzh.MM.DataAccess;
	/// <summary>
	/// MAIO 的摘要说明。
	/// </summary>
	public class MAIO : Messages
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
		private bool check(MAIOData oMAIOData)
		{
			bool ret = true;
			if (oMAIOData.Count == 0)
			{
				this.Message = "库存盘点数据为空！";
				return false;
			}
			if (oMAIOData.ItemCode == null || oMAIOData.ItemCode == "")
			{
				this.Message = "物料编号不能为空！";
				return false;
			}
			if (oMAIOData.StoCode == null || oMAIOData.StoCode == "")
			{
				this.Message = "仓库编号不能为空！";
				return false;
			}
			
			if (oMAIOData.BookNum.ToString() == null )
			{
				this.Message = "账面数量不能为空！";
				return false;
			}
			if (oMAIOData.BookPrice.ToString() == null)
			{
				this.Message = "账面单价不能为空！";
				return false;
			}
			if (oMAIOData.ItemNum.ToString() == null)
			{
				this.Message = "实际数量不能为空！";
				return false;
			}
			return ret;
		}
		#endregion

		#region 公开方法
		public bool Add(MAIOData oMAIOData)
		{
			bool ret = false;
			if (this.check(oMAIOData))
			{
				ret = new MAIOs().Add(oMAIOData);
				if (ret == false)
				{
					this.Message = "库存盘点数据保存失败！";
				}
				return ret;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 修改库存盘点记录。
		/// </summary>
		/// <param name="oMAIOData">MAIOData:	盘点记录实体。</param>
		/// <param name="StoCode">string:	仓库编号。</param>
		/// <param name="ConName">string:	架位名称。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(MAIOData oMAIOData, string StoCode, string ConName)
		{
			bool ret = false;
			if (this.check(oMAIOData))
			{
				ret = new MAIOs().Update(oMAIOData, StoCode, ConName);
				if (ret == false)
				{
					this.Message = "库存盘点数据保存失败！";
				}
				return ret;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region 构造函数
		public MAIO()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
