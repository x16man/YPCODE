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

namespace MZHMM.WebMM.Analysis
{
	/// <summary>
	/// CurrentWithDraw 的摘要说明。
	/// </summary>
	public partial class CurrentWithDraw : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ItemSystem oIS = new ItemSystem();

			CurrentMonth_WithdrawData oCWData ;

			oCWData = oIS.Get_CurrentMonth_Withdraw(DateTime.Now.Year, DateTime.Now.Month);

			double[]    yValues;
			string[]    xValues;

			xValues =	new string[oCWData.Tables[CurrentMonth_WithdrawData.CurrentMonth_Withdraw_Table].Rows.Count];
			yValues =   new double[oCWData.Tables[CurrentMonth_WithdrawData.CurrentMonth_Withdraw_Table].Rows.Count];

			for (int i=0; i< oCWData.Tables[CurrentMonth_WithdrawData.CurrentMonth_Withdraw_Table].Rows.Count; i++)
			{
				xValues[i] = oCWData.Tables[CurrentMonth_WithdrawData.CurrentMonth_Withdraw_Table].Rows[i][CurrentMonth_WithdrawData.Classify_Field].ToString();
				yValues[i] = Convert.ToDouble(oCWData.Tables[CurrentMonth_WithdrawData.CurrentMonth_Withdraw_Table].Rows[i][CurrentMonth_WithdrawData.ItemMoney_Field].ToString());
			}
			this.Chart1.ImageType = ChartImageType.Png;
			Chart1.Legends["Default"].LegendStyle = LegendStyle.Column;
			Chart1.Legends["Default"].Docking = LegendDocking.Bottom;
			Chart1.Legends["Default"].Alignment = StringAlignment.Center;
			Chart1.Legends["Default"].InsideChartArea = "";
			Chart1.Series["Default"].Label = "#VALX: #PERCENT";
			Chart1.Series["Default"].LegendText = "#VALX: #VAL{C} 元: #PERCENT";
			Chart1.Series["Default"].ToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			Chart1.Series["Default"].LegendToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			this.Chart1.Series["Default"]["PieLineColor"] = "64,64,64";
			Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
			this.Chart1.Titles[0].Href="WithDrawAnalysis.aspx";
			this.Chart1.Titles[0].MapAreaAttributes="TARGET='_blank'";
			for (int i=0;i < xValues.Length; i++)
			{
				this.Chart1.Series["Default"].Points[i].Href = "WithDrawAnalysis.aspx?Classify="+xValues[i].Substring(0,1);
				this.Chart1.Series["Default"].Points[i].MapAreaAttributes = "TARGET='_blank'";
				this.Chart1.Series["Default"].Points[i].LegendHref = "WithDrawAnalysis.aspx?Classify="+xValues[i].Substring(0,1);
				this.Chart1.Series["Default"].Points[i].LegendMapAreaAttributes = "TARGET='_blank'";
				this.Chart1.Series["Default"].Points[i].CustomAttributes += "Exploded=true";
			}
		}
	}
}
