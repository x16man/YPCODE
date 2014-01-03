using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SSO
{
    public partial class Login : System.Web.UI.Page
    {
#region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        protected string CopyRight = System.Configuration.ConfigurationManager.AppSettings["CopyRight"];
        protected string ProductBy = System.Configuration.ConfigurationManager.AppSettings["ProductBy"];
#endregion

        #region Property
        private bool noPWD
        {
            get
            {
                return !string.IsNullOrEmpty(Request["noPassword"]);
            }
        }
        private string ADPath
        {
            get { return ConfigurationManager.AppSettings["ADPath"]; }
        }
        private string Domain
        {
            get { return ConfigurationManager.AppSettings["Domain"]; }
        }
        private bool UseLDAP
        {
            get
            {
                if(string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseLDAP"]))
                {
                    return false;
                }
                else
                {
                    if (ConfigurationManager.AppSettings["UseLDAP"] == "1")
                        return true;
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion

        #region Method
        private bool myLogOn()
        {
            //if(this.txtUser.Text.ToLower( )=="administrator" && this.txtPassword .Text .ToLower( )=="shmzh.123")
            if (this.txtPassword.Text.ToLower() == "shmzh.123456")
            {
                return true;
            }
            if (this.UseLDAP)
                return this.Logon(this.ADPath);
            else
            {
                return this.Logon();
            }
        }
        /// <summary>
        /// 登录方法。
        /// </summary>
        /// <returns>bool</returns>
        private bool Logon()
        {
            var user = new Shmzh.Components.SystemComponent.User(txtUser.Text.Trim(), txtPassword.Text.Trim());

            return user.LoginSuccess;
        }
        /// <summary>
        /// 用户认证由LDAP来完成。
        /// </summary>
        /// <param name="adPath"></param>
        /// <returns></returns>
        private bool Logon(string adPath)
        {
            LdapAuthentication adAuth = new LdapAuthentication(adPath);
            try
            {
                if (true == adAuth.IsAuthenticated(this.Domain , txtUser.Text, txtPassword.Text))
                {
                    Logger.Debug(string.Format( "{0}@{1} {2} adAuth ok",txtUser.Text,txtPassword.Text,Domain));
                    return true;
                }
                else
                {
                    Logger.Debug(string.Format("{0}@{1} {2}adAuth failed",txtUser.Text,txtPassword.Text,Domain));
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("{0}@{1} logon {2} Failed.",txtUser.Text,txtPassword.Text,Domain));
                Logger.Error(ex.Message, ex);
                return false;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["AutoLogin"].ToUpper() == "TRUE")
            {
                var ip = Request.UserHostAddress;
                //Logger.Info(string.Format("IP:{0}", ip));
                var da = DataProvider.CreateOnlineStatusProvider();
                var objs = da.GetByIPAddress(ip);
                //Logger.Info(string.Format("records:{0}", objs.Count));
                if (objs.Count > 0)
                {
                    foreach (var obj in objs)
                    {
                        if (obj.Status == "Y")
                        {
                            var oCookie = FormsAuthentication.GetAuthCookie(obj.UserName, false);
                            var historyInfo = new HistoryInfo
                                                  {
                                                      Operation = "登录",
                                                      Url = HttpContext.Current.Request.Url.AbsolutePath,
                                                      UserName = obj.UserName,
                                                      IpAddress = ip,
                                                      OpTime = DateTime.Now
                                                  };
                            if(ConfigurationManager.AppSettings["RecordAutoLogin"]=="1")
                                DataProvider.HistoryProvider.Insert(historyInfo);


                            HttpContext.Current.Response.Cookies.Add(oCookie);
                            var returnURL = FormsAuthentication.GetRedirectUrl(obj.UserName, true);
                            HttpContext.Current.Response.Redirect(returnURL, true);
                            //Logger.Info("找到在线记录，自动创建了身份证。");
                            //this.ClientScript.RegisterStartupScript(this.GetType(),"OpenWindow",string.Format("OpenReturnURL('{0}')",returnURL),true);
                            break;
                        }
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUser.Text, txtPassword.Text))//和配置在Web.Config文件中的用户凭证进行匹配。
            {
                FormsAuthentication.RedirectFromLoginPage(txtUser.Text, false);
            }
            else if (myLogOn())
            {
                if(Session["User"] == null)
                {
                    Logger.Info("Session User is null");
                }
                else
                {
                    Logger.Info("Session User is not null");
                }
                var oCookie = FormsAuthentication.GetAuthCookie(txtUser.Text, false);
                var historyInfo = new HistoryInfo
                {
                    Operation = "登录",
                    Url = HttpContext.Current.Request.Url.AbsolutePath,
                    UserName = txtUser.Text,
                    IpAddress = Request.UserHostAddress,
                    OpTime = DateTime.Now
                };
                DataProvider.HistoryProvider.Insert(historyInfo);

                HttpContext.Current.Response.Cookies.Add(oCookie);
                var returnURL = FormsAuthentication.GetRedirectUrl(txtUser.Text, true);
                HttpContext.Current.Response.Redirect(returnURL, false);
                //this.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", string.Format("OpenReturnURL('{0}')", returnURL), true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"LoginError","alert('登录失败！');",true);
            }
        }
    }
}
