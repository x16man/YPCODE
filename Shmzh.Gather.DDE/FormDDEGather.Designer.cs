namespace Shmzh.Gather.DDE
{
    partial class FormDDEGather
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDDEGather));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGather = new System.Windows.Forms.TabPage();
            this.listViewEventLogger = new System.Windows.Forms.ListView();
            this.tabPageDataFile = new System.Windows.Forms.TabPage();
            this.listView_DataFile = new System.Windows.Forms.ListView();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelAlertIntervalUnit = new System.Windows.Forms.Label();
            this.txtAlertMaxCount = new System.Windows.Forms.TextBox();
            this.txtAlertInterval = new System.Windows.Forms.TextBox();
            this.txtTryConnectionTimes = new System.Windows.Forms.TextBox();
            this.labelAlertMaxCount = new System.Windows.Forms.Label();
            this.labelAlertInterval = new System.Windows.Forms.Label();
            this.labelTryConnectionTimes = new System.Windows.Forms.Label();
            this.labelConnectionCheckUnit = new System.Windows.Forms.Label();
            this.txtConnectionInterval = new System.Windows.Forms.TextBox();
            this.labelConnectInterval = new System.Windows.Forms.Label();
            this.labelSecond = new System.Windows.Forms.Label();
            this.txtWriteInterval = new System.Windows.Forms.TextBox();
            this.labelWriteInterval = new System.Windows.Forms.Label();
            this.labelMilliSecond = new System.Windows.Forms.Label();
            this.txtReadInterval = new System.Windows.Forms.TextBox();
            this.labelReadInterval = new System.Windows.Forms.Label();
            this.txtLinkTopic = new System.Windows.Forms.TextBox();
            this.labelLinkTopic = new System.Windows.Forms.Label();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.labelAction = new System.Windows.Forms.Label();
            this.txtQueueName = new System.Windows.Forms.TextBox();
            this.labelQueueName = new System.Windows.Forms.Label();
            this.btnFolderBrowser = new System.Windows.Forms.Button();
            this.txtDataFile = new System.Windows.Forms.TextBox();
            this.labelDataFile = new System.Windows.Forms.Label();
            this.groupBoxConnectionString = new System.Windows.Forms.GroupBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.imageList4Tab = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_GatherService = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ShowRequestTime = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_AutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Test = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_RequestTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ErrorCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenWorkStation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker_Start = new System.ComponentModel.BackgroundWorker();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel_Status = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_RequestTime = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_ErrorCount = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_ConnectionStatus = new System.Windows.Forms.StatusBarPanel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tabControl1.SuspendLayout();
            this.tabPageGather.SuspendLayout();
            this.tabPageDataFile.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxConnectionString.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_RequestTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_ErrorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_ConnectionStatus)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGather);
            this.tabControl1.Controls.Add(this.tabPageDataFile);
            this.tabControl1.Controls.Add(this.tabPageConfig);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ImageList = this.imageList4Tab;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(602, 388);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageGather
            // 
            this.tabPageGather.Controls.Add(this.listViewEventLogger);
            this.tabPageGather.ImageIndex = 8;
            this.tabPageGather.Location = new System.Drawing.Point(4, 23);
            this.tabPageGather.Name = "tabPageGather";
            this.tabPageGather.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGather.Size = new System.Drawing.Size(594, 361);
            this.tabPageGather.TabIndex = 0;
            this.tabPageGather.Text = "数据采集";
            this.tabPageGather.UseVisualStyleBackColor = true;
            // 
            // listViewEventLogger
            // 
            this.listViewEventLogger.Location = new System.Drawing.Point(180, 30);
            this.listViewEventLogger.Name = "listViewEventLogger";
            this.listViewEventLogger.Size = new System.Drawing.Size(121, 71);
            this.listViewEventLogger.TabIndex = 0;
            this.listViewEventLogger.UseCompatibleStateImageBehavior = false;
            // 
            // tabPageDataFile
            // 
            this.tabPageDataFile.Controls.Add(this.listView_DataFile);
            this.tabPageDataFile.ImageIndex = 9;
            this.tabPageDataFile.Location = new System.Drawing.Point(4, 23);
            this.tabPageDataFile.Name = "tabPageDataFile";
            this.tabPageDataFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataFile.Size = new System.Drawing.Size(594, 361);
            this.tabPageDataFile.TabIndex = 1;
            this.tabPageDataFile.Text = "数据文件";
            this.tabPageDataFile.UseVisualStyleBackColor = true;
            // 
            // listView_DataFile
            // 
            this.listView_DataFile.Location = new System.Drawing.Point(8, 6);
            this.listView_DataFile.Name = "listView_DataFile";
            this.listView_DataFile.Size = new System.Drawing.Size(126, 107);
            this.listView_DataFile.TabIndex = 0;
            this.listView_DataFile.UseCompatibleStateImageBehavior = false;
            this.listView_DataFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_DataFile_MouseDoubleClick);
            
            this.listView_DataFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_DataFile_KeyDown);
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.btnCancel);
            this.tabPageConfig.Controls.Add(this.btnYes);
            this.tabPageConfig.Controls.Add(this.groupBox3);
            this.tabPageConfig.Controls.Add(this.groupBoxConnectionString);
            this.tabPageConfig.ImageIndex = 7;
            this.tabPageConfig.Location = new System.Drawing.Point(4, 23);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(594, 361);
            this.tabPageConfig.TabIndex = 2;
            this.tabPageConfig.Text = "配置信息";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(513, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&C.取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(513, 282);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "&Y.确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelAlertIntervalUnit);
            this.groupBox3.Controls.Add(this.txtAlertMaxCount);
            this.groupBox3.Controls.Add(this.txtAlertInterval);
            this.groupBox3.Controls.Add(this.txtTryConnectionTimes);
            this.groupBox3.Controls.Add(this.labelAlertMaxCount);
            this.groupBox3.Controls.Add(this.labelAlertInterval);
            this.groupBox3.Controls.Add(this.labelTryConnectionTimes);
            this.groupBox3.Controls.Add(this.labelConnectionCheckUnit);
            this.groupBox3.Controls.Add(this.txtConnectionInterval);
            this.groupBox3.Controls.Add(this.labelConnectInterval);
            this.groupBox3.Controls.Add(this.labelSecond);
            this.groupBox3.Controls.Add(this.txtWriteInterval);
            this.groupBox3.Controls.Add(this.labelWriteInterval);
            this.groupBox3.Controls.Add(this.labelMilliSecond);
            this.groupBox3.Controls.Add(this.txtReadInterval);
            this.groupBox3.Controls.Add(this.labelReadInterval);
            this.groupBox3.Controls.Add(this.txtLinkTopic);
            this.groupBox3.Controls.Add(this.labelLinkTopic);
            this.groupBox3.Controls.Add(this.txtAction);
            this.groupBox3.Controls.Add(this.labelAction);
            this.groupBox3.Controls.Add(this.txtQueueName);
            this.groupBox3.Controls.Add(this.labelQueueName);
            this.groupBox3.Controls.Add(this.btnFolderBrowser);
            this.groupBox3.Controls.Add(this.txtDataFile);
            this.groupBox3.Controls.Add(this.labelDataFile);
            this.groupBox3.Location = new System.Drawing.Point(9, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 255);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // labelAlertIntervalUnit
            // 
            this.labelAlertIntervalUnit.AutoSize = true;
            this.labelAlertIntervalUnit.Location = new System.Drawing.Point(452, 181);
            this.labelAlertIntervalUnit.Name = "labelAlertIntervalUnit";
            this.labelAlertIntervalUnit.Size = new System.Drawing.Size(41, 12);
            this.labelAlertIntervalUnit.TabIndex = 24;
            this.labelAlertIntervalUnit.Text = "label2";
            // 
            // txtAlertMaxCount
            // 
            this.txtAlertMaxCount.Location = new System.Drawing.Point(376, 210);
            this.txtAlertMaxCount.Name = "txtAlertMaxCount";
            this.txtAlertMaxCount.Size = new System.Drawing.Size(97, 21);
            this.txtAlertMaxCount.TabIndex = 23;
            // 
            // txtAlertInterval
            // 
            this.txtAlertInterval.Location = new System.Drawing.Point(376, 178);
            this.txtAlertInterval.Name = "txtAlertInterval";
            this.txtAlertInterval.Size = new System.Drawing.Size(72, 21);
            this.txtAlertInterval.TabIndex = 22;
            // 
            // txtTryConnectionTimes
            // 
            this.txtTryConnectionTimes.Location = new System.Drawing.Point(376, 144);
            this.txtTryConnectionTimes.Name = "txtTryConnectionTimes";
            this.txtTryConnectionTimes.Size = new System.Drawing.Size(97, 21);
            this.txtTryConnectionTimes.TabIndex = 21;
            // 
            // labelAlertMaxCount
            // 
            this.labelAlertMaxCount.AutoSize = true;
            this.labelAlertMaxCount.Location = new System.Drawing.Point(250, 210);
            this.labelAlertMaxCount.Name = "labelAlertMaxCount";
            this.labelAlertMaxCount.Size = new System.Drawing.Size(41, 12);
            this.labelAlertMaxCount.TabIndex = 20;
            this.labelAlertMaxCount.Text = "label3";
            // 
            // labelAlertInterval
            // 
            this.labelAlertInterval.AutoSize = true;
            this.labelAlertInterval.Location = new System.Drawing.Point(246, 178);
            this.labelAlertInterval.Name = "labelAlertInterval";
            this.labelAlertInterval.Size = new System.Drawing.Size(41, 12);
            this.labelAlertInterval.TabIndex = 19;
            this.labelAlertInterval.Text = "label2";
            // 
            // labelTryConnectionTimes
            // 
            this.labelTryConnectionTimes.AutoSize = true;
            this.labelTryConnectionTimes.Location = new System.Drawing.Point(250, 150);
            this.labelTryConnectionTimes.Name = "labelTryConnectionTimes";
            this.labelTryConnectionTimes.Size = new System.Drawing.Size(41, 12);
            this.labelTryConnectionTimes.TabIndex = 18;
            this.labelTryConnectionTimes.Text = "label1";
            // 
            // labelConnectionCheckUnit
            // 
            this.labelConnectionCheckUnit.AutoSize = true;
            this.labelConnectionCheckUnit.Location = new System.Drawing.Point(199, 210);
            this.labelConnectionCheckUnit.Name = "labelConnectionCheckUnit";
            this.labelConnectionCheckUnit.Size = new System.Drawing.Size(41, 12);
            this.labelConnectionCheckUnit.TabIndex = 17;
            this.labelConnectionCheckUnit.Text = "(毫秒)";
            // 
            // txtConnectionInterval
            // 
            this.txtConnectionInterval.Location = new System.Drawing.Point(125, 207);
            this.txtConnectionInterval.Name = "txtConnectionInterval";
            this.txtConnectionInterval.Size = new System.Drawing.Size(70, 21);
            this.txtConnectionInterval.TabIndex = 16;
            // 
            // labelConnectInterval
            // 
            this.labelConnectInterval.AutoSize = true;
            this.labelConnectInterval.Location = new System.Drawing.Point(6, 210);
            this.labelConnectInterval.Name = "labelConnectInterval";
            this.labelConnectInterval.Size = new System.Drawing.Size(107, 12);
            this.labelConnectInterval.TabIndex = 15;
            this.labelConnectInterval.Text = "检查DDE连接间隔：";
            // 
            // labelSecond
            // 
            this.labelSecond.AutoSize = true;
            this.labelSecond.Location = new System.Drawing.Point(199, 178);
            this.labelSecond.Name = "labelSecond";
            this.labelSecond.Size = new System.Drawing.Size(41, 12);
            this.labelSecond.TabIndex = 14;
            this.labelSecond.Text = "( 秒 )";
            // 
            // txtWriteInterval
            // 
            this.txtWriteInterval.Location = new System.Drawing.Point(125, 174);
            this.txtWriteInterval.Name = "txtWriteInterval";
            this.txtWriteInterval.Size = new System.Drawing.Size(70, 21);
            this.txtWriteInterval.TabIndex = 13;
            // 
            // labelWriteInterval
            // 
            this.labelWriteInterval.AutoSize = true;
            this.labelWriteInterval.Location = new System.Drawing.Point(6, 178);
            this.labelWriteInterval.Name = "labelWriteInterval";
            this.labelWriteInterval.Size = new System.Drawing.Size(101, 12);
            this.labelWriteInterval.TabIndex = 12;
            this.labelWriteInterval.Text = "写文本文件间隔：";
            // 
            // labelMilliSecond
            // 
            this.labelMilliSecond.AutoSize = true;
            this.labelMilliSecond.Location = new System.Drawing.Point(199, 147);
            this.labelMilliSecond.Name = "labelMilliSecond";
            this.labelMilliSecond.Size = new System.Drawing.Size(41, 12);
            this.labelMilliSecond.TabIndex = 11;
            this.labelMilliSecond.Text = "(毫秒)";
            // 
            // txtReadInterval
            // 
            this.txtReadInterval.Location = new System.Drawing.Point(124, 143);
            this.txtReadInterval.Name = "txtReadInterval";
            this.txtReadInterval.Size = new System.Drawing.Size(71, 21);
            this.txtReadInterval.TabIndex = 10;
            // 
            // labelReadInterval
            // 
            this.labelReadInterval.AutoSize = true;
            this.labelReadInterval.Location = new System.Drawing.Point(6, 147);
            this.labelReadInterval.Name = "labelReadInterval";
            this.labelReadInterval.Size = new System.Drawing.Size(113, 12);
            this.labelReadInterval.TabIndex = 9;
            this.labelReadInterval.Text = "读取指标数据间隔：";
            // 
            // txtLinkTopic
            // 
            this.txtLinkTopic.Location = new System.Drawing.Point(124, 116);
            this.txtLinkTopic.Name = "txtLinkTopic";
            this.txtLinkTopic.Size = new System.Drawing.Size(351, 21);
            this.txtLinkTopic.TabIndex = 8;
            // 
            // labelLinkTopic
            // 
            this.labelLinkTopic.AutoSize = true;
            this.labelLinkTopic.Location = new System.Drawing.Point(6, 119);
            this.labelLinkTopic.Name = "labelLinkTopic";
            this.labelLinkTopic.Size = new System.Drawing.Size(107, 12);
            this.labelLinkTopic.TabIndex = 7;
            this.labelLinkTopic.Text = "DDE源应用程序名：";
            // 
            // txtAction
            // 
            this.txtAction.Location = new System.Drawing.Point(124, 83);
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(351, 21);
            this.txtAction.TabIndex = 6;
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Location = new System.Drawing.Point(23, 86);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(89, 12);
            this.labelAction.TabIndex = 5;
            this.labelAction.Text = "指标采集动作：";
            // 
            // txtQueueName
            // 
            this.txtQueueName.Location = new System.Drawing.Point(124, 47);
            this.txtQueueName.Name = "txtQueueName";
            this.txtQueueName.Size = new System.Drawing.Size(351, 21);
            this.txtQueueName.TabIndex = 4;
            // 
            // labelQueueName
            // 
            this.labelQueueName.AutoSize = true;
            this.labelQueueName.Location = new System.Drawing.Point(23, 56);
            this.labelQueueName.Name = "labelQueueName";
            this.labelQueueName.Size = new System.Drawing.Size(89, 12);
            this.labelQueueName.TabIndex = 3;
            this.labelQueueName.Text = "消息队列名称：";
            // 
            // btnFolderBrowser
            // 
            this.btnFolderBrowser.Image = global::Shmzh.Gather.DDE.Properties.Resources.folder_explore;
            this.btnFolderBrowser.Location = new System.Drawing.Point(447, 17);
            this.btnFolderBrowser.Name = "btnFolderBrowser";
            this.btnFolderBrowser.Size = new System.Drawing.Size(26, 23);
            this.btnFolderBrowser.TabIndex = 2;
            this.btnFolderBrowser.UseVisualStyleBackColor = true;
            this.btnFolderBrowser.Click += new System.EventHandler(this.btnFolderBrowser_Click);
            // 
            // txtDataFile
            // 
            this.txtDataFile.Location = new System.Drawing.Point(124, 17);
            this.txtDataFile.Name = "txtDataFile";
            this.txtDataFile.ReadOnly = true;
            this.txtDataFile.Size = new System.Drawing.Size(317, 21);
            this.txtDataFile.TabIndex = 1;
            // 
            // labelDataFile
            // 
            this.labelDataFile.AutoSize = true;
            this.labelDataFile.Location = new System.Drawing.Point(22, 21);
            this.labelDataFile.Name = "labelDataFile";
            this.labelDataFile.Size = new System.Drawing.Size(89, 12);
            this.labelDataFile.TabIndex = 0;
            this.labelDataFile.Text = "数据文件目录：";
            // 
            // groupBoxConnectionString
            // 
            this.groupBoxConnectionString.Controls.Add(this.txtConnectionString);
            this.groupBoxConnectionString.Location = new System.Drawing.Point(8, 6);
            this.groupBoxConnectionString.Name = "groupBoxConnectionString";
            this.groupBoxConnectionString.Size = new System.Drawing.Size(580, 67);
            this.groupBoxConnectionString.TabIndex = 1;
            this.groupBoxConnectionString.TabStop = false;
            this.groupBoxConnectionString.Text = "数据库连接";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(7, 21);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(567, 35);
            this.txtConnectionString.TabIndex = 0;
            // 
            // imageList4Tab
            // 
            this.imageList4Tab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4Tab.ImageStream")));
            this.imageList4Tab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4Tab.Images.SetKeyName(0, "shell32_152.ico");
            this.imageList4Tab.Images.SetKeyName(1, "shell32_177.ico");
            this.imageList4Tab.Images.SetKeyName(2, "shell32_36.ico");
            this.imageList4Tab.Images.SetKeyName(3, "eventlog.ico");
            this.imageList4Tab.Images.SetKeyName(4, "textdoc.ico");
            this.imageList4Tab.Images.SetKeyName(5, "otheroptions.ico");
            this.imageList4Tab.Images.SetKeyName(6, "page_white_text_width.png");
            this.imageList4Tab.Images.SetKeyName(7, "wrench.png");
            this.imageList4Tab.Images.SetKeyName(8, "application_view_list.png");
            this.imageList4Tab.Images.SetKeyName(9, "page_white_text.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_GatherService,
            this.ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(602, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_GatherService
            // 
            this.ToolStripMenuItem_GatherService.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Start,
            this.ToolStripMenuItem_Stop,
            this.toolStripMenuItem2,
            this.ToolStripMenuItem_Exit});
            this.ToolStripMenuItem_GatherService.Name = "ToolStripMenuItem_GatherService";
            this.ToolStripMenuItem_GatherService.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItem_GatherService.Text = "采集服务";
            // 
            // ToolStripMenuItem_Start
            // 
            this.ToolStripMenuItem_Start.Name = "ToolStripMenuItem_Start";
            this.ToolStripMenuItem_Start.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_Start.Text = "启动(&S)";
            this.ToolStripMenuItem_Start.Click += new System.EventHandler(this.ToolStripMenuItem_Start_Click);
            // 
            // ToolStripMenuItem_Stop
            // 
            this.ToolStripMenuItem_Stop.Name = "ToolStripMenuItem_Stop";
            this.ToolStripMenuItem_Stop.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_Stop.Text = "停止(&P)";
            this.ToolStripMenuItem_Stop.Click += new System.EventHandler(this.ToolStripMenuItem_Stop_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(109, 6);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(112, 22);
            this.ToolStripMenuItem_Exit.Text = "退出(&X)";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Checked = true;
            this.ToolStripMenuItem.CheckOnClick = true;
            this.ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ShowRequestTime,
            this.ToolStripMenuItem_ClearLog,
            this.ToolStripMenuItem_AutoScroll,
            this.toolStripMenuItem4,
            this.ToolStripMenuItem_Test});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.ToolStripMenuItem.Text = "调试";
            // 
            // ToolStripMenuItem_ShowRequestTime
            // 
            this.ToolStripMenuItem_ShowRequestTime.CheckOnClick = true;
            this.ToolStripMenuItem_ShowRequestTime.Name = "ToolStripMenuItem_ShowRequestTime";
            this.ToolStripMenuItem_ShowRequestTime.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_ShowRequestTime.Text = "显示轮询时间(&T)";
            this.ToolStripMenuItem_ShowRequestTime.Click += new System.EventHandler(this.ToolStripMenuItem_ShowRequestTime_Click);
            // 
            // ToolStripMenuItem_ClearLog
            // 
            this.ToolStripMenuItem_ClearLog.Name = "ToolStripMenuItem_ClearLog";
            this.ToolStripMenuItem_ClearLog.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_ClearLog.Text = "清除日志(&L)";
            this.ToolStripMenuItem_ClearLog.Click += new System.EventHandler(this.ToolStripMenuItem_ClearLog_Click);
            // 
            // ToolStripMenuItem_AutoScroll
            // 
            this.ToolStripMenuItem_AutoScroll.CheckOnClick = true;
            this.ToolStripMenuItem_AutoScroll.Name = "ToolStripMenuItem_AutoScroll";
            this.ToolStripMenuItem_AutoScroll.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_AutoScroll.Text = "自动滚动(&R)";
            this.ToolStripMenuItem_AutoScroll.Click += new System.EventHandler(this.ToolStripMenuItem_AutoScroll_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 6);
            // 
            // ToolStripMenuItem_Test
            // 
            this.ToolStripMenuItem_Test.Name = "ToolStripMenuItem_Test";
            this.ToolStripMenuItem_Test.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_Test.Text = "测试(&T)";
            this.ToolStripMenuItem_Test.Click += new System.EventHandler(this.ToolStripMenuItem_Test_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_Status,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_RequestTime,
            this.toolStripSplitButton2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel_ErrorCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 412);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(602, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel1.Text = "状态：";
            // 
            // toolStripStatusLabel_Status
            // 
            this.toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            this.toolStripStatusLabel_Status.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel2.Text = "轮询时间：";
            // 
            // toolStripStatusLabel_RequestTime
            // 
            this.toolStripStatusLabel_RequestTime.Name = "toolStripStatusLabel_RequestTime";
            this.toolStripStatusLabel_RequestTime.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(16, 20);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel3.Text = "错误计数：";
            // 
            // toolStripStatusLabel_ErrorCount
            // 
            this.toolStripStatusLabel_ErrorCount.Name = "toolStripStatusLabel_ErrorCount";
            this.toolStripStatusLabel_ErrorCount.Size = new System.Drawing.Size(0, 17);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "DDE采集程序";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenWorkStation,
            this.tsmiExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            // 
            // tsmiOpenWorkStation
            // 
            this.tsmiOpenWorkStation.Name = "tsmiOpenWorkStation";
            this.tsmiOpenWorkStation.Size = new System.Drawing.Size(142, 22);
            this.tsmiOpenWorkStation.Text = "&O.打开工作台";
            this.tsmiOpenWorkStation.Click += new System.EventHandler(this.tsmiOpenWorkStation_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(142, 22);
            this.tsmiExit.Text = "&X.退出程序";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // backgroundWorker_Start
            // 
            this.backgroundWorker_Start.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Start_DoWork);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 412);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel_Status,
            this.statusBarPanel_RequestTime,
            this.statusBarPanel_ErrorCount,
            this.statusBarPanel_ConnectionStatus});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(602, 22);
            this.statusBar1.TabIndex = 13;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel_Status
            // 
            this.statusBarPanel_Status.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel_Status.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel_Status.Icon")));
            this.statusBarPanel_Status.MinWidth = 100;
            this.statusBarPanel_Status.Name = "statusBarPanel_Status";
            this.statusBarPanel_Status.ToolTipText = "当前状态";
            // 
            // statusBarPanel_RequestTime
            // 
            this.statusBarPanel_RequestTime.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel_RequestTime.Icon")));
            this.statusBarPanel_RequestTime.MinWidth = 100;
            this.statusBarPanel_RequestTime.Name = "statusBarPanel_RequestTime";
            this.statusBarPanel_RequestTime.Text = "50ms";
            this.statusBarPanel_RequestTime.ToolTipText = "查询耗时";
            // 
            // statusBarPanel_ErrorCount
            // 
            this.statusBarPanel_ErrorCount.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel_ErrorCount.Icon")));
            this.statusBarPanel_ErrorCount.Name = "statusBarPanel_ErrorCount";
            this.statusBarPanel_ErrorCount.Text = "0";
            this.statusBarPanel_ErrorCount.ToolTipText = "错误计数";
            // 
            // statusBarPanel_ConnectionStatus
            // 
            this.statusBarPanel_ConnectionStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel_ConnectionStatus.Name = "statusBarPanel_ConnectionStatus";
            this.statusBarPanel_ConnectionStatus.Text = "已连接";
            this.statusBarPanel_ConnectionStatus.ToolTipText = "DDE的连接状态";
            this.statusBarPanel_ConnectionStatus.Width = 285;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(137, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "图标(&N)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem3.Text = "详细信息(D)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // FormDDEGather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 434);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormDDEGather";
            this.Text = "DDE数据采集";
            this.Load += new System.EventHandler(this.FormDDEGather_Load);
            this.SizeChanged += new System.EventHandler(this.FormDDEGather_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDDEGather_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGather.ResumeLayout(false);
            this.tabPageDataFile.ResumeLayout(false);
            this.tabPageConfig.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxConnectionString.ResumeLayout(false);
            this.groupBoxConnectionString.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_RequestTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_ErrorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_ConnectionStatus)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGather;
        private System.Windows.Forms.TabPage tabPageDataFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenWorkStation;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.GroupBox groupBoxConnectionString;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelDataFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFolderBrowser;
        private System.Windows.Forms.TextBox txtDataFile;
        private System.Windows.Forms.ImageList imageList4Tab;
        private System.Windows.Forms.TextBox txtQueueName;
        private System.Windows.Forms.Label labelQueueName;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Label labelLinkTopic;
        private System.Windows.Forms.TextBox txtLinkTopic;
        private System.Windows.Forms.TextBox txtWriteInterval;
        private System.Windows.Forms.Label labelWriteInterval;
        private System.Windows.Forms.Label labelMilliSecond;
        private System.Windows.Forms.TextBox txtReadInterval;
        private System.Windows.Forms.Label labelReadInterval;
        private System.Windows.Forms.Label labelSecond;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.ListView listViewEventLogger;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_GatherService;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Start;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Stop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ShowRequestTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_RequestTime;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Start;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ErrorCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel_Status;
        private System.Windows.Forms.StatusBarPanel statusBarPanel_RequestTime;
        private System.Windows.Forms.StatusBarPanel statusBarPanel_ErrorCount;
        private System.Windows.Forms.StatusBarPanel statusBarPanel_ConnectionStatus;
        private System.Windows.Forms.Label labelConnectionCheckUnit;
        private System.Windows.Forms.TextBox txtConnectionInterval;
        private System.Windows.Forms.Label labelConnectInterval;
        private System.Windows.Forms.Label labelAlertMaxCount;
        private System.Windows.Forms.Label labelAlertInterval;
        private System.Windows.Forms.Label labelTryConnectionTimes;
        private System.Windows.Forms.TextBox txtAlertMaxCount;
        private System.Windows.Forms.TextBox txtAlertInterval;
        private System.Windows.Forms.TextBox txtTryConnectionTimes;
        private System.Windows.Forms.Label labelAlertIntervalUnit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ClearLog;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_AutoScroll;
        private System.Windows.Forms.ListView listView_DataFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Test;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

