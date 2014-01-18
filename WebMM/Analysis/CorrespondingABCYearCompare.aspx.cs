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
using MZHCommon.Database;
using Dundas.Charting.WebControl;
namespace WebMM.Analysis
{
	/// <summary>
	/// CorrespondingABCYearCompare 的摘要说明。
	/// </summary>
	public partial class CorrespondingABCYearCompare : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		#region 属性 
		/// <summary>
		/// 类型 0：库存，1：收料，2：发料。
		/// </summary>
		protected int Type
		{
			get {return int.Parse(this.Request["Type"].ToString());}
		}
		/// <summary>
		/// 开始年份。
		/// </summary>
		public int StartYear
		{
			get  {return (DateTime.Now.Year - 2)>2004?DateTime.Now.Year -2:2005;}
		}
		/// <summary>
		/// 结束年份。
		/// </summary>
		public int EndYear
		{
			get {return DateTime.Now.Year;}
		}
		#endregion
		#region 私有方法。
		private void ChartDataBind()
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Type", this.Type);
			oHT.Add("@StartYear", this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			DataSet DS;
			DS = DA.ExecSPReturnDS("Analysis_ABCYearCompare",oHT);//CrossTab
			this.Chart1.Series.Clear();
			if (this.Type == 0)
			{
				this.Chart1.Titles[0].Text = "ABC分类库存的年度比较";
			}
			else if (this.Type == 1)
			{
				this.Chart1.Titles[0].Text = "ABC分类收料的年度比较";
			}
			else if (this.Type == 2)
			{
				this.Chart1.Titles[0].Text = "ABC分类发料的年度比较";
			}
			this.Chart1.DataSource = DS.Tables[0].DefaultView;
			
			int ColumnCount;
			ColumnCount  = DS.Tables[0].Columns.Count;
			for (int i=1;i<ColumnCount;i++)
			{
				DS.Tables[0].Columns.Add(DS.Tables[0].Columns[i].ColumnName+"Wan",typeof(System.Decimal),DS.Tables[0].Columns[i].ColumnName+"/10000");
			}
			for (int i=1;i<ColumnCount;i++)
			{
				Series s;
				s = new Series(DS.Tables[0].Columns[i].ColumnName.Substring(1,4));
				s.ValueMemberX = "ABC";
				s.ValueMembersY = DS.Tables[0].Columns[i].ColumnName+"Wan";
				//s.ToolTip = "年份：#SER&#10类别： #VALX &#10 金额：#VAL(万元)";
				s.LegendText =s.Name+"年";
				
				s.MapAreaAttributes= "Target=_Black";
				//s.Href = String.Format("CorrespondingABCMonthCompare.aspx?Type={0}&ABC=#VALX&StartYear={1}&EndYear={2}&StartMonth={3}&EndMonth={4}",this.Type,this.StartYear,this.EndYear,1,12);
				this.Chart1.Series.Add(s);
			}
			this.Chart1.DataBind();
			foreach(Series s in this.Chart1.Series)
			{
				for (int i=0;i<DS.Tables[0].Rows.Count;i++)
				{
					s.Points[i].ToolTip=String.Format("年份：#SER&#10类别： {0} &#10 金额：#VAL(万元)",DS.Tables[0].Rows[i]["ABC"].ToString());
					s.Points[i].Href = String.Format("CorrespondingABCMonthCompare.aspx?Type={0}&ABC={1}&StartYear={2}&EndYear={3}&StartMonth={4}&EndMonth={5}",this.Type,DS.Tables[0].Rows[i]["ABC"].ToString(),this.StartYear,this.EndYear,1,12);
				}
			}
			
		}
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!this.IsPostBack)
			{
				this.ChartDataBind();
			}
		}
	}
}
