using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using NDde.Client;
using Shmzh.Gather.Data;
using Shmzh.Gather.Data.Model;
using NDde.Advanced;

namespace Shmzh.Gather.DDE
{
    public partial class FormDDEGather
    {
        /// <summary>
        /// 窗体加载事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDDEGather_Load(object sender, EventArgs e)
        {
            //this.backgroundWorker_Start.RunWorkerAsync();
        }
        /// <summary>
        /// 窗体尺寸变化事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDDEGather_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(5);
            }
        }
        /// <summary>
        /// 窗体关闭事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDDEGather_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.isClosing = true;

                if (!this.isBusy)//如果采集动作不在忙，则可以进行关闭动作，否则等待该次采集动作完成才关闭。
                {
                    foreach (var ddeClient in this.ddeClients)
                    {
                        if (ddeClient.IsConnected)
                        {
                            ddeClient.Disconnect();

                            this.AddInfo(string.Format("{0}|{1} dde 连接关闭！", ddeClient.Service, ddeClient.Topic));
                            Logger.Info(string.Format("{0}|{1} dde 连接关闭！", ddeClient.Service, ddeClient.Topic));
                            ddeClient.Dispose();
                        }
                    }
                    if (this.AdjustTimer != null)
                    {

                        this.AdjustTimer.Stop();
                        this.AdjustTimer.Dispose();
                        Logger.Info("销毁AdjustTimer");
                    }
                    if (this.TagTimer != null)
                    {
                        this.TagTimer.Stop();
                        this.TagTimer.Dispose();
                        Logger.Info("销毁TagTimer");
                    }
                }
                else//如果采集动作现在正在忙，则生成一个时钟，每秒中判断一次，采集动作有没有结束，结束则关闭。
                {
                    var closerTimer = new System.Timers.Timer { Interval = 1000 };
                    closerTimer.Elapsed += closerTimer_Elapsed;
                    closerTimer.Enabled = true;
                    this.AddInfo("启动关闭时钟！");
                }

            }
            else
            {
                e.Cancel = true;
            }

        }
        /// <summary>
        /// Tab control selectedIndexChanged event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)//数据文件
            {
                if (this.listView_DataFile.Items.Count == 0)
                {
                    var parent = new DirectoryInfo(this.txtDataFile.Text);
                    this.listView_DataFile.Tag = parent;
                    var folders = parent.GetDirectories();
                    foreach (var folder in folders)
                    {
                        if ((folder.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
                        {
                            var obj = new ListViewItem(folder.Name, 1) { Tag = folder };
                            obj.SubItems.AddRange(new[] { "", "文件夹", folder.LastWriteTime.ToString(), folder.GetFiles().Length.ToString() });
                            this.listView_DataFile.Items.Add(obj);
                        }

                    }
                }
                else
                {
                    //显示当前内容。
                }
            }
        }
        /// <summary>
        /// notifyIcon的鼠标双击事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.notifyIcon1.Visible = false;
        }
        
        #region Data File
        /// <summary>
        /// 数据文件Tab页的右键菜单的图标菜单项的点击事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.listView_DataFile.View = View.LargeIcon;

        }
        /// <summary>
        /// 数据文件Tab页的右键菜单的详细信息的点击事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.listView_DataFile.View = View.Details;
        }
        /// <summary>
        /// 数据文件ListView控件的鼠标双击事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DataFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = this.listView_DataFile.GetItemAt(e.X, e.Y);

            if (item.ImageIndex == 1)//目录
            {
                this.listView_DataFile.Items.Clear();
                if (item.Tag is DirectoryInfo)
                {
                    var folder = item.Tag as DirectoryInfo;
                    var files = folder.GetFiles();
                    foreach (var file in files)
                    {
                        var obj = new ListViewItem(file.Name, 0) { Tag = file };
                        obj.SubItems.AddRange(new[] { string.Format("{0} kb", Math.Round(file.Length / 1024d, 2)), "文本文件", file.LastWriteTime.ToString(), "" });
                        this.listView_DataFile.Items.Add(obj);
                    }
                    this.listView_DataFile.Tag = folder;
                }
            }
            else if (item.ImageIndex == 0 && item.Tag is FileInfo)
            {
                System.Diagnostics.Process.Start((item.Tag as FileInfo).FullName);
            }
        }
        /// <summary>
        /// 数据文件ListView控件的键盘KeyDown事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DataFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)//刷新。
            {
                var parent = this.listView_DataFile.Tag as DirectoryInfo;
                if (parent != null)
                {
                    this.listView_DataFile.Items.Clear();
                    this.listView_DataFile.Tag = parent;
                    var folders = parent.GetDirectories();
                    foreach (var folder in folders)
                    {
                        if ((folder.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
                        {
                            var obj = new ListViewItem(folder.Name, 1) { Tag = folder };
                            obj.SubItems.AddRange(new[] { "", "文件夹", folder.LastWriteTime.ToString(), folder.GetFiles().Length.ToString() });
                            this.listView_DataFile.Items.Add(obj);
                        }
                    }
                    var files = parent.GetFiles();
                    foreach (var file in files)
                    {
                        if ((file.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
                        {
                            var obj = new ListViewItem(file.Name, 0) { Tag = file };
                            obj.SubItems.AddRange(new[] { string.Format("{0} kb", Math.Round(file.Length / 1024d, 2)), "文本文件", file.LastWriteTime.ToString(), "" });
                            this.listView_DataFile.Items.Add(obj);
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Back)
            {
                if (this.listView_DataFile.Tag is DirectoryInfo)
                {
                    var parent = (this.listView_DataFile.Tag as DirectoryInfo).Parent;
                    if (parent == null)
                    {
                        Process.Start("::{20D04FE0-3AEA-1069-A2D8-08002B30309D}");
                        return;
                    }
                    else
                    {
                        this.listView_DataFile.Items.Clear();
                        this.listView_DataFile.Tag = parent;
                        var folders = parent.GetDirectories();
                        foreach (var folder in folders)
                        {
                            if ((folder.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
                            {
                                var obj = new ListViewItem(folder.Name, 1) { Tag = folder };
                                obj.SubItems.AddRange(new[] { "", "文件夹", folder.LastWriteTime.ToString(), folder.GetFiles().Length.ToString() });
                                this.listView_DataFile.Items.Add(obj);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Config Tab
        /// <summary>
        /// 配置信息取消按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.LoadConfig();
        }
        /// <summary>
        /// 配置信息确定按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            Shmzh.Components.Util.Configuration.UpdateConnectionStringsConfig("Shmzh.Gather.Data.ConnectionString", this.txtConnectionString.Text.Trim(), string.Empty);

            Shmzh.Components.Util.Configuration.UpdateAppConfig("DataFile", this.txtDataFile.Text.Trim());

            Shmzh.Components.Util.Configuration.UpdateAppConfig("QueueName", this.txtQueueName.Text.Trim());

            Shmzh.Components.Util.Configuration.UpdateAppConfig("Action", this.txtAction.Text.Trim());

            Shmzh.Components.Util.Configuration.UpdateAppConfig("LinkTopic", this.txtLinkTopic.Text.Trim());

            Shmzh.Components.Util.Configuration.UpdateAppConfig("ReadInterval", this.txtReadInterval.Text.Trim());

            Shmzh.Components.Util.Configuration.UpdateAppConfig("WriteInterval", this.txtWriteInterval.Text.Trim());
        }
        /// <summary>
        /// 文本文件存放位置浏览按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFolderBrowser_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowNewFolderButton = true;
            this.folderBrowserDialog1.SelectedPath = this.txtDataFile.Text;
            this.folderBrowserDialog1.Description = "选择数据文件存放的目录";
            var result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtDataFile.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }
        #endregion

        #region Timer Event
        /// <summary>
        /// 调整时钟，使读指标时钟TagTimer能在系统启动后的第一分钟前一个读指标时间间隔启动，
        /// 然后正好在第一分钟0秒触发，TagTimer事件。
        /// 例如：目前是10000毫秒一个读指标时间间隔，那么在50秒的时候，开始开启读指标时钟。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AdjustTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.isClosing || this.isPaused)//如果已经进入关闭，则将时钟停止,将忙标志位置为False。
            {
                try
                {
                    if(sender is System.Timers.Timer)
                    {
                        (sender as System.Timers.Timer).Stop();
                    }
                    this.Invoke(this.ShowInfoDelegateInstance, "调整时钟关闭！");
                    this.Invoke(this.ShowStatusDelegateInstance, "调整时钟关闭");
                    return;
                }
                catch (Exception)
                {
                    return;
                }

            }
            try
            {
                this.Invoke(this.ShowStatusDelegateInstance, "采集时钟等待中...");
                if (e.SignalTime.Second == 60 - this.ReadInterval / 1000 && e.SignalTime.Millisecond <= 100)
                {
                    this.AdjustTimer.Enabled = false;
                    this.lastFileName = string.Empty;
                    this.lastTableName = string.Format("T_TAG_S{0}", e.SignalTime.ToString("yyyyMMdd"));
                    this.TagTimer = new System.Timers.Timer { Interval = this.ReadInterval };
                    this.TagTimer.Elapsed += TagTimer_Elapsed;
                    this.TagTimer.Enabled = true;
                    this.Invoke(this.ShowInfoDelegateInstance, string.Format("采集时钟启动，{0}", DateTime.Now));
                    this.Invoke(this.ShowStatusDelegateInstance, "开始采集");
                    //this.Invoke(this.ShowTimeDelegateInstance, e.SignalTime.ToString());
                }
                else
                {
                    //this.Invoke(this.ShowTimeDelegateInstance, e.SignalTime.ToString());
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message,ex);
            }
        }
        /// <summary>
        /// 采集时钟。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TagTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(this.ShowStatusDelegateInstance, "正在采集");
            if (this.isClosing || this.isPaused)//如果已经进入关闭，则将时钟停止,将忙标志位置为False。
            {
                var timer = sender as System.Timers.Timer;
                if(timer != null)
                {
                    timer.Stop();
                }

                this.isBusy = false;
                this.Invoke(this.ShowWarningDelegateInstance, "采集停止！");
                this.Invoke(this.ShowStatusDelegateInstance, "采集停止");
                return;
            }
            
            this.currentWriter = e.SignalTime.Hour * 3600 + e.SignalTime.Minute * 60 + e.SignalTime.Second;
            var i_Cycle_Id = this.currentWriter;

            #region 关闭文件，发送消息队列，新建文件。
            //如果达到写文件时间间隔，则结束上次的写文件，同时新建一个文件，将下面一个写时间间隔内读取到的数据
            //写到流sw中。
            //第一次启动时由于是在整分触发，所以肯定触发下面的条件，此时LastFileName=="",因此只是新建一个文件。
            if (i_Cycle_Id >= this.fileWriter + writeInterval || i_Cycle_Id < this.fileWriter)
            {
                this.fileWriter = i_Cycle_Id;
                long fileLength = 0;
                try
                {
                    if (sw != null) 
                    {
                        fileLength = fs.Length;
                        sw.Close();//关闭StreamWriter。
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                    this.Invoke(this.ShowErrorDelegateInstance, ex.Message);
                }
                
                try
                {
                    if (fs != null) 
                    {
                        fs.Close();//关闭文件流。
                    }
                    
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                    this.Invoke(this.ShowErrorDelegateInstance, ex.Message);
                }

                if (!string.IsNullOrEmpty(this.lastFileName))
                {
                    this.SendMessageQueue(this.lastTableName, this.lastFileName);//发送消息队列。
                    this.Invoke(this.ShowInfoDelegateInstance, string.Format("发送消息队列：{0}-{1},Size is {2} kb", this.lastTableName, this.lastFileName, fileLength/1024));
                }
                //新建文件名和表名。
                this.lastFileName = string.Format(@"{0}\{1}.TXT", this.WorkPath, i_Cycle_Id.ToString("00000"));
                this.lastTableName = string.Format(@"T_TAG_S{0}", e.SignalTime.ToString("yyyyMMdd"));

                try
                {
                    fs = File.OpenWrite(this.lastFileName);//打开文件流。
                    sw = new StreamWriter(fs);//新建StreamWriter。
                    this.Invoke(this.ShowInfoDelegateInstance, string.Format("打开文件{0}", this.lastFileName));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                    this.Invoke(this.ShowErrorDelegateInstance, ex.Message);
                }
            }
            #endregion

            if (isBusy)//如果正在执行指标的采集动作，则本次操作忽略，减少一次采集动作。
            {
                return;
            }
            else
            {
                this.isBusy = true;
            }
            #region 从DDE数据源请求数据
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var obj in Objs)
            {
                try
                {
                    //Logger.Info(string.Format("Request {0}",obj.Address));
                    //obj.Value0 = double.Parse(obj.Client.Request(obj.Address, 5000));
                    obj.Value0 = obj.AdviseValue;
                }
                catch (Exception ex)
                {
                    obj.Value0 = obj.DefaultValue;//如果请求到的值在转换的过程中发生异常，则置为指标的默认值.
                    this.ErrorCount++;      //错误计数器加一。
                    this.Invoke(this.ShowErrorCountDelegateInstance, ErrorCount.ToString());//显示错误计数。
                    this.Invoke(this.ShowErrorDelegateInstance, string.Format("{0}指标 DDE请求数据失败！", obj.TagId));
                    Logger.Error(ex.Message, ex);//记录错误日志。
                }
                if (isFirst) obj.LastValue = obj.Value0;//如果是第一次采集那么将采集到的第一轮原始值同样也复制给LastValue。

                //this.Invoke(this.ShowValueDelegateInstance,obj.Value0.ToString() );//显示请求到的值。
            }
            stopWatch.Stop();
            this.Invoke(this.ShowRequestTimeDelegateInstance, string.Format("{0} 毫秒", stopWatch.ElapsedMilliseconds));
            if (this.isShowRequstTime)
                this.Invoke(this.ShowInfoDelegateInstance, string.Format("轮询一次耗时： {0} 毫秒", stopWatch.ElapsedMilliseconds));
            #endregion
            if (isFirst)
                this.isFirst = false;//即将是否第一次采集置为False。

            try
            {
                #region 计算指标的修正值
                foreach (var obj in Objs)
                {
                    if(obj.TagType == "201" && obj.ParaB > 0)//开关量指标，多个机泵的状态存放于一个Byte中的情况。ParaB代表第几位。
                    {

                        if(obj.ParaB==1)//第一位,00000001
                        {
                            var ret = ((int)obj.Value0) & 1;
                            obj.Value1 = ret == 1 ? 1 : 0;
                        }
                        else if(obj.ParaB == 2)//第二位,00000010
                        {
                            var ret = ((int)obj.Value0) & 2;
                            obj.Value1 = ret == 2 ? 1 : 0;
                        }
                        else if(obj.ParaB == 3)//第三位,00000100
                        {
                            var ret = ((int)obj.Value0) & 4;
                            obj.Value1 = ret == 4 ? 1 : 0;
                        }
                        else if(obj.ParaB == 4)//第四位,00001000
                        {
                            var ret = ((int)obj.Value0) & 8;
                            obj.Value1 = ret == 8 ? 1 : 0;
                        }
                        else if(obj.ParaB == 5)//第五位,00010000
                        {
                            var ret = ((int)obj.Value0) & 16;
                            obj.Value1 = ret == 16 ? 1 : 0;
                        }
                        else if(obj.ParaB == 6)//第六位,00100000
                        {
                            var ret = ((int)obj.Value0) & 32;
                            obj.Value1 = ret == 32 ? 1 : 0;
                        }
                        else if(obj.ParaB == 7)//第七位,01000000
                        {
                            var ret = ((int)obj.Value0) & 64;
                            obj.Value1 = ret == 64 ? 1 : 0;
                        }
                        else if(obj.ParaB == 8)//第八位,10000000
                        {
                            var ret = ((int)obj.Value0) & 128;
                            obj.Value1 = ret == 128 ? 1 : 0;
                        }
                    }
                    else
                    {

                        switch (obj.Calc_Type_Before_Hour)
                        {
                            case 3: //表码值的类型，该值会一直增加。该一轮的采样值，应该等于本次采集值-上次采集值之差。
                                if (obj.Value0 > obj.LastValue) //如果当前采集到值比上一次的大。
                                {
                                    if (obj.BreakValue != 0 && obj.Value0 >= obj.BreakValue)
                                    {
                                        obj.Value1 = obj.Value0 - obj.BreakValue;
                                        obj.BreakValue = 0;
                                    }
                                    else
                                    {
                                        obj.Value1 = obj.Value0 - obj.LastValue;
                                    }
                                }
                                else if (obj.Value0 == obj.LastValue) //如果当前值等于上一次采集到的值。
                                {
                                    obj.Value1 = 0; //当前的修正值为0.
                                }
                                else //当前的采集值小于上一次的采集值。
                                {
                                    //指标值突然变小时，用BreakValue记录突变前的值。
                                    obj.BreakValue = obj.LastValue;
                                }
                                obj.LastValue = obj.Value0; //将当前值赋给上一次的值。
                                // y=a*x+b,修正计算。
                                obj.Value1 = obj.ParaA*obj.Value1 + obj.ParaB;
                                break;
                            case 2: //积分计算方式。
                                //先进行修正计算。
                                obj.Value1 = obj.ParaA*obj.Value0 + obj.ParaB;
                                //再微分。
                                obj.Value1 = (obj.Value1/obj.ParaC)*(this.ReadInterval/1000);
                                break;
                            case 1: //平均。采集的时候由于是单个值，所以只需要进行修正计算。
                            default:
                                obj.Value1 = obj.ParaA*obj.Value0 + obj.ParaB;
                                break;
                        }
                        //如果修正值超出有效值的范围，则置为指标的默认值。
                        if (obj.Value1 > obj.MaxGatherValue || obj.Value1 < obj.MinGatherValue)
                        {
                            obj.Value1 = obj.DefaultValue;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                this.Invoke(this.ShowErrorDelegateInstance, ex.Message);
            }
            #region 将数据写到文件中
            try
            {
                foreach (var obj in Objs)
                {
                    if (sw != null)
                        sw.WriteLine(string.Format("{0},{1},{2},{3}", i_Cycle_Id, obj.TagId, obj.Value0, obj.Value1));
                    else
                    {
                        Logger.Warn("StreamWriter 为空。");
                        this.Invoke(this.ShowWarningDelegateInstance, string.Format("StreamWriter为空！"));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                this.Invoke(this.ShowErrorDelegateInstance, ex.Message);
            }
            #endregion

            this.isBusy = false;//操作完成，将忙标志置为False。
            this.Invoke(this.ShowStatusDelegateInstance, "空闲");
        }
        /// <summary>
        /// 关闭时钟事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void closerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!this.isBusy)
            {
                var timer = sender as System.Timers.Timer;
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
                this.Close();
            }
        }
        /// <summary>
        /// DDEClient连接检查时钟的事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ConnectionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!this.isPaused && !this.isClosing)
            {
                foreach (var client in this.ddeClients)
                {
                    if (client.IsConnected)
                    {
                        this.Invoke(this.ShowConnectionStatusDelegateInstance, string.Format("{0}|{1}已连接", client.Service, client.Topic));
                    }
                    else
                    {
                        this.Invoke(this.ShowConnectionStatusDelegateInstance, string.Format("{0}|{1}未连接", client.Service, client.Topic));
                        this.Invoke(this.ShowErrorDelegateInstance, string.Format("{0}|{1}未连接", client.Service, client.Topic));
                        try
                        {
                            this.Invoke(this.ShowInfoDelegateInstance, string.Format("尝试对{0}|{1}进行连接", client.Service, client.Topic));
                            client.Connect();
                            this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}|{1} DDE连接成功。", this.ServiceName, client.Topic));
                            var tags = this.Objs.FindAll(item => item.Client == client);
                            foreach (var tag in tags)
                            {
                                try
                                {
                                    client.StartAdvise(tag.Address, 1, true, 60000);
                                    this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}{1}{2} 通知成功！", tag.TagId, tag.TagName, tag.Address));
                                }
                                catch (Exception ex)
                                {
                                    Logger.Error(ex.Message, ex);
                                    this.Invoke(this.ShowWarningDelegateInstance, ex.Message);
                                }
                            }
                            this.tryConnectCount = 0; //将尝试连接计数器置0.
                        }
                        catch (Exception ex)
                        {
                            this.tryConnectCount++;
                            //if (this.tryConnectCount > this.tryConnectMaxCount)
                            //{
                            //    //TODO:发出警告。
                            //    this.Invoke(this.ShowInfoDelegateInstance, "发出DDE连接不能连接的警告通知！");
                            //    this.ConnectionTimer.Enabled = false;
                            //    this.Invoke(this.ShowWarningDelegateInstance, "尝试连接已经超出最大尝试次数，连接检查时钟停止");
                            //}
                            Logger.Error(ex.Message, ex);
                            this.Invoke(this.ShowErrorDelegateInstance, string.Format("尝试对{0}|{1}进行连接失败！", client.Service, client.Topic));
                        }
                    }
                }
            }
            else
            {
                this.ConnectionTimer.Enabled = false;
            }
        }
        #endregion

        #region Menu&Toolbar
        /// <summary>
        /// notifyIcon关联的菜单的退出事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// notifyIcon关联菜单的打开工作站菜单项事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenWorkStation_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.notifyIcon1.Visible = false;
        }
        /// <summary>
        /// 显示轮询时间菜单事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ShowRequestTime_Click(object sender, EventArgs e)
        {
            this.isShowRequstTime = !this.isShowRequstTime;
            this.AddInfo("开始轮询时间日志功能！");
        }
        /// <summary>
        /// 退出菜单事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 采集服务开始菜单事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Start_Click(object sender, EventArgs e)
        {
            this.backgroundWorker_Start.RunWorkerAsync();
        }
        /// <summary>
        /// 采集服务停止菜单事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Stop_Click(object sender, EventArgs e)
        {
            this.isPaused = true;
            this.ToolStripMenuItem_Stop.Enabled = false;
            this.ToolStripMenuItem_Start.Enabled = true;
            this.AddInfo("停止采集服务！");
            this.Invoke(this.ShowStatusDelegateInstance, "采集服务停止");
        }
        /// <summary>
        /// 清除日期菜单事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ClearLog_Click(object sender, EventArgs e)
        {
            this.listViewEventLogger.Items.Clear();
        }
        /// <summary>
        /// 自动滚动菜单事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_AutoScroll_Click(object sender, EventArgs e)
        {
            this.isAutoScroll = !this.isAutoScroll;
        }
        /// <summary>
        /// Test Menu Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Test_Click(object sender, EventArgs e)
        {
            Objs = DataRepository.TagProvider.GetByAction(this.Action) as List<TagInfo>;
            if (Objs != null)
            {
                this.Invoke(this.ShowInfoDelegateInstance, string.Format("指标加载成功，总共加载{0}个指标！", Objs.Count));
                this.Invoke(this.ShowStatusDelegateInstance, "指标加载成功");
                foreach (var obj1 in Objs)
                {
                    var obj = obj1;
                    var ddeClient = ddeClients.Find(item => item.Service == this.ServiceName && item.Topic == obj.DesignCD);

                    if (ddeClient == null)
                    {
                        ddeClient = new DdeClient(this.ServiceName, obj.DesignCD);

                        var stopWatch = new Stopwatch();
                        stopWatch.Start();

                        try
                        {
                            ddeClient.Connect();
                            stopWatch.Stop();
                            this.ddeClients.Add(ddeClient);
                            obj.Client = ddeClient;
                            this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}|{1} DDE连接成功。", this.ServiceName, obj.DesignCD));
                            this.Invoke(this.ShowConnectionStatusDelegateInstance, string.Format("{0}|{1} DDE连接成功。", this.ServiceName, obj.DesignCD));
                        }
                        catch (Exception ex)
                        {
                            stopWatch.Stop();
                            this.ddeClients.Add(ddeClient);
                            obj.Client = ddeClient;
                            //MessageBox.Show(string.Format("DDE连接失败！耗时：{0}", stopWatch.ElapsedMilliseconds));
                            this.Invoke(this.ShowErrorDelegateInstance, string.Format("{0}|{1} DDE连接失败！耗时：{2}", this.ServiceName, obj.DesignCD, stopWatch.ElapsedMilliseconds));
                            this.Invoke(this.ShowConnectionStatusDelegateInstance, string.Format("{0}|{1} DDE连接失败", this.ServiceName, obj.DesignCD));
                            Logger.Error(ex.Message, ex);
                        }
                    }
                    else
                    {
                        obj.Client = ddeClient;
                    }
                }
                var sw2 = new Stopwatch();
                sw2.Start();

                foreach (var obj in Objs)
                {
                    try
                    {
                        var sw1 = new Stopwatch();
                        sw1.Start();
                        //var value = obj.Client.Request(obj.Address, 5);
                        (obj.Client as DdeClient).StartAdvise(obj.Address, 1, true, 1000);

                        sw1.Stop();
                        this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0} Advise spend {1} ms", obj.TagId, sw1.ElapsedMilliseconds));
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                        this.Invoke(this.ShowInfoDelegateInstance, ex.Message);
                    }

                }
                sw2.Stop();
                this.Invoke(this.ShowInfoDelegateInstance, string.Format("轮询耗时{0}毫秒",sw2.ElapsedMilliseconds));
            }
        }
        #endregion

        /// <summary>
        /// 后台线程任务。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_Start_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Logger.Info("backgroundworker_start");
            this.isPaused = false;
            this.ToolStripMenuItem_Start.Enabled = false;
            this.ToolStripMenuItem_Stop.Enabled = true;

            Objs = DataRepository.TagProvider.GetByAction(this.Action) as List<TagInfo>;

            if (Objs != null)
            {
                this.Invoke(this.ShowInfoDelegateInstance, string.Format("指标加载成功，总共加载{0}个指标！", Objs.Count));
                this.Invoke(this.ShowStatusDelegateInstance, "指标加载成功");
                #region DdeClient Connect And Advise.
                foreach (var obj1 in Objs)
                {
                    var obj = obj1;
                    var ddeClient = ddeClients.Find(item => item.Service == this.ServiceName && item.Topic == obj.DesignCD);

                    if (ddeClient == null)
                    {
                        var context = new DdeContext();
                        ddeClient = new DdeClient(this.ServiceName, obj.DesignCD, context);

                        var stopWatch = new Stopwatch();
                        stopWatch.Start();

                        try
                        {
                            ddeClient.Connect();

                            stopWatch.Stop();
                            this.ddeClients.Add(ddeClient);
                            obj.Client = ddeClient;
                            try
                            {
                                (obj.Client as DdeClient).StartAdvise(obj.Address, 1, true,true, 60000,null);//第一次提供咨询。
                                this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} StartAdvise sucessful!", obj.TagId, obj.TagName, this.ServiceName,obj.DesignCD,obj.Address));
                                Logger.Info(string.Format("{0}{1} {2}|{3}!{4} startadvise sucessful!", obj.TagId, obj.TagName, this.ServiceName,obj.DesignCD,obj.Address));
                                try
                                {
                                    (obj.Client as DdeClient).Advise += new EventHandler<DdeAdviseEventArgs>(Client_Advise);
                                    this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} bind Advise event sucessful!", obj.TagId, obj.TagName,this.ServiceName,obj.DesignCD, obj.Address));
                                    Logger.Info(string.Format("{0}{1} {2}|{3}!{4} bind advise event sucessful!", obj.TagId, obj.TagName,this.ServiceName,obj.DesignCD, obj.Address));
                                }
                                catch (Exception ex2)
                                {
                                    Logger.Error(string.Format("{0}{1} {2}|{3}!{4} bind advise event failed!：{5}", obj.TagId, obj.TagName,this.ServiceName,obj.DesignCD, obj.Address, ex2.Message), ex2);
                                    this.Invoke(this.ShowErrorDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} bind advise event failed：{5}", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address, ex2.Message));
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(string.Format("{0}{1} {2}|{3}!{4} startadvise failed：{5}", obj.TagId, obj.TagName, this.ServiceName,obj.DesignCD, obj.Address, ex.Message), ex);
                                this.Invoke(this.ShowWarningDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} startadvise failed：{5}", obj.TagId, obj.TagName,this.ServiceName,obj.DesignCD, obj.Address, ex.Message));
                                try
                                {
                                    (obj.Client as DdeClient).StartAdvise(obj.Address, 1, true,true, 60000,null);//第二次提供咨询。
                                    this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} second start advise sucessful!", obj.TagId, obj.TagName, this.ServiceName,obj.DesignCD, obj.Address));
                                    Logger.Info(string.Format("{0}{1} {2}|{3}!{4} second start advise sucessful!", obj.TagId, obj.TagName,this.ServiceName, obj.DesignCD, obj.Address));
                                    try
                                    {
                                        (obj.Client as DdeClient).Advise += new EventHandler<DdeAdviseEventArgs>(Client_Advise);
                                    }
                                    catch (Exception ex3)
                                    {
                                        Logger.Error(string.Format("{0}{1} {2}|{3}!{4} bind advise event failed：{5}", obj.TagId, obj.TagName,this.ServiceName,obj.DesignCD, obj.Address, ex3.Message), ex3);
                                        this.Invoke(this.ShowWarningDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} bind advise event failed：{5}", obj.TagId, obj.TagName,this.ServiceName, obj.DesignCD, obj.Address, ex3.Message));
                                    }
                                }
                                catch (Exception ex1)
                                {
                                    Logger.Error(string.Format("{0}{1} {2}|{3}!{4} second start advise failed：{5}", obj.TagId, obj.TagName,this.ServiceName,obj.DesignCD, obj.Address, ex1.Message), ex1);
                                    this.Invoke(this.ShowWarningDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} second start advise failed：{5}", obj.TagId, obj.TagName,this.ServiceName, obj.DesignCD, obj.Address, ex1.Message));
                                }
                            }
                            this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}|{1} DDE connect sucessful.", this.ServiceName, obj.DesignCD));
                            this.Invoke(this.ShowConnectionStatusDelegateInstance, string.Format("{0}|{1} DDE connect sucessful.", this.ServiceName, obj.DesignCD));
                        }
                        catch (Exception ex)
                        {
                            stopWatch.Stop();
                            this.ddeClients.Add(ddeClient);
                            obj.Client = ddeClient;
                            this.Invoke(this.ShowErrorDelegateInstance, string.Format("{0}|{1} DDE connect failed!耗时：{2}", this.ServiceName, obj.DesignCD, stopWatch.ElapsedMilliseconds));
                            this.Invoke(this.ShowConnectionStatusDelegateInstance, string.Format("{0}|{1} DDE connect failed!", this.ServiceName, obj.DesignCD));
                            Logger.Error(string.Format("{0}-{1}:{2}", this.ServiceName, obj.DesignCD, ex.Message), ex);
                        }
                    }
                    else
                    {
                        obj.Client = ddeClient;
                        try
                        {
                            (obj.Client as DdeClient).StartAdvise(obj.Address, 1, true, true,60000,null);

                            this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} start advise sucessful.", obj.TagId, obj.TagName, this.ServiceName,obj.DesignCD,obj.Address));
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(string.Format("{0}{1} {2}|{3}!{4} start advise failed:{5}", obj.TagId, obj.TagName,this.ServiceName,obj.DesignCD, obj.Address, ex.Message), ex);
                            this.Invoke(this.ShowWarningDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} start advise failed:{5}", obj.TagId, obj.TagName,this.ServiceName,obj.DesignCD, obj.Address, ex.Message));
                            try
                            {
                                (obj.Client as DdeClient).StartAdvise(obj.Address, 1, true,true, 60000,null);
                                this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} start advise sucessful!", obj.TagId, obj.TagName, this.ServiceName,obj.DesignCD,obj.Address));
                                Logger.Info(string.Format("{0}{1} {2}|{3}!{4} start advise sucessful!", obj.TagId, obj.TagName, this.ServiceName,obj.DesignCD, obj.Address));
                            }
                            catch (Exception ex1)
                            {
                                Logger.Error(string.Format("{0}{1} {2}|{3}!{4} start advise failed:{5}", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address, ex1.Message), ex1);
                                this.Invoke(this.ShowWarningDelegateInstance, string.Format("{0}{1} {2}|{3}!{4} start advise failed:{5}", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address, ex1.Message));
                            }
                        }
                    }
                }
                #endregion

                #region First Time Request
                foreach (var obj in Objs)
                {
                    try
                    {
                        obj.AdviseValue = double.Parse((obj.Client as DdeClient).Request(obj.Address, 60000));
                        this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}{1}{2}|{3}!{4} first time DDE Request sucessful!", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address));
                        Logger.Info(string.Format("{0}{1}{2}|{3}!{4} first time DDE Request sucessful!", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address));
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            obj.AdviseValue = double.Parse((obj.Client as DdeClient).Request(obj.Address, 120000));
                            this.Invoke(this.ShowInfoDelegateInstance, string.Format("{0}{1}{2}|{3}!{4} second time DDE Request sucessful!", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address));
                            Logger.Info(string.Format("{0}{1}{2}|{3}!{4} second time DDE Request sucessful!", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address));
                        }
                        catch(Exception ex1)
                        {
                            this.Invoke(this.ShowErrorDelegateInstance, string.Format("{0}{1}{2}|{3}!{4} first time DDE request failed!", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address));
                            obj.AdviseValue = obj.DefaultValue;//如果请求到的值在转换的过程中发生异常，则置为指标的默认值.
                            this.ErrorCount++;      //错误计数器加一。
                            this.Invoke(this.ShowErrorCountDelegateInstance, ErrorCount.ToString());//显示错误计数。
                            this.Invoke(this.ShowErrorDelegateInstance, string.Format("{0}{1}{2}|{3}!{4} second time DDE request failed!", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address));
                            Logger.Error(string.Format("{0}{1} {2}|{3}!{4} request failed:{3}", obj.TagId, obj.TagName, this.ServiceName, obj.DesignCD, obj.Address, ex.Message), ex);//记录错误日志。
                            Logger.Error(ex1.Message, ex1);
                        }
                        
                    }
                }
                #endregion

                #region Dde Connection Checker
                if (this.ConnectionTimer == null)
                    this.ConnectionTimer = new System.Timers.Timer();
                this.ConnectionTimer.Interval = this.connectionCheckInterval;
                this.ConnectionTimer.Elapsed += ConnectionTimer_Elapsed;
                this.ConnectionTimer.Enabled = true;
                this.Invoke(this.ShowInfoDelegateInstance, "DDE连接检查时钟启动！");
                #endregion

                #region Adjust Timer
                if (this.AdjustTimer == null)
                    this.AdjustTimer = new System.Timers.Timer { Interval = 100 };
                this.AdjustTimer.Elapsed += AdjustTimer_Elapsed;
                this.AdjustTimer.Enabled = true;
                this.Invoke(this.ShowStatusDelegateInstance, "预备时钟启动！");
                this.Invoke(this.ShowInfoDelegateInstance, "预备时钟启动.");
                #endregion
            }
            else
            {
                this.Invoke(this.ShowWarningDelegateInstance, "没有找到相关的指标！");
                this.Invoke(this.ShowStatusDelegateInstance, "没有找到相关的指标");
                Logger.Info("没有找到指标！");
            }
        }
        /// <summary>
        /// DdeClient 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Client_Advise(object sender, DdeAdviseEventArgs e)
        {
            var client = sender as DdeClient;
            //Logger.Debug(string.Format("Client_Advise:{0}!{1} : {2} (state:{3};format:{4}:Data:[5})", client.Topic, e.Item, e.Text, e.State, e.Format, e.Data));
            //Must be ToUpper() ,because in the tag's setting,it maybe case.
            var objs = this.Objs.FindAll(item => item.DesignCD.ToUpper() == client.Topic.ToUpper() && item.Address.ToUpper() == e.Item.ToUpper());

            double value = 0.0;
            try
            {
                value = double.Parse(e.Text);
                foreach (var obj in objs)
                {
                    obj.AdviseValue = value;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }

        }
    }
}
