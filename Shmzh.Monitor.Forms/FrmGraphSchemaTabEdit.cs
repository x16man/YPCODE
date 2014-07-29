using System;
using System.Collections;
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
    public partial class FrmGraphSchemaTabEdit : Form
    {

        #region Field
        
        #endregion

        #region property
        /// <summary>
        /// 设置或获取操作类型。
        /// </summary>
        private ActionType ActType { get; set; }
        /// <summary>
        /// 曲线方案对象。
        /// </summary>
        public GraphSchemaInfo SchemaInfo { get; set; }
        /// <summary>
        /// 关联项对象。
        /// </summary>
        public GraphSchemaTabInfo TabInfo { get; set; }
        #endregion

        #region CTOR
        private FrmGraphSchemaTabEdit()
        {
            InitializeComponent();
        }
        public FrmGraphSchemaTabEdit(GraphSchemaInfo schemaInfo, GraphSchemaTabInfo tabInfo): this()
        {
            this.SchemaInfo = schemaInfo;
            this.TabInfo = tabInfo;
            this.ActType = ActionType.Edit;
        }
        public FrmGraphSchemaTabEdit(GraphSchemaInfo schemaInfo):this()
        {
            this.SchemaInfo = schemaInfo;
            this.TabInfo = new GraphSchemaTabInfo();
            this.ActType = ActionType.Add;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 绑定标签类型列表。
        /// </summary>
        public void BindTabType()
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>
                                             {
                                                 new DictionaryEntry("关联指标", Convert.ToByte(TabType.RelativeTag).ToString())
                                             };
            cbTabType.ValueMember = "Value";
            cbTabType.DisplayMember = "Key";
            cbTabType.DataSource = list;
        }

        /// <summary>
        /// 数据绑定。
        /// </summary>
        private void BindData()
        {
            if (this.ActType == ActionType.Add)
            {
                this.Text = "新增关联指标项";
                this.lblScheme.Text = this.SchemaInfo.Name;
            }
            else
            {
                this.Text = "编辑关联指标项";
                this.lblScheme.Text = this.SchemaInfo.Name;
                this.txtTabName.Text = this.TabInfo.TabName;
                this.txtTitle.Text = this.TabInfo.Title;
                this.chkTabVisible.Checked = this.TabInfo.TabVisible;
                this.chkTitleVisible.Checked = this.TabInfo.TitleVisible;
                try
                {
                    this.cbTabType.SelectedValue = this.TabInfo.TabType.ToString();
                }
                catch { }
            }
        }
        /// <summary>
        /// 填充数据体。
        /// </summary>
        private void FillData()
        {
            this.TabInfo.SchemaId = this.SchemaInfo.SchemaId;
            this.TabInfo.TabName = this.txtTabName.Text;
            this.TabInfo.Title = this.txtTitle.Text;
            this.TabInfo.TabVisible = this.chkTabVisible.Checked;
            this.TabInfo.TitleVisible = this.chkTitleVisible.Checked;
        }
        #endregion

        #region Events
        private void FrmGraphSchemaTabEdit_Load(object sender, EventArgs e)
        {
            BindTabType();
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            if (this.txtTabName.Text.Trim().Length == 0)
            {
                isValid = false;
                this.errorProvider1.SetError(this.txtTabName, "请输入标签名。");
            }
            else
            {
                this.errorProvider1.SetError(this.txtTabName, "");
            }

            if (!isValid) return;
            this.FillData();

            switch (ActType)
            {
                case ActionType.Add:
                    var ret = DataProvider.GraphSchemaTabProvider.Insert(this.TabInfo);
                    if (ret > 0)
                    {
                        this.TabInfo.TabId = ret;
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ActionType.Edit:
                    if (DataProvider.GraphSchemaTabProvider.Update(this.TabInfo))
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
