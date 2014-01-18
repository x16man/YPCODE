using System;

namespace WebMM
{
    public partial class ToDo : System.Web.UI.Page
    {
        #region Property
        public Shmzh.Components.SystemComponent.User CurrentUser
        {
            get { return Session["User"] as Shmzh.Components.SystemComponent.User; }
        }
        #endregion
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
