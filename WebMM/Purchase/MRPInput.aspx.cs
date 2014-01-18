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
    /// MRPInput 的摘要说明。
    /// </summary>
    public partial class MRPInput : Page
    {
        #region 成员变量
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

        #region 私有方法
        /// <summary>
        /// 新增单据状态下，数据绑定。
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
        /// 编辑数据状态下，数据绑定。
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
            //将单据填充到数据集,DataGrid绑定数据源。
            oPMRPData = oPurchaseSystem.GetPMRPByEntryNo(Master.EntryNo);
            this.CheckOpPrecondition(this._OP, oPMRPData);
            oDT = oPMRPData.Tables[PMRPData.PMRP_TABLE];
            this.item1.thisTable = oDT;

            if (oDT.Rows.Count > 0)
            {
                //台头部分。
                this.doc1.EntryNo = Convert.ToInt32(oDT.Rows[0][InItemData.ENTRYNO_FIELD].ToString());
                this.doc1.EntryCode = oDT.Rows[0][InItemData.ENTRYCODE_FIELD].ToString();
                this.doc1.EntryDate = Convert.ToDateTime(oDT.Rows[0][InItemData.ENTRYDATE_FIELD].ToString());
                //审批段。
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
                //用途。
                this.ddlPurpose.SelectedText = oDT.Rows[0][PMRPData.REQREASON_FIELD].ToString();
                this.ddlPurpose.SelectedValue = oDT.Rows[0][PMRPData.REQREASONCODE_FIELD].ToString();
                //备注。
                this.item1.Remark = oDT.Rows[0][InItemData.REMARK_FIELD].ToString();
                //申请部门。
                this.ddlDept.SelectedText = oDT.Rows[0][PMRPData.REQDEPTNAME_FIELD].ToString();
                this.ddlDept.SelectedValue = oDT.Rows[0][PMRPData.REQDEPT_FIELD].ToString();
                //申请人。
                this.txtProposer.Text = oDT.Rows[0][PMRPData.PROPOSER_FIELD].ToString();
            }
        }

        /// <summary>
        /// 填充数据集。
        /// </summary>
        /// <param name="oPMRPData">PMRPData:	物料需求单数据实体。</param>
        private void FillData(PMRPData oPMRPData)
        {
            dr = oPMRPData.Tables[PMRPData.PMRP_TABLE].NewRow();
            //单据台头部分内容。
            dr[InItemData.ENTRYNO_FIELD] = doc1.EntryNo;							//单据流水号。
            dr[InItemData.ENTRYCODE_FIELD] = doc1.EntryCode;						//单据编号。
            dr[InItemData.DOCCODE_FIELD] = doc1.DocCode;							//单据类型。
            dr[InItemData.DOCNAME_FIELD] = doc1.DocName;							//单据类型名称。
            dr[InItemData.DOCNO_FIELD] = doc1.DocNo;								//单据文档编号。
            dr[InItemData.ENTRYDATE_FIELD] = DateTime.Now;							//单据日期。
            dr[PMRPData.REQDEPT_FIELD] = ddlDept.SelectedValue;			//申请部门。
            dr[PMRPData.REQDEPTNAME_FIELD] = ddlDept.SelectedText;		//申请部门名称。
            dr[InItemData.REMARK_FIELD] = this.item1.Remark;				//备注。
            if (txtProposer.Text != "")
            {
                dr[PMRPData.PROPOSER_FIELD] = txtProposer.Text;			//申请人。
            }
            dr[PMRPData.REQREASON_FIELD] = ddlPurpose.SelectedText;		//用途名称。
            dr[PMRPData.REQREASONCODE_FIELD] = ddlPurpose.SelectedValue;	//用途编号。

            dr[InItemData.AUDIT1_FIELD] = this.DocAuditWebControl1.rblAudit1.SelectedValue;	//一级审批。
            dr[InItemData.AUDIT2_FIELD] = this.DocAuditWebControl1.rblAudit2.SelectedValue;	//二级审批。
            dr[InItemData.AUDIT3_FIELD] = this.DocAuditWebControl1.rblAudit3.SelectedValue;	//三级审批。

            dr[InItemData.AUDITSUGGEST1_FIELD] = this.DocAuditWebControl1.txtAuditSuggest1.Text;	//一级审批意见。
            dr[InItemData.AUDITSUGGEST2_FIELD] = this.DocAuditWebControl1.txtAuditSuggest2.Text;	//二级审批意见。
            dr[InItemData.AUDITSUGGEST3_FIELD] = this.DocAuditWebControl1.txtAuditSuggest3.Text;	//三级审批意见。

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
            dr[InItemData.SUBTOTAL_FIELD] = MyCol2List.GetSum(InItemData.ITEMMONEY_FIELD); ;//合计金额。
            oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows.Add(dr);
        }
        /// <summary>
        /// 设置单据状态。
        /// </summary>
        /// <param name="oPMRPData">PMRPData:	物料需求单实体。</param>
        /// <param name="OpMode">string:	操作模式。</param>
        private void SetEntryState(PMRPData oPMRPData, string OpMode)
        {
            if (oPMRPData.Count > 0)
            {
                oDataRow = oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0];
                oDataRow[InItemData.ENTRYSTATE_FIELD] = new Entry(oPMRPData.Tables[0]).GetEntryState(OpMode);
            }
        }

        /// <summary>
        /// 设置操作人。
        /// </summary>
        /// <param name="oPMRPData">PMRPData:	物料需求单实体。</param>
        /// <param name="OpMode">string:	操作模式。</param>
        private void SetOperator(PMRPData oPMRPData, string OpMode)
        {
            if (oPMRPData.Count > 0)
            {
                oDataRow = oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0];

                switch (OpMode)
                {
                    case OP.New://新建。
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
                    case OP.Edit://编辑。
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
        /// 检查操作的前提条件。
        /// </summary>
        /// <param name="OpMode">string:	操作模式。</param>
        /// <param name="oMRPData">PMRPData:	物料需求单实体。</param>
        private void CheckOpPrecondition(string OpMode,PMRPData oMRPData)
        {
            switch (OpMode)
            {
                case OP.Edit://编辑。
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XUpdate, true); }
                    break;
                case OP.Submit://提交。
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.New ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Cancel ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstNoPass ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecNoPass ||
                        oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.TrdNoPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XPresent, true); }
                    break;
                case OP.FirstAudit://一级审批。
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.Present)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XFirstAudit, true); }
                    break;
                case OP.SecondAudit://二级审批。
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.FstPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XSecondAudit, true); }
                    break;
                case OP.ThirdAudit://三级审批。
                    if (oMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.ENTRYSTATE_FIELD].ToString() == DocStatus.SecPass)
                    { return; }
                    else
                    { Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + PMRPData.XThirdAudit, true); }
                    break;
            }
        }
        #endregion
        
        #region 事件
        /// <summary>
        /// 页面的Load事件。
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[MySession.Help] = HelpCode.MRP;
            // 在此处放置用户代码以初始化页面
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
                                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('无法审批其他部门的物料需求单!');window.close();", true);
                                return;
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('无法审批其他部门的物料需求单!');document.location = 'MRPBrowser.aspx?DocCode=2'", true);
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
            //没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            //构建数据实体.
            oPMRPData = new PMRPData();
            this.FillData(oPMRPData);
            this.SetOperator(oPMRPData, this._OP);//设置操作人。
            this.SetEntryState(oPMRPData, this._OP);//设置单据状态。

            if (!Master.IsContaintContent(oPMRPData.Tables[0].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oPMRPData.Tables[0].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('所申请物料不符合限制!');", true);
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
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo="+Server.UrlEncode("无法删除其他部门的物料需求单"));
                            return;
                        }
                        if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "Y" &&
                            oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT1_FIELD].ToString() != "N")
                        {
                            //this.Response.Write("<script>alert(\"请确认审批通过或是不通过！\")</script>");
                            ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('请确认审批通过或是不通过!');", true);
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
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + Server.UrlEncode("无法删除其他部门的物料需求单"));
                            return;
                        }

                        if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "Y" &&
                            oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT2_FIELD].ToString() != "N")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('请确认审批通过或是不通过!');", true);
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
                            Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + Server.UrlEncode("无法删除其他部门的物料需求单"));
                            return;
                        }

                        if (oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "Y" &&
                            oPMRPData.Tables[PMRPData.PMRP_TABLE].Rows[0][InItemData.AUDIT3_FIELD].ToString() != "N")
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "SaveError", "alert('请确认审批通过或是不通过!');", true);
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
                //this._OP = "Edit";//一旦保存成功，则自动将当前的单据状态改为编辑模式。
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
            //没有内容
            if (item1.thisTable.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }

            //构建数据实体.
            oPMRPData = new PMRPData();
            this.FillData(oPMRPData);

            if (!Master.IsContaintContent(oPMRPData.Tables[0].Rows[0][InItemData.ITEMCODE_FIELD].ToString(), oPMRPData.Tables[0].Rows[0][PMRPData.REQREASONCODE_FIELD].ToString()))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('所需求物料不符合限制!');", true);
                return;
            }
         
            ret = true;
            switch (this._OP)
            {
                case OP.New:
                    this._OP = OP.NewAndPresent;
                    this.SetOperator(oPMRPData, this._OP);//设置操作人。
                    this.SetEntryState(oPMRPData, this._OP);//设置单据状态。
                    ret = oPurchaseSystem.AddAndPresentPMRP(oPMRPData);
                    break;
                case OP.Edit:
                    this._OP = OP.EditAndPresent;
                    this.SetOperator(oPMRPData, this._OP);//设置操作人。
                    this.SetEntryState(oPMRPData, this._OP);//设置单据状态。
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
                //this._OP = "Edit";//一旦保存成功，则自动将当前的单据状态改为编辑模式。
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
