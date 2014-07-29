using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Shmzh.OnlineUpgradeConfig
{
    public partial class FrmMain : Form
    {
        private OpenType _openType;
        private String _openFileName;

        public FrmMain()
        {
            InitializeComponent();
        }

        private enum OpenType
        {
            ConfigFile,
            AppFolder
        }

        #region Event Handlers
        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                String fileName = this.openFileDialog1.FileName;

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileName);
                    XmlNode xmlNode = doc.DocumentElement.SelectSingleNode("Version");
                    this.txtVersion.Text = xmlNode.InnerText.Trim();
                    //XmlNodeList nodeList = doc.DocumentElement.SelectNodes("FileList/File[@IsNeedUpdate=\"True\"]");
                    XmlNodeList nodeList = doc.DocumentElement.SelectNodes("FileList/File");
                    this.lvFiles.BeginUpdate();
                    this.lvFiles.Items.Clear();
                    foreach (XmlNode node in nodeList)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Checked = Convert.ToBoolean(node.Attributes.GetNamedItem("IsNeedUpdate").Value);
                        item.Text = node.InnerText;
                        this.lvFiles.Items.Add(item);
                    }

                    if (this.lvFiles.Items.Count > 0)
                    {
                        this.btnSave.Enabled = this.btnSaveAs.Enabled = true;
                        this.columnHeader1.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                    this.lvFiles.EndUpdate();
                    _openFileName = fileName;
                    _openType = OpenType.ConfigFile;
                }
                catch
                {
                    MessageBox.Show(this, "该文件不是升级程序的配置文件，请选择有效的配置文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnOpenConfig_Click(sender, e);
                }
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                String folderPath = this.folderBrowserDialog1.SelectedPath;
                if (!folderPath.EndsWith("\\"))
                {
                    folderPath += "\\";
                }
                int preLen = folderPath.Length;

                var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
                if (files.Length == 0)
                {
                    MessageBox.Show(this, "该文件夹中没有任何文件，请选择要升级的程序的根目录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.btnOpenFolder_Click(sender, e);
                    return;
                }
                this.lvFiles.BeginUpdate();
                this.lvFiles.Items.Clear();
                foreach (var file in files)
                {
                    ListViewItem item = new ListViewItem();
                    item.Checked = true;
                    item.Text = file.Substring(preLen);
                    this.lvFiles.Items.Add(item);
                }

                if (this.lvFiles.Items.Count > 0)
                {
                    this.btnSave.Enabled = true;
                    this.btnSaveAs.Enabled = false;
                    this.columnHeader1.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                this.lvFiles.EndUpdate();

                _openType = OpenType.AppFolder;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
                return;
            if (_openType == OpenType.ConfigFile)
            {
                String fileName = this.openFileDialog1.FileName;
                String tmpFileName = fileName + ".tmp";
                try
                {
                    File.Move(fileName, tmpFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, String.Format("出错：{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (SaveConfig(fileName))
                {
                    try
                    {
                        File.Delete(tmpFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, String.Format("出错：{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        File.Move(tmpFileName, fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, String.Format("出错：{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (_openType == OpenType.AppFolder)
            {
                this.saveFileDialog1.FileName = "Upgrade.config";
                if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    SaveConfig(this.saveFileDialog1.FileName);
                }
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (_openType == OpenType.ConfigFile)
            {
                if (ValidInput())
                {
                    String fileName = this._openFileName;
                    String extension = Path.GetExtension(fileName);
                    fileName = fileName.Substring(0, fileName.Length - extension.Length) + "副本" + extension;

                    this.saveFileDialog1.FileName = fileName;
                    if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        SaveConfig(fileName);
                    }
                }                
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            this.lvFiles.BeginUpdate();
            foreach (ListViewItem item in this.lvFiles.Items)
            {
                item.Checked = chkAll.Checked;
            }
            this.lvFiles.EndUpdate();
        }

        private void chkOpposite_CheckedChanged(object sender, EventArgs e)
        {
            this.lvFiles.BeginUpdate();
            foreach (ListViewItem item in this.lvFiles.Items)
            {
                item.Checked = !item.Checked;
            }
            this.lvFiles.EndUpdate();
        }
        #endregion

        #region Private Methods
        private bool ValidInput()
        {
            String version = this.txtVersion.Text.Trim();
            if (version.Length == 0)
            {
                MessageBox.Show(this, "请输入版本号。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtVersion.Focus();
                return false;
            }
            if (this.lvFiles.Items.Count == 0)
            {
                MessageBox.Show(this, "没有要保存的项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存配置文件。保存成功返回true，保存失败返回false。
        /// </summary>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        private bool SaveConfig(String configFileName)
        {
            String version = this.txtVersion.Text.Trim();            
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode;
            XmlNode node;
            XmlNode fileListNode;

            rootNode = doc.CreateElement("configuration");
            doc.AppendChild(rootNode);
            XmlDeclaration xmldecl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.InsertBefore(xmldecl, rootNode);

            node = doc.CreateElement("Version");
            node.InnerText = this.txtVersion.Text;
            rootNode.AppendChild(node);

            fileListNode = doc.CreateElement("FileList");
            rootNode.AppendChild(fileListNode);

            foreach (ListViewItem item in this.lvFiles.Items)
            {
                node = doc.CreateElement("File");
                XmlNode attr = doc.CreateNode(XmlNodeType.Attribute, "IsNeedUpdate", null);
                attr.Value = item.Checked.ToString();
                node.Attributes.SetNamedItem(attr);
                node.InnerText = item.Text;
                fileListNode.AppendChild(node);
            }
            try
            {
                doc.Save(configFileName);

                if (MessageBox.Show(this, "保存成功，要打开保存的目录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select," + configFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, String.Format("出错：{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

    }
}
