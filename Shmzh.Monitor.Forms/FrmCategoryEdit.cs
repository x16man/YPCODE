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
    public partial class FrmCategoryEdit : Form
    {
        #region Constructors
        public FrmCategoryEdit()
        {
            InitializeComponent();
        }

        public FrmCategoryEdit(CategoryInfo categoryInfo) : this()
        {
            this.CategoryEntity = categoryInfo;
        }

        #endregion

        #region Properties
        public CategoryInfo CategoryEntity { get; set; }
        public ActionType ActType { get; set; }
        #endregion

        #region Event Handlers
        private void FrmCategoryEdit_Load(object sender, EventArgs e)
        {
            if (this.CategoryEntity == null)
            {
                this.ActType = ActionType.Add;
                this.Text = "新增方案类别";
                this.CategoryEntity = new CategoryInfo();
            }
            else
            {
                this.ActType = ActionType.Edit;
                this.Text = "编辑方案类别";
            }
            this.txtCategoryName.Text = this.CategoryEntity.CategoryName;
            this.txtRemark.Text = this.CategoryEntity.Remark;
            this.txtRightCode.Text = this.CategoryEntity.RightCode.ToString();
            this.chkIsPublic.Checked = this.CategoryEntity.IsPublic;
            //this.lblRightCode.Visible = this.txtRightCode.Visible = this.chkIsPublic.Visible = Common.GetIsSuperUser();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (txtCategoryName.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(lblCategoryName, "方案类别名称不能为空。");
                isValid = false;
            }
            else
            {
                this.errorProvider1.SetError(lblCategoryName, "");
            }

            short rightCode;
            if (short.TryParse(this.txtRightCode.Text.Trim(), out rightCode))
            {
                if (rightCode < 0)
                {
                    this.errorProvider1.SetError(this.txtRightCode, "权限码必须为不小于零的短整数。");
                    isValid = false;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtRightCode, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(this.txtRightCode, "权限码必须为不小于零的短整数。");
                isValid = false;
            }
            if (!isValid)
                return;

            this.CategoryEntity.CategoryName = this.txtCategoryName.Text.Trim();
            this.CategoryEntity.Remark = this.txtRemark.Text.Trim();
            this.CategoryEntity.RightCode = Convert.ToInt16(this.txtRightCode.Text.Trim());
            this.CategoryEntity.IsPublic = this.chkIsPublic.Checked;
            if (this.ActType == ActionType.Edit)
            {
                if (DataProvider.CategoryProvider.Update(this.CategoryEntity))
                {
                    MessageBox.Show("修改成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.ActType == ActionType.Add)
            {
                var ret = DataProvider.CategoryProvider.Insert(this.CategoryEntity); 
                if (ret >0)
                {
                    this.CategoryEntity.CategoryId = ret;
                    MessageBox.Show("新增成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("新增失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
               
        #endregion

    }
}
