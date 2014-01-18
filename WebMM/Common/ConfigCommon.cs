using System;
using System.Collections.Generic;
using System.Web;
using log4net;

namespace MZHMM.WebMM.Common
{
    public class ConfigCommon
    {
        static Shmzh.Components.Util.Configuration common = null;
        private static readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        

        ConfigCommon()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        static public Shmzh.Components.Util.Configuration instance()
        {
            if (common == null)
                common = new Shmzh.Components.Util.Configuration(AppDomain.CurrentDomain.BaseDirectory.Replace(@"/", @"\") + @"switchs.xml");

            return common;
        }

        public static string GetMessageValue(string strKey)
        {
            try
            {
                return ConfigCommon.instance().Message[strKey].ToString();
            }
            catch
            {
                Logger.Info(strKey);
                return "";
            }
        }
    }
}
