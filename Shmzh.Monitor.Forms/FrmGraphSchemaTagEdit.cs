using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmGraphSchemaTagEdit : Form
    {
        #region property
        /// <summary>
        /// 设置或获取操作类型。
        /// </summary>
        private ActionType ActType { get; set; }
        /// <summary>
        /// 曲线方案项对象。
        /// </summary>
        public GraphSchemaItemInfo SchemaItemInfo { get; set; }
        /// <summary>
        /// 曲线方案指标项对象。
        /// </summary>
        public GraphSchemaTagInfo SchemaTagInfo { get; set; }
        #endregion

        #region CTOR
        private FrmGraphSchemaTagEdit()
        {
            InitializeComponent();
        }
        public FrmGraphSchemaTagEdit(GraphSchemaItemInfo obj):this()
        {
            this.SchemaItemInfo = obj;
            this.SchemaTagInfo = new GraphSchemaTagInfo();
            this.ActType = ActionType.Add;

        }
        public FrmGraphSchemaTagEdit(GraphSchemaTagInfo obj):this()
        {
            this.SchemaTagInfo = obj;
            this.SchemaItemInfo = GlobleVariables.GraphSchemaItemList.Find(item => item.ItemId == obj.ItemId);
            //this.SchemaItemInfo = DataProvider.GraphSchemaItemProvider.GetById(obj.ItemId);
            this.ActType = ActionType.Edit;
        }
        #endregion

        #region private method
        /// <summary>
        /// 数据绑定。
        /// </summary>
        private void BindData()
        {
            if (this.ActType == ActionType.Add)
            {
                this.Text = "新增方案指标项";
                this.lblSchemeItem.Text = this.SchemaItemInfo.Title;
            }
            else
            {
                this.Text = "编辑方案指标项";
                this.SchemaItemInfo = DataProvider.GraphSchemaItemProvider.GetById(this.SchemaTagInfo.ItemId);
                this.lblSchemeItem.Text = this.SchemaItemInfo.Title;
                this.txtTagId.Text = this.SchemaTagInfo.TagId;
                this.txtTagName.Text = this.SchemaTagInfo.TagName;
                this.cbCurveType.SelectedValue = this.SchemaTagInfo.CurveType;
                this.cp_CurveColor.Value = Color.FromArgb(this.SchemaTagInfo.CurveColor);
                this.txtLineWidth.Text = this.SchemaTagInfo.LineWidth.ToString();
                this.cbSymbolType.SelectedValue = this.SchemaTagInfo.SymbolType;                
                this.txtPeriod.Text = this.SchemaTagInfo.MAPeriod.ToString();
                this.cp_SymbolColor.Value = Color.FromArgb(this.SchemaTagInfo.SymbolColor);
            }
            this.cbLineType.SelectedValue = (int)this.SchemaTagInfo.LineType;
            this.txtSymbolSize.Text = this.SchemaTagInfo.SymbolSize.ToString();
        }
        /// <summary>
        /// 填充数据体。
        /// </summary>
        private void FillData()
        {
            this.SchemaTagInfo.ItemId = this.SchemaItemInfo.ItemId;
            this.SchemaTagInfo.TagId = this.txtTagId.Text;
            this.SchemaTagInfo.TagName = this.txtTagName.Text;
            this.SchemaTagInfo.CurveType = this.cbCurveType.SelectedValue.ToString();
            this.SchemaTagInfo.CurveColor = this.cp_CurveColor.Value.ToArgb();
            this.SchemaTagInfo.LineWidth = this.txtLineWidth.Text.Trim().Length > 0 ? Convert.ToSingle(this.txtLineWidth.Text.Trim()) : 1;
            this.SchemaTagInfo.SymbolType = this.cbSymbolType.SelectedValue.ToString();
            this.SchemaTagInfo.SymbolSize = this.txtSymbolSize.Text.Trim().Length > 0 ? Convert.ToSingle(this.txtSymbolSize.Text.Trim()) : 3;
            this.SchemaTagInfo.MAPeriod = this.txtPeriod.Text.Trim().Length > 0 ? Convert.ToInt32(this.txtPeriod.Text.Trim()) : 0;
            this.SchemaTagInfo.LineType = Convert.ToByte(this.cbLineType.SelectedValue);
            this.SchemaTagInfo.SymbolColor = this.cp_SymbolColor.Value.ToArgb();
        }

        /// <summary>
        /// 绑定节点标记。
        /// </summary>
        private void BindSymbolType()
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>() { new DictionaryEntry("None", "None"),
                new DictionaryEntry("Default","Default"),
                new DictionaryEntry("Square","Square"),
                new DictionaryEntry("Diamond","Diamond"),
                new DictionaryEntry("Triangle","Triangle"),
                new DictionaryEntry("Circle","Circle"),
                new DictionaryEntry("XCross","XCross"),
                new DictionaryEntry("Plus","Plus"),
                new DictionaryEntry("Star","Star"),
                new DictionaryEntry("TriangleDown","TriangleDown"),
                new DictionaryEntry("HDash","HDash"),
                new DictionaryEntry("VDash","VDash")
            };
            this.cbSymbolType.ValueMember = "Value";
            this.cbSymbolType.DisplayMember = "Key";
            this.cbSymbolType.DataSource = list;
        }

        /// <summary>
        /// 绑定曲线样式。
        /// </summary>
        private void BindLineType()
        {
            List<DictionaryEntry> list = new List<DictionaryEntry>(){
                new DictionaryEntry("散点", 0),
                new DictionaryEntry("折线", 1),
                new DictionaryEntry("平滑曲线", 2),
            };
            this.cbLineType.ValueMember = "Value";
            this.cbLineType.DisplayMember = "Key";
            this.cbLineType.DataSource = list;
        }
               
        #endregion

        #region Event
        private void FrmGraphSchemaTagEdit_Load(object sender, EventArgs e)
        {
            Common.BindCurveType(this.cbCurveType);
            BindSymbolType();
            BindLineType();
            this.BindData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            #region 输入验证。    
            if (this.txtTagId.Text.Trim().Length == 0)
            {
                isValid = false;
                this.errorProvider1.SetError(this.txtTagId, "请输入指标Id。");
            }
            else
            {
                this.errorProvider1.SetError(this.txtTagId, "");
            }
            if (this.txtTagName.Text.Trim().Length == 0)
            {
                isValid = false;
                this.errorProvider1.SetError(this.txtTagName, "请输入指标名称。");
            }
            else
            {
                this.errorProvider1.SetError(this.txtTagName, "");
            }

            if (this.panelLineWidth.Enabled)
            {
                if(this.txtLineWidth.Text.Trim().Length == 0)
                {
                    isValid = false;
                    this.errorProvider1.SetError(this.txtLineWidth, "请输入线宽。");
                }
                else
                {
                    try
                    {
                        var f = Single.Parse(this.txtLineWidth.Text.Trim());
                        this.errorProvider1.SetError(this.txtLineWidth, "");
                    }
                    catch
                    {
                        isValid = false;
                        this.errorProvider1.SetError(this.txtLineWidth, "输入线宽有误。");
                    }
                }

                if (this.txtSymbolSize.Text.Trim().Length == 0)
                {
                    isValid = false;
                    this.errorProvider1.SetError(this.txtSymbolSize, "请输入节点标记大小。");
                }
                else
                {
                    try
                    {
                        var f = Single.Parse(this.txtSymbolSize.Text.Trim());
                        this.errorProvider1.SetError(this.txtSymbolSize, "");
                    }
                    catch
                    {
                        isValid = false;
                        this.errorProvider1.SetError(this.txtSymbolSize, "输入节点标记大小有误。");
                    }
                }
            }

            if (this.txtPeriod.Enabled)
            {
                if (this.txtPeriod.Text.Trim().Length == 0)
                {
                    isValid = false;
                    this.errorProvider1.SetError(this.txtPeriod, "请输入周期。");
                }
                else
                {
                    try
                    {
                        var tempPeriod = Int32.Parse(this.txtPeriod.Text.Trim());
                        if (tempPeriod < 3 || tempPeriod > 30)
                        {
                            isValid = false;
                            this.errorProvider1.SetError(this.txtPeriod, "周期必须是3~30之间的整数。");
                        }
                        else
                        {
                            this.errorProvider1.SetError(this.txtPeriod, "");
                        }
                    }
                    catch
                    {
                        isValid = false;
                        this.errorProvider1.SetError(this.txtPeriod, "周期必须是3~30之间的整数。");
                    }
                }
            }
            #endregion
            if (!isValid) return;
            this.FillData();

            switch (ActType)
            {
                case ActionType.Add:
                    if (DataProvider.GraphSchemaTagProvider.Insert(this.SchemaTagInfo))
                    {
                        GlobleVariables.GraphSchemaTagList.Add(this.SchemaTagInfo);
                        if (DataProvider.GraphSchemaProvider.UpdateLoginName(this.SchemaItemInfo.SchemaId, Common.CurrentUser.LoginName))
                        {
                            //MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ActionType.Edit:
                    if (DataProvider.GraphSchemaTagProvider.Update(this.SchemaTagInfo))
                    {
                        if (DataProvider.GraphSchemaProvider.UpdateLoginName(this.SchemaItemInfo.SchemaId, Common.CurrentUser.LoginName))
                        {
                            //MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void cbCurveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbCurveType.SelectedValue.ToString())
            {
                case "Curve":
                    this.panelLineWidth.Enabled = true;
                    this.panelPeriod.Enabled = false;
                    break;
                case "CurveMA":
                    this.panelPeriod.Enabled = true;
                    this.panelLineWidth.Enabled = true;
                    break;
                case "Bar":                
                case "JapaneseCandleStick":                
                    this.panelLineWidth.Enabled = false;
                    this.panelPeriod.Enabled = false;
                    break;
                default:
                    this.panelLineWidth.Enabled = false;
                    this.panelPeriod.Enabled = false;
                    break;
            }
        }
    }
}
