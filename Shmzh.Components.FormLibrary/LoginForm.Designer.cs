namespace Shmzh.Components.FormLibrary
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.okButton = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_AutoLogin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(377, 195);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(50, 24);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "登录";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Location = new System.Drawing.Point(237, 197);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(130, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // cbUserName
            // 
            this.cbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUserName.Font = new System.Drawing.Font("宋体", 9F);
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.ItemHeight = 12;
            this.cbUserName.Location = new System.Drawing.Point(52, 197);
            this.cbUserName.MaxDropDownItems = 10;
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(130, 20);
            this.cbUserName.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.MediumBlue;
            this.linkLabel1.Location = new System.Drawing.Point(373, 258);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "技术支持";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Location = new System.Drawing.Point(12, 201);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(41, 12);
            this.lblUserName.TabIndex = 17;
            this.lblUserName.Text = "帐号：";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(196, 201);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(41, 12);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(220, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "上海名之赫科技有限公司";
            // 
            // checkBox_AutoLogin
            // 
            this.checkBox_AutoLogin.AutoSize = true;
            this.checkBox_AutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_AutoLogin.Location = new System.Drawing.Point(379, 225);
            this.checkBox_AutoLogin.Name = "checkBox_AutoLogin";
            this.checkBox_AutoLogin.Size = new System.Drawing.Size(72, 16);
            this.checkBox_AutoLogin.TabIndex = 20;
            this.checkBox_AutoLogin.Text = "自动登录";
            this.checkBox_AutoLogin.UseVisualStyleBackColor = false;
            this.checkBox_AutoLogin.Visible = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(446, 278);
            this.Controls.Add(this.checkBox_AutoLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cbUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.okButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }        

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbUserName;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_AutoLogin;
    }
}