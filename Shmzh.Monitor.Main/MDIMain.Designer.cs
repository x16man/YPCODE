namespace Shmzh.Monitor.Main
{
    partial class MDIMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTagSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTagCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSortTags = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGraphSchemaConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuickGraphSchema = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMonitorObjConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTagAndTemperature = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolsMenu,
            this.windowsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(736, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.toolStripSeparator5,
            this.menuLogout,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(59, 20);
            this.fileMenu.Text = "文件(&F)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(174, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveToolStripMenuItem.Text = "保存方案(&S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(174, 6);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(177, 22);
            this.menuLogout.Text = "注销";
            this.menuLogout.ToolTipText = "退出系统并重新登录";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exitToolStripMenuItem.Text = "退出(&X)";
            this.exitToolStripMenuItem.ToolTipText = "退出系统";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTagSearch,
            this.menuTagCategory,
            this.menuSortTags,
            this.menuCategory,
            this.menuGraphSchemaConfig,
            this.menuQuickGraphSchema,
            this.menuMonitorObjConfig,
            this.menuTagAndTemperature});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(59, 20);
            this.toolsMenu.Text = "维护(&T)";
            // 
            // menuTagSearch
            // 
            this.menuTagSearch.Name = "menuTagSearch";
            this.menuTagSearch.Size = new System.Drawing.Size(238, 22);
            this.menuTagSearch.Text = "指标查询";
            this.menuTagSearch.Click += new System.EventHandler(this.menuTagSearch_Click);
            // 
            // menuTagCategory
            // 
            this.menuTagCategory.Name = "menuTagCategory";
            this.menuTagCategory.Size = new System.Drawing.Size(238, 22);
            this.menuTagCategory.Text = "指标类别管理(已删)";
            this.menuTagCategory.Visible = false;
            this.menuTagCategory.Click += new System.EventHandler(this.menuTagCategory_Click);
            // 
            // menuSortTags
            // 
            this.menuSortTags.Name = "menuSortTags";
            this.menuSortTags.Size = new System.Drawing.Size(238, 22);
            this.menuSortTags.Text = "指标类别管理";
            this.menuSortTags.Click += new System.EventHandler(this.menuSortTags_Click);
            // 
            // menuCategory
            // 
            this.menuCategory.Name = "menuCategory";
            this.menuCategory.Size = new System.Drawing.Size(238, 22);
            this.menuCategory.Text = "方案类别管理";
            this.menuCategory.Click += new System.EventHandler(this.menuCategory_Click);
            // 
            // menuGraphSchemaConfig
            // 
            this.menuGraphSchemaConfig.Name = "menuGraphSchemaConfig";
            this.menuGraphSchemaConfig.Size = new System.Drawing.Size(238, 22);
            this.menuGraphSchemaConfig.Text = "曲线图配置";
            this.menuGraphSchemaConfig.Click += new System.EventHandler(this.menuGraphSchemaConfig_Click);
            // 
            // menuQuickGraphSchema
            // 
            this.menuQuickGraphSchema.Name = "menuQuickGraphSchema";
            this.menuQuickGraphSchema.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.menuQuickGraphSchema.Size = new System.Drawing.Size(238, 22);
            this.menuQuickGraphSchema.Text = "快速生成指标曲线方案";
            this.menuQuickGraphSchema.Click += new System.EventHandler(this.menuQuickGraphSchema_Click);
            // 
            // menuMonitorObjConfig
            // 
            this.menuMonitorObjConfig.Name = "menuMonitorObjConfig";
            this.menuMonitorObjConfig.Size = new System.Drawing.Size(238, 22);
            this.menuMonitorObjConfig.Text = "监控对象设置";
            this.menuMonitorObjConfig.Click += new System.EventHandler(this.menuMonitorObjConfig_Click);
            // 
            // menuTagAndTemperature
            // 
            this.menuTagAndTemperature.Name = "menuTagAndTemperature";
            this.menuTagAndTemperature.Size = new System.Drawing.Size(238, 22);
            this.menuTagAndTemperature.Text = "气温、总出厂水与指标关系查询";
            this.menuTagAndTemperature.Click += new System.EventHandler(this.menuTagAndTemperature_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(59, 20);
            this.windowsMenu.Text = "窗口(&W)";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.cascadeToolStripMenuItem.Text = "层叠(&C)";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.tileVerticalToolStripMenuItem.Text = "垂直平铺(&V)";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.tileHorizontalToolStripMenuItem.Text = "水平平铺(&H)";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.closeAllToolStripMenuItem.Text = "全部关闭(&L)";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUpgrade});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(59, 20);
            this.helpMenu.Text = "帮助(&H)";
            // 
            // menuUpgrade
            // 
            this.menuUpgrade.Name = "menuUpgrade";
            this.menuUpgrade.Size = new System.Drawing.Size(118, 22);
            this.menuUpgrade.Text = "在线升级";
            this.menuUpgrade.Click += new System.EventHandler(this.menuUpgrade_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 467);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(736, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            this.statusStrip.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabel.Text = "状态";
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(736, 489);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIMain";
            this.Text = "工程师分析平台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.MDIMain_MdiChildActivate);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem menuTagSearch;
        private System.Windows.Forms.ToolStripMenuItem menuGraphSchemaConfig;
        private System.Windows.Forms.ToolStripMenuItem menuMonitorObjConfig;
        private System.Windows.Forms.ToolStripMenuItem menuCategory;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuTagCategory;
        private System.Windows.Forms.ToolStripMenuItem menuSortTags;
        private System.Windows.Forms.ToolStripMenuItem menuQuickGraphSchema;
        private System.Windows.Forms.ToolStripMenuItem menuTagAndTemperature;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem menuUpgrade;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
    }
}



