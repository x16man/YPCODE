
namespace SystemManagement.MZHUM
{
    using System;
    using System.Collections.Generic;
    using ComponentArt.Web.UI;
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;
    using System.Data.SqlClient;

	/// <summary>
	/// SYS_DeptManagement 的摘要说明。
	/// </summary>
    public partial class SYS_DeptManagement : BasePage
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    /// <summary>
	    /// 部门新增失败的提示脚本。
	    /// </summary>
        private static readonly string INSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue("OrgInsertFailed"));
        /// <summary>
        /// 部门新增成功的提示脚本。
        /// </summary>

        private static readonly string INSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue("OrgInsertSuccess"));
        /// <summary>
        /// 部门更新失败的提示脚本。
        /// </summary>
        private static readonly string UPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue("OrgUpdateFailed"));
        /// <summary>
        /// 部门更新成功的提示脚本。
        /// </summary>

        private static readonly string UPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,

                                                                           ConfigCommon.GetMessageValue("OrgUpdateSuccess"));
        /// <summary>
        /// 部门删除失败的提示脚本。
        /// </summary>
        private static readonly string DELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
                                                                           ConfigCommon.GetMessageValue("OrgDeleteFailed"));
        /// <summary>
        /// 部门删除成功的提示脚本。
        /// </summary>

        private static readonly string DELETESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING,

                                                                           ConfigCommon.GetMessageValue("OrgDeleteSuccess"));
	    /// <summary>
	    /// 
	    /// </summary>

        private static readonly string NONUNIQUE_SCRIPT = string.Format(ALERT_FORMATSTRING,ConfigCommon.GetMessageValue("OrgCodeNonUnique"));
        private static readonly string NONUNIQUENAME_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("OrgNameNonUnique"));
