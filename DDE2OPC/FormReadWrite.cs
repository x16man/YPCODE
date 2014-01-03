using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DDE2OPC.DALFactory;
using DDE2OPC.Model;
using DDE2OPC.Properties;
using NDde.Client;
using RsiOPCAuto;
using Timer=System.Timers.Timer;

namespace DDE2OPC
{
    public partial class FormReadWrite : Form
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private System.Diagnostics.Stopwatch stopWatch = new Stopwatch();
        /// <summary>
        /// 采样值显示的控件数组。
        /// </summary>
        private Control[] textBox_Values;
        
        /// <summary>
        /// 映射关系对象集合。
        /// </summary>
        private List<MapInfo> MapObjs;

        /// <summary>
        /// OPC Server的IP地址。
        /// </summary>
        private string OPC_NodeIP;

        /// <summary>
        /// OPC Server的应用程序ID。
        /// </summary>
        private string OPC_ProgID;

        /// <summary>
        /// OPC Group名称。
        /// </summary>
        private string OPC_Group;
        /// <summary>
        /// OPC Server.
        /// </summary>
        private OPCServer[] MyOPCServer;
        
        /// <summary>
        /// OPC Group.
        /// </summary>
        private OPCGroup[] MyOPCGroup;

        private DateTime[] EndTime;
        
        private System.ComponentModel.BackgroundWorker[] OpcWriters;
        /// <summary>
        /// DDE Client 列表。
        /// </summary>
        readonly List<DdeClient> ddeClients = new List<DdeClient>();
        
        /// <summary>
        /// DDE的Service名称。
        /// </summary>
        private string DDEServiceName;

        /// <summary>
        /// 读写的频率。
        /// </summary>
        private int RWInterval;
        /// <summary>
        /// 是否写入OPC。
        /// </summary>
        private bool IsWriteToOPC = false;
        
        /// <summary>
        /// 采集时钟。
        /// </summary>
        private System.Timers.Timer RefreshTimer = new System.Timers.Timer();
        /// <summary>
        /// 写指标数据到OPC的时钟。
        /// </summary>
        private System.Timers.Timer WriteToOPCTimer = new System.Timers.Timer();
        //private System.Timers.Timer AdviseCountTimer = new System.Timers.Timer();
        /// <summary>
        /// 检查DDE连接的时钟.
        /// </summary>
        private System.Timers.Timer CheckTimer = new System.Timers.Timer();
        /// <summary>
        /// 显示采集值。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        private delegate void ShowValueDelegate(ListViewItem.ListViewSubItem control, string value);

        private ShowValueDelegate ShowValueDelegateInstance;

        private long AdviseCount = 0;
        
        #endregion

