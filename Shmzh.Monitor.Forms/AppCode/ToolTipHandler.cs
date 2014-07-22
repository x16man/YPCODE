using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shmzh.Monitor.Forms
{
    /// <summary>
    /// 同时只允许打开一个提示窗口。
    /// 若要打开多个，可创建多个ToolTipHandler的实例。
    /// </summary>
    public class ToolTipHandler
    {
        #region Fields
        private static FrmToolTip frmToolTip = null;
        ///// <summary>
        ///// 提示窗口是否已经打开，尚未关闭。
        ///// </summary>
        //private bool _isOpened = false;

        //private struct MyInfo
        //{
        //    public MyInfo(String content, Rectangle rect)
        //    {
        //        this.Content = content;
        //        this.Rect = rect; 
        //    }
        //    public String Content;
        //    public Rectangle Rect;
        //}
        
        #endregion

        #region Property
        public Form Parent { get; set; }
        #endregion
        #region Methods
        //private void ShowToolTipWin(object obj)
        //{
        //    lock (this)
        //    {
        //        var tmp = (MyInfo)obj;
        //        ShowToolTipWin(tmp.Content, tmp.Rect);
        //    }
        //}

        //private void ShowToolTipWin(String tInfo, Rectangle rect)
        //{
        //    if (this._isOpened) return;
        //    this._isOpened = true;
        //    frmToolTip = new FrmToolTip(tInfo, rect);            
        //    frmToolTip.ShowDialog();//打开对话框时，当前线程自动阻止。关闭后接着运行。
            
        //    frmToolTip.Dispose();
        //    this._isOpened = false;
        //}

        //public void Show(String tInfo, Rectangle rect)
        //{
        //    if (this._isOpened) return;

        //    ParameterizedThreadStart pts = new ParameterizedThreadStart(ShowToolTipWin);
        //    Thread thread = new Thread(pts) { IsBackground = true };
        //    thread.Start(new MyInfo(tInfo, rect));
        //}

        //public void Close()
        //{
        //    if (frmToolTip != null)
        //    {
        //        //Thread.Sleep(5);//等待提示窗口完全打开，才能进行关闭？
        //        frmToolTip.CloseToolTip();
        //    }
        //}
        #endregion
        
        private delegate void ChangeInfoHandle(String content, Rectangle rect);
        public void Show(String tInfo, Rectangle rect)
        {
            if (frmToolTip == null)
            {
                frmToolTip = new FrmToolTip();
                frmToolTip.TopMost = false;
                if (this.Parent != null)
                    frmToolTip.MdiParent = this.Parent;    
                frmToolTip.Show();
            }
            frmToolTip.Invoke(new ChangeInfoHandle(frmToolTip.ChangeInfo), tInfo, rect);
        }

        public void Close()
        {
            frmToolTip.Invoke(new ThreadStart(frmToolTip.CloseWin));
        }

    }

}
