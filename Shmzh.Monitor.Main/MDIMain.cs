using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Forms;
using Shmzh.Monitor.Forms.Setting;

namespace Shmzh.Monitor.Main
{
    public partial class MDIMain : Form
    {
        #region Fields
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Assembly assembly = null;
        #endregion

        public MDIMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 生成类别方案菜单。
        /// </summary>
        private void BuildCategorySchemaMenus()
        {
            var isFirstOpened = false;
            if(GlobleVariables.CategoryList.Count == 0) GlobleVariables.RefreshCategoryList();

            //var sw = new Stopwatch();
            //sw.Start();
            
            foreach (var categoryInfo in GlobleVariables.CategoryList)
            {
                if(Common.CurrentUser.HasRight(categoryInfo.RightCode) || categoryInfo.IsPublic)
                {
                    var menuItemTop = new ToolStripMenuItem { Text = categoryInfo.CategoryName, Tag = categoryInfo };
                    this.menuStrip.Items.Insert(this.menuStrip.Items.Count - 2, menuItemTop);

                    var itemList = GlobleVariables.CategoryItemList.FindAll(item => item.CategoryId == categoryInfo.CategoryId);
                    foreach (var item in itemList)
                    {
                        var menuItem = new ToolStripMenuItem { Text = item.Title, Tag = item };
                        menuItem.Click += new EventHandler(menuItem_Click);
                        menuItemTop.DropDownItems.Add(menuItem);

                        if (!isFirstOpened)
                        {
                            isFirstOpened = true;
                            menuItem_Click(menuItem, EventArgs.Empty);
                        }
                    }    
                }
            }
            var menu = new ToolStripMenuItem() {Text = "自定义方案",Name = "CustomerMenu"};
            this.menuStrip.Items.Insert(this.menuStrip.Items.Count - 2, menu);
            var objs = GlobleVariables.GraphSchemaList.FindAll(item => !GlobleVariables.CategoryItemList.Exists(o => o.ConfigFile == item.Name));
            objs = objs.FindAll(item => item.ReferLoginName == Common.CurrentUser.LoginName);
            foreach(var obj in objs)
            {
                var menuItem = new ToolStripMenuItem { Text = obj.Name, Tag = obj };
                menuItem.Click += new EventHandler(menuItem_Click);
                menu.DropDownItems.Add(menuItem);

                if (!isFirstOpened)
                {
                    isFirstOpened = true;
                    menuItem_Click(menuItem, EventArgs.Empty);
                }
            }

            //sw.Stop();
            //Trace.WriteLine(string.Format("BuildCategorySchemaMenus spend {0}ms",sw.ElapsedMilliseconds));
        }

        /// <summary>
        /// 调整类别菜单。
        /// </summary>
        /// <param name="categoryInfo"></param>
        /// <param name="actType"></param>
        public void UpdateCategoryMenu(CategoryInfo categoryInfo, ActionType actType)
        {
            ToolStripMenuItem categoryMenu = null;
            if (actType != ActionType.Add)
            {
                foreach (ToolStripItem item in this.menuStrip.Items)
                {
                    if (item.Tag is CategoryInfo)
                    {
                        var temp = item.Tag as CategoryInfo;
                        if (temp.CategoryId == categoryInfo.CategoryId)
                        {
                            categoryMenu = item as ToolStripMenuItem;
                            break;
                        }
                    }
                }
            }
            switch (actType)
            {
                case ActionType.Add:                   
                    ToolStripMenuItem menuItemTop = new ToolStripMenuItem();
                    menuItemTop.Text = categoryInfo.CategoryName;
                    menuItemTop.Tag = categoryInfo;
                    this.menuStrip.Items.Insert(this.menuStrip.Items.Count - 2, menuItemTop);

                    var itemList = DataProvider.CategoryItemProvider.GetByCategoryId(categoryInfo.CategoryId);
                    foreach (var item in itemList)
                    {
                        ToolStripMenuItem menuItem = new ToolStripMenuItem();
                        menuItem.Text = item.Title;
                        menuItem.Tag = item;
                        menuItem.Click += new EventHandler(menuItem_Click);
                        menuItemTop.DropDownItems.Add(menuItem);
                    }
                    break;
                case ActionType.Edit:
                    if (categoryMenu != null)
                    {
                        categoryMenu.Text = categoryInfo.CategoryName;
                        categoryMenu.Tag = categoryInfo;
                    }
                    break;
                case ActionType.Delete:
                    if (categoryMenu != null)
                        this.menuStrip.Items.Remove(categoryMenu);
                    break;
            }
        }

