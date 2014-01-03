using System;
using System.Drawing.Imaging;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using NDde.Client;
using Shmzh.Gather.Data;
using System.Configuration;
using System.Diagnostics;
using Shmzh.Gather.Data.Model;
using System.Timers;
using Timer=System.Timers.Timer;
using Shmzh.Gather.DDE.Properties;
using System.Messaging;
using System.Drawing.IconLib;
using System.Management;

namespace Shmzh.Gather.DDE
{
    public partial class FormDDEGather : Form
    {
        #region Const
        private const int Removable = 2;
        private const int LocalDisk = 3;
        private const int Network = 4;
        private const int CD = 5;
        private const int RamDisk = 6;
        #endregion

        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly List<DdeClient> ddeClients = new List<DdeClient>();
        private string ServiceName;
        private List<TagInfo> Objs;
        private short Action;
        private Timer AdjustTimer;
        private Timer TagTimer;
        private Timer ConnectionTimer;
        //private Timer RequestTimer;
        private long ErrorCount;
        private bool InitMessageQueueResult = false;
        private delegate void ShowValueDelegate(string value);

        //private readonly ShowValueDelegate ShowValueDelegateInstance;
        private readonly ShowValueDelegate ShowRequestTimeDelegateInstance;
        private readonly ShowValueDelegate ShowErrorCountDelegateInstance;
        private readonly ShowValueDelegate ShowStatusDelegateInstance;
        private readonly ShowValueDelegate ShowInfoDelegateInstance;
        private readonly ShowValueDelegate ShowWarningDelegateInstance;
        private readonly ShowValueDelegate ShowErrorDelegateInstance;
        private readonly ShowValueDelegate ShowConnectionStatusDelegateInstance;

        private string lastFileName;
        private string lastTableName;
        private MessageQueue msgQueue;
        private string queueName;
        private bool isFirst = true;
        private bool isBusy = false;
        private bool isClosing = false;
        private bool isPaused = false;
        private bool isShowRequstTime = false;
        private bool isAutoScroll = false;
        private FileStream fs;
        private StreamWriter sw;
        private int currentWriter;
        private int fileWriter;
        private string workPath;
        private int readInterval;
        private int writeInterval;
        /// <summary>
        /// 检查连接的时间间隔。
        /// </summary>
        private int connectionCheckInterval;
        /// <summary>
        /// 目前尝试连接的次数。
        /// </summary>
        private int tryConnectCount;
        /// <summary>
        /// 尝试连接的最大次数。
        /// </summary>
        private int tryConnectMaxCount;
        /// <summary>
        /// 发出警告的时间间隔。
        /// </summary>
        private int alertInterval;
        /// <summary>
        /// 警告的最大次数。
        /// </summary>
        private int alertMaxCount;

        //private System.Diagnostics.Process Proc;
        private System.Diagnostics.ProcessStartInfo viewProcess;

        #endregion

        #region Property
        /// <summary>
        /// 数据文件存放路径，写入时只要传入一个总路径名就可以了。
        /// 读取时会读出总路径名，加上当天的日期。总路径缺省是D:\PCDDEDates。
        /// </summary>
        public string WorkPath
        {
            get
            {
                var myPath = string.Format(@"{0}\{1}", workPath, DateTime.Today.ToString("yyyyMMdd"));
                if(!Directory.Exists(myPath))
                {
                    Directory.CreateDirectory(myPath);
                }
                return myPath;
            }
            set
            {
                if(Directory.Exists(value))
                {
                    workPath = value;
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(value);
                    }
                    catch (Exception)
                    {
                        value = @"D:\PCDDEDatas";
                        if (!Directory.Exists(value))
                            Directory.CreateDirectory(value);
                    }
                    finally
                    {
                        workPath = value;
                    }
                }
            }
        }

        /// <summary>
        /// 写文件时间间隔，间隔必须是10的整数倍，必须小于60秒，否则作为30秒写一次处理
        /// </summary>
        public int WriteInterval
        {
            get { return writeInterval; }
            set
            {
                if(value%10!=0 || value < 0 || value >= 60 )
                {
                    value = 30;
                }
                writeInterval = value;
                currentWriter = value;
            }
        }
        /// <summary>
        /// 读指标时间间隔，间隔必须是1000毫秒的整数倍，
        /// 即是整数秒，同时必须小于30秒，否则作为10秒处理
        /// </summary>
        public int ReadInterval
        {
            get { return readInterval; }
            set
            {
                if(value % 1000 != 0 || value >= 30000 || value <5)
                {
                    value = 10000;
                }
                readInterval = value;
            }
        }
        #endregion

        #region private method
        private void ShowStatus(string status)
        {
            this.toolStripStatusLabel1.Visible = true;
            this.toolStripStatusLabel_Status.Text = status;
            this.statusBarPanel_Status.Text = status;
        }
        /// <summary>
        /// 显示采集值。
        /// </summary>
        /// <param name="value"></param>
        //private void ShowValue(string value)
        //{
        //    this.textBox1.Text = value;
        //}
        /// <summary>
        /// 显示Timer的秒数。
        /// </summary>
        /// <param name="requestTime"></param>
        private void ShowTime(string requestTime)
        {
            
        }
        /// <summary>
        /// 显示错误计数。
        /// </summary>
        /// <param name="value"></param>
        private void ShowErrorCount(string value)
        {
            this.toolStripStatusLabel_ErrorCount.Text = value;
            this.statusBarPanel_ErrorCount.Text = value;
        }
        /// <summary>
        /// 显示轮询一次耗时。
        /// </summary>
        /// <param name="value"></param>
        private void ShowRequestTime(string requestTime)
        {
            this.toolStripStatusLabel2.Visible  = true;
            this.toolStripStatusLabel_RequestTime.Text = requestTime;
            this.statusBarPanel_RequestTime.Text = requestTime;
        }
        /// <summary>
        /// 显示DDE的连接状态。
        /// </summary>
        /// <param name="value"></param>
        private void ShowConnectionStatus(string value)
        {
            this.statusBarPanel_ConnectionStatus.Text = value;
        }
        /// <summary>
        /// 初始化UI界面。
        /// </summary>
        private void InitUI()
        {
            this.Text = Resources.FormDDEGather_Text;
            this.tabPageGather.Text = Resources.tabPage_Gather_Text;
            this.tabPageDataFile.Text = Resources.tabPage_DataFile_Text;
            this.tabPageConfig.Text = Resources.tabPage_Config_Text;
            this.groupBoxConnectionString.Text = Resources.groupBoxConnectionString_Text;
            this.labelDataFile.Text = Resources.labelDataFile_Text;
            this.labelQueueName.Text = Resources.labelQueueName_Text;
            this.labelAction.Text = Resources.labelAction_Text;
            this.labelLinkTopic.Text = Resources.labelLinkTopic_Text;
            this.labelReadInterval.Text = Resources.labelReadInterval_Text;
            this.labelMilliSecond.Text = Resources.labelMilliSecond_Text;
            this.labelWriteInterval.Text = Resources.labelWriteInterval_Text;
            this.labelSecond.Text = Resources.labelSecond_Text;
            this.labelConnectInterval.Text = Resources.labelConnectionInterval_Text;
            this.labelConnectionCheckUnit.Text = Resources.labelConnectionIntervalUnit_Text;
            this.labelTryConnectionTimes.Text = Resources.labelTryConnectionTimes_Text;
            this.labelAlertInterval.Text = Resources.labelAlertInterval_Text;
            this.labelAlertIntervalUnit.Text = Resources.labelAlertIntervalUnit_Text;
            this.labelAlertMaxCount.Text = Resources.labelAlertMaxCount_Text;

            
            this.btnYes.Text = Resources.btnYes_Text;
            this.btnCancel.Text = Resources.btnCancel_Text;

            //初始化TabControl的ImageList。
            //this.InitImageList4Tab();

            
            //初始化EventLog的ListView。
            this.InitListViewEventLog();

            //初始化DataFile的ListView。
            this.InitListView_DataFile();

        }
       
