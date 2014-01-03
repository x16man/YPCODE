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

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_EditDuty 的摘要说明。
	/// </summary>
	public partial class SYS_EditDuty : BasePage
	{
		private string ParentDuty;
		private string DutyCode;
		private string EditState;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request["DutyCode"]!=null&&Request["DutyCode"]!="")
			{
				EditState="edit";
				DutyCode = Request["DutyCode"].ToString();
				if(!Page.IsPostBack)
				{
					
					//if(!UserRights.IsHaveRightCode(((User)Session["User"]),(int)RightCodeList.DutyEdit))
					if(!CurrentUser.HasRight(RightEnum.DutyMaintain))
					{
						Response.Write("<script>alert('"+ConfigCommon.GetMessageValue("RightCodeNoEmpty")+"');</script>");
						return;
				
					}
					ShowDutyInfo();
				}
			}
			else if (Request["ParentDuty"]!=null&&Request["ParentDuty"]!="")
			{
				//if(!UserRights.IsHaveRightCode(((User)Session["User"]),(int)RightCodeList.DutyEdit))
				if(!CurrentUser.HasRight(RightEnum.DutyMaintain))
				{
					Response.Write("<script>alert('"+ConfigCommon.GetMessageValue("RightCodeNoEmpty")+"');</script>");
					return;
				
				}
				EditState="new";
				ParentDuty = Request["ParentDuty"].ToString();
			}
			else
			{
				EditState="root";
				ParentDuty = "-1";
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private void ShowDutyInfo()
		{
			string EmpCnNames;
			EntryDuty duty = new EntryDuty();
			Organize org = new Organize();
			duty=org.GetDutyByDutyCode(((User)Session["User"]).thisUserInfo.EmpCo,DutyCode);
			tb_DutyCnName.Text=duty.Tables[0].Rows[0][EntryDuty.DUTYCNNAME_FIELD].ToString();
			tb_Remark.Text=duty.Tables[0].Rows[0][EntryDuty.REMARK_FIELD].ToString();
//			tb_DeptMgr.Text=dept.Tables[0].Rows[0][EntryDept.DEPTMGR_FIELD].ToString();
			tb_DutyCode.Text=duty.Tables[0].Rows[0][EntryDuty.DUTYCODE_FIELD].ToString();
			tb_DutyCode.Enabled=false;
			tb_UserIDs.Value=org.GetDutyUsers(DutyCode,((User)Session["User"]).thisUserInfo.EmpCo,out EmpCnNames);
			tb_UserNames.Text=EmpCnNames;
			this.txtEnName.Text = duty.Tables[0].Rows[0][EntryDuty.DUTYENNAME_FIELD].ToString();
			this.dpValid.SelectedValue = duty.Tables[0].Rows[0][EntryDuty.ISVALID_FIELD].ToString();
		}

		protected void btn_save_Click(object sender, System.EventArgs e)
		{
			//if(!UserRights.IsHaveRightCode(((User)Session["User"]),(int)RightCodeList.DutyEdit))
			if(!CurrentUser.HasRight(RightEnum.DutyMaintain))
			{
				Response.Write("<script>alert('"+ConfigCommon.GetMessageValue("RightCodeNoEmpty")+"');</script>");
				return;
				
			}
			EntryDuty duty = new EntryDuty();
			duty.Tables[0].Rows.Add(duty.Tables[0].NewRow());

			duty.Tables[0].Rows[0][EntryDuty.DUTYCNNAME_FIELD]=tb_DutyCnName.Text;
			duty.Tables[0].Rows[0][EntryDuty.REMARK_FIELD]=tb_Remark.Text;
//			duty.Tables[0].Rows[0][EntryDuty.DEPTMGR_FIELD]=tb_DeptMgr.Text;
			duty.Tables[0].Rows[0][EntryDuty.DUTYCO_FIELD]=((User)Session["User"]).thisUserInfo.EmpCo;
			duty.Tables[0].Rows[0][EntryDuty.ISVALID_FIELD]= this.dpValid.SelectedValue;
			duty.Tables[0].Rows[0][EntryDuty.DUTYENNAME_FIELD] = this.txtEnName.Text ;
			
			if(EditState=="new")
			{
				duty.Tables[0].Rows[0][EntryDuty.DUTYCODE_FIELD]=tb_DutyCode.Text.Trim();
				duty.Tables[0].Rows[0][EntryDuty.PARENTDUTYCODE_FIELD]=ParentDuty;
				Shmzh.Components.SystemComponent.Organize obj = new Shmzh.Components.SystemComponent.Organize();
				
				if(obj.AddDuty(duty))
				{
					Response.Write("<script>alert('"+ConfigCommon.GetMessageValue("DutyInsertSuccess")+"');parent.frames['tree'].CommitNewNode('"+tb_DutyCode.Text.Trim()+"','"+tb_DutyCnName.Text+"','SYS_EditDuty.aspx?DutyCode="+tb_DutyCode.Text.Trim()+"')</script>");
					Response.Write("<script>document.location='SYS_EditDuty.aspx?DutyCode="+tb_DutyCode.Text.Trim()+"'</script>");					
				}
				else
				{
					Response.Write(obj.Message);
					Response.Write("<script>parent.frames['tree'].alert('"+obj.Message+"');</script>");
				}
				
			}
			else if(EditState=="edit")
			{
				duty.Tables[0].Rows[0][EntryDuty.DUTYCODE_FIELD]=DutyCode;				
				Organize obj = new Organize();
				if(obj.UpdateDuty(duty))
				{
					Response.Write("<script>alert('"+ConfigCommon.GetMessageValue("DutyUpdateSuccess")+"');parent.frames['tree'].CommitEditNode('"+tb_DutyCnName.Text+"')</script>");
					
				}
				else
				{
					Response.Write("<script>parent.frames['tree'].alert('"+obj.Message+"');</script>");
					Response.Write(obj.Message);
				}
			}
			else
			{
				duty.Tables[0].Rows[0][EntryDuty.DUTYCODE_FIELD]=tb_DutyCode.Text.Trim();
				duty.Tables[0].Rows[0][EntryDuty.PARENTDUTYCODE_FIELD]=ParentDuty;
				Organize obj = new Organize();
				if(obj.AddDuty(duty))
				{
					Response.Write("<script>alert('"+ConfigCommon.GetMessageValue("DutyInsertSuccess")+"');parent.frames['tree'].CommitNewRootNode('"+tb_DutyCode.Text.Trim()+"','"+tb_DutyCnName.Text+"','SYS_EditDuty.aspx?DutyCode="+tb_DutyCode.Text.Trim()+"')</script>");
					Response.Write("<script>document.location='SYS_EditDuty.aspx?DutyCode="+tb_DutyCode.Text.Trim()+"'</script>");					
				}
				else
				{
					Response.Write(obj.Message);
					Response.Write("<script>parent.frames['tree'].alert('"+obj.Message+"');</script>");
				}
			}
		}
	}
}
