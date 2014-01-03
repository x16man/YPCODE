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
	/// SYS_UserRole1 ��ժҪ˵����
	/// </summary>
	public partial class SYS_UserRoleEdit : BasePage
	{
		#region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
		

		#region Property
		/// <summary>
		/// ��Ʒ��š�
		/// </summary>
		public short ProductCode
		{
			get {return short.Parse(this.ViewState["ProductCode"].ToString());}
			set {this.ViewState["ProductCode"] = value;}
		}
        /// <summary>
        /// ���ʶ���ID��
        /// </summary>
	    public string CheckCode
	    {
            get { return this.ViewState["CheckCode"]==null?string.Empty:this.ViewState["CheckCode"].ToString(); }
            set { this.ViewState["CheckCode"] = value; }
	    }
        /// <summary>
        /// ���ʶ������͡�
        /// </summary>
	    public string Type
	    {
            get { return this.ViewState["Type"] == null?string.Empty:this.ViewState["Type"].ToString(); }
            set { this.ViewState["Type"] = value; }
	    }
        /// <summary>
        /// �û���¼����
        /// </summary>
        public string UserId
        {
            get { return this.tb_UserIDs.Value; }
            set { this.tb_UserIDs.Value = value; }
        }
        /// <summary>
        /// ��Id��
        /// </summary>
        public short GroupId
        {
            get { return short.Parse(this.tb_GroupIDs.Value); }
            set { this.tb_GroupIDs.Value = value.ToString(); }
        }
		#endregion

        #region Method
        /// <summary>
        /// �û���Ϣ�󶨡�
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
        /// �����û���ɫ���ݱ�
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
        /// �����û��Ľ�ɫ�б�״̬��
        /// </summary>
        /// <param name="userCode">�û�����</param>
        /// <param name="checkCode">�������š�</param>
        /// <param name="type">���������͡�</param>
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
        /// ������Ľ�ɫ״̬�б�
        /// </summary>
        /// <param name="groupCode">���š�</param>
        /// <param name="checkCode">�������š�</param>
        /// <param name="type">���������͡�</param>
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
        /// ��ɫ���ݰ󶨡�
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
        /// ҳ������¼���
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
        /// Toolbar��postback�¼���
        /// </summary>
        /// <param name="item">�����¼���ToolbarItem.</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "save":
                    
                    if (tb_UserIDs.Value.Trim() == "" && tb_GroupIDs.Value.Trim() == "")
                    {
                        AddScript(this.GetType(), "NoUser", "<script>alert('��ѡ������һ���û����飡');</script>");
                        return;
                    }
                    if (cblRoles.SelectedIndex < 0)
                    {
                        AddScript(this.GetType(), "NoUser", "<script>alert('��ѡ������һ����ɫ��');</script>");
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
                        //������ӽ�ɫ��
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
                                                                                 OpDesc = string.Format("���ɫ�� ProductCode:{2}-GroupIds:{0}-RoleCodes:{1}", this.tb_GroupIDs.Value, roleCodeList, ProductCode)
                                                                             });
                                tb_GroupIDs.Value = "";
                                tb_GroupNames.Value = "";
                                empDataBind();
                                cblRoles.SelectedIndex = -1;
                                AddScript( "<script>alert('�����ɫ�ɹ���');</script>");
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            }
                            else
                            {
                                AddScript(this.GetType(), "AddGroupRoleFailed", "<script>alert('������ɫʧ�ܣ�');</script>");
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
                                    OpDesc = string.Format("���ɫ�� CheckCode:{2}-Type:{3}-GroupIds:{0}-RoleCodes:{1}", this.tb_GroupIDs.Value, roleCodeList, CheckCode, this.Type),
                                });
                                tb_GroupIDs.Value = "";
                                tb_GroupNames.Value = "";
                                empDataBind();
                                cblRoles.SelectedIndex = -1;
                                AddScript("<script>alert('�����ɫ�ɹ���');</script>");
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            }
                            else
                            {
                                AddScript(this.GetType(), "AddGroupRoleFailed", "<script>alert('������ɫʧ�ܣ�');</script>");
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
                                    OpDesc = string.Format("�û���ɫ�� ProductCode:{2}-UserIds:{0}-RoleCodes:{1}", Server.UrlDecode(this.tb_UserIDs.Value), roleCodeList, ProductCode)
                                });
                                tb_UserIDs.Value = "";
                                tb_UserNames.Value = "";
                                empDataBind();
                                cblRoles.SelectedIndex = -1;
                                AddScript("<script>alert('���û���ɫ�ɹ���');</script>");
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            }
                            else
                            {
                                AddScript(this.GetType(), "AddUserRoleFailed", "<script>alert('����û���ɫʧ�ܣ�');</script>");
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
                                    OpDesc = string.Format("�û���ɫ�� CheckCode:{2}-Type:{3}-UserIds:{0}-RoleCodes:{1}", Server.UrlDecode(this.tb_UserIDs.Value), roleCodeList, CheckCode, this.Type),
                                });
                                tb_UserIDs.Value = "";
                                tb_UserNames.Value = "";
                                empDataBind();
                                cblRoles.SelectedIndex = -1;
                                AddScript("<script>alert('���û���ɫ�ɹ���');</script>");
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            }
                            else
                            {
                                AddScript(this.GetType(), "AddUserRoleFailed", "<script>alert('����û���ɫʧ�ܣ�');</script>");
                            }
                        }
                        
                    }
                    break;
            }
        }
        /// <summary>
        /// ѡ���û���ť�¼���
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
