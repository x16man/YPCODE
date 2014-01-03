﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SEControlTypeList : BasePage
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Property

        #endregion

        #region Method
        private void myDataBind()
        {
            var objs = DataProvider.SEControlTypeProvider.GetAll() as ListBase<SEControlTypeInfo>;
            this.dg_SEControlTypeInfo.DataSource = objs;
            this.dg_SEControlTypeInfo.DataBind();
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.myDataBind();
            }
            this.dg_SEControlTypeInfo.AutoDataBind = myDataBind;
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
                    if (this.dg_SEControlTypeInfo.SelectedID.Length > 0)
                    {
                        if (!DataProvider.SEControlTypeProvider.Delete(int.Parse(this.dg_SEControlTypeInfo.SelectedID)))
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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myDataBind();
        }
        #endregion

        
    }
}