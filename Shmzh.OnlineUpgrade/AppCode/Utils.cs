using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Shmzh.OnlineUpgrade
{
    class Utils
    {
        #region Fields
        private static String _appName;
        private static String _appFile;
        #endregion

        public static String GetConfig(String key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetConfig(String key, String value, Boolean isNeedRefresh)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] != null)
            {
                config.AppSettings.Settings[key].Value = value;
            }
            else
            {
                config.AppSettings.Settings.Add(key, value);
            }
            try
            {
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch { }
            if (isNeedRefresh)
            {
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public static String AppName
        {
            get 
            {
                if(_appName == null)
                    _appName = ConfigurationManager.AppSettings["AppName"];
                return _appName;
            }
        }

        public static String AppFile
        {
            get
            {
                if (_appFile == null)
                    _appFile = ConfigurationManager.AppSettings["AppFile"];
                return _appFile;
            }
        }
    }
}
