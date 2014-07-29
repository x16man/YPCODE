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
    public partial class FrmTagCategoryEdit : Form
    {
        public FrmTagCategoryEdit()
        {
            InitializeComponent();
        }

        public FrmTagCategoryEdit(ActionType actType) : this()
        {
            ActType = actType;
        }
        #region Properties
        public ActionType ActType { get; set; }
        public TagCategoryInfo TagCategoryEntity { get; set; }
        #endregion

        #region Event Handlers
        private void FrmTagCategoryEdit_Load(object sender, EventArgs e)
        {
            if (ActType == ActionType.Add)
            {
                if (TagCategoryEntity == null)
                {
                    this.Text = "新建根类别";
                }
                else
                {
                    this.Text = "新建子类别";
                }
            }
            else
            {
                if (ActType == ActionType.Edit)
                {
                    this.Text = "编辑类别";
                    this.txtCategoryName.Text = this.TagCategoryEntity.CategoryName;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtCategoryName.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(this.txtCategoryName, "必须输入类别名。");
                return;
            }
            else
            {
                this.errorProvider1.SetError(this.txtCategoryName, "");
            }
            
            if (ActType == ActionType.Add)
            {
                TagCategoryInfo entity = new TagCategoryInfo();
                entity.CategoryName = this.txtCategoryName.Text.Trim();
                entity.ParentId = TagCategoryEntity == null ? -1 : TagCategoryEntity.CategoryId;
                var ret = DataProvider.TagCategoryProvider.Insert(entity);
                if ( ret > 0)
                {
                    entity.CategoryId = ret;
                    TagCategoryEntity = entity;
                    MessageBox.Show("新建成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("新建失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (ActType == ActionType.Edit)
            {
                TagCategoryEntity.CategoryName = this.txtCategoryName.Text.Trim();
                if (DataProvider.TagCategoryProvider.Update(TagCategoryEntity))
                {
                    MessageBox.Show("更新成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("更新失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
