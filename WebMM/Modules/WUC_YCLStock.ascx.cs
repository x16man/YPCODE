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
	public partial class WUC_YCLStock : System.Web.UI.UserControl
	{
		protected YCLData oYCLData ;

	    private ItemSystem oItemSystem = new ItemSystem();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.UG_YCL.DataBind();
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
			this.UG_YCL.InitializeRow += new Infragistics.WebUI.UltraWebGrid.InitializeRowEventHandler(this.UG_YCL_InitializeRow);
			this.UG_YCL.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UG_YCL_InitializeLayout);

		}
		#endregion

		private void UG_YCL_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UG_YCL.DisplayLayout.ViewType = ViewType.Flat;
			this.UG_YCL.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.PKID_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.PrvCode_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.PrvName_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.UnitCode_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.OpDate_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey("StartVolNum").Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey("StartItemNum").Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.OutItemNum_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.OutVolNum_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.InVolNum_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.InItemNum_Field).Hidden = true;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.EndVolNum_Field).Hidden = true;

			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.ItemCode_Field).Header.Caption = "编号";
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.ItemCode_Field).Width = new Unit("50px");
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.ItemCode_Field).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.ItemName_Field).Header.Caption = "名称";
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.ItemName_Field).Width = new Unit("100px");
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.ItemName_Field).CellStyle.HorizontalAlign = HorizontalAlign.Left;

			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.UnitName_Field).Header.Caption = "单位";
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.UnitName_Field).Width = new Unit("40px");
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.UnitName_Field).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.EndItemNum_Field).Header.Caption = "库存数";
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.EndItemNum_Field).Width = new Unit("80px");
			this.UG_YCL.Bands[0].Columns.FromKey(YCLData.EndItemNum_Field).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			
		}
		protected void UG_YCL_DataBinding(object sender, System.EventArgs e)
		{
			
			oYCLData = oItemSystem.GetYCLNow();
			this.UG_YCL.DataSource = oYCLData.Tables[YCLData.YCL_Table].DefaultView;
			
		}

		private void UG_YCL_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
//			e.Row.Cells.FromKey("ItemCode").TargetURL = "@[_blank]Storage/YCLGroupBrowser.aspx";
//			e.Row.Cells.FromKey("ItemName").TargetURL = "@[_blank]Storage/YCLGroupBrowser.aspx";
//			e.Row.Cells.FromKey("UnitName").TargetURL = "@[_blank]Storage/YCLGroupBrowser.aspx";
//			e.Row.Cells.FromKey("EndItemNum").TargetURL = "@[_blank]Storage/YCLGroupBrowser.aspx";
			
			e.Row.Cells.FromKey("ItemCode").TargetURL = "Storage/YCLGroupBrowser.aspx?ItemCode="+e.Row.Cells.FromKey("ItemCode").Value.ToString();
			e.Row.Cells.FromKey("ItemName").TargetURL = "Storage/YCLGroupBrowser.aspx?ItemCode="+e.Row.Cells.FromKey("ItemCode").Value.ToString();
			e.Row.Cells.FromKey("UnitName").TargetURL = "Storage/YCLGroupBrowser.aspx?ItemCode="+e.Row.Cells.FromKey("ItemCode").Value.ToString();
			e.Row.Cells.FromKey("EndItemNum").TargetURL = "Storage/YCLGroupBrowser.aspx?ItemCode="+e.Row.Cells.FromKey("ItemCode").Value.ToString();
		}
	}
}
