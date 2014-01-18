namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		VendorChooserControl 的摘要说明。
	/// </summary>
	public partial class VendorChooserControl : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
		}
		public string VendorCode
		{
			get {return this.txtVendorCode.Text;}
		}
		public string VendorName
		{
			get {return this.txtVendor.Text;}
		}
	}
}
