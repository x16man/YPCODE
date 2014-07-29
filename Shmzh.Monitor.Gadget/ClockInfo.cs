using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Shmzh.Monitor.Gadget
{
    public class ClockInfo : IDisposable
    {
        private IContainer components = new Container();
        private bool disposed = false;
        private System.Timers.Timer timerBeat;
        //private System.Windows.Forms.Timer timerBeat2;
        private Label lblTime;

        public ClockInfo()
        {
            lblTime = new Label() {AutoSize = true};
            timerBeat = new System.Timers.Timer { AutoReset = true };
            timerBeat.Elapsed += new ElapsedEventHandler(timerBeat_Elapsed);

            //timerBeat2 = new System.Windows.Forms.Timer(component);
            //timerBeat2.Tick += new EventHandler(timerBeat2_Tick);
        }

        //private void timerBeat2_Tick(object sender, EventArgs e)
        //{
        //    RefreshTime();
        //}

        /// <summary>
        /// X坐标。
        /// </summary>
        public virtual Int32 X { get; set; }
        /// <summary>
        /// Y坐标。
        /// </summary>
        public virtual Int32 Y { get; set; }

        /// <summary>
        /// 字体名。
        /// </summary>
        public String FontFamily { get; set; }
        /// <summary>
        /// 字体大小emSize.
        /// </summary>
        public Single FontSize { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public Boolean IsBold { get; set; }
        public Boolean IsUnderLine { get; set; }
        public Boolean IsItalic { get; set; }

        public String TimeFormat { get; set; }
        public String StringFormat { get; set; }

        public void test(object o)
        {
            Render((Control)o);
        }

        /// <summary>
        /// 输出。
        /// </summary>
        /// <param name="control"></param>
        public void Render(Control control)
        {
            if (String.IsNullOrEmpty(TimeFormat))
            {
                Dispose();
                return;
            }
            
            if (TimeFormat.Contains("s"))
            {
                timerBeat.Interval = 1000;
                //timerBeat2.Interval = 1000;
            }
            else //分钟显示时，调整为10秒刷新一次。
            {
                timerBeat.Interval = 10000;
                //timerBeat2.Interval = 10 * 1000;
            }
            FontStyle fs = FontStyle.Regular;
            if(IsBold) fs |= FontStyle.Bold;
            if (IsUnderLine) fs |= FontStyle.Underline;
            if (IsItalic) fs |= FontStyle.Italic;
            lblTime.Font = new Font(FontFamily, FontSize, fs);
            lblTime.ForeColor = ForeColor;
            lblTime.BackColor = BackColor;
            lblTime.Location = new Point(X, Y);
            control.Controls.Add(lblTime);
            lblTime.BringToFront();

            RefreshTime();
            timerBeat.Start();
            //timerBeat2.Start();
        }

        private delegate void MyDelegate();
        private void timerBeat_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (lblTime.Created)
            {
                lblTime.Invoke(new MyDelegate(RefreshTime));
            }
            //System.Diagnostics.Debug.WriteLine("timerBeat_Elapsed:" + e.SignalTime);
        }

        private void RefreshTime()
        {
            lblTime.Text = String.Format(StringFormat, DateTime.Now.ToString(TimeFormat));
        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    components.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                if (timerBeat != null) {timerBeat.Stop(); timerBeat.Dispose();}
                //if (timerBeat2 != null) { timerBeat2.Stop(); timerBeat2.Dispose(); }

                // Note disposing has been done.
                disposed = true;
            }
        }
        
        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~ClockInfo()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }
    }

}
