using System.Windows.Forms;

namespace Shmzh.Monitor.Forms
{
    partial class FrmGraphSchema
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvScheme = new System.Windows.Forms.TreeView();
            this.imgListTV = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsSchema = new System.Windows.Forms.ToolStrip();
            this.tsAddSchema = new System.Windows.Forms.ToolStripButton();
            this.tsEditSchema = new System.Windows.Forms.ToolStripButton();
            this.tsDeleteSchema = new System.Windows.Forms.ToolStripButton();
            this.tsView = new System.Windows.Forms.ToolStripButton();
            this.tsCopy = new System.Windows.Forms.ToolStripButton();
            this.tsSchemaRelative = new System.Windows.Forms.ToolStripButton();
            this.tsFloatingBlock = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gvItem = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tsItem = new System.Windows.Forms.ToolStrip();
            this.tsbAddItem = new System.Windows.Forms.ToolStripButton();
            this.tsbEditItem = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tsbUpItem = new System.Windows.Forms.ToolStripButton();
            this.tsbDownItem = new System.Windows.Forms.ToolStripButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gvTag = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tsTag = new System.Windows.Forms.ToolStrip();
            this.tsAddTag = new System.Windows.Forms.ToolStripButton();
            this.tsEditTag = new System.Windows.Forms.ToolStripButton();
            this.tsDeleteTag = new System.Windows.Forms.ToolStripButton();
            this.tsUpTag = new System.Windows.Forms.ToolStripButton();
            this.tsDownTag = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsSchema.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).BeginInit();
            this.panel3.SuspendLayout();
            this.tsItem.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTag)).BeginInit();
            this.panel4.SuspendLayout();
            this.tsTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(753, 478);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tvScheme);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 451);
            this.panel2.TabIndex = 1;
            // 
            // tvScheme
            // 
            this.tvScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvScheme.HideSelection = false;
            this.tvScheme.ImageIndex = 0;
            this.tvScheme.ImageList = this.imgListTV;
            this.tvScheme.Location = new System.Drawing.Point(0, 0);
            this.tvScheme.Name = "tvScheme";
            this.tvScheme.SelectedImageIndex = 0;
            this.tvScheme.ShowNodeToolTips = true;
            this.tvScheme.Size = new System.Drawing.Size(310, 451);
            this.tvScheme.TabIndex = 1;
            this.tvScheme.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvScheme_NodeMouseDoubleClick);
            this.tvScheme.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvScheme_AfterSelect);
            // 
            // imgListTV
            // 
            this.imgListTV.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListTV.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListTV.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tsSchema);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 27);
            this.panel1.TabIndex = 0;
            // 
            // tsSchema
            // 
            this.tsSchema.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddSchema,
            this.tsEditSchema,
            this.tsDeleteSchema,
            this.tsView,
            this.tsCopy,
            this.tsSchemaRelative,
            this.tsFloatingBlock});
            this.tsSchema.Location = new System.Drawing.Point(0, 0);
            this.tsSchema.Name = "tsSchema";
            this.tsSchema.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsSchema.Size = new System.Drawing.Size(308, 25);
            this.tsSchema.TabIndex = 5;
            this.tsSchema.Text = "toolStrip1";
            // 
            // tsAddSchema
            // 
            this.tsAddSchema.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_add;
            this.tsAddSchema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddSchema.Name = "tsAddSchema";
            this.tsAddSchema.Size = new System.Drawing.Size(49, 22);
            this.tsAddSchema.Tag = "Add";
            this.tsAddSchema.Text = "新建";
            this.tsAddSchema.ToolTipText = "新建方案";
            this.tsAddSchema.Click += new System.EventHandler(this.tsAddSchema_Click);
            // 
            // tsEditSchema
            // 
            this.tsEditSchema.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_edit;
            this.tsEditSchema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditSchema.Name = "tsEditSchema";
            this.tsEditSchema.Size = new System.Drawing.Size(49, 22);
            this.tsEditSchema.Tag = "Edit";
            this.tsEditSchema.Text = "编辑";
            this.tsEditSchema.ToolTipText = "编辑方案";
            this.tsEditSchema.Click += new System.EventHandler(this.tsEditSchema_Click);
            // 
            // tsDeleteSchema
            // 
            this.tsDeleteSchema.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_delete;
            this.tsDeleteSchema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDeleteSchema.Name = "tsDeleteSchema";
            this.tsDeleteSchema.Size = new System.Drawing.Size(49, 22);
            this.tsDeleteSchema.Tag = "Delete";
            this.tsDeleteSchema.Text = "删除";
            this.tsDeleteSchema.ToolTipText = "删除方案";
            this.tsDeleteSchema.Click += new System.EventHandler(this.tsDeleteSchema_Click);
            // 
            // tsView
            // 
            this.tsView.Image = global::Shmzh.Monitor.Forms.Properties.Resources.eye;
            this.tsView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsView.Name = "tsView";
            this.tsView.Size = new System.Drawing.Size(49, 22);
            this.tsView.Text = "查看";
            this.tsView.Click += new System.EventHandler(this.tsView_Click);
            // 
            // tsCopy
            // 
            this.tsCopy.Image = global::Shmzh.Monitor.Forms.Properties.Resources.copy;
            this.tsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCopy.Name = "tsCopy";
            this.tsCopy.Size = new System.Drawing.Size(49, 22);
            this.tsCopy.Text = "复制";
            this.tsCopy.Click += new System.EventHandler(this.tsCopy_Click);
            // 
            // tsSchemaRelative
            // 
            this.tsSchemaRelative.Image = global::Shmzh.Monitor.Forms.Properties.Resources.attach;
            this.tsSchemaRelative.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSchemaRelative.Name = "tsSchemaRelative";
            this.tsSchemaRelative.Size = new System.Drawing.Size(61, 20);
            this.tsSchemaRelative.Text = "关联项";
            this.tsSchemaRelative.Visible = false;
            this.tsSchemaRelative.Click += new System.EventHandler(this.tsSchemaRelative_Click);
            // 
            // tsFloatingBlock
            // 
            this.tsFloatingBlock.Image = global::Shmzh.Monitor.Forms.Properties.Resources.attach;
            this.tsFloatingBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFloatingBlock.Name = "tsFloatingBlock";
            this.tsFloatingBlock.Size = new System.Drawing.Size(73, 20);
            this.tsFloatingBlock.Text = "浮动窗口";
            this.tsFloatingBlock.Click += new System.EventHandler(this.tsFloatingBlock_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel5);
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            this.splitContainer2.Panel1MinSize = 60;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel6);
            this.splitContainer2.Panel2.Controls.Add(this.panel4);
            this.splitContainer2.Panel2MinSize = 60;
            this.splitContainer2.Size = new System.Drawing.Size(441, 478);
            this.splitContainer2.SplitterDistance = 211;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gvItem);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(441, 184);
            this.panel5.TabIndex = 2;
            // 
            // gvItem
            // 
            this.gvItem.AllowUserToAddRows = false;
            this.gvItem.AllowUserToDeleteRows = false;
            this.gvItem.AllowUserToResizeRows = false;
            this.gvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.gvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvItem.Location = new System.Drawing.Point(0, 0);
            this.gvItem.MultiSelect = false;
            this.gvItem.Name = "gvItem";
            this.gvItem.ReadOnly = true;
            this.gvItem.RowHeadersVisible = false;
            this.gvItem.RowTemplate.Height = 23;
            this.gvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvItem.Size = new System.Drawing.Size(441, 184);
            this.gvItem.TabIndex = 1;
            this.gvItem.SelectionChanged += new System.EventHandler(this.gvItem_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn1.HeaderText = "标题";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "XAxis";
            this.dataGridViewTextBoxColumn2.HeaderText = "X轴名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "YAxis";
            this.dataGridViewTextBoxColumn3.HeaderText = "Y轴名称";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tsItem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 27);
            this.panel3.TabIndex = 1;
            // 
            // tsItem
            // 
            this.tsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddItem,
            this.tsbEditItem,
            this.tsbDeleteItem,
            this.tsbUpItem,
            this.tsbDownItem});
            this.tsItem.Location = new System.Drawing.Point(0, 0);
            this.tsItem.Name = "tsItem";
            this.tsItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsItem.Size = new System.Drawing.Size(439, 25);
            this.tsItem.TabIndex = 4;
            this.tsItem.Text = "toolStrip1";
            // 
            // tsbAddItem
            // 
            this.tsbAddItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.add;
            this.tsbAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddItem.Name = "tsbAddItem";
            this.tsbAddItem.Size = new System.Drawing.Size(49, 22);
            this.tsbAddItem.Tag = "Add";
            this.tsbAddItem.Text = "新建";
            this.tsbAddItem.Click += new System.EventHandler(this.tsbAddItem_Click);
            // 
            // tsbEditItem
            // 
            this.tsbEditItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.pencil;
            this.tsbEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditItem.Name = "tsbEditItem";
            this.tsbEditItem.Size = new System.Drawing.Size(49, 22);
            this.tsbEditItem.Tag = "Edit";
            this.tsbEditItem.Text = "编辑";
            this.tsbEditItem.Click += new System.EventHandler(this.tsbEditItem_Click);
            // 
            // tsbDeleteItem
            // 
            this.tsbDeleteItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.delete;
            this.tsbDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteItem.Name = "tsbDeleteItem";
            this.tsbDeleteItem.Size = new System.Drawing.Size(49, 22);
            this.tsbDeleteItem.Tag = "Delete";
            this.tsbDeleteItem.Text = "删除";
            this.tsbDeleteItem.Click += new System.EventHandler(this.tsbDeleteItem_Click);
            // 
            // tsbUpItem
            // 
            this.tsbUpItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.up;
            this.tsbUpItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpItem.Name = "tsbUpItem";
            this.tsbUpItem.Size = new System.Drawing.Size(49, 22);
            this.tsbUpItem.Text = "上移";
            this.tsbUpItem.Click += new System.EventHandler(this.tsbUpItem_Click);
            // 
            // tsbDownItem
            // 
            this.tsbDownItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.down;
            this.tsbDownItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownItem.Name = "tsbDownItem";
            this.tsbDownItem.Size = new System.Drawing.Size(49, 22);
            this.tsbDownItem.Text = "下移";
            this.tsbDownItem.Click += new System.EventHandler(this.tsbDownItem_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gvTag);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(441, 238);
            this.panel6.TabIndex = 2;
            // 
            // gvTag
            // 
            this.gvTag.AllowUserToAddRows = false;
            this.gvTag.AllowUserToResizeRows = false;
            this.gvTag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTag.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gvTag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column4});
            this.gvTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTag.Location = new System.Drawing.Point(0, 0);
            this.gvTag.MultiSelect = false;
            this.gvTag.Name = "gvTag";
            this.gvTag.RowHeadersVisible = false;
            this.gvTag.RowTemplate.Height = 23;
            this.gvTag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTag.Size = new System.Drawing.Size(441, 238);
            this.gvTag.TabIndex = 2;
            this.gvTag.SelectionChanged += new System.EventHandler(this.gvTag_SelectionChanged);
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "颜色";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 60;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TagId";
            this.Column5.HeaderText = "指标Id";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TagName";
            this.Column6.HeaderText = "指标名称";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "曲线类型";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.DataPropertyName = "SerialNumber";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column4.HeaderText = "序号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 54;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tsTag);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(441, 27);
            this.panel4.TabIndex = 1;
            // 
            // tsTag
            // 
            this.tsTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddTag,
            this.tsEditTag,
            this.tsDeleteTag,
            this.tsUpTag,
            this.tsDownTag});
            this.tsTag.Location = new System.Drawing.Point(0, 0);
            this.tsTag.Name = "tsTag";
            this.tsTag.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsTag.Size = new System.Drawing.Size(439, 25);
            this.tsTag.TabIndex = 5;
            this.tsTag.Text = "toolStrip1";
            // 
            // tsAddTag
            // 
            this.tsAddTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.add;
            this.tsAddTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddTag.Name = "tsAddTag";
            this.tsAddTag.Size = new System.Drawing.Size(49, 22);
            this.tsAddTag.Tag = "Add";
            this.tsAddTag.Text = "新建";
            this.tsAddTag.Click += new System.EventHandler(this.tsAddTag_Click);
            // 
            // tsEditTag
            // 
            this.tsEditTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.pencil;
            this.tsEditTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditTag.Name = "tsEditTag";
            this.tsEditTag.Size = new System.Drawing.Size(49, 22);
            this.tsEditTag.Tag = "Edit";
            this.tsEditTag.Text = "编辑";
            this.tsEditTag.Click += new System.EventHandler(this.tsEditTag_Click);
            // 
            // tsDeleteTag
            // 
            this.tsDeleteTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.delete;
            this.tsDeleteTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDeleteTag.Name = "tsDeleteTag";
            this.tsDeleteTag.Size = new System.Drawing.Size(49, 22);
            this.tsDeleteTag.Tag = "Delete";
            this.tsDeleteTag.Text = "删除";
            this.tsDeleteTag.Click += new System.EventHandler(this.tsDeleteTag_Click);
            // 
            // tsUpTag
            // 
            this.tsUpTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.up;
            this.tsUpTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpTag.Name = "tsUpTag";
            this.tsUpTag.Size = new System.Drawing.Size(49, 22);
            this.tsUpTag.Text = "上移";
            this.tsUpTag.Click += new System.EventHandler(this.tsUpTag_Click);
            // 
            // tsDownTag
            // 
            this.tsDownTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.down;
            this.tsDownTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDownTag.Name = "tsDownTag";
            this.tsDownTag.Size = new System.Drawing.Size(49, 22);
            this.tsDownTag.Text = "下移";
            this.tsDownTag.Click += new System.EventHandler(this.tsDownTag_Click);
            // 
            // FrmGraphSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 478);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmGraphSchema";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "曲线图配置";
            this.Load += new System.EventHandler(this.FrmGraphScheme_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsSchema.ResumeLayout(false);
            this.tsSchema.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tsItem.ResumeLayout(false);
            this.tsItem.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTag)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tsTag.ResumeLayout(false);
            this.tsTag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private DataGridView gvItem;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridView gvTag;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column4;
        private ToolStrip tsItem;
        private ToolStripButton tsbAddItem;
        private ToolStripButton tsbEditItem;
        private ToolStripButton tsbDeleteItem;
        private ToolStrip tsTag;
        private ToolStripButton tsAddTag;
        private ToolStripButton tsEditTag;
        private ToolStripButton tsDeleteTag;
        private ToolStripButton tsUpTag;
        private ToolStripButton tsDownTag;
        private ToolStrip tsSchema;
        private ToolStripButton tsAddSchema;
        private ToolStripButton tsEditSchema;
        private ToolStripButton tsDeleteSchema;
        private ToolStripButton tsSchemaRelative;
        private ToolStripButton tsbUpItem;
        private ToolStripButton tsbDownItem;
        private ToolStripButton tsFloatingBlock;
        private TreeView tvScheme;
        private ImageList imgListTV;
        private ToolStripButton tsView;
        private ToolStripButton tsCopy;


    }
}