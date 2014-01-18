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
//using MZHCommon.PageStyle;
using MZHMM.WebMM.Modules;
using Infragistics.WebUI.UltraWebGrid;
using Dundas.Charting.WebControl;
using NBoolean = NullableTypes.NullableBoolean;
using NByte = NullableTypes.NullableByte; 
using NInt16 = NullableTypes.NullableInt16;
using NInt32 = NullableTypes.NullableInt32;
using NInt64 = NullableTypes.NullableInt64;
using NSingle = NullableTypes.NullableSingle; 
using NDouble = NullableTypes.NullableDouble;
using NDecimal = NullableTypes.NullableDecimal;
using NString = NullableTypes.NullableString;
using NDateTime = NullableTypes.NullableDateTime;
namespace WebMM.Analysis
{
	/// <summary>
	/// WithDrawAnalysis 的摘要说明。
	/// </summary>
	public partial class VendorAnalysis : System.Web.UI.Page
	{
		#region 成员变量
		protected MZHCommon.Database.SQLServer MySQLServer = new SQLServer();
		private DataSet  VendorDS = new DataSet();
		private DataSet oData = new DataSet();
		#endregion

		#region 属性	
        /// <summary>
        /// 开始日期 
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return DateTime.Parse(((Shmzh.Web.UI.Controls.ToolbarCalendar)this.WebPanel1.FindControl("WebDateChooser_StartDate")).Text);
                //return Convert.ToDateTime(((Infragistics.WebUI.WebSchedule.WebDateChooser)this.WebPanel1.FindControl("WebDataChooser_StartDate")).Value.ToString());
            }
            set
            {
                ((Shmzh.Web.UI.Controls.ToolbarCalendar)this.WebPanel1.FindControl("WebDateChooser_StartDate")).Text = value.ToString("yyyy-MM-dd");
                //((Infragistics.WebUI.WebSchedule.WebDateChooser)this.WebPanel1.FindControl("WebDateChooser_StartDate")).Value = value;
            }
        }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return DateTime.Parse(((Shmzh.Web.UI.Controls.ToolbarCalendar)this.WebPanel1.FindControl("WebDateChooser_EndDate")).Text);
                //return Convert.ToDateTime(((Infragistics.WebUI.WebSchedule.WebDateChooser)this.WebPanel1.FindControl("WebDateChooser_EndDate")).Value.ToString());
            }
            set
            {
                ((Shmzh.Web.UI.Controls.ToolbarCalendar)this.WebPanel1.FindControl("WebDateChooser_EndDate")).Text = value.ToString("yyyy-MM-dd");
                //((Infragistics.WebUI.WebSchedule.WebDateChooser)this.WebPanel1.FindControl("WebDateChooser_EndDate")).Value = value;
            }
        }
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.StartDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
				this.EndDate = this.StartDate.AddMonths(1);
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

		}
		#endregion

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.ExpandableDefault = Expandable.Yes;
			this.UltraWebGrid1.DisplayLayout.AllowColumnMovingDefault = AllowColumnMoving.None;
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.VerticalAlign = VerticalAlign.Middle;
			this.UltraWebGrid1.DisplayLayout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("PrvCode").HeaderText = "供应商编号";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("PrvCode").Width = new Unit("100 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("PrvCode").CellStyle.HorizontalAlign = HorizontalAlign.Center;

			this.UltraWebGrid1.Bands[0].Columns.FromKey("PrvName").HeaderText = "供应商名称";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("PrvName").Width = new Unit("150 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("PrvName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").HeaderText = "金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Width = new Unit("120 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").CellStyle.HorizontalAlign = HorizontalAlign.Right;			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Format = "c";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Footer.Total = SummaryInfo.Sum;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Footer.Style.HorizontalAlign = HorizontalAlign.Right;
		}

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			Hashtable oHT = new Hashtable();
			oHT.Add("@StartDate", this.StartDate);
			oHT.Add("@EndDate", this.EndDate);

			this.VendorDS = new DataSet();
			this.VendorDS = MySQLServer.ExecSPReturnDS("Analysis_GetVendorGroup",oHT);
			this.UltraWebGrid1.DataSource = this.VendorDS.Tables[0].DefaultView;
			
			oHT = new Hashtable();
			oHT.Add("@StartDate", this.StartDate);
			oHT.Add("@EndDate", this.EndDate);
			
			oData =	new SQLServer().ExecSPReturnDS("Analysis_GetVerdorGroupByDate",oHT); 
			this.Chart1.DataSource = oData.Tables[0];
			
			this.Chart1.Series["Default"].ValueMemberX = "PrvName";
			this.Chart1.Series["Default"].XValueType = ChartValueTypes.String;
			this.Chart1.Series["Default"].ValueMembersY = "ItemMoney";
			this.Chart1.Series["Default"].YValueType = ChartValueTypes.Double;
			this.Chart1.ImageType = ChartImageType.Png;
			this.Chart1.Legends["Default"].LegendStyle = LegendStyle.Column;
			this.Chart1.Legends["Default"].Docking = LegendDocking.Bottom;
			this.Chart1.Legends["Default"].Alignment = StringAlignment.Near;
			this.Chart1.Series["Default"].Type = SeriesChartType.Pie;
			this.Chart1.Titles[0].Href = ""; 
			this.Chart1.Series["Default"].Label = "#PERCENT";
			this.Chart1.Series["Default"].LegendText = "#VALX: #VAL{C} 元: #PERCENT ";
			this.Chart1.Series["Default"].ToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			this.Chart1.Series["Default"].LegendToolTip = "#VALX: #VAL{C} 元: #PERCENT";
		}

		
		/// <summary>
		/// Grid行初始化。
		/// </summary>
		private void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
			if (e.Row.Cells.FromKey("ItemMoney") != null)
			{
				e.Row.Cells.FromKey("ItemMoney").TargetURL = "@[_blank]VendorInDetail.aspx?"
					                                       + "StartDate="+this.StartDate.ToShortDateString()
														    + "&EndDate="+this.EndDate.ToShortDateString()
														   + "&PrvCode="+e.Row.Cells.FromKey("PrvCode").Value.ToString()
					                                       + "&PrvName="+Server.UrlEncode(e.Row.Cells.FromKey("PrvName").Value.ToString());
														   
			}
		}
		/// <summary>
		/// 确定按钮。
		/// </summary>
		protected void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.UltraWebGrid1.DataBind();	
		}
	}
}
