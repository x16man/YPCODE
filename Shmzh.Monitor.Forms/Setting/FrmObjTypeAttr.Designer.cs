namespace Shmzh.Monitor.Forms.Setting
{
    partial class FrmObjTypeAttr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObjTypeAttr));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvObjType = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tsObjType = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabContent = new System.Windows.Forms.TabControl();
            this.tpMonitorObj = new System.Windows.Forms.TabPage();
            this.lvMonitorObj = new System.Windows.Forms.ListView();
            this.tpTypeAttr = new System.Windows.Forms.TabPage();
            this.lvTypeAttr = new System.Windows.Forms.ListView();
            this.chSerialNo = new System.Windows.Forms.ColumnHeader();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chType = new System.Windows.Forms.ColumnHeader();
            this.chFieldName = new System.Windows.Forms.ColumnHeader();
            this.chDataType = new System.Windows.Forms.ColumnHeader();
            this.tsMonitorObj_TypeAttr = new System.Windows.Forms.ToolStrip();
            this.tsbAddContent = new System.Windows.Forms.ToolStripButton();
            this.tsbEditContent = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteContent = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tsObjType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabContent.SuspendLayout();
            this.tpMonitorObj.SuspendLayout();
            this.tpTypeAttr.SuspendLayout();
            this.tsMonitorObj_TypeAttr.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(690, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvObjType);
            this.splitContainer1.Panel1.Controls.Add(this.tsObjType);
            this.splitContainer1.Panel1MinSize = 180;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.tsMonitorObj_TypeAttr);
            this.splitContainer1.Size = new System.Drawing.Size(690, 439);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvObjType
            // 
            this.tvObjType.AllowDrop = true;
            this.tvObjType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObjType.HideSelection = false;
            this.tvObjType.ImageIndex = 3;
            this.tvObjType.ImageList = this.imageList1;
            this.tvObjType.Location = new System.Drawing.Point(0, 25);
            this.tvObjType.Name = "tvObjType";
            this.tvObjType.SelectedImageIndex = 4;
            this.tvObjType.Size = new System.Drawing.Size(196, 414);
            this.tvObjType.TabIndex = 1;
            this.tvObjType.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvObjType_DragDrop);
            this.tvObjType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvObjType_AfterSelect);
            this.tvObjType.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvObjType_MouseMove);
            this.tvObjType.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvObjType_DragEnter);
            this.tvObjType.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvObjType_BeforeSelect);
            this.tvObjType.MouseHover += new System.EventHandler(this.tvObjType_MouseHover);
            this.tvObjType.MouseLeave += new System.EventHandler(this.tvObjType_MouseLeave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "application_view_tile.png");
            this.imageList1.Images.SetKeyName(1, "application_view_list.png");
            this.imageList1.Images.SetKeyName(2, "page_white_powerpoint.png");
            this.imageList1.Images.SetKeyName(3, "folder.png");
            this.imageList1.Images.SetKeyName(4, "folder_go.png");
            this.imageList1.Images.SetKeyName(5, "world.png");
            // 
            // tsObjType
            // 
            this.tsObjType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete});
            this.tsObjType.Location = new System.Drawing.Point(0, 0);
            this.tsObjType.Name = "tsObjType";
            this.tsObjType.Size = new System.Drawing.Size(196, 25);
            this.tsObjType.TabIndex = 2;
            this.tsObjType.Text = "toolStrip1";
            this.tsObjType.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsObjType_ItemClicked);
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_add;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(52, 22);
            this.tsbAdd.Tag = "Add";
            this.tsbAdd.Text = "新建";
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_edit;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(52, 22);
            this.tsbEdit.Tag = "Edit";
            this.tsbEdit.Text = "编辑";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(52, 22);
            this.tsbDelete.Tag = "Delete";
            this.tsbDelete.Text = "删除";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 414);
            this.panel1.TabIndex = 2;
            // 
            // tabContent
            // 
            this.tabContent.Controls.Add(this.tpMonitorObj);
            this.tabContent.Controls.Add(this.tpTypeAttr);
            this.tabContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContent.ImageList = this.imageList1;
            this.tabContent.Location = new System.Drawing.Point(0, 0);
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(490, 414);
            this.tabContent.TabIndex = 0;
            // 
            // tpMonitorObj
            // 
            this.tpMonitorObj.Controls.Add(this.lvMonitorObj);
            this.tpMonitorObj.ImageIndex = 2;
            this.tpMonitorObj.Location = new System.Drawing.Point(4, 23);
            this.tpMonitorObj.Name = "tpMonitorObj";
            this.tpMonitorObj.Padding = new System.Windows.Forms.Padding(3);
            this.tpMonitorObj.Size = new System.Drawing.Size(482, 387);
            this.tpMonitorObj.TabIndex = 0;
            this.tpMonitorObj.Text = "监测对象";
            this.tpMonitorObj.UseVisualStyleBackColor = true;
            // 
            // lvMonitorObj
            // 
            this.lvMonitorObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMonitorObj.FullRowSelect = true;
            this.lvMonitorObj.GridLines = true;
            this.lvMonitorObj.Location = new System.Drawing.Point(3, 3);
            this.lvMonitorObj.MultiSelect = false;
            this.lvMonitorObj.Name = "lvMonitorObj";
            this.lvMonitorObj.Size = new System.Drawing.Size(476, 381);
            this.lvMonitorObj.SmallImageList = this.imageList1;
            this.lvMonitorObj.TabIndex = 0;
            this.lvMonitorObj.UseCompatibleStateImageBehavior = false;
            this.lvMonitorObj.View = System.Windows.Forms.View.Details;
            // 
            // tpTypeAttr
            // 
            this.tpTypeAttr.Controls.Add(this.lvTypeAttr);
            this.tpTypeAttr.ImageIndex = 1;
            this.tpTypeAttr.Location = new System.Drawing.Point(4, 23);
            this.tpTypeAttr.Name = "tpTypeAttr";
            this.tpTypeAttr.Padding = new System.Windows.Forms.Padding(3);
            this.tpTypeAttr.Size = new System.Drawing.Size(482, 387);
            this.tpTypeAttr.TabIndex = 1;
            this.tpTypeAttr.Text = "类别属性";
            this.tpTypeAttr.UseVisualStyleBackColor = true;
            // 
            // lvTypeAttr
            // 
            this.lvTypeAttr.AllowDrop = true;
            this.lvTypeAttr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSerialNo,
            this.chName,
            this.chType,
            this.chFieldName,
            this.chDataType});
            this.lvTypeAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTypeAttr.FullRowSelect = true;
            this.lvTypeAttr.GridLines = true;
            this.lvTypeAttr.Location = new System.Drawing.Point(3, 3);
            this.lvTypeAttr.Name = "lvTypeAttr";
            this.lvTypeAttr.Size = new System.Drawing.Size(476, 381);
            this.lvTypeAttr.SmallImageList = this.imageList1;
            this.lvTypeAttr.TabIndex = 0;
            this.lvTypeAttr.UseCompatibleStateImageBehavior = false;
            this.lvTypeAttr.View = System.Windows.Forms.View.Details;
            this.lvTypeAttr.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvTypeAttr_ItemDrag);
            // 
            // chSerialNo
            // 
            this.chSerialNo.Text = "序号";
            this.chSerialNo.Width = 38;
            // 
            // chName
            // 
            this.chName.Text = "名称";
            this.chName.Width = 100;
            // 
            // chType
            // 
            this.chType.Text = "类别";
            // 
            // chFieldName
            // 
            this.chFieldName.Text = "字段名称";
            this.chFieldName.Width = 80;
            // 
            // chDataType
            // 
            this.chDataType.Text = "数据类型";
            // 
            // tsMonitorObj_TypeAttr
            // 
            this.tsMonitorObj_TypeAttr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddContent,
            this.tsbEditContent,
            this.tsbDeleteContent});
            this.tsMonitorObj_TypeAttr.Location = new System.Drawing.Point(0, 0);
            this.tsMonitorObj_TypeAttr.Name = "tsMonitorObj_TypeAttr";
            this.tsMonitorObj_TypeAttr.Size = new System.Drawing.Size(490, 25);
            this.tsMonitorObj_TypeAttr.TabIndex = 1;
            this.tsMonitorObj_TypeAttr.Text = "toolStrip1";
            this.tsMonitorObj_TypeAttr.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsMonitorObj_TypeAttr_ItemClicked);
            // 
            // tsbAddContent
            // 
            this.tsbAddContent.Image = global::Shmzh.Monitor.Forms.Properties.Resources.add;
            this.tsbAddContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddContent.Name = "tsbAddContent";
            this.tsbAddContent.Size = new System.Drawing.Size(52, 22);
            this.tsbAddContent.Tag = "Add";
            this.tsbAddContent.Text = "新建";
            // 
            // tsbEditContent
            // 
            this.tsbEditContent.Image = global::Shmzh.Monitor.Forms.Properties.Resources.pencil;
            this.tsbEditContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditContent.Name = "tsbEditContent";
            this.tsbEditContent.Size = new System.Drawing.Size(52, 22);
            this.tsbEditContent.Tag = "Edit";
            this.tsbEditContent.Text = "编辑";
            // 
            // tsbDeleteContent
            // 
            this.tsbDeleteContent.Image = global::Shmzh.Monitor.Forms.Properties.Resources.delete;
            this.tsbDeleteContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteContent.Name = "tsbDeleteContent";
            this.tsbDeleteContent.Size = new System.Drawing.Size(52, 22);
            this.tsbDeleteContent.Tag = "Delete";
            this.tsbDeleteContent.Text = "删除";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 439);
            this.panel2.TabIndex = 1;
            // 
            // FrmObjTypeAttr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmObjTypeAttr";
            this.Text = "监测对象设置";
            this.Load += new System.EventHandler(this.frmObjTypeAttr_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tsObjType.ResumeLayout(false);
            this.tsObjType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabContent.ResumeLayout(false);
            this.tpMonitorObj.ResumeLayout(false);
            this.tpTypeAttr.ResumeLayout(false);
            this.tsMonitorObj_TypeAttr.ResumeLayout(false);
            this.tsMonitorObj_TypeAttr.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvObjType;
        private System.Windows.Forms.ToolStrip tsObjType;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.TabControl tabContent;
        private System.Windows.Forms.TabPage tpMonitorObj;
        private System.Windows.Forms.TabPage tpTypeAttr;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip tsMonitorObj_TypeAttr;
        private System.Windows.Forms.ToolStripButton tsbAddContent;
        private System.Windows.Forms.ToolStripButton tsbEditContent;
        private System.Windows.Forms.ToolStripButton tsbDeleteContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvMonitorObj;
        private System.Windows.Forms.ListView lvTypeAttr;
        private System.Windows.Forms.ColumnHeader chSerialNo;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chFieldName;
        private System.Windows.Forms.ColumnHeader chDataType;
        
    }
}