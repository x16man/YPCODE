using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_GroupCatEdit : BasePage
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string GROUPCATINSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupCatInsertSuccess"));
        private static readonly string GROUPCATINSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupCatInsertFailed"));
        private static readonly string GROUPCATUPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupCatUpdateSuccess"));
        private static readonly string GROUPCATUPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupCatUpdateFailed"));
        private static readonly string GROUPCATNAMENONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupCatNameNonUnique"));
        #endregion

        #region Property
        /// <summary>
        /// 组编号。
        /// </summary>
        public short GroupCatId
        {
            get { return short.Parse(this.ViewState["GroupCatId"].ToString()); }
            set { this.ViewState["GroupCatId"] = value; }
        }
        /// <summary>
        /// 组名称。
        /// </summary>
        public string GroupCatName
        {
            get { return this.ViewState["GroupCatName"].ToString(); }
            set { this.ViewState["GroupCatName"] = value; }
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
            var groupCatInfo = DataProvider.GroupCatProvider.GetById(this.GroupCatId);
            if (groupCatInfo != null)
            {
                this.GroupCatName = groupCatInfo.Name;
                this.txtName.Text = groupCatInfo.Name;
                this.txtRemark.Text = groupCatInfo.Remark;
                this.txtSerialNo.Text = groupCatInfo.SerialNo.ToString();

            }
        }
        /// <summary>
        /// 保存操作。
        /// </summary>
        private void Save()
        {
            var groupCatInfo = new GroupCatInfo
            {
                Id = this.GroupCatId,
                Name = this.txtName.Text.Trim(),
                Remark = this.txtRemark.Text.Trim(),
                SerialNo = string.IsNullOrEmpty(this.txtSerialNo.Text.Trim()) ? (short)0 : short.Parse(this.txtSerialNo.Text.Trim()),
            };

            if (this.OP == "Add")
            {
                if (DataProvider.GroupCatProvider.IsExist(groupCatInfo.Name))
                {
                    AddScript(GROUPCATNAMENONUNIQUE_SCRIPT);
                    return;
                }
                if (DataProvider.GroupCatProvider.Insert(groupCatInfo))
                {
                    AddScript(GROUPCATINSERTSUCCESS_SCRIPT);
                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                }
                else
                {
                    AddScript(GROUPCATINSERTFAILED_SCRIPT);
                }
            }
            else
            {
                if (this.GroupCatName != groupCatInfo.Name)
                {
                    if (DataProvider.GroupCatProvider.IsExist(groupCatInfo.Name))
                    {
                        AddScript(GROUPCATNAMENONUNIQUE_SCRIPT);
                    }
                    else
                    {
                        if (DataProvider.GroupCatProvider.Update(groupCatInfo))
                        {
                            Logger.Info(groupCatInfo.SerialNo);
                            AddScript(GROUPCATUPDATESUCCESS_SCRIPT);
                            AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                        }
                        else
                        {
                            AddScript(GROUPCATUPDATEFAILED_SCRIPT);
                        }
                    }
                }
                else
                {
                    if (DataProvider.GroupCatProvider.Update(groupCatInfo))
                    {
                        Logger.Info(groupCatInfo.SerialNo);
                        AddScript(GROUPCATUPDATESUCCESS_SCRIPT);
                        AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                    }
                    else
                    {
                        AddScript(GROUPCATUPDATEFAILED_SCRIPT);
                    }
                }
            }
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Id"]))
                {
                    this.GroupCatId = short.Parse(Request["Id"]);
                    this.OP = "Edit";
                    this.BindData();
                }
                else
                {
                    this.GroupCatId = -1;
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
        #endregion
    }
}
