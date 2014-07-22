using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Configuration;

namespace Shmzh.OnlineUpgrade
{
    public class UpgradeHandler
    {
        #region Fields
        private static OnlineUpgradeService.OnlineUpgrade _onlineUpgrade;
        private String _product = "Monitor";
        #endregion

        static UpgradeHandler()
        {
            _onlineUpgrade = new OnlineUpgradeService.OnlineUpgrade();
        }

        //public UpgradeHandler() { }

        /// <summary>
        /// 检查是否可以连接到 WebService。
        /// </summary>
        /// <returns></returns>
        public bool LinkService()
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(_onlineUpgrade.Url);
            try
            {
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                myHttpWebResponse.Close();
                return true;
            }
            catch (WebException e)
            {
                //Debug.WriteLine("This program is expected to throw WebException on successful run." +
                //                    "\n\nException Message :" + e.Message);
                //if (e.Status == WebExceptionStatus.ProtocolError)
                //{
                //    Debug.WriteLine(String.Format("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode));
                //    Debug.WriteLine(String.Format("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription));
                //}
                return false;
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message);
                return false;
            }
        }
        
        /// <summary>
        /// 开始升级。
        /// </summary>
        public void Start()
        {
            String myVersion = Utils.GetConfig("Version");
            String newVersion = myVersion;
            bool isNeedUpgrade = _onlineUpgrade.CheckVersion(_product, ref newVersion);

            if (isNeedUpgrade)
            {
                var fileList = _onlineUpgrade.GetUpgradeList(_product, newVersion);

                //WebClient webClient = new WebClient();
                //webClient.DownloadFileAsync(
            }
        }

    }
}
