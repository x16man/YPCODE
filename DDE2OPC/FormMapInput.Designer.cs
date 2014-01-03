namespace DDE2OPC
{
    partial class FormMapInput
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
            this.groupBox_Map = new System.Windows.Forms.GroupBox();
            this.label_Remark = new System.Windows.Forms.Label();
            this.textBox_Remark = new System.Windows.Forms.TextBox();
            this.textBox_OPCAddress = new System.Windows.Forms.TextBox();
            this.textBox_DDEItem = new System.Windows.Forms.TextBox();
            this.textBox_DDETopic = new System.Windows.Forms.TextBox();
            this.label_OPCAddress = new System.Windows.Forms.Label();
            this.label_DDEItem = new System.Windows.Forms.Label();
            this.label_DDETopic = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.pictureBox_Title = new System.Windows.Forms.PictureBox();
            this.groupBox_Map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Title)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Map
            // 
            this.groupBox_Map.Controls.Add(this.label_Remark);
            this.groupBox_Map.Controls.Add(this.textBox_Remark);
            this.groupBox_Map.Controls.Add(this.textBox_OPCAddress);
            this.groupBox_Map.Controls.Add(this.textBox_DDEItem);
            this.groupBox_Map.Controls.Add(this.textBox_DDETopic);
            this.groupBox_Map.Controls.Add(this.label_OPCAddress);
            this.groupBox_Map.Controls.Add(this.label_DDEItem);
            this.groupBox_Map.Controls.Add(this.label_DDETopic);
            this.groupBox_Map.Location = new System.Drawing.Point(0, 59);
            this.groupBox_Map.Name = "groupBox_Map";
            this.groupBox_Map.Size = new System.Drawing.Size(358, 213);
            this.groupBox_Map.TabIndex = 0;
            this.groupBox_Map.TabStop = false;
            // 
            // label_Remark
            // 
            this.label_Remark.AutoSize = true;
            this.label_Remark.Location = new System.Drawing.Point(15, 152);
            this.label_Remark.Name = "label_Remark";
            this.label_Remark.Size = new System.Drawing.Size(41, 12);
            this.label_Remark.TabIndex = 7;
            this.label_Remark.Text = "label4";
            // 
            // textBox_Remark
            // 
            this.textBox_Remark.Location = new System.Drawing.Point(101, 149);
            this.textBox_Remark.MaxLength = 100;
            this.textBox_Remark.Multiline = true;
            this.textBox_Remark.Name = "textBox_Remark";
            this.textBox_Remark.Size = new System.Drawing.Size(245, 57);
            this.textBox_Remark.TabIndex = 6;
            // 
            // textBox_OPCAddress
            // 
            this.textBox_OPCAddress.Location = new System.Drawing.Point(101, 110);
            this.textBox_OPCAddress.MaxLength = 100;
            this.textBox_OPCAddress.Name = "textBox_OPCAddress";
            this.textBox_OPCAddress.Size = new System.Drawing.Size(245, 21);
            this.textBox_OPCAddress.TabIndex = 5;
            // 
            // textBox_DDEItem
            // 
            this.textBox_DDEItem.Location = new System.Drawing.Point(101, 71);
            this.textBox_DDEItem.MaxLength = 50;
            this.textBox_DDEItem.Name = "textBox_DDEItem";
            this.textBox_DDEItem.Size = new System.Drawing.Size(245, 21);
            this.textBox_DDEItem.TabIndex = 4;
            // 
            // textBox_DDETopic
            // 
            this.textBox_DDETopic.Location = new System.Drawing.Point(101, 32);
            this.textBox_DDETopic.MaxLength = 50;
            this.textBox_DDETopic.Name = "textBox_DDETopic";
            this.textBox_DDETopic.Size = new System.Drawing.Size(245, 21);
            this.textBox_DDETopic.TabIndex = 3;
            // 
            // label_OPCAddress
            // 
            this.label_OPCAddress.AutoSize = true;
            this.label_OPCAddress.Location = new System.Drawing.Point(15, 113);
            this.label_OPCAddress.Name = "label_OPCAddress";
            this.label_OPCAddress.Size = new System.Drawing.Size(41, 12);
            this.label_OPCAddress.TabIndex = 2;
            this.label_OPCAddress.Text = "label3";
            // 
            // label_DDEItem
            // 
            this.label_DDEItem.AutoSize = true;
            this.label_DDEItem.Location = new System.Drawing.Point(13, 74);
            this.label_DDEItem.Name = "label_DDEItem";
            this.label_DDEItem.Size = new System.Drawing.Size(41, 12);
            this.label_DDEItem.TabIndex = 1;
            this.label_DDEItem.Text = "label2";
            // 
            // label_DDETopic
            // 
            this.label_DDETopic.AutoSize = true;
            this.label_DDETopic.Location = new System.Drawing.Point(13, 35);
            this.label_DDETopic.Name = "label_DDETopic";
            this.label_DDETopic.Size = new System.Drawing.Size(41, 12);
            this.label_DDETopic.TabIndex = 0;
            this.label_DDETopic.Text = "label1";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(174, 291);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "button1";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(271, 291);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "button2";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // pictureBox_Title
            // 
            this.pictureBox_Title.BackColor = System.Drawing.Color.White;
            this.pictureBox_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox_Title.Image = global::DDE2OPC.Properties.Resources.BrandTitle;
            this.pictureBox_Title.InitialImage = global::DDE2OPC.Properties.Resources.BrandTitle;
            this.pictureBox_Title.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Title.Name = "pictureBox_Title";
            this.pictureBox_Title.Size = new System.Drawing.Size(358, 50);
            this.pictureBox_Title.TabIndex = 3;
            this.pictureBox_Title.TabStop = false;
            // 
            // FormMapInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 331);
            this.Controls.Add(this.pictureBox_Title);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox_Map);
            this.Name = "FormMapInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DDE&OPC映射关系维护";
            this.groupBox_Map.ResumeLayout(false);
            this.groupBox_Map.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Title)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Map;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.PictureBox pictureBox_Title;
        private System.Windows.Forms.Label label_Remark;
        private System.Windows.Forms.TextBox textBox_Remark;
        private System.Windows.Forms.TextBox textBox_OPCAddress;
        private System.Windows.Forms.TextBox textBox_DDEItem;
        private System.Windows.Forms.TextBox textBox_DDETopic;
        private System.Windows.Forms.Label label_OPCAddress;
        private System.Windows.Forms.Label label_DDEItem;
        private System.Windows.Forms.Label label_DDETopic;
    }
}