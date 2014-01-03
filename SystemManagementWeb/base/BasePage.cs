using System;
using System.Web;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;


namespace SystemManagement 
{
	/// <summary>
	/// ʵ���Զ���ViewState�洢��ҳ����ࡣ
	/// </summary>
	public class BasePage : System.Web.UI.Page
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// javascript��alert�﷨��format�ַ�����<script>alert('{0}');</script>
        /// </summary>
	    protected static readonly string ALERT_FORMATSTRING = "<script>alert('{0}');</script>";
        /// <summary>
        /// ˢ�¸�ҳ��ű���
        /// </summary>
        protected readonly static string REFRESHPARENT_SCRIPT = "<script>parent.opener.refresh();</script>";

	    /// <summary>
	    /// ˢ�¸�ҳ�沢�ҹرձ����ڡ�
	    /// </summary>
	    protected static readonly string REFRESHPARENTANDCLOSE_SCRIPT = "<script>parent.opener.refresh();window.close();</script>";
        private string _pageGuid = null;
        #endregion

        #region Property
        /// <summary>
		/// ��ǰ�û���
		/// </summary>
		public User CurrentUser
		{
			get {return Session["User"] as User;}
		}
        /// <summary>
        /// ��˾��š�
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
		/// ����һ����guidΪ���Ƶ��ļ����ơ�
		/// </summary>
		/// <param name="guid"> ȫ��Ψһ��ʶ����</param>
		/// <returns>�ļ�ȫ·�����ơ�</returns>
		private string CreateOfflineViewStateFilePath(Guid guid)
		{
			return string.Format("{0}ViewState/{1}.vs",AppDomain.CurrentDomain.BaseDirectory,guid);
		}
		#endregion

		#region Protected method
		/// <summary>
		/// ����û��Ȩ�޲�����
		/// </summary>
		protected void YouHaveNoRight()
		{
            Response.Write(string.Format("<script>alert('{0}');</script>", ConfigCommon.GetMessageValue("NoRight")));
		}
        /// <summary>
        /// ����û��Ȩ�޲�����Ȼ��رյ������塣
        /// </summary>
        protected void YouHaveNoRightAndClose()
        {
            Response.Write(string.Format("<script>alert('{0}');window.close();</script>",ConfigCommon.GetMessageValue("NoRight")));
        }
        /// <summary>
        /// ���StartupScript��
        /// this.ClientScript.RegisterStartupScript(type,key,script);
        /// </summary>
        /// <param name="type">���͡�</param>
        /// <param name="key">�ű�Keyֵ</param>
        /// <param name="script">�ű��ַ�����</param>
        protected void AddScript(Type type, string key, string script)
        {
            this.ClientScript.RegisterStartupScript(type,key,script);
        }
        /// <summary>
        /// ���StartupScript��
        /// </summary>
        /// <param name="key">�ű�keyֵ��</param>
        /// <param name="script">�ű��ַ�����</param>
        protected void AddScript(string key, string script)
        {
            AddScript(this.GetType(), key, script);
        }
        /// <summary>
        /// ���StartupScript��
        /// </summary>
        /// <param name="script">�ű��ַ�����</param>
        /// <remarks>Ĭ�ϵ�KeyֵΪPromptMessage��</remarks>
        protected void AddScript(string script)
        {
            AddScript(this.GetType(), "PromptMessage", script);
        }
        /// <summary>
        /// �趨������Ϣ��
        /// </summary>
        /// <param name="errorString">������Ϣ�ַ�����</param>
        private void SetErrorInfo(string errorString)
        {
            this.Session["Error"] = errorString;    
        }
        /// <summary>
        /// �趨������ϢȻ���Զ���ת��������ʾҳ�档
        /// </summary>
        /// <param name="errorString">������Ϣ�ַ�����</param>
        /// <param name="autoRedirect">�Ƿ��Զ���ת��</param>
        protected void SetErrorInfo(string errorString,bool autoRedirect)
        {
            this.SetErrorInfo(errorString);
            if(autoRedirect)
                this.Response.Redirect("Error.aspx", true);
        }
        /// <summary>
        /// �趨û��Ȩ�޵���ʾ��Ϣ��
        /// </summary>
        private void SetNoRightInfo()
        {
            this.Session["Error"] = "�Բ�������Ȩ���д˲���������ϵϵͳ����Աȷ�����Ƿ�߱���Ȩ�ޡ�";
        }
        /// <summary>
        /// �趨û��Ȩ�޵���ʾ��Ϣ��Ȼ�����boolֵ�ж��Ƿ�����Զ���ת��
        /// </summary>
        /// <param name="AutoRedirect">�Ƿ�����Զ���ת��</param>
        protected void SetNoRightInfo(bool AutoRedirect)
        {
            this.SetNoRightInfo();
            if(AutoRedirect)
                this.Response.Redirect("Error.aspx", true);
        }
        /// <summary>
        /// �Ƿ�ͬ���������ݿ�
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
		/// �����б������ͼ״̬��Ϣ���ص� Page ����
		/// </summary>
		/// <returns>
		/// ���ͣ�System.Object
		///	�������ͼ״̬�� 
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
		/// ����ҳ��������ͼ״̬��Ϣ�Ϳؼ�״̬��Ϣ�� 
		/// </summary>
		/// <param name="viewState">���ͣ�object </param>
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
