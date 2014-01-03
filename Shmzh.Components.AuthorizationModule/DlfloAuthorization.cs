using System;
using System.Web;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Components.AuthorizationModule
{
    public class DlfloAuthorization : System.Web.IHttpModule
    {
        #region 成员变量
        HttpApplication _currentApplication;
        #endregion

        #region 属性
        /// <summary>
        /// 当前的HttpApplication.
        /// </summary>
        private HttpApplication CurrentApplication
        {
            get { return _currentApplication; }
            set { _currentApplication = value; }
        }

        /// <summary>
        /// 当前用户.
        /// </summary>
        private Shmzh.Components.SystemComponent.User CurrentUser
        {
            get
            {
                if (this.CurrentApplication.Context.Session["User"] == null ||//如果当前用户对象为空.
                    this.CurrentApplication.Context.Session["User"].ToString().Trim() == string.Empty ||//如果当前的用户名为空字符
                    (this.CurrentApplication.Context.Session["User"] as Shmzh.Components.SystemComponent.User).thisUserInfo.LoginName != this.CurrentApplication.Context.User.Identity.Name)//如果当前的用户名和通行证的名称不符
                {
                    this.CurrentApplication.Context.Session["User"] = new Shmzh.Components.SystemComponent.User(this.CurrentApplication.Context.User.Identity.Name);
                }
                return this.CurrentApplication.Context.Session["User"] as Shmzh.Components.SystemComponent.User;
            }
        }
        #endregion

        #region IHttpModule 成员
        public void Init(System.Web.HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
        }                

        public void Dispose()
        {
            // TODO:  添加 AuthorizationModule.Dispose 实现
        } 
        #endregion

        /// <summary>
        /// 获取与当前请求关联的当前状态。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void context_AcquireRequestState(object sender, EventArgs e)
        {            
            this.CurrentApplication = sender as HttpApplication;
            if (CurrentUser.LoginSuccess)
            {
                this.CurrentApplication.Context.Session["User"] = CurrentUser;

                DLTECHLib.UserMan objUserMan;
                String connectionString = DLFloNet.DLFrmwk.ApplicationConfiguration.GetDLConnectionString();
                String strLoginName = this.CurrentApplication.Context.User.Identity.Name;
                String strPWD = "ypwater";//东兰数据库中用户的密码统一为ypwater。
                if (strLoginName != null)
                {
                    objUserMan = (DLTECHLib.UserMan)this.CurrentApplication.Context.Server.CreateObject("DLTech.UserMan");                    
                    if (objUserMan.Login(strLoginName, strPWD, connectionString, "TB_USERS", "UserID", "UserName", "PWD", "UserDspName", "", "") == 1)
                    {
                        this.CurrentApplication.Context.Session["DLFLoUserID"] = objUserMan.LoginUserID;
                    }                    
                    objUserMan = null;
                }                
            }    
        }
    }
}
