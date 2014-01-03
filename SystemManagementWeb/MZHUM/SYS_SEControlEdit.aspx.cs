using System;
using System.Web.UI.WebControls;
using Shmzh.Web.UI.Controls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
namespace SystemManagement.MZHUM
{
    public partial class SYS_SEControlEdit : BasePage
    {
        #region Field

        private static readonly string SECONTROL_NOMODULEID_SCRIPT = string.Format(ALERT_FORMATSTRING,ConfigCommon.GetMessageValue("SEControlNoModuleId"));
        private static readonly string SECONTROL_INSERT_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlInsertSuccess"));
        private static readonly string SECONTROL_INSERT_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlInsertFailed"));
        private static readonly string SECONTROL_UPDATE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlUpdateSuccess"));
        private static readonly string SECONTROL_UPDATE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlUpdateFailed"));
        #endregion

        #region Property
        /// <summary>
        /// 查询模块Id。
        /// </summary>
        public string ModuleId
        {
            get { return this.ViewState["ModuleId"].ToString(); }
            set { this.ViewState["ModuleId"] = value;}
        }
        /// <summary>
        /// 控件id。
        /// </summary>
        public int ControlId
        {
            get { return int.Parse(this.ViewState["ControlId"].ToString()); }
            set { this.ViewState["ControlId"] = value; }
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
        /// 绑定控件类型数据。
        /// </summary>
        private void BindControlType()
        {
            this.ddlControlType.Items.Clear();
            var objs = DataProvider.SEControlTypeProvider.GetAll();
            foreach(var obj in objs)
            {
                this.ddlControlType.Items.Add(new ListItem(obj.Name,obj.Id.ToString()));
            }
        }
        /// <summary>
        /// 绑定数据类型数据。
        /// </summary>
        private void BindDataType()
        {
            this.ddlDataType.Items.Clear();
            var objs = DataProvider.SEDataTypeProvider.GetAll();
            foreach(var obj in objs)
            {
                this.ddlDataType.Items.Add(new ListItem(obj.Name,obj.Id.ToString()));
            }
        }
        /// <summary>
        /// 绑定数据到界面。
        /// </summary>
        private void myDataBind()
        {
            var obj = DataProvider.SEControlProvider.GetById(this.ControlId);
            if (obj != null)
            {
                this.txtLabelName.Text = obj.LabelName;
                this.ddlControlType.SelectedValue = obj.ControlTypeId.ToString();
                this.ddlDataType.SelectedValue = obj.DataTypeId.ToString();
                this.txtDataTextField.Text = obj.DataTextField;
                this.txtDataValueField.Text = obj.DataValueField;
                this.txtAssembly.Text = obj.Assembly;
                this.txtObjType.Text = obj.ObjType;
                this.txtMethod.Text = obj.Method;
                this.txtTableName.Text = obj.TableName;
                this.txtFieldName.Text = obj.FieldName;
                this.txtOperator.Text = obj.Operator;
                this.chkIsValid.Checked = obj.IsValid;
                this.txtSerialNo.Text = obj.SerialNo.ToString();
                this.txtRemark.Text = obj.Remark;
            }
        }
        /// <summary>
        /// 保存操作。
        /// </summary>
        private void Save()
        {
            var obj = new SEControlInfo
            {
                ModuleId = this.ModuleId,
                LabelName = this.txtLabelName.Text.Trim(),
                ControlTypeId = int.Parse(this.ddlControlType.SelectedValue),
                DataTypeId = int.Parse(this.ddlDataType.SelectedValue),
                DataTextField = this.txtDataTextField.Text,
                DataValueField = this.txtDataValueField.Text,
                Assembly = this.txtAssembly.Text,
                ObjType = this.txtObjType.Text,
                Method = this.txtMethod.Text,
                TableName = this.txtTableName.Text.Trim(),
                FieldName = this.txtFieldName.Text.Trim(),
                Operator = this.txtOperator.Text.Trim(),
                IsValid = this.chkIsValid.Checked,
                SerialNo = int.Parse(this.txtSerialNo.Text),
                Remark = this.txtRemark.Text.Trim(),
            };

            if (this.OP == "Add")
            {
                if (DataProvider.SEControlProvider.Insert(obj))
                {
                    AddScript(SECONTROL_INSERT_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SECONTROL_INSERT_FAILED_SCRIPT);
                }
            }
            else
            {
                obj.Id = this.ControlId;
                if (DataProvider.SEControlProvider.Update(obj))
                {
                    AddScript(SECONTROL_UPDATE_SUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(SECONTROL_UPDATE_FAILED_SCRIPT);
                }
                
            }
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(!string.IsNullOrEmpty(this.Request["ModuleId"]))
                {
                    this.ModuleId = this.Request["ModuleId"];
                    this.BindDataType();
                    this.BindControlType();
                    this.OP = OperationEnum.Add;
                    if (!string.IsNullOrEmpty(this.Request["Id"]))
                    {
                        this.ControlId = int.Parse(this.Request["Id"]);
                        this.OP = OperationEnum.Edit;
                        this.myDataBind();
                    }
                }
                else
                {
                    AddScript(SECONTROL_NOMODULEID_SCRIPT);
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
