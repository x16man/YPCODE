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

namespace WebMM.Purchase
{
	/// <summary>
	/// PPDetail ��ժҪ˵����
	/// </summary>
	public partial class PPDetail : System.Web.UI.Page
	{
        int EntryNo;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			
			EntryNo = int.Parse(this.Request["EntryNo"].ToString());
			this.Response.Redirect("PPReport.aspx?OP= View&EntryNo="+EntryNo.ToString(),true);
		}

		
	}
}
