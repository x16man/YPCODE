using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SEDataTypeList : BasePage
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Property

        #endregion

        #region Method
        private void myDataBind()
        {
            var objs = DataProvider.SEDataTypeProvider.GetAll() as ListBase<SEDataTypeInfo>;
            this.dg_SEDataTypeInfo.DataSource = objs;
            this.dg_SEDataTypeInfo.DataBind();
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.myDataBind();
            }
            this.dg_SEDataTypeInfo.AutoDataBind = myDataBind;
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
                    if (!CurrentUser.HasRight(RightEnum.SEModule))
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    if (this.dg_SEDataTypeInfo.SelectedID.Length > 0)
                    {
                        if (!DataProvider.SEDataTypeProvider.Delete(int.Parse(this.dg_SEDataTypeInfo.SelectedID)))
                        {
                            this.Response.Write("<script>alert('删除查询引擎数据类型失败！');</script>");
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
