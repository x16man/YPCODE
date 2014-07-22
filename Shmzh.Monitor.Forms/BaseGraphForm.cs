using System;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using ZedGraph;
using Timer = System.Windows.Forms.Timer;

namespace Shmzh.Monitor.Forms
{  
    public class BaseGraphForm : System.Windows.Forms.Form
    {
        protected System.Windows.Forms.Timer timerUpdate = new Timer();
        public BaseGraphForm()
        {
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            timerUpdate.Tick += new EventHandler(timerUpdate_Tick);
        }

        #region

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(UpdateData));
            //new Thread(new ThreadStart(UpdateData)) { IsBackground = true }.Start();
            //UpdateData();
        }

        protected virtual void UpdateData(object obj) { UpdateData(); }

        protected virtual void UpdateData() { }

        protected override void OnLoad(EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(UpdateData));
            //new Thread(new ThreadStart(UpdateData)) { IsBackground = true }.Start();
            UpdateData();
            base.OnLoad(e);
        }

        protected override void Dispose(bool disposing)
        {
            timerUpdate.Stop();
            timerUpdate.Dispose();
            base.Dispose(disposing);
        }

        #endregion

    }
}