using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.MM.Facade;
using Shmzh.MM.Common;
using Shmzh.Components.SystemComponent.DALFactory;
using SysRight = MZHMM.WebMM.Common.SysRight;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent.Enum;

namespace MZHMM.WebMM.SYS
{
	/// <summary>
	/// UserDocDept 的摘要说明。
	/// </summary>
	public partial class UserDocDept : System.Web.UI.Page
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Property
        /// <summary>
        /// 当前用户。
        /// </summary>
        public User CurrentUser
        {
            get { return Session["User"] as User; }
        }
        #endregion

        #region Method
        /// <summary>
        /// 绑定角色下拉列表
        /// </summary>
        private void BindRole()
        {
            //角色列表。
            lbRole.Items.Clear();

            var rolelist = DataProvider.RoleProvider.GetAllAvalibleByProductCode(ProductEnum.MM);
            for (var i = 0; i < rolelist.Count; i++)
            {
                var olt = new ListItem(rolelist[i].RoleName, rolelist[i].RoleCode.ToString());
                lbRole.Items.Add(olt);
            }
        }
        private void BindUser()
        {
            var objs = DataProvider.UserProvider.GetAllByCompany(this.CurrentUser.Company) as List<UserInfo>;
            objs.Sort((a, b) => a.LoginName.CompareTo(b.LoginName));

            foreach (UserInfo t in objs)
            {
                var olt = new ListItem(t.EmpName + "  [" + t.LoginName + "]", t.LoginName);
                lbUser.Items.Add(olt);
            }
        }
        /// <summary>
        /// 根据角色绑定用户对象。
        /// </summary>
        /// <param name="RoleID"></param>
        private void BindUserByRole(int RoleID)
        {
            var userlist = DataProvider.UserProvider.GetByRoleCode((short)RoleID) as List<UserInfo>;
            userlist.Sort((a, b) => a.EmpName.CompareTo(b.EmpName));

            lbUser.Items.Clear();
            foreach (var t in userlist)
            {
                var olt = new ListItem(t.EmpName + "  [" + t.LoginName + "]", t.LoginName);
                lbUser.Items.Add(olt);
            }
        }
        /// <summary>
        /// 绑定单据类型下拉列表。
        /// </summary>
        private void BindDocs()
        {
            var objDoc = new SysSystem().GetAllBillOfDocs();

            for (var i = 0; i < objDoc.Tables[SBODData.SBOD_TABLE].Rows.Count; i++)
            {
                var olt = new ListItem(objDoc.Tables[SBODData.SBOD_TABLE].Rows[i][SBODData.DOCNAME_FIELD].ToString(), objDoc.Tables[SBODData.SBOD_TABLE].Rows[i][SBODData.DOCCODE_FIELD].ToString());
                lbDocs.Items.Add(olt);
            }

        }
        /// <summary>
        /// 绑定并且勾选部门下拉列表。
        /// </summary>
        private void BindDepts()
        {
            if ((lbUser.SelectedValue != "") && (lbDocs.SelectedValue != "") && (lbRole.SelectedValue !=""))
            {
                var deptList = new SysSystem().GetAllDeptsByUserAndDocAndRole(lbUser.SelectedValue, short.Parse(lbDocs.SelectedValue), short.Parse(lbRole.SelectedValue));

                DeptTreeControls1.ClearAllNodeChecked();
                DeptTreeControls1.SetCheckLists(deptList);
            }
        }

        #endregion

        #region Event
        protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
                if (!CurrentUser.HasRight(SysRight.UserDocDeptMaintain))
                {
                    Response.Redirect("../Common/NoRight.aspx");
                    return;
                }

				this.BindRole();
				//BindUser();
				BindDocs();
				DeptTreeControls1.Company=this.CurrentUser.Company;
			}
		}
		
		protected void lbDocs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if((lbUser.SelectedValue!="") &&(lbDocs.SelectedValue!="") && (lbRole.SelectedValue!=""))
			{
				BindDepts();
			}
		}

		protected void lbUser_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if((lbUser.SelectedValue!="") &&(lbDocs.SelectedValue!="") && (lbRole.SelectedValue != ""))
			{
				BindDepts();
			}
		}
		
        protected void lbRole_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lbRole.SelectedValue != "")
			{
				this.BindUserByRole(int.Parse(lbRole.SelectedValue));
			}
            if ((lbUser.SelectedValue != "") && (lbDocs.SelectedValue != "") && (lbRole.SelectedValue != ""))
            {
                BindDepts();
            }
		}	

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
		    var roleCode = lbRole.SelectedValue;
		    var loginName =lbUser.SelectedValue;
			var docs =lbDocs.SelectedValue;
		    var deptList="";

            if(string.IsNullOrEmpty(roleCode))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "NoRole", "alert('没有选中角色');", true);
                return;
            }
			if(loginName=="")
			{
                ClientScript.RegisterStartupScript( this.GetType(), "NoUser", "alert('没有选中用户');", true);
				return;
			}

			if(docs=="")
			{
                ClientScript.RegisterStartupScript( this.GetType(), "NoBill", "alert('没有选中单据');", true);
				return;
			}

			deptList=DeptTreeControls1.GetAllCheckedList();

		    new SysSystem().AddUserDocDepts(loginName,short.Parse(roleCode),short.Parse(docs),deptList);
            ClientScript.RegisterStartupScript(this.GetType(), "Dept", "alert('保存成功');", true);
        }
        #endregion
    }	
}


