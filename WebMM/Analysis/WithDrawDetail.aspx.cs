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

using Shmzh.MM.Common;
using Shmzh.MM.Facade;
//using MZHCommon.PageStyle;
using MZHMM.WebMM.Modules;
namespace MZHMM.WebMM
{
	/// <summary>
	/// WithDrawDetail ��ժҪ˵����
	/// </summary>
	public partial class WithDrawDetail : System.Web.UI.Page
	{
		protected WithDrawDetailData oData;
		/// <summary>
		/// ��;���ࡣ
		/// </summary>
		public string ClassifyName
		{
			get 
			{
				if (this.Request["ClassifyName"] != null && this.Request["ClassifyName"]!="")
				{
					return this.Request["ClassifyName"].ToString();
				}
				else
				{
					return "";
				}
			}
			set 
			{
				((Label)this.WebPanel1.FindControl("lblClassify")).Text = value == ""?"&nbsp;":value;
			}
		}
		/// <summary>
		/// ��;
		/// </summary>
		public string ReqReason
		{
			get 
			{
				if (this.Request["ReqReason"] != null && this.Request["ReqReason"] != "")
				{
					return this.Request["ReqReason"].ToString();
				}
				else
				{
					return "";
				}
			}
			set 
			{
				((Label)this.WebPanel1.FindControl("lblReqReason")).Text = value==""?"&nbsp;":value;
			}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string AuthorDeptName
		{
			get 
			{
				if (this.Request["AuthorDeptName"] != null && this.Request["AuthorDeptName"] != "")
				{
					return this.Request["AuthorDeptName"].ToString();
				}
				else
				{
					return "";
				}
			}
			set 
			{
				((Label)this.WebPanel1.FindControl("lblAuthorDeptName")).Text = value==""?"&nbsp;":value;
			}
		}
		/// <summary>
		/// �ܽ�
		/// </summary>
		public string SubTotal
		{
			get 
			{
				if (this.oData.Tables[0].Rows.Count> 0)
				{
					decimal ItemMoney = 0;
					for (int i=0; i< oData.Tables[0].Rows.Count; i++)
					{
						ItemMoney += Convert.ToDecimal(oData.Tables[0].Rows[i]["ItemMoney"].ToString());
					}
					return ItemMoney.ToString("c");
				}
				else
				{
					return "0";
				}
			}
			set 
			{
				((Label)this.WebPanel1.FindControl("lblItemMoney")).Text = value;
			}
		}
		/// <summary>
		/// ��ʼ���ڡ�
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
					return new DateTime(DateTime.Now.Year, DateTime.Now.Month,1);
				}
			}
			set
			{
				this.lblStartDate.Text = value.ToShortDateString();
			}
		}
		/// <summary>
		/// �������ڡ�
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
				this.lblEndDate.Text = value.ToShortDateString();
			}
		}
		/// <summary>
		/// ҳ��Load��
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)	
			{
				this.UltraWebGrid1.DataBind();
			}
			this.ClassifyName = this.ClassifyName;
			this.ReqReason = this.ReqReason;
			this.AuthorDeptName = this.AuthorDeptName;
			this.SubTotal = this.SubTotal;
			this.StartDate = this.StartDate;
			this.EndDate = this.EndDate;
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

		}
		#endregion

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.DisplayLayout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.Height = new Unit("25px");			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Classify").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ClassifyName").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReasonCode").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDept").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").Hidden = true;
			
//			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").Header.Caption = "��;";
//			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").CellStyle.HorizontalAlign = HorizontalAlign.Left;
//			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").Width = new Unit("120px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").Header.Caption="���ϱ��";	
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").CellStyle.Width = new Unit("80px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").Footer.Caption = "&nbsp;&nbsp;�ϼƣ�";
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").Header.Caption="��������";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").CellStyle.Width = new Unit("100px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpec").Header.Caption="����ͺ�";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpec").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpec").CellStyle.Width = new Unit("100px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey(CurrentStockData.ItemUnit_Field).Hidden = true;
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").Header.Caption="��λ";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").CellStyle.Width = new Unit("40px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").Header.Caption="����";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").CellStyle.Width = new Unit("80px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").Header.Caption="����";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").CellStyle.Width = new Unit("80px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Header.Caption="���";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").CellStyle.Width = new Unit("100px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Format = "c";//���Ҹ�ʽ
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Footer.Total = SummaryInfo.Sum;

			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorCode").Hidden = true;

			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorName").Header.Caption = "�Ƶ�";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorName").CellStyle.Width = new Unit("60px");
		}

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			
			oData = new ItemSystem().Get_WithDrawDetail(this.ClassifyName,this.ReqReason,this.AuthorDeptName,this.StartDate,this.EndDate);
			this.UltraWebGrid1.DataSource = oData.Tables[WithDrawDetailData.WithDrawDetail_Table].DefaultView;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Response.Write("<script>window.close();</script>");
		}
	}
}
