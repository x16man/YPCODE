using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();

            //PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
            //pictureBox1.Image = Properties.Resources.horse;
            //pictureBox1.Location = new Point(10, 20);
            //pictureBox1.Name = "pictureBox1";
            //pictureBox1.Size = new System.Drawing.Size(114, 75);
            //pictureBox1.TabIndex = 0;
            //pictureBox1.TabStop = false;

            //this.Controls.Add(pictureBox1);
        }

        private void Form5_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.BlueViolet,this.ClientRectangle);
        }
        private void SetAndFillClip(PaintEventArgs e)
        {

            // Set the Clip property to a new region.
            //e.Graphics.Clip = new Region(new Rectangle(10, 10, 100, 200));

            //// Fill the region.
            //e.Graphics.FillRegion(Brushes.LightSalmon, e.Graphics.Clip);

            // Demonstrate the clip region by drawing a string
            // at the outer edge of the region.
            e.Graphics.DrawString("Outside of Clip", new Font("Arial",
                12.0F, FontStyle.Regular), Brushes.White, 0.0F, 0.0F);

            e.Graphics.DrawString("Hello World!", new Font(this.Font.FontFamily, 18), Brushes.Red, 400, 400);


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //var g = this.CreateGraphics();
            //g.DrawString("Hello World!",new Font(this.Font.FontFamily,18),Brushes.Red,400,400 );
        }
    }
}
