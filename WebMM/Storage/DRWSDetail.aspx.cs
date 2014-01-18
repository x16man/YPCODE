using System;
using System.Web.UI;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// DRWSDetail 的摘要说明。
	/// </summary>
	public partial class DRWSDetail : Page
	{
		#region 成员变量
		private string PKID;
		#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
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
