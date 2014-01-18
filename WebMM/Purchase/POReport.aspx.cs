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


namespace MZHMM.WebMM.Purchase
{
	/// <summary>
	/// PPReport ��ժҪ˵����
	/// </summary>
	public partial class POReport : System.Web.UI.Page
	{
		#region ��Ա����

		

		private string _EntryNo;
		#endregion
	
		#region �¼�
		protected void Page_Load(object sender, System.EventArgs e)
		{

			this._EntryNo = this.Request["EntryNo"].ToString();

			this.ReportViewer1.ServerUrl = System.Configuration.ConfigurationManager.AppSettings["ReportServerUrl"].ToString();

			this.ReportViewer1.ReportPath= "/MMReports/Order";
			
			this.ReportViewer1.SetQueryParameter("EntryNo",this._EntryNo);
			this.ReportViewer1.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.False;

		}
		#endregion

		
	}
}
