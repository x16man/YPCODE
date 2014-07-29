using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Shmzh.Monitor.Main
{
    public partial class FrmConfig : Form
    {
        #region Fields
        private List<ConfigInfo.ItemInfo> configList;
        private String xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\Config.xml");
        /// <summary>
        /// 是否需要更新主界面菜单。
        /// </summary>
        private bool isChanged = false; 
        #endregion

        public FrmConfig()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void FrmConfig_Load(object sender, EventArgs e)
        {
            configList = this.LoadConfig().ConfigList;
            this.dgvConfig.DataSource = configList;
            this.EnableMoveButton();
        }

        private void dgvConfig_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font, rect, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right); 
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            FrmConfigEdit frm = new FrmConfigEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var doc = new XmlDocument();
                doc.Load(xmlPath);

                XmlNodeList nodeList = doc.DocumentElement.SelectNodes("Charts/Item");
                var node = doc.CreateNode(XmlNodeType.Element, "Item", null);
                var xmlAttr = doc.CreateNode(XmlNodeType.Attribute, "Visible", null);
                xmlAttr.Value = frm.ItemInfo.Visible.ToString();
                node.Attributes.Append((XmlAttribute)xmlAttr);
                xmlAttr = doc.CreateNode(XmlNodeType.Attribute, "ShowTime", null);
                xmlAttr.Value = frm.ItemInfo.ShowTime.ToString();
                node.Attributes.Append((XmlAttribute)xmlAttr);
                xmlAttr = doc.CreateNode(XmlNodeType.Attribute, "UpdateTime", null);
                xmlAttr.Value = frm.ItemInfo.UpdateTime.ToString();
                node.Attributes.Append((XmlAttribute)xmlAttr);
                xmlAttr = doc.CreateNode(XmlNodeType.Attribute, "ClassName", null);
                xmlAttr.Value = frm.ItemInfo.ClassName;
                node.Attributes.Append((XmlAttribute)xmlAttr);
                xmlAttr = doc.CreateNode(XmlNodeType.Attribute, "ConfigFile", null);
                xmlAttr.Value = frm.ItemInfo.ConfigFile;
                node.Attributes.Append((XmlAttribute)xmlAttr);                
                xmlAttr = doc.CreateNode(XmlNodeType.Attribute, "Title", null);
                xmlAttr.Value = frm.ItemInfo.Title;
                node.Attributes.Append((XmlAttribute)xmlAttr);

                doc.DocumentElement.SelectSingleNode("Charts").AppendChild(node);
                doc.Save(xmlPath);

                configList.Add(frm.ItemInfo);
                this.dgvConfig.DataSource = configList.ToArray();

                MessageBox.Show("新增成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isChanged = true;
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvConfig.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择您要编辑的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow row = this.dgvConfig.SelectedRows[0];
            ConfigInfo.ItemInfo itemInfo = row.DataBoundItem as ConfigInfo.ItemInfo;
            FrmConfigEdit frm = new FrmConfigEdit(itemInfo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var doc = new XmlDocument();
                doc.Load(xmlPath);
                
                var nodeList = doc.DocumentElement.SelectNodes("Charts/Item");
                var node = nodeList[row.Index];
                node.Attributes.GetNamedItem("ClassName").Value = frm.ItemInfo.ClassName;
                node.Attributes.GetNamedItem("ConfigFile").Value = frm.ItemInfo.ConfigFile;
                node.Attributes.GetNamedItem("ShowTime").Value = frm.ItemInfo.ShowTime.ToString();
                node.Attributes.GetNamedItem("UpdateTime").Value = frm.ItemInfo.UpdateTime.ToString();
                node.Attributes.GetNamedItem("Title").Value = frm.ItemInfo.Title;
                node.Attributes.GetNamedItem("Visible").Value = frm.ItemInfo.Visible.ToString();
                doc.Save(xmlPath);

                this.dgvConfig.InvalidateRow(row.Index);
                MessageBox.Show("编辑成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isChanged = true;
            }
        }

        private void tdbDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvConfig.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择您要删除的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("您确定要删除选定的记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                DataGridViewRow row = this.dgvConfig.SelectedRows[0];

                var doc = new XmlDocument();
                doc.Load(xmlPath);

                var nodeList = doc.DocumentElement.SelectNodes("Charts/Item");
                var node = nodeList[row.Index];
                node.ParentNode.RemoveChild(node);
                doc.Save(xmlPath);

                ConfigInfo.ItemInfo item = configList[row.Index];
                if (item.Visible)
                    isChanged = true;
                configList.RemoveAt(row.Index);
                this.dgvConfig.DataSource = configList.ToArray();
                MessageBox.Show("删除成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            if (this.dgvConfig.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择您要移动的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = this.dgvConfig.SelectedRows[0];
            if (row.Index == 0) return;
            int index = row.Index;
                       
            var doc = new XmlDocument();            
            doc.Load(xmlPath);
            var parentNode = doc.DocumentElement.SelectSingleNode("Charts");
            var nodeList = doc.DocumentElement.SelectNodes("Charts/Item");
            parentNode.InsertBefore(nodeList[index], nodeList[index - 1]);
            doc.Save(xmlPath);

            var tempItem = configList[index];
            configList[index] = configList[index - 1];
            configList[index - 1] = tempItem;
            this.dgvConfig.Rows[index - 1].Selected = true;
            if (configList[index].Visible && configList[index - 1].Visible)
                isChanged = true;
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            if (this.dgvConfig.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择您要移动的记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow row = this.dgvConfig.SelectedRows[0];
            if (row.Index == this.dgvConfig.Rows.Count - 1) return;
            int index = row.Index;

            var doc = new XmlDocument();
            doc.Load(xmlPath);
            var parentNode = doc.DocumentElement.SelectSingleNode("Charts");
            var nodeList = doc.DocumentElement.SelectNodes("Charts/Item");
            parentNode.InsertBefore(nodeList[index + 1], nodeList[index]);
            doc.Save(xmlPath);

            var tempItem = configList[index];
            configList[index] = configList[index + 1];
            configList[index + 1] = tempItem;
            this.dgvConfig.Rows[index + 1].Selected = true;

            if (configList[index].Visible && configList[index - 1].Visible)
                isChanged = true;
        }

        private void dgvConfig_SelectionChanged(object sender, EventArgs e)
        {
            this.EnableMoveButton();
        }

        private void FrmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                FrmMain.Instance.RefreshMainMenu();
            }
        }
        #endregion

        #region Methods
        private void EnableMoveButton()
        {
            if (this.dgvConfig.Rows.Count < 2 || this.dgvConfig.SelectedRows.Count < 1)
            {
                this.tsbMoveDown.Enabled = this.tsbMoveUp.Enabled = false;
            }
            else
            {
                if (this.dgvConfig.SelectedRows[0].Index == 0)
                {
                    this.tsbMoveDown.Enabled = true;
                    this.tsbMoveUp.Enabled = false;
                }
                else if (this.dgvConfig.SelectedRows[0].Index == this.dgvConfig.Rows.Count - 1)
                {
                    this.tsbMoveDown.Enabled = false;
                    this.tsbMoveUp.Enabled = true;
                }
                else
                {
                    this.tsbMoveDown.Enabled = this.tsbMoveUp.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Load Config.
        /// </summary>
        /// <returns></returns>
        private ConfigInfo LoadConfig()
        {
            var configObj = new ConfigInfo();
            var doc = new XmlDocument();
            doc.Load(xmlPath);
            configObj.AssemblyFile = doc.DocumentElement.SelectSingleNode("AssemblyFile").Attributes.GetNamedItem("Name").Value;

            ConfigInfo.ItemInfo configItemInfo;
            var nodeList = doc.DocumentElement.SelectNodes("Charts/Item");
            foreach (XmlNode node in nodeList)
            {
                var visible = Convert.ToBoolean(node.Attributes.GetNamedItem("Visible").Value);
                configItemInfo = new ConfigInfo.ItemInfo {
                    ClassName = node.Attributes.GetNamedItem("ClassName").Value,
                    ConfigFile = node.Attributes.GetNamedItem("ConfigFile").Value,
                    ShowTime = Convert.ToInt32(node.Attributes.GetNamedItem("ShowTime").Value),
                    UpdateTime = Convert.ToInt32(node.Attributes.GetNamedItem("UpdateTime").Value),
                    Title = node.Attributes.GetNamedItem("Title").Value,
                    Visible = visible
                };
                configObj.ConfigList.Add(configItemInfo);
            }
            return configObj;
        }
        #endregion

    }
}