        #region method
        /// <summary>
        /// 加载并且连接DdeClient。
        /// </summary>
        private bool LoadAndConnectDDEClient()
        {
            this.MapObjs = DataProvider.MapProvider.GetAll() as List<MapInfo>;
            var retValue = true;

            foreach(var obj in this.MapObjs)
            {
                var ddeClient = this.ddeClients.Find(item => item.Service == this.DDEServiceName && item.Topic == obj.DDETopic);
                if(ddeClient == null)
                {
                    ddeClient = new DdeClient(this.DDEServiceName, obj.DDETopic);
                    stopWatch.Start();
                    try
                    {
                        ddeClient.Connect();
                        Logger.Info(string.Format("{0}-{1} DdeClient 连接成功！", this.DDEServiceName, obj.DDETopic));

                        stopWatch.Stop();
                        this.ddeClients.Add(ddeClient);

                    }
                    catch (Exception ex)
                    {
                        stopWatch.Stop();
                        this.ddeClients.Add(ddeClient);
                        
                        obj.Client = ddeClient;
                        Logger.Info(string.Format("{0}-{1} DdeClient 连接失败！",this.DDEServiceName, obj.DDETopic));
                        Logger.Error(ex.Message, ex);
                        retValue = false;
                    }
                    obj.Client = ddeClient;

                    var listViewItem = new ListViewItem(obj.Remark, 0) { Tag = obj };
                    listViewItem.SubItems.Add(obj.DDETopic);//DDE Topic
                    listViewItem.SubItems.Add(obj.DDEItem);//DDE Item
                    listViewItem.SubItems.Add(obj.OPCAddress);//Opc Address
                    listViewItem.SubItems.Add(string.Empty);// Value
                    listViewItem.SubItems.Add(string.Empty);//Status
                    this.listView1.Items.Add(listViewItem);
                    obj.LVItem = listViewItem;
                    try
                    {
                        obj.Client.Advise += new EventHandler<DdeAdviseEventArgs>(Client_Advise);
                        obj.Client.StartAdvise(obj.DDEItem, 1, true, 60000);
                        listViewItem.SubItems[5].Text = Resources.MapInfo_Status_Start_Success_Text;
                    }
                    catch (Exception ex)
                    {
                        listViewItem.SubItems[5].Text = Resources.MapInfo_Status_Start_Failed_Text;
                        Logger.Error(ex.Message, ex);
                    }
                    
                }
                else
                {
                    obj.Client = ddeClient;
                    var listViewItem = new ListViewItem(obj.Remark, 0) { Tag = obj };
                    listViewItem.SubItems.Add(obj.DDETopic);//DDE Topic
                    listViewItem.SubItems.Add(obj.DDEItem);//DDE Item
                    listViewItem.SubItems.Add(obj.OPCAddress);//Opc Address
                    listViewItem.SubItems.Add(string.Empty);// Value
                    listViewItem.SubItems.Add(string.Empty);//Status
                    this.listView1.Items.Add(listViewItem);
                    obj.LVItem = listViewItem;
                    try
                    {
                        obj.Client.Advise += new EventHandler<DdeAdviseEventArgs>(Client_Advise);
                        obj.Client.StartAdvise(obj.DDEItem, 1, true, 60000);
                        listViewItem.SubItems[5].Text = Resources.MapInfo_Status_Start_Success_Text;

                    }
                    catch (Exception ex)
                    {
                        listViewItem.SubItems[5].Text = Resources.MapInfo_Status_Start_Failed_Text;
                        Logger.Error(ex.Message, ex);
                    }
                }
            }
            //this.AdviseCountTimer.Enabled = true;
            return retValue;
        }

        /// <summary>
        /// 加载应用程序的配置信息。
        /// </summary>
        private void LoadConfig()
        {
            this.OPC_NodeIP = ConfigurationManager.AppSettings["NodeIP"];
            this.OPC_ProgID = ConfigurationManager.AppSettings["ProgId"];
            this.OPC_Group = ConfigurationManager.AppSettings["OPCGroup"];
            this.DDEServiceName = ConfigurationManager.AppSettings["DDEServiceName"];
            this.RWInterval = int.Parse(ConfigurationManager.AppSettings["ReadInterval"]);
        }
        /// <summary>
        /// 将采集到的值设置到TextBox上。
        /// </summary>
        /// <param name="control">TextBox控件。</param>
        /// <param name="value">采集值。</param>
        private void ShowValue(ListViewItem.ListViewSubItem control, string value)
        {
            control.Text = value;
        }

        private void InitListView1()
        {
            this.listView1.Dock = DockStyle.Fill;
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Columns.AddRange(new[]
                                                          {
                                                              new ColumnHeader(){Text = Resources.ColumnHeader_Remark_Text,TextAlign = HorizontalAlignment.Center,DisplayIndex = 0,Name ="Icon",Width = 120,},
                                                              new ColumnHeader(){Text = Resources.ColumnHeader_DDE_Topic_Text,TextAlign = HorizontalAlignment.Left,DisplayIndex = 1,Name ="DDETopic",Width = 70,},
                                                              new ColumnHeader(){Text = Resources.ColumnHeader_DDE_Item_Text,TextAlign = HorizontalAlignment.Left,DisplayIndex = 2,Name = "DDEItem",Width = 80,}, 
                                                              new ColumnHeader(){Text = Resources.ColumnHeader_OPC_Address_Text,TextAlign = HorizontalAlignment.Left,DisplayIndex = 3,Name="OPCAddress",Width = 120,}, 
                                                              new ColumnHeader(){Text = Resources.ColumnHeader_Value_Text,TextAlign = HorizontalAlignment.Right,DisplayIndex=4,Name="Value",Width = 120,}, 
                                                              new ColumnHeader(){Text= Resources.ColumnHeader_Status_Text, TextAlign = HorizontalAlignment.Left,DisplayIndex = 5,Name="Status",Width=60,}, 
                                                          });
            var imageList = new ImageList();
            imageList.Images.Add(Resources.tag_blue);
            this.listView1.SmallImageList = imageList;
        }
        #endregion

