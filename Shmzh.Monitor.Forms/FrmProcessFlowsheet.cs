using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Shmzh.Monitor.Config;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmProcessFlowsheet : FrmBase
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string ConfigFile;
        #endregion

        #region CTOR
        public FrmProcessFlowsheet()
        {
            InitializeComponent();
        }

        public FrmProcessFlowsheet(String configFile, Int32 updateTime):this()
        {
            this.ConfigFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\" + configFile);
            var sw = new Stopwatch();
            sw.Start();
            config = ConfigManagement.Load(configFile);
            Logger.Debug(configFile);
            sw.Stop();
            Trace.WriteLine(string.Format("Load ConfigFile spend {0}ms", sw.ElapsedMilliseconds));
            sw.Reset();
            sw.Start();
            updateData = new UpdateData(this, config);
            sw.Stop();
            Trace.WriteLine(string.Format("new UpdateData spend {0}ms",sw.ElapsedMilliseconds));
            if (updateTime > 0)
            {
                timerUpdate.Interval = updateTime * 1000;
                timerUpdate.Start();
            }
        }
        #endregion

        #region Method

        protected override void UpdateData()
        {
            #region 更新数据 多线程。

            //System.Diagnostics.Debug.WriteLine("线程个数:" + System.Diagnostics.Process.GetCurrentProcess().Threads.Count);
            Logger.Debug("UpdateData()");
            if (updateData.IsFinished)
            {
                Logger.Debug("update do work.");
                updateData.DoWork();
            }
            else
            {
                Logger.Debug("update not finished.");
            }
            #endregion
        }
        
        #endregion

        private void FrmProcessFlowsheet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.Shift && e.Control && e.KeyCode == Keys.F12)
            {
                System.Diagnostics.Process.Start(this.ConfigFile);
            }
            else if(e.Control && e.KeyCode == Keys.F5)//force refresh
            {
                
            }
        }
    }
}
