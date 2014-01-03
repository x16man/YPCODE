using System;
using Shmzh.Components.Util;

namespace SystemManagement
{
	/// <summary>
	/// Common 的摘要说明。
	/// </summary>
	public class ConfigCommon
	{
		static Shmzh.Components.Util.Configuration common;
		ConfigCommon()
		{
		}
		static public Shmzh.Components.Util.Configuration instance() 
		{ 
			if(common == null)
				common =  new Shmzh.Components.Util.Configuration(AppDomain.CurrentDomain.BaseDirectory.Replace(@"/",@"\")+ @"switchs.xml");

			return common;
		}
		public static string GetMessageValue(string strKey)
		{
			return ConfigCommon.instance().Message[strKey].ToString();
		}
	}
}
