namespace Shmzh.Monitor.Forms
{
    partial class FrmSortTags
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvCategory = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.dgvCategoryDetail = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvTagMS = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSetRoot = new System.Windows.Forms.ToolStripButton();
            this.tsbAddRoot = new System.Windows.Forms.ToolStripButton();
            this.tsbAddSub = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagMS)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 486);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvCategory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCategoryDetail);
            this.splitContainer1.Panel2.Controls.Add(this.txtTag);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel2.Controls.Add(this.dgvTagMS);
            this.splitContainer1.Size = new System.Drawing.Size(920, 461);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 5;
            // 
            // tvCategory
            // 
            this.tvCategory.AllowDrop = true;
            this.tvCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCategory.HideSelection = false;
            this.tvCategory.ImageIndex = 0;
            this.tvCategory.ImageList = this.imgList;
            this.tvCategory.Location = new System.Drawing.Point(0, 0);
            this.tvCategory.Name = "tvCategory";
            this.tvCategory.SelectedImageIndex = 0;
            this.tvCategory.Size = new System.Drawing.Size(242, 461);
            this.tvCategory.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tvCategory, "在节点上按下左键并拖动，可以\r\n将一个类别拖动到另一个类别下。");
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
            // dgvCategoryDetail
            // 
            this.dgvCategoryDetail.AllowUserToAddRows = false;
            this.dgvCategoryDetail.AllowUserToDeleteRows = false;
            this.dgvCategoryDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategoryDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategoryDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategoryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvCategoryDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvCategoryDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvCategoryDetail.Name = "dgvCategoryDetail";
            this.dgvCategoryDetail.ReadOnly = true;
            this.dgvCategoryDetail.RowTemplate.Height = 23;
            this.dgvCategoryDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoryDetail.Size = new System.Drawing.Size(293, 461);
            this.dgvCategoryDetail.TabIndex = 1;
            this.dgvCategoryDetail.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCategoryDetail_ColumnHeaderMouseClick);
            this.dgvCategoryDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "I_TAG_ID";
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "指标";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "I_TAG_NAME";
            this.Column2.HeaderText = "指标名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(377, 1);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(160, 21);
            this.txtTag.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtTag, "输入部分指标名或指标Id");
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(300, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(300, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除 >>";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(544, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.toolTip1.SetToolTip(this.btnSearch, "根据指标名或指标Id进行查询");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(300, 188);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "<< 添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvTagMS
            // 
            this.dgvTagMS.AllowUserToAddRows = false;
            this.dgvTagMS.AllowUserToDeleteRows = false;
            this.dgvTagMS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTagMS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTagMS.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTagMS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTagMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTagMS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.dgvTagMS.Location = new System.Drawing.Point(377, 25);
            this.dgvTagMS.Name = "dgvTagMS";
            this.dgvTagMS.ReadOnly = true;
            this.dgvTagMS.RowTemplate.Height = 23;
            this.dgvTagMS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTagMS.Size = new System.Drawing.Size(293, 436);
            this.dgvTagMS.TabIndex = 1;
            this.dgvTagMS.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCategoryDetail_ColumnHeaderMouseClick);
            this.dgvTagMS.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "I_TAG_ID";
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "指标";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "I_TAG_NAME";
            this.Column4.HeaderText = "指标名";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.toolStrip1.Size = new System.Drawing.Size(920, 25);
            this.toolStrip1.TabIndex = 4;
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
            this.tsbEdit.ToolTipText = "编辑选中类别";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(49, 22);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.ToolTipText = "删除选中类别";
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
            // FrmSortTags
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 486);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSortTags";
            this.ShowIcon = false;
            this.Text = "指标分类管理";
            this.Load += new System.EventHandler(this.FrmSortTags_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagMS)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvCategory;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.DataGridView dgvTagMS;
        private System.Windows.Forms.DataGridView dgvCategoryDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSetRoot;
        private System.Windows.Forms.ToolStripButton tsbAddRoot;
        private System.Windows.Forms.ToolStripButton tsbAddSub;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbMoveUp;
        private System.Windows.Forms.ToolStripButton tsbMoveDown;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}