using System;

namespace SystemManagement
{
	/// <summary>
	/// _default 的摘要说明。
	/// </summary>
	public partial class _default : BasePage
	{
	
		#region 属性
		
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				this.objMzhWebUIFrame.CurrentUser = this.CurrentUser;
			}
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
	}
}
