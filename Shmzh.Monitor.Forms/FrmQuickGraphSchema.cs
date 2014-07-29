using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;
using ZedGraph;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmQuickGraphSchema : Form
    {
        private Form _mdiParent = null;

        public FrmQuickGraphSchema()
        {
            InitializeComponent();
        }

        public FrmQuickGraphSchema(Form mdiParent):this()
        {
            this._mdiParent = mdiParent;
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
            this.cbLineType.SelectedIndex = 2;
        }

        private void FrmQuickGraphSchema_Load(object sender, EventArgs e)
        {
            Common.BindCurveType(this.cbCurveType);
            this.cbCurveType.SelectedIndex = 1;
            BindLineType();
        }

        private void btnSelectTas_Click(object sender, EventArgs e)
        {
            List<TagInfo> list;
            if (this.cbTags.DataSource is List<TagInfo>)
                list = this.cbTags.DataSource as List<TagInfo>;
            else
                list = new List<TagInfo>();
            FrmTagsPicker form = new FrmTagsPicker(list);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.cbTags.ValueMember = "I_TAG_ID";
                this.cbTags.DisplayMember = "I_TAG_NAME";
                this.cbTags.DataSource = form.SelectedTags;
            }
            form.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.cbTags.SelectedIndex < 0)
            {
                MessageBox.Show("请选择要生成曲线的指标", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<TagInfo> list = this.cbTags.DataSource as List<TagInfo>;
            if (list == null || list.Count == 0)
                return;

            GraphSchemaInfo graphSchemaInfo = new GraphSchemaInfo(){
                DataType = "Hour",
                Name = "",
                Remark = "",
                IsValid = true,
                TabWidth = 0,
                ReferLoginName = Common.CurrentUser.LoginName,
                Layout = "1|",
            };

            int tmpKeyId = 0;
            int iMAPeriod = 10;
            if(!int.TryParse(this.txtPeriod.Text.Trim(), out iMAPeriod))
            {
                iMAPeriod = 10;
            }
            String curveType = this.cbCurveType.SelectedValue.ToString();
            
            foreach (TagInfo tagInfo in list)
            {
                String tagName = tagInfo.I_Tag_Name;               
                
                GraphSchemaItemInfo tmpItemInfo = new GraphSchemaItemInfo()
                {
                    TitleVisible = true,
                    Title = String.Format("{0}：{1}", tagName, tagInfo.I_Tag_Id),
                };
                graphSchemaInfo.ItemList.Add(tmpItemInfo);
                GraphSchemaTagInfo schemaTagInfo = new GraphSchemaTagInfo()
                {
                    CurveType = curveType,
                    CurveColor = ColorSymbolRotator.StaticNextColor.ToArgb(),
                    LineType = Convert.ToByte(this.cbLineType.SelectedValue),
                    LineWidth = 1,
                    MAPeriod = iMAPeriod,
                    SymbolColor = ColorSymbolRotator.StaticNextColor.ToArgb(),
                    SymbolSize = 3,
                    SymbolType = ColorSymbolRotator.StaticInstance.NextSymbol.ToString(),
                    TagId = String.Format("[{0}]", tagInfo.I_Tag_Id),
                    TagName = tagName,
                    KeyId = tmpKeyId++,
                };
                tmpItemInfo.TagList.Add(schemaTagInfo);
            }

            //显示状态窗口。
            ToolTipHandler tHandler = new ToolTipHandler();
            tHandler.Show("正在生成曲线，请稍候...", Screen.PrimaryScreen.WorkingArea);
            //显示状态窗口。
            FrmGraphSchemaStage form = new FrmGraphSchemaStage(graphSchemaInfo);
            if (this._mdiParent != null) form.MdiParent = this._mdiParent;
            form.StartPosition = FormStartPosition.CenterParent;
            if (list.Count == 1)
            {
                form.Text = list[0].I_Tag_Name;
            }
            form.Show();
            
            tHandler.Close();//隐藏状态窗口。
            this.DialogResult = DialogResult.OK;
            form.Activate();
        }

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
