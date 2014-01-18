namespace WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Infragistics.WebUI.UltraWebGrid;

    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	/// <summary>
	///		WUC_GKCStock 的摘要说明。
	/// </summary>
	public partial class WUC_GKCStock : System.Web.UI.UserControl
	{
		protected StockData oStockData;

        ItemSystem oItemSystem = new ItemSystem();

		protected void Page_Load(object sender, System.EventArgs e)
		{
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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.UltraWebGrid1.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UltraWebGrid1_InitializeLayout);

		}
		#endregion

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			
			oStockData = oItemSystem.GetStockByUppWarning();
			this.UltraWebGrid1.DataSource = oStockData.Tables[StockData.WSTKWARNING_TABLE].DefaultView;
		}

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;

			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMSPEC_FIELD).Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUNIT_FIELD).Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUNIT_FIELD).Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMLOWNUM_FIELD).Hidden = true;

			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).Header.Caption = "编号";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).Width = new Unit("50px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).Header.Caption = "名称";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).Width = new Unit("70px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).Header.Caption = "单位";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).Width = new Unit("30px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUPPNUM_FIELD).Header.Caption = "高库存";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUPPNUM_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUPPNUM_FIELD).Width = new Unit("60px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).Header.Caption = "库存";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).Width = new Unit("60px");
		}
	}
}
