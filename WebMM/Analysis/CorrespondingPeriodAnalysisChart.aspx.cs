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
using Infragistics.WebUI.UltraWebGrid;
using MZHCommon.Database;
using Dundas.Charting.WebControl;
namespace WebMM.Analysis
{
	/// <summary>
	/// CorrespondingPeriodAnalysisChart 的摘要说明。
	/// </summary>
	public class CorrespondingPeriodAnalysisChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected Dundas.Charting.WebControl.Chart Chart1;
		protected Infragistics.WebUI.UltraWebGrid.UltraWebGrid UltraWebGrid1;
		#region 属性
		public int StartYear
		{
			get { return int.Parse(this.Request["StartYear"]);}
		}
		public int EndYear
		{
			get { return int.Parse(this.Request["EndYear"]);}
		}
		public int StartMonth
		{
			get { return int.Parse(this.Request["StartMonth"]);}
		}
		public int EndMonth
		{
			get { return int.Parse(this.Request["EndMonth"]);}
		}
		public int SpecificItem
		{
			get { return int.Parse(this.Request["SpecificItem"]);}
		}
		public int CompareType
		{
			get { return int.Parse(this.Request["CompareType"]);}
		}
		public int Pivot
		{
			get { return int.Parse(this.Request["Pivot"]);}
		}
		public string Code
		{
			get { return this.Request["Code"];}
		}
		public new  string Title
		{
			get 
			{
				return this.Request["Title"]+"同期"+(this.CompareType==0?"存货":"收发")+"比较";
			}
		}
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.Chart1.Titles[0].Text = this.Title;
			this.Chart1.ImageType = ChartImageType.Png;
			this.UltraWebGrid1.DataBind();
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.UltraWebGrid1.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UltraWebGrid1_InitializeLayout);
			this.UltraWebGrid1.DataBinding += new System.EventHandler(this.UltraWebGrid1_DataBinding);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			
			e.Layout.ViewType = ViewType.Flat;
			e.Layout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;

			e.Layout.Bands[0].Columns.FromKey("Code").Header.Caption = "代码";
			e.Layout.Bands[0].Columns.FromKey("Code").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Columns.FromKey("Code").Width = new Unit("50px");
			this.UltraWebGrid1.Columns.FromKey("Code").MergeCells = true;
			e.Layout.Bands[0].Columns.FromKey("Name").Header.Caption = "名称";
			e.Layout.Bands[0].Columns.FromKey("Name").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Columns.FromKey("Name").Width = new Unit("120px");
			this.UltraWebGrid1.Columns.FromKey("Name").MergeCells = true;
			e.Layout.Bands[0].Columns.FromKey("YM").Header.Caption="月份";
			e.Layout.Bands[0].Columns.FromKey("YM").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Columns.FromKey("YM").Width = new Unit("60px");

			int Index = 3;
			string inFieldName,outFieldName,endFieldName;
			if (this.CompareType ==0)//存货
			{
				for(int i = this.StartYear;i<=this.EndYear;i++)
				{
					endFieldName = "c"+i.ToString()+"_EndMoney";
					if (e.Layout.Bands[0].Columns.Exists(endFieldName))
					{
						e.Layout.Bands[0].Columns.FromKey(endFieldName).Header.Caption= i.ToString()+"年";
						e.Layout.Bands[0].Columns.FromKey(endFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
						e.Layout.Bands[0].Columns.FromKey(endFieldName).Width = new Unit("100px");
					}
				}
			}
			else				//收发
			{
				foreach(UltraGridColumn c in e.Layout.Bands[0].Columns)
				{
					c.Header.RowLayoutColumnInfo.OriginY = 1;
				}

				ColumnHeader ch;
				//代码列合并两行
				ch = e.Layout.Bands[0].Columns.FromKey("Code").Header;
				ch.RowLayoutColumnInfo.OriginY = 0;
				ch.RowLayoutColumnInfo.SpanY = 2;
				//名称列合并两行
				ch = e.Layout.Bands[0].Columns.FromKey("Name").Header;
				ch.RowLayoutColumnInfo.OriginY = 0;
				ch.RowLayoutColumnInfo.SpanY = 2;
				//月份列合并两行
				ch = e.Layout.Bands[0].Columns.FromKey("YM").Header;
				ch.RowLayoutColumnInfo.OriginY = 0;
				ch.RowLayoutColumnInfo.SpanY = 2;

				for(int i = this.StartYear;i<=this.EndYear;i++)
				{
					inFieldName = "c"+i.ToString()+"_InMoney";
					outFieldName = "c"+i.ToString()+"_OutMoney";
					if (this.UltraWebGrid1.Columns.Exists(inFieldName))
					{
						e.Layout.Bands[0].Columns.FromKey(inFieldName).Header.Caption = "收料";
						e.Layout.Bands[0].Columns.FromKey(inFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
						e.Layout.Bands[0].Columns.FromKey(inFieldName).Width = new Unit("100px");
						e.Layout.Bands[0].Columns.FromKey(outFieldName).Header.Caption = "发料";
						e.Layout.Bands[0].Columns.FromKey(outFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
						e.Layout.Bands[0].Columns.FromKey(outFieldName).Width = new Unit("100px");
						
						ch = new ColumnHeader(true);
						ch.Caption = i.ToString()+"年";
						ch.RowLayoutColumnInfo.SpanX = 2;
						ch.RowLayoutColumnInfo.OriginY = 0;
						ch.RowLayoutColumnInfo.OriginX = Index;
						Index += 2;				
						e.Layout.Bands[0].HeaderLayout.Add(ch);
					}

				}
			}
			
		}

		private void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			DataSet DS;

			oHT.Add("@StartYear", this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			oHT.Add("@StartMonth", this.StartMonth);
			oHT.Add("@EndMonth", this.EndMonth);
			oHT.Add("@SpecificItem",this.SpecificItem);
			oHT.Add("@Code", this.Code);
			
			if (this.CompareType == 0)
				DS = oSQLServer.ExecSPReturnDS("Analysis_CorrespondingPeriodCompareStockBySpecificItem", oHT);
			else
				DS = oSQLServer.ExecSPReturnDS("Analysis_CorrespondingPeriodCompareIOBySpecificItem", oHT);

			this.UltraWebGrid1.DataSource = DS;
			
			this.Chart1.Series.Clear();
			string inFieldName,outFieldName,endFieldName;

			this.Chart1.DataSource = DS;
			for (int i=this.StartYear; i<=this.EndYear; i++)
			{
				inFieldName = "c"+i.ToString()+"_InMoney";
				outFieldName = "c"+i.ToString()+"_OutMoney";
				endFieldName = "c"+i.ToString()+"_EndMoney";

				if (this.CompareType ==0)
				{
					//if (this.UltraWebGrid1.Columns.Exists(endFieldName))
					if (DS.Tables[0].Columns.Contains(endFieldName)	)
					{
						this.Chart1.Series.Add(endFieldName);
						this.Chart1.Series[endFieldName].LegendText = i.ToString()+"年存货";
						this.Chart1.Series[endFieldName].ValueMemberX = "YM";
						this.Chart1.Series[endFieldName].ValueMembersY = endFieldName; 
						this.Chart1.Series[endFieldName].ToolTip = "#VAL";
					}
				}
				else
				{
					if (DS.Tables[0].Columns.Contains(inFieldName))
					{
						this.Chart1.Series.Add(inFieldName);
						this.Chart1.Series[inFieldName].LegendText = i.ToString()+"年收料";
						this.Chart1.Series[inFieldName].ValueMemberX = "YM";
						this.Chart1.Series[inFieldName].ValueMembersY = inFieldName;
						this.Chart1.Series[inFieldName].ToolTip = "#VAL";

						this.Chart1.Series.Add(outFieldName);
						this.Chart1.Series[outFieldName].LegendText = i.ToString()+"年发料";
						this.Chart1.Series[outFieldName].ValueMemberX = "YM";
						this.Chart1.Series[outFieldName].ValueMembersY = outFieldName;
						this.Chart1.Series[inFieldName].ToolTip = "#VAL";
					}
				}
			}
			this.Chart1.DataBind();
		}
	}
}
