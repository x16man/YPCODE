using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDde.Client;
using NDde.Advanced;
using Shmzh.Gather.DDE.Test.Properties;
using Shmzh.Gather.Data;
using Shmzh.Gather.Data.Model;
using Shmzh.Components.Util;
using System.Diagnostics;
using NDde;
namespace Shmzh.Gather.DDE.Test
{
    public partial class Form1 : Form
    {
        #region Class
        private class DdeTagInfo
        {
            #region Property
            public string TagId { get; set; }
            public string TagName { get; set; }
            public string Topic { get; set; }
            public string Item { get; set; }
            public string Value { get; set; }
            public int Count { get; set; }
            public DdeClient Client { get; set; }
            public ListViewItem LVItem { get; set; }
            #endregion
        }
        #endregion

        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DdeContext context;
        private System.Diagnostics.Stopwatch stopWatch = new Stopwatch();
        private List<TagInfo> Tags;
        private List<DdeTagInfo> DdeTags = new List<DdeTagInfo>();
        readonly List<DdeClient> ddeClients = new List<DdeClient>();
        private DdeClient client;
        private delegate void ShowValueDelegate(ListViewItem.ListViewSubItem control, string value);
        private ShowValueDelegate ShowValueDelegateInstance;
        private System.Timers.Timer RefreshTimer = new System.Timers.Timer();
        private long adviseCount = 0;
        #endregion

        #region Property
        public string ServiceName
        {
            get { return this.txtAppName.Text; }
        }
        public short Action
        {
            get { return short.Parse(this.txtAction.Text); }
        }
        #endregion

        #region Method

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
                                                              new ColumnHeader(){Text = Resources.ColumnHeader_Value_Text,TextAlign = HorizontalAlignment.Right,DisplayIndex=3,Name="Value",Width = 120,}, 
                                                              new ColumnHeader(){Text = Resources.ColumnHeader_Status_Text, TextAlign = HorizontalAlignment.Left,DisplayIndex = 4,Name="Status",Width=60,}, 
                                                              new ColumnHeader(){Text= Resources.ColumnHeader_Count_Text, TextAlign=HorizontalAlignment.Center,DisplayIndex=5,Name="Count",Width=80}
                                                          });
        }

        private bool LoadAndConnectDDEClient(short action)
        {
            this.Tags = DataRepository.TagProvider.GetByAction(action) as List<TagInfo>;
            foreach(var tag in this.Tags){
                var ddeTag = new DdeTagInfo();
                ddeTag.TagId = tag.TagId;
                ddeTag.TagName = tag.TagName;
                ddeTag.Topic = tag.DesignCD;
                ddeTag.Item = tag.Address;
                ddeTag.Count = 0;
                this.DdeTags.Add(ddeTag);
            }
            var retValue = true;

            foreach (var obj in this.DdeTags)
            {
                var ddeClient = this.ddeClients.Find(item => item.Service == this.ServiceName && item.Topic == obj.Topic);
                if (ddeClient == null)
                {
                    var context = new DdeContext();
                    try
                    {
                        ddeClient = new DdeClient(this.ServiceName, obj.Topic, context);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);

                    }
                    stopWatch.Start();
                    try
                    {
                        ddeClient.Connect();
                        Logger.Info(string.Format("{0}-{1} DdeClient 连接成功！", this.ServiceName, obj.Topic));

                        stopWatch.Stop();
                        
                        this.ddeClients.Add(ddeClient);

                    }
                    catch (Exception ex)
                    {
                        stopWatch.Stop();
                        this.ddeClients.Add(ddeClient);

                        obj.Client = ddeClient;
                        Logger.Info(string.Format("{0}-{1} DdeClient 连接失败！", this.ServiceName, obj.Topic));
                        Logger.Error(ex.Message, ex);
                        retValue = false;
                    }
                    obj.Client = ddeClient;

                    var listViewItem = new ListViewItem(string.Format("{0}-{1}",obj.TagId,obj.TagName)) { Tag = obj };
                    listViewItem.SubItems.Add(obj.Topic);//DDE Topic
                    listViewItem.SubItems.Add(obj.Item);//DDE Item
                    listViewItem.SubItems.Add(string.Empty);// Value
                    listViewItem.SubItems.Add(string.Empty);//Status
                    listViewItem.SubItems.Add(string.Empty);
                    listViewItem.SubItems.Add(obj.Count.ToString());
                    this.listView1.Items.Add(listViewItem);
                    obj.LVItem = listViewItem;
                    try
                    {
                        obj.Client.Advise += new EventHandler<DdeAdviseEventArgs>(Client_Advise);
                        obj.Client.StartAdvise(obj.Item, 1, true,true, 60000,obj);
                        listViewItem.SubItems[4].Text = Resources.MapInfo_Status_Start_Success_Text;
                        obj.Value = obj.Client.Request(obj.Item, 60000);
                    }
                    catch (InvalidOperationException ex)
                    {
                        listViewItem.SubItems[4].Text = Resources.MapInfo_Status_Start_Success_Text;
                        obj.Value = obj.Client.Request(obj.Item, 60000);
                    }
                    catch (DdeException ex)
                    {
                        listViewItem.SubItems[4].Text = Resources.MapInfo_Status_Start_Failed_Text;
                        listViewItem.ForeColor = Color.Red;
                        //Logger.Error(ex.Message, ex);
                    }

                }
                else
                {
                    obj.Client = ddeClient;
                    var listViewItem = new ListViewItem(string.Format("{0}-{1}",obj.TagId,obj.TagName)) { Tag = obj };
                    listViewItem.SubItems.Add(obj.Topic);//DDE Topic
                    listViewItem.SubItems.Add(obj.Item);//DDE Item
                    listViewItem.SubItems.Add(string.Empty);// Value
                    listViewItem.SubItems.Add(string.Empty);//Status
                    listViewItem.SubItems.Add(obj.Count.ToString());
                    this.listView1.Items.Add(listViewItem);
                    obj.LVItem = listViewItem;
                    try
                    {
                        obj.Client.Advise += new EventHandler<DdeAdviseEventArgs>(Client_Advise);
                        obj.Client.StartAdvise(obj.Item, 1, true,true, 60000,obj);
                        listViewItem.SubItems[4].Text = Resources.MapInfo_Status_Start_Success_Text;

                    }
                    catch (InvalidOperationException ex)
                    {
                        listViewItem.SubItems[4].Text = Resources.MapInfo_Status_Start_Success_Text;
                        obj.Value = obj.Client.Request(obj.Item, 60000);
                    }
                    catch (DdeException ex)
                    {
                        listViewItem.SubItems[4].Text = Resources.MapInfo_Status_Start_Failed_Text;
                        listViewItem.ForeColor = Color.Red;
                        //Logger.Error(ex.Message, ex);
                    }
                }
            }
            //this.AdviseCountTimer.Enabled = true;
            return retValue;
        }

        private void ShowValue(ListViewItem.ListViewSubItem control, string value)
        {
            control.Text = value;
        }

        

        #endregion
        public Form1()
        {
            InitializeComponent();
            this.RefreshTimer.Interval = 5000;
            this.RefreshTimer.Elapsed += RefreshTimer_Elapsed;
            context = new DdeContext();
            this.ShowValueDelegateInstance = this.ShowValue;
            this.InitListView1();
        }

        private void Client_Advise(object sender, DdeAdviseEventArgs e)
        {
            this.adviseCount++;
            var ddeClient = sender as DdeClient;
            //if (ddeClient == null)
            //{
            //    Logger.Warn("sender is not a DdeClient");
            //}
            //else
            //{
            //    Logger.Debug(string.Format("Advise:{0}!{1}  Text:{2}   Data:{3}", ddeClient.Topic, e.Item, e.Text, Encoding.ASCII.GetString(e.Data)));
            //}

            var objs = this.DdeTags.FindAll(item => item.Topic == ddeClient.Topic && item.Item == e.Item);
            if (objs.Count > 0)
            {
                foreach (var obj in objs)
                {
                    //Logger.Debug(string.Format("{0}-{1}", obj.TagId, obj.TagName));
                    obj.Value = e.Text;
                    obj.Count = obj.Count + 1;
                }
                
                //try
                //{
                //    this.Invoke(this.ShowValueDelegateInstance, new object[] { obj.LVItem.SubItems[3], obj.Value });
                //}
                //catch (Exception ex)
                //{
                //    Logger.Error(ex.Message);
                //}
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var serviceName = this.txtServiceName.Text;
            var topic = this.txtTopic.Text;
            if (client == null)
            {
                client = new DdeClient(serviceName, topic, context);
            }
            else
            {
                if (client.IsConnected)
                {
                    client.Disconnect();
                    client.Dispose();
                }
                client = new DdeClient(serviceName, topic, context);
            }

            client.Connect();
            client.Advise += ddeClient_Advise;
            client.Disconnected += ddeClient_Disconnected;
        }

        void ddeClient_Disconnected(object sender, DdeDisconnectedEventArgs e)
        {
            MessageBox.Show("DdeClient disconnected!");
        }

        void ddeClient_Advise(object sender, DdeAdviseEventArgs e)
        {
            this.txtResult.Text = e.Text;
        }

        private void btnAdvise_Click(object sender, EventArgs e)
        {
            var item = this.txtItem.Text;
            try
            {
                this.client.StartAdvise(item, int.Parse(this.txtFormat.Text), true, 60000);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        private void btnStopAdvise_Click(object sender, EventArgs e)
        {
            var item = this.txtItem.Text;
            try
            {
                this.client.StopAdvise(item, 60000);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (this.client.IsConnected) this.client.Disconnect();
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            this.LoadAndConnectDDEClient(this.Action);
            this.RefreshTimer.Enabled = true;

        }

        void RefreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Text = this.adviseCount.ToString();
            foreach (var obj in this.DdeTags)
            {
                try
                {
                    this.Invoke(this.ShowValueDelegateInstance, new object[] { obj.LVItem.SubItems[3], obj.Value });
                    this.Invoke(this.ShowValueDelegateInstance, new object[] { obj.LVItem.SubItems[5], obj.Count.ToString() });
                    //obj.LVItem.SubItems[3].Text = obj.Value;
                    //obj.LVItem.SubItems[5].Text = obj.Count.ToString();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
        }
    }
}
