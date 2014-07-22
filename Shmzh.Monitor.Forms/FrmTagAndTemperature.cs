using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;
using Shmzh.Components.Util;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmTagAndTemperature : Form
    {
        /// <summary>
        /// 总出厂水量指标。
        /// </summary>
        private String _waterTag = ConfigurationManager.AppSettings["WaterTag"];
        /// <summary>
        /// 每日最高气温指标。
        /// </summary>
        private String _temperatureTagHigh = ConfigurationManager.AppSettings["TemperatureTagHigh"];
        /// <summary>
        /// 每日最低气温指标。
        /// </summary>
        private String _temperatureTagLow = ConfigurationManager.AppSettings["TemperatureTagLow"];
        public FrmTagAndTemperature()
        {
            InitializeComponent();
        }

        private void FrmTagAndTemperature_Load(object sender, EventArgs e)
        {
            DateTime day = DateTime.Today.AddMonths(-1);
            this.dtpStartDate.Value = new DateTime(day.Year, day.Month, 1);
            this.dtpEndDate.Value = DateTime.Today;
            this.cbStartTemperature.SelectedIndex = 0;
            this.cbEndTemperature.SelectedIndex = this.cbEndTemperature.Items.Count - 1;
            this.cbStartWater.SelectedIndex = 0;
            this.cbEndWater.SelectedIndex = this.cbEndWater.Items.Count - 1;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 验证输入是否合理。
            if (this.cbTags.SelectedIndex < 0)
            {
                MessageBox.Show("请选择指标。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<TagInfo> tagInfolist = this.cbTags.DataSource as List<TagInfo>;
            if (tagInfolist == null || tagInfolist.Count == 0)
                return;

            if (this.dtpStartDate.Value > this.dtpEndDate.Value)
            {
                MessageBox.Show("开始时间不能晚于结束时间，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.cbStartTemperature.Text.Trim().Length == 0)
            {
                MessageBox.Show("最小温度不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbEndTemperature.Text.Trim().Length == 0)
            {
                MessageBox.Show("最大温度不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double startTemperature, endTemperature;
            try
            {
                startTemperature = Convert.ToDouble(this.cbStartTemperature.Text.Trim());
                endTemperature = Convert.ToDouble(this.cbEndTemperature.Text.Trim());
            }
            catch
            {
                MessageBox.Show("温度必须为数字。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (startTemperature > endTemperature)
            {
                MessageBox.Show("最小温度不能大于最大温度。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.cbStartWater.Text.Trim().Length == 0)
            {
                MessageBox.Show("最小水量不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbEndWater.Text.Trim().Length == 0)
            {
                MessageBox.Show("最大水量不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double startWater, endWater;
            try
            {
                startWater = Convert.ToDouble(this.cbStartWater.Text.Trim());
                endWater = Convert.ToDouble(this.cbEndWater.Text.Trim());
            }
            catch
            {
                MessageBox.Show("水量必须为数字。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (startWater > endWater)
            {
                MessageBox.Show("最小水量不能大于最大水量。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            #endregion

            //设置鼠标为等待。
            this.Cursor = Cursors.WaitCursor;

            String tags = "";
            for (int i = 0; i < tagInfolist.Count; i++)
            {
                if (tags.Length == 0)
                    tags += tagInfolist[i].I_Tag_Id;
                else
                    tags += "," + tagInfolist[i].I_Tag_Id;
            }

            this.dgvResult.Columns.Clear();
            this.dgvResult.AutoGenerateColumns = false;            
            DataGridViewTextBoxColumn dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.DataPropertyName = "CycleDate";
            dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvColumn.HeaderText = "日期";
            dgvColumn.ReadOnly = true;
            dgvColumn.DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvResult.Columns.Add(dgvColumn);

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.DataPropertyName = "Water";
            dgvColumn.FillWeight = 50F;
            dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvColumn.HeaderText = "总出厂水";
            dgvColumn.ReadOnly = true;
            dgvColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvResult.Columns.Add(dgvColumn);

            dgvColumn = new DataGridViewTextBoxColumn();
            dgvColumn.DataPropertyName = "Temperature";
            dgvColumn.FillWeight = 50F;
            dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvColumn.HeaderText = "温度";
            dgvColumn.ReadOnly = true;
            dgvColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvResult.Columns.Add(dgvColumn);

            foreach (TagInfo tagInfo in tagInfolist)
            {
                dgvColumn = new DataGridViewTextBoxColumn();
                dgvColumn.DataPropertyName = String.Format("T_{0}", tagInfo.I_Tag_Id);
                dgvColumn.FillWeight = 50F;
                dgvColumn.HeaderText = tagInfo.I_Tag_Name;
                dgvColumn.ReadOnly = true;
                this.dgvResult.Columns.Add(dgvColumn);
            }

            var list =
            DataProvider.TagDayProvider.TagAndTemperatureAnalyze(tags, _temperatureTagHigh, _temperatureTagLow, _waterTag,
                Gather.DateTime2DayCycleId(this.dtpStartDate.Value), Gather.DateTime2DayCycleId(this.dtpEndDate.Value),
                startWater, endWater, startTemperature, endTemperature);
            if (list.Count > 0)
            {
                DataTable dt = new DataTable();
                DataColumn col;
                col = new DataColumn("CycleDate");
                col.Caption = "日期";
                col.DataType = typeof(DateTime);
                dt.Columns.Add(col);

                col = new DataColumn("Water");
                col.Caption = "总出厂水";
                col.DataType = typeof(Double);
                dt.Columns.Add(col);

                col = new DataColumn("Temperature");
                col.Caption = "温度";
                col.DataType = typeof(String);
                dt.Columns.Add(col);

                foreach (TagInfo tagInfo in tagInfolist)
                {
                    col = new DataColumn(String.Format("T_{0}", tagInfo.I_Tag_Id));
                    col.Caption = tagInfo.I_Tag_Name;
                    col.DataType = typeof(Double);
                    dt.Columns.Add(col);
                }

                int preCycleId = 0;
                DataRow row = null;
                foreach (TagDayInfo tagDayInfo in list)
                {
                    if (preCycleId != tagDayInfo.I_Cycle_Id)
                    {
                        if (row != null)
                            dt.Rows.Add(row);
                        preCycleId = tagDayInfo.I_Cycle_Id;
                        row = dt.NewRow();
                        row["CycleDate"] = Gather.DayCycleId2DateTime(tagDayInfo.I_Cycle_Id);
                    }

                    double value = tagDayInfo.I_Value_Man;
                    if (tagDayInfo.I_Tag_Id.Equals(this._waterTag, StringComparison.OrdinalIgnoreCase))
                    {
                        row["Water"] = value;
                    }
                    else if (tagDayInfo.I_Tag_Id.Equals(this._temperatureTagLow, StringComparison.OrdinalIgnoreCase))
                    {
                        if (row["Temperature"] != DBNull.Value)
                            row["Temperature"] = String.Format("{0}℃ ～ {1}℃", value, row["Temperature"]);
                        else
                            row["Temperature"] = value;
                    }
                    else if (tagDayInfo.I_Tag_Id.Equals(this._temperatureTagHigh, StringComparison.OrdinalIgnoreCase))
                    {
                        if (row["Temperature"] != DBNull.Value)
                            row["Temperature"] = String.Format("{0}℃ ～ {1}℃", row["Temperature"], value);
                        else
                            row["Temperature"] = value;
                    }
                    else
                    {
                        row[String.Format("T_{0}", tagDayInfo.I_Tag_Id)] = value;
                    }
                }
                this.dgvResult.DataSource = dt;
            }
            else
            { 
                this.dgvResult.DataSource = null;
            }
            this.Cursor = Cursors.Default;
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font, rect, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            }
        }
    }
}
