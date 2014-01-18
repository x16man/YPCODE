using System;
using myWF = Shmzh.Components.WorkFlow;

namespace WebMM.Modules
{
    /// <summary>
    /// 已办事宜的用户Web组件.
    /// </summary>
    public partial class WUCHaveDoneList : System.Web.UI.UserControl
    {
        #region Property
        public Shmzh.Components.SystemComponent.User CurrentUser
        {
            get { return Session["User"] as Shmzh.Components.SystemComponent.User; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindData();
        }
        private void BindData()
        {
            this.mzhDataGrid1.DataSource = new myWF.Task().GetLatestDoneTasksByUser(CurrentUser.LoginName).Tables[0];
            this.mzhDataGrid1.DataBind();
        }
    }
}