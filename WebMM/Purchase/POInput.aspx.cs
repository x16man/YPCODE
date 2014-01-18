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
	using Shmzh.Components.SystemComponent;
	using MZHMM.WebMM.Modules;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using MZHCommon.Database;
    using SysRight = MZHMM.WebMM.Common.SysRight;
    using Shmzh.Components.SystemComponent.SQLServerDAL;
    using System.Collections.Generic;
	/// <summary>
	/// MRPInput 的摘要说明。
	/// </summary>
	public partial class POInput : System.Web.UI.Page
	{
		#region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private string _OP;
	//	private bool IsTODO;
		protected DocWebControl doc1=new DocWebControl();
		protected DocAuditWebControl DocAuditWebControl1;
		protected POWebControl item1=new POWebControl();
		//protected StorageDropdownlist ddlCurrency = new StorageDropdownlist();
		//public    POSBrowser fp;
		//protected int _EntryNo;
		//protected User myUser;
		//protected MagicAjax.UI.Controls.AjaxPanel AjaxPanel1;
		protected System.Web.UI.WebControls.TextBox txtAuthorName;
		protected System.Web.UI.WebControls.TextBox txtAuthorDeptName;
		
		//protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";
		protected StorageDropdownlist ddlPayStyle;
		protected StorageDropdownlist ddlStoManager;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
       // PurchaseOrderData oPOData;
	    private POSData oPOSData = new POSData();

	    private DataRow oDataRow;
	    private PurchaseOrderData oPOdata = new PurchaseOrderData();
	    //private int i;
        //DataTable oDT;

	    private DataRow dr;


	    private bool ret;

        private Grant grant = new Grant();

        private IList<GrantInfo> grantlist;

	    private Col2List MyCol2List;

        private int ParentEntryNo
        {
            get
            {
                if (ViewState["ParentEntryNo"] != null && ViewState["ParentEntryNo"].ToString() != "")
                    return Int32.Parse(ViewState["ParentEntryNo"].ToString());
                else
                    return 0;
            }
            set
            {
                ViewState["ParentEntryNo"] = value.ToString();
            }
        }
#endregion

		#region 私有方法
		/// <summary>
		/// 新增单据状态下，数据绑定。
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.PO;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.PO;
			
			this.ddlStoManager.Module_Tag = (int)SDDLTYPE.PSLP;
			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			
			//购方绑定
			this.PscBindData();
			this.item1.thisTable = oPOSData.Tables[POSData.VPOS_VIEW];

		}
        private void BindDataCopy()
        {
            this.doc1.DocCode = DocType.PO;
            this.doc1.DataBindNew();
            this.DocAuditWebControl1.DocCode = DocType.PO;
            this.ddlStoManager.Module_Tag = (int)SDDLTYPE.PSLP;
            this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
            //购方绑定
            this.PscBindData();

            PurchaseOrderData oPOData;
            oPOData = oPurchaseSystem.GetPOByEntryNo(Master.EntryNo);
            var oDT = oPOData.Tables[PurchaseOrderData.PORD_TABLE];
            for (var i = 0; i < oDT.Rows.Count - 1; i++)
            {
                oDT.Rows[i]["SourceEntry"] = DBNull.Value;
                oDT.Rows[i]["SourceDocCode"] = DBNull.Value;
                oDT.Rows[i]["SourceSerialNo"] = DBNull.Value;
                oDT.Rows[i]["ItemLackNum"]=DBNull.Value;
            }
                this.item1.thisTable = oDT;
            if (oDT.Rows.Count > 0)
            {
                //采购员。
                this.ddlStoManager.SelectedText = oDT.Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
                this.ddlStoManager.SelectedValue = oDT.Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
                //备注。
                this.item1.txtRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //付款方式。
                if (_OP != OP.Copy)
                {
                    this.ddlPayStyle.SetItemSelected(oDT.Rows[0][PPRNData.PAYSTYLE_FIELD].ToString());
                    this.ddlPayStyle.SelectedValue = oDT.Rows[0][PPRNData.PAYSTYLE_FIELD].ToString();
                }
                //供货商。
                this.txtVendorCode.Value = oDT.Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString();
                this.txtVendor.Text = oDT.Rows[0][PurchaseOrderData.PRVNAME_FIELD].ToString();
                this.txtTel.Text = oDT.Rows[0][PurchaseOrderData.PRVTEL_FIELD].ToString();
                this.txtFax.Value = oDT.Rows[0][PurchaseOrderData.PRVFAX_FIELD].ToString();
                this.txtAccount.Text = oDT.Rows[0][PurchaseOrderData.PRVACCOUNT_FIELD].ToString();
                this.txtAdd.Text = oDT.Rows[0][PurchaseOrderData.PRVADD_FIELD].ToString();
                this.txtBank.Value = oDT.Rows[0][PurchaseOrderData.PRVBANK_FIELD].ToString();
                this.txtCurrency.Value = oDT.Rows[0][PurchaseOrderData.CURRENCYCODE_FIELD].ToString();
                this.TxtPayment.Text = oDT.Rows[0][PurchaseOrderData.PAYMENT_FIELD].ToString();
                this.txtZip.Value = oDT.Rows[0][PurchaseOrderData.PRVZIP_FIELD].ToString();

                //付款条款
                this.TxtPayment.Text = oDT.Rows[0][PurchaseOrderData.PAYMENT_FIELD].ToString();
                this.ddlStoManager.SelectedValue = oDT.Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
                
            }
        }
        /// <summary>
        /// 编辑数据状态下，数据绑定。
        /// </summary>
        private void BindDataUpdate()
        {
            //购方绑定
            this.PscBindData();
            this.DocAuditWebControl1.DocCode = DocType.PO;

            PurchaseOrderData oPOData;

            this.doc1.DocCode = DocType.PO;
            this.doc1.DataBindUpdate();
            this.ddlStoManager.Module_Tag = (int)SDDLTYPE.PSLP;
            this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
            //将单据填充到数据集,DataGrid绑定数据源。
            if (this._OP != OP.Red)
            {
                oPOData = oPurchaseSystem.GetPOByEntryNo(Master.EntryNo);
            }
            else
            {
                oPOData = oPurchaseSystem.GetPORepealEntryNo(Master.EntryNo);
            }
            //检查操作的前提条件。
            this.CheckOpPrecondition(this._OP, oPOData);

            var oDT = oPOData.Tables[PurchaseOrderData.PORD_TABLE];

            //把数量和金额变为负数
            if (this._OP == OP.Red)
            {
                for (int i = 0; i < oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows.Count; i++)
                {
                    oDT.Rows[i][InItemData.ITEMNUM_FIELD] = "-" + oDT.Rows[i][InItemData.ITEMNUM_FIELD].ToString();
                    oDT.Rows[i][InItemData.ITEMMONEY_FIELD] = "-" + oDT.Rows[i][InItemData.ITEMMONEY_FIELD].ToString();

                }
            }
            this.item1.thisTable = oDT;

            if (oDT.Rows.Count > 0)
            {
                //台头部分。
                this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
                this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
                this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
                //采购员。
                this.ddlStoManager.SelectedText = oDT.Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
                this.ddlStoManager.SelectedValue = oDT.Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
                //备注。
                this.item1.txtRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //付款方式。
                if (_OP != OP.New)
                {
                    this.ddlPayStyle.SetItemSelected(oDT.Rows[0][PPRNData.PAYSTYLE_FIELD].ToString());
                    this.ddlPayStyle.SelectedValue = oDT.Rows[0][PPRNData.PAYSTYLE_FIELD].ToString();
                }
                //供货商。
                this.txtVendorCode.Value = oDT.Rows[0][PurchaseOrderData.PRVCODE_FIELD].ToString();
                this.txtVendor.Text = oDT.Rows[0][PurchaseOrderData.PRVNAME_FIELD].ToString();
                this.txtTel.Text = oDT.Rows[0][PurchaseOrderData.PRVTEL_FIELD].ToString();
                this.txtFax.Value = oDT.Rows[0][PurchaseOrderData.PRVFAX_FIELD].ToString();
                this.txtAccount.Text = oDT.Rows[0][PurchaseOrderData.PRVACCOUNT_FIELD].ToString();
                this.txtAdd.Text = oDT.Rows[0][PurchaseOrderData.PRVADD_FIELD].ToString();
                this.txtBank.Value = oDT.Rows[0][PurchaseOrderData.PRVBANK_FIELD].ToString();
                this.txtCurrency.Value = oDT.Rows[0][PurchaseOrderData.CURRENCYCODE_FIELD].ToString();
                this.TxtPayment.Text = oDT.Rows[0][PurchaseOrderData.PAYMENT_FIELD].ToString();
                this.txtZip.Value = oDT.Rows[0][PurchaseOrderData.PRVZIP_FIELD].ToString();

                //付款条款
                this.TxtPayment.Text = oDT.Rows[0][PurchaseOrderData.PAYMENT_FIELD].ToString();
                this.ddlStoManager.SelectedValue = oDT.Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
                //审批段。
                //为撤消单并且不是采购员确认的时候
                if (this._OP != OP.Red)
                {
                    if (((oDT.Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString() != ""
                        || oDT.Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString() != "0")
                        && (this._OP == OP.Affirm))
                        || ((oDT.Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString() == ""
                        || oDT.Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString() == "0")))
                    {
                        this.DocAuditWebControl1.AuditName1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                        this.DocAuditWebControl1.AuditName2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                        this.DocAuditWebControl1.AuditName3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
                        if (oDT.Rows[0][InItemData.AUDIT1_FIELD] != DBNull.Value)
                        {
                            this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y" ? 0 : 1;
                        }
                        if (oDT.Rows[0][InItemData.AUDIT2_FIELD] != DBNull.Value)
                        {
                            this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y" ? 0 : 1;
                        }
                        if (oDT.Rows[0][InItemData.AUDIT3_FIELD] != DBNull.Value)
                        {
                            this.DocAuditWebControl1.rblAudit3.SelectedIndex = oDT.Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y" ? 0 : 1;
                        }
                        this.DocAuditWebControl1.txtAuditSuggest1.Text = oDT.Rows[0][InItemData.AUDITSUGGEST1_FIELD].ToString();
                        this.DocAuditWebControl1.txtAuditSuggest2.Text = oDT.Rows[0][InItemData.AUDITSUGGEST2_FIELD].ToString();
                        this.DocAuditWebControl1.txtAuditSuggest3.Text = oDT.Rows[0][InItemData.AUDITSUGGEST3_FIELD].ToString();
                        try
                        {
                            this.DocAuditWebControl1.txtAuditDate1.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString()).ToString("yyyy-MM-dd");
                            this.DocAuditWebControl1.txtAuditDate2.Text = oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString();
                            this.DocAuditWebControl1.txtAuditDate3.Text = oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString();
                        }
                        catch(Exception )
                        {
                            
                        }
                    }
                }


                if (oDT.Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString() != "")
                {
                    this.ParentEntryNo = Int32.Parse(oDT.Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString());
                }

                this.CancelControl(oDT.Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString());

            }


        }
		/// <summary>
		/// 设置指定下拉列表的选中项。
		/// </summary>
		/// <param name="List">DropDownList：下拉列表。</param>
		/// <param name="TargetValue">string:	指定值。</param>
		private void SetSelectedItem(DropDownList List ,string TargetValue)
		{
			for (var i=0;i<List.Items.Count;i++)			
			{
				if (List.Items[i].Value == TargetValue)
				{
					List.Items[i].Selected = true;
					List.SelectedIndex = i;
					List.SelectedValue = List.Items[i].Value;
					break;
				}
			}
		}
		/// <summary>
		/// 购方参数绑定
		/// </summary>
		private void PscBindData()
		{
			PPRNData oPPRNData = (new PurchaseSystem()).GetPPRNSelf();
			this.lblPscCode.Text = oPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString();
			this.lblPscName.Text = oPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CNNAME_FIELD].ToString();
		}
		/// <summary>
		/// 设置单据状态。
		/// </summary>
		/// <param name="oPOData">PurchaseOrderData:	采购订单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryState(PurchaseOrderData oPOData, string OpMode)
		{
			if ( oPOData.Count > 0)
			{
				oDataRow = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oPOData.Tables[PurchaseOrderData.PORD_TABLE]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// 设置单据操作人。
		/// </summary>
		/// <param name="oPOData">PurchaseOrderData:	采购订单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetOperator(PurchaseOrderData oPOData, string OpMode)
		{
			if ( oPOData.Count > 0)
			{
				DataRow oDataRow = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];

				switch (OpMode)
				{
					case OP.New://新建。
                    case OP.Copy://复制
						oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.NewAndPresent://新建并且提交。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.NewAndAssign://新建并且指派。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.Edit://编辑。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.EditAndPresent://编辑并且提交。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.EditAndAssign:
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
					case OP.FirstAudit://一级审批。
                        oDataRow[InItemData.ASSESSOR1_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.SecondAudit://二级审批。
                        oDataRow[InItemData.ASSESSOR2_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
					case OP.ThirdAudit://三级审批。
                        oDataRow[InItemData.ASSESSOR3_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
				}
			}
		}

		/// <summary>
		/// 填充数据集。
		/// </summary>
		/// <param name="oPOdata">PurchaseOrderData:	采购订单实体。</param>
		private void FillData(PurchaseOrderData oPOdata)
		{
			dr = oPOdata.Tables[PurchaseOrderData.PORD_TABLE].NewRow();
			//单据台头部分内容。
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//单据流水号。
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//单据编号。
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//单据类型。
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//单据类型名称。
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//单据文档编号。
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//单据日期。

			//dr[PurchaseOrderData.PRVCODE_FIELD] = ddlPrv.SelectedValue;			    //供货商
            dr[PurchaseOrderData.PRVCODE_FIELD] = this.txtVendorCode.Value;
			dr[PurchaseOrderData.PRVNAME_FIELD] = this.txtVendor.Text;
			dr[PurchaseOrderData.PRVADD_FIELD] = this.txtAdd.Text;                       //供货商地址。
            dr[PurchaseOrderData.PRVZIP_FIELD] = this.txtZip.Value;                  //邮编。
			dr[PurchaseOrderData.PRVTEL_FIELD] = this.txtTel.Text;                  //电话。
            dr[PurchaseOrderData.PRVFAX_FIELD] = this.txtFax.Value;                  //传真。
			//dr[PurchaseOrderData.PRVLICENCE_FIELD] = this.txtLicence.Text;          //营业执照号。
            dr[PurchaseOrderData.PRVBANK_FIELD] = this.txtBank.Value;                //开户银行。
			dr[PurchaseOrderData.PRVACCOUNT_FIELD] = this.txtAccount.Text;          //开户帐户。
            dr[PurchaseOrderData.PRVTAXNO_FIELD] = this.txtTaxNo.Value;              //税务登记号。
			//dr[PurchaseOrderData.CURRENCYCODE_FIELD] = this.ddlCurrency.SelectedValue; //币种。
            dr[PurchaseOrderData.CURRENCYCODE_FIELD] = this.txtCurrency.Value;
			dr[PurchaseOrderData.PAYSTYLE_FIELD] = this.ddlPayStyle.SelectedValue;  //付款方式。
			dr[PurchaseOrderData.PAYMENT_FIELD] = this.TxtPayment.Text;             //付款条款。

			dr[InItemData.REMARK_FIELD] = this.item1.txtRemark.Text;				//备注。
			dr[PurchaseOrderData.BUYERNAME_FIELD] = ddlStoManager.SelectedText;		//采购员名称。
			dr[PurchaseOrderData.BUYERCODE_FIELD] = ddlStoManager.SelectedValue;	//采购员编号。
			dr[PurchaseOrderData.PSCCODE_FIELD] = this.lblPscCode.Text;             //购方编号。
			dr[PurchaseOrderData.PSCNAME_FIELD] = this.lblPscName.Text;              //购方名称。
			//审批段。
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。
			
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。
			//子项明细。
			MyCol2List = new Col2List(this.item1.thisTable);
			dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();
			dr[PurchaseOrderData.SOURCEENTRY_FIELD] = MyCol2List.GetList(PurchaseOrderData.SOURCEENTRY_FIELD);
			dr[PurchaseOrderData.SOURCEDOCCODE_FIELD]= MyCol2List.GetList(PurchaseOrderData.SOURCEDOCCODE_FIELD);
			dr[PurchaseOrderData.SOURCESERIALNO_FIELD] = MyCol2List.GetList(PurchaseOrderData.SOURCESERIALNO_FIELD);
		    
            dr[InItemData.NEWCODE_FIELD] = MyCol2List.GetList(InItemData.NEWCODE_FIELD);
			dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);
			dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);
			dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);
			dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);
			dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);
			dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);
			dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
			dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);//合计金额。

            if (this._OP == OP.Red)
            {
                dr[InItemData.Parent_EntryNo] = Request["EntryNo"].ToString();
            }
            else if (this.ParentEntryNo.ToString() != "0")
            {
                dr[InItemData.Parent_EntryNo] = this.ParentEntryNo.ToString();
            }
            else
            {
                dr[InItemData.Parent_EntryNo] = "0";
            }
			oPOdata.Tables[PurchaseOrderData.PORD_TABLE].Rows.Add(dr);
		}
		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="OpMode">string:	操作模式。</param>
        /// <param name="oPOData">PurchasePlanData:	物料需求单实体。</param>
		private void CheckOpPrecondition(string OpMode,PurchaseOrderData oPOData)
		{
			switch (OpMode)
			{
				case OP.Edit://编辑。
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject )
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XUpdate, true); }
					break;
				case OP.Assigned://提交。
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XAssign, true); }
					break;
				case OP.FirstAudit://一级审批。
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Assigned)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XFirstAudit, true); }
					break;
				case OP.SecondAudit://二级审批。
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
					{	return ;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XSecondAudit, true); }
					break;
				case OP.ThirdAudit://三级审批。
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XThirdAudit, true); }
					break;
				case OP.Affirm://采购员确认。
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdPass) 
					{
                        if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString() == Master.CurrentUser.thisUserInfo.EmpCode)
						{
							return;	
						}
						else
						{
                            grantlist = grant.GetAllAvalibleByGrantor(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString());
                            for (var i = 0; i < grantlist.Count; i++)
							{
                                if (grantlist[i].Embracer == Master.CurrentUser.thisUserInfo.EmpCode)
								{
									return;
								}
							}
							Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XConfirm,true);	
						}
					}
					else
					{
                        Response.Redirect("../Common//ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XConfirm, true);	
					}
					break;
                case OP.Red:
                    //string strState= oPOData.Tables[PurchaseOrderData.
                    if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows.Count > 0)
                    {

                        var strParentvalue = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString();

                        if (strParentvalue != "" && strParentvalue != "0")
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=此订单已是采购订单红字,不能再次冲红字!", true);
                        }
                        //如果当前用户与被红冲的采购订单的制单用户不是同一个人，则不允许进行操作。
                        if ((this.Session["User"] as Shmzh.Components.SystemComponent.User).thisUserInfo.LoginName != oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString())
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=此订单为别人的采购订单，您无权进行红冲！!", true);
                            return;
                        }
                        var strState = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();


                        if (strState == "E")//为E确认T为审核通过。
                        {
                            return;
                        }
                        else
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=只有采购确认后的状态才能撤消，如果是之前的节点，可以通过拒绝或审批不通过的方式来退回。", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=只有欠缺数量大于0的订单才能撤消", true);
                    }


                    break;
			}
		}
		#endregion
		
		#region 事件
		/// <summary>
		/// 页面的Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.PO;
			// 在此处放置用户代码以初始化页面
			_OP = Request["Op"];
            txtVendor.Attributes.Add("ReadOnly", "ReadOnly");
            txtAdd.Attributes.Add("ReadOnly", "ReadOnly");
            txtAccount.Attributes.Add("ReadOnly", "ReadOnly");
            txtTel.Attributes.Add("ReadOnly", "ReadOnly");
			
