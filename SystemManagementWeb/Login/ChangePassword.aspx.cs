using System;
using Shmzh.Components.SystemComponent;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// ChangePassword 的摘要说明。
	/// </summary>
	public partial class ChangePassword : BasePage
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			base.OnInit(e);
			InitializeComponent();
			
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void btn_submit_Click(object sender, System.EventArgs e)
		{
			if(!Shmzh.Components.SystemComponent.User.ChangePassword(this.CurrentUser.thisUserInfo.LoginName,tb_oldpass.Text,tb_newpass.Text))
			{
				this.ClientScript.RegisterStartupScript(this.GetType(),"password","alert('The old password is wrong!');",true);
			}
			else
			{
				Response.Redirect("CPWDOK.aspx");
			}
		}
	}
}
