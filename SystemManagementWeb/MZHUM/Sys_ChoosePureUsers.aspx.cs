using System;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class Sys_ChoosePureUsers : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack )
            {
                var deptIds = this.Request["DeptIds"];
                var userIds = this.Request["UserIds"];
                if(!string.IsNullOrEmpty( deptIds ))
                {
                    var objs = DataProvider.UserProvider.GetAllAvalibleByCompanyAndDeptIds(CurrentUser.Company, deptIds) as ListBase<UserInfo>;
                    this.cblUsers.DataSource = objs;
                    this.cblUsers.DataValueField = "PKID";
                    this.cblUsers.DataTextField = "EmpName";
                    this.cblUsers.DataBind();
                    if(!string.IsNullOrEmpty(userIds))
                    {
                        var aUserIds = userIds.Split(new[] {','});
                        foreach(ListItem ctrl in this.cblUsers.Items)
                        {
                            foreach(var aUserId in aUserIds)
                            {
                                if(ctrl.Value == aUserId)
                                {
                                    ctrl.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.lblInformation.Visible = true;
                }
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            var userIdsControlId = this.Request["userIdsControlId"];
            var userNamesControlId = this.Request["userNamesControlId"];
            var userNamesHideControlId = this.Request["userNamesHideControlId"];

            var userIds = string.Empty;
            var userNames = string.Empty;
            var userEncodeNames = string.Empty;
            foreach(ListItem ctrl in this.cblUsers.Items)
            {
                if (ctrl.Selected)
                {
                    userIds += ctrl.Value + ",";
                    userNames += ctrl.Text + ",";
                }
            }
            if(userIds.Length > 0)
            {
                userIds = userIds.Substring(0, userIds.Length - 1);
                userEncodeNames = Server.UrlEncode(userNames.Substring(0, userNames.Length - 1));
                userNames = userNames.Substring(0, userNames.Length - 1);
            }
            var setValueScript =
                string.Format(
                    "window.opener.document.getElementById('{0}').value='{1}';\r\nwindow.opener.document.getElementById('{2}').value='{3}';\r\nwindow.opener.document.getElementById('{4}').value='{5}';\r\nwindow.close();",
                    userIdsControlId, userIds, userNamesControlId, userNames,userNamesHideControlId,userEncodeNames);

            this.ClientScript.RegisterStartupScript(this.GetType(),"setValue",setValueScript,true);
        }
    }
}