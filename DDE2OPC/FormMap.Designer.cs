namespace DDE2OPC
{
    partial class FormMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMap));
            this.menuStrip_Map = new System.Windows.Forms.MenuStrip();
            this.映射关系MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Map = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Update = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.statusBar_Map = new System.Windows.Forms.StatusBar();
            this.statusBarPanel_Status = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_RequestTime = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_ErrorCount = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_ConnectionStatus = new System.Windows.Forms.StatusBarPanel();
            this.listView_Map = new System.Windows.Forms.ListView();
            this.menuStrip_Map.SuspendLayout();
            this.toolStrip_Map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_RequestTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_ErrorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_ConnectionStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_Map
            // 
            this.menuStrip_Map.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.映射关系MToolStripMenuItem});
            this.menuStrip_Map.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Map.Name = "menuStrip_Map";
            this.menuStrip_Map.Size = new System.Drawing.Size(468, 24);
            this.menuStrip_Map.TabIndex = 0;
            this.menuStrip_Map.Text = "menuStrip1";
            // 
            // 映射关系MToolStripMenuItem
            // 
            this.映射关系MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_New,
            this.ToolStripMenuItem_Update,
            this.ToolStripMenuItem_Delete,
            this.toolStripMenuItem1,
            this.ToolStripMenuItem_Close});
            this.映射关系MToolStripMenuItem.Name = "映射关系MToolStripMenuItem";
            this.映射关系MToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.映射关系MToolStripMenuItem.Text = "映射关系(&M)";
            // 
            // ToolStripMenuItem_New
            // 
            this.ToolStripMenuItem_New.Name = "ToolStripMenuItem_New";
            this.ToolStripMenuItem_New.ShortcutKeyDisplayString = "";
            this.ToolStripMenuItem_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.ToolStripMenuItem_New.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItem_New.Text = "新建(&N)";
            this.ToolStripMenuItem_New.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // ToolStripMenuItem_Update
            // 
            this.ToolStripMenuItem_Update.Name = "ToolStripMenuItem_Update";
            this.ToolStripMenuItem_Update.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.ToolStripMenuItem_Update.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItem_Update.Text = "修改(&U)";
            this.ToolStripMenuItem_Update.Click += new System.EventHandler(this.toolStripButton_Update_Click);
            // 
            // ToolStripMenuItem_Delete
            // 
            this.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete";
            this.ToolStripMenuItem_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ToolStripMenuItem_Delete.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItem_Delete.Text = "删除(&D)";
            this.ToolStripMenuItem_Delete.Click += new System.EventHandler(this.toolStripButton_Delete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // ToolStripMenuItem_Close
            // 
            this.ToolStripMenuItem_Close.Name = "ToolStripMenuItem_Close";
            this.ToolStripMenuItem_Close.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItem_Close.Text = "关闭(&X)";
            this.ToolStripMenuItem_Close.Click += new System.EventHandler(this.ToolStripMenuItem_Close_Click);
            // 
            // toolStrip_Map
            // 
            this.toolStrip_Map.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Update,
            this.toolStripButton_Delete});
            this.toolStrip_Map.Location = new System.Drawing.Point(0, 24);
            this.toolStrip_Map.Name = "toolStrip_Map";
            this.toolStrip_Map.Size = new System.Drawing.Size(468, 25);
            this.toolStrip_Map.TabIndex = 1;
            this.toolStrip_Map.Text = "toolStrip1";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Add.Image")));
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(121, 22);
            this.toolStripButton_Add.Text = "toolStripButton1";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Update
            // 
            this.toolStripButton_Update.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Update.Image")));
            this.toolStripButton_Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Update.Name = "toolStripButton_Update";
            this.toolStripButton_Update.Size = new System.Drawing.Size(121, 22);
            this.toolStripButton_Update.Text = "toolStripButton1";
            this.toolStripButton_Update.Click += new System.EventHandler(this.toolStripButton_Update_Click);
            // 
            // toolStripButton_Delete
            // 
            this.toolStripButton_Delete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Delete.Image")));
            this.toolStripButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Delete.Name = "toolStripButton_Delete";
            this.toolStripButton_Delete.Size = new System.Drawing.Size(121, 22);
            this.toolStripButton_Delete.Text = "toolStripButton2";
            this.toolStripButton_Delete.Click += new System.EventHandler(this.toolStripButton_Delete_Click);
            // 
            // statusBar_Map
            // 
            this.statusBar_Map.Location = new System.Drawing.Point(0, 404);
            this.statusBar_Map.Name = "statusBar_Map";
            this.statusBar_Map.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel_Status,
            this.statusBarPanel_RequestTime,
            this.statusBarPanel_ErrorCount,
            this.statusBarPanel_ConnectionStatus});
            this.statusBar_Map.ShowPanels = true;
            this.statusBar_Map.Size = new System.Drawing.Size(468, 22);
            this.statusBar_Map.TabIndex = 14;
            this.statusBar_Map.Text = "statusBar1";
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
            this.statusBarPanel_ConnectionStatus.Width = 151;
            // 
            // listView_Map
            // 
            this.listView_Map.Location = new System.Drawing.Point(54, 86);
            this.listView_Map.Name = "listView_Map";
            this.listView_Map.Size = new System.Drawing.Size(121, 97);
            this.listView_Map.TabIndex = 15;
            this.listView_Map.UseCompatibleStateImageBehavior = false;
            this.listView_Map.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_Map_MouseDoubleClick);
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 426);
            this.Controls.Add(this.listView_Map);
            this.Controls.Add(this.statusBar_Map);
            this.Controls.Add(this.toolStrip_Map);
            this.Controls.Add(this.menuStrip_Map);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip_Map;
            this.Name = "FormMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DDE&OPC-映射关系";
            this.Load += new System.EventHandler(this.FormMap_Load);
            this.menuStrip_Map.ResumeLayout(false);
            this.menuStrip_Map.PerformLayout();
            this.toolStrip_Map.ResumeLayout(false);
            this.toolStrip_Map.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_RequestTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_ErrorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_ConnectionStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_Map;
        private System.Windows.Forms.ToolStrip toolStrip_Map;
        private System.Windows.Forms.StatusBar statusBar_Map;
        private System.Windows.Forms.StatusBarPanel statusBarPanel_Status;
        private System.Windows.Forms.StatusBarPanel statusBarPanel_RequestTime;
        private System.Windows.Forms.StatusBarPanel statusBarPanel_ErrorCount;
        private System.Windows.Forms.StatusBarPanel statusBarPanel_ConnectionStatus;
        private System.Windows.Forms.ListView listView_Map;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Update;
        private System.Windows.Forms.ToolStripButton toolStripButton_Delete;
        private System.Windows.Forms.ToolStripMenuItem 映射关系MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_New;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Update;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Close;
    }
}

