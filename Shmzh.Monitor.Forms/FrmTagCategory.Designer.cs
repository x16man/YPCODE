namespace Shmzh.Monitor.Forms
{
    partial class FrmTagCategory
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSetRoot = new System.Windows.Forms.ToolStripButton();
            this.tsbAddRoot = new System.Windows.Forms.ToolStripButton();
            this.tsbAddSub = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveDown = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvCategory = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSetRoot,
            this.tsbAddRoot,
            this.tsbAddSub,
            this.tsbEdit,
            this.tsbDelete,
            this.tsbMoveUp,
            this.tsbMoveDown});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(507, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSetRoot
            // 
            this.tsbSetRoot.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_go;
            this.tsbSetRoot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetRoot.Name = "tsbSetRoot";
            this.tsbSetRoot.Size = new System.Drawing.Size(85, 22);
            this.tsbSetRoot.Text = "设为根类别";
            this.tsbSetRoot.Click += new System.EventHandler(this.tsbSetRoot_Click);
            // 
            // tsbAddRoot
            // 
            this.tsbAddRoot.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_add;
            this.tsbAddRoot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddRoot.Name = "tsbAddRoot";
            this.tsbAddRoot.Size = new System.Drawing.Size(85, 22);
            this.tsbAddRoot.Text = "新建根类别";
            this.tsbAddRoot.Click += new System.EventHandler(this.tsbAddRoot_Click);
            // 
            // tsbAddSub
            // 
            this.tsbAddSub.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_add;
            this.tsbAddSub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddSub.Name = "tsbAddSub";
            this.tsbAddSub.Size = new System.Drawing.Size(85, 22);
            this.tsbAddSub.Text = "新建子类别";
            this.tsbAddSub.Click += new System.EventHandler(this.tsbAddSub_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_edit;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(49, 22);
            this.tsbEdit.Text = "编辑";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(49, 22);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbMoveUp
            // 
            this.tsbMoveUp.Image = global::Shmzh.Monitor.Forms.Properties.Resources.up;
            this.tsbMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveUp.Name = "tsbMoveUp";
            this.tsbMoveUp.Size = new System.Drawing.Size(49, 22);
            this.tsbMoveUp.Text = "上移";
            this.tsbMoveUp.ToolTipText = "同级类别上移";
            this.tsbMoveUp.Click += new System.EventHandler(this.tsbMoveUp_Click);
            // 
            // tsbMoveDown
            // 
            this.tsbMoveDown.Image = global::Shmzh.Monitor.Forms.Properties.Resources.down;
            this.tsbMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveDown.Name = "tsbMoveDown";
            this.tsbMoveDown.Size = new System.Drawing.Size(49, 22);
            this.tsbMoveDown.Text = "下移";
            this.tsbMoveDown.ToolTipText = "同级类别下移";
            this.tsbMoveDown.Click += new System.EventHandler(this.tsbMoveDown_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvCategory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 391);
            this.panel1.TabIndex = 1;
            // 
            // tvCategory
            // 
            this.tvCategory.AllowDrop = true;
            this.tvCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCategory.ImageIndex = 0;
            this.tvCategory.ImageList = this.imgList;
            this.tvCategory.Location = new System.Drawing.Point(0, 0);
            this.tvCategory.Name = "tvCategory";
            this.tvCategory.SelectedImageIndex = 0;
            this.tvCategory.Size = new System.Drawing.Size(507, 391);
            this.tvCategory.TabIndex = 0;
            this.tvCategory.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvCategory_DragDrop);
            this.tvCategory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCategory_AfterSelect);
            this.tvCategory.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvCategory_DragEnter);
            this.tvCategory.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvCategory_ItemDrag);
            this.tvCategory.DragOver += new System.Windows.Forms.DragEventHandler(this.tvCategory_DragOver);
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmTagCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 416);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmTagCategory";
            this.ShowIcon = false;
            this.Text = "指标类别管理";
            this.Load += new System.EventHandler(this.FrmTagCategory_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddRoot;
        private System.Windows.Forms.ToolStripButton tsbAddSub;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvCategory;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripButton tsbMoveUp;
        private System.Windows.Forms.ToolStripButton tsbMoveDown;
        private System.Windows.Forms.ToolStripButton tsbSetRoot;
    }
}