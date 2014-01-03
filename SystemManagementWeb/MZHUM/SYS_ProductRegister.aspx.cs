
namespace SystemManagement.MZHUM
{
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;

    /// <summary>
    /// ��Ʒע��ҳ�档
    /// </summary>
    public partial class SYS_ProductRegister : BasePage
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
        private ProductInfo Product
        {
            get
            {
                return ViewState["Product"] as ProductInfo;
            }
            set
            {
                ViewState["Product"] = value;
            }
        }
        /// <summary>
        /// ����ģʽ��
        /// </summary>
        string OP
        {
            get { return this.ViewState["OP"].ToString(); }
            set { this.ViewState["OP"] = value; }
        }
        /// <summary>
        /// ��Ʒ��š�
        /// </summary>
        short ProductCode
        {
            get { return short.Parse(this.ViewState["ProductCode"].ToString()); }
            set { this.ViewState["ProductCode"] = value; }
        }
        /// <summary>
        /// ��Ʒ���ơ�
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
        /// �����ݵ��ؼ���
        /// </summary>
        private void MyDataBind()
        {
            this.tb_ProductCode.Enabled = false;
            this.tb_ProductName.Enabled = false;

            this.Product = DataProvider.ProductProvider.GetByCode(this.ProductCode);

            this.tb_ProductCode.Text = Product.ProductCode.ToString();
            this.tb_ProductName.Text = Product.ProductName;
            this.tb_License.Text = Product.License;

            var company = DataProvider.CompanyProvider.GetDefault();
            if (company != null)
            {
                this.lblCompanyName.Text = company.CoName;
            }
        }
        /// <summary>
        /// ���档
        /// </summary>
        private void Save()
        {
            this.Product.License = this.tb_License.Text;

            if(DataProvider.ProductProvider.Register(this.Product))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"ok","alert('ע��ɹ���');window.close();",true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "ok", "alert('ע��ʧ�ܣ�');window.close();", true);   
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// ҳ������¼���
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
                    this.Response.Write("����Ҫָ����Ʒ��");
                    this.Response.End();
                    return;
                }
                this.tbiClose.Visible = !this.NoParent;
            }
        }
        /// <summary>
        /// �������������¼���
        /// </summary>
        /// <param name="item">�����¼���ToolbarItem��</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch(item.ItemId)
            {
                case "Save":
                    this.Save();
                    break;
            }
        }
        #endregion
    }
}
