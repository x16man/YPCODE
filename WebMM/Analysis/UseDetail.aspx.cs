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
using MZHCommon.Database;

namespace MZHMM.WebMM
{
	/// <summary>
	/// WithDrawDetail ��ժҪ˵����
	/// </summary>
	public partial class UseDetail : System.Web.UI.Page
	{
		protected DataSet oData;
		#region ����
		public string LblTitle
		{
			set {this.lblTitle.Text = value;}
		}
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
				((Label)this.WebPanel1.FindControl("lblClassifyName")).Text = value == ""?"&nbsp;":value;
			}
		}
		/// <summary>
		/// ��;
		/// </summary>
		public string ClassifyID
		{
			get 
			{
				if (this.Request["ClassifyID"] != null && this.Request["ClassifyID"] != "")
				{
					return this.Request["ClassifyID"].ToString();
				}
				else
				{
					return "";
				}
			}
			set 
			{
				((Label)this.WebPanel1.FindControl("lblClassifyID")).Text = value==""?"&nbsp;":value;
			}
		}
		/// <summary>
		/// �ܽ�
		/// </summary>
		public string SubTotal
		{
			get 
			{

                if (oData != null && this.oData.Tables[0].Rows.Count > 0)
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
		public int StartYear
		{
			get 
			{
				if (this.Request["StartYear"] != null && this.Request["StartYear"] != "")
				{
					return Convert.ToInt32(this.Request["StartYear"].ToString());
				}
				else
				{
					return DateTime.Now.Year;
				}
			}
			set
			{
				this.lblStartDate.Text = value.ToString();
			}
		}
		/// <summary>
		/// �������ڡ�
		/// </summary>
		public int EndYear
		{
			get 
			{
				if (this.Request["EndYear"] != null && this.Request["EndYear"] != "")
				{
					return Convert.ToInt32(this.Request["EndYear"].ToString());
				}
				else
				{
					return this.StartYear;
				}
			}
			set 
			{
				this.lblEndDate.Text = value.ToString();
			}
		}
		/// <summary>
		/// �·ݡ�
		/// </summary>
		public int Month
		{
			get 
			{
				if (this.Request["Month"] != null && this.Request["Month"] != "")
				{
					return Convert.ToInt32(this.Request["Month"].ToString());
				}
				else
				{
					return 0;
				}
			}
			set
			{
				if (value.ToString() == "0")
				{
					((Label)this.WebPanel1.FindControl("lblMonth")).Text = "ȫ���·�";
				}
				else
				{
					((Label)this.WebPanel1.FindControl("lblMonth")).Text = value.ToString()+"�·�";
				}
			}
		}
		public int Flag 
		{
			get 
			{
				if (this.Request["Flag"] != null && this.Request["Flag"] != "")
				{
					return Convert.ToInt32(this.Request["Flag"].ToString());
				}
				else
				{
					return -1;
				}		 
			}
		}
		public int Type
		{
			get 
			{
				if (this.Request["Type"] != null && this.Request["Type"] != "")
				{
					return Convert.ToInt32(this.Request["Type"].ToString());
				}
				else
				{
					return -1;
				}
			}
		}
		#endregion

		/// <summary>
		/// ҳ��Load��
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)	
			{
				this.UltraWebGrid1.DataBind();

			}
			this.ClassifyID = this.ClassifyID;
			this.ClassifyName = this.ClassifyName;
			this.SubTotal = this.SubTotal;
			this.StartYear = this.StartYear;
			this.EndYear = this.EndYear;
			this.Month = this.Month;
			switch (this.Type)
			{
				case -1:
                    this.LblTitle = "������ϸ���";
					break;
				case 0:
                    this.LblTitle = "�����ϸ���";
					break;
				case 1:
                    this.LblTitle = "������ϸ���";
					break;
				case 2:
                    this.LblTitle = "������ϸ���";
					break;
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

		}
		#endregion

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.DisplayLayout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.Height = new Unit("25px");			
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").Header.Caption="���ϱ��";	
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").CellStyle.Width = new Unit("80px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemCode").Footer.Caption = "&nbsp;&nbsp;�ϼƣ�";
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").Header.Caption="��������";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemName").CellStyle.Width = new Unit("100px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpecial").Header.Caption="����ͺ�";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpecial").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemSpecial").CellStyle.Width = new Unit("100px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").Header.Caption="��λ";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemUnitName").CellStyle.Width = new Unit("40px");
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").Header.Caption="����";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").CellStyle.Width = new Unit("80px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemPrice").Format = "n3";
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").Header.Caption="����";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemNum").CellStyle.Width = new Unit("80px");

			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Header.Caption="���";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").CellStyle.Width = new Unit("100px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Format = "c2";//���Ҹ�ʽ
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Footer.Total = SummaryInfo.Sum;

		}

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			SQLServer DA = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@ClassifyID", this.ClassifyID);
			oHT.Add("@StartYear", this.StartYear);
			oHT.Add("@EndYear", this.EndYear);
			oHT.Add("@Month", this.Month);
			switch(this.Type)
			{
				case -1:
					oData = DA.ExecSPReturnDS("Analysis_UseDetail",oHT);
					break;
				case 0:
					break;
				case 1:
					break;
				case 2:
					break;
			}
            if (oData != null)
			    this.UltraWebGrid1.DataSource = oData.Tables[0].DefaultView;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Response.Write("<script>window.close();</script>");
		}
	}
}
