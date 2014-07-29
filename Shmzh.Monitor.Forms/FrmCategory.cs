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
    public partial class FrmCategory : Form
    {
        #region Fields
        private int lastSelIdx;
        #endregion

        public FrmCategory()
        {
            InitializeComponent();
            this.dgvCategory.AutoGenerateColumns = false;
            this.dgvCategoryItem.AutoGenerateColumns = false;
        }

        #region Methods
        /// <summary>
        /// 绑定方案类别列表。
        /// </summary>
        private void BindCategoryGridView()
        {
            //var objs = DataProvider.CategoryProvider.GetAll();
            dgvCategory.DataSource = GlobleVariables.CategoryList;
            this.EnableMoveButtonCategory();
        }

        private void BindCategoryItemGridView()
        {
            if (this.dgvCategory.SelectedRows.Count > 0)
            {
                var categoryInfo = this.dgvCategory.SelectedRows[0].DataBoundItem as CategoryInfo;
                //var objs = DataProvider.CategoryItemProvider.GetByCategoryId(categoryInfo.CategoryId);
                var objs = GlobleVariables.CategoryItemList.FindAll(item => item.CategoryId == categoryInfo.CategoryId);
                this.dgvCategoryItem.DataSource = objs;
                this.EnableMoveButtonItem();
            }
        }

        private void EnableMoveButtonItem()
        {
            if (!Common.GetIsSuperUser() && (this.dgvCategoryItem.SelectedRows.Count > 0))
            {
                var itemInfo = this.dgvCategoryItem.SelectedRows[0].DataBoundItem as CategoryItemInfo;
                if (itemInfo != null && itemInfo.ConfigFile.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    this.tsbEditItem.Enabled = this.tsbDeleteItem.Enabled = false;
                }
                else
                {
                    this.tsbEditItem.Enabled = this.tsbDeleteItem.Enabled = true;
                }
            }
            if (this.dgvCategoryItem.Rows.Count < 2 || this.dgvCategoryItem.SelectedRows.Count < 1)
            {
                this.tsbDownItem.Enabled = this.tsbUpItem.Enabled = false;
            }
            else
            {
                if (this.dgvCategoryItem.SelectedRows[0].Index == 0)
                {
                    this.tsbDownItem.Enabled = true;
                    this.tsbUpItem.Enabled = false;
                }
                else if (this.dgvCategoryItem.SelectedRows[0].Index == this.dgvCategoryItem.Rows.Count - 1)
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

        private void EnableMoveButtonCategory()
        {
            if (this.dgvCategory.Rows.Count < 2 || this.dgvCategory.SelectedRows.Count < 1)
            {
                this.tsbMoveDown.Enabled = this.tsbMoveUp.Enabled = false;
            }
            else
            {
                if (this.dgvCategory.SelectedRows[0].Index == 0)
                {
                    this.tsbMoveDown.Enabled = true;
                    this.tsbMoveUp.Enabled = false;
                }
                else if (this.dgvCategory.SelectedRows[0].Index == this.dgvCategory.Rows.Count - 1)
                {
                    this.tsbMoveDown.Enabled = false;
                    this.tsbMoveUp.Enabled = true;
                }
                else
                {
                    this.tsbMoveDown.Enabled = this.tsbMoveUp.Enabled = true;
                }
            }
        }
        #endregion

        #region Event Handler
        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            this.tsCategoryItem.Enabled = false;
            if(this.dgvCategory.SelectedRows.Count > 0)
            {
                var entity = this.dgvCategory.SelectedRows[0].DataBoundItem as CategoryInfo;
                if (entity != null)
                {
                    if (Common.CurrentUser.HasRight(entity.RightCode))
                    {
                        this.tsCategoryItem.Enabled = true;
                    }
                }
            }
            this.EnableMoveButtonCategory();
            this.BindCategoryItemGridView();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            if (!Common.CurrentUser.HasRight(Convert.ToInt32(RightType.CategoryManage)))
            {
                this.tsCategory.Enabled = false;
            }
            BindCategoryGridView();
            BindCategoryItemGridView();
            
            this.colIsPublic.Visible = this.colRightCode.Visible =
                this.colClassName.Visible = this.colCode.Visible = Common.GetIsSuperUser();
        }

        private void tsbAddCategory_Click(object sender, EventArgs e)
        {
            var form = new FrmCategoryEdit();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                GlobleVariables.RefreshCategoryList();
                BindCategoryGridView();
                if (this.MdiParent != null)
                {
                    this.MdiParent.GetType().GetMethod("UpdateCategoryMenu").Invoke(this.MdiParent, new object[] { form.CategoryEntity, ActionType.Add });
                }
            }
            form.Dispose();
        }

        private void tsdEditCategory_Click(object sender, EventArgs e)
        {
            if (this.dgvCategory.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择您要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = this.dgvCategory.SelectedRows[0];
            var entity = row.DataBoundItem as CategoryInfo;
            var form = new FrmCategoryEdit(entity);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (this.MdiParent != null)
                {
                    this.MdiParent.GetType().GetMethod("UpdateCategoryMenu").Invoke(this.MdiParent, new object[] { form.CategoryEntity, ActionType.Edit });
                }
            }
            form.Dispose();
        }

        private void tsbDeleteCategory_Click(object sender, EventArgs e)
        {
            if (this.dgvCategory.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择您要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (MessageBox.Show("您确定要删除选中的记录吗？将连同所包含的方案条目一起删除。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var row = this.dgvCategory.SelectedRows[0];
                var entity = row.DataBoundItem as CategoryInfo;
                if (DataProvider.CategoryProvider.Delete(entity.CategoryId))
                {
                    MessageBox.Show("删除成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GlobleVariables.RefreshCategoryList();
                    GlobleVariables.RefreshCategoryItemList();

                    BindCategoryGridView();
                    if (this.MdiParent != null)
                    {
                        this.MdiParent.GetType().GetMethod("UpdateCategoryMenu").Invoke(this.MdiParent, new object[] { entity, ActionType.Delete });
                    }
                }
                else
                {
                    MessageBox.Show("删除失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tsbAddItem_Click(object sender, EventArgs e)
        {
            if (this.dgvCategory.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择新增记录所属的分类。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var categoryInfo = this.dgvCategory.SelectedRows[0].DataBoundItem as CategoryInfo;
            var form = new FrmCategoryItemEdit(categoryInfo);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                BindCategoryItemGridView();
                if (this.MdiParent != null)
                {
                    this.MdiParent.GetType().GetMethod("UpdateCategoryItemMenu").Invoke(this.MdiParent, new object[] { form.CategoryItemEntity, ActionType.Add });
                }
            }
            form.Dispose();
        }

        private void tsbEditItem_Click(object sender, EventArgs e)
        {
            if (this.dgvCategoryItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择您要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                        
            var categoryItemInfo = this.dgvCategoryItem.SelectedRows[0].DataBoundItem as CategoryItemInfo;

            var form = new FrmCategoryItemEdit(categoryItemInfo);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (this.MdiParent != null)
                {
                    this.MdiParent.GetType().GetMethod("UpdateCategoryItemMenu").Invoke(this.MdiParent, new object[] { form.CategoryItemEntity, ActionType.Edit });
                }
            }
            form.Dispose();
        }

        private void tsbDeleteItem_Click(object sender, EventArgs e)
        {
            if (this.dgvCategoryItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择您要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("您确定要删除选中的记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var row = this.dgvCategoryItem.SelectedRows[0];
                var entity = row.DataBoundItem as CategoryItemInfo;
                if (DataProvider.CategoryItemProvider.Delete(entity.ItemId))
                {
                    MessageBox.Show("删除成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindCategoryItemGridView();
                    if (this.MdiParent != null)
                    {
                        this.MdiParent.GetType().GetMethod("UpdateCategoryItemMenu").Invoke(this.MdiParent, new object[] { entity, ActionType.Delete });
                    }
                }
                else
                {
                    MessageBox.Show("删除失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tsbUpItem_Click(object sender, EventArgs e)
        {
            var obj = (CategoryItemInfo)this.dgvCategoryItem.SelectedRows[0].DataBoundItem;
            if (DataProvider.CategoryItemProvider.Move(obj.ItemId, 0))
            {
                lastSelIdx = this.dgvCategoryItem.SelectedRows[0].Index;
                this.BindCategoryItemGridView();
                this.dgvCategoryItem.Rows[lastSelIdx - 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDownItem_Click(object sender, EventArgs e)
        {
            var obj = (CategoryItemInfo)this.dgvCategoryItem.SelectedRows[0].DataBoundItem;
            if (DataProvider.CategoryItemProvider.Move(obj.ItemId, 1))
            {
                lastSelIdx = this.dgvCategoryItem.SelectedRows[0].Index;
                this.BindCategoryItemGridView();
                this.dgvCategoryItem.Rows[lastSelIdx + 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            var obj = (CategoryInfo)this.dgvCategory.SelectedRows[0].DataBoundItem;
            if (DataProvider.CategoryProvider.Move(obj.CategoryId, 0))
            {
                lastSelIdx = this.dgvCategory.SelectedRows[0].Index;
                this.BindCategoryGridView();
                this.dgvCategory.Rows[lastSelIdx - 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            var obj = (CategoryInfo)this.dgvCategory.SelectedRows[0].DataBoundItem;
            if (DataProvider.CategoryProvider.Move(obj.CategoryId, 1))
            {
                lastSelIdx = this.dgvCategory.SelectedRows[0].Index;
                this.BindCategoryGridView();
                this.dgvCategory.Rows[lastSelIdx + 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategoryItem_SelectionChanged(object sender, EventArgs e)
        {
            this.EnableMoveButtonItem();
        }
        #endregion

        

    }
}
