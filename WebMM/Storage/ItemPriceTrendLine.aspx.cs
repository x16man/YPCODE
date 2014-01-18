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

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// ItemPriceTrendLine 的摘要说明。
	/// </summary>
	public partial class ItemPriceTrendLine : System.Web.UI.Page
	{
		//protected Infragistics.WebUI.WebSchedule.WebDateChooser ddlStartDate;
		//protected Infragistics.WebUI.WebSchedule.WebDateChooser ddlEndDate;

        DataSet oData ;
	    private Hashtable oHT;

	    private DataRow oRow;

	    private int i;
		#region 属性
		private string ItemCode
		{
			get
			{
				if (this.Request["ItemCode"] != null && this.Request["ItemCode"].ToString() != "")
				{
					return this.Request["ItemCode"].ToString();
				}
				else
				{
					return null;
				}
			}
		}
		private DateTime StartDate
		{
			get 
			{ 
				//return Convert.ToDateTime(this.ddlStartDate.Value.ToString());
				return Convert.ToDateTime(this.txtStartDate.Text.Trim().ToString());
			}
			set 
			{ 
				//this.ddlStartDate.Value = value;
				this.txtStartDate.Text = value.ToString("yyyy-MM-dd");
			}
		}
		private DateTime EndDate
		{
			get 
			{
				//return Convert.ToDateTime(this.ddlEndDate.Value.ToString());
				return Convert.ToDateTime(this.txtEndDate.Text.Trim().ToString());
			}
			set 
			{ 
				//this.ddlEndDate.Value = value;
                this.txtEndDate.Text = value.ToString("yyyy-MM-dd");
			}
		}
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				
				oHT = new Hashtable();
				oHT.Add("@ItemCode", this.ItemCode);

				oData = new SQLServer().ExecSPReturnDS("Sto_ItemGetTrendLineByCode",oHT);
				if (oData.Tables[0].Rows.Count==1)
				{
					oRow = oData.Tables[0].NewRow();
					oRow["Date"] = DateTime.Now.ToShortDateString();
					oRow["ItemCode"] = this.ItemCode;
					oRow["ItemName"] = oData.Tables[0].Rows[0]["ItemName"].ToString();
					oRow["DocCode"]	= System.DBNull.Value;
					oRow["PrvName"] = "至今";
					try
					{
						oRow["ItemPrice"] = Convert.ToDecimal(oData.Tables[0].Rows[0]["ItemPrice"].ToString());
					}
					catch
					{}
					try
					{
						oRow["AveragePrice"] = Convert.ToDecimal(oData.Tables[0].Rows[0]["AveragePrice"].ToString());
					}
					catch
					{}
					oData.Tables[0].Rows.Add(oRow);
				}
				this.Chart1.DataSource = oData.Tables[0];
				this.Chart1.Series["Default"].ValueMemberX = "Date";
				this.Chart1.Series["Default"].ValueMembersY = "ItemPrice";
				//this.Chart1.Series["Average"].ValueMemberX = "Date";
				//this.Chart1.Series["Average"].ValueMembersY = "AveragePrice";
				this.Chart1.DataBind();
				if (oData.Tables[0].Rows.Count>0)
				{
					this.Chart1.Titles[0].Text = oData.Tables[0].Rows[0]["ItemName"].ToString()+"  价格走势图";
				}
				else
				{
					this.Chart1.Titles[0].Text = "此物料尚未发生采购业务没有价格信息";
				}
				for (i= 0; i< this.Chart1.Series[0].Points.Count; i++)
				{
					if (oData.Tables[0].Rows[i]["DocCode"].ToString() == "6")
					{
						this.Chart1.Series[0].Points[i].Href= "../Purchase/PBORDetail.aspx?Op=View&EntryNo="+oData.Tables[0].Rows[i]["EntryNo"].ToString();
						this.Chart1.Series[0].Points[i].ToolTip = oData.Tables[0].Rows[i]["PrvName"].ToString();
					}
					else  if (oData.Tables[0].Rows[i]["DocCode"].ToString() == "17")
					{
						this.Chart1.Series[0].Points[i].Href= "../Storage/WINWDetail.aspx?Op=View&EntryNo="+oData.Tables[0].Rows[i]["EntryNo"].ToString();
						this.Chart1.Series[0].Points[i].ToolTip = oData.Tables[0].Rows[i]["PrvName"].ToString();
					}
					else 
					{
						this.Chart1.Series[0].Points[i].ToolTip = oData.Tables[0].Rows[i]["PrvName"].ToString();
					}
					this.Chart1.Series[0].Points[i].MapAreaAttributes = "TARGET='_blank'";
				}

				this.MzhDataGrid1.DataSource = oData;
				this.MzhDataGrid1.DataBind();
				if (oData.Tables[0].Rows.Count > 0)
				{
					this.StartDate = Convert.ToDateTime(oData.Tables[0].Rows[0]["Date"].ToString());
                    this.EndDate = Convert.ToDateTime(oData.Tables[0].Rows[oData.Tables[0].Rows.Count - 1]["Date"].ToString());
				}
			}
		}

		protected void btnYes_Click(object sender, System.EventArgs e)
		{
			oHT = new Hashtable();
			oHT.Add("@ItemCode", this.ItemCode);
			oHT.Add("@StartDate", this.StartDate);
			oHT.Add("@EndDate", this.EndDate);
													 
			oData = new SQLServer().ExecSPReturnDS("Sto_ItemGetTrendLineByCodeAndDate",oHT);
			if (oData.Tables[0].Rows.Count==1)
			{
				oRow = oData.Tables[0].NewRow();
				oRow["Date"] = DateTime.Now.ToShortDateString();
				oRow["ItemCode"] = this.ItemCode;
				oRow["ItemName"] = oData.Tables[0].Rows[0]["ItemPrice"].ToString();
				oRow["DocCode"]	= System.DBNull.Value;
				oRow["PrvName"] = "至今";
				oRow["ItemPrice"] = Convert.ToDecimal(oData.Tables[0].Rows[0]["ItemPrice"].ToString());
				oRow["AveragePrice"] = Convert.ToDecimal(oData.Tables[0].Rows[0]["AveragePrice"].ToString());
				oData.Tables[0].Rows.Add(oRow);
			}
			this.Chart1.DataSource = oData.Tables[0];
			this.Chart1.Series["Default"].ValueMemberX = "Date";
			this.Chart1.Series["Default"].ValueMembersY = "ItemPrice";
			this.Chart1.DataBind();
			if (oData.Tables[0].Rows.Count>0)
			{
				this.Chart1.Titles[0].Text = oData.Tables[0].Rows[0]["ItemName"].ToString()+"  价格走势图";
			}
			else
			{
				this.Chart1.Titles[0].Text = "此物料尚未发生采购业务没有价格信息";
			}
			for (i= 0; i< this.Chart1.Series[0].Points.Count; i++)
			{
				if (oData.Tables[0].Rows[i]["DocCode"].ToString() == "6")
				{
					this.Chart1.Series[0].Points[i].Href= "../Purchase/PBORDetail.aspx?Op=View&EntryNo="+oData.Tables[0].Rows[i]["EntryNo"].ToString();
					this.Chart1.Series[0].Points[i].ToolTip = oData.Tables[0].Rows[i]["PrvName"].ToString();
				}
				else  if (oData.Tables[0].Rows[i]["DocCode"].ToString() == "17")
				{
					this.Chart1.Series[0].Points[i].Href= "../Storage/WINWDetail.aspx?Op=View&EntryNo="+oData.Tables[0].Rows[i]["EntryNo"].ToString();
					this.Chart1.Series[0].Points[i].ToolTip = oData.Tables[0].Rows[i]["PrvName"].ToString();
				}
				this.Chart1.Series[0].Points[i].MapAreaAttributes = "TARGET='_blank'";
			}

			this.MzhDataGrid1.DataSource = oData;
			this.MzhDataGrid1.DataBind();
            //CommonStyle.InitDataGridStyle(this.MzhDataGrid1,false,CommonStyle.StyleScheme.HotMail);
		}
	}
}
