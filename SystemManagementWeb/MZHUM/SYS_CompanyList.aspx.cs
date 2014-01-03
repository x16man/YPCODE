using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_CompanyList 的摘要说明。
	/// </summary>
	public partial class SYS_CompanyList : BasePage
    {
        #region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore 169
        #endregion

        #region Method
        /// <summary>
        /// 绑定数据到Grid。
        /// </summary>
        private void BindDataToGrid()
        {
            var objs = DataProvider.CompanyProvider.GetAll() as ListBase<CompanyInfo>;
            this.dg_CompanyInfo.DataSource = objs;
            this.dg_CompanyInfo.DataBind();
        }
        #endregion

        #region Event
        /// <summary>
        /// 页面的加载事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
		{
            this.dg_CompanyInfo.AutoDataBind = this.BindDataToGrid;
			// 在此处放置用户代码以初始化页面
			if(!this.IsPostBack)
			{
			    if(!CurrentUser.HasRight(RightEnum.CompanyView))
				{
                    this.SetNoRightInfo(true);
                    return;
				}
			    this.BindDataToGrid();
			}
            this.dg_CompanyInfo.AutoDataBind = BindDataToGrid;
		}
        /// <summary>
        /// Toolbar事件。
        /// </summary>
        /// <param name="item">触发事件的ToolbarItem。</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "delete":
                    if(!CurrentUser.HasRight(RightEnum.CompanyMaintain))
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    if (this.dg_CompanyInfo.SelectedID.Length > 0)
                    {
                        if (!DataProvider.CompanyProvider.Delete(this.dg_CompanyInfo.SelectedID))
                        {
                            this.Response.Write("<script>alert('删除企业信息失败！');</script>");
                        }
                        else
                        {
                            this.BindDataToGrid();
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
    
        protected void btnRefresh_Click(object sender, System.EventArgs e)
        {
            this.BindDataToGrid();
        }
        #endregion
    }
}
