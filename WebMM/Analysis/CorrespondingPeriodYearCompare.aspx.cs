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
	/// CurrentROS ��ժҪ˵����
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
		#region ˽�з���
		private void ChartDataBind()
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@StartYear", this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			
			if (this.Flag == 0)//���Ƚϡ�
			{
				this.Chart1.Titles[0].Text = "���ͬ�ڱȽ�";
				DS = DA.ExecSPReturnDS("Analysis_YearCompareStock",oHT);
			}
			else if (this.Flag == 1)
			{
				this.Chart1.Titles[0].Text = "����ͬ�ڱȽ�";
				DS = DA.ExecSPReturnDS("Analysis_YearCompareIn",oHT);
			}
			else if (this.Flag == 2)
			{
				this.Chart1.Titles[0].Text = "����ͬ�ڱȽ�";
				DS = DA.ExecSPReturnDS("Analysis_YearCompareOut",oHT);
			}
			else if (this.Flag == 3)
			{
				this.Chart1.Titles[0].Text = "����;����ͬ�ڱȽ�";
				DS = DA.ExecSPReturnDS("Analysis_CorrespondingPeriodUseYearCompare",oHT);
			}
			if (this.Flag != 3)
			{
				int ColumnCount = DS.Tables[0].Columns.Count;
				this.Chart1.Series.Clear();	
				//�ֿ�����ȡǰ��λ
				DS.Tables[0].Columns.Add("SubStoName",typeof(System.String),"SUBSTRING(StoName,1,2)");
				//�����Ԫ���ֶΡ�
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
					this.Chart1.Series[SerieName].LegendText = SerieName+"��";
					this.Chart1.Series[SerieName].ToolTip = "  #VAL{C2}��Ԫ";
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
			else//��;���ϵ�ͬ�ڱȽϡ�
			{
				this.Chart1.Series.Clear();	
				this.Chart1.DataBindCrossTab(DS.Tables[0].DefaultView,"Year","TopClass","ItemMoney","",PointsSortOrder.Ascending);
				foreach (Series s in this.Chart1.Series)
				{
					s.Name = s.Name.Substring(s.Name.Length -4,4);
					s.LegendText = s.Name+"��";
					foreach(DataPoint p in s.Points)
					{
						p.Href = String.Format("USEMonthCompare.aspx?TopClass={0}&StartYear={1}&EndYear={2}&StartMonth={3}&EndMonth={4}",Server.UrlEncode(p.AxisLabel),this.StartYear,this.EndYear,1,12);
						p.MapAreaAttributes = "TARGET='_blank'";
						p.ToolTip = s.Name+"�꣺#VALX(#VAL{C2}��Ԫ)&#10�������쿴ÿ�µ�ͬ�ڱȽ�.";
					}
					
					
				}
			}
		}
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.ChartDataBind();
		}
		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
						Chart1.MapAreas.Add("&#10�������"+r["StoName"].ToString()+"ÿ��ͬ�ڱȽ�",// Tool tip text
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
					Chart1.MapAreas.Add("�������"+this.Chart1.Series[0].Points[j].AxisLabel+"��������ͬ�ڱȽ�",// Tool tip text
						String.Format(s,Server.UrlEncode(this.Chart1.Series[0].Points[j].AxisLabel),this.StartYear>2004?this.StartYear:2005,this.EndYear),// no HREF
						"Target=\"_Blank\"",// link attribute (i.e.: Target="_Blank"
						rect);// the "hot" region for the link
				}
			}

		}
	}
}