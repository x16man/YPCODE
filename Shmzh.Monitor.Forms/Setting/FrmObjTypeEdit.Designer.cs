namespace Shmzh.Monitor.Forms.Setting
{
    partial class FrmObjTypeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObjTypeEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslResult});
            this.statusStrip1.Location = new System.Drawing.Point(0, 227);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslResult
            // 
            this.tsslResult.Name = "tsslResult";
            this.tsslResult.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblRemark);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 162);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类别信息";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(79, 71);
            this.txtRemark.MaxLength = 50;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(174, 85);
            this.txtRemark.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 32);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(174, 21);
            this.txtName.TabIndex = 2;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(24, 78);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 1;
            this.lblRemark.Text = "备注：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "名称：";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(92, 191);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "&Y.确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&C.取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmObjTypeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 249);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmObjTypeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "监测对象类别";
            this.TopMost = true;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCancel;
    }
}