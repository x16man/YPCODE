using System;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Web.UI.Controls;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SEControlTypeEdit : BasePage
    {
        #region Field
        private static readonly string SECONTROLTYPE_INSERT_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlTypeInsertSuccess"));
        private static readonly string SECONTROLTYPE_INSERT_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlTypeInsertFailed"));
        private static readonly string SECONTROLTYPE_UPDATE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlTypeUpdateSuccess"));
        private static readonly string SECONTROLTYPE_UPDATE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlTypeUpdateFailed"));
        private static readonly string SECONTROLTYPE_ID_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlTypeIdNonUnique"));
        private static readonly string SECONTROLTYPE_NAME_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlTypeNameNonUnique"));
        #endregion

        #region Property
        /// <summary>
        /// 查询模块ID。
        /// </summary>
        public int SEControlTypeId
        {
            get { return int.Parse(this.ViewState["SEControlTypeId"].ToString()); }
            set { this.ViewState["SEControlTypeId"] = value; }
        }
        public string SEControlTypeName
        {
            get { return this.ViewState["SEControlTypeName"].ToString(); }
            set { this.ViewState["SEControlTypeName"] = value; }
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
        private void myDataBind()
        {
            var obj = DataProvider.SEControlTypeProvider.GetById(this.SEControlTypeId);
            if (obj != null)
            {
                this.SEControlTypeName = obj.Name;
                this.txtId.Text = obj.Id.ToString();
                this.txtName.Text = obj.Name;
                this.txtRemark.Text = obj.Remark;
            }
        }
        /// <summary>
        /// 保存操作。
        /// </summary>
        private void Save()
        {
            var obj = new SEControlTypeInfo
            {
                Id = int.Parse(this.txtId.Text.Trim()),
                Name = this.txtName.Text.Trim(),
                Remark = this.txtRemark.Text.Trim(),
            };
            if (this.OP == "Add")
            {
                if (DataProvider.SEControlTypeProvider.IsExist(obj.Id))
                {
                    AddScript(SECONTROLTYPE_ID_NONUNIQUE_SCRIPT);
                    return;
                }
                if (DataProvider.SEControlTypeProvider.Insert(obj))
                {
                    AddScript(SECONTROLTYPE_INSERT_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SECONTROLTYPE_INSERT_FAILED_SCRIPT);
                }
            }
            else
            {
                obj.OldId = this.SEControlTypeId;
                if (this.SEControlTypeId != obj.Id)
                {
                    if (DataProvider.SEControlTypeProvider.IsExist(obj.Id))
                    {
                        AddScript(SECONTROLTYPE_ID_NONUNIQUE_SCRIPT);
                        return;
                    }
                }
                if (this.SEControlTypeName != obj.Name)
                {
                    if (DataProvider.SEControlTypeProvider.IsExist(obj.Name))
                    {
                        AddScript(SECONTROLTYPE_NAME_NONUNIQUE_SCRIPT);
                        return;
                    }
                }
                if (DataProvider.SEControlTypeProvider.Update(obj))
                {
                    AddScript(SECONTROLTYPE_UPDATE_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SECONTROLTYPE_UPDATE_FAILED_SCRIPT);
                }
            }
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.SEModule))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!string.IsNullOrEmpty(Request["ID"]))
                {
                    this.SEControlTypeId = int.Parse(Request["ID"]);
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
            switch (item.ItemId.ToUpper())
            {
                case "SAVE":
                    this.Save();
                    break;
            }
        }
        #endregion
    }
}
