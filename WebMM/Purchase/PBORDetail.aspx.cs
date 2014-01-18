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
	/// ROSInput 的摘要说明。
	/// </summary>
	public partial class PBORDetail : System.Web.UI.Page
	{
		#region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		//private int _EntryNo;
		protected DocWebControl doc1=new DocWebControl();
        protected Shmzh.Web.UI.Controls.MzhDataGrid DGModel_Items1 = new Shmzh.Web.UI.Controls.MzhDataGrid();
		protected StorageDropdownlist ddlPayStyle=new StorageDropdownlist();
		protected DocAuditWebControl DocAuditWebControl1=new DocAuditWebControl();
		
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnCancel;

        BillOfReceiveData oBORData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        DataTable oDT;

        private decimal dsumMoney;

        private decimal dsumMoney1;

		#endregion
		
		#region 私有方法

		/// <summary>
		/// 数据绑定。
		/// </summary>
		private void BindData()
		{
			
			this.doc1.DocCode=DocType.BOR;
			this.doc1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode=DocType.BOR;
			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			//将单据填充到数据集,DataGrid绑定数据源。
			oBORData = oPurchaseSystem.GetBRByEntryNo(Master.EntryNo);
			oDT = oBORData.Tables[BillOfReceiveData.PBOR_TABLE];

			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
			//this.DGModel_Items1.DgStyleScheme = CommonStyle.StyleScheme.Printer;
            this.DGModel_Items1.DataSource = oDT;
			//this.DGModel_Items1.ShowPager = false;
			//this.DGModel_Items1.AllowPaging = false;
			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			this.DGModel_Items1.DataBind();
			
			if (oDT.Rows.Count > 0)
			{
				//台头部分。
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//审批段。
//				this.DocAuditWebControl1.lblAduitName1.Text = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
//				this.DocAuditWebControl1.lblAuditName2.Text = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
//				this.DocAuditWebControl1.lblAuditName3.Text = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
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
                    this.DocAuditWebControl1.txtAuditDate2.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate3.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch
                {
                }

				//人
				this.DocAuditWebControl1.Auditor1=oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
				this.DocAuditWebControl1.Auditor2=oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
				this.DocAuditWebControl1.Auditor3=oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();


				//this.lblAccept.Text = oDT.Rows[0][BillOfReceiveData.ACCEPTNAME_FIELD].ToString();
				this.lblAccept.Text = oDT.Rows[0]["AcceptName"].ToString();
				this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
				this.lblAuthorDept.Text = oDT.Rows[0][InItemData.AUTHORDEPTNAME_FIELD].ToString();

				this.lblBuyer.Text = oDT.Rows[0][BillOfReceiveData.BUYERNAME_FIELD].ToString();
				//this.ddlPayStyle.SetItemSelected(oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString());
				switch (oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString())
				{
					case "G":
						this.lblPayStyle.Text = "付委";
						break;
					case "Q":
						this.lblPayStyle.Text = "现金";
						break;
					case "C":
						this.lblPayStyle.Text = "支票";
						break;
				}
				
				this.ddlPayStyle.Visible = false;
				this.lblProvider.Text = oDT.Rows[0][BillOfReceiveData.PRVNAME_FIELD].ToString();
				this.lblStock.Text = oDT.Rows[0][BillOfReceiveData.STONAME_FIELD].ToString();
				this.lblInvoice.Text = oDT.Rows[0][BillOfReceiveData.INVOICENO_FIELD].ToString();
//				this.lblJFKM.Text = oDT.Rows[0][BillOfReceiveData.JFKM_FIELD].ToString();
				this.lblJFKM.Text = oDT.Rows[0][BillOfReceiveData.CONTRACTCODE_FIELD].ToString();
				//this.lblUsedFor.Text = oDT.Rows[0][BillOfReceiveData.USEDFOR_FIELD].ToString();
				this.lblUsedFor.Text = oDT.Rows[0][BillOfReceiveData.TOTALFEE_FIELD].ToString();
				this.lblChkResult.Text = oDT.Rows[0][BillOfReceiveData.CHKRESULT_FIELD].ToString();
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

			if(!IsPostBack)
			{
				this.BindData();
			}
		}

        
        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                dsumMoney = 0;
                dsumMoney1 = 0;
                e.Item.Cells[9].Visible = Master.DisplayBORPrice ;
                e.Item.Cells[10].Visible = Master.DisplayBORPrice;
                e.Item.Cells[11].Visible = Master.DisplayBORPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    e.Item.Attributes.Add("ondblclick", "window.open('../Analysis/DocRoute.aspx?EntryNo=" + Master.EntryNo.ToString() + "&DocCode=6&SerialNo=" + e.Item.ItemIndex.ToString() + "&ItemCode=" + e.Item.Cells[0].Text + "','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
						
                    dsumMoney += decimal.Parse(e.Item.Cells[10].Text);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                }
                try
                {
                    dsumMoney1 += decimal.Parse(e.Item.Cells[11].Text);
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                }
                e.Item.Cells[9].Visible = Master.DisplayBORPrice;
                e.Item.Cells[10].Visible = Master.DisplayBORPrice;
                e.Item.Cells[11].Visible = Master.DisplayBORPrice;

                //e.Item.Cells[13].Text = oPurchaseSystem.GetReqReasonCodeByBREntryNo(e.Item.Cells[11].Text, e.Item.Cells[12].Text);
                e.Item.Cells[14].Text = oPurchaseSystem.GetBor_ReqReasonCode(int.Parse(e.Item.Cells[12].Text),int.Parse(e.Item.Cells[13].Text));
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                try
                {
                    e.Item.Cells[10].Text = dsumMoney.ToString("n3");
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                }
                try
                {
                    e.Item.Cells[11].Text = dsumMoney1.ToString("n3");
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                }
                e.Item.Cells[9].Visible = Master.DisplayBORPrice;
                e.Item.Cells[10].Visible = Master.DisplayBORPrice;
                e.Item.Cells[11].Visible = Master.DisplayBORPrice;
                 
            }
        }
		#endregion
	}
}