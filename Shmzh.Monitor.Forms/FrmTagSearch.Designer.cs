namespace Shmzh.Monitor.Forms
{
    partial class FrmTagSearch
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTagName = new System.Windows.Forms.TextBox();
            this.txtTagId = new System.Windows.Forms.TextBox();
            this.txtTagType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgTagMS = new System.Windows.Forms.TabPage();
            this.dgvTagMS = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpgTagGather = new System.Windows.Forms.TabPage();
            this.dgvTagGather = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpgTagMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagMS)).BeginInit();
            this.tpgTagGather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagGather)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.txtTagName);
            this.pnlTop.Controls.Add(this.txtTagId);
            this.pnlTop.Controls.Add(this.txtTagType);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(737, 37);
            this.pnlTop.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(513, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTagName
            // 
            this.txtTagName.Location = new System.Drawing.Point(394, 8);
            this.txtTagName.MaxLength = 180;
            this.txtTagName.Name = "txtTagName";
            this.txtTagName.Size = new System.Drawing.Size(100, 21);
            this.txtTagName.TabIndex = 3;
            // 
            // txtTagId
            // 
            this.txtTagId.Location = new System.Drawing.Point(212, 8);
            this.txtTagId.MaxLength = 8;
            this.txtTagId.Name = "txtTagId";
            this.txtTagId.Size = new System.Drawing.Size(100, 21);
            this.txtTagId.TabIndex = 2;
            // 
            // txtTagType
            // 
            this.txtTagType.Location = new System.Drawing.Point(74, 8);
            this.txtTagType.MaxLength = 3;
            this.txtTagType.Name = "txtTagType";
            this.txtTagType.Size = new System.Drawing.Size(58, 21);
            this.txtTagType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "指标名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "指标编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "指标类型：";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabControl1);
            this.pnlMain.Controls.Add(this.statusStrip1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 37);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(737, 418);
            this.pnlMain.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgTagMS);
            this.tabControl1.Controls.Add(this.tpgTagGather);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 396);
            this.tabControl1.TabIndex = 1;
            // 
            // tpgTagMS
            // 
            this.tpgTagMS.Controls.Add(this.dgvTagMS);
            this.tpgTagMS.Location = new System.Drawing.Point(4, 21);
            this.tpgTagMS.Name = "tpgTagMS";
            this.tpgTagMS.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTagMS.Size = new System.Drawing.Size(729, 371);
            this.tpgTagMS.TabIndex = 0;
            this.tpgTagMS.Text = "所有指标数据";
            this.tpgTagMS.UseVisualStyleBackColor = true;
            // 
            // dgvTagMS
            // 
            this.dgvTagMS.AllowUserToAddRows = false;
            this.dgvTagMS.AllowUserToDeleteRows = false;
            this.dgvTagMS.AllowUserToResizeRows = false;
            this.dgvTagMS.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTagMS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTagMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTagMS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27});
            this.dgvTagMS.ContextMenuStrip = this.contextMenuCopy;
            this.dgvTagMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTagMS.Location = new System.Drawing.Point(3, 3);
            this.dgvTagMS.Name = "dgvTagMS";
            this.dgvTagMS.ReadOnly = true;
            this.dgvTagMS.RowTemplate.Height = 23;
            this.dgvTagMS.Size = new System.Drawing.Size(723, 365);
            this.dgvTagMS.TabIndex = 5;
            this.dgvTagMS.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "I_Tag_Type";
            this.Column10.HeaderText = "指标类型";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 78;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "I_Tag_Id";
            this.Column11.HeaderText = "指标编号";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 78;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "I_Tag_Name";
            this.Column12.HeaderText = "指标名称";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 78;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "I_Dig_Num";
            this.Column13.HeaderText = "小数位";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 66;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "I_Unit";
            this.Column14.HeaderText = "单位";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 54;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "Calc_Type_Before_Hour";
            this.Column15.HeaderText = "小时前计";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 78;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "Calc_Type_After_Hour";
            this.Column16.HeaderText = "小时后计";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 78;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "Second_To_Minute";
            this.Column17.HeaderText = "秒到分";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 66;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "Minute_To_Min5";
            this.Column18.HeaderText = "分到5分";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 72;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "Minute_To_Hour";
            this.Column19.HeaderText = "分到时";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Width = 66;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "Hour_To_Day";
            this.Column20.HeaderText = "时到天";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Width = 66;
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "Day_To_Month";
            this.Column21.HeaderText = "天到月";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.Width = 66;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "Month_To_Year";
            this.Column22.HeaderText = "月到年";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.Width = 66;
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "Remark";
            this.Column23.HeaderText = "备注";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.Width = 54;
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "Func";
            this.Column24.HeaderText = "公式";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            this.Column24.Width = 54;
            // 
            // Column25
            // 
            this.Column25.DataPropertyName = "Max_Value";
            this.Column25.HeaderText = "最大值";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            this.Column25.Width = 66;
            // 
            // Column26
            // 
            this.Column26.DataPropertyName = "Min_Value";
            this.Column26.HeaderText = "最小值";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            this.Column26.Width = 66;
            // 
            // Column27
            // 
            this.Column27.DataPropertyName = "Dev_Code";
            this.Column27.HeaderText = "设备编号";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            this.Column27.Width = 78;
            // 
            // tpgTagGather
            // 
            this.tpgTagGather.Controls.Add(this.dgvTagGather);
            this.tpgTagGather.Location = new System.Drawing.Point(4, 21);
            this.tpgTagGather.Name = "tpgTagGather";
            this.tpgTagGather.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTagGather.Size = new System.Drawing.Size(729, 371);
            this.tpgTagGather.TabIndex = 1;
            this.tpgTagGather.Text = "自动采集指标数据";
            this.tpgTagGather.UseVisualStyleBackColor = true;
            // 
            // dgvTagGather
            // 
            this.dgvTagGather.AllowUserToAddRows = false;
            this.dgvTagGather.AllowUserToDeleteRows = false;
            this.dgvTagGather.AllowUserToOrderColumns = true;
            this.dgvTagGather.AllowUserToResizeRows = false;
            this.dgvTagGather.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTagGather.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTagGather.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTagGather.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTagGather.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvTagGather.ContextMenuStrip = this.contextMenuCopy;
            this.dgvTagGather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTagGather.Location = new System.Drawing.Point(3, 3);
            this.dgvTagGather.Name = "dgvTagGather";
            this.dgvTagGather.ReadOnly = true;
            this.dgvTagGather.RowTemplate.Height = 23;
            this.dgvTagGather.Size = new System.Drawing.Size(723, 365);
            this.dgvTagGather.TabIndex = 6;
            this.dgvTagGather.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "I_TAG_ID";
            this.Column1.HeaderText = "指标编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "I_DESIGN_CD";
            this.Column2.HeaderText = "I_DESIGN_CD";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "I_ADDRESS";
            this.Column3.HeaderText = "地址";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "I_PARA_A";
            this.Column4.HeaderText = "参数 A";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "I_PARA_B";
            this.Column5.HeaderText = "参数 B";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "I_PARA_C";
            this.Column6.HeaderText = "参数 C";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "I_MAX";
            this.Column7.HeaderText = "最大值";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "I_MIN";
            this.Column8.HeaderText = "最小值";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "I_ACTION";
            this.Column9.HeaderText = "是否采集";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(737, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLabel
            // 
            this.tsStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsStatusLabel.Name = "tsStatusLabel";
            this.tsStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopy});
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShowImageMargin = false;
            this.contextMenuCopy.Size = new System.Drawing.Size(121, 26);
            // 
            // menuCopy
            // 
            this.menuCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(120, 22);
            this.menuCopy.Text = "复制";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // FrmTagSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 455);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmTagSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指标查询";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpgTagMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagMS)).EndInit();
            this.tpgTagGather.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagGather)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuCopy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtTagName;
        private System.Windows.Forms.TextBox txtTagId;
        private System.Windows.Forms.TextBox txtTagType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgTagMS;
        private System.Windows.Forms.TabPage tpgTagGather;
        private System.Windows.Forms.DataGridView dgvTagMS;
        private System.Windows.Forms.DataGridView dgvTagGather;
        //private Shmzh.Windows.Forms.MzhDataGridView dgvTagMS;
        //private Shmzh.Windows.Forms.MzhDataGridView dgvTagGather;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
    }
}