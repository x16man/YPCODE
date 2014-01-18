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
	/// CorrespondingABCMonthCompare 的摘要说明。
	/// </summary>
	public partial class CorrespondingABCMonthCompare : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		#region 属性
		private DataSet DS;
		
	
		public string ABC
		{
			get {return this.Request["ABC"].ToString();}
		
		}
		public int Type
		{
			get {return int.Parse(this.Request["Type"].ToString());}
		}
		public int StartYear
		{
			get {return int.Parse(this.ddlStartYear.SelectedValue);}
			set {this.ddlStartYear.SelectedValue = value.ToString();}
		}
		public int EndYear
		{
			get {return int.Parse(this.ddlEndYear.SelectedValue);}
			set {this.ddlEndYear.SelectedValue = value.ToString();}
		}
		public int StartMonth
		{
			get {return int.Parse(this.ddlStartMonth.SelectedValue);}
			set {this.ddlStartMonth.SelectedValue = value.ToString();}	
		}
		public int EndMonth
		{
			get {return int.Parse(this.ddlEndMonth.SelectedValue);}
			set {this.ddlEndMonth.SelectedValue = value.ToString();}	
		}
		#endregion
		#region 私有方法
		private void ChartDataBind()
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Type", this.Type);
			oHT.Add("@ABC",this.ABC);
			oHT.Add("@StartYear",this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			oHT.Add("@StartMonth", this.StartMonth);
			oHT.Add("@EndMonth", this.EndMonth);
			DS = DA.ExecSPReturnDS("Analysis_ABCMonthCompare",oHT);
			if (this.Type == 0)//库存
			{
				this.Chart1.Titles[0].Text = this.ABC+"类库存的每月比较";
			}
			else if (this.Type == 1)//收料
			{
				this.Chart1.Titles[0].Text = this.ABC+"类收料的每月比较";
			}
			else if (this.Type == 2)//发料
			{
				this.Chart1.Titles[0].Text = this.ABC + "类发料的每月比较";
			}
			Series s;
			this.Chart1.Series.Clear();
			this.Chart1.DataSource = this.DS.Tables[0].DefaultView;
			for (int i=2;i<this.DS.Tables[0].Columns.Count;i++)
			{
				s = new Series(this.DS.Tables[0].Columns[i].ColumnName.Substring(1,4));
				s.ValueMemberX = "Month";
				s.ValueMembersY = this.DS.Tables[0].Columns[i].ColumnName;
				s.MapAreaAttributes= "Target=_Black";
				s.ToolTip = "#VAL{C2}";
				this.Chart1.Series.Add(s);
			}
			this.Chart1.DataBind();
		}
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!this.IsPostBack)
			{
				//this.Type = int.Parse(this.Request["Type"].ToString());
				//this.ABC = this.Request["ABC"].ToString();
				this.StartYear = int.Parse(this.Request["StartYear"].ToString());
				this.EndYear = int.Parse(this.Request["EndYear"].ToString());
				this.StartMonth = int.Parse(this.Request["StartMonth"].ToString());
				this.EndMonth = int.Parse(this.Request["EndMonth"].ToString());
				this.ChartDataBind();
			}
		}

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.ChartDataBind();
        }

 

	

     
	}
}
