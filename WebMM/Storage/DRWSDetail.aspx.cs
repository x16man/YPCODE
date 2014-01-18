using System;
using System.Web.UI;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// DRWSDetail ��ժҪ˵����
	/// </summary>
	public partial class DRWSDetail : Page
	{
		#region ��Ա����
		private string PKID;
		#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (!string.IsNullOrEmpty(this.Request["PKID"]))
            {
                PKID = this.Request["PKID"].ToString();
                switch (PKID.Split('|')[1])
                {
                    case "1":
                        this.Response.Redirect("../Purchase/ROSDetail.aspx?Op=View&EntryNo=" + PKID.Split('|')[0]);
                        break;
                    case "2":
                        this.Response.Redirect("../Purchase/MRPDetail.aspx?Op=View&EntryNo=" + PKID.Split('|')[0]);
                        break;
                }
            }
        }
	}
}