        public FormReadWrite()
        {
            InitializeComponent();

            this.Icon = Resources.bridge;
            

            this.notifyIcon1.Visible = false;
            this.notifyIcon1.Icon = Resources.bridge;

            
            this.ShowValueDelegateInstance = this.ShowValue;
            this.LoadConfig();

            this.RefreshTimer.Interval = int.Parse(ConfigurationManager.AppSettings["ReadInterval"]);
            this.RefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(RefreshTimer_Elapsed);

            this.WriteToOPCTimer.Interval = int.Parse(ConfigurationManager.AppSettings["WriteInterval"]);
            this.WriteToOPCTimer.Elapsed += new System.Timers.ElapsedEventHandler(WriteToOPCTimer_Elapsed);

            this.notifyIcon1.BalloonTipTitle = "DDE2OPC";
            this.notifyIcon1.BalloonTipText = "DDE2OPC 正在此运行！";
            this.notifyIcon1.Text = string.Format("{0}->[{1}] {2}", this.DDEServiceName, this.OPC_NodeIP, this.OPC_ProgID);
            this.notifyIcon1.DoubleClick += new EventHandler(notifyIcon1_DoubleClick);


        }

        void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.notifyIcon1.Visible = false;
        }

        void RefreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (var obj in this.MapObjs)
            {
                try
                {
                    this.Invoke(this.ShowValueDelegateInstance, new object[] { obj.LVItem.SubItems[4], obj.CurrentValue.ToString() });
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
        }
        /// <summary>
        /// 写指标数据到OPC的时钟事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WriteToOPCTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime maxEndTime = DateTime.MinValue;
            if(this.EndTime[0] != DateTime.MinValue)
            {
                for(var i=0;i<this.EndTime.Length;i++)
                {
                    if(this.EndTime[i] > maxEndTime)
                    {
                        maxEndTime = this.EndTime[i];
                        this.EndTime[i] = DateTime.MinValue;
                    }
                }
                Logger.Debug(maxEndTime.ToLongTimeString());
            }
            Logger.Debug("Begin Run Worker.");
            for (var i = 0; i < this.MapObjs.Count;i++ )
            {
                if (!string.IsNullOrEmpty(this.MapObjs[i].OPCAddress))
                {
                    //this.MyOPCGroup[i].OPCItems.Item(this.MapObjs[i].OPCAddress).Write(this.MapObjs[i].CurrentValue);
                    if(!this.OpcWriters[i].IsBusy)
                    {
                        this.OpcWriters[i].RunWorkerAsync(i);
                        //Logger.Info(string.Format("[{0}] run work",this.MapObjs[i].OPCAddress));
                    }
                }
            }
            Logger.Debug("End Run Worker");
            //Logger.Info(string.Format("Writer OPC Loop spend {0} ms",sw.ElapsedMilliseconds));
        }

        private void FormReadWrite_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("DDE2OPC - {0}->[{1}]{2} ", this.DDEServiceName, this.OPC_NodeIP, this.OPC_ProgID);

            this.InitListView1();

            this.CheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(CheckTimer_Elapsed);
            this.CheckTimer.Interval = 60000;//一分钟检查一次.
        }
        /// <summary>
        /// 检查ddeClient连接的时钟事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.ddeClients.Count > 0)
            {
                foreach (var client in this.ddeClients)
                {
                    if (!client.IsConnected)//当检查到ddeClient当前不在连接,则重新连接并且订阅该ddeClient下的Item.
                    {
                        try
                        {
                            client.Connect();
                            Logger.Info(string.Format("{0}-{1} DdeClient 连接成功！", this.DDEServiceName, client.Topic));
                            var items = this.MapObjs.FindAll(item => item.Client == client);
                            for (var i = 0; i < items.Count; i++)
                            {
                                try
                                {
                                    client.StartAdvise(items[i].DDEItem, 1, true, 60000);//重新开始订阅.
                                }
                                catch (Exception ex)
                                {
                                    Logger.Error(ex.Message, ex);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Info(string.Format("CheckTimer {0}-{1} DdeClient 连接失败！", this.DDEServiceName, client.Topic));
                            Logger.Error(ex.Message, ex);
                        }
                    }
                    else
                    {
                        Logger.Info(string.Format("{0}.{1} is Connected!",client.Service,client.Topic));
                    }
                }
            }
        }
        /// <summary>
        /// 连接到DDE Server的按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ConnectToDDE_Click(object sender, EventArgs e)
        {
            if(this.LoadAndConnectDDEClient())
            {
                this.button_ConnectToDDE.Enabled = false;
                this.button_ConnectToDDE.Image = Resources.link;
                this.button_Refresh.Enabled = true;

                //启动检查ddeClient连接状态的时钟.
                this.CheckTimer.Enabled = true;
            }
            else
            {
                this.button_ConnectToDDE.Image = Resources.link_error;
                this.button_Refresh.Enabled = false;
            }
        }
        /// <summary>
        /// 连接到OPC Server按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>一个指标一个OPC连接。</remarks>
        private void button_ConnectToOPCServer_Click(object sender, EventArgs e)
        {
            this.MyOPCServer = new OPCServer[this.MapObjs.Count];
            this.MyOPCGroup = new OPCGroup[this.MapObjs.Count];
            this.OpcWriters = new BackgroundWorker[this.MapObjs.Count];
            this.EndTime = new DateTime[this.MapObjs.Count];

            var IsConnected = true;
            for (var i = 0; i < this.MyOPCServer.Length;i++ )
            {
                this.MyOPCServer[i] = new OPCServer();
                try
                {
                    this.MyOPCServer[i].Connect( this.OPC_ProgID,this.OPC_NodeIP);
                    this.MyOPCGroup[i] = this.MyOPCServer[i].OPCGroups.Add(this.OPC_Group);
                    this.MyOPCGroup[i].IsActive = true;
                    //this.MyOPCGroup[i].IsSubscribed = true;
                    if(!string.IsNullOrEmpty(this.MapObjs[i].OPCAddress))
                        this.MyOPCGroup[i].OPCItems.AddItem(this.MapObjs[i].OPCAddress, 1);
                    
                }
                catch (Exception ex)
                {
                    IsConnected = false;
                    Logger.Error(ex.Message,ex);
                }
                this.OpcWriters[i] = new BackgroundWorker();
                this.OpcWriters[i].DoWork+=new DoWorkEventHandler(OpcWrite_DoWork);
                //this.OpcWriters[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(OpcWrite_RunWorkerCompleted);
            }
            if(IsConnected)
            {
                this.button_ConnectToOPCServer.Enabled = false;
                this.button_ConnectToOPCServer.Image = Resources.link;
                this.button_WriteToOPC.Enabled = true;
            }
            else
            {
                this.button_ConnectToOPCServer.Image = Resources.link_error;
                this.button_WriteToOPC.Enabled = false;
            }
        }

        private void OpcWrite_DoWork(object sender, DoWorkEventArgs e)
        {
            //var sw = new Stopwatch();
            //sw.Start();
            int i = 0;
            try
            {
                i = (int) e.Argument;
                this.MyOPCGroup[i].OPCItems.Item(this.MapObjs[i].OPCAddress).Write(this.MapObjs[i].CurrentValue);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            //sw.Stop();
            //Logger.Info(string.Format("Write to OPC[{0}] @ {1} ",this.MapObjs[i].OPCAddress,DateTime.Now));
            this.EndTime[i] = DateTime.Now;
        }

        //void OpcWrite_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
            
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 开始读取并且写入按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            if(this.RefreshTimer.Enabled == false)
            {
                this.RefreshTimer.Enabled = true;
                this.button_Refresh.Image = Resources.control_stop;
                this.button_Refresh.Text = "&P. 停止刷新";                
            }
            else
            {
                this.RefreshTimer.Enabled = false;
                this.button_Refresh.Image = Resources.control_play;
                this.button_Refresh.Text = "&R. 开始刷新";                
            }
        }

        private void button_WriterToOPC_Click(object sender, EventArgs e)
        {
            if(this.WriteToOPCTimer.Enabled == false)
            {
                this.WriteToOPCTimer.Enabled = true;
                this.button_WriteToOPC.Image = Resources.control_stop;
                this.button_WriteToOPC.Text = "&T. 停止写入";
            }
            else
            {
                this.WriteToOPCTimer.Enabled = false;
                this.button_WriteToOPC.Image = Resources.control_play;
                this.button_WriteToOPC.Text = "&W. 开始写入";
            }
        }

        private void FormReadWrite_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RefreshTimer.Enabled = false;
            //this.AdviseCountTimer.Enabled = false;
            this.WriteToOPCTimer.Enabled = false;
            
            if(this.MyOPCServer != null)
            {
                for (var i = 0; i < this.MyOPCServer.Length; i++)
                {
                    try
                    {
                        this.MyOPCServer[i].Disconnect();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            
            if(this.MapObjs != null && this.MapObjs.Count > 0)
            {
                foreach (var mapObj in this.MapObjs)
                {
                    if (mapObj.Client != null)
                    {
                        var sw = new Stopwatch();
                        sw.Start();
                        try
                        {
                            mapObj.Client.StopAdvise(mapObj.DDEItem, 5000);
                            mapObj.Client.Advise -= new EventHandler<DdeAdviseEventArgs>(Client_Advise);  
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex.Message);

                        }
                        sw.Stop();
                        Logger.Info(string.Format("Stop Advise spend {0} ms", sw.ElapsedMilliseconds));
                    }
                }
            }
            

            foreach(var obj in this.ddeClients)
            {
                if(obj.IsConnected)
                    obj.Disconnect();
            }
        }

        private void toolStripButton_MapConfig_Click(object sender, EventArgs e)
        {
            new FormMap().Show();
        }

        /// <summary>
        /// DDE Client 触发Advise事件。
        /// </summary>
        /// <param name="sender">应该是DdeClient对象。</param>
        /// <param name="e">DdeAdviseEventArgs对象。</param>
        void Client_Advise(object sender, DdeAdviseEventArgs e)
        {
            //this.AdviseCount++;
            var ddeClient = sender as DdeClient;

            var obj = this.MapObjs.Find(item => item.DDETopic == ddeClient.Topic && item.DDEItem == e.Item);
            if(obj != null)
            {
                obj.CurrentValue = double.Parse(e.Text, NumberStyles.Float);
                //if (this.IsWriteToOPC && !string.IsNullOrEmpty(obj.OPCAddress))
                //{
                //    try
                //    {
                //        //var sw9 = new Stopwatch();
                //        //sw9.Start();
                //        this.MyOPCGroup.OPCItems.Item(obj.OPCAddress).Write(e.Text);
                //        //sw9.Stop();
                //        //Logger.Info(string.Format("write spends {0} ms,{1}",sw9.ElapsedMilliseconds, mapInfo.OPCAddress));
                //    }
                //    catch (Exception ex)
                //    {
                //        Logger.Error(ex.Message, ex);
                //    }
                //}
            }
               
       }

        private void FormReadWrite_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(5);
            }
        }

        private void FormReadWrite_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
    }
}
