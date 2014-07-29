using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Shmzh.Components.FormLibrary;
using Shmzh.Components.SystemComponent;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Forms;

namespace Shmzh.Monitor.Main
{
    /// <summary>
    /// 程序启动时的窗口状态。
    /// </summary>
    internal enum StartupType
    {
        Normal,
        Minimized,
        Maximized,
        FullScreen
    } 

    static class Program
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 程序启动时的窗口状态。
        /// </summary>
        internal static StartupType StartupType { get; set; }

        #region method
        static private void AutoUpdate()
        {
            String upgradeApp = Path.Combine(Application.StartupPath, @"Upgrade\OnlineUpgrade.exe");
            if (File.Exists(upgradeApp))
            {
                System.Diagnostics.Process.Start(upgradeApp);
            }
            else
            {
                //MessageBox.Show(this, "未找到升级程序。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Program.StartupType = StartupType.Maximized;
            
            if (args.Length > 0)
            {
                switch (args[0].Replace("-", "").ToLower())
                {
                    case "f":
                        Program.StartupType = StartupType.FullScreen;
                        break;
                    case "max":
                        Program.StartupType = StartupType.Maximized;
                        break;
                    case "min":
                        Program.StartupType = StartupType.Minimized;
                        break;
                    case "n":
                        Program.StartupType = StartupType.Normal;
                        break;
                    default:
                        Program.StartupType = StartupType.Maximized;
                        break;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += CurrentDomainUnhandledException;
            AutoUpdate();
            switch (ConfigurationManager.AppSettings["LaunchType"])
            {
                case "1":
                    
                    Application.Run(new FrmMain());
                    break;
                case "2":
                    
                    LoginForm loginForm = new LoginForm { Title = "工程师分析系统登录" };
                    loginForm.ShowDialog();
                    
                    if (loginForm.IsLoginSuccess)
                    {
                        
                        //显示状态窗口。
                        Common.CurrentUser = loginForm.LoginUser;
                        //loginForm.Dispose();
                        loginForm.Close();
                        //显示状态窗口。
                        var tHandler = new ToolTipHandler();
                        //加载图片。
                        tHandler.Show("正在加载程序资源，请稍候...", Screen.PrimaryScreen.Bounds);
                        
                        Shmzh.Monitor.Gadget.ConfigImages.LoadAllImages();
                        //加载菜单。
                        tHandler.Show("正在加载菜单数据,请稍侯...", Screen.PrimaryScreen.Bounds);
                        GlobleVariables.RefreshCategoryList();
                        GlobleVariables.RefreshCategoryItemList();
                        tHandler.Show("正在加载监控对象,请稍侯...", Screen.PrimaryScreen.Bounds);
                        GlobleVariables.RefreshMonitorObjList();
                        tHandler.Show("正在加载监控方案,请稍侯...", Screen.PrimaryScreen.Bounds);
                        GlobleVariables.RefreshGraphSchemaList();
                        GlobleVariables.RefreshGraphSchemaItemList();
                        GlobleVariables.RefreshGraphSchemaTagList();
                        tHandler.Close();//隐藏状态窗口。
                        
                        System.Diagnostics.Process.GetCurrentProcess().MinWorkingSet = new IntPtr(5);//用于释放加载资源时所占用的内存.
                        
                        Application.Run(new MDIMain());
                    }


                    break;                
                default:
                    Application.Run(new FrmMain());
                    break;
            }
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var e = (Exception)args.ExceptionObject;
            Logger.Error(String.Format("ThreadException:{0}", e));
            //Console.WriteLine("MyHandler caught : " + e.Message);
            //if (!Shmzh.Components.Util.Internet.IsConnected())
            //{
            //    MessageBox.Show("网络已经断开，请检查您的网络。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    MessageBox.Show("出现如下错误：\n\n" + e.Message + "\n\n如果您经常遇到此问题，请与软件开发商联系。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //Application.Exit();

            //DialogResult result = System.Windows.Forms.DialogResult.Cancel;
            //try
            //{
            //    result = MessageBox.Show(String.Format("程序域异常，终止：{0}。\n{1}", args.IsTerminating.ToString(), e.Message), Application.ProductName,
            //                             MessageBoxButtons.AbortRetryIgnore);
            //}
            //catch (Exception)
            //{
            //    try
            //    {

            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("程序域异常", "错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
            //    }
            //    finally
            //    {
            //        Application.Exit();
            //    }               
            //}
            //if (result == System.Windows.Forms.DialogResult.Abort) Application.Exit();
        }

        /// <summary>
        /// 发生未捕获的异常时，捕获主线程异常。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //if (!Shmzh.Components.Util.Internet.IsConnected())
            //{
            //    MessageBox.Show("网络已经断开，请检查您的网络。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    MessageBox.Show("出现如下错误：\n\n" + e.Exception.Message + "\n\n如果您经常遇到此问题，请与软件开发商联系。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            Logger.Error(String.Format("ThreadException:{0}", e.Exception));
        }
    }
}
