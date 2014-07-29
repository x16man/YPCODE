using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using Shmzh.Monitor.Data;
using Shmzh.Monitor.Entity;

namespace Shmzh.Monitor.Forms
{
    public partial class FrmSchemaPicker : Form
    {
        #region Fields
        /// <summary>
        /// 方案类别列表。
        /// </summary>
        private List<CategoryInfo> categoryList;
        private bool _isSuperUser = Common.GetIsSuperUser();
        #endregion

        public FrmSchemaPicker()
        {
            InitializeComponent();
            this.imgListTV.Images.Add(Properties.Resources.door_in);
            this.imgListTV.Images.Add(Properties.Resources.application_side_boxes);
            this.imgListTV.Images.Add(Properties.Resources.user);
            categoryList = DataProvider.CategoryProvider.GetAll();
        }

        /// <summary>
        /// 选中的曲线方案名或配置文件名。
        /// </summary>
        public String ConfigFile { get; private set; }

        private void FrmSchemaPicker_Load(object sender, EventArgs e)
        {
            BindSchemeTreeView();
            if (_isSuperUser)
            {
                BindXmlTreeView();
            }
            else
            {
                this.tabCtlMain.TabPages.Remove(this.tabPgXml);
            }
        }

        private void BindXmlTreeView()
        {
            String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\");
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            List<String> localFiles = new List<String>();
            //取本地全部配置文件，筛选后做为“未分类配置文件”。
            if (dirInfo.Exists)
            {
                FileInfo[] files = dirInfo.GetFiles("*.xml", SearchOption.TopDirectoryOnly);
                localFiles = new List<string>(files.Length);
                foreach (var file in files)
                {
                    if (file.Name.Equals("config.xml", StringComparison.OrdinalIgnoreCase))
                        continue;
                    localFiles.Add(file.Name);
                }
            }
            //取数据库中已分类的配置文件。
            var schemaList = DataProvider.CategoryItemProvider.GetXmlItemInfo();
            foreach (var entity in categoryList)
            {
                //如果用户不是超级用户，且该分类仅超级用户可见。
                if (!_isSuperUser && !entity.IsPublic)
                    continue;
                TreeNode tn = new TreeNode(entity.CategoryName);
                tn.ImageIndex = tn.SelectedImageIndex = 0;
                tn.Tag = entity;
                this.tvXml.Nodes.Add(tn);

                var tmpList = schemaList.FindAll(o => o.CategoryId == entity.CategoryId);
                foreach (var categoryItemInfo in tmpList)
                {
                    TreeNode tnXml = new TreeNode(categoryItemInfo.ConfigFile);
                    tnXml.Tag = categoryItemInfo.ConfigFile;
                    tnXml.ImageIndex = tnXml.SelectedImageIndex = 1;
                    tnXml.ToolTipText = String.Format("标题：{0}\r\n双击选择", categoryItemInfo.Title);
                    tn.Nodes.Add(tnXml);
                    
                    //从本地列表中删除已经分类的配置文件。
                    if(localFiles.Count > 0)
                    {
                        String tmpFile = localFiles.Find(o=>o.Equals(categoryItemInfo.ConfigFile, StringComparison.OrdinalIgnoreCase));
                        if(tmpFile != null)
                        {
                            localFiles.Remove(tmpFile);
                        }
                    }
                }
            }
            //未分类配置文件。
            if (localFiles.Count > 0)
            {
                TreeNode tn = new TreeNode("未分类XML方案");
                tn.ImageIndex = tn.SelectedImageIndex = 0;
                CategoryInfo categoryInfo = new CategoryInfo()
                {
                    CategoryId = -100,
                    CategoryName = "未分类XML方案",
                };
                tn.Tag = categoryInfo;
                this.tvXml.Nodes.Add(tn);

                foreach (var tmpFile in localFiles)
                {
                    TreeNode tnXml = new TreeNode(tmpFile);
                    tnXml.Tag = tmpFile;
                    tnXml.ImageIndex = tnXml.SelectedImageIndex = 1;
                    tnXml.ToolTipText = String.Format("双击选择：{0}", tmpFile);
                    tn.Nodes.Add(tnXml);
                }
            }
            this.tvXml.ExpandAll();
        }

        /// <summary>
        /// 生成目录树。
        /// </summary>
        private void BindSchemeTreeView()
        {
            this.tvScheme.Nodes.Clear();
            foreach (var entity in categoryList)
            {
                if (!_isSuperUser && !entity.IsPublic)
                    continue;
                if (Common.CurrentUser.HasRight(entity.RightCode))
                {
                    TreeNode tn = new TreeNode(entity.CategoryName);
                    tn.ImageIndex = tn.SelectedImageIndex = 0;
                    tn.Tag = entity;
                    this.tvScheme.Nodes.Add(tn);

                    var schemaList = DataProvider.GraphSchemaProvider.GetByCategoryId(entity.CategoryId);
                    foreach (var schemaInfo in schemaList)
                    {
                        TreeNode tnSchema = new TreeNode(schemaInfo.Name);
                        tnSchema.Tag = schemaInfo;
                        tnSchema.ImageIndex = tnSchema.SelectedImageIndex = 1;
                        tnSchema.ToolTipText = String.Format("双击选择：{0}", schemaInfo.Name);
                        tn.Nodes.Add(tnSchema);
                    }
                }
            }
            if (Common.CurrentUser.LoginName.ToLower() == "administrator")
            {
                TreeNode tn = new TreeNode("所有未分类方案");
                tn.ImageIndex = tn.SelectedImageIndex = 0;
                CategoryInfo categoryInfo = new CategoryInfo()
                {
                    CategoryId = -100,
                    CategoryName = "所有未分类方案",
                };
                tn.Tag = categoryInfo;
                this.tvScheme.Nodes.Add(tn);

                var schemaList = DataProvider.GraphSchemaProvider.GetNoCategorySchema(null);
                List<String> loginNames = new List<String>();
                foreach (var schemaInfo in schemaList)
                {
                    if (!loginNames.Contains(schemaInfo.ReferLoginName))
                    {
                        loginNames.Add(schemaInfo.ReferLoginName);
                    }
                }

                foreach (String loginName in loginNames)
                {
                    TreeNode tnLoginName = new TreeNode(loginName);
                    CategoryInfo tmpCategoryInfo = new CategoryInfo()
                    {
                        CategoryId = -101,
                        CategoryName = loginName,
                    };
                    tnLoginName.Tag = tmpCategoryInfo;
                    tnLoginName.ImageIndex = tnLoginName.SelectedImageIndex = 2;
                    tn.Nodes.Add(tnLoginName);

                    var tmpList = schemaList.FindAll(o => o.ReferLoginName.Equals(loginName, StringComparison.OrdinalIgnoreCase));
                    foreach (var schemaInfo in tmpList)
                    {
                        TreeNode tnSchema = new TreeNode(schemaInfo.Name);
                        tnSchema.Tag = schemaInfo;
                        tnSchema.ImageIndex = tnSchema.SelectedImageIndex = 1;
                        tnSchema.ToolTipText = String.Format("双击选择：{0}", schemaInfo.Name);
                        tnLoginName.Nodes.Add(tnSchema);
                    }
                }
            }
            else
            {
                TreeNode tn = new TreeNode("我的未分类方案");
                tn.ImageIndex = tn.SelectedImageIndex = 0;
                CategoryInfo categoryInfo = new CategoryInfo()
                {
                    CategoryId = -200,
                    CategoryName = "我的未分类方案",
                };
                tn.Tag = categoryInfo;
                this.tvScheme.Nodes.Add(tn);

                var schemaList = DataProvider.GraphSchemaProvider.GetNoCategorySchema(Common.CurrentUser.LoginName);
                foreach (var schemaInfo in schemaList)
                {
                    TreeNode tnSchema = new TreeNode(schemaInfo.Name);
                    tnSchema.Tag = schemaInfo;
                    tnSchema.ImageIndex = tnSchema.SelectedImageIndex = 1;
                    tnSchema.ToolTipText = String.Format("双击选择：{0}", schemaInfo.Name);
                    tn.Nodes.Add(tnSchema);
                }
            }
            this.tvScheme.ExpandAll();
        }

        private void tvScheme_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is GraphSchemaInfo)
            {
                var schemaInfo = e.Node.Tag as GraphSchemaInfo;
                this.ConfigFile = schemaInfo.Name;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tvXml_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is String)
            {
                var configFile = e.Node.Tag as String;
                this.ConfigFile = configFile;
                this.DialogResult = DialogResult.OK;
            }
        }       
    }
}
