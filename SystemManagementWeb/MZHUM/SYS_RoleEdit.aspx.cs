using System;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_RoleEdit : BasePage
    {
        #region Field

        private static readonly string ROLEINSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                               ConfigCommon.GetMessageValue(
                                                                                   "RoleInsertFailed"));

        private static readonly string ROLEINSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                                ConfigCommon.GetMessageValue(
                                                                                    "RoleInsertSuccess"));
        private static readonly string ROLEUPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                                ConfigCommon.GetMessageValue(
                                                                                    "RoleUpdateFailed"));
        private static readonly string ROLEUPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                                ConfigCommon.GetMessageValue(
                                                                                    "RoleUpdateSuccess"));
        #endregion

        #region Property
        /// <summary>
        /// 产品编号。
        /// </summary>
        public short ProductCode
        {
            get { return short.Parse(this.ViewState["ProductCode"].ToString()); }
            set { this.ViewState["ProductCode"] = value; }
        }
        /// <summary>
        /// 角色编号。
        /// </summary>
        public short Code
        {
            get { return short.Parse(ViewState["Code"].ToString()); }
            set { ViewState["Code"] = value; }
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
            var obj = DataProvider.RoleProvider.GetByCode(this.Code);
            if (obj != null)
            {
                this.txtName.Text = obj.RoleName; 
                this.txtRemark.Text = obj.Remark;
                this.txtSerialNo.Text = obj.SerialNo == -1 ? string.Empty : obj.SerialNo.ToString();
                this.chkIsValid.Checked = obj.IsValid == "Y" ? true : false;
            }
        }

        /// <summary>
        /// 保存。
        /// </summary>
        private void Save()
        {
            var role = new RoleInfo
                           {
                               RoleName = this.txtName.Text,
                               IsValid = this.chkIsValid.Checked?"Y":"N",
                               ProductCode = this.ProductCode,
                               SerialNo = string.IsNullOrEmpty(this.txtSerialNo.Text.Trim())?-1:int.Parse(this.txtSerialNo.Text.Trim()),
                               Remark = this.txtRemark.Text,
                           };

            if (this.OP == "Add")
            {
                if (DataProvider.RoleProvider.Insert(role))
                {
                    AddScript(ROLEINSERTSUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENT_SCRIPT);
                }
                else
                {
                    AddScript(ROLEINSERTFAILED_SCRIPT);
                }
            }
            else
            {
                role.RoleCode = this.Code;
                if (DataProvider.RoleProvider.Update(role))
                {
                    AddScript(ROLEUPDATESUCCESS_SCRIPT);
                    AddScript("refresh",REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(ROLEUPDATEFAILED_SCRIPT);
                }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Code"]))
                {
                    this.Code = short.Parse(Request["Code"]);
                    this.OP = "Edit";
                }
                else
                {
                    this.OP = "Add";
                }
                if (!string.IsNullOrEmpty(Request["ProductCode"]))
                {
                    this.ProductCode = short.Parse(Request["ProductCode"]);
                }
                if(this.OP == "Edit")
                {
                    this.BindData();
                }
            }
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch(item.ItemId.ToUpper())
            {
                case "SAVE":
                    this.Save();
                    break;
            }
        }

    }
}
