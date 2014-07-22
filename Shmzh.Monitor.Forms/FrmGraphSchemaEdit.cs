using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Monitor.Entity;
using Shmzh.Monitor.Data;
using Shmzh.Components.SystemComponent;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmGraphSchemaEdit : Form
    {
        #region Property
        /// <summary>
        /// 设置或获取操作类型。
        /// </summary>
        public ActionType ActType { get; set; }

        /// <summary>
        /// 设置或获取方案信息。
        /// </summary>
        public GraphSchemaInfo GraphSchemeEntity { get; set; }
        #endregion

        #region CTOR
        public FrmGraphSchemaEdit(ActionType actType)
        {
            InitializeComponent();
            this.ActType = actType;
        }
        #endregion


        #region Events
        private void FrmGraphSchemeEdit_Load(object sender, EventArgs e)
        {
            Common.BindTagDataType(cbDataType, false);
            var fonts = new System.Drawing.Text.InstalledFontCollection();
            this.cbTitleFontFamily.BeginUpdate();
            this.cbLegendFontFamily.BeginUpdate();
            foreach (System.Drawing.FontFamily ff in fonts.Families)
            {
                this.cbTitleFontFamily.Items.Add(ff.Name);
                this.cbLegendFontFamily.Items.Add(ff.Name);
            }
            this.cbTitleFontFamily.EndUpdate();
            this.cbLegendFontFamily.EndUpdate();
            String[] arrLegendPos = Enum.GetNames(typeof(ZedGraph.LegendPos));
            this.cbLegendPosition.BeginUpdate();
            foreach (String pos in arrLegendPos)
            {
                this.cbLegendPosition.Items.Add(pos);
            }
            this.cbLegendPosition.EndUpdate();
            switch (ActType)
            {
                case ActionType.Add:
                    this.Text = "新增方案";
                    this.GraphSchemeEntity = new GraphSchemaInfo();
                    break;
                case ActionType.Edit:
                    this.Text = "编辑方案";
                    if (GraphSchemeEntity != null)
                    {
                        this.txtName.Text = GraphSchemeEntity.Name;
                        this.txtRemark.Text = GraphSchemeEntity.Remark;
                        this.chkIsValid.Checked = GraphSchemeEntity.IsValid;
                        this.cbDataType.SelectedValue = GraphSchemeEntity.DataType;

                        String[] tempArray = GraphSchemeEntity.Layout.Split('|');
                        if (tempArray[0].Equals("0"))
                        {
                            this.rdoH.Checked = true;
                        }
                        else if (tempArray[0].Equals("1"))
                        {
                            this.rdoV.Checked = true;
                        }
                        if (tempArray.Length == 3)
                        {
                            this.txtLayout1.Text = tempArray[1];
                            this.txtLayout2.Text = tempArray[2];
                        }
                    }
                    break;
                case ActionType.Save:
                    if (GraphSchemeEntity != null)
                    {
                        this.Text = (GraphSchemeEntity.SchemaId > 0 ? "复制方案" : "保存方案");

                        this.txtName.Text = GraphSchemeEntity.Name;
                        this.txtRemark.Text = GraphSchemeEntity.Remark;
                        this.chkIsValid.Checked = GraphSchemeEntity.IsValid;
                        this.cbDataType.SelectedValue = GraphSchemeEntity.DataType;

                        String[] tempArray = GraphSchemeEntity.Layout.Split('|');
                        if (tempArray[0].Equals("0"))
                        {
                            this.rdoH.Checked = true;
                        }
                        else if (tempArray[0].Equals("1"))
                        {
                            this.rdoV.Checked = true;
                        }
                        if (tempArray.Length == 3)
                        {
                            this.txtLayout1.Text = tempArray[1];
                            this.txtLayout2.Text = tempArray[2];
                        }
                    }
                    break;
            }
            this.txtTitle.Text = this.GraphSchemeEntity.Title;
            this.chkTitleVisible.Checked = this.GraphSchemeEntity.TitleVisible;
            this.txtTitleFontSize.Text = this.GraphSchemeEntity.TitleFontSize.ToString();
            this.cbTitleFontFamily.SelectedIndex = this.cbTitleFontFamily.FindString(this.GraphSchemeEntity.TitleFontFamily);

            this.chkLegendVisible.Checked = this.GraphSchemeEntity.LegendVisible;
            this.chkLegendIsShowSymbols.Checked = this.GraphSchemeEntity.LegendIsShowSymbols;
            this.chkLegendIsHStack.Checked = this.GraphSchemeEntity.LegendIsHStack;
            this.txtLegendFontSize.Text = this.GraphSchemeEntity.LegendFontSize.ToString();
            this.cbLegendFontFamily.SelectedIndex = this.cbLegendFontFamily.FindString(this.GraphSchemeEntity.LegendFontFamily);
            this.cbLegendPosition.SelectedIndex = this.cbLegendPosition.FindString(this.GraphSchemeEntity.LegendPosition);

            this.txtInnerPaneGap.Text = this.GraphSchemeEntity.InnerPaneGap.ToString();
            this.txtMargin.Text = this.GraphSchemeEntity.Margin;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text.Trim();
            if(name.Length == 0)
            {
                this.errorProvider1.SetError(this.txtName, "方案名称不能为空。");
                return;
            }
            var tempObj = DataProvider.GraphSchemaProvider.GetByName(name);

            this.GraphSchemeEntity.Title = this.txtTitle.Text.Trim();
            this.GraphSchemeEntity.TitleVisible = this.chkTitleVisible.Checked;
            this.GraphSchemeEntity.TitleFontSize = Convert.ToSingle(this.txtTitleFontSize.Text.Trim());
            this.GraphSchemeEntity.TitleFontFamily = this.cbTitleFontFamily.Text.Trim();
            this.GraphSchemeEntity.LegendVisible = this.chkLegendVisible.Checked;
            this.GraphSchemeEntity.LegendIsShowSymbols = this.chkLegendIsShowSymbols.Checked;
            this.GraphSchemeEntity.LegendIsHStack = this.chkLegendIsHStack.Checked;
            this.GraphSchemeEntity.LegendFontSize = Convert.ToSingle(this.txtLegendFontSize.Text.Trim());
            this.GraphSchemeEntity.LegendFontFamily = this.cbLegendFontFamily.Text.Trim();
            this.GraphSchemeEntity.LegendPosition = this.cbLegendPosition.Text.Trim();
            this.GraphSchemeEntity.Margin = this.txtMargin.Text.Trim();
            this.GraphSchemeEntity.InnerPaneGap = Convert.ToSingle(this.txtInnerPaneGap.Text.Trim());

            switch (ActType)
            {
                case ActionType.Add:
                    if (tempObj != null)
                    {
                        this.errorProvider1.SetError(this.txtName, "方案名称有重复，请用其他名称。");
                        return;
                    }
                    //GraphSchemeEntity = new GraphSchemaInfo();
                    GraphSchemeEntity.Name = name;
                    GraphSchemeEntity.Remark = this.txtRemark.Text.Trim();
                    GraphSchemeEntity.IsValid = this.chkIsValid.Checked;
                    GraphSchemeEntity.DataType = this.cbDataType.SelectedValue.ToString();
                    GraphSchemeEntity.TabWidth = 220;
                    GraphSchemeEntity.ReferLoginName = Common.CurrentUser.LoginName;
                    if (rdoH.Checked)
                    {
                        GraphSchemeEntity.Layout = "0|";
                    }
                    else if (rdoV.Checked)
                    {
                        GraphSchemeEntity.Layout = "1|";
                    }

                    if (this.txtLayout1.Text.Trim().Length > 0 && this.txtLayout2.Text.Trim().Length > 0)
                    {
                        GraphSchemeEntity.Layout += String.Format("{0}|{1}", this.txtLayout1.Text.Trim(),
                                                                 this.txtLayout2.Text.Trim());
                    }
                    var ret = DataProvider.GraphSchemaProvider.Insert(GraphSchemeEntity);

                    if (ret > 0)
                    {
                        GraphSchemeEntity.SchemaId = ret;
                        GlobleVariables.GraphSchemaList.Add(GraphSchemeEntity);
                        MessageBox.Show("新增成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(String.Format("保存出错！"), "错误", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                    break;
                case ActionType.Edit:
                    if (tempObj != null && tempObj.SchemaId != GraphSchemeEntity.SchemaId)
                    {
                        this.errorProvider1.SetError(this.txtName, "方案名称有重复，请用其他名称。");
                        return;
                    }
                    GraphSchemeEntity.Name = name;
                    GraphSchemeEntity.Remark = this.txtRemark.Text.Trim();
                    GraphSchemeEntity.IsValid = this.chkIsValid.Checked;
                    GraphSchemeEntity.DataType = this.cbDataType.SelectedValue.ToString();
                    GraphSchemeEntity.ReferLoginName = Common.CurrentUser.LoginName;
                    if (rdoH.Checked)
                    {
                        GraphSchemeEntity.Layout = "0|";
                    }
                    else if (rdoV.Checked)
                    {
                        GraphSchemeEntity.Layout = "1|";
                    }

                    if (this.txtLayout1.Text.Trim().Length > 0 && this.txtLayout2.Text.Trim().Length > 0)
                    {
                        GraphSchemeEntity.Layout += String.Format("{0}|{1}", this.txtLayout1.Text.Trim(),
                                                                 this.txtLayout2.Text.Trim());
                    }

                    if (DataProvider.GraphSchemaProvider.Update(GraphSchemeEntity))
                    {
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(String.Format("保存出错！"), "错误", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                    break;
                case ActionType.Save:
                    #region  保存临时曲线方案或复制已有方案。
                    if (tempObj != null)
                    {
                        this.errorProvider1.SetError(this.txtName, "方案名称有重复，请用其他名称。");
                        return;
                    }

                    int oldSchemaId = GraphSchemeEntity.SchemaId;//原有方案的Id。

                    GraphSchemeEntity.Name = name;
                    GraphSchemeEntity.Remark = this.txtRemark.Text.Trim();
                    GraphSchemeEntity.IsValid = this.chkIsValid.Checked;
                    GraphSchemeEntity.DataType = this.cbDataType.SelectedValue.ToString();
                    GraphSchemeEntity.ReferLoginName = Common.CurrentUser.LoginName;
                    if (rdoH.Checked)
                    {
                        GraphSchemeEntity.Layout = "0|";
                    }
                    else if (rdoV.Checked)
                    {
                        GraphSchemeEntity.Layout = "1|";
                    }

                    if (this.txtLayout1.Text.Trim().Length > 0 && this.txtLayout2.Text.Trim().Length > 0)
                    {
                        GraphSchemeEntity.Layout += String.Format("{0}|{1}", this.txtLayout1.Text.Trim(),
                                                                 this.txtLayout2.Text.Trim());
                    }
                    if(oldSchemaId > 0)
                    {
                        var floatingBlocks = DataProvider.FloatingBlockProvider.GetBySchemaId(oldSchemaId);
                        foreach (var blockInfo in floatingBlocks)
                        {
                            blockInfo.ItemList = DataProvider.FloatingBlockItemProvider.GetByBlockId(blockInfo.BlockId);
                        }
                        var tabs = DataProvider.GraphSchemaTabProvider.GetBySchemaId(oldSchemaId);
                        foreach (var tabInfo in tabs)
                        {
                            tabInfo.RTagList = DataProvider.GraphSchemaRTagProvider.GetByTabId(tabInfo.TabId);
                        }
                        GraphSchemeEntity.FloatingBlockInfos = floatingBlocks;
                        GraphSchemeEntity.GraphSchemaTabInfos = tabs;
                    }
                    
                    if(DataProvider.GraphSchemaProvider.DeepSave(GraphSchemeEntity))
                    {
                        MessageBox.Show( "保存成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(oldSchemaId > 0 ? "复制失败。" : "保存失败。", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                    

                    //using (SqlConnection conn = new SqlConnection(ConnectionString.Monitor))
                    //{
                    //    conn.Open();
                    //    using (SqlTransaction trans = conn.BeginTransaction("SAVE_GRAPH_SCHEMA"))
                    //    {
                    //        if (DataProvider.GraphSchemaProvider.InsertWithTrans(trans, GraphSchemeEntity) == false)
                    //            goto SAVE_ERROR;
                    //        foreach (var itemInfo in GraphSchemeEntity.ItemList)
                    //        {
                    //            itemInfo.SchemaId = GraphSchemeEntity.SchemaId;
                    //            if (DataProvider.GraphSchemaItemProvider.InsertWithTrans(trans, itemInfo) == false)
                    //                goto SAVE_ERROR;
                    //            foreach (var tagInfo in itemInfo.TagList)
                    //            {
                    //                tagInfo.ItemId = itemInfo.ItemId;
                    //                if (DataProvider.GraphSchemaTagProvider.InsertWithTrans(trans, tagInfo) == false)
                    //                    goto SAVE_ERROR;
                    //            }
                    //        }

                    //        if (oldSchemaId > 0)
                    //        {
                    //            var floatingBlocks = DataProvider.FloatingBlockProvider.GetBySchemaId(oldSchemaId);
                    //            foreach (var blockInfo in floatingBlocks)
                    //            {
                    //                blockInfo.ItemList = DataProvider.FloatingBlockItemProvider.GetByBlockId(blockInfo.BlockId);
                    //            }
                    //            var tabs = DataProvider.GraphSchemaTabProvider.GetBySchemaId(oldSchemaId);
                    //            foreach (var tabInfo in tabs)
                    //            {
                    //                tabInfo.RTagList = DataProvider.GraphSchemaRTagProvider.GetByTabId(tabInfo.TabId);
                    //            }

                    //            foreach (var blockInfo in floatingBlocks)
                    //            {
                    //                blockInfo.SchemaId = GraphSchemeEntity.SchemaId;
                    //                if (DataProvider.FloatingBlockProvider.InsertWithTrans(trans, blockInfo) == false)
                    //                    goto SAVE_ERROR;
                    //                foreach (var blockItemInfo in blockInfo.ItemList)
                    //                {
                    //                    blockItemInfo.BlockId = blockInfo.BlockId;
                    //                    if (DataProvider.FloatingBlockItemProvider.InsertWithTrans(trans, blockItemInfo) == false)
                    //                        goto SAVE_ERROR;
                    //                }
                    //            }
                    //            foreach (var tabInfo in tabs)
                    //            {
                    //                tabInfo.SchemaId = GraphSchemeEntity.SchemaId;
                    //                if (DataProvider.GraphSchemaTabProvider.InsertWithTrans(trans, tabInfo) == false)
                    //                    goto SAVE_ERROR;
                    //                foreach (var rTagInfo in tabInfo.RTagList)
                    //                {
                    //                    rTagInfo.TabId = tabInfo.TabId;
                    //                    if (DataProvider.GraphSchemaRTagProvider.InsertWithTrans(trans, rTagInfo) == false)
                    //                        goto SAVE_ERROR;
                    //                }
                    //            }
                    //        }
                    //        trans.Commit();
                    //        conn.Close();
                    //        MessageBox.Show(oldSchemaId > 0 ? "复制成功。" : "保存成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        this.DialogResult = DialogResult.OK;
                    //        return;
                    //    //保存过程中出错。
                    //    SAVE_ERROR:
                    //        trans.Rollback();
                    //        conn.Close();
                    //        MessageBox.Show(oldSchemaId > 0 ? "复制失败。" : "保存失败。", "错误", MessageBoxButtons.OK,
                    //                    MessageBoxIcon.Error);
                    //        this.DialogResult = DialogResult.Cancel;
                    //    }
                    //}
                    break;
                    #endregion 
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoH_CheckedChanged(object sender, EventArgs e)
        {
            this.rdoV.Checked = !this.rdoH.Checked;
        }

        private void rdoV_CheckedChanged(object sender, EventArgs e)
        {
            this.rdoH.Checked = !this.rdoV.Checked;
        }
        #endregion

        private void FrmGraphSchemaEdit_Shown(object sender, EventArgs e)
        {
            this.txtName.Focus();
        }

    }
}
