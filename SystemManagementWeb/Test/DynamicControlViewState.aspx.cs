using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SystemManagement.Test
{
    public partial class DynamicControlViewState : System.Web.UI.Page
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            this.output.Text += "PageLoad" + Environment.NewLine;
        }
        protected void OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.output.Text += string.Format("结果：{0}",sqlStatement+Environment.NewLine);
        }
    }
}
