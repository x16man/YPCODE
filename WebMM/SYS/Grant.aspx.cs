using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Shmzh.Components.SystemComponent;
using SysRight = MZHMM.WebMM.Common.SysRight;
using Shmzh.Components.SystemComponent.SQLServerDAL;
using System.Collections.Generic;

namespace MZHMM.WebMM.SYS
{
    public partial class Grant : System.Web.UI.Page
    {
        private Shmzh.Components.SystemComponent.SQLServerDAL.Grant grants = new Shmzh.Components.SystemComponent.SQLServerDAL.Grant();

        private string grantorName;

        private string grantorDept;

        private string embracer;

        private IList<GrantInfo> grantlist;
       
        private Shmzh.Components.SystemComponent.GrantInfo grant;

        private string grantor;

        private DateTime effectiveTime;

        private bool loginIsValid;

        private string reason;

        protected void Page_Load(object sender, EventArgs e)
        {
            tb_rolename.Attributes.Add("ReadOnly","ReadOnly");
            tbRoleCode.Attributes.Add("ReadOnly", "ReadOnly");
            if (!this.IsPostBack)
            {
                if (!Master.HasBrowseRight(SysRight.GrantMaintain))
                {
                    return;
                }

                //this.WebDateChooser1.Value=DateTime.Now;
                this.txtRoleDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                this.myBindDatas();
            }
        }

        private void myBindDatas()
        {


            grantlist = grants.GetAllAvalibleByGrantor(Master.CurrentUser.thisUserInfo.LoginName);

            this.MzhDataGrid1.DataSource = grantlist;
            this.MzhDataGrid1.DataBind();

        }

        protected void CancelGrant_Click(object sender, EventArgs e)
        {
            if (this.MzhDataGrid1.SelectedID == "") return;

            grants = new Shmzh.Components.SystemComponent.SQLServerDAL.Grant();

            grant = grants.GetById(int.Parse(MzhDataGrid1.SelectedID));
            grant.IsValid = false;
            grant.InvalidTime = System.DateTime.Now;

            if (grants.Update(grant))
            {
                this.myBindDatas();
            }
            else
            {
                ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"取消授权失败！\");", true);
                    
                return;
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            if (MzhDataGrid1.SelectedID != "")
            {
                grants = new Shmzh.Components.SystemComponent.SQLServerDAL.Grant();

                grant = grants.GetById(long.Parse(this.MzhDataGrid1.SelectedID));

                if (grant.ID != -1)
                {
                    this.txtPKID.Value = grant.ID.ToString();
                    this.tbRoleCode.Text = grant.Embracer;
                    this.tb_rolename.Text = grant.EmbracerName;
                    //this.WebDateChooser1.Value=grant.EffectTime.ToShortDateString();
                    this.txtRoleDate.Text = grant.EffectTime.ToString("yyyy-MM-dd");
                    this.CheckBox1.Checked = grant.LoginIsValid;
                    this.txtReason.Text = grant.Reason;
                }
            }
        }

        protected void AddGrant_Click(object sender, EventArgs e)
        {
            if (tbRoleCode.Text != "")
            {
               
                if (this.txtPKID.Value != "")
                {
                    //grant.ID = long.Parse(this.txtPKID.Value);

                    // Shmzh.Components.SystemComponent.Grants grants=new Shmzh.Components.SystemComponent.Grants();
                    //grants.get
                    grant = grants.GetById(long.Parse(this.txtPKID.Value));
                    
                    if (txtRoleDate.Text != "")
                        grant.EffectTime = DateTime.Parse(this.txtRoleDate.Text.Trim().ToString());
                    grant.Embracer = embracer;
                    
                    grant.LoginIsValid = this.CheckBox1.Checked;
                    grant.Reason = reason;
                    grant.IsValid = true;
                    grant.Embracer = this.tbRoleCode.Text;
                    grant.EmbracerName = tb_rolename.Text;
                    grant.EmbracerDept = txtDeptName.Value;

                    if(grants.Update(grant))
                    {
                         this.tbRoleCode.Text = "";
                        this.tb_rolename.Text = "";
                        this.txtReason.Text = "";
                        this.myBindDatas();
                        this.txtPKID.Value = "";
                        ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"修改授权成功！\");", true);
                          myBindDatas();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"修改授权失败！\");", true);
                        return;
                    }

                }
                else
                {
                    grantor = Master.CurrentUser.thisUserInfo.LoginName;
                    grantorName = Master.CurrentUser.thisUserInfo.EmpName;
                    grantorDept = Master.CurrentUser.thisUserInfo.DeptName;
                    embracer = this.tbRoleCode.Text;
                    if (txtRoleDate.Text != "")
                        effectiveTime = DateTime.Parse(this.txtRoleDate.Text.Trim().ToString());

                    loginIsValid = this.CheckBox1.Checked;
                    reason = this.txtReason.Text;

                   
                    grant = new Shmzh.Components.SystemComponent.GrantInfo();

                    grant.EffectTime = effectiveTime;
                    grant.Embracer = embracer;
                    grant.Grantor = grantor;
                    grant.GrantorDept = grantorDept;
                    grant.GrantorName = grantorName;
                    grant.LoginIsValid = loginIsValid;
                    grant.Reason = reason;
                    grant.CreateTime = System.DateTime.Now;
                    grant.IsValid = true;
                    grant.EmbracerName = tb_rolename.Text;
                    grant.EmbracerDept = txtDeptName.Value;

                    if (grants.Insert(grant))
                    {
                        this.tbRoleCode.Text = "";
                        this.tb_rolename.Text = "";
                        this.txtReason.Text = "";
                        this.myBindDatas();
                        this.txtPKID.Value = "";
                        ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"增加授权成功！\");", true);
                        myBindDatas();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"增加授权失败！\");", true);
                        return;
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"选择接受人！\");", true);
                return;

            }
        }
    }
}
