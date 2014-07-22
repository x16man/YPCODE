using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Configuration;
using System.IO;

using ICSharpCode.SharpZipLib.Zip;

namespace Shmzh.OnlineUpgrade
{
    public partial class FrmMain : Form
    {
        #region Fields
        private static Shmzh.Monitor.OnlineUpgrade.OnlineUpgradeService.OnlineUpgrade _onlineUpgrade = new Shmzh.Monitor.OnlineUpgrade.OnlineUpgradeService.OnlineUpgrade();
        private delegate void SetStatusHandler(String status);
        private delegate void PerformStepHandler();
        private delegate void SetBtnCancelHandler(bool isEnabled, String text);
        private String _product = ConfigurationManager.AppSettings["Product"];
        private String _tempFolder;
        private String _appFolder;
        private String _upgradeZip;
        /// <summary>
        /// 升级是否已经被取消。
        /// </summary>
        private bool _isCanceled = false;
        /// <summary>
        /// 是否正在完成更新(覆盖升级文件)。
        /// </summary>
        private bool _isUpdating = false;
        private AutoResetEvent autoEvent;
        #endregion

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Properties
        /// <summary>
        /// 获取临时文件夹路径。
        /// </summary>
        public String TempFolder
        {
            get 
            {
                if(_tempFolder == null)
                    _tempFolder = Path.Combine(Application.StartupPath, "Temp\\");
                return _tempFolder;
            }
        }

        /// <summary>
        /// 获取主程序的文件夹路径。
        /// </summary>
        public String AppFolder
        {
            get
            {
                if (_appFolder == null)
                {
                    DirectoryInfo tmpDir = new DirectoryInfo(_tempFolder);
                    _appFolder = tmpDir.Parent.Parent.FullName;
                    if (!_appFolder.EndsWith("\\"))
                        _appFolder += "\\";
                }
                return _appFolder; 
            }
        }

        /// <summary>
        /// 获取升级包文件的路径。
        /// </summary>
        public String UpgradeZip
        {
            get
            {
                if (this._upgradeZip == null)
                {
                    this._upgradeZip = Path.Combine(new DirectoryInfo(this.TempFolder).Parent.FullName, "Upgrade.zip");
                }
                return this._upgradeZip;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 设置当前状态。
        /// </summary>
        /// <param name="status"></param>
        private void SetStatus(String status)
        {
            if (this.lblStatus.InvokeRequired)
            {
                this.Invoke(new SetStatusHandler(SetStatus), status);
            }
            else
            {
                this.lblStatus.Text += status + "\r\n";
                this.pnlStatus.VerticalScroll.Value = this.pnlStatus.VerticalScroll.Maximum;
            }
        }

        /// <summary>
        /// 刷新一步进度条。
        /// </summary>
        private void PerformStep()
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new PerformStepHandler(PerformStep));
            }
            else
            {
                this.progressBar.PerformStep();
            }
        }

        private void SetBtnCancel(bool isEnabled, String text)
        {
            if (this.btnCancel.InvokeRequired)
            {
                this.btnCancel.Invoke(new SetBtnCancelHandler(SetBtnCancel), isEnabled, text);
            }
            else
            {
                if (text == "关闭")
                {
                    this._isUpdating = false;
                }
                this.btnCancel.Text = text;
                this.btnCancel.Enabled = isEnabled;
            }
        }

        //private String MyUrlEncode(String urlPart)
        //{
        //    urlPart = System.Web.HttpUtility.UrlPathEncode(urlPart);
        //    if (urlPart.Contains("#"))
        //    {
        //        String[] arrStr = urlPart.Split('/');

        //        for (int i = 0; i < arrStr.Length; i++)
        //        {
        //            arrStr[i] = System.Web.HttpUtility.UrlEncode(arrStr[i]);
        //        }
        //        urlPart = String.Join("/", arrStr);
        //    }
        //    return urlPart;
        //}

        /// <summary>
        /// 获取本地程序的版本。
        /// </summary>
        /// <returns></returns>
        private String GetVersion()
        {
            String locVersion = Utils.GetConfig("Version");
            return locVersion;
        }

