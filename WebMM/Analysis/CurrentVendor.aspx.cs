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

using Dundas.Charting.WebControl;

namespace WebMM.Analysis
{
	/// <summary>
	/// CurrentVendor 的摘要说明。
	/// </summary>
	public partial class CurrentVendor : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ItemSystem oIS = new ItemSystem();

			CurrentVendorINData oCurrentVendorData ;

			oCurrentVendorData = oIS.Get_CurrentVendorIN(DateTime.Now.Year, DateTime.Now.Month);

			string[]    xValues;
			string[]    PrvCodeValues;
			double[]    yValues;

			xValues =	new string[oCurrentVendorData.Count];
			PrvCodeValues = new string[oCurrentVendorData.Count];
			yValues =   new double[oCurrentVendorData.Count];

			for (int i=0; i< oCurrentVendorData.Count; i++)
			{
				xValues[i] = oCurrentVendorData.Tables[CurrentVendorINData.CurrentVendorIN_Table].Rows[i][CurrentVendorINData.PrvName_Field].ToString();
				PrvCodeValues[i] = oCurrentVendorData.Tables[CurrentVendorINData.CurrentVendorIN_Table].Rows[i][CurrentVendorINData.PrvCode_Field].ToString();
				yValues[i] = Convert.ToDouble(oCurrentVendorData.Tables[CurrentVendorINData.CurrentVendorIN_Table].Rows[i][CurrentVendorINData.ItemMoney_Field].ToString());
			}
			this.Chart_CurrentVendor.Series["Default"].Points.DataBindXY(xValues, yValues);

			this.Chart_CurrentVendor.ImageType = ChartImageType.Png;
			this.Chart_CurrentVendor.Legends["Default"].LegendStyle = LegendStyle.Column;
			this.Chart_CurrentVendor.Legends["Default"].Docking = LegendDocking.Bottom;
			this.Chart_CurrentVendor.Legends["Default"].Alignment = StringAlignment.Near;
			this.Chart_CurrentVendor.Legends["Default"].InsideChartArea = "";
			this.Chart_CurrentVendor.Series["Default"].Label = "#PERCENT";
			
			this.Chart_CurrentVendor.Series["Default"].LegendText = "#VALX: #VAL{C} 元: #PERCENT";
			this.Chart_CurrentVendor.Series["Default"].ToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			this.Chart_CurrentVendor.Series["Default"].LegendToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			
			this.Chart_CurrentVendor.Series["Default"]["PieLineColor"] = "64,64,64";
			this.Chart_CurrentVendor.Series["Default"].CustomAttributes = "LabelStyle=Outside";
			this.Chart_CurrentVendor.Titles[0].Href="VendorAnalysis.aspx";
			this.Chart_CurrentVendor.Titles[0].MapAreaAttributes =	"TARGET='_blank'";
			for (int i=0;i < PrvCodeValues.Length; i++)
			{
				if (PrvCodeValues[i] == "-1")
				{
					this.Chart_CurrentVendor.Series["Default"].Points[i].Href = "VendorAnalysis.aspx";
					this.Chart_CurrentVendor.Series["Default"].Points[i].MapAreaAttributes = "TARGET='_blank'";
					this.Chart_CurrentVendor.Series["Default"].Points[i].LegendHref = "VendorAnalysis.aspx";
					this.Chart_CurrentVendor.Series["Default"].Points[i].LegendMapAreaAttributes  = "TARGET='_blank'";
					this.Chart_CurrentVendor.Series["Default"].Points[i].CustomAttributes += "Exploded=true";
				}
				else
				{
					this.Chart_CurrentVendor.Series["Default"].Points[i].Href = "VendorInDetail.aspx?PrvCode="+PrvCodeValues[i]+"&PrvName="+Server.UrlEncode(xValues[i]);
					this.Chart_CurrentVendor.Series["Default"].Points[i].MapAreaAttributes = "TARGET='_blank'";
					this.Chart_CurrentVendor.Series["Default"].Points[i].LegendHref = "VendorInDetail.aspx?PrvCode="+PrvCodeValues[i]+"&PrvName="+Server.UrlEncode(xValues[i]);
					this.Chart_CurrentVendor.Series["Default"].Points[i].LegendMapAreaAttributes  = "TARGET='_blank'";
					this.Chart_CurrentVendor.Series["Default"].Points[i].CustomAttributes += "Exploded=true";
				}
        	}
			
		}
	}
}
