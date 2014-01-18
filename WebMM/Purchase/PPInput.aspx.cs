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
    using System.Data;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
    using SysRight = Common.SysRight;

    /// <summary>
    /// MRPInput ��ժҪ˵����
    /// </summary>
    public partial class PPInput : System.Web.UI.Page
    {
        #region ��Ա����
        private string _OP;
        //private bool IsTODO;
        //private int _EntryNo;
        //protected DocWebControl doc1=new DocWebControl();
        //protected StorageDropdownlist ddlDept=new StorageDropdownlist();
        //protected DocAuditWebControl DocAuditWebControl1=new DocAuditWebControl();
        //protected PPWebControl item1 = new PPWebControl();
        //protected User myUser;
        //protected string AlertMessage = "<script>alert(\""+SysRight.NoRight+"\");</script>";

       // PPSData oPPSData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

        private Col2List MyCol2List;

        
        private DataRow dr;

        private DataRow oDataRow;

        private PurchasePlanData oPurchasePlanData;

        private  PPSData oPPSData;

        private bool ret;

        DataTable oDT;
        #endregion

        #region ˽�з���
        /// <summary>
        /// ��������״̬�£����ݰ󶨡�
        /// </summary>
        private void BindDataNew()
        {
            this.doc1.DocCode = DocType.PP;
            this.doc1.DataBindNew();
            this.DocAuditWebControl1.DocCode = DocType.PP;
            this.ddlDept.Module_Tag = (int)SDDLTYPE.AllDept;
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
            this.ddlDept.DocType = DocType.PP;
            ddlDept.DeptCo = Master.CurrentUser.thisUserInfo.EmpCo;
            this.ddlDept.SelectedValue = Master.CurrentUser.thisUserInfo.DeptCode;
            this.txtAuthor.Text = Master.CurrentUser.thisUserInfo.EmpName;

            item1.DeptCo = Master.CurrentUser.thisUserInfo.EmpCo;

            oPPSData = oPurchaseSystem.GetPPSAll(Master.CurrentUser.thisUserInfo.LoginName);
            this.item1.thisTable = oPPSData.Tables[PPSData.PPS_TABLE];
        }
        /// <summary>
        /// �༭����״̬�£����ݰ󶨡�
        /// </summary>
        private void BindDataUpdate()
        {
           
            this.doc1.DocCode = DocType.PP;
            this.doc1.DataBindUpdate();
            this.DocAuditWebControl1.DocCode = DocType.PP;
            this.ddlDept.Module_Tag = (int)SDDLTYPE.AllDept;
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
            ddlDept.DeptCo = Master.CurrentUser.thisUserInfo.EmpCo;
            this.ddlDept.DocType = DocType.PP;

            item1.DeptCo = Master.CurrentUser.thisUserInfo.EmpCo;

            //��������䵽���ݼ�,DataGrid������Դ��
            if (this._OP == OP.Edit || this._OP == OP.Submit)
                oPurchasePlanData = oPurchaseSystem.GetPPByEntryNo(Master.EntryNo);
            else
                oPurchasePlanData = oPurchaseSystem.GetPPByEntryNoExceptZero(Master.EntryNo);

            this.CheckOpPrecondition(this._OP, oPurchasePlanData);
            oDT = oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE];

            this.item1.thisTable = oDT;

            if (oDT.Rows.Count > 0)
            {
                //̨ͷ���֡�
                this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
                this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
                this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
                this.doc1.PlanYear = Convert.ToDateTime(oDT.Rows[0][PurchasePlanData.PLANDATE_FIELD].ToString()).Year;//�ƻ��ꡣ
                this.doc1.PlanMonth = Convert.ToDateTime(oDT.Rows[0][PurchasePlanData.PLANDATE_FIELD].ToString()).Month;//�ƻ��¡�
                //�����Ρ�
                this.DocAuditWebControl1.Auditor1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                this.DocAuditWebControl1.Auditor2 = oDT.Rows[0][InItemData.ASSESSOR2_FIELD].ToString();
                this.DocAuditWebControl1.Auditor3 = oDT.Rows[0][InItemData.ASSESSOR3_FIELD].ToString();
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
                    this.DocAuditWebControl1.txtAuditDate2.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString()).ToString("yyyy-MM-dd");
                    this.DocAuditWebControl1.txtAuditDate3.Text = DateTime.Parse(oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString()).ToString("yyyy-MM-dd");
                }
                catch { }

                if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
                {
                    //					this.ddlPurpose.thisDDL.Enabled = false;
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtAuthor.Enabled = false;
                }
                //				//��;��
                //				//this.ddlPurpose.SelectedText = oDT.Rows[0][PMRPData.REQREASON_FIELD].ToString();
                //				//this.ddlPurpose.SelectedValue= oDT.Rows[0][PMRPData.REQREASONCODE_FIELD].ToString();
                //				//��ע��
                //				this.item1.txtRemark.Text = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //���Ʋ��š�
                this.ddlDept.SelectedText = oDT.Rows[0][InItemData.AUTHORDEPTNAME_FIELD].ToString();
                this.ddlDept.SelectedValue = oDT.Rows[0][InItemData.AUTHORDEPT_FIELD].ToString();
                //�����ˡ�
                this.txtAuthor.Text = oDT.Rows[0][InItemData.AUTHORNAME_FIELD].ToString();
            }
        }
        
        /// <summary>
        /// ���õ���״̬��
        /// </summary>
        /// <param name="oPurchasePlanData">PurchasePlanData:	�ɹ��ƻ�ʵ�塣</param>
        /// <param name="OpMode">string:	����ģʽ��</param>
        private void SetEntryState(PurchasePlanData oPurchasePlanData, string OpMode)
        {
            if (oPurchasePlanData.Count > 0)
            {
                oDataRow = oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];
                oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE]).GetEntryState(OpMode);
            }
        }
        /// <summary>
        /// ���õ��ݵĲ����ˡ�
        /// </summary>
        /// <param name="oPurchasePlanData">PurchasePlanData:	�ɹ��ƻ�ʵ�塣</param>
        /// <param name="OpMode">string:	����ģʽ��</param>
        private void SetOperator(PurchasePlanData oPurchasePlanData, string OpMode)
        {
            if (oPurchasePlanData.Count > 0)
            {
                oDataRow = oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0];

                switch (OpMode)
                {
                    case OP.New://�½���
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
                }
            }
        }

        /// <summary>
        /// ������ݼ���
        /// </summary>
        /// <param name="oPurchasePlanData">PurchasePlanData:	�ɹ��ƻ�ʵ�塣</param>
        private void FillData(PurchasePlanData oPurchasePlanData)
        {
            dr = oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].NewRow();
            //����̨ͷ�������ݡ�
            dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//������ˮ�š�
            dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//���ݱ�š�
            dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//�������͡�
            dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//�����������ơ�
            dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//�����ĵ���š�
            dr[PurchasePlanData.PLANDATE_FIELD] = new DateTime(Convert.ToInt32(this.doc1.ddlYear.thisDDL.SelectedValue), Convert.ToInt32(this.doc1.ddlMonth.thisDDL.SelectedValue), 1);
            dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//�������ڡ�
            dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//һ��������
            dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//����������
            dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//����������
            dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//һ�����������
            dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//�������������
            dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//�������������

            MyCol2List = new Col2List(this.item1.thisTable);
            dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();

            dr[PurchasePlanData.SOURCEENTRY_FIELD] = MyCol2List.GetList(PPSData.ENTRYNO_FIELD);
            dr[PurchasePlanData.SOURCEDOCCODE_FIELD] = MyCol2List.GetList(PPSData.DOCCODE_FIELD);
            
            dr[InItemData.NEWCODE_FIELD] = MyCol2List.GetList(InItemData.NEWCODE_FIELD);
            dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);
            dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);
            dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);
            dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);
            dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);
            dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);
            dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
            dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);
            dr[PurchasePlanData.REQDEPT_FIELD] = MyCol2List.GetList(PPSData.REQDEPT_FIELD);
            dr[PurchasePlanData.REQDEPTNAME_FIELD] = MyCol2List.GetList(PPSData.REQDEPTNAME_FIELD);
            dr[PurchasePlanData.REQREASONCODE_FIELD] = MyCol2List.GetList(PPSData.REQREASONCODE_FIELD);
            dr[PurchasePlanData.REQREASON_FIELD] = MyCol2List.GetList(PurchasePlanData.REQREASON_FIELD);
            dr[PurchasePlanData.REQDATE_FIELD] = MyCol2List.GetList(PurchasePlanData.REQDATE_FIELD);
            dr[InItemData.REMARK_FIELD] = MyCol2List.GetList(InItemData.REMARK_FIELD);
            dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD);//�ϼƽ�
            oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows.Add(dr);
        }
        /// <summary>
        /// ��������ǰ��������
        /// </summary>
        /// <param name="OpMode">string:	����ģʽ��</param>
        /// <param name="oPPData">PurchasePlanData:	��������ʵ�塣</param>
        private void CheckOpPrecondition(string OpMode,PurchasePlanData oPPData)
        {
            switch (OpMode)
            {
                case OP.Edit://�༭��
                    if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchasePlanData.XUpdate, true); }
                    break;
                case OP.Submit://�ύ��
                    if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchasePlanData.XPresent, true); }
                    break;
                case OP.FirstAudit://һ��������
                    if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchasePlanData.XFirstAudit, true); }
                    break;
                case OP.SecondAudit://����������
                    if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchasePlanData.XSecondAudit, true); }
                    break;
                case OP.ThirdAudit://����������
                    if (oPPData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PurchasePlanData.XThirdAudit, true); }
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
            Session[MySession.Help] = HelpCode.PP;
            // �ڴ˴������û������Գ�ʼ��ҳ��
            _OP = Master.PurposeOp;

            item1.IsDisplayPPPrice = Master.DisplayPPPrice;
           
            if (!this.IsPostBack)
            {
                switch (_OP)
                {
                    case OP.New:
                        if (!Master.HasRight(SysRight.PPMaintain))
                        {
                           // this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
                            return;
                        }
                        this.BindDataNew();
                        this.btnSave.Text = OPName.New;
                        break;
                    case OP.Edit:
                        if (!Master.HasRight(SysRight.PPMaintain))
                        {
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.Edit;
                        break;
                    case OP.Submit:
                        if (!Master.HasRight(SysRight.PPPresent))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.Submit;
                        this.btnPresent.Visible = false;
                        break;
                    case OP.FirstAudit:
                        if (!Master.HasRight(SysRight.PPFirstAudit))
                        {
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.FirstAudit;
                        this.btnPresent.Visible = false;
                        break;
                    case OP.SecondAudit:
                        if (!Master.HasRight(SysRight.PPSecondAudit))
                        {
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.SecondAudit;
                        this.btnPresent.Visible = false;
                        break;
                    case OP.ThirdAudit:
                        if (!Master.HasRight(SysRight.PPThirdAudit))
                        {
                            return;
                        }
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.ThirdAudit;
                        this.btnPresent.Visible = false;
                        break;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //û������
            if (item1.thisTable.Rows.Count == 0) return;

            //��������ʵ��.
            oPurchasePlanData = new PurchasePlanData();
            this.FillData(oPurchasePlanData);
            this.SetEntryState(oPurchasePlanData, this._OP);
            this.SetOperator(oPurchasePlanData, this._OP);

            
            ret = true;
            switch (this._OP)
            {
                case OP.New:
                    if (Master.HasRight(SysRight.PPMaintain))
                    {
                        ret = oPurchaseSystem.AddPP(oPurchasePlanData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case OP.Edit:
                    if (Master.HasRight(SysRight.PPMaintain))
                    {
                        ret = oPurchaseSystem.UpdatePP(oPurchasePlanData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case OP.Submit:
                    if (Master.HasRight(SysRight.PPPresent))
                    {
                        ret = oPurchaseSystem.PresentPP(this.doc1.EntryNo, Master.CurrentUser.thisUserInfo.LoginName);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case OP.FirstAudit:
                    if (Master.HasRight(SysRight.PPFirstAudit))
                    {
                        if (oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() == "Y" ||
                            oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() == "N")
                        {
                            ret = oPurchaseSystem.FirstAuditPP(oPurchasePlanData);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            //this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            return;
                        }
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case OP.SecondAudit:
                    if (Master.HasRight(SysRight.PPSecondAudit))
                    {
                        if (oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() == "Y" ||
                            oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() == "N")
                        {
                            ret = oPurchaseSystem.SecondAuditPP(oPurchasePlanData);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            //this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            return;
                        }
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case OP.ThirdAudit:
                    if (Master.HasRight(SysRight.PPThirdAudit))
                    {
                        if (oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() == "Y" ||
                            oPurchasePlanData.Tables[PurchasePlanData.PPLN_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() == "N")
                        {
                            ret = oPurchaseSystem.ThirdAuditPP(oPurchasePlanData);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            //this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            return;
                        }

                    }
                    else
                    {
                        ret = false;
                    }

                    break;
            }

            if (ret == false)
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
            }
            else
            {
                //Response.Write("Success!");
                //this._OP = "Edit";//һ������ɹ������Զ�����ǰ�ĵ���״̬��Ϊ�༭ģʽ��
                if (Master.IsTODO)
                {
                    this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
                }
                else
                {
                    Response.Redirect("PPBrowser.aspx");
                }

            }
        }

        protected void btnPresent_Click(object sender, EventArgs e)
        {
            //û������.
            if (item1.thisTable.Rows.Count == 0) return;

            //��������ʵ��.
            oPurchasePlanData = new PurchasePlanData();
            this.FillData(oPurchasePlanData);


            
            ret = true;
            switch (this._OP)
            {
                case OP.New:
                    if (Master.HasRight(SysRight.PPMaintain) && Master.HasRight(SysRight.PPPresent))
                    {
                        this._OP = OP.NewAndPresent;
                        this.SetEntryState(oPurchasePlanData, this._OP);
                        this.SetOperator(oPurchasePlanData, this._OP);
                        ret = oPurchaseSystem.AddAndPresentPP(oPurchasePlanData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case OP.Edit:
                    if (Master.HasRight(SysRight.PPMaintain) && Master.HasRight(SysRight.PPPresent))
                    {
                        this._OP = OP.EditAndPresent;
                        this.SetEntryState(oPurchasePlanData, this._OP);
                        this.SetOperator(oPurchasePlanData, this._OP);
                        ret = oPurchaseSystem.UpdateAndPresentPP(oPurchasePlanData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
            }

            if (ret == false)
            {
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
            }
            else
            {
                //Response.Write("Success!");
                //this._OP = "Edit";//һ������ɹ������Զ�����ǰ�ĵ���״̬��Ϊ�༭ģʽ��
                if (Master.IsTODO)
                {
                    this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
                }
                else
                {
                    Response.Redirect("PPBrowser.aspx");
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Master.IsTODO)
            {
                this.Response.Write("<Script>window.close();window.opener.history.go(0);</Script>");
            }
            else
            {
                Response.Redirect("PPBrowser.aspx");
            }
        }
        #endregion
    }
}
