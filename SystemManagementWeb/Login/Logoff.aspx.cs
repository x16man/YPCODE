using System;
using System.Configuration;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// Logoff ��ժҪ˵����
	/// </summary>
	public partial class Logoff : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            //����ע����
            if(ConfigurationManager.AppSettings["Logoff"]=="1")
            {
                Session.Abandon();
                this.Session["User"] = null;
                if (User.Identity.IsAuthenticated)
                {
                    System.Web.Security.FormsAuthentication.SignOut();
                }
                Response.Redirect(this.Request["ReturnURL"]);
            }
            else
            {
                
                var historyInfo = new HistoryInfo
                {
                    UserName = User.Identity.Name,
                    Operation = "�˳�",
                    IpAddress = Request.UserHostAddress,
                    Url = Request.Url.AbsolutePath,
                    OpTime = DateTime.Now
                };
                DataProvider.HistoryProvider.Insert(historyInfo);
                Session.Abandon();
                this.Session["User"] = null;
                if (User.Identity.IsAuthenticated)
                {
                    System.Web.Security.FormsAuthentication.SignOut();
                }
                this.ClientScript.RegisterStartupScript(this.GetType(), "close", "CloseMe();", true);
            }
		}
    }
}
