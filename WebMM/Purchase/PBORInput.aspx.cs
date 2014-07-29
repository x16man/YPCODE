using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Modules;
using Shmzh.Components.SystemComponent;
using MZHCommon.Database;
using SysRight = MZHMM.WebMM.Common.SysRight;

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
    /// <summary>
    /// ROSInput 的摘要说明。
    /// </summary>
    public partial class PBORInput : Page
    {
        #region 成员变量
        private string _OP;
        private int SourceEntryNo;
        BillOfReceiveData oBORData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

        private PBRBData oPBRBData;

        private DataTable oDT;

        private int i;

        private DataRow oDataRow;

        private Col2List BorCol2List;

        private DataRow dr;

        private BillOfReceiveData oBorData;

        bool ret = true;
        bool IsRepeated = false;

        BillOfReceiveData TempBORData;
        string InvoiceNo ;
        string ItemCode;

        private string strParentEntryNo = "";

        #endregion
        
        #region 私有方法
        /// <summary>
        /// 新增单据状态下，数据绑定。
        /// </summary>
        private void BindDataNew()
        {
            if (this._OP != OP.Red)
            {
                this.doc1.DocCode = DocType.BOR;
                this.doc1.DataBindNew();
                this.DocAuditWebControl1.DocCode = DocType.BOR;
                this.ddlBuyer.Module_Tag = (int)SDDLTYPE.PSLP;
                this.ddlBuyer.SelectedValue = Master.CurrentUser.thisUserInfo.EmpCode;
                this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
                //this.ddlCheckResult.Width = "100%";
                this.lblAuthor.Text = Master.CurrentUser.thisUserInfo.EmpName;
                this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
                //this.ddlPayStyle.Width = "100%";
                this.ddlStock.Module_Tag = (int)SDDLTYPE.STORAGE;
                //this.ddlStock.Width = "100%";
                this.ddlStock.AutoPostBack = true;
                this.ddlCurrency.Module_Tag = (int)SDDLTYPE.CURRENCY;

                if (this._OP == OP.Bor)//如果是批次进货单生成。
                {
                    SourceEntryNo = int.Parse(this.Request["EntryNo"].ToString().Split('|')[0]);
                    oPBRBData = new PurchaseSystem().GetPBRBByEntryNo(SourceEntryNo);
                    this.ddlStock.SelectedValue = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString();
                }
            }
            else		   //红字。
            {
                oBORData = oPurchaseSystem.GetBROldByEntryNo(Master.EntryNo);

                if (oBORData.Tables[0].Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('此单据已经作过红字操作不可以再次进行红字操作！');document.location='PBORBrowser.aspx?DocCode=6';", true);
                    return;
                }
               
            
                oBORData = oPurchaseSystem.GetBRByEntryNo(Master.EntryNo);
                strParentEntryNo = oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString();
                if (strParentEntryNo != "" )
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('此单据是红字操作单据不可以再次进行红字操作！');document.location='PBORBrowser.aspx?DocCode=6';", true);
                    return;
                }

                if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Received)
                {
                    item1.OperateRed = true;
                    btnProvicerCom.Visible = false;
                    ddlStock.Enable = false;
                    txtInvoice.Attributes.Add("ReadOnly","ReadOnly");
                    txtContractCode.Attributes.Add("ReadOnly","ReadOnly");
                    ddlPayStyle.Enable = false;
                    ddlCheckResult.Enable = false;
                    txtUsedFor.Attributes.Add("ReadOnly","ReadOnly");
                    ddlCurrency.Enable = false;

                    this.doc1.DocCode = DocType.BOR;
                    this.doc1.DataBindNew();
                    this.DocAuditWebControl1.DocCode = DocType.BOR;
                    this.ddlBuyer.Module_Tag = (int)SDDLTYPE.PSLP;
                    this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
                    //this.ddlCheckResult.Width = "100%";
                    this.lblAuthor.Text = Master.CurrentUser.thisUserInfo.EmpName;
                    this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
                    //this.ddlPayStyle.Width = "100%";
                    this.ddlStock.Module_Tag = (int)SDDLTYPE.STORAGE;
                    //this.ddlStock.Width = "100%";
                    this.ddlCurrency.Module_Tag = (int)SDDLTYPE.CURRENCY;
                    this.txtParentEntryNo.Value = Master.EntryNo.ToString()  ;
                
                
                    oBORData = oPurchaseSystem.GetBRRedByEntryNo(Master.EntryNo);
                    
                    //判断操作的前提条件.
                    this.CheckOpPrecondition(this._OP,oBORData);
                    oDT = oBORData.Tables[BillOfReceiveData.PBOR_TABLE];
                    this.item1.thisTable = oDT;
                    if (oDT.Rows.Count > 0)
                    {
                        //验收结果。
                        this.ddlCheckResult.SelectedValue = oDT.Rows[0][BillOfReceiveData.CHKRESULT_FIELD].ToString();
                        //付款方式
                        this.ddlPayStyle.SetItemSelected(oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString());
                        //供应商。
                        this.txtVendor.Text = oDT.Rows[0][BillOfReceiveData.PRVNAME_FIELD].ToString();
                        this.txtVendorCode.Value = oDT.Rows[0][BillOfReceiveData.PRVCODE_FIELD].ToString();
                        //仓库。
                        this.ddlStock.SelectedText = oDT.Rows[0][BillOfReceiveData.STONAME_FIELD].ToString();
                        this.ddlStock.SelectedValue = oDT.Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString();
                        //Buyer
                        this.ddlBuyer.SelectedText = oDT.Rows[0][BillOfReceiveData.BUYERNAME_FIELD].ToString();
                        this.ddlBuyer.SelectedValue = oDT.Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString();

                        this.txtInvoice.Text = oDT.Rows[0][BillOfReceiveData.INVOICENO_FIELD].ToString();
                        this.txtJFKM.Value = oDT.Rows[0][BillOfReceiveData.JFKM_FIELD].ToString();
                        this.txtUsedFor.Text = oDT.Rows[0][BillOfReceiveData.USEDFOR_FIELD].ToString();
                        this.lblAccept.Text = oDT.Rows[0][BillOfReceiveData.ACCEPTNAME_FIELD].ToString();
                        this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
                        this.txtContractCode.Text = oDT.Rows[0][BillOfReceiveData.CONTRACTCODE_FIELD].ToString();
                    }
                }
                else
                {
                    //this.Response.Write("<Script>alert('采购收料单出红字的前提条件是该单据已收料！');</Script>");
                    //this.Response.Redirect("PBORBrowser.aspx",true);
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('采购收料单出红字的前提条件是该单据已收料！');document.location='PBORBrowser.aspx?DocCode=6';", true);
                }
            }
        }
        /// <summary>
        /// 编辑数据状态下，数据绑定。
        /// </summary>
        private void BindDataUpdate()
        {
            oBORData = new BillOfReceiveData();
        
            this.doc1.DocCode=DocType.BOR;
            this.doc1.DataBindUpdate();
            this.DocAuditWebControl1.DocCode=DocType.BOR;
            this.ddlBuyer.Module_Tag = (int)SDDLTYPE.PSLP;

            this.ddlCheckResult.Module_Tag = (int)SDDLTYPE.CheckResult;
            //this.ddlCheckResult.Width = "100%";
            
            this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
            //this.ddlPayStyle.Width = "100%";
            
            this.ddlStock.Module_Tag = (int)SDDLTYPE.STORAGE;
            //this.ddlStock.Width = "100%";
            this.ddlStock.AutoPostBack = true;
            this.ddlCurrency.Module_Tag = (int)SDDLTYPE.CURRENCY;
            //将单据填充到数据集,DataGrid绑定数据源。
            if (this._OP == OP.I)
            {
                oBORData = oPurchaseSystem.GetBRByEntryNoInMode(Master.EntryNo);
            }
            else
            {
                oBORData = oPurchaseSystem.GetBRByEntryNo(Master.EntryNo);
            }
            //判断操作的前提条件.
            this.CheckOpPrecondition(this._OP,oBORData);

            oDT = oBORData.Tables[BillOfReceiveData.PBOR_TABLE];
            this.item1.thisTable = oDT;
            
            if (oDT.Rows.Count > 0)
            {
                strParentEntryNo = oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString();
                

                //台头部分。
                this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
                this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
                this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
                //审批段。
                this.DocAuditWebControl1.AuditName1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.AuditName2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.AuditName3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
                if (oDT.Rows[0][InItemData.AUDIT1_FIELD] != DBNull.Value)
                {
                    this.DocAuditWebControl1.rblAudit1.SelectedIndex = oDT.Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y"? 0:1;
                }
                if (oDT.Rows[0][InItemData.AUDIT2_FIELD] != DBNull.Value)
                {
                    this.DocAuditWebControl1.rblAudit2.SelectedIndex = oDT.Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y"? 0:1;
                }
                if(oDT.Rows[0][InItemData.AUDIT3_FIELD] != DBNull.Value)
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

                

                //对应的蓝单据。
                this.txtParentEntryNo.Value = oDT.Rows[0][BillOfReceiveData.PARENTENTRYNO_FIELD].ToString();
                //采购员。
                this.ddlBuyer.SelectedText = oDT.Rows[0][BillOfReceiveData.BUYERNAME_FIELD].ToString();
                this.ddlBuyer.SelectedValue = oDT.Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString();
                this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
                //验收结果。
                this.ddlCheckResult.SelectedValue = oDT.Rows[0][BillOfReceiveData.CHKRESULT_FIELD].ToString();
                //付款方式
                this.ddlPayStyle.SelectedValue = oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString();
                switch (oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString())
                {
                    case "G":
                        this.ddlPayStyle.SelectedText = "付委";
                        break;
                    case "Q":
                        this.ddlPayStyle.SelectedText = "现金";
                        break;
                    case "C":
                        this.ddlPayStyle.SelectedText = "支票";
                        break;
                }
                this.ddlPayStyle.SetItemSelected(oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString());
                //供应商。
                this.txtVendorCode.Value = oDT.Rows[0]["PrvCode"].ToString();
                this.txtVendor.Text = oDT.Rows[0]["PrvName"].ToString();
                //仓库。
                this.ddlStock.SelectedText = oDT.Rows[0][BillOfReceiveData.STONAME_FIELD].ToString();
                this.ddlStock.SelectedValue = oDT.Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString();
                //架位。
                if (this._OP == OP.I)
                {
                    this.item1.ddlCon.StoCode = oDT.Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString();
                    this.item1.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
                }
                //发票号。
                this.txtInvoice.Text = oDT.Rows[0][BillOfReceiveData.INVOICENO_FIELD].ToString();
                //借方科目。
                this.txtJFKM.Value = oDT.Rows[0][BillOfReceiveData.JFKM_FIELD].ToString();
                //用于。
                this.txtUsedFor.Text = oDT.Rows[0][BillOfReceiveData.USEDFOR_FIELD].ToString();
                //收料人。
                this.lblAccept.Text = oDT.Rows[0][BillOfReceiveData.ACCEPTNAME_FIELD].ToString();
                //制单人。
                this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
                //合同编号。
                this.txtContractCode.Text = oDT.Rows[0][BillOfReceiveData.CONTRACTCODE_FIELD].ToString();
                //备注。
                this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //费用。
                this.item1.TotalFee = Convert.ToDecimal(oDT.Rows[0][BillOfReceiveData.TOTALFEE_FIELD].ToString());

                if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit" || this._OP == OP.I)
                {
                    this.ddlBuyer.thisDDL.Enabled = false;
                    this.ddlPayStyle.thisDDL.Enabled = false;
                    this.ddlStock.thisDDL.Enabled = false;
                    this.ddlCheckResult.Enable = false;
                    this.txtInvoice.Enabled = false;
                    //this.txtJFKM.Enabled = false;
                    this.txtUsedFor.Enabled = false;
                    this.btnProvicerCom.Disabled = true;
                }
            }
        }
        /// <summary>
        /// 设置指定下拉列表的选中项。
        /// </summary>
        /// <param name="List">DropDownList：下拉列表。</param>
        /// <param name="TargetValue">string:	指定值。</param>
        private void SetSelectedItem(DropDownList List ,string TargetValue)
        {
            for (i=0;i<List.Items.Count;i++)			
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
        /// 设置单据状态。
        /// </summary>
        /// <param name="oBorData">BillOfReceiveData:	收料单实体。</param>
        /// <param name="OpMode">string:	操作类型。</param>
        private void SetEntryState(BillOfReceiveData oBorData, string OpMode)
        {
            if ( oBorData.Count > 0)
            {
                oDataRow = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];
                oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oBorData.Tables[0]).GetEntryState(OpMode);
            }
        }
        /// <summary>
        /// 设置操作人员信息。
        /// </summary>
        /// <param name="oBorData"></param>
        /// <param name="OpMode"></param>
        private void SetOperator(BillOfReceiveData oBorData, string OpMode)
        {
            if ( oBorData.Count > 0)
            {
                oDataRow = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];

                switch (OpMode)
                {
                    case OP.New://新建。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.Red://红字。
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.Bor://由批次进货单生成。
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
                    case OP.Reject://收料拒绝
                        oDataRow[BillOfReceiveData.ACCEPTCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[BillOfReceiveData.ACCEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                }
            }
        }
        /// <summary>
        /// 根据页面内容来填充数据集。
        /// </summary>
        /// <param name="oBorData">BillOfReceiveData:	收料单数据实体。</param>
        private void FillBillOfReceiveData(BillOfReceiveData oBorData)
        {
            

            dr = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].NewRow();
            //单据台头部分内容。
            dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//单据流水号。
            dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//单据编号。
            dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//单据类型。
            dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//单据类型名称。
            dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//单据文档编号。
            dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//单据日期。
            dr[BillOfReceiveData.PRVCODE_FIELD] = this.txtVendorCode.Value;		//供应单位。
           // dr[BillOfReceiveData.PRVCODE_FIELD] = this.txtVendorCode.Value;

            dr[BillOfReceiveData.PRVNAME_FIELD] = this.txtVendor.Text;			//供应商名称。
            dr[BillOfReceiveData.PRVNAME_FIELD] = this.txtVendor.Text;
            dr[BillOfReceiveData.STOCODE_FIELD] = ddlStock.SelectedValue;			//仓库编号。
            dr[BillOfReceiveData.STONAME_FIELD] = ddlStock.SelectedText;			//仓库名称。
            dr[BillOfReceiveData.CURRENCYCODE_FIELD] = ddlCurrency.SelectedValue;   //币种
            dr[BillOfReceiveData.INVOICENO_FIELD] = Master.GetNoSpaceString(txtInvoice.Text);		//发票。
            dr[BillOfReceiveData.JFKM_FIELD] = txtJFKM.Value;						//会计科目。
            dr[BillOfReceiveData.PAYSTYLE_FIELD] = ddlPayStyle.SelectedValue;		//付款方式。
            dr[BillOfReceiveData.CHKRESULT_FIELD] = ddlCheckResult.SelectedValue;	//验收情况。
            dr[BillOfReceiveData.USEDFOR_FIELD] = txtUsedFor.Text;					//用于。
            dr[BillOfReceiveData.BUYERNAME_FIELD] = ddlBuyer.SelectedText;			//采购员名称。
            dr[BillOfReceiveData.BUYERCODE_FIELD] = ddlBuyer.SelectedValue;			//采购员编号。
            dr[BillOfReceiveData.CONTRACTCODE_FIELD] = this.txtContractCode.Text;	//合同编号。
            try { dr[BillOfReceiveData.PARENTENTRYNO_FIELD] = Convert.ToInt32(this.txtParentEntryNo.Value); }	//对应蓝单据流水号。
            catch{}
            dr[BillOfReceiveData.TOTALFEE_FIELD] = this.item1.TotalFee;//费用。

            dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
            dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
            dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。
            dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
            dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
            dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。
            dr[InItemData.REMARK_FIELD] = this.item1.Remark;						//备注。
            
            //连接字符串。
            BorCol2List = new Col2List(this.item1.thisTable);
            //填充数据实体层。
            dr[BillOfReceiveData.TOTALMONEY_FIELD] = BorCol2List.GetSum(InItemData.ITEMMONEY_FIELD);//物料金额。
            dr[BillOfReceiveData.TOTALTAX_FIELD] = BorCol2List.GetSum(BillOfReceiveData.ITEMTAX_FIELD);//税额。
            //dr[BillOfReceiveData.TOTALDISCOUNT_FIELD] = BorCol2List.GetSum(BillOfReceiveData.ITEMDISCOUNT_FIELD);//折扣。
            dr[InItemData.SUBTOTAL_FIELD] = BorCol2List.GetSum(BillOfReceiveData.ITEMSUM_FIELD);//物料总金额。
            dr[InItemData.SERIALNO_FIELD] = BorCol2List.GetList();//顺序号连接。
            dr[BillOfReceiveData.SOURCEENTRY_FIELD] = BorCol2List.GetList(BillOfReceiveData.SOURCEENTRY_FIELD);//源单据号。
            dr[BillOfReceiveData.SOURCEDOCCODE_FIELD] = BorCol2List.GetList(BillOfReceiveData.SOURCEDOCCODE_FIELD);//源单据类型号。
            dr[BillOfReceiveData.SOURCESERIALNO_FIELD] = BorCol2List.GetList(BillOfReceiveData.SOURCESERIALNO_FIELD);//源单据流水号。
            dr[InItemData.NEWCODE_FIELD] = BorCol2List.GetList(InItemData.NEWCODE_FIELD);
            dr[InItemData.ITEMCODE_FIELD] = BorCol2List.GetList(InItemData.ITEMCODE_FIELD);//物料编号。
            dr[InItemData.ITEMNAME_FIELD] = BorCol2List.GetList(InItemData.ITEMNAME_FIELD);//物料名称。
            dr[InItemData.ITEMSPECIAL_FIELD] = BorCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);//规格型号。
            dr[InItemData.ITEMUNIT_FIELD] = BorCol2List.GetList(InItemData.ITEMUNIT_FIELD);//单位编号。
            dr[InItemData.ITEMUNITNAME_FIELD] = BorCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);//单位名称。
            dr[BillOfReceiveData.BATCHCODE_FIELD] = BorCol2List.GetList(BillOfReceiveData.BATCHCODE_FIELD);//批号。
            dr[InItemData.ITEMPRICE_FIELD] = BorCol2List.GetList(InItemData.ITEMPRICE_FIELD);//单价。
            dr[BillOfReceiveData.PLANNUM_FIELD] = BorCol2List.GetList(BillOfReceiveData.PLANNUM_FIELD);//应收数量。
            dr[InItemData.ITEMNUM_FIELD] = BorCol2List.GetList(InItemData.ITEMNUM_FIELD);//实收数量。
            dr[InItemData.ITEMMONEY_FIELD] = BorCol2List.GetList(InItemData.ITEMMONEY_FIELD);//物料金额。
            dr[BillOfReceiveData.TAXCODE_FIELD] = BorCol2List.GetList(BillOfReceiveData.TAXCODE_FIELD);//税码。
            dr[BillOfReceiveData.TAXRATE_FIELD] = BorCol2List.GetList(BillOfReceiveData.TAXRATE_FIELD);//税率。
            dr[BillOfReceiveData.ITEMTAX_FIELD] = BorCol2List.GetList(BillOfReceiveData.ITEMTAX_FIELD);//税额。
            //dr[BillOfReceiveData.DISCOUNTRATE_FIELD] = BorCol2List.GetList(BillOfReceiveData.DISCOUNTRATE_FIELD);//折扣率。
            //dr[BillOfReceiveData.ITEMDISCOUNT_FIELD] = BorCol2List.GetList(BillOfReceiveData.ITEMDISCOUNT_FIELD);//折扣。
            dr[BillOfReceiveData.ITEMFEE_FIELD] = BorCol2List.GetList(BillOfReceiveData.ITEMFEE_FIELD);//费用。
            dr[BillOfReceiveData.ITEMSUM_FIELD] = BorCol2List.GetList(BillOfReceiveData.ITEMSUM_FIELD);//物料总金额。
            dr[BillOfReceiveData.CONCODE_FIELD] = BorCol2List.GetList(BillOfReceiveData.CONCODE_FIELD);//架位编号。
            dr[BillOfReceiveData.CONNAME_FIELD] = BorCol2List.GetList(BillOfReceiveData.CONNAME_FIELD);//架位名称。
            oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows.Add(dr);
        }
        /// <summary>
        /// 检查操作的前提条件。
        /// </summary>
        /// <param name="OpMode">string:	操作模式。</param>
        /// <param name="oBORData">BillOfReceiveData:	收料单实体。</param>
        private void CheckOpPrecondition(string OpMode,BillOfReceiveData oBORData)
        {
            switch (OpMode)
            {
                case OP.Edit://编辑。
                    if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    {	return;	}
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + BillOfReceiveData.XUpdate, true); }
                    break;
                case OP.Submit://提交。
                    if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.OrdReject ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    {	return;	}
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + BillOfReceiveData.XPresent, true); }
                    break;
                case OP.FirstAudit://一级审批。
                    if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
                    {	return;	}
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + BillOfReceiveData.XFirstAudit, true); }
                    break;
                case OP.SecondAudit://二级审批。
                    if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
                    {	return ;	}
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + BillOfReceiveData.XSecondAudit, true); }
                    break;
                case OP.ThirdAudit://三级审批。
                    if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
                    {	return;	}
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + BillOfReceiveData.XThirdAudit, true); }
                    break;
            }
        }
        #endregion
        
    
        
        #region 事件
        /// <summary>
        /// 页面Load事件。
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[MySession.Help] = HelpCode.BOR;
            // 在此处放置用户代码以初始化页面
            _OP = Request["Op"].ToString();


            txtVendor.Attributes.Add("ReadOnly", "ReadOnly");

            item1.IsDisplayPBORPrice = Master.DisplayBORPrice;
            this.btnReject.Visible = false;
            if(!this.IsPostBack)
            {
                //this.txtIsRepeated.Text = "";
                switch (_OP)
                {
                        #region New
                    case OP.New:
                        if (!Master.HasBrowseRight(SysRight.BORMaintain))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.BindDataNew();
                        this.btnSave.Text = OPName.New;
                        this.btnPresent.Visible = true;
                        this.ddlBuyer.Enable = true;
                        break;
                        #endregion
                        #region Bor
                    case OP.Bor:
                        if (!Master.HasBrowseRight(SysRight.BORMaintain))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.BindDataNew();
                        this.btnSave.Text = OPName.New;
                        this.btnPresent.Visible = true;
                        this.ddlBuyer.Enable = true;
                        break;
                        #endregion
                        #region Edit
                    case OP.Edit:
                        if (!Master.HasBrowseRight(SysRight.BORMaintain))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.Edit;
                        this.btnPresent.Visible = true;
                        this.ddlBuyer.Enable = true;
                        break;
                        #endregion
                        #region Submit
                    case OP.Submit:
                        if (!Master.HasBrowseRight(SysRight.BORPresent))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.Submit;
                        this.btnPresent.Visible = false;
                        this.ddlBuyer.Enable = false;
                        break;
                        #endregion
                        #region FirstAudit
                    case OP.FirstAudit:
                        if (!Master.HasBrowseRight(SysRight.BORFirstAudit))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.FirstAudit;
                        this.btnPresent.Visible = false;
                        Image1.Visible = false;
                        this.ddlBuyer.Enable = false;
                        txtVendor.Attributes.Add("ReadOnly","ReadOnly");
                        txtContractCode.Attributes.Add("ReadOnly","ReadOnly");
                        ddlCurrency.Enable = false;


                        break;
                        #endregion
                        #region SecondAudit
                    case OP.SecondAudit:
                        if (!Master.HasBrowseRight(SysRight.BORSecondAudit))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.SecondAudit;
                        Image1.Visible = false;
                        this.btnPresent.Visible = false;
                        this.ddlBuyer.Enable = false;
                        txtVendor.Attributes.Add("ReadOnly", "ReadOnly");
                        txtContractCode.Attributes.Add("ReadOnly", "ReadOnly");
                        ddlCurrency.Enable = false;
                        break;
                        #endregion
                        #region ThirdAudit
                    case OP.ThirdAudit:
                        if (!Master.HasBrowseRight(SysRight.BORThirdAudit))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.ThirdAudit;
                        this.btnPresent.Visible = false;
                        Image1.Visible = false;
                        this.ddlBuyer.Enable = false;
                        txtVendor.Attributes.Add("ReadOnly", "ReadOnly");
                        txtContractCode.Attributes.Add("ReadOnly", "ReadOnly");
                        ddlCurrency.Enable = false;
                        break;
                        #endregion
                        #region I
                    case OP.I:
                        if (!Master.HasBrowseRight(SysRight.StockIn))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.btnReject.Visible = true;
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.I;
                        Image1.Visible = false;
                        this.btnPresent.Visible = false;
                        this.ddlBuyer.Enable = false;
                        txtVendor.Attributes.Add("ReadOnly", "ReadOnly");
                        txtContractCode.Attributes.Add("ReadOnly", "ReadOnly");
                        ddlCurrency.Enable = false;
                        break;
                        #endregion
                        #region 红字
                    case OP.Red:
                        if (!Master.HasBrowseRight(SysRight.BORCancelOpera))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo="+SysRight.NoRight);
                            return;
                        }
                        this.BindDataNew();
                        Image1.Visible = false;
                        this.btnPresent.Visible = true;
                        this.ddlBuyer.Enable = false;
                        txtVendor.Attributes.Add("ReadOnly", "ReadOnly");
                        txtContractCode.Attributes.Add("ReadOnly", "ReadOnly");
                        ddlCurrency.Enable = false;
                        break;
                        #endregion
                }
            }

            if ((strParentEntryNo != "" && strParentEntryNo != "0")  || this._OP == OP.Red)
            {
                item1.OperateRed = true;
                btnProvicerCom.Visible = false;
                 Image1.Visible = false;
                this.ddlBuyer.Enable = false;
                txtVendor.Attributes.Add("ReadOnly", "ReadOnly");
                txtContractCode.Attributes.Add("ReadOnly", "ReadOnly");
                ddlCurrency.Enable = false;
                ddlStock.Enable = false;
                txtInvoice.Attributes.Add("ReadOnly", "ReadOnly");
                ddlPayStyle.Enable = false;
                ddlCheckResult.Enable = false;
            }
        }
        /// <summary>
        /// 保存按钮。
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            //构建数据实体.
            oBorData = new BillOfReceiveData();
            //填充数据集。
            this.FillBillOfReceiveData(oBorData);
            //设定操作人员信息。
            this.SetOperator(oBorData, this._OP);
            //设定单据状态。
            this.SetEntryState( oBorData, this._OP);

            ret = true;
            IsRepeated = false;
            switch (this._OP)
            {
                    #region New
                case OP.New:
                    if ( Master.HasRight(SysRight.BORMaintain))
                    {
                        TempBORData = new BillOfReceiveData();
                        InvoiceNo = this.txtInvoice.Text;
                        ItemCode = "";

                        //for (i=0; i< this.item1.thisTable.Rows.Count; i++)
                        //{
                        //    ItemCode = this.item1.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString();
                        //    TempBORData = null;
                        //    TempBORData = oPurchaseSystem.GetBRByInvoiceNoAndItemCode(InvoiceNo, ItemCode);
                        //    if (TempBORData.Count > 0)
                        //    {
                        //        IsRepeated = true;
                        //    }
                        //}
                        //if (IsRepeated)
                        //{
                        //    this.txtIsRepeated.Value = "已存在该物料的记录，是否继续？";
                        //}
                        //else
                        //{
                        ret = oPurchaseSystem.AddBR( oBorData );

                         
                        //}
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                    #endregion
                    #region Bor
                case OP.Bor:
                    if (Master.HasRight(SysRight.BORMaintain))
                    {
                        ret = oPurchaseSystem.AddBR(oBorData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                    #endregion
                    #region Edit
                case OP.Edit:
                    if (Master.HasRight(SysRight.BORMaintain))
                    {
                        ret = oPurchaseSystem.UpdateBR( oBorData );
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                    #endregion
                    #region Submit
                case OP.Submit:
                    if (Master.HasRight(SysRight.BORPresent))
                    {
                        ret = oPurchaseSystem.PresentBR(this.doc1.EntryNo, Master.CurrentUser.thisUserInfo.LoginName);
                    }
                    else
                    {
                        ret = false;
                    }
                    
                    break;
                    #endregion
                    #region FirstAudit
                case OP.FirstAudit:
                    if (Master.HasRight(SysRight.BORFirstAudit))
                    {
                        if (oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
                            oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
                        {
                            //this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
                        }
                        else
                        {
                            ret = oPurchaseSystem.FirstAuditBR( oBorData );
                        }
                    }
                    else
                    {
                        ret = false;
                    }
                    
                    break;
                    #endregion
                    #region SecondAudit
                case OP.SecondAudit:
                    if (Master.HasRight(SysRight.BORSecondAudit))
                    {
                        if (oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "Y" &&
                            oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "N")
                        {
                            //this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
                        }
                        else
                        {
                            ret = oPurchaseSystem.SecondAuditBR( oBorData );
                        }
                    }
                    else
                    {
                        ret = false;
                    }
                    
                    break;
                    #endregion
                    #region ThirdAudit
                case OP.ThirdAudit:
                    if (Master.HasRight(SysRight.BORThirdAudit))
                    {
                        if (oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "Y" &&
                            oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "N")
                        {
                            //this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                            return;
                        }
                        else
                        {
                            ret = oPurchaseSystem.ThirdAuditBR( oBorData );
                        }
                    }
                    else
                    {
                        ret = false;
                    }
                    
                    break;
                    #endregion
                    #region I
                case OP.I:
                    if (Master.HasRight(SysRight.StockIn))
                    {
                        ret = oPurchaseSystem.ReceiveBR( oBorData );
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                    #endregion
                    #region Red
                case OP.Red:
                    if (Master.HasRight(SysRight.BORCancelOpera))
                    {
                        ret = oPurchaseSystem.AddBR( oBorData );
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                    #endregion
            }
                    
            if ( ret== false && IsRepeated ==false)
            {
                //item1.thisTable = null;  
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + Server.UrlEncode(oPurchaseSystem.Message));
            }
            else 
            {
                if (IsRepeated == false)
                {
                    //this._OP = "Edit";//一旦保存成功，则自动将当前的单据状态改为编辑模式。
                    //item1.thisTable = null;  
                    if (Master.IsTODO)
                    {
                        this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                    }
                    else
                    {
                        if (this._OP == OP.I)
                        {
                            this.Response.Redirect("PINBrowser.aspx");
                        }
                        else
                        {
                            Response.Redirect("PBORBrowser.aspx?DocCode=6");
                        }
                    
                    }
                }
            }
        }
        /// <summary>
        /// 取消按钮事件。
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //this.item1.thisTable = null;
            if (Master.IsTODO)
            {
               this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
            }
            else
            {
                Response.Redirect("PBORBrowser.aspx?DocCode=6");
            }
        }
        protected void btnPresent_Click(object sender, EventArgs e)
        {
            //没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            //构建数据实体.
            oBorData = new BillOfReceiveData();
            //填充数据集。
            this.FillBillOfReceiveData(oBorData);

            ret = true;

            switch (this._OP)
            {
                case OP.New:
                    this._OP = OP.NewAndPresent;
                    //设定操作人员信息。
                    this.SetOperator(oBorData, this._OP);
                    //设定单据状态。
                    this.SetEntryState(oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR(oBorData);
                    break;
                case OP.Edit:
                    this._OP = OP.EditAndPresent;
                    //设定操作人员信息。
                    this.SetOperator(oBorData, this._OP);
                    //设定单据状态。
                    this.SetEntryState(oBorData, this._OP);
                    ret = oPurchaseSystem.UpdateAndPresentBR(oBorData);
                    break;
                case OP.Bor:
                    this._OP = OP.NewAndPresent;
                    //设定操作人员信息。
                    this.SetOperator(oBorData, this._OP);
                    //设定单据状态。
                    this.SetEntryState(oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR(oBorData);
                    break;
                case OP.Red:
                    this._OP = OP.NewAndPresent;
                    //设定操作人员信息。
                    this.SetOperator(oBorData, this._OP);
                    //设定单据状态。
                    this.SetEntryState(oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR(oBorData);
                    break;
            }

            if (ret == false)
            {
                //item1.thisTable = null;  
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
                //Response.Redirect(Log.LogPath);
            }
            else
            {
                //Response.Write("Success!");
                //this._OP = "Edit";//一旦保存成功，则自动将当前的单据状态改为编辑模式。
                // item1.thisTable = null;  
                if (Master.IsTODO)
                {
                    this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                }
                else
                {

                    if (this._OP == OP.I)
                    {
                        this.Response.Redirect("PINBrowser.aspx");
                    }
                    else
                    {
                        Response.Redirect("PBORBrowser.aspx?DocCode=6");
                    }

                }
            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            this._OP = OP.Reject;
            //构建数据实体.
            oBorData = new BillOfReceiveData();
            //填充数据集。
            this.FillBillOfReceiveData(oBorData);
            //设定操作人员信息。
            this.SetOperator(oBorData, this._OP);
            //设定单据状态。
            this.SetEntryState(oBorData, this._OP);
            var ret = oPurchaseSystem.RejectBR((int)(oBorData.Tables[0].Rows[0][InItemData.ENTRYNO_FIELD]),Master.CurrentUser.LoginName);
            if ( ret== false)
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + Server.UrlEncode(oPurchaseSystem.Message));
            }
            else
            {
                if (Master.IsTODO)
                {
                    this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                }
                else
                {
                    this.Response.Redirect("PINBrowser.aspx");
                }
            }
         
        }
        /*
        /// <summary>
        /// 马上提交事件。
        /// </summary>
        protected void btnPresent_Click(object sender, EventArgs e)
        {
            //没有内容
            if(item1.thisTable.Rows.Count == 0) return;
            //构建数据实体.
            oBorData = new BillOfReceiveData();
            //填充数据集。
            this.FillBillOfReceiveData(oBorData);

            ret = true;

            switch (this._OP)
            {
                case OP.New:
                    this._OP = OP.NewAndPresent;
                    //设定操作人员信息。
                    this.SetOperator(oBorData, this._OP);
                    //设定单据状态。
                    this.SetEntryState( oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR( oBorData );
                    break;
                case OP.Edit:
                    this._OP = OP.EditAndPresent;
                    //设定操作人员信息。
                    this.SetOperator(oBorData, this._OP);
                    //设定单据状态。
                    this.SetEntryState( oBorData, this._OP);
                    ret = oPurchaseSystem.UpdateAndPresentBR( oBorData );
                    break;
                case OP.Bor:
                    this._OP = OP.NewAndPresent;
                    //设定操作人员信息。
                    this.SetOperator(oBorData, this._OP);
                    //设定单据状态。
                    this.SetEntryState( oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR( oBorData );
                    break;
                case OP.Red:
                    this._OP = OP.NewAndPresent;
                    //设定操作人员信息。
                    this.SetOperator(oBorData, this._OP);
                    //设定单据状态。
                    this.SetEntryState( oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR( oBorData );
                    break;
            }
                    
            if ( ret== false)
            {
                //item1.thisTable = null;  
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
                //Response.Redirect(Log.LogPath);
            }
            else
            {
                //Response.Write("Success!");
                //this._OP = "Edit";//一旦保存成功，则自动将当前的单据状态改为编辑模式。
               // item1.thisTable = null;  
                if (Master.IsTODO)
                {
                    this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                }
                else
                {
                   
                    if (this._OP == OP.I)
                    {
                        this.Response.Redirect("PINBrowser.aspx");
                    }
                    else
                    {
                        Response.Redirect("PBORBrowser.aspx?DocCode=6");
                    }
                    
                }
            }
        }*/
        #endregion

        protected void btnDoRepeat_Click(object sender, System.EventArgs e)
        {
            //没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            //构建数据实体.
            oBorData = new BillOfReceiveData();
            //填充数据集。
            this.FillBillOfReceiveData(oBorData);
            //设定操作人员信息。
            this.SetOperator(oBorData, this._OP);
            //设定单据状态。
            this.SetEntryState( oBorData, this._OP);

            ret = true;
            if ( Master.HasRight(SysRight.BORMaintain))
            {
                ret = oPurchaseSystem.AddBR( oBorData );
            }
            else
            {
                ret = false;
            }
            if ( ret== false)
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
                //Response.Redirect(Log.LogPath);
            }
            else
            {
                //this._OP = "Edit";//一旦保存成功，则自动将当前的单据状态改为编辑模式。
                //item1.thisTable = null;  
                if (Master.IsTODO)
                {
                    this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                }
                else
                {
                    if (this._OP == OP.I)
                    {
                        this.Response.Redirect("PINBrowser.aspx?DocCode=6");
                    }
                    else
                    {
                        Response.Redirect("PBORBrowser.aspx?DocCode=6");
                    }
                    
                }
            }
        }

        protected override bool OnBubbleEvent(object Sender,EventArgs e)
        {
            try
            {
                //仓库下拉列表事件。
                if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == this.ddlStock.thisDDL.ClientID)
                {
                    this.item1.StoCode = this.ddlStock.SelectedValue;
                }
            }
            catch
            {}
            return true;
        }

       
    }
}