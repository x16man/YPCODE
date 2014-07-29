namespace Shmzh.Monitor.Forms
{
    partial class FrmCategoryItemEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblConfigFile = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbClassName = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(124, 52);
            this.txtTitle.MaxLength = 100;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(260, 21);
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "更新时间：";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(124, 84);
            this.txtUpdateTime.MaxLength = 10;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.Size = new System.Drawing.Size(237, 21);
            this.txtUpdateTime.TabIndex = 2;
            // 
            // lblClassName
            // 
            this.lblClassName.Location = new System.Drawing.Point(36, 151);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(65, 12);
            this.lblClassName.TabIndex = 4;
            this.lblClassName.Text = "类名称：";
            // 
            // lblConfigFile
            // 
            this.lblConfigFile.Location = new System.Drawing.Point(36, 119);
            this.lblConfigFile.Name = "lblConfigFile";
            this.lblConfigFile.Size = new System.Drawing.Size(65, 12);
            this.lblConfigFile.TabIndex = 4;
            this.lblConfigFile.Text = "方案：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(229, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(321, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbClassName
            // 
            this.cbClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassName.DropDownWidth = 300;
            this.cbClassName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbClassName.FormattingEnabled = true;
            this.cbClassName.ItemHeight = 13;
            this.cbClassName.Items.AddRange(new object[] {
            "Shmzh.Monitor.Forms.FrmGraphSchemaStage",
            "Shmzh.Monitor.Forms.FrmProcessFlowsheet",
            "Shmzh.Monitor.Forms.FrmWebBrowser",
            "Shmzh.Monitor.Forms.FrmDailyTask"});
            this.cbClassName.Location = new System.Drawing.Point(124, 147);
            this.cbClassName.Name = "cbClassName";
            this.cbClassName.Size = new System.Drawing.Size(260, 21);
            this.cbClassName.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(34, 23);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(65, 12);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "编号：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(124, 20);
            this.txtCode.MaxLength = 30;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(260, 21);
            this.txtCode.TabIndex = 3;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(343, 115);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(41, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.Location = new System.Drawing.Point(124, 116);
            this.txtConfigFile.MaxLength = 50;
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.ReadOnly = true;
            this.txtConfigFile.Size = new System.Drawing.Size(219, 21);
            this.txtConfigFile.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "秒";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.cbClassName);
            this.groupBox1.Controls.Add(this.txtConfigFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUpdateTime);
            this.groupBox1.Controls.Add(this.lblConfigFile);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Controls.Add(this.lblClassName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 184);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分类方案信息";
            // 
            // FrmCategoryItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 271);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCategoryItemEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分类方案编辑";
            this.Load += new System.EventHandler(this.FrmCategoryItemEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblConfigFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbClassName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtConfigFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}