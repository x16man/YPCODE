using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using Shmzh.Monitor.Config;

namespace Shmzh.Monitor.Forms
{
    public abstract class UpdateBase
    {
        private static object syncRoot = new Object();
        /// <summary>
        /// 正在运行的子线程数。
        /// </summary>
        private Int32 _runThreads = 0;
        /// <summary>
        /// 取数据时单个线程所包含的对象个数。
        /// </summary>
        protected static Int32 threadObjCount = 0;

        protected Control _form;
        protected MonitorConfig _config;
        protected UpdateBase()
        {
            if (threadObjCount == 0)
            {
                threadObjCount = ConfigurationManager.AppSettings["ThreadObjCount"] == null ? 10 : Convert.ToInt32(ConfigurationManager.AppSettings["ThreadObjCount"]);
            }
        }
        protected UpdateBase(Control ctrl, MonitorConfig config):this()
        {
            _form = ctrl;
            _config = config;
        }
        protected void IncreaseRunThreads()
        {
            lock (syncRoot)
            {
                this._runThreads++;
                if (this._form is Form)
                {
                    this._form.Text = this._runThreads.ToString();
                }
            }
        }

        protected void DecreaseRunThreads()
        {
            lock (syncRoot)
            {
                this._runThreads--;
                if (this._form is Form)
                {
                    this._form.Text = this._runThreads.ToString();
                }
            }
        }

        //protected Int32 RunThreads
        //{
        //    get
        //    {
        //        return this._runThreads;
        //    }
        //    set
        //    {
        //        lock (syncRoot)
        //        {
        //            this._runThreads = value;
        //            if (this._form != null && this._form is Form)
        //            {
        //                (this._form as Form).Text = value.ToString();
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 更新线程是否中止。
        /// </summary>
        public Boolean IsStopped { get; set; }

        /// <summary>
        /// 所有线程是否都已完成。
        /// </summary>
        public Boolean IsFinished
        {
            get
            {
                //System.Diagnostics.Debug.WriteLine(System.DateTime.Now + " " + _runThreads.ToString() + " 个线程。");
                return (_runThreads == 0);
            }
        }

       
    }
}
