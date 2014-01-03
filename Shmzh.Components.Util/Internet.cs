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


namespace Shmzh.Components.Util
{
	using System.Runtime.InteropServices;
	/// <summary>
	/// Internet 的摘要说明。
	/// </summary>
	public class Internet
	{
		[DllImport("wininet.dll")]
		#region 成员变量
		//
		//
		//
		#endregion

		#region 属性
		//
		//
		//
		#endregion
		
		#region 私有方法
		private extern static bool InternetGetConnectedState( out int connectionDescription, int reservedValue ) ;
		#endregion

		#region 公开方法
		/// <summary>
		/// 网络是否可用，不仅限于公网，内网通也返回true。
		/// </summary>
		/// <returns>bool:	可用返回true，不可用返回false。</returns>
		public static bool IsConnected()

		{

			int I=0;

			bool state = InternetGetConnectedState(out I,0);

			return state;
		}
    	#endregion

		#region 构造函数
		/// <summary>
		/// 空构造函数。
		/// </summary>
		public Internet()
		{
			//
			// 
			//
		}
		#endregion
	}
}
