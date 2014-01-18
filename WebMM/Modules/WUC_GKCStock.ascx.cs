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
	///		WUC_GKCStock ��ժҪ˵����
	/// </summary>
	public partial class WUC_GKCStock : System.Web.UI.UserControl
	{
		protected StockData oStockData;

        ItemSystem oItemSystem = new ItemSystem();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.UltraWebGrid1.DataBind();
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
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
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

			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).Header.Caption = "���";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMCODE_FIELD).Width = new Unit("50px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).Header.Caption = "����";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNAME_FIELD).Width = new Unit("70px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).Header.Caption = "��λ";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUNITNAME_FIELD).Width = new Unit("30px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUPPNUM_FIELD).Header.Caption = "�߿��";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUPPNUM_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMUPPNUM_FIELD).Width = new Unit("60px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).Header.Caption = "���";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(StockData.ITEMNUM_FIELD).Width = new Unit("60px");
		}
	}
}
