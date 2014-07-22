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
    public partial class FrmFloatingBlockItemEdit : Form
    {
        #region Constructors
        public FrmFloatingBlockItemEdit()
        {
            InitializeComponent();
        }

        public FrmFloatingBlockItemEdit(FloatingBlockInfo blockInfo)
            : this()
        {
            this.BlockInfo = blockInfo;
            this.BlockItemInfo = new FloatingBlockItemInfo();
            this.ActType = ActionType.Add;
        }

        public FrmFloatingBlockItemEdit(FloatingBlockInfo blockInfo, FloatingBlockItemInfo blockItemInfo)
            : this()
        {
            this.BlockInfo = blockInfo;
            this.BlockItemInfo = blockItemInfo;
            this.ActType = ActionType.Edit;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 设置或获取操作类型。
        /// </summary>
        private ActionType ActType { get; set; }
        /// <summary>
        /// FloatingBlockInfo 对象。
        /// </summary>
        public FloatingBlockInfo BlockInfo { get; set; }
        /// <summary>
        /// FloatingBlockItemInfo 对象。
        /// </summary>
        public FloatingBlockItemInfo BlockItemInfo { get; set; }
        #endregion

        #region Private Methods
        /// <summary>
        /// 数据绑定。
        /// </summary>
        private void BindData()
        {
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            this.cbUnitFontFamily.BeginUpdate();
            this.cbValueFontFamily.BeginUpdate();
            foreach (System.Drawing.FontFamily ff in fonts.Families)
            {
                this.cbUnitFontFamily.Items.Add(ff.Name);
                this.cbValueFontFamily.Items.Add(ff.Name);
            }
            this.cbUnitFontFamily.EndUpdate();
            this.cbValueFontFamily.EndUpdate();

            Common.BindTagDataType(cbDataType, false);

            if (this.ActType == ActionType.Add)
            {
                this.Text = "新增标签项";               
            }
            else
            {
                this.Text = "编辑标签项";
                this.txtLabel.Text = this.BlockItemInfo.Label;
                this.txtTagExp.Text = this.BlockItemInfo.TagExp;
                this.txtUnit.Text = this.BlockItemInfo.Unit;
                
                this.cpValueForeColor.Value = Color.FromArgb(this.BlockItemInfo.ValueForeColor) == Color.Transparent ? Color.Transparent : Color.FromArgb(this.BlockItemInfo.ValueForeColor);
                this.cpUnitForeColor.Value = Color.FromArgb(this.BlockItemInfo.UnitForeColor) == Color.Transparent ? Color.Transparent : Color.FromArgb(this.BlockItemInfo.UnitForeColor);                
            }
            try
            {
                this.cbDataType.SelectedValue = this.BlockItemInfo.DataType;
            }
            catch { }

            this.txtValueFontSize.Text = this.BlockItemInfo.ValueFontSize.ToString();
            this.cbValueFontFamily.SelectedIndex = this.cbValueFontFamily.FindString(this.BlockItemInfo.ValueFontFamily);

            this.txtUnitFontSize.Text = this.BlockItemInfo.UnitFontSize.ToString();
            this.cbUnitFontFamily.SelectedIndex = this.cbUnitFontFamily.FindString(this.BlockItemInfo.UnitFontFamily);
        }

        /// <summary>
        /// 填充数据体。
        /// </summary>
        private void FillData()
        {
            if (this.ActType == ActionType.Add)
            {
                this.BlockItemInfo.BlockId = this.BlockInfo.BlockId;
            }
            this.BlockItemInfo.Label = this.txtLabel.Text.Trim();            
            this.BlockItemInfo.TagExp = this.txtTagExp.Text.Trim();
            this.BlockItemInfo.Unit = this.txtUnit.Text.Trim();
            this.BlockItemInfo.DataType = this.cbDataType.SelectedValue.ToString();
            this.BlockItemInfo.ValueFontSize = Convert.ToSingle(this.txtValueFontSize.Text.Trim());
            this.BlockItemInfo.ValueFontFamily = this.cbValueFontFamily.Text;
            this.BlockItemInfo.ValueForeColor = this.cpValueForeColor.Value.ToArgb();
            this.BlockItemInfo.UnitFontSize = Convert.ToSingle(this.txtUnitFontSize.Text.Trim());
            this.BlockItemInfo.UnitFontFamily = this.cbUnitFontFamily.Text;
            this.BlockItemInfo.UnitForeColor = this.cpUnitForeColor.Value.ToArgb();
        }

        /// <summary>
        /// 验证输入是否是单精度浮点数字。
        /// </summary>
        /// <param name="textBox">输入框。</param>
        /// <param name="label">输入框的标签。</param>
        /// <param name="isRequired">是否必须输入。</param>
        /// <returns></returns>
        private bool ValidSingle(TextBox textBox, String label, bool isRequired)
        {
            bool isValid = true;
            if (textBox.Text.Trim().Length == 0)
            {
                if (isRequired)
                {
                    isValid = false;
                    this.errorProvider1.SetError(textBox, String.Format("{0}不能为空。", label));
                }
            }
            else
            {
                try
                {
                    Single test = float.Parse(textBox.Text.Trim());
                    this.errorProvider1.SetError(textBox, "");
                }
                catch
                {
                    isValid = false;
                    this.errorProvider1.SetError(textBox, String.Format("{0}必须为单精度浮点数字。", label));
                }
            }
            return isValid;
        }
        #endregion

        #region Event Handlers
        private void FrmFloatingBlockItemEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            if (this.txtLabel.Text.Trim().Length == 0)
            {
                isValid = false;
                this.errorProvider1.SetError(this.txtLabel, "请输入标签名。");
            }
            else
            {
                this.errorProvider1.SetError(this.txtLabel, "");
            }
            if (this.txtTagExp.Text.Trim().Length == 0)
            {
                isValid = false;
                this.errorProvider1.SetError(this.txtTagExp, "请输入指标名。");
            }
            else
            {
                this.errorProvider1.SetError(this.txtTagExp, "");
            }
            if (!ValidSingle(this.txtValueFontSize, "值字体大小", true)) isValid = false;
            if (!ValidSingle(this.txtUnitFontSize, "单位字体大小", true)) isValid = false;

            if (!isValid) return;
            FillData();

            switch (ActType)
            {
                case ActionType.Add:
                    if (DataProvider.FloatingBlockItemProvider.Insert(this.BlockItemInfo))
                    {
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ActionType.Edit:
                    if (DataProvider.FloatingBlockItemProvider.Update(this.BlockItemInfo))
                    {
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        

    }
}
