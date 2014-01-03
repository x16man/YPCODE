using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using System.Data;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.Enum;
using Shmzh.Components.SystemComponent.Model;


namespace SystemManagement.MZHUM
{
    /// <summary>
    /// SYS_AddUserSecond ��ժҪ˵����
    /// </summary>
    public partial class SYS_UserEdit : BasePage
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169

        #endregion

        #region Property
        /// <summary>
        /// PKID.
        /// </summary>
        public int PKID
        {
            get
            {
                if (ViewState["PKID"] == null)
                    return -1;
                return int.Parse(ViewState["PKID"].ToString());
            }
            set { ViewState["PKID"] = value; }
        }
        /// <summary>
        /// ����ģʽ��
        /// </summary>
        public string OP
        {
            get 
            {
                return this.PKID == -1 ? "Add" : "Edit";
            }
        }
        /// <summary>
        /// ҳ���״̬��
        /// ��ϵ�������ʱ���Ƿ���Ҫˢ�¸�ҳ�档
        /// </summary>
        public string PageState
        {
            get
            {
                var s = Request["PageState"];
                return s ?? string.Empty;
            }
        }
        /// <summary>
        /// ���ű�š�
        /// </summary>
        public string DeptCode
        {
            get { return this.ViewState["DeptCode"].ToString(); }
            set { this.ViewState["DeptCode"] = value; }
        }
        /// <summary>
        /// Ա�����š�
        /// </summary>
        public string EmpCode
        {
            get { return this.tb_EmpCode.Text.Trim(); }
            set { this.tb_EmpCode.Text = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// ��Ա��״̬��
        /// </summary>
        private void BindEmpState()
        {
            var objs = DataProvider.EmpStateProvider.GetAll();
            ddw_EmpState.DataSource = objs;
            ddw_EmpState.DataBind();
        }
        /// <summary>
        /// ��ְλ�б�
        /// </summary>
        private void BindDuty()
        {
            var objs = DataProvider.DutyProvider.GetAllAvalibleByCompanyCode(this.CompanyCode);
            ddw_Duty.DataSource = objs;
            ddw_Duty.DataBind();
            ddw_Duty.Items.Add(new ListItem("��", "-1"));
            ddw_Duty.SelectedIndex = ddw_Duty.Items.Count - 1;
        }
        /// <summary>
        /// ��ʾԱ����Ϣ�顣
        /// </summary>
        private void showEmpInfoBlock()
        {
            this.empInfo.Attributes.Remove("class");
        }
        /// <summary>
        /// ����Ա����Ϣ�顣
        /// </summary>
        private void hideEmpInfoBlock()
        {
            this.empInfo.Attributes.Add("class", "hidden");
        }
        /// <summary>
        /// ���ݹ�˾��ź�Ա�����Ż�ȡ��Ա��Ϣ��
        /// </summary>
        /// <param name="companyCode">��˾���</param>
        /// <param name="empCode">���š�</param>
        private void GetUserInfoByCompanyAndEmpCode(string companyCode, string empCode)
        {
            var obj = DataProvider.UserProvider.GetByCompanyAndEmpCode(companyCode, empCode);
            if (obj != null)
            {
                showUserInfo(obj);
            }
            else
            {
                if (this.ddw_IsEmp.SelectedValue == "Y")
                {
                    this.empInfo.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    this.empInfo.Style.Add(HtmlTextWriterStyle.Position, "static");
                }
                else
                {
                    this.empInfo.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    this.empInfo.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                }
            }
        }
        /// <summary>
        /// ����PKID��ȡ��Ա��Ϣ��
        /// </summary>
        /// <param name="pkid">PKID</param>
        private void GetUserInfo(int pkid)
        {
            var emp = DataProvider.UserProvider.GetById(pkid);
            if (emp != null)
            {
                showUserInfo(emp);
            }
            else
            {
                AddScript(this.GetType(), "UserNotFind", ConfigCommon.GetMessageValue("UserNoFind"));
            }
        }
        /// <summary>
        /// ����Ա��Ϣ�����档
        /// </summary>
        /// <param name="emp">EntryUserʵ�塣</param>
        private void showUserInfo(UserInfo emp)
        {
            this.PKID = emp.PKID;
            if (emp.IsEmp == "Y")
            {
                tb_DeptCnName.Text = emp.DeptName;
                tb_EmpDept.Value = emp.DeptCode;
                ddw_EmpState.SelectedValue = emp.EmpState;
                try
                {
                    ddw_Duty.SelectedValue = emp.DutyCode;
                }
                catch
                {
                    ddw_Duty.Items.Add(new ListItem(emp.DutyName, emp.DutyCode));
                    ddw_Duty.SelectedValue = emp.DutyCode;
                }

                this.tbiInDate.Text = emp.InDate == DateTime.MinValue ? string.Empty : emp.InDate.ToString("d");
                this.tbiLeaveDate.Text = emp.LeaveDate == DateTime.MinValue ? string.Empty : emp.LeaveDate.ToString("d");
                this.chk_IsLeave.Checked = emp.IsLeave == "Y" ? true : false;
                this.showEmpInfoBlock();
            }
            else
            {
                this.hideEmpInfoBlock();
            }
            tb_SupervisorHrid.Text = emp.SuperHrid;
            tb_EmpCode.Text = emp.EmpCode;
            tb_EmpCnName.Text = emp.EmpName;
            tb_EmpEnName.Text = emp.EmpEnName;
            tb_LoginName.Text = emp.LoginName;
            this.tbiBirthday.Text = emp.BirthDay == DateTime.MinValue ? string.Empty : emp.BirthDay.ToString("d");
            tb_IDCard.Text = emp.IDCard;
            tb_Mobile.Text = emp.Mobile;
            tb_OfficeFax.Text = emp.OfficeFax;
            tb_OfficeSubCall.Text = emp.OfficeSubCall;
            tb_OfficeCall.Text = emp.OfficeCall;
            tb_Email.Text = emp.EMail;
            ddw_Gender.SelectedValue = emp.Gender;
            ddw_UserState.SelectedValue = emp.UserState;
            ddw_IsEmp.SelectedValue = string.IsNullOrEmpty(emp.IsEmp) ? "Y" : emp.IsEmp;
            if (ddw_IsEmp.SelectedValue == "Y")
            {
                this.showEmpInfoBlock();
            }
            else
            {
                this.hideEmpInfoBlock();
            }
            ddlUICultrue.SelectedValue = string.IsNullOrEmpty(emp.UICulture) ? "zh-CN" : emp.UICulture;
        }
        /// <summary>
        /// ���档
        /// </summary>
        protected void save()
        {
            #region Fill EntryUser

            var emp = this.OP == "Add" ? new UserInfo() : DataProvider.UserProvider.GetById(this.PKID);

            emp.IsEmp = ddw_IsEmp.SelectedValue;
            if (ddw_IsEmp.SelectedValue == "Y")
            {
                if (string.IsNullOrEmpty(this.tb_EmpDept.Value.Trim()))
                {
                    AddScript(this.GetType(),"DeptEmpty","<script>alert('���Ų�����Ϊ�գ�');</script>");
                    return;
                }
                emp.DeptCode = tb_EmpDept.Value.Trim();
                emp.DeptName = tb_DeptCnName.Text.Trim();
                emp.SuperHrid = tb_SupervisorHrid.Text.Trim();
                emp.EmpState = ddw_EmpState.SelectedValue;
                emp.DutyCode = ddw_Duty.SelectedValue=="-1"?string.Empty:ddw_Duty.SelectedValue;
                emp.DutyName = ddw_Duty.SelectedItem.Text;
                emp.InDate = string.IsNullOrEmpty(this.tbiInDate.Text.Trim())
                                 ? DateTime.MinValue
                                 : DateTime.Parse(this.tbiInDate.Text.Trim());
                emp.LeaveDate = string.IsNullOrEmpty(this.tbiLeaveDate.Text.Trim()) ? DateTime.MinValue : DateTime.Parse(this.tbiLeaveDate.Text.Trim());
                emp.IsLeave = chk_IsLeave.Checked ? "Y" : "N";
            }
            else
            {
                if (string.IsNullOrEmpty(this.tb_LoginName.Text.Trim()))
                {
                    AddScript(this.GetType(),"LoginNameNull","<script>alert('��¼��������Ϊ��!');</script>");
                    return;
                }
                emp.DeptCode = "-100";//-100Ϊ�̶����ⲿ��Ա�������š�
                
                emp.InDate = DateTime.MinValue;
                emp.LeaveDate = DateTime.MinValue;
                emp.IsLeave = "N";
            }
            emp.EmpCode = this.tb_EmpCode.Text;
            emp.EmpCo = this.CurrentUser.thisUserInfo.EmpCo;
            emp.EmpName = this.tb_EmpCnName.Text.Trim();
            emp.EmpEnName = this.tb_EmpEnName.Text.Trim();
            emp.LoginName = this.tb_LoginName.Text.Trim();
            emp.BirthDay = this.tbiBirthday.Text.Trim() == "" ? DateTime.MinValue : DateTime.Parse(this.tbiBirthday.Text);
            emp.IDCard = tb_IDCard.Text.Trim();
            emp.Mobile = tb_Mobile.Text.Trim();
            emp.OfficeFax = tb_OfficeFax.Text.Trim();
            emp.OfficeSubCall = tb_OfficeSubCall.Text.Trim();
            emp.OfficeCall = tb_OfficeCall.Text.Trim();
            emp.EMail = tb_Email.Text.Trim();
            emp.Gender = ddw_Gender.SelectedValue;
            emp.UserState = ddw_UserState.SelectedValue;
            emp.IsUser = string.IsNullOrEmpty(emp.LoginName) ? "N" : "Y";
            emp.SerialNo = string.IsNullOrEmpty(tb_SerialNo.Text.Trim()) ? int.MaxValue : int.Parse(tb_SerialNo.Text.Trim());
            emp.UICulture = ddlUICultrue.SelectedValue;
            #endregion

            #region Add
            if (this.OP == "Add")
            {
                if(!string.IsNullOrEmpty(emp.LoginName))
                {
                    if(DataProvider.UserProvider.GetByLoginName(emp.LoginName)!=null)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(),"NonUniqueUserName","alert('��¼����Ψһ��');",true);
                        return;
                    }
                }
                emp.AppandCode = DataProvider.UserProvider.CreateSalt();

                if (UserAdd(emp))
                {
                    if (!string.IsNullOrEmpty(emp.LoginName))
                    {
                        DataProvider.UserProvider.SetPassword(tb_LoginName.Text.Trim(), ConfigurationManager.AppSettings["DefaultPassword"]);
                    }
                    if (this.PageState.ToLower() == "new") //ֱ���ɿ��ҳ����á�
                    {
                        AddScript(this.GetType(), "ok", "<script>alert('" + ConfigCommon.GetMessageValue("UserInsertSuccess") + "��');if(window.opener){window.close();} else {window.location='SYS_USER.aspx';}</script>");
                    }
                    else//���б�ҳ����á�
                    {
                        AddScript(this.GetType(), "close", "<script>alert('����ɹ���');window.opener.refresh();window.close();</script>");
                    }
                }
                else
                {
                    AddScript(this.GetType(), "InsertFailed", "<script>alert('����û�ʧ�ܣ�');</script>");
                }
            }
            #endregion

            #region Update
            else
            {
                if(!string.IsNullOrEmpty(emp.LoginName))
                {
                    var user = DataProvider.UserProvider.GetById(emp.PKID);
                    if(user.LoginName.ToLower() == "administrator" && emp.LoginName != user.LoginName)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "Administrator", "alert('Administrator�ĵ�¼�������޸ģ�');", true);
                        return;
                    }
                    user = DataProvider.UserProvider.GetByLoginName(emp.LoginName);
                    if(user!= null && user.PKID != emp.PKID)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(),"NonUniqueUserName","alert('��¼����Ψһ��');",true);
                        return;
                    }
                }
                var oldEmp = DataProvider.UserProvider.GetById(emp.PKID);
                if(oldEmp.LoginName != emp.LoginName && !string.IsNullOrEmpty(oldEmp.LoginName))
                {
                    DataProvider.OperationLogProvider.Insert(new OperationLogInfo
                                                                 {
                                                                     UserName = this.CurrentUser.LoginName,
                                                                     OpTime = DateTime.Now,
                                                                     ProductCode = 11,
                                                                     OpType = OpTypeEnum.UserOperation,
                                                                     OpDesc = string.Format("�û����ı� {0}->{1}", oldEmp, emp)
                                                                 });
                }
                if (UserUpdate(emp))
                {
                    if(string.IsNullOrEmpty(emp.Password1))
                    {
                        DataProvider.UserProvider.SetPassword(tb_LoginName.Text.Trim(), ConfigurationManager.AppSettings["DefaultPassword"]);
                    }
                    if (this.PageState.ToLower() == "new") //ֱ���ɿ��ҳ����á�
                    {
                        AddScript(this.GetType(), "ok", "<script>alert('" + ConfigCommon.GetMessageValue("UserUpdateSuccess") + "��');if(window.opener){window.close();}else{window.location='SYS_USER.aspx';}</script>");
                    }
                    else//���б�ҳ����á�
                    {
                        AddScript(this.GetType(), "close", "<script>alert('����ɹ���');window.opener.refresh();window.close();</script>");
                    }
                }
                else
                {
                    AddScript(this.GetType(), "InsertFailed", "<script>alert('�޸��û�ʧ�ܡ�');</script>");
                }
            }
            #endregion
        }

        /// <summary>
        /// ������Ա
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public bool UserAdd(UserInfo userinfo)
        {
            if (isSynchronization() && userinfo.IsUser.ToUpper() == "Y")
            {
                #region Check UserCat
                var userCat = DataProvider.TB_UserCatProvider.GetByUserCatName(ConfigurationManager.AppSettings["DLFlo_UserCat"]);
                if(userCat == null)
                {
                    userCat = new TB_UserCatInfo
                                  {
                                      UserCatName = ConfigurationManager.AppSettings["DLFlo_UserCat"],
                                      UserCatEnable = true
                                  };
                    using (var conn = new SqlConnection(ConnectionString.DLFLODB))
                    {
                        conn.Open();
                        var trans = conn.BeginTransaction();
                        if(DataProvider.TB_UserCatProvider.Insert(userCat, trans))
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                            Logger.Error("��������ϵͳ������û��������");
                            return false;
                        }
                    }
                }
                #endregion

                #region Check UserName

                //var tbluser = DataProvider.TB_UsersProvider.GetByUserName(userinfo.LoginName);
                //if (tbluser != null)
                //{
                //    this.ClientScript.RegisterStartupScript(this.GetType(), "NonUnique", "<script>alert('������ϵͳ�д��ڴ˹��ŵ���Ա��Ϣ��');</script>");
                //    return false;
                //}
                #endregion

                using (var conn = new SqlConnection(ConnectionString.PubData))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction("MyTrans");
                    var tbluserinfo = DataProvider.TB_UsersProvider.GetByUserName(userinfo.LoginName);
                    #region Employee
                    if (userinfo.IsEmp.ToUpper() == "Y")//������û���Ա������Ҫ��¼Ա���Ͳ��ŵĹ�����Ϣ��
                    {
                        var orgTree = DataProvider.TB_OrgTreeProvider.GetByName(userinfo.DeptName);
                        if (orgTree == null)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "NoDept", "<script>alert('������ϵͳ���޴��û������Ĳ���,����ͬ�����ţ�');</script>");
                            return false;
                        }
                        
                        if (tbluserinfo == null)
                        {
                            tbluserinfo = new TB_UsersInfo
                                              {
                                                  HRID = userinfo.EmpCode,
                                                  UserName = userinfo.LoginName,
                                                  Domain = ConfigurationManager.AppSettings["DLFlo_Domain"],
                                                  PWD = ConfigurationManager.AppSettings["DLFlo_UserPWD"],
                                                  UserDspName = userinfo.EmpName,
                                                  EMail = userinfo.EMail,
                                                  Tel = string.IsNullOrEmpty(userinfo.Tel) ? string.Empty : userinfo.Tel,
                                                  Dept = userinfo.DeptName,
                                                  JobTitle = userinfo.DutyName ?? string.Empty,
                                                  
                                                  //SpHRID = DataProvider.UserProvider.GetDeptMgr(userinfo.DeptCode) ?? string.Empty,

                                                  JoinDate = (userinfo.InDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.InDate),
                                                  CostCenter = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(userinfo.EmpCo, userinfo.DeptCode).CostCenter ?? string.Empty,
                                                  LocationCode = ConfigurationManager.AppSettings["DLFlo_LocationCode"],
                                                  Enalbe = true,
                                                  IsOut = false,
                                                  AgentUserId = 0,
                                                  Language = ConfigurationManager.AppSettings["DLFlo_Language"],
                                                  MbTel = userinfo.Mobile,
                                                  CanAssignOut = false,
                                                  IsLeave = (userinfo.IsLeave.ToLower() == "y"),
                                                  LeaveDate = (userinfo.LeaveDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.LeaveDate),
                                                  UserCatId = userCat.UserCatId,
                                              };
                            if (string.IsNullOrEmpty(userinfo.SuperHrid))
                            {
                                tbluserinfo.SpHRID = DataProvider.UserProvider.GetDeptMgr(userinfo.DeptCode) ?? string.Empty;
                            }
                            else
                            {
                                tbluserinfo.SpHRID = userinfo.SuperHrid;
                            }
                            if (DataProvider.UserProvider.Insert(userinfo, trans) &&
                            DataProvider.TB_UsersProvider.Insert(tbluserinfo, trans))
                            {
                                if(!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EveryOneGroup"]))
                                {
                                    var groupCode = short.Parse(ConfigurationManager.AppSettings["EveryOneGroup"]);
                                    var groupUserInfo = new GroupUserInfo{GroupCode = groupCode,UserCode = userinfo.LoginName};
                                    if(!DataProvider.GroupUserProvider.Insert(groupUserInfo,trans))
                                    {
                                        trans.Rollback();
                                        return false;
                                    }
                                }
                                var orgmemlk = new TB_ORGMEMLKInfo { LnkId = 0, OrgId = orgTree.ItemID, UserId = tbluserinfo.UserId };
                                if (DataProvider.TB_OrgMemLkProvider.Insert(orgmemlk, trans))
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
                            else
                            {
                                trans.Rollback();
                                return false;
                            }
                        }
                        else
                        {
                            tbluserinfo = new TB_UsersInfo
                            {
                                UserId = tbluserinfo.UserId,
                                HRID = userinfo.EmpCode,
                                UserName = userinfo.LoginName,
                                Domain = ConfigurationManager.AppSettings["DLFlo_Domain"],
                                PWD = ConfigurationManager.AppSettings["DLFlo_UserPWD"],
                                UserDspName = userinfo.EmpName,
                                EMail = userinfo.EMail,
                                Tel = string.IsNullOrEmpty(userinfo.Tel) ? string.Empty : userinfo.Tel,
                                Dept = userinfo.DeptName,
                                JobTitle = userinfo.DutyName ?? string.Empty,
                                SpHRID = DataProvider.UserProvider.GetDeptMgr(userinfo.DeptCode) ?? string.Empty,
                                JoinDate = (userinfo.InDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.InDate),
                                CostCenter = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(userinfo.EmpCo, userinfo.DeptCode).CostCenter ?? string.Empty,
                                LocationCode = ConfigurationManager.AppSettings["DLFlo_LocationCode"],
                                Enalbe = true,
                                IsOut = false,
                                AgentUserId = 0,
                                Language = ConfigurationManager.AppSettings["DLFlo_Language"],
                                MbTel = userinfo.Mobile,
                                CanAssignOut = false,
                                IsLeave = (userinfo.IsLeave.ToLower() == "y"),
                                LeaveDate = (userinfo.LeaveDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.LeaveDate),
                                UserCatId = userCat.UserCatId,
                            };
                            if (DataProvider.UserProvider.Insert(userinfo, trans) &&
                                DataProvider.TB_UsersProvider.Update(tbluserinfo, trans))
                            {
                                var orgmemlk = new TB_ORGMEMLKInfo { LnkId = 0, OrgId = orgTree.ItemID, UserId = tbluserinfo.UserId };
                                if (DataProvider.TB_OrgMemLkProvider.Insert(orgmemlk, trans))
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
                            else
                            {
                                trans.Rollback();
                                return false;
                            }
                        }
                        
                    }
                    #endregion
                    #region not Employee
                    else//���û�����Ա�����������¼Ա���벿�ŵĹ�����Ϣ��
                    {
                        if(tbluserinfo == null)
                        {
                            tbluserinfo = new TB_UsersInfo
                            {
                                HRID = userinfo.EmpCode,
                                UserName = userinfo.LoginName,
                                Domain = ConfigurationManager.AppSettings["DLFlo_Domain"],
                                PWD = ConfigurationManager.AppSettings["DLFlo_UserPWD"],
                                UserDspName = userinfo.EmpName,
                                EMail = userinfo.EMail,
                                Tel = string.IsNullOrEmpty(userinfo.OfficeSubCall) ? userinfo.OfficeCall : string.Format("{0}-{1}", userinfo.OfficeCall, userinfo.OfficeSubCall),
                                Dept = userinfo.DeptName,
                                JobTitle = userinfo.DutyName ?? string.Empty,
                                SpHRID = DataProvider.UserProvider.GetDeptMgr(userinfo.DeptCode),
                                JoinDate = (userinfo.InDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.InDate),

                                LocationCode = ConfigurationManager.AppSettings["DLFlo_LocationCode"],
                                Enalbe = true,
                                IsOut = false,
                                AgentUserId = 0,
                                Language = ConfigurationManager.AppSettings["DLFlo_Language"],
                                MbTel = userinfo.Mobile,
                                CanAssignOut = false,
                                IsLeave = (userinfo.IsLeave.ToLower() == "y"),
                                LeaveDate = (userinfo.LeaveDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.LeaveDate),
                                UserCatId = userCat.UserCatId,
                            };
                            var dept = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(userinfo.EmpCo, userinfo.DeptCode);
                            tbluserinfo.CostCenter = dept == null ? string.Empty : dept.CostCenter;
                            if (DataProvider.UserProvider.Insert(userinfo, trans) &&
                                DataProvider.TB_UsersProvider.Insert(tbluserinfo, trans))
                            {
                                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EveryOneGroup"]))
                                {
                                    var groupCode = short.Parse(ConfigurationManager.AppSettings["EveryOneGroup"]);
                                    var groupUserInfo = new GroupUserInfo { GroupCode = groupCode, UserCode = userinfo.LoginName };
                                    if (!DataProvider.GroupUserProvider.Insert(groupUserInfo, trans))
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
                                return true;
                            }
                            else
                            {
                                trans.Rollback();
                                return false;
                            }
                        }
                        else
                        {
                            tbluserinfo = new TB_UsersInfo
                            {
                                UserId = tbluserinfo.UserId,
                                HRID = userinfo.EmpCode,
                                UserName = userinfo.LoginName,
                                Domain = ConfigurationManager.AppSettings["DLFlo_Domain"],
                                PWD = ConfigurationManager.AppSettings["DLFlo_UserPWD"],
                                UserDspName = userinfo.EmpName,
                                EMail = userinfo.EMail,
                                Tel = string.IsNullOrEmpty(userinfo.OfficeSubCall) ? userinfo.OfficeCall : string.Format("{0}-{1}", userinfo.OfficeCall, userinfo.OfficeSubCall),
                                Dept = userinfo.DeptName,
                                JobTitle = userinfo.DutyName ?? string.Empty,
                                SpHRID = DataProvider.UserProvider.GetDeptMgr(userinfo.DeptCode),
                                JoinDate = (userinfo.InDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.InDate),

                                LocationCode = ConfigurationManager.AppSettings["DLFlo_LocationCode"],
                                Enalbe = true,
                                IsOut = false,
                                AgentUserId = 0,
                                Language = ConfigurationManager.AppSettings["DLFlo_Language"],
                                MbTel = userinfo.Mobile,
                                CanAssignOut = false,
                                IsLeave = (userinfo.IsLeave.ToLower() == "y"),
                                LeaveDate = (userinfo.LeaveDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.LeaveDate),
                                UserCatId = userCat.UserCatId,
                            };
                            var dept = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(userinfo.EmpCo, userinfo.DeptCode);
                            tbluserinfo.CostCenter = dept == null ? string.Empty : dept.CostCenter;
                            if (DataProvider.UserProvider.Insert(userinfo, trans) &&
                                DataProvider.TB_UsersProvider.Update(tbluserinfo, trans))
                            {
                                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EveryOneGroup"]))
                                {
                                    var groupCode = short.Parse(ConfigurationManager.AppSettings["EveryOneGroup"]);
                                    var groupUserInfo = new GroupUserInfo { GroupCode = groupCode, UserCode = userinfo.LoginName };
                                    if (!DataProvider.GroupUserProvider.Insert(groupUserInfo, trans))
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
                                return true;
                            }
                            else
                            {
                                trans.Rollback();
                                return false;
                            }
                        }
                        
                    }
                    #endregion
                }
            }
            else
            {
                using (var conn = new SqlConnection(ConnectionString.PubData))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction();
                    if (DataProvider.UserProvider.Insert(userinfo, trans))
                    {
                        if(!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EveryOneGroup"]) &&
                            !string.IsNullOrEmpty(userinfo.LoginName))
                        {
                            var groupCode = short.Parse(ConfigurationManager.AppSettings["EveryOneGroup"]);
                            var groupUserInfo = new GroupUserInfo{GroupCode = groupCode,UserCode = userinfo.LoginName};
                            if(DataProvider.GroupUserProvider.Insert(groupUserInfo,trans))
                            {
                                //���¶�����ͬ����־��
                                if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                    !DataProvider.TB_SYNProvider.Update("02", trans))
                                {
                                    trans.Rollback();
                                    return false;
                                }

                                trans.Commit();
                                return true;
                            }
                            else
                            {
                                trans.Rollback();
                                return false;
                            }
                            
                        }
                        else
                        {
                            //���¶�����ͬ����־��
                            if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                !DataProvider.TB_SYNProvider.Update("02", trans))
                            {
                                trans.Rollback();
                                return false;
                            }

                            trans.Commit();
                            return true;
                        }
                    }
                    else
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// �޸���Ա
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public bool UserUpdate(UserInfo userinfo)
        {
            if (isSynchronization() && userinfo.IsUser.ToUpper()=="Y")
            {
                DeptInfo oldDeptInfo = null;
                DeptInfo currentDeptInfo = null;
                TB_ORGTREEInfo oldOrg = null;
                TB_ORGTREEInfo currentOrg = null;
                TB_UsersInfo oldTBUser = null;

                var oldUserInfo = DataProvider.UserProvider.GetById(userinfo.PKID);

                using (var conn = new SqlConnection(ConnectionString.PubData))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction();
                    
                    #region UserCat
                    var userCat = DataProvider.TB_UserCatProvider.GetByUserCatName(ConfigurationManager.AppSettings["DLFlo_UserCat"]);
                    if (userCat == null)
                    {
                        userCat = new TB_UserCatInfo
                        {
                            UserCatName = ConfigurationManager.AppSettings["DLFlo_UserCat"],
                            UserCatEnable = true
                        };
                        if (!DataProvider.TB_UserCatProvider.Insert(userCat, trans))
                        {
                            trans.Rollback();
                            this.AddScript(this.GetType(), "UserCatInsertFailed", "<script>alert('��������ϵͳ������û�����ʧ�ܣ�');</script>");
                            return false;
                        }
                    }
                    #endregion

                    #region Fill TB_User
                    var currentTBUser = new TB_UsersInfo
                                            {
                                                HRID = userinfo.EmpCode,
                                                UserName = userinfo.LoginName,
                                                Domain = ConfigurationManager.AppSettings["DLFlo_Domain"],
                                                PWD = ConfigurationManager.AppSettings["DLFlo_UserPWD"],
                                                UserDspName = userinfo.EmpName,
                                                EMail = (userinfo.EMail ?? string.Empty),
                                                Tel =
                                                    (string.IsNullOrEmpty(userinfo.OfficeSubCall)
                                                         ? userinfo.OfficeCall ?? string.Empty
                                                         : string.Format("{0}-{1}", userinfo.OfficeCall, userinfo.OfficeSubCall)),
                                                Dept = (userinfo.DeptName ?? string.Empty),
                                                JobTitle = (userinfo.DutyName ?? string.Empty),
                                                SpHRID = (DataProvider.UserProvider.GetDeptMgr(userinfo.DeptCode) ?? string.Empty),
                                                JoinDate = (userinfo.InDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.InDate),
                                                LocationCode = ConfigurationManager.AppSettings["DLFlo_LocationCode"],
                                                Enalbe = (userinfo.UserState == "A"),
                                                IsOut = false,
                                                AgentUserId = 0,
                                                Language = ConfigurationManager.AppSettings["DLFlo_Language"],
                                                MbTel = (userinfo.Mobile ?? string.Empty),
                                                CanAssignOut = false,
                                                IsLeave = (userinfo.IsLeave.ToUpper() == "Y"),
                                                LeaveDate = (userinfo.LeaveDate == DateTime.MinValue ? new DateTime(1900, 1, 1) : userinfo.LeaveDate),
                                                UserCatId = userCat.UserCatId
                                            };
                    if (string.IsNullOrEmpty(userinfo.SuperHrid))
                    {
                        currentTBUser.SpHRID = (DataProvider.UserProvider.GetDeptMgr(userinfo.DeptCode) ?? string.Empty);
                    }
                    else
                    {
                        currentTBUser.SpHRID = userinfo.SuperHrid;
                    }
                    var dept = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(userinfo.EmpCo, userinfo.DeptCode);
                    currentTBUser.CostCenter = dept == null ? string.Empty : dept.CostCenter;
                    #endregion
                    #region GroupUser
                    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EveryOneGroup"]) &&
                            !string.IsNullOrEmpty(userinfo.LoginName))
                    {
                        var everyOneGroup = short.Parse(ConfigurationManager.AppSettings["EveryOneGroup"]);
                        var objs = DataProvider.GroupUserProvider.GetByUserCode(userinfo.LoginName) as ListBase<GroupUserInfo>;
                        var groupuser = objs.Find(item => item.GroupCode == everyOneGroup);
                        if (groupuser == null)
                        {
                            groupuser = new GroupUserInfo { GroupCode = everyOneGroup, UserCode = userinfo.LoginName };
                            if (DataProvider.GroupUserProvider.Insert(groupuser, trans) == false)
                            {
                                trans.Rollback();
                                return false;
                            }
                        }
                    }
                    #endregion
                    #region is emp and is user before update
                    if (oldUserInfo.IsEmp.ToUpper() == "Y" && oldUserInfo.IsUser.ToUpper() == "Y")
                    {
                        oldDeptInfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(userinfo.EmpCo, oldUserInfo.DeptCode);
                        oldOrg = DataProvider.TB_OrgTreeProvider.GetByName(oldDeptInfo.DeptCnName);
                        if (oldOrg == null)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "NoCurrentDept", "<script>alert('������ϵͳ�в����ڸ���ǰ�Ĳ���,����ͬ�����ţ�');</script>");
                            return false;
                        }
                        oldTBUser = DataProvider.TB_UsersProvider.GetByUserName(oldUserInfo.LoginName);
                        if (oldTBUser == null)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "NoCurrentDept", "<script>alert('������ϵͳ�в����ڸ���ǰ���û�,����ͬ���û���');</script>");
                            return false;
                        }
                        currentTBUser.UserId = oldTBUser.UserId;
                        currentOrg = DataProvider.TB_OrgTreeProvider.GetByName(userinfo.DeptName);
                        if (currentOrg == null)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "NoCurrentDept", "<script>alert('������ϵͳ���޵�ǰ����,����ͬ�����ţ�');</script>");
                            return false;
                        }
                        
                        if (DataProvider.UserProvider.Update(userinfo, trans) &&
                            DataProvider.TB_UsersProvider.Update(currentTBUser, trans))
                        {
                            var obj = DataProvider.TB_OrgMemLkProvider.GetByUserId(currentTBUser.UserId);
                            if (obj == null)
                            {
                                obj = new TB_ORGMEMLKInfo { LnkId = 0, OrgId = currentOrg.ItemID, UserId = currentTBUser.UserId };
                                if (DataProvider.TB_OrgMemLkProvider.Insert(obj, trans))
                                {
                                    //���¶�����ͬ����־��
                                    if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                        !DataProvider.TB_SYNProvider.Update("02", trans))
                                    {
                                        trans.Rollback();
                                        return false;
                                    }

                                    trans.Commit();
                                    return true;
                                }
                                else
                                {
                                    trans.Rollback();
                                    return false;
                                }
                            }
                            else
                            {
                                obj.OrgId = currentOrg.ItemID;
                                if (DataProvider.TB_OrgMemLkProvider.Update(obj, trans))
                                {
                                    //���¶�����ͬ����־��
                                    if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                        !DataProvider.TB_SYNProvider.Update("02", trans))
                                    {
                                        trans.Rollback();
                                        return false;
                                    }

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
                        else
                        {
                            trans.Rollback();
                            return false;
                        }
                        
                    }
                    #endregion
                    #region is user and is not emp before update
                    else if (oldUserInfo.IsUser.ToUpper() == "Y" && oldUserInfo.IsEmp.ToUpper() == "N")
                    {
                        oldTBUser = DataProvider.TB_UsersProvider.GetByUserName(oldUserInfo.LoginName);
                        if (oldTBUser == null)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "NoCurrentDept", "<script>alert('������ϵͳ�в����ڸ���ǰ���û�,����ͬ���û���');</script>");
                            return false;
                        }
                        currentTBUser.UserId = oldTBUser.UserId;
                        if (userinfo.IsEmp.ToUpper() == "Y")//��ǰ�û���Ա��
                        {
                            currentDeptInfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(userinfo.EmpCo, userinfo.DeptCode);
                            currentOrg = DataProvider.TB_OrgTreeProvider.GetByName(currentDeptInfo.DeptCnName);
                            if (currentOrg == null)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "NoCurrentDept", "<script>alert('������ϵͳ���޵�ǰ����,����ͬ�����ţ�');</script>");
                                return false;
                            }
                            
                            if (DataProvider.UserProvider.Update(userinfo, trans) &&
                                DataProvider.TB_UsersProvider.Update(currentTBUser, trans))
                            {
                                var obj = DataProvider.TB_OrgMemLkProvider.GetByUserId(currentTBUser.UserId);
                                if (obj == null)
                                {
                                    obj = new TB_ORGMEMLKInfo { LnkId = 0, OrgId = currentOrg.ItemID, UserId = currentTBUser.UserId };

                                    if (DataProvider.TB_OrgMemLkProvider.Insert(obj, trans))
                                    {
                                        //���¶�����ͬ����־��
                                        if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                            !DataProvider.TB_SYNProvider.Update("02", trans))
                                        {
                                            trans.Rollback();
                                            return false;
                                        }

                                        trans.Commit();
                                        return true;
                                    }
                                    else
                                    {
                                        trans.Rollback();
                                        return false;
                                    }
                                }
                                else
                                {
                                    obj.OrgId = currentOrg.ItemID;
                                    if (DataProvider.TB_OrgMemLkProvider.Insert(obj, trans))
                                    {
                                        //���¶�����ͬ����־��
                                        if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                            !DataProvider.TB_SYNProvider.Update("02", trans))
                                        {
                                            trans.Rollback();
                                            return false;
                                        }

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
                            else
                            {
                                trans.Rollback();
                                return false;
                            }
                            
                        }
                        else
                        {
                            if (DataProvider.UserProvider.Update(userinfo, trans) &&
                                DataProvider.TB_UsersProvider.Update(currentTBUser, trans))
                            {
                                //���¶�����ͬ����־��
                                if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                    !DataProvider.TB_SYNProvider.Update("02", trans))
                                {
                                    trans.Rollback();
                                    return false;
                                }

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
                    #endregion
                    #region is not user and is emp before update
                    else if (oldUserInfo.IsUser.ToUpper() == "N" && oldUserInfo.IsEmp.ToUpper() == "Y")
                    {
                        #region If IsEmp Check Current Org.
                        if (userinfo.IsEmp.ToUpper() == "Y")//��ǰ�û���Ա��
                        {
                            currentDeptInfo = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(userinfo.EmpCo, userinfo.DeptCode);
                            currentOrg = DataProvider.TB_OrgTreeProvider.GetByName(currentDeptInfo.DeptCnName);
                            if (currentOrg == null)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "NoCurrentDept", "<script>alert('������ϵͳ���޵�ǰ����,����ͬ�����ţ�');</script>");
                                return false;
                            }
                            #region update
                            if (DataProvider.UserProvider.Update(userinfo, trans) &&
                                DataProvider.TB_UsersProvider.Insert(currentTBUser, trans))
                            {
                                var obj = new TB_ORGMEMLKInfo { LnkId = 0, OrgId = currentOrg.ItemID, UserId = currentTBUser.UserId };

                                if (DataProvider.TB_OrgMemLkProvider.Insert(obj, trans))
                                {
                                    //���¶�����ͬ����־��
                                    if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                        !DataProvider.TB_SYNProvider.Update("02", trans))
                                    {
                                        trans.Rollback();
                                        return false;
                                    }

                                    trans.Commit();
                                    return true;
                                }
                                else
                                {
                                    trans.Rollback();
                                    return false;
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                return false;
                            }
                            #endregion
                        }
                        else
                        {
                            if(DataProvider.UserProvider.Update(userinfo, trans) &&
                                DataProvider.TB_UsersProvider.Insert(currentTBUser,trans))
                            {
                                //���¶�����ͬ����־��
                                if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                    !DataProvider.TB_SYNProvider.Update("02", trans))
                                {
                                    trans.Rollback();
                                    return false;
                                }

                                trans.Commit();
                                return true;
                            }
                            else
                            {
                                trans.Rollback();
                                return false;
                            }
                        }
                        #endregion
                    }
                    #endregion
                    #region is not user and is not emp before update
                    else if (oldUserInfo.IsUser.ToUpper() == "N" && oldUserInfo.IsEmp.ToUpper() == "N")
                    {
                        if (DataProvider.UserProvider.Update(userinfo, trans) &&
                            DataProvider.TB_UsersProvider.Insert(currentTBUser, trans))
                        {
                            //���¶�����ͬ����־��
                            if (!DataProvider.TB_SYNProvider.Update("01", trans) ||
                                !DataProvider.TB_SYNProvider.Update("02", trans))
                            {
                                trans.Rollback();
                                return false;
                            }

                            trans.Commit();
                            return true;
                        }
                        else
                        {
                            trans.Rollback();
                            return false;
                        }
                    }
                    #endregion
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return DataProvider.UserProvider.Update(userinfo);
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
            if(!Page.IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.UserMaintain))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!string.IsNullOrEmpty(Request["PKID"]))
                    this.PKID = int.Parse(Request["PKID"]);
                if (!string.IsNullOrEmpty(Request["DeptCode"]))
                {
                    this.DeptCode = Request["DeptCode"];
                    if (this.DeptCode == "-100")//�ⲿ��Ա
                    {
                        this.hideEmpInfoBlock();
                        this.tb_EmpDept.Value = "-100";
                        this.tb_DeptCnName.Text = string.Empty;
                        this.ddw_IsEmp.SelectedValue = "N";
                    }
                    else
                    {
                        var oDept = DataProvider.DeptProvider.GetByCompanyCodeAndDeptCode(this.CompanyCode,
                                                                                                 this.DeptCode);
                            
                        if (oDept != null)
                        {
                            this.tb_EmpDept.Value = oDept.DeptCode;
                            this.tb_DeptCnName.Text = oDept.DeptCnName;
                        }
                    }
                }
                
                BindEmpState();
                BindDuty();
                ddw_IsEmp.Attributes.Add("onchange", "showEmpPart()");
                this.tb_DeptCnName.Attributes.Add("readonly", "readonly");
                if (this.PKID != -1)
                    GetUserInfo(PKID);
            }
        }
        /// <summary>
        /// Ա�������ı����ı��ı��¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tb_EmpCode_TextChanged(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.EmpCode))
            {
                this.GetUserInfoByCompanyAndEmpCode(this.CompanyCode, this.EmpCode);
            }
        }
        /// <summary>
        /// toolbar���¼���
        /// </summary>
        /// <param name="item">�����¼���ToolbarItem��</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "save":
                    this.save();
                    break;
            }
        }
        #endregion

        protected void tb_DeptCnName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_DeptCnName.Text))
            {
                var deptCode = tb_EmpDept.Value;
                var superHrid = DataProvider.UserProvider.GetDeptMgr(deptCode);
                this.tb_SupervisorHrid.Text = superHrid;    
            }
            else
            {
                this.tb_SupervisorHrid.Text = "";
            }
        }
    }
}
