namespace Shmzh.Monitor.Forms
{
    partial class FrmGraphSchemaRTagEdit
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.lblDataType = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtTagId = new System.Windows.Forms.TextBox();
            this.lblTagId = new System.Windows.Forms.Label();
            this.txtTagName = new System.Windows.Forms.TextBox();
            this.lblTagName = new System.Windows.Forms.Label();
            this.lblScheme = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.cbDataType);
            this.panelMain.Controls.Add(this.lblDataType);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.txtUnit);
            this.panelMain.Controls.Add(this.lblUnit);
            this.panelMain.Controls.Add(this.txtTagId);
            this.panelMain.Controls.Add(this.lblTagId);
            this.panelMain.Controls.Add(this.txtTagName);
            this.panelMain.Controls.Add(this.lblTagName);
            this.panelMain.Controls.Add(this.lblScheme);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(371, 236);
            this.panelMain.TabIndex = 0;
            // 
            // cbDataType
            // 
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(77, 126);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(274, 20);
            this.cbDataType.TabIndex = 19;
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(13, 130);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(65, 12);
            this.lblDataType.TabIndex = 18;
            this.lblDataType.Text = "数据类型：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(276, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(183, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(77, 164);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(274, 21);
            this.txtUnit.TabIndex = 7;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(25, 168);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(53, 12);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "单  位：";
            // 
            // txtTagId
            // 
            this.txtTagId.Location = new System.Drawing.Point(77, 88);
            this.txtTagId.MaxLength = 300;
            this.txtTagId.Name = "txtTagId";
            this.txtTagId.Size = new System.Drawing.Size(274, 21);
            this.txtTagId.TabIndex = 5;
            // 
            // lblTagId
            // 
            this.lblTagId.AutoSize = true;
            this.lblTagId.Location = new System.Drawing.Point(25, 92);
            this.lblTagId.Name = "lblTagId";
            this.lblTagId.Size = new System.Drawing.Size(53, 12);
            this.lblTagId.TabIndex = 4;
            this.lblTagId.Text = "指  标：";
            // 
            // txtTagName
            // 
            this.txtTagName.Location = new System.Drawing.Point(77, 52);
            this.txtTagName.Name = "txtTagName";
            this.txtTagName.Size = new System.Drawing.Size(274, 21);
            this.txtTagName.TabIndex = 3;
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Location = new System.Drawing.Point(25, 56);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(53, 12);
            this.lblTagName.TabIndex = 2;
            this.lblTagName.Text = "指标名：";
            // 
            // lblScheme
            // 
            this.lblScheme.AutoSize = true;
            this.lblScheme.Location = new System.Drawing.Point(75, 25);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(41, 12);
            this.lblScheme.TabIndex = 1;
            this.lblScheme.Text = "标签名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标签名：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmGraphSchemaRTagEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 236);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGraphSchemaRTagEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "方案项编辑";
            this.Load += new System.EventHandler(this.FrmGraphSchemeItemEdit_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.TextBox txtTagName;
        private System.Windows.Forms.Label lblTagName;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtTagId;
        private System.Windows.Forms.Label lblTagId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}