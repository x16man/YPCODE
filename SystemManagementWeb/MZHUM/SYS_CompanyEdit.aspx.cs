
namespace SystemManagement.MZHUM
{
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;

	/// <summary>
	/// SYS_CompanyEdit 的摘要说明。
	/// </summary>
	public partial class SYS_CompanyEdit : BasePage
	{
		#region Field
	    private static readonly string COMPANYCODENOEMPTY_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("CompanyCodeNoEmpty"));
        private static readonly string COMPANYNAMENOEMPTY_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("CompanyNameNoEmpty"));
        private static readonly string INSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("CompanyInsertSuccess"));
        private static readonly string INSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("CompanyInsertFailed"));
	    private static readonly string UPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("CompanyUpdateSuccess"));
        private static readonly string UPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("CompanyUpdateFailed"));
		#endregion

		#region Property
		public string OP
		{
			get{return Request.QueryString["OP"];}
		}

		public string Code
		{
			get{return Request.QueryString["ID"];}
		}
		#endregion
        
        #region Method
        /// <summary>
        /// 绑定公司下拉列表。
        /// </summary>
		private void BindCompany()
		{
            var objs = DataProvider.CompanyProvider.GetAll();
            foreach(var obj in objs)
            {
                this.dpParentCompany.Items.Add(new ListItem(obj.CoName, obj.CoCode));
            }
			this.dpParentCompany.Items.Insert(0,new ListItem("----空----","0"));
		}
        /// <summary>
        /// 绑定数据到界面。
        /// </summary>
		private void BindData()
		{
            var obj = DataProvider.CompanyProvider.GetByCode(this.Code);
			if(obj != null)
			{
			    this.txtCoCnName.Text = obj.CoName;
			    this.txtCoCode.Text = obj.CoCode;
			    this.txtCoEnName.Text = obj.CoEnName;
			    this.txtShortName.Text = obj.CoShortName;
			    this.txtArtificialPerson.Text = obj.ArtificialPerson;
			    this.txtMgr.Text = obj.Mgr;
			    this.txtBussinessLicense.Text = obj.BussinessLicense;
			    this.txtBussinessRange.Text = obj.BussinessRange;
			    this.txtArea.Text = obj.CoArea;
			    this.txtAddress.Text = obj.CoAddress;
			    this.txtRemark.Text = obj.Remark;
				if( obj.ParentCo == "0")
					this.dpParentCompany.SelectedIndex = 0;
				else
					this.dpParentCompany.SelectedValue =  obj.ParentCo;
			
                this.chkIsValid.Checked = obj.IsValid == "Y" ? true : false;
                this.chkIsDefault.Checked = obj.IsDefault == "Y" ? true : false;
			}

        }
        /// <summary>
        /// 保存。
        /// </summary>
        private void Save()
        {
            if (!CurrentUser.HasRight(RightEnum.CompanyMaintain))
            {
                this.SetNoRightInfo(true);
                return;
            }
            if (string.IsNullOrEmpty(this.txtCoCode.Text))
            {
                AddScript(COMPANYCODENOEMPTY_SCRIPT);
                return;
            }
            if (string.IsNullOrEmpty(this.txtCoCnName.Text))
            {
                AddScript(COMPANYNAMENOEMPTY_SCRIPT);
                return;
            }
            var obj = new CompanyInfo
                          {
                              CoName = this.txtCoCnName.Text.Trim(),
                              CoCode = this.txtCoCode.Text.Trim(),
                              CoEnName = this.txtCoEnName.Text.Trim(),
                              CoShortName = this.txtShortName.Text.Trim(),
                              ArtificialPerson = this.txtArtificialPerson.Text.Trim(),
                              Mgr = this.txtMgr.Text.Trim(),
                              BussinessLicense = this.txtBussinessLicense.Text.Trim(),
                              BussinessRange = this.txtBussinessRange.Text.Trim(),
                              CoArea = this.txtArea.Text.Trim(),
                              CoAddress = this.txtAddress.Text.Trim(),
                              Remark = this.txtRemark.Text.Trim(),
                              ParentCo = this.dpParentCompany.SelectedValue,
                              ParentCoName =
                                  this.dpParentCompany.SelectedValue == "0"
                                      ? string.Empty
                                      : this.dpParentCompany.SelectedItem.Text.Trim(),
                              IsValid = this.chkIsValid.Checked ? "Y" : "N",
                              IsDefault = this.chkIsDefault.Checked?"Y":"N",
                          };
            
            if (this.OP == "New")
            {
                if (DataProvider.CompanyProvider.Insert(obj))
                {
                    AddScript(INSERTSUCCESS_SCRIPT);
                    AddScript("refresh",REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(INSERTFAILED_SCRIPT);
                }
            }
            else
            {
                if (DataProvider.CompanyProvider.Update(obj))
                {
                    AddScript(UPDATESUCCESS_SCRIPT);
                    AddScript("refresh",REFRESHPARENTANDCLOSE_SCRIPT);
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
            // 在此处放置用户代码以初始化页面
            if (!this.IsPostBack)
            {
                if (this.OP == "New")
                {
                    if (!CurrentUser.HasRight(RightEnum.CompanyMaintain))
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    BindCompany();
                }
                else if (this.OP == "Edit")
                {
                    if (!CurrentUser.HasRight(RightEnum.CompanyMaintain))
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    BindCompany();
                    BindData();
                    this.txtCoCode.ReadOnly = true;
                }
                else
                {
                    BindCompany();
                    BindData();
                    foreach (Control temp in this.Page.Controls[1].Controls)
                    {
                        if (temp is TextBox)
                        {
                            ((TextBox)temp).ReadOnly = true;
                        }

                        if (temp is DropDownList)
                        {
                            ((DropDownList)temp).Enabled = false;
                        }
                    }
                    this.MzhToolbar1.Visible = false;
                }
            }

        }
		
        /// <summary>
        /// Toolbar的PostBack事件。
        /// </summary>
        /// <param name="item">触发事件的ToolbarItem。</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId)
            {
                case "Save":
                    this.Save();
                    break;
            }
        }
        #endregion

    }
}
