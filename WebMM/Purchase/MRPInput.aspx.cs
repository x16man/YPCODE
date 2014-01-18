using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Modules;
using Shmzh.Components.SystemComponent;
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
    /// MRPInput ��ժҪ˵����
    /// </summary>
    public partial class MRPInput : Page
    {
        #region ��Ա����
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _OP;
       // private int _EntryNo;
        //private bool IsTODO;

        PMRPData oPMRPData;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        DataTable oDT;

        private bool ret;

        private DataRow dr;

        private DataRow oDataRow;

        private Col2List MyCol2List;
        #endregion

        #region ˽�з���
        /// <summary>
        /// ��������״̬�£����ݰ󶨡�
        /// </summary>
        private void BindDataNew()
        {
            
            this.doc1.DocCode = DocType.MRP;
            this.doc1.DataBindNew();
            this.DocAuditWebControl1.DocCode = DocType.MRP;
            this.ddlDept.Module_Tag = (int)SDDLTYPE.OWNDEPT;
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
            this.ddlDept.DocType = DocType.MRP;
            this.ddlDept.SelectedValue = Master.CurrentUser.thisUserInfo.DeptCode;
            this.txtProposer.Text = Master.CurrentUser.thisUserInfo.EmpName;
            this.ddlPurpose.SelectedValue = "-1";
            this.ddlPurpose.Flag = 0;
            this.item1.DocCode = DocType.MRP;
        }

        public bool IsAudit(int EntryNo)
        {
            return oPurchaseSystem.IsAuditDept(Master.CurrentUser.EmpCode, EntryNo);
        }
        /// <summary>
        /// �༭����״̬�£����ݰ󶨡�
        /// </summary>
        private void BindDataUpdate()
        {
            this.item1.DocCode = DocType.MRP;
            this.doc1.DocCode = DocType.MRP;
            this.doc1.DataBindUpdate();
            this.DocAuditWebControl1.DocCode = DocType.MRP;
            this.ddlDept.Module_Tag = (int)SDDLTYPE.OWNDEPT;
            this.ddlDept.UserCode = Master.CurrentUser.thisUserInfo.LoginName;
            this.ddlDept.DocType = DocType.MRP;
            this.ddlPurpose.Flag = 0;
            //��������䵽���ݼ�,DataGrid������Դ��
            oPMRPData = oPurchaseSystem.GetPMRPByEntryNo(Master.EntryNo);
            this.CheckOpPrecondition(this._OP, oPMRPData);
            oDT = oPMRPData.Tables[PMRPData.PMRP_TABLE];
            this.item1.thisTable = oDT;

            if (oDT.Rows.Count > 0)
            {
                //̨ͷ���֡�
                this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
                this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
                this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
                //�����Ρ�
                this.DocAuditWebControl1.Auditor1 = oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString();
                Logger.Info(oDT.Rows[0][InItemData.ASSESSOR1_FIELD].ToString());
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
                
                this.DocAuditWebControl1.txtAuditDate1.Text = oDT.Rows[0][InItemData.AUDITDATE1_FIELD].ToString();
                this.DocAuditWebControl1.txtAuditDate2.Text = oDT.Rows[0][InItemData.AUDITDATE2_FIELD].ToString();
                this.DocAuditWebControl1.txtAuditDate3.Text = oDT.Rows[0][InItemData.AUDITDATE3_FIELD].ToString();

                if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
                {
                    this.ddlDept.thisDDL.Enabled = false;
                    this.txtProposer.Enabled = false;
                    this.ddlPurpose.Disabled = true;
                }
                //				switch (this._OP)
                //				{
                //					case OP.FirstAudit:
                //						this.DocAuditWebControl1.rblAudit1.SelectedIndex = 1;
                //						break;
                //					case OP.SecondAudit:
                //						this.DocAuditWebControl1.rblAudit2.SelectedIndex = 1;
                //						break;
                //					case OP.ThirdAudit:
                //						this.DocAuditWebControl1.rblAudit3.SelectedIndex = 1;
                //						break;
                //				}
                //��;��
                this.ddlPurpose.SelectedText = oDT.Rows[0][PMRPData.REQREASON_FIELD].ToString();
                this.ddlPurpose.SelectedValue = oDT.Rows[0][PMRPData.REQREASONCODE_FIELD].ToString();
                //��ע��
                this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //���벿�š�
                this.ddlDept.SelectedText = oDT.Rows[0][PMRPData.REQDEPTNAME_FIELD].ToString();
                this.ddlDept.SelectedValue = oDT.Rows[0][PMRPData.REQDEPT_FIELD].ToString();
                //�����ˡ�
                this.txtProposer.Text = oDT.Rows[0][PMRPData.PROPOSER_FIELD].ToString();
            }
        }

        /// <summary>
        /// ������ݼ���
        /// </summary>
        /// <param name="oPMRPData">PMRPData:	������������ʵ�塣</param>
        private void FillData(PMRPData oPMRPData)
        {
            dr = oPMRPData.Tables[PMRPData.PMRP_TABLE].NewRow();
            //����̨ͷ�������ݡ�
            dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//������ˮ�š�
            dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//���ݱ�š�
            dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//�������͡�
            dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//�����������ơ�
            dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//�����ĵ���š�
            dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//�������ڡ�
            dr[PMRPData.REQDEPT_FIELD] = ddlDept.SelectedValue;			//���벿�š�
            dr[PMRPData.REQDEPTNAME_FIELD] = ddlDept.SelectedText;		//���벿�����ơ�
            dr[InItemData.REMARK_FIELD] = this.item1.Remark;				//��ע��
            if (txtProposer.Text != "")
            {
                dr[PMRPData.PROPOSER_FIELD] = txtProposer.Text;			//�����ˡ�
            }
            dr[PMRPData.REQREASON_FIELD] = ddlPurpose.SelectedText;		//��;���ơ�
            dr[PMRPData.REQREASONCODE_FIELD] = ddlPurpose.SelectedValue;	//��;��š�

            dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//һ��������
            dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//����������
            dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//����������

            dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//һ�����������
            dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//�������������
            dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//�������������

            MyCol2List = new Col2List(this.item1.thisTable);

            dr[InItemData.SERIALNO_FIELD] = MyCol2List.GetList();
            dr[InItemData.ITEMCODE_FIELD] = MyCol2List.GetList(InItemData.ITEMCODE_FIELD); ;
            dr[InItemData.ITEMNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMNAME_FIELD);
            dr[InItemData.ITEMSPECIAL_FIELD] = MyCol2List.GetList(InItemData.ITEMSPECIAL_FIELD);
            dr[InItemData.ITEMUNIT_FIELD] = MyCol2List.GetList(InItemData.ITEMUNIT_FIELD);
            dr[InItemData.ITEMUNITNAME_FIELD] = MyCol2List.GetList(InItemData.ITEMUNITNAME_FIELD);
            dr[InItemData.ITEMPRICE_FIELD] = MyCol2List.GetList(InItemData.ITEMPRICE_FIELD);
            dr[InItemData.ITEMNUM_FIELD] = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
            dr[InItemData.ITEMMONEY_FIELD] = MyCol2List.GetList(InItemData.ITEMMONEY_FIELD);
            dr[PMRPData.REQDATE_FIELD] = MyCol2List.GetList(PMRPData.REQDATE_FIELD);
            dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD); ;//�ϼƽ�
            oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows.Add(dr);
        }
        /// <summary>
        /// ���õ���״̬��
        /// </summary>
        /// <param name="oPMRPData">PMRPData:	��������ʵ�塣</param>
        /// <param name="OpMode">string:	����ģʽ��</param>
        private void SetEntryState(PMRPData oPMRPData, string OpMode)
        {
            if (oPMRPData.Count > 0)
            {
                oDataRow = oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0];
                oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oPMRPData.Tables[0]).GetEntryState(OpMode);
            }
        }

        /// <summary>
        /// ���ò����ˡ�
        /// </summary>
        /// <param name="oPMRPData">PMRPData:	��������ʵ�塣</param>
        /// <param name="OpMode">string:	����ģʽ��</param>
        private void SetOperator(PMRPData oPMRPData, string OpMode)
        {
            if (oPMRPData.Count > 0)
            {
                oDataRow = oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0];

                switch (OpMode)
                {
                    case OP.New://�½���
                        oDataRow[InItemData.AUTHORCODE_FIELD] = Master.CurrentUser.thisUserInfo.EmpCode;
                        oDataRow[InItemData.AUTHORNAME_FIELD] = Master.CurrentUser.thisUserInfo.EmpName;
                        oDataRow[InItemData.AUTHORLOGINID_FIELD] = Master.CurrentUser.thisUserInfo.LoginName;
                        oDataRow[InItemData.AUTHORDEPT_FIELD] = Master.CurrentUser.thisUserInfo.DeptCode;
                        oDataRow[InItemData.AUTHORDEPTNAME_FIELD] = Master.CurrentUser.thisUserInfo.DeptName;
                        break;
                    case OP.NewAndPresent:
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
                    case OP.EditAndPresent:
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
        /// ��������ǰ��������
        /// </summary>
        /// <param name="OpMode">string:	����ģʽ��</param>
        /// <param name="oMRPData">PMRPData:	��������ʵ�塣</param>
        private void CheckOpPrecondition(string OpMode,PMRPData oMRPData)
        {
            switch (OpMode)
            {
                case OP.Edit://�༭��
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XUpdate, true); }
                    break;
                case OP.Submit://�ύ��
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XPresent, true); }
                    break;
                case OP.FirstAudit://һ��������
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XFirstAudit, true); }
                    break;
                case OP.SecondAudit://����������
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XSecondAudit, true); }
                    break;
                case OP.ThirdAudit://����������
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XThirdAudit, true); }
                    break;
            }
        }
        #endregion
        
        #region �¼�
        /// <summary>
        /// ҳ���Load�¼���
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[MySession.Help] = HelpCode.MRP;
            // �ڴ˴������û������Գ�ʼ��ҳ��
            _OP = Request["Op"].ToString();
            this.ddlPurpose.Width = new Unit("90%");
            item1.IsDisplayPrice = Master.DisplayMRPPrice;
          
            if (!this.IsPostBack)
            {
                switch (_OP)
                {
                    case OP.New:
                        if (!Master.HasBrowseRight(SysRight.MRPMaintain))
                        {
                           // this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
                            return;
                        }
                      
                        this.BindDataNew();
                        this.btnSave.Text = OPName.New;
                        
                        break;
                    case OP.Edit:
                        if (!Master.HasBrowseRight(SysRight.MRPMaintain))
                        {
                           // this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
                            return;
                        }
                        
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.Edit;
                        
                        break;
                    case OP.Submit:
                        if (!Master.HasBrowseRight(SysRight.MRPPresent))
                        {
                           // this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
                            return;
                        }
                        
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.Submit;
                        this.btnPresent.Visible = false;
                       
                        break;
                    case OP.FirstAudit:
                        if (!Master.HasBrowseRight(SysRight.MRPFirstAudit))
                        {
                           // this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
                            return;
                        }

                        if (!IsAudit(Master.EntryNo))
                        {
                            if (Master.IsTODO)
                            {
                                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�޷������������ŵ���������!');window.close();", true);
                                return;
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('�޷������������ŵ���������!');document.location = 'MRPBrowser.aspx?DocCode=2'", true);
                                return;
                            }
                        }
                       
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.FirstAudit;
                        ddlPurpose.Disabled = false;
                        this.btnPresent.Visible = false;
                        
                        break;
                    case OP.SecondAudit:
                        if (!Master.HasBrowseRight(SysRight.MRPSecondAudit))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
                            return;
                        }
                        
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.SecondAudit;
                        ddlPurpose.Disabled = false;
                        this.btnPresent.Visible = false;
                        
                        break;
                    case OP.ThirdAudit:
                        if (!Master.HasBrowseRight(SysRight.MRPThirdAudit))
                        {
                            //this.Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + SysRight.NoRight);
                            return;
                        }
                        
                        this.BindDataUpdate();
                        this.btnSave.Text = OPName.ThirdAudit;
                        ddlPurpose.Disabled = false;
                        this.btnPresent.Visible = false;
                        
                        break;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //û������
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('û����������!');", true);
                return;
            }

            //��������ʵ��.
            oPMRPData = new PMRPData();
            this.FillData(oPMRPData);
            this.SetOperator(oPMRPData, this._OP);//���ò����ˡ�
            this.SetEntryState(oPMRPData, this._OP);//���õ���״̬��

            if (!Master.IsContaintContent(oPMRPData.Tables[0].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oPMRPData.Tables[0].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('���������ϲ���������!');", true);
                return;
            }
            
            ret = true;
            switch (this._OP)
            {
                case OP.New:
                    if (Master.HasRight(SysRight.MRPMaintain))
                    {
                        ret = oPurchaseSystem.AddPMRP(oPMRPData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case OP.Edit:
                    if (Master.HasRight(SysRight.MRPMaintain))
                    {
                        ret = oPurchaseSystem.UpdatePMRP(oPMRPData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case OP.Submit:
                    if (Master.HasRight(SysRight.MRPPresent))
                    {
                        ret = oPurchaseSystem.PresentPMRP(this.doc1.EntryNo, Master.CurrentUser.thisUserInfo.LoginName);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case "FirstAudit":
                    if (Master.HasRight(SysRight.MRPFirstAudit))
                    {

                        if(!IsAudit(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString())))
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo="+Server.UrlEncode("�޷�ɾ���������ŵ���������"));
                            return;
                        }
                        if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
                            oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
                        {
                            //this.Response.Write("<script>alert(\"��ȷ������ͨ�����ǲ�ͨ����\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            return;
                        }
                        ret = oPurchaseSystem.FirstAuditPMRP(oPMRPData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case "SecondAudit":
                    if (Master.HasRight(SysRight.MRPSecondAudit))
                    {
                        if (!IsAudit(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString())))
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + Server.UrlEncode("�޷�ɾ���������ŵ���������"));
                            return;
                        }

                        if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "Y" &&
                            oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "N")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            return;
                        }
                        ret = oPurchaseSystem.SecondAuditPMRP(oPMRPData);
                    }
                    else
                    {
                        ret = false;
                    }
                    break;
                case "ThirdAudit":
                    if (Master.HasRight(SysRight.MRPThirdAudit))
                    {
                        if (!IsAudit(int.Parse(oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYNO_FIELD].ToString())))
                        {
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + Server.UrlEncode("�޷�ɾ���������ŵ���������"));
                            return;
                        }

                        if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "Y" &&
                            oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "N")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('��ȷ������ͨ�����ǲ�ͨ��!');", true);
                            return;
                        }
                        ret = oPurchaseSystem.ThirdAuditPMRP(oPMRPData);
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
                    this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                }
                else
                {
                    Response.Redirect("MRPBrowser.aspx?DocCode=2");
                }
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
            oPMRPData = new PMRPData();
            this.FillData(oPMRPData);

            if (!Master.IsContaintContent(oPMRPData.Tables[0].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oPMRPData.Tables[0].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('���������ϲ���������!');", true);
                return;
            }
         
            ret = true;
            switch (this._OP)
            {
                case OP.New:
                    this._OP = OP.NewAndPresent;
                    this.SetOperator(oPMRPData, this._OP);//���ò����ˡ�
                    this.SetEntryState(oPMRPData, this._OP);//���õ���״̬��
                    ret = oPurchaseSystem.AddAndPresentPMRP(oPMRPData);
                    break;
                case OP.Edit:
                    this._OP = OP.EditAndPresent;
                    this.SetOperator(oPMRPData, this._OP);//���ò����ˡ�
                    this.SetEntryState(oPMRPData, this._OP);//���õ���״̬��
                    ret = oPurchaseSystem.UpdateAndPresentPMRP(oPMRPData);
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
                    this.Response.Write("<script>window.close();window.opener.history.go(0);</script>");
                }
                else
                {
                    Response.Redirect("MRPBrowser.aspx?DocCode=2");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            if (Master.IsTODO)
            {
                this.Response.Write("<script>window.close();</script>");
            }
            else
            {
                Response.Redirect("MRPBrowser.aspx?DocCode=2");
            }
        }
        #endregion
    }
}
