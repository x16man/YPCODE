namespace WebMM.Analysis
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using MZHCommon.Database;
    using Shmzh.MM.Common;
	//using MZHCommon.PageStyle;
	/// <summary>
	///		WUC_DocDowithCount 的摘要说明。
	/// </summary>
	public partial class WUC_DocDowithCount : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				
				SQLServer oSQLServer = new SQLServer();
				DataSet oDT;
				Hashtable oHT = new Hashtable();
				oHT.Add("@UserLoginId",Session[MySession.UserLoginId].ToString());
				oDT = oSQLServer.ExecSPReturnDS("Analysis_GetDocDowithCount",oHT);
				this.MzhDataGrid1.DataSource = oDT.Tables[0].DefaultView;
				this.MzhDataGrid1.DataBind();
			}
		}
	}
}
