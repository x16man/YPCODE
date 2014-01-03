using System;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_MenuTypeList : BasePage
    {
        #region Field

        #endregion

        #region Property

        #endregion

        #region private method
        private void myDataBind()
        {
            var objs = DataProvider.MenuTypeProvider.GetAll();
            this.dg_MenuTypeInfo.DataSource = objs;
            this.dg_MenuTypeInfo.DataBind();
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.myDataBind();
            }
            this.dg_MenuTypeInfo.AutoDataBind = myDataBind;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myDataBind();
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToUpper())
            {
                case "DELETE":
                    if (!CurrentUser.HasRight(RightEnum.MenuTypeMaintain))
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    if (this.dg_MenuTypeInfo.SelectedID.Length > 0)
                    {
                        if (DataProvider.MenuProvider.IsExistsByType(int.Parse(this.dg_MenuTypeInfo.SelectedID)))
                        {
                            AddScript("existsMenu","<script>alert('存在关联的菜单项，不能删除！');</script>");
                            return;
                        }
                        if (!DataProvider.MenuTypeProvider.Delete(int.Parse(this.dg_MenuTypeInfo.SelectedID)))
                        {
                            AddScript("deleteFailed","<script>alert('删除企业信息失败！');</script>");
                        }
                        else
                        {
                            this.myDataBind();
                        }
                    }
                    break;
            }
        }
        #endregion
    }
}
