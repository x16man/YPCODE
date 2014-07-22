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
    public partial class FrmFloatingBlockEdit : Form
    {
        public FrmFloatingBlockEdit()
        {
            InitializeComponent();
        }

        public FrmFloatingBlockEdit(GraphSchemaInfo schemaInfo)
            : this()
        {
            SchemaInfo = schemaInfo;
            BlockInfo = new FloatingBlockInfo();
            this.ActType = ActionType.Add;
        }

        public FrmFloatingBlockEdit(GraphSchemaInfo schemaInfo, FloatingBlockInfo blockInfo)
            : this()
        {
            SchemaInfo = schemaInfo;
            BlockInfo = blockInfo;
            this.ActType = ActionType.Edit;
        }


        #region Properties
        /// <summary>
        /// 设置或获取操作类型。
        /// </summary>
        private ActionType ActType { get; set; }
        /// <summary>
        /// 曲线方案对象。
        /// </summary>
        public GraphSchemaInfo SchemaInfo { get; set; }
        /// <summary>
        /// FloatingBlockInfo 对象。
        /// </summary>
        public FloatingBlockInfo BlockInfo { get; set; }
        ///// <summary>
        ///// FloatingBlockItemInfo 对象。
        ///// </summary>
        //public FloatingBlockItemInfo BlockItemInfo { get; set; }
        #endregion

        #region Event Handlers
        private void FrmFloatingBlockEdit_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            if (!ValidSingle(this.txtLableFontSize, "字体大小", true)) isValid = false;
            if (!ValidSingle(this.txtX, "水平位置", true)) isValid = false;
            if (!ValidSingle(this.txtY, "垂直位置", true)) isValid = false;
            if (!ValidSingle(this.txtWidth, "宽度", true)) isValid = false;
            if (!ValidSingle(this.txtHeight, "高度", true)) isValid = false;

            if (!isValid) return;
            this.FillData();
            if (this.ActType == ActionType.Add)
            {
                var ret = DataProvider.FloatingBlockProvider.Insert(BlockInfo);

                if (ret > 0)
                {
                    BlockInfo.BlockId = ret;
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.ActType == ActionType.Edit)
            {
                if (DataProvider.FloatingBlockProvider.Update(BlockInfo))
                {
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkIsAutoSize_CheckedChanged(object sender, EventArgs e)
        {
            this.txtWidth.Enabled = this.txtHeight.Enabled = !this.chkIsAutoSize.Checked;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 数据绑定。
        /// </summary>
        private void BindData()
        {
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            this.cbLableFontFamily.BeginUpdate();
            foreach (System.Drawing.FontFamily ff in fonts.Families)
            {
                this.cbLableFontFamily.Items.Add(ff.Name);
            }
            this.cbLableFontFamily.EndUpdate();

            this.lblScheme.Text = SchemaInfo.Name;
            if (this.ActType == ActionType.Add)
            {
                this.Text = "新增浮动窗口";
            }
            else if (this.ActType == ActionType.Edit)
            {
                this.Text = "编辑浮动窗口";
                this.cpBorderColor.Value = Color.FromArgb(this.BlockInfo.BorderColor);
                this.cpFillColor.Value = Color.FromArgb(this.BlockInfo.FillColor);
                this.cpLableForeColor.Value = Color.FromArgb(this.BlockInfo.LableForeColor);
            }
            this.txtLableFontSize.Text = this.BlockInfo.LableFontSize.ToString();
            this.cbLableFontFamily.SelectedIndex = this.cbLableFontFamily.FindString(this.BlockInfo.LableFontFamily);
            this.txtX.Text = this.BlockInfo.X.ToString();
            this.txtY.Text = this.BlockInfo.Y.ToString();
            this.txtWidth.Text = this.BlockInfo.Width.ToString();
            this.txtHeight.Text = this.BlockInfo.Height.ToString();
            this.chkIsAutoSize.Checked = this.BlockInfo.IsAutoSize;
            this.chkIsLabelInLine.Checked = this.BlockInfo.IsLabelInLine;
        }

        /// <summary>
        /// 填充数据体。
        /// </summary>
        private void FillData()
        {
            if (this.ActType == ActionType.Add)
            {
                this.BlockInfo.SchemaId = this.SchemaInfo.SchemaId;
            }

            this.BlockInfo.BorderColor = this.cpBorderColor.Value.ToArgb();
            this.BlockInfo.FillColor = this.cpFillColor.Value.ToArgb();
            this.BlockInfo.LableFontFamily = this.cbLableFontFamily.Text.Trim();
            this.BlockInfo.LableFontSize = Convert.ToSingle(this.txtLableFontSize.Text.Trim());
            this.BlockInfo.LableForeColor = this.cpLableForeColor.Value.ToArgb();
            this.BlockInfo.X = Convert.ToSingle(this.txtX.Text.Trim());
            this.BlockInfo.Y = Convert.ToSingle(this.txtY.Text.Trim());            
            this.BlockInfo.Width = Convert.ToSingle(this.txtWidth.Text.Trim());
            this.BlockInfo.Height = Convert.ToSingle(this.txtHeight.Text.Trim());
            this.BlockInfo.IsAutoSize = this.chkIsAutoSize.Checked;
            this.BlockInfo.IsLabelInLine = this.chkIsLabelInLine.Checked;
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

    }
}
