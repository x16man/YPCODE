using System;
using System.Web;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;


namespace SystemManagement 
{
	/// <summary>
	/// 实现自定义ViewState存储的页面基类。
	/// </summary>
	public class BasePage : System.Web.UI.Page
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// javascript的alert语法的format字符串。<script>alert('{0}');</script>
        /// </summary>
	    protected static readonly string ALERT_FORMATSTRING = "<script>alert('{0}');</script>";
        /// <summary>
        /// 刷新父页面脚本。
        /// </summary>
        protected readonly static string REFRESHPARENT_SCRIPT = "<script>parent.opener.refresh();</script>";

	    /// <summary>
	    /// 刷新父页面并且关闭本窗口。
	    /// </summary>
	    protected static readonly string REFRESHPARENTANDCLOSE_SCRIPT = "<script>parent.opener.refresh();window.close();</script>";
        private string _pageGuid = null;
        #endregion

        #region Property
        /// <summary>
		/// 当前用户。
		/// </summary>
		public User CurrentUser
		{
			get {return Session["User"] as User;}
		}
        /// <summary>
        /// 公司编号。
        /// </summary>
        public string CompanyCode
        {
            get { return this.CurrentUser.thisUserInfo.EmpCo; }
        }

        public string PageGUID
        {
            get
            {
                if (_pageGuid == null)
                    _pageGuid = this.Request.Form["__GUIDViewState"];
                if (_pageGuid == null)
                    _pageGuid = Guid.NewGuid().ToString();
                return _pageGuid;
            }
            set { _pageGuid = value; }
        }
		#endregion

		#region Constructor
		public BasePage()
		{
		}
		#endregion
        
		#region private method
		/// <summary>
		/// 创建一个以guid为名称的文件名称。
		/// </summary>
		/// <param name="guid"> 全局唯一标识符。</param>
		/// <returns>文件全路径名称。</returns>
		private string CreateOfflineViewStateFilePath(Guid guid)
		{
			return string.Format("{0}ViewState/{1}.vs",AppDomain.CurrentDomain.BaseDirectory,guid);
		}
		#endregion

