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
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHCommon.Database;
namespace MZHMM.WebMM.Purchase
{
	/// <summary>
	/// PPReport 的摘要说明。
	/// </summary>
	public partial class PPAYDetail : System.Web.UI.Page
	{
		#region 成员变量

		

		private int _EntryNo;
		#endregion
	
		#region 事件
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this._EntryNo = Convert.ToInt32(this.Request["EntryNo"].ToString());
			
			this.ReportViewer1.ServerUrl = System.Configuration.ConfigurationSettings.AppSettings["ReportServerUrl"].ToString();

			this.ReportViewer1.ReportPath= "/MMReports/BorDetailByInvoice";
			
			this.ReportViewer1.SetQueryParameter("EntryNo",this._EntryNo.ToString());

		}
		#endregion
	}
}
