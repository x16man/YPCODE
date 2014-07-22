using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmWebBrowser : Form, IBaseForm
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private String configFile = "WebBrowser.xml";
        private bool isLoadingData = false;
        private WebBrowserConfig webBrowserConfig;
        #endregion

        #region Constructors
        public FrmWebBrowser()
        {
            InitializeComponent();
        }

        public FrmWebBrowser(String configFile, Int32 updateTime)
            : this()
        {
            this.configFile = configFile;
            if (updateTime > 0)
            {
                timerUpdate.Interval = updateTime * 1000;
                timerUpdate.Start();
            }

            webBrowserConfig = this.LoadConfig();
            if (!String.IsNullOrEmpty(webBrowserConfig.Url))
            {
                this.webBrowser1.Navigate(webBrowserConfig.Url);
            }
        }
        #endregion

        /// <summary>
        /// Load Config.
        /// </summary>
        /// <returns></returns>
        private WebBrowserConfig LoadConfig()
        {
            WebBrowserConfig configInfo = new WebBrowserConfig();
            XmlDocument doc = new XmlDocument();
            String xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\" + configFile);
            try
            {
                doc.Load(xmlPath);
                XmlNode xmlNode = doc.DocumentElement.SelectSingleNode("Url");
                configInfo.Url = xmlNode.InnerText;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return configInfo;
        }

        #region Event Handlers
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "CurrentProgress", e.CurrentProgress);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "MaximumProgress", e.MaximumProgress);
            //messageBoxCS.AppendLine();
            //System.Diagnostics.Debug.WriteLine("ProgressChanged Event: " + messageBoxCS.ToString());

            if ((e.CurrentProgress > 0) && (e.MaximumProgress > 0))
            {
                if (e.CurrentProgress < e.MaximumProgress)
                    isLoadingData = true;
            }
            else //if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                isLoadingData = false;
            }
        }

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Message msg = new Message();
            switch (e.KeyData)
            {
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Home:
                case Keys.End:
                    this.ProcessCmdKey(ref msg, e.KeyData);
                    break;
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            this.webBrowser1.Refresh(WebBrowserRefreshOption.Normal);

            //if (!String.IsNullOrEmpty(webBrowserConfig.Url))
            //{
            //    //this.webBrowser1.Url = new System.Uri(webBrowserConfig.Url, System.UriKind.Absolute);
            //    //this.webBrowser1.Navigate(webBrowserConfig.Url);
            //    System.Diagnostics.Debug.WriteLine("timerUpdate_Tick: ");
            //}
        }
        #endregion

        #region IBaseForm 实现
        public LoadState GetLoadState()
        {
            if (isLoadingData)
            {
                return LoadState.Loading;
            }
            else
            {
                return LoadState.Finished;
            }
        }
        #endregion

        public struct WebBrowserConfig
        {
            public String Url { get; set; }
        }

        
    }
}
