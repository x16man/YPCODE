using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DDE2OPC.DALFactory;
using DDE2OPC.Model;
using DDE2OPC.Properties;


namespace DDE2OPC
{
    public partial class FormMap : Form
    {
        #region Field

        #endregion

        #region Method
        /// <summary>
        /// 初始化界面的文字显示。
        /// </summary>
        private void InitUI()
        {
            this.Icon = Resources.bridge;

            this.menuStrip_Map.Visible = false;

            this.toolStripButton_Add.Text = Resources.FormMap_toolStrip_Map_Add;
            this.toolStripButton_Add.Image = Resources.tag_blue_add;
            this.toolStripButton_Update.Text = Resources.FormMap_toolStrip_Map_Update;
            this.toolStripButton_Update.Image = Resources.tag_blue_edit;
            this.toolStripButton_Delete.Text = Resources.FormMap_toolStrip_Map_Delete;
            this.toolStripButton_Delete.Image = Resources.tag_blue_delete;

            this.InitListView_Map();
        }
        /// <summary>
        /// 初始化指标对应的ListView。
        /// </summary>
        private void InitListView_Map()
        {
            this.listView_Map.Dock = DockStyle.Fill;
            this.listView_Map.View = View.Details;
            this.listView_Map.FullRowSelect = true;
            this.listView_Map.Columns.AddRange(new[]
                                                          {
                                                              new ColumnHeader(){Text ="！",TextAlign = HorizontalAlignment.Center,DisplayIndex = 0,Name ="Icon",Width = 24,},
                                                              new ColumnHeader(){Text ="DDE主题",TextAlign = HorizontalAlignment.Left,DisplayIndex = 1,Name ="Content",Width = 70,},
                                                              new ColumnHeader(){Text ="DDE项",TextAlign = HorizontalAlignment.Left,DisplayIndex = 2,Name = "DDEItem",Width = 70,}, 
                                                              new ColumnHeader(){Text ="OPC地址",TextAlign = HorizontalAlignment.Left,DisplayIndex = 3,Name="OPCAddress",Width=100}, 
                                                              new ColumnHeader(){Text = "描述",TextAlign = HorizontalAlignment.Left,DisplayIndex = 4,Name="Remark",Width = 150}, 
                                                          });
            var imageList = new ImageList();
            imageList.Images.Add(Resources.tag);
            imageList.Images.Add(Resources.tag_blue);
            this.listView_Map.SmallImageList = imageList;
            this.statusBar_Map.Visible = false;
        }

        /// <summary>
        /// 将DDE指标和OPC指标的映射关系绑定到ListView。
        /// </summary>
        private void BindListView_Map()
        {
            var objs = DataProvider.MapProvider.GetAll();
            this.listView_Map.Items.Clear();

            foreach(var obj in objs)
            {
                var item = new ListViewItem(string.Empty,1) {Tag = obj};
                item.SubItems.Add(obj.DDETopic);
                item.SubItems.Add(obj.DDEItem);
                item.SubItems.Add(obj.OPCAddress);
                item.SubItems.Add(obj.Remark);
                

                this.listView_Map.Items.Add(item);
            }
        }
        #endregion

        public FormMap()
        {
            InitializeComponent();

            this.InitUI();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            var result = new FormMapInput().ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                this.BindListView_Map();
            }
        }

        private void toolStripButton_Update_Click(object sender, EventArgs e)
        {
            if(this.listView_Map.SelectedItems.Count > 0)
            {
                var result = new FormMapInput(this.listView_Map.SelectedItems[0].Tag as MapInfo).ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.BindListView_Map();
                }
            }
            else
            {
                MessageBox.Show(Resources.Message_PleaseSelectItem);
            }
            
        }

        private void toolStripButton_Delete_Click(object sender, EventArgs e)
        {
            if (this.listView_Map.SelectedItems.Count > 0)
            {
                if(MessageBox.Show(Resources.Message_ConfirmDeleteText,Resources.Message_ConfirmDeleteCaption,MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataProvider.MapProvider.Delete(this.listView_Map.SelectedItems[0].Tag as MapInfo);
                    this.BindListView_Map();
                }
            }
            else
            {
                MessageBox.Show(Resources.Message_PleaseSelectItem);
            }
        }

        private void FormMap_Load(object sender, EventArgs e)
        {
            this.BindListView_Map();
        }

        private void ToolStripMenuItem_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView_Map_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var obj = this.listView_Map.GetItemAt(e.X, e.Y);
            if(obj != null)
            {
                this.toolStripButton_Update_Click(null,e);
            }
        }
    }
}
