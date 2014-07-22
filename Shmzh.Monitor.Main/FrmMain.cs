using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;
using Shmzh.Components.FormLibrary;
using Shmzh.Monitor.Forms;
using Shmzh.Monitor.Forms.Setting;
using Shmzh.Monitor.Gadget;
using Shmzh.Windows.Forms;

namespace Shmzh.Monitor.Main
{
    public partial class FrmMain : Form
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ConfigInfo configInfo;
        private Assembly assembly;
        private Timer timerShow = new Timer();
        private System.Timers.Timer timerState;
        /// <summary>
        /// 上个画面的Form。
        /// </summary>
        private Form preForm;
        /// <summary>
        /// 上个画面的相关信息。
        /// </summary>
        private ConfigInfo.ItemInfo preConfigItemInfo;
        /// <summary>
        /// 数据加载状态。
        /// </summary>
        private LoadState preLoadState;
        private FormWindowState formWindowState;
        private delegate void ParmDelegate(Object obj);

        protected bool _isShowPostion = true;

        private static FrmMain frmMain;
        
        #endregion

        public FrmMain()
        {
            ToolTipHandler tHandler = new ToolTipHandler();
            tHandler.Show("生产监控程序启动中,请稍候...", Screen.PrimaryScreen.WorkingArea);

            InitializeComponent();
            this._isShowPostion = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsShowCursorPosition"]);
            if (this._isShowPostion)
            {
                Gma.UserActivityMonitor.HookManager.MouseMove += HookManager_MouseMove;
                this.lblPostion.Visible = true;
            }
            else
            {
                this.lblPostion.Visible = false;
            }

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.BackColor = Color.Transparent;

            //this.WindowState = FormWindowState.Maximized;

            configInfo = LoadConfig();
            assembly = Assembly.LoadFrom(Path.Combine(Application.StartupPath, configInfo.AssemblyFile));

            Shmzh.Monitor.Gadget.ConfigImages.LoadAllImages();
            System.Diagnostics.Process.GetCurrentProcess().MinWorkingSet = new IntPtr(5);

            tHandler.Close();

            frmMain = this;
        }