        /// <summary>
        /// 初始化EventLog的ListView的列和布局。
        /// </summary>
        private void InitListViewEventLog()
        {
            this.listViewEventLogger.Dock = DockStyle.Fill;
            this.listViewEventLogger.View = View.Details;
            this.listViewEventLogger.FullRowSelect = true;
            this.listViewEventLogger.Columns.AddRange(new[]
                                                          {
                                                              new ColumnHeader(){Text ="！",TextAlign = HorizontalAlignment.Center,DisplayIndex = 0,Name ="Icon",Width = 24,},
                                                              new ColumnHeader(){Text ="说明",TextAlign = HorizontalAlignment.Left,DisplayIndex = 1,Name ="Content",Width = 600,},
                                                              new ColumnHeader(){Text ="时间",TextAlign = HorizontalAlignment.Center,DisplayIndex = 2,Name = "DateTime",Width = 120,}, 
                                                          });
            var imageList = new ImageList();
            imageList.Images.Add((System.Drawing.Image)Resources.exclamation);
            imageList.Images.Add((System.Drawing.Image)Resources.error);
            imageList.Images.Add((System.Drawing.Image)Resources.information);
            this.listViewEventLogger.SmallImageList = imageList;
            
        }
        /// <summary>
        /// 初始化文本文件的ListView。
        /// </summary>
        private void InitListView_DataFile()
        {
            //this.webBrowser1.Dock = DockStyle.Fill;
            
            this.listView_DataFile.Dock = DockStyle.Fill;
            this.listView_DataFile.ContextMenuStrip = this.contextMenuStrip2;
            this.listView_DataFile.View = View.Details;
            this.listView_DataFile.Columns.AddRange(new[]
                                                        {
                                                            new ColumnHeader(){Text="名称",TextAlign = HorizontalAlignment.Left,DisplayIndex = 0,Name="Name",Width = 100,},
                                                            new ColumnHeader(){Text = "大小",TextAlign =HorizontalAlignment.Right,DisplayIndex=1,Name="Size",Width=120,},
                                                            new ColumnHeader(){Text = "类型",TextAlign =HorizontalAlignment.Left,DisplayIndex=2,Name="Type",Width=100,},
                                                            new ColumnHeader(){Text = "修改日期",TextAlign =HorizontalAlignment.Left,DisplayIndex=3,Name="UpdateTime",Width = 120}, 
                                                            new ColumnHeader(){Text="包含对象",TextAlign=HorizontalAlignment.Left,DisplayIndex=4,Name="IncludeObject",Width=120}, 
                                                   });
            var smallImageList = new ImageList {ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(16, 16), TransparentColor = Color.Transparent};

            var largeImageList = new ImageList {ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(32, 32), TransparentColor = Color.Transparent};

            //var folderIcon = new Icon(Path.Combine(Application.StartupPath, "Resources/icon/folder.ico"));
            //var textIcon = new Icon(Path.Combine(Application.StartupPath, "Resources/icon/textdoc.ico"));

            //smallImageList.Images.Add(textIcon);
            //smallImageList.Images.Add(folderIcon);
            //largeImageList.Images.Add(textIcon);
            //largeImageList.Images.Add(folderIcon);

            var textIcon = new SingleIcon("textDoc");
            textIcon.Load(Path.Combine(Application.StartupPath, "Resources/icon/textdoc.ico"));
            foreach (IconImage iconImage in textIcon)
            {
                //find the 16x16 32 colordepth's bmp.
                if (iconImage.Size.Width == 16 && iconImage.Size.Width == 16 && iconImage.PixelFormat == PixelFormat.Format32bppArgb)
                {
                    smallImageList.Images.Add(iconImage.Icon);
                }
                else if (iconImage.Size.Width == 32 && iconImage.Size.Width == 32 && iconImage.PixelFormat == PixelFormat.Format32bppArgb)
                {
                    largeImageList.Images.Add(iconImage.Icon);
                }
            }

            var folderIcon = new SingleIcon("folder");
            folderIcon.Load(Path.Combine(Application.StartupPath, "Resources/icon/folder.ico"));
            foreach (IconImage iconImage in folderIcon)
            {
                //find the 16x16 32 colordepth's bmp.
                if (iconImage.Size.Width == 16 && iconImage.Size.Width == 16 && iconImage.PixelFormat == PixelFormat.Format32bppArgb)
                {
                    smallImageList.Images.Add(iconImage.Icon);
                }
                else if (iconImage.Size.Width == 32 && iconImage.Size.Width == 32 && iconImage.PixelFormat == PixelFormat.Format32bppArgb)
                {
                    largeImageList.Images.Add(iconImage.Icon);
                }
            }
            
            this.listView_DataFile.SmallImageList = smallImageList;
            this.listView_DataFile.LargeImageList = largeImageList;

            
        }
        /// <summary>
        /// 加载配置信息。
        /// </summary>
        private void LoadConfig()
        {
            this.txtConnectionString.Text = ConfigurationManager.ConnectionStrings["Shmzh.Gather.Data.ConnectionString"].ConnectionString;
            this.WorkPath = this.txtDataFile.Text = ConfigurationManager.AppSettings["DataFile"];
            this.queueName = this.txtQueueName.Text = ConfigurationManager.AppSettings["QueueName"];
            this.ServiceName = this.txtLinkTopic.Text = ConfigurationManager.AppSettings["LinkTopic"];
            this.txtAction.Text = ConfigurationManager.AppSettings["Action"];
            this.Action = short.Parse(this.txtAction.Text);
            this.txtReadInterval.Text = ConfigurationManager.AppSettings["ReadInterval"];
            this.ReadInterval = int.Parse(this.txtReadInterval.Text);
            this.txtWriteInterval.Text = ConfigurationManager.AppSettings["WriteInterval"];
            this.WriteInterval = int.Parse(this.txtWriteInterval.Text);

            this.txtConnectionInterval.Text = ConfigurationManager.AppSettings["ConnnectionCheckInterval"];
            this.connectionCheckInterval = int.Parse(this.txtConnectionInterval.Text);
            this.txtTryConnectionTimes.Text = ConfigurationManager.AppSettings["TryConnectionTimes"];
            this.tryConnectMaxCount = int.Parse(this.txtTryConnectionTimes.Text);
            this.txtAlertInterval.Text = ConfigurationManager.AppSettings["AlertInterval"];
            this.alertInterval = int.Parse(this.txtAlertInterval.Text);
            this.txtAlertMaxCount.Text = ConfigurationManager.AppSettings["AlertMaxCount"];
            this.alertMaxCount = int.Parse(this.txtAlertMaxCount.Text);
        }
        /// <summary>
        /// 初始化消息队列。
        /// </summary>
        private void InitMessageQueue()
        {
            if(!MessageQueue.Exists(this.queueName))
            {
                MessageQueue.Create(queueName);
            }
            msgQueue = new MessageQueue(queueName) {Formatter = new System.Messaging.XmlMessageFormatter(new[] {"System.String"})};
        }
        
