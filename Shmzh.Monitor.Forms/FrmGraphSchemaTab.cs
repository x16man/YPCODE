using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmGraphSchemaTab : Form
    {
        private Int32 lastSelIdx;

        #region CTOR
        public FrmGraphSchemaTab()
        {
            InitializeComponent();
            this.gvTab.AutoGenerateColumns = false;
            this.gvRTag.AutoGenerateColumns = false;
        }
       
        public FrmGraphSchemaTab(GraphSchemaInfo schemaInfo):this()
        {
            SchemaInfo = schemaInfo;
        }
        #endregion

        #region Properties
        GraphSchemaInfo SchemaInfo { get; set; }
        #endregion

        #region Private Methods
        /// <summary>
        /// 绑定关联项指标列表。
        /// </summary>
        private void BindRTagGridView()
        {
            if (gvTab.SelectedRows.Count > 0)
            {
                var obj = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
                var objs = DataProvider.GraphSchemaRTagProvider.GetByTabId(obj.TabId);
                gvRTag.DataSource = objs;
            }
            this.EnableMoveButtonRTag();
        }

        /// <summary>
        /// 绑定关联项列表。
        /// </summary>
        private void BindTabGridView()
        {
            var objs = DataProvider.GraphSchemaTabProvider.GetBySchemaId(SchemaInfo.SchemaId);
            gvTab.DataSource = objs;
            this.EnableMoveButtonTab();
        }

        private void EnableMoveButtonRTag()
        {
            if (this.gvRTag.Rows.Count < 2 || this.gvRTag.SelectedRows.Count < 1)
            {
                this.tsDownRTag.Enabled = this.tsUpRTag.Enabled = false;
            }
            else
            {
                if (this.gvRTag.SelectedRows[0].Index == 0)
                {
                    this.tsDownRTag.Enabled = true;
                    this.tsUpRTag.Enabled = false;
                }
                else if (this.gvRTag.SelectedRows[0].Index == this.gvRTag.Rows.Count - 1)
                {
                    this.tsDownRTag.Enabled = false;
                    this.tsUpRTag.Enabled = true;
                }
                else
                {
                    this.tsDownRTag.Enabled = this.tsUpRTag.Enabled = true;
                }
            }
        }

        private void EnableMoveButtonTab()
        {
            if (this.gvTab.Rows.Count < 2 || this.gvTab.SelectedRows.Count < 1)
            {
                this.tsDownTab.Enabled = this.tsUpTab.Enabled = false;
            }
            else
            {
                if (this.gvTab.SelectedRows[0].Index == 0)
                {
                    this.tsDownTab.Enabled = true;
                    this.tsUpTab.Enabled = false;
                }
                else if (this.gvTab.SelectedRows[0].Index == this.gvTab.Rows.Count - 1)
                {
                    this.tsDownTab.Enabled = false;
                    this.tsUpTab.Enabled = true;
                }
                else
                {
                    this.tsDownTab.Enabled = this.tsUpTab.Enabled = true;
                }
            }
        }
        #endregion

        #region Events
        private void FrmGraphSchemaRTag_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("{0}--关联指标项", SchemaInfo.Name);
            BindTabGridView();
            BindRTagGridView();
        }

        #region Tab
        //private void btnAddTab_Click(object sender, EventArgs e)
        //{
        //    var frmGraphSchemaTabEdit = new FrmGraphSchemaTabEdit(SchemaInfo);

        //    if (frmGraphSchemaTabEdit.ShowDialog(this) == DialogResult.OK)
        //    {
        //        this.BindTabGridView();
        //    }
        //}

        //private void btnEditTab_Click(object sender, EventArgs e)
        //{
        //    if (this.gvTab.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("请选择要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    var tagInfo = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
        //    var frmGraphSchemaTabEdit = new FrmGraphSchemaTabEdit(SchemaInfo, tagInfo);

        //    if (frmGraphSchemaTabEdit.ShowDialog(this) == DialogResult.OK)
        //    {
        //        this.BindTabGridView();
        //    }
        //}

        //private void btnDelTab_Click(object sender, EventArgs e)
        //{
        //    if (this.gvTab.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("请选择要删除的标签。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    else
        //    {
        //        if (MessageBox.Show("删除标签会连同标签所包含的指标一起删除，确定要删除选定的标签吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            try
        //            {
        //                var tagInfo = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
        //                DataProvider.GraphSchemaTabProvider.Delete(tagInfo);
        //                BindTabGridView();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}

        

        //private void btnMoveUpTab_Click(object sender, EventArgs e)
        //{
        //    var obj = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
        //    if (DataProvider.GraphSchemaTabProvider.Move(obj.TabId, 0))
        //    {
        //        lastSelIdx = this.gvTab.SelectedRows[0].Index;
        //        this.BindTabGridView();
        //        this.gvTab.Rows[lastSelIdx - 1].Selected = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnMoveDownTab_Click(object sender, EventArgs e)
        //{
        //    var obj = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
        //    if (DataProvider.GraphSchemaTabProvider.Move(obj.TabId, 1))
        //    {
        //        lastSelIdx = this.gvTab.SelectedRows[0].Index;
        //        this.BindTabGridView();
        //        this.gvTab.Rows[lastSelIdx + 1].Selected = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void gvTab_SelectionChanged(object sender, EventArgs e)
        {
            EnableMoveButtonTab();
            BindRTagGridView();
        }

        private void tsUpTab_Click(object sender, EventArgs e)
        {
            var obj = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
            if (DataProvider.GraphSchemaTabProvider.Move(obj.TabId, 0))
            {
                lastSelIdx = this.gvTab.SelectedRows[0].Index;
                this.BindTabGridView();
                this.gvTab.Rows[lastSelIdx - 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsDownTab_Click(object sender, EventArgs e)
        {
            var obj = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
            if (DataProvider.GraphSchemaTabProvider.Move(obj.TabId, 1))
            {
                lastSelIdx = this.gvTab.SelectedRows[0].Index;
                this.BindTabGridView();
                this.gvTab.Rows[lastSelIdx + 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsAddTab_Click(object sender, EventArgs e)
        {
            var frmGraphSchemaTabEdit = new FrmGraphSchemaTabEdit(SchemaInfo);

            if (frmGraphSchemaTabEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.BindTabGridView();
            }
        }

        private void tsEditTab_Click(object sender, EventArgs e)
        {
            if (this.gvTab.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var tagInfo = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
            var frmGraphSchemaTabEdit = new FrmGraphSchemaTabEdit(SchemaInfo, tagInfo);

            if (frmGraphSchemaTabEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.BindTabGridView();
            }
        }

        private void tsDeleteTab_Click(object sender, EventArgs e)
        {
            if (this.gvTab.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的标签。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("删除标签会连同标签所包含的指标一起删除，确定要删除选定的标签吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var tagInfo = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
                        DataProvider.GraphSchemaTabProvider.Delete(tagInfo);
                        BindTabGridView();
                        if (gvTab.Rows.Count == 0)
                        {
                            gvRTag.DataSource = new List<Object>();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region RTag
        //private void btnAddRTag_Click(object sender, EventArgs e)
        //{
        //    if (this.gvTab.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("请选择新建项所属的标签。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    var tabInfo = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;

        //    var frmGraphSchemaRTagEdit = new FrmGraphSchemaRTagEdit(tabInfo);

        //    if (frmGraphSchemaRTagEdit.ShowDialog(this) == DialogResult.OK)
        //    {
        //        this.BindRTagGridView();
        //    }
        //}

        //private void btnEditRTag_Click(object sender, EventArgs e)
        //{
        //    if (this.gvRTag.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("请选择要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    var tabInfo = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
        //    var rTagInfo = (GraphSchemaRTagInfo)this.gvRTag.SelectedRows[0].DataBoundItem;
        //    var frmGraphSchemaRTagEdit = new FrmGraphSchemaRTagEdit(tabInfo, rTagInfo);

        //    if (frmGraphSchemaRTagEdit.ShowDialog(this) == DialogResult.OK)
        //    {
        //        this.BindRTagGridView();
        //    }
        //}

        //private void btnDelRTag_Click(object sender, EventArgs e)
        //{
        //    if (this.gvRTag.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("请选择要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    else
        //    {
        //        if (MessageBox.Show("确定要删除选定的记录吗！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            try
        //            {
        //                var rTagInfo = (GraphSchemaRTagInfo)this.gvRTag.SelectedRows[0].DataBoundItem;
        //                DataProvider.GraphSchemaRTagProvider.Delete(rTagInfo);
        //                BindRTagGridView();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}

        //private void btnMoveUp_Click(object sender, EventArgs e)
        //{
        //    var obj = (GraphSchemaRTagInfo)this.gvRTag.SelectedRows[0].DataBoundItem;
        //    if (DataProvider.GraphSchemaRTagProvider.Move(obj.RTagId, 0))
        //    {
        //        lastSelIdx = this.gvRTag.SelectedRows[0].Index;
        //        this.BindRTagGridView();
        //        this.gvRTag.Rows[lastSelIdx - 1].Selected = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnMoveDown_Click(object sender, EventArgs e)
        //{
        //    var obj = (GraphSchemaRTagInfo)this.gvRTag.SelectedRows[0].DataBoundItem;
        //    if (DataProvider.GraphSchemaRTagProvider.Move(obj.RTagId, 1))
        //    {
        //        lastSelIdx = this.gvRTag.SelectedRows[0].Index;
        //        this.BindRTagGridView();
        //        this.gvRTag.Rows[lastSelIdx + 1].Selected = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void gvRTag_SelectionChanged(object sender, EventArgs e)
        {
            EnableMoveButtonRTag();
        }
        #endregion

        private void tsUpRTag_Click(object sender, EventArgs e)
        {
            var obj = (GraphSchemaRTagInfo)this.gvRTag.SelectedRows[0].DataBoundItem;
            if (DataProvider.GraphSchemaRTagProvider.Move(obj.RTagId, 0))
            {
                lastSelIdx = this.gvRTag.SelectedRows[0].Index;
                this.BindRTagGridView();
                this.gvRTag.Rows[lastSelIdx - 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsDownRTag_Click(object sender, EventArgs e)
        {
            var obj = (GraphSchemaRTagInfo)this.gvRTag.SelectedRows[0].DataBoundItem;
            if (DataProvider.GraphSchemaRTagProvider.Move(obj.RTagId, 1))
            {
                lastSelIdx = this.gvRTag.SelectedRows[0].Index;
                this.BindRTagGridView();
                this.gvRTag.Rows[lastSelIdx + 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsAddRTag_Click(object sender, EventArgs e)
        {
            if (this.gvTab.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择新建项所属的标签。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var tabInfo = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;

            var frmGraphSchemaRTagEdit = new FrmGraphSchemaRTagEdit(tabInfo);

            if (frmGraphSchemaRTagEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.BindRTagGridView();
            }
        }

        private void tsEditRTag_Click(object sender, EventArgs e)
        {
            if (this.gvRTag.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var tabInfo = (GraphSchemaTabInfo)this.gvTab.SelectedRows[0].DataBoundItem;
            var rTagInfo = (GraphSchemaRTagInfo)this.gvRTag.SelectedRows[0].DataBoundItem;
            var frmGraphSchemaRTagEdit = new FrmGraphSchemaRTagEdit(tabInfo, rTagInfo);

            if (frmGraphSchemaRTagEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.BindRTagGridView();
            }
        }

        private void tsDeleteRTag_Click(object sender, EventArgs e)
        {
            if (this.gvRTag.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("确定要删除选定的记录吗！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var rTagInfo = (GraphSchemaRTagInfo)this.gvRTag.SelectedRows[0].DataBoundItem;
                        DataProvider.GraphSchemaRTagProvider.Delete(rTagInfo);
                        BindRTagGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        #endregion
                
    }
}
