
namespace SystemManagement.MZHUM
{
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;

	/// <summary>
	/// SYS_ProductEdit 的摘要说明。
	/// </summary>
	public partial class SYS_ProductEdit : BasePage
	{
		#region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169

	    private static readonly string INSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                ConfigCommon.GetMessageValue("ProductInsertFailed"));

#pragma warning disable 169
        private static readonly string INSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
#pragma warning restore 169
	                                                                 ConfigCommon.GetMessageValue("ProductInsertSuccess"));

        private static readonly string UPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                ConfigCommon.GetMessageValue("ProductUpdateFailed"));

#pragma warning disable 169
        private static readonly string UPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
#pragma warning restore 169
	                                                                 ConfigCommon.GetMessageValue("ProductUpdateSuccess"));

        private static readonly string PRODUCTCODENONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                        ConfigCommon.GetMessageValue("ProductCodeNonUnique"));

        private static readonly string PRODUCTNAMENONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                        ConfigCommon.GetMessageValue("ProductNameNonUnique"));
        #endregion

		#region Property
        /// <summary>
        /// 操作模式。
        /// </summary>
        string OP
        {
            get { return this.ViewState["OP"].ToString(); }
            set { this.ViewState["OP"] = value; }
        }
        /// <summary>
        /// 产品编号。
        /// </summary>
        short ProductCode
        {
            get { return short.Parse(this.ViewState["ProductCode"].ToString()); }
            set { this.ViewState["ProductCode"] = value; }
        }
        /// <summary>
        /// 产品名称。
        /// </summary>
	    string ProductName
	    {
            get { return this.ViewState["ProductName"].ToString(); }
            set { this.ViewState["ProductName"] = value;}
	    }
        bool NoParent
        {
            get {
                return !string.IsNullOrEmpty(Request["NoParent"]);
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 复位。
        /// </summary>
        private void Reset()
        {
            this.tb_ProductCode.Enabled = true;
            this.tb_ProductCode.Text = string.Empty;
            this.tb_ProductName.Text = string.Empty;
            this.tb_Remark.Text = string.Empty;
            this.chkIsValid.Checked = true;
        }
        /// <summary>
        /// 绑定数据到控件。
        /// </summary>
        private void MyDataBind()
        {
            this.tb_ProductCode.Enabled = false;
            var product = DataProvider.ProductProvider.GetByCode(this.ProductCode);
            this.ProductName = product.ProductName;

            this.tb_ProductCode.Text = product.ProductCode.ToString();
            this.tb_ProductName.Text = product.ProductName;
            this.tb_Remark.Text = product.Remark;
            this.chkIsValid.Checked = product.IsValid == "Y" ? true : false;
        }
        /// <summary>
        /// 保存。
        /// </summary>
        private void Save()
        {
            var product = new ProductInfo
                              {
                                  ProductCode = short.Parse(this.tb_ProductCode.Text),
                                  ProductName = this.tb_ProductName.Text,
                                  Remark = this.tb_Remark.Text,
                                  IsValid = (this.chkIsValid.Checked ? "Y" : "N")
                              };

            if (this.OP == "Add")
            {
                if (DataProvider.ProductProvider.IsExist(product.ProductCode))
                {
                    AddScript(PRODUCTCODENONUNIQUE_SCRIPT );
                    return;
                }
                if (DataProvider.ProductProvider.IsExist(product.ProductName))
                {
                    AddScript(PRODUCTNAMENONUNIQUE_SCRIPT);
                    return;
                }
                if (DataProvider.ProductProvider.Insert(product))
                {
                    if(!this.NoParent)
                        AddScript(REFRESHPARENT_SCRIPT);
                    this.tb_ProductCode.Enabled = false;
                    this.OP = "Edit";
                    this.ProductName = product.ProductName;
                }
                else
                {
                    AddScript(INSERTFAILED_SCRIPT);
                }
            }
            else
            {
                var producttemp = DataProvider.ProductProvider.GetByCode(product.ProductCode);
                if (producttemp != null)
                {
                    ProductName = producttemp.ProductName;
                }
                if(this.ProductName != product.ProductName)
                {
                    if(DataProvider.ProductProvider.IsExist(product.ProductName))
                    {
                        AddScript(PRODUCTNAMENONUNIQUE_SCRIPT);
                        return;
                    }
                }
                if (DataProvider.ProductProvider.Update(product))
                {
                    if(!this.NoParent)
                        AddScript(REFRESHPARENT_SCRIPT);
                }
                else
                {
                    AddScript(UPDATEFAILED_SCRIPT);
                }
            }
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
            if (!IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.ProductMaintain))
                {
                    this.YouHaveNoRightAndClose();
                    return;
                }
                if (!string.IsNullOrEmpty(Request["code"]))
                {
                    this.OP = "Edit";
                    this.ProductCode = short.Parse(Request["code"]);
                    this.MyDataBind();
                }
                else
                {
                    this.OP = "Add";
                }
                this.tbiClose.Visible = !this.NoParent;
            }
        }
        /// <summary>
        /// 工具条触发的事件。
        /// </summary>
        /// <param name="item">触发事件的ToolbarItem。</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch(item.ItemId)
            {
                case "Add":
                    this.OP = "Add";
                    this.Reset();
                    break;
                case "Save":
                    this.Save();
                    break;
            }
        }
        #endregion
    }
}
