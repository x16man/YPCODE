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
	/// CurrentStock 的摘要说明。
	/// </summary>
	public partial class CurrentStock : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ItemSystem oIS = new ItemSystem();

			CurrentABCStockData oABCStockData ;

			oABCStockData = oIS.Get_CurrentABCStock();

			this.Chart_CurrentStock.DataSource = oABCStockData.Tables[CurrentABCStockData.ABC_Table];
			this.Chart_CurrentStock.Series["Default"].ValueMemberX = CurrentABCStockData.ABC_Field;
			this.Chart_CurrentStock.Series["Default"].XValueType = ChartValueTypes.String;
			this.Chart_CurrentStock.Series["Default"].ValueMembersY = CurrentABCStockData.ItemMoney_Field;
			this.Chart_CurrentStock.Series["Default"].YValueType = ChartValueTypes.Double;

			this.Chart_CurrentStock.DataBind();
//			string[]    xValues;
//			double[]    yValues;
//
//			xValues =	new string[oABCStockData.Count];
//			yValues =   new double[oABCStockData.Count];
//
//			for (int i=0; i< oABCStockData.Count; i++)
//			{
//				xValues[i] = oABCStockData.Tables[CurrentABCStockData.ABC_Table].Rows[i][CurrentABCStockData.ABC_Field].ToString();
//				yValues[i] = Convert.ToDouble(oABCStockData.Tables[CurrentABCStockData.ABC_Table].Rows[i][CurrentABCStockData.ItemMoney_Field].ToString());
//			}
//			this.Chart_CurrentStock.Series["Default"].Points.DataBindXY(xValues, yValues);

			
			this.Chart_CurrentStock.ImageType = ChartImageType.Png;
			this.Chart_CurrentStock.Legends["Default"].LegendStyle = LegendStyle.Column;
			this.Chart_CurrentStock.Legends["Default"].Docking = LegendDocking.Bottom;
			this.Chart_CurrentStock.Legends["Default"].Alignment = StringAlignment.Near;

			this.Chart_CurrentStock.Series["Default"].Label = "#VALX: #PERCENT";
			this.Chart_CurrentStock.Series["Default"].LegendText = "#VALX: #VAL{C} 元: #PERCENT ";
			this.Chart_CurrentStock.Series["Default"].ToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			this.Chart_CurrentStock.Series["Default"].LegendToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			this.Chart_CurrentStock.Titles[0].Href = "StockAnalysis.aspx";
			this.Chart_CurrentStock.Titles[0].MapAreaAttributes = "TARGET='_blank'";
			for (int i=0;i < oABCStockData.Count; i++)
			{
				//this.Chart_CurrentStock.Series["Default"].Points[i].Href = "StockDetail.aspx?ABC="+oABCStockData.Tables[CurrentABCStockData.ABC_Table].Rows[i][CurrentABCStockData.ABC_Field].ToString().Substring(0,1);
				this.Chart_CurrentStock.Series["Default"].Points[i].Href = "StockAnalysis.aspx?ABC="+oABCStockData.Tables[CurrentABCStockData.ABC_Table].Rows[i][CurrentABCStockData.ABC_Field].ToString().Substring(0,1);
				this.Chart_CurrentStock.Series["Default"].Points[i].MapAreaAttributes = "TARGET='_blank'";
				//this.Chart_CurrentStock.Series["Default"].Points[i].LegendHref = "StockDetail.aspx?ABC="+oABCStockData.Tables[CurrentABCStockData.ABC_Table].Rows[i][CurrentABCStockData.ABC_Field].ToString().Substring(0,1);
				this.Chart_CurrentStock.Series["Default"].Points[i].LegendHref = "StockAnalysis.aspx?ABC="+oABCStockData.Tables[CurrentABCStockData.ABC_Table].Rows[i][CurrentABCStockData.ABC_Field].ToString().Substring(0,1);
				this.Chart_CurrentStock.Series["Default"].Points[i].LegendMapAreaAttributes = "TARGET='_blank'";
				this.Chart_CurrentStock.Series["Default"].Points[i].CustomAttributes += "Exploded=true";
			}
		}
	}
}
