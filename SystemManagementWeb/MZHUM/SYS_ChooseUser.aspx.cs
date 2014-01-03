using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

using ComponentArt.Web.UI;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_ChooseUser 的摘要说明。
	/// </summary>
	public partial class SYS_ChooseUser : BasePage
	{
		protected void  Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
                //if (string.IsNullOrEmpty(this.Request["WorkFlow"]))
                //{

                    var deptInfos = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(this.CompanyCode) as ListBase<DeptInfo>;
                    ListBase<UserInfo> userInfos;
                    if (!string.IsNullOrEmpty(this.Request["Include"]) && this.Request["Include"] == "all")
                    {
                        userInfos = DataProvider.UserProvider.GetAllAvalibleByCompany(this.CompanyCode) as ListBase<UserInfo>;
                    }
                    else
                    {
                        userInfos = DataProvider.UserProvider.GetAllUserByCompany(this.CompanyCode) as ListBase<UserInfo>;
                    }

                    CreatTree(deptInfos, userInfos, this.tvUser);
                //}
                //else
                //{
                //    var orgs = DataProvider.TB_OrgTreeProvider.GetAllAvalible() as ListBase<TB_ORGTREEInfo>;
                //    var userInfos = DataProvider.TB_UsersProvider.GetAllAvalible() as ListBase<TB_UsersInfo>;
                //    var orgmems = DataProvider.TB_OrgMemLkProvider.GetAllAvalible() as ListBase<TB_ORGMEMLKInfo>;

                //    CreateTree(orgs, userInfos, orgmems, this.tvUser);
                //}
			}	
		}

        #region Method
        /// <summary>
        /// 创建树。
        /// </summary>
        /// <param name="depts">部门DataTable。</param>
        /// <param name="users">人员DataTable。</param>
        /// <param name="tv">TreeView。</param>
        private void CreatTree(ListBase<DeptInfo> depts,ListBase<UserInfo> users,TreeView tv)
		{
            var subDepts = depts.FindAll(obj=>obj.ParentDept == "-1");
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));

			if(subDepts.Count > 0)
			{
                foreach(var obj in subDepts)
                {
                    var tn = new TreeViewNode {ID = obj.DeptCode, Text = obj.DeptCnName, CssClass = "RootNode"};
                    AddSubNode(depts, users, tn);
                    tn.Expanded = true;
                    tv.Nodes.Add(tn);
                }
			}
            if(!string.IsNullOrEmpty(this.Request["withoutside"]) && this.Request["withoutside"].ToUpper() =="Y" )
            {
                var tnOther = new TreeViewNode { ID = "-100", Text = "外部会员", CssClass = "RootNode" };
                AddSubNode(depts, users, tnOther);
                tnOther.Expanded = true;
                tv.Nodes.Add(tnOther);
            }
		}

        //private void CreateTree(ListBase<TB_ORGTREEInfo> depts, ListBase<TB_UsersInfo> users, ListBase<TB_ORGMEMLKInfo> orgmembers, TreeView tv)
        //{
        //    var subDepts = depts.FindAll(obj => obj.ParentID == 0);

        //    if (subDepts.Count > 0)
        //    {
        //        foreach (var obj in subDepts)
        //        {
        //            var tn = new TreeViewNode { ID = obj.ItemID.ToString(), Text = obj.ItemName, CssClass = "RootNode" };
        //            AddSubNode(depts, users, orgmembers, tn);
        //            tn.Expanded = true;
        //            tv.Nodes.Add(tn);
        //        }
        //    }
        //}
        /// <summary>
        /// 增加子节点。
        /// </summary>
        /// <param name="depts">部门DataTable。</param>
        /// <param name="users">人员DataTable。</param>
        /// <param name="tn">父节点。</param>
		private static void AddSubNode(ListBase<DeptInfo> depts,ListBase<UserInfo> users,TreeViewNode tn)
		{
            var deptUsers = users.FindAll(obj => obj.DeptCode == tn.ID);
            deptUsers.Sort("SerialNo,LoginName");
            
            foreach (var obj in deptUsers)
            {
                var subTn = new TreeViewNode
                {
                    ID = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", obj.LoginName,obj.EmpCode,obj.EmpName,obj.DeptCode,obj.DeptName,obj.PKID,obj.DutyName),
                    Value = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", obj.LoginName,obj.EmpCode,obj.EmpName,obj.DeptCode,obj.DeptName,obj.PKID,obj.DutyName),
                    Text = obj.EmpName,
                    ImageUrl = "User.png"
                };
                tn.Nodes.Add(subTn);
            }
            
            var subDepts = depts.FindAll(obj => obj.ParentDept == tn.ID);
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
			if(subDepts.Count > 0)
			{
                foreach (var obj in subDepts)
                {
                    var subTn = new TreeViewNode
                                {
                                    ID = obj.DeptCode,
                                    Value = obj.DeptCode,
                                    Text = obj.DeptCnName,
                                };
                    AddSubNode(depts, users, subTn);
                    tn.Nodes.Add(subTn);
                }
			}
        }
        //private static void AddSubNode(ListBase<TB_ORGTREEInfo> depts, ListBase<TB_UsersInfo> users, ListBase<TB_ORGMEMLKInfo> orgmembers, TreeViewNode tn)
        //{
        //    var orgmems = orgmembers.FindAll(obj => obj.OrgId == int.Parse(tn.ID));

        //    foreach (var obj in orgmems)
        //    {
        //        var userinfo = users.Find(o => o.UserId == obj.UserId && o.Enalbe == true);
        //        var orgInfo = depts.Find(o => o.ItemID == obj.OrgId && o.Enable == true);

        //        var subTn = new TreeViewNode
        //        {
        //            ID = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", userinfo.UserName, userinfo.HRID, userinfo.UserDspName, orgInfo.ItemID, orgInfo.ItemName, userinfo.UserId, userinfo.JobTitle),
        //            Value = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", userinfo.UserName, userinfo.HRID, userinfo.UserDspName, orgInfo.ItemID, orgInfo.ItemName, userinfo.UserId, userinfo.JobTitle),
        //            Text = userinfo.UserDspName,
        //            ImageUrl = "User.png"
        //        };
        //        tn.Nodes.Add(subTn);
        //    }

        //    var subDepts = depts.FindAll(obj => obj.ParentID == int.Parse(tn.ID));
        //    if (subDepts.Count > 0)
        //    {
        //        foreach (var obj in subDepts)
        //        {
        //            var subTn = new TreeViewNode
        //            {
        //                ID = obj.ItemID.ToString(),
        //                Value = obj.ItemID.ToString(),
        //                Text = obj.ItemName,
        //            };
        //            AddSubNode(depts, users,orgmembers, subTn);
        //            tn.Nodes.Add(subTn);
        //        }
        //    }
        //}
        #endregion
    }
}
