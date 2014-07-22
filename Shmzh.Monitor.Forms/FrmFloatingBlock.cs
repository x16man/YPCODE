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
    public partial class FrmFloatingBlock : Form
    {
        private int lastSelIdx;
        private FrmFloatingBlock()
        {
            InitializeComponent();
            this.dgvBlock.AutoGenerateColumns = false;
            this.dgvBlockItem.AutoGenerateColumns = false;
        }

        public FrmFloatingBlock(GraphSchemaInfo schemaInfo)
            : this()
        {
            SchemaInfo = schemaInfo;
        }


        public GraphSchemaInfo SchemaInfo { get; set; }

        #region Event Handlers
        private void FrmFloatingBlock_Load(object sender, EventArgs e)
        {
            this.BindBlockGridView();
        }

        private void tsbAddBlock_Click(object sender, EventArgs e)
        {
            var form = new FrmFloatingBlockEdit(SchemaInfo);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.BindBlockGridView();
            }
        }

        private void tsbEditBlock_Click(object sender, EventArgs e)
        {
            if (this.dgvBlock.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var blockInfo = (FloatingBlockInfo)this.dgvBlock.SelectedRows[0].DataBoundItem;
            var form = new FrmFloatingBlockEdit(SchemaInfo, blockInfo);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.BindBlockGridView();
            }
        }

        private void tsbDeleteBlock_Click(object sender, EventArgs e)
        {
            if (this.dgvBlock.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("删除浮动窗口会连同浮动窗口所包含的条目一起删除，确定要删除选定的浮动窗口吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var blockInfo = (FloatingBlockInfo)this.dgvBlock.SelectedRows[0].DataBoundItem;
                        DataProvider.FloatingBlockProvider.Delete(blockInfo);
                        this.BindBlockGridView();
                        if (dgvBlock.Rows.Count == 0)
                        {
                            dgvBlockItem.DataSource = new List<Object>();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvBlock_SelectionChanged(object sender, EventArgs e)
        {
            this.BindBlockItemGridView();
        }

        private void tsbAddBlockItem_Click(object sender, EventArgs e)
        {
            if (this.dgvBlock.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择新建项所属的浮动窗口。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var blockInfo = (FloatingBlockInfo)this.dgvBlock.SelectedRows[0].DataBoundItem;

            var form = new FrmFloatingBlockItemEdit(blockInfo);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.BindBlockItemGridView();
            }
        }

        private void tsbEditBlockItem_Click(object sender, EventArgs e)
        {
            if (this.dgvBlockItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var blockInfo = (FloatingBlockInfo)this.dgvBlock.SelectedRows[0].DataBoundItem;
            var blockItemInfo = (FloatingBlockItemInfo)this.dgvBlockItem.SelectedRows[0].DataBoundItem;
            var form = new FrmFloatingBlockItemEdit(blockInfo, blockItemInfo);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.BindBlockItemGridView();
            }
        }

        private void tsbDeleteBlockItem_Click(object sender, EventArgs e)
        {
            if (this.dgvBlockItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("确定要删除选定的记录吗！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var blockItemInfo = (FloatingBlockItemInfo)this.dgvBlockItem.SelectedRows[0].DataBoundItem;
                        DataProvider.FloatingBlockItemProvider.Delete(blockItemInfo);
                        BindBlockItemGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbUpBlockItem_Click(object sender, EventArgs e)
        {
            var obj = (FloatingBlockItemInfo)this.dgvBlockItem.SelectedRows[0].DataBoundItem;
            if (DataProvider.FloatingBlockItemProvider.Move(obj.BlockItemId, 0))
            {
                lastSelIdx = this.dgvBlockItem.SelectedRows[0].Index;
                this.BindBlockItemGridView();
                this.dgvBlockItem.Rows[lastSelIdx - 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDownBlockItem_Click(object sender, EventArgs e)
        {
            var obj = (FloatingBlockItemInfo)this.dgvBlockItem.SelectedRows[0].DataBoundItem;
            if (DataProvider.FloatingBlockItemProvider.Move(obj.BlockItemId, 1))
            {
                lastSelIdx = this.dgvBlockItem.SelectedRows[0].Index;
                this.BindBlockItemGridView();
                this.dgvBlockItem.Rows[lastSelIdx + 1].Selected = true;
            }
            else
            {
                MessageBox.Show("移动失败，请稍候重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBlockItem_SelectionChanged(object sender, EventArgs e)
        {
            this.EnableMoveButtonBlockItem();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 绑定关联项指标列表。
        /// </summary>
        private void BindBlockItemGridView()
        {
            if (dgvBlock.SelectedRows.Count > 0)
            {
                var obj = (FloatingBlockInfo)this.dgvBlock.SelectedRows[0].DataBoundItem;
                var objs = DataProvider.FloatingBlockItemProvider.GetByBlockId(obj.BlockId);
                dgvBlockItem.DataSource = objs;

                for (var i = 0; i < this.dgvBlockItem.Rows.Count; i++)
                {
                    FloatingBlockItemInfo blockItemInfo = (FloatingBlockItemInfo)this.dgvBlockItem.Rows[i].DataBoundItem;
                    dgvBlockItem.Rows[i].Cells[3].Value = Common.GetDataTypeName(blockItemInfo.DataType);
                }
            }
            this.EnableMoveButtonBlockItem();
        }

        /// <summary>
        /// 绑定浮动窗口列表。
        /// </summary>
        private void BindBlockGridView()
        {
            var objs = DataProvider.FloatingBlockProvider.GetBySchemaId(SchemaInfo.SchemaId);
            dgvBlock.DataSource = objs;

            for (var i = 0; i < this.dgvBlock.Rows.Count; i++)
            {
                FloatingBlockInfo blockInfo = (FloatingBlockInfo)this.dgvBlock.Rows[i].DataBoundItem;
                dgvBlock.Rows[i].Cells[0].Style.BackColor = dgvBlock.Rows[i].Cells[0].Style.SelectionBackColor = Color.FromArgb(blockInfo.BorderColor);
                dgvBlock.Rows[i].Cells[1].Style.BackColor = dgvBlock.Rows[i].Cells[1].Style.SelectionBackColor = Color.FromArgb(blockInfo.FillColor);
            }
        }

        private void EnableMoveButtonBlockItem()
        {
            if (this.dgvBlockItem.Rows.Count < 2 || this.dgvBlockItem.SelectedRows.Count < 1)
            {
                this.tsbDownBlockItem.Enabled = this.tsbUpBlockItem.Enabled = false;
            }
            else
            {
                if (this.dgvBlockItem.SelectedRows[0].Index == 0)
                {
                    this.tsbDownBlockItem.Enabled = true;
                    this.tsbUpBlockItem.Enabled = false;
                }
                else if (this.dgvBlockItem.SelectedRows[0].Index == this.dgvBlockItem.Rows.Count - 1)
                {
                    this.tsbDownBlockItem.Enabled = false;
                    this.tsbUpBlockItem.Enabled = true;
                }
                else
                {
                    this.tsbDownBlockItem.Enabled = this.tsbUpBlockItem.Enabled = true;
                }
            }
        }
        #endregion

    }
}
