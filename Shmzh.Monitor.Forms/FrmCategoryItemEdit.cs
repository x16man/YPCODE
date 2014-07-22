using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmCategoryItemEdit : Form
    {
        #region Constructors
        private FrmCategoryItemEdit()
        {
            InitializeComponent();
        }

        public FrmCategoryItemEdit(CategoryInfo categoryInfo)
            : this()
        {
            this.CategoryEntity = categoryInfo;
        }

        public FrmCategoryItemEdit(CategoryItemInfo categoryItemInfo)
            : this()
        {
            this.CategoryItemEntity = categoryItemInfo;
        }
        #endregion

        #region Properties
        public CategoryInfo CategoryEntity { get; set; }
        public CategoryItemInfo CategoryItemEntity { get; set; }
        public ActionType ActType { get; set; }
        #endregion

        #region Event Handlers
        private void FrmCategoryItemEdit_Load(object sender, EventArgs e)
        {
            //BindConfigFile();
            if (this.CategoryItemEntity == null)
            {
                this.ActType = ActionType.Add;
                this.Text = "新增方案类别项";
                this.CategoryItemEntity = new CategoryItemInfo();
                this.cbClassName.SelectedIndex = 0;
            }
            else
            {
                this.ActType = ActionType.Edit;
                this.Text = "编辑方案类别项";
                this.cbClassName.Text = this.CategoryItemEntity.ClassName;
                this.txtConfigFile.Text = this.CategoryItemEntity.ConfigFile;
                this.txtCode.Text = this.CategoryItemEntity.Code;
            }
            this.txtTitle.Text = this.CategoryItemEntity.Title;
            this.txtUpdateTime.Text = this.CategoryItemEntity.UpdateTime.ToString();

            this.lblCode.Visible = this.txtCode.Visible = 
                this.lblClassName.Visible = this.cbClassName.Visible =
                Common.GetIsSuperUser();           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (this.txtTitle.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtTitle, "标题不能为空。");
                isValid = false;
            }
            else
            {
                this.errorProvider1.SetError(txtTitle, "");
            }

            int updateTime;
            if (int.TryParse(this.txtUpdateTime.Text.Trim(), out updateTime))
            {
                if (updateTime < 0)
                {
                    this.errorProvider1.SetError(this.txtUpdateTime, "更新时间必须为不小于零的整数。");
                    isValid = false;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtUpdateTime, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(this.txtUpdateTime, "更新时间必须为不小于零的整数。");
                isValid = false;
            }

            this.errorProvider1.SetError(this.txtCode, "");
            if (this.txtCode.Text.Trim().Length > 0)
            {
                var itemInfo = DataProvider.CategoryItemProvider.GetByCode(this.txtCode.Text.Trim());
                if (itemInfo != null)
                {
                    if (this.ActType == ActionType.Add || (this.ActType == ActionType.Edit && itemInfo.ItemId != this.CategoryItemEntity.ItemId))
                    {
                        this.errorProvider1.SetError(this.txtCode, "编号不允许有重复，请重新输入。");
                        isValid = false;
                    }
                }
            }

            if (this.cbClassName.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(cbClassName, "ClassName不能为空。");
                isValid = false;
            }
            else
            {
                this.errorProvider1.SetError(cbClassName, "");
            }

            if (this.txtConfigFile.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(this.btnSelect, "方案不能为空。");
                isValid = false;
            }
            else
            {
                this.errorProvider1.SetError(this.btnSelect, "");
            }

            if (!isValid)
                return;
            
            this.CategoryItemEntity.Title = this.txtTitle.Text.Trim();
            this.CategoryItemEntity.UpdateTime = Convert.ToInt32(this.txtUpdateTime.Text.Trim());
            this.CategoryItemEntity.ClassName = this.cbClassName.Text;
            this.CategoryItemEntity.ConfigFile = this.txtConfigFile.Text.Trim();
            this.CategoryItemEntity.Code = this.txtCode.Text.Trim();

            if (this.ActType == ActionType.Edit)
            {
                if (DataProvider.CategoryItemProvider.Update(this.CategoryItemEntity))
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
                this.CategoryItemEntity.CategoryId = CategoryEntity.CategoryId;
                var ret = DataProvider.CategoryItemProvider.Insert(this.CategoryItemEntity);
                if (ret > 0)
                {
                    this.CategoryItemEntity.ItemId = ret;
                    GlobleVariables.CategoryItemList.Add(this.CategoryItemEntity);
                    MessageBox.Show("新增成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("新增失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FrmSchemaPicker form = new FrmSchemaPicker();
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.txtConfigFile.Text = form.ConfigFile;
            }
            form.Dispose();
        }

        #endregion
    }
}
