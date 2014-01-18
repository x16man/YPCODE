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
	/// CurrentROS ��ժҪ˵����
	/// </summary>
	public partial class CurrentROS : System.Web.UI.Page
	{
		public int ResultCode
		{
			get 
			{
				if (this.Request["ResultCode"] != null && this.Request["ResultCode"].ToString() != "")
				{
					return int.Parse(this.Request["ResultCode"].ToString());
				}
				else
				{
					return 100;
				}
			}
		}
		public DateTime StartDate
		{
			get 
			{
				return new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
			}
		}
		public DateTime EndDate
		{
			get 
			{
				return this.StartDate.AddMonths(1);
			}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			CurrentROSData oData;
			ItemSystem oIS = new ItemSystem();
			if (this.ResultCode == 100)
			{
				oData = oIS.Get_CurrentROS(DateTime.Now.Year, DateTime.Now.Month);
			}
			else
			{
				oData = oIS.Get_CurrentROS(ResultCode,DateTime.Now.Year, DateTime.Now.Month);
			}
			this.Chart1.DataSource = oData.Tables[CurrentROSData.ROS_Table];

			this.Chart1.Series["Default"].ValueMemberX = CurrentROSData.Result_Field;
			this.Chart1.Series["Default"].XValueType = ChartValueTypes.String;
			this.Chart1.Series["Default"].ValueMembersY = CurrentROSData.Count_Field;
			this.Chart1.Series["Default"].YValueType = ChartValueTypes.Int;

			this.Chart1.DataBind();

			this.Chart1.ImageType = ChartImageType.Png;
			this.Chart1.Legends["Default"].LegendStyle = LegendStyle.Column;
			this.Chart1.Legends["Default"].Docking = LegendDocking.Bottom;
			this.Chart1.Legends["Default"].Alignment = StringAlignment.Near;
			this.Chart1.Titles[0].Href = "ROSAnalysis.aspx";
			this.Chart1.Titles[0].MapAreaAttributes = "TARGET='_blank'";
//			this.Chart1.Series["Default"].Label = "#VALX: #VAL ��";
//			this.Chart1.Series["Default"].LegendText = "#VALX: #VAL ��: #PERCENT ";
//			this.Chart1.Series["Default"].ToolTip = "#VALX: #VAL ��: #PERCENT";
//			this.Chart1.Series["Default"].LegendToolTip = "#VALX: #VAL ��: #PERCENT";

			for (int i=0;i < oData.Count; i++)
			{
				if (ResultCode != 100)
				{
					this.Chart1.Series["Default"].Points[i].Href = "CurrentROSDetail.aspx?ResultCode=" + oData.ResultCode[i].ToString()
						                                                               +"&Result=" + Server.UrlEncode(oData.Result[i].ToString())
						                                                               +"&StartDate="+this.StartDate.ToShortDateString()
						                                                               +"&EndDate="+this.EndDate.ToShortDateString();
					this.Chart1.Series["Default"].Points[i].LegendHref = "CurrentROSDetail.aspx?ResultCode=" + oData.ResultCode[i].ToString()
																								+"&Result=" + Server.UrlEncode(oData.Result[i].ToString())
																								+"&StartDate="+this.StartDate.ToShortDateString()
																								+"&EndDate="+this.EndDate.ToShortDateString();

					//this.Chart1.Series["Default"].Points[i].Href = "ROSDetails.aspx?Flag="+oData.ResultCode[i].ToString()+"&Result="+Server.UrlEncode(oData.Result[i].ToString());
					//this.Chart1.Series["Default"].Points[i].LegendHref = "ROSDetails.aspx?Flag="+oData.ResultCode[i].ToString()+"&Result="+Server.UrlEncode(oData.Result[i].ToString());					
					//this.Chart1.Series["Default"].Points[i].Href = "../Purchase/ROSBrowser.aspx";
					//this.Chart1.Series["Default"].Points[i].LegendHref = "../Purchase/ROSBrowser.aspx";
					this.Chart1.Series["Default"].Points[i].MapAreaAttributes = "TARGET='_blank'";
					this.Chart1.Series["Default"].Points[i].LegendMapAreaAttributes = "TARGET='_blank'";
					this.Chart1.Series["Default"].Points[i].Label = oData.Result[i]+":"+oData.DocCount[i].ToString()+"��";
					this.Chart1.Series["Default"].Points[i].ToolTip = oData.Result[i]+":"+oData.DocCount[i].ToString()+"��,"+oData.SubTotal[i].ToString()+"Ԫ";
					this.Chart1.Series["Default"].Points[i].LegendText = oData.Result[i]+":"+oData.DocCount[i].ToString()+"��,"+oData.SubTotal[i].ToString()+"Ԫ";
					this.Chart1.Series["Default"].Points[i].LegendToolTip = oData.Result[i]+":"+oData.DocCount[i].ToString()+"��,"+oData.SubTotal[i].ToString()+"Ԫ";
				}
				else
				{

					//this.Chart1.Series["Default"].Points[i].Label = "abcdde";
					this.Chart1.Series["Default"].Points[i].Label = oData.Result[i].ToString() + ":" + oData.DocCount[i].ToString()+"��";
					this.Chart1.Series["Default"].Points[i].ToolTip = oData.Result[i]+":"+oData.DocCount[i].ToString()+"��,"+oData.SubTotal[i].ToString()+"Ԫ";
					this.Chart1.Series["Default"].Points[i].LegendText = oData.Result[i]+":"+oData.DocCount[i].ToString()+"��,"+oData.SubTotal[i].ToString()+"Ԫ";
					this.Chart1.Series["Default"].Points[i].LegendToolTip = oData.Result[i]+":"+oData.DocCount[i].ToString()+"��,"+oData.SubTotal[i].ToString()+"Ԫ";
					
					this.Chart1.Series["Default"].Points[i].Href = "CurrentROS.aspx?ResultCode="+oData.ResultCode[i].ToString();
					this.Chart1.Series["Default"].Points[i].LegendHref = "CurrentROS.aspx?ResultCode="+oData.ResultCode[i].ToString();
				}
				this.Chart1.Series["Default"].Points[i].CustomAttributes += "Exploded=true";
			}
		}
	}
}