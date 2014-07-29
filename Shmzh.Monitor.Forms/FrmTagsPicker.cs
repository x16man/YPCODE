using System;
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
    public partial class FrmTagsPicker : Form
    {
        private List<TagCategoryInfo> tagCategoryList;
        private FrmTagsPicker()
        {
            InitializeComponent();
            this.dgvSelected.AutoGenerateColumns = false;
            this.dgvCategoryDetail.AutoGenerateColumns = false;
            this.imgList.Images.Add(Properties.Resources.folder);
        }

        public FrmTagsPicker(List<TagInfo> selectedTags)
            : this()
        {
            this.SelectedTags = selectedTags;
        }

        public List<TagInfo> SelectedTags { get; set; }

        private void FrmTagsPicker_Load(object sender, EventArgs e)
        {
            BuildTree();
            this.tvCategory.ExpandAll();
            if (SelectedTags == null)
                SelectedTags = new List<TagInfo>();
            this.dgvSelected.DataSource = this.SelectedTags;
        }

        /// <summary>
        /// 生成树。
        /// </summary>
        private void BuildTree()
        {
            tagCategoryList = DataProvider.TagCategoryProvider.GetAll();
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

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font, rect, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            }
        }

        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TagCategoryInfo categoryInfo = tvCategory.SelectedNode.Tag as TagCategoryInfo;
            var list = DataProvider.TagCategoryDetailProvider.GetTagsByCategoryId(categoryInfo.CategoryId);
            this.dgvCategoryDetail.DataSource = list;
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
        /// <param name="orderToggle">变更排序方向的Toggle </param>
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

        private void dgvCategoryDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (this.dgvCategoryDetail.SelectedRows.Count > 0)
                {
                    List<TagInfo> data_CategoryDetail = this.dgvCategoryDetail.DataSource as List<TagInfo>;
                    List<TagInfo> data_Selected = this.dgvSelected.DataSource as List<TagInfo>;
                    for (int i = 0; i < this.dgvCategoryDetail.SelectedRows.Count; i++)
                    {
                        var row = this.dgvCategoryDetail.SelectedRows[i];
                        TagInfo entity = row.DataBoundItem as TagInfo;
                        if (!data_Selected.Exists(o => o.I_Tag_Id.Equals(entity.I_Tag_Id, StringComparison.OrdinalIgnoreCase)))
                        {
                            data_Selected.Add(entity);
                        }
                        data_CategoryDetail.Remove(entity);
                    }
                    this.dgvCategoryDetail.DataSource = new List<TagInfo>(data_CategoryDetail);
                    this.dgvSelected.DataSource = new List<TagInfo>(data_Selected);
                }
            }
        }

        private void dgvSelected_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (this.dgvSelected.SelectedRows.Count > 0)
                {
                    List<TagInfo> data_CategoryDetail = this.dgvCategoryDetail.DataSource as List<TagInfo>;
                    List<TagInfo> data_Selected = this.dgvSelected.DataSource as List<TagInfo>;
                    for (int i = 0; i < this.dgvSelected.SelectedRows.Count; i++)
                    {
                        var row = this.dgvSelected.SelectedRows[i];
                        TagInfo entity = row.DataBoundItem as TagInfo;
                        if (!data_CategoryDetail.Exists(o => o.I_Tag_Id.Equals(entity.I_Tag_Id, StringComparison.OrdinalIgnoreCase)))
                        {
                            data_CategoryDetail.Add(entity);
                        }
                        data_Selected.Remove(entity);
                    }
                    this.dgvCategoryDetail.DataSource = new List<TagInfo>(data_CategoryDetail);
                    this.dgvSelected.DataSource = new List<TagInfo>(data_Selected);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SelectedTags = this.dgvSelected.DataSource as List<TagInfo>;
            if (SelectedTags == null)
                SelectedTags = new List<TagInfo>();
            this.DialogResult = DialogResult.OK;
        }

       
    }
}