        private void timerState_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (preForm == null || !(preForm is ILoadState) || preForm.IsDisposed) return;
            ILoadState iLoadState = preForm as ILoadState;
            var state = iLoadState.GetLoadState();
            if (preLoadState == state) return;
            preLoadState = state;
            switch (state)
            {
                case LoadState.Loading:
                    SetLoadState("正在加载数据...");
                    break;
                case LoadState.Finished:
                    SetLoadState("加载数据完成。");
                    break;
                case LoadState.Stopped:
                    SetLoadState("停止加载数据。");
                    break;
                default :
                    SetLoadState(String.Empty);
                    break;
            }
        }

        /// <summary>
        /// 设置当前装载数据状态。
        /// </summary>
        /// <param name="text"></param>
        private void SetLoadState(Object text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ParmDelegate(SetLoadState), text);
            }
            else
            {
                String strText = text.ToString();
                if (String.IsNullOrEmpty(strText))
                {
                    this.Text = preConfigItemInfo.Title;
                }
                else
                {
                    this.Text = String.Format("{0} -- {1}", preConfigItemInfo.Title, text);
                }
            }
        }

        #region Property
        private Int32 CurrentIndex { get; set; }

        /// <summary>
        /// 获取主窗口的单件实例。
        /// </summary>
        public static FrmMain Instance 
        {
            get { return frmMain; }
        }
        #endregion
        
        #region 显示时给绘出。
        private void FrmMain_Load(object sender, EventArgs e)
        {
            timerShow.Tick += timerShow_Tick;
            //只有一幅图时，不进行画面切换。
            if (configInfo.ConfigList.Count > 1)
            {
                timerShow.Start();
            }
            else
            {
                timerShow.Stop();
                this.toolTip1.SetToolTip(this.mzhBtnStop, "仅有一幅图，此按钮不可用。");
            }

            this.HideToolBarByTimer();
            //this.ToggleMenuByLogin(false);
            
            //刷新取数据状态的计时器。
            timerState = new System.Timers.Timer();
            timerState.AutoReset = true;
            timerState.Interval = 200;
            timerState.Elapsed += new System.Timers.ElapsedEventHandler(timerState_Elapsed);
            timerState.Start();

            if(configInfo.ConfigList.Count > 0)
                ShowByIndex(0);
        }

        /// <summary>
        /// 显示指定项。
        /// </summary>
        /// <param name="idx">索引。</param>
        private void ShowByIndex(Int32 idx)
        {
            Boolean enabled = timerShow.Enabled;
            timerShow.Stop();

            ConfigInfo.ItemInfo configItemInfo = configInfo.ConfigList[idx];
            preConfigItemInfo = configItemInfo;

            //显示状态窗口。
            ToolTipHandler tHandler = new ToolTipHandler();
            tHandler.Show(String.Format("[{0}]\n加载中，请稍候...", configItemInfo.Title), this.Bounds);
            //显示状态窗口。

            CurrentIndex = idx;
            Form form = null;
            if (configItemInfo.ClassName.EndsWith("FrmProcessFlowsheet") || configItemInfo.ClassName.EndsWith("FrmDailyTask") ||
                configItemInfo.ClassName.EndsWith("FrmWebBrowser"))
            {
                try
                {
                    var type = assembly.GetType(configItemInfo.ClassName);
                    form = Activator.CreateInstance(type, new object[] { configItemInfo.ConfigFile, configItemInfo.UpdateTime }) as Form;
                }
                catch (Exception ex)
                {
                    tHandler.Close();//隐藏状态窗口。
                    Logger.Error(ex.Message, ex);
                }
            }
            else if (configItemInfo.ClassName.EndsWith("FrmGraphSchemaStage"))
            {
                var obj = Shmzh.Monitor.Data.DataProvider.GraphSchemaProvider.GetByName(configItemInfo.ConfigFile);
                if (obj == null || !obj.IsValid)
                {
                    Logger.Error(String.Format("曲线方案[{0}]" + (obj == null ? "不存在。" : "无效。"), configItemInfo.ConfigFile));
                    tHandler.Close();//隐藏状态窗口。
                    this.ShowNext();
                    return;
                }
                try
                {
                    var type = assembly.GetType(configItemInfo.ClassName);
                    form = Activator.CreateInstance(type, new object[] { configItemInfo.ConfigFile, configItemInfo.UpdateTime }) as Form;
                }
                catch (Exception ex)
                {
                    tHandler.Close();//隐藏状态窗口。
                    Logger.Error(ex.Message, ex);
                }
            }
            timerShow.Interval = configItemInfo.ShowTime * 1000;
            if (form != null)
            {
                preLoadState = LoadState.Unknown;
                form.FormBorderStyle = FormBorderStyle.None;
                form.WindowState = FormWindowState.Maximized;
                form.TopLevel = false;
                form.Location = new Point(0, 0);
                form.Size = ClientSize;
                form.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                form.Visible = true;                
                this.panelMain.Controls.Add(form);
                this.Text = configItemInfo.Title;

                if (preForm != null)
                {
                    panelMain.Controls.Remove(preForm);
                    preForm.WindowState = FormWindowState.Minimized;
                    preForm.Dispose();
                    //preForm.Close();
                    preForm = null;
                    GC.Collect();
                }
                preForm = form;
            }

            foreach (ToolStripMenuItem item in menuItemGoto.DropDownItems)
            {
                if (item.Checked) item.Checked = false;
            }
            ((ToolStripMenuItem)menuItemGoto.DropDownItems[idx]).Checked = true;

            //CurrentIndex = idx;

            timerShow.Enabled = enabled;

            //隐藏状态窗口。
            tHandler.Close();
            //隐藏状态窗口。

            if (this._isShowPostion)
            {
                this.lblPostion.BringToFront();
            }
            this.Focus();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// 根据 Title 显示对应的Form.
        /// </summary>
        /// <param name="name"></param>
        public void ShowByName(String name)
        {
            for (int i = 0; i < configInfo.ConfigList.Count; i++)
            {
                if (configInfo.ConfigList[i].Title.Equals(name))
                {
                    ShowByIndex(i);
                    break;
                }
            }
        }

        /// <summary>
        /// 立即刷新当前Form.
        /// </summary>
        public void RefreshAtOnce()
        {
            ShowByIndex(CurrentIndex);
        }

        /// <summary>
        /// 主配置文件更改后，刷新主菜单。
        /// </summary>
        public void RefreshMainMenu()
        {
            this.menuItemGoto.DropDownItems.Clear();
            configInfo = LoadConfig();
            if (configInfo.ConfigList.Count > 0)
                this.ShowByIndex(0);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Load Config.
        /// </summary>
        /// <returns></returns>
        private ConfigInfo LoadConfig()
        {
            var configObj = new ConfigInfo();
            var doc = new XmlDocument();
            var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\Config.xml");
            doc.Load(xmlPath);
            configObj.AssemblyFile = doc.DocumentElement.SelectSingleNode("AssemblyFile").Attributes.GetNamedItem("Name").Value;

            XmlNode nodeDebug = doc.DocumentElement.SelectSingleNode("ConfigMode");
            Gadget.Utils.IsDebug = (nodeDebug != null && Convert.ToBoolean(nodeDebug.Attributes.GetNamedItem("Debug").Value));

            ConfigInfo.ItemInfo configItemInfo;
            
            var idx = 0;
            var nodeList = doc.DocumentElement.SelectNodes("Charts/Item");

            foreach (XmlNode node in nodeList)
            {
                var visible = Convert.ToBoolean(node.Attributes.GetNamedItem("Visible").Value);
                if (visible)
                {
                    configItemInfo = new ConfigInfo.ItemInfo {
                        ClassName = node.Attributes.GetNamedItem("ClassName").Value,
                        ConfigFile = node.Attributes.GetNamedItem("ConfigFile").Value,
                        ShowTime = Convert.ToInt32(node.Attributes.GetNamedItem("ShowTime").Value),
                        UpdateTime = Convert.ToInt32(node.Attributes.GetNamedItem("UpdateTime").Value),
                        Title = node.Attributes.GetNamedItem("Title").Value,
                        Visible = visible
                    };
                    configObj.ConfigList.Add(configItemInfo);

                    var menuItem = new ToolStripMenuItem(configItemInfo.Title) { Tag = idx };
                    menuItem.Click += menuItem_Click;
                    this.menuItemGoto.DropDownItems.Add(menuItem);
                    idx++;
                }               
            }
            return configObj;
        }

        /// <summary>
        /// 显示上一个。
        /// </summary>
        private void ShowPrevious()
        {
            Int32 idx = CurrentIndex - 1;
            if (idx < 0) idx = configInfo.ConfigList.Count - 1;
            ShowByIndex(idx);
        }

        /// <summary>
        /// 显示下一个。
        /// </summary>
        private void ShowNext()
        {
            Int32 idx = CurrentIndex + 1;
            if (idx >= configInfo.ConfigList.Count) { idx = 0; }
            ShowByIndex(idx);
        }

        /// <summary>
        /// 切换全屏状态。
        /// </summary>
        private void ToggleFullScreen()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                menuFullScreen.Text = "全屏显示 Ctrl+Enter";
                this.FormBorderStyle = FormBorderStyle.Sizable;
                //因为为最大化状态变为最大化状态，只改变窗口边框样式时，Form大小不变，故先调整为Normal，再转为最大化。
                //if (formWindowState == FormWindowState.Maximized)
                //{
                //    this.WindowState = FormWindowState.Normal;
                //}
                this.WindowState = formWindowState;
            }
            else
            {
                menuFullScreen.Text = "退出全屏 Ctrl+Enter";
                formWindowState = this.WindowState;
                this.FormBorderStyle = FormBorderStyle.None;
                //因为为最大化状态变为最大化状态，只改变窗口边框样式时，Form大小不变，故先调整为Normal，再转为最大化。
                if (formWindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                this.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// 切换ToolBar的显示。
        /// </summary>
        /// <param name="isShow">是否显示。</param>
        private void ToggleToolBar(Boolean isShow)
        {
            if (isShow)
            {
                if(panelMenu.BackgroundImage != null) //不是显示状态。
                {
                    panelMenu.Top = this.ClientRectangle.Height - panelMenu.Height;
                    foreach (Control control in panelMenu.Controls)
                    {
                        control.Visible = true;
                    }
                    panelMenu.Width = 154;
                    panelMenu.BackgroundImage = null;
                }
            }
            else
            {
                if(panelMenu.BackgroundImage == null) //是显示状态。
                {
                    Point point = this.PointToClient(MousePosition);
                    if (!panelMenu.Bounds.Contains(point))
                    {
                        if (!cMenuStrip.Visible)
                        {
                            panelMenu.SuspendLayout();
                            panelMenu.Top = this.ClientRectangle.Height - Properties.Resources.expand.Height;
                            foreach (Control control in panelMenu.Controls)
                            {
                                control.Visible = false;
                            }
                            panelMenu.BackgroundImage = Properties.Resources.expand;
                            panelMenu.Width = Properties.Resources.expand.Width;
                            panelMenu.BackgroundImageLayout = ImageLayout.None;
                            panelMenu.ResumeLayout(false);
                        }
                    }
                }
            }
            if (this.timerToolbar.Enabled) this.timerToolbar.Stop();
        }

        /// <summary>
        /// 切换播放和暂停。
        /// </summary>
        private void TogglePlayStop()
        {
            //只有一幅图时，不进行画面切换。
            if (configInfo.ConfigList.Count <= 1) return;

            if (this.timerShow.Enabled)
            {
                this.mzhBtnStop.Image = Properties.Resources.play;
                this.timerShow.Stop();
                this.menuPlayStop.Text = "播  放    空格";
                this.toolTip1.SetToolTip(this.mzhBtnStop, "点击播放  (空格)");
            }
            else
            {
                this.mzhBtnStop.Image = Properties.Resources.pause;
                this.timerShow.Start();
                this.menuPlayStop.Text = "暂  停    空格";
                this.toolTip1.SetToolTip(this.mzhBtnStop, "点击暂停  (空格)");
            }
        }

        /// <summary>
        /// 延时隐藏ToolBar。
        /// </summary>
        private void HideToolBarByTimer()
        {
            this.timerToolbar.Start();
        }

        /// <summary>
        /// 登录和登出时切换菜单的显示。
        /// </summary>
        /// <param name="isLoginSuccess">是否登录成功。</param>
        private void ToggleMenuByLogin(Boolean isLoginSuccess)
        {
            if (isLoginSuccess)
            {
                //if (Common.CurrentUser.HasRight(Convert.ToInt32(RightType.MonitorObjConfig)))
                //{
                //    this.menuMonitorObjConfig.Visible = true;
                //}
                this.menuLogin.Visible = false;
                this.menuLogoff.Visible = true;
            }
            else
            {
                //this.menuMonitorObjConfig.Visible = false;
                this.menuLogin.Visible = true;
                this.menuLogoff.Visible = false;
            }
        }
        #endregion

        #region 事件处理。
        private void menuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem != null) ShowByIndex(Convert.ToInt32(menuItem.Tag));
        }

        private void timerShow_Tick(object sender, EventArgs e)
        {
            ShowNext();
        }
        
        private void cMenuStrip_VisibleChanged(object sender, EventArgs e)
        {
            if (!cMenuStrip.Visible)
                this.HideToolBarByTimer();
        }

        private void menuItemPre_Click(object sender, EventArgs e)
        {
            ShowPrevious();
        }

        private void menuItemNext_Click(object sender, EventArgs e)
        {
            ShowNext();
        }

        private void menuPlayStop_Click(object sender, EventArgs e)
        {
            this.TogglePlayStop();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                //case Keys.Up:
                //case Keys.Left: 
                //case Keys.Down:
                //case Keys.Right:
                case Keys.PageUp:
                    ShowPrevious();
                    break;
                case Keys.PageDown:
                    ShowNext();
                    break;
                case Keys.Home:
                    if (configInfo.ConfigList.Count > 0)
                        ShowByIndex(0);
                    break;
                case Keys.End:
                    if (configInfo.ConfigList.Count > 0)
                        ShowByIndex(configInfo.ConfigList.Count - 1);
                    break;
                case Keys.Escape:
                    if(this.FormBorderStyle == FormBorderStyle.None)
                    {
                        ToggleFullScreen();
                    }
                    else
                    {
                        if(MessageBox.Show(this, "确定要关闭程序吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    break;
                case Keys.Space:
                    this.ToggleToolBar(true);
                    this.TogglePlayStop();
                    this.HideToolBarByTimer();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            //切换全屏状态
            if (e.Control && e.KeyCode.Equals(Keys.Enter))
            {
                ToggleFullScreen();
            }
            else if (e.KeyCode.Equals(Keys.F5))
            {
                RefreshAtOnce();
            }
        }

        private void mzhBtnMain_Click(object sender, EventArgs e)
        {
            this.cMenuStrip.Show(this.mzhBtnMain, new Point(0,0), ToolStripDropDownDirection.AboveRight);
        }

        private void mzhBtnPre_Click(object sender, EventArgs e)
        {
            ShowPrevious();
        }

        private void mzhBtnNext_Click(object sender, EventArgs e)
        {
            ShowNext();
        }

        private void menuItemHome_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void menuItemEnd_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{END}");
        }

        private void mzhBtnStop_Click(object sender, EventArgs e)
        {
            this.TogglePlayStop();
        }

        private void panelMenu_MouseEnter(object sender, EventArgs e)
        {
            this.ToggleToolBar(true);
        }

        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
            this.HideToolBarByTimer();
        }

        private void menuFullScreen_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void menuTagSearch_Click(object sender, EventArgs e)
        {
            new FrmTagSearch().Show(this);
        }

        private void menuConfig_Click(object sender, EventArgs e)
        {
            new FrmConfig().Show(this);
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            RefreshAtOnce();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void mzhBtnMain_MouseLeave(object sender, EventArgs e)
        {
            //this.ToggleToolBar(false);
            this.HideToolBarByTimer();
        }

        private void mzhBtnMain_MouseEnter(object sender, EventArgs e)
        {
            this.ToggleToolBar(true);
        }

        private void timerToolbar_Tick(object sender, EventArgs e)
        {
            ToggleToolBar(false);
        }

        private void menuLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm {Title = "生产监控系统登录"};
            loginForm.ShowDialog();

            if (loginForm.IsLoginSuccess)
            {
                Common.CurrentUser = loginForm.LoginUser;
                loginForm.Dispose();
                this.ToggleMenuByLogin(true);

                //MessageBox.Show(this, "您已成功登录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuLogoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定要退出登录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Common.CurrentUser = null;
                this.ToggleMenuByLogin(false);
            }
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = PointToClient(e.Location);
            this.lblPostion.Text = String.Format("X={0:0000}; Y={1:0000}", pt.X, pt.Y);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            switch (Program.StartupType)
            {
                case StartupType.FullScreen:
                    ToggleFullScreen();
                    break;
                case StartupType.Maximized:
                    this.WindowState = FormWindowState.Maximized;
                    break;
                case StartupType.Minimized:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case StartupType.Normal:
                    this.WindowState = FormWindowState.Normal;
                    break;
            }
            this.Activate();
        }

        private void menuUpgrade_Click(object sender, EventArgs e)
        {
            String upgradeApp = Path.Combine(Application.StartupPath, @"Upgrade\OnlineUpgrade.exe");
            if (File.Exists(upgradeApp))
            {
                System.Diagnostics.Process.Start(upgradeApp);
            }
            else
            {
                MessageBox.Show(this, "未找到升级程序。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        #endregion

        
    }
   
}
