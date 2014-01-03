using System;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_GroupEdit : BasePage
    {
        #region Field
        private static readonly string GROUPINSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupInsertSuccess"));
        private static readonly string GROUPINSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupInsertFailed"));
        private static readonly string GROUPUPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupUpdateSuccess"));
        private static readonly string GROUPUPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupUpdateFailed"));
        private static readonly string GROUPNAMENONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupNameNonUnique"));
        #endregion

        #region Property
        /// <summary>
        /// 组类别。
        /// </summary>
        public short GroupCatId
        {
            get { return short.Parse(this.Request["GroupCat"]); }
            set { this.ViewState["GroupCat"] = value;}
        }
        /// <summary>
        /// 组编号。
        /// </summary>
        public short GroupCode
        {
            get { return short.Parse(this.ViewState["GroupCode"].ToString()); }
            set { this.ViewState["GroupCode"] = value; }
        }
        /// <summary>
        /// 组名称。
        /// </summary>
        public string GroupName
        {
            get { return this.ViewState["GroupName"].ToString(); }
            set { this.ViewState["GroupName"] = value; }
        }
        /// <summary>
        /// 操作模式。
        /// </summary>
        public string OP
        {
            get { return ViewState["OP"].ToString(); }
            set { ViewState["OP"] = value;}
        }
        #endregion

        #region Method
        private void BindGroupCat()
        {
            var objs = DataProvider.GroupCatProvider.GetAll() as ListBase<GroupCatInfo>;
            if(objs != null)
            {
                objs.Sort("SerialNo");
                foreach (var obj in objs)
                {
                    this.ddlGroupCat.Items.Add(new ListItem(obj.Name, obj.Id.ToString()));
                }
            }
            
            this.ddlGroupCat.Items.Add(new ListItem("其他","0"));
        }
        /// <summary>
        /// 绑定数据到界面。
        /// </summary>
        private void BindData()
        {
            var groupInfo = DataProvider.GroupProvider.GetByCode(this.GroupCode);
            if(groupInfo != null)
            {
                this.GroupName = groupInfo.GroupName;
                this.txtName.Text = groupInfo.GroupName;
                this.txtRemark.Text = groupInfo.Remark;
                this.txtSerialNo.Text = groupInfo.SerialNo.ToString();
                this.ddlGroupCat.SelectedValue = groupInfo.GroupCatId.ToString();
            }
        }
        /// <summary>
        /// 保存操作。
        /// </summary>
        private void Save()
        {
            var groupInfo = new GroupInfo
                                {
                                    GroupCode = this.GroupCode,
                                    GroupName = this.txtName.Text.Trim(),
                                    Remark = this.txtRemark.Text.Trim(),
                                    SerialNo = string.IsNullOrEmpty(this.txtSerialNo.Text.Trim()) ? (short) 0 : short.Parse(this.txtSerialNo.Text.Trim()),
                                    GroupCatId = short.Parse(this.ddlGroupCat.SelectedValue),
                                };
            
            if(this.OP == "Add")
            {
                if(DataProvider.GroupProvider.IsExist(groupInfo.GroupName))
                {
                    AddScript(GROUPNAMENONUNIQUE_SCRIPT);
                    return;
                }
                if(DataProvider.GroupProvider.Insert(groupInfo))
                {
                    AddScript(GROUPINSERTSUCCESS_SCRIPT);
                    AddScript("refresh",REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(GROUPINSERTFAILED_SCRIPT);
                }
            }
            else
            {
                if (this.GroupName != groupInfo.GroupName)
                {
                    if (DataProvider.GroupProvider.IsExist(groupInfo.GroupName))
                    {
                        AddScript(GROUPNAMENONUNIQUE_SCRIPT);
                    }
                    else
                    {
                        if (DataProvider.GroupProvider.Update(groupInfo))
                        {
                            AddScript(GROUPUPDATESUCCESS_SCRIPT);
                            AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                        }
                        else
                        {
                            AddScript(GROUPUPDATEFAILED_SCRIPT);
                        }
                    }
                    
                }
                else
                {
                    if (DataProvider.GroupProvider.Update(groupInfo))
                    {
                        AddScript(GROUPUPDATESUCCESS_SCRIPT);
                        AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                    }
                    else
                    {
                        AddScript(GROUPUPDATEFAILED_SCRIPT);
                    }
                }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.BindGroupCat();
                if(!string.IsNullOrEmpty(this.Request["GroupCat"]))
                {
                    this.ddlGroupCat.SelectedValue = this.Request["GroupCat"];
                }
                if(!string.IsNullOrEmpty(Request["Code"]))
                {
                    this.GroupCode = short.Parse(Request["Code"]);
                    this.OP = "Edit";
                    this.BindData();
                }
                else
                {
                    this.GroupCode = -1;
                    this.OP = "Add";
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
