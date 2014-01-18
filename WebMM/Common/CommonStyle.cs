using System;
using System.Collections.Generic;
using System.Web;

namespace WebMM.Common
{
   
    public class CommonStyle
    {
        public static string TableBgcolor = System.Configuration.ConfigurationSettings.AppSettings.Get("TableBgcolor");
        public static string TableTitleBgcolor = System.Configuration.ConfigurationSettings.AppSettings.Get("TableTitleBgcolor");
        public static string TableSingularBgcolor = System.Configuration.ConfigurationSettings.AppSettings.Get("TableSingularBgcolor");
        public static string TableDualBgcolor = System.Configuration.ConfigurationSettings.AppSettings.Get("TableDualBgcolor");
        public static string TableSubmitBgcolor = System.Configuration.ConfigurationSettings.AppSettings.Get("TableSubmitBgcolor");

    }
}
