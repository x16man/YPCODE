namespace Shmzh.Components.FormLibrary
{
    partial class FrmUsersPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsersPicker));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabUserGroup = new System.Windows.Forms.TabControl();
            this.tpgUser = new System.Windows.Forms.TabPage();
            this.tvUser = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tpgGroup = new System.Windows.Forms.TabPage();
            this.tvGroup = new System.Windows.Forms.TreeView();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tabUserGroup.SuspendLayout();
            this.tpgUser.SuspendLayout();
            this.tpgGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnCancel);
            this.pnlTop.Controls.Add(this.btnOk);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTop.Location = new System.Drawing.Point(0, 375);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(293, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(205, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(112, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabUserGroup);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(293, 375);
            this.pnlMain.TabIndex = 1;
            // 
            // tabUserGroup
            // 
            this.tabUserGroup.Controls.Add(this.tpgUser);
            this.tabUserGroup.Controls.Add(this.tpgGroup);
            this.tabUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUserGroup.ImageList = this.imageList1;
            this.tabUserGroup.Location = new System.Drawing.Point(0, 0);
            this.tabUserGroup.Name = "tabUserGroup";
            this.tabUserGroup.SelectedIndex = 0;
            this.tabUserGroup.Size = new System.Drawing.Size(293, 375);
            this.tabUserGroup.TabIndex = 1;
            // 
            // tpgUser
            // 
            this.tpgUser.Controls.Add(this.tvUser);
            this.tpgUser.ImageIndex = 1;
            this.tpgUser.Location = new System.Drawing.Point(4, 23);
            this.tpgUser.Name = "tpgUser";
            this.tpgUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpgUser.Size = new System.Drawing.Size(285, 348);
            this.tpgUser.TabIndex = 0;
            this.tpgUser.Text = "用户";
            this.tpgUser.ToolTipText = "切换到用户列表";
            this.tpgUser.UseVisualStyleBackColor = true;
            // 
            // tvUser
            // 
            this.tvUser.CheckBoxes = true;
            this.tvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUser.ImageIndex = 0;
            this.tvUser.ImageList = this.imageList1;
            this.tvUser.Location = new System.Drawing.Point(3, 3);
            this.tvUser.Name = "tvUser";
            this.tvUser.SelectedImageIndex = 0;
            this.tvUser.ShowNodeToolTips = true;
            this.tvUser.Size = new System.Drawing.Size(279, 342);
            this.tvUser.TabIndex = 1;
            this.tvUser.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvUser_AfterCheck);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folders.png");
            this.imageList1.Images.SetKeyName(1, "user.png");
            this.imageList1.Images.SetKeyName(2, "group.png");
            // 
            // tpgGroup
            // 
            this.tpgGroup.Controls.Add(this.tvGroup);
            this.tpgGroup.ImageIndex = 2;
            this.tpgGroup.Location = new System.Drawing.Point(4, 23);
            this.tpgGroup.Name = "tpgGroup";
            this.tpgGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tpgGroup.Size = new System.Drawing.Size(285, 348);
            this.tpgGroup.TabIndex = 1;
            this.tpgGroup.Text = "组";
            this.tpgGroup.ToolTipText = "切换到组列表";
            this.tpgGroup.UseVisualStyleBackColor = true;
            // 
            // tvGroup
            // 
            this.tvGroup.CheckBoxes = true;
            this.tvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGroup.ImageIndex = 0;
            this.tvGroup.ImageList = this.imageList1;
            this.tvGroup.Location = new System.Drawing.Point(3, 3);
            this.tvGroup.Name = "tvGroup";
            this.tvGroup.SelectedImageIndex = 0;
            this.tvGroup.ShowNodeToolTips = true;
            this.tvGroup.Size = new System.Drawing.Size(279, 342);
            this.tvGroup.TabIndex = 2;
            this.tvGroup.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvGroup_AfterCheck);
            // 
            // FrmUsersPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 411);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsersPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择用户";
            this.Load += new System.EventHandler(this.FrmUserPicker_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tabUserGroup.ResumeLayout(false);
            this.tpgUser.ResumeLayout(false);
            this.tpgGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tpgUser;
        private System.Windows.Forms.TabPage tpgGroup;
        public System.Windows.Forms.TreeView tvUser;
        public System.Windows.Forms.TreeView tvGroup;
        public System.Windows.Forms.TabControl tabUserGroup;
    }
}