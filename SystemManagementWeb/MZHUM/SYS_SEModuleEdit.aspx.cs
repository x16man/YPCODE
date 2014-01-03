using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Web.UI.Controls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SEModuleEdit : BasePage
    {
        #region Field

        private static readonly string SEMODULE_INSERT_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEModuleInsertSuccess"));
        private static readonly string SEMODULE_INSERT_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEModuleInsertFailed"));
        private static readonly string SEMODULE_UPDATE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEModuleUpdateSuccess"));
        private static readonly string SEMODULE_UPDATE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEModuleUpdateFailed"));
        private static readonly string SEMODULE_ID_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEModuleIdNonUnique"));
        #endregion

        #region Property
        /// <summary>
        /// 产品编号。
        /// </summary>
        public short ProductCode
        {
            get { return short.Parse(this.ViewState["ProductCode"].ToString()); }
            set { this.ViewState["ProductCode"] = value;}
        }
        /// <summary>
        /// 查询模块ID。
        /// </summary>
        public string SEModuleId
        {
            get { return this.ViewState["SEModuleId"].ToString(); }
            set { this.ViewState["SEModuleId"] = value;}
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

        #region private method

        #endregion
        private void myDataBind()
        {
            var obj = DataProvider.SEModuleProvider.GetById(this.SEModuleId);
            if (obj != null)
            {
                this.txtId.Text = obj.Id;
                this.txtName.Text = obj.Name;
                this.txtSQL.Text = obj.SQL;
                this.txtWhere.Text = obj.Where;
                this.txtRemark.Text = obj.Remark;
            }
        }
        /// <summary>
        /// 保存操作。
        /// </summary>
        private void Save()
        {
            var obj = new SEModuleInfo()
            {
                Id = this.txtId.Text.Trim(),
                Name = this.txtName.Text.Trim(),
                ProductCode = this.ProductCode,
                SQL = this.txtSQL.Text.Trim(),
                Where = this.txtWhere.Text.Trim(),
                Remark = this.txtRemark.Text.Trim(),
                
            };

            if (this.OP == "Add")
            {
                if (DataProvider.SEModuleProvider.IsExist(obj.Id))
                {
                    AddScript(SEMODULE_ID_NONUNIQUE_SCRIPT);
                    return;
                }
                if (DataProvider.SEModuleProvider.Insert(obj))
                {
                    AddScript(SEMODULE_INSERT_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SEMODULE_INSERT_FAILED_SCRIPT);
                }
            }
            else
            {
                obj.OldId = this.SEModuleId;
                if (DataProvider.SEModuleProvider.Update(obj))
                {
                    AddScript(SEMODULE_UPDATE_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SEMODULE_UPDATE_FAILED_SCRIPT);
                }
            }
        }
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(!CurrentUser.HasRight(RightEnum.SEModule))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if(!string.IsNullOrEmpty(Request["ProductCode"]))
                {
                    this.ProductCode = short.Parse(Request["ProductCode"]);
                }
                if(!string.IsNullOrEmpty(Request["Id"]))
                {
                    this.SEModuleId = Request["Id"];
                    this.OP = OperationEnum.Edit;
                    this.myDataBind();
                }
                else
                {
                    this.OP = OperationEnum.Add;
                }
            }
        }

        protected void MzhToolbar1_ItemPostBack(ToolbarItem item)
        {
            switch(item.ItemId.ToUpper())
            {
                case "SAVE":
                    this.Save();
                    break;
            }
        }
        #endregion
    }
}