        /// <summary>
        /// 发送消息队列。
        /// </summary>
        /// <param name="tableName">表名。</param>
        /// <param name="fileName">文件名。</param>
        private void SendMessageQueue(string tableName,string fileName)
        {
            msgQueue.Send(new System.Messaging.Message {Formatter = new ActiveXMessageFormatter(), Body = tableName, Label = fileName});
        }

        /// <summary>
        /// 在EventLog中增加日志信息。
        /// </summary>
        /// <param name="info"></param>
        private void AddInfo(string info)
        {
            AddContent(2,info);
        }
        private void AddWarning(string warning)
        {
            AddContent(1,warning);
        }
        private void AddError(string error)
        {
            AddContent(0,error);
        }
        private void AddContent(int imageIndex,string content)
        {
            var obj = new ListViewItem(string.Empty, imageIndex);
            obj.SubItems.Add(content);
            obj.SubItems.Add(DateTime.Now.ToString());

            this.listViewEventLogger.Items.Add(obj);
            if(this.listViewEventLogger.Items.Count >100)
            {
                this.listViewEventLogger.Items.RemoveAt(0);
            }
            if (this.isAutoScroll)
                this.listViewEventLogger.Items[this.listViewEventLogger.Items.Count - 1].EnsureVisible();

        }

        protected ManagementObjectCollection getDrives()
        {
            //get drive collection
            var query = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
            var queryCollection = query.Get();

            return queryCollection;
        }

        #endregion

        #region CTOR
        public FormDDEGather()
        {
            InitializeComponent();

            this.viewProcess = new ProcessStartInfo("notepad.exe");


            this.notifyIcon1.Visible = false;
            this.Icon = Resources.Normal;
            this.toolStripStatusLabel1.Visible = false;
            this.toolStripStatusLabel2.Visible = false;

            //this.ShowValueDelegateInstance = this.ShowValue;
            this.ShowRequestTimeDelegateInstance = this.ShowRequestTime;
            this.ShowErrorCountDelegateInstance = this.ShowErrorCount;
            this.ShowStatusDelegateInstance = this.ShowStatus;
            this.ShowInfoDelegateInstance = this.AddInfo;
            this.ShowWarningDelegateInstance = this.AddWarning;
            this.ShowErrorDelegateInstance = this.AddError;
            this.ShowConnectionStatusDelegateInstance = this.ShowConnectionStatus;

            this.notifyIcon1.Icon = Resources.Normal;

            this.notifyIcon1.BalloonTipTitle = "DDE采集程序";
            this.notifyIcon1.BalloonTipText = "DDE采集程序正在此运行";
            this.notifyIcon1.Text = string.Format("当前采集的DDE数据源为{0}", ConfigurationManager.AppSettings["LinkTopic"]);
            this.notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;

            this.InitUI(); //初始化用户界面。

            this.LoadConfig();

            //当服务器采用用户自动登录模式时，应用程序启动在消息队列服务启动之前，会发生异常。所以，进行多次尝试。
            while (this.InitMessageQueueResult == false)
            {
                try
                {
                    this.InitMessageQueue(); //初始化消息队列。
                    this.InitMessageQueueResult = true;

                    this.ShowInfoDelegateInstance("消息队列初始化成功！");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                    
                    this.ShowErrorDelegateInstance(ex.Message);
                    Thread.Sleep(5000);//初始化消息队列发生异常后，线程挂起5秒后，再重新尝试初始化。
                }
            }

            this.currentWriter = -1;
            this.fileWriter = -this.WriteInterval - 1;
        }
        
        public FormDDEGather(int delay):this()
        {
            if(delay > 0)
            {
                Thread.Sleep(delay*1000);

                this.ToolStripMenuItem_Start.PerformClick();
            }
        }
        #endregion

    }
}
