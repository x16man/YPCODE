namespace Test
{
    partial class Form4
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
            this.animateBox1 = new Shmzh.Windows.Forms.AnimateBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // animateBox1
            // 
            this.animateBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animateBox1.Image = global::Test.Properties.Resources.horse;
            this.animateBox1.ImagePath = null;
            this.animateBox1.Location = new System.Drawing.Point(45, 37);
            this.animateBox1.Name = "animateBox1";
            this.animateBox1.Size = new System.Drawing.Size(275, 99);
            this.animateBox1.TabIndex = 0;
            this.animateBox1.Title = "hello World";
            this.animateBox1.Title_X = 0;
            this.animateBox1.Title_Y = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Test.Properties.Resources.horse;
            this.pictureBox1.Location = new System.Drawing.Point(197, 232);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 70);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 351);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.animateBox1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.DoubleClick += new System.EventHandler(Form4_DoubleClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form4_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private Shmzh.Windows.Forms.AnimateBox animateBox1;
        private System.Windows.Forms.PictureBox pictureBox1;

        


    }
}