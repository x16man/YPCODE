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
	/// PPReport 的摘要说明。
	/// </summary>
	public partial class POReport : System.Web.UI.Page
	{
		#region 成员变量

		

		private string _EntryNo;
		#endregion
	
		#region 事件
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
