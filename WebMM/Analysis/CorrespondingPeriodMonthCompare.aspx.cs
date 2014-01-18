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
using Infragistics.WebUI;
using MZHCommon.Database;
using Dundas.Charting.WebControl;

namespace WebMM.Analysis
{
	/// <summary>
	/// CorrespondingPeriodMonthCompare ��ժҪ˵����
	/// </summary>
	public partial class CorrespondingPeriodMonthCompare : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlStorage;
	
		#region ����
		protected int StartYear
		{
			get {return int.Parse(this.ddlStartYear.SelectedValue);}
			set {this.ddlStartYear.SelectedValue = value.ToString();}
		}
		protected int EndYear
		{
			get {return int.Parse(this.ddlEndYear.SelectedValue);}
			set {this.ddlEndYear.SelectedValue = value.ToString();}
		}
		protected int StartMonth
		{
			get {return int.Parse(this.ddlStartMonth.SelectedValue);}
			set {this.ddlStartMonth.SelectedValue = value.ToString();}
		}
		protected int EndMonth
		{
			get {return int.Parse(this.ddlEndMonth.SelectedValue);}
			set {this.ddlEndMonth.SelectedValue = value.ToString();}
		}
		protected string StoCode
		{
			get { return this.ListBoxStorage.SelectedValue;}
			set { this.ListBoxStorage.SelectedValue = value;}
		}
		protected string StoName
		{
			get { return this.ListBoxStorage.SelectedItem.Text;}
		}
		protected int CatCode
		{
			get {return int.Parse(this.ListBoxCategory.SelectedValue);}
			set {this.ListBoxCategory.SelectedValue = value.ToString();}
		}
		protected string CatName
		{
			get { return this.ListBoxCategory.SelectedItem.Text;}
		}
		private int _Flag;
		/// <summary>
		/// �ǲֿ⻹�Ƿ��ࡣ
		/// </summary>
		public int Flag
		{
			get {return this._Flag;}
			set {this._Flag = value;}
		}
		private int _type;
		/// <summary>
		/// ͬ�ڱȽϵ����ͣ���棬���ϣ����ϡ�
		/// </summary>
		public int Type
		{
			get {return this._type;}
			set {this._type = value;}
		}
		public string ClassifyID
		{
			get { return this.Flag == 1?this.StoCode:this.CatCode.ToString();}
		}
		public string ClassifyName
		{
			get { return this.Flag == 1?this.StoName:this.CatName;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// Chart���ݰ󶨡�
		/// </summary>
		private void ChartDatabind()
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			if (this.Flag == 1)
				oHT.Add("@StoCode", this.StoCode);
			else
				oHT.Add("@CatCode", this.CatCode);

			oHT.Add("@StartYear", this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			oHT.Add("@StartMonth", this.StartMonth);
			oHT.Add("@EndMonth", this.EndMonth);
			oHT.Add("@Flag",1);//ָ����Chart�����ݰ�
			oHT.Add("@Type", this.Type);
			DataSet DS;
			DS = this.Flag == 1?DA.ExecSPReturnDS("Analysis_CorrespondingPeriodStoCompare",oHT):DA.ExecSPReturnDS("Analysis_CorrespondingPeriodCategoryCompare",oHT);

			if (this.Type ==0)//���
			{
				this.Chart1.Titles[0].Text = (this.Flag == 1?DS.Tables[0].Rows[0]["StoName"].ToString():DS.Tables[0].Rows[0]["CatName"].ToString())+"-���ͬ�ڱȽ�";
			}
			else if (this.Type == 1) //����
			{
				this.Chart1.Titles[0].Text = (this.Flag == 1?DS.Tables[0].Rows[0]["StoName"].ToString():DS.Tables[0].Rows[0]["CatName"].ToString())+"-����ͬ�ڱȽ�";
			}
			else if (this.Type == 2)//���ϡ�
			{
				this.Chart1.Titles[0].Text = (this.Flag == 1?DS.Tables[0].Rows[0]["StoName"].ToString():DS.Tables[0].Rows[0]["CatName"].ToString())+"-����ͬ�ڱȽ�";
			}

			this.Chart1.Series.Clear();
			this.Chart1.ChartAreas[0].AxisY.Minimum=0;
			this.Chart1.DataBindCrossTab(DS.Tables[0].DefaultView,"Year","Month","WanMoney","Tooltip=ItemMoney{C2}",PointsSortOrder.Ascending);		
		}
		private void FillStorage()
		{
			SQLServer DA = new SQLServer();
			DataSet DS = DA.ExecSPReturnDS("Sto_StoGetNormal");
			ListItem Item;
			foreach(DataRow row in DS.Tables[0].Rows)
			{
				Item = new ListItem(row["Description"].ToString(),row["Code"].ToString());
				this.ListBoxStorage.Items.Add(Item);
			}
		}
		private void FillCategory()
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@Code",-1);
			DataSet DS = DA.ExecSPReturnDS("Sto_CategoryQueryByCode",oHT);
			ListItem Item;
			foreach(DataRow row in DS.Tables[0].Rows)
			{
				if (row["Code"].ToString() != "-1")
				{
					Item = new ListItem(row["Code"].ToString()+"-"+row["Description"].ToString(),row["Code"].ToString());
					this.ListBoxCategory.Items.Add(Item);
				}
			}	
		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.Flag = 1;//��ʾ�ǲֿ⡣
				this.Type = int.Parse(this.Request["Type"].ToString());
				if (this.Type == 0) 
					this.WebPanel1.Header.Text = "���ͬ�ڱȽ�";
				else if(this.Type == 1)
					this.WebPanel1.Header.Text = "����ͬ�ڱȽ�";
				else if (this.Type == 2)
					this.WebPanel1.Header.Text = "����ͬ�ڱȽ�";

				this.StartYear = int.Parse(this.Request["StartYear"]);
				this.EndYear = int.Parse(this.Request["EndYear"]);
				this.StartMonth = int.Parse(this.Request["StartMonth"]);
				this.EndMonth = int.Parse(this.Request["EndMonth"]);
				this.FillStorage();
				this.StoCode = this.Request["StoCode"];
				this.FillCategory();				
				this.ChartDatabind();
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

		protected void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.Flag = 1;//��ʾ�ǲֿ⡣
			this.ListBoxCategory.SelectedIndex = -1;
			this.ChartDatabind();
			this.UltraWebGrid1.DataBind();
		}

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;

			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			
				try
				{
					this.UltraWebGrid1.Bands[0].Columns[0].Width = new Unit("50px");
					this.UltraWebGrid1.Bands[0].Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
					for (int i= 1;i<this.UltraWebGrid1.Bands[0].Columns.Count;i++)
					{
						this.UltraWebGrid1.Bands[0].Columns[i].Header.Caption =	this.UltraWebGrid1.Bands[0].Columns[i].Header.Caption.Substring(1,2)+"�·�";
						this.UltraWebGrid1.Bands[0].Columns[i].Width = new Unit("60px");
						this.UltraWebGrid1.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
						this.UltraWebGrid1.Bands[0].Columns[i].Format="C0";
					}
				}
				catch {}
		}

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			if (this.Flag == 1)
				oHT.Add("@StoCode", this.StoCode);
			else
				oHT.Add("@CatCode", this.CatCode);
			oHT.Add("@StartYear", this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			oHT.Add("@StartMonth", this.StartMonth);
			oHT.Add("@EndMonth", this.EndMonth);
			oHT.Add("@Flag",0);//ָ����Grid�����ݰ�
			oHT.Add("@Type",this.Type);
			DataSet DS;
			if (this.Flag == 1)
                DS = DA.ExecSPReturnDS("Analysis_CorrespondingPeriodStoCompare",oHT);
			else
				DS = DA.ExecSPReturnDS("Analysis_CorrespondingPeriodCategoryCompare",oHT);
			this.UltraWebGrid1.Bands[0].Columns.Clear();
			this.UltraWebGrid1.DataSource = DS.Tables[0].DefaultView;
		}

		protected void btnCategoryQuery_Click(object sender, System.EventArgs e)
		{
			this.Flag = 0;//��ʾ�����Ϸ��ࣻ
			this.ListBoxStorage.SelectedIndex = -1;
			this.ChartDatabind();
			this.UltraWebGrid1.DataBind();
		}

		private void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
		{
			for (int i= 1;i<this.UltraWebGrid1.Bands[0].Columns.Count;i++)
			{
				int month;
				try
				{
					month = int.Parse(this.UltraWebGrid1.Bands[0].Columns[i].Header.Caption.Substring(0,2));
				}
				catch
				{
					month = int.Parse(this.UltraWebGrid1.Bands[0].Columns[i].Header.Caption.Substring(0,1));
				}
				e.Row.Cells[i].TargetURL = String.Format("UseDetail.aspx?ClassfyID={0}&ClassifyName={1}&StartYear={2}&EndYear={3}&Month={4}&Flag={5}&Type={6}",this.ClassifyID,this.ClassifyName,e.Row.Cells[0].Text,e.Row.Cells[0].Text,month,this.Flag,this.Type);
			}
		}
	}
}
