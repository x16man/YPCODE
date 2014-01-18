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
	///		WUC_YCLStock 的摘要说明。
	/// </summary>
	public partial class WUC_DKCStock : System.Web.UI.UserControl
	{
		protected StockData oStockData;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.UG_DKC.DataBind();
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
			this.UG_DKC.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UG_DKC_InitializeLayout);

		}
		#endregion

		private void UG_DKC_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UG_DKC.DisplayLayout.ViewType = ViewType.Flat;
			this.UG_DKC.DisplayLayout.AllowSortingDefault = AllowSorting.No;
			this.UG_DKC.DisplayLayout.AllowColSizingDefault = AllowSizing.Fixed;
			this.UG_DKC.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMSPEC_FIELD).Hidden = true;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMUNIT_FIELD).Hidden = true;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMUNIT_FIELD).Hidden = true;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMUPPNUM_FIELD).Hidden = true;

			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).Header.Caption = "编号";
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).Width = new Unit("50px");
			
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).Header.Caption = "名称";
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).Width = new Unit("70px");

			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).Header.Caption = "单位";
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).Width = new Unit("30px");

			
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMLOWNUM_FIELD).Header.Caption = "低库存";
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMLOWNUM_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMLOWNUM_FIELD).Width = new Unit("60px");

			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).Header.Caption = "库存";
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_DKC.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).Width = new Unit("60px");
		}

		protected void UG_DKC_DataBinding(object sender, System.EventArgs e)
		{
			ItemSystem oItemSystem = new ItemSystem();
			oStockData = oItemSystem.GetStockByWarning();
			this.UG_DKC.DataSource = oStockData.Tables[StockData.WSTKWARNING_TABLE].DefaultView;
		}



		
	}
}
