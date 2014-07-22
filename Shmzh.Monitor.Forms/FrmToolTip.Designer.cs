namespace Shmzh.Monitor.Forms
{
    partial class FrmToolTip
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
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblContent
            // 
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContent.Font = new System.Drawing.Font("宋体", 9.5F);
            this.lblContent.ForeColor = System.Drawing.Color.Black;
            this.lblContent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContent.Location = new System.Drawing.Point(0, 0);
            this.lblContent.Margin = new System.Windows.Forms.Padding(0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblContent.Size = new System.Drawing.Size(287, 66);
            this.lblContent.TabIndex = 0;
            this.lblContent.Text = "label1";
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmToolTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(287, 66);
            this.Controls.Add(this.lblContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmToolTip";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmToolTip";
            this.Load += new System.EventHandler(this.FrmToolTip_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblContent;
    }
}