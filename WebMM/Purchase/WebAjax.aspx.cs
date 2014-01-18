using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MZHCommon.Database;
namespace MZHMM.WebMM.Purchase
{
	/// <summary>
	/// WebAjax 的摘要说明。
	/// </summary>
	public partial class WebAjax : System.Web.UI.Page
	{
		private int CatCode
		{
			get {return int.Parse(this.Request["CatCode"].ToString());}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!this.IsPostBack)
			{
				SQLServer oSQLServer = new SQLServer();
				DataSet DS ;
				Hashtable oHT = new Hashtable();
				oHT.Add("@CatCode", this.CatCode);
				StringBuilder myStringBuilder = new StringBuilder();
				//StringBuilder myStringBuilder = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\" ?> ");
				//myStringBuilder.Append("<VendorList>");
				DS = oSQLServer.ExecSPReturnDS("Pur_PPRNGetByCatCode",oHT);
				/*
				for (int i = 0; i<DS.Tables[0].Rows.Count; i++)
				{
					myStringBuilder.Append("<Vendor>");
				    myStringBuilder.Append("<Code>");
					myStringBuilder.Append(DS.Tables[0].Rows[i]["Code"].ToString());
					myStringBuilder.Append("</Code>");
					myStringBuilder.Append("<Name>");
					myStringBuilder.Append(DS.Tables[0].Rows[i]["CNName"].ToString());
					myStringBuilder.Append("</Name>");
					myStringBuilder.Append("</Vendor>");
				}
				myStringBuilder.Append("</VendorList>");
				*/
				myStringBuilder.Append("<SELECT id=\"VendorList\">" );
				for (int i = 0; i<DS.Tables[0].Rows.Count; i++)
				{
					myStringBuilder.Append("<option value=\""+DS.Tables[0].Rows[i]["Code"].ToString()+"\">"+DS.Tables[0].Rows[i]["CNName"].ToString()+"</option>");
				}
				myStringBuilder.Append("</SELECT>");
				this.Response.ContentType = "text/html";
				this.Response.ContentEncoding = Encoding.UTF8;
				this.Response.Write(myStringBuilder.ToString());
			}
		}
	}
}
