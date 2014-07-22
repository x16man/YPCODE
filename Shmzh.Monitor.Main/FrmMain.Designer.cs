namespace Shmzh.Monitor.Main
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (this._isShowPostion)
            {
                try
                {
                    Gma.UserActivityMonitor.HookManager.MouseMove -= HookManager_MouseMove;
                }
                catch { }
            }

            if (timerState != null)
            {
                timerState.Stop();
                timerState.Dispose();
            }
            
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblPostion = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.mzhBtnStop = new Shmzh.Windows.Forms.MzhRibbonMenuButton();
            this.mzhBtnMain = new Shmzh.Windows.Forms.MzhRibbonMenuButton();
            this.mzhBtnPre = new Shmzh.Windows.Forms.MzhRibbonMenuButton();
            this.mzhBtnNext = new Shmzh.Windows.Forms.MzhRibbonMenuButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerToolbar = new System.Windows.Forms.Timer(this.components);
            this.menuPlayStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPre = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGoto = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuLogoff = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTagSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHome = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.cMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.lblPostion);
            this.panelMain.Controls.Add(this.panelMenu);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(338, 253);
            this.panelMain.TabIndex = 0;
            // 
            // lblPostion
            // 
            this.lblPostion.AutoSize = true;
            this.lblPostion.BackColor = System.Drawing.Color.White;
            this.lblPostion.Location = new System.Drawing.Point(0, 0);
            this.lblPostion.Name = "lblPostion";
            this.lblPostion.Size = new System.Drawing.Size(113, 12);
            this.lblPostion.TabIndex = 2;
            this.lblPostion.Text = "X=0:0000; Y=1:0000";
            this.lblPostion.Visible = false;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMenu.Controls.Add(this.mzhBtnStop);
            this.panelMenu.Controls.Add(this.mzhBtnMain);
            this.panelMenu.Controls.Add(this.mzhBtnPre);
            this.panelMenu.Controls.Add(this.mzhBtnNext);
            this.panelMenu.Location = new System.Drawing.Point(45, 213);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panelMenu.Size = new System.Drawing.Size(154, 40);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.MouseLeave += new System.EventHandler(this.panelMenu_MouseLeave);
            this.panelMenu.MouseEnter += new System.EventHandler(this.panelMenu_MouseEnter);
            // 
            // mzhBtnStop
            // 
            this.mzhBtnStop.Arrow = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_arrow.None;
            this.mzhBtnStop.AutoSize = true;
            this.mzhBtnStop.BackColor = System.Drawing.Color.Transparent;
            this.mzhBtnStop.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.mzhBtnStop.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.mzhBtnStop.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.mzhBtnStop.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.mzhBtnStop.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mzhBtnStop.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mzhBtnStop.FadingSpeed = 36;
            this.mzhBtnStop.FlatAppearance.BorderSize = 0;
            this.mzhBtnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mzhBtnStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mzhBtnStop.GroupPos = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_groupPos.Center;
            this.mzhBtnStop.Image = global::Shmzh.Monitor.Main.Properties.Resources.pause;
            this.mzhBtnStop.ImageLocation = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_imagelocation.Left;
            this.mzhBtnStop.ImageOffset = 0;
            this.mzhBtnStop.IsPressed = false;
            this.mzhBtnStop.KeepPress = false;
            this.mzhBtnStop.Location = new System.Drawing.Point(77, 1);
            this.mzhBtnStop.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.mzhBtnStop.MaxImageSize = new System.Drawing.Point(0, 0);
            this.mzhBtnStop.MenuPos = new System.Drawing.Point(0, 0);
            this.mzhBtnStop.Name = "mzhBtnStop";
            this.mzhBtnStop.Radius = 8;
            this.mzhBtnStop.ShowBase = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_showbase.Yes;
            this.mzhBtnStop.Size = new System.Drawing.Size(38, 38);
            this.mzhBtnStop.SplitButton = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_splitbutton.No;
            this.mzhBtnStop.SplitDistance = 0;
            this.mzhBtnStop.TabIndex = 10;
            this.mzhBtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.mzhBtnStop.Title = "";
            this.toolTip1.SetToolTip(this.mzhBtnStop, "点击暂停  (空格)");
            this.mzhBtnStop.UseVisualStyleBackColor = true;
            this.mzhBtnStop.MouseLeave += new System.EventHandler(this.mzhBtnMain_MouseLeave);
            this.mzhBtnStop.Click += new System.EventHandler(this.mzhBtnStop_Click);
            this.mzhBtnStop.MouseEnter += new System.EventHandler(this.mzhBtnMain_MouseEnter);
            // 
            // mzhBtnMain
            // 
            this.mzhBtnMain.Arrow = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_arrow.None;
            this.mzhBtnMain.AutoSize = true;
            this.mzhBtnMain.BackColor = System.Drawing.Color.Transparent;
            this.mzhBtnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mzhBtnMain.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.mzhBtnMain.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.mzhBtnMain.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.mzhBtnMain.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.mzhBtnMain.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mzhBtnMain.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mzhBtnMain.FadingSpeed = 36;
            this.mzhBtnMain.FlatAppearance.BorderSize = 0;
            this.mzhBtnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mzhBtnMain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mzhBtnMain.GroupPos = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_groupPos.Left;
            this.mzhBtnMain.Image = global::Shmzh.Monitor.Main.Properties.Resources.main;
            this.mzhBtnMain.ImageLocation = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_imagelocation.Left;
            this.mzhBtnMain.ImageOffset = 0;
            this.mzhBtnMain.IsPressed = false;
            this.mzhBtnMain.KeepPress = false;
            this.mzhBtnMain.Location = new System.Drawing.Point(1, 1);
            this.mzhBtnMain.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.mzhBtnMain.MaxImageSize = new System.Drawing.Point(0, 0);
            this.mzhBtnMain.MenuPos = new System.Drawing.Point(0, 0);
            this.mzhBtnMain.Name = "mzhBtnMain";
            this.mzhBtnMain.Radius = 8;
            this.mzhBtnMain.ShowBase = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_showbase.Yes;
            this.mzhBtnMain.Size = new System.Drawing.Size(38, 38);
            this.mzhBtnMain.SplitButton = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_splitbutton.No;
            this.mzhBtnMain.SplitDistance = 0;
            this.mzhBtnMain.TabIndex = 9;
            this.mzhBtnMain.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.mzhBtnMain.Title = "";
            this.toolTip1.SetToolTip(this.mzhBtnMain, "主菜单");
            this.mzhBtnMain.UseVisualStyleBackColor = true;
            this.mzhBtnMain.MouseLeave += new System.EventHandler(this.mzhBtnMain_MouseLeave);
            this.mzhBtnMain.Click += new System.EventHandler(this.mzhBtnMain_Click);
            this.mzhBtnMain.MouseEnter += new System.EventHandler(this.mzhBtnMain_MouseEnter);
            // 
            // mzhBtnPre
            // 
            this.mzhBtnPre.Arrow = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_arrow.None;
            this.mzhBtnPre.AutoSize = true;
            this.mzhBtnPre.BackColor = System.Drawing.Color.Transparent;
            this.mzhBtnPre.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.mzhBtnPre.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.mzhBtnPre.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.mzhBtnPre.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.mzhBtnPre.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mzhBtnPre.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mzhBtnPre.FadingSpeed = 36;
            this.mzhBtnPre.FlatAppearance.BorderSize = 0;
            this.mzhBtnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mzhBtnPre.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mzhBtnPre.GroupPos = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_groupPos.Center;
            this.mzhBtnPre.Image = global::Shmzh.Monitor.Main.Properties.Resources.previous;
            this.mzhBtnPre.ImageLocation = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_imagelocation.Left;
            this.mzhBtnPre.ImageOffset = 0;
            this.mzhBtnPre.IsPressed = false;
            this.mzhBtnPre.KeepPress = false;
            this.mzhBtnPre.Location = new System.Drawing.Point(39, 1);
            this.mzhBtnPre.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.mzhBtnPre.MaxImageSize = new System.Drawing.Point(0, 0);
            this.mzhBtnPre.MenuPos = new System.Drawing.Point(0, 0);
            this.mzhBtnPre.Name = "mzhBtnPre";
            this.mzhBtnPre.Radius = 8;
            this.mzhBtnPre.ShowBase = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_showbase.Yes;
            this.mzhBtnPre.Size = new System.Drawing.Size(38, 38);
            this.mzhBtnPre.SplitButton = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_splitbutton.No;
            this.mzhBtnPre.SplitDistance = 0;
            this.mzhBtnPre.TabIndex = 8;
            this.mzhBtnPre.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.mzhBtnPre.Title = "";
            this.toolTip1.SetToolTip(this.mzhBtnPre, "上一个  (Page Up)");
            this.mzhBtnPre.UseVisualStyleBackColor = true;
            this.mzhBtnPre.MouseLeave += new System.EventHandler(this.mzhBtnMain_MouseLeave);
            this.mzhBtnPre.Click += new System.EventHandler(this.mzhBtnPre_Click);
            this.mzhBtnPre.MouseEnter += new System.EventHandler(this.mzhBtnMain_MouseEnter);
            // 
            // mzhBtnNext
            // 
            this.mzhBtnNext.Arrow = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_arrow.None;
            this.mzhBtnNext.AutoSize = true;
            this.mzhBtnNext.BackColor = System.Drawing.Color.Transparent;
            this.mzhBtnNext.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.mzhBtnNext.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.mzhBtnNext.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.mzhBtnNext.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.mzhBtnNext.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mzhBtnNext.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mzhBtnNext.FadingSpeed = 36;
            this.mzhBtnNext.FlatAppearance.BorderSize = 0;
            this.mzhBtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mzhBtnNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mzhBtnNext.GroupPos = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_groupPos.Right;
            this.mzhBtnNext.Image = global::Shmzh.Monitor.Main.Properties.Resources.next;
            this.mzhBtnNext.ImageLocation = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_imagelocation.Left;
            this.mzhBtnNext.ImageOffset = 0;
            this.mzhBtnNext.IsPressed = false;
            this.mzhBtnNext.KeepPress = false;
            this.mzhBtnNext.Location = new System.Drawing.Point(115, 1);
            this.mzhBtnNext.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.mzhBtnNext.MaxImageSize = new System.Drawing.Point(0, 0);
            this.mzhBtnNext.MenuPos = new System.Drawing.Point(0, 0);
            this.mzhBtnNext.Name = "mzhBtnNext";
            this.mzhBtnNext.Radius = 8;
            this.mzhBtnNext.ShowBase = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_showbase.Yes;
            this.mzhBtnNext.Size = new System.Drawing.Size(38, 38);
            this.mzhBtnNext.SplitButton = Shmzh.Windows.Forms.MzhRibbonMenuButton.e_splitbutton.No;
            this.mzhBtnNext.SplitDistance = 0;
            this.mzhBtnNext.TabIndex = 7;
            this.mzhBtnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.mzhBtnNext.Title = "";
            this.toolTip1.SetToolTip(this.mzhBtnNext, "下一个  (Page Down)");
            this.mzhBtnNext.UseVisualStyleBackColor = true;
            this.mzhBtnNext.MouseLeave += new System.EventHandler(this.panelMenu_MouseLeave);
            this.mzhBtnNext.Click += new System.EventHandler(this.mzhBtnNext_Click);
            this.mzhBtnNext.MouseEnter += new System.EventHandler(this.mzhBtnMain_MouseEnter);
            // 
            // timerToolbar
            // 
            this.timerToolbar.Interval = 3000;
            this.timerToolbar.Tick += new System.EventHandler(this.timerToolbar_Tick);
            // 
            // menuPlayStop
            // 
            this.menuPlayStop.Name = "menuPlayStop";
            this.menuPlayStop.Size = new System.Drawing.Size(165, 22);
            this.menuPlayStop.Text = "暂  停     空格";
            this.menuPlayStop.Click += new System.EventHandler(this.menuPlayStop_Click);
            // 
            // menuItemPre
            // 
            this.menuItemPre.Name = "menuItemPre";
            this.menuItemPre.Size = new System.Drawing.Size(165, 22);
            this.menuItemPre.Text = "上一个   Page Up";
            this.menuItemPre.Click += new System.EventHandler(this.menuItemPre_Click);
            // 
            // menuItemNext
            // 
            this.menuItemNext.Name = "menuItemNext";
            this.menuItemNext.Size = new System.Drawing.Size(165, 22);
            this.menuItemNext.Text = "下一个   Page Down";
            this.menuItemNext.Click += new System.EventHandler(this.menuItemNext_Click);
            // 
            // menuFullScreen
            // 
            this.menuFullScreen.Name = "menuFullScreen";
            this.menuFullScreen.Size = new System.Drawing.Size(165, 22);
            this.menuFullScreen.Text = "全屏显示 Ctrl+Enter";
            this.menuFullScreen.Click += new System.EventHandler(this.menuFullScreen_Click);
            // 
            // menuItemGoto
            // 
            this.menuItemGoto.Name = "menuItemGoto";
            this.menuItemGoto.Size = new System.Drawing.Size(165, 22);
            this.menuItemGoto.Text = "转  到";
            // 
            // cMenuStrip
            // 
            this.cMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogoff,
            this.menuLogin,
            this.menuConfig,
            this.menuTagSearch,
            this.toolStripSeparator1,
            this.menuUpgrade,
            this.menuExit,
            this.menuRefresh,
            this.menuPlayStop,
            this.menuItemPre,
            this.menuItemNext,
            this.menuItemHome,
            this.menuItemEnd,
            this.menuFullScreen,
            this.menuItemGoto});
            this.cMenuStrip.Name = "cMenuStrip";
            this.cMenuStrip.ShowImageMargin = false;
            this.cMenuStrip.Size = new System.Drawing.Size(166, 340);
            this.cMenuStrip.VisibleChanged += new System.EventHandler(this.cMenuStrip_VisibleChanged);
            // 
            // menuLogoff
            // 
            this.menuLogoff.Name = "menuLogoff";
            this.menuLogoff.Size = new System.Drawing.Size(165, 22);
            this.menuLogoff.Text = "退  出";
            this.menuLogoff.Visible = false;
            this.menuLogoff.Click += new System.EventHandler(this.menuLogoff_Click);
            // 
            // menuLogin
            // 
            this.menuLogin.Name = "menuLogin";
            this.menuLogin.Size = new System.Drawing.Size(165, 22);
            this.menuLogin.Text = "登  录";
            this.menuLogin.Visible = false;
            this.menuLogin.Click += new System.EventHandler(this.menuLogin_Click);
            // 
            // menuConfig
            // 
            this.menuConfig.Name = "menuConfig";
            this.menuConfig.Size = new System.Drawing.Size(165, 22);
            this.menuConfig.Text = "配  置";
            this.menuConfig.Click += new System.EventHandler(this.menuConfig_Click);
            // 
            // menuTagSearch
            // 
            this.menuTagSearch.Name = "menuTagSearch";
            this.menuTagSearch.Size = new System.Drawing.Size(165, 22);
            this.menuTagSearch.Text = "指标查询";
            this.menuTagSearch.Visible = false;
            this.menuTagSearch.Click += new System.EventHandler(this.menuTagSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // menuUpgrade
            // 
            this.menuUpgrade.Name = "menuUpgrade";
            this.menuUpgrade.Size = new System.Drawing.Size(165, 22);
            this.menuUpgrade.Text = "在线升级";
            this.menuUpgrade.Click += new System.EventHandler(this.menuUpgrade_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(165, 22);
            this.menuExit.Text = "关  闭    Esc";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(165, 22);
            this.menuRefresh.Text = "刷  新    F5";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // menuItemHome
            // 
            this.menuItemHome.Name = "menuItemHome";
            this.menuItemHome.Size = new System.Drawing.Size(165, 22);
            this.menuItemHome.Text = "第一个   Home";
            this.menuItemHome.Click += new System.EventHandler(this.menuItemHome_Click);
            // 
            // menuItemEnd
            // 
            this.menuItemEnd.Name = "menuItemEnd";
            this.menuItemEnd.Size = new System.Drawing.Size(165, 22);
            this.menuItemEnd.Text = "最后一个 End";
            this.menuItemEnd.Click += new System.EventHandler(this.menuItemEnd_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 253);
            this.Controls.Add(this.panelMain);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(300, 240);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产监控";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.cMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMenu;
        private Shmzh.Windows.Forms.MzhRibbonMenuButton mzhBtnNext;
        private Shmzh.Windows.Forms.MzhRibbonMenuButton mzhBtnMain;
        private Shmzh.Windows.Forms.MzhRibbonMenuButton mzhBtnPre;
        private Shmzh.Windows.Forms.MzhRibbonMenuButton mzhBtnStop;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerToolbar;
        private System.Windows.Forms.ToolStripMenuItem menuPlayStop;
        private System.Windows.Forms.ToolStripMenuItem menuItemPre;
        private System.Windows.Forms.ToolStripMenuItem menuItemNext;
        private System.Windows.Forms.ToolStripMenuItem menuFullScreen;
        private System.Windows.Forms.ToolStripMenuItem menuItemGoto;
        private System.Windows.Forms.ContextMenuStrip cMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuLogin;
        private System.Windows.Forms.ToolStripMenuItem menuLogoff;
        private System.Windows.Forms.ToolStripMenuItem menuItemHome;
        private System.Windows.Forms.ToolStripMenuItem menuItemEnd;
        private System.Windows.Forms.Label lblPostion;
        private System.Windows.Forms.ToolStripMenuItem menuUpgrade;
        private System.Windows.Forms.ToolStripMenuItem menuConfig;
        private System.Windows.Forms.ToolStripMenuItem menuTagSearch;
    }
}