namespace Shmzh.Gather.DDE.Test
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnAdvise = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnStopAdvise = new System.Windows.Forms.Button();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Name:";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(105, 18);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(129, 21);
            this.txtServiceName.TabIndex = 1;
            this.txtServiceName.Text = "IMPACC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Topic:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Item:";
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(319, 18);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(218, 21);
            this.txtTopic.TabIndex = 4;
            this.txtTopic.Text = "NetLinkNo3";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(105, 62);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(129, 21);
            this.txtItem.TabIndex = 5;
            this.txtItem.Text = "D56POSENERGY";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(553, 16);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnAdvise
            // 
            this.btnAdvise.Location = new System.Drawing.Point(553, 60);
            this.btnAdvise.Name = "btnAdvise";
            this.btnAdvise.Size = new System.Drawing.Size(90, 23);
            this.btnAdvise.TabIndex = 7;
            this.btnAdvise.Text = "StartAdvise";
            this.btnAdvise.UseVisualStyleBackColor = true;
            this.btnAdvise.Click += new System.EventHandler(this.btnAdvise_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Result:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(319, 62);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(218, 21);
            this.txtResult.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 546);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDisconnect);
            this.tabPage1.Controls.Add(this.btnStopAdvise);
            this.tabPage1.Controls.Add(this.txtFormat);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtResult);
            this.tabPage1.Controls.Add(this.txtServiceName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnAdvise);
            this.tabPage1.Controls.Add(this.txtItem);
            this.tabPage1.Controls.Add(this.txtTopic);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(649, 16);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 13;
            this.btnDisconnect.Text = "DisConnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnStopAdvise
            // 
            this.btnStopAdvise.Location = new System.Drawing.Point(651, 60);
            this.btnStopAdvise.Name = "btnStopAdvise";
            this.btnStopAdvise.Size = new System.Drawing.Size(75, 23);
            this.btnStopAdvise.TabIndex = 12;
            this.btnStopAdvise.Text = "StopAdvise";
            this.btnStopAdvise.UseVisualStyleBackColor = true;
            this.btnStopAdvise.Click += new System.EventHandler(this.btnStopAdvise_Click);
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(105, 93);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(129, 21);
            this.txtFormat.TabIndex = 11;
            this.txtFormat.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Format:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(726, 442);
            this.panel2.TabIndex = 11;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(133, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMonitor);
            this.panel1.Controls.Add(this.txtAction);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtAppName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 72);
            this.panel1.TabIndex = 10;
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(562, 28);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnMonitor.TabIndex = 9;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // txtAction
            // 
            this.txtAction.Location = new System.Drawing.Point(318, 28);
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(218, 21);
            this.txtAction.TabIndex = 8;
            this.txtAction.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Service Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Action:";
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(104, 28);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(129, 21);
            this.txtAppName.TabIndex = 6;
            this.txtAppName.Text = "IMPACC";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 546);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Shmzh.Gather.DDE.Test";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnAdvise;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStopAdvise;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
    }
}

