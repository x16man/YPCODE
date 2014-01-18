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
	/// MRPInput ��ժҪ˵����
	/// </summary>
	public partial class POInput : System.Web.UI.Page
	{
		#region ��Ա����
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

		#region ˽�з���
		/// <summary>
		/// ��������״̬�£����ݰ󶨡�
		/// </summary>
		private void BindDataNew()
		{
			this.doc1.DocCode = DocType.PO;
			this.doc1.DataBindNew();
			this.DocAuditWebControl1.DocCode = DocType.PO;
			
			this.ddlStoManager.Module_Tag = (int)SDDLTYPE.PSLP;
			this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
			
			//������
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
            //������
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
                //�ɹ�Ա��
                this.ddlStoManager.SelectedText = oDT.Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
                this.ddlStoManager.SelectedValue = oDT.Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
                //��ע��
                this.item1.txtRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //���ʽ��
                if (_OP != OP.Copy)
                {
                    this.ddlPayStyle.SetItemSelected(oDT.Rows[0][PPRNData.PAYSTYLE_FIELD].ToString());
                    this.ddlPayStyle.SelectedValue = oDT.Rows[0][PPRNData.PAYSTYLE_FIELD].ToString();
                }
                //�����̡�
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

                //��������
                this.TxtPayment.Text = oDT.Rows[0][PurchaseOrderData.PAYMENT_FIELD].ToString();
                this.ddlStoManager.SelectedValue = oDT.Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
                
            }
        }
        /// <summary>
        /// �༭����״̬�£����ݰ󶨡�
        /// </summary>
        private void BindDataUpdate()
        {
            //������
            this.PscBindData();
            this.DocAuditWebControl1.DocCode = DocType.PO;

            PurchaseOrderData oPOData;

            this.doc1.DocCode = DocType.PO;
            this.doc1.DataBindUpdate();
            this.ddlStoManager.Module_Tag = (int)SDDLTYPE.PSLP;
            this.ddlPayStyle.Module_Tag = (int)SDDLTYPE.PAYSTYLE;
            //��������䵽���ݼ�,DataGrid������Դ��
            if (this._OP != OP.Red)
            {
                oPOData = oPurchaseSystem.GetPOByEntryNo(Master.EntryNo);
            }
            else
            {
                oPOData = oPurchaseSystem.GetPORepealEntryNo(Master.EntryNo);
            }
            //��������ǰ��������
            this.CheckOpPrecondition(this._OP, oPOData);

            var oDT = oPOData.Tables[PurchaseOrderData.PORD_TABLE];

            //�������ͽ���Ϊ����
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
                //̨ͷ���֡�
                this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
                this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
                this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
                //�ɹ�Ա��
                this.ddlStoManager.SelectedText = oDT.Rows[0][PurchaseOrderData.BUYERNAME_FIELD].ToString();
                this.ddlStoManager.SelectedValue = oDT.Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
                //��ע��
                this.item1.txtRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //���ʽ��
                if (_OP != OP.New)
                {
                    this.ddlPayStyle.SetItemSelected(oDT.Rows[0][PPRNData.PAYSTYLE_FIELD].ToString());
                    this.ddlPayStyle.SelectedValue = oDT.Rows[0][PPRNData.PAYSTYLE_FIELD].ToString();
                }
                //�����̡�
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

                //��������
                this.TxtPayment.Text = oDT.Rows[0][PurchaseOrderData.PAYMENT_FIELD].ToString();
                this.ddlStoManager.SelectedValue = oDT.Rows[0][PurchaseOrderData.BUYERCODE_FIELD].ToString();
                //�����Ρ�
                //Ϊ���������Ҳ��ǲɹ�Աȷ�ϵ�ʱ��
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
		/// ����ָ�������б��ѡ���
		/// </summary>
		/// <param name="List">DropDownList�������б�</param>
		/// <param name="TargetValue">string:	ָ��ֵ��</param>
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
		/// ����������
		/// </summary>
		private void PscBindData()
		{
			PPRNData oPPRNData = (new PurchaseSystem()).GetPPRNSelf();
			this.lblPscCode.Text = oPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CODE_FIELD].ToString();
			this.lblPscName.Text = oPPRNData.Tables[PPRNData.PPRN_TABLE].Rows[0][PPRNData.CNNAME_FIELD].ToString();
		}
		/// <summary>
		/// ���õ���״̬��
		/// </summary>
		/// <param name="oPOData">PurchaseOrderData:	�ɹ�����ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEntryState(PurchaseOrderData oPOData, string OpMode)
		{
			if ( oPOData.Count > 0)
			{
				oDataRow = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];
				oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oPOData.Tables[PurchaseOrderData.PORD_TABLE]).GetEntryState(OpMode);
			}
		}
		/// <summary>
		/// ���õ��ݲ����ˡ�
		/// </summary>
		/// <param name="oPOData">PurchaseOrderData:	�ɹ�����ʵ�塣</param>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetOperator(PurchaseOrderData oPOData, string OpMode)
		{
			if ( oPOData.Count > 0)
			{
				DataRow oDataRow = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0];

				switch (OpMode)
				{
					case OP.New://�½���
                    case OP.Copy://����
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
					case OP.NewAndAssign://�½�����ָ�ɡ�
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
					case OP.EditAndAssign:
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
				}
			}
		}

		/// <summary>
		/// ������ݼ���
		/// </summary>
		/// <param name="oPOdata">PurchaseOrderData:	�ɹ�����ʵ�塣</param>
		private void FillData(PurchaseOrderData oPOdata)
		{
			dr = oPOdata.Tables[PurchaseOrderData.PORD_TABLE].NewRow();
			//����̨ͷ�������ݡ�
			dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//������ˮ�š�
			dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//���ݱ�š�
			dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//�������͡�
			dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//�����������ơ�
			dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//�����ĵ���š�
			dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//�������ڡ�

			//dr[PurchaseOrderData.PRVCODE_FIELD] = ddlPrv.SelectedValue;			    //������
            dr[PurchaseOrderData.PRVCODE_FIELD] = this.txtVendorCode.Value;
			dr[PurchaseOrderData.PRVNAME_FIELD] = this.txtVendor.Text;
			dr[PurchaseOrderData.PRVADD_FIELD] = this.txtAdd.Text;                       //�����̵�ַ��
            dr[PurchaseOrderData.PRVZIP_FIELD] = this.txtZip.Value;                  //�ʱࡣ
			dr[PurchaseOrderData.PRVTEL_FIELD] = this.txtTel.Text;                  //�绰��
            dr[PurchaseOrderData.PRVFAX_FIELD] = this.txtFax.Value;                  //���档
			//dr[PurchaseOrderData.PRVLICENCE_FIELD] = this.txtLicence.Text;          //Ӫҵִ�պš�
            dr[PurchaseOrderData.PRVBANK_FIELD] = this.txtBank.Value;                //�������С�
			dr[PurchaseOrderData.PRVACCOUNT_FIELD] = this.txtAccount.Text;          //�����ʻ���
            dr[PurchaseOrderData.PRVTAXNO_FIELD] = this.txtTaxNo.Value;              //˰��ǼǺš�
			//dr[PurchaseOrderData.CURRENCYCODE_FIELD] = this.ddlCurrency.SelectedValue; //���֡�
            dr[PurchaseOrderData.CURRENCYCODE_FIELD] = this.txtCurrency.Value;
			dr[PurchaseOrderData.PAYSTYLE_FIELD] = this.ddlPayStyle.SelectedValue;  //���ʽ��
			dr[PurchaseOrderData.PAYMENT_FIELD] = this.TxtPayment.Text;             //�������

			dr[InItemData.REMARK_FIELD] = this.item1.txtRemark.Text;				//��ע��
			dr[PurchaseOrderData.BUYERNAME_FIELD] = ddlStoManager.SelectedText;		//�ɹ�Ա���ơ�
			dr[PurchaseOrderData.BUYERCODE_FIELD] = ddlStoManager.SelectedValue;	//�ɹ�Ա��š�
			dr[PurchaseOrderData.PSCCODE_FIELD] = this.lblPscCode.Text;             //������š�
			dr[PurchaseOrderData.PSCNAME_FIELD] = this.lblPscName.Text;              //�������ơ�
			//�����Ρ�
			dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//һ��������
			dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//����������
			dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//����������
			
			dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//һ�����������
			dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//�������������
			dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//�������������
			//������ϸ��
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
			dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);//�ϼƽ�

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
		/// ��������ǰ��������
		/// </summary>
		/// <param name="OpMode">string:	����ģʽ��</param>
        /// <param name="oPOData">PurchasePlanData:	��������ʵ�塣</param>
		private void CheckOpPrecondition(string OpMode,PurchaseOrderData oPOData)
		{
			switch (OpMode)
			{
				case OP.Edit://�༭��
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
				case OP.Assigned://�ύ��
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
						oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XAssign, true); }
					break;
				case OP.FirstAudit://һ��������
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Assigned)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XFirstAudit, true); }
					break;
				case OP.SecondAudit://����������
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
					{	return ;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XSecondAudit, true); }
					break;
				case OP.ThirdAudit://����������
					if (oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
					{	return;	}
					else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchaseOrderData.XThirdAudit, true); }
					break;
				case OP.Affirm://�ɹ�Աȷ�ϡ�
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
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=�˶������ǲɹ���������,�����ٴγ����!", true);
                        }
                        //�����ǰ�û��뱻���Ĳɹ��������Ƶ��û�����ͬһ���ˣ���������в�����
                        if ((this.Session["User"] as Shmzh.Components.SystemComponent.User).thisUserInfo.LoginName != oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.AUTHORLOGINID_FIELD].ToString())
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=�˶���Ϊ���˵Ĳɹ�����������Ȩ���к�壡!", true);
                            return;
                        }
                        var strState = oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString();


                        if (strState == "E")//ΪEȷ��TΪ���ͨ����
                        {
                            return;
                        }
                        else
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=ֻ�вɹ�ȷ�Ϻ��״̬���ܳ����������֮ǰ�Ľڵ㣬����ͨ���ܾ���������ͨ���ķ�ʽ���˻ء�", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=ֻ��Ƿȱ��������0�Ķ������ܳ���", true);
                    }


                    break;
			}
		}
		#endregion
		
		#region �¼�
		/// <summary>
		/// ҳ���Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.PO;
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
                    case OP.Red://����
                        if (!Master.HasBrowseRight(SysRight.POCancelOpera))
                        {
                            return;
                        }

                        this.BindDataUpdate();
                        this.btnSave.Text = "����";
                        this.btnPresent.Visible = true;
                        TxtPayment.Attributes.Add("ReadOnly", "ReadOnly");
                        break;
				}

			}
			//������ѡ��仯ʱ�����°󶨹����̡�
