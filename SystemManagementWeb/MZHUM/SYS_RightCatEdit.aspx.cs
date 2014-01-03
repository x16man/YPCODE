using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_RightCatEdit 的摘要说明。
	/// </summary>
	public partial class SYS_RightCatEdit : BasePage
    {
        #region Field
        /// <summary>
        /// 权限分类编号不唯一的提示脚本。
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
        public string Code
        {
            get { return ViewState["Code"].ToString(); }
            set { ViewState["Code"] = value; }
        }
        /// <summary>
        /// 权限分类名称。
        /// </summary>
	    public string Name
	    {
            get { return ViewState["Name"].ToString(); }
            set { ViewState["Name"] = value;}
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
        /// 显示权限分类信息。
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
        /// 复位。
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
        /// 保存。
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
        /// 页面加载事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
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
        /// Toolbar的事件。
        /// </summary>
        /// <param name="item">触发事件的ToolbarItem。</param>
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
