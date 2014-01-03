//-----------------------------------------------------------------------
// <copyright file="ConnectionString.cs" company="Shmzh Technology">
//     Copyright (c) Shmzh Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Shmzh.Components.SystemComponent
{
    using System;
	/// <summary>
	/// SystemComponent������������ݿ�������ַ���.
	/// </summary>
	public class ConnectionString
	{
		#region ��������
		/// <summary>
		/// SystemComponent���ʹ�õ����ݿ������ַ���.
		/// </summary>
		[Obsolete("�������Ѿ�����,������ʹ��!��ʹ��PubData���ԡ�", true)] 
		public static string Value 
		{
			get {return	((ComponentConfiguration) ComponentConfigurations.Instance["SystemComponent"]).DatabaseConnectionString; }
		}
		/// <summary>
		/// PubData�����ݿ������ַ�����
		/// </summary>
		public static string PubData
		{
			get { return GetDBConnectionString("PubData");}
		}
		/// <summary>
		/// ֪ʶ�������ݿ�������ַ�����
		/// </summary>
		public static string KM
		{
			get { return GetDBConnectionString("KM");}
		}
		/// <summary>
		/// ���Ϲ������ݿ�������ַ�����
		/// </summary>
		public static string MM
		{
			get { return GetDBConnectionString("MM");}
		}
		/// <summary>
		/// ��Ӧ�����ݿ�������ַ�����
		/// </summary>
		public static string CRM
		{
			get { return GetDBConnectionString("CRM");}
		}
		/// <summary>
		/// ��Ŀ�������ݿ�������ַ�����
		/// </summary>
		public static string PM
		{
			get { return GetDBConnectionString("PM");}
		}
		/// <summary>
		/// ʳ�ù������ݿ�������ַ�����
		/// </summary>
		public static string ET
		{
			get { return GetDBConnectionString("ET");}
		}
		/// <summary>
		/// ��ˮ��Ϣ���ݿ�������ַ�����
		/// </summary>
		public static string INFO
		{
			get { return GetDBConnectionString("INFO");}
		}
		/// <summary>
		/// �������ݿ�������ַ�����
		/// </summary>
		public static string Produce
		{
			get { return GetDBConnectionString("Produce");}
		}
		/// <summary>
		/// �豸���ݿ�������ַ�����
		/// </summary>
		public static string DEV
		{
			get { return GetDBConnectionString("DEV");}
		}
		/// <summary>
		/// ͨѶ¼���ݿ�������ַ�����
		/// </summary>
		public static string Address
		{
			get { return GetDBConnectionString("Address");}
		}
		/// <summary>
		/// �ʼ����ݿ�������ַ�����
		/// </summary>
		public static string MAIL
		{
			get { return GetDBConnectionString("MAIL");}
		}
		/// <summary>
		/// ���������ݿ�������ַ�����
		/// </summary>
		public static string DLFLODB
		{
			get { return GetDBConnectionString("DLFLODB");}
		}
		/// <summary>
		/// Ѳ�����ݿ�������ַ�����
		/// </summary>
		public static string NetDoor
		{
			get { return GetDBConnectionString("NetDoor");}
		}
        /// <summary>
        /// �������ݿ⡣
        /// </summary>
	    public static string HR
	    {
            get { return GetDBConnectionString("HR"); }
	    }
        /// <summary>
        /// ����������ݿ⡣
        /// </summary>
	    public static String Monitor
	    {
            get { return GetDBConnectionString("Monitor"); }
	    }
        /// <summary>
        /// ��ͬ���ݿ⡣
        /// </summary>
	    public static string Contract
	    {
            get { return GetDBConnectionString("Contract"); }
	    }
		#endregion

		#region ˽�з���
		/// <summary>
		/// ����ComponentConfiguration.xml��SectionName��ȡ���ݿ�������ַ�����
		/// </summary>
		/// <param name="sectionName">ComponentConfiguration.xml��Section���ơ�</param>
		/// <returns>���ݿ������ַ�����</returns>
		private static string GetDBConnectionString(string sectionName)
		{
			return	((ComponentConfiguration) ComponentConfigurations.Instance[sectionName]).DatabaseConnectionString; 
		}
		#endregion

		#region ���캯��
		/// <summary>
		/// �ڲ����캯����
		/// </summary>
		internal ConnectionString()
		{
		}
		#endregion
	}
}
