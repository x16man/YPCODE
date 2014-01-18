using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MZHMM.WebMM.Modules;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
//using MZHCommon.PageStyle;
using System.Data;

namespace WebMM.Purchase
{
    public partial class PBORUpdateInvoice : System.Web.UI.Page
    {
        #region 成员变量
      
        BillOfReceiveData oBORData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        DataTable oDT;
        private decimal SubTotalItemMoney;
        private decimal SubTotalItemSum;
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
			//this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			//将单据填充到数据集,DataGrid绑定数据源。
			oBORData = oPurchaseSystem.GetBRByEntryNo(Master.EntryNo);
			oDT = oBORData.Tables[BillOfReceiveData.PBOR_TABLE];

			

            if (oDT.Rows.Count > 0)
            {
                if (oDT.Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.TrdPass && oDT.Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() != DocStatus.Received)
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "aa", "alert(\"收料单未审批通过！\");window.close();", true);
                    return;
                }
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
                    this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y" ? 0 : 1;
                }
                if (oDT.Rows[0][InItemData.AUDIT2_FIELD] != System.DBNull.Value)
                {
                    this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y" ? 0 : 1;
                }
                if (oDT.Rows[0][InItemData.AUDIT3_FIELD] != System.DBNull.Value)
                {
                    this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y" ? 0 : 1;
                }
                this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString();
                this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][InItemData.AUDITSUGGEST2_FIELD].ToString();
                this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][InItemData.AUDITSUGGEST3_FIELD].ToString();
                this.DocAuditWebControl1.txtAuditDate1.Text = oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString();
                this.DocAuditWebControl1.txtAuditDate2.Text = oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString();
                this.DocAuditWebControl1.txtAuditDate3.Text = oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString();

                //人
                this.DocAuditWebControl1.Auditor1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.Auditor2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.Auditor3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();


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

                //this.ddlPayStyle.Visible = false;
                this.lblProvider.Text = oDT.Rows[0][BillOfReceiveData.PRVNAME_FIELD].ToString();
                this.lblStock.Text = oDT.Rows[0][BillOfReceiveData.STONAME_FIELD].ToString();
                this.txtInvoice.Text = oDT.Rows[0][BillOfReceiveData.INVOICENO_FIELD].ToString();
                //				this.lblJFKM.Text = oDT.Rows[0][BillOfReceiveData.JFKM_FIELD].ToString();
                this.lblJFKM.Text = oDT.Rows[0][BillOfReceiveData.CONTRACTCODE_FIELD].ToString();
                //this.lblUsedFor.Text = oDT.Rows[0][BillOfReceiveData.USEDFOR_FIELD].ToString();
                this.lblUsedFor.Text = oDT.Rows[0][BillOfReceiveData.TOTALFEE_FIELD].ToString();
                this.lblChkResult.Text = oDT.Rows[0][BillOfReceiveData.CHKRESULT_FIELD].ToString();
            }
            else
            {
            }

            //this.DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
            this.DGModel_Items1.DataSource = oDT;
            //this.DGModel_Items1.ShowPager = false;
            this.DGModel_Items1.AllowPaging = false;
            //DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
            this.DGModel_Items1.DataBind();
		}
		#endregion
		

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
			{
				
						

				this.BindData();
			}
        }


        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                SubTotalItemMoney = 0;
                SubTotalItemSum = 0;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    SubTotalItemMoney += decimal.Parse(e.Item.Cells[7].Text);
                }
                catch
                {
                    SubTotalItemMoney += 0;
                }

                try
                {
                    SubTotalItemSum += decimal.Parse(e.Item.Cells[8].Text);
                }
                catch
                {
                    SubTotalItemSum += 0;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[7].Text = SubTotalItemMoney.ToString();
                e.Item.Cells[8].Text = SubTotalItemSum.ToString();
            }
        }


        private bool Check()
        {
            if (txtInvoice.Text != "")
            {
                if (txtInvoice.Text.IndexOf("，") > 0)
                    return false;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    oPurchaseSystem.BRInvoiceUpdate(Master.EntryNo, Master.GetNoSpaceString(this.txtInvoice.Text));
                    ClientScript.RegisterStartupScript(this.GetType(), "aa", "alert(\"收料单发票号修改成功，如有需要请稍候修改相应的材料付款单的发票号！\");window.close();", true);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "aa", "alert(\"" + ex.Message + "\");", true);
                    return;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript( this.GetType(), "aa", "alert(\"收料单发票号不能为空或者有中文逗号！\");", true);
                return;
            }
        }
    }
}
