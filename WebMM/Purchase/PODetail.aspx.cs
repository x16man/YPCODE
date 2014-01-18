#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved

/* ---------------------------------------------------------------------*
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
	/// ROSDetail 的摘要说明。
	/// </summary>
	public partial class PODetail : System.Web.UI.Page
	{
		#region 成员变量

	    private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		protected DocWebControl DocWebControl1 = new DocWebControl();//单据台头。
        protected Shmzh.Web.UI.Controls.MzhDataGrid DGModel_Items1 = new Shmzh.Web.UI.Controls.MzhDataGrid();
		
//备注。
		protected System.Web.UI.WebControls.Label lblReqDept;//申请部门。
		protected System.Web.UI.WebControls.Label lblProposer;//申请人。
		protected System.Web.UI.WebControls.Label lblReason;
//用途。
		//private int _EntryNo;//单据流水号，有URL传递进来。

        PurchaseOrderData oPOData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        DataTable oDT;

        private decimal dsumPrice = 0;
		#endregion

		#region 私有方法
		private void BindData()
		{
			
			this.DocWebControl1.DocCode = DocType.PO;
			this.DocWebControl1.DataBindUpdate();
			//将单据填充到数据集,DataGrid绑定数据源。
			oPOData = oPurchaseSystem.GetPOByEntryNo(Master.EntryNo);
			oDT = oPOData.Tables[PurchaseOrderData.PORD_TABLE];
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.PO;
			this.DGModel_Items1.DataSource = oDT;
			this.DGModel_Items1.DataBind();
			if (oDT.Rows.Count > 0)
			{
				//台头部分。
				this.DocWebControl1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.DocWebControl1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.DocWebControl1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//备注。
				this.lblRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				//制单部门。
				this.lblAuthorDept.Text = oDT.Rows[0][InItemData.AUTHORDEPTNAME_FIELD].ToString();
				//制单人。
				this.lblAuthorName.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
                //采购员
			    this.lblBuyer.Text = oDT.Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
				//供货商
				this.lblPrvName.Text = oDT.Rows[0][PurchaseOrderData.PRVNAME_FIELD].ToString();
				this.lblAdd.Text = oDT.Rows[0][PurchaseOrderData.PRVADD_FIELD].ToString();
				this.lblAccount.Text = oDT.Rows[0][PurchaseOrderData.PRVACCOUNT_FIELD].ToString();
				this.lblBank.Text = oDT.Rows[0][PurchaseOrderData.PRVBANK_FIELD].ToString();
				this.lblFax.Text = oDT.Rows[0][PurchaseOrderData.PRVFAX_FIELD].ToString();
				this.lblLicence.Text = oDT.Rows[0][PurchaseOrderData.PRVLICENCE_FIELD].ToString();
				this.lblTaxNo.Text = oDT.Rows[0][PurchaseOrderData.PRVTAXNO_FIELD].ToString();
				this.lblTel.Text = oDT.Rows[0][PurchaseOrderData.PRVTEL_FIELD].ToString();
			}
		}

		#endregion

		#region 事件
		/// <summary>
		/// 页面的Load事件。
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
                dsumPrice = 0;
                e.Item.Cells[7].Visible = Master.DisplayPOPrice;
                e.Item.Cells[8].Visible = Master.DisplayPOPrice;

            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('../Analysis/DocRoute.aspx?EntryNo=" + Master.EntryNo.ToString() + "&DocCode=3&SerialNo=" + e.Item.ItemIndex.ToString() + "&ItemCode=" + e.Item.Cells[0].Text + "','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                try
                {
                    e.Item.Cells[7].Visible = Master.DisplayPOPrice;
                    e.Item.Cells[8].Visible = Master.DisplayPOPrice;
                    dsumPrice += decimal.Parse(e.Item.Cells[8].Text);
                    //e.Item.Cells[11].Text = oPurchaseSystem.GetReqReasonCode(e.Item.Cells[10].Text);
                    var obj = oPurchaseSystem.GetPO_ReqReasonCode(int.Parse(e.Item.Cells[11].Text), int.Parse(e.Item.Cells[12].Text));
                    Logger.Info(string.Format("{0}-{1}",e.Item.Cells[11].Text,e.Item.Cells[12].Text));
                    e.Item.Cells[13].Text = obj;
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message, ex);
                }

                if (e.Item.Cells[10].Text != "&nbsp;" || e.Item.Cells[10].Text != "")
                {
                    try
                    {
                        if (Convert.ToDecimal(e.Item.Cells[10].Text) <= 0)
                        {
                            e.Item.ForeColor = Color.Gray;
                        }
                    }
                    catch { }
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[8].Text = dsumPrice.ToString("n3");
                e.Item.Cells[7].Visible = Master.DisplayPOPrice;
                e.Item.Cells[8].Visible = Master.DisplayPOPrice;
            }
        }
		#endregion

	

		protected void LinkPrint_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("POReport.aspx?EntryNo="+Master.EntryNo.ToString(),true);	
		}
	}
}
