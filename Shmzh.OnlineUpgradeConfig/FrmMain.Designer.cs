namespace Shmzh.OnlineUpgradeConfig
{
    partial class FrmMain
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.chkOpposite = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtVersion);
            this.pnlTop.Controls.Add(this.lblVersion);
            this.pnlTop.Controls.Add(this.chkOpposite);
            this.pnlTop.Controls.Add(this.chkAll);
            this.pnlTop.Controls.Add(this.btnSaveAs);
            this.pnlTop.Controls.Add(this.btnSave);
            this.pnlTop.Controls.Add(this.btnOpenFolder);
            this.pnlTop.Controls.Add(this.btnOpenConfig);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(675, 42);
            this.pnlTop.TabIndex = 0;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(166, 11);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(103, 21);
            this.txtVersion.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(128, 15);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(41, 12);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "版本：";
            // 
            // chkOpposite
            // 
            this.chkOpposite.AutoSize = true;
            this.chkOpposite.Location = new System.Drawing.Point(63, 13);
            this.chkOpposite.Name = "chkOpposite";
            this.chkOpposite.Size = new System.Drawing.Size(48, 16);
            this.chkOpposite.TabIndex = 2;
            this.chkOpposite.Text = "反选";
            this.chkOpposite.UseVisualStyleBackColor = true;
            this.chkOpposite.CheckedChanged += new System.EventHandler(this.chkOpposite_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(9, 13);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 1;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Location = new System.Drawing.Point(589, 10);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 7;
            this.btnSaveAs.Text = "另存为";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(502, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(404, 10);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(86, 23);
            this.btnOpenFolder.TabIndex = 5;
            this.btnOpenFolder.Text = "打开文件夹";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(306, 10);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(86, 23);
            this.btnOpenConfig.TabIndex = 4;
            this.btnOpenConfig.Text = "打开配置文件";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Upgrade.config";
            this.openFileDialog1.Filter = "升级配置文件|*.config|所有文件|*.*";
            this.openFileDialog1.Title = "打开升级配置文件";
            // 
            // lvFiles
            // 
            this.lvFiles.CheckBoxes = true;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.GridLines = true;
            this.lvFiles.Location = new System.Drawing.Point(0, 42);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(675, 393);
            this.lvFiles.TabIndex = 1;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件";
            this.columnHeader1.Width = 533;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Upgrade.config";
            this.saveFileDialog1.Filter = "升级配置文件|*.config|所有文件|*.*";
            this.saveFileDialog1.Title = "保存升级配置文件";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 435);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(683, 467);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序升级配置";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnOpenConfig;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkOpposite;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

