using System;
using System.Data;
using System.Web.UI.WebControls;
using ComponentArt.Web.UI;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_Menu : BasePage
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
        /// <summary>
        /// 菜单的数据集。
        /// </summary>
        DataSet menuDS;
        #endregion

        #region Property
        /// <summary>
        /// 编辑模式。
        /// </summary>
        public string EditMode
        {
            get
            {
                return ViewState["EditMode"] == null ? string.Empty : ViewState["EditMode"].ToString();
            }
            set { ViewState["EditMode"] = value; }
        }
        /// <summary>
        /// 产品Id。
        /// </summary>
        public short ProductId
        {
            get { return short.Parse(this.ViewState["ProductId"].ToString());}
            set { this.ViewState["ProductId"] = value; }
        }
        /// <summary>
        /// 产品名称。
        /// </summary>
        public string ProductName
        {
            get { return this.ViewState["ProductName"].ToString(); }
            set { this.ViewState["ProductName"] = value; }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定菜单类型的下拉列表。
        /// </summary>
        private void BindMenuType()
        {
            this.ddlType.Items.Clear();
            var objs = DataProvider.MenuTypeProvider.GetAll();
            foreach(var obj in objs)
            {
                this.ddlType.Items.Add(new ListItem(obj.Name,obj.ID.ToString()));
            }
        }

        /// <summary>
        /// 创建TreeView。
        /// </summary>
        /// <param name="dt">数据表。</param>
        private void CreateTree(DataTable dt)
        {
            this.tvMenu.Nodes.Clear();
            var rootNode = new TreeViewNode {ID = "0", Value = "0", Text = this.ProductName, CssClass = "RootNode"};
            AddSubNode(dt, rootNode);
            this.tvMenu.Nodes.Add(rootNode);
            rootNode.Expanded = true;
            //string filterExpr = "fParentId = 0";//一级菜单的过滤条件。
            //System.Data.DataRow[] drs = new System.Data.DataRow[dt.Select(filterExpr).Length];
            //drs = dt.Select(filterExpr);
            //TreeViewNode oNode;
            //foreach (DataRow oRow in drs)
            //{
            //    oNode = new TreeViewNode();
            //    oNode.ID = oRow["fID"].ToString();
            //    oNode.Value = oRow["fID"].ToString();
            //    oNode.Text = oRow["fName"].ToString();
            //    this.AddSubNode(dt, oNode);
            //    rootNode.Nodes.Add(oNode);
            //}
        }
        /// <summary>
        /// 递归增加子节点。
        /// </summary>
        /// <param name="dt">数据表。</param>
        /// <param name="tn">父节点。</param>
        private static void AddSubNode(DataTable dt, TreeViewNode tn)
        {
            TreeViewNode subNode;

            //Logger.Info(dt.Rows.Count.ToString());
            
            if (dt.Rows.Count == 0)
            {
                subNode = new TreeViewNode {ID = "noMenuItem", Value = "-1", Text = "该产品下尚无菜单项！"};
                tn.Nodes.Add(subNode);
                return;
            }
            //string oldFilter = dt.DefaultView.RowFilter;
            var FilterExpr = "fParentId = " + tn.ID + "";
            //以下代码块在只安装了FrameWork2.0的机器上有问题。
            var SortExpr = "fOrder asc";
            using (var dv = new DataView(dt, FilterExpr, SortExpr, DataViewRowState.CurrentRows))
            {
                foreach (DataRowView oRow in dv)
                {
                    subNode = new TreeViewNode
                                  {
                                      ID = oRow["fID"].ToString(),
                                      Value = oRow["fID"].ToString(),
                                      Text = oRow["fName"].ToString(),
                                      ToolTip = string.Format("ID:{0}\r\nRightCode:{1}<br>URL:{2}",oRow["fID"],oRow["fRightCode"],oRow["fURL"]),
                                  };
                    if (oRow["fIsEnable"].ToString() != "1")
                        subNode.ImageUrl = "deletedFolder.gif";
                    AddSubNode(dt, subNode);
                    tn.Nodes.Add(subNode);
                }
            }
            //for (int i = 0; i < dt.DefaultView.Count; i++)
            //{
            //    subNode = new TreeViewNode();
            //    subNode.ID = dt.DefaultView[i]["fID"].ToString();
            //    subNode.Value = dt.DefaultView[i]["fID"].ToString();
            //    subNode.Text = dt.DefaultView[i]["fName"].ToString();
            //    AddSubNode(dt, subNode);
            //    tn.Nodes.Add(subNode);
            //}
            
            //System.Data.DataRow[] drs = new System.Data.DataRow[dt.Select(FilterExpr).Length];
            //drs = dt.Select(FilterExpr);
            //foreach (DataRow oRow in drs)
            //{
            //    subNode = new TreeViewNode();
            //    subNode.ID = oRow["fID"].ToString();
            //    subNode.Value = oRow["fID"].ToString();
            //    subNode.Text = oRow["fName"].ToString();
            //    AddSubNode(dt, subNode);
            //    tn.Nodes.Add(subNode);
            //}

        }
        /// <summary>
        /// 保存菜单项。
        /// </summary>
        private bool Save()
        {
            var obj = new MenuInfo
                          {
                              ID = (this.txtId.Text.Trim().Length == 0 ? 0 : int.Parse(this.txtId.Text.Trim())),
                              Name = this.txtName.Text.Trim(),
                              Title = this.txtTitle.Text.Trim(),
                              ProductID = this.ProductId,
                              RightCode = int.Parse(this.txtRightCode.Text.Trim()),
                              ParentID = int.Parse(this.txtParentId.Text.Trim()),
                              Order = int.Parse(this.txtOrder.Text.Trim()),
                              Level = int.Parse(this.ddlLevel.SelectedValue),
                              URLType = int.Parse(this.ddlURLType.SelectedValue),
                              URL = this.txtURL.Text,
                              HasSubMenu = (this.chkSubMenu.Checked ? 1 : 0),
                              Type = int.Parse(this.ddlType.SelectedValue),
                              IsEnable = (this.chkIsEnable.Checked ? 1 : 0),
                              ImageURL = this.txtImageUrl.Text.Trim(),
                              Remark = this.txtRemark.Text.Trim(),
                              CheckCode = this.txtCheckCode.Text.Trim(),
                              ObjType = this.txtObjType.Text.Trim(),

                          };

            switch (this.EditMode)
            {
                case "Add":
                    try
                    {
                        DataProvider.MenuProvider.Insert(obj);
                        this.menuDS = DataProvider.MenuProvider.GetAllMenuByProductId(this.ProductId);
                        this.CreateTree(this.menuDS.Tables[0]);
                        this.txtId.Text = obj.ID.ToString();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "AddFailed", string.Format(@"<script>alert('添加失败！\r\n{0}');</script>", ex.Message.Replace("'","")));
                        return false;
                    }
                case "Edit":
                    try
                    {
                        DataProvider.MenuProvider.Update(obj);
                        this.tvMenu.SelectedNode.Text = this.txtName.Text.Trim();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "EditFail", string.Format(@"<script>alert('更新失败！\r\n{0}');</script>", ex.Message.Replace("'", "")));
                        return false;
                    }
                default:
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoEditMode", "<script>alert('没有指定编辑模式！');</script>");
                        return false;                        
                    }
            }
        }
        /// <summary>
        /// 维护界面模式切换。
        /// </summary>
        /// <param name="editable"></param>
        private void SwitchMode(bool editable)
        {
            this.txtName.Enabled        = editable;
            this.txtTitle.Enabled       = editable;
            this.txtRightCode.Enabled   = editable;
            this.txtOrder.Enabled       = editable;
            this.ddlLevel.Enabled       = editable;
            this.ddlURLType.Enabled     = editable;
            this.ddlType.Enabled        = editable;
            this.txtURL.Enabled         = editable;
            this.chkIsEnable.Enabled    = editable;
            this.chkSubMenu.Enabled     = editable;
            this.txtRemark.Enabled      = editable;
            this.txtCheckCode.Enabled   = editable;
            this.txtObjType.Enabled     = editable;
        }
        /// <summary>
        /// 菜单项编辑区域复位。
        /// </summary>
        private void Reset()
        {
            this.txtId.Text = string.Empty;
            this.txtParentId.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtTitle.Text = string.Empty;
            this.txtRightCode.Text = string.Empty;
            this.txtOrder.Text = "0";
            this.ddlLevel.SelectedIndex = 2;
            this.ddlURLType.SelectedIndex = 1;
            this.txtURL.Text = "#";
            this.chkIsEnable.Checked = true;
            this.chkSubMenu.Checked = false;
            this.txtRemark.Text = string.Empty;
        }
        
        #endregion

        #region Event
        /// <summary>
        /// 页面加载事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindMenuType();
                this.MzhToolbar1.Items["Save"].Visible = false;
                if (string.IsNullOrEmpty(Request["ProductId"]))
                {
                    this.Response.Write("<script>alert('页面URL没有指定ProductId值。');</script>");
                    return;
                }
                this.ProductId = short.Parse(Request["ProductId"]);
                var obj = DataProvider.ProductProvider.GetByCode(this.ProductId);
                if (obj != null)
                {
                    this.ProductName = obj.ProductName;
                    this.menuDS = DataProvider.MenuProvider.GetAllMenuByProductId(this.ProductId);
                    if (this.menuDS.Tables.Count > 0 && this.menuDS.Tables[0].Rows.Count > 0)
                    {
                        this.CreateTree(this.menuDS.Tables[0]);
                    }
                    else
                    {
                        this.CreateTree(this.menuDS.Tables[0]);
                    }
                }
                else
                {
                    this.Response.Write("<script>alert('没有指定产品的信息。');</script>");
                    return;
                }

                this.SwitchMode(false);
            }
            else
            {
                this.tvMenu.Focus();
            }
        }
        /// <summary>
        /// TreeView节点选中事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvMenu_NodeSelected(object sender, TreeViewNodeEventArgs e)
        {
            this.SwitchMode(false);
            this.tbiDelete.Visible = true;
            var menuId = int.Parse(e.Node.Value);
            if (menuId != 0 || menuId != -1)
            {
                var ds = DataProvider.MenuProvider.GetMenuById(menuId);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.txtId.Text = ds.Tables[0].Rows[0]["fID"].ToString();
                    this.txtName.Text = ds.Tables[0].Rows[0]["fName"].ToString();
                    this.txtTitle.Text = ds.Tables[0].Rows[0]["fTitle"].ToString();
                    this.txtRightCode.Text = ds.Tables[0].Rows[0]["fRightCode"].ToString();
                    this.txtParentId.Text = ds.Tables[0].Rows[0]["fParentId"].ToString();
                    this.txtOrder.Text = ds.Tables[0].Rows[0]["fOrder"].ToString();
                    this.ddlLevel.SelectedValue = ds.Tables[0].Rows[0]["fLevel"].ToString();
                    this.ddlURLType.SelectedValue = ds.Tables[0].Rows[0]["fURLType"].ToString();
                    this.txtURL.Text = ds.Tables[0].Rows[0]["fURL"].ToString();
                    this.txtImageUrl.Text = ds.Tables[0].Rows[0]["fImage"].ToString();
                    this.chkIsEnable.Checked = ds.Tables[0].Rows[0]["fIsEnable"].ToString() == "1" ? true : false;
                    this.chkSubMenu.Checked = ds.Tables[0].Rows[0]["fHasSubMenu"].ToString() == "1" ? true : false;
                    this.ddlType.SelectedValue = ds.Tables[0].Rows[0]["fType"].ToString();
                    this.txtRemark.Text = ds.Tables[0].Rows[0]["fRemark"].ToString();
                    this.txtCheckCode.Text = ds.Tables[0].Rows[0]["fCheckCode"].ToString();
                    this.txtObjType.Text = ds.Tables[0].Rows[0]["fObjType"].ToString();
                }
            }
        }
        /// <summary>
        /// 工具条事件。
        /// </summary>
        /// <param name="item"></param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId)
            {
                case "Add":
                    if (this.tvMenu.SelectedNode != null && this.tvMenu.SelectedNode.Value != "-1")
                    {
                        this.EditMode = "Add";
                        this.SwitchMode(true);
                        this.Reset();
                        this.txtParentId.Text = this.tvMenu.SelectedNode.Value;
                        this.tbiSave.Visible = true;
                        this.tbiDelete.Visible = false;
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoParent", "<script>alert('请先选择上一级菜单项！');</script>");
                        this.SwitchMode(false);
                    }
                    break;
                case "Edit":
                    if (this.tvMenu.SelectedNode != null && this.tvMenu.SelectedNode.Value != "-1")
                    {
                        if (this.tvMenu.SelectedNode.ID == this.txtId.Text)
                        {
                            this.EditMode = "Edit";
                            this.SwitchMode(true);
                            this.MzhToolbar1.Items["Save"].Visible = true;
                        }
                        else
                        {
                            foreach(TreeViewNode node in this.tvMenu.SelectedNode.Nodes)
                            {
                                if(node.ID == this.txtId.Text)
                                {
                                    this.tvMenu.SelectedNode = node;
                                    this.EditMode = "Edit";
                                    this.SwitchMode(true);
                                    this.MzhToolbar1.Items["Save"].Visible = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoSelectedNode", "<script>alert('请先选择菜单项,然后再进行修改！');</script>");
                        this.SwitchMode(false);
                    }
                    break;
                case "Delete":
                    if (this.tvMenu.SelectedNode != null && this.tvMenu.SelectedNode.Value != "-1" && this.tvMenu.SelectedNode.Value != "0")
                    {
                        if (this.tvMenu.SelectedNode.Nodes.Count == 0)
                        {
                            if (DataProvider.MenuProvider.Delete(int.Parse(this.txtId.Text)))
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "NodeDelete","window.tvMenu.SelectedNode.remove();",true);
                                this.Reset();
                            }
                            else
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteFail", "<script>alert('删除失败！');</script>");
                            }
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "DeleteFail", "<script>alert('该菜单项包含子菜单，不允许删除！');</script>");
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "NoSelectedNodeDelete", "<script>alert('请先选择菜单项,然后再进行删除！');</script>");
                        this.SwitchMode(false);
                    }
                    break;
                case "Save":
                    if(this.Save())
                    {
                        this.SwitchMode(false);
                        this.MzhToolbar1.Items["Save"].Visible = false;
                        //this.menuDS = DataProvider.CreateMenuProvider().GetAllMenuByProductId(this.ProductId);
                        //this.CreateTree(this.menuDS.Tables[0]);
                        //this.AddScript("Success","<script>alert('保存成功！');</script>");
                    }
                    
                    break;
            }
        }
        /// <summary>
        /// 树节点移动事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvMenu_NodeMoved(object sender, TreeViewNodeMovedEventArgs e)
        {
            var id = int.Parse(e.Node.Value);
            var newParentId = int.Parse(e.Node.ParentNode.Value);
            if (DataProvider.MenuProvider.MoveTo(id, newParentId))
            {
                //this.ClientScript.RegisterStartupScript(this.GetType(), "MoveSuccessed", "<script>alert('转移成功！');</script>");
            }
            else
            {
                //this.menuDS = DataProvider.CreateMenuProvider().GetAllMenuByProductId(this.ProductId);
                if (this.menuDS.Tables.Count > 0)
                {
                    //this.CreateTree(this.menuDS.Tables[0]);
                }
                //else
                //{
                //    this.Response.Write("<script>alert('没有指定产品的菜单数据！');</script>");
                //    return;
                //}
            }
        }
        #endregion
    }
}
