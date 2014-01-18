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
    using Shmzh.MM.DataAccess;
    using Shmzh.MM.Common;
	using MZHCommon.Input;
	using MZHCommon.Database;
	using System.Collections;
	/// <summary>
	/// WITR 的摘要说明。
	/// </summary>
	public class WITR : Messages
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
		/// 新物料申请新建。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Insert(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "没有指定物料名称！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqReasonCode_Field] == System.DBNull.Value || 
				oData.Tables[0].Rows[0][WITRData.ReqReasonCode_Field].ToString() == "-1" ||
				oData.Tables[0].Rows[0][WITRData.ReqReasonCode_Field].ToString() == "")
			{
				this.Message = "没有指定用途！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "没有指定日期！";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "没有指定数量！";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Insert(oData);
			this.Message = oWITRs.Message;
			return ret;
		}

		/// <summary>
		/// 新物料申请新建并马上提交.
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool InsertAndPresent(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "没有指定物料名称！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "没有指定日期！";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "没有指定数量！";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.InsertAndPresent(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// 新物料申请修改。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Update(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "没有指定物料名称！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "没有指定日期！";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "没有指定数量！";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Update(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// 新物料申请修改并马上提交。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool UpdateAndPresent(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "没有指定物料名称！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "没有指定日期！";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "没有指定数量！";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.UpdateAndPresent(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// 新物料提交.
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Present(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ItemName_Field] == System.DBNull.Value || oData.Tables[0].Rows[0][WITRData.ItemName_Field].ToString() == "")
			{
				this.Message = "没有指定物料名称！";
				return false;
			}
			if (oData.Tables[0].Rows[0][WITRData.ReqDate_Field] == System.DBNull.Value )
			{
				this.Message = "没有指定日期！";
				return false;
			}
			try
			{
				Convert.ToDecimal(oData.Tables[0].Rows[0][WITRData.ItemNum_Field].ToString());
			}
			catch
			{
				this.Message = "没有指定数量！";
				return false;
			}
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Present(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// 删除新物料申请。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Delete(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Delete(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// 新物料申请确认。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Affirm(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Affirm(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// 新物料申请拒绝.
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool Refuse(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.Refuse(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// 新物料转采购申请单。
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ToPROS(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.ToPros(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		/// <summary>
		/// 新物料申请转成月度计划需求单
		/// </summary>
		/// <param name="oData">WITRData:	新物料申请数据实体。</param>
		/// <returns>bool:	成功返回true，失败返回false。</returns>
		public bool ToMRP(WITRData oData)
		{
			bool ret = false;
			if (oData.Count == 0)
			{
				this.Message = "没有数据！";
				return false;
			}
			
			WITRs oWITRs = new WITRs();
			ret = oWITRs.ToMRP(oData);
			this.Message = oWITRs.Message;
			return ret;
		}
		#endregion

		#region 构造函数
		public WITR()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
	}
}
