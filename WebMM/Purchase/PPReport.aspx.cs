using System;

namespace WebMM.Purchase
{
    public partial class PPReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                this.ReportViewer1.ServerUrl = System.Configuration.ConfigurationManager.AppSettings["ReportServerUrl"].ToString();

                if (Master.EntryNo > 163)
                {
                    if (Master.DisplayPPPrice)
                        this.ReportViewer1.ReportPath = "/MMReports/PurchasePlanKM";
                    else
                        this.ReportViewer1.ReportPath = "/MMReports/PurchasePlanNoPrice";
                }
                else
                {
                    if (Master.DisplayPPPrice)
                        this.ReportViewer1.ReportPath = "/MMReports/PurchasePlan";
                    else
                        this.ReportViewer1.ReportPath = "/MMReports/PurchasePlanNoPrice";
                }
                this.ReportViewer1.SetQueryParameter("EntryNo", Master.EntryNo.ToString());
            }
        }
    }
}
