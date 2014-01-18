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

namespace MZHMM.WebMM.Analysis
{
	/// <summary>
	/// CorrespondingPeriodAnalysis 的摘要说明。
	/// </summary>
	public class CorrespondingPeriodAnalysis : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected Infragistics.WebUI.Misc.WebPanel WebPanel1;
		protected Infragistics.WebUI.UltraWebGrid.UltraWebGrid UltraWebGrid1;
	
		#region 属性
		public int StartYear
		{
			//get { return int.Parse(this.ddlStartYear.SelectedValue);}
			get { return int.Parse(((DropDownList)this.WebPanel1.FindControl("ddlStartYear")).SelectedValue);}
		}
		public int EndYear
		{
			//get {return int.Parse(this.ddlEndYear.SelectedValue);}
			get { return int.Parse(((DropDownList)this.WebPanel1.FindControl("ddlEndYear")).SelectedValue);}
		}
		public int StartMonth
		{
			//get {return int.Parse(this.ddlStartMonth.SelectedValue);}
			get { return int.Parse(((DropDownList)this.WebPanel1.FindControl("ddlStartMonth")).SelectedValue);}
		}
		public int EndMonth
		{
			//get {return int.Parse(this.ddlEndMonth.SelectedValue);}
			get { return int.Parse(((DropDownList)this.WebPanel1.FindControl("ddlEndMonth")).SelectedValue);}
		}
		public int SpecificItem
		{
			//get {return int.Parse(this.ddlSpecificItem.SelectedValue);}
			get { return int.Parse(((DropDownList)this.WebPanel1.FindControl("ddlSpecificItem")).SelectedValue);}
		}	 
		public int Pivot
		{
			//get {return int.Parse(this.ddlPivot.SelectedValue);}
			get { return int.Parse(((DropDownList)this.WebPanel1.FindControl("ddlPivot")).SelectedValue);}
		}
		public int CompareType
		{
			//get {return int.Parse(this.ddlCompareType.SelectedValue);}
			get { return int.Parse(((DropDownList)this.WebPanel1.FindControl("ddlCompareType")).SelectedValue);}
		}
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.UltraWebGrid1.DataBind();
			}
			
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
			this.UltraWebGrid1.InitializeRow += new Infragistics.WebUI.UltraWebGrid.InitializeRowEventHandler(this.UltraWebGrid1_InitializeRow);
			this.UltraWebGrid1.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UltraWebGrid1_InitializeLayout);
			this.UltraWebGrid1.DataBinding += new System.EventHandler(this.UltraWebGrid1_DataBinding);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.UltraWebGrid1.Columns.Clear();
			this.UltraWebGrid1.DisplayLayout.Bands[0].HeaderLayout.Clear();
			this.UltraWebGrid1.DataBind();
		}

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			e.Layout.ViewType = ViewType.Flat;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Columns.FromKey("Code").Header.Caption = "代码";
			this.UltraWebGrid1.Columns.FromKey("Code").Width= new Unit("50px");
			this.UltraWebGrid1.Columns.FromKey("Code").MergeCells= true;
			this.UltraWebGrid1.Columns.FromKey("Code").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Columns.FromKey("Name").Header.Caption = "名称";
			this.UltraWebGrid1.Columns.FromKey("Name").Width = new Unit("100px");
			this.UltraWebGrid1.Columns.FromKey("Name").MergeCells = true;
			this.UltraWebGrid1.Columns.FromKey("YM").Header.Caption = this.Pivot == 0?"月份":"年份";
			this.UltraWebGrid1.Columns.FromKey("YM").Width = new Unit("60px");
			this.UltraWebGrid1.Columns.FromKey("YM").CellStyle.HorizontalAlign = HorizontalAlign.Center;

			foreach(UltraGridColumn c in e.Layout.Bands[0].Columns)
			{
				c.Header.RowLayoutColumnInfo.OriginY = 1;
			}
			
			ColumnHeader ch = e.Layout.Bands[0].Columns.FromKey("Code").Header;
			ch.RowLayoutColumnInfo.SpanY=2;
			ch.RowLayoutColumnInfo.OriginY = 0;
			
			ch = e.Layout.Bands[0].Columns.FromKey("Name").Header;
			ch.RowLayoutColumnInfo.SpanY = 2;
			ch.RowLayoutColumnInfo.OriginY = 0;
			
			ch = e.Layout.Bands[0].Columns.FromKey("YM").Header;
			ch.RowLayoutColumnInfo.SpanY = 2;
			ch.RowLayoutColumnInfo.OriginY = 0;

			int Index = 3;
			if (this.Pivot==0)   //年份旋转
			{
				for (int i=this.StartYear;i<=this.EndYear;i++)
				{
					string inFieldName,outFieldName,endFieldName;
					inFieldName = "c"+i.ToString()+"_InMoney";
					outFieldName = "c"+i.ToString()+"_OutMoney";
					endFieldName = "c"+i.ToString()+"_EndMoney";

					if (this.CompareType == 1)//收发
					{
						if (this.UltraWebGrid1.Columns.Exists(inFieldName))
						{
						
							this.UltraWebGrid1.Columns.FromKey(inFieldName).Header.Caption="收料";
							this.UltraWebGrid1.Columns.FromKey(inFieldName).Width = new Unit("70px");
							this.UltraWebGrid1.Columns.FromKey(inFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
							this.UltraWebGrid1.Columns.FromKey(outFieldName).Header.Caption="发料";
							this.UltraWebGrid1.Columns.FromKey(outFieldName).Width = new Unit("70px");
							this.UltraWebGrid1.Columns.FromKey(outFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
					
							ch = new ColumnHeader(true);
							ch.Caption = i.ToString()+"年";
							ch.RowLayoutColumnInfo.SpanX = 2;
							ch.RowLayoutColumnInfo.OriginY = 0;
							ch.RowLayoutColumnInfo.OriginX = Index;
							Index += 2;				
							e.Layout.Bands[0].HeaderLayout.Add(ch);
						}
					}
					else//存货
					{
						if (this.UltraWebGrid1.Columns.Exists(endFieldName))
						{
							this.UltraWebGrid1.Columns.FromKey(endFieldName).Header.Caption = i.ToString()+"年";
							this.UltraWebGrid1.Columns.FromKey(endFieldName).Width = new Unit("70px");
							this.UltraWebGrid1.Columns.FromKey(endFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
							this.UltraWebGrid1.Columns.FromKey(endFieldName).Header.RowLayoutColumnInfo.OriginY = 0;
							this.UltraWebGrid1.Columns.FromKey(endFieldName).Header.RowLayoutColumnInfo.SpanY = 2;
						}
					}
				}
			}
			else //月份旋转
			{
				for (int i=this.StartMonth;i<=this.EndMonth;i++)
				{
					string inFieldName,outFieldName,endFieldName;
					inFieldName = "c"+i.ToString()+"_InMoney";
					outFieldName = "c"+i.ToString()+"_OutMoney";
					endFieldName = "c"+i.ToString()+"_EndMoney";

					if (this.CompareType ==0)//存货
					{
						if (this.UltraWebGrid1.Columns.Exists(endFieldName))
						{
							this.UltraWebGrid1.Columns.FromKey(endFieldName).Header.Caption = i.ToString()+"月";
							this.UltraWebGrid1.Columns.FromKey(endFieldName).Width = new Unit("70px");
							this.UltraWebGrid1.Columns.FromKey(endFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
							this.UltraWebGrid1.Columns.FromKey(endFieldName).Header.RowLayoutColumnInfo.OriginY = 0;
							this.UltraWebGrid1.Columns.FromKey(endFieldName).Header.RowLayoutColumnInfo.SpanY = 2;
						}
					}
					else
					{
						if (this.UltraWebGrid1.Columns.Exists(inFieldName))
						{
							this.UltraWebGrid1.Columns.FromKey(inFieldName).Header.Caption="收料";
							this.UltraWebGrid1.Columns.FromKey(inFieldName).Width = new Unit("70px");
							this.UltraWebGrid1.Columns.FromKey(inFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
							this.UltraWebGrid1.Columns.FromKey(outFieldName).Header.Caption="发料";
							this.UltraWebGrid1.Columns.FromKey(outFieldName).Width = new Unit("70px");
							this.UltraWebGrid1.Columns.FromKey(outFieldName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
					
							ch = new ColumnHeader(true);
							ch.Caption = i.ToString()+"月";
							ch.RowLayoutColumnInfo.SpanX = 2;
							ch.RowLayoutColumnInfo.OriginY = 0;
							ch.RowLayoutColumnInfo.OriginX = Index;
							Index += 2;				
							e.Layout.Bands[0].HeaderLayout.Add(ch);
						}
					}
				}
			}
		}

		private void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			SQLServer oSQLServer = new SQLServer();
			DataSet DS ;

			Hashtable oHT = new Hashtable();
			oHT.Add("@StartYear",this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			oHT.Add("@StartMonth",this.StartMonth);
			oHT.Add("@EndMonth", this.EndMonth);
			oHT.Add("@SpecificItem", this.SpecificItem);
			oHT.Add("@PivotFlag", this.Pivot);  

			if (this.CompareType == 0)//存货
			{
				DS = oSQLServer.ExecSPReturnDS("Analysis_CorrespondingPeriodCompareStock",oHT);
			}
			else//收发
			{
				DS = oSQLServer.ExecSPReturnDS("Analysis_CorrespondingPeriodCompareIO",oHT);
			}

			this.UltraWebGrid1.DataSource = DS;
		}

		private void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
			e.Row.Cells.FromKey("Name").TargetURL="@[_blank]CorrespondingPeriodAnalysisChart.aspx?StartYear="+this.StartYear.ToString()
				                                                                                    +"&EndYear="+this.EndYear.ToString()
																									+"&StartMonth="+this.StartMonth.ToString()
																									+"&EndMonth="+this.EndMonth.ToString()
																									+"&SpecificItem="+this.SpecificItem.ToString()
				                                                                                    +"&CompareType="+this.CompareType.ToString()
																									+"&Pivot="+this.Pivot.ToString()
																									+"&Code="+e.Row.Cells.FromKey("Code").Value.ToString()
																									+"&Title="+Server.UrlEncode(e.Row.Cells.FromKey("Name").Value.ToString());
		}
	}
}
