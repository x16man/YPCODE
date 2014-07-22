namespace Shmzh.Monitor.Forms
{
    partial class FrmTagAndTemperature
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbEndWater = new System.Windows.Forms.ComboBox();
            this.cbEndTemperature = new System.Windows.Forms.ComboBox();
            this.cbStartWater = new System.Windows.Forms.ComboBox();
            this.cbStartTemperature = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTags = new System.Windows.Forms.ComboBox();
            this.btnSelectTas = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.cbEndWater);
            this.pnlTop.Controls.Add(this.cbEndTemperature);
            this.pnlTop.Controls.Add(this.cbStartWater);
            this.pnlTop.Controls.Add(this.cbStartTemperature);
            this.pnlTop.Controls.Add(this.dtpEndDate);
            this.pnlTop.Controls.Add(this.dtpStartDate);
            this.pnlTop.Controls.Add(this.label7);
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.label6);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.cbTags);
            this.pnlTop.Controls.Add(this.btnSelectTas);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(740, 64);
            this.pnlTop.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(642, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbEndWater
            // 
            this.cbEndWater.DropDownHeight = 150;
            this.cbEndWater.FormattingEnabled = true;
            this.cbEndWater.IntegralHeight = false;
            this.cbEndWater.Items.AddRange(new object[] {
            "0",
            "1000",
            "5000",
            "10000",
            "50000",
            "100000",
            "500000",
            "1000000",
            "5000000",
            "10000000",
            "50000000"});
            this.cbEndWater.Location = new System.Drawing.Point(540, 36);
            this.cbEndWater.Name = "cbEndWater";
            this.cbEndWater.Size = new System.Drawing.Size(97, 20);
            this.cbEndWater.TabIndex = 22;
            this.cbEndWater.Text = "100000";
            // 
            // cbEndTemperature
            // 
            this.cbEndTemperature.FormattingEnabled = true;
            this.cbEndTemperature.Items.AddRange(new object[] {
            "-20",
            "-10",
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cbEndTemperature.Location = new System.Drawing.Point(202, 36);
            this.cbEndTemperature.Name = "cbEndTemperature";
            this.cbEndTemperature.Size = new System.Drawing.Size(97, 20);
            this.cbEndTemperature.TabIndex = 22;
            this.cbEndTemperature.Text = "20";
            // 
            // cbStartWater
            // 
            this.cbStartWater.DropDownHeight = 150;
            this.cbStartWater.FormattingEnabled = true;
            this.cbStartWater.IntegralHeight = false;
            this.cbStartWater.Items.AddRange(new object[] {
            "0",
            "1000",
            "5000",
            "10000",
            "50000",
            "100000",
            "500000",
            "1000000",
            "5000000",
            "10000000",
            "50000000"});
            this.cbStartWater.Location = new System.Drawing.Point(414, 36);
            this.cbStartWater.Name = "cbStartWater";
            this.cbStartWater.Size = new System.Drawing.Size(97, 20);
            this.cbStartWater.TabIndex = 22;
            this.cbStartWater.Text = "0";
            // 
            // cbStartTemperature
            // 
            this.cbStartTemperature.FormattingEnabled = true;
            this.cbStartTemperature.Items.AddRange(new object[] {
            "-20",
            "-10",
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cbStartTemperature.Location = new System.Drawing.Point(76, 36);
            this.cbStartTemperature.Name = "cbStartTemperature";
            this.cbStartTemperature.Size = new System.Drawing.Size(97, 20);
            this.cbStartTemperature.TabIndex = 22;
            this.cbStartTemperature.Text = "0";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(202, 7);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(97, 21);
            this.dtpEndDate.TabIndex = 21;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(76, 7);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(97, 21);
            this.dtpStartDate.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(517, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "至";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "至";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "总出厂水水量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "温度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "指标名：";
            // 
            // cbTags
            // 
            this.cbTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTags.DropDownWidth = 223;
            this.cbTags.FormattingEnabled = true;
            this.cbTags.Location = new System.Drawing.Point(414, 7);
            this.cbTags.Name = "cbTags";
            this.cbTags.Size = new System.Drawing.Size(223, 20);
            this.cbTags.TabIndex = 19;
            // 
            // btnSelectTas
            // 
            this.btnSelectTas.Location = new System.Drawing.Point(642, 6);
            this.btnSelectTas.Name = "btnSelectTas";
            this.btnSelectTas.Size = new System.Drawing.Size(64, 23);
            this.btnSelectTas.TabIndex = 18;
            this.btnSelectTas.Text = "选择";
            this.btnSelectTas.UseVisualStyleBackColor = true;
            this.btnSelectTas.Click += new System.EventHandler(this.btnSelectTas_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvResult);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 64);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(740, 362);
            this.pnlMain.TabIndex = 1;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(740, 362);
            this.dgvResult.TabIndex = 0;
            this.dgvResult.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // FrmTagAndTemperature
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 426);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmTagAndTemperature";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "气温、总出厂水与指标关系查询";
            this.Load += new System.EventHandler(this.FrmTagAndTemperature_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTags;
        private System.Windows.Forms.Button btnSelectTas;
        private System.Windows.Forms.ComboBox cbEndWater;
        private System.Windows.Forms.ComboBox cbEndTemperature;
        private System.Windows.Forms.ComboBox cbStartWater;
        private System.Windows.Forms.ComboBox cbStartTemperature;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvResult;
    }
}