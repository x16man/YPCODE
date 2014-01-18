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
using Infragistics.WebUI.UltraWebGrid;

namespace MZHMM.WebMM.Analysis
{
	/// <summary>
	/// CurrentROSDetail 的摘要说明。
	/// </summary>
	public partial class CurrentROSDetail : System.Web.UI.Page
	{
		private DataSet oData;
		#region 属性
		/// <summary>
		/// 审批结果代码。
		/// </summary>
		private string ResultCode
		{
			get 
			{
				if (this.Request["ResultCode"] != null && this.Request["ResultCode"].ToString() != "")
				{
					return this.Request["ResultCode"].ToString();
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (value == "1")
				{
					((Label)this.WebPanel1.FindControl("lblResultCode")).Text = "审批通过";
				}
				else if (value == "-1")
				{
					((Label)this.WebPanel1.FindControl("lblResultCode")).Text = "审批不通过";
				}
				else if(value == "0")
				{
					((Label)this.WebPanel1.FindControl("lblResultCode")).Text = "待审批";
				}
				else if (value == "100")
				{
					((Label)this.WebPanel1.FindControl("lblResultCode")).Text = "全部";
				}
			}
		}
		/// <summary>
		/// 审批人。
		/// </summary>
		private string Result
		{
			get 
			{
				if (this.Request["Result"] != null && this.Request["Result"].ToString() != "")
				{
					return this.Request["Result"].ToString();
				}
				else
				{
					return null;
				}
			}
			set
			{
				((Label)this.WebPanel1.FindControl("lblResult")).Text = value;
			}
		}
		/// <summary>
		/// 开始日期。
		/// </summary>
		private DateTime StartDate
		{
			get 
			{
				if (this.Request["StartDate"] != null && this.Request["StartDate"] != "")
				{
					return Convert.ToDateTime(this.Request["StartDate"]);
				}
				else
				{
					return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
				}
			}
			set
			{
				this.lblStartDate.Text = value.ToShortDateString();
			}
		}
		/// <summary>
		/// 结束日期。
		/// </summary>
		private DateTime EndDate
		{
			get
			{
				if (this.Request["EndDate"] != null && this.Request["EndDate"] != "")
				{
					return Convert.ToDateTime(this.Request["EndDate"]);
				}
				else
				{
					return this.StartDate.AddMonths(1);
				}
			}
			set 
			{
				this.lblEndDate.Text = value.ToShortDateString();
			}
		}
		private decimal ItemMoney
		{
			get
			{
				decimal SubTotal = 0;
				if (this.oData.Tables[0].Rows.Count > 0)
				{
					for (int i=0; i< this.oData.Tables[0].Rows.Count; i++)
					{
						SubTotal += Convert.ToDecimal(this.oData.Tables[0].Rows[i]["SubTotal"].ToString());
					}
				}
				return SubTotal;
			}
			set
			{
				((System.Web.UI.WebControls.Label)this.WebPanel1.FindControl("lblItemMoney")).Text = value.ToString("c");
			}
		}
		#endregion
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.ResultCode = this.ResultCode;
				this.Result = this.Result;
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
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.DisplayLayout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("EntryNo").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").Header.Caption = "申请部门";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReasonCode").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").Header.Caption = "用途";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").Width = new Unit("100px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").Width = new Unit("100px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSummary").Header.Caption = "物料摘要";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSummary").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSummary").Width = new Unit("120px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("SubTotal").Header.Caption = "总金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("SubTotal").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("SubTotal").Footer.Total = SummaryInfo.Sum;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("SubTotal").Format = "c";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("SubTotal").Width = new Unit("80px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("EntryDate").Header.Caption = "日期";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("EntryDate").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("EntryDate").Format="yyyy-MM-dd";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("EntryDate").Width = new Unit("80px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor1").Header.Caption = "部门";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor1").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor1").Width = new Unit("80px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor2").Header.Caption = "财务";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor2").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor2").Width = new Unit("8px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor3").Header.Caption = "厂部";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor3").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Assessor3").Width = new Unit("80px");
		}

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			Hashtable oHT = new Hashtable();
			oHT.Add("@StartDate", this.StartDate);
			oHT.Add("@EndDate", this.EndDate);
			oHT.Add("@ResultCode", int.Parse(this.ResultCode));
			oHT.Add("@Result", this.Result);
		
			oData = new SQLServer().ExecSPReturnDS("Analysis_ROS_DetailList",oHT);
			this.UltraWebGrid1.DataSource = this.oData.Tables[0].DefaultView;
		}
	}
}
