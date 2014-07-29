namespace Shmzh.Gather.DataService.Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Tag = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_DateTime = new System.Windows.Forms.DateTimePicker();
            this.button_Go = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_Hour = new System.Windows.Forms.RadioButton();
            this.radioButton_Day = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "指标：";
            // 
            // comboBox_Tag
            // 
            this.comboBox_Tag.FormattingEnabled = true;
            this.comboBox_Tag.Items.AddRange(new object[] {
            "5003001",
            "5103001"});
            this.comboBox_Tag.Location = new System.Drawing.Point(59, 12);
            this.comboBox_Tag.Name = "comboBox_Tag";
            this.comboBox_Tag.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Tag.TabIndex = 1;
            // 
            // dateTimePicker_DateTime
            // 
            this.dateTimePicker_DateTime.Location = new System.Drawing.Point(245, 12);
            this.dateTimePicker_DateTime.Name = "dateTimePicker_DateTime";
            this.dateTimePicker_DateTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_DateTime.TabIndex = 2;
            // 
            // button_Go
            // 
            this.button_Go.Location = new System.Drawing.Point(545, 10);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(75, 23);
            this.button_Go.TabIndex = 3;
            this.button_Go.Text = "Go";
            this.button_Go.UseVisualStyleBackColor = true;
            this.button_Go.Click += new System.EventHandler(this.button_Go_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "日期：";
            // 
            // radioButton_Hour
            // 
            this.radioButton_Hour.AutoSize = true;
            this.radioButton_Hour.Checked = true;
            this.radioButton_Hour.Location = new System.Drawing.Point(451, 17);
            this.radioButton_Hour.Name = "radioButton_Hour";
            this.radioButton_Hour.Size = new System.Drawing.Size(47, 16);
            this.radioButton_Hour.TabIndex = 5;
            this.radioButton_Hour.TabStop = true;
            this.radioButton_Hour.Text = "小时";
            this.radioButton_Hour.UseVisualStyleBackColor = true;
            // 
            // radioButton_Day
            // 
            this.radioButton_Day.AutoSize = true;
            this.radioButton_Day.Location = new System.Drawing.Point(504, 17);
            this.radioButton_Day.Name = "radioButton_Day";
            this.radioButton_Day.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Day.TabIndex = 6;
            this.radioButton_Day.Text = "日";
            this.radioButton_Day.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(638, 328);
            this.dataGridView1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox_Tag);
            this.panel1.Controls.Add(this.button_Go);
            this.panel1.Controls.Add(this.radioButton_Day);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.radioButton_Hour);
            this.panel1.Controls.Add(this.dateTimePicker_DateTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 50);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 328);
            this.panel2.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 378);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Shmzh.Gather.DataService.Test";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Tag;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DateTime;
        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_Hour;
        private System.Windows.Forms.RadioButton radioButton_Day;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

