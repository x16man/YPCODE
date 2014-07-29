using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmTagSearch : Form
    {
        private List<TagInfo> tagMSList;
        private List<TagGatherInfo> tagGatherList;

        public FrmTagSearch()
        {
            InitializeComponent();
            this.dgvTagMS.AutoGenerateColumns = false;
            this.dgvTagGather.AutoGenerateColumns = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.tsStatusLabel.Text = "正在查询，请稍候...";

            ThreadStart ts = new ThreadStart(Search);
            IAsyncResult Iar = ts.BeginInvoke(SearchFinish, null);
        }

        private void SearchFinish(IAsyncResult Iar)
        {
            if (Iar.IsCompleted)
            {
                ThreadStart ts = delegate { 
                    this.tsStatusLabel.Text = "查询完成。";
                    this.dgvTagMS.DataSource = tagMSList;
                    this.dgvTagGather.DataSource = tagGatherList;
                };
                this.Invoke(ts); 
            }
        }

        private void Search()
        {
            String tagId = this.txtTagId.Text.Trim();
            String tagType = this.txtTagType.Text.Trim();
            String tagName = this.txtTagName.Text.Trim();
            tagMSList = DataProvider.TagProvider.GetByType_TagId_TagName(tagType, tagId, tagName);
            tagGatherList = DataProvider.TagGatherProvider.GetByTagId(this.txtTagId.Text.Trim());
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

        private void menuCopy_Click(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (this.tabControl1.SelectedIndex == 0)
            {
                Clipboard.SetDataObject(dgvTagMS.GetClipboardContent());
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                Clipboard.SetDataObject(dgvTagGather.GetClipboardContent());
            }
        }
    }
}
