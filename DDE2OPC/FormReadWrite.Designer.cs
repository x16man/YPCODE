namespace DDE2OPC
{
    partial class FormReadWrite
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
            this.button_ConnectToDDE = new System.Windows.Forms.Button();
            this.button_ConnectToOPCServer = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_WriteToOPC = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_MapConfig = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_OpenWorkStation = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ConnectToDDE
            // 
            this.button_ConnectToDDE.Image = global::DDE2OPC.Properties.Resources.link_go;
            this.button_ConnectToDDE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ConnectToDDE.Location = new System.Drawing.Point(9, 20);
            this.button_ConnectToDDE.Name = "button_ConnectToDDE";
            this.button_ConnectToDDE.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_ConnectToDDE.Size = new System.Drawing.Size(143, 29);
            this.button_ConnectToDDE.TabIndex = 2;
            this.button_ConnectToDDE.Text = "连接 &DDE Server";
            this.button_ConnectToDDE.UseVisualStyleBackColor = true;
            this.button_ConnectToDDE.Click += new System.EventHandler(this.button_ConnectToDDE_Click);
            // 
            // button_ConnectToOPCServer
            // 
            this.button_ConnectToOPCServer.Image = global::DDE2OPC.Properties.Resources.link_go;
            this.button_ConnectToOPCServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ConnectToOPCServer.Location = new System.Drawing.Point(9, 55);
            this.button_ConnectToOPCServer.Name = "button_ConnectToOPCServer";
            this.button_ConnectToOPCServer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_ConnectToOPCServer.Size = new System.Drawing.Size(143, 29);
            this.button_ConnectToOPCServer.TabIndex = 3;
            this.button_ConnectToOPCServer.Text = "连接 &OPC Server";
            this.button_ConnectToOPCServer.UseVisualStyleBackColor = true;
            this.button_ConnectToOPCServer.Click += new System.EventHandler(this.button_ConnectToOPCServer_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Enabled = false;
            this.button_Refresh.Image = global::DDE2OPC.Properties.Resources.control_play;
            this.button_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Refresh.Location = new System.Drawing.Point(9, 125);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_Refresh.Size = new System.Drawing.Size(143, 29);
            this.button_Refresh.TabIndex = 5;
            this.button_Refresh.Text = "&R.刷新界面";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // button_WriteToOPC
            // 
            this.button_WriteToOPC.Enabled = false;
            this.button_WriteToOPC.Image = global::DDE2OPC.Properties.Resources.control_play;
            this.button_WriteToOPC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_WriteToOPC.Location = new System.Drawing.Point(9, 160);
            this.button_WriteToOPC.Name = "button_WriteToOPC";
            this.button_WriteToOPC.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_WriteToOPC.Size = new System.Drawing.Size(143, 29);
            this.button_WriteToOPC.TabIndex = 6;
            this.button_WriteToOPC.Text = "&W.写入OPC";
            this.button_WriteToOPC.UseVisualStyleBackColor = true;
            this.button_WriteToOPC.Click += new System.EventHandler(this.button_WriterToOPC_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 600);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 575);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "实时信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(52, 83);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ConnectToDDE);
            this.groupBox1.Controls.Add(this.button_WriteToOPC);
            this.groupBox1.Controls.Add(this.button_ConnectToOPCServer);
            this.groupBox1.Controls.Add(this.button_Refresh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 600);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_MapConfig});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(818, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_MapConfig
            // 
            this.toolStripButton_MapConfig.Image = global::DDE2OPC.Properties.Resources.tag;
            this.toolStripButton_MapConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_MapConfig.Name = "toolStripButton_MapConfig";
            this.toolStripButton_MapConfig.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton_MapConfig.Text = "映射配置";
            this.toolStripButton_MapConfig.Click += new System.EventHandler(this.toolStripButton_MapConfig_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(818, 600);
            this.splitContainer1.SplitterDistance = 626;
            this.splitContainer1.TabIndex = 9;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_OpenWorkStation,
            this.ToolStripMenuItem_Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // ToolStripMenuItem_OpenWorkStation
            // 
            this.ToolStripMenuItem_OpenWorkStation.Name = "ToolStripMenuItem_OpenWorkStation";
            this.ToolStripMenuItem_OpenWorkStation.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_OpenWorkStation.Text = "打开控制台";
            this.ToolStripMenuItem_OpenWorkStation.Click += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_Exit.Text = "退出";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // FormReadWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 625);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormReadWrite";
            this.Text = "DDE2OPC";
            this.Load += new System.EventHandler(this.FormReadWrite_Load);
            this.SizeChanged += new System.EventHandler(this.FormReadWrite_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReadWrite_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReadWrite_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ConnectToDDE;
        private System.Windows.Forms.Button button_ConnectToOPCServer;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_WriteToOPC;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_MapConfig;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenWorkStation;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
    }
}