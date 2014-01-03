using System;
using System.Collections;
using System.Xml;
using System.Configuration;

namespace Shmzh.Components.Util
{
	/// <summary>
	/// 名之赫系统所用配置信息的处理类。
	/// </summary>
	/// <example>
	/// 读取配置信息的示例代码：
	/// <code>
	/// using Shmzh.Components.Util;
	/// 
	/// namespace Shmzh.Test
	/// {
	///		//提供一个全局的访问点。
	///		public class XXXConfig
	///		{
	///			private static Shmzh.Components.Util.Configuration _xxxConfig;
	///			public static Shmzh.Components.Util.Configuration Instance 
	///			{
	///				if (_xxxConfig==null)
	///					_xxxConfig = new new Shmzh.Components.Util.Configuration(AppDomain.CurrentDomain.BaseDirectory.Replace(@"/",@"\")+ @"switchs.xml");
	///				return _xxxConfig;
	///			}
	///			
	///		}
	///		
	///		public class TestConfig
	///		{
	///			public TestConfig(){}
	///			
	///			public void test()
	///			{
	///				string switch1 = XXXConfig.Instance.Switch["IsNeedAudit"].ToString();
	///			}
	///		}
	/// }
	/// 
	/// 配置文件格式如下所示：
	/// <?xml version="1.0" encoding="utf-8" ?>
	/// <Configs>
	///		<Switchs>
	///			<Switch name="IsNeedAudit" value="1"/>
	///			<Switch name="switchName2" value="switchValue2"/>
	///		</Switchs>
	///		<Messages>
	///			<Message name="Message1" value="MessageValue1"/>
	///			<Message name="Message2" value="MessageValue2"/>
	///		</Messages>
	/// </Configs>
	/// </code>
	/// </example>
	public class Configuration
	{
		#region 属性
		/// <summary>
		///  信息的哈希表。
		/// </summary>
		public Hashtable Message
		{
			get 
			{
				if (_message == null)
					_message = new Hashtable();
				return _message;
			}
			set {this._message = value;}
		}
		private Hashtable _message;
		/// <summary>
		/// 开关量的哈希表。
		/// </summary>
		public Hashtable Switch
		{
			get 
			{
				if (_switch == null)
					_switch = new Hashtable();
				return _switch;
			}
			set {this._switch = value;}
		}
		private Hashtable _switch;

	    /// <summary>
	    /// 配置文件路径。
	    /// </summary>
	    public string FilePath { get; set; }


	    private System.Xml.XmlDocument objXmlDocument = new System.Xml.XmlDocument();
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 空构造函数。
		/// </summary>
		protected Configuration()
		{
		}
		/// <summary>
		/// 构造函数。
		/// </summary>
		/// <param name="filePath"></param>
		public Configuration(string filePath)
		{
			this.FilePath = filePath;
			this.LoadConfigFile();
			
			this.FillMessage();//填充消息表。
			this.FillSwitch();//填充开关量表。
		}
		#endregion

		#region 方法
		/// <summary>
		/// 根据属性中指定的FilePath来加载配置文件。
		/// </summary>
		protected void LoadConfigFile()
		{
			this.LoadConfigFile(this.FilePath);
		}
		/// <summary>
		/// 加载配置文件。
		/// </summary>
		/// <param name="filePath">文件路径。</param>
		protected void LoadConfigFile(string filePath)
		{
			this.objXmlDocument.Load(filePath);
		}
		/// <summary>
		/// 从XML配置文件中提取指定标签名称的元素填充到Hashtable中。
		/// </summary>
		/// <param name="tagName">标签名称。</param>
		/// <param name="ht">哈希表。</param>
		/// <returns>bool</returns>
		protected void FillHashtableByTagName(string tagName,Hashtable ht)
		{
			try
			{
				XmlNodeList nodeList = objXmlDocument.GetElementsByTagName(tagName);
				foreach(XmlNode oNode in nodeList)
				{
					ht.Add(oNode.Attributes["name"].Value, oNode.Attributes["value"].Value);	
				}
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// 从XML配置文件中根据指定的SectionName和TagName将配置信息填充到哈希表中。
		/// </summary>
		/// <param name="sectionName">节名称。</param>
		/// <param name="tagName">标签名称。</param>
		/// <param name="ht">哈希表。</param>
		/// <returns>bool</returns>
		protected void FillHashtableBySectionTag(string sectionName,string tagName, Hashtable ht)
		{
			try
			{
				XmlNodeList oNodeList = this.objXmlDocument.GetElementsByTagName(sectionName);
				if (oNodeList.Count == 0)
				{
					throw new Exception("配置文件中没有找到指定的节。");
				}
				else if (oNodeList.Count > 1)
				{
					throw new Exception("配置文件中存在着超过一个的指定节。");
				}
				else
				{
					foreach(XmlNode oNode in oNodeList[0].ChildNodes)
					{
						if (oNode.Name == tagName)
						{
							ht.Add(oNode.Attributes.GetNamedItem("name").Value, oNode.Attributes.GetNamedItem("value").Value);
						}
					}
				}
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// 从XML配置文件中根据指定的SectionName和TagName将配置信息填充到哈希表中。
		/// </summary>
		/// <param name="sectionName">节名称。</param>
		/// <param name="ht">哈希表。</param>
		/// <returns>bool</returns>
		protected void FillHashtableBySection(string sectionName, Hashtable ht)
		{
			try
			{
				XmlNodeList oNodeList = this.objXmlDocument.GetElementsByTagName(sectionName);
				if (oNodeList.Count == 0)
				{
					throw new Exception("配置文件中没有找到指定的节。");
				}
				else if (oNodeList.Count > 1)
				{
					throw new Exception("配置文件中存在着超过一个的指定节。");
				}
				else
				{
					foreach(XmlNode oNode in oNodeList[0].ChildNodes)
					{
						ht.Add(oNode.Attributes["name"].Value, oNode.Attributes["value"].Value);
					}
				}
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// 从配置文件中将Messages节中的Message元素填充到哈希表中。
		/// </summary>
		/// <remarks>消息。</remarks>
		/// <returns>bool</returns>
		protected void FillMessage()
		{
			try
			{
				this.FillHashtableBySectionTag("Messages","Message",this.Message);
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// 从配置文件中将Switchs节中的Switch元素填充到哈希表中。
		/// </summary>
		/// <remarks>开关量。</remarks>
		/// <returns>bool</returns>
		protected void FillSwitch()
		{
			try
			{
				this.FillHashtableBySectionTag("Switchs","Switch",this.Switch);
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		#endregion

        #region static method
        ///<summary>
        ///更新连接字符串
        ///</summary>
        ///<param name="newName">连接字符串名称</param>
        ///<param name="newConString">连接字符串内容</param>
        ///<param name="newProviderName">数据提供程序名称</param>
        public static void UpdateConnectionStringsConfig(string newName, string newConString, string newProviderName)
        {
            var isModified = false;    //记录该连接串是否已经存在
            //如果要更改的连接串已经存在
            if (ConfigurationManager.ConnectionStrings[newName] != null)
            {
                isModified = true;
            }
            //新建一个连接字符串实例
            var mySettings = new ConnectionStringSettings(newName, newConString, newProviderName);
            // 打开可执行的配置文件*.exe.config
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 如果连接串已存在，首先删除它
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // 将新的连接串添加到配置文件中.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
        ///<summary>
        ///在＊.exe.config文件中appSettings配置节增加一对键、值对
        ///</summary>
        ///<param name="newKey"></param>
        ///<param name="newValue"></param>
        public static void UpdateAppConfig(string newKey, string newValue)
        {
            var isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isModified = true;
                }
            }

            // Open App.Config of executable
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // You need to remove the old settings object before you can replace it
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            // Add an Application Setting.
            config.AppSettings.Settings.Add(newKey, newValue);
            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion
    }
}
