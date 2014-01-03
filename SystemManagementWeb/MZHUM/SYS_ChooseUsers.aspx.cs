using System;
using System.Collections.Generic;
using ComponentArt.Web.UI;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_ChooseUsers 的摘要说明。
	/// </summary>
	public partial class SYS_ChooseUsers :BasePage
	{
		#region 成员变量
private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		protected string IdInitializtion = string.Empty;
		protected string NameInitializtion = string.Empty;
		protected string GroupIdInitializtion = string.Empty;
		protected string GroupNameInitializtion = string.Empty;
		#endregion

		#region 属性
		/// <summary>
		/// 当前选中的用户ID。
		/// </summary>
		protected string[] UserIDs
		{
			get
			{
			    return !string.IsNullOrEmpty(Request["UserIds"]) ? Request["UserIds"].Split(',') : null;
			}
		}
		/// <summary>
		/// 当前选中的组。
		/// </summary>
		protected string[] GroupIDs
		{
			get {return !string.IsNullOrEmpty(Request["GroupIds"]) ? Request["GroupIds"].Split(',') : null;}
		}
        /// <summary>
        /// 是否只列出用户。
        /// </summary>
        protected bool IncludeAll
        {
            get { return !string.IsNullOrEmpty(Request["Include"]) && Request["Include"].Trim().ToUpper() == "ALL"; }
        }
        /// <summary>
        /// 是否包括外部用户。
        /// </summary>
        protected bool IncludeOutSide
        {
            get { return string.IsNullOrEmpty(Request["WithOutSide"]) || Request["WithOutSide"].Trim().ToUpper() == "Y"; }
        }
        /// <summary>
        /// 是否包括组。
        /// </summary>
	    protected bool IncludeGroup
	    {
            get { return !string.IsNullOrEmpty(Request["WithGroup"]) && Request["WithGroup"].Trim().ToUpper() == "Y"; }
	    }
		#endregion

		#region 方法
		/// <summary>
		/// 创建树
		/// </summary>
		/// <param name="depts">部门集合</param>
		/// <param name="users">用户集合</param>
		/// <param name="tv">TreeView控件。</param>
		private void CreatTree(ListBase<DeptInfo> depts,ListBase<UserInfo> users,ComponentArt.Web.UI.TreeView tv)
		{
		    var subDepts = depts.FindAll(obj => obj.ParentDept == "-1");
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
        	foreach(var obj in subDepts)
			{
                var tn = new TreeViewNode
                             {
                                 ID = obj.DeptCode,
                                 Value = obj.DeptCode,
                                 Text = obj.DeptCnName,
                                 CssClass = "RootNode",
                                 Expanded = true
                             };
			    AddSubNode(depts, users, tn);

				tv.Nodes.Add(tn);
			}
            if (this.IncludeOutSide)
            {
                var tnOther = new TreeViewNode {ID = "-100", Text = "外部会员", CssClass = "RootNode"};
                AddSubNode(depts, users, tnOther);
                tv.Nodes.Add(tnOther);
            }
		}
		/// <summary>
		/// 增加子节点。
		/// </summary>
		/// <param name="depts">部门集合。</param>
		/// <param name="users">用户集合。</param>
		/// <param name="tn">树节点。</param>
		private void AddSubNode(ListBase<DeptInfo> depts,ListBase<UserInfo> users,TreeViewNode tn)
		{
		    var subUsers = users.FindAll(obj => obj.DeptCode == tn.ID);
		    tn.Text = string.Format("{0}({1})", tn.Text, subUsers.Count);

            subUsers.Sort("SerialNo,LoginName");
            
            foreach (var obj in subUsers)
            {
                var subTn = new TreeViewNode
                {
                    ID = string.Format("{0}|{1}",obj.PKID,obj.LoginName),
                    Value = obj.EmpCode,
                    Text = obj.EmpName,
                    ImageUrl = "user.png",
                    ShowCheckBox = true
                };

                if (this.UserIDs != null && this.UserIDs.Length > 0)
                {
                    for (var j = 0; j < this.UserIDs.Length; j++)
                    {
                        Logger.Info(string.Format("{0}-{1}",this.UserIDs[j],subTn.ID.Split('|')[1]));
                        if (subTn.ID.Split('|')[1] == this.UserIDs[j])
                        {
                            this.IdInitializtion += string.Format(this.IdInitializtion == string.Empty ? @"'{0}'" : @",'{0}'", subTn.ID);
                            this.NameInitializtion += string.Format(this.NameInitializtion == string.Empty ? @"'{0}'" : @",'{0}'", subTn.Text);
                            subTn.Checked = true;
                        }
                    }
                }
                tn.Nodes.Add(subTn);
            }
            
		    var subDepts = depts.FindAll(obj => obj.ParentDept == tn.ID);
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
			if(subDepts.Count > 0)
			{
				foreach(var obj in subDepts)
				{
                    var subTn = new TreeViewNode
                                             {
                                                 ID = obj.DeptCode,
                                                 Value = obj.DeptCode,
                                                 Text = obj.DeptCnName,
                                             };
				    AddSubNode(depts,users,subTn);
                    if (tn.Parent == null )
                        tn.Expanded = true;
					tn.Nodes.Add(subTn);
				}
			}
		}
        /// <summary>
        /// 构建组树。
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="tv"></param>
        private void CreateGroup(IList<GroupInfo> groups, ComponentArt.Web.UI.TreeView tv)
        {

            var othergroups = ((ListBase<GroupInfo>)groups).FindAll(item => item.GroupCatId == 0);
            othergroups.Sort("SerialNo");
            if(othergroups.Count > 0 )
            {
                var oNode = new TreeViewNode
                                {
                                    ID = "C0",
                                    Value = "0",
                                    Text = "其他",
                                    ShowCheckBox = false,
                                };
                tv.Nodes.Add(oNode);
                foreach (var obj in othergroups)
                {
                    var isChecked = false;
                    if(this.GroupIDs != null)
                    {
                        for (var i = 0; i < this.GroupIDs.Length;i++ )
                        {
                            if(GroupIDs[i] == obj.GroupCode.ToString())
                            {
                                isChecked =true;
                                break;
                            }
                        }
                    }
                    if(isChecked)
                    {
                        oNode.Nodes.Add(new TreeViewNode
                        {
                            ID = obj.GroupCode.ToString(),
                            Value = obj.GroupCode.ToString(),
                            Text = obj.GroupName,
                            ShowCheckBox = true,
                            Checked = true,
                        });
                    }
                    else
                    {
                        oNode.Nodes.Add(new TreeViewNode
                        {
                            ID = obj.GroupCode.ToString(),
                            Value = obj.GroupCode.ToString(),
                            Text = obj.GroupName,
                            ShowCheckBox = true,
                            Checked = false,
                        });
                    }    
                }
            }
            var groupCats = DataProvider.GroupCatProvider.GetAll();
            foreach(var cat1 in groupCats)
            {
                var cat = cat1;
                var gps = ((ListBase<GroupInfo>) groups).FindAll(item => item.GroupCatId == cat.Id);
                gps.Sort("SerialNo");
                if(gps.Count> 0)
                {
                    var oNode = new TreeViewNode {ID = string.Format("C{0}", cat.Id), Value = cat.Id.ToString(), Text = cat.Name,};
                    foreach(var obj in gps)
                    {
                        var isChecked = false;
                        if (this.GroupIDs != null)
                        {
                            for (var i = 0; i < this.GroupIDs.Length; i++)
                            {
                                if (GroupIDs[i] == obj.GroupCode.ToString())
                                {
                                    isChecked = true;
                                    break;
                                }
                            }
                        }
                        oNode.Nodes.Add(isChecked
                                            ? new TreeViewNode {ID = obj.GroupCode.ToString(), Value = obj.GroupCode.ToString(), Text = obj.GroupName, ShowCheckBox = true, Checked = true,}
                                            : new TreeViewNode {ID = obj.GroupCode.ToString(), Value = obj.GroupCode.ToString(), Text = obj.GroupName, ShowCheckBox = true, Checked = false,});
                    }
                    tv.Nodes.Add(oNode);
                }
            }
        }
        #endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
                var depts = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(this.CompanyCode) as List<DeptInfo>;

			    var users = new List<UserInfo>();

                if (this.IncludeAll == false && this.IncludeOutSide == false)
                    users = DataProvider.UserProvider.GetInnerUserByCompany(this.CompanyCode) as ListBase<UserInfo>;
                else if (this.IncludeAll == false && this.IncludeOutSide)
                    users = DataProvider.UserProvider.GetAllUserByCompany(this.CompanyCode) as ListBase<UserInfo>;
                else if (this.IncludeAll && this.IncludeOutSide == false)
                    users = DataProvider.UserProvider.GetInnerUserByCompany(this.CompanyCode) as ListBase<UserInfo>;
                else if (this.IncludeAll && this.IncludeOutSide)
                    users = DataProvider.UserProvider.GetAllByCompany(this.CompanyCode) as ListBase<UserInfo>;


                this.CreatTree(depts as ListBase<DeptInfo>, users as ListBase<UserInfo>, tvDept);

                if (this.IncludeGroup)
                {
                    var groupList = DataProvider.GroupProvider.GetAll() as ListBase<GroupInfo>;
                    if(groupList != null)
                    {
                        groupList.Sort("SerialNo");
                        CreateGroup(groupList, this.tvGroup);    
                    }
                    this.Image1.Visible = true;
                    this.Image2.Visible = true;
                }
			    AddScript(this.GetType(),"ShowDeptTree","<script>showDeptTree();</script>");
			}			
		}
        /// <summary>
        /// 提交按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userIds = string.Empty,
                   userCodes = string.Empty,
                   userNames = string.Empty,
                   deptCodes = string.Empty,
                   deptNames = string.Empty,
                   pkIds = string.Empty;
            string groupIds = string.Empty, groupNames = string.Empty;
            foreach(var oNode in tvDept.CheckedNodes)
            {
                pkIds += string.Format(pkIds.Length > 0 ? ",{0}" : "{0}", oNode.ID.Split('|')[0]);
                userIds += string.Format(userIds.Length > 0 ? ",{0}" : "{0}", oNode.ID.Split('|')[1]);
                userCodes += string.Format(userCodes.Length > 0?",{0}":"{0}",oNode.Value);
                userNames += string.Format(userNames.Length > 0?",{0}":"{0}",oNode.Text);
                deptCodes += string.Format(deptCodes.Length>0?",{0}":"{0}",oNode.ParentNode.ID);
                deptNames += string.Format(deptNames.Length > 0?",{0}":"{0}",oNode.ParentNode.Text);
            }
            foreach (var oNode in tvGroup.CheckedNodes)
            {
                if (oNode.Checked)
                {
                    groupIds += string.Format(groupIds.Length > 0 ? ",{0}" : "{0}", oNode.Value);
                    groupNames += string.Format(groupNames.Length > 0 ? ",{0}" : "{0}", oNode.Text);
                }
            }
            /*
             * loginName,empCode,empName,deptCode,deptName,groupId,groupName.
             */
            var script = string.Format("<script>window.opener.setUserInfo('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');window.close();</script>", Server.UrlEncode(userIds), userCodes, userNames, deptCodes, deptNames, groupIds, groupNames, pkIds);
            AddScript(this.GetType(), "FeedBack", script);
        }
	}
}
