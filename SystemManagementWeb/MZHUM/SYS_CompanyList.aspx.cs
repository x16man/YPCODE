using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_CompanyList ��ժҪ˵����
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
        /// �����ݵ�Grid��
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
        /// ҳ��ļ����¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
		{
            this.dg_CompanyInfo.AutoDataBind = this.BindDataToGrid;
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
        /// Toolbar�¼���
        /// </summary>
        /// <param name="item">�����¼���ToolbarItem��</param>
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
                            this.Response.Write("<script>alert('ɾ����ҵ��Ϣʧ�ܣ�');</script>");
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
        /// ˢ�°�ť�¼���
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
