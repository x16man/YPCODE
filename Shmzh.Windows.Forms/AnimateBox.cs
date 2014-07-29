using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Shmzh.Windows.Forms
{
    public partial class AnimateBox : UserControl
    {
        #region Field
        private bool isAnimating = false;
        private Image _image;
        private string _imagePath;
        private int _title_x;
        private int _title_y;
        private string _title;
        #endregion
        #region Property
        /// <summary>
        /// 在AnimateBox中显示的图片。
        /// </summary>
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// 图片路径。
        /// </summary>
        public string ImagePath
        {
            get { return this._imagePath; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._imagePath = value;
                    this.Image = Image.FromFile(value);
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// 显示的标题。
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                this._title = value;
                this.Invalidate();
            }
        }

        public int Title_X
        {
            get { return _title_x; }
            set
            {
                _title_x = value;
                this.Invalidate();
            }
        }
        public int Title_Y
        {
            get
            {
                return _title_y;
            }
            set
            {
                _title_y = value;
                this.Invalidate();
            }
        }    

        #endregion

        public AnimateBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }

        #region Method
        public void AnimateImage()
        {
            if (!isAnimating)
            {
                ImageAnimator.Animate(this.Image, new EventHandler(this.Image_FrameChanged));
                isAnimating = true;
            }
        } 
        #endregion

        #region Event
        private void AnimateBox_Load(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                if (ImageAnimator.CanAnimate(this.Image))
                {
                    ImageAnimator.Animate(this.Image, new EventHandler(this.Image_FrameChanged));
                }
            }
        }
        public void Image_FrameChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        #endregion

        private void AnimateBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.Image != null)
            {
                AnimateImage();

                ImageAnimator.UpdateFrames();

                e.Graphics.DrawImage(this.Image, 0, 0, this.Width, this.Height);
                
            }
            e.Graphics.DrawString(Title, this.Font, Brushes.Blue, Title_X, Title_Y);
        }
    }
}
