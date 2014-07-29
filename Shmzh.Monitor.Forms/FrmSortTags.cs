﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmSortTags : Form
    {
        //这里做移动的时候，只在数据库和类别树上调整了次序和层级关系，
        //并没有将新的次序和层级关系更新到每个树节点的Tag所存的类别实体中(做起来比较麻烦且影响运行效率)。
        //但由于操作时并没有用到次序和层级关系，故并不影响操作。
        #region Fields
        private List<TagCategoryInfo> tagCategoryList;
        private TreeNode _prevNode;
        #endregion

        public FrmSortTags()
        {
            InitializeComponent();
            this.dgvTagMS.AutoGenerateColumns = false;
            this.dgvCategoryDetail.AutoGenerateColumns = false;
            this.imgList.Images.Add(Properties.Resources.folder);
        }

        private void FrmSortTags_Load(object sender, EventArgs e)
        {
            tagCategoryList = DataProvider.TagCategoryProvider.GetAll();
            this.dgvTagMS.DataSource = new List<TagInfo>();
            BuildTree();
            this.tvCategory.ExpandAll();
        }


        /// <summary>
        /// 生成树。
        /// </summary>
        private void BuildTree()
        {
            var list = tagCategoryList.FindAll(o => o.ParentId == -1);
            list.Sort((a, b) => a.SerialNumber.CompareTo(b.SerialNumber));
            foreach (TagCategoryInfo entity in list)
            {
                TreeNode tn = new TreeNode(entity.CategoryName)
                {
                    Tag = entity,
                    ImageIndex = 0,
                };
                this.tvCategory.Nodes.Add(tn);
                BuildSubTree(tn, entity.CategoryId);
            }
        }

        private void BuildSubTree(TreeNode tnParent, int parentId)
        {
            var list = tagCategoryList.FindAll(o => o.ParentId == parentId);
            if (list.Count > 0)
            {
                list.Sort((a, b) => a.SerialNumber.CompareTo(b.SerialNumber));
                foreach (TagCategoryInfo entity in list)
                {
                    TreeNode tn = new TreeNode(entity.CategoryName)
                    {
                        Tag = entity,
                        ImageIndex = 0,
                    };
                    tnParent.Nodes.Add(tn);
                    BuildSubTree(tn, entity.CategoryId);
                }
            }
        }

        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.PrevNode == null)
            {
                tsbMoveUp.Enabled = false;
            }
            else
            {
                tsbMoveUp.Enabled = true;
            }

            if (e.Node.NextNode == null)
            {
                tsbMoveDown.Enabled = false;
            }
            else
            {
                tsbMoveDown.Enabled = true;
            }

            TagCategoryInfo categoryInfo = tvCategory.SelectedNode.Tag as TagCategoryInfo;
            var list = DataProvider.TagCategoryDetailProvider.GetTagsByCategoryId(categoryInfo.CategoryId);
            this.dgvCategoryDetail.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtTag.Text.Trim().Length == 0)
            {
                this.dgvTagMS.DataSource = new List<TagInfo>();
                return;
            }
            else
            {
                var tag = this.txtTag.Text.Trim();
                List<TagInfo> list = DataProvider.TagProvider.QuickSearch(tag);
                this.dgvTagMS.DataSource = list;
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font, rect, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.dgvTagMS.SelectedRows.Count == 0)
                return;
            List<TagInfo> listCategoryDetailData = this.dgvCategoryDetail.DataSource as List<TagInfo>;
            List<TagInfo> listTagMSData = this.dgvTagMS.DataSource as List<TagInfo>;
            List<TagInfo> tmpList = new List<TagInfo>();
            foreach (DataGridViewRow row in this.dgvTagMS.SelectedRows)
            {
                TagInfo entity = row.DataBoundItem as TagInfo;
                tmpList.Add(entity);
            }
            foreach (TagInfo entity in tmpList)
            {
                if (!listCategoryDetailData.Exists(o => o.I_Tag_Id.Equals(entity.I_Tag_Id, StringComparison.OrdinalIgnoreCase)))
                {
                    listCategoryDetailData.Add(entity);
                }
                listTagMSData.Remove(entity);
            }

            

            this.dgvCategoryDetail.DataSource = null;
            this.dgvTagMS.DataSource = null;
            this.dgvCategoryDetail.DataSource = listCategoryDetailData;            
            this.dgvTagMS.DataSource = listTagMSData;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvCategoryDetail.SelectedRows.Count == 0)
                return;
            List<TagInfo> listCategoryDetailData = this.dgvCategoryDetail.DataSource as List<TagInfo>;
            List<TagInfo> listTagMSData = this.dgvTagMS.DataSource as List<TagInfo>;            
            List<TagInfo> tmpList = new List<TagInfo>();
            foreach (DataGridViewRow row in this.dgvCategoryDetail.SelectedRows)
            {
                TagInfo entity = row.DataBoundItem as TagInfo;
                tmpList.Add(entity);
            }
            foreach (TagInfo entity in tmpList)
            {
                if (!listTagMSData.Exists(o => o.I_Tag_Id.Equals(entity.I_Tag_Id, StringComparison.OrdinalIgnoreCase)))
                {
                    listTagMSData.Add(entity);
                }
                listCategoryDetailData.Remove(entity);
            }
            this.dgvCategoryDetail.DataSource = null;
            this.dgvTagMS.DataSource = null;
            this.dgvCategoryDetail.DataSource = listCategoryDetailData;
            this.dgvTagMS.DataSource = listTagMSData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tvCategory.SelectedNode == null)
                return;
            List<TagInfo> listCategoryDetailData = this.dgvCategoryDetail.DataSource as List<TagInfo>;
            TagCategoryInfo tagCategoryInfo = this.tvCategory.SelectedNode.Tag as TagCategoryInfo;
            String[] tagIds = new String[listCategoryDetailData.Count];
            for (int i = 0; i < listCategoryDetailData.Count; i++)
            {
                tagIds[i] = listCategoryDetailData[i].I_Tag_Id;
            }
            if (DataProvider.TagCategoryDetailProvider.Reset(tagCategoryInfo.CategoryId, tagIds))
            {
                MessageBox.Show("保存成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region DataGridView 排序。
        private SortOrder sort = SortOrder.Descending;
        private DataGridViewColumn sortedColumn;
        private void dgvCategoryDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = (sender as DataGridView).Columns[e.ColumnIndex];
            if (clickedColumn.SortMode != DataGridViewColumnSortMode.Automatic)
            {
                this.SortRows(clickedColumn);
            }
        }

        /// <summary>
        ///以被指定的列为标准进行排序
        /// </summary>
        /// <param name="sortColumn">为标准的列</param>
        private void SortRows(DataGridViewColumn sortColumn)
        {
            //清除前面的排序
            if (sortColumn.SortMode == DataGridViewColumnSortMode.Programmatic &&
                 sortedColumn != null && !sortedColumn.Equals(sortColumn))
            {
                sortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            var dataSource = sortColumn.DataGridView.DataSource as List<TagInfo>;

            switch (sortColumn.DataPropertyName)
            {
                case "I_TAG_ID":
                    if (sort == SortOrder.Ascending)
                    {
                        dataSource.Sort((a, b) => String.Compare(a.I_Tag_Id, b.I_Tag_Id));
                    }
                    else
                    {
                        dataSource.Sort((a, b) => String.Compare(b.I_Tag_Id, a.I_Tag_Id));
                    }
                    break;
                case "I_TAG_NAME":
                    if (sort == SortOrder.Ascending)
                    {
                        dataSource.Sort((a, b) => String.Compare(a.I_Tag_Name, b.I_Tag_Name));
                    }
                    else
                    {
                        dataSource.Sort((a, b) => String.Compare(b.I_Tag_Name, a.I_Tag_Name));
                    }
                    break;
            }
            sortColumn.HeaderCell.SortGlyphDirection = sort;
            sort = (sort == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending);
            sortedColumn = sortColumn;
            sortColumn.DataGridView.Invalidate();
        }
        #endregion

        #region 指标类别操作。
        private void tsbAddRoot_Click(object sender, EventArgs e)
        {
            FrmTagCategoryEdit form = new FrmTagCategoryEdit(ActionType.Add);
            if (form.ShowDialog() == DialogResult.OK)
            {
                TreeNode tn = new TreeNode(form.TagCategoryEntity.CategoryName)
                {
                    Tag = form.TagCategoryEntity,
                    ImageIndex = 0,
                };
                this.tvCategory.Nodes.Add(tn);
            }
            form.Dispose();
        }

        private void tsbAddSub_Click(object sender, EventArgs e)
        {
            if (this.tvCategory.SelectedNode == null)
            {
                MessageBox.Show("请选择父类别。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FrmTagCategoryEdit form = new FrmTagCategoryEdit(ActionType.Add);
            form.TagCategoryEntity = this.tvCategory.SelectedNode.Tag as TagCategoryInfo;
            if (form.ShowDialog() == DialogResult.OK)
            {
                TreeNode tn = new TreeNode(form.TagCategoryEntity.CategoryName)
                {
                    Tag = form.TagCategoryEntity,
                    ImageIndex = 0
                };
                this.tvCategory.SelectedNode.Nodes.Add(tn);
            }
            form.Dispose();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.tvCategory.SelectedNode == null)
            {
                MessageBox.Show("请选择要编辑的类别。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FrmTagCategoryEdit form = new FrmTagCategoryEdit(ActionType.Edit);
            form.TagCategoryEntity = this.tvCategory.SelectedNode.Tag as TagCategoryInfo;
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.tvCategory.SelectedNode.Tag = form.TagCategoryEntity;
                this.tvCategory.SelectedNode.Text = form.TagCategoryEntity.CategoryName;
            }
            form.Dispose();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.tvCategory.SelectedNode == null)
            {
                MessageBox.Show("请选择要删除的类别。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TagCategoryInfo tagCategoryInfo = this.tvCategory.SelectedNode.Tag as TagCategoryInfo;
            if (tagCategoryInfo != null)
            {
                var subCategorys = DataProvider.TagCategoryProvider.GetByParentId(tagCategoryInfo.CategoryId);
                if (subCategorys.Count > 0)
                {
                    MessageBox.Show("该类别有子类别，不允许删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var tags = DataProvider.TagCategoryDetailProvider.GetByCategoryId(tagCategoryInfo.CategoryId);
                if (tags.Count > 0)
                {
                    MessageBox.Show("该类别有指标，不允许删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("确定要删除该类别吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (DataProvider.TagCategoryProvider.Delete(tagCategoryInfo.CategoryId))
                    {
                        this.tvCategory.SelectedNode.Remove();
                        MessageBox.Show("删除成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbSetRoot_Click(object sender, EventArgs e)
        {
            if (this.tvCategory.SelectedNode == null)
            {
                MessageBox.Show("请选择要设为根类别的类别。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tvCategory.SelectedNode.Parent == null)
                return;

            TreeNode moveNode = this.tvCategory.SelectedNode;
            var moveCategoryId = (moveNode.Tag as TagCategoryInfo).CategoryId;
            var targetCategoryId = -1;
            if (DataProvider.TagCategoryProvider.Move(moveCategoryId, targetCategoryId))
            {
                //添加到下级节点的未端
                TreeNode newMoveNode = (TreeNode)moveNode.Clone();
                this.tvCategory.Nodes.Insert(this.tvCategory.Nodes.Count, newMoveNode);

                //更新当前拖动的节点选择
                tvCategory.SelectedNode = newMoveNode;
                ////展开目标节点,便于显示拖放效果
                //targetNode.Expand();

                //移除拖放的节点
                moveNode.Remove();
            }
        }

        #region 拖动处理。
        private void tvCategory_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvCategory_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tvCategory_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
            {
                TreeView treeView = (TreeView)(sender);
                Point pt = treeView.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = this.tvCategory.GetNodeAt(pt);

                if (_prevNode != null && _prevNode != targetNode)
                {
                    treeView.Invalidate(_prevNode.Bounds);
                }
                if (targetNode == null)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }

                using (var g = tvCategory.CreateGraphics())
                {
                    g.DrawRectangle(Pens.Red, Rectangle.Inflate(targetNode.Bounds, -1, -1));
                }
                _prevNode = targetNode;
            }
        }

        private void tvCategory_DragDrop(object sender, DragEventArgs e)
        {
            //获得拖放中的节点
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

            //根据鼠标坐标确定要移动到的目标节点
            TreeView treeView = (TreeView)(sender);
            Point pt = treeView.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = this.tvCategory.GetNodeAt(pt);

            if (targetNode == null) return;

            if (moveNode == targetNode || moveNode.Parent == targetNode)
            {
                treeView.Invalidate(targetNode.Bounds);
                return;
            }
            TreeNode tmpNode = targetNode;
            while (tmpNode != null)
            {
                if (tmpNode == moveNode)
                {
                    treeView.Invalidate(targetNode.Bounds);
                    return;
                }
                tmpNode = tmpNode.Parent;
            }

            if (MessageBox.Show(String.Format("确定将分类[{0}]移动到[{1}]吗？", moveNode.Text, targetNode.Text), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var moveCategoryId = (moveNode.Tag as TagCategoryInfo).CategoryId;
                var targetCategoryId = (targetNode.Tag as TagCategoryInfo).CategoryId;
                if (DataProvider.TagCategoryProvider.Move(moveCategoryId, targetCategoryId))
                {
                    //添加到下级节点的未端
                    TreeNode newMoveNode = (TreeNode)moveNode.Clone();
                    targetNode.Nodes.Insert(targetNode.Nodes.Count, newMoveNode);

                    //更新当前拖动的节点选择
                    tvCategory.SelectedNode = newMoveNode;
                    //展开目标节点,便于显示拖放效果
                    targetNode.Expand();

                    //移除拖放的节点
                    moveNode.Remove();
                }
            }
            else
            {
                treeView.Invalidate(targetNode.Bounds);
            }
        }
        #endregion

        #region 上移或下移。        
        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            if (this.tvCategory.SelectedNode == null)
            {
                MessageBox.Show("请选择要移动的类别。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TagCategoryInfo tagCategoryInfo = this.tvCategory.SelectedNode.Tag as TagCategoryInfo;
            if (tagCategoryInfo != null)
            {
                if (DataProvider.TagCategoryProvider.MoveUpDown(tagCategoryInfo.CategoryId, 0))
                {
                    var moveNode = this.tvCategory.SelectedNode;
                    var newMoveNode = this.tvCategory.SelectedNode.Clone() as TreeNode;
                    if (moveNode.Parent == null)
                    {
                        this.tvCategory.Nodes.Insert(moveNode.PrevNode.Index, newMoveNode);
                    }
                    else
                    {
                        moveNode.Parent.Nodes.Insert(moveNode.PrevNode.Index, newMoveNode);
                    }
                    moveNode.Remove();
                    this.tvCategory.SelectedNode = newMoveNode;
                    newMoveNode.Expand();
                }
                else
                {
                    MessageBox.Show("移动失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            if (this.tvCategory.SelectedNode == null)
            {
                MessageBox.Show("请选择要移动的类别。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TagCategoryInfo tagCategoryInfo = this.tvCategory.SelectedNode.Tag as TagCategoryInfo;
            if (tagCategoryInfo != null)
            {
                if (DataProvider.TagCategoryProvider.MoveUpDown(tagCategoryInfo.CategoryId, 1))
                {
                    var moveNode = this.tvCategory.SelectedNode;
                    var newMoveNode = this.tvCategory.SelectedNode.Clone() as TreeNode;
                    if (moveNode.Parent == null)
                    {
                        this.tvCategory.Nodes.Insert(moveNode.NextNode.Index + 1, newMoveNode);
                    }
                    else
                    {
                        moveNode.Parent.Nodes.Insert(moveNode.NextNode.Index + 1, newMoveNode);
                    }
                    moveNode.Remove();
                    this.tvCategory.SelectedNode = newMoveNode;
                    newMoveNode.Expand();
                }
                else
                {
                    MessageBox.Show("移动失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
        #endregion
    }
}
