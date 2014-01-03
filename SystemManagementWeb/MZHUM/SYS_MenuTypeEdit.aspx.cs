using System;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_MenuTypeEdit : BasePage
    {
        #region Field

        private static readonly string MENUTYPE_INSERT_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("MenuTypeInsertSuccess"));
        private static readonly string MENUTYPE_INSERT_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("MenuTypeInsertFailed"));
        private static readonly string MENUTYPE_UPDATE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("MenuTypeUpdateSuccess"));
        private static readonly string MENUTYPE_UPDATE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("MenuTypeUpdateFailed"));
        private static readonly string MENUTYPEID_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING,ConfigCommon.GetMessageValue("MenuTypeIdNonUnique"));
        private static readonly string MENUTYPENAME_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("MenuTypeNameNonUnique"));
        #endregion

        #region Property
        /// <summary>
        /// 菜单类型Id。
        /// </summary>
        public int MenuTypeId
        {
            get { return int.Parse(this.ViewState["MenuTypeId"].ToString()); }
            set { this.ViewState["MenuTypeId"] = value; }
        }
        /// <summary>
        /// 菜单类型名称。
        /// </summary>
        public string MenuTypeName
        {
            get { return this.ViewState["MenuTypeName"].ToString(); }
            set { this.ViewState["MenuTypeName"] = value; }
        }
        /// <summary>
        /// 操作模式。
        /// </summary>
        public string OP
        {
            get { return ViewState["OP"].ToString(); }
            set { ViewState["OP"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// 绑定数据到界面。
        /// </summary>
        private void BindData()
        {
            var obj = DataProvider.MenuTypeProvider.GetById(this.MenuTypeId);
            if (obj != null)
            {
                this.MenuTypeId = obj.ID;
                this.MenuTypeName = obj.Name;

                this.txtId.Text = obj.ID.ToString();
                this.txtName.Text = obj.Name;
                this.chkIsUsedByFrameWork.Checked = obj.IsUsedByFrameWork;
                this.txtRemark.Text = obj.Remark;
            }
        }
        /// <summary>
        /// 保存操作。
        /// </summary>
        private void Save()
        {
            var obj = new MenuTypeInfo
            {
                ID = int.Parse(this.txtId.Text),
                Name = this.txtName.Text.Trim(),
                IsUsedByFrameWork = this.chkIsUsedByFrameWork.Checked,
                Remark = this.txtRemark.Text.Trim()
            };

            if (this.OP == "Add")
            {
                if (DataProvider.MenuTypeProvider.IsExist(obj.ID))
                {
                    AddScript(MENUTYPEID_NONUNIQUE_SCRIPT);
                    return;
                }
                if(DataProvider.MenuTypeProvider.IsExist(obj.Name))
                {
                    AddScript(MENUTYPENAME_NONUNIQUE_SCRIPT);
                    return;
                }
                if (DataProvider.MenuTypeProvider.Insert(obj))
                {
                    AddScript(MENUTYPE_INSERT_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(MENUTYPE_INSERT_FAILED_SCRIPT);
                }
            }
            else
            {
                if (this.MenuTypeName != obj.Name)
                {
                    if (DataProvider.MenuTypeProvider.IsExist(obj.Name))
                    {
                        AddScript(MENUTYPENAME_NONUNIQUE_SCRIPT);
                        return;
                    }
                }
                if (DataProvider.MenuTypeProvider.Update(obj))
                {
                    AddScript(MENUTYPE_UPDATE_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(MENUTYPE_UPDATE_FAILED_SCRIPT);
                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (!string.IsNullOrEmpty(Request["Id"]))
                {
                    this.MenuTypeId = int.Parse(Request["Id"]);
                    this.OP = "Edit";
                    this.BindData();
                    this.txtId.ReadOnly = true;
                }
                else
                {
                    this.MenuTypeId = -1;
                    this.OP = "Add";
                }
            }
        }
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToUpper())
            {
                case "SAVE":
                    this.Save();
                    break;
            }
        }
    }
}
