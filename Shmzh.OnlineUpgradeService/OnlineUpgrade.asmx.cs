using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.Configuration;

using ICSharpCode.SharpZipLib.Zip;

namespace Shmzh.OnlineUpgradeService
{
    /// <summary>
    /// OnlineUpdate 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.shmzh.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class OnlineUpgrade : System.Web.Services.WebService
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        /// <summary>
        /// 程序原文件的根目录。
        /// </summary>
        private String sourceFolder;
        /// <summary>
        /// 升级包的根目录。
        /// </summary>
        private String packsFolder;
        #endregion

        /// <summary>
        /// 创建 OnlineUpgrade 的新实例。
        /// </summary>
        public OnlineUpgrade()
        {
            sourceFolder = Server.MapPath(String.Format("~/{0}/", ConfigurationManager.AppSettings["SourceFolder"]));
            packsFolder = Server.MapPath(String.Format("~/{0}/", ConfigurationManager.AppSettings["PacksFolder"]));
            if (!Directory.Exists(packsFolder))
            {
                Directory.CreateDirectory(packsFolder);
            }
        }

        [WebMethod(Description="获取应用程序的虚拟目录根目录。")]
        public String GetAppsVirtualRoot()
        {
            return String.Format("{0}/", ConfigurationManager.AppSettings["PacksFolder"]);
        }

        [WebMethod(Description="检查客户端版本是否需要升级。需要升级则返回 true， 否则返回 false。")]
        /// <summary>
        /// 检查客户端版本是否需要升级。需要升级则返回 true， 否则返回 false。
        /// </summary>
        /// <param name="product">产品名称。</param>
        /// <param name="version">传入客户端版本号。返回新的可用的版本号。</param>
        /// <returns>需要升级则返回 true， 否则返回 false。</returns>
        public bool CheckVersion(String product, ref String version)
        {
            XmlDocument doc = new XmlDocument();
            String xmlPath = Path.Combine(sourceFolder, product +  @"\Upgrade.config");
            try
            {
                doc.Load(xmlPath);
                XmlNode xmlNode = doc.DocumentElement.SelectSingleNode("Version");
                String svrVersion = xmlNode.InnerText;
                if (version != svrVersion)
                {
                    version = svrVersion;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(String.Format("检测版本时出错：{0}", ex.Message), ex);
                return false; 
            }
            return false;
        }

        [WebMethod(Description="获取要更新的文件列表。")]
        public List<String> GetUpgradeList(String product)
        {
            List<String> list = new List<String>();
            XmlDocument doc = new XmlDocument();
            String xmlPath = Path.Combine(sourceFolder, product + @"\Upgrade.config");
            try
            {
                doc.Load(xmlPath);
                XmlNodeList nodeList = doc.DocumentElement.SelectNodes("FileList/File[@IsNeedUpdate=\"True\"]");
                //Logger.Debug("地址:" + nodeList.Count);
                foreach (XmlNode node in nodeList)
                {
                    list.Add(node.InnerText);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(String.Format("获取升级列表时出错：{0}", ex.Message), ex);
            }           
            return list;
        }

        [WebMethod(Description = "检查是否需要重新打包升级文件。需要重新打包返回 true，否则返回 false。")]
        /// <summary>
        /// 检测是否需要压缩。
        /// </summary>
        /// <param name="product">产品名称。</param>
        /// <returns></returns>
        public bool CheckIsNeedZip(String product)
        {
            String xmlPath = Path.Combine(sourceFolder, product + @"\Upgrade.config");
            String zipFile = Path.Combine(packsFolder, product + ".zip");
            if (File.Exists(zipFile))
            {
                //如果配置文件的最后修改时间　早于　升级压缩包的时间，则不需要重新压缩。
                if (File.GetLastWriteTime(xmlPath) <= File.GetLastWriteTime(zipFile))
                {
                    return false;
                }
            }
            return true;
        }

        [WebMethod(Description = "重新打包升级文件。")]
        /// <summary>
        /// 压缩升级文件。
        /// </summary>
        /// <param name="product">产品名称。</param>
        public void ZipFiles(String product)
        {
            var list = GetUpgradeList(product);
            String strBaseDir = Path.Combine(sourceFolder, product + "\\");
            String zipFile = Path.Combine(packsFolder, product + ".zip");
            ZipFiles(list.ToArray(), zipFile, strBaseDir);
        }

        [WebMethod(Description = "获取升级包的大小。")]
        public long GetTotalBytes(String product)
        {
            String zipFile = Path.Combine(packsFolder, product + ".zip");
            FileInfo fileInfo = new FileInfo(zipFile);
            return fileInfo.Length;
        }

        [WebMethod(Description = "返回需要下载的文件字节。")]
        public byte[] DownloadFileBytes(String product, String fileName)
        {
            String filePath = Path.Combine(sourceFolder, product + @"\" + fileName);
            if (File.Exists(filePath))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(filePath))
                    {
                        int i = (int)fs.Length;
                        byte[] ba = new byte[i];
                        fs.Read(ba, 0, i);
                        fs.Close();
                        return ba;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(String.Format("下载时出错，文件：{0}", filePath), ex);
                    return new byte[0];
                }
            }
            else
            {
                Logger.Error(String.Format("不存在文件：{0}", filePath));
                return new byte[0];
            }
        }

        /// <summary>
        /// 压缩文件。
        /// </summary>
        /// <param name="filenames"></param>
        /// <param name="zipFileName"></param>
        /// <param name="strBaseDir"></param>
        private void ZipFiles(String[] filenames, String zipFileName, String strBaseDir)
        {
            // 'using' statements gaurantee the stream is closed properly which is a big source
            // of problems otherwise.  Its exception safe as well which is great.
            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFileName)))
            {
                s.SetLevel(9); // 0 - store only to 9 - means best compression

                byte[] buffer = new byte[4096];

                foreach (string file in filenames)
                {
                    // Using GetFileName makes the result compatible with XP
                    // as the resulting path is not absolute.
                    ZipEntry entry = new ZipEntry(file);

                    // Setup the entry data as required.

                    // Crc and size are handled by the library for seakable streams
                    // so no need to do them here.

                    // Could also use the last write time or similar for the file.
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(Path.Combine(strBaseDir, file)))
                    {
                        // Using a fixed size buffer here makes no noticeable difference for output
                        // but keeps a lid on memory usage.
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }

                // Finish/Close arent needed strictly as the using statement does this automatically

                // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                // the created file would be invalid.
                s.Finish();

                // Close is important to wrap things up and unlock the file.
                s.Close();
            }
        }
    }
}