        /// <summary>
        /// 调整类别方案菜单。
        /// </summary>
        /// <param name="categoryItemInfo"></param>
        /// <param name="actType"></param>
        public void UpdateCategoryItemMenu(CategoryItemInfo categoryItemInfo, ActionType actType)
        {
            //先找出新建或者编辑方案所属类别所对应的菜单项。
            ToolStripMenuItem categoryMenu = null;
            foreach (ToolStripItem item in this.menuStrip.Items)
            {
                if (item.Tag is CategoryInfo)
                {
                    var temp = item.Tag as CategoryInfo;
                    if (temp.CategoryId == categoryItemInfo.CategoryId)
                    {
                        categoryMenu = item as ToolStripMenuItem;
                        break;
                    }
                }
            }
            //如果是编辑或删除，找出菜单中对应的方案项。
            ToolStripMenuItem itemMenu = null;
            if (actType != ActionType.Add && categoryMenu != null)
            {
                foreach (ToolStripMenuItem item in categoryMenu.DropDownItems)
                {
                    CategoryItemInfo temp = item.Tag as CategoryItemInfo;
                    if (temp.ItemId == categoryItemInfo.ItemId)
                    {
                        itemMenu = item;
                        break;
                    }
                }
            }
            switch (actType)
            {
                case ActionType.Add:
                    if (categoryMenu != null)
                    {
                        ToolStripMenuItem menuItem = new ToolStripMenuItem();
                        menuItem.Text = categoryItemInfo.Title;
                        menuItem.Tag = categoryItemInfo;
                        menuItem.Click += new EventHandler(menuItem_Click);
                        categoryMenu.DropDownItems.Add(menuItem);
                    }
                    break;
                case ActionType.Edit:
                    if (itemMenu != null)
                    {
                        itemMenu.Text = categoryItemInfo.Title;
                        itemMenu.Tag = categoryItemInfo;
                    }
                    break;
                case ActionType.Delete:
                    if (itemMenu != null)
                        categoryMenu.DropDownItems.Remove(itemMenu);
                    break;
            }
        }
        public void UpdateCustomerMenu(GraphSchemaInfo obj, ActionType actType)
        {
            var menus = this.menuStrip.Items.Find("CustomerMenu", false);
            if(menus.Length > 0)
            {
                var menuItem = menus[0] as ToolStripMenuItem;
                for(var i=0;i<menuItem.DropDownItems.Count;i++)
                {
                    if(menuItem.DropDownItems[i].Text == obj.Name)
                    {
                        switch(actType)
                        {
                            case ActionType.Add:
                                menuItem.DropDownItems.Add(new ToolStripMenuItem() {Text = obj.Name, Tag = obj});
                                break;
                            case ActionType.Delete:
                                menuItem.DropDownItems.RemoveAt(i);
                                break;
                            case ActionType.Edit:
                                menuItem.DropDownItems[i].Text = obj.Name;
                                menuItem.DropDownItems[i].Tag = obj;
                                break;
                        }
                        
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 初始化菜单.
        /// </summary>
        public void InitMenu()
        {
            this.menuSortTags.Visible = Common.CurrentUser.HasRight(22003);
            this.menuCategory.Visible = Common.CurrentUser.HasRight(22003);
            //this.menuGraphSchemaConfig.Visible = Common.CurrentUser.HasRight(22003);
            this.menuMonitorObjConfig.Visible = Common.CurrentUser.HasRight(22001);
        }
        #region Event Handlers
        private void MDIMain_Load(object sender, EventArgs e)
        {
            this.BuildCategorySchemaMenus();
            this.InitMenu();
        }
        /// <summary>
        /// 显示方案项.
        /// </summary>
        /// <param name="itemInfo"></param>
        public void ShowItem(CategoryItemInfo itemInfo)
        {
            if (assembly == null)
            {
                assembly = Assembly.LoadFrom(Path.Combine(Application.StartupPath, "Shmzh.Monitor.Forms.dll"));
            }
            Form form = null;
            if (itemInfo.ClassName.EndsWith("FrmProcessFlowsheet") || itemInfo.ClassName.EndsWith("FrmDailyTask") ||
                itemInfo.ClassName.EndsWith("FrmWebBrowser") || itemInfo.ClassName.EndsWith("FrmGraphSchemaStage"))
            {
                if (itemInfo.ClassName.EndsWith("FrmGraphSchemaStage"))
                {
                    var obj = Shmzh.Monitor.Data.DataProvider.GraphSchemaProvider.GetByName(itemInfo.ConfigFile);
                    //if (obj == null || !obj.IsValid)
                    if (obj == null)
                    {
                        MessageBox.Show(String.Format("找不到方案[{0}]，可能已被删除，请配置为已经存在的方案！", itemInfo.ConfigFile), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (itemInfo.ConfigFile.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\" + itemInfo.ConfigFile);
                    if (!File.Exists(xmlPath))
                    {
                        MessageBox.Show(String.Format("找不到配置文件[{0}]，请升级程序以获取最新的配置文件！", itemInfo.ConfigFile), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //显示状态窗口。
                var tHandler = new ToolTipHandler();
                tHandler.Parent = this;
                tHandler.Show(String.Format("[{0}]\n正在打开，请稍候...", itemInfo.Title), this.Bounds);
                //显示状态窗口。

                try
                {
                    var type = assembly.GetType(itemInfo.ClassName);
                    form = Activator.CreateInstance(type, new object[] { itemInfo.ConfigFile, itemInfo.UpdateTime }) as Form;
                    form.MdiParent = this;
                    form.Text = itemInfo.Title;
                    form.Show();
                    form.WindowState = FormWindowState.Maximized;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                    MessageBox.Show(String.Format("打开{0}时出错，请检查方案分类配置是否正确。", itemInfo.Title),
                        "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    tHandler.Close();//隐藏状态窗口。
                }
            }
        }
        public void ShowItem(GraphSchemaInfo obj)
        {
            //显示状态窗口。
            var tHandler = new ToolTipHandler();
            tHandler.Parent = this;
            tHandler.Show(String.Format("[{0}]\n正在打开，请稍候...", obj.Name), this.Bounds);
            //显示状态窗口。

            try
            {
                var form = new FrmGraphSchemaStage(obj.Name, Common.GetUpdateTime(obj.DataType)) { MdiParent = this, Text = obj.Name };
                
                form.Show();
                form.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                MessageBox.Show(String.Format("打开{0}时出错，请检查方案分类配置是否正确。", obj.Name),
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                tHandler.Close();//隐藏状态窗口。
            }

                
            
        }
        private void menuItem_Click(object sender, EventArgs e)
        {
            if(sender is ToolStripMenuItem)
            {
                var menuItem = sender as ToolStripMenuItem;
                if(menuItem.Tag is CategoryItemInfo)
                {
                    var itemInfo = menuItem.Tag as CategoryItemInfo;
                    ShowItem(itemInfo);                    
                }
                else if(menuItem.Tag is GraphSchemaInfo)
                {
                    var itemInfo = menuItem.Tag as GraphSchemaInfo;
                    ShowItem(itemInfo);
                }

            }            
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void menuTagSearch_Click(object sender, EventArgs e)
        {
            var form = new FrmTagSearch() { MdiParent = this };
            form.StartPosition = FormStartPosition.CenterParent;
            form.Show();
        }

        private void menuGraphSchemaConfig_Click(object sender, EventArgs e)
        {
            var form = new FrmGraphSchema() { MdiParent = this };
            form.StartPosition = FormStartPosition.CenterParent;
            form.Show();
        }

        private void menuMonitorObjConfig_Click(object sender, EventArgs e)
        {
            var form = new FrmObjTypeAttr() { MdiParent = this };
            form.StartPosition = FormStartPosition.CenterParent;
            form.Show();
        }

        private void menuCategory_Click(object sender, EventArgs e)
        {
            var form = new FrmCategory() { MdiParent = this };
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void menuTagCategory_Click(object sender, EventArgs e)
        {
            var form = new FrmTagCategory() { MdiParent = this };
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        //private void newToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    String[] test = new String[] { "5003001", "1001009", "1106002", "1106003", "1106006" };
        //    FrmGraphSchemaStage form = new FrmGraphSchemaStage(test, null){ MdiParent = this };
        //    form.StartPosition = FormStartPosition.CenterParent;
        //    form.Show();
        //}

        private void MDIMain_MdiChildActivate(object sender, EventArgs e)
        {
            this.saveToolStripMenuItem.Enabled = false;
            if (this.ActiveMdiChild is FrmGraphSchemaStage)
            {
                FrmGraphSchemaStage form = this.ActiveMdiChild as FrmGraphSchemaStage;
                
                if (!form.IsSaved && form.GraphSchemaEntity.SchemaId <= 0)
                {
                    this.saveToolStripMenuItem.Enabled = true;
                }
            }            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is FrmGraphSchemaStage) {
                FrmGraphSchemaStage form = this.ActiveMdiChild as FrmGraphSchemaStage;
                if (!form.IsSaved && form.GraphSchemaEntity.SchemaId <= 0)
                {
                    var frmGraphSchemeEdit = new FrmGraphSchemaEdit(ActionType.Save) {
                        GraphSchemeEntity = form.GraphSchemaEntity
                    };
                    if (frmGraphSchemeEdit.ShowDialog() == DialogResult.OK)
                    {
                        var menu = this.menuStrip.Items.Find("CustomerMenu", false);
                        if(menu.Length > 0 && menu[0] is ToolStripMenuItem)
                        {
                            var menuItem = menu[0] as ToolStripMenuItem;
                            var menuItem1 = new ToolStripMenuItem { Text = form.GraphSchemaEntity.Name, Tag = form.GraphSchemaEntity };
                            menuItem1.Click += new EventHandler(menuItem_Click);
                            menuItem.DropDownItems.Add(menuItem1);
                        }
                        form.IsSaved = true;
                        this.saveToolStripMenuItem.Enabled = false;
                    }
                    frmGraphSchemeEdit.Dispose();
                }
            }
        }

        private void menuSortTags_Click(object sender, EventArgs e)
        {
            var form = new FrmSortTags() { MdiParent = this };
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void menuQuickGraphSchema_Click(object sender, EventArgs e)
        {
            var form = new FrmQuickGraphSchema(this);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            form.Dispose();
        }

        private void menuTagAndTemperature_Click(object sender, EventArgs e)
        {
            var form = new FrmTagAndTemperature() { MdiParent = this };
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
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

        private void menuLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #endregion
    }
}
