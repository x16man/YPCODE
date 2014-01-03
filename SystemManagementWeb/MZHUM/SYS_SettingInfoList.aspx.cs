using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SettingInfoList : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.SettingView))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                String category = Request.QueryString["category"];
                if (!String.IsNullOrEmpty(category))
                {
                    this.hidCategory.Value = category;
                }
               
                BindData();
            }
            else
            {

                this.dg_SettingInfo.AutoDataBind = BindData;
            }
        }

        private void BindData()
        {
            ListBase<SettingInfo> objs;
            if (this.hidCategory.Value.Length > 0)
            {
                objs = DataProvider.SettingProvider.GetByCategory(this.hidCategory.Value) as ListBase<SettingInfo>;
                if (objs.Count > 0) //确保同一类别的大小写一致。
                {
                    this.hidCategory.Value = objs[0].Category;
                }
            }
            else
            {
                objs = DataProvider.SettingProvider.GetAll() as ListBase<SettingInfo>;
            }

            this.dg_SettingInfo.DataSource = objs;
            this.dg_SettingInfo.DataBind();
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            if (item.ItemId.ToLower() == "delete")
            {
                try
                {
                    DataProvider.SettingProvider.Delete(this.dg_SettingInfo.SelectedID);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('开关量删除成功！');</script>");
                    BindData();
                }
                catch
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script>alert('开关量删除失败！');</script>");

                }
            }
          
        }
    }
}
