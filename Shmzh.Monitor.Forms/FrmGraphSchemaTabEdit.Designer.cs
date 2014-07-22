namespace Shmzh.Monitor.Forms
{
    partial class FrmGraphSchemaTabEdit
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTabType = new System.Windows.Forms.Label();
            this.txtTabName = new System.Windows.Forms.TextBox();
            this.lblTabName = new System.Windows.Forms.Label();
            this.lblScheme = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTabType = new System.Windows.Forms.ComboBox();
            this.chkTabVisible = new System.Windows.Forms.CheckBox();
            this.chkTitleVisible = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(272, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(154, 204);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(73, 135);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(274, 21);
            this.txtTitle.TabIndex = 27;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(21, 139);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 12);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "标  题：";
            // 
            // lblTabType
            // 
            this.lblTabType.AutoSize = true;
            this.lblTabType.Location = new System.Drawing.Point(9, 102);
            this.lblTabType.Name = "lblTabType";
            this.lblTabType.Size = new System.Drawing.Size(65, 12);
            this.lblTabType.TabIndex = 24;
            this.lblTabType.Text = "标签类型：";
            // 
            // txtTabName
            // 
            this.txtTabName.Location = new System.Drawing.Point(73, 59);
            this.txtTabName.Name = "txtTabName";
            this.txtTabName.Size = new System.Drawing.Size(274, 21);
            this.txtTabName.TabIndex = 23;
            // 
            // lblTabName
            // 
            this.lblTabName.AutoSize = true;
            this.lblTabName.Location = new System.Drawing.Point(21, 63);
            this.lblTabName.Name = "lblTabName";
            this.lblTabName.Size = new System.Drawing.Size(53, 12);
            this.lblTabName.TabIndex = 22;
            this.lblTabName.Text = "标签名：";
            // 
            // lblScheme
            // 
            this.lblScheme.AutoSize = true;
            this.lblScheme.Location = new System.Drawing.Point(71, 28);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(53, 12);
            this.lblScheme.TabIndex = 21;
            this.lblScheme.Text = "方案名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "方  案：";
            // 
            // cbTabType
            // 
            this.cbTabType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTabType.FormattingEnabled = true;
            this.cbTabType.Location = new System.Drawing.Point(73, 98);
            this.cbTabType.Name = "cbTabType";
            this.cbTabType.Size = new System.Drawing.Size(124, 20);
            this.cbTabType.TabIndex = 32;
            // 
            // chkTabVisible
            // 
            this.chkTabVisible.AutoSize = true;
            this.chkTabVisible.Location = new System.Drawing.Point(214, 100);
            this.chkTabVisible.Name = "chkTabVisible";
            this.chkTabVisible.Size = new System.Drawing.Size(72, 16);
            this.chkTabVisible.TabIndex = 33;
            this.chkTabVisible.Text = "标签可见";
            this.chkTabVisible.UseVisualStyleBackColor = true;
            // 
            // chkTitleVisible
            // 
            this.chkTitleVisible.AutoSize = true;
            this.chkTitleVisible.Location = new System.Drawing.Point(73, 174);
            this.chkTitleVisible.Name = "chkTitleVisible";
            this.chkTitleVisible.Size = new System.Drawing.Size(72, 16);
            this.chkTitleVisible.TabIndex = 34;
            this.chkTitleVisible.Text = "标题可见";
            this.chkTitleVisible.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmGraphSchemaTabEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 243);
            this.Controls.Add(this.chkTitleVisible);
            this.Controls.Add(this.chkTabVisible);
            this.Controls.Add(this.cbTabType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTabType);
            this.Controls.Add(this.txtTabName);
            this.Controls.Add(this.lblTabName);
            this.Controls.Add(this.lblScheme);
            this.Controls.Add(this.label1);
            this.Name = "FrmGraphSchemaTabEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑关联项";
            this.Load += new System.EventHandler(this.FrmGraphSchemaTabEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTabType;
        private System.Windows.Forms.TextBox txtTabName;
        private System.Windows.Forms.Label lblTabName;
        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTabType;
        private System.Windows.Forms.CheckBox chkTabVisible;
        private System.Windows.Forms.CheckBox chkTitleVisible;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}