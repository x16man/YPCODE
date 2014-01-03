using Shmzh.Components.SystemComponent;

namespace SystemManagement.MZHUM
{
    using System;
    using System.Web.UI.WebControls;
    using Shmzh.Components.SystemComponent.DALFactory;
	/// <summary>
	/// SYS_ProductList 的摘要说明。
	/// </summary>
	public partial class SYS_RightCodeList : BasePage
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 删除失败的提示脚本。
        /// </summary>
#pragma warning disable 169
	    private static readonly string DELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
#pragma warning restore 169
	                                                                       ConfigCommon.GetMessageValue(
                                                                               "RightCodeDeleteFailed"));
        /// <summary>
        /// 权限码正在被使用。
        /// </summary>
	    private static readonly string RIGHTCODEISUSING_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                           ConfigCommon.GetMessageValue(
	                                                                               "RightCodeIsUsing"));
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
	        get { return this.ViewState["ProductName"].ToString();}  
            set { this.ViewState["ProductName"] = value;}
	    }
	    
	    
        /// <summary>
        /// 数据绑定标记。
        /// </summary>
	    public int Flag
	    {
            get { return int.Parse(ViewState["Flag"].ToString()); }
            set { ViewState["Flag"] = value; }
	    }
        #endregion

        #region Method
        /// <summary>
        /// 绑定数据到DataGrid。
        /// </summary>
        private void myDataBind()
		{
            var objs = new ListBase<RightInfo>();
            switch (this.Flag)
            {
                case 1:
                    if (this.tbiDisabled.Checked)
                        objs = DataProvider.RightProvider.GetAllByProductCode(this.ProductCode) as ListBase<RightInfo>;
                    else
                        objs =
                            DataProvider.RightProvider.GetAllAvalibleByProductCode(this.ProductCode) as ListBase<RightInfo>;
                    this.dg_RightCode.DataSource = objs;
                    break;
                case 2:
                    objs = (this.tbiRightCat.SelectedValue == "0"
                               ? (this.tbiDisabled.Checked
                                      ? DataProvider.RightProvider.GetAllByProductCode(this.ProductCode)
                                      : DataProvider.RightProvider.GetAllAvalibleByProductCode(this.ProductCode))
                               : (this.tbiDisabled.Checked
                                      ? DataProvider.RightProvider.GetAllByRightCatCode(this.tbiRightCat.SelectedValue)
                                      : DataProvider.RightProvider.GetAllAvalibleByRightCatCode(this.tbiRightCat.SelectedValue))) as ListBase<RightInfo>;
                    
                    this.dg_RightCode.DataSource = objs;
                    break;
            }
            this.dg_RightCode.DataBind();
        }
        /// <summary>
        /// 绑定分组列表。
        /// </summary>
        private void BindRightCat()
        {
            this.tbiRightCat.Items.Clear();

            var objs = DataProvider.RightCatProvider.GetAllAvalibleByProductCode(this.ProductCode);
            var oItem = new ListItem("--全部--", "0");
            this.tbiRightCat.Items.Add(oItem);
            foreach (var obj in objs)
            {
                oItem = new ListItem(obj.Name,obj.Code);
                this.tbiRightCat.Items.Add(oItem);
            }
        }
        /// <summary>
        /// 获取权限分类名称。
        /// </summary>
        /// <param name="rightCatCode">权限分类编号。</param>
        /// <returns>权限分类名称。</returns>
        protected string GetRightCatName(string rightCatCode)
        {
            foreach (ListItem oItem in this.tbiRightCat.Items)
            {
                if (oItem.Value == rightCatCode && rightCatCode !="0")
                    return oItem.Text;
            }
            return string.Empty;
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
            //Logger.Info("Page_Load");
			if(!Page.IsPostBack)
			{
                if (!CurrentUser.HasRight(RightEnum.ProductRightMaintain))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["productCode"]))
                {
                    this.ProductCode = short.Parse(Request.QueryString["productCode"]);
                    var product = DataProvider.ProductProvider.GetByCode(this.ProductCode);
                   
                    if (product == null)
                    {
                        this.SetErrorInfo("没有该产品信息！请先维护该产品信息。", true);
                    }
                    else
                    {
                        this.ProductName = product.ProductName;
                        this.BindRightCat();
                        this.Flag = 1;
                        myDataBind();
                    }
                }
			}
            this.dg_RightCode.AutoDataBind = myDataBind;
		}
		/// <summary>
		/// Toolbar事件。
		/// </summary>
		/// <param name="item">触发事件的ToolbarItem</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
		{
			switch(item.ItemId.ToUpper())
			{
				case "DELETE":
					if(this.dg_RightCode.SelectedID .Length  > 0 )
					{
					    var rightCode = short.Parse(this.dg_RightCode.SelectedID);
                        if(DataProvider.RightProvider.IsUsing(rightCode))
                        {
                            AddScript(RIGHTCODEISUSING_SCRIPT);
                        }
                        else
                        {
                            if (DataProvider.RightProvider.Delete(rightCode))
                            {
                                myDataBind();
                            }
                            else
                            {
                                AddScript(DELETEFAILED_SCRIPT);
                            }
                        }
                        
					}
					break;
				case "RIGHTCAT":
			        this.Flag = 2;
                    this.myDataBind();
					break;
                case "INCLUDEDISABLED":
                    this.myDataBind();
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
