namespace Shmzh.Components.AuthorizationModule
{
    using System;
    using System.Web;
    using Shmzh.Components.SystemComponent;


    /// <summary>
    /// 用户认证.
    /// 在请求的时候，判断用户的Session对象有没有创建。没有创建或者和当前的身份验证票据不符则，以当前身份票据的身份创建用户Session。
    /// </summary>
    public class UserAuthorization : System.Web.IHttpModule
    {
        #region 成员变量
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore 169

        #endregion

        #region 属性

        /// <summary>
        /// 当前的HttpApplication.
        /// </summary>
        private HttpApplication CurrentApplication { get; set; }

        #endregion

        #region CTOR
        public UserAuthorization()
        {
        }
        #endregion

        #region IHttpModule 成员

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += context_AcquireRequestState;
        }

        public void Dispose()
        {
        }
        
        /// <summary>
        /// ASP.Net获取与当前请求相关的当前状态.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void context_AcquireRequestState(object sender, EventArgs e)
        {
            //Logger.Debug("context_AcquireRequestState");
            string userName;
            // 获取应用程序
            this.CurrentApplication = sender as HttpApplication;
            //Logger.Debug(this.CurrentApplication);
            if(this.CurrentApplication != null)
            {
                if (this.CurrentApplication.Context.Session != null)//webresource.axc?类型的请求无需处理。
                {
                    //Logger.Debug(this.CurrentApplication.Context.Session.SessionID);
                    //Logger.Debug("this.CurrentApplication.Context.Session != null");
                    if(this.CurrentApplication.Context.Session["User"] != null)
                    {
                        //Logger.Debug("1、this.CurrentApplication.Context.Session[User] != null");

                        var obj = this.CurrentApplication.Context.Session["User"] as User;
                        #region User is not null
                        if (obj != null)
                        {
                            Logger.Debug("2、http module User is not null");
                            
                            if (this.CurrentApplication.Context.User.Identity.Name.IndexOf('\\') > 0 )
                            {
                                userName = this.CurrentApplication.Context.User.Identity.Name.Split('\\')[1];
                            }
                            else
                            {
                                userName = this.CurrentApplication.Context.User.Identity.Name;
                            }
                            
                            //Logger.Debug(userName);
                            //Logger.Debug(obj.thisUserInfo.LoginName);

                            if (obj.thisUserInfo.LoginName.ToUpper() != userName.ToUpper())
                            {
                                //Logger.Debug("obj.thisUserInfo.LoginName.ToUpper() != userName.ToUpper()");
                                var currentUser = new User(userName);
                                //Logger.Debug(string.Format("{0}'s user login {1}.",userName,currentUser.LoginSuccess));

                                this.CurrentApplication.Context.Session["User"] = currentUser;
                                this.CurrentApplication.Context.Session["COMPANY"] = "YPWATER";
                                
                                this.CurrentApplication.Context.Session["USERCODE"] = currentUser.thisUserInfo.EmpCode;
                                this.CurrentApplication.Context.Session["USERNAME"] = currentUser.thisUserInfo.EmpName;
                                this.CurrentApplication.Context.Session["LOGINID"] = currentUser.thisUserInfo.LoginName;
                                this.CurrentApplication.Context.Session["USERDEPTCODE"] = currentUser.thisUserInfo.DeptCode;
                                this.CurrentApplication.Context.Session["USERDEPTNAME"] = currentUser.thisUserInfo.DeptName;
                            }
                            else if(!this.CurrentApplication.Context.User.Identity.IsAuthenticated)
                            {
                                if (this.CurrentApplication.Context.User.Identity.Name.IndexOf('\\') > 0)
                                {
                                    userName = this.CurrentApplication.Context.User.Identity.Name.Split('\\')[1];
                                }
                                else
                                {
                                    userName = this.CurrentApplication.Context.User.Identity.Name;
                                }
                                var currentUser = new User(userName);
                                //Logger.Debug(string.Format("{0}'s user login {1}.", userName, currentUser.LoginSuccess));

                                this.CurrentApplication.Context.Session["User"] = currentUser;
                                this.CurrentApplication.Context.Session["COMPANY"] = "YPWATER";
                                this.CurrentApplication.Context.Session["USERCODE"] = currentUser.thisUserInfo.EmpCode;
                                this.CurrentApplication.Context.Session["USERNAME"] = currentUser.thisUserInfo.EmpName;
                                this.CurrentApplication.Context.Session["LOGINID"] = currentUser.thisUserInfo.LoginName;
                                this.CurrentApplication.Context.Session["USERDEPTCODE"] = currentUser.thisUserInfo.DeptCode;
                                this.CurrentApplication.Context.Session["USERDEPTNAME"] = currentUser.thisUserInfo.DeptName;
                                //Logger.Debug("!this.CurrentApplication.Context.User.Identity.IsAuthenticated");
                            }
                        }
                        #endregion
                        #region User is null
                        else
                        {
                            Logger.Debug("http module User is null");
                            if (this.CurrentApplication.Context.User.Identity.Name.IndexOf('\\') > 0)
                            {
                                userName = this.CurrentApplication.Context.User.Identity.Name.Split('\\')[1];
                            }
                            else
                            {
                                userName = this.CurrentApplication.Context.User.Identity.Name;
                            }
                            var currentUser = new User(userName);
                            Logger.Debug(string.Format("{0}'s user login {1}.", userName, currentUser.LoginSuccess));

                            this.CurrentApplication.Context.Session["User"] = currentUser;
                            this.CurrentApplication.Context.Session["COMPANY"] = "YPWATER";
                            this.CurrentApplication.Context.Session["USERCODE"] = currentUser.thisUserInfo.EmpCode;
                            this.CurrentApplication.Context.Session["USERNAME"] = currentUser.thisUserInfo.EmpName;
                            this.CurrentApplication.Context.Session["LOGINID"] = currentUser.thisUserInfo.LoginName;
                            this.CurrentApplication.Context.Session["USERDEPTCODE"] = currentUser.thisUserInfo.DeptCode;
                            this.CurrentApplication.Context.Session["USERDEPTNAME"] = currentUser.thisUserInfo.DeptName;
                        }
                        #endregion
                    }
                    else
                    {
                        Logger.Debug("this.CurrentApplication.Context.Session[User] == null");
                        if(this.CurrentApplication.Context.User.Identity.IsAuthenticated)
                        {
                            if (this.CurrentApplication.Context.User.Identity.Name.IndexOf('\\') > 0)
                            {
                                userName = this.CurrentApplication.Context.User.Identity.Name.Split('\\')[1];
                            }
                            else
                            {
                                userName = this.CurrentApplication.Context.User.Identity.Name;
                            }
                            var currentUser = new User(userName);
                            //Logger.Debug(string.Format("{0}'s user login {1}.", userName, currentUser.LoginSuccess));

                            this.CurrentApplication.Context.Session["User"] = currentUser;
                            this.CurrentApplication.Context.Session["COMPANY"] = "001";
                            this.CurrentApplication.Context.Session["USERCODE"] = currentUser.thisUserInfo.EmpCode;
                            this.CurrentApplication.Context.Session["USERNAME"] = currentUser.thisUserInfo.EmpName;
                            this.CurrentApplication.Context.Session["LOGINID"] = currentUser.thisUserInfo.LoginName;
                            this.CurrentApplication.Context.Session["USERDEPTCODE"] = currentUser.thisUserInfo.DeptCode;
                            this.CurrentApplication.Context.Session["USERDEPTNAME"] = currentUser.thisUserInfo.DeptName;
                        }
                        else if(this.CurrentApplication.Request.UserAgent!= null && this.CurrentApplication.Request.UserAgent.IndexOf("Flash",StringComparison.OrdinalIgnoreCase)>0)//When Flash upload file the Identity is Null.
                        {
                            Logger.Debug(string.Format("{0}-Upload File.",this.CurrentApplication.Request.UserAgent));
                            
                        }
                    }

                }
            }
        }
        #endregion
    }
}
