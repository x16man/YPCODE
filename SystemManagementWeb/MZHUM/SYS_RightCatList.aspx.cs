using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_RightCatList 的摘要说明。
	/// </summary>
	public partial class SYS_RightCatList : BasePage
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	    /// <summary>
	    /// 权限分类正在被使用的提示脚本。
	    /// </summary>
	    private static readonly string RIGHTCATEGORYISUSING_SCRIPT =
	        string.Format(ALERT_FORMATSTRING,
	                      ConfigCommon.GetMessageValue("RightCatIsUsing"));

	    /// <summary>
	    /// 权限分类删除失败的提示脚本。
	    /// </summary>
	    private static readonly string DELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                       ConfigCommon.GetMessageValue(
	                                                                           "RightCatDeleteFailed"));
        #endregion

        #region Property
        /// <summary>
        /// 产品编号。
        /// </summary>
        public short ProductCode
        {
            get { return short.Parse(this.txtProductCode.Text); }
            set { this.txtProductCode.Text = value.ToString(); }
        }
	    /// <summary>
	    /// 产品名称。
	    /// </summary>
	    public string ProductName
	    {
            get { return this.ViewState["ProductName"].ToString(); }
            set { this.ViewState["ProductName"] = value; }
	    }
        /// <summary>
        /// 查询标志。
        /// </summary>
        public int SelectFlag
        {
            get { return int.Parse(ViewState["SelectFlag"].ToString()); }
            set { ViewState["SelectFlag"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// 绑定产品列表。
        /// </summary>
        private void BindProduct()
        {
            this.toolbarDropdownList1.Items.Clear();
            var products = DataProvider.ProductProvider.GetAllAvalible();

            var oItem = new ListItem("--全部--", "0");
            this.toolbarDropdownList1.Items.Add(oItem);
            foreach (ProductInfo obj in products)
            {
                oItem = new ListItem(obj.ProductName, obj.ProductCode.ToString());
                this.toolbarDropdownList1.Items.Add(oItem);
            }
        }
        /// <summary>
        /// 绑定权限分类信息到DataGrid控件。
        /// </summary>
        private void BindData()
        {
            if (this.SelectFlag == 2)
            {
                this.ProductCode = short.Parse(this.toolbarDropdownList1.SelectedValue);
            }
            var objs = DataProvider.RightCatProvider.GetAllByProductCode(this.ProductCode) as ListBase<RightCatInfo>;
            this.dg_RightCat.DataSource = objs;
            this.dg_RightCat.DataBind();

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
                if (!CurrentUser.HasRight(RightEnum.RightCatMaintain))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
			    this.SelectFlag = 1;
				if (string.IsNullOrEmpty(Request["productCode"]))
				{
					this.ProductCode = 0;
					BindProduct();
                } 
				else
				{
					this.ProductCode = short.Parse(Request["productCode"]);
				    this.ProductName = DataProvider.ProductProvider.GetByCode(this.ProductCode).ProductName;
				}
				this.BindData();
			}
            this.dg_RightCat.AutoDataBind = BindData;
		}
        
        /// <summary>
        /// Toolbar回送事件。
        /// </summary>
        /// <param name="item">触发事件的ToolbarItem。</param>
		protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
		{
			switch(item.ItemId.ToUpper())
			{
				case "DELETE":
					if(this.dg_RightCat.SelectedID .Length  > 0 )
					{
					    if (DataProvider.RightCatProvider.HasChildren(this.dg_RightCat.SelectedID))
					    {
					        AddScript(RIGHTCATEGORYISUSING_SCRIPT);
					    }
					    else
					    {
					        if (DataProvider.RightCatProvider.Delete(this.dg_RightCat.SelectedID))
					        {
					            this.BindData();
					        }
					        else
					        {
					            AddScript(DELETEFAILED_SCRIPT);
					        }
					    }
					}
					break;
				case "DDLPRODUCT":
			        this.SelectFlag = 2;
			        this.BindData();
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
            this.BindData();
        }
        #endregion
    }
}