//			this.ddlPrv.AutoPostBack = true;

            item1.IsDisplayPOPrice = Master.DisplayPOPrice;

			if(!this.IsPostBack)
			{
				switch (_OP)
				{
					case OP.New:
						if (!Master.HasBrowseRight(SysRight.POMaintain))
						{	
							return;
						}
						this.BindDataNew();
						this.btnSave.Text = OPName.New;
						this.btnPresent.Visible = true;
						break;
                    case OP.Copy:
                        if (!Master.HasBrowseRight(SysRight.POMaintain))
						{	
							return;
						}
                        this.BindDataCopy();
						this.btnSave.Text = OPName.New;
						this.btnPresent.Visible = true;
                        break;
					case OP.Edit:
                        if (!Master.HasBrowseRight(SysRight.POMaintain))
						{	
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Edit;
						this.btnPresent.Visible = true;
						break;
					case OP.Submit:
                        if (!Master.HasBrowseRight(SysRight.POPresent))
						{	
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Submit;
						this.btnPresent.Visible = false;
						break;
					case OP.Assigned:
                        if (!Master.HasBrowseRight(SysRight.POAssign))
						{	
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Assigned;
						this.btnPresent.Visible = false;
						break;
					case OP.Affirm:
                        if (!Master.HasBrowseRight(SysRight.POConfirm))
						{	
							return;
						}
						this.BindDataUpdate();
                        
                        this.btnSave.Text = OPName.Affirm;
                        this.btnPresent.Text = OPName.Reject;
                        this.Image1.Visible = false;
                        this.ddlPayStyle.Enable = false;
                        this.ddlStoManager.Enable = false;
                        TxtPayment.Attributes.Add("ReadOnly", "ReadOnly");
						break;
					case OP.FirstAudit:
                        if (!Master.HasBrowseRight(SysRight.POFirstAudit))
						{	
							return;
						}
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.FirstAudit;
                        this.btnPresent.Visible = false;
                        this.Image1.Visible = false;
                        this.ddlPayStyle.Enable = false;
                        this.ddlStoManager.Enable = false;
                        TxtPayment.Attributes.Add("ReadOnly", "ReadOnly");
						break;
					case OP.SecondAudit:
                        if (!Master.HasBrowseRight(SysRight.POSecondAudit))
						{	
							return;
						}
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.SecondAudit;
                        this.btnPresent.Visible = false;
                        TxtPayment.Attributes.Add("ReadOnly", "ReadOnly");
					    break;
					case OP.ThirdAudit:
                        if (!Master.HasBrowseRight(SysRight.POThirdAudit))
						{	
							return;
						}
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.ThirdAudit;
                        this.btnPresent.Visible = false;
                        TxtPayment.Attributes.Add("ReadOnly", "ReadOnly");
					    break;
                    case OP.Red://撤消
                        if (!Master.HasBrowseRight(SysRight.POCancelOpera))
                        {
                            return;
                        }

                        this.BindDataUpdate();
                        this.btnSave.Text = "保存";
                        this.btnPresent.Visible = true;
                        TxtPayment.Attributes.Add("ReadOnly", "ReadOnly");
                        break;
				}

			}
			//供货商选择变化时，重新绑定供货商。
//			if(this.IsPostBack)
//			{
//				if(ddlPrv.SelectedValue != "") PrvBindData(ddlPrv.SelectedValue);
//			}

		}
		
        /// <summary>
		/// 保存按钮。
		/// </summary>
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			//没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

			//构建数据实体.
		    oPOdata = new PurchaseOrderData();
			//填充数据集。
			this.FillData(oPOdata);
			//设置单据状态。
			this.SetEntryState(oPOdata,this._OP);
			//设置操作人。
			this.SetOperator(oPOdata,this._OP);

			oPurchaseSystem=new PurchaseSystem();
			
			ret = true;
			switch (this._OP)
			{
				case OP.New:
                case OP.Copy:
					if (Master.HasRight(SysRight.POMaintain))
					{
						ret = oPurchaseSystem.AddPO(oPOdata);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Edit:
					if (Master.HasRight(SysRight.POMaintain))
					{
						ret = oPurchaseSystem.UpdatePO(oPOdata);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Submit:
                    if (Master.HasRight(SysRight.POPresent))
					{
						//ret = oPurchaseSystem.PresentPO(this.doc1.EntryNo,Session[MySession.UserLoginId].ToString());
						//设置单据状态。
						this.SetEntryState(oPOdata,OP.NewAndAssign);
						//设置操作人。
						this.SetOperator(oPOdata,OP.NewAndAssign);

						ret = oPurchaseSystem.UpdateAndPresentPO(oPOdata);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Assigned:
                    if (Master.HasRight(SysRight.POPresent))
					{
						//设置单据状态。
						this.SetEntryState(oPOdata,OP.NewAndAssign);
						//设置操作人。
						this.SetOperator(oPOdata,OP.NewAndAssign);
						//ret = oPurchaseSystem.PresentPO(this.doc1.EntryNo,Session[MySession.UserLoginId].ToString());
						ret = oPurchaseSystem.UpdateAndPresentPO(oPOdata);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Affirm:
                    if (Master.HasRight(SysRight.POConfirm))
					{
                        ret = oPurchaseSystem.AffirmPO(this.doc1.EntryNo, DocStatus.OrdExec, Master.CurrentUser.thisUserInfo.LoginName);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.FirstAudit:
                    if (Master.HasRight(SysRight.POFirstAudit))
					{
                        if (oPOdata.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
                           oPOdata.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('请确认审批通过或是不通过!');", true);
                            return;
                        }
						ret = oPurchaseSystem.FirstAuditPO(oPOdata);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.SecondAudit:
                    if (Master.HasRight(SysRight.POSecondAudit))
					{
						ret = oPurchaseSystem.SecondAuditPO(oPOdata);
					}
					else
					{
						ret = false;
					}
					break;
				case OP.ThirdAudit:
                    if (Master.HasRight(SysRight.POSecondAudit))
					{
						ret = oPurchaseSystem.ThirdAuditPO(oPOdata);
					}
					else
					{
						ret = false;
					}
					break;
                case OP.Red:
                    if (Master.HasRight(SysRight.POCancelOpera))
                    {

                        ret = oPurchaseSystem.AddPO(oPOdata);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
			}
					
			if ( ret== false)
			{
				Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
			}
			else
			{
				if (Master.IsTODO)
				{
					this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
				}
				else
				{
					Response.Redirect("POBrowser.aspx?DocCode=3");
				}
				
			}
			
		}
		
        /// <summary>
		/// 取消按钮事件。
		/// </summary>
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (Master.IsTODO)
			{
				this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
			}
			else
			{
				Response.Redirect("POBrowser.aspx?DocCode=3");
			}
		}
		
        /// <summary>
		/// 马上指派事件。
		/// </summary>
		protected void btnPresent_Click(object sender, System.EventArgs e)
		{
			//没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }
			//构建数据实体.
			oPOdata = new PurchaseOrderData();
			//填充数据集。
			this.FillData(oPOdata);
			oPurchaseSystem=new PurchaseSystem();
		
			ret = true;
			switch (this._OP)
			{
				case OP.New:
                case OP.Copy:
					if (Master.HasRight(SysRight.POMaintain) && Master.HasRight(SysRight.POAssign))
					{
						this._OP = OP.NewAndAssign;
						//设置单据状态。
						this.SetEntryState(oPOdata,this._OP);
						//设置操作人。
						this.SetOperator(oPOdata,this._OP);
						ret = oPurchaseSystem.AddAndPresentPO(oPOdata);
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.Edit:
                    if (Master.HasRight(SysRight.POMaintain) && Master.HasRight(SysRight.POAssign))
					{
						this._OP = OP.NewAndAssign;
						//设置单据状态。
						this.SetEntryState(oPOdata,this._OP);
						//设置操作人。
						this.SetOperator(oPOdata,this._OP);
						ret = oPurchaseSystem.UpdateAndPresentPO(oPOdata);
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.Affirm:
                    if (Master.HasRight(SysRight.POConfirm))
					{
                        ret = oPurchaseSystem.AffirmPO(this.doc1.EntryNo, DocStatus.OrdReject, Master.CurrentUser.thisUserInfo.LoginName);
					}
					else
					{
						ret = false;
					}
					break;
                case OP.Red:
                    if (Master.HasRight(SysRight.POCancelOpera))
                    {
                        //设置单据状态。
                        this._OP = OP.NewAndAssign;
                        this.SetEntryState(oPOdata, this._OP);
                        //设置操作人。
                        this.SetOperator(oPOdata, this._OP);
                        ret = oPurchaseSystem.AddAndPresentPO(oPOdata);
                    }
                    else
                    {
                        	ret = false;
                    }
                    break;
			}
					
			if ( ret== false)
			{
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
			}
			else
			{
				if (Master.IsTODO)
				{
					this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
				}
				else
				{
					Response.Redirect("POBrowser.aspx?DocCode=3");
				}
				
			}
	
		}

        /// <summary>
        /// 撤消单的页面控制
        /// </summary>
        public void CancelControl(string strParentEntryNo)
        {
            if ((strParentEntryNo != "" && strParentEntryNo != "0") || this._OP == OP.Red)
            {
                //this.doc1.DocName = "采购订单撤消单";
                //classvalue = "hidden";
                ddlPayStyle.Enable = false;
                ddlStoManager.Enable = false;
                this.Image1.Visible = false;
                //把列表上的新增按按扭变为不可见 
                item1.NewBtnClass = "display: none;visibility:hidded;";
            }
        }

        /// <summary>
        /// 撤消单的页面控制
        /// </summary>
        public void CancelControl(string strParentEntryNo, string strstate)
        {
            if ((strParentEntryNo != "" && strParentEntryNo != "0") || this._OP == OP.Red)
            {
                //this.doc1.DocName = "采购订单撤消单";
                //classvalue = "hidden";
                ddlPayStyle.Enable = false;
                if (strstate != "T")
                    ddlStoManager.Enable = false;
                this.Image1.Visible = false;
            }
        }
		
        /// <summary>
		/// 供应商下拉列表改变事件。
		/// </summary>
		/// <returns></returns>
		protected override bool OnBubbleEvent(object Sender,EventArgs e)
		{
			try
			{
				if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == "ddlPrv_thisDDL" )
				{
					//if(ddlPrv.SelectedValue != "") PrvBindData(ddlPrv.SelectedValue,true);
				}
			}
			catch
			{}
			return true;
		}

		#endregion
		
	}
}
