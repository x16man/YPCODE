using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;

namespace WebMM
{
	public partial class Default : System.Web.UI.Page
	{
        /// <summary>
        /// 当前用户。
        /// </summary>
        public User CurrentUser
        {
            get { return Session["User"] as User; }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!this.IsPostBack)
            {
                this.objMzhWebUIFrame.CurrentUser = CurrentUser;
            }
		}
	}
}
