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
	/// CorrespondingABCYearCompare ��ժҪ˵����
	/// </summary>
	public partial class CorrespondingABCYearCompare : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		#region ���� 
		/// <summary>
		/// ���� 0����棬1�����ϣ�2�����ϡ�
		/// </summary>
		protected int Type
		{
			get {return int.Parse(this.Request["Type"].ToString());}
		}
		/// <summary>
		/// ��ʼ��ݡ�
		/// </summary>
		public int StartYear
		{
			get  {return (DateTime.Now.Year - 2)>2004?DateTime.Now.Year -2:2005;}
		}
		/// <summary>
		/// ������ݡ�
		/// </summary>
		public int EndYear
		{
			get {return DateTime.Now.Year;}
		}
		#endregion
		#region ˽�з�����
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
				this.Chart1.Titles[0].Text = "ABC���������ȱȽ�";
			}
			else if (this.Type == 1)
			{
				this.Chart1.Titles[0].Text = "ABC�������ϵ���ȱȽ�";
			}
			else if (this.Type == 2)
			{
				this.Chart1.Titles[0].Text = "ABC���෢�ϵ���ȱȽ�";
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
				//s.ToolTip = "��ݣ�#SER&#10��� #VALX &#10 ��#VAL(��Ԫ)";
				s.LegendText =s.Name+"��";
				
				s.MapAreaAttributes= "Target=_Black";
				//s.Href = String.Format("CorrespondingABCMonthCompare.aspx?Type={0}&ABC=#VALX&StartYear={1}&EndYear={2}&StartMonth={3}&EndMonth={4}",this.Type,this.StartYear,this.EndYear,1,12);
				this.Chart1.Series.Add(s);
			}
			this.Chart1.DataBind();
			foreach(Series s in this.Chart1.Series)
			{
				for (int i=0;i<DS.Tables[0].Rows.Count;i++)
				{
					s.Points[i].ToolTip=String.Format("��ݣ�#SER&#10��� {0} &#10 ��#VAL(��Ԫ)",DS.Tables[0].Rows[i]["ABC"].ToString());
					s.Points[i].Href = String.Format("CorrespondingABCMonthCompare.aspx?Type={0}&ABC={1}&StartYear={2}&EndYear={3}&StartMonth={4}&EndMonth={5}",this.Type,DS.Tables[0].Rows[i]["ABC"].ToString(),this.StartYear,this.EndYear,1,12);
				}
			}
			
		}
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!this.IsPostBack)
			{
				this.ChartDataBind();
			}
		}
	}
}
