using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_RightCatEdit ��ժҪ˵����
	/// </summary>
	public partial class SYS_RightCatEdit : BasePage
    {
        #region Field
        /// <summary>
        /// Ȩ�޷����Ų�Ψһ����ʾ�ű���
        /// </summary>
#pragma warning disable 169
        private static readonly string RIGHTCATCODENONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RightCatCodeNonUnique"));
        private static readonly string RIGHTCATNAMENONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RightCatNameNonUnique"));
	    private static readonly string INSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,ConfigCommon.GetMessageValue("RightCatInsertSuccess"));
        private static readonly string INSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RightCatInsertFailed"));
        private static readonly string UPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RightCatUpdateSuccess"));
        private static readonly string UPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RightCatUpdateFailed"));
#pragma warning restore 169
        #endregion

        #region Property
        /// <summary>
        /// ��Ʒ��š�
        /// </summary>
        public short Productcode
		{
            get { return short.Parse(this.ViewState["ProductCode"].ToString()); }
            set { this.ViewState["ProductCode"] = value; }
        }
        /// <summary>
        /// Ȩ�޷����š�
        /// </summary>
        public string Code
        {
            get { return ViewState["Code"].ToString(); }
            set { ViewState["Code"] = value; }
        }
        /// <summary>
        /// Ȩ�޷������ơ�
        /// </summary>
	    public string Name
	    {
            get { return ViewState["Name"].ToString(); }
            set { ViewState["Name"] = value;}
	    }
        /// <summary>
        /// ����ģʽ��
        /// </summary>
        public string OP
        {
            get { return this.ViewState["OP"].ToString(); }
            set { this.ViewState["OP"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// ��ʾȨ�޷�����Ϣ��
        /// </summary>
        private void BindData()
        {
            this.txtRightCatCode.Enabled = false;
            var obj = DataProvider.RightCatProvider.GetByCode(this.Code);
            if (obj != null)
            {
                this.txtRightCatCode.Text = obj.Code;
                this.txtRightCatName.Text = obj.Name;
                this.Name = obj.Name;
                this.txtRemark.Text = obj.Desc;
                this.chkIsValid.Checked = obj.IsValid == "Y" ? true : false;
            }
        }
        /// <summary>
        /// ��λ��
        /// </summary>
        private void Reset()
        {
            this.txtRightCatCode.Enabled = true;
            this.txtRightCatCode.Text = string.Empty;
            this.txtRightCatName.Text = string.Empty;
            this.txtRemark.Text = string.Empty;
            this.chkIsValid.Checked = true;
        }
        /// <summary>
        /// ���档
        /// </summary>
        private void Save()
        {
            var obj = new RightCatInfo
                          {
                              Code = this.txtRightCatCode.Text,
                              Name = this.txtRightCatName.Text,
                              Desc = this.txtRemark.Text,
                              IsValid = this.chkIsValid.Checked ? "Y" : "N",
                              ProductCode = this.Productcode,
                          };
            if (this.OP == "Add")
            {
                if (DataProvider.RightCatProvider.IsExist(obj.Code))
                {
                    AddScript(RIGHTCATCODENONUNIQUE_SCRIPT);
                    return;
                }
                if(DataProvider.RightCatProvider.IsExist(this.Productcode, obj.Name))
                {
                    AddScript(RIGHTCATNAMENONUNIQUE_SCRIPT);
                    return;
                }
                if (DataProvider.RightCatProvider.Insert(obj))
                {
                    AddScript(INSERTSUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENT_SCRIPT);
                    this.txtRightCatCode.Enabled = false;
                    this.OP = "Edit";
                }
                else
                {
                    AddScript(INSERTFAILED_SCRIPT);
                }
                
            }
            else
            {
                var oldobj = DataProvider.RightCatProvider.GetByCode(this.txtRightCatCode.Text);
                if (oldobj.Name != obj.Name)
                {
                    if(DataProvider.RightCatProvider.IsExist(this.Productcode, obj.Name))
                    {
                        AddScript(RIGHTCATNAMENONUNIQUE_SCRIPT);
                        return;
                    }
                }
                if (DataProvider.RightCatProvider.Update(obj))
                {
                    AddScript(UPDATESUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENT_SCRIPT);
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
        /// ҳ������¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (!Page.IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.RightCatMaintain))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!string.IsNullOrEmpty(Request["ProductCode"]))
                {
                    this.Productcode = short.Parse(Request["ProductCode"].ToString());
                }
                if (!string.IsNullOrEmpty(Request["Code"]))
                {
                    this.Code = Request["Code"].ToString();
                    this.OP = "Edit";
                    this.BindData();
                }
                else
                {
                    this.OP = "Add";
                }
            }
        }
        /// <summary>
        /// Toolbar���¼���
        /// </summary>
        /// <param name="item">�����¼���ToolbarItem��</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId)
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