//			if(this.IsPostBack)
//			{
//				if(ddlPrv.SelectedValue != "") PrvBindData(ddlPrv.SelectedValue);
//			}

		}
		
        /// <summary>
		/// ���水ť��
		/// </summary>
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			//û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

			//��������ʵ��.
		    oPOdata = new PurchaseOrderData();
			//������ݼ���
			this.FillData(oPOdata);
			//���õ���״̬��
			this.SetEntryState(oPOdata,this._OP);
			//���ò����ˡ�
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
						//���õ���״̬��
						this.SetEntryState(oPOdata,OP.NewAndAssign);
						//���ò����ˡ�
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
						//���õ���״̬��
						this.SetEntryState(oPOdata,OP.NewAndAssign);
						//���ò����ˡ�
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
                            ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
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
		/// ȡ����ť�¼���
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
		/// ����ָ���¼���
		/// </summary>
		protected void btnPresent_Click(object sender, System.EventArgs e)
		{
			//û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }
			//��������ʵ��.
			oPOdata = new PurchaseOrderData();
			//������ݼ���
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
						//���õ���״̬��
						this.SetEntryState(oPOdata,this._OP);
						//���ò����ˡ�
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
						//���õ���״̬��
						this.SetEntryState(oPOdata,this._OP);
						//���ò����ˡ�
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
                        //���õ���״̬��
                        this._OP = OP.NewAndAssign;
                        this.SetEntryState(oPOdata, this._OP);
                        //���ò����ˡ�
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
        /// ��������ҳ�����
        /// </summary>
        public void CancelControl(string strParentEntryNo)
        {
            if ((strParentEntryNo != "" && strParentEntryNo != "0") || this._OP == OP.Red)
            {
                //this.doc1.DocName = "�ɹ�����������";
                //classvalue = "hidden";
                ddlPayStyle.Enable = false;
                ddlStoManager.Enable = false;
                this.Image1.Visible = false;
                //���б��ϵ���������Ť��Ϊ���ɼ� 
                item1.NewBtnClass = "display: none;visibility:hidded;";
            }
        }

        /// <summary>
        /// ��������ҳ�����
        /// </summary>
        public void CancelControl(string strParentEntryNo, string strstate)
        {
            if ((strParentEntryNo != "" && strParentEntryNo != "0") || this._OP == OP.Red)
            {
                //this.doc1.DocName = "�ɹ�����������";
                //classvalue = "hidden";
                ddlPayStyle.Enable = false;
                if (strstate != "T")
                    ddlStoManager.Enable = false;
                this.Image1.Visible = false;
            }
        }
		
        /// <summary>
		/// ��Ӧ�������б�ı��¼���
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
