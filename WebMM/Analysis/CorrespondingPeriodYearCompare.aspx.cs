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
using MZHCommon.Database;
namespace MZHMM.WebMM.Analysis
{
	/// <summary>
	/// CurrentROS 的摘要说明。
	/// </summary>
	public partial class CorrespondingPeriodYearCompare : System.Web.UI.Page
	{
		private DataSet DS;
		public int StartYear
		{
			get  {return DateTime.Now.Year - 2;}
		}
		public int EndYear
		{
			get {return DateTime.Now.Year;}
		}
		public int Flag
		{
			get {return int.Parse(this.Request["Flag"].ToString());}
		}
		#region 私有方法
		private void ChartDataBind()
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@StartYear", this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			
			if (this.Flag == 0)//库存比较。
			{
				this.Chart1.Titles[0].Text = "库存同期比较";
				DS = DA.ExecSPReturnDS("Analysis_YearCompareStock",oHT);
			}
			else if (this.Flag == 1)
			{
				this.Chart1.Titles[0].Text = "收料同期比较";
				DS = DA.ExecSPReturnDS("Analysis_YearCompareIn",oHT);
			}
			else if (this.Flag == 2)
			{
				this.Chart1.Titles[0].Text = "发料同期比较";
				DS = DA.ExecSPReturnDS("Analysis_YearCompareOut",oHT);
			}
			else if (this.Flag == 3)
			{
				this.Chart1.Titles[0].Text = "按用途发料同期比较";
				DS = DA.ExecSPReturnDS("Analysis_CorrespondingPeriodUseYearCompare",oHT);
			}
			if (this.Flag != 3)
			{
				int ColumnCount = DS.Tables[0].Columns.Count;
				this.Chart1.Series.Clear();	
				//仓库名称取前两位
				DS.Tables[0].Columns.Add("SubStoName",typeof(System.String),"SUBSTRING(StoName,1,2)");
				//添加万元的字段。
				for (int i=2;i<ColumnCount;i++)
				{
					DS.Tables[0].Columns.Add(DS.Tables[0].Columns[i].ColumnName+"Wan",typeof(System.Decimal),
						DS.Tables[0].Columns[i].ColumnName+"/10000");	
				}
				this.Chart1.DataSource=DS.Tables[0].DefaultView;
				string SerieName;
				for (int i=2;i<ColumnCount;i++)
				{
					SerieName = DS.Tables[0].Columns[i].ColumnName.Substring(1,4);
					this.Chart1.Series.Add(SerieName);
					this.Chart1.Series[SerieName].ValueMemberX = "SubStoName";
					this.Chart1.Series[SerieName].ValueMembersY = DS.Tables[0].Columns[i].ColumnName+"Wan";
					this.Chart1.Series[SerieName].LegendText = SerieName+"年";
					this.Chart1.Series[SerieName].ToolTip = "  #VAL{C2}万元";
				}
				this.Chart1.DataBind();
				for (int i=0;i<ColumnCount -2;i++)
				{
					for(int j=0;j<DS.Tables[0].Rows.Count;j++)
					{
						this.Chart1.Series[i].Points[j].ToolTip = DS.Tables[0].Rows[j]["SubStoName"].ToString() + this.Chart1.Series[i].Points[j].ToolTip;
					}
				}
			}
			else//用途领料的同期比较。
			{
				this.Chart1.Series.Clear();	
				this.Chart1.DataBindCrossTab(DS.Tables[0].DefaultView,"Year","TopClass","ItemMoney","",PointsSortOrder.Ascending);
				foreach (Series s in this.Chart1.Series)
				{
					s.Name = s.Name.Substring(s.Name.Length -4,4);
					s.LegendText = s.Name+"年";
					foreach(DataPoint p in s.Points)
					{
						p.Href = String.Format("USEMonthCompare.aspx?TopClass={0}&StartYear={1}&EndYear={2}&StartMonth={3}&EndMonth={4}",Server.UrlEncode(p.AxisLabel),this.StartYear,this.EndYear,1,12);
						p.MapAreaAttributes = "TARGET='_blank'";
						p.ToolTip = s.Name+"年：#VALX(#VAL{C2}万元)&#10点击进入察看每月的同期比较.";
					}
					
					
				}
			}
		}
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.ChartDataBind();
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
			this.Chart1.PrePaint += new Dundas.Charting.WebControl.PaintEventHandler(this.Chart1_PrePaint);

		}
		#endregion

		private void Chart1_PrePaint(object sender, Dundas.Charting.WebControl.ChartPaintEventArgs e)
		{
			if (this.Flag != 3)
			{
				for (int i =0;i<DS.Tables[0].Rows.Count;i++)
				{
					DataRow r = DS.Tables[0].Rows[i];
					// Retrieve size and position of individual labels
					RectangleF rect = new RectangleF(
						(float)Chart1.ChartAreas[0].AxisX.GetPosition( i + 0.5 ),
						(float)Chart1.ChartAreas[0].AxisY.GetPosition(0),
						(float)Chart1.ChartAreas[0].AxisX.GetPosition( i + 1.5 )
						-(float)Chart1.ChartAreas[0].AxisX.GetPosition( i + 0.5 ),
						7);
					
						// Use label's size and position information to define "hot" areas
						string s = "CorrespondingPeriodMonthCompare.aspx?StoCode={0}&StartYear={1}&EndYear={2}&StartMonth={3}&EndMonth={4}&Type={5}";
						Chart1.MapAreas.Add("&#10点击进入"+r["StoName"].ToString()+"每月同期比较",// Tool tip text
							String.Format(s,r["StoCode"].ToString(),this.StartYear>2004?this.StartYear:2005,this.EndYear,1,12,this.Flag),// no HREF
							"Target=\"_Blank\"",// link attribute (i.e.: Target="_Blank"
							rect);// the "hot" region for the link
				}
			}
			else
			{
				for (int j=0;j<this.Chart1.Series[0].Points.Count;j++)
				{
					// Retrieve size and position of individual labels
					RectangleF rect = new RectangleF(
						(float)Chart1.ChartAreas[0].AxisX.GetPosition( j + 0.5 ),
						(float)Chart1.ChartAreas[0].AxisY.GetPosition(0),
						(float)Chart1.ChartAreas[0].AxisX.GetPosition( j + 1.5 )
						-(float)Chart1.ChartAreas[0].AxisX.GetPosition( j + 0.5 ),
						7);

					// Use label's size and position information to define "hot" areas
					string s = "USECompare.aspx?TopClass={0}&StartYear={1}&EndYear={2}";
					Chart1.MapAreas.Add("点击进入"+this.Chart1.Series[0].Points[j].AxisLabel+"下子类别的同期比较",// Tool tip text
						String.Format(s,Server.UrlEncode(this.Chart1.Series[0].Points[j].AxisLabel),this.StartYear>2004?this.StartYear:2005,this.EndYear),// no HREF
						"Target=\"_Blank\"",// link attribute (i.e.: Target="_Blank"
						rect);// the "hot" region for the link
				}
			}

		}
	}
}