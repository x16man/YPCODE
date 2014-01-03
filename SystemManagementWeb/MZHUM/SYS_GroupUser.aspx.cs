namespace SystemManagement.MZHUM
{
    using System;
    using System.Configuration;
    using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SystemComponent.DALFactory;
    using ComponentArt.Web.UI;

    /// <summary>
	/// SYS_GroupUser 的摘要说明。
	/// </summary>
	public partial class SYS_GroupUser : BasePage
    {
        #region Field

        private static readonly string GROUPUSERINSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupUserInsertFailed"));
        private static readonly string GROUPUSERINSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupUserInsertSuccess"));
        private static readonly string GROUPUSERDELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupUserDeleteFailed"));
        private static readonly string GROUPUSERDELETESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupUserDeleteSuccess"));
        private static readonly string GROUPCATDELETEFAILED = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupCatDeleteFailed"));
        private static readonly string GROUPCATDELETESUCCESS = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupCatDeleteSuccess"));
        private static readonly string GROUPDELETEFAILED = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupDeleteFailed"));
        private static readonly string GROUPDELETESUCCESS = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupDeleteSuccess"));
        
        private static readonly string NOSELECTEDUSER = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("GroupNoChooseUser"));

        #endregion

        #region Property
        public short GroupCode
        {
            get { return short.Parse(ViewState["GroupCode"].ToString()); }
            set { ViewState["GroupCode"] = value;}
        }
        /// <summary>
        /// 所有人的组编号。
        /// </summary>
        public short EveryOneGroupCode
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["EveryOneGroup"]))
                    return 0;
                else
                    return short.Parse(ConfigurationManager.AppSettings["EveryOneGroup"]);
            }
        }

        public string SelectedNodeId
        {
            get
            {
                return this.ViewState["SelectedNodeId"] == null?string.Empty:this.ViewState["SelectedNodeId"].ToString();
            }
            set { this.ViewState["SelectedNodeId"] = value; }
        }
		#endregion

		#region private method
		/// <summary>
		/// 绑定组信息.
		/// </summary>
		private void BindGroups()
		{
            this.tvGroup.Nodes.Clear();
		    var groupCats = DataProvider.GroupCatProvider.GetAll() as ListBase<GroupCatInfo>;
            groupCats.Sort("SerialNo");
            var groups = DataProvider.GroupProvider.GetAll() as ListBase<GroupInfo>;
		    var otherGroups = groups.FindAll(o => o.GroupCatId == 0);
            otherGroups.Sort("SerialNo");
            if(otherGroups.Count > 0)
            {
                var oNode = new TreeViewNode {ID = "C0", Value = "0", Text = "其他", ToolTip = "自动产生的组分类", ImageUrl = "folders.gif", Expanded = true};
                tvGroup.Nodes.Add(oNode);
                foreach(var obj in otherGroups)
                {
                    var gusers = DataProvider.GroupUserProvider.GetByGroupCode(obj.GroupCode);
                    var gNode = new TreeViewNode
                    {
                        ID = obj.GroupCode.ToString(),
                        Value = obj.GroupCode.ToString(),
                        Text = gusers.Count > 0?string.Format("{0}({1})",obj.GroupName,gusers.Count):obj.GroupName,
                        ToolTip = string.Format("G{0}-{1}-{2}", obj.GroupCode, obj.Remark, obj.SerialNo),
                    };
                    oNode.Nodes.Add(gNode);
                }
            }
            
            if(groupCats.Count > 0)
            {
                foreach(var obj in groupCats)
                {
                    var oNode = new TreeViewNode {ID=string.Format("C{0}",obj.Id),Value = obj.Id.ToString(), Text = obj.Name, ToolTip = obj.Remark, ImageUrl="folders.gif"};
                    tvGroup.Nodes.Add(oNode);
                    var thisGroups = groups.FindAll(o => o.GroupCatId == obj.Id);
                    thisGroups.Sort("SerialNo");
                    if(thisGroups.Count > 0)
                    {
                        foreach (var obj1 in thisGroups)
                        {
                            var gusers = DataProvider.GroupUserProvider.GetByGroupCode(obj1.GroupCode);
                            var gNode = new TreeViewNode
                            {
                                ID = obj1.GroupCode.ToString(),
                                Value = obj1.GroupCode.ToString(),
                                Text = gusers.Count > 0?string.Format("{0}({1})", obj1.GroupName, gusers.Count):obj1.GroupName,
                                ToolTip = string.Format("{0}-{1}-{2}", obj1.GroupCode, obj1.Remark, obj1.SerialNo),
                            };
                            oNode.Nodes.Add(gNode);
                        }
                    }
                }
            }
            if(tvGroup.Nodes.Count > 0)
            {
                if(tvGroup.Nodes[0].Nodes.Count > 0)
                {
                    //this.tvGroup.SelectedNode = tvGroup.Nodes[0].Nodes[0];
                    this.GroupCode = short.Parse(tvGroup.Nodes[0].Nodes[0].Value);
                    this.BindGroupUsers();
                }
            }
		}
		/// <summary>
		/// 绑定组成员用户.
		/// </summary>
		private void BindGroupUsers()
		{
		    var objs = DataProvider.UserProvider.GetByGroupCode(this.GroupCode);
		    mdg_GroupUserList.DataSource = objs;
			mdg_GroupUserList.DataBind();
		}
		#endregion

		#region Event
		/// <summary>
		/// 页面的Load事件.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if(!CurrentUser.HasRight(RightEnum.GroupView))
				{
                    this.SetNoRightInfo(true);
				}
				else
				{
					BindGroups();
                    this.tbiAddUser.Visible = false;
				    this.tbiDeleteUser.Visible = false;
                    if (this.tvGroup.Nodes.Count > 0)
                    {
                        this.tvGroup.SelectedNode = this.tvGroup.Nodes[0];
                        //this.GroupCode = short.Parse(this.tvGroup.Nodes[0].Value);
                        //this.BindGroupUsers();
                        //if (this.GroupCode != this.EveryOneGroupCode)
                        //{
                        this.tbiAddGroup.Visible = true;
                        this.tbiEditGroup.Visible = true;
                        this.tbiDeleteGroup.Visible = true;
                        this.tbiAddUser.Visible = true;
                        this.tbiDeleteUser.Visible = true;
                        //}
                    }
				}
			}
		    this.mdg_GroupUserList.AutoDataBind = BindGroupUsers;
		}
        /// <summary>
        /// 组工具条回送事件。
        /// </summary>
        /// <param name="item">触发事件的ToolbarItem。</param>
        protected void MzhToolbar_Group_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch(item.ItemId.ToUpper())
            {
                case "REFRESH":
                    this.BindGroups();
                    break;
                case "DELETEGROUPCAT":
                    if(tvGroup.SelectedNode == null || tvGroup.SelectedNode.ID.Substring(0,1)!="C")
                    {
                        AddScript("<script>alert('没有选中的组分类！');</script>");
                    }
                    else
                    {
                        var groups = DataProvider.GroupProvider.GetAll() as ListBase<GroupInfo>;
                        if(groups == null)
                        {
                            if (DataProvider.GroupCatProvider.Delete(short.Parse(this.tvGroup.SelectedNode.Value)))
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "DeleteGroupCatNode", "tvGroup_DeleteNode()", true);

                                AddScript(GROUPCATDELETESUCCESS);
                            }
                            else
                            {
                                AddScript(GROUPCATDELETEFAILED);
                            }
                        }
                        else if (!groups.Exists(obj => obj.GroupCatId == short.Parse(this.tvGroup.SelectedNode.Value)))
                        {
                            if (DataProvider.GroupCatProvider.Delete(short.Parse(this.tvGroup.SelectedNode.Value)))
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "DeleteGroupCatNode", "tvGroup_DeleteNode()", true);

                                AddScript(GROUPCATDELETESUCCESS);
                            }
                            else
                            {
                                AddScript(GROUPCATDELETEFAILED);
                            }
                        }
                        else
                        {
                            AddScript("<script>alert('该分类下还存在组，不能进行删除！');</script>");
                        }
                    }
                    break;
                case "DELETEGROUP":
                    if(tvGroup.SelectedNode == null || this.tvGroup.SelectedNode.ID.Substring(0,1)=="C")
                    {
                        AddScript("<script>alert('没有选中的用户组！');</script>");
                    }
                    else
                    {
                        if (DataProvider.GroupProvider.Delete(short.Parse(this.tvGroup.SelectedNode.Value)))
                        {
                            //this.BindGroups();
                            ClientScript.RegisterStartupScript(this.GetType(), "DeleteNode", "tvGroup_DeleteNode()", true);
                            this.tvGroup.Nodes.Remove(tvGroup.SelectedNode);
                        
                            AddScript(GROUPDELETESUCCESS);
                        }
                        else
                        {
                            AddScript(GROUPDELETEFAILED);
                        }
                    }
                    break;
                case "DELETEUSER":
                    if (this.mdg_GroupUserList.SelectedArray.Length > 0)
                    {
                        var userIds = this.mdg_GroupUserList.SelectedArray.Split(',');
                        for(var i=0;i<userIds.Length;i++)
                        {
                            var obj = new GroupUserInfo{GroupCode = this.GroupCode,UserCode = userIds[i],};
                            if (DataProvider.GroupUserProvider.Delete(obj))
                            {

                            }
                            else
                            {
                                AddScript(GROUPUSERDELETEFAILED_SCRIPT);
                                break;
                            }
                        }
                        AddScript(GROUPUSERDELETESUCCESS_SCRIPT);
                        this.BindGroupUsers();
                    }
                    else
                    {
                        AddScript(NOSELECTEDUSER);
                    }
                    break;
            }
        }
        
        /// <summary>
        /// 增加组用户按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddGroupUser_Click(object sender, EventArgs e)
        {
            if(DataProvider.GroupUserProvider.Insert(this.GroupCode, Server.UrlDecode(this.txtLoginNames.Value)))
            {
                this.BindGroupUsers();
                AddScript(GROUPUSERINSERTSUCCESS_SCRIPT);
            }
            else
            {
                AddScript(GROUPUSERINSERTFAILED_SCRIPT);
            }
        }
        /// <summary>
        /// 组树节点选中事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvGroup_NodeSelected(object sender, TreeViewNodeEventArgs e)
        {
            if(e.Node.ParentNode != null)
            {
                this.GroupCode = short.Parse(e.Node.Value);
                this.BindGroupUsers();
            }
            this.SelectedNodeId = e.Node.ID;
            
        }
        #endregion

        protected void tvGroup_NodeMoved(object sender, TreeViewNodeMovedEventArgs e)
        {
            if(e.Node.ParentNode != null && e.Node.ParentNode.ParentNode == null)
            {
                var group = DataProvider.GroupProvider.GetByCode(short.Parse(e.Node.Value));

                if (group.GroupCatId == short.Parse(e.Node.ParentNode.Value))//分类不变。
                {
                    for (var i = 0; i < e.Node.ParentNode.Nodes.Count;i++ )
                    {
                        var obj = DataProvider.GroupProvider.GetByCode(short.Parse(e.Node.ParentNode.Nodes[i].Value));
                        obj.SerialNo =(short)( i + 1);
                        DataProvider.GroupProvider.Update(obj);
                    }
                }
                else//跨分类转移。
                {
                    for (var i = 0; i < e.Node.ParentNode.Nodes.Count; i++)
                    {
                        var obj = DataProvider.GroupProvider.GetByCode(short.Parse(e.Node.ParentNode.Nodes[i].Value));
                        obj.SerialNo = (short)(i + 1);
                        if (i == e.Node.GetCurrentIndex())
                            obj.GroupCatId = short.Parse(e.Node.ParentNode.Value);
                        DataProvider.GroupProvider.Update(obj);
                    } 
                }
                
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGroups();
            var node = this.tvGroup.FindNodeById(this.SelectedNodeId);
            if(node != null)
            {
                this.tvGroup.SelectedNode = node;
                node.Expanded = true;    
            }
        }
    }
}
