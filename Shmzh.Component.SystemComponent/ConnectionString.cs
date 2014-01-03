//-----------------------------------------------------------------------
// <copyright file="ConnectionString.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
	/// <summary>
	/// SystemComponent组件所连接数据库的连接字符串.
	/// </summary>
	public class ConnectionString
	{
		#region 公开属性
		/// <summary>
		/// SystemComponent组件使用的数据库连接字符串.
		/// </summary>
		[Obsolete("该属性已经过期,请勿再使用!请使用PubData属性。", true)] 
		public static string Value 
		{
			get {return	((ComponentConfiguration) ComponentConfigurations.Instance["SystemComponent"]).DatabaseConnectionString; }
		}
		/// <summary>
		/// PubData的数据库连接字符串。
		/// </summary>
		public static string PubData
		{
			get { return GetDBConnectionString("PubData");}
		}
		/// <summary>
		/// 知识管理数据库的连接字符串。
		/// </summary>
		public static string KM
		{
			get { return GetDBConnectionString("KM");}
		}
		/// <summary>
		/// 物料管理数据库的连接字符串。
		/// </summary>
		public static string MM
		{
			get { return GetDBConnectionString("MM");}
		}
		/// <summary>
		/// 供应商数据库的连接字符串。
		/// </summary>
		public static string CRM
		{
			get { return GetDBConnectionString("CRM");}
		}
		/// <summary>
		/// 项目管理数据库的连接字符串。
		/// </summary>
		public static string PM
		{
			get { return GetDBConnectionString("PM");}
		}
		/// <summary>
		/// 食堂管理数据库的连接字符串。
		/// </summary>
		public static string ET
		{
			get { return GetDBConnectionString("ET");}
		}
		/// <summary>
		/// 杨水信息数据库的连接字符串。
		/// </summary>
		public static string INFO
		{
			get { return GetDBConnectionString("INFO");}
		}
		/// <summary>
		/// 生产数据库的连接字符串。
		/// </summary>
		public static string Produce
		{
			get { return GetDBConnectionString("Produce");}
		}
		/// <summary>
		/// 设备数据库的连接字符串。
		/// </summary>
		public static string DEV
		{
			get { return GetDBConnectionString("DEV");}
		}
		/// <summary>
		/// 通讯录数据库的连接字符串。
		/// </summary>
		public static string Address
		{
			get { return GetDBConnectionString("Address");}
		}
		/// <summary>
		/// 邮件数据库的连接字符串。
		/// </summary>
		public static string MAIL
		{
			get { return GetDBConnectionString("MAIL");}
		}
		/// <summary>
		/// 工作流数据库的连接字符串。
		/// </summary>
		public static string DLFLODB
		{
			get { return GetDBConnectionString("DLFLODB");}
		}
		/// <summary>
		/// 巡检数据库的连接字符串。
		/// </summary>
		public static string NetDoor
		{
			get { return GetDBConnectionString("NetDoor");}
		}
        /// <summary>
        /// 人事数据库。
        /// </summary>
	    public static string HR
	    {
            get { return GetDBConnectionString("HR"); }
	    }
        /// <summary>
        /// 生产监控数据库。
        /// </summary>
	    public static String Monitor
	    {
            get { return GetDBConnectionString("Monitor"); }
	    }
        /// <summary>
        /// 合同数据库。
        /// </summary>
	    public static string Contract
	    {
            get { return GetDBConnectionString("Contract"); }
	    }
		#endregion

		#region 私有方法
		/// <summary>
		/// 根据ComponentConfiguration.xml的SectionName获取数据库的连接字符串。
		/// </summary>
		/// <param name="sectionName">ComponentConfiguration.xml中Section名称。</param>
		/// <returns>数据库连接字符串。</returns>
		private static string GetDBConnectionString(string sectionName)
		{
			return	((ComponentConfiguration) ComponentConfigurations.Instance[sectionName]).DatabaseConnectionString; 
		}
		#endregion

		#region 构造函数
		/// <summary>
		/// 内部构造函数。
		/// </summary>
		internal ConnectionString()
		{
		}
		#endregion
	}
}
