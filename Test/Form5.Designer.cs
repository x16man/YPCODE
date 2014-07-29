namespace Test
{
    partial class Form5
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
            this.SuspendLayout();
            // 
            // animateBox1
            // 
            this.animateBox1.Image = global::Test.Properties.Resources.horse;
            this.animateBox1.ImagePath = null;
            this.animateBox1.Location = new System.Drawing.Point(439, 179);
            this.animateBox1.Name = "animateBox1";
            this.animateBox1.Size = new System.Drawing.Size(150, 150);
            this.animateBox1.TabIndex = 0;
            this.animateBox1.Title = null;
            this.animateBox1.Title_X = 0;
            this.animateBox1.Title_Y = 0;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(678, 404);
            this.Controls.Add(this.animateBox1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form5_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Shmzh.Windows.Forms.AnimateBox animateBox1;



    }
}