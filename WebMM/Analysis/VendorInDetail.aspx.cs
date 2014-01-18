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
//using MZHCommon.PageStyle;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Modules;

using Infragistics.WebUI.UltraWebGrid;


namespace WebMM.Analysis
{
	/// <summary>
	/// VendorInDetail 的摘要说明。
	/// </summary>
	public partial class VendorInDetail : System.Web.UI.Page
	{
		private VendorInDetailData oData;
		/// <summary>
		/// 供应商编号。
		/// </summary>
		public string PrvCode
		{
			get 
			{ 
				if (this.Request["PrvCode"] != null && this.Request["PrvCode"] != "")
				{
					return this.Request["PrvCode"].ToString();
				}
				else
				{
					return "";
				}
			}
			set
			{
				((System.Web.UI.WebControls.Label)this.WebPanel1.FindControl("lblPrvCode")).Text = this.PrvCode;
			}
		}
		/// <summary>
		/// 供应商名称。
		/// </summary>
		public string PrvName
		{
			get 
			{ 
				if (this.Request["PrvName"] != null && this.Request["PrvName"] != "")
				{
					return this.Request["PrvName"].ToString();
				}
				else
				{
					return "";
				}
			}
			set
			{
				((System.Web.UI.WebControls.Label)this.WebPanel1.FindControl("lblPrvName")).Text = this.PrvName;
			}
		}
		/// <summary>
		/// 开始日期。
		/// </summary>
		public DateTime StartDate
		{
			get 
			{ 
				if (this.Request["StartDate"] != null && this.Request["StartDate"] != "")
				{
					return Convert.ToDateTime(this.Request["StartDate"].ToString());
				}
				else
				{
					return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
				}
			}
			set
			{
				this.lblStartDate.Text = this.StartDate.ToShortDateString();
			}
		}
		/// <summary>
		/// 结束日期。
		/// </summary>
		public DateTime EndDate
		{
			get 
			{ 
				if (this.Request["EndDate"] != null && this.Request["EndDate"] != "")
				{
					return Convert.ToDateTime(this.Request["EndDate"].ToString());
				}
				else
				{
					return this.StartDate.AddMonths(1);
				}
			}
			set
			{
				this.lblEndDate.Text = this.EndDate.ToShortDateString();
			}
		}

		public decimal ItemMoney
		{
			get
			{
				decimal SubTotal = 0;
				if (this.oData.Tables[0].Rows.Count > 0)
				{
					for (int i=0; i< this.oData.Tables[0].Rows.Count; i++)
					{
						SubTotal += Convert.ToDecimal(this.oData.Tables[0].Rows[i]["ItemMoney"].ToString());
					}
					return SubTotal;
				}
				else
				{
					return 0;
				}
			}
			set
			{
				((System.Web.UI.WebControls.Label)this.WebPanel1.FindControl("lblItemMoney")).Text = this.ItemMoney.ToString("c");
			}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.PrvCode = this.PrvCode;
				this.PrvName = this.PrvName;
				this.StartDate = this.StartDate;
				this.EndDate = this.EndDate;
				this.UltraWebGrid1.DataBind();
				this.ItemMoney = this.ItemMoney;
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
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("PrvCode").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("PrvName").Hidden = true;

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").Header.Caption = "物料编号";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").Width = new Unit("70px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").Header.Caption = "物料名称";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").Width = new Unit("100px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpecial").Header.Caption = "规格型号";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpecial").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpecial").Width = new Unit("100px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnit").Hidden = true;

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").Header.Caption = "单位";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").Width = new Unit("40px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").Header.Caption = "单价";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").Width = new Unit("80px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").Header.Caption = "数量";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").Format = "0.##";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").Width = new Unit("80px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Header.Caption = "金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Format = "c";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Width = new Unit("80px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("EntryNo").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("DocCode").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AcceptDate").Header.Caption = "日期";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AcceptDate").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AcceptDate").Width = new Unit("80px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AcceptDate").Format = "yyyy-MM-dd";

		}

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			this.oData = new ItemSystem().Get_VendorInDetail(this.PrvCode, this.StartDate, this.EndDate);
			this.UltraWebGrid1.DataSource = this.oData.Tables[0].DefaultView;
		}
	}
}
