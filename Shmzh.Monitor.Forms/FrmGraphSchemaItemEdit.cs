using System;
using System.Windows.Forms;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmGraphSchemaItemEdit : Form
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
        /// 曲线方案项对象。
        /// </summary>
        public GraphSchemaItemInfo SchemaItemInfo { get; set; }
        #endregion

        #region CTOR
        private FrmGraphSchemaItemEdit()
        {
            InitializeComponent();
        }
        public FrmGraphSchemaItemEdit(GraphSchemaItemInfo schemaItemInfo):this()
        {
            this.SchemaInfo = new GraphSchemaInfo();
            this.SchemaItemInfo = schemaItemInfo;
            this.ActType = ActionType.Edit;
        }
        public FrmGraphSchemaItemEdit(GraphSchemaInfo schemaInfo):this()
        {
            this.SchemaInfo = schemaInfo;
            this.SchemaItemInfo = new GraphSchemaItemInfo();
            this.ActType = ActionType.Add;
        }
        #endregion

        #region private method
        /// <summary>
        /// 数据绑定。
        /// </summary>
        private void BindData()
        {
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            this.cbTitleFontFamily.BeginUpdate();
            this.cbXScaleFontFamily.BeginUpdate();
            this.cbYScaleFontFamily.BeginUpdate();
            this.cbXTitleFontFamily.BeginUpdate();
            this.cbYTitleFontFamily.BeginUpdate();
            this.cbLegendFontFamily.BeginUpdate();
            foreach (System.Drawing.FontFamily ff in fonts.Families)
            {
                this.cbTitleFontFamily.Items.Add(ff.Name);
                this.cbXScaleFontFamily.Items.Add(ff.Name);
                this.cbYScaleFontFamily.Items.Add(ff.Name);
                this.cbXTitleFontFamily.Items.Add(ff.Name);
                this.cbYTitleFontFamily.Items.Add(ff.Name);
                this.cbLegendFontFamily.Items.Add(ff.Name);
            }
            this.cbTitleFontFamily.EndUpdate();
            this.cbXScaleFontFamily.EndUpdate();
            this.cbYScaleFontFamily.EndUpdate();
            this.cbXTitleFontFamily.EndUpdate();
            this.cbYTitleFontFamily.EndUpdate();
            this.cbLegendFontFamily.EndUpdate();

            String[] arrLegendPos = Enum.GetNames(typeof(ZedGraph.LegendPos));
            this.cbLegendPosition.BeginUpdate();
            foreach (String pos in arrLegendPos)
            {
                this.cbLegendPosition.Items.Add(pos);
            }           
            this.cbLegendPosition.EndUpdate();

            if(this.ActType==ActionType.Add)
            {
                this.Text = "新增方案项";
                this.lblScheme.Text = this.SchemaInfo.Name;
            }
            else
            {
                this.Text = "编辑方案项";
                this.SchemaInfo = DataProvider.GraphSchemaProvider.GetById(this.SchemaItemInfo.SchemaId);
                this.lblScheme.Text = this.SchemaInfo.Name;
                
            }
            this.txtTitle.Text = this.SchemaItemInfo.Title;
            this.txtXAxis.Text = this.SchemaItemInfo.XAxis;
            this.txtYAxis.Text = this.SchemaItemInfo.YAxis;

            this.chkTitleVisible.Checked = this.SchemaItemInfo.TitleVisible;
            this.txtTitleFontSize.Text = this.SchemaItemInfo.TitleFontSize.ToString();
            this.cbTitleFontFamily.SelectedIndex = this.cbTitleFontFamily.FindString(this.SchemaItemInfo.TitleFontFamily);

            this.chkLegendVisible.Checked = this.SchemaItemInfo.LegendVisible;
            this.chkLegendIsShowSymbols.Checked = this.SchemaItemInfo.LegendIsShowSymbols;
            this.chkLegendIsHStack.Checked = this.SchemaItemInfo.LegendIsHStack;
            this.txtLegendFontSize.Text = this.SchemaItemInfo.LegendFontSize.ToString();
            this.cbLegendFontFamily.SelectedIndex = this.cbLegendFontFamily.FindString(this.SchemaItemInfo.LegendFontFamily);
            this.cbLegendPosition.SelectedIndex = this.cbLegendPosition.FindString(this.SchemaItemInfo.LegendPosition);            

            this.chkXScaleVisible.Checked = this.SchemaItemInfo.XScaleVisible;
            this.txtXScaleFontSize.Text = this.SchemaItemInfo.XScaleFontSize.ToString();
            this.cbXScaleFontFamily.SelectedIndex = this.cbXScaleFontFamily.FindString(this.SchemaItemInfo.XScaleFontFamily);

            this.chkXTitleVisible.Checked = this.SchemaItemInfo.XTitleVisible;
            this.txtXTitleFontSize.Text = this.SchemaItemInfo.XTitleFontSize.ToString();
            this.cbXTitleFontFamily.SelectedIndex = this.cbXTitleFontFamily.FindString(this.SchemaItemInfo.XTitleFontFamily);

            this.chkYScaleVisible.Checked = this.SchemaItemInfo.YScaleVisible;
            this.txtYScaleFontSize.Text = this.SchemaItemInfo.YScaleFontSize.ToString();
            this.cbYScaleFontFamily.SelectedIndex = this.cbYScaleFontFamily.FindString(this.SchemaItemInfo.YScaleFontFaminly);

            this.chkYTitleVisible.Checked = this.SchemaItemInfo.YTitleVisible;
            this.txtYTitleFontSize.Text = this.SchemaItemInfo.YTitleFontSize.ToString();
            this.cbYTitleFontFamily.SelectedIndex = this.cbYTitleFontFamily.FindString(this.SchemaItemInfo.YTitleFontFamily);

            if (!String.IsNullOrEmpty(this.SchemaItemInfo.XScaleFormat))
            {
                this.txtXScaleFormat.Text = this.SchemaItemInfo.XScaleFormat;
            }
            if (!String.IsNullOrEmpty(this.SchemaItemInfo.YScaleFormat))
            {
                this.txtYScaleFormat.Text = this.SchemaItemInfo.YScaleFormat;
            }

            this.txtMinSpaceL.Text = this.SchemaItemInfo.MinSpaceL.ToString();
            this.txtMinSpaceR.Text = this.SchemaItemInfo.MinSpaceR.ToString();
        }
        /// <summary>
        /// 填充数据体。
        /// </summary>
        private void FillData()
        {
            this.SchemaItemInfo.SchemaId = this.SchemaInfo.SchemaId;
            this.SchemaItemInfo.Title = this.txtTitle.Text;
            this.SchemaItemInfo.XAxis = this.txtXAxis.Text;
            this.SchemaItemInfo.YAxis = this.txtYAxis.Text;

            this.SchemaItemInfo.TitleVisible = this.chkTitleVisible.Checked;
            this.SchemaItemInfo.TitleFontSize = Convert.ToSingle(this.txtTitleFontSize.Text.Trim());
            this.SchemaItemInfo.TitleFontFamily = this.cbTitleFontFamily.Text.Trim();

            this.SchemaItemInfo.LegendVisible = this.chkLegendVisible.Checked;
            this.SchemaItemInfo.LegendIsShowSymbols = this.chkLegendIsShowSymbols.Checked;
            this.SchemaItemInfo.LegendIsHStack = this.chkLegendIsHStack.Checked;
            this.SchemaItemInfo.LegendFontSize = Convert.ToSingle(this.txtLegendFontSize.Text.Trim());
            this.SchemaItemInfo.LegendFontFamily = this.cbLegendFontFamily.Text.Trim();
            this.SchemaItemInfo.LegendPosition = this.cbLegendPosition.Text.Trim();

            this.SchemaItemInfo.XScaleVisible = this.chkXScaleVisible.Checked ;
            this.SchemaItemInfo.XScaleFontSize = Convert.ToSingle(this.txtXScaleFontSize.Text.Trim());
            this.SchemaItemInfo.XScaleFontFamily = this.cbXScaleFontFamily.Text.Trim();

            this.SchemaItemInfo.XTitleVisible = this.chkXTitleVisible.Checked;
            this.SchemaItemInfo.XTitleFontSize = Convert.ToSingle(this.txtXTitleFontSize.Text.Trim());
            this.SchemaItemInfo.XTitleFontFamily = this.cbXTitleFontFamily.Text.Trim();

            this.SchemaItemInfo.YScaleVisible = this.chkYScaleVisible.Checked;
            this.SchemaItemInfo.YScaleFontSize = Convert.ToSingle(this.txtYScaleFontSize.Text);
            this.SchemaItemInfo.YScaleFontFaminly = this.cbYScaleFontFamily.Text.Trim();

            this.SchemaItemInfo.YTitleVisible = this.chkYTitleVisible.Checked;
            this.SchemaItemInfo.YTitleFontSize = Convert.ToSingle(this.txtYTitleFontSize.Text.Trim());
            this.SchemaItemInfo.YTitleFontFamily = this.cbYTitleFontFamily.Text.Trim();

            this.SchemaItemInfo.XScaleFormat = this.txtXScaleFormat.Text.Trim();
            this.SchemaItemInfo.YScaleFormat = this.txtYScaleFormat.Text.Trim();
            this.SchemaItemInfo.MinSpaceL = Convert.ToSingle(this.txtMinSpaceL.Text.Trim());
            this.SchemaItemInfo.MinSpaceR = Convert.ToSingle(this.txtMinSpaceR.Text.Trim());
        }
        #endregion

        #region Event

        private void FrmGraphSchemeItemEdit_Load(object sender, EventArgs e)
        {
            this.BindData();   
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            if (this.txtTitle.Text.Trim().Length == 0)
            {
                isValid = false;
                this.errorProvider1.SetError(this.txtTitle, "请输入标题。");
            }
            else
            {
                this.errorProvider1.SetError(this.txtTitle, "");
            }
            if (!ValidSingle(this.txtTitleFontSize, "标题字体大小", true)) isValid = false;
            if (!ValidSingle(this.txtLegendFontSize, "图例字体大小", true)) isValid = false;
            if (!ValidSingle(this.txtXScaleFontSize, "X轴刻度字体大小", true)) isValid = false;
            if (!ValidSingle(this.txtXTitleFontSize, "X轴标题字体大小", true)) isValid = false;
            if(!ValidSingle(this.txtYScaleFontSize, "Y轴刻度字体大小", true)) isValid = false;
            if (!ValidSingle(this.txtYTitleFontSize, "Y轴标题字体大小", true)) isValid = false;
            if (!ValidSingle(this.txtMinSpaceL, "左边距", true)) isValid = false;
            if (!ValidSingle(this.txtMinSpaceR, "右边距", true)) isValid = false;
                      
            if (!isValid) return;
            this.FillData();
            
            switch (ActType)
            {
                case ActionType.Add:
                    var ret = DataProvider.GraphSchemaItemProvider.Insert(this.SchemaItemInfo);
                    if(ret > 0)
                    {
                        this.SchemaItemInfo.ItemId = ret;
                        GlobleVariables.GraphSchemaItemList.Add(this.SchemaItemInfo);

                        if (DataProvider.GraphSchemaProvider.UpdateLoginName(this.SchemaInfo.SchemaId, Common.CurrentUser.LoginName))
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
                        MessageBox.Show("保存出错", "提示",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ActionType.Edit:
                    if(DataProvider.GraphSchemaItemProvider.Update(this.SchemaItemInfo))
                    {
                        if (DataProvider.GraphSchemaProvider.UpdateLoginName(this.SchemaItemInfo.SchemaId, Common.CurrentUser.LoginName))
                        {
                            //MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("保存出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void btnScaleFormat_Click(object sender, EventArgs e)
        {
            new FrmScaleFormatSample() { StartPosition = FormStartPosition.CenterParent }.ShowDialog(this);
        }
        #endregion

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
    }
}