#pragma warning restore 169
	    /// <summary>
	    /// 部门的数据集。
	    /// </summary>
	    private IList<DeptInfo> deptInfos = new List<DeptInfo>();

	    #endregion

        #region Property
        /// <summary>
        /// 公司编号。
        /// </summary>
        public string DefaultCompanyCode
        {
            get { return this.ViewState["DefaultCompanyCode"].ToString(); }
            set { this.ViewState["DefaultCompanyCode"] = value; }
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
        /// 部门名称。
        /// </summary>
	    public string DeptName
	    {
            get { return this.ViewState["DeptName"].ToString(); }
            set { this.ViewState["DeptName"] = value;}
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

        #region Private Method

        private bool DeptAdd(DeptInfo deptinfo)
        {
            if (this.isSynchronization())
            {
                var parentDeptInfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(deptinfo.DeptCo,deptinfo.ParentDept);
                TB_ORGTREEInfo parentOrgTree = null;
                if (parentDeptInfo != null)//非顶级部门。
                {
                    parentOrgTree = DataProvider.TB_OrgTreeProvider.GetByName(parentDeptInfo.DeptCnName);

                    if (parentOrgTree == null)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errror", "<script>alert('工作流系统中无此名称的上级部门！');</script>");
                        return false;
                    }
                }

                if (DataProvider.TB_OrgTreeProvider.IsExistName(deptinfo.DeptCnName))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "Errror", "<script>alert('工作流系统中已经有此部门！');</script>");
                    return false;
                }

                using (var conn = new SqlConnection(ConnectionString.PubData))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction("MyTrans");
                    try
                    {
                        var orgType = DataProvider.OrgTypeProvider.GetByCode(deptinfo.TypeId);
                        var orgTP = DataProvider.TB_SYSORGTPProvider.GetByTypeName(orgType.CnName);
                        if(orgTP == null) //组织机构类型不存在，则要添加。
                        {
                            orgTP = new TB_SYSORGTPInfo
                                        {
                                            TypeId = 0,
                                            
                                            ClassOrder = orgType.Level,
                                            TypeName = orgType.CnName,
                                            Enable = (orgType.IsValid == "Y" ? true : false)
                                        };
                            if(!DataProvider.TB_SYSORGTPProvider.Insert(orgTP,trans))
                            {
                                trans.Rollback();
                                Logger.Error("添加部门的时候，在工作流中同步增加新组织机构类型的时候，发生异常。");
                                return false;
                            }
                        }
                        
                        var orgtree = new TB_ORGTREEInfo
                                      {
                                          ParentID = parentOrgTree==null?0:parentOrgTree.ItemID,
                                          ItemName = deptinfo.DeptCnName,
                                          TypeID = orgTP.TypeId,
                                          Enable = (deptinfo.IsValid.ToLower() == "y")
                                      };

                        if (DataProvider.DeptProvider.Insert(deptinfo, trans) && DataProvider.TB_OrgTreeProvider.Insert(orgtree, trans))
                        {
                            if(!string.IsNullOrEmpty(deptinfo.DeptMgr))
                            {
                                var supervisor = DataProvider.TB_UsersProvider.GetByUserName(deptinfo.DeptMgr);
                                if(supervisor != null)
                                {
                                    var tbUsers = DataProvider.TB_UsersProvider.GetByOrgId(orgtree.ItemID);
                                    foreach(var tbuser in tbUsers)
                                    {
                                        tbuser.SpHRID = supervisor.HRID;
                                        if(DataProvider.TB_UsersProvider.Update(tbuser, trans)== false)
                                        {
                                            trans.Rollback();
                                            return false;
                                        }
                                    }
                                }
                                trans.Commit();
                                return true;
                            }
                            else
                            {
                                trans.Commit();
                                return true;
                            }
                        }
                        else
                        {
                            trans.Rollback();
                            return false;
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            else
            {
                return DataProvider.DeptProvider.Insert(deptinfo);
            }
        }

        private bool DeptUpdate(DeptInfo deptinfo)
        {
            if (this.isSynchronization() )
            {
                var oldDeptInfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(deptinfo.DeptCo, deptinfo.DeptCode);
                var parentDeptInfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(deptinfo.DeptCo, deptinfo.ParentDept);
                TB_ORGTREEInfo parentOrgTree = null;
                if(parentDeptInfo != null)
                {
                    parentOrgTree = DataProvider.TB_OrgTreeProvider.GetByName(parentDeptInfo.DeptCnName);

                    if (parentOrgTree == null)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "<script>alert('工作流系统中无此上级部门！');</script>");
                        return false;
                    }
                }
                var orgTree = DataProvider.TB_OrgTreeProvider.GetByName(oldDeptInfo.DeptCnName);
                if (orgTree == null)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "<script>alert('工作流系统中无此部门！');</script>");
                    return false;
                }

                using (var conn = new SqlConnection(ConnectionString.PubData))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction("MyTrans");
                    try
                    {
                        var orgType = DataProvider.OrgTypeProvider.GetByCode(deptinfo.TypeId);
                        var orgTP = DataProvider.TB_SYSORGTPProvider.GetByTypeName(orgType.CnName);
                        if (orgTP == null)//组织机构类型不存在，则要添加。
                        {
                            orgTP = new TB_SYSORGTPInfo
                            {
                                TypeId = 0,
                                ClassOrder = orgType.Level,
                                TypeName = orgType.CnName,
                                Enable = (orgType.IsValid == "Y" ? true : false)
                            };
                            if (!DataProvider.TB_SYSORGTPProvider.Insert(orgTP, trans))
                            {
                                trans.Rollback();
                                Logger.Error("修改部门的时候，在工作流中同步增加新组织机构类型的时候，发生异常。");
                                return false;
                            }
                        }

                        orgTree.ItemName = deptinfo.DeptCnName;
                        orgTree.TypeID = orgTP.TypeId;
                        orgTree.Enable = (deptinfo.IsValid.ToLower() == "y");
                        orgTree.ParentID = parentDeptInfo != null ? parentOrgTree.ItemID : 0;

                        if(DataProvider.DeptProvider.Update(deptinfo, trans) && DataProvider.TB_OrgTreeProvider.Update(orgTree, trans))
                        {
                            if (!string.IsNullOrEmpty(deptinfo.DeptMgr))
                            {
                                var supervisor = DataProvider.TB_UsersProvider.GetByUserName(deptinfo.DeptMgr);
                                if (supervisor != null)
                                {
                                    var tbUsers = DataProvider.TB_UsersProvider.GetByOrgId(orgTree.ItemID);
                                    foreach (var tbuser in tbUsers)
                                    {
                                        tbuser.SpHRID = supervisor.HRID;
                                        if (DataProvider.TB_UsersProvider.Update(tbuser, trans) == false)
                                        {
                                            trans.Rollback();
                                            return false;
                                        }
                                    }
                                }
                                trans.Commit();
                                return true;
                            }
                            else
                            {
                                trans.Commit();
                                return true;
                            }
                        }
                        else
                        {
                            trans.Rollback();
                            return false;
                        }
                    }
                    catch(Exception ex)
                    {
                        Logger.Error(ex.Message);
                        trans.Rollback();
                        return false;
                    }
                }
            }
            else
            {
                return DataProvider.DeptProvider.Update(deptinfo);
            }
        }

        private bool DeptDelete(string deptCode)
        {
            if (this.isSynchronization())
            {
                var deptinfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(this.DefaultCompanyCode, deptCode);
                var orgTree = DataProvider.TB_OrgTreeProvider.GetByName(deptinfo.DeptCnName);

                if(orgTree != null)//判断工作流中是否存在该名称的部门。
                {
                    if (DataProvider.TB_OrgTreeProvider.HasChildDept(deptinfo.DeptCnName))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "alert('工作流系统中，此部门下存在下属部门，不允许删除！');",true);
                        return false;
                    }
                    else if (DataProvider.TB_OrgTreeProvider.HasUser(deptinfo.DeptCnName))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "alert('工作流系统中，此部门下存在人员，不允许删除！');",true);
                        return false;
                    }
                    else if(DataProvider.TB_OrgTreeProvider.HasLeader(deptinfo.DeptCnName))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "alert('工作流系统中，此部门下存在领导，不允许删除！');", true);
                        return false;
                    }
                    else if(DataProvider.DeptProvider.HasChildDept(deptinfo.DeptCo,deptinfo.DeptCode))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "alert('此部门下存在子部门，不允许删除！');", true);
                        return false;
                    }
                    else if(DataProvider.DeptProvider.HasUser(deptinfo.DeptCo, deptinfo.DeptCode))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "alert('此部门下存在人员，不允许删除！');", true);
                        return false;
                    }

                    using (var conn = new SqlConnection(ConnectionString.PubData))
                    {
                        conn.Open();
                        var trans = conn.BeginTransaction("MyTrans");
                        if(DataProvider.DeptProvider.Disable(this.DefaultCompanyCode, deptCode, trans) &&
                            DataProvider.TB_OrgTreeProvider.Disable(orgTree.ItemID, trans))
                        {
                            trans.Commit();
                            return true;
                        }
                        else
                        {
                            trans.Rollback();
                            return false;
                        }
                    }
                }
                else//判断工作流中是否存在该名称的部门,不存在该名称的部门。
                {
                    if (DataProvider.DeptProvider.HasChildDept(deptinfo.DeptCo, deptinfo.DeptCode))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "alert('此部门下存在子部门，不允许删除！');", true);
                        return false;
                    }
                    else if (DataProvider.DeptProvider.HasUser(deptinfo.DeptCo, deptinfo.DeptCode))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "alert('此部门下存在人员，不允许删除！');", true);
                        return false;
                    }
                    return DataProvider.DeptProvider.Disable(this.DefaultCompanyCode, deptCode);
                }
                
            }
            else//不同步工作流。
            {
                return DataProvider.DeptProvider.Disable(this.DefaultCompanyCode, deptCode);
            }
        }

        /// <summary>
        /// 创建TreeView。
        /// </summary>
        /// <param name="objs">数据表。</param>
        private void CreateTree(IList<DeptInfo> objs)
        {
            this.tvDept.Nodes.Clear();
            var subDepts = ((ListBase<DeptInfo>)objs ).FindAll(obj => obj.ParentDept == "-1");
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
            TreeViewNode rootNode;
            foreach (var obj in subDepts)
            {
                rootNode = new TreeViewNode
                               {
                                   ID = obj.DeptCode,
                                   Value = obj.DeptCode,
                                   Text = obj.DeptCnName,
                                   ToolTip = obj.Remark,
                                   CssClass = "RootNode"
                               };

                if (obj.IsValid != "Y")
                    rootNode.ImageUrl = "deletedFolder.gif";

                this.AddSubNode(this.deptInfos, rootNode);
                this.tvDept.Nodes.Add(rootNode);
            }            
            this.tvDept.ExpandAll();
        }
        /// <summary>
        /// 递归增加子节点。
        /// </summary>
        /// <param name="objs">数据表。</param>
        /// <param name="parentNode">父节点。</param>
        private void AddSubNode(ICollection<DeptInfo> objs, TreeViewNode parentNode)
        {
            TreeViewNode subNode;
            if (objs.Count == 0)
            {
                subNode = new TreeViewNode
                              {
                                  ID = "noMenuItem",
                                  Value = "-1",
                                  Text = "该公司下尚无部门项！",
                                  ImageUrl = "deletedFolder.gif"
                              };
                parentNode.Nodes.Add(subNode);
                return;
            }
            var subDepts = ((List<DeptInfo>)objs).FindAll(obj => obj.ParentDept == parentNode.ID);
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
            foreach (var obj in subDepts)
            {
                subNode = new TreeViewNode
                              {
                                  ID = obj.DeptCode,
                                  Value = obj.DeptCode,
                                  Text = obj.DeptCnName,
                                  ToolTip = obj.Remark
                              };

                if(obj.IsValid != "Y")
                    subNode.ImageUrl = "deletedFolder.gif";
                AddSubNode(this.deptInfos, subNode);
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
                this.txtDeptCode.Enabled = this.EditMode == "Edit" ? false : editable;
            else
                this.txtDeptCode.Enabled = editable;
            if (editable)
                this.btnUserChooser.Attributes.Add("onclick", "ShowUserList(this.id);");
            else
                this.btnUserChooser.Attributes.Remove("onclick");
            this.txtDeptCnName.Enabled = editable;
            this.txtDeptEnName.Enabled = editable;
            this.txtDeptMgrName.Enabled = editable;
            this.txtDeptMgrName.Attributes["readonly"] = "readonly";
            this.txtSerial.Enabled = editable;
            this.ddlType.Enabled = editable;
            this.txtCostCenter.Enabled = editable;
            this.chkIsValid.Enabled = editable;
            this.chkShowInOtherSys.Enabled = editable;
            this.txtRemark.Enabled = editable;
        }
        /// <summary>
        /// 部门编辑区域复位。
        /// </summary>
        private void Reset()
        {
            this.txtParentDept.Text = string.Empty;
            this.txtParentDeptName.Text = string.Empty;
            this.txtDeptCode.Text = string.Empty;
            this.txtDeptCnName.Text = string.Empty;
            this.txtDeptEnName.Text = string.Empty;
            this.txtDeptMgr.Text = string.Empty;
            this.txtDeptMgrName.Text = string.Empty;
            this.txtSerial.Text = string.Empty;
            this.txtCostCenter.Text = string.Empty;
            this.ddlType.SelectedIndex = 0;
            
            this.chkIsValid.Checked = true;
            this.chkShowInOtherSys.Checked = false;
            this.txtRemark.Text = string.Empty;
        }
        /// <summary>
        /// 组织机构类型数据绑定。
        /// </summary>
        private void BindOrgType()
        {
            this.ddlType.Items.Clear();
            var objs = DataProvider.OrgTypeProvider.GetAllAvalible();
            this.ddlType.DataSource = objs;
            this.ddlType.DataTextField = "CnName";
            this.ddlType.DataValueField = "Code";
            this.ddlType.DataBind();
        }
        /// <summary>
        /// 部门保存。
        /// </summary>
        private bool Save()
        {
            switch (this.EditMode)
            {
                case "Add":
                    if (DataProvider.DeptProvider.IsExistDeptCode(this.DefaultCompanyCode, this.txtDeptCode.Text.Trim()))
                    {
                        AddScript(NONUNIQUE_SCRIPT);
                        return false;
                    }
                    if (DataProvider.DeptProvider.IsExistDeptName(this.DefaultCompanyCode, this.txtDeptCnName.Text.Trim()))
                    {
                        AddScript(NONUNIQUENAME_SCRIPT);
                        
                        return false;
                    }
                    try
                    {
                        var oDept = new DeptInfo
                                        {
                                            DeptCode = this.txtDeptCode.Text.Trim(),
                                            DeptCnName = this.txtDeptCnName.Text.Trim(),
                                            DeptEnName = this.txtDeptEnName.Text.Trim(),
                                            CostCenter = this.txtCostCenter.Text.Trim(),
                                            CreateDate = DateTime.Now,
                                            DeptCo = this.DefaultCompanyCode,
                                            DeptLevel = short.Parse(this.txtDeptLevel.Text.Trim()),
                                            DeptMgr = this.txtDeptMgr.Text.Trim(),
                                            DeptMgrName = this.txtDeptMgrName.Text.Trim(),
                                            IsValid = this.chkIsValid.Checked?"Y":"N",
                                            ParentDept = this.txtParentDept.Text.Trim(),
                                            ParentDeptName = this.txtParentDeptName.Text.Trim(),
                                            Remark = this.txtRemark.Text.Trim(),
                                            Serial = string.IsNullOrEmpty(this.txtSerial.Text.Trim())?(short)1:short.Parse(this.txtSerial.Text.Trim()),
                                            ShowInOtherSys = this.chkShowInOtherSys.Checked?1:0,
                                            TypeId = this.ddlType.SelectedValue,
                                            TypeName = this.ddlType.SelectedItem.Text.Trim(),
                                        };

                        if (DeptAdd(oDept))
                        {
                            this.deptInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DeptProvider.GetAllByCompanyCode(
                                                       this.DefaultCompanyCode)
                                                 : DataProvider.DeptProvider.GetAllAvalibleCompanyCode(
                                                       this.DefaultCompanyCode);
                            this.CreateTree(this.deptInfos);
                            return true;
                        }
                        AddScript(INSERTFAILED_SCRIPT);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        return false;
                    }
                case "Edit":
                    if (this.txtDeptCnName.Text.Trim() != this.DeptName)
                    {
                        if (DataProvider.DeptProvider.IsExistDeptName(this.DefaultCompanyCode, this.txtDeptCnName.Text.Trim()))
                        {
                            AddScript(NONUNIQUENAME_SCRIPT);
                            return false;
                        }
                    }
                    try
                    {
                        var oDept = new DeptInfo
                                        {
                                            DeptCode = this.txtDeptCode.Text.Trim(),
                                            DeptCnName = this.txtDeptCnName.Text.Trim(),
                                            DeptEnName = this.txtDeptEnName.Text.Trim(),
                                            CostCenter = this.txtCostCenter.Text.Trim(),
                                            CreateDate = DateTime.Now,
                                            DeptCo = this.DefaultCompanyCode,
                                            DeptLevel = short.Parse(this.txtDeptLevel.Text.Trim()),
                                            DeptMgr = this.txtDeptMgr.Text.Trim(),
                                            DeptMgrName = this.txtDeptMgrName.Text.Trim(),
                                            IsValid = this.chkIsValid.Checked?"Y":"N",
                                            ParentDept = this.txtParentDept.Text.Trim(),
                                            ParentDeptName = this.txtParentDeptName.Text.Trim(),
                                            Remark = this.txtRemark.Text.Trim(),
                                            Serial = short.Parse(this.txtSerial.Text.Trim()),
                                            ShowInOtherSys = this.chkShowInOtherSys.Checked?1:0,
                                            TypeId = this.ddlType.SelectedValue,
                                            TypeName = this.ddlType.SelectedItem.Text.Trim(),
                                        };

                        
                        if (DeptUpdate(oDept) == false)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "MultiObject", "<script>alert('部门修改失败！');</script>");
                            return false;
                        }
                        this.deptInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DeptProvider.GetAllByCompanyCode(
                                                       this.DefaultCompanyCode)
                                                 : DataProvider.DeptProvider.GetAllAvalibleCompanyCode(
                                                       this.DefaultCompanyCode);
                        this.CreateTree(this.deptInfos);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        AddScript(UPDATEFAILED_SCRIPT);
                        Logger.Error(ex.Message);
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
        /// 页面的加载事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                this.SwitchMode(false);
                this.BindOrgType();
                this.txtDeptLevel.Text = "1";//部门级数初始化为1.
                this.txtDeptMgrName.Attributes["readonly"] = "readonly";
                var companyInfo = DataProvider.CompanyProvider.GetDefault();
                if (companyInfo != null)
                {
                    this.DefaultCompanyCode = companyInfo.CoCode;
                    this.CompanyName = companyInfo.CoName;
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "NoDefaultCompany", "<script>alert('系统中尚未设置默认公司信息！');</script>");
                    return;
                }
                this.deptInfos = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(this.DefaultCompanyCode);
                if (this.deptInfos.Count > 0)
                {
                    this.CreateTree(this.deptInfos);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "NoDepartment", "<script>alert('系统中尚未设置部门信息！');</script>");
                    return;
                }
            }
		}
        /// <summary>
        /// TreeView的节点移动事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvDept_NodeMoved(object sender, TreeViewNodeMovedEventArgs e)
        {
            var deptCode = e.Node.Value;
            var parentDeptCode = e.Node.ParentNode.Value;
            var parentDeptName = e.Node.ParentNode.Text;

            var oDept = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(this.DefaultCompanyCode, deptCode);
            oDept.ParentDept = parentDeptCode;
            oDept.ParentDeptName = parentDeptName;


            if (DeptUpdate(oDept))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "MoveSuccessed", "<script>alert('转移成功！');</script>");
            }
            else
            {
                //转移失败，需要重新构造树。
                this.deptInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DeptProvider.GetAllByCompanyCode(
                                                       this.DefaultCompanyCode)
                                                 : DataProvider.DeptProvider.GetAllAvalibleCompanyCode(
                                                       this.DefaultCompanyCode);
                if (this.deptInfos.Count > 0)
                {
                    this.CreateTree(this.deptInfos);
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
        protected void tvDept_NodeSelected(object sender, TreeViewNodeEventArgs e)
        {
            this.SwitchMode(false);

            var deptCode = e.Node.Value;
            if (deptCode != "0" || deptCode != "-1")
            {
                var obj = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(this.DefaultCompanyCode, deptCode);
                if (obj != null)
                {
                    this.txtDeptCode.Text = obj.DeptCode;
                    this.txtDeptCnName.Text = obj.DeptCnName;
                    this.DeptName = this.txtDeptCnName.Text;
                    this.txtDeptEnName.Text = obj.DeptEnName;
                    this.txtParentDept.Text = obj.ParentDept;
                    this.txtParentDeptName.Text = obj.ParentDeptName;
                    this.txtDeptMgr.Text = obj.DeptMgr;
                    this.txtDeptMgrName.Text = obj.DeptMgrName;
                    this.txtSerial.Text = obj.Serial.ToString();
                    this.txtCostCenter.Text = obj.CostCenter;
                    this.txtRemark.Text = obj.Remark;
                    this.txtDeptLevel.Text = obj.DeptLevel.ToString();
                    try
                    {
                        this.ddlType.SelectedValue = obj.TypeId;
                    }
                    catch 
                    {
                        var oItem = new System.Web.UI.WebControls.ListItem(obj.TypeName,obj.TypeId);
                        this.ddlType.Items.Add(oItem);
                        this.ddlType.SelectedValue = obj.TypeId;
                    }
                    this.chkIsValid.Checked = obj.IsValid=="Y"?true:false;
                    this.chkShowInOtherSys.Checked = obj.ShowInOtherSys == 0 ? false : true;
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
                    this.txtParentDept.Text = "-1";
                    this.txtParentDeptName.Text = string.Empty;
                    this.txtDeptLevel.Text = "1";
                    this.MzhToolbar1.Items["Save"].Visible = true;
                    this.MzhToolbar1.Items["Separator1"].Visible = true;
                    break;
                case "Add":
                    if (this.tvDept.SelectedNode != null && this.tvDept.SelectedNode.Value != "-1")
                    {
                        this.EditMode = "Add";
                        this.SwitchMode(true);
                        this.Reset();
                        this.txtParentDept.Text = this.tvDept.SelectedNode.Value;
                        this.txtParentDeptName.Text = this.tvDept.SelectedNode.Text;
                        this.txtDeptLevel.Text = (short.Parse(this.txtDeptLevel.Text) + 1).ToString();
                        this.MzhToolbar1.Items["Save"].Visible = true;
                        this.MzhToolbar1.Items["Separator1"].Visible = true;
                    }
                    else 
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoParent", "<script>alert('请先选择上一级部门！');</script>");
                        this.SwitchMode(false);
                    }
                    break;
                case "Edit":
                    if (this.tvDept.SelectedNode != null && this.tvDept.SelectedNode.Value != "-1")
                    {
                        this.EditMode = "Edit";
                        this.SwitchMode(true);
                        this.MzhToolbar1.Items["Save"].Visible = true;
                        this.MzhToolbar1.Items["Separator1"].Visible = true;
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoSelectedNode", "<script>alert('请先选择菜单项,然后再进行修改！');</script>");
                        this.SwitchMode(false);
                    }
                    break;
                case "Delete":
                    if (this.tvDept.SelectedNode != null && 
                        this.tvDept.SelectedNode.Value != "-1" &&
                        this.tvDept.SelectedNode.Value != "0")
                    {
                        //if (this.tvDept.SelectedNode.Nodes.Count == 0)
                        //{
                            if (DeptDelete(this.tvDept.SelectedNode.Value))
                            {
                                this.Reset();
                                this.deptInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DeptProvider.GetAllByCompanyCode(
                                                       this.DefaultCompanyCode)
                                                 : DataProvider.DeptProvider.GetAllAvalibleCompanyCode(
                                                       this.DefaultCompanyCode);
                                this.CreateTree(this.deptInfos);
                            }
                            else
                            {
                                AddScript(DELETEFAILED_SCRIPT);
                            }
                        //}
                        //else
                        //{
                        //    AddScript("<script>alert('该菜单项包含子菜单，不允许删除！');</script>");
                        //}
                    }
                    else
                    {
                        AddScript( "<script>alert('请先选择菜单项,然后再进行删除！');</script>");
                        this.SwitchMode(false);
                    }
                    break;
                case "Save":
                    if (this.Save())
                    {
                        this.SwitchMode(false);
                        this.btnUserChooser.Attributes.Remove("onclick");
                        this.MzhToolbar1.Items["Save"].Visible = false;
                        this.MzhToolbar1.Items["Separator1"].Visible = false;
                    }
                    break;
                case "IncludeDelete":
                    this.deptInfos = this.tbiIncludeDelete.Checked
                                                 ? DataProvider.DeptProvider.GetAllByCompanyCode(
                                                       this.DefaultCompanyCode)
                                                 : DataProvider.DeptProvider.GetAllAvalibleCompanyCode(
                                                       this.DefaultCompanyCode);

                    if (this.deptInfos.Count > 0)
                    {
                        this.CreateTree(this.deptInfos);
                    }
                    else
                    {
                        AddScript( "<script>alert('系统中尚未设置部门信息！');</script>");
                        return;
                    }
                    break;
            }
        }
        
        #endregion
    }
}
