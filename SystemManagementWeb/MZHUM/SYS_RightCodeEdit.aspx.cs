

namespace SystemManagement.MZHUM
{
    using System.Web.UI.WebControls;
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;
    /// <summary>
	/// SYS_ProductEdit ��ժҪ˵����
	/// </summary>
	public partial class SYS_RightCodeEdit : BasePage
    {
        #region Field
        /// <summary>
        /// Ȩ��������ʧ�ܵ���ʾ�ű���
        /// </summary>
        private static readonly string INSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeInsertFailed"));
        /// <summary>
        /// Ȩ������³ɹ�����ʾ�ű���
        /// </summary>
        private static readonly string INSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeInsertSuccess"));
        /// <summary>
        /// Ȩ�������ʧ�ܵ���ʾ�ű���
        /// </summary>
        private static readonly string UPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeUpdateFailed"));
        /// <summary>
        /// Ȩ������³ɹ�����ʾ�ű���
        /// </summary>
        private static readonly string UPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeUpdateSuccess"));
        /// <summary>
        /// Ȩ���벻Ψһ����ʾ�ű���
        /// </summary>
        private static readonly string NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeNonUnique"));
        /// <summary>
        /// Ȩ����û��ָ��Ȩ�޷��顣
        /// </summary>
        private static readonly string NOCAT_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RightCodeNoCat")); 
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
        public short OldCode
        {
            get 
            {
                return ViewState["OldCode"] == null ? (short) 0 : short.Parse(ViewState["OldCode"].ToString());
            }
            set { ViewState["OldCode"] = value; }
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
        /// ��Ȩ�޷�����Ϣ��DropdownList�ؼ���
        /// </summary>
		private void BindRightCatData()
		{
            this.ddlCat.Items.Clear();
            this.ddlCat.DataTextField = "Name";
            this.ddlCat.DataValueField = "Code";
            this.ddlCat.DataSource = DataProvider.RightCatProvider.GetAllAvalibleByProductCode(this.Productcode);
            this.ddlCat.DataBind();
            this.ddlCat.Items.Insert(0, new ListItem("---��---", "0"));
		}
		/// <summary>
		/// ��ʾ��Ϣ.
		/// </summary>
		private void showInfo()
		{
            this.txtRightCode.Enabled = this.CurrentUser.thisUserInfo.LoginName.ToLower() == "administrator";
			
			var obj = DataProvider.RightProvider.GetByCode(OldCode);
			
			if (obj != null)
			{
				this.txtRightCode.Text = obj.RightCode.ToString();
				this.txtRightName.Text = obj.RightName;
				this.txtRemark.Text = obj.Remark;
                this.chkIsValid.Checked = obj.IsValid == "Y" ? true : false;
				try
				{
					if(obj.RightCatCode.ToString().Trim() != "")
					{
						this.ddlCat.SelectedValue = obj.RightCatCode.ToString();
					}
				}
				catch
				{
					AddScript(NOCAT_SCRIPT);
				}
			}
        }
        /// <summary>
        /// ��λ��
        /// </summary>
        private void Reset()
        {
            this.txtRightCode.Enabled = true;
            this.txtRightCode.Text = string.Empty;
            this.txtRightName.Text = string.Empty;
            this.txtRemark.Text = string.Empty;
            this.ddlCat.SelectedIndex = 0;
            this.chkIsValid.Checked = true;
        }
        /// <summary>
        /// ���档
        /// </summary>
        private void Save()
        {
            var obj = new RightInfo
                          {
                              RightCode = short.Parse(this.txtRightCode.Text),
                              RightName = this.txtRightName.Text,
                              RightCatCode = this.ddlCat.SelectedValue == "0" ? string.Empty : this.ddlCat.SelectedValue,
                              Remark = this.txtRemark.Text,
                              IsValid = (this.chkIsValid.Checked ? "Y" : "N"),
                              ProductCode = this.Productcode
                          };

            if (this.OP == "Add")
            {
                if (DataProvider.RightProvider.IsExist(obj.RightCode))
                {
                    AddScript(NONUNIQUE_SCRIPT);
                    return;
                }
                if (DataProvider.RightProvider.Insert(obj))
                {
                    AddScript(REFRESHPARENT_SCRIPT);
                    AddScript("refresh", INSERTSUCCESS_SCRIPT);
                    this.txtRightCode.Enabled = this.CurrentUser.thisUserInfo.LoginName.ToLower() == "administrator";
                    this.OldCode = obj.RightCode;
                    this.OP = "Edit";
                }
                else
                {
                    AddScript(INSERTFAILED_SCRIPT);
                }
            }
            else
            {
                obj.OldRightCode = this.OldCode;
                if (this.OldCode != obj.RightCode)//Ȩ�ޱ�Ÿı�,��Ҫ�ж��޸ĺ�ı����Ƿ��Ѿ����ڡ�
                {
                    if (DataProvider.RightProvider.IsExist(obj.RightCode))
                    {
                        AddScript(NONUNIQUE_SCRIPT);
                        return;
                    }
                }
                if (DataProvider.RightProvider.Update(obj))
                {
                    this.OldCode = obj.RightCode;
                    AddScript(REFRESHPARENT_SCRIPT);
                    AddScript("refresh", UPDATESUCCESS_SCRIPT);
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
            if (!Page.IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.ProductRightMaintain))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!string.IsNullOrEmpty(Request["ProductCode"]))
                {
                    this.Productcode = short.Parse(Request["ProductCode"].ToString());
                }
                
                this.BindRightCatData();
                if (!string.IsNullOrEmpty(Request["Code"]))
                {

                    this.OldCode = short.Parse(Request["Code"].ToString());
                    this.OP = "Edit";
                    this.showInfo();
                }
                else
                {
                    this.OP = "Add";
                }
            }
		}
        /// <summary>
        /// Toolbar�¼���
        /// </summary>
        /// <param name="item">����toolbar���͵�ToolbarItem��</param>
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
