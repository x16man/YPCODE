using System;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_UserDetail 的摘要说明。
	/// </summary>
	public partial class SYS_UserDetail : System.Web.UI.Page
	{

		private int PKID;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!string.IsNullOrEmpty(Request["PKID"]))
			{
				PKID=int.Parse(Request["PKID"]);
			    var obj = DataProvider.UserProvider.GetById(PKID);

			    lb_EmpCnName.Text = obj.EmpName;
			    lb_EmpCode.Text = obj.EmpCode;
			    lb_EmpEnName.Text = obj.EmpEnName;
				lb_IsEmp.Text = obj.IsEmp == "Y"?"内部员工":"外部用户";
			    lb_LoginName.Text = obj.LoginName;
				lb_UserState.Text = obj.IsUser == "Y"?"启用":"禁用";
			    lb_OfficeCall.Text = string.Format("{0}-{1}", obj.OfficeCall, obj.OfficeSubCall);
			    lb_OfficeFax.Text = obj.OfficeFax;
			    lb_Mobile.Text = obj.Mobile;
			    lb_Email.Text = obj.EMail;
			    lb_Birthday.Text = obj.BirthDay == DateTime.MinValue ? string.Empty:obj.BirthDay.ToString("d");
				lb_Gender.Text = obj.Gender == "M"?"男":"女";
			    lb_DeptCnName.Text = obj.DeptName;
			    lb_IDCard.Text = obj.IDCard;
			    lb_DutyCnName.Text = obj.DutyName;
			    lb_DutyEnName.Text = obj.DutyEnName;
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
	}
}
