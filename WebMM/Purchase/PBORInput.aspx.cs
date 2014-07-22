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
    /// ROSInput ��ժҪ˵����
    /// </summary>
    public partial class PBORInput : Page
    {
        #region ��Ա����
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
        
        #region ˽�з���
        /// <summary>
        /// ��������״̬�£����ݰ󶨡�
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

                if (this._OP == OP.Bor)//��������ν��������ɡ�
                {
                    SourceEntryNo = int.Parse(this.Request["EntryNo"].ToString().Split('|')[0]);
                    oPBRBData = new PurchaseSystem().GetPBRBByEntryNo(SourceEntryNo);
                    this.ddlStock.SelectedValue = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.STOCODE_FIELD].ToString();
                }
            }
            else		   //���֡�
            {
                oBORData = oPurchaseSystem.GetBROldByEntryNo(Master.EntryNo);

                if (oBORData.Tables[0].Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�˵����Ѿ��������ֲ����������ٴν��к��ֲ�����');document.location='PBORBrowser.aspx?DocCode=6';", true);
                    return;
                }
               
            
                oBORData = oPurchaseSystem.GetBRByEntryNo(Master.EntryNo);
                strParentEntryNo = oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString();
                if (strParentEntryNo != "" )
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�˵����Ǻ��ֲ������ݲ������ٴν��к��ֲ�����');document.location='PBORBrowser.aspx?DocCode=6';", true);
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
                    
                    //�жϲ�����ǰ������.
                    this.CheckOpPrecondition(this._OP,oBORData);
                    oDT = oBORData.Tables[BillOfReceiveData.PBOR_TABLE];
                    this.item1.thisTable = oDT;
                    if (oDT.Rows.Count > 0)
                    {
                        //���ս����
                        this.ddlCheckResult.SelectedValue = oDT.Rows[0][BillOfReceiveData.CHKRESULT_FIELD].ToString();
                        //���ʽ
                        this.ddlPayStyle.SetItemSelected(oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString());
                        //��Ӧ�̡�
                        this.txtVendor.Text = oDT.Rows[0][BillOfReceiveData.PRVNAME_FIELD].ToString();
                        this.txtVendorCode.Value = oDT.Rows[0][BillOfReceiveData.PRVCODE_FIELD].ToString();
                        //�ֿ⡣
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
                    //this.Response.Write("<Script>alert('�ɹ����ϵ������ֵ�ǰ�������Ǹõ��������ϣ�');</Script>");
                    //this.Response.Redirect("PBORBrowser.aspx",true);
                    ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�ɹ����ϵ������ֵ�ǰ�������Ǹõ��������ϣ�');document.location='PBORBrowser.aspx?DocCode=6';", true);
                }
            }
        }
        /// <summary>
        /// �༭����״̬�£����ݰ󶨡�
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
            //��������䵽���ݼ�,DataGrid������Դ��
            if (this._OP == OP.I)
            {
                oBORData = oPurchaseSystem.GetBRByEntryNoInMode(Master.EntryNo);
            }
            else
            {
                oBORData = oPurchaseSystem.GetBRByEntryNo(Master.EntryNo);
            }
            //�жϲ�����ǰ������.
            this.CheckOpPrecondition(this._OP,oBORData);

            oDT = oBORData.Tables[BillOfReceiveData.PBOR_TABLE];
            this.item1.thisTable = oDT;
            
            if (oDT.Rows.Count > 0)
            {
                strParentEntryNo = oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][PurchaseOrderData.ParentEntryNo_Field].ToString();
                

                //̨ͷ���֡�
                this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
                this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
                this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
                //�����Ρ�
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

                

                //��Ӧ�������ݡ�
                this.txtParentEntryNo.Value = oDT.Rows[0][BillOfReceiveData.PARENTENTRYNO_FIELD].ToString();
                //�ɹ�Ա��
                this.ddlBuyer.SelectedText = oDT.Rows[0][BillOfReceiveData.BUYERNAME_FIELD].ToString();
                this.ddlBuyer.SelectedValue = oDT.Rows[0][BillOfReceiveData.BUYERCODE_FIELD].ToString();
                this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
                //���ս����
                this.ddlCheckResult.SelectedValue = oDT.Rows[0][BillOfReceiveData.CHKRESULT_FIELD].ToString();
                //���ʽ
                this.ddlPayStyle.SelectedValue = oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString();
                switch (oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString())
                {
                    case "G":
                        this.ddlPayStyle.SelectedText = "��ί";
                        break;
                    case "Q":
                        this.ddlPayStyle.SelectedText = "�ֽ�";
                        break;
                    case "C":
                        this.ddlPayStyle.SelectedText = "֧Ʊ";
                        break;
                }
                this.ddlPayStyle.SetItemSelected(oDT.Rows[0][BillOfReceiveData.PAYSTYLE_FIELD].ToString());
                //��Ӧ�̡�
                this.txtVendorCode.Value = oDT.Rows[0]["PrvCode"].ToString();
                this.txtVendor.Text = oDT.Rows[0]["PrvName"].ToString();
                //�ֿ⡣
                this.ddlStock.SelectedText = oDT.Rows[0][BillOfReceiveData.STONAME_FIELD].ToString();
                this.ddlStock.SelectedValue = oDT.Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString();
                //��λ��
                if (this._OP == OP.I)
                {
                    this.item1.ddlCon.StoCode = oDT.Rows[0][BillOfReceiveData.STOCODE_FIELD].ToString();
                    this.item1.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
                }
                //��Ʊ�š�
                this.txtInvoice.Text = oDT.Rows[0][BillOfReceiveData.INVOICENO_FIELD].ToString();
                //�跽��Ŀ��
                this.txtJFKM.Value = oDT.Rows[0][BillOfReceiveData.JFKM_FIELD].ToString();
                //���ڡ�
                this.txtUsedFor.Text = oDT.Rows[0][BillOfReceiveData.USEDFOR_FIELD].ToString();
                //�����ˡ�
                this.lblAccept.Text = oDT.Rows[0][BillOfReceiveData.ACCEPTNAME_FIELD].ToString();
                //�Ƶ��ˡ�
                this.lblAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
                //��ͬ��š�
                this.txtContractCode.Text = oDT.Rows[0][BillOfReceiveData.CONTRACTCODE_FIELD].ToString();
                //��ע��
                this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //���á�
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
        /// ����ָ�������б��ѡ���
        /// </summary>
        /// <param name="List">DropDownList�������б�</param>
        /// <param name="TargetValue">string:	ָ��ֵ��</param>
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
        /// ���õ���״̬��
        /// </summary>
        /// <param name="oBorData">BillOfReceiveData:	���ϵ�ʵ�塣</param>
        /// <param name="OpMode">string:	�������͡�</param>
        private void SetEntryState(BillOfReceiveData oBorData, string OpMode)
        {
            if ( oBorData.Count > 0)
            {
                oDataRow = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0];
                oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oBorData.Tables[0]).GetEntryState(OpMode);
            }
        }
        /// <summary>
        /// ���ò�����Ա��Ϣ��
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
                    case OP.New://�½���
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.Red://���֡�
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.Bor://�����ν��������ɡ�
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.NewAndPresent://�½������ύ��
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.Edit://�༭��
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.EditAndPresent://�༭�����ύ��
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.FirstAudit://һ��������
                        oDataRow[InItemData.ASSESSOR1_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.SecondAudit://����������
                        oDataRow[InItemData.ASSESSOR2_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.ThirdAudit://����������
                        oDataRow[InItemData.ASSESSOR3_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.I://���ϡ�
                        oDataRow[BillOfReceiveData.ACCEPTCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[BillOfReceiveData.ACCEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                    case OP.Reject://���Ͼܾ�
                        oDataRow[BillOfReceiveData.ACCEPTCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[BillOfReceiveData.ACCEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        break;
                }
            }
        }
        /// <summary>
        /// ����ҳ��������������ݼ���
        /// </summary>
        /// <param name="oBorData">BillOfReceiveData:	���ϵ�����ʵ�塣</param>
        private void FillBillOfReceiveData(BillOfReceiveData oBorData)
        {
            

            dr = oBorData.Tables[BillOfReceiveData.PBOR_TABLE].NewRow();
            //����̨ͷ�������ݡ�
            dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//������ˮ�š�
            dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//���ݱ�š�
            dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//�������͡�
            dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//�����������ơ�
            dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//�����ĵ���š�
            dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//�������ڡ�
            dr[BillOfReceiveData.PRVCODE_FIELD] = this.txtVendorCode.Value;		//��Ӧ��λ��
           // dr[BillOfReceiveData.PRVCODE_FIELD] = this.txtVendorCode.Value;

            dr[BillOfReceiveData.PRVNAME_FIELD] = this.txtVendor.Text;			//��Ӧ�����ơ�
            dr[BillOfReceiveData.PRVNAME_FIELD] = this.txtVendor.Text;
            dr[BillOfReceiveData.STOCODE_FIELD] = ddlStock.SelectedValue;			//�ֿ��š�
            dr[BillOfReceiveData.STONAME_FIELD] = ddlStock.SelectedText;			//�ֿ����ơ�
            dr[BillOfReceiveData.CURRENCYCODE_FIELD] = ddlCurrency.SelectedValue;   //����
            dr[BillOfReceiveData.INVOICENO_FIELD] = Master.GetNoSpaceString(txtInvoice.Text);		//��Ʊ��
            dr[BillOfReceiveData.JFKM_FIELD] = txtJFKM.Value;						//��ƿ�Ŀ��
            dr[BillOfReceiveData.PAYSTYLE_FIELD] = ddlPayStyle.SelectedValue;		//���ʽ��
            dr[BillOfReceiveData.CHKRESULT_FIELD] = ddlCheckResult.SelectedValue;	//���������
            dr[BillOfReceiveData.USEDFOR_FIELD] = txtUsedFor.Text;					//���ڡ�
            dr[BillOfReceiveData.BUYERNAME_FIELD] = ddlBuyer.SelectedText;			//�ɹ�Ա���ơ�
            dr[BillOfReceiveData.BUYERCODE_FIELD] = ddlBuyer.SelectedValue;			//�ɹ�Ա��š�
            dr[BillOfReceiveData.CONTRACTCODE_FIELD] = this.txtContractCode.Text;	//��ͬ��š�
            try { dr[BillOfReceiveData.PARENTENTRYNO_FIELD] = Convert.ToInt32(this.txtParentEntryNo.Value); }	//��Ӧ��������ˮ�š�
            catch{}
            dr[BillOfReceiveData.TOTALFEE_FIELD] = this.item1.TotalFee;//���á�

            dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//һ��������
            dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//����������
            dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//����������
            dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//һ�����������
            dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//�������������
            dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//�������������
            dr[InItemData.REMARK_FIELD] = this.item1.Remark;						//��ע��
            
            //�����ַ�����
            BorCol2List = new Col2List(this.item1.thisTable);
            //�������ʵ��㡣
            dr[BillOfReceiveData.TOTALMONEY_FIELD] = BorCol2List.GetSum(InItemData.ITEMMONEY_FIELD);//���Ͻ�
            dr[BillOfReceiveData.TOTALTAX_FIELD] = BorCol2List.GetSum(BillOfReceiveData.ITEMTAX_FIELD);//˰�
            //dr[BillOfReceiveData.TOTALDISCOUNT_FIELD] = BorCol2List.GetSum(BillOfReceiveData.ITEMDISCOUNT_FIELD);//�ۿۡ�
            dr[InItemData.SUBTOTAL_FIELD] = BorCol2List.GetSum(BillOfReceiveData.ITEMSUM_FIELD);//�����ܽ�
            dr[InItemData.SERIALNO_FIELD] = BorCol2List.GetList();//˳������ӡ�
            dr[BillOfReceiveData.SOURCEENTRY_FIELD] = BorCol2List.GetList(BillOfReceiveData.SOURCEENTRY_FIELD);//Դ���ݺš�
            dr[BillOfReceiveData.SOURCEDOCCODE_FIELD] = BorCol2List.GetList(BillOfReceiveData.SOURCEDOCCODE_FIELD);//Դ�������ͺš�
            dr[BillOfReceiveData.SOURCESERIALNO_FIELD] = BorCol2List.GetList(BillOfReceiveData.SOURCESERIALNO_FIELD);//Դ������ˮ�š�
            dr[InItemData.NEWCODE_FIELD] = BorCol2List.GetList(InItemData.NEWCODE_FIELD);
            dr[InItemData.ITEMCODE_FIELD] = BorCol2List.GetList(InItemData.ITEMCODE_FIELD);//���ϱ�š�
            dr[InItemData.ITEMNAME_FIELD] = BorCol2List.GetList(InItemData.ITEMNAME_FIELD);//�������ơ�
            dr[InItemData.ITEMSPECIAL_FIELD] = BorCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);//����ͺš�
            dr[InItemData.ITEMUNIT_FIELD] = BorCol2List.GetList(InItemData.ITEMUNIT_FIELD);//��λ��š�
            dr[InItemData.ITEMUNITNAME_FIELD] = BorCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);//��λ���ơ�
            dr[BillOfReceiveData.BATCHCODE_FIELD] = BorCol2List.GetList(BillOfReceiveData.BATCHCODE_FIELD);//���š�
            dr[InItemData.ITEMPRICE_FIELD] = BorCol2List.GetList(InItemData.ITEMPRICE_FIELD);//���ۡ�
            dr[BillOfReceiveData.PLANNUM_FIELD] = BorCol2List.GetList(BillOfReceiveData.PLANNUM_FIELD);//Ӧ��������
            dr[InItemData.ITEMNUM_FIELD] = BorCol2List.GetList(InItemData.ITEMNUM_FIELD);//ʵ��������
            dr[InItemData.ITEMMONEY_FIELD] = BorCol2List.GetList(InItemData.ITEMMONEY_FIELD);//���Ͻ�
            dr[BillOfReceiveData.TAXCODE_FIELD] = BorCol2List.GetList(BillOfReceiveData.TAXCODE_FIELD);//˰�롣
            dr[BillOfReceiveData.TAXRATE_FIELD] = BorCol2List.GetList(BillOfReceiveData.TAXRATE_FIELD);//˰�ʡ�
            dr[BillOfReceiveData.ITEMTAX_FIELD] = BorCol2List.GetList(BillOfReceiveData.ITEMTAX_FIELD);//˰�
            //dr[BillOfReceiveData.DISCOUNTRATE_FIELD] = BorCol2List.GetList(BillOfReceiveData.DISCOUNTRATE_FIELD);//�ۿ��ʡ�
            //dr[BillOfReceiveData.ITEMDISCOUNT_FIELD] = BorCol2List.GetList(BillOfReceiveData.ITEMDISCOUNT_FIELD);//�ۿۡ�
            dr[BillOfReceiveData.ITEMFEE_FIELD] = BorCol2List.GetList(BillOfReceiveData.ITEMFEE_FIELD);//���á�
            dr[BillOfReceiveData.ITEMSUM_FIELD] = BorCol2List.GetList(BillOfReceiveData.ITEMSUM_FIELD);//�����ܽ�
            dr[BillOfReceiveData.CONCODE_FIELD] = BorCol2List.GetList(BillOfReceiveData.CONCODE_FIELD);//��λ��š�
            dr[BillOfReceiveData.CONNAME_FIELD] = BorCol2List.GetList(BillOfReceiveData.CONNAME_FIELD);//��λ���ơ�
            oBorData.Tables[BillOfReceiveData.PBOR_TABLE].Rows.Add(dr);
        }
        /// <summary>
        /// ��������ǰ��������
        /// </summary>
        /// <param name="OpMode">string:	����ģʽ��</param>
        /// <param name="oBORData">BillOfReceiveData:	���ϵ�ʵ�塣</param>
        private void CheckOpPrecondition(string OpMode,BillOfReceiveData oBORData)
        {
            switch (OpMode)
            {
                case OP.Edit://�༭��
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
                case OP.Submit://�ύ��
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
                case OP.FirstAudit://һ��������
                    if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
                    {	return;	}
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + BillOfReceiveData.XFirstAudit, true); }
                    break;
                case OP.SecondAudit://����������
                    if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
                    {	return ;	}
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + BillOfReceiveData.XSecondAudit, true); }
                    break;
                case OP.ThirdAudit://����������
                    if (oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
                    {	return;	}
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + BillOfReceiveData.XThirdAudit, true); }
                    break;
            }
        }
        #endregion
        
    
        
        #region �¼�
        /// <summary>
        /// ҳ��Load�¼���
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[MySession.Help] = HelpCode.BOR;
            // �ڴ˴������û������Գ�ʼ��ҳ��
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
                        #region ����
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
        /// ���水ť��
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

            //��������ʵ��.
            oBorData = new BillOfReceiveData();
            //������ݼ���
            this.FillBillOfReceiveData(oBorData);
            //�趨������Ա��Ϣ��
            this.SetOperator(oBorData, this._OP);
            //�趨����״̬��
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
                        //    this.txtIsRepeated.Value = "�Ѵ��ڸ����ϵļ�¼���Ƿ������";
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
                            //this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
                            //this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
                            //this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
                    //this._OP = "Edit";//һ������ɹ������Զ�����ǰ�ĵ���״̬��Ϊ�༭ģʽ��
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
        /// ȡ����ť�¼���
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
            //û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

            //��������ʵ��.
            oBorData = new BillOfReceiveData();
            //������ݼ���
            this.FillBillOfReceiveData(oBorData);

            ret = true;

            switch (this._OP)
            {
                case OP.New:
                    this._OP = OP.NewAndPresent;
                    //�趨������Ա��Ϣ��
                    this.SetOperator(oBorData, this._OP);
                    //�趨����״̬��
                    this.SetEntryState(oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR(oBorData);
                    break;
                case OP.Edit:
                    this._OP = OP.EditAndPresent;
                    //�趨������Ա��Ϣ��
                    this.SetOperator(oBorData, this._OP);
                    //�趨����״̬��
                    this.SetEntryState(oBorData, this._OP);
                    ret = oPurchaseSystem.UpdateAndPresentBR(oBorData);
                    break;
                case OP.Bor:
                    this._OP = OP.NewAndPresent;
                    //�趨������Ա��Ϣ��
                    this.SetOperator(oBorData, this._OP);
                    //�趨����״̬��
                    this.SetEntryState(oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR(oBorData);
                    break;
                case OP.Red:
                    this._OP = OP.NewAndPresent;
                    //�趨������Ա��Ϣ��
                    this.SetOperator(oBorData, this._OP);
                    //�趨����״̬��
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
                //this._OP = "Edit";//һ������ɹ������Զ�����ǰ�ĵ���״̬��Ϊ�༭ģʽ��
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
            //��������ʵ��.
            oBorData = new BillOfReceiveData();
            //������ݼ���
            this.FillBillOfReceiveData(oBorData);
            //�趨������Ա��Ϣ��
            this.SetOperator(oBorData, this._OP);
            //�趨����״̬��
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
        /// �����ύ�¼���
        /// </summary>
        protected void btnPresent_Click(object sender, EventArgs e)
        {
            //û������
            if(item1.thisTable.Rows.Count == 0) return;
            //��������ʵ��.
            oBorData = new BillOfReceiveData();
            //������ݼ���
            this.FillBillOfReceiveData(oBorData);

            ret = true;

            switch (this._OP)
            {
                case OP.New:
                    this._OP = OP.NewAndPresent;
                    //�趨������Ա��Ϣ��
                    this.SetOperator(oBorData, this._OP);
                    //�趨����״̬��
                    this.SetEntryState( oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR( oBorData );
                    break;
                case OP.Edit:
                    this._OP = OP.EditAndPresent;
                    //�趨������Ա��Ϣ��
                    this.SetOperator(oBorData, this._OP);
                    //�趨����״̬��
                    this.SetEntryState( oBorData, this._OP);
                    ret = oPurchaseSystem.UpdateAndPresentBR( oBorData );
                    break;
                case OP.Bor:
                    this._OP = OP.NewAndPresent;
                    //�趨������Ա��Ϣ��
                    this.SetOperator(oBorData, this._OP);
                    //�趨����״̬��
                    this.SetEntryState( oBorData, this._OP);
                    ret = oPurchaseSystem.AddAndPresentBR( oBorData );
                    break;
                case OP.Red:
                    this._OP = OP.NewAndPresent;
                    //�趨������Ա��Ϣ��
                    this.SetOperator(oBorData, this._OP);
                    //�趨����״̬��
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
                //this._OP = "Edit";//һ������ɹ������Զ�����ǰ�ĵ���״̬��Ϊ�༭ģʽ��
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
            //û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

            //��������ʵ��.
            oBorData = new BillOfReceiveData();
            //������ݼ���
            this.FillBillOfReceiveData(oBorData);
            //�趨������Ա��Ϣ��
            this.SetOperator(oBorData, this._OP);
            //�趨����״̬��
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
                //this._OP = "Edit";//һ������ɹ������Զ�����ǰ�ĵ���״̬��Ϊ�༭ģʽ��
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
                //�ֿ������б��¼���
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