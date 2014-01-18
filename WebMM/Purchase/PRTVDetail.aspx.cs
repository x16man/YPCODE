#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

namespace MZHMM.WebMM.Purchase
{
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
	using MZHMM.WebMM.Modules;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	//using MZHCommon.PageStyle;

	/// <summary>
	/// PRTVDetail 采购退料单的摘要说明。
	/// </summary>
	public partial class PRTVDetail : System.Web.UI.Page
	{
		#region 成员变量
		//private int _EntryNo;
		protected DocWebControl doc1=new DocWebControl();
       // protected Shmzh.Web.UI.Controls.MzhDataGrid DGModel_Items1 = new Shmzh.Web.UI.Controls.MzhDataGrid();
		protected StorageDropdownlist ddlPayStyle=new StorageDropdownlist();
		protected StorageDropdownlist ddlCurrency=new StorageDropdownlist();
		protected DocAuditWebControl DocAuditWebControl1=new DocAuditWebControl();
		
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnCancel;

        PRTVData oPRTVData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

	    private string ps;
	    private string cu;

        DataTable oDT;

        private decimal dsumMoney = 0;
		#endregion
		
		#region 私有方法
		/// <summary>
		/// 编辑数据状态下，数据绑定。
		/// </summary>
		private void BindData()
		{
			
			this.doc1.DocCode=DocType.RTV;
			this.doc1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode=DocType.RTV;
			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			this.ddlPayStyle.Width = new Unit(0);
			this.ddlCurrency.Module_Tag = (int)SDDLTYPE.CURRENCY;
            this.ddlCurrency.Width = new Unit(0);
			//将单据填充到数据集,DataGrid绑定数据源。
			oPRTVData = oPurchaseSystem.GetPRTVByEntryNo(Master.EntryNo);
			oDT = oPRTVData.Tables[PRTVData.PRTV_TABLE];

			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.RTV;
			//this.DGModel_Items1.DgStyleScheme = CommonStyle.StyleScheme.Printer;
			this.DGModel_Items1.DataSource = oDT;
			//this.DGModel_Items1.ShowPager = false;
			this.DGModel_Items1.DataBind();
			this.HyperLink1.Text = "采购收料单"+oDT.Rows[0][PRTVData.SOURCEENTRY_FIELD].ToString()+"号";
			this.HyperLink1.NavigateUrl="PBorDetail.aspx?EntryNo="+oDT.Rows[0][PRTVData.SOURCEENTRY_FIELD].ToString()+"&Op=View";
			
			if (oDT.Rows.Count > 0)
			{
				//台头部分。
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//审批段。
				if (oDT.Rows[0][InItemData.AUDIT1_FIELD] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y"? 0:1;
				}
				if (oDT.Rows[0][InItemData.AUDIT2_FIELD] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y"? 0:1;
				}
				if(oDT.Rows[0][InItemData.AUDIT3_FIELD] != System.DBNull.Value)
				{
					this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y"? 0:1;
				}
				this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString();
				this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][InItemData.AUDITSUGGEST2_FIELD].ToString();
				this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][InItemData.AUDITSUGGEST3_FIELD].ToString();
                try
                {
                    this.DocAuditWebControl1.txtAuditDate1.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }
                try
                {
                    this.DocAuditWebControl1.txtAuditDate2.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }
                try
                {
                    this.DocAuditWebControl1.txtAuditDate3.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }

				//人
				this.DocAuditWebControl1.Auditor1=oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
				this.DocAuditWebControl1.Auditor2=oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
				this.DocAuditWebControl1.Auditor3=oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
				


				//采购员。
				this.lblBuyer.Text = oDT.Rows[0][PRTVData.BUYERNAME_FIELD].ToString();

				//付款方式
				this.ddlPayStyle.SetItemSelected(oDT.Rows[0][PRTVData.PAYSTYLE_FIELD].ToString());
				this.ddlPayStyle.SelectedValue = oDT.Rows[0][PRTVData.PAYSTYLE_FIELD].ToString();
				ps = oDT.Rows[0][PRTVData.PAYSTYLE_FIELD].ToString();
				cu = oDT.Rows[0][PRTVData.CURRENCYCODE_FIELD].ToString();
				this.ddlCurrency.SetItemSelected(oDT.Rows[0][PRTVData.CURRENCYCODE_FIELD].ToString());
				this.ddlCurrency.SelectedValue = oDT.Rows[0][PRTVData.CURRENCYCODE_FIELD].ToString();
	

				this.lblPayStyle.Text = this.ddlPayStyle.SelectedText;
				this.lblCurrency.Text = this.ddlCurrency.SelectedText;

				//供应商。
				this.lblProvider.Text = oDT.Rows[0][PRTVData.PRVNAME_FIELD].ToString();
				//仓库。
                this.lblStock.Text = oDT.Rows[0][PRTVData.STONAME_FIELD].ToString();


				this.lblChkResult.Text = oDT.Rows[0][PRTVData.CHKRESULT_FIELD].ToString();
				this.lblInvoice.Text = oDT.Rows[0][PRTVData.INVOICENO_FIELD].ToString();
				this.lblJFKM.Text = oDT.Rows[0][PRTVData.JFKM_FIELD].ToString();
				this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
				this.lblAuthorDept.Text = oDT.Rows[0][InItemData.AUTHORDEPTNAME_FIELD].ToString();
				
			}
		}
		#endregion
		
		
		
		#region 事件
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			
			if(!this.IsPostBack)
			{
				this.BindData();
			}
		}

       

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Header)
            {
                dsumMoney = 0;
                e.Item.Cells[9].Visible = Master.DisplayPRTVPrice;
                e.Item.Cells[6].Visible = Master.DisplayPRTVPrice;
                
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                   // e.Item.Attributes.Add("ondblclick", "window.open('../Analysis/DocRoute.aspx?EntryNo=" + Master.EntryNo.ToString() + "&DocCode=8&SerialNo=" + e.Item.ItemIndex.ToString() + "&ItemCode=" + e.Item.Cells[0].Text + "','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");

                    e.Item.Cells[9].Visible = Master.DisplayPRTVPrice;
                    e.Item.Cells[6].Visible = Master.DisplayPRTVPrice;
                    dsumMoney += decimal.Parse(e.Item.Cells[9].Text);

                   
                }
                catch
                {
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[9].Visible = Master.DisplayPRTVPrice;
                e.Item.Cells[6].Visible = Master.DisplayPRTVPrice;
                if (!Master.DisplayPRTVPrice)
                    e.Item.Cells[8].Text = "";
                try
                {
                    e.Item.Cells[9].Text = dsumMoney.ToString("n3");
                }
                catch { }
            }
        }

       


		#endregion
	}
}