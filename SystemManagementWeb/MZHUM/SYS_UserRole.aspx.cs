using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Enum;
using Shmzh.Web.UI.Controls;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_UserRole1 ��ժҪ˵����
	/// </summary>
	public partial class SYS_UserRole : BasePage
	{
		#region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
		protected string CheckCode;
		protected string Type;
		//private int iStatus = 0 ;//0Ĭ��Ϊ���� 1Ϊ�û���ѯ 2 Ϊ��ɫ��ѯ
		#endregion

		#region Property
		/// <summary>
		/// ��Ʒ��š�
		/// </summary>
		public short ProductCode
		{
			get {return short.Parse(this.tb_ProductCode.Value);}
			set {this.tb_ProductCode.Value = value.ToString();}
		}
        IList<GroupInfo> GroupInfos { get; set; }
        IList<RoleInfo> RoleInfos { get; set; }
        IList<UserInfo> UserInfos { get; set; }

        /// <summary>
        /// �û���ɫ�б�
        /// </summary>
        public DataTable UserRoleDataTable
        {
            get { return this.Session["UserRole"] as DataTable; }
            set { this.Session["UserRole"] = value; }
        }
        /// <summary>
        /// ���ݰ󶨷�����־λ��
        /// </summary>
	    public int Flag
	    {
            get { return int.Parse(ViewState["Flag"].ToString()); }
            set { ViewState["Flag"] = value; }
	    }
		#endregion

        #region Method
        
        /// <summary>
        /// ���ݲ�Ʒ��Ż�ȡ�û������ɫ�б������ݰ󶨵�DataGrid��
        /// </summary>
        private void BindDataByProduct()
        {
            this.UserRoleDataTable = CreateUserRoleTable();

            var groupRoles = DataProvider.GroupRoleProvider.GetByProductCode(this.ProductCode);
            var userRoles = DataProvider.UserRoleProvider.GetByProductCode(this.ProductCode);
            //Logger.Info(userRoles.Count);
            this.FillUserRoleTable(groupRoles, this.UserRoleDataTable);
            this.FillUserRoleTable(userRoles, this.UserRoleDataTable);
            
            this.MzhDataGrid1.DataSource = this.UserRoleDataTable.DefaultView;
            this.MzhDataGrid1.DataBind();
        }
        /// <summary>
        /// ���ݲ�Ʒ��źͽ�ɫ��Ű����ݵ�DataGrid��
        /// </summary>
        private void BindDataByProductAndRole()
        {
            this.UserRoleDataTable = CreateUserRoleTable();

            var groupRoles = DataProvider.GroupRoleProvider.GetByRoleCode(short.Parse(this.tbiRole.SelectedValue));
            var userRoles = DataProvider.UserRoleProvider.GetByRoleCode(short.Parse(this.tbiRole.SelectedValue));

            this.FillUserRoleTable(groupRoles, this.UserRoleDataTable);
            this.FillUserRoleTable(userRoles, this.UserRoleDataTable);

            this.MzhDataGrid1.DataSource = this.UserRoleDataTable.DefaultView;
            this.MzhDataGrid1.DataBind();
        }
        /// <summary>
        /// ���ݲ�Ʒ��ź����������ݵ�DataGrid��
        /// </summary>
        private void BindDataByProductAndName()
        {
            this.UserRoleDataTable = CreateUserRoleTable();

            var groupRoles = DataProvider.GroupRoleProvider.GetByProductCodeAndName(this.ProductCode,this.tbiContent.Text.Trim());
            var userRoles = DataProvider.UserRoleProvider.GetByProductCodeAndName(this.ProductCode,this.tbiContent.Text.Trim());

            this.FillUserRoleTable(groupRoles, this.UserRoleDataTable);
            this.FillUserRoleTable(userRoles, this.UserRoleDataTable);

            this.MzhDataGrid1.DataSource = this.UserRoleDataTable.DefaultView;
            this.MzhDataGrid1.DataBind();
        }
        /// <summary>
        /// �������ݰ󶨱�־λ���Զ��������ݰ󶨡�
        /// </summary>
        private void myDataBind()
        {
            switch(this.Flag )
            {
                case 1:
                    this.BindDataByProduct();
                    break;
                case 2:
                    this.BindDataByProductAndName();
                    break;
                case 3:
                    if(this.tbiRole.SelectedValue=="-1")
                        this.BindDataByProduct();
                    else
                        this.BindDataByProductAndRole();
                    break;
            }
        }

	    /// <summary>
        /// �����Զ����û������ɫDataTable��
        /// </summary>
        /// <returns>DataTable</returns>
        private static DataTable CreateUserRoleTable()
        {
            var dt = new DataTable("UserRoles");
	        var keyColumn = new DataColumn("Code", typeof (string)); 
            dt.Columns.Add(keyColumn);
            dt.Columns.Add("UserType", typeof(System.String));
            dt.Columns.Add("Name", typeof(System.String));
            dt.Columns.Add("RoleNameList", typeof(System.String));
	        dt.PrimaryKey = new[] {keyColumn,};
            return dt;
        }
        /// <summary>
        /// �����ɫ����Ϣ��䵽�Զ���DataTable�С�
        /// </summary>
        /// <param name="groupRoleInfos">���ɫ���ϡ�</param>
        /// <param name="userRoleTable">�Զ���DataTable��</param>
        private void FillUserRoleTable(IEnumerable<GroupRoleInfo> groupRoleInfos, DataTable userRoleTable)
        {
            foreach (var obj1 in groupRoleInfos)
            {
                var obj = obj1;
                if (!this.UserRoleDataTable.Rows.Contains(string.Format("G:{0}", Server.UrlEncode(obj.GroupCode.ToString()))))
                {
                    var dr = userRoleTable.NewRow();
                    dr["Code"] = string.Format("G:{0}", Server.UrlEncode(obj.GroupCode.ToString()));
                    dr["UserType"] = "Group";

                    dr["Name"] = ((List<GroupInfo>)this.GroupInfos).Find(
                            o => o.GroupCode == obj.GroupCode).GroupName;

                    dr["RoleNameList"] = ((List<RoleInfo>)this.RoleInfos ).Find(
                        o => o.RoleCode == obj.RoleCode).RoleName;
                    this.UserRoleDataTable.Rows.Add(dr);
                }
                else
                {
                    var dr = userRoleTable.Rows.Find(string.Format("G:{0}", Server.UrlEncode(obj.GroupCode.ToString())));
                    dr["RoleNameList"] += string.Format(",{0}",
                                                        ((List<RoleInfo>)this.RoleInfos).Find(
                                                            o => o.RoleCode == obj.RoleCode).
                                                            RoleName);
                }
            }
        }
        /// <summary>
        /// ���û���ɫ����Ϣ��䵽�Զ���DataTable�С�
        /// </summary>
        /// <param name="userRoleInfos">�û���ɫ���ϡ�</param>
        /// <param name="userRoleTable">�Զ���DataTable��</param>
        private void FillUserRoleTable(IEnumerable<UserRoleInfo> userRoleInfos , DataTable userRoleTable)
        {
            foreach (var obj1 in userRoleInfos)
            {
                var obj = obj1;
                if (!this.UserRoleDataTable.Rows.Contains(string.Format("E:{0}", Server.UrlEncode(obj.UserName))))
                {
                    var dr = userRoleTable.NewRow();
                    dr["Code"] = string.Format("E:{0}", Server.UrlEncode(obj.UserName));
                    dr["UserType"] = "Emp";
                    var user = ((List<UserInfo>)this.UserInfos).Find(o => o.LoginName == obj.UserName);
                    if(user != null)
                    {
                        dr["Name"] = ((List<UserInfo>)this.UserInfos).Find(o => o.LoginName == obj.UserName).EmpName;
                        dr["RoleNameList"] = ((List<RoleInfo>)this.RoleInfos).Find(o => o.RoleCode == obj.RoleCode).RoleName;
                        this.UserRoleDataTable.Rows.Add(dr);    
                    }
                }
                else
                {
                    var dr = userRoleTable.Rows.Find(string.Format("E:{0}", Server.UrlEncode(obj.UserName)));
                    dr["RoleNameList"] += string.Format(",{0}", ((List< RoleInfo >) this.RoleInfos).Find(o => o.RoleCode == obj.RoleCode).RoleName);
                }
            }
        }
        /// <summary>
        /// �󶨽�ɫ�����б�
        /// </summary>
        private void BindRole()
        {
            this.tbiRole.Items.Clear();
            var roles = DataProvider.RoleProvider.GetAllAvalibleByProductCode(this.ProductCode);
            this.tbiRole.Items.Add(new ListItem("ȫ��", "-1"));
            foreach (var obj in roles)
            {
                var oItem = new ListItem(obj.RoleName, obj.RoleCode.ToString());
                this.tbiRole.Items.Add(oItem);
            }
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, System.EventArgs e)
		{
            this.ProductCode = short.Parse(this.Request["ProductCode"]);
            this.GroupInfos = DataProvider.GroupProvider.GetAll();
            this.RoleInfos = DataProvider.RoleProvider.GetAllAvalibleByProductCode(this.ProductCode);
            this.UserInfos = DataProvider.UserProvider.GetByProductCode(this.ProductCode);
            //Logger.Info(string.Format("userinfos's count:{0}",this.UserInfos.Count));
            if(!this.IsPostBack)
			{			
				if(!CurrentUser.HasRight(RightEnum.UserRoleRightMaintain))
				{
                    this.SetNoRightInfo(true);
                    return;
				}
			    
                
			    switch(this.ProductCode)
                {
                    case ProductEnum.KM: //֪ʶ�⡣
                        if(!CurrentUser.HasRight(RightEnum.KM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.MM: //���Ϲ���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.MM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.RS: //��Դ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.RS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PC: //Ѳ�����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PC))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.VM: //��Ӧ�̹���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.VM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        } 
                        break;
                    case ProductEnum.QA: //ˮ�ʷ���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.QA))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PD: //��������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PD))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PM: //��Ŀ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.SD: //��������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.SD))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.WS: //��վ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.WS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.FW: //ϵͳ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.FW))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.CM: //��ͬ����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.CM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.ET: //ʳ�ù���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.ET))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.EP: //���ù���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.EP))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.SM: //����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.SM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.QF: //ˮ��Ԥ��ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.QF))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.MT: //�������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.MT))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PR: //��������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PR))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PDV: //�����豸����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PDV))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.OA: //OA��ҳϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.OA))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PS: //�������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PG: //�����ɼ�ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.PG))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.AM: //��������ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.AM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.GQ: //ȫ�ֲ�ѯϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.GQ))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.HR: //���¹���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.HR))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.CW: //���չ���ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.CW))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.ODV: //�����豸����ϵͳ��
                        if (!CurrentUser.HasRight(RightEnum.ODV))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.WF://����������ϵͳ��
                        if(!CurrentUser.HasRight(RightEnum.WF))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                }
			    this.Flag = 1;
			    this.myDataBind();
			    this.BindRole();
			}
        }
        /// <summary>
        /// Toolbar��postback�¼���
        /// </summary>
        /// <param name="item">�����¼���ToolbarItem��</param>
        protected void MzhToolbar1_ItemPostBack1(ToolbarItem item)
        {
            switch (item.ItemId.ToUpper())
            {
                case "QUERY":
                    this.Flag = 2;
                    this.myDataBind();
                    break;
                case "ROLE":
                    this.Flag = 3;
                    this.myDataBind();
                    break;
                case "DELETE":
                    var user_group = this.MzhDataGrid1.SelectedID.Split(":".ToCharArray())[0];
                    var loginName = this.MzhDataGrid1.SelectedID.Split(":".ToCharArray())[1];

                    if (user_group == "E")
                    {
                        DataProvider.UserRoleProvider.Delete(loginName, this.ProductCode);
                        DataProvider.OperationLogProvider.Insert(new OperationLogInfo
                                                                     {
                                                                         UserName = this.CurrentUser.LoginName,
                                                                         OpTime = DateTime.Now,
                                                                         ProductCode = this.ProductCode,
                                                                         OpType = OpTypeEnum.UserRoleOperation,
                                                                         OpDesc = string.Format("ɾ���û���ɫ LoginName:{0},ProductCode:{1}", loginName, ProductCode)
                                                                     });
                    }
                    else
                    {
                        DataProvider.GroupRoleProvider.Delete(loginName, this.ProductCode);
                        DataProvider.OperationLogProvider.Insert(new OperationLogInfo
                        {
                            UserName = this.CurrentUser.LoginName,
                            OpTime = DateTime.Now,
                            ProductCode = this.ProductCode,
                            OpType = OpTypeEnum.UserRoleOperation,
                            OpDesc = string.Format("ɾ�����ɫ GroupCode:{0},ProductCode:{1}", loginName, ProductCode)
                        });
                    }
                    foreach (DataRow oRow in this.UserRoleDataTable.Rows)
                    {
                        if (oRow["Code"].ToString() == this.MzhDataGrid1.SelectedID)
                        {
                            this.UserRoleDataTable.Rows.Remove(oRow);
                            break;
                        }
                    }
                    this.MzhDataGrid1.DataSource = this.UserRoleDataTable;
                    this.MzhDataGrid1.DataBind();
                    break;
            }
        }
        /// <summary>
        /// DataGrid�ķ�ҳ�¼���
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void MzhDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.MzhDataGrid1.DataSource = this.UserRoleDataTable;
            this.MzhDataGrid1.DataBind();
        }
        /// <summary>
        /// ˢ�°�ť�¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, System.EventArgs e)
        {
            this.myDataBind();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
	    protected void MzhDataGrid1_PageSizeChanged(object sender, EventArgs e)
	    {
            this.MzhDataGrid1.DataSource = this.UserRoleDataTable;
            this.MzhDataGrid1.DataBind();
        }
        #endregion
    }
}
