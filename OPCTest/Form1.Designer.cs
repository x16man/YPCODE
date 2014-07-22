namespace OPCTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_NodeIP = new System.Windows.Forms.TextBox();
            this.textBox_ProgID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_OPCGroup = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Read = new System.Windows.Forms.Button();
            this.button_Write = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ReadValue = new System.Windows.Forms.TextBox();
            this.textBox_WriteValue = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_BatchWrite = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKEPReadValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnKEPRead = new System.Windows.Forms.Button();
            this.btnKEPDisconnect = new System.Windows.Forms.Button();
            this.btnKEPConnect = new System.Windows.Forms.Button();
            this.txtKEPAddress = new System.Windows.Forms.TextBox();
            this.Adress = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKEPNodeIP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKEPOPCGroup = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKEPProgID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "NodeIP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "ProgID:";
            // 
            // textBox_NodeIP
            // 
            this.textBox_NodeIP.Location = new System.Drawing.Point(90, 21);
            this.textBox_NodeIP.Name = "textBox_NodeIP";
            this.textBox_NodeIP.Size = new System.Drawing.Size(257, 21);
            this.textBox_NodeIP.TabIndex = 2;
            // 
            // textBox_ProgID
            // 
            this.textBox_ProgID.Location = new System.Drawing.Point(90, 55);
            this.textBox_ProgID.Name = "textBox_ProgID";
            this.textBox_ProgID.Size = new System.Drawing.Size(257, 21);
            this.textBox_ProgID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "OPCGroup:";
            // 
            // textBox_OPCGroup
            // 
            this.textBox_OPCGroup.Location = new System.Drawing.Point(90, 87);
            this.textBox_OPCGroup.Name = "textBox_OPCGroup";
            this.textBox_OPCGroup.Size = new System.Drawing.Size(257, 21);
            this.textBox_OPCGroup.TabIndex = 5;
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(389, 20);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 6;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Read
            // 
            this.button_Read.Location = new System.Drawing.Point(389, 221);
            this.button_Read.Name = "button_Read";
            this.button_Read.Size = new System.Drawing.Size(75, 23);
            this.button_Read.TabIndex = 7;
            this.button_Read.Text = "Read";
            this.button_Read.UseVisualStyleBackColor = true;
            this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
            // 
            // button_Write
            // 
            this.button_Write.Location = new System.Drawing.Point(389, 254);
            this.button_Write.Name = "button_Write";
            this.button_Write.Size = new System.Drawing.Size(75, 23);
            this.button_Write.TabIndex = 8;
            this.button_Write.Text = "Write";
            this.button_Write.UseVisualStyleBackColor = true;
            this.button_Write.Click += new System.EventHandler(this.button_Write_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "ReadValue:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "WriteValue:";
            // 
            // textBox_ReadValue
            // 
            this.textBox_ReadValue.Location = new System.Drawing.Point(90, 221);
            this.textBox_ReadValue.Name = "textBox_ReadValue";
            this.textBox_ReadValue.Size = new System.Drawing.Size(257, 21);
            this.textBox_ReadValue.TabIndex = 13;
            // 
            // textBox_WriteValue
            // 
            this.textBox_WriteValue.Location = new System.Drawing.Point(90, 256);
            this.textBox_WriteValue.Name = "textBox_WriteValue";
            this.textBox_WriteValue.Size = new System.Drawing.Size(257, 21);
            this.textBox_WriteValue.TabIndex = 14;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(90, 121);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(257, 21);
            this.textBox_Address.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Address:";
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(389, 53);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.button_Disconnect.TabIndex = 17;
            this.button_Disconnect.Text = "DisConnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            // 
            // button_BatchWrite
            // 
            this.button_BatchWrite.Location = new System.Drawing.Point(389, 293);
            this.button_BatchWrite.Name = "button_BatchWrite";
            this.button_BatchWrite.Size = new System.Drawing.Size(75, 23);
            this.button_BatchWrite.TabIndex = 18;
            this.button_BatchWrite.Text = "Batch Write";
            this.button_BatchWrite.UseVisualStyleBackColor = true;
            this.button_BatchWrite.Click += new System.EventHandler(this.button_BatchWrite_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(389, 322);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 23);
            this.button_Stop.TabIndex = 19;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Connect);
            this.groupBox1.Controls.Add(this.button_Stop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_BatchWrite);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_Disconnect);
            this.groupBox1.Controls.Add(this.textBox_NodeIP);
            this.groupBox1.Controls.Add(this.textBox_Address);
            this.groupBox1.Controls.Add(this.textBox_ProgID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_WriteValue);
            this.groupBox1.Controls.Add(this.textBox_OPCGroup);
            this.groupBox1.Controls.Add(this.textBox_ReadValue);
            this.groupBox1.Controls.Add(this.button_Read);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button_Write);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 505);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RSLinx";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtKEPReadValue);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnKEPRead);
            this.groupBox2.Controls.Add(this.btnKEPDisconnect);
            this.groupBox2.Controls.Add(this.btnKEPConnect);
            this.groupBox2.Controls.Add(this.txtKEPAddress);
            this.groupBox2.Controls.Add(this.Adress);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtKEPNodeIP);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtKEPOPCGroup);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtKEPProgID);
            this.groupBox2.Location = new System.Drawing.Point(502, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 505);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KEPWare";
            // 
            // txtKEPReadValue
            // 
            this.txtKEPReadValue.Location = new System.Drawing.Point(95, 236);
            this.txtKEPReadValue.Name = "txtKEPReadValue";
            this.txtKEPReadValue.Size = new System.Drawing.Size(257, 21);
            this.txtKEPReadValue.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 239);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "ReadValue:";
            // 
            // btnKEPRead
            // 
            this.btnKEPRead.Location = new System.Drawing.Point(176, 189);
            this.btnKEPRead.Name = "btnKEPRead";
            this.btnKEPRead.Size = new System.Drawing.Size(75, 23);
            this.btnKEPRead.TabIndex = 20;
            this.btnKEPRead.Text = "Read";
            this.btnKEPRead.UseVisualStyleBackColor = true;
            // 
            // btnKEPDisconnect
            // 
            this.btnKEPDisconnect.Location = new System.Drawing.Point(95, 189);
            this.btnKEPDisconnect.Name = "btnKEPDisconnect";
            this.btnKEPDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnKEPDisconnect.TabIndex = 20;
            this.btnKEPDisconnect.Text = "DisConnect";
            this.btnKEPDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnKEPConnect
            // 
            this.btnKEPConnect.Location = new System.Drawing.Point(14, 189);
            this.btnKEPConnect.Name = "btnKEPConnect";
            this.btnKEPConnect.Size = new System.Drawing.Size(75, 23);
            this.btnKEPConnect.TabIndex = 20;
            this.btnKEPConnect.Text = "Connect";
            this.btnKEPConnect.UseVisualStyleBackColor = true;
            this.btnKEPConnect.Click += new System.EventHandler(this.btnKEPConnect_Click);
            // 
            // txtKEPAddress
            // 
            this.txtKEPAddress.Location = new System.Drawing.Point(84, 124);
            this.txtKEPAddress.Name = "txtKEPAddress";
            this.txtKEPAddress.Size = new System.Drawing.Size(257, 21);
            this.txtKEPAddress.TabIndex = 21;
            // 
            // Adress
            // 
            this.Adress.AutoSize = true;
            this.Adress.Location = new System.Drawing.Point(12, 127);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(47, 12);
            this.Adress.TabIndex = 20;
            this.Adress.Text = "Adress:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "NodeIP:";
            // 
            // txtKEPNodeIP
            // 
            this.txtKEPNodeIP.Location = new System.Drawing.Point(84, 22);
            this.txtKEPNodeIP.Name = "txtKEPNodeIP";
            this.txtKEPNodeIP.Size = new System.Drawing.Size(257, 21);
            this.txtKEPNodeIP.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "ProgID:";
            // 
            // txtKEPOPCGroup
            // 
            this.txtKEPOPCGroup.Location = new System.Drawing.Point(84, 88);
            this.txtKEPOPCGroup.Name = "txtKEPOPCGroup";
            this.txtKEPOPCGroup.Size = new System.Drawing.Size(257, 21);
            this.txtKEPOPCGroup.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "OPCGroup:";
            // 
            // txtKEPProgID
            // 
            this.txtKEPProgID.Location = new System.Drawing.Point(84, 56);
            this.txtKEPProgID.Name = "txtKEPProgID";
            this.txtKEPProgID.Size = new System.Drawing.Size(257, 21);
            this.txtKEPProgID.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 521);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_NodeIP;
        private System.Windows.Forms.TextBox textBox_ProgID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_OPCGroup;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Read;
        private System.Windows.Forms.Button button_Write;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ReadValue;
        private System.Windows.Forms.TextBox textBox_WriteValue;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_BatchWrite;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtKEPReadValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnKEPRead;
        private System.Windows.Forms.Button btnKEPDisconnect;
        private System.Windows.Forms.Button btnKEPConnect;
        private System.Windows.Forms.TextBox txtKEPAddress;
        private System.Windows.Forms.Label Adress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKEPNodeIP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKEPOPCGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKEPProgID;
    }
}

