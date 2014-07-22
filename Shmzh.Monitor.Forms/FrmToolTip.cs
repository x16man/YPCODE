using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmToolTip : Form
    {
        #region Fields
        private String _content = String.Empty;
        private Rectangle _rect = Rectangle.Empty;
        //private bool _isClosed = false;
        #endregion

        #region Constructor
        public FrmToolTip()
        {
            InitializeComponent();
        }

        public FrmToolTip(String strContent)
            : this()
        {
            this._content = strContent;
        }

        public FrmToolTip(String strContent, Rectangle rect)
            : this(strContent)
        {
            this._rect = rect;
        }
        #endregion

        #region Property
        /// <summary>
        /// 提示信息。
        /// </summary>
        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }
        /// <summary>
        /// 提示窗口的所有者边界区域。
        /// </summary>
        public Rectangle ParentRect
        {
            get { return this._rect; }
            set { this._rect = value; }
        }
        #endregion

        #region Event Handler
        private void FrmToolTip_Load(object sender, EventArgs e)
        {
            //this.timerCloseFrm.Interval = 50;
            //this.timerCloseFrm.Start();

            //this.lblContent.Text = this._content;
            //if (_rect != Rectangle.Empty)
            //{
            //    this.Location = new Point(_rect.Left + (_rect.Width - this.Width) / 2, _rect.Top + (_rect.Height - this.Height) / 2);
            //}
        }

        //private void timerCloseFrm_Tick(object sender, EventArgs e)
        //{
        //    if (this._isClosed)
        //    {
        //        this.timerCloseFrm.Stop();
        //        this.Close();
        //        this.Dispose();
        //    }
        //}
        #endregion

        ///// <summary>
        ///// 关闭提示窗口。
        ///// </summary>
        //public void CloseToolTip()
        //{
        //    this._isClosed = true;
        //}

        #region 单线程。
        public void ChangeInfo(String content, Rectangle rect)
        {
            this.ParentRect = rect;
            this.Content = content;

            this.lblContent.Text = this._content;
            if (_rect != Rectangle.Empty)
            {
                this.Location = new Point(_rect.Left + (_rect.Width - this.Width) / 2, _rect.Top + (_rect.Height - this.Height) / 2);
            }
            
            if (!this.Visible)
            {
                this.Show();
            }
            this.Refresh();
        }

        public void ChangeInfo(String content)
        {
            this.Content = content;

            this.lblContent.Text = this._content;
            if (!this.Visible)
            {
                this.Show();
            }
            this.Refresh();
        }

        /// <summary>
        /// 关闭提示窗口。
        /// </summary>
        public void CloseWin()
        {
            this.Hide();
        }
        #endregion

    }
}
