using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Enum;
using Shmzh.Components.SystemComponent.Model;
using Shmzh.Web.UI.Controls;
using System.Data.SqlClient;
using ComponentArt.Web.UI;

namespace SystemManagement.MZHUM
{
    /// <summary>
    /// SYS_User ��ժҪ˵����
    /// </summary>
    public partial class SYS_User : BasePage
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IList<DeptInfo> deptDS;

        #endregion

        #region Property
        /// <summary>
        /// ���ű�š�
        /// </summary>
        public string DeptCode
        {
            get { return this.txtDeptCode.Text;}
            set { this.txtDeptCode.Text = value;}
        }
        /// <summary>
        /// �Ƿ�����Ѿ����õ���Ա��
        /// </summary>
        public bool IncludeDisable
        {
            get { return this.tbiIncludeDisable.Checked; }
        }
        /// <summary>
        /// �Ƿ�����Ӳ��š�
        /// </summary>
        public bool IncludeChildDept
        {
            get { return this.tbiIncludeChildDept.Checked; }
        }
        /// <summary>
        /// ��ѯ���ݡ�
        /// </summary>
        public string QueryContent
        {
            get { return this.tbiContent.Text; }
        }
        /// <summary>
        /// ��ѯ��־��
        /// </summary>
        public int SelectFlag
        {
            get { return int.Parse(ViewState["SelectFlag"].ToString()); }
            set { ViewState["SelectFlag"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// ���ݰ󶨷�����
        /// </summary>
        private void myDataBind()
        {
            switch(this.SelectFlag)
            {
                case 1:
                    this.BindData();
                    break;
                case 2:
                    this.BindSearch();
                    break;
                case 3:
                    this.BindSE();
                    break;
            }
        }

        /// <summary>
        /// ���ݰ󶨡�
        /// </summary>
        private void BindData()
        {
            this.SelectFlag = 1;
            ListBase<UserInfo> objs;

            if (this.IncludeDisable && this.DeptCode == string.Empty)
                objs = DataProvider.UserProvider.GetAllByCompany(this.CompanyCode) as ListBase<UserInfo>;
            else if (this.IncludeDisable && this.DeptCode != string.Empty)
            {
                if(this.IncludeChildDept)
                    objs = DataProvider.UserProvider.GetAllByCompanyAndDept(this.CompanyCode, this.DeptCode, true) as ListBase<UserInfo>;
                else
                    objs = DataProvider.UserProvider.GetAllByCompanyAndDept(this.CompanyCode, this.DeptCode, false) as ListBase<UserInfo>;
            }
            else if (!this.IncludeDisable && this.DeptCode == string.Empty)
                objs = DataProvider.UserProvider.GetAllAvalibleByCompany(this.CompanyCode) as ListBase<UserInfo>;
            else
            {
                if(this.IncludeChildDept)
                    objs = DataProvider.UserProvider.GetAllAvalibleByCompanyAndDept(this.CompanyCode, this.DeptCode, true) as ListBase<UserInfo>;
                else
                    objs = DataProvider.UserProvider.GetAllAvalibleByCompanyAndDept(this.CompanyCode, this.DeptCode, false) as ListBase<UserInfo>;
            }
            UserList.DataSource = objs;
            UserList.DataBind();
        }
        /// <summary>
        /// ��ѯ������ݰ󶨡�
        /// </summary>
        public void BindSearch()
        {
            this.SelectFlag = 2;

            IList<UserInfo> ds;
            if(this.tbiIncludeDisable.Checked)
                ds = DataProvider.UserProvider.SearchAll(this.CompanyCode, this.QueryContent) as ListBase<UserInfo>;
            else
                ds = DataProvider.UserProvider.SearchAllAvalible(this.CompanyCode, this.QueryContent) as ListBase<UserInfo>;
            
            UserList.DataSource = ds;
            UserList.DataBind();
        }
        /// <summary>
        /// ��ѯ��
        /// </summary>
        public void BindSE()
        {
            this.SelectFlag = 3;
            IList<UserInfo> ds = DataProvider.UserProvider.GetBySQL(this.ViewState["SQL"].ToString());
            UserList.DataSource = ds;
            UserList.DataBind();

        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="depts"></param>
        private void CreatTree(IList<DeptInfo> depts)
        {
            var subDepts = ((List<DeptInfo>) depts).FindAll(obj => obj.ParentDept == "-1");
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
            if (subDepts.Count > 0)
            {
                foreach (var obj in subDepts)
                {
                    var tn = new TreeViewNode
                                 {
                                     ID = obj.DeptCode,
                                     Value = obj.DeptCode,
                                     Text = obj.DeptCnName,
                                     ToolTip = obj.Remark,
                                     CssClass = "RootNode"
                                 };
                    if (obj.IsValid != "Y")
                        tn.ImageUrl = "deletedFolder.gif";

                    AddSubNode(depts, tn);
                    this.tvDept.Nodes.Add(tn);
                    this.tvDept.ExpandAll();
                }
            }
            var tnOther = new TreeViewNode
                                       {
                                           ID = "-100",
                                           Value = "-100",
                                           Text = "�ⲿ��Ա",
                                           CssClass = "RootNode"
                                       };
            this.tvDept.Nodes.Add(tnOther);
        }
        /// <summary>
        /// ���������ӽڵ㡣
        /// </summary>
        /// <param name="depts"></param>
        /// <param name="tn"></param>
        private void AddSubNode(IList<DeptInfo> depts, TreeViewNode tn)
        {
            var subDepts = ((List<DeptInfo>) depts).FindAll(obj => obj.ParentDept == tn.ID);
            subDepts.Sort((a,b)=>a.Serial.CompareTo(b.Serial));
            if (subDepts.Count > 0)
            {
                foreach(var obj in subDepts)
                {
                    var subTn = new TreeViewNode
                                    {
                                        ID = obj.DeptCode.Replace(" ",""),
                                        Value = obj.DeptCode,
                                        Text = obj.DeptCnName,
                                        ToolTip = obj.Remark,
                                    };
                    if (obj.IsValid != "Y")
                        subTn.ImageUrl = "deletedFolder.gif";
                    
                    AddSubNode(depts, subTn);
                    tn.Nodes.Add(subTn);
                }
            }
        }
        /// <summary>
        /// �û�ɾ����
        /// </summary>
        /// <param name="userId">�û�Id��</param>
        /// <returns>bool</returns>
        private bool UserDelete(int userId)
        {
            var user = DataProvider.UserProvider.GetById(userId);
            if(user.LoginName.ToLower() == "administrator")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "Errr", "<script>alert('AdministratorΪϵͳ�̶��û�����ɾ����');</script>");
                return false;
            }
            TB_UsersInfo tbluser = null;
            if (isSynchronization() && user.IsUser.ToUpper()=="Y")
            {
                tbluser = DataProvider.TB_UsersProvider.GetByUserName(user.LoginName);
                if (tbluser == null)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "Errr","<script>alert('������ϵͳ���޴���Ա��Ϣ��');</script>");
                    return false;
                }
            }
            if (isSynchronization() && tbluser != null && user.IsUser.ToUpper()=="Y")
            {
                using (var conn = new SqlConnection(ConnectionString.PubData))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction("MyTrans");
                    try
                    {
                        if (DataProvider.UserProvider.Delete(user, trans) &&
                            DataProvider.TB_UsersProvider.Delete(tbluser, trans))
                        {
                            if (!DataProvider.GroupUserProvider.Delete(user.LoginName,trans))
                            {
                                trans.Rollback();
                                return false;
                            }
                            if(!DataProvider.OperationLogProvider.Insert(new OperationLogInfo
                                                                         {
                                                                             UserName = this.CurrentUser.LoginName,
                                                                             OpTime = DateTime.Now,
                                                                             ProductCode = 11,
                                                                             OpType = OpTypeEnum.UserOperation,
                                                                             OpDesc =string.Format("ɾ���û�{0}", user),
                                                                         },trans))
                            {
                                trans.Rollback();
                                return false;
                            }
                            var orgmemlk = DataProvider.TB_OrgMemLkProvider.GetByUserId(tbluser.UserId);
                            if (orgmemlk != null)
                            {
                                if (!DataProvider.TB_OrgMemLkProvider.Delete(orgmemlk, trans))
                                {
                                    trans.Rollback();
                                    return false;
                                }
                            }
                            //���¶�����ͬ����־��
                            if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                !DataProvider.TB_SYNProvider.Update("02", trans))
                            {
                                trans.Rollback();
                                return false;
                            }

                            trans.Commit();
                            //Add the Delete User Operation Log.
                            
                            return true;
                        }
                        else
                        {
                            trans.Rollback();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        return false;
                    }
                }
            }
            else
            {
                using (var conn = new SqlConnection(ConnectionString.PubData))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction();
                    if (DataProvider.UserProvider.Delete(user,trans) &&
                        DataProvider.GroupUserProvider.Delete(user.LoginName,trans) &&
                        DataProvider.OperationLogProvider.Insert(new OperationLogInfo
                        {
                            UserName = this.CurrentUser.LoginName,
                            OpTime = DateTime.Now,
                            ProductCode = 11,
                            OpType = OpTypeEnum.UserOperation,
                            OpDesc = string.Format("ɾ���û�{0}", user),
                        }, trans))
                    {
                        trans.Commit();
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        return false;
                    }
                }
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
            if (!Page.IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.UserView))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!CurrentUser.HasRight(RightEnum.UserMaintain))
                {
                    this.MzhToolbar1.Visible = false;
                }
                else if (CurrentUser.thisUserInfo.LoginName.ToLower() != "administrator")
                {
                    this.tbiDelete.Visible = false;
                }
                this.deptDS = DataProvider.DeptProvider.GetAllAvalibleCompanyCode(this.CompanyCode);
                
                this.CreatTree(this.deptDS);
                this.SelectFlag = 1;
                this.myDataBind();
            }
            this.UserList.AutoDataBind = myDataBind;
        }
        /// <summary>
        /// TreeView�Ľڵ�ѡ���¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvMenu_NodeSelected(object sender, ComponentArt.Web.UI.TreeViewNodeEventArgs e)
        {
            this.SelectFlag = 1;
            this.DeptCode = e.Node.Value;
            this.myDataBind();    
        }
        /// <summary>
        /// ˢ�°�ť�¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myDataBind();
        }

        protected void MzhToolbar1_ItemPostBack(ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "go":
                    this.SelectFlag = 2;
                    this.myDataBind();
                    break;
                case "includechilddept":
                case "includedisable":
                    this.myDataBind();
                    break;
                case "reset":
                    var userInfo = DataProvider.UserProvider.GetById(int.Parse(UserList.SelectedID));
                    if(userInfo != null)
                        Shmzh.Components.SystemComponent.User.ResetPassword(userInfo);
                    break;
                case "delete":
                    //����Ա��ɾ��Ȩ��ֻ����administrator����û��������û�һ�ɲ���ɾ���û���
                    //���ڽ���Աɾ���ĺ����administrator�����Լ�Ҫ�����
                    //��������Ա�������Ƽ�����ɾ����
                    if (CurrentUser.HasRight(RightEnum.UserMaintain) && CurrentUser.thisUserInfo.LoginName.ToLower() == "administrator")
                    {
                        if (this.UserList.SelectedID.Length > 0)
                        {
                            try
                            {
                                if (UserDelete(int.Parse(this.UserList.SelectedID)))
                                {
                                    this.myDataBind();
                                }
                                else
                                {
                                    AddScript("<script>alert('" + ConfigCommon.GetMessageValue("UserDeleteFailed") + "');</script>");
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(ex.Message);
                                AddScript(this.GetType(), "DeleteException", string.Format("<script>alert('{0}')</script>", ConfigCommon.GetMessageValue("UserDeleteFailed")));
                            }
                        }
                    }
                    else
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    break;
                case "enabledisable"://���á����á�
                    #region
                    if (!CurrentUser.HasRight(RightEnum.UserMaintain))
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    if (this.UserList.SelectedID.Length <= 0)
                    {
                        return;
                    }
                    
                    var obj = DataProvider.UserProvider.GetById(int.Parse(UserList.SelectedID));
                    #region ͬ��������
                    if (isSynchronization() )//��Ҫͬ����������
                    {
                        using (var conn = new SqlConnection(ConnectionString.PubData))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            #region userCat

                            var userCat = DataProvider.TB_UserCatProvider.GetByUserCatName(ConfigurationManager.AppSettings["DLFlo_Domain"]);
                            if(userCat == null)
                            {
                                userCat = new TB_UserCatInfo {UserCatId = 0, UserCatName = ConfigurationManager.AppSettings["DLFlo_Domain"], UserCatEnable = true};
                                if(!DataProvider.TB_UserCatProvider.Insert(userCat, trans))
                                {
                                    trans.Rollback();
                                    this.ClientScript.RegisterStartupScript(this.GetType(),"UserCatInsertFailed","alert('���������û��������ʧ��!'",true);
                                    return;
                                }
                            }    
                            
                            #endregion
                            
                            #region IsUser
                            if (obj.IsUser.ToUpper() == "Y")
                            {
                                var oldTB_User = DataProvider.TB_UsersProvider.GetByUserName(obj.LoginName);
                                if (oldTB_User == null)
                                {
                                    AddScript(this.GetType(), "No_User", "<script>alert('������ϵͳ�����ڴ��û���');</script>");
                                    return;
                                }
                                #region Active
                                if (obj.UserState == "A")//�����ǰ�û��ǻ�ġ�
                                {
                                    obj.UserState = "U";
                                    oldTB_User.Enalbe = false;
                                    if(DataProvider.UserProvider.Update(obj, trans) &&
                                        DataProvider.OperationLogProvider.Insert(new OperationLogInfo{UserName = this.CurrentUser.LoginName, OpTime = DateTime.Now,ProductCode = 11, OpType = OpTypeEnum.UserOperation, OpDesc = string.Format("�����û� {0}",obj)},trans) &&
                                        DataProvider.TB_UsersProvider.Update(oldTB_User,trans) )
                                    {
                                        var orgmemln = DataProvider.TB_OrgMemLkProvider.GetByUserId(oldTB_User.UserId);
                                        if (orgmemln != null)
                                        {
                                            if(DataProvider.TB_OrgMemLkProvider.Delete(orgmemln,trans))
                                            {
                                                trans.Commit();
                                            }
                                            else
                                            {
                                                trans.Rollback();
                                                this.ClientScript.RegisterStartupScript(this.GetType(),"OrgMemLkDeleteFailed","alert('����������֯��������Ա��ϵ��¼ɾ��ʧ�ܣ�');",true);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            trans.Commit();
                                        }
                                    }
                                    else
                                    {
                                        trans.Rollback();
                                        this.ClientScript.RegisterStartupScript(this.GetType(),"updateFailed","alert('�û�����ʧ�ܣ�');",true);
                                        return;
                                    }
                                }
                                #endregion
                                #region UnActive

                                else
                                {
                                    obj.UserState = "A";
                                    oldTB_User.Enalbe = true;
                                    if(DataProvider.UserProvider.Update(obj,trans) &&
                                        DataProvider.OperationLogProvider.Insert(new OperationLogInfo { UserName = this.CurrentUser.LoginName, OpTime = DateTime.Now,ProductCode = 11,OpType = OpTypeEnum.UserOperation, OpDesc = string.Format("�����û� {0}", obj) }, trans) &&
                                        DataProvider.TB_UsersProvider.Update(oldTB_User,trans))
                                    {
                                        if(obj.IsEmp.ToUpper() == "Y")
                                        {
                                            var currentDeptInfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(obj.EmpCo, obj.DeptCode);
                                            var currentOrg = DataProvider.TB_OrgTreeProvider.GetByName(currentDeptInfo.DeptCnName);
                                            if(currentOrg == null)
                                            {
                                                trans.Rollback();
                                                this.ClientScript.RegisterStartupScript(this.GetType(),"NoOrg","alert('��������û�ж�Ӧ�Ĳ��š�');",true);
                                                return;
                                            }
                                            else
                                            {
                                                var orgmemlk = new TB_ORGMEMLKInfo{LnkId = 0,OrgId = currentOrg.ItemID,UserId = oldTB_User.UserId};
                                                if(DataProvider.TB_OrgMemLkProvider.Insert(orgmemlk,trans))
                                                {
                                                    trans.Commit();
                                                }
                                                else
                                                {
                                                    trans.Rollback();
                                                    this.ClientScript.RegisterStartupScript(this.GetType(),"OrgMemLkInsertFailed","alert('����������֯��������Ա��ϵ��¼����ʧ�ܡ�')",true);
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            trans.Commit();
                                        }
                                    }
                                    else
                                    {
                                        trans.Rollback();
                                        this.ClientScript.RegisterStartupScript(this.GetType(), "updateFailed","alert('�û�����ʧ�ܣ�');",true);
                                        return;
                                    }
                                }
                                #endregion
                            }
                            #endregion
                            #region is not user
                            else//��ǰ��Ա�������û���
                            {
                                if (string.IsNullOrEmpty(obj.LoginName))
                                {
                                    var script = new StringBuilder();
                                    script.Append("<script type='text/javascript'>\r\n");
                                    script.Append("alert('" + ConfigCommon.GetMessageValue("UserNoLoginName") + "��');\r\n");
                                    script.Append("popupWindow.setUrl('SYS_UserEdit.aspx?PKID=" + UserList.SelectedID +"&IsUser=Y');\r\n");
                                    script.Append("popupWindow.setSize(600,500);\r\n");
                                    script.Append("popupWindow.showPopup('" + item.ClientID + "',false);\r\n");
                                    script.Append("</script>");

                                    AddScript(this.GetType(), "UserNoUse", script.ToString());
                                }
                                else
                                {
                                    obj.UserState = "A";
                                    obj.IsUser = "Y";

                                    var oldTB_User = DataProvider.TB_UsersProvider.GetByUserName(obj.LoginName);
                                    var currentDeptInfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(obj.EmpCo, obj.DeptCode);

                                    if (oldTB_User == null)
                                    {
                                        oldTB_User = new TB_UsersInfo
                                                         {
                                                             UserName = obj.LoginName,
                                                             PWD = ConfigurationManager.AppSettings["DLFlo_UserPWD"],
                                                             Domain = ConfigurationManager.AppSettings["DLFlo_Domain"],
                                                             Language = ConfigurationManager.AppSettings["DLFlo_Language"],
                                                             UserDspName = obj.EmpName,
                                                             HRID = (string.IsNullOrEmpty(obj.EmpCode) ? string.Empty : obj.EmpCode),
                                                             EMail = (string.IsNullOrEmpty(obj.EMail) ? string.Empty : obj.EMail),
                                                             Tel = (string.IsNullOrEmpty(obj.Tel) ? string.Empty : obj.Tel),
                                                             Dept = (currentDeptInfo == null ? string.Empty : currentDeptInfo.DeptCnName),
                                                             JobTitle = (string.IsNullOrEmpty(obj.DutyName) ? string.Empty : obj.DutyName),
                                                             SpHRID = (DataProvider.UserProvider.GetDeptMgr(obj.DeptCode) ?? string.Empty),
                                                             JoinDate = (obj.InDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : obj.InDate),
                                                             CostCenter = (currentDeptInfo == null ? string.Empty : currentDeptInfo.CostCenter),
                                                             LocationCode = ConfigurationManager.AppSettings["DLFlo_LocationCode"],
                                                             Enalbe = true,
                                                             IsOut = false,
                                                             AgentUserId = 0,
                                                             MbTel = (obj.Mobile ?? string.Empty),
                                                             CanAssignOut = false,
                                                             IsLeave = (obj.IsLeave.ToUpper() == "Y"),
                                                             LeaveDate = (obj.LeaveDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : obj.LeaveDate),
                                                             UserCatId = userCat.UserCatId
                                                         };
                                        if( DataProvider.UserProvider.Update(obj,trans) &&
                                            DataProvider.OperationLogProvider.Insert(new OperationLogInfo { UserName = this.CurrentUser.LoginName, OpTime = DateTime.Now,ProductCode=11, OpType = OpTypeEnum.UserOperation, OpDesc = string.Format("�����û� {0}", obj) }, trans) &&
                                            DataProvider.TB_UsersProvider.Insert(oldTB_User, trans))
                                        {
                                            if(obj.IsEmp.ToUpper() == "Y")
                                            {
                                                var currentOrg = DataProvider.TB_OrgTreeProvider.GetByName(currentDeptInfo.DeptCnName);
                                                if(currentOrg == null)
                                                {
                                                    trans.Rollback();
                                                    this.ClientScript.RegisterStartupScript(this.GetType(),"NoOrg","������ϵͳ��û�ж�Ӧ�Ĳ��ţ�",true);
                                                    return;
                                                }
                                                else
                                                {
                                                    var orgmemlk = new TB_ORGMEMLKInfo {LnkId = 0, OrgId = currentOrg.ItemID, UserId = oldTB_User.UserId};
                                                    if(DataProvider.TB_OrgMemLkProvider.Insert(orgmemlk,trans))
                                                    {
                                                        trans.Commit();
                                                    }
                                                    else
                                                    {
                                                        trans.Rollback();
                                                        this.ClientScript.RegisterStartupScript(this.GetType(),"OrgmemlkInsertFailed","alert('�������������֯��������Ա��ϵʧ�ܣ�')",true);
                                                        return;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                trans.Commit();
                                            }
                                        }
                                        else
                                        {
                                            trans.Rollback();
                                            this.ClientScript.RegisterStartupScript(this.GetType(),"updateFailed","alert('����ʧ�ܣ�');",true);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        oldTB_User.Enalbe = true;
                                        if( DataProvider.UserProvider.Update(obj,trans) &&
                                            DataProvider.OperationLogProvider.Insert(new OperationLogInfo { UserName = this.CurrentUser.LoginName, OpTime = DateTime.Now,ProductCode = 11,OpType = OpTypeEnum.UserOperation, OpDesc = string.Format("�����û� {0}", obj) }, trans) &&
                                            DataProvider.TB_UsersProvider.Update(oldTB_User, trans))
                                        {
                                            if (obj.IsEmp.ToUpper() == "Y")
                                            {
                                                var currentOrg = DataProvider.TB_OrgTreeProvider.GetByName(currentDeptInfo.DeptCnName);
                                                if (currentOrg == null)
                                                {
                                                    trans.Rollback();
                                                    this.ClientScript.RegisterStartupScript(this.GetType(), "NoOrg", "������ϵͳ��û�ж�Ӧ�Ĳ��ţ�", true);
                                                    return;
                                                }
                                                else
                                                {
                                                    var orgmemlk = new TB_ORGMEMLKInfo { LnkId = 0, OrgId = currentOrg.ItemID, UserId = oldTB_User.UserId };
                                                    if (DataProvider.TB_OrgMemLkProvider.Insert(orgmemlk, trans))
                                                    {
                                                        trans.Commit();
                                                    }
                                                    else
                                                    {
                                                        trans.Rollback();
                                                        this.ClientScript.RegisterStartupScript(this.GetType(), "OrgmemlkInsertFailed", "alert('�������������֯��������Ա��ϵʧ�ܣ�')", true);
                                                        return;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                trans.Commit();
                                            }
                                        }
                                        else
                                        {
                                            trans.Rollback();
                                            return;
                                        }
                                    }
                                }
                                
                            }
                            #endregion
                        }
                    }
                    #endregion
                    #region ��ͬ��������
                    else//��ͬ����������
                    {
                        if (obj.IsUser == "Y") //�����ǰ��Ա���û���
                        {
                            obj.UserState = obj.UserState == UserStateEnum.ACTIVED
                                                ? UserStateEnum.UNACTIVED
                                                : UserStateEnum.ACTIVED;
                            DataProvider.UserProvider.Update(obj);
                            if(obj.UserState =="A")
                                DataProvider.OperationLogProvider.Insert(
                                    new OperationLogInfo {UserName = this.CurrentUser.LoginName, OpTime = DateTime.Now,ProductCode = 11,OpType = OpTypeEnum.UserOperation, OpDesc = string.Format("�����û� {0}", obj)});
                            else
                                DataProvider.OperationLogProvider.Insert(new OperationLogInfo
                                                                             {
                                                                                 UserName = this.CurrentUser.LoginName,
                                                                                 OpTime = DateTime.Now,
                                                                                 ProductCode = 11,
                                                                                 OpType = OpTypeEnum.UserOperation,
                                                                                 OpDesc = string.Format("�����û� {0}", obj)
                                                                             });
                                
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(obj.LoginName))
                            {
                                var script = new StringBuilder();
                                script.Append("<script type='text/javascript'>\r\n");
                                script.Append("alert('" + ConfigCommon.GetMessageValue("UserNoUse") + "��');\r\n");
                                script.Append("popupWindow.setUrl('SYS_UserEdit.aspx?PKID=" + UserList.SelectedID +
                                              "&IsUser=Y');\r\n");
                                script.Append("popupWindow.setSize(600,500);\r\n");
                                script.Append("popupWindow.showPopup('" + item.ClientID + "',false);\r\n");
                                script.Append("</script>");

                                AddScript(this.GetType(), "UserNoUse", script.ToString());
                            }
                            else
                            {
                                obj.IsUser = "Y";
                                obj.UserState = UserStateEnum.ACTIVED;
                                DataProvider.UserProvider.Update(obj);
                                DataProvider.OperationLogProvider.Insert(new OperationLogInfo
                                                                             {
                                                                                 UserName = this.CurrentUser.LoginName,
                                                                                 OpTime = DateTime.Now,
                                                                                 ProductCode = 11,
                                                                                 OpType = OpTypeEnum.UserOperation,
                                                                                 OpDesc = string.Format("�����û� {0}", obj)
                                                                             });
                            }
                        }

                    }
                    #endregion

                    this.myDataBind();
                    #endregion
                    break;
            }
        }

        protected void MzhToolbar1_SEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.SelectFlag = 3;
            this.ViewState["SQL"] = sqlStatement;
            this.myDataBind();
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {

            for (var i = 0; i < this.UserList.Items.Count;i++ )
            {
                var item = this.UserList.Items[i];
                var hfSuperHrid = item.FindControl("hfSuperHrid") as HiddenField;
                //var txtSuperHrid = item.FindControl("txtSuperHrid") as TextBox;
                var hfSuperHrid1 = item.FindControl("hfSuperHrid1") as HiddenField;
                Logger.Debug(hfSuperHrid.Value);
                Logger.Debug(hfSuperHrid1.Value);
                if (hfSuperHrid != null && hfSuperHrid1 != null && hfSuperHrid.Value != hfSuperHrid1.Value)
                {
                    var id = int.Parse(item.Cells[0].Text);
                    var superHrid = hfSuperHrid1.Value;
                    Logger.Debug(id);
                    var userInfo = DataProvider.UserProvider.GetById(id);
                    if (userInfo != null)
                    {
                        userInfo.SuperHrid = superHrid;
                        if (!string.IsNullOrEmpty(userInfo.LoginName))
                        {
                            var tbUserInfo = DataProvider.TB_UsersProvider.GetByUserName(userInfo.LoginName);

                            if (tbUserInfo != null)
                            {
                                tbUserInfo.SpHRID = superHrid;
                                using (var conn = new SqlConnection(ConnectionString.PubData))
                                {
                                    conn.Open();
                                    var trans = conn.BeginTransaction("MyTrans");
                                    if (DataProvider.UserProvider.Update(userInfo, trans))
                                    {
                                        if (DataProvider.TB_UsersProvider.Update(tbUserInfo, trans))
                                        {

                                            trans.Commit();
                                        }
                                        else
                                        {
                                            trans.Rollback();
                                            this.ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('����ʧ�ܣ�')", true);
                                        }
                                    }
                                    else
                                    {
                                        trans.Rollback();
                                        this.ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('����ʧ�ܣ�')", true);
                                    }
                                }
                            }
                            else
                            {
                                DataProvider.UserProvider.Update(userInfo);
                            }
                        }
                    }
                }
            }
            this.myDataBind();
        }
    }
}
