//-----------------------------------------------------------------------
// <copyright file="ComponentConfiguration.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Shmzh.Components.SystemComponent
{
    using System;
    using System.Collections;
    using System.Xml;

	/// <summary>
	/// 组件配置信息。
	/// </summary>
	public class ComponentConfiguration
	{
        /// <summary>
        /// 配置对象实例。
        /// </summary>
		private static ComponentConfiguration instance;
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#region 成员变量
		private readonly string componentName = string.Empty;
		private readonly string version = string.Empty;
		private readonly string purpose = string.Empty;
		private readonly string databaseConnectionString = string.Empty;
		private readonly string logFilePath = string.Empty;
		#endregion

        #region 构造函数
        /// <summary>
        /// 内部使用的构造函数.
        /// </summary>
        /// <param name="componentName">组件名称</param>
        /// <param name="version">版本</param>
        /// <param name="purpose">用途</param>
        /// <param name="databaseConnectionString">数据库连接</param>
        /// <param name="logFilePath">日志文件路径</param>
        internal ComponentConfiguration(string componentName, string version, string purpose, string databaseConnectionString, string logFilePath)
        {
            this.componentName = componentName;
            this.version = version;
            this.purpose = purpose;
            this.databaseConnectionString = databaseConnectionString;
            this.logFilePath = logFilePath;
        }
        /// <summary>
        /// 内部使用的构造函数。
        /// </summary>
        /// <param name="componentName">组件名称。</param>
        /// <param name="databaseConnectionString">数据库连接字符串。</param>
        internal ComponentConfiguration(string componentName, string databaseConnectionString)
        {
            this.componentName = componentName;
            this.databaseConnectionString = databaseConnectionString;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        protected ComponentConfiguration()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="componentName">组件名称。</param>
        protected ComponentConfiguration(string componentName)
        {
            try
            {
                var dir = System.AppDomain.CurrentDomain.BaseDirectory;
                dir = dir.Replace(@"/", @"\") + @"CompontentConfiguration.xml";

                var xmlInfo = new System.Xml.XmlDocument();
                xmlInfo.Load(dir);

                var nodeList = xmlInfo.SelectSingleNode("Components").ChildNodes;

                foreach (XmlNode xn in nodeList) ////遍历所有子节点
                {
                    var xe = (XmlElement)xn;	////将子节点类型转换为XmlElement类型
                    if (xe.GetAttribute("Name") == componentName)
                    {
                        ////组件名称
                        this.componentName = xe.GetAttribute("Name");

                        ////版本
                        this.version = xe.GetAttribute("Version");

                        ////xe.ChildNodes
                        var nls = xe.ChildNodes;		////继续获取xe子节点的所有子节点

                        foreach (XmlNode xn1 in nls)			////遍历
                        {
                            var xe2 = (XmlElement)xn1;		////转换类型
                            if (xe2.Name == "Purpose")		////如果找到
                            {
                                //用途
                                this.purpose = xe2.InnerText;
                            }
                            if (xe2.Name == "DatabaseConnectionString")
                            {
                                //数据库联接
                                this.databaseConnectionString = xe2.InnerText;
                            }

                            if (xe2.Name == "LogFilePath")
                            {
                                this.logFilePath = xe2.InnerText;
                            }
                        }
                        break;
                    } //End if
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }		//End ComponentConfiguration

        #endregion

		#region 属性
		/// <summary>
		/// 组件名称.
		/// </summary>
		public string ComponentName
		{
			get {return this.componentName;}
		}
		
		/// <summary>
		/// 组件版本
		/// </summary>
		public string Version
		{
			get {return this.version;}
		}
		/// <summary>
		/// 组件用途
		/// </summary>
		public string Purpose
		{
			get {return this.purpose;}
		}
		/// <summary>
		/// 组件对应的数据库连接字符串
		/// </summary>
		public string DatabaseConnectionString
		{
			get {return this.databaseConnectionString;}
		}
		/// <summary>
		/// 组件所产生的日志文件路径
		/// </summary>
		public string LogFilePath
		{
			get {return this.logFilePath;}
		}

		#endregion
		
		/// <summary>
		/// 全局访问点
		/// </summary>
		/// <param name="thisComponentName">组件名称</param>
		/// <returns>ComponentConfiguration</returns>
		[Obsolete("该方法已经作废,请勿再使用!", true)] 
		public static ComponentConfiguration Instance(string thisComponentName)
		{
			if (instance == null)
				instance = new ComponentConfiguration(thisComponentName);

			return instance;
		}
	}

	/// <summary>
	/// ComponentConfigurations 的摘要说明。
	/// </summary>
	public class ComponentConfigurations : Hashtable
	{
        private static object syncObject = new object();
		private static ComponentConfigurations instance;

		#region 构造函数
		private ComponentConfigurations()
		{}
        #endregion
        #region private method
        /// <summary>
		/// 加载配置文件.
		/// </summary>
		private static void LoadConfig()
		{
			var xmlInfo = new System.Xml.XmlDocument();
			xmlInfo.Load(ConfigFilePath);
			var nodeList = xmlInfo.SelectSingleNode("Components").ChildNodes;
            ////遍历所有子节点.
			foreach (XmlNode xn in nodeList)
			{
				//var purpose = string.Empty;
				var databaseConnectionString = string.Empty;
				//var logFilePath = string.Empty;

                //将子节点类型转换为XmlElement类型
				var xe = (XmlElement)xn;		

				//如果哈希表中尚不存在该组件的配置信息.
				if (!instance.Contains(xe.GetAttribute("Name")))
				{
					var componentName = xe.GetAttribute("Name");//组件名称
					//var version = xe.GetAttribute("Version");//版本
					//xe.ChildNodes
					var nls = xe.ChildNodes;		//继续获取xe子节点的所有子节点

					foreach (XmlNode xn1 in nls)//遍历组件节点的下属节点.
					{
						var xe2 = (XmlElement)xn1;	//转换类型
                        //if (xe2.Name == "Purpose")//如果找到用途
                        //{
                        //    purpose = xe2.InnerText;
                        //}
						if (xe2.Name == "DatabaseConnectionString")//数据库联接
						{
							databaseConnectionString = xe2.InnerText;
						}
                        //if (xe2.Name == "LogFilePath")//日志文件路径.
                        //{
                        //    logFilePath = xe2.InnerText;
                        //}
					}
                    if (!instance.Contains(xe.GetAttribute("Name")))
                    {
                        instance.Add(componentName,new ComponentConfiguration(componentName, databaseConnectionString));
                        //instance.Add(componentName, new ComponentConfiguration(componentName, version, purpose, databaseConnectionString, logFilePath));
                    }
				} 
			}
		}
		#endregion

        #region 属性
        
        /// <summary>
        /// 组件配置信息集合体.
        /// </summary>
        public static ComponentConfigurations Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (instance == null)
                    {
                        instance = new ComponentConfigurations();
                        LoadConfig();
                    }
                    else if (instance.Count == 0)
                    {
                        LoadConfig();
                    }
                }
                
                return instance;
            }
        }
        /// <summary>
        /// 组件配置文件的路径.
        /// </summary>
        private static string ConfigFilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory.Replace(@"/", @"\") + @"CompontentConfiguration.xml";
            }
        }
        #endregion
	}
}
