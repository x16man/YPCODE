using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using log4net;

namespace Shmzh.Monitor.DataService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //配置log4net   
            //log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));   
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}