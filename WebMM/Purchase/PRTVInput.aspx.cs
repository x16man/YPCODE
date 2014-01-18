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
    using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// PRTVInput 采购退料单的摘要说明。
	/// </summary>
	public partial class PRTVInput : System.Web.UI.Page
	{
		#region 成员变量
		private string _OP;
	//	private int _EntryNo;
		//private bool IsTODO;
		protected DocWebControl doc1;
		protected PRTVWebControl item1;
		protected StorageDropdownlist ddlStock;
		protected StorageDropdownlist ddlPayStyle;
		protected StorageDropdownlist ddlBuyer;
		protected StorageDropdownlist ddlCurrency;
		protected StorageDropdownlist ddlCheckResult;
		protected DocAuditWebControl DocAuditWebControl1;
		
		//protected User myUser;
		//protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";

        PRTVData oPRTVData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

        PurchaseSystem oPS = new PurchaseSystem();

	    private RTVSData oRTVSData = new RTVSData();

	    private DataRow dr;

	    private DataRow oDataRow;

	    private Col2List MyCol2List;

	    private bool ret;

        DataTable oDT;

		#endregion
		
		#region 私有方法
		/// <summary>
		/// 新增单据状态下，数据绑定。
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.RTV;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.RTV;
			this.ddlBuyer.Module_Tag = (int)SDDLTYPE.PSLP;
			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
			//this.ddlCheckResult.Width = "100%";
			//this.ddlPayStyle.Width = "100%";
			//this.ddlProvider.Module_Tag = (int)SDDLTYPE.VENDOR;
			this.ddlStock.Module_Tag = (int)SDDLTYPE.STORAGE;
			//this.ddlStock.Width = "100%";
			this.ddlCurrency.Module_Tag = (int)SDDLTYPE.CURRENCY;
            this.lblAuthor.Text = Master.CurrentUser.thisUserInfo.EmpName;
            this.ddlBuyer.SelectedValue = Master.CurrentUser.thisUserInfo.EmpCode;
		}
		/// <summary>
		/// 编辑数据状态下，数据绑定。
		/// </summary>
		private void BindDataUpdate()
		{
			
			this.doc1.DocCode=DocType.RTV;
			this.doc1.DataBindUpdate();
			this.DocAuditWebControl1.DocCode=DocType.RTV;
			this.ddlBuyer.Module_Tag = (int)SDDLTYPE.PSLP;
			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
			//this.ddlCheckResult.Width = "100%";
			//this.ddlPayStyle.Width = "100%";
			//this.ddlProvider.Module_Tag = (int)SDDLTYPE.VENDOR;
			this.ddlStock.Module_Tag = (int)SDDLTYPE.STORAGE;
			//this.ddlStock.Width = "100%";
			this.ddlCurrency.Module_Tag = (int)SDDLTYPE.CURRENCY;
			
			//将单据填充到数据集,DataGrid绑定数据源。
			oPRTVData = oPurchaseSystem.GetPRTVByEntryNo(Master.EntryNo);
			this.CheckOpPrecondition(this._OP, oPRTVData);
			if(this._OP != OP.New )
			{
				for(int i = 0; i<oPRTVData.Tables[0].Rows.Count;i++)
					oPRTVData.Tables[0].Rows[i][InItemData.ITEMNUM_FIELD] =oPRTVData.Tables[0].Rows[i][PRTVData.PLANNUM_FIELD];
			}

			oDT = oPRTVData.Tables[PRTVData.PRTV_TABLE];
			this.item1.thisTable = oDT;
			this.HyperLink1.Text = "采购收料单"+oDT.Rows[0][PRTVData.SOURCEENTRY_FIELD].ToString();
			this.HyperLink1.NavigateUrl = "PBorDetail.aspx?EntryNo="+oDT.Rows[0][PRTVData.SOURCEENTRY_FIELD].ToString()+"&Op=View";
			if (oDT.Rows.Count > 0)
			{
				//台头部分。
				this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
				this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
				this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
				//审批段。
				this.DocAuditWebControl1.AuditName1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.Auditor1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString(); 
                this.DocAuditWebControl1.AuditName2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.Auditor2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString(); 
                this.DocAuditWebControl1.AuditName3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
                this.DocAuditWebControl1.Auditor3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString(); 
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

                

				//采购员。
				this.ddlBuyer.SelectedText = oDT.Rows[0][PRTVData.BUYERNAME_FIELD].ToString();
				this.ddlBuyer.SelectedValue = oDT.Rows[0][PRTVData.BUYERCODE_FIELD].ToString();
				//仓库管理员。
				this.txtStoManager.Text = oDT.Rows[0][PRTVData.ACCEPTNAME_FIELD].ToString();
				//付款方式
				this.ddlPayStyle.SetItemSelected(oDT.Rows[0][PRTVData.PAYSTYLE_FIELD].ToString());
				this.ddlPayStyle.SelectedValue = oDT.Rows[0][PRTVData.PAYSTYLE_FIELD].ToString();
				this.ddlCurrency.SetItemSelected(oDT.Rows[0][PRTVData.CURRENCYCODE_FIELD].ToString());
				this.ddlCurrency.SelectedValue = oDT.Rows[0][PRTVData.CURRENCYCODE_FIELD].ToString();
				//供应商。
				//this.ddlProvider.SelectedText = oDT.Rows[0][PRTVData.PRVNAME_FIELD].ToString();
				//this.ddlProvider.SelectedValue = oDT.Rows[0][PRTVData.PRVCODE_FIELD].ToString();
				this.txtVendorCode.Value = oDT.Rows[0][PRTVData.PRVCODE_FIELD].ToString();
				this.txtVendor.Text = oDT.Rows[0][PRTVData.PRVNAME_FIELD].ToString();
				//仓库。
				this.ddlStock.SelectedText = oDT.Rows[0][PRTVData.STONAME_FIELD].ToString();
				this.ddlStock.SelectedValue = oDT.Rows[0][PRTVData.STOCODE_FIELD].ToString();
				//备注。
				this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
				this.ddlCheckResult.SelectedValue = oDT.Rows[0][PRTVData.CHKRESULT_FIELD].ToString();
				this.txtInvoice.Text = oDT.Rows[0][PRTVData.INVOICENO_FIELD].ToString();
				this.txtJFKM.Text = oDT.Rows[0][PRTVData.JFKM_FIELD].ToString();
				this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
				

				if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
				{
                    this.ddlBuyer.thisDDL.Enabled = false;
					this.ddlPayStyle.thisDDL.Enabled = false;
					//this.ddlProvider.thisDDL.Enabled =false;
					this.ddlStock.thisDDL.Enabled = false;

					this.ddlCheckResult.Enable = false;
					this.txtInvoice.Enabled = false;
					this.txtJFKM.Enabled = false;
				}
			}
		}

		/// <summary>
		/// 检查操作的前提条件。
		/// </summary>
		/// <param name="OpMode">string: 操作模式。</param>
		/// <param name="oPRTVData">PRTVData:	单据实体。</param>
		/// <returns>bool:	前提条件满足则返回True，不满足则返回False。</returns>
		private void CheckOpPrecondition(string OpMode,PRTVData oPRTVData)
		{	
			switch (OpMode)
			{
				case OP.Edit://编辑。
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XUpdate, true); }
					break;
				case OP.Submit://提交。
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XPresent, true); }
					break;
				case OP.FirstAudit://一级审批。
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XFirstAudit, true); }
					break;
				case OP.SecondAudit://二级审批。
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
					{	return ;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XSecondAudit, true); }
					break;
				case OP.ThirdAudit://三级审批。
					if (oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PRTVData.XThirdAudit, true); }
					break;
			}
		}
		
		/// <summary>
		/// 设置单据状态。
		/// </summary>
		/// <param name="oPRTVData">PRTVData:	采购退货单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEntryState(PRTVData oPRTVData, string OpMode)
		{
			if ( oPRTVData.Count > 0)
			{
				oDataRow = oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oPRTVData.Tables[0]).GetEntryState(OpMode);
			}
//			if ( oPRTVData.Count > 0)
//			{
//				DataRow oDataRow = oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0];
//
//				switch (OpMode)
//				{
//					case OP.New:
//						oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.New;
//						break;
//					case OP.Edit:
//						oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.New;
//						break;
//					case OP.FirstAudit:
//						if ( oDataRow[InItemData.AUDIT1_FIELD].ToString() == AuditResult.Passed )
//						{
//
//							oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.FstPass;
//						}
//						else
//						{
//							if ( oDataRow[InItemData.AUDIT1_FIELD].ToString() == AuditResult.NoPassed )
//							{
//								oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.FstNoPass;
//							}
//						}
//						break;
//					case OP.SecondAudit:
//						if ( oDataRow[InItemData.AUDIT2_FIELD].ToString() == AuditResult.Passed )
//						{
//							oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.SecPass;
//						}
//						else
//						{
//							if ( oDataRow[InItemData.AUDIT2_FIELD].ToString() == AuditResult.NoPassed )
//							{
//								oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.SecNoPass;
//							}
//						}
//						break;
//					case OP.ThirdAudit:
//						if ( oDataRow[InItemData.AUDIT3_FIELD].ToString() == AuditResult.Passed )
//						{
//							oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.TrdPass;
//						}
//						else
//						{
//							if ( oDataRow[InItemData.AUDIT3_FIELD].ToString() == AuditResult.NoPassed )
//							{
//								oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.TrdNoPass;
//							}
//						}
//						break;
//					case OP.I:
//						//TODO: ADD Bor's receive status.
//						oDataRow[InItemData.ENTRYSTATE_FIELD] = DocStatus.Received;
//						break;
//				}
//			}
		}

		/// <summary>
		/// 设置单据操作人。
		/// </summary>
		/// <param name="oPRTVData">PRTVData:	采购退货单实体。</param>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetOperator(PRTVData oPRTVData, string OpMode)
		{
			if ( oPRTVData.Count > 0)
			{
				oDataRow = oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows[0];

				switch (OpMode)
				{
					case OP.New://新建。
						oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
						break;
                    case OP.Submit://新建。
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
					case OP.I://收料。
						oDataRow[BillOfReceiveData.ACCEPTCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
						oDataRow[BillOfReceiveData.ACCEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
						break;
				}
			}
		}

		/// <summary>
		/// 填充采购退货单实体。
		/// </summary>
		/// <param name="oPRTVData">PRTVData:	采购退货单实体。</param>
		private void FillData(PRTVData oPRTVData)
		{
			

			dr = oPRTVData.Tables[PRTVData.PRTV_TABLE].NewRow();
			//单据台头部分内容。
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//单据流水号。
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//单据编号。
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//单据类型。
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//单据类型名称。
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//单据文档编号。
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//单据日期。

			dr[InItemData.REMARK_FIELD] = this.item1.Remark;						//备注。
            dr[PRTVData.PRVCODE_FIELD] = this.txtVendorCode.Value;					//供应单位。
			dr[PRTVData.PRVNAME_FIELD] = this.txtVendor.Text;					//供应商名称。
			dr[PRTVData.STOCODE_FIELD] = ddlStock.SelectedValue;					//仓库。
			dr[PRTVData.STONAME_FIELD] = ddlStock.SelectedText;						//仓库名称。
			dr[PRTVData.CURRENCYCODE_FIELD] = ddlCurrency.SelectedValue;			//币种。
			dr[PRTVData.INVOICENO_FIELD] = Master.GetNoSpaceString(txtInvoice.Text);							//发票。
			dr[PRTVData.JFKM_FIELD] = txtJFKM.Text;									//会计科目。
			dr[PRTVData.PAYSTYLE_FIELD] = ddlPayStyle.SelectedValue;				//付款方式。
			dr[PRTVData.CHKRESULT_FIELD] = ddlCheckResult.SelectedValue;			//验收情况。
			dr[PRTVData.BUYERCODE_FIELD] = ddlBuyer.SelectedValue;					//采购员编号。
			dr[PRTVData.BUYERNAME_FIELD] = ddlBuyer.SelectedText;					//采购员名称。
			
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。

			//Col2List MyCol2List = new Col2List(oPRTVData.Tables[PRTVData.PRTV_TABLE]);
			MyCol2List = new Col2List(this.item1.thisTable);
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(PRTVData.ITEMSUM_FIELD);//请购单合计金额。
			dr[PRTVData.TOTALTAX_FIELD] = MyCol2List.GetSum(PRTVData.ITEMTAX_FIELD);
			dr[PRTVData.TOTALMONEY_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);
			dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();
			dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);
			dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);
			dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);
			dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);
			dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);
			dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);
			dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);
			dr[PRTVData.SOURCEENTRY_FIELD] = MyCol2List.GetList(PRTVData.SOURCEENTRY_FIELD);
			dr[PRTVData.SOURCEDOCCODE_FIELD] = MyCol2List.GetList(PRTVData.SOURCEDOCCODE_FIELD);
			dr[PRTVData.SOURCESERIALNO_FIELD] = MyCol2List.GetList(PRTVData.SOURCESERIALNO_FIELD);
			dr[PRTVData.PLANNUM_FIELD] = MyCol2List.GetList(PRTVData.PLANNUM_FIELD);
			dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
			dr[PRTVData.TAXCODE_FIELD] = MyCol2List.GetList(PRTVData.TAXCODE_FIELD);
			dr[PRTVData.TAXRATE_FIELD] = MyCol2List.GetList(PRTVData.TAXRATE_FIELD);
			dr[PRTVData.ITEMTAX_FIELD] = MyCol2List.GetList(PRTVData.ITEMTAX_FIELD);
			dr[PRTVData.ITEMSUM_FIELD] = MyCol2List.GetList(PRTVData.ITEMSUM_FIELD);
			oPRTVData.Tables[PRTVData.PRTV_TABLE].Rows.Add(dr);
			this.SetEntryState(oPRTVData,this._OP);
			this.SetOperator(oPRTVData,this._OP);
		}
		#endregion
		
		
		
		#region 事件
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.RTV;
			// 在此处放置用户代码以初始化页面
			_OP = Request["Op"].ToString();

           
			
			SetEditMode();
            item1.IsDisplayPRTVPrice = Master.DisplayPRTVPrice;
			if(!this.IsPostBack)
			{
				switch (_OP)
				{
					case OP.New:
						if (!Master.HasRight(SysRight.RTVMaintain))
						{	
							//this.Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataNew();
						this.btnSave.Text = OPName.New;
						break;
					case OP.Edit:
                        if (!Master.HasRight(SysRight.RTVMaintain))
						{	
							//.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Edit;
						break;
					case OP.Submit:
                        if (!Master.HasRight(SysRight.RTVPresent))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.Submit;
						break;
					case OP.FirstAudit:
                        if (!Master.HasRight(SysRight.RTVFirstAudit))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
						this.btnSave.Text = OPName.FirstAudit;
                        txtStoManager.Attributes.Add("ReadOnly", "ReadOnly");
                        Image1.Visible = false;
						break;
					case OP.SecondAudit:
                        if (!Master.HasRight(SysRight.RTVSecondAudit))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
                        Image1.Visible = false;
						this.btnSave.Text = OPName.SecondAudit;
                        txtStoManager.Attributes.Add("ReadOnly", "ReadOnly");
						break;
					case OP.ThirdAudit:
						if (!Master.HasRight(SysRight.RTVThirdAudit))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
                        Image1.Visible = false;
						this.btnSave.Text = OPName.ThirdAudit;
                        txtStoManager.Attributes.Add("ReadOnly", "ReadOnly");
						break;
					case OP.I:
                        if (!Master.HasRight(SysRight.StockOut))
						{	
							//this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
							return;
						}
						this.BindDataUpdate();
                        Image1.Visible = false;
						this.btnSave.Text = "退料";
                        txtStoManager.Attributes.Add("ReadOnly", "ReadOnly");
						break;
				}
			}
		}
		private void SetEditMode()
		{
			switch(this._OP)
			{
				case OP.New:
					break;
				case OP.Edit:
					break;
				default:
					//this.ddlProvider.Enable = false;
					this.ddlStock.Enable = false;
					this.ddlPayStyle.Enable = false;
					this.ddlCurrency.Enable = false;
					this.txtInvoice.ReadOnly= true;
					this.txtJFKM.ReadOnly = true;
					this.ddlCheckResult.Enable = false;
					this.btnSelectProvider.Disabled = true;
					break;
			}
		}

        private bool CheckInvoice()
        {
            if (this.txtInvoice.Text == "")
            {
                ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('发票号不能为空');", true);

                return false;
            }

            if (this.txtInvoice.Text.IndexOf("，") > -1)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('发票号不能有中文逗号');", true);

                return false;
            }
            return true;
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
			oPRTVData = new PRTVData();
			//填充数据集。			
			this.FillData(oPRTVData);
			
			
			ret = true;
			switch (this._OP)
			{
				case OP.New:
                   
					if (Master.HasRight(SysRight.RTVMaintain))
					{
                        if (CheckInvoice())
						    ret = oPurchaseSystem.AddPRTV(oPRTVData);
                        else
                            return;
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.Edit:
                    
                    if (Master.HasRight(SysRight.RTVMaintain))
					{
                        if (CheckInvoice())
                            ret = oPurchaseSystem.UpdatePRTV(oPRTVData, Master.CurrentUser.thisUserInfo.EmpCode);
                        else
                            return;
					}
					else
					{
						ret = false;
					}
					break;
				case OP.Submit:
                   
                    if (Master.HasRight(SysRight.RTVPresent))
					{
                        if (CheckInvoice())
                            ret = oPurchaseSystem.PresentPRTV(Master.EntryNo, Master.CurrentUser.thisUserInfo.LoginName, Master.CurrentUser.thisUserInfo.EmpCode);
                        else
                            return;
                    }
					else
					{
						ret = false;
					}
					break;
				case OP.FirstAudit:
                    if (Master.HasRight(SysRight.RTVFirstAudit))
					{
						ret = oPurchaseSystem.FirstAuditPRTV(oPRTVData);
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.SecondAudit:
                    if (Master.HasRight(SysRight.RTVSecondAudit))
					{
						ret = oPurchaseSystem.SecondAuditPRTV(oPRTVData);
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.ThirdAudit:
                    if (Master.HasRight(SysRight.RTVThirdAudit))
					{
						ret = oPurchaseSystem.ThirdAuditPRTV(oPRTVData);
					}
					else
					{
						ret = false;
					}
					
					break;
				case OP.I:
                    if (Master.HasRight(SysRight.StockOut))
					{
						Session[MySession.DrawDt] = this.item1.thisTable;
						this.Response.Redirect("../Storage/ConChooser.aspx?DocCode=7&EntryNo="+this.doc1.EntryNo.ToString()+"&Op="+OP.I);
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
					this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
				}
				else
				{
					Response.Redirect("PRTVBrowser.aspx?DocCode=7");
				}
				
			}
		}


		protected void btnForPKID_Click(object sender, System.EventArgs e)
		{
           // PurchaseSystem oPS = new PurchaseSystem();
            oRTVSData = oPS.GetRTVSByPKID(txtPKID.Value);
            if (oRTVSData.Tables[RTVSData.RTVS_VIEW].Rows.Count > 0)
            {
                dr = oRTVSData.Tables[RTVSData.RTVS_VIEW].Rows[0];
                //仓库。
                this.ddlStock.SelectedText = dr[RTVSData.STONAME_FIELD].ToString();
                this.ddlStock.SelectedValue = dr[RTVSData.STOCODE_FIELD].ToString();
                this.ddlStock.SetItemSelected(dr[RTVSData.STOCODE_FIELD].ToString());
                //币种。
                this.ddlCurrency.SetItemSelected(dr[RTVSData.CURRENCYCODE_FIELD].ToString());
                //采购员。
                this.ddlBuyer.SelectedText = dr[RTVSData.BUYERNAME_FIELD].ToString();
                this.ddlBuyer.SelectedValue = dr[RTVSData.BUYERCODE_FIELD].ToString();
                this.ddlBuyer.SetItemSelected(dr[RTVSData.BUYERCODE_FIELD].ToString());
                //原采购收料单连接。
                this.HyperLink1.Text = "采购收料单" + dr[RTVSData.ENTRYNO_FIELD].ToString() + "号";
                this.HyperLink1.NavigateUrl = "PBorDetail.aspx?EntryNo=" + dr[RTVSData.ENTRYNO_FIELD].ToString() + "&Op=View";
                //更新列表。
                 item1.PKID = this.txtPKID.Value;

            }
		}

		/// <summary>
		/// 取消按钮。
		/// </summary>
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (Master.IsTODO)
			{
				this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
			}
			else
			{
				Response.Redirect("PRTVBrowser.aspx?DocCode=7");
			}
		}
		#endregion




	}
}