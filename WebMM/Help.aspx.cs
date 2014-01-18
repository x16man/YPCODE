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
using Shmzh.Components.SystemComponent;

namespace MZHMM.WebMM
{
	/// <summary>
	/// Help 的摘要说明。
	/// </summary>
	public partial class Help : System.Web.UI.Page
	{
		private string Code;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request["Code"]!=null&&Request["Code"]!="")
			{
				Code=Server.UrlDecode(Request["Code"]);
			}
			else
			{
				Code=Session["HelpCode"].ToString();
			}
			Session["HelpCode"] = Code;
			loadMainHelp();
			loadSubHelp();
		}


		private void loadMainHelp()
		{
			MzhHelp mainHelp = new MzhHelp();
			DataSet mds = mainHelp.GetHelpInfoByCode(Code);
			if(mds.Tables[0].Rows.Count>0)
			{
				lb_mainHelpTitle.Text=mds.Tables[0].Rows[0]["Title"].ToString();
				lb_mainHelpContent.Text=mds.Tables[0].Rows[0]["Content"].ToString();
			}
			else
			{
				Response.Write(mainHelp.Message);
			}
		}

		private void loadSubHelp()
		{
			MzhHelp subHelp = new MzhHelp();
			DataSet sds = subHelp.GetAllHelpsByParentCode(Code);
			Repeater1.DataSource=sds;
			Repeater1.DataBind();			
		}
	}
}
