namespace Shmzh.Monitor.Forms
{
    partial class FrmFloatingBlockEdit
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
            this.lblScheme = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbLableFontFamily = new System.Windows.Forms.ComboBox();
            this.txtLableFontSize = new System.Windows.Forms.TextBox();
            this.cpLableForeColor = new Shmzh.Windows.Forms.Pickers.ColorPicker();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.cpFillColor = new Shmzh.Windows.Forms.Pickers.ColorPicker();
            this.cpBorderColor = new Shmzh.Windows.Forms.Pickers.ColorPicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsLabelInLine = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.chkIsAutoSize = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScheme
            // 
            this.lblScheme.AutoSize = true;
            this.lblScheme.Location = new System.Drawing.Point(80, 8);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(53, 12);
            this.lblScheme.TabIndex = 3;
            this.lblScheme.Text = "方案名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "方案：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "边框颜色：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "填充颜色：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "字体：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "字体大小：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "字体颜色：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "水平位置：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "垂直位置：";
            // 
            // cbLableFontFamily
            // 
            this.cbLableFontFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbLableFontFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLableFontFamily.FormattingEnabled = true;
            this.cbLableFontFamily.Location = new System.Drawing.Point(80, 95);
            this.cbLableFontFamily.MaxDropDownItems = 12;
            this.cbLableFontFamily.MaxLength = 30;
            this.cbLableFontFamily.Name = "cbLableFontFamily";
            this.cbLableFontFamily.Size = new System.Drawing.Size(121, 20);
            this.cbLableFontFamily.TabIndex = 19;
            // 
            // txtLableFontSize
            // 
            this.txtLableFontSize.Location = new System.Drawing.Point(286, 94);
            this.txtLableFontSize.MaxLength = 3;
            this.txtLableFontSize.Name = "txtLableFontSize";
            this.txtLableFontSize.Size = new System.Drawing.Size(51, 21);
            this.txtLableFontSize.TabIndex = 3;
            // 
            // cpLableForeColor
            // 
            this.cpLableForeColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpLableForeColor.Location = new System.Drawing.Point(80, 125);
            this.cpLableForeColor.Name = "cpLableForeColor";
            this.cpLableForeColor.Size = new System.Drawing.Size(196, 21);
            this.cpLableForeColor.TabIndex = 4;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(80, 157);
            this.txtX.MaxLength = 6;
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(51, 21);
            this.txtX.TabIndex = 5;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(286, 157);
            this.txtY.MaxLength = 6;
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(51, 21);
            this.txtY.TabIndex = 6;
            // 
            // cpFillColor
            // 
            this.cpFillColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpFillColor.Location = new System.Drawing.Point(80, 64);
            this.cpFillColor.Name = "cpFillColor";
            this.cpFillColor.Size = new System.Drawing.Size(196, 21);
            this.cpFillColor.TabIndex = 2;
            // 
            // cpBorderColor
            // 
            this.cpBorderColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpBorderColor.Location = new System.Drawing.Point(80, 33);
            this.cpBorderColor.Name = "cpBorderColor";
            this.cpBorderColor.Size = new System.Drawing.Size(196, 21);
            this.cpBorderColor.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(79, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsLabelInLine
            // 
            this.chkIsLabelInLine.AutoSize = true;
            this.chkIsLabelInLine.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsLabelInLine.Location = new System.Drawing.Point(193, 218);
            this.chkIsLabelInLine.Name = "chkIsLabelInLine";
            this.chkIsLabelInLine.Size = new System.Drawing.Size(144, 16);
            this.chkIsLabelInLine.TabIndex = 20;
            this.chkIsLabelInLine.Text = "标签与值显示在同一行";
            this.chkIsLabelInLine.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "宽度：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(215, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "高度：";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(80, 187);
            this.txtWidth.MaxLength = 4;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(51, 21);
            this.txtWidth.TabIndex = 5;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(286, 187);
            this.txtHeight.MaxLength = 4;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(51, 21);
            this.txtHeight.TabIndex = 6;
            // 
            // chkIsAutoSize
            // 
            this.chkIsAutoSize.AutoSize = true;
            this.chkIsAutoSize.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsAutoSize.Location = new System.Drawing.Point(12, 218);
            this.chkIsAutoSize.Name = "chkIsAutoSize";
            this.chkIsAutoSize.Size = new System.Drawing.Size(96, 16);
            this.chkIsAutoSize.TabIndex = 20;
            this.chkIsAutoSize.Text = "自动调整大小";
            this.chkIsAutoSize.UseVisualStyleBackColor = true;
            this.chkIsAutoSize.CheckedChanged += new System.EventHandler(this.chkIsAutoSize_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmFloatingBlockEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(350, 281);
            this.Controls.Add(this.chkIsAutoSize);
            this.Controls.Add(this.chkIsLabelInLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cpBorderColor);
            this.Controls.Add(this.cpFillColor);
            this.Controls.Add(this.cpLableForeColor);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtLableFontSize);
            this.Controls.Add(this.cbLableFontFamily);
            this.Controls.Add(this.lblScheme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmFloatingBlockEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmFloatingBlockEdit";
            this.Load += new System.EventHandler(this.FrmFloatingBlockEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbLableFontFamily;
        private System.Windows.Forms.TextBox txtLableFontSize;
        private Shmzh.Windows.Forms.Pickers.ColorPicker cpLableForeColor;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private Shmzh.Windows.Forms.Pickers.ColorPicker cpFillColor;
        private Shmzh.Windows.Forms.Pickers.ColorPicker cpBorderColor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkIsLabelInLine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.CheckBox chkIsAutoSize;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}