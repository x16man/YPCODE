using System;

namespace SystemManagement
{
	/// <summary>
	/// _default ��ժҪ˵����
	/// </summary>
	public partial class _default : BasePage
	{
	
		#region ����
		
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				this.objMzhWebUIFrame.CurrentUser = this.CurrentUser;
			}
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
	}
}
