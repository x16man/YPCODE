namespace Shmzh.Monitor.Forms.Setting
{
    partial class FrmObjTypeAttrEdit
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.lblDataType = new System.Windows.Forms.Label();
            this.cbFieldName = new System.Windows.Forms.ComboBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.lblSerialNo = new System.Windows.Forms.Label();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 266);
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
            this.groupBox1.Controls.Add(this.cbDataType);
            this.groupBox1.Controls.Add(this.lblDataType);
            this.groupBox1.Controls.Add(this.cbFieldName);
            this.groupBox1.Controls.Add(this.lblFieldName);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtSerialNo);
            this.groupBox1.Controls.Add(this.lblSerialNo);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 183);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类别属性";
            // 
            // cbDataType
            // 
            this.cbDataType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbDataType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(75, 145);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(165, 20);
            this.cbDataType.TabIndex = 7;
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(7, 148);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(65, 12);
            this.lblDataType.TabIndex = 6;
            this.lblDataType.Text = "数据类型：";
            // 
            // cbFieldName
            // 
            this.cbFieldName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbFieldName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFieldName.FormattingEnabled = true;
            this.cbFieldName.Items.AddRange(new object[] {
            "AttrField01",
            "AttrField02",
            "AttrField03",
            "AttrField04",
            "AttrField05",
            "AttrField06",
            "AttrField07",
            "AttrField08",
            "AttrField09",
            "AttrField10",
            "AttrField11",
            "AttrField12",
            "AttrField13",
            "AttrField14",
            "AttrField15",
            "AttrField16",
            "AttrField17",
            "AttrField18",
            "AttrField19",
            "AttrField20"});
            this.cbFieldName.Location = new System.Drawing.Point(75, 109);
            this.cbFieldName.Name = "cbFieldName";
            this.cbFieldName.Size = new System.Drawing.Size(165, 20);
            this.cbFieldName.TabIndex = 5;
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(7, 112);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(53, 12);
            this.lblFieldName.TabIndex = 4;
            this.lblFieldName.Text = "字段名：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 72);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 21);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "名称：";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(75, 35);
            this.txtSerialNo.MaxLength = 3;
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(165, 21);
            this.txtSerialNo.TabIndex = 1;
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.AutoSize = true;
            this.lblSerialNo.Location = new System.Drawing.Point(7, 38);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(41, 12);
            this.lblSerialNo.TabIndex = 0;
            this.lblSerialNo.Text = "序号：";
            // 
            // btnYes
            // 
            this.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYes.Location = new System.Drawing.Point(116, 214);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "&Y.确定";
            this.btnYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&C.取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmObjTypeAttrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 288);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmObjTypeAttrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "类别属性设置";
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
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.ComboBox cbFieldName;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSerialNo;
    }
}