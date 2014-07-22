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
    /// <summary>
    /// 多用户和组选择窗口。
    /// </summary>
    public partial class FrmUsersPicker : Form
    {
        private String[] _loginNames;
        private Int16[] _groupCodes;
        private Boolean _isIncludeGroup = true;
        private Boolean _isIncludeUser = true;
        private Boolean _isIncludeAll = true;        
        private Boolean _withCheckBox = true;
        #region Constructor
        public FrmUsersPicker()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数，是否显示复选框
        /// </summary>
        /// <param name="withCheckBox"></param>
        public FrmUsersPicker(bool withCheckBox)
        {
            _withCheckBox = withCheckBox;
            InitializeComponent();
        }
        /// <summary>
        /// 实例化多用户和组选择窗口。
        /// </summary>
        /// <param name="loginNames">用户登录名数组。</param>
        public FrmUsersPicker(String[] loginNames)
            : this()
        {
            _loginNames = loginNames;
        }
        /// <summary>
        /// 实例化多用户和组选择窗口。
        /// </summary>
        /// <param name="loginNames">用户登录名数组。</param>
        /// <param name="groupCodes">用户组编号数组。</param>
        public FrmUsersPicker(String[] loginNames, Int16[] groupCodes)
            : this()
        {
            _loginNames = loginNames;
            _groupCodes = groupCodes;
        }
        /// <summary>
        /// 实例化多用户和组选择窗口。
        /// </summary>
        /// <param name="loginNames">用户登录名数组。</param>
        /// <param name="isIncludeAll">是否全部员工，false表示只包含用户，true表示包含用户和员工。</param>
        /// <param name="isIncludeOutSide">是否包括外部用户。</param>
        /// <param name="isIncludeGroup">是否包括组。</param>
        public FrmUsersPicker(String[] loginNames, Boolean isIncludeAll, Boolean isIncludeOutSide, Boolean isIncludeGroup)
            : this(loginNames)
        {
            IsIncludeAll = isIncludeAll;
            IsIncludeOutSide = isIncludeOutSide;
            IsIncludeGroup = isIncludeGroup;
        }
        /// <summary>
        /// 实例化多用户和组选择窗口。
        /// </summary>
        /// <param name="loginNames">用户登录名数组。</param>
        /// <param name="groupCodes">用户组编号数组。</param>
        /// <param name="isIncludeAll">是否全部员工，false表示只包含用户，true表示包含用户和员工。</param>
        /// <param name="isIncludeOutSide">是否包括外部用户。</param>
        /// <param name="isIncludeGroup">是否包括组。</param>
        public FrmUsersPicker(String[] loginNames, Int16[] groupCodes, Boolean isIncludeAll, Boolean isIncludeOutSide, Boolean isIncludeGroup)
            : this(loginNames, groupCodes)
        {
            IsIncludeAll = isIncludeAll;
            IsIncludeOutSide = isIncludeOutSide;
            IsIncludeGroup = isIncludeGroup;
        }
        /// <summary>
        /// 实例化多用户和组选择窗口。
        /// </summary>
        /// <param name="selectedUsers">选中的用户。</param>
        public FrmUsersPicker(List<UserInfo> selectedUsers)
            : this()
        {
            this.SelectedUsers = selectedUsers;
        }
        /// <summary>
        /// 实例化多用户和组选择窗口。
        /// </summary>
        /// <param name="selectedUsers">选中的用户。</param>
        /// <param name="selectedGroups">选中的用户组。</param>
        public FrmUsersPicker(List<UserInfo> selectedUsers, List<GroupInfo> selectedGroups)
            : this()
        {
            this.SelectedUsers = selectedUsers;
            this.SelectedGroups = selectedGroups;
        }
        /// <summary>
        /// 实例化多用户和组选择窗口。
        /// </summary>
        /// <param name="selectedUsers">选中的用户。</param>
        /// <param name="isIncludeAll">是否全部员工，false表示只包含用户，true表示包含用户和员工。</param>
        /// <param name="isIncludeOutSide">是否包括外部用户。</param>
        /// <param name="isIncludeGroup">是否包括组。</param>
        public FrmUsersPicker(List<UserInfo> selectedUsers, Boolean isIncludeAll, Boolean isIncludeOutSide, Boolean isIncludeGroup)
            : this(selectedUsers)
        {
            IsIncludeAll = isIncludeAll;
            IsIncludeOutSide = isIncludeOutSide;
            IsIncludeGroup = isIncludeGroup;
        }
        /// <summary>
        /// 实例化多用户和组选择窗口。
        /// </summary>
        /// <param name="selectedUsers">选中的用户。</param>
        /// <param name="selectedGroups">选中的用户组。</param>
        /// <param name="isIncludeAll">是否全部员工，false表示只包含用户，true表示包含用户和员工。</param>
        /// <param name="isIncludeOutSide">是否包括外部用户。</param>
        /// <param name="isIncludeGroup">是否包括组。</param>
        public FrmUsersPicker(List<UserInfo> selectedUsers, List<GroupInfo> selectedGroups, Boolean isIncludeAll, Boolean isIncludeOutSide, Boolean isIncludeGroup)
            : this(selectedUsers, selectedGroups)
        {
            IsIncludeAll = isIncludeAll;
            IsIncludeOutSide = isIncludeOutSide;
            IsIncludeGroup = isIncludeGroup;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置选中的用户。
        /// </summary>
        public List<UserInfo> SelectedUsers { get; set; }

        /// <summary>
        /// 获取或设置选中的用户组。
        /// </summary>
        public List<GroupInfo> SelectedGroups { get; set; }

        /// <summary>
        /// 是否全部员工，false表示只包含用户，true表示包含用户和员工，默认为true。
        /// </summary>
        public Boolean IsIncludeAll { private get { return _isIncludeAll; } set { _isIncludeAll = value; } }
        /// <summary>
        /// 是否包括外部用户，默认为false。
        /// </summary>
        public Boolean IsIncludeOutSide { private get; set; }
        /// <summary>
        /// 是否包括组选择，默认为true。
        /// </summary>
        public Boolean IsIncludeGroup { private get { return _isIncludeGroup; } set { _isIncludeGroup = value; } }
        /// <summary>
        /// 是否包括用户选择，默认为true。
        /// </summary>
        public Boolean IsIncludeUser { private get { return _isIncludeUser; } set { _isIncludeUser = value; } }
        #endregion

        #region Events
        private void FrmUserPicker_Load(object sender, EventArgs e)
        {
            String companyCode = DataProvider.CompanyProvider.GetDefault().CoCode;
            if (_loginNames == null || _loginNames.Length == 0)
            {
                if (this.SelectedUsers != null && this.SelectedUsers.Count > 0)
                {
                    Int32 count = this.SelectedUsers.Count;
                    _loginNames = new String[count];

                    for (Int32 i = 0; i < count; i++)
                    {
                        _loginNames[i] = this.SelectedUsers[i].LoginName;
                    }
                }
            }
            if (_groupCodes == null || _groupCodes.Length == 0)
            {
                if (this.SelectedGroups != null && this.SelectedGroups.Count > 0)
                {
                    Int32 count = this.SelectedGroups.Count;
                    _groupCodes = new Int16[count];

                    for (Int32 i = 0; i < count; i++)
                    {
                        _groupCodes[i] = this.SelectedGroups[i].GroupCode;
                    }
                }
            }

            if (this.IsIncludeUser)
            {
                var depts = DataProvider.CreateDeptProvider().GetAllAvalibleCompanyCode(companyCode) as List<DeptInfo>;

                List<UserInfo> users = new List<UserInfo>();
                if (this.IsIncludeAll == false && this.IsIncludeOutSide == false)
                    users = DataProvider.UserProvider.GetInnerUserByCompany(companyCode) as ListBase<UserInfo>;
                else if (this.IsIncludeAll == false && this.IsIncludeOutSide)
                    users = DataProvider.UserProvider.GetAllUserByCompany(companyCode) as ListBase<UserInfo>;
                else if (this.IsIncludeAll && this.IsIncludeOutSide == false)
                    users = DataProvider.UserProvider.GetInnerUserByCompany(companyCode) as ListBase<UserInfo>;
                else if (this.IsIncludeAll && this.IsIncludeOutSide)
                    users = DataProvider.UserProvider.GetAllByCompany(companyCode) as ListBase<UserInfo>;

                this.CreatTree(depts as ListBase<DeptInfo>, users as ListBase<UserInfo>, tvUser);
                tvUser.ExpandAll();
                this.tvUser.Nodes[0].EnsureVisible();
            }
            else
            {
                this.tabUserGroup.TabPages.Remove(tpgUser);
            }

            if (this.IsIncludeGroup)
            {
                var groupList = DataProvider.CreateGroupProvider().GetAll();
                CreateGroup(groupList, tvGroup);
                tvGroup.ExpandAll();
                this.tvGroup.Nodes[0].EnsureVisible();
            }
            else
            {
                this.tabUserGroup.TabPages.Remove(tpgGroup);
            }
            this.pnlTop.Visible = this.tvUser.CheckBoxes = this.tvGroup.CheckBoxes = this._withCheckBox;
        }

        private void tvUser_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.tvUser.BeginUpdate();
            Shmzh.Components.Util.TreeViewCheck.CheckControl(e);
            this.tvUser.EndUpdate();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConfirmSelect();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 创建树
        /// </summary>
        /// <param name="depts">部门集合</param>
        /// <param name="users">用户集合</param>
        /// <param name="tv">TreeView控件。</param>
        private void CreatTree(ListBase<DeptInfo> depts, ListBase<UserInfo> users, TreeView tv)
        {
            var subDepts = depts.FindAll(obj => obj.ParentDept == "-1");
            subDepts.Sort((a, b) => a.Serial.CompareTo(b.Serial));
            foreach (var obj in subDepts)
            {
                var tn = new TreeNode { Tag = obj.DeptCode, Text = obj.DeptCnName, ImageIndex = 0, SelectedImageIndex = 0 };
                
                AddSubNode((ListBase<DeptInfo>)depts, (ListBase<UserInfo>)users, tn);

                tv.Nodes.Add(tn);
            }
            if (this.IsIncludeOutSide)
            {
                var tnOther = new TreeNode { Tag = "-100", Text = "外部会员", ImageIndex = 0, SelectedImageIndex = 0 };
                AddSubNode((ListBase<DeptInfo>)depts, (ListBase<UserInfo>)users, tnOther);
                tv.Nodes.Add(tnOther);
            }
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

                if (_loginNames != null && _loginNames.Length > 0)
                {
                    foreach (String loginName in _loginNames)
                    {
                        if (loginName.Equals(obj.LoginName, StringComparison.OrdinalIgnoreCase))
                        {
                            subTn.Checked = true;
                            TreeNode tnTemp = subTn;
                            while ((tnTemp = tnTemp.Parent) != null)
                            {
                                if (tnTemp.Checked) break;
                                tnTemp.Checked = true;
                            }
                            break;
                        }
                    }
                }
            }

            var subDepts = depts.FindAll(obj => obj.ParentDept == tn.Tag.ToString());
            subDepts.Sort((a, b) => a.Serial.CompareTo(b.Serial));
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

        /// <summary>
        /// 构建组树。
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="tv"></param>
        private void CreateGroup(IList<GroupInfo> groups, TreeView tv)
        {
            ((List<GroupInfo>)groups).Sort((a, b) => a.SerialNo.CompareTo(b.SerialNo));
            var groupCats = (List<GroupCatInfo>)DataProvider.GroupCatProvider.GetAll();
            groupCats.Sort((a, b) => a.SerialNo.CompareTo(b.SerialNo));
            bool other = false;
            TreeNode otherNode = new TreeNode { Text = "其他", ImageIndex = 2, SelectedImageIndex = 2 };
            foreach (var cat in groupCats)
            {
                var parentNode = new TreeNode { Tag = cat, Text = cat.Name, ImageIndex = 2, SelectedImageIndex = 2 };
                //tv.Nodes.Add(parentNode);
                foreach (var obj in groups)
                {
                    
                    var groupNode = new TreeNode { Tag = obj, Text = obj.GroupName, ImageIndex = 2, SelectedImageIndex = 2 };
                    //tv.Nodes.Add(groupNode);

                    if (_groupCodes != null && _groupCodes.Length > 0)
                    {
                        foreach (short groupCode in _groupCodes)
                        {
                            if (groupCode.Equals(obj.GroupCode))
                            {
                                groupNode.Checked = true;
                                break;
                            }
                        }
                    }
                    if (obj.GroupCatId == cat.Id)
                    {
                        parentNode.Nodes.Add(groupNode);
                    }
                }
                tv.Nodes.Add(parentNode);
            }
            foreach (var obj in groups)
            {
                var groupNode = new TreeNode { Tag = obj, Text = obj.GroupName, ImageIndex = 2, SelectedImageIndex = 2 };
                if (_groupCodes != null && _groupCodes.Length > 0)
                {
                    foreach (short groupCode in _groupCodes)
                    {
                        if (groupCode.Equals(obj.GroupCode))
                        {
                            groupNode.Checked = true;
                            break;
                        }
                    }
                }
                if (obj.GroupCatId == 0)
                {
                    other = true;
                    otherNode.Nodes.Add(groupNode);
                }
            }
            if (other)
            {
                tv.Nodes.Add(otherNode);
            }
        }

        /// <summary>
        /// 确认选择。
        /// </summary>
        private void ConfirmSelect()
        {
            this.SelectedUsers = new List<UserInfo>();
            this.SelectedGroups = new List<GroupInfo>();

            List<UserInfo> userList = GetSelectedUsers();            
            List<GroupInfo> groupList = GetSelectedGroups();

            if (userList.Count == 0 && groupList.Count == 0)
            {
                MessageBox.Show("您尚未选择任何用户或组。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.SelectedUsers = userList;
            this.SelectedGroups = groupList;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 获取所有选中的组。
        /// </summary>
        /// <returns>组列表。</returns>
        private List<GroupInfo> GetSelectedGroups()
        {
            List<GroupInfo> groupList = new List<GroupInfo>();
            if (this.IsIncludeGroup)
            {
                foreach (TreeNode treeNode in this.tvGroup.Nodes)
                {
                    if (treeNode.Nodes.Count == 0)
                    {
                        if (treeNode.Checked)
                        {
                            GroupInfo groupInfo = treeNode.Tag as GroupInfo;
                            groupList.Add(groupInfo);
                        }
                    }
                    else
                    {
                        foreach (TreeNode childNode in treeNode.Nodes)
                        {
                            if (childNode.Checked)
                            {
                                GroupInfo groupInfo = childNode.Tag as GroupInfo;
                                groupList.Add(groupInfo);
                            }
                        }
                    }
                }
            }
            return groupList;
        }

        /// <summary>
        /// 获取所有选中的用户。
        /// </summary>
        /// <returns>用户列表。</returns>
        private List<UserInfo> GetSelectedUsers()
        {
            List<UserInfo> userList = new List<UserInfo>();

            if (this.IsIncludeUser)
            {
                foreach (TreeNode treeNode in this.tvUser.Nodes)
                {
                    GetSelectedUsers(ref userList, treeNode);
                }
            }

            return userList;
        }

        /// <summary>
        /// 获取特定节点上的选中的用户。
        /// </summary>
        /// <param name="userList">用户列表</param>
        /// <param name="parentNode">树节点</param>
        private void GetSelectedUsers(ref List<UserInfo> userList, TreeNode parentNode)
        {
            foreach (TreeNode treeNode in parentNode.Nodes)
            {
                if (treeNode.Nodes.Count == 0)
                {
                    if (treeNode.Checked && (treeNode.Tag is UserInfo))
                    {
                        UserInfo userInfo = treeNode.Tag as UserInfo;

                        if (!userList.Contains(userInfo))
                        {
                            userList.Add(userInfo);
                        }
                    }
                }
                else
                {
                    GetSelectedUsers(ref userList, treeNode);
                }
            }
        }
        #endregion

        private void tvGroup_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.tvGroup.BeginUpdate();
            Shmzh.Components.Util.TreeViewCheck.CheckControl(e);
            this.tvGroup.EndUpdate();
        }
    }
}
