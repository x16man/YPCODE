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
    public partial class FrmGraphSchemaRTagEdit : Form
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
        public GraphSchemaTabInfo SchemaTabInfo { get; set; }
        /// <summary>
        /// 关联项对象。
        /// </summary>
        public GraphSchemaRTagInfo RTagInfo { get; set; }
        #endregion

        #region CTOR
        private FrmGraphSchemaRTagEdit()
        {
            InitializeComponent();
        }
        public FrmGraphSchemaRTagEdit(GraphSchemaTabInfo schemaTabInfo, GraphSchemaRTagInfo rTagInfo)
            : this()
        {
            this.SchemaTabInfo = schemaTabInfo;
            this.RTagInfo = rTagInfo;
            this.ActType = ActionType.Edit;
        }
        public FrmGraphSchemaRTagEdit(GraphSchemaTabInfo schemaTabInfo)
            : this()
        {
            this.SchemaTabInfo = schemaTabInfo;
            RTagInfo = new GraphSchemaRTagInfo();
            this.ActType = ActionType.Add;
        }
        #endregion

        #region private method
        /// <summary>
        /// 数据绑定。
        /// </summary>
        private void BindData()
        {
            if(this.ActType == ActionType.Add)
            {
                this.Text = "新增关联指标项";
                this.lblScheme.Text = this.SchemaTabInfo.TabName;
            }
            else
            {
                this.Text = "编辑关联指标项";
                this.lblScheme.Text = this.SchemaTabInfo.TabName;
                this.txtTagName.Text = this.RTagInfo.TagName;
                this.txtTagId.Text = this.RTagInfo.TagId;
                this.txtUnit.Text = this.RTagInfo.Unit;
                try
                {
                    this.cbDataType.SelectedValue = this.RTagInfo.DataType;
                }
                catch { }
            }
        }
        /// <summary>
        /// 填充数据体。
        /// </summary>
        private void FillData()
        {
            this.RTagInfo.TagName = this.txtTagName.Text;
            this.RTagInfo.TagId = this.txtTagId.Text;
            this.RTagInfo.Unit = this.txtUnit.Text;
            this.RTagInfo.DataType = this.cbDataType.SelectedValue.ToString();
        }
        #endregion

        #region Events

        private void FrmGraphSchemeItemEdit_Load(object sender, EventArgs e)
        {
            Common.BindTagDataType(this.cbDataType, true);
            this.BindData();   
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            if (this.txtTagName.Text.Trim().Length == 0)
            {
                isValid = false;
                this.errorProvider1.SetError(this.txtTagName, "请输入指标名。");
            }
            else
            {
                this.errorProvider1.SetError(this.txtTagName, "");
            }
            if (this.txtTagId.Text.Trim().Length == 0)
            {
                isValid = false;
                this.errorProvider1.SetError(this.txtTagId, "请输入指标。");
            }
            else
            {
                this.errorProvider1.SetError(this.txtTagId, "");
            }

            if (!isValid) return;
            this.FillData();
            
            switch (ActType)
            {
                case ActionType.Add:
                    this.RTagInfo.TabId = this.SchemaTabInfo.TabId;
                    if(DataProvider.GraphSchemaRTagProvider.Insert(this.RTagInfo))
                    {
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "保存出错", "提示",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ActionType.Edit:
                    if (DataProvider.GraphSchemaRTagProvider.Update(this.RTagInfo))
                    {
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("保存出错", "提示",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
