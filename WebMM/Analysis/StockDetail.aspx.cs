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
//using MZHCommon.PageStyle;
using Infragistics.WebUI.UltraWebGrid;
//NullableTypes.
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
using NGuid = NullableTypes.NullableGuid;
//------------------------------------------------
namespace MZHMM.WebMM
{
	/// <summary>
	/// StockDetail 的摘要说明。
	/// </summary>
	public partial class StockDetail : System.Web.UI.Page
	{
		protected CurrentStockData oData;
		#region 属性
		private NString mABC;
		public NString ABC
		{
			get {return this.mABC;}
			set {this.mABC = value;}
		}
		private NString mStoName;
	
		public NString StoName
		{
			get {return this.mStoName;}
			set {this.mStoName = value;}
		}
		private NString mCatName;
		public NString CatName
		{
			get {return this.mCatName;}
			set {this.mCatName = value;}
		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.ABC = this.Request["ABC"];
				this.StoName = this.Request["StoName"];
				this.CatName = this.Request["CatName"];
				if (!this.ABC.IsNull && !this.ABC.IsEmpty)
				{
					((System.Web.UI.WebControls.Label)this.WebPanel1.FindControl("lblABC")).Text = "&nbsp;&nbsp;&nbsp;&nbsp;"+this.ABC.ToString();
				}
				if (!this.StoName.IsNull && !this.StoName.IsEmpty)
				{
					((System.Web.UI.WebControls.Label)this.WebPanel1.FindControl("lblStoName")).Text = "&nbsp;&nbsp;&nbsp;&nbsp;"+this.StoName.ToString();
				}
				if (!this.CatName.IsNull && !this.CatName.IsEmpty)
				{
					((System.Web.UI.WebControls.Label)this.WebPanel1.FindControl("lblCatName")).Text = "&nbsp;&nbsp;&nbsp;&nbsp;"+this.CatName.ToString();
				}
				this.UltraWebGrid1.DataBind();
				decimal ItemMoney = 0;
				for (int i=0; i<oData.Tables[0].Rows.Count; i++)
				{
					ItemMoney += Convert.ToDecimal(oData.Tables[0].Rows[i]["ItemMoney"].ToString());
				}
				((System.Web.UI.WebControls.Label)this.WebPanel1.FindControl("lblItemMoney")).Text = "&nbsp;&nbsp;&nbsp;&nbsp;"+ItemMoney.ToString("c");
				
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
			this.UltraWebGrid1.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UltraWebGrid1_InitializeLayout);

		}
		#endregion

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.DisplayLayout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.Height = new Unit("25px");			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemCode_Field).Header.Caption="物料编号";	
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemCode_Field).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemCode_Field).CellStyle.Width = new Unit("80px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemCode_Field).Footer.Caption = "&nbsp;&nbsp;合计：";
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemName_Field).Header.Caption="物料名称";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemName_Field).CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemName_Field).CellStyle.Width = new Unit("100px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemSpec_Field).Header.Caption="规格型号";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemName_Field).CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemName_Field).CellStyle.Width = new Unit("150px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemUnit_Field).Hidden = true;
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemUnitName_Field).Header.Caption="单位";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemUnitName_Field).CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemUnitName_Field).CellStyle.Width = new Unit("40px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemPrice_Field).Header.Caption="单价";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemPrice_Field).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemPrice_Field).CellStyle.Width = new Unit("100px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemNum_Field).Header.Caption="数量";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemNum_Field).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemNum_Field).CellStyle.Width = new Unit("100px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemMoney_Field).Header.Caption="金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemMoney_Field).CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemMoney_Field).CellStyle.Width = new Unit("100px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemMoney_Field).Format = "c";//货币格式
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemMoney_Field).Footer.Total = SummaryInfo.Sum;
			
		}
		/// <summary>
		/// 数据绑定。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			if ( !this.ABC.IsNull && !this.StoName.IsNull && !this.CatName.IsNull)
			{
				oData = new ItemSystem().Get_CurrentStock(this.ABC.ToString(), this.StoName.ToString(), this.CatName.ToString());
			}
			else if (!this.ABC.IsNull)
			{
				oData = new ItemSystem().Get_CurrentStock(ABC.ToString());
			}

			this.UltraWebGrid1.DataSource = oData.Tables[CurrentStockData.CurrentStock_Table].DefaultView;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Response.Write("<script>window.close();</script>");
		}
	}
}
