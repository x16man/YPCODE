using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

using Shmzh.Monitor.Forms;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmGraphSchema : Form
    {
        private Int32 lastSelIdx;
        /// <summary>
        /// 我的未分类方案所在的节点。
        /// </summary>
        private TreeNode _myNoCategorySchema;

        private bool _isSuperUser = Common.GetIsSuperUser();

        #region CTOR
        public FrmGraphSchema()
        {
            InitializeComponent();
            gvItem.AutoGenerateColumns = false;
            gvTag.AutoGenerateColumns = false;

            this.imgListTV.Images.Add(Properties.Resources.door_in);
            this.imgListTV.Images.Add(Properties.Resources.application_side_boxes);
            this.imgListTV.Images.Add(Properties.Resources.user);
        }
        #endregion

        #region Properties
        /// <summary>
        /// 我的未分类方案所在的节点。
        /// </summary>
        private TreeNode MyNoCategorySchema
        {
            get
            {
                if (_myNoCategorySchema == null && _isSuperUser)
                {
                    String loginName = Common.CurrentUser.LoginName;
                    TreeNode tnLoginName = new TreeNode(loginName);
                    CategoryInfo tmpCategoryInfo = new CategoryInfo()
                    {
                        CategoryId = -101,
                        CategoryName = loginName,
                    };
                    tnLoginName.Tag = tmpCategoryInfo;
                    tnLoginName.ImageIndex = tnLoginName.SelectedImageIndex = 2;
                    tvScheme.Nodes[tvScheme.Nodes.Count - 1].Nodes.Add(tnLoginName);
                    _myNoCategorySchema = tnLoginName;
                }
                return _myNoCategorySchema;
            }
            set
            {
                _myNoCategorySchema = value;
            }
        }
        #endregion

        #region private method
        /// <summary>
        /// 生成目录树。
        /// </summary>
        private void BindSchemeTreeView()
        {
            this.tvScheme.Nodes.Clear();
            //var categoryList = DataProvider.CategoryProvider.GetAll();
            var categoryList = GlobleVariables.CategoryList;
            foreach (var entity in categoryList)
            {
                if (Common.CurrentUser.HasRight(entity.RightCode) || entity.IsPublic)
                {
                    var tn = new TreeNode(entity.CategoryName);
                    tn.ImageIndex = tn.SelectedImageIndex = 0;
                    tn.Tag = entity;
                    this.tvScheme.Nodes.Add(tn);

                    var objs = GlobleVariables.CategoryItemList.FindAll(item => item.CategoryId == entity.CategoryId);
                    foreach (var obj in objs)
                    {
                        var schemaInfo = GlobleVariables.GraphSchemaList.Find(item => item.Name == obj.ConfigFile);
                        if(schemaInfo != null)
                        {
                            var tnSchema = new TreeNode(schemaInfo.Name) { Tag = schemaInfo };
                            tnSchema.ImageIndex = tnSchema.SelectedImageIndex = 1;
                            tnSchema.ToolTipText = String.Format("双击查看：{0}", schemaInfo.Name);
                            tn.Nodes.Add(tnSchema);    
                        }
                    }
                }
            }
            if (_isSuperUser)
            {
                var tn = new TreeNode("所有未分类方案");
                tn.ImageIndex = tn.SelectedImageIndex = 0;
                var categoryInfo = new CategoryInfo()
                {
                    CategoryId = -100,
                    CategoryName = "所有未分类方案",
                };
                tn.Tag = categoryInfo;
                this.tvScheme.Nodes.Add(tn);

                var schemaList = DataProvider.GraphSchemaProvider.GetNoCategorySchema(null);
                
                var loginNames = new List<String>();
                foreach (var schemaInfo in schemaList)
                {
                    if (!loginNames.Contains(schemaInfo.ReferLoginName))
                    {
                        loginNames.Add(schemaInfo.ReferLoginName);
                    }
                }

                foreach (var loginName in loginNames)
                {
                    var tnLoginName = new TreeNode(loginName);
                    var tmpCategoryInfo = new CategoryInfo() {
                        CategoryId = -101,
                        CategoryName = loginName,
                    };
                    tnLoginName.Tag = tmpCategoryInfo;
                    tnLoginName.ImageIndex = tnLoginName.SelectedImageIndex = 2;
                    tn.Nodes.Add(tnLoginName);

                    if (loginName.Equals(Common.CurrentUser.LoginName, StringComparison.OrdinalIgnoreCase))
                    {
                        this._myNoCategorySchema = tnLoginName;
                    }

                    var tmpList = schemaList.FindAll(o => o.ReferLoginName.Equals(loginName, StringComparison.OrdinalIgnoreCase));
                    foreach (var schemaInfo in tmpList)
                    {
                        var tnSchema = new TreeNode(schemaInfo.Name) {Tag = schemaInfo};
                        tnSchema.ImageIndex = tnSchema.SelectedImageIndex = 1;
                        tnSchema.ToolTipText = String.Format("双击查看：{0}", schemaInfo.Name);
                        tnLoginName.Nodes.Add(tnSchema);
                    }
                }
            }
            else
            {
                var tn = new TreeNode("我的未分类方案");
                tn.ImageIndex = tn.SelectedImageIndex = 0;
                var categoryInfo = new CategoryInfo()
                {
                    CategoryId = -200,
                    CategoryName = "我的未分类方案",
                };
                tn.Tag = categoryInfo;
                this.tvScheme.Nodes.Add(tn);
                _myNoCategorySchema = tn;

                var schemaList = DataProvider.GraphSchemaProvider.GetNoCategorySchema(Common.CurrentUser.LoginName);
                foreach (var schemaInfo in schemaList)
                {
                    var tnSchema = new TreeNode(schemaInfo.Name) {Tag = schemaInfo};
                    tnSchema.ImageIndex = tnSchema.SelectedImageIndex = 1;
                    tnSchema.ToolTipText = String.Format("双击查看：{0}", schemaInfo.Name);
                    tn.Nodes.Add(tnSchema);
                }
            }
            //this.tvScheme.ExpandAll();
        }

        /// <summary>
        /// 绑定方案项列表。
        /// </summary>
        private void BindItemGridView()
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                return;
            }
            var schemaInfo = this.tvScheme.SelectedNode.Tag as GraphSchemaInfo;
            //var objs = DataProvider.GraphSchemaItemProvider.GetBySchemaId(schemaInfo.SchemaId);
            var objs = GlobleVariables.GraphSchemaItemList.FindAll(item => item.SchemaId == schemaInfo.SchemaId);
            gvItem.DataSource = objs;
            this.EnableMoveButtonItem();
        }
        /// <summary>
        /// 绑定曲线方案指标项。
        /// </summary>
        private void BindTagGridView()
        {
            if (this.gvItem.SelectedRows.Count > 0)
            {
                var obj = (GraphSchemaItemInfo)this.gvItem.SelectedRows[0].DataBoundItem;
                //var objs = DataProvider.GraphSchemaTagProvider.GetBySchemaItemId(obj.ItemId);
                var objs = GlobleVariables.GraphSchemaTagList.FindAll(item => item.ItemId == obj.ItemId);
                objs.Sort((x,y)=>x.SerialNumber.CompareTo(y.SerialNumber));
                this.gvTag.DataSource = objs;
                for (var i = 0; i < this.gvTag.Rows.Count; i++)
                {
                    var graphSchemaTagInfo = (GraphSchemaTagInfo)this.gvTag.Rows[i].DataBoundItem;
                    gvTag.Rows[i].Cells[0].Style.BackColor = gvTag.Rows[i].Cells[0].Style.SelectionBackColor = Color.FromArgb(graphSchemaTagInfo.CurveColor);
                    gvTag.Rows[i].Cells[3].Value = Common.GetCurveName(graphSchemaTagInfo.CurveType);
                }
                this.EnableMoveButtonTag();
            }
            else
            {
                this.gvTag.DataSource = new List<Object>();
            }
        }

        private void EnableMoveButtonTag()
        {
            if(this.gvTag.Rows.Count < 2 || this.gvTag.SelectedRows.Count < 1)
            {
                this.tsDownTag.Enabled = this.tsUpTag.Enabled = false;
            }
            else 
            {
                if (this.gvTag.SelectedRows[0].Index == 0)
                {
                    this.tsDownTag.Enabled = true;
                    this.tsUpTag.Enabled = false;
                }
                else if (this.gvTag.SelectedRows[0].Index == this.gvTag.Rows.Count - 1)
                {
                    this.tsDownTag.Enabled = false;
                    this.tsUpTag.Enabled = true;
                }
                else
                {
                    this.tsDownTag.Enabled = this.tsUpTag.Enabled = true;
                }
            }
        }

        private void EnableMoveButtonItem()
        {
            if (this.gvItem.Rows.Count < 2 || this.gvItem.SelectedRows.Count < 1)
            {
                this.tsbDownItem.Enabled = this.tsbUpItem.Enabled = false;
            }
            else
            {
                if (this.gvItem.SelectedRows[0].Index == 0)
                {
                    this.tsbDownItem.Enabled = true;
                    this.tsbUpItem.Enabled = false;
                }
                else if (this.gvItem.SelectedRows[0].Index == this.gvItem.Rows.Count - 1)
                {
                    this.tsbDownItem.Enabled = false;
                    this.tsbUpItem.Enabled = true;
                }
                else
                {
                    this.tsbDownItem.Enabled = this.tsbUpItem.Enabled = true;
                }
            }
        }
        #endregion

        #region Event
        private void FrmGraphScheme_Load(object sender, EventArgs e)
        {
            this.BindSchemeTreeView();
            //this.BindSchemeGridView();
            this.BindItemGridView();
            this.BindTagGridView();
        }

        #region tvScheme TreeView.
        private void tvScheme_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level > 0)
            {
                var obj = e.Node.Tag as GraphSchemaInfo;
                if (obj != null)
                {
                    //var objs = DataProvider.GraphSchemaItemProvider.GetBySchemaId(entity.SchemaId);
                    var objs = GlobleVariables.GraphSchemaItemList.FindAll(item => item.SchemaId == obj.SchemaId);
                    gvItem.DataSource = objs;
                    this.EnableMoveButtonItem();
                }
                else
                {
                    this.gvItem.DataSource = new List<Object>();
                    this.gvTag.DataSource = new List<Object>();
                }
            }
            else
            {
                this.gvItem.DataSource = new List<Object>();
                this.gvTag.DataSource = new List<Object>();
            }
        }
        #endregion

        #region Schema        
        private void tsAddSchema_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is CategoryInfo))
            {
                MessageBox.Show("请选择要添加到的方案类别。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var categoryInfo = this.tvScheme.SelectedNode.Tag as CategoryInfo;
            var frmGraphSchemeEdit = new FrmGraphSchemaEdit(ActionType.Add);
            if (frmGraphSchemeEdit.ShowDialog(this) == DialogResult.OK)
            {
                var schemaInfo = frmGraphSchemeEdit.GraphSchemeEntity;
                var tnSchema = new TreeNode(schemaInfo.Name) {Tag = schemaInfo};
                tnSchema.ImageIndex = tnSchema.SelectedImageIndex = 1;
                //新增到我的未分类方案(即不进行分类)。
                if (categoryInfo.CategoryId < 0)
                {
                    this.MyNoCategorySchema.Nodes.Add(tnSchema);
                    if (!this.MyNoCategorySchema.IsExpanded)
                        this.MyNoCategorySchema.ExpandAll();
                }
                else
                {                    
                    var categoryItem = new CategoryItemInfo
                                           {
                                               Title = schemaInfo.Name,
                                               UpdateTime = Common.GetUpdateTime(schemaInfo.DataType),
                                               ClassName = "Shmzh.Monitor.Forms.FrmGraphSchemaStage",
                                               ConfigFile = schemaInfo.Name,
                                               CategoryId = categoryInfo.CategoryId
                                           };
                    var ret = DataProvider.CategoryItemProvider.Insert(categoryItem);
                    if (ret > 0)
                    {
                        categoryItem.ItemId = ret;
                        this.tvScheme.SelectedNode.Nodes.Add(tnSchema);
                        if (!this.tvScheme.SelectedNode.IsExpanded)
                            this.tvScheme.SelectedNode.ExpandAll();
                        if (this.MdiParent != null)
                        {
                            this.MdiParent.GetType().GetMethod("UpdateCategoryItemMenu").Invoke(this.MdiParent, new object[] { categoryItem, ActionType.Add });
                        }
                    }
                }
            }
            frmGraphSchemeEdit.Dispose();
        }

        private void tsEditSchema_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                MessageBox.Show("请选择要编辑的方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var graphSchemaInfo = this.tvScheme.SelectedNode.Tag as GraphSchemaInfo;
            var frmGraphSchemeEdit = new FrmGraphSchemaEdit(ActionType.Edit)
            {
                GraphSchemeEntity = graphSchemaInfo
            };
            if (frmGraphSchemeEdit.ShowDialog(this) == DialogResult.OK)
            {
                var itemList = new List<CategoryItemInfo>();
                //修改对应菜单项。
                var categoryInfo = this.tvScheme.SelectedNode.Parent.Tag as CategoryInfo;
                if (categoryInfo != null && categoryInfo.CategoryId > 0)
                {
                    //itemList = DataProvider.CategoryItemProvider.GetByConfigFile(this.tvScheme.SelectedNode.Text);
                    itemList = GlobleVariables.CategoryItemList.FindAll(item => item.ConfigFile == this.tvScheme.SelectedNode.Text);
                    if (this.MdiParent != null)
                    {
                        foreach (CategoryItemInfo itemInfo in itemList)
                        {
                            if (itemInfo.Title == itemInfo.ConfigFile)
                            {
                                itemInfo.Title = frmGraphSchemeEdit.GraphSchemeEntity.Name;
                            }
                            itemInfo.ConfigFile = frmGraphSchemeEdit.GraphSchemeEntity.Name;

                            if (DataProvider.CategoryItemProvider.Update(itemInfo))
                            {
                                this.MdiParent.GetType().GetMethod("UpdateCategoryItemMenu").Invoke(this.MdiParent, new object[] { itemInfo, ActionType.Edit });
                            }
                        }
                    }
                }
                //修改树节点。
                if (itemList != null)
                {
                    if (itemList.Count < 2)
                    {
                        this.tvScheme.SelectedNode.Text = frmGraphSchemeEdit.GraphSchemeEntity.Name;
                        this.tvScheme.SelectedNode.Tag = frmGraphSchemeEdit.GraphSchemeEntity;
                    }
                    else
                    {
                        foreach (TreeNode tn in this.tvScheme.Nodes)
                        {
                            var tempCategoryInfo = tn.Tag as CategoryInfo;
                            if (tempCategoryInfo != null && tempCategoryInfo.CategoryId > 0)
                            {
                                foreach (TreeNode tnSchema in tn.Nodes)
                                {
                                    var tempGraphSchemaInfo = tnSchema.Tag as GraphSchemaInfo;
                                    if (tempGraphSchemaInfo != null && tempGraphSchemaInfo.SchemaId == graphSchemaInfo.SchemaId)
                                    {
                                        tnSchema.Text = frmGraphSchemeEdit.GraphSchemeEntity.Name;
                                        tnSchema.Tag = frmGraphSchemeEdit.GraphSchemeEntity;
                                    }
                                }
                            }
                        } 
                    }
                }                
            }
            frmGraphSchemeEdit.Dispose();
        }

        private void tsDeleteSchema_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                MessageBox.Show("请选择要删除的方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (MessageBox.Show("删除方案会连同方案所包含的图表一起删除，确定要删除选定的方案吗！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var obj = this.tvScheme.SelectedNode.Tag as GraphSchemaInfo;

                var itemList = GlobleVariables.CategoryItemList.FindAll(item => item.ConfigFile == this.tvScheme.SelectedNode.Text);
                if (DataProvider.GraphSchemaProvider.Delete(obj.SchemaId))
                {
                    if (this.tvScheme.SelectedNode.Parent.Nodes.Count == 1)
                    {
                        this.gvItem.DataSource = new List<Object>();
                        this.gvTag.DataSource = new List<Object>();
                    }
                    if(itemList.Count > 0)
                    {
                        foreach (var itemInfo in itemList)
                        {
                            if (this.MdiParent != null)
                                this.MdiParent.GetType().GetMethod("UpdateCategoryItemMenu").Invoke(this.MdiParent, new object[] { itemInfo, ActionType.Delete });
                        }    
                    }
                    else//自定义方案.
                    {
                        if(this.MdiParent != null)
                        {
                            this.MdiParent.GetType().GetMethod("UpdateCustomerMenu").Invoke(this.MdiParent, new object[] {obj, ActionType.Delete});
                        }
                    }
                    //删除树节点。
                    if (itemList.Count < 2)
                    {
                        this.tvScheme.SelectedNode.Remove();
                    }
                    else
                    {
                        foreach (TreeNode tn in this.tvScheme.Nodes)
                        {
                            var tempCategoryInfo = tn.Tag as CategoryInfo;
                            if (tempCategoryInfo != null && tempCategoryInfo.CategoryId > 0)
                            {
                                foreach (TreeNode tnSchema in tn.Nodes)
                                {
                                    var tempGraphSchemaInfo = tnSchema.Tag as GraphSchemaInfo;
                                    if (tempGraphSchemaInfo != null && tempGraphSchemaInfo.SchemaId == obj.SchemaId)
                                    {
                                        tnSchema.Remove();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void gvScheme_SelectionChanged(object sender, EventArgs e)
        {
            this.BindItemGridView();
        }
        #endregion
        #region Item
        private void tsbAddItem_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                MessageBox.Show("请选择所属方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var schemaInfo = this.tvScheme.SelectedNode.Tag as GraphSchemaInfo;
            var frmGraphSchemeItemEdit = new FrmGraphSchemaItemEdit(schemaInfo);

            if (frmGraphSchemeItemEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.BindItemGridView();
            }
        }

        private void tsbEditItem_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                MessageBox.Show("请选择所属方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.gvItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var schemeItemInfo = (GraphSchemaItemInfo)this.gvItem.SelectedRows[0].DataBoundItem;
                var frmGraphSchemeItemEdit = new FrmGraphSchemaItemEdit(schemeItemInfo);

                if (frmGraphSchemeItemEdit.ShowDialog(this) == DialogResult.OK)
                {
                    //this.BindItemGridView();
                }
            }
        }

        private void tsbDeleteItem_Click(object sender, EventArgs e)
        {
            if (this.gvItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的图表。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("删除图表会连同图表所包含的指标一起删除，确定要删除选定的图表吗！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var obj = (GraphSchemaItemInfo)this.gvItem.SelectedRows[0].DataBoundItem;
                        DataProvider.GraphSchemaItemProvider.Delete(obj.ItemId);
                        GlobleVariables.GraphSchemaItemList.Remove(obj);
                        BindItemGridView();
                        if (gvItem.Rows.Count == 0)
                        {
                            gvTag.DataSource = new List<Object>();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gvItem_SelectionChanged(object sender, EventArgs e)
        {
            this.EnableMoveButtonItem();
            this.BindTagGridView();            
        }

        private void tsbUpItem_Click(object sender, EventArgs e)
        {
            var obj = (GraphSchemaItemInfo)this.gvItem.SelectedRows[0].DataBoundItem;
            if (DataProvider.GraphSchemaItemProvider.Move(obj.ItemId, 0))
            {
                lastSelIdx = this.gvItem.SelectedRows[0].Index;
                this.BindItemGridView();
                this.gvItem.Rows[lastSelIdx - 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDownItem_Click(object sender, EventArgs e)
        {
            var obj = (GraphSchemaItemInfo)this.gvItem.SelectedRows[0].DataBoundItem;
            if (DataProvider.GraphSchemaItemProvider.Move(obj.ItemId, 1))
            {
                lastSelIdx = this.gvItem.SelectedRows[0].Index;
                this.BindItemGridView();
                this.gvItem.Rows[lastSelIdx + 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region Tag
        private void tsAddTag_Click(object sender, EventArgs e)
        {
            if (this.gvItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择所属方案项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var schemaItemInfo = (GraphSchemaItemInfo)this.gvItem.SelectedRows[0].DataBoundItem;
            var frmGraphSchemeTagEdit = new FrmGraphSchemaTagEdit(schemaItemInfo);

            if (frmGraphSchemeTagEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.BindTagGridView();
            }
        }

        private void tsEditTag_Click(object sender, EventArgs e)
        {
            if (this.gvTag.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var schemeTagInfo = (GraphSchemaTagInfo)this.gvTag.SelectedRows[0].DataBoundItem;
                var frmGraphSchemeTagEdit = new FrmGraphSchemaTagEdit(schemeTagInfo);

                if (frmGraphSchemeTagEdit.ShowDialog(this) == DialogResult.OK)
                {
                    //this.BindTagGridView();
                    var row = this.gvTag.SelectedRows[0];
                    row.Cells[0].Style.BackColor = row.Cells[0].Style.SelectionBackColor = Color.FromArgb(schemeTagInfo.CurveColor);
                    row.Cells[3].Value = Common.GetCurveName(schemeTagInfo.CurveType);
                }
            }
        }

        private void tsDeleteTag_Click(object sender, EventArgs e)
        {
            if (this.gvTag.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("确定要删除选定的记录吗！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var obj = (GraphSchemaTagInfo)this.gvTag.CurrentRow.DataBoundItem;
                        DataProvider.GraphSchemaTagProvider.Delete(obj.KeyId);
                        GlobleVariables.GraphSchemaTagList.Remove(obj);
                        BindTagGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsDownTag_Click(object sender, EventArgs e)
        {
            var obj = (GraphSchemaTagInfo)this.gvTag.SelectedRows[0].DataBoundItem;
            if (DataProvider.GraphSchemaTagProvider.Move(obj.KeyId, 1))
            {
                GlobleVariables.RefreshGraphSchemaTagList();
                lastSelIdx = this.gvTag.SelectedRows[0].Index;
                this.BindTagGridView();
                this.gvTag.Rows[lastSelIdx + 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsUpTag_Click(object sender, EventArgs e)
        {
            var obj = (GraphSchemaTagInfo)this.gvTag.SelectedRows[0].DataBoundItem;
            if (DataProvider.GraphSchemaTagProvider.Move(obj.KeyId, 0))
            {
                GlobleVariables.RefreshGraphSchemaTagList();
                lastSelIdx = this.gvTag.SelectedRows[0].Index;
                this.BindTagGridView();
                this.gvTag.Rows[lastSelIdx - 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvTag_SelectionChanged(object sender, EventArgs e)
        {
            this.EnableMoveButtonTag();
        }
        #endregion

        private void tsSchemaRelative_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                MessageBox.Show("请选择所属方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var schemaInfo = this.tvScheme.SelectedNode.Tag as GraphSchemaInfo;

            var frmGraphSchemaRTag = new FrmGraphSchemaTab(schemaInfo);
            frmGraphSchemaRTag.ShowDialog(this);
        }

        private void tsFloatingBlock_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                MessageBox.Show("请选择所属方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var schemaInfo = this.tvScheme.SelectedNode.Tag as GraphSchemaInfo;

            var form = new FrmFloatingBlock(schemaInfo);
            form.ShowDialog(this);
        }
        #endregion

        private void OpenGraphSchema(GraphSchemaInfo schemaInfo)
        {
            //显示状态窗口。
            var tHandler = new ToolTipHandler();
            tHandler.Show(String.Format("[{0}]\n正在打开，请稍候...", schemaInfo.Name), this.Bounds);
            //显示状态窗口。

            var form = new FrmGraphSchemaStage(schemaInfo.Name, Common.GetUpdateTime(schemaInfo.DataType)) {MdiParent = this.MdiParent, Text = schemaInfo.Name};
            form.Show();
            //隐藏状态窗口。
            tHandler.Close();
        }

        private void tsView_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                MessageBox.Show("请选择要查看的方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var schemaInfo = this.tvScheme.SelectedNode.Tag as GraphSchemaInfo;
            OpenGraphSchema(schemaInfo);
        }

        private void tvScheme_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is GraphSchemaInfo)
            {
                var schemaInfo = e.Node.Tag as GraphSchemaInfo;
                OpenGraphSchema(schemaInfo);
            }
        }

        private void tsCopy_Click(object sender, EventArgs e)
        {
            if (this.tvScheme.SelectedNode == null || !(this.tvScheme.SelectedNode.Tag is GraphSchemaInfo))
            {
                MessageBox.Show("请选择要复制的方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var schemaInfo = (this.tvScheme.SelectedNode.Tag as GraphSchemaInfo);
            schemaInfo = schemaInfo.Clone() as GraphSchemaInfo;
            schemaInfo.ItemList = DataProvider.GraphSchemaItemProvider.GetBySchemaId(schemaInfo.SchemaId);
            
            foreach (var itemInfo in schemaInfo.ItemList)
            {
                itemInfo.TagList = DataProvider.GraphSchemaTagProvider.GetBySchemaItemId(itemInfo.ItemId);
            }
            var frmGraphSchemeEdit = new FrmGraphSchemaEdit(ActionType.Save) {
                GraphSchemeEntity = schemaInfo
            };
            if (frmGraphSchemeEdit.ShowDialog() == DialogResult.OK)
            {
                //将新建方案添加到我的未分类方案节点。
                schemaInfo = frmGraphSchemeEdit.GraphSchemeEntity; 
                var tnSchema = new TreeNode(schemaInfo.Name) {Tag = schemaInfo};
                tnSchema.ImageIndex = tnSchema.SelectedImageIndex = 1;
                MyNoCategorySchema.Nodes.Add(tnSchema);
                if (!this.MyNoCategorySchema.IsExpanded)
                    this.MyNoCategorySchema.ExpandAll();
                //将新建方案添加到我的未分类方案节点。
            }

            frmGraphSchemeEdit.Dispose();
        }       
    }
}
