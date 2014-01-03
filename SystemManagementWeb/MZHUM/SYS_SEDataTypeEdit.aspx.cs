using System;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Web.UI.Controls;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SEDataTypeEdit : BasePage
    {
        #region Field
        private static readonly string SEDATATYPE_INSERT_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEDataTypeInsertSuccess"));
        private static readonly string SEDATATYPE_INSERT_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEDataTypeInsertFailed"));
        private static readonly string SEDATATYPE_UPDATE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEDataTypeUpdateSuccess"));
        private static readonly string SEDATATYPE_UPDATE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEDataTypeUpdateFailed"));
        private static readonly string SEDATATYPE_ID_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEDataTypeIdNonUnique"));
        private static readonly string SEDATATYPE_NAME_NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEDataTypeNameNonUnique"));
        #endregion

        #region Property
        /// <summary>
        /// 查询模块ID。
        /// </summary>
        public int SEDataTypeId
        {
            get { return int.Parse(this.ViewState["SEDataTypeId"].ToString()); }
            set { this.ViewState["SEDataTypeId"] = value; }
        }
        public string SEDataTypeName
        {
            get { return this.ViewState["SEDataTypeName"].ToString(); }
            set { this.ViewState["SEDataTypeName"] = value;}
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
            var obj = DataProvider.SEDataTypeProvider.GetById(this.SEDataTypeId);
            if (obj != null)
            {
                this.SEDataTypeName = obj.Name;
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
            var obj = new SEDataTypeInfo
                          {
                              Id = int.Parse(this.txtId.Text.Trim()),
                              Name = this.txtName.Text.Trim(),
                              Remark = this.txtRemark.Text.Trim(),
                          };
            if (this.OP == "Add")
            {
                if (DataProvider.SEDataTypeProvider.IsExist(obj.Id))
                {
                    AddScript(SEDATATYPE_ID_NONUNIQUE_SCRIPT);
                    return;
                }
                if (DataProvider.SEDataTypeProvider.Insert(obj))
                {
                    AddScript(SEDATATYPE_INSERT_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SEDATATYPE_INSERT_FAILED_SCRIPT);
                }
            }
            else
            {
                obj.OldId = this.SEDataTypeId;
                if(this.SEDataTypeId != obj.Id)
                {
                    if(DataProvider.SEDataTypeProvider.IsExist(obj.Id))
                    {
                        AddScript(SEDATATYPE_ID_NONUNIQUE_SCRIPT);
                        return;
                    }
                }
                if(this.SEDataTypeName != obj.Name)
                {
                    if(DataProvider.SEDataTypeProvider.IsExist(obj.Name))
                    {
                        AddScript(SEDATATYPE_NAME_NONUNIQUE_SCRIPT);
                        return;
                    }
                }
                if (DataProvider.SEDataTypeProvider.Update(obj))
                {
                    AddScript(SEDATATYPE_UPDATE_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SEDATATYPE_UPDATE_FAILED_SCRIPT);
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
                    this.SEDataTypeId = int.Parse(Request["ID"]);
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
