namespace Shmzh.Monitor.Forms
{
    partial class FrmCategoryEdit
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
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblRightCode = new System.Windows.Forms.Label();
            this.txtRightCode = new System.Windows.Forms.TextBox();
            this.chkIsPublic = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(6, 26);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(65, 12);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "类别名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "备注：";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(81, 20);
            this.txtCategoryName.MaxLength = 50;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(292, 21);
            this.txtCategoryName.TabIndex = 1;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(81, 121);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(292, 61);
            this.txtRemark.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(239, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(327, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblRightCode
            // 
            this.lblRightCode.AutoSize = true;
            this.lblRightCode.Location = new System.Drawing.Point(6, 53);
            this.lblRightCode.Name = "lblRightCode";
            this.lblRightCode.Size = new System.Drawing.Size(53, 12);
            this.lblRightCode.TabIndex = 0;
            this.lblRightCode.Text = "权限码：";
            this.toolTip1.SetToolTip(this.lblRightCode, "系统管理中对应的权限码。");
            // 
            // txtRightCode
            // 
            this.txtRightCode.Location = new System.Drawing.Point(81, 50);
            this.txtRightCode.MaxLength = 5;
            this.txtRightCode.Name = "txtRightCode";
            this.txtRightCode.Size = new System.Drawing.Size(292, 21);
            this.txtRightCode.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtRightCode, "系统管理中对应的权限码。");
            // 
            // chkIsPublic
            // 
            this.chkIsPublic.AutoSize = true;
            this.chkIsPublic.Location = new System.Drawing.Point(81, 88);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new System.Drawing.Size(48, 16);
            this.chkIsPublic.TabIndex = 6;
            this.chkIsPublic.Text = "公开";
            this.toolTip1.SetToolTip(this.chkIsPublic, "公开：所有有权限的人可见；非公开：仅超级用户可见。");
            this.chkIsPublic.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsPublic);
            this.groupBox1.Controls.Add(this.txtRightCode);
            this.groupBox1.Controls.Add(this.lblRightCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCategoryName);
            this.groupBox1.Controls.Add(this.lblCategoryName);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 211);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分类信息";
            // 
            // FrmCategoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 290);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCategoryEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分类编辑";
            this.Load += new System.EventHandler(this.FrmCategoryEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtRightCode;
        private System.Windows.Forms.Label lblRightCode;
        private System.Windows.Forms.CheckBox chkIsPublic;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}