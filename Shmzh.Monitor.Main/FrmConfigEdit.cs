using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shmzh.Monitor.Main
{
    public partial class FrmConfigEdit : Form
    {
        private ConfigInfo.ItemInfo _itemInfo;
        public FrmConfigEdit()
        {
            InitializeComponent();
        }

        public FrmConfigEdit(ConfigInfo.ItemInfo itemInfo)
            : this()
        {
            this._itemInfo = itemInfo;
        }

        public ConfigInfo.ItemInfo ItemInfo 
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

        private void FrmConfigEdit_Load(object sender, EventArgs e)
        {
            if (ItemInfo == null)
            {
                this.Text = "新增配置条目";
            }
            else
            {
                this.Text = "编辑配置条目";
                this.txtTitle.Text = ItemInfo.Title;
                this.txtShowTime.Text = ItemInfo.ShowTime.ToString();
                this.txtUpdateTime.Text = ItemInfo.UpdateTime.ToString();
                this.chkVisible.Checked = ItemInfo.Visible;
                this.txtClassName.Text = ItemInfo.ClassName;
                this.txtConfigFile.Text = ItemInfo.ConfigFile;
            }
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
                this.errorProvider1.SetError(this.txtTitle, "标题不能为空。");
                isValid = false;
            }
            else 
            {
                this.errorProvider1.SetError(this.txtTitle, "");
            }

            int showTime;
            if (int.TryParse(this.txtShowTime.Text.Trim(), out showTime))
            {
                if (showTime < 0)
                {
                    this.errorProvider1.SetError(this.txtShowTime, "显示时间必须为不小于零的整数。");
                    isValid = false;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtShowTime, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(this.txtShowTime, "显示时间必须为不小于零的整数。");
                isValid = false;
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

            if (this.txtClassName.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(this.txtClassName, "ClassName 不能为空。");
                isValid = false;
            }
            else
            {
                this.errorProvider1.SetError(this.txtClassName, "");
            }

            if (this.txtConfigFile.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(this.txtConfigFile, "ConfigFile 不能为空。");
                isValid = false;
            }
            else
            {
                this.errorProvider1.SetError(this.txtConfigFile, "");
            }

            if (!isValid)
                return;

            if (ItemInfo == null)
            {
                ItemInfo = new ConfigInfo.ItemInfo();
            }
            ItemInfo.Title = this.txtTitle.Text.Trim();
            ItemInfo.ShowTime = Convert.ToInt32(this.txtShowTime.Text.Trim());
            ItemInfo.UpdateTime = Convert.ToInt32(this.txtUpdateTime.Text.Trim());
            ItemInfo.Visible = this.chkVisible.Checked;
            ItemInfo.ClassName = this.txtClassName.Text.Trim();
            ItemInfo.ConfigFile = this.txtConfigFile.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}
