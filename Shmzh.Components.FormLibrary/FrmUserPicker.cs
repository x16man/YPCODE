using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.IDAL;

namespace Shmzh.Components.FormLibrary
{
    public partial class FrmUserPicker : Form
    {
        private String _loginName;
        private TreeNode _selectedNode;

        public FrmUserPicker()
        {
            InitializeComponent();
        }

        public FrmUserPicker(String loginName) : this()
        {
            _loginName = loginName;
        }

        public FrmUserPicker(UserInfo selectedUser) : this()
        {
            this.SelectedUser = selectedUser;
        }
              
        /// <summary>
        /// 获取或设置选中的用户。
        /// </summary>
        public UserInfo SelectedUser { get; set; }

        #region Events
        private void FrmUserPicker_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_loginName) && (this.SelectedUser != null))
            {
                _loginName = this.SelectedUser.LoginName;
            }
            String companyCode = DataProvider.CompanyProvider.GetDefault().CoCode;
            var deptInfos = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(companyCode) as List<DeptInfo>;
            var userInfos = DataProvider.UserProvider.GetAllUserByCompany(companyCode) as List<UserInfo>;
            CreatTree(deptInfos, userInfos, this.tvUser);

            this.tvUser.ExpandAll();
            if (_selectedNode != null) this.tvUser.SelectedNode = _selectedNode;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConfirmSelect();
        }

        private void tvUser_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.tvUser.SelectedNode == null || !(this.tvUser.SelectedNode.Tag is UserInfo)) return;
            ConfirmSelect();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 创建树。
        /// </summary>
        /// <param name="depts">部门DataTable。</param>
        /// <param name="users">人员DataTable。</param>
        /// <param name="tv">TreeView。</param>
        private void CreatTree(List<DeptInfo> depts, List<UserInfo> users, TreeView tv)
        {
            var subDepts = depts.FindAll(obj => obj.ParentDept == "-1");
            if (subDepts.Count > 0)
            {
                foreach (var obj in subDepts)
                {                   
                    var tn = new TreeNode { Tag = obj.DeptCode, Text = obj.DeptCnName, ImageIndex = 0, SelectedImageIndex = 0 };
                    AddSubNode(depts, users, tn);
                    tv.Nodes.Add(tn);                   
                }
            }
            var tnOther = new TreeNode { Tag = "-100", Text = "外部会员", ImageIndex = 0, SelectedImageIndex = 0 };
            AddSubNode(depts, users, tnOther);
            tv.Nodes.Add(tnOther);
            tnOther.Expand();
        }

        /// <summary>
        /// 增加子节点。
        /// </summary>
        /// <param name="depts">部门DataTable。</param>
        /// <param name="users">人员DataTable。</param>
        /// <param name="tn">父节点。</param>
        private void AddSubNode(List<DeptInfo> depts, List<UserInfo> users, TreeNode tn)
        {
            var deptUsers = users.FindAll(obj => obj.DeptCode == tn.Tag.ToString());
            deptUsers.Sort((a, b) => a.LoginName.CompareTo(b.LoginName));

            foreach (var obj in deptUsers)
            {
                var subTn = new TreeNode
                {
                    Tag = obj,
                    ToolTipText = String.Format("用户：{0}\r\n工号：{1}\r\n姓名：{2}\r\n部门：{3}", obj.LoginName, obj.EmpCode, obj.EmpName, obj.DeptName),
                    Text = obj.EmpName,
                    ImageIndex = 1,
                    SelectedImageIndex = 1
                };                
                tn.Nodes.Add(subTn);
                
                if (!String.IsNullOrEmpty(_loginName) && _loginName.Equals(obj.LoginName, StringComparison.OrdinalIgnoreCase))
                {
                    _selectedNode = subTn;
                }                
            }

            var subDepts = depts.FindAll(obj => obj.ParentDept == tn.Tag.ToString());
            if (subDepts.Count > 0)
            {
                foreach (var obj in subDepts)
                {
                    var subTn = new TreeNode
                    {
                        Tag = obj.DeptCode,
                        Text = obj.DeptCnName,
                        ImageIndex = 0,
                        SelectedImageIndex = 0
                    };
                    AddSubNode(depts, users, subTn);
                    tn.Nodes.Add(subTn);
                }
            }
        }

        private void ConfirmSelect()
        {
            if (this.tvUser.SelectedNode == null || !(this.tvUser.SelectedNode.Tag is UserInfo))
            {
                MessageBox.Show("请选择人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UserInfo user = this.tvUser.SelectedNode.Tag as UserInfo;
            this.SelectedUser = user;
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
