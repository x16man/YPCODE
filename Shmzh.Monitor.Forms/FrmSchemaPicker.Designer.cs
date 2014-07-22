namespace Shmzh.Monitor.Forms
{
    partial class FrmSchemaPicker
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
            this.tabCtlMain = new System.Windows.Forms.TabControl();
            this.tabPgGraph = new System.Windows.Forms.TabPage();
            this.tvScheme = new System.Windows.Forms.TreeView();
            this.imgListTV = new System.Windows.Forms.ImageList(this.components);
            this.tabPgXml = new System.Windows.Forms.TabPage();
            this.tvXml = new System.Windows.Forms.TreeView();
            this.tabCtlMain.SuspendLayout();
            this.tabPgGraph.SuspendLayout();
            this.tabPgXml.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtlMain
            // 
            this.tabCtlMain.Controls.Add(this.tabPgGraph);
            this.tabCtlMain.Controls.Add(this.tabPgXml);
            this.tabCtlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtlMain.Location = new System.Drawing.Point(0, 0);
            this.tabCtlMain.Name = "tabCtlMain";
            this.tabCtlMain.SelectedIndex = 0;
            this.tabCtlMain.Size = new System.Drawing.Size(311, 413);
            this.tabCtlMain.TabIndex = 0;
            // 
            // tabPgGraph
            // 
            this.tabPgGraph.Controls.Add(this.tvScheme);
            this.tabPgGraph.Location = new System.Drawing.Point(4, 21);
            this.tabPgGraph.Name = "tabPgGraph";
            this.tabPgGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgGraph.Size = new System.Drawing.Size(303, 388);
            this.tabPgGraph.TabIndex = 0;
            this.tabPgGraph.Text = "曲线方案";
            this.tabPgGraph.UseVisualStyleBackColor = true;
            // 
            // tvScheme
            // 
            this.tvScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvScheme.ImageIndex = 0;
            this.tvScheme.ImageList = this.imgListTV;
            this.tvScheme.Location = new System.Drawing.Point(3, 3);
            this.tvScheme.Name = "tvScheme";
            this.tvScheme.SelectedImageIndex = 0;
            this.tvScheme.ShowNodeToolTips = true;
            this.tvScheme.Size = new System.Drawing.Size(297, 382);
            this.tvScheme.TabIndex = 0;
            this.tvScheme.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvScheme_NodeMouseDoubleClick);
            // 
            // imgListTV
            // 
            this.imgListTV.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListTV.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListTV.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPgXml
            // 
            this.tabPgXml.Controls.Add(this.tvXml);
            this.tabPgXml.Location = new System.Drawing.Point(4, 21);
            this.tabPgXml.Name = "tabPgXml";
            this.tabPgXml.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgXml.Size = new System.Drawing.Size(303, 388);
            this.tabPgXml.TabIndex = 1;
            this.tabPgXml.Text = "XML 文件";
            this.tabPgXml.UseVisualStyleBackColor = true;
            // 
            // tvXml
            // 
            this.tvXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvXml.ImageIndex = 0;
            this.tvXml.ImageList = this.imgListTV;
            this.tvXml.Location = new System.Drawing.Point(3, 3);
            this.tvXml.Name = "tvXml";
            this.tvXml.SelectedImageIndex = 0;
            this.tvXml.ShowNodeToolTips = true;
            this.tvXml.Size = new System.Drawing.Size(297, 382);
            this.tvXml.TabIndex = 1;
            this.tvXml.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvXml_NodeMouseDoubleClick);
            // 
            // FrmSchemaPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 413);
            this.Controls.Add(this.tabCtlMain);
            this.Name = "FrmSchemaPicker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "方案选择";
            this.Load += new System.EventHandler(this.FrmSchemaPicker_Load);
            this.tabCtlMain.ResumeLayout(false);
            this.tabPgGraph.ResumeLayout(false);
            this.tabPgXml.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtlMain;
        private System.Windows.Forms.TabPage tabPgGraph;
        private System.Windows.Forms.TabPage tabPgXml;
        private System.Windows.Forms.TreeView tvScheme;
        private System.Windows.Forms.ImageList imgListTV;
        private System.Windows.Forms.TreeView tvXml;
    }
}