
namespace SystemManagement.MZHUM
{
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;
	/// <summary>
	/// SYS_ProductEdit ��ժҪ˵����
	/// </summary>
	public partial class SYS_TemplateEdit : BasePage
	{
		#region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	    private static readonly string INSERT_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("TemplateInsertFailed"));
        private static readonly string INSERT_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("TemplateInsertSuccess"));
        private static readonly string UPDATE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("TemplateUpdateFailed"));
        private static readonly string UPDATE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("TemplateUpdateSuccess"));
        private static readonly string TEMPLATE_CODE_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("TemplateCodeNonUnique"));
        #pragma warning restore 169
        #endregion

        #region Property
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
        int TemplateID
        {
            get { return int.Parse(this.ViewState["ID"].ToString()); }
            set { this.ViewState["ID"] = value; }
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
        /// �ɱ�š�
        /// </summary>
	    string OldCode
	    {
            get { return this.ViewState["OldCode"].ToString(); }
            set { this.ViewState["OldCode"] = value;}
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
            this.txtCode.Enabled = false;
            var template = DataProvider.TemplateProvider.GetById(this.TemplateID);
            this.OldCode = template.Code;
            this.ProductCode = template.ProductCode;
            this.txtCode.Text = template.Code;
            this.txtName.Text = template.Name;
            this.txtContent.Text = template.Content;
            this.txtRemark.Text = template.Remark;
        }
        /// <summary>
        /// ���档
        /// </summary>
        private void Save()
        {
            var template = new TemplateInfo();
            var da = DataProvider.TemplateProvider;

            template.ID = this.TemplateID;
            template.ProductCode = this.ProductCode;
            template.Code = this.txtCode.Text;
            template.Name = this.txtName.Text.Trim();
            template.Content = this.txtContent.Text;
            template.Remark = this.txtRemark.Text;
            
            if (this.OP == "Add")
            {
                if (da.IsExist(template.Code))
                {
                    AddScript(TEMPLATE_CODE_NONUNIQUE_SCRIPT );
                    return;
                }
                if (da.Insert(template))
                {
                    AddScript("Refresh",REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(INSERT_FAILED_SCRIPT);
                }
            }
            else
            {
                if (template.Code != this.OldCode && da.IsExist(template.Code))
                {
                    AddScript(TEMPLATE_CODE_NONUNIQUE_SCRIPT);
                    return;
                }

                if (da.Update(template))
                {
                    AddScript("Refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(UPDATE_FAILED_SCRIPT);
                }
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
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!string.IsNullOrEmpty(Request["ID"]))
                {
                    this.OP = "Edit";
                    this.TemplateID = int.Parse(Request["ID"]);
                    this.MyDataBind();
                }
                else
                {
                    this.TemplateID = 0;
                    this.ProductCode = short.Parse(Request["ProductCode"]);
                    this.OP = "Add";
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
