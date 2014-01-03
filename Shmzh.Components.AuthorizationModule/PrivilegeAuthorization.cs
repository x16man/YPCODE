using System;
using System.Configuration;
using System.Web;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.Components.AuthorizationModule
{
	/// <summary>
	/// 权限认证
	/// </summary>
	public class PrivilegeAuthorization : System.Web.IHttpModule
	{
		#region 成员变量
private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    #endregion
		#region 属性
        /// <summary>
        /// 产品Id。
        /// </summary>
	    private static short ProductId
	    {
            get { return short.Parse(ConfigurationManager.AppSettings["ProductId"]); }
	    }

	    /// <summary>
	    /// 当前的HttpApplication.
	    /// </summary>
	    private HttpApplication CurrentApplication { get; set; }

	    /// <summary>
		/// 当前用户.
		/// </summary>
		private Shmzh.Components.SystemComponent.User CurrentUser
		{
			get 
			{
				if (this.CurrentApplication.Context.Session["User"] == null ||//如果当前用户对象为空.
					this.CurrentApplication.Context.Session["User"].ToString().Trim() == string.Empty ||//如果当前的用户名为空字符
					(this.CurrentApplication.Context.Session["User"] as Shmzh.Components.SystemComponent.User).thisUserInfo.LoginName.ToUpper() != this.CurrentApplication.Context.User.Identity.Name.ToUpper() )//如果当前的用户名和通行证的名称不符
				{
					this.CurrentApplication.Context.Session["User"] = new Shmzh.Components.SystemComponent.User(this.CurrentApplication.Context.User.Identity.Name);
				}
				return this.CurrentApplication.Context.Session["User"] as Shmzh.Components.SystemComponent.User;
			}
		}
        /// <summary>
        /// 授权信息。
        /// </summary>
	    private string License
	    {
	        get
	        {
	            if(this.CurrentApplication.Context.Session["License"] == null)
	            {
	                var product = DataProvider.ProductProvider.GetByCode(ProductId);
	                this.CurrentApplication.Context.Session["License"] = product.License;
	            }
	            return this.CurrentApplication.Context.Session["License"].ToString();
	        }
	    }
        /// <summary>
        /// 默认单位。
        /// </summary>
	    private CompanyInfo DefaultCompany
	    {
	        get
	        {
                if (this.CurrentApplication.Context.Session["DefaultCompany"] == null)
                {
                    var company = DataProvider.CompanyProvider.GetDefault();
                    this.CurrentApplication.Context.Session["DefaultCompany"] = company;
                }
                return this.CurrentApplication.Context.Session["DefaultCompany"] as CompanyInfo;
	        }
	    }
		#endregion
		public PrivilegeAuthorization()
		{
			// 
			// 
			//
		}
	
		#region IHttpModule 成员

		public void Init(System.Web.HttpApplication context)
		{
			context.AcquireRequestState+=new EventHandler(context_AcquireRequestState);
		}

		public void Dispose()
		{
			// 
		}

		#endregion
		/// <summary>
		/// ASP.Net获取与当前请求相关的当前状态.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void context_AcquireRequestState(object sender, EventArgs e)
		{
			string requestURL;
			this.CurrentApplication = sender as HttpApplication;
            if (this.CurrentApplication.Context.Session != null)
            {
                var a = new Authorization(License, this.DefaultCompany);
                if (a.LicenseStatus == 1 || a.LicenseStatus == 2)
                {
                    //ok
                }
                else
                {
                    requestURL = this.CurrentApplication.Context.Request.Url.ToString().ToUpper();
                    if (requestURL.Contains("SYS_PRODUCTREGISTER.ASPX"))
                    {
                    }
                    else
                    {
                        this.CurrentApplication.CompleteRequest();
                        this.CurrentApplication.Context.Response.Redirect(string.Format("/SystemManagementWeb/MZHUM/SYS_ProductRegister.aspx?code={0}", ProductId));
                    }
                }
                //userName = this.CurrentUser.thisUserInfo.LoginName;
                //requestURL = this.CurrentApplication.Context.Request.Url.ToString();
            }

			//operationCode = this.CurrentApplication.Context.Request["OP"];
			//TODO:	根据用户名和当前的URL以及操作码来进行权限的判断.
			//		是否应该维护一个URL和OperationCode以及权限的关联表.
//			if (!this.CurrentUser.HasRight(rightCode))
//			{
//				this.CurrentApplication.CompleteRequest();
//				this.CurrentApplication.Context.Response.Write(string.Format("{0}:<br>对不起! 您无权进行此操作,如果不当请联系系统管理员解决. ",this.CurrentUser.thisUserInfo.EmpName));
//			}
			
			
		}
	}
}
