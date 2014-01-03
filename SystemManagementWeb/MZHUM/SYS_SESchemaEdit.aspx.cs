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
    public partial class SYS_SESchemaEdit : BasePage
    {
        #region Field

        private static readonly string SESCHEMA_INSERT_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SESchemaInsertSuccess"));
        private static readonly string SESCHEMA_INSERT_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SESchemaInsertFailed"));
        private static readonly string SESCHEMA_UPDATE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SESchemaUpdateSuccess"));
        private static readonly string SESCHEMA_UPDATE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SESchemaUpdateFailed"));
        private static readonly string SESCHEMA_NAME_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SESchemaNameNonUnique"));
        #endregion

        #region Property
        /// <summary>
        /// 查询模块ID。
        /// </summary>
        public string SEModuleId
        {
            get { return this.ViewState["SEModuleId"].ToString(); }
            set { this.ViewState["SEModuleId"] = value;}
        }
        /// <summary>
        /// 查询方案Id。
        /// </summary>
        public int SchemaId
        {
            get { return (int) this.ViewState["SchemaId"]; }
            set { this.ViewState["SchemaId"] = value;}
        }
        /// <summary>
        /// 条件语句。
        /// </summary>
        public string WhereClause
        {
            get { return this.ViewState["WhereClause"].ToString(); }
            set { this.ViewState["WhereClause"] = value; }
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
            var obj = DataProvider.SESchemaProvider.GetById(this.SchemaId);
            if (obj != null)
            {
                this.txtSchemaName.Text = obj.SchemaName;
                this.txtRemark.Text = obj.Remark;
                this.chkIsDefault.Checked = obj.IsDefault;
                this.WhereClause = obj.WhereClause;
            }
        }
        /// <summary>
        /// 保存操作。
        /// </summary>
        private void Save()
        {
            var obj = new SESchemaInfo()
                          {
                              ModuleId = this.SEModuleId,
                              UserCode = this.CurrentUser.LoginName,
                              SchemaName = this.txtSchemaName.Text.Trim(),
                              WhereClause = this.WhereClause,
                              Remark = this.txtRemark.Text.Trim(),
                              CreateTime = DateTime.Now,
                              IsDefault = this.chkIsDefault.Checked,
                          };

            if (this.OP == "Add")
            {
                if (DataProvider.SESchemaProvider.IsExist(obj.ModuleId,obj.UserCode,obj.SchemaName))
                {
                    AddScript(SESCHEMA_NAME_NONUNIQUE_SCRIPT);
                    return;
                }
                var defaultObj = DataProvider.SESchemaProvider.GetDefaultByModuleAndUser(obj.ModuleId, CurrentUser.LoginName);
                if (defaultObj != null)
                {
                    defaultObj.IsDefault = false;
                    DataProvider.SESchemaProvider.Update(defaultObj);
                }
                if (DataProvider.SESchemaProvider.Insert(obj))
                {
                    AddScript(SESCHEMA_INSERT_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SESCHEMA_INSERT_FAILED_SCRIPT);
                }
            }
            else
            {
                if(obj.IsDefault)
                {
                    var defaultObj = DataProvider.SESchemaProvider.GetDefaultByModuleAndUser(obj.ModuleId, CurrentUser.LoginName);
                    if(defaultObj != null)
                    {
                        defaultObj.IsDefault = false;
                        DataProvider.SESchemaProvider.Update(defaultObj);
                    }
                }
                obj.Id = this.SchemaId;
                if (DataProvider.SESchemaProvider.Update(obj))
                {
                    AddScript(SESCHEMA_UPDATE_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SESCHEMA_UPDATE_FAILED_SCRIPT);
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
                this.SEModuleId = Request["ModuleId"];
                if(!string.IsNullOrEmpty(Request["Id"]))
                {
                    this.SchemaId = int.Parse(Request["Id"].ToUpper());
                    this.SEModuleId = Request["ModuleId"];
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