		#region Protected method
		/// <summary>
		/// 提醒没有权限操作。
		/// </summary>
		protected void YouHaveNoRight()
		{
            Response.Write(string.Format("<script>alert('{0}');</script>", ConfigCommon.GetMessageValue("NoRight")));
		}
        /// <summary>
        /// 提醒没有权限操作，然后关闭弹出窗体。
        /// </summary>
        protected void YouHaveNoRightAndClose()
        {
            Response.Write(string.Format("<script>alert('{0}');window.close();</script>",ConfigCommon.GetMessageValue("NoRight")));
        }
        /// <summary>
        /// 添加StartupScript。
        /// this.ClientScript.RegisterStartupScript(type,key,script);
        /// </summary>
        /// <param name="type">类型。</param>
        /// <param name="key">脚本Key值</param>
        /// <param name="script">脚本字符串。</param>
        protected void AddScript(Type type, string key, string script)
        {
            this.ClientScript.RegisterStartupScript(type,key,script);
        }
        /// <summary>
        /// 添加StartupScript。
        /// </summary>
        /// <param name="key">脚本key值。</param>
        /// <param name="script">脚本字符串。</param>
        protected void AddScript(string key, string script)
        {
            AddScript(this.GetType(), key, script);
        }
        /// <summary>
        /// 添加StartupScript。
        /// </summary>
        /// <param name="script">脚本字符串。</param>
        /// <remarks>默认的Key值为PromptMessage。</remarks>
        protected void AddScript(string script)
        {
            AddScript(this.GetType(), "PromptMessage", script);
        }
        /// <summary>
        /// 设定错误信息。
        /// </summary>
        /// <param name="errorString">错误信息字符串。</param>
        private void SetErrorInfo(string errorString)
        {
            this.Session["Error"] = errorString;    
        }
        /// <summary>
        /// 设定错误信息然后自动跳转到错误提示页面。
        /// </summary>
        /// <param name="errorString">错误信息字符串。</param>
        /// <param name="autoRedirect">是否自动跳转。</param>
        protected void SetErrorInfo(string errorString,bool autoRedirect)
        {
            this.SetErrorInfo(errorString);
            if(autoRedirect)
                this.Response.Redirect("Error.aspx", true);
        }
        /// <summary>
        /// 设定没有权限的提示信息。
        /// </summary>
        private void SetNoRightInfo()
        {
            this.Session["Error"] = "对不起，你无权进行此操作！请联系系统管理员确认你是否具备此权限。";
        }
        /// <summary>
        /// 设定没有权限的提示信息，然后根据bool值判断是否进行自动跳转。
        /// </summary>
        /// <param name="AutoRedirect">是否进行自动跳转。</param>
        protected void SetNoRightInfo(bool AutoRedirect)
        {
            this.SetNoRightInfo();
            if(AutoRedirect)
                this.Response.Redirect("Error.aspx", true);
        }
        /// <summary>
        /// 是否同步东兰数据库
        /// </summary>
        /// <returns></returns>
        public bool isSynchronization()
        {
            try
            {
               // Logger.Info("SettingName=" + System.Configuration.ConfigurationManager.AppSettings["SettingName"]);
                var Settingtemp = DataProvider.SettingProvider.GetByKey(System.Configuration.ConfigurationManager.AppSettings["SettingName"]);
                if (Settingtemp.Value.ToLower() == "1")
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            //return true;
        }


	    #endregion

		#region override method
		/// <summary>
		/// 将所有保存的视图状态信息加载到 Page 对象。
		/// </summary>
		/// <returns>
		/// 类型：System.Object
		///	保存的视图状态。 
		/// </returns>
        //protected override object LoadPageStateFromPersistenceMedium()
        //{

        //    //object viewState = base.LoadPageStateFromPersistenceMedium();
        //    //using(new StopwatchWriter("LoadPageStateFromPersistenceMedium"))
        //    //{
        //    //    if (viewState != null)
        //    //    {
        //    //        Guid guid = (Guid)((Pair)viewState).Second;
        //    //        LosFormatter formatter = new LosFormatter();
        //    //        using (FileStream fileStream = new FileStream(CreateOfflineViewStateFilePath(guid), FileMode.Open, FileAccess.Read, FileShare.None))
        //    //        {
        //    //            viewState = formatter.Deserialize(fileStream);
        //    //        }
        //    //    }
        //    //}
        //    //return viewState;
        //    return Session[this.PageGUID];
        //}
		/// <summary>
		/// 保存页的所有视图状态信息和控件状态信息。 
		/// </summary>
		/// <param name="viewState">类型：object </param>
        //protected override void SavePageStateToPersistenceMedium(object viewState)
        //{
        //    ////create a guid for this viewstate
        //    //Guid guid;
        //    //using (new StopwatchWriter("SavePageStateToPersistenceMedium"))
        //    //{
        //    //    guid = Guid.NewGuid();

        //    //    LosFormatter formatter = new LosFormatter();
        //    //    using (FileStream fileStream = new FileStream(CreateOfflineViewStateFilePath(guid), FileMode.CreateNew, FileAccess.Write, FileShare.None))
        //    //    {
        //    //        formatter.Serialize(fileStream, viewState);
        //    //    }
        //    //}
        //    ////trick the regular system into thinking all it needs to save is the guid
        //    //base.SavePageStateToPersistenceMedium(guid);
        //    using (new StopwatchWriter("SavePageStateToPersistenceMedium"))
        //    {
        //        this.ClientScript.RegisterHiddenField("__GUIDViewState", this.PageGUID);
        //        Session[this.PageGUID] = viewState;
        //    }
        //}
        protected override void OnError(EventArgs e)
        {
            var ctx = HttpContext.Current;
            var ex = ctx.Server.GetLastError();
            Logger.Error(string.Format("{0}\r\n{1}", ex.Message,ex.StackTrace));
            this.SetErrorInfo(string.Format("{0}<br>{1}", ex.Message, ex.StackTrace), true);
            ctx.Server.ClearError();
        }
		#endregion
	}
}
