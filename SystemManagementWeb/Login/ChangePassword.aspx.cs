using System;
using Shmzh.Components.SystemComponent;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// ChangePassword ��ժҪ˵����
	/// </summary>
	public partial class ChangePassword : BasePage
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			base.OnInit(e);
			InitializeComponent();
			
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
