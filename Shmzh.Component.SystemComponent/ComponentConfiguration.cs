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
	/// ���������Ϣ��
	/// </summary>
	public class ComponentConfiguration
	{
        /// <summary>
        /// ���ö���ʵ����
        /// </summary>
		private static ComponentConfiguration instance;
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#region ��Ա����
		private readonly string componentName = string.Empty;
		private readonly string version = string.Empty;
		private readonly string purpose = string.Empty;
		private readonly string databaseConnectionString = string.Empty;
		private readonly string logFilePath = string.Empty;
		#endregion

        #region ���캯��
        /// <summary>
        /// �ڲ�ʹ�õĹ��캯��.
        /// </summary>
        /// <param name="componentName">�������</param>
        /// <param name="version">�汾</param>
        /// <param name="purpose">��;</param>
        /// <param name="databaseConnectionString">���ݿ�����</param>
        /// <param name="logFilePath">��־�ļ�·��</param>
        internal ComponentConfiguration(string componentName, string version, string purpose, string databaseConnectionString, string logFilePath)
        {
            this.componentName = componentName;
            this.version = version;
            this.purpose = purpose;
            this.databaseConnectionString = databaseConnectionString;
            this.logFilePath = logFilePath;
        }
        /// <summary>
        /// �ڲ�ʹ�õĹ��캯����
        /// </summary>
        /// <param name="componentName">������ơ�</param>
        /// <param name="databaseConnectionString">���ݿ������ַ�����</param>
        internal ComponentConfiguration(string componentName, string databaseConnectionString)
        {
            this.componentName = componentName;
            this.databaseConnectionString = databaseConnectionString;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        protected ComponentConfiguration()
        {
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="componentName">������ơ�</param>
        protected ComponentConfiguration(string componentName)
        {
            try
            {
                var dir = System.AppDomain.CurrentDomain.BaseDirectory;
                dir = dir.Replace(@"/", @"\") + @"CompontentConfiguration.xml";

                var xmlInfo = new System.Xml.XmlDocument();
                xmlInfo.Load(dir);

                var nodeList = xmlInfo.SelectSingleNode("Components").ChildNodes;

                foreach (XmlNode xn in nodeList) ////���������ӽڵ�
                {
                    var xe = (XmlElement)xn;	////���ӽڵ�����ת��ΪXmlElement����
                    if (xe.GetAttribute("Name") == componentName)
                    {
                        ////�������
                        this.componentName = xe.GetAttribute("Name");

                        ////�汾
                        this.version = xe.GetAttribute("Version");

                        ////xe.ChildNodes
                        var nls = xe.ChildNodes;		////������ȡxe�ӽڵ�������ӽڵ�

                        foreach (XmlNode xn1 in nls)			////����
                        {
                            var xe2 = (XmlElement)xn1;		////ת������
                            if (xe2.Name == "Purpose")		////����ҵ�
                            {
                                //��;
                                this.purpose = xe2.InnerText;
                            }
                            if (xe2.Name == "DatabaseConnectionString")
                            {
                                //���ݿ�����
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

		#region ����
		/// <summary>
		/// �������.
		/// </summary>
		public string ComponentName
		{
			get {return this.componentName;}
		}
		
		/// <summary>
		/// ����汾
		/// </summary>
		public string Version
		{
			get {return this.version;}
		}
		/// <summary>
		/// �����;
		/// </summary>
		public string Purpose
		{
			get {return this.purpose;}
		}
		/// <summary>
		/// �����Ӧ�����ݿ������ַ���
		/// </summary>
		public string DatabaseConnectionString
		{
			get {return this.databaseConnectionString;}
		}
		/// <summary>
		/// �������������־�ļ�·��
		/// </summary>
		public string LogFilePath
		{
			get {return this.logFilePath;}
		}

		#endregion
		
		/// <summary>
		/// ȫ�ַ��ʵ�
		/// </summary>
		/// <param name="thisComponentName">�������</param>
		/// <returns>ComponentConfiguration</returns>
		[Obsolete("�÷����Ѿ�����,������ʹ��!", true)] 
		public static ComponentConfiguration Instance(string thisComponentName)
		{
			if (instance == null)
				instance = new ComponentConfiguration(thisComponentName);

			return instance;
		}
	}

	/// <summary>
	/// ComponentConfigurations ��ժҪ˵����
	/// </summary>
	public class ComponentConfigurations : Hashtable
	{
        private static object syncObject = new object();
		private static ComponentConfigurations instance;

		#region ���캯��
		private ComponentConfigurations()
		{}
        #endregion
        #region private method
        /// <summary>
		/// ���������ļ�.
		/// </summary>
		private static void LoadConfig()
		{
			var xmlInfo = new System.Xml.XmlDocument();
			xmlInfo.Load(ConfigFilePath);
			var nodeList = xmlInfo.SelectSingleNode("Components").ChildNodes;
            ////���������ӽڵ�.
			foreach (XmlNode xn in nodeList)
			{
				//var purpose = string.Empty;
				var databaseConnectionString = string.Empty;
				//var logFilePath = string.Empty;

                //���ӽڵ�����ת��ΪXmlElement����
				var xe = (XmlElement)xn;		

				//�����ϣ�����в����ڸ������������Ϣ.
				if (!instance.Contains(xe.GetAttribute("Name")))
				{
					var componentName = xe.GetAttribute("Name");//�������
					//var version = xe.GetAttribute("Version");//�汾
					//xe.ChildNodes
					var nls = xe.ChildNodes;		//������ȡxe�ӽڵ�������ӽڵ�

					foreach (XmlNode xn1 in nls)//��������ڵ�������ڵ�.
					{
						var xe2 = (XmlElement)xn1;	//ת������
                        //if (xe2.Name == "Purpose")//����ҵ���;
                        //{
                        //    purpose = xe2.InnerText;
                        //}
						if (xe2.Name == "DatabaseConnectionString")//���ݿ�����
						{
							databaseConnectionString = xe2.InnerText;
						}
                        //if (xe2.Name == "LogFilePath")//��־�ļ�·��.
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

        #region ����
        
        /// <summary>
        /// ���������Ϣ������.
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
        /// ��������ļ���·��.
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
