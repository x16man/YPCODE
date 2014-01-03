using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SSO
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                string s = "";

                s = s + User.Identity.Name;

                Response.Write("你已通过验证" + s);

                //	this.TextBox2.Text ="ht"+"tp"+"://"+System.Configuration.ConfigurationSettings.AppSettings["firstKey"]+"."+System.Configuration.ConfigurationSettings.AppSettings["secondKey"] +"."+System.Configuration.ConfigurationSettings.AppSettings["thirdKey"];

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}
