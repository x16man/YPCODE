using System;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;


namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_ProductList 的摘要说明。
	/// </summary>
	public partial class SYS_TemplateList : BasePage
    {
        #region Field
        /// <summary>
        /// 删除失败提醒脚本。
        /// </summary>
        private static readonly string DELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                ConfigCommon.GetMessageValue("ProductDeleteFailed"));
        #endregion

        #region Propetry
        /// <summary>
        /// 产品Id。
        /// </summary>
        public short ProductCode
        {
            get { return short.Parse(this.txtProductCode.Text); }
            set { this.txtProductCode.Text = value.ToString(); }
        }
        /// <summary>
		/// 模板记录集合。
		/// </summary>
		protected IList<TemplateInfo> Templates
		{
            get { return this.Session["Templates"] as List<TemplateInfo>; }
            set { this.Session["Templates"] = value; }
		}
		#endregion

		#region private method
		/// <summary>
		/// 数据绑定。
		/// </summary>
		private void myDataBind()
		{
		    this.Templates = DataProvider.TemplateProvider.GetByProductCode(this.ProductCode) as ListBase<TemplateInfo>;
            this.dg_Template.DataSource = this.Templates;
			this.dg_Template.DataBind();
		}
		#endregion
        
		#region Event
		/// <summary>
		/// 页面加载事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
                if (string.IsNullOrEmpty(Request["ProductCode"]))
                {
                    this.Response.Write("<script>alert('页面URL没有指定ProductCode参数值。');</script>");
                    return;
                }
                this.ProductCode = short.Parse(Request["ProductCode"]);

				if(CurrentUser.HasRight(RightEnum.ProductView))
				{
					this.myDataBind();
					if (!CurrentUser.HasRight(RightEnum.TemplateMaintain))
					{
						this.toolbarItemAdd.Visible = false;
						this.toolbarItemEdit.Visible = false;
						this.toolbarItemDelete.Visible = false;
					}
				}
				else
				{
					this.SetNoRightInfo(true);
				}
			}
		    this.dg_Template.AutoDataBind = myDataBind;
		}
		/// <summary>
		/// 菜单工具条事件。
		/// </summary>
		/// <param name="item"></param>
		protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
		{
			switch(item.ItemId.ToUpper())
			{
				case "DELETE":
			        if (this.dg_Template.SelectedID.Length > 0)
			        {
			            if (DataProvider.TemplateProvider.Delete(int.Parse(this.dg_Template.SelectedID)))
			            {
			                this.myDataBind();
			            }
			            else
			            {
			                AddScript(DELETEFAILED_SCRIPT);
			            }
			        }
			        break;
			}
		}
		/// <summary>
		/// 刷新按钮事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myDataBind();
        }
        #endregion
    }
}
