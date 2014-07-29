namespace Shmzh.Monitor.Forms
{
    partial class FrmCategory
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRightCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPublic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsCategory = new System.Windows.Forms.ToolStrip();
            this.tsbAddCategory = new System.Windows.Forms.ToolStripButton();
            this.tsdEditCategory = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteCategory = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveDown = new System.Windows.Forms.ToolStripButton();
            this.dgvCategoryItem = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsCategoryItem = new System.Windows.Forms.ToolStrip();
            this.tsbAddItem = new System.Windows.Forms.ToolStripButton();
            this.tsbEditItem = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tsbUpItem = new System.Windows.Forms.ToolStripButton();
            this.tsbDownItem = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.tsCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryItem)).BeginInit();
            this.tsCategoryItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCategory);
            this.splitContainer1.Panel1.Controls.Add(this.tsCategory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCategoryItem);
            this.splitContainer1.Panel2.Controls.Add(this.tsCategoryItem);
            this.splitContainer1.Size = new System.Drawing.Size(746, 421);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvCategory
            // 
            this.dgvCategory.AllowUserToAddRows = false;
            this.dgvCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colRightCode,
            this.colIsPublic,
            this.Column2});
            this.dgvCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategory.Location = new System.Drawing.Point(0, 25);
            this.dgvCategory.MultiSelect = false;
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.RowTemplate.Height = 23;
            this.dgvCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategory.Size = new System.Drawing.Size(318, 396);
            this.dgvCategory.TabIndex = 1;
            this.dgvCategory.SelectionChanged += new System.EventHandler(this.dgvCategory_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CategoryName";
            this.Column1.HeaderText = "类别";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.ToolTipText = "类别名称。";
            // 
            // colRightCode
            // 
            this.colRightCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRightCode.DataPropertyName = "RightCode";
            this.colRightCode.HeaderText = "权限码";
            this.colRightCode.Name = "colRightCode";
            this.colRightCode.ReadOnly = true;
            this.colRightCode.ToolTipText = "系统管理中对应的权限码。";
            this.colRightCode.Width = 66;
            // 
            // colIsPublic
            // 
            this.colIsPublic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colIsPublic.DataPropertyName = "IsPublic";
            this.colIsPublic.HeaderText = "是否公开";
            this.colIsPublic.Name = "colIsPublic";
            this.colIsPublic.ReadOnly = true;
            this.colIsPublic.ToolTipText = "公开：所有有权限的人可见；非公开：仅超级用户可见。";
            this.colIsPublic.Width = 65;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Remark";
            this.Column2.HeaderText = "备注";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.ToolTipText = "备注。";
            // 
            // tsCategory
            // 
            this.tsCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddCategory,
            this.tsdEditCategory,
            this.tsbDeleteCategory,
            this.tsbMoveUp,
            this.tsbMoveDown});
            this.tsCategory.Location = new System.Drawing.Point(0, 0);
            this.tsCategory.Name = "tsCategory";
            this.tsCategory.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsCategory.Size = new System.Drawing.Size(318, 25);
            this.tsCategory.TabIndex = 0;
            this.tsCategory.Text = "toolStrip1";
            // 
            // tsbAddCategory
            // 
            this.tsbAddCategory.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder;
            this.tsbAddCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddCategory.Name = "tsbAddCategory";
            this.tsbAddCategory.Size = new System.Drawing.Size(49, 22);
            this.tsbAddCategory.Text = "新增";
            this.tsbAddCategory.Click += new System.EventHandler(this.tsbAddCategory_Click);
            // 
            // tsdEditCategory
            // 
            this.tsdEditCategory.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_edit;
            this.tsdEditCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdEditCategory.Name = "tsdEditCategory";
            this.tsdEditCategory.Size = new System.Drawing.Size(49, 22);
            this.tsdEditCategory.Text = "编辑";
            this.tsdEditCategory.Click += new System.EventHandler(this.tsdEditCategory_Click);
            // 
            // tsbDeleteCategory
            // 
            this.tsbDeleteCategory.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_delete;
            this.tsbDeleteCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteCategory.Name = "tsbDeleteCategory";
            this.tsbDeleteCategory.Size = new System.Drawing.Size(49, 22);
            this.tsbDeleteCategory.Text = "删除";
            this.tsbDeleteCategory.Click += new System.EventHandler(this.tsbDeleteCategory_Click);
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
            // dgvCategoryItem
            // 
            this.dgvCategoryItem.AllowUserToAddRows = false;
            this.dgvCategoryItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategoryItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategoryItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategoryItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategoryItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column4,
            this.colClassName});
            this.dgvCategoryItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategoryItem.Location = new System.Drawing.Point(0, 25);
            this.dgvCategoryItem.MultiSelect = false;
            this.dgvCategoryItem.Name = "dgvCategoryItem";
            this.dgvCategoryItem.ReadOnly = true;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategoryItem.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategoryItem.RowTemplate.Height = 23;
            this.dgvCategoryItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoryItem.Size = new System.Drawing.Size(424, 396);
            this.dgvCategoryItem.TabIndex = 1;
            this.dgvCategoryItem.SelectionChanged += new System.EventHandler(this.dgvCategoryItem_SelectionChanged);
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.FillWeight = 50F;
            this.colCode.HeaderText = "编号";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn1.HeaderText = "标题";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "通常显示在窗口标题位置。";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UpdateTime";
            this.dataGridViewTextBoxColumn2.HeaderText = "更新时间(秒)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ConfigFile";
            this.Column4.HeaderText = "方案";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // colClassName
            // 
            this.colClassName.DataPropertyName = "ClassName";
            this.colClassName.HeaderText = "ClassName";
            this.colClassName.Name = "colClassName";
            this.colClassName.ReadOnly = true;
            // 
            // tsCategoryItem
            // 
            this.tsCategoryItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddItem,
            this.tsbEditItem,
            this.tsbDeleteItem,
            this.tsbUpItem,
            this.tsbDownItem});
            this.tsCategoryItem.Location = new System.Drawing.Point(0, 0);
            this.tsCategoryItem.Name = "tsCategoryItem";
            this.tsCategoryItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsCategoryItem.Size = new System.Drawing.Size(424, 25);
            this.tsCategoryItem.TabIndex = 0;
            this.tsCategoryItem.Text = "toolStrip1";
            // 
            // tsbAddItem
            // 
            this.tsbAddItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.add;
            this.tsbAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddItem.Name = "tsbAddItem";
            this.tsbAddItem.Size = new System.Drawing.Size(49, 22);
            this.tsbAddItem.Text = "新增";
            this.tsbAddItem.Click += new System.EventHandler(this.tsbAddItem_Click);
            // 
            // tsbEditItem
            // 
            this.tsbEditItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.pencil;
            this.tsbEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditItem.Name = "tsbEditItem";
            this.tsbEditItem.Size = new System.Drawing.Size(49, 22);
            this.tsbEditItem.Text = "编辑";
            this.tsbEditItem.Click += new System.EventHandler(this.tsbEditItem_Click);
            // 
            // tsbDeleteItem
            // 
            this.tsbDeleteItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.delete;
            this.tsbDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteItem.Name = "tsbDeleteItem";
            this.tsbDeleteItem.Size = new System.Drawing.Size(49, 22);
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
            // FrmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 421);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmCategory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "方案类别管理";
            this.Load += new System.EventHandler(this.FrmCategory_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.tsCategory.ResumeLayout(false);
            this.tsCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryItem)).EndInit();
            this.tsCategoryItem.ResumeLayout(false);
            this.tsCategoryItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.ToolStrip tsCategory;
        private System.Windows.Forms.DataGridView dgvCategoryItem;
        private System.Windows.Forms.ToolStrip tsCategoryItem;
        private System.Windows.Forms.ToolStripButton tsbAddCategory;
        private System.Windows.Forms.ToolStripButton tsdEditCategory;
        private System.Windows.Forms.ToolStripButton tsbDeleteCategory;
        private System.Windows.Forms.ToolStripButton tsbAddItem;
        private System.Windows.Forms.ToolStripButton tsbEditItem;
        private System.Windows.Forms.ToolStripButton tsbDeleteItem;
        private System.Windows.Forms.ToolStripButton tsbDownItem;
        private System.Windows.Forms.ToolStripButton tsbUpItem;
        private System.Windows.Forms.ToolStripButton tsbMoveDown;
        private System.Windows.Forms.ToolStripButton tsbMoveUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRightCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPublic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;

    }
}