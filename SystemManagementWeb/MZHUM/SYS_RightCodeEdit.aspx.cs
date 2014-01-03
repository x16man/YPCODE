

namespace SystemManagement.MZHUM
{
    using System.Web.UI.WebControls;
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;
    /// <summary>
	/// SYS_ProductEdit 的摘要说明。
	/// </summary>
	public partial class SYS_RightCodeEdit : BasePage
    {
        #region Field
        /// <summary>
        /// 权限码新增失败的提示脚本。
        /// </summary>
        private static readonly string INSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeInsertFailed"));
        /// <summary>
        /// 权限码更新成功的提示脚本。
        /// </summary>
        private static readonly string INSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeInsertSuccess"));
        /// <summary>
        /// 权限码更新失败的提示脚本。
        /// </summary>
        private static readonly string UPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeUpdateFailed"));
        /// <summary>
        /// 权限码更新成功的提示脚本。
        /// </summary>
        private static readonly string UPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeUpdateSuccess"));
        /// <summary>
        /// 权限码不唯一的提示脚本。
        /// </summary>
        private static readonly string NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue(
                                                                               "RightCodeNonUnique"));
        /// <summary>
        /// 权限码没有指定权限分组。
        /// </summary>
        private static readonly string NOCAT_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("RightCodeNoCat")); 
        #endregion

        #region Property
        /// <summary>
        /// 产品编号。
        /// </summary>
        public short Productcode
        {
            get { return short.Parse(this.ViewState["ProductCode"].ToString()); }
            set { this.ViewState["ProductCode"] = value; }
        }
        /// <summary>
        /// 权限分类编号。
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
        /// 操作模式。
        /// </summary>
        public string OP
        {
            get { return this.ViewState["OP"].ToString(); }
            set { this.ViewState["OP"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// 绑定权限分类信息到DropdownList控件。
        /// </summary>
		private void BindRightCatData()
		{
            this.ddlCat.Items.Clear();
            this.ddlCat.DataTextField = "Name";
            this.ddlCat.DataValueField = "Code";
            this.ddlCat.DataSource = DataProvider.RightCatProvider.GetAllAvalibleByProductCode(this.Productcode);
            this.ddlCat.DataBind();
            this.ddlCat.Items.Insert(0, new ListItem("---空---", "0"));
		}
		/// <summary>
		/// 显示信息.
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
        /// 复位。
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
        /// 保存。
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
                if (this.OldCode != obj.RightCode)//权限编号改变,需要判断修改后的编码是否已经存在。
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
        /// 页面加载事件。
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
        /// Toolbar事件。
        /// </summary>
        /// <param name="item">触发toolbar回送的ToolbarItem。</param>
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
