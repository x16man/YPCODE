namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		VendorChooserControl ��ժҪ˵����
	/// </summary>
	public partial class VendorChooserControl : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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