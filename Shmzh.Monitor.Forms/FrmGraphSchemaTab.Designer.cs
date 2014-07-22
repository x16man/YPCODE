namespace Shmzh.Monitor.Forms
{
    partial class FrmGraphSchemaTab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelRTagToolBar = new System.Windows.Forms.Panel();
            this.tsRTag = new System.Windows.Forms.ToolStrip();
            this.tsAddRTag = new System.Windows.Forms.ToolStripButton();
            this.tsEditRTag = new System.Windows.Forms.ToolStripButton();
            this.tsDeleteRTag = new System.Windows.Forms.ToolStripButton();
            this.tsUpRTag = new System.Windows.Forms.ToolStripButton();
            this.tsDownRTag = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelGvTab = new System.Windows.Forms.Panel();
            this.gvTab = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTabToolBar = new System.Windows.Forms.Panel();
            this.tsTab = new System.Windows.Forms.ToolStrip();
            this.tsAddTab = new System.Windows.Forms.ToolStripButton();
            this.tsEditTab = new System.Windows.Forms.ToolStripButton();
            this.tsDeleteTab = new System.Windows.Forms.ToolStripButton();
            this.tsUpTab = new System.Windows.Forms.ToolStripButton();
            this.tsDownTab = new System.Windows.Forms.ToolStripButton();
            this.panelGvRTag = new System.Windows.Forms.Panel();
            this.gvRTag = new System.Windows.Forms.DataGridView();
            this.colTagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTagId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRTagToolBar.SuspendLayout();
            this.tsRTag.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelGvTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTab)).BeginInit();
            this.panelTabToolBar.SuspendLayout();
            this.tsTab.SuspendLayout();
            this.panelGvRTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRTag)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRTagToolBar
            // 
            this.panelRTagToolBar.AutoSize = true;
            this.panelRTagToolBar.BackColor = System.Drawing.SystemColors.Control;
            this.panelRTagToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRTagToolBar.Controls.Add(this.tsRTag);
            this.panelRTagToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRTagToolBar.Location = new System.Drawing.Point(0, 0);
            this.panelRTagToolBar.Name = "panelRTagToolBar";
            this.panelRTagToolBar.Size = new System.Drawing.Size(633, 27);
            this.panelRTagToolBar.TabIndex = 2;
            // 
            // tsRTag
            // 
            this.tsRTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddRTag,
            this.tsEditRTag,
            this.tsDeleteRTag,
            this.tsUpRTag,
            this.tsDownRTag});
            this.tsRTag.Location = new System.Drawing.Point(0, 0);
            this.tsRTag.Name = "tsRTag";
            this.tsRTag.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsRTag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsRTag.Size = new System.Drawing.Size(631, 25);
            this.tsRTag.TabIndex = 8;
            this.tsRTag.Text = "toolStrip2";
            // 
            // tsAddRTag
            // 
            this.tsAddRTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.add;
            this.tsAddRTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddRTag.Name = "tsAddRTag";
            this.tsAddRTag.Size = new System.Drawing.Size(49, 22);
            this.tsAddRTag.Tag = "Add";
            this.tsAddRTag.Text = "新建";
            this.tsAddRTag.Click += new System.EventHandler(this.tsAddRTag_Click);
            // 
            // tsEditRTag
            // 
            this.tsEditRTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.pencil;
            this.tsEditRTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditRTag.Name = "tsEditRTag";
            this.tsEditRTag.Size = new System.Drawing.Size(49, 22);
            this.tsEditRTag.Tag = "Edit";
            this.tsEditRTag.Text = "编辑";
            this.tsEditRTag.Click += new System.EventHandler(this.tsEditRTag_Click);
            // 
            // tsDeleteRTag
            // 
            this.tsDeleteRTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.delete;
            this.tsDeleteRTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDeleteRTag.Name = "tsDeleteRTag";
            this.tsDeleteRTag.Size = new System.Drawing.Size(49, 22);
            this.tsDeleteRTag.Tag = "Delete";
            this.tsDeleteRTag.Text = "删除";
            this.tsDeleteRTag.Click += new System.EventHandler(this.tsDeleteRTag_Click);
            // 
            // tsUpRTag
            // 
            this.tsUpRTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.up;
            this.tsUpRTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpRTag.Name = "tsUpRTag";
            this.tsUpRTag.Size = new System.Drawing.Size(49, 22);
            this.tsUpRTag.Text = "上移";
            this.tsUpRTag.Click += new System.EventHandler(this.tsUpRTag_Click);
            // 
            // tsDownRTag
            // 
            this.tsDownRTag.Image = global::Shmzh.Monitor.Forms.Properties.Resources.down;
            this.tsDownRTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDownRTag.Name = "tsDownRTag";
            this.tsDownRTag.Size = new System.Drawing.Size(49, 22);
            this.tsDownRTag.Text = "下移";
            this.tsDownRTag.Click += new System.EventHandler(this.tsDownRTag_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelGvTab);
            this.splitContainer1.Panel1.Controls.Add(this.panelTabToolBar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelGvRTag);
            this.splitContainer1.Panel2.Controls.Add(this.panelRTagToolBar);
            this.splitContainer1.Size = new System.Drawing.Size(633, 440);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 4;
            // 
            // panelGvTab
            // 
            this.panelGvTab.Controls.Add(this.gvTab);
            this.panelGvTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGvTab.Location = new System.Drawing.Point(0, 27);
            this.panelGvTab.Name = "panelGvTab";
            this.panelGvTab.Size = new System.Drawing.Size(633, 150);
            this.panelGvTab.TabIndex = 3;
            // 
            // gvTab
            // 
            this.gvTab.AllowUserToAddRows = false;
            this.gvTab.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTab.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.gvTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTab.Location = new System.Drawing.Point(0, 0);
            this.gvTab.MultiSelect = false;
            this.gvTab.Name = "gvTab";
            this.gvTab.RowHeadersVisible = false;
            this.gvTab.RowTemplate.Height = 23;
            this.gvTab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTab.Size = new System.Drawing.Size(633, 150);
            this.gvTab.TabIndex = 0;
            this.gvTab.SelectionChanged += new System.EventHandler(this.gvTab_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "TabName";
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "标签名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "TabType";
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "类型";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "TabVisible";
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "标签可见";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Title";
            this.Column4.HeaderText = "标题";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.DataPropertyName = "TitleVisible";
            this.Column5.FillWeight = 60.89744F;
            this.Column5.HeaderText = "标题可见";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 60;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.DataPropertyName = "SerialNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.FillWeight = 50F;
            this.Column6.HeaderText = "排序号";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // panelTabToolBar
            // 
            this.panelTabToolBar.AutoSize = true;
            this.panelTabToolBar.BackColor = System.Drawing.SystemColors.Control;
            this.panelTabToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTabToolBar.Controls.Add(this.tsTab);
            this.panelTabToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTabToolBar.Location = new System.Drawing.Point(0, 0);
            this.panelTabToolBar.Name = "panelTabToolBar";
            this.panelTabToolBar.Size = new System.Drawing.Size(633, 27);
            this.panelTabToolBar.TabIndex = 2;
            // 
            // tsTab
            // 
            this.tsTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddTab,
            this.tsEditTab,
            this.tsDeleteTab,
            this.tsUpTab,
            this.tsDownTab});
            this.tsTab.Location = new System.Drawing.Point(0, 0);
            this.tsTab.Name = "tsTab";
            this.tsTab.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsTab.Size = new System.Drawing.Size(631, 25);
            this.tsTab.TabIndex = 7;
            this.tsTab.Text = "toolStrip1";
            // 
            // tsAddTab
            // 
            this.tsAddTab.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_add;
            this.tsAddTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddTab.Name = "tsAddTab";
            this.tsAddTab.Size = new System.Drawing.Size(49, 22);
            this.tsAddTab.Tag = "Add";
            this.tsAddTab.Text = "新建";
            this.tsAddTab.Click += new System.EventHandler(this.tsAddTab_Click);
            // 
            // tsEditTab
            // 
            this.tsEditTab.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_edit;
            this.tsEditTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditTab.Name = "tsEditTab";
            this.tsEditTab.Size = new System.Drawing.Size(49, 22);
            this.tsEditTab.Tag = "Edit";
            this.tsEditTab.Text = "编辑";
            this.tsEditTab.Click += new System.EventHandler(this.tsEditTab_Click);
            // 
            // tsDeleteTab
            // 
            this.tsDeleteTab.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_delete;
            this.tsDeleteTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDeleteTab.Name = "tsDeleteTab";
            this.tsDeleteTab.Size = new System.Drawing.Size(49, 22);
            this.tsDeleteTab.Tag = "Delete";
            this.tsDeleteTab.Text = "删除";
            this.tsDeleteTab.Click += new System.EventHandler(this.tsDeleteTab_Click);
            // 
            // tsUpTab
            // 
            this.tsUpTab.Image = global::Shmzh.Monitor.Forms.Properties.Resources.up;
            this.tsUpTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpTab.Name = "tsUpTab";
            this.tsUpTab.Size = new System.Drawing.Size(49, 22);
            this.tsUpTab.Text = "上移";
            this.tsUpTab.Click += new System.EventHandler(this.tsUpTab_Click);
            // 
            // tsDownTab
            // 
            this.tsDownTab.Image = global::Shmzh.Monitor.Forms.Properties.Resources.down;
            this.tsDownTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDownTab.Name = "tsDownTab";
            this.tsDownTab.Size = new System.Drawing.Size(49, 22);
            this.tsDownTab.Text = "下移";
            this.tsDownTab.Click += new System.EventHandler(this.tsDownTab_Click);
            // 
            // panelGvRTag
            // 
            this.panelGvRTag.Controls.Add(this.gvRTag);
            this.panelGvRTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGvRTag.Location = new System.Drawing.Point(0, 27);
            this.panelGvRTag.Name = "panelGvRTag";
            this.panelGvRTag.Size = new System.Drawing.Size(633, 234);
            this.panelGvRTag.TabIndex = 4;
            // 
            // gvRTag
            // 
            this.gvRTag.AllowUserToAddRows = false;
            this.gvRTag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvRTag.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvRTag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvRTag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRTag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTagName,
            this.colTagId,
            this.colDataType,
            this.colUnit,
            this.colSerialNumber});
            this.gvRTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvRTag.Location = new System.Drawing.Point(0, 0);
            this.gvRTag.MultiSelect = false;
            this.gvRTag.Name = "gvRTag";
            this.gvRTag.RowHeadersVisible = false;
            this.gvRTag.RowHeadersWidth = 22;
            this.gvRTag.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvRTag.RowTemplate.Height = 23;
            this.gvRTag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRTag.Size = new System.Drawing.Size(633, 234);
            this.gvRTag.TabIndex = 0;
            this.gvRTag.SelectionChanged += new System.EventHandler(this.gvRTag_SelectionChanged);
            // 
            // colTagName
            // 
            this.colTagName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTagName.DataPropertyName = "TagName";
            this.colTagName.HeaderText = "指标名";
            this.colTagName.Name = "colTagName";
            this.colTagName.ReadOnly = true;
            // 
            // colTagId
            // 
            this.colTagId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTagId.DataPropertyName = "TagId";
            this.colTagId.FillWeight = 80F;
            this.colTagId.HeaderText = "指标";
            this.colTagId.Name = "colTagId";
            this.colTagId.ReadOnly = true;
            // 
            // colDataType
            // 
            this.colDataType.DataPropertyName = "DataType";
            this.colDataType.FillWeight = 50F;
            this.colDataType.HeaderText = "数据类型";
            this.colDataType.Name = "colDataType";
            this.colDataType.ReadOnly = true;
            // 
            // colUnit
            // 
            this.colUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUnit.DataPropertyName = "Unit";
            this.colUnit.FillWeight = 50F;
            this.colUnit.HeaderText = "单位";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSerialNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSerialNumber.HeaderText = "排序号";
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 70;
            // 
            // FrmGraphSchemaTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 440);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmGraphSchemaTab";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmGraphSchemaRTag";
            this.Load += new System.EventHandler(this.FrmGraphSchemaRTag_Load);
            this.panelRTagToolBar.ResumeLayout(false);
            this.panelRTagToolBar.PerformLayout();
            this.tsRTag.ResumeLayout(false);
            this.tsRTag.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panelGvTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTab)).EndInit();
            this.panelTabToolBar.ResumeLayout(false);
            this.panelTabToolBar.PerformLayout();
            this.tsTab.ResumeLayout(false);
            this.tsTab.PerformLayout();
            this.panelGvRTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRTag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRTagToolBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelGvRTag;
        private System.Windows.Forms.DataGridView gvRTag;
        private System.Windows.Forms.Panel panelGvTab;
        private System.Windows.Forms.Panel panelTabToolBar;
        private System.Windows.Forms.DataGridView gvTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.ToolStrip tsTab;
        private System.Windows.Forms.ToolStripButton tsAddTab;
        private System.Windows.Forms.ToolStripButton tsEditTab;
        private System.Windows.Forms.ToolStripButton tsDeleteTab;
        private System.Windows.Forms.ToolStripButton tsUpTab;
        private System.Windows.Forms.ToolStripButton tsDownTab;
        private System.Windows.Forms.ToolStrip tsRTag;
        private System.Windows.Forms.ToolStripButton tsAddRTag;
        private System.Windows.Forms.ToolStripButton tsEditRTag;
        private System.Windows.Forms.ToolStripButton tsDeleteRTag;
        private System.Windows.Forms.ToolStripButton tsUpRTag;
        private System.Windows.Forms.ToolStripButton tsDownRTag;
    }
}