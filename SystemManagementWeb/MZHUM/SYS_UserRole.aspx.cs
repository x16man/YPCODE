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
	/// SYS_UserRole1 的摘要说明。
	/// </summary>
	public partial class SYS_UserRole : BasePage
	{
		#region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
		protected string CheckCode;
		protected string Type;
		//private int iStatus = 0 ;//0默认为正常 1为用户查询 2 为角色查询
		#endregion

		#region Property
		/// <summary>
		/// 产品编号。
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
        /// 用户角色列表。
        /// </summary>
        public DataTable UserRoleDataTable
        {
            get { return this.Session["UserRole"] as DataTable; }
            set { this.Session["UserRole"] = value; }
        }
        /// <summary>
        /// 数据绑定方案标志位。
        /// </summary>
	    public int Flag
	    {
            get { return int.Parse(ViewState["Flag"].ToString()); }
            set { ViewState["Flag"] = value; }
	    }
		#endregion

        #region Method
        
        /// <summary>
        /// 根据产品编号获取用户和组角色列表，将数据绑定到DataGrid。
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
        /// 根据产品编号和角色编号绑定数据到DataGrid。
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
        /// 根据产品编号和组名绑定数据到DataGrid。
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
        /// 根据数据绑定标志位，自动进行数据绑定。
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
        /// 创建自定义用户和组角色DataTable。
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
        /// 将组角色的信息填充到自定义DataTable中。
        /// </summary>
        /// <param name="groupRoleInfos">组角色集合。</param>
        /// <param name="userRoleTable">自定义DataTable。</param>
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
        /// 将用户角色的信息填充到自定义DataTable中。
        /// </summary>
        /// <param name="userRoleInfos">用户角色集合。</param>
        /// <param name="userRoleTable">自定义DataTable。</param>
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
        /// 绑定角色下拉列表。
        /// </summary>
        private void BindRole()
        {
            this.tbiRole.Items.Clear();
            var roles = DataProvider.RoleProvider.GetAllAvalibleByProductCode(this.ProductCode);
            this.tbiRole.Items.Add(new ListItem("全部", "-1"));
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
                    case ProductEnum.KM: //知识库。
                        if(!CurrentUser.HasRight(RightEnum.KM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.MM: //物料管理系统。
                        if (!CurrentUser.HasRight(RightEnum.MM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.RS: //资源管理系统。
                        if (!CurrentUser.HasRight(RightEnum.RS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PC: //巡检管理系统。
                        if (!CurrentUser.HasRight(RightEnum.PC))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.VM: //供应商管理系统。
                        if (!CurrentUser.HasRight(RightEnum.VM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        } 
                        break;
                    case ProductEnum.QA: //水质分析系统。
                        if (!CurrentUser.HasRight(RightEnum.QA))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PD: //党政建设系统。
                        if (!CurrentUser.HasRight(RightEnum.PD))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PM: //项目管理系统。
                        if (!CurrentUser.HasRight(RightEnum.PM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.SD: //智能桌面系统。
                        if (!CurrentUser.HasRight(RightEnum.SD))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.WS: //网站管理系统。
                        if (!CurrentUser.HasRight(RightEnum.WS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.FW: //系统管理系统。
                        if (!CurrentUser.HasRight(RightEnum.FW))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.CM: //合同管理系统。
                        if (!CurrentUser.HasRight(RightEnum.CM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.ET: //食堂管理系统。
                        if (!CurrentUser.HasRight(RightEnum.ET))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.EP: //费用管理系统。
                        if (!CurrentUser.HasRight(RightEnum.EP))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.SM: //短信系统。
                        if (!CurrentUser.HasRight(RightEnum.SM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.QF: //水质预测系统。
                        if (!CurrentUser.HasRight(RightEnum.QF))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.MT: //会议管理系统。
                        if (!CurrentUser.HasRight(RightEnum.MT))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PR: //生产报表系统。
                        if (!CurrentUser.HasRight(RightEnum.PR))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PDV: //生产设备管理系统。
                        if (!CurrentUser.HasRight(RightEnum.PDV))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.OA: //OA首页系统。
                        if (!CurrentUser.HasRight(RightEnum.OA))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PS: //生产监控系统。
                        if (!CurrentUser.HasRight(RightEnum.PS))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.PG: //生产采集系统。
                        if (!CurrentUser.HasRight(RightEnum.PG))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.AM: //报警管理系统。
                        if (!CurrentUser.HasRight(RightEnum.AM))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.GQ: //全局查询系统。
                        if (!CurrentUser.HasRight(RightEnum.GQ))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.HR: //人事管理系统。
                        if (!CurrentUser.HasRight(RightEnum.HR))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.CW: //工艺管理系统。
                        if (!CurrentUser.HasRight(RightEnum.CW))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.ODV: //其他设备管理系统。
                        if (!CurrentUser.HasRight(RightEnum.ODV))
                        {
                            this.SetNoRightInfo(true);
                            return;
                        }
                        break;
                    case ProductEnum.WF://工作流管理系统。
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
        /// Toolbar的postback事件。
        /// </summary>
        /// <param name="item">触发事件的ToolbarItem。</param>
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
                                                                         OpDesc = string.Format("删除用户角色 LoginName:{0},ProductCode:{1}", loginName, ProductCode)
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
                            OpDesc = string.Format("删除组角色 GroupCode:{0},ProductCode:{1}", loginName, ProductCode)
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
        /// DataGrid的翻页事件。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void MzhDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.MzhDataGrid1.DataSource = this.UserRoleDataTable;
            this.MzhDataGrid1.DataBind();
        }
        /// <summary>
        /// 刷新按钮事件。
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
