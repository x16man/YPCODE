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
using Dundas.Charting.WebControl;
using MZHCommon.Database;
namespace WebMM.Analysis
{
	/// <summary>
	/// USECompare ��ժҪ˵����
	/// </summary>
	public partial class USEMonthCompare : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		#region ��Ա����
		private DataSet DS;
		#endregion

		#region ����
		/// <summary>
		/// ��ʼ��ݡ�
		/// </summary>
		protected int StartYear
		{
			get {return int.Parse(this.ddlStartYear.SelectedValue);}
			set {this.ddlStartYear.SelectedValue = value>2004?value.ToString():"2005";}
		}
		/// <summary>
		/// ������ݡ�
		/// </summary>
		protected int EndYear
		{
			get {return int.Parse(this.ddlEndYear.SelectedValue);}
			set {this.ddlEndYear.SelectedValue = value.ToString();}
		}
		/// <summary>
		/// ��ʼ�·ݡ�
		/// </summary>
		protected int StartMonth
		{
			get {return int.Parse(this.ddlStartMonth.SelectedValue);}
			set {this.ddlStartMonth.SelectedValue = value.ToString();}
		}
		/// <summary>
		/// �����·� ��
		/// </summary>
		protected int EndMonth
		{
			get {return int.Parse(this.ddlEndMonth.SelectedValue);}
			set {this.ddlEndMonth.SelectedValue = value.ToString();}
		}
		/// <summary>
		/// ��;���ࡣ
		/// </summary>
		private string _TopClass;
		protected string TopClass
		{
			get {return this._TopClass;}
			set {this._TopClass = value;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// �����;�����б�
		/// </summary>
//		private void FillTopClass(string TopClass)
//		{
//			SQLServer DA = new SQLServer();
//			DataSet oData;
//			ListItem Item;
//			Hashtable oHT = new Hashtable();
//			oHT.Add("@ClassifyID", TopClass);
//			
//			oData = DA.ExecSPReturnDS("Sto_PurposeGetTopClass",oHT);
//			foreach (DataRow r in oData.Tables[0].Rows)
//			{
//				Item = new ListItem(r["Description"].ToString(),r["ClassifyID"].ToString());
//				this.ListBoxClass.Items.Add(Item);
//			}
//			
//		}
		/// <summary>
		/// ͼ�οؼ����ݰ󶨡�
		/// </summary>
		private void ChartDataBind()
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ClassifyID",this.TopClass);
			oHT.Add("@StartYear", this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			oHT.Add("@StartMonth", this.StartMonth);
			oHT.Add("@EndMonth", this.EndMonth);
			DS = DA.ExecSPReturnDS("Analysis_TopClassMonthCompare",oHT);

			Series s;
			this.Chart1.Series.Clear();
			
			this.Chart1.DataSource = DS.Tables[0].DefaultView;
			for (int i=3;i<DS.Tables[0].Columns.Count;i++)
			{
				s = new Series(DS.Tables[0].Columns[i].ColumnName.Substring(1,4));
				s.ValueMemberX = "Month";
				s.ValueMembersY = DS.Tables[0].Columns[i].ColumnName;
				s.LegendText = DS.Tables[0].Columns[i].ColumnName.Substring(1,4)+"��";
				s.ToolTip = s.LegendText+"#VALX�£�#VAL{C2}��Ԫ";
				this.Chart1.Series.Add(s);
			}
			this.Chart1.DataBind();
			this.Chart1.ChartAreas[0].AxisX.Interval = 1;
//			for (int i=3;i<DS.Tables[0].Columns.Count;i++)
//			{
//				for (int index =0;index<DS.Tables[0].Rows.Count;index++)
//				{
//					if (DS.Tables[0].Rows[index]["IsDrillDown"] != System.DBNull.Value)
//					{
//						this.Chart1.Series[i-3].Points[index].Href = String.Format("USECompare.aspx?TopClass={0}&Year={1}",
//							DS.Tables[0].Rows[index]["ClassifyID"].ToString(),DS.Tables[0].Columns[i].ColumnName.Substring(1,4));
//					}
//					this.Chart1.Series[i-3].Points[index].ToolTip = DS.Tables[0].Rows[index]["ClassifyName"].ToString()+this.Chart1.Series[i-3].Points[index].ToolTip;
//				}
//			}
		}
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!this.IsPostBack)
			{
				//this.FillTopClass(this.Request["TopClass"]);
				this.TopClass = this.Request["TopClass"];
			
				this.StartYear = int.Parse(this.Request["StartYear"].ToString());
				this.EndYear = int.Parse(this.Request["EndYear"].ToString());
				try
				{
					this.StartMonth = int.Parse(this.Request["StartMonth"].ToString());
				}
				catch
				{
					this.StartMonth = 1;
				}
				try
				{
					this.EndMonth = int.Parse(this.Request["EndMonth"].ToString());
				}
				catch
				{
					this.EndMonth = 12;
				}
				this.ChartDataBind();
				this.UltraWebGrid1.DataBind();
			}
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
			this.UltraWebGrid1.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UltraWebGrid1_InitializeLayout);
			this.UltraWebGrid1.InitializeRow+=new InitializeRowEventHandler(UltraWebGrid1_InitializeRow);

		}
		#endregion

//		private void ListBoxClass_SelectedIndexChanged(object sender, EventArgs e)
//		{
//			this.TopClass = this.ListBoxClass.SelectedValue;
//			this.ChartDataBind();
//			this.UltraWebGrid1.DataBind();
//		}
		/// <summary>
		/// Grid��۳�ʼ����
		/// </summary>
		private void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			if (this.TopClass =="���¸���" || this.TopClass == "��������")
			{
				this.UltraWebGrid1.Bands[0].Columns.FromKey("ClassifyID").Hidden = true;
			}
			else
			{
				this.UltraWebGrid1.Bands[0].Columns.FromKey("ClassifyID").Hidden = false;
				this.UltraWebGrid1.Bands[0].Columns.FromKey("ClassifyID").Header.Caption = "���";
				this.UltraWebGrid1.Bands[0].Columns.FromKey("ClassifyID").Width = new Unit("80px");
			}
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ClassifyName").Header.Caption = "��;����";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ClassifyName").Width = new Unit("100px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ClassifyName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Month").Hidden = false;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Month").Header.Caption = "�·�";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Month").Width = new Unit("60px");

			
			for (int i = 3; i<DS.Tables[0].Columns.Count;i++)
			{
				this.UltraWebGrid1.Bands[0].Columns.FromKey(DS.Tables[0].Columns[i].ColumnName).Header.Caption = DS.Tables[0].Columns[i].ColumnName.Substring(1,4);
				this.UltraWebGrid1.Bands[0].Columns.FromKey(DS.Tables[0].Columns[i].ColumnName).Width = new Unit("80px");
				this.UltraWebGrid1.Bands[0].Columns.FromKey(DS.Tables[0].Columns[i].ColumnName).CellStyle.HorizontalAlign = HorizontalAlign.Right;
				this.UltraWebGrid1.Bands[0].Columns.FromKey(DS.Tables[0].Columns[i].ColumnName).Format="C2";
			}
		}
		/// <summary>
		/// Grid���ݰ�.
		/// </summary>
		protected void UltraWebGrid1_DataBinding(object sender, EventArgs e)
		{
			this.UltraWebGrid1.DataSource = this.DS.Tables[0].DefaultView;
		}
		/// <summary>
		/// ����X��������
		/// </summary>
//		private void Chart1_PrePaint(object sender, ChartPaintEventArgs e)
//		{
//			for (int i =0;i<DS.Tables[0].Rows.Count;i++)
//			{
//				DataRow r = DS.Tables[0].Rows[i];
//				// Retrieve size and position of individual labels
//				RectangleF rect = new RectangleF(
//					(float)Chart1.ChartAreas[0].AxisX.GetPosition( i + 0.5 ),
//					(float)Chart1.ChartAreas[0].AxisY.GetPosition(0),
//					(float)Chart1.ChartAreas[0].AxisX.GetPosition( i + 1.5 )
//					-(float)Chart1.ChartAreas[0].AxisX.GetPosition( i + 0.5 ),
//					7);
//				if (DS.Tables[0].Rows[i]["IsDrillDown"] != System.DBNull.Value)
//				{
//					// Use label's size and position information to define "hot" areas
//					string s = "USECompare.aspx?TopClass={0}&StartYear={1}&EndYear={2}";
//					Chart1.MapAreas.Add(r["ClassifyName"].ToString(),// Tool tip text
//						String.Format(s,r["ClassifyID"].ToString(),this.StartYear>2004?this.StartYear:2005,this.EndYear),//HREF
//						"Target=\"_Blank\"",// link attribute (i.e.: Target="_Blank"
//						rect);// the "hot" region for the link
//				}
//			}
		//		}

		private void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
		{
			e.Row.Cells.FromKey("ClassifyID").TargetURL = String.Format("UseDetail.aspx?ClassifyID={0}&StartYear={1}&EndYear={2}&Month={3}&ClassifyName={4}",Server.UrlEncode(e.Row.Cells.FromKey("ClassifyID").Text),this.StartYear,this.EndYear,e.Row.Cells.FromKey("Month").Text,Server.UrlEncode(e.Row.Cells.FromKey("ClassifyName").Text));						
			e.Row.Cells.FromKey("ClassifyName").TargetURL = String.Format("UseDetail.aspx?ClassifyID={0}&StartYear={1}&EndYear={2}&Month={3}&ClasifyName={4}",Server.UrlEncode(e.Row.Cells.FromKey("ClassifyID").Text),this.StartYear,this.EndYear,e.Row.Cells.FromKey("Month").Text,Server.UrlEncode(e.Row.Cells.FromKey("ClassifyName").Text));									
			for (int i = 3; i<DS.Tables[0].Columns.Count;i++)
			{
				e.Row.Cells.FromKey(DS.Tables[0].Columns[i].ColumnName).TargetURL = String.Format("UseDetail.aspx?ClassifyID={0}&StartYear={1}&EndYear={2}&Month={3}&ClassifyName={4}",Server.UrlEncode(e.Row.Cells.FromKey("ClassifyID").Text),this.DS.Tables[0].Columns[i].ColumnName.Substring(1,4),this.DS.Tables[0].Columns[i].ColumnName.Substring(1,4),e.Row.Cells.FromKey("Month").Text,Server.UrlEncode(e.Row.Cells.FromKey("ClassifyName").Text));	
			}
		}
	}
}
