using System;
using System.Collections;
using System.Xml;
using System.Configuration;

namespace Shmzh.Components.Util
{
	/// <summary>
	/// ��֮��ϵͳ����������Ϣ�Ĵ����ࡣ
	/// </summary>
	/// <example>
	/// ��ȡ������Ϣ��ʾ�����룺
	/// <code>
	/// using Shmzh.Components.Util;
	/// 
	/// namespace Shmzh.Test
	/// {
	///		//�ṩһ��ȫ�ֵķ��ʵ㡣
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
	/// �����ļ���ʽ������ʾ��
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
		#region ����
		/// <summary>
		///  ��Ϣ�Ĺ�ϣ��
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
		/// �������Ĺ�ϣ��
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
	    /// �����ļ�·����
	    /// </summary>
	    public string FilePath { get; set; }


	    private System.Xml.XmlDocument objXmlDocument = new System.Xml.XmlDocument();
		
		#endregion

		#region ���캯��
		/// <summary>
		/// �չ��캯����
		/// </summary>
		protected Configuration()
		{
		}
		/// <summary>
		/// ���캯����
		/// </summary>
		/// <param name="filePath"></param>
		public Configuration(string filePath)
		{
			this.FilePath = filePath;
			this.LoadConfigFile();
			
			this.FillMessage();//�����Ϣ��
			this.FillSwitch();//��俪������
		}
		#endregion

		#region ����
		/// <summary>
		/// ����������ָ����FilePath�����������ļ���
		/// </summary>
		protected void LoadConfigFile()
		{
			this.LoadConfigFile(this.FilePath);
		}
		/// <summary>
		/// ���������ļ���
		/// </summary>
		/// <param name="filePath">�ļ�·����</param>
		protected void LoadConfigFile(string filePath)
		{
			this.objXmlDocument.Load(filePath);
		}
		/// <summary>
		/// ��XML�����ļ�����ȡָ����ǩ���Ƶ�Ԫ����䵽Hashtable�С�
		/// </summary>
		/// <param name="tagName">��ǩ���ơ�</param>
		/// <param name="ht">��ϣ��</param>
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
		/// ��XML�����ļ��и���ָ����SectionName��TagName��������Ϣ��䵽��ϣ���С�
		/// </summary>
		/// <param name="sectionName">�����ơ�</param>
		/// <param name="tagName">��ǩ���ơ�</param>
		/// <param name="ht">��ϣ��</param>
		/// <returns>bool</returns>
		protected void FillHashtableBySectionTag(string sectionName,string tagName, Hashtable ht)
		{
			try
			{
				XmlNodeList oNodeList = this.objXmlDocument.GetElementsByTagName(sectionName);
				if (oNodeList.Count == 0)
				{
					throw new Exception("�����ļ���û���ҵ�ָ���Ľڡ�");
				}
				else if (oNodeList.Count > 1)
				{
					throw new Exception("�����ļ��д����ų���һ����ָ���ڡ�");
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
		/// ��XML�����ļ��и���ָ����SectionName��TagName��������Ϣ��䵽��ϣ���С�
		/// </summary>
		/// <param name="sectionName">�����ơ�</param>
		/// <param name="ht">��ϣ��</param>
		/// <returns>bool</returns>
		protected void FillHashtableBySection(string sectionName, Hashtable ht)
		{
			try
			{
				XmlNodeList oNodeList = this.objXmlDocument.GetElementsByTagName(sectionName);
				if (oNodeList.Count == 0)
				{
					throw new Exception("�����ļ���û���ҵ�ָ���Ľڡ�");
				}
				else if (oNodeList.Count > 1)
				{
					throw new Exception("�����ļ��д����ų���һ����ָ���ڡ�");
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
		/// �������ļ��н�Messages���е�MessageԪ����䵽��ϣ���С�
		/// </summary>
		/// <remarks>��Ϣ��</remarks>
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
		/// �������ļ��н�Switchs���е�SwitchԪ����䵽��ϣ���С�
		/// </summary>
		/// <remarks>��������</remarks>
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
        ///���������ַ���
        ///</summary>
        ///<param name="newName">�����ַ�������</param>
        ///<param name="newConString">�����ַ�������</param>
        ///<param name="newProviderName">�����ṩ��������</param>
        public static void UpdateConnectionStringsConfig(string newName, string newConString, string newProviderName)
        {
            var isModified = false;    //��¼�����Ӵ��Ƿ��Ѿ�����
            //���Ҫ���ĵ����Ӵ��Ѿ�����
            if (ConfigurationManager.ConnectionStrings[newName] != null)
            {
                isModified = true;
            }
            //�½�һ�������ַ���ʵ��
            var mySettings = new ConnectionStringSettings(newName, newConString, newProviderName);
            // �򿪿�ִ�е������ļ�*.exe.config
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // ������Ӵ��Ѵ��ڣ�����ɾ����
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // ���µ����Ӵ���ӵ������ļ���.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // ����������ļ������ĸ���
            config.Save(ConfigurationSaveMode.Modified);
            // ǿ���������������ļ���ConnectionStrings���ý�
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
        ///<summary>
        ///�ڣ�.exe.config�ļ���appSettings���ý�����һ�Լ���ֵ��
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