        /// <summary>
        /// 删除临时文件夹。
        /// </summary>
        private void DeleteTempFiles()
        {
            if (Directory.Exists(this.TempFolder))
            {
                try
                {
                    Directory.Delete(this.TempFolder, true);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(String.Format("删除临时文件时出错：{0}\r\n", ex.Message), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.Sleep(1000);
                    this.DeleteTempFiles();
                }
            }
            if (File.Exists(this.UpgradeZip))
            {
                try
                {
                    File.Delete(this.UpgradeZip);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(String.Format("删除临时文件时出错：{0}\r\n", ex.Message), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.Sleep(1000);
                    this.DeleteTempFiles();
                }
            }
        }
        #endregion

        #region Event Handlers
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("{0}在线升级程序", Utils.AppName);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            ThreadStart ts = delegate
            {
                SetStatus("正在连接服务器...");
                if (LinkService())
                {
                    SetStatus("连接服务器成功。");
                    new Thread(new ThreadStart(Start)) { IsBackground = true }.Start();
                }
                else
                {
                    SetStatus("未能转接到服务器，请检查您的网络，稍候重试。");
                    MessageBox.Show("未能转接到服务器，请检查您的网络，稍候重试。", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            };
            new Thread(ts) { IsBackground = true }.Start();
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                SetStatus("升级包下载被取消。");
            }
            else
            {
                SetStatus("升级包下载完成。");
            }
            autoEvent.Set();
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (this._isCanceled)
            {
                WebClient webClient = sender as WebClient;
                if (webClient != null)
                {
                    webClient.CancelAsync();
                }
            }
            else
            {
                ThreadStart ts = delegate {
                    this.progressBar.Maximum = (int)e.TotalBytesToReceive;
                    this.progressBar.Value = (int)e.BytesReceived;
                };
                this.Invoke(ts);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.btnCancel.Text == "取消")
            {
                SetStatus("升级已经被取消。");
                this._isCanceled = true;
                Application.Exit();
            }
            else if (this.btnCancel.Text == "关闭")
            {
                Application.Exit();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._isUpdating)
            {
                if (MessageBox.Show("正在完成更新，您确定要停止更新并退出升级操作吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this._isCanceled = true;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            this.DeleteTempFiles();
        }
        #endregion

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
            SetStatus(String.Format("开始检测更新 {0}", DateTime.Now));
            String svrUrl = _onlineUpgrade.Url;
            String virtualPath = svrUrl.Substring(0, svrUrl.LastIndexOf('/') + 1) + _onlineUpgrade.GetAppsVirtualRoot();
            String locVersion = GetVersion();
            String newVersion = locVersion;
            bool isNeedUpgrade = _onlineUpgrade.CheckVersion(_product, ref newVersion);
            String processName = Utils.AppFile.Substring(0, Utils.AppFile.LastIndexOf('.'));
            if (isNeedUpgrade)
            {
                SetStatus(String.Format("检测到最新版本：{0}", newVersion));

                var processes = System.Diagnostics.Process.GetProcessesByName(processName);
                if (processes.Length > 0)
                {
                    if (MessageBox.Show(String.Format("检测到{0}程序正在运行，点击[是]关闭程序并完成升级，点击[否]终止升级。", Utils.AppName), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (var process in processes)
                        {
                            process.Kill();
                        }
                    }
                    else
                    {
                        SetStatus("升级已经被取消。");
                        DelayExit();
                        return;
                    }
                }

                var fileList = _onlineUpgrade.GetUpgradeList(_product);
                SetStatus(String.Format("共检测到要更新的文件{0}个。", fileList.Length));
                if (fileList.Length > 0)
                {
                    if (_onlineUpgrade.CheckIsNeedZip(_product))
                    {
                        SetStatus("正在打包升级文件...");
                        _onlineUpgrade.ZipFiles(_product);
                        SetStatus("打包升级文件完成。");
                    }
                    //int totalKBs = (int)(_onlineUpgrade.GetTotalBytes(_product) / 1024);
                    //int onceKBs = 50;
                    ThreadStart ts = delegate
                    {
                        this.progressBar.Visible = true;
                        //this.progressBar.Maximum = totalKBs;
                        //this.progressBar.Step = onceKBs;
                    };

                    //ThreadStart ts = delegate {
                    //    this.progressBar.Visible = true;
                    //    this.progressBar.Maximum = fileList.Length + 1;
                    //    this.progressBar.Step = 1;
                    //};
                    this.Invoke(ts);

                    #region =============== 下载全部文件。Start=================
                    //======================WebClient 逐个文件下载。==================
                    //WebClient webClient = new WebClient();
                    //foreach (String file in fileList)
                    //{
                    //    String tmpFolder = file.Substring(0, file.LastIndexOf("\\") + 1);
                    //    String fileName = file.Substring(file.LastIndexOf("\\") + 1);
                    //    tmpFolder = Path.Combine(this.TempFolder, tmpFolder);
                    //    if (!Directory.Exists(tmpFolder))
                    //        Directory.CreateDirectory(tmpFolder);

                    //    try
                    //    {
                    //        var fileUrl = virtualPath + this.MyUrlEncode(file.Replace("\\", "/"));
                    //        webClient.DownloadFile(fileUrl, tmpFolder + fileName);
                    //        SetStatus(String.Format("文件{0}下载完成。", file));
                    //    }
                    //    catch (WebException e)
                    //    {
                    //        SetStatus(String.Format("文件{0}下载失败。错误：{1}", file, e.Message));
                    //        SetStatus("升级已经停止，请稍候重试。");
                    //        return;
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        SetStatus(String.Format("文件{0}下载失败。错误：{1}", file, e.Message));
                    //        SetStatus("升级已经停止，请稍候重试。");
                    //        return;
                    //    }

                    //    PerformStep();
                    //}    
                    //======================Byte[]流 逐个文件下载。==================
                    //_onlineUpgrade.Timeout = 10000;
                    //foreach (String file in fileList)
                    //{
                    //    String tmpFolder = file.Substring(0, file.LastIndexOf("\\") + 1);
                    //    String fileName = file.Substring(file.LastIndexOf("\\") + 1);
                    //    tmpFolder = Path.Combine(this.TempFolder, tmpFolder);
                    //    if (!Directory.Exists(tmpFolder))
                    //        Directory.CreateDirectory(tmpFolder);

                    //    try
                    //    {
                    //        byte[] ba = _onlineUpgrade.DownloadFileBytes(_product, file);
                    //        FileStream fs = new FileStream(tmpFolder + fileName, FileMode.Create);
                    //        fs.Write(ba, 0, ba.Length);
                    //        fs.Close();

                    //        SetStatus(String.Format("文件{0}下载完成。", file));
                    //    }
                    //    catch (WebException e)
                    //    {
                    //        SetStatus(String.Format("文件{0}下载失败。错误：{1}", file, e.Message));
                    //        SetStatus("升级已经停止，请稍候重试。");
                    //        return;
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        SetStatus(String.Format("文件{0}下载失败。错误：{1}", file, e.Message));
                    //        SetStatus("升级已经停止，请稍候重试。");
                    //        return;
                    //    }

                    //    PerformStep();
                    //}
                    //======================Byte[]流 压缩后单个文件下载。未完成==================
                    //SetStatus("正在下载升级包...");
                    //byte[] buffer = new byte[onceKBs * 1024];
                    //String tmpFile = Path.Combine(this.TempFolder, this._product + ".zip");
                    //if (!Directory.Exists(this.TempFolder))
                    //    Directory.CreateDirectory(this.TempFolder);
                    //FileStream fs = new FileStream(tmpFile, FileMode.Create);
                    //int nBytesRead = 0;
                    //do
                    //{
                    //    nBytesRead = _onlineUpgrade.DownloadBytes(_product, ref buffer);
                    //    fs.Write(buffer, 0, nBytesRead);
                    //    PerformStep();
                    //} while (nBytesRead > 0);
                    //SetStatus("升级包下载完成。");
                    //======================WebClient 压缩后单个文件下载。==================                    
                    SetStatus("正在下载升级包...");
                    WebClient webClient = new WebClient();
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    String fileUrl = virtualPath + _product + ".zip";
                    webClient.DownloadFileAsync(new Uri(fileUrl), this.UpgradeZip);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    //等待下载完成。
                    autoEvent = new AutoResetEvent(false);
                    autoEvent.WaitOne();
                    webClient.Dispose();
                    //如果升级被取消，则退出升级线程。
                    if (this._isCanceled)
                        return;
                    #endregion =============== 下载全部文件。End=================
                    ts = delegate
                    {
                        this.progressBar.Visible = false;
                    };
                    this.Invoke(ts);

                    #region ================ 解压升级包。================
                    SetStatus("解压缩升级包...");
                    if (!Directory.Exists(this.TempFolder))
                        Directory.CreateDirectory(this.TempFolder);
                    UnZipFile(this.UpgradeZip, this.TempFolder);
                    SetStatus("升级包解压缩成功。");
                    #endregion

                    //临时文件目录。
                    DirectoryInfo tmpDirInfo = new DirectoryInfo(this.TempFolder);

                    int lenTmpDir = tmpDirInfo.FullName.Length;
                    FileInfo[] fileInfos = tmpDirInfo.GetFiles("*", SearchOption.AllDirectories);

                    //取消按钮设置为不可用。
                    SetBtnCancel(false, "取消");
                    //如果升级被取消，则退出升级线程。
                    if (this._isCanceled)
                        return;

                    ts = delegate
                    {
                        this.progressBar.Visible = true;
                        this.progressBar.Maximum = fileInfos.Length;
                        this.progressBar.Step = 1;
                        this.progressBar.Value = 0;
                    };
                    this.Invoke(ts);

                    this._isUpdating = true;
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        //如果升级被取消，则退出升级线程。
                        if (this._isCanceled)
                            return;

                        String myFileName = fileInfo.FullName.Substring(lenTmpDir);
                        String destFileName = Path.Combine(this.AppFolder, myFileName);
                        String sourceFileName = Path.Combine(this.TempFolder, myFileName);
                        String destDirName = Path.GetDirectoryName(destFileName);
                        if (!Directory.Exists(destDirName))
                            Directory.CreateDirectory(destDirName);

                        try
                        {
                            File.Copy(sourceFileName, destFileName, true);
                            SetStatus(String.Format("文件{0}更新成功。", myFileName));
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            MessageBox.Show(String.Format("出现错误：{0}\r\n升级失败，请稍候重试。", ex.Message), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SetBtnCancel(true, "关闭");
                            return;
                        }
                        catch (PathTooLongException ex)
                        {
                            MessageBox.Show(String.Format("出现错误：{0}\r\n升级失败，请稍候重试。", ex.Message), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SetBtnCancel(true, "关闭");
                            return;
                        }
                        catch (IOException ex)
                        {
                            DialogResult dr = MessageBox.Show(String.Format("出现错误：{0}\r\n如果{1}程序正在运行，请先关闭{1}程序，然后点击[重试]。\r\n如果要终止升级，请点击[终止]。\r\n如果忽略此更新，请点击[忽略]。", ex.Message, Utils.AppName), "错误提示", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
                            while (dr == DialogResult.Retry)
                            {
                                try
                                {
                                    File.Copy(sourceFileName, destFileName, true);
                                    SetStatus(String.Format("文件{0}更新成功。", myFileName));
                                    break;
                                }
                                catch (IOException ex2)
                                {
                                    dr = MessageBox.Show(String.Format("出现错误：{0}\r\n如果{1}程序正在运行，请先关闭{1}程序，然后点击[重试]。\r\n如果要停止升级，请点击[终止]。\r\n如果忽略此更新，请点击[忽略]。", ex2.Message, Utils.AppName), "错误提示", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
                                }
                            }
                            if (dr == DialogResult.Ignore)
                            {
                                SetStatus(String.Format("文件{0}的更新被忽略。", myFileName));
                                continue;
                            }
                            if (dr == DialogResult.Abort)
                            {
                                SetStatus("升级已经被停止，升级失败。");
                                SetBtnCancel(true, "关闭");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(String.Format("出现错误：{0}\r\n升级失败，请稍候重试。", ex.Message), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SetBtnCancel(true, "关闭");
                            return;
                        }
                        PerformStep();
                    }
                }

                //更新当前版本号。
                Utils.SetConfig("Version", newVersion, true);
                SetStatus("升级完成。");
                SetBtnCancel(true, "关闭");
                if (MessageBox.Show(String.Format("要启动 {0} 吗？", Utils.AppName), "更新完成", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(Path.Combine(AppFolder, Utils.AppFile));
                    }
                    catch
                    {
                        MessageBox.Show(String.Format("启动程序 {0} 失败。", Utils.AppName));
                    }
                }
            }
            else
            {
                SetStatus("您的程序已经是最新的，不需要升级。");
                SetBtnCancel(true, "关闭");
            }
            DelayExit();
        }

        private void DelayExit()
        {
            SetStatus("五秒后自动关闭该窗口。");
            Thread.Sleep(5000);
            Application.Exit();
        }

        /// <summary>
        /// 解压文件。
        /// </summary>
        /// <param name="zipFileName">要解压的文件路径。</param>
        /// <param name="strBaseDir">解压后文件的基目录。</param>
        private void UnZipFile(String zipFileName, String strBaseDir)
        {
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFileName)))
            {
                ZipEntry theEntry;
                
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(Path.Combine(strBaseDir, directoryName));
                    }

                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(Path.Combine(strBaseDir, theEntry.Name)))
                        {
                            int size;
                            byte[] data = new byte[4096];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
