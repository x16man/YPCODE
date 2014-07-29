namespace Shmzh.Monitor.Forms
{
    partial class FrmFloatingBlockItemEdit
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
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTagExp = new System.Windows.Forms.TextBox();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.lblDataType = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbValueFontFamily = new System.Windows.Forms.ComboBox();
            this.txtValueFontSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cpValueForeColor = new Shmzh.Windows.Forms.Pickers.ColorPicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnitFontSize = new System.Windows.Forms.TextBox();
            this.cbUnitFontFamily = new System.Windows.Forms.ComboBox();
            this.cpUnitForeColor = new Shmzh.Windows.Forms.Pickers.ColorPicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(60, 14);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(274, 21);
            this.txtLabel.TabIndex = 1;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(12, 18);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(41, 12);
            this.lblLabel.TabIndex = 4;
            this.lblLabel.Text = "标签：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "单位：";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(60, 104);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(121, 21);
            this.txtUnit.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "指标：";
            // 
            // txtTagExp
            // 
            this.txtTagExp.Location = new System.Drawing.Point(60, 46);
            this.txtTagExp.MaxLength = 500;
            this.txtTagExp.Multiline = true;
            this.txtTagExp.Name = "txtTagExp";
            this.txtTagExp.Size = new System.Drawing.Size(392, 48);
            this.txtTagExp.TabIndex = 2;
            // 
            // cbDataType
            // 
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(339, 108);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(113, 20);
            this.cbDataType.TabIndex = 19;
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(256, 112);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(65, 12);
            this.lblDataType.TabIndex = 18;
            this.lblDataType.Text = "数据类型：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "字体";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "字体大小";
            // 
            // cbValueFontFamily
            // 
            this.cbValueFontFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbValueFontFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbValueFontFamily.FormattingEnabled = true;
            this.cbValueFontFamily.Location = new System.Drawing.Point(123, 156);
            this.cbValueFontFamily.MaxDropDownItems = 12;
            this.cbValueFontFamily.MaxLength = 30;
            this.cbValueFontFamily.Name = "cbValueFontFamily";
            this.cbValueFontFamily.Size = new System.Drawing.Size(121, 20);
            this.cbValueFontFamily.TabIndex = 29;
            // 
            // txtValueFontSize
            // 
            this.txtValueFontSize.Location = new System.Drawing.Point(60, 156);
            this.txtValueFontSize.MaxLength = 3;
            this.txtValueFontSize.Name = "txtValueFontSize";
            this.txtValueFontSize.Size = new System.Drawing.Size(51, 21);
            this.txtValueFontSize.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "颜色";
            // 
            // cpValueForeColor
            // 
            this.cpValueForeColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpValueForeColor.Location = new System.Drawing.Point(256, 156);
            this.cpValueForeColor.Name = "cpValueForeColor";
            this.cpValueForeColor.Size = new System.Drawing.Size(196, 21);
            this.cpValueForeColor.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "单位：";
            // 
            // txtUnitFontSize
            // 
            this.txtUnitFontSize.Location = new System.Drawing.Point(60, 183);
            this.txtUnitFontSize.MaxLength = 3;
            this.txtUnitFontSize.Name = "txtUnitFontSize";
            this.txtUnitFontSize.Size = new System.Drawing.Size(51, 21);
            this.txtUnitFontSize.TabIndex = 6;
            // 
            // cbUnitFontFamily
            // 
            this.cbUnitFontFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUnitFontFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUnitFontFamily.FormattingEnabled = true;
            this.cbUnitFontFamily.Location = new System.Drawing.Point(123, 183);
            this.cbUnitFontFamily.MaxDropDownItems = 12;
            this.cbUnitFontFamily.MaxLength = 30;
            this.cbUnitFontFamily.Name = "cbUnitFontFamily";
            this.cbUnitFontFamily.Size = new System.Drawing.Size(121, 20);
            this.cbUnitFontFamily.TabIndex = 29;
            // 
            // cpUnitForeColor
            // 
            this.cpUnitForeColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpUnitForeColor.Location = new System.Drawing.Point(256, 183);
            this.cpUnitForeColor.Name = "cpUnitForeColor";
            this.cpUnitForeColor.Size = new System.Drawing.Size(196, 21);
            this.cpUnitForeColor.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(254, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(136, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmFloatingBlockItemEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 248);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cpUnitForeColor);
            this.Controls.Add(this.cpValueForeColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbUnitFontFamily);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtUnitFontSize);
            this.Controls.Add(this.cbValueFontFamily);
            this.Controls.Add(this.txtValueFontSize);
            this.Controls.Add(this.cbDataType);
            this.Controls.Add(this.lblDataType);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtTagExp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmFloatingBlockItemEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmFloatingBlockItemEdit";
            this.Load += new System.EventHandler(this.FrmFloatingBlockItemEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTagExp;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbValueFontFamily;
        private System.Windows.Forms.TextBox txtValueFontSize;
        private System.Windows.Forms.Label label3;
        private Shmzh.Windows.Forms.Pickers.ColorPicker cpValueForeColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnitFontSize;
        private System.Windows.Forms.ComboBox cbUnitFontFamily;
        private Shmzh.Windows.Forms.Pickers.ColorPicker cpUnitForeColor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}