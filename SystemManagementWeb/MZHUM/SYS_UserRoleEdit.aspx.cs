using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Enum;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_UserRole1 的摘要说明。
	/// </summary>
	public partial class SYS_UserRoleEdit : BasePage
	{
		#region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
		

		#region Property
		/// <summary>
		/// 产品编号。
		/// </summary>
		public short ProductCode
		{
			get {return short.Parse(this.ViewState["ProductCode"].ToString());}
			set {this.ViewState["ProductCode"] = value;}
		}
        /// <summary>
        /// 访问对象ID。
        /// </summary>
	    public string CheckCode
	    {
            get { return this.ViewState["CheckCode"]==null?string.Empty:this.ViewState["CheckCode"].ToString(); }
            set { this.ViewState["CheckCode"] = value; }
	    }
        /// <summary>
        /// 访问对象类型。
        /// </summary>
	    public string Type
	    {
            get { return this.ViewState["Type"] == null?string.Empty:this.ViewState["Type"].ToString(); }
            set { this.ViewState["Type"] = value; }
	    }
        /// <summary>
        /// 用户登录名。
        /// </summary>
        public string UserId
        {
            get { return this.tb_UserIDs.Value; }
            set { this.tb_UserIDs.Value = value; }
        }
        /// <summary>
        /// 组Id。
        /// </summary>
        public short GroupId
        {
            get { return short.Parse(this.tb_GroupIDs.Value); }
            set { this.tb_GroupIDs.Value = value.ToString(); }
        }
		#endregion

        #region Method
        /// <summary>
        /// 用户信息绑定。
        /// </summary>
        private void empDataBind()
        {
            var dt = CreateUserRoleTable();

            if (tb_GroupIDs.Value.Trim() != "" || tb_UserIDs.Value.Trim() != "")
            {
                if (tb_GroupIDs.Value.Trim() != "")
                {
                    //var ids = Server.UrlDecode(tb_GroupIDs.Value.Trim()).Split(',');
                    //var names = Server.UrlDecode(tb_GroupNames.Value.Trim()).Split(',');

                    var ids = tb_GroupIDs.Value.Trim().Split(',');
                    var names =tb_GroupNames.Value.Trim().Split(',');

                    for (var i = 0; i < ids.Length; i++)
                    {
                        var dr = dt.NewRow();
                        dr["Code"] = ids[i];
                        dr["UserType"] = "Group";
                        dr["Name"] = names[i];
                        dt.Rows.Add(dr);
                    }

                    Emps.Visible = true;
                }
                if (tb_UserIDs.Value.Trim() != "")
                {
                    var ids = Server.UrlDecode(tb_UserIDs.Value.Trim()).Split(',');
                    var names = Server.UrlDecode(tb_UserNames.Value.Trim()).Split(',');

                    for (var i = 0; i < ids.Length; i++)
                    {
                        var dr = dt.NewRow();
                        dr["Code"] = ids[i];
                        dr["UserType"] = "Emp";
                        dr["Name"] = names[i];
                        dt.Rows.Add(dr);
                    }

                    Emps.Visible = true;
                }
            }
            else
            {
                Emps.Visible = false;
            }

            Emps.DataSource = dt;
            Emps.DataBind();
        }
        
        /// <summary>
        /// 创建用户角色数据表。
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable CreateUserRoleTable()
        {
            var dt = new DataTable("UserRoles");

            dt.Columns.Add("Code", typeof(System.String));
            dt.Columns.Add("UserType", typeof(System.String));
            dt.Columns.Add("Name", typeof(System.String));
            dt.Columns.Add("RoleNameList", typeof(System.String));
            return dt;
        }
        /// <summary>
        /// 设置用户的角色列表状态。
        /// </summary>
        /// <param name="userCode">用户名。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        private void SetCheckBoxList(string userCode,string checkCode, string type)
        {
            cblRoles.SelectedIndex = -1;

            if (userCode != "")
            {
                var userRoles = string.IsNullOrEmpty(checkCode) ? DataProvider.UserRoleProvider.GetByProductCodeAndUserName(this.ProductCode,userCode) : DataProvider.UserRoleProvider.GetByProductCodeAndUserNameAndCheckCodeAndType(this.ProductCode, userCode, checkCode, type);
                foreach (var obj in userRoles)
                {
                    foreach (ListItem oItem in this.cblRoles.Items)
                    {
                        if (obj.RoleCode.ToString() == oItem.Value)
                        {
                            oItem.Selected = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 设置组的角色状态列表。
        /// </summary>
        /// <param name="groupCode">组编号。</param>
        /// <param name="checkCode">检查对象编号。</param>
        /// <param name="type">检查对象类型。</param>
        private void SetCheckBoxList(short groupCode,string checkCode, string type)
        {
            cblRoles.SelectedIndex = -1;
            if (groupCode != 0)
            {
                var groupRoles = string.IsNullOrEmpty(checkCode) ? DataProvider.GroupRoleProvider.GetByProductCodeAndGroupCode(this.ProductCode,groupCode) : DataProvider.GroupRoleProvider.GetByProductCodeAndGroupCodeAndCheckCodeAndType(this.ProductCode, groupCode, checkCode, type);
                foreach (var obj in groupRoles)
                {
                    foreach (ListItem oItem in this.cblRoles.Items)
                    {
                        if (obj.RoleCode.ToString() == oItem.Value)
                        {
                            oItem.Selected = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 角色数据绑定。
        /// </summary>
        private void BindRole()
        {
            this.cblRoles.Items.Clear();
            var roles = DataProvider.RoleProvider.GetAllAvalibleByProductCode(this.ProductCode);
            
            foreach (var obj in roles)
            {
                var oItem = new ListItem(obj.RoleName, obj.RoleCode.ToString());
                this.cblRoles.Items.Add(oItem);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// 页面加载事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{			
				if(!CurrentUser.HasRight(RightEnum.UserRoleRightMaintain))
				{
                    this.SetNoRightInfo(true);
                    return;
				}
			    this.ProductCode = short.Parse(this.Request["ProductCode"]);
			    this.CheckCode = this.Request["CheckCode"];
			    this.Type = this.Request["Type"];

			    BindRole();

			    if (!string.IsNullOrEmpty(Request["UserId"]))
			    {
			        var a = Request["UserId"].Split(":".ToCharArray());
			        if (a.Length > 0 && a[0] == "E")
			        {
			            this.UserId = Server.UrlDecode(a[1]);
                        Logger.Debug(a[1]);
			            //var oUser = new Organize().GetEmployeeByCompanyAndLoginName(this.CompanyCode, this.UserId);
			            var userInfo = DataProvider.UserProvider.GetByLoginName(this.UserId);
			            this.tb_UserNames.Value = userInfo.EmpName;

			            this.empDataBind();
			            this.SetCheckBoxList(this.UserId, this.CheckCode, this.Type);
			        }
			        else if(a.Length > 0 && a[0]=="G")
			        {
			            this.GroupId = short.Parse(Server.UrlDecode(a[1]));

			            var groupInfo = DataProvider.GroupProvider.GetByCode(this.GroupId);
			            this.tb_GroupNames.Value = groupInfo.GroupName;

			            this.empDataBind();
			            this.SetCheckBoxList(this.GroupId,this.CheckCode,this.Type);
			        }
			    }
			}
        }
        /// <summary>
        /// Toolbar的postback事件。
        /// </summary>
        /// <param name="item">触发事件的ToolbarItem.</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "save":
                    
                    if (tb_UserIDs.Value.Trim() == "" && tb_GroupIDs.Value.Trim() == "")
                    {
                        AddScript(this.GetType(), "NoUser", "<script>alert('请选择至少一个用户或组！');</script>");
                        return;
                    }
                    if (cblRoles.SelectedIndex < 0)
                    {
                        AddScript(this.GetType(), "NoUser", "<script>alert('请选择至少一个角色！');</script>");
                        return;
                    }
                    var roleCodeList = "";
                    foreach (ListItem oItem in this.cblRoles.Items)
                    {
                        if(oItem.Selected)
                            roleCodeList += string.Format(roleCodeList.Length >0?",{0}":"{0}",oItem.Value);
                    }
                    
                    if (tb_GroupIDs.Value.Trim() != "")
                    {
                        //重新添加角色。
                        if(string.IsNullOrEmpty(this.CheckCode))
                        {
                            if(DataProvider.GroupRoleProvider.Insert(this.tb_GroupIDs.Value.Trim(), roleCodeList, this.ProductCode))
                            {
                                DataProvider.OperationLogProvider.Insert(new OperationLogInfo()
                                                                             {
                                                                                 UserName = this.CurrentUser.LoginName,
                                                                                 OpTime = DateTime.Now,
                                                                                 ProductCode = this.ProductCode,
                                                                                 OpType = OpTypeEnum.UserRoleOperation,
                                                                                 OpDesc = string.Format("组角色绑定 ProductCode:{2}-GroupIds:{0}-RoleCodes:{1}", this.tb_GroupIDs.Value, roleCodeList, ProductCode)
                                                                             });
                                tb_GroupIDs.Value = "";
                                tb_GroupNames.Value = "";
                                empDataBind();
                                cblRoles.SelectedIndex = -1;
                                AddScript( "<script>alert('绑定组角色成功！');</script>");
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            }
                            else
                            {
                                AddScript(this.GetType(), "AddGroupRoleFailed", "<script>alert('添加组角色失败！');</script>");
                            }
                        }
                        else
                        {
                            if (DataProvider.GroupRoleProvider.Insert(this.tb_GroupIDs.Value.Trim(), roleCodeList, this.CheckCode, this.Type))
                            {
                                DataProvider.OperationLogProvider.Insert(new OperationLogInfo()
                                {
                                    UserName = this.CurrentUser.LoginName,
                                    OpTime = DateTime.Now,
                                    ProductCode = this.ProductCode,
                                    OpType = OpTypeEnum.UserRoleOperation,
                                    OpDesc = string.Format("组角色绑定 CheckCode:{2}-Type:{3}-GroupIds:{0}-RoleCodes:{1}", this.tb_GroupIDs.Value, roleCodeList, CheckCode, this.Type),
                                });
                                tb_GroupIDs.Value = "";
                                tb_GroupNames.Value = "";
                                empDataBind();
                                cblRoles.SelectedIndex = -1;
                                AddScript("<script>alert('绑定组角色成功！');</script>");
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            }
                            else
                            {
                                AddScript(this.GetType(), "AddGroupRoleFailed", "<script>alert('添加组角色失败！');</script>");
                            }
                        }
                        
                    }
                    if (tb_UserIDs.Value.Trim() != "")
                    {
                        if(string.IsNullOrEmpty(this.CheckCode))
                        {
                            if (DataProvider.UserRoleProvider.Insert(Server.UrlDecode(tb_UserIDs.Value.Trim()), roleCodeList, this.ProductCode))
                            {
                                DataProvider.OperationLogProvider.Insert(new OperationLogInfo()
                                {
                                    UserName = this.CurrentUser.LoginName,
                                    OpTime = DateTime.Now,
                                    ProductCode = this.ProductCode,
                                    OpType = OpTypeEnum.UserRoleOperation,
                                    OpDesc = string.Format("用户角色绑定 ProductCode:{2}-UserIds:{0}-RoleCodes:{1}", Server.UrlDecode(this.tb_UserIDs.Value), roleCodeList, ProductCode)
                                });
                                tb_UserIDs.Value = "";
                                tb_UserNames.Value = "";
                                empDataBind();
                                cblRoles.SelectedIndex = -1;
                                AddScript("<script>alert('绑定用户角色成功！');</script>");
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            }
                            else
                            {
                                AddScript(this.GetType(), "AddUserRoleFailed", "<script>alert('添加用户角色失败！');</script>");
                            }
                        }
                        else
                        {
                            if(DataProvider.UserRoleProvider.Insert(Server.UrlDecode(tb_UserIDs.Value.Trim()),roleCodeList, this.CheckCode, this.Type))
                            {
                                DataProvider.OperationLogProvider.Insert(new OperationLogInfo()
                                {
                                    UserName = this.CurrentUser.LoginName,
                                    OpTime = DateTime.Now,
                                    ProductCode = this.ProductCode,
                                    OpType = OpTypeEnum.UserRoleOperation,
                                    OpDesc = string.Format("用户角色绑定 CheckCode:{2}-Type:{3}-UserIds:{0}-RoleCodes:{1}", Server.UrlDecode(this.tb_UserIDs.Value), roleCodeList, CheckCode, this.Type),
                                });
                                tb_UserIDs.Value = "";
                                tb_UserNames.Value = "";
                                empDataBind();
                                cblRoles.SelectedIndex = -1;
                                AddScript("<script>alert('绑定用户角色成功！');</script>");
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            }
                            else
                            {
                                AddScript(this.GetType(), "AddUserRoleFailed", "<script>alert('添加用户角色失败！');</script>");
                            }
                        }
                        
                    }
                    break;
            }
        }
        /// <summary>
        /// 选择用户按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_selectUser_Click(object sender, System.EventArgs e)
        {
            empDataBind();
        }
        #endregion

	}
}
