using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form4 : Form
    {
        private Image internalImage;
        bool currentlyAnimating = false;

        //This method begins the animation.
        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                ImageAnimator.Animate(internalImage, new EventHandler(this.Image_FrameChanged));
                currentlyAnimating = true;
            }
        } 

        public Form4()
        {
            
            SetStyle(ControlStyles.UserPaint |ControlStyles.AllPaintingInWmPaint |ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }
        void Form4_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.animateBox1.BackColor == Color.Transparent)
                this.animateBox1.BackColor = Color.Black;
            else
            {
                this.animateBox1.BackColor = Color.Transparent;
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            internalImage = Image.FromFile("c:\\image2.gif");
            this.BackColor = Color.Black;
            //this.animateBox1.BackColor = Color.Transparent;
            if (ImageAnimator.CanAnimate(internalImage))
            {
                ImageAnimator.Animate(internalImage, new EventHandler(this.Image_FrameChanged));
            }
        }

        public void Image_FrameChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            AnimateImage();
            
            ImageAnimator.UpdateFrames();
            
            e.Graphics.DrawImage(this.internalImage, new Point(100, 100));
            e.Graphics.DrawString("Hello",this.Font,Brushes.Blue,100,100);
        } 
        
    }
    
}
