using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Shmzh.Monitor.Forms;

namespace Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Entry());
            //Application.Run(new FrmGraphSchema());
        }
    }
}
