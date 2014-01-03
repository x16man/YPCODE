using System;
using System.Configuration;
using System.Web;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.Components.AuthorizationModule
{
	/// <summary>
	/// Ȩ����֤
	/// </summary>
	public class PrivilegeAuthorization : System.Web.IHttpModule
	{
		#region ��Ա����
private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    #endregion
		#region ����
        /// <summary>
        /// ��ƷId��
        /// </summary>
	    private static short ProductId
	    {
            get { return short.Parse(ConfigurationManager.AppSettings["ProductId"]); }
	    }

	    /// <summary>
	    /// ��ǰ��HttpApplication.
	    /// </summary>
	    private HttpApplication CurrentApplication { get; set; }

	    /// <summary>
		/// ��ǰ�û�.
		/// </summary>
		private Shmzh.Components.SystemComponent.User CurrentUser
		{
			get 
			{
				if (this.CurrentApplication.Context.Session["User"] == null ||//�����ǰ�û�����Ϊ��.
					this.CurrentApplication.Context.Session["User"].ToString().Trim() == string.Empty ||//�����ǰ���û���Ϊ���ַ�
					(this.CurrentApplication.Context.Session["User"] as Shmzh.Components.SystemComponent.User).thisUserInfo.LoginName.ToUpper() != this.CurrentApplication.Context.User.Identity.Name.ToUpper() )//�����ǰ���û�����ͨ��֤�����Ʋ���
				{
					this.CurrentApplication.Context.Session["User"] = new Shmzh.Components.SystemComponent.User(this.CurrentApplication.Context.User.Identity.Name);
				}
				return this.CurrentApplication.Context.Session["User"] as Shmzh.Components.SystemComponent.User;
			}
		}
        /// <summary>
        /// ��Ȩ��Ϣ��
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
        /// Ĭ�ϵ�λ��
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
	
		#region IHttpModule ��Ա

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
		/// ASP.Net��ȡ�뵱ǰ������صĵ�ǰ״̬.
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
			//TODO:	�����û����͵�ǰ��URL�Լ�������������Ȩ�޵��ж�.
			//		�Ƿ�Ӧ��ά��һ��URL��OperationCode�Լ�Ȩ�޵Ĺ�����.
//			if (!this.CurrentUser.HasRight(rightCode))
//			{
//				this.CurrentApplication.CompleteRequest();
//				this.CurrentApplication.Context.Response.Write(string.Format("{0}:<br>�Բ���! ����Ȩ���д˲���,�����������ϵϵͳ����Ա���. ",this.CurrentUser.thisUserInfo.EmpName));
//			}
			
			
		}
	}
}
