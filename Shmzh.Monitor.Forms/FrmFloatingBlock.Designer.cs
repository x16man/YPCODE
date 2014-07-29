namespace Shmzh.Monitor.Forms
{
    partial class FrmFloatingBlock
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvBlock = new System.Windows.Forms.DataGridView();
            this.colBorderColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFillColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBlock = new System.Windows.Forms.Panel();
            this.tsBlock = new System.Windows.Forms.ToolStrip();
            this.tsbAddBlock = new System.Windows.Forms.ToolStripButton();
            this.tsbEditBlock = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteBlock = new System.Windows.Forms.ToolStripButton();
            this.dgvBlockItem = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBlockItem = new System.Windows.Forms.Panel();
            this.tsBlockItem = new System.Windows.Forms.ToolStrip();
            this.tsbAddBlockItem = new System.Windows.Forms.ToolStripButton();
            this.tsbEditBlockItem = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteBlockItem = new System.Windows.Forms.ToolStripButton();
            this.tsbUpBlockItem = new System.Windows.Forms.ToolStripButton();
            this.tsbDownBlockItem = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlock)).BeginInit();
            this.pnlBlock.SuspendLayout();
            this.tsBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockItem)).BeginInit();
            this.pnlBlockItem.SuspendLayout();
            this.tsBlockItem.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvBlock);
            this.splitContainer1.Panel1.Controls.Add(this.pnlBlock);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvBlockItem);
            this.splitContainer1.Panel2.Controls.Add(this.pnlBlockItem);
            this.splitContainer1.Size = new System.Drawing.Size(704, 415);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvBlock
            // 
            this.dgvBlock.AllowUserToAddRows = false;
            this.dgvBlock.AllowUserToDeleteRows = false;
            this.dgvBlock.AllowUserToResizeRows = false;
            this.dgvBlock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBlock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBlock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBorderColor,
            this.colFillColor,
            this.colHPos,
            this.colVPos});
            this.dgvBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBlock.Location = new System.Drawing.Point(0, 25);
            this.dgvBlock.MultiSelect = false;
            this.dgvBlock.Name = "dgvBlock";
            this.dgvBlock.ReadOnly = true;
            this.dgvBlock.RowHeadersVisible = false;
            this.dgvBlock.RowTemplate.Height = 23;
            this.dgvBlock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBlock.Size = new System.Drawing.Size(253, 390);
            this.dgvBlock.TabIndex = 0;
            this.dgvBlock.SelectionChanged += new System.EventHandler(this.dgvBlock_SelectionChanged);
            // 
            // colBorderColor
            // 
            this.colBorderColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colBorderColor.FillWeight = 131.9797F;
            this.colBorderColor.HeaderText = "边框颜色";
            this.colBorderColor.Name = "colBorderColor";
            this.colBorderColor.ReadOnly = true;
            this.colBorderColor.Width = 60;
            // 
            // colFillColor
            // 
            this.colFillColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFillColor.FillWeight = 89.3401F;
            this.colFillColor.HeaderText = "填充颜色";
            this.colFillColor.Name = "colFillColor";
            this.colFillColor.ReadOnly = true;
            this.colFillColor.Width = 60;
            // 
            // colHPos
            // 
            this.colHPos.DataPropertyName = "X";
            this.colHPos.FillWeight = 89.3401F;
            this.colHPos.HeaderText = "水平位置";
            this.colHPos.Name = "colHPos";
            this.colHPos.ReadOnly = true;
            // 
            // colVPos
            // 
            this.colVPos.DataPropertyName = "Y";
            this.colVPos.FillWeight = 89.3401F;
            this.colVPos.HeaderText = "垂直位置";
            this.colVPos.Name = "colVPos";
            this.colVPos.ReadOnly = true;
            // 
            // pnlBlock
            // 
            this.pnlBlock.AutoSize = true;
            this.pnlBlock.Controls.Add(this.tsBlock);
            this.pnlBlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBlock.Location = new System.Drawing.Point(0, 0);
            this.pnlBlock.Name = "pnlBlock";
            this.pnlBlock.Size = new System.Drawing.Size(253, 25);
            this.pnlBlock.TabIndex = 9;
            // 
            // tsBlock
            // 
            this.tsBlock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddBlock,
            this.tsbEditBlock,
            this.tsbDeleteBlock});
            this.tsBlock.Location = new System.Drawing.Point(0, 0);
            this.tsBlock.Name = "tsBlock";
            this.tsBlock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsBlock.Size = new System.Drawing.Size(253, 25);
            this.tsBlock.TabIndex = 9;
            this.tsBlock.Text = "toolStrip1";
            // 
            // tsbAddBlock
            // 
            this.tsbAddBlock.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_add;
            this.tsbAddBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddBlock.Name = "tsbAddBlock";
            this.tsbAddBlock.Size = new System.Drawing.Size(52, 22);
            this.tsbAddBlock.Tag = "Add";
            this.tsbAddBlock.Text = "新建";
            this.tsbAddBlock.Click += new System.EventHandler(this.tsbAddBlock_Click);
            // 
            // tsbEditBlock
            // 
            this.tsbEditBlock.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_edit;
            this.tsbEditBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditBlock.Name = "tsbEditBlock";
            this.tsbEditBlock.Size = new System.Drawing.Size(52, 22);
            this.tsbEditBlock.Tag = "Edit";
            this.tsbEditBlock.Text = "编辑";
            this.tsbEditBlock.Click += new System.EventHandler(this.tsbEditBlock_Click);
            // 
            // tsbDeleteBlock
            // 
            this.tsbDeleteBlock.Image = global::Shmzh.Monitor.Forms.Properties.Resources.folder_delete;
            this.tsbDeleteBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteBlock.Name = "tsbDeleteBlock";
            this.tsbDeleteBlock.Size = new System.Drawing.Size(52, 22);
            this.tsbDeleteBlock.Tag = "Delete";
            this.tsbDeleteBlock.Text = "删除";
            this.tsbDeleteBlock.Click += new System.EventHandler(this.tsbDeleteBlock_Click);
            // 
            // dgvBlockItem
            // 
            this.dgvBlockItem.AllowUserToAddRows = false;
            this.dgvBlockItem.AllowUserToDeleteRows = false;
            this.dgvBlockItem.AllowUserToResizeRows = false;
            this.dgvBlockItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBlockItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBlockItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBlockItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvBlockItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBlockItem.Location = new System.Drawing.Point(0, 25);
            this.dgvBlockItem.MultiSelect = false;
            this.dgvBlockItem.Name = "dgvBlockItem";
            this.dgvBlockItem.ReadOnly = true;
            this.dgvBlockItem.RowHeadersVisible = false;
            this.dgvBlockItem.RowTemplate.Height = 23;
            this.dgvBlockItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBlockItem.Size = new System.Drawing.Size(447, 390);
            this.dgvBlockItem.TabIndex = 0;
            this.dgvBlockItem.SelectionChanged += new System.EventHandler(this.dgvBlockItem_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Label";
            this.Column1.HeaderText = "标签";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Unit";
            this.Column2.HeaderText = "单位";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TagExp";
            this.Column3.HeaderText = "指标";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "数据类别";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // pnlBlockItem
            // 
            this.pnlBlockItem.AutoSize = true;
            this.pnlBlockItem.Controls.Add(this.tsBlockItem);
            this.pnlBlockItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBlockItem.Location = new System.Drawing.Point(0, 0);
            this.pnlBlockItem.Name = "pnlBlockItem";
            this.pnlBlockItem.Size = new System.Drawing.Size(447, 25);
            this.pnlBlockItem.TabIndex = 9;
            // 
            // tsBlockItem
            // 
            this.tsBlockItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddBlockItem,
            this.tsbEditBlockItem,
            this.tsbDeleteBlockItem,
            this.tsbUpBlockItem,
            this.tsbDownBlockItem});
            this.tsBlockItem.Location = new System.Drawing.Point(0, 0);
            this.tsBlockItem.Name = "tsBlockItem";
            this.tsBlockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsBlockItem.Size = new System.Drawing.Size(447, 25);
            this.tsBlockItem.TabIndex = 9;
            this.tsBlockItem.Text = "toolStrip2";
            // 
            // tsbAddBlockItem
            // 
            this.tsbAddBlockItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.add;
            this.tsbAddBlockItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddBlockItem.Name = "tsbAddBlockItem";
            this.tsbAddBlockItem.Size = new System.Drawing.Size(52, 22);
            this.tsbAddBlockItem.Tag = "Add";
            this.tsbAddBlockItem.Text = "新建";
            this.tsbAddBlockItem.Click += new System.EventHandler(this.tsbAddBlockItem_Click);
            // 
            // tsbEditBlockItem
            // 
            this.tsbEditBlockItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.pencil;
            this.tsbEditBlockItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditBlockItem.Name = "tsbEditBlockItem";
            this.tsbEditBlockItem.Size = new System.Drawing.Size(52, 22);
            this.tsbEditBlockItem.Tag = "Edit";
            this.tsbEditBlockItem.Text = "编辑";
            this.tsbEditBlockItem.Click += new System.EventHandler(this.tsbEditBlockItem_Click);
            // 
            // tsbDeleteBlockItem
            // 
            this.tsbDeleteBlockItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.delete;
            this.tsbDeleteBlockItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteBlockItem.Name = "tsbDeleteBlockItem";
            this.tsbDeleteBlockItem.Size = new System.Drawing.Size(52, 22);
            this.tsbDeleteBlockItem.Tag = "Delete";
            this.tsbDeleteBlockItem.Text = "删除";
            this.tsbDeleteBlockItem.Click += new System.EventHandler(this.tsbDeleteBlockItem_Click);
            // 
            // tsbUpBlockItem
            // 
            this.tsbUpBlockItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.up;
            this.tsbUpBlockItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpBlockItem.Name = "tsbUpBlockItem";
            this.tsbUpBlockItem.Size = new System.Drawing.Size(52, 22);
            this.tsbUpBlockItem.Text = "上移";
            this.tsbUpBlockItem.Click += new System.EventHandler(this.tsbUpBlockItem_Click);
            // 
            // tsbDownBlockItem
            // 
            this.tsbDownBlockItem.Image = global::Shmzh.Monitor.Forms.Properties.Resources.down;
            this.tsbDownBlockItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownBlockItem.Name = "tsbDownBlockItem";
            this.tsbDownBlockItem.Size = new System.Drawing.Size(52, 22);
            this.tsbDownBlockItem.Text = "下移";
            this.tsbDownBlockItem.Click += new System.EventHandler(this.tsbDownBlockItem_Click);
            // 
            // FrmFloatingBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 415);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmFloatingBlock";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浮动窗口";
            this.Load += new System.EventHandler(this.FrmFloatingBlock_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlock)).EndInit();
            this.pnlBlock.ResumeLayout(false);
            this.pnlBlock.PerformLayout();
            this.tsBlock.ResumeLayout(false);
            this.tsBlock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockItem)).EndInit();
            this.pnlBlockItem.ResumeLayout(false);
            this.pnlBlockItem.PerformLayout();
            this.tsBlockItem.ResumeLayout(false);
            this.tsBlockItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvBlock;
        private System.Windows.Forms.DataGridView dgvBlockItem;
        private System.Windows.Forms.Panel pnlBlock;
        private System.Windows.Forms.ToolStrip tsBlock;
        private System.Windows.Forms.ToolStripButton tsbAddBlock;
        private System.Windows.Forms.ToolStripButton tsbEditBlock;
        private System.Windows.Forms.ToolStripButton tsbDeleteBlock;
        private System.Windows.Forms.Panel pnlBlockItem;
        private System.Windows.Forms.ToolStrip tsBlockItem;
        private System.Windows.Forms.ToolStripButton tsbAddBlockItem;
        private System.Windows.Forms.ToolStripButton tsbEditBlockItem;
        private System.Windows.Forms.ToolStripButton tsbDeleteBlockItem;
        private System.Windows.Forms.ToolStripButton tsbUpBlockItem;
        private System.Windows.Forms.ToolStripButton tsbDownBlockItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBorderColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFillColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}