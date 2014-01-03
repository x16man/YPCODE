using System;
using System.Collections.Generic;
using ComponentArt.Web.UI;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_DutyManagement1 的摘要说明。
	/// </summary>
	public partial class SYS_DutyManagement : BasePage
    {
        #region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string DUTYCODENONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING,ConfigCommon.GetMessageValue("DutyCodeNonUnique"));
        private static readonly string DUTYNAMENONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("DutyNameNonUnique"));
        private static readonly string INSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("DutyInsertFailed"));
        private static readonly string INSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("DutyInsertSuccess"));
        private static readonly string UPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("DutyUpdateFailed"));
        private static readonly string UPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("DutyUpdateSuccess"));
        #pragma warning restore 169

        private IList<DutyInfo> dutyInfos = new List<DutyInfo>();
        #endregion

        #region Property
        /// <summary>
        /// 公司编号。
        /// </summary>
        public new string CompanyCode
        {
            get { return this.ViewState["CompanyCode"].ToString(); }
            set { this.ViewState["CompanyCode"] = value; }
        }
        /// <summary>
        /// 公司名称。
        /// </summary>
        public string CompanyName
        {
            get { return this.ViewState["CompanyName"].ToString(); }
            set { this.ViewState["CompanyName"] = value; }
        }
        /// <summary>
        /// 职务名称。
        /// </summary>
	    public string DutyName
	    {
            get { return this.ViewState["DutyName"].ToString(); }
            set { this.ViewState["DutyName"] = value;}
	    }
        /// <summary>
        /// 编辑模式。
        /// </summary>
        public string EditMode
        {
            get { return ViewState["EditMode"] == null ? string.Empty : ViewState["EditMode"].ToString(); }
            set { ViewState["EditMode"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// 创建TreeView。
        /// </summary>
        /// <param name="objs">职务集合。</param>
        private void CreateTree(ICollection<DutyInfo> objs)
        {
            this.tvDuty.Nodes.Clear();
            var rootNode = new TreeViewNode {ID = "-1", Value = "-1", Text = this.CompanyName, CssClass = "RootNode"};
            AddSubNode(objs, rootNode);
            this.tvDuty.Nodes.Add(rootNode);

            this.tvDuty.ExpandAll();
        }
        /// <summary>
        /// 递归增加子节点。
        /// </summary>
        /// <param name="objs">职务集合。</param>
        /// <param name="parentNode">父节点。</param>
        private static void AddSubNode(ICollection<DutyInfo> objs, TreeViewNode parentNode)
        {
            TreeViewNode subNode;
            if (objs.Count == 0)
            {
                subNode = new TreeViewNode
                              {
                                  ID = "noMenuItem",
                                  Value = "-1",
                                  Text = "该公司下尚无职务！",
                                  ImageUrl = "deletedFolder.gif"
                              };
                parentNode.Nodes.Add(subNode);
                return;
            }

            var subDutyInfos = ((ListBase<DutyInfo>)objs).FindAll(o => o.ParentDutyCode == parentNode.Value);
            foreach (var obj in subDutyInfos)
            {
                subNode = new TreeViewNode
                              {
                                  ID = obj.DutyCode,
                                  Value = obj.DutyCode,
                                  Text = string.Format("({0}){1}",obj.DutyCode,obj.DutyCnName),
                                  ToolTip = obj.Remark,
                              };

                if (obj.IsValid != "Y")
                    subNode.ImageUrl = "deletedFolder.gif";
                AddSubNode(objs, subNode);
                parentNode.Nodes.Add(subNode);
            }
        }
        /// <summary>
        /// 维护界面模式切换。
        /// </summary>
        /// <param name="editable"></param>
        private void SwitchMode(bool editable)
        {
            if (this.EditMode != null)
                this.txtDutyCode.Enabled = this.EditMode == "Edit" ? false : editable;
            else
                this.txtDutyCode.Enabled = editable;
            this.txtDutyCnName.Enabled = editable;
            this.txtDutyEnName.Enabled = editable;
            this.chkIsValid.Enabled = editable;
            this.txtRemark.Enabled = editable;
        }
        /// <summary>
        /// 职位编辑区域复位。
        /// </summary>
        private void Reset()
        {
            this.txtParentDutyCode.Text = string.Empty;
            this.txtDutyCode.Text = string.Empty;
            this.txtDutyCnName.Text = string.Empty;
            this.txtDutyEnName.Text = string.Empty;
            this.chkIsValid.Checked = true;
            this.txtRemark.Text = string.Empty;
        }
        /// <summary>
        /// 部门保存。
        /// </summary>
        private bool Save()
        {
            switch (this.EditMode)
            {
                case "Add":
                    try
                    {
                        var obj = new DutyInfo
                                      {
                                          DutyCo = this.CompanyCode,
                                          DutyCode = this.txtDutyCode.Text.Trim(),
                                          DutyCnName = this.txtDutyCnName.Text.Trim(),
                                          DutyEnName = this.txtDutyEnName.Text.Trim(),
                                          ParentDutyCode = this.txtParentDutyCode.Text.Trim(),
                                          IsValid = this.chkIsValid.Checked ? "Y" : "N",
                                          DutyLevel = short.Parse(this.txtDutyLevel.Text.Trim()),
                                          Remark = this.txtRemark.Text.Trim(),
                                      };

                        if (DataProvider.DutyProvider.IsExistDutyCode(this.txtDutyCode.Text, this.CompanyCode))
                        {
                            AddScript(DUTYCODENONUNIQUE_SCRIPT);
                            return false;
                        }
                        if (DataProvider.DutyProvider.IsExistDutyName( this.CompanyCode, this.txtDutyCnName.Text))
                        {
                            AddScript(DUTYNAMENONUNIQUE_SCRIPT);
                            return false;
                        }
                        if (DataProvider.DutyProvider.Insert(obj))
                        {
                            this.dutyInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DutyProvider.GetAllByCompanyCode(
                                                       this.CompanyCode)
                                                 : DataProvider.DutyProvider.GetAllAvalibleByCompanyCode(
                                                       this.CompanyCode);
                            this.CreateTree(this.dutyInfos);
                            return true;
                        }
                        AddScript(INSERTFAILED_SCRIPT);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        this.ClientScript.RegisterStartupScript(this.GetType(), "AddFail", string.Format("<script>alert('添加失败！\r\n{0}');</script>", ex.Message));
                        return false;
                    }
                case "Edit":
                    try
                    {
                        var obj = new DutyInfo
                                      {
                                          DutyCo = this.CompanyCode,
                                          DutyCode = this.txtDutyCode.Text.Trim(),
                                          DutyCnName = this.txtDutyCnName.Text.Trim(),
                                          DutyEnName = this.txtDutyEnName.Text.Trim(),
                                          ParentDutyCode = this.txtParentDutyCode.Text.Trim(),
                                          IsValid = this.chkIsValid.Checked ? "Y" : "N",
                                          DutyLevel = short.Parse(this.txtDutyLevel.Text.Trim()),
                                          Remark = this.txtRemark.Text.Trim(),
                                      };
                        if (obj.DutyCnName != this.DutyName)
                        {
                            if (DataProvider.DutyProvider.IsExistDutyName(this.CompanyCode,obj.DutyCnName))
                            {
                                AddScript(DUTYNAMENONUNIQUE_SCRIPT);
                                return false;
                            }
                        }
                        if (!DataProvider.DutyProvider.Update(obj))
                        {
                            AddScript(UPDATEFAILED_SCRIPT);
                            return false;
                        }
                        this.dutyInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DutyProvider.GetAllByCompanyCode(
                                                       this.CompanyCode)
                                                 : DataProvider.DutyProvider.GetAllAvalibleByCompanyCode(
                                                       this.CompanyCode);
                        this.CreateTree(this.dutyInfos);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        
                        this.ClientScript.RegisterStartupScript(this.GetType(), "EditFail", string.Format("<script>alert('更新失败！{0}');</script>", ex.Message));
                        return false;
                    }
                default:
                    this.ClientScript.RegisterStartupScript(this.GetType(), "NoEditMode", "<script>alert('没有指定编辑模式！');</script>");
                    return false;
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
            if (!IsPostBack)
            {
                this.txtDutyLevel.Text = "1";//职位级数初始化为1.
                var companyInfo = DataProvider.CompanyProvider.GetDefault();

                if (companyInfo != null)
                {
                    this.CompanyCode = companyInfo.CoCode;
                    this.CompanyName = companyInfo.CoName;
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "NoDefaultCompany", "<script>alert('系统中尚未设置默认公司信息！');</script>");
                    return;
                }
                //this.dutyDS = new OrganizeDA().GetAllAvalibleDutiesByCompany(this.CompanyCode);
                this.dutyInfos = DataProvider.DutyProvider.GetAllAvalibleByCompanyCode((this.CompanyCode));
                if (this.dutyInfos.Count > 0)
                {
                    this.CreateTree(this.dutyInfos);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "NoDepartment", "<script>alert('系统中尚未设置职务信息！');</script>");
                    return;
                }
                this.SwitchMode(false);
            }
		}
        /// <summary>
        /// TreeView的节点移动事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvDuty_NodeMoved(object sender, TreeViewNodeMovedEventArgs e)
        {
            var dutyCode = e.Node.Value;
            var parentDutyCode = e.Node.ParentNode.Value;

            //var da = new OrganizeDA();
            //var oDuty = new EntryDuty();
            //var oParentDuty = new EntryDuty();

            //da.GetDutyByDutyCode(oDuty, this.CompanyCode, dutyCode);
            //da.GetDutyByDutyCode(oParentDuty, this.CompanyCode, parentDutyCode);

            var oDuty = DataProvider.DutyProvider.GetByCompanyCodeAndDutyCode(this.CompanyCode, dutyCode);
            var oParentDuty = DataProvider.DutyProvider.GetByCompanyCodeAndDutyCode(this.CompanyCode, parentDutyCode);

            oDuty.ParentDutyCode = parentDutyCode;
            oDuty.DutyLevel = ++oParentDuty.DutyLevel;
            if (DataProvider.DutyProvider.Update(oDuty))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "MoveSuccessed", "<script>alert('转移成功！');</script>");
            }
            else
            {
                //转移失败，需要重新构造树。
                this.dutyInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DutyProvider.GetAllByCompanyCode(
                                                       this.CompanyCode)
                                                 : DataProvider.DutyProvider.GetAllAvalibleByCompanyCode(
                                                       this.CompanyCode);

                if (this.dutyInfos.Count> 0)
                {
                    this.CreateTree(this.dutyInfos);
                }
                else
                {
                    this.Response.Write("<script>alert('部门转移失败！');</script>");
                    return;
                }
            }
        }
        /// <summary>
        /// TreeView的节点选中事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvDuty_NodeSelected(object sender, TreeViewNodeEventArgs e)
        {
            this.SwitchMode(false);

            var dutyCode = e.Node.Value;
            this.DutyName = e.Node.Text;

            if (dutyCode != "0" || dutyCode != "-1")
            {
                this.tbiDelete.Visible = true;
                var obj = DataProvider.DutyProvider.GetByCompanyCodeAndDutyCode(this.CompanyCode, dutyCode);
                
                if (obj != null)
                {
                    this.txtDutyCode.Text = obj.DutyCode;
                    this.txtDutyCnName.Text = obj.DutyCnName;
                    this.txtDutyEnName.Text = obj.DutyEnName;
                    this.txtParentDutyCode.Text = obj.ParentDutyCode;
                    this.txtDutyLevel.Text = obj.DutyLevel.ToString();
                    this.chkIsValid.Checked = obj.IsValid == "Y" ? true : false;
                    this.txtRemark.Text = obj.Remark;
                }
            }
        }
        /// <summary>
        /// ToolBar的按钮事件。
        /// </summary>
        /// <param name="item"></param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId)
            {
                case "AddRoot":
                    this.EditMode = "Add";
                    this.SwitchMode(true);
                    this.Reset();
                    this.txtParentDutyCode.Text = "-1";
                    this.txtDutyLevel.Text = "1";
                    this.MzhToolbar1.Items["Save"].Visible = true;
                    this.MzhToolbar1.Items["Separator1"].Visible = true;
                    this.tbiDelete.Visible = false;
                    break;
                case "Add":
                    if (this.tvDuty.SelectedNode != null && this.tvDuty.SelectedNode.Value != "-1")
                    {
                        this.EditMode = "Add";
                        this.SwitchMode(true);
                        this.Reset();
                        this.txtParentDutyCode.Text = this.tvDuty.SelectedNode.Value;
                        this.txtDutyLevel.Text = (short.Parse(this.txtDutyLevel.Text) + 1).ToString();
                        this.MzhToolbar1.Items["Save"].Visible = true;
                        this.MzhToolbar1.Items["Separator1"].Visible = true;
                        this.tbiDelete.Visible = false;
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoParent", "<script>alert('请先选择上一级职位！');</script>");
                        this.SwitchMode(false);
                    }
                    break;
                case "Edit":
                    if (this.tvDuty.SelectedNode != null && this.tvDuty.SelectedNode.Value != "-1")
                    {
                        this.EditMode = "Edit";
                        this.SwitchMode(true);
                        this.MzhToolbar1.Items["Save"].Visible = true;
                        this.MzhToolbar1.Items["Separator1"].Visible = true;
                        this.tbiDelete.Visible = false;
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoSelectedNode", "<script>alert('请先选择职位项,然后再进行修改！');</script>");
                        this.SwitchMode(false);
                    }
                    break;
                case "Delete":
                    if (this.tvDuty.SelectedNode != null &&
                        this.tvDuty.SelectedNode.Value != "-1" &&
                        this.tvDuty.SelectedNode.Value != "0")
                    {
                        if (this.tvDuty.SelectedNode.Nodes.Count == 0)
                        {
                            if (DataProvider.DutyProvider.Delete(this.CompanyCode, this.tvDuty.SelectedNode.Value))
                            {
                                this.Reset();
                                this.dutyInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DutyProvider.GetAllByCompanyCode(
                                                       this.CompanyCode)
                                                 : DataProvider.DutyProvider.GetAllAvalibleByCompanyCode(
                                                       this.CompanyCode);
                                this.CreateTree(this.dutyInfos);
                            }
                            else
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteFail", "<script>alert('删除失败！');</script>");
                            }
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteFail", "<script>alert('该职位项包含下属职位，不允许删除！');</script>");
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoSelectedNodeDelete", "<script>alert('请先选择职位项,然后再进行删除！');</script>");
                        this.SwitchMode(false);
                    }
                    this.tbiDelete.Visible = false;
                    break;
                case "Save":
                    if (this.Save())
                    {
                        this.SwitchMode(false);
                        this.Reset();
                        this.MzhToolbar1.Items["Save"].Visible = false;
                        this.MzhToolbar1.Items["Separator1"].Visible = false;
                        this.tbiDelete.Visible = true;
                    }
                    break;
                case "IncludeDelete":
                    this.dutyInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DutyProvider.GetAllByCompanyCode(
                                                       this.CompanyCode)
                                                 : DataProvider.DutyProvider.GetAllAvalibleByCompanyCode(
                                                       this.CompanyCode);

                    if (this.dutyInfos.Count > 0)
                    {
                        this.CreateTree(this.dutyInfos);
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoDepartment", "<script>alert('系统中尚未设置职位信息！');</script>");
                        return;
                    }
                    break;
            }
        }
        #endregion
        
	}
}
