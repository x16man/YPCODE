using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common.Storage;
using Shmzh.MM.DataAccess.Storage;
using Shmzh.MM.Common;
using Shmzh.MM.DataAccess;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Common;
using Shmzh.Components.SystemComponent;
using System.Drawing;

namespace WebMM.Storage
{
    public partial class InventoryProfitInput : System.Web.UI.Page
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        #endregion

        #region Property
        public InventoryProfitInfo InventoryProfit
        {
            get
            {
                if (Session["InventoryProfitInfo"] == null)
                    Session["InventoryProfitInfo"] = new InventoryProfitInfo(){DocCode = (short)this.doc1.DocCode,DocName = doc1.DocName,DocNo = doc1.DocNo,EntryDate = DateTime.Now};
                return Session["InventoryProfitInfo"] as InventoryProfitInfo;
            }
            set { Session["InventoryProfitInfo"] = value; }
        }
            
        public List<InventoryProfitDetailInfo> InventoryProfitDetail
        {
            get
            {
                if (Session["InventoryProfitDetailInfos"] == null)
                {
                    Session["InventoryProfitDetailInfos"] = new List<InventoryProfitDetailInfo>();
                }
                return Session["InventoryProfitDetailInfos"] as List<InventoryProfitDetailInfo>;
            }
            set { Session["InventoryProfitDetailInfos"] = value; }
        }
        public int EntryNo
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request["EntryNo"]))
                    {
                        return int.Parse(this.Request["EntryNo"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch
                {
                    return 0;
                }

            }
        }
        public string OP
        {
            get { return this.Request["OP"]; }
        }
        /// <summary>
        /// 是否是红字操作
        /// </summary>
        public bool OperateRed
        {
            get
            {
                if (ViewState["OperateRed"] != null)
                    return bool.Parse(ViewState["OperateRed"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["OperateRed"] = value;
            }
        }
        #endregion

        #region private method
        
        /// <summary>
        /// 对数据进行校验.
        /// </summary>
        /// <returns>bool:	校验通过返回true，失败返回false。</returns>
        private bool DoCheck()
        {
            var retValue = true;
            if (this.ddlStorage.SelectedValue == "-1")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "DoCheck", "alert(\"请选择仓库！\");", true);
                return false;
            }
            try
            {
                if (!string.IsNullOrEmpty(txtItemCode.Text) &&
                    !string.IsNullOrEmpty(txtItemName.Text) &&
                    !string.IsNullOrEmpty(txtItemPrice.Text) &&
                    (ddlUnit.SelectedValue != "-1") &&
                    !string.IsNullOrEmpty(txtItemNum.Text))
                {
                    var tmpDecimal = decimal.Parse(txtItemNum.Text);
                    var tmpItemPrice = decimal.Parse(txtItemPrice.Text);
                }
                else
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"物料编号、物料名称、单位、数量、单价不能为空！\");", true);
                    retValue = false;
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "DoCheck", "alert(\"单价、数量应为数字型！\");", true);
                retValue = false;
            }
            return retValue;
        }
        private bool CheckStorage()
        {
            var stoCode = this.ddlStorage.SelectedValue;
            foreach (var obj in this.InventoryProfitDetail)
            {
                if (obj.StoCode != stoCode)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 根据不同操作模式，设定编辑区域的显示方式。
        /// </summary>
        /// <param name="OpMode">string:	操作模式。</param>
        private void SetEditMode(string OpMode)
        {
            if (!Page.IsPostBack)
            {
                switch (OpMode)
                {
                    case Shmzh.MM.Common.OP.FirstAudit:
                    case Shmzh.MM.Common.OP.SecondAudit:
                    case Shmzh.MM.Common.OP.ThirdAudit:
                        this.editRowHeader.Visible = false;
                        this.editRow.Visible = false;
                        this.btnRefuse.Visible = false;
                        this.btnPresent.Visible = false;
                        break;
                    case Shmzh.MM.Common.OP.View:
                        this.editRowHeader.Visible = false;
                        this.editRow.Visible = false;
                        this.btnRefuse.Visible = false;
                        this.btnSave.Visible = false;
                        this.btnCancel.Text = "关闭";
                        this.btnPresent.Visible = false;
                        break;
                    case Shmzh.MM.Common.OP.I:
                        #region 收料
                        this.txtItemCode.Visible = true;
                        this.txtItemCode.ReadOnly = true;
                        this.txtItemName.Visible = true;
                        this.txtItemName.ReadOnly = true;
                        this.txtItemSpecial.Visible = true;
                        this.txtItemSpecial.ReadOnly = true;
                        this.ddlUnit.Visible = true;
                        this.ddlUnit.Enable = false;
                        this.txtItemPrice.Visible = true;
                        this.txtItemPrice.ReadOnly = true;
                        this.txtItemNum.Visible = true;
                        this.txtItemNum.ReadOnly = true;
                        this.txtRemark.Visible = true;
                        this.txtRemark.ReadOnly = true;
                        this.ddlCon.Visible = true;
                        this.ddlCon.Enabled = true;
                        this.btnAddItem.Enabled = false;
                        this.btnDelItem.Enabled = false;
                        this.btnEditItem.Enabled = true;
                        this.btnPresent.Visible = false;
                        this.txtAcceptName.Text = Master.CurrentUser.EmpName;
                        this.txtAcceptDate.Text = DateTime.Today.ToShortDateString();
                        this.btnSave.Text = OPName.I;
                        break;
                        #endregion
                    default:
                        #region 默认
                        this.txtItemCode.Visible = true;
                        this.txtItemCode.Enabled = true;
                        this.txtItemName.Visible = true;
                        this.txtItemName.Enabled = true;
                        this.txtItemName.ReadOnly = true;
                        this.txtItemSpecial.Visible = true;
                        this.txtItemSpecial.Enabled = true;
                        this.txtItemSpecial.ReadOnly = true;
                        this.ddlUnit.Visible = true;
                        this.ddlUnit.Enable = true;
                        this.txtItemPrice.Visible = true;
                        this.txtItemPrice.Enabled = true;
                        this.txtItemPrice.ReadOnly = false;
                        this.txtItemNum.Visible = true;
                        this.txtItemNum.Enabled = true;
                        this.txtItemNum.ReadOnly = false;
                        this.txtRemark.Enabled = true;
                        this.txtRemark.Visible = true;
                        this.txtRemark.ReadOnly = false;
                        this.ddlCon.Visible = true;
                        this.btnAddItem.Enabled = true;
                        this.btnDelItem.Enabled = true;
                        this.btnEditItem.Enabled = true;
                        this.btnRefuse.Enabled = true;
                        this.btnRefuse.Visible = false;
                        break;
                    case MZHMM.Common.OP.Red:
                        this.txtItemCode.Visible = true;
                        this.txtItemCode.Enabled = true;
                        this.txtItemName.Visible = true;
                        this.txtItemName.Enabled = true;
                        this.txtItemName.ReadOnly = true;
                        this.txtItemSpecial.Visible = true;
                        this.txtItemSpecial.Enabled = true;
                        this.txtItemSpecial.ReadOnly = true;
                        this.ddlUnit.Visible = true;
                        this.ddlUnit.Enable = true;
                        this.txtItemPrice.Visible = true;
                        this.txtItemPrice.Enabled = true;
                        this.txtItemPrice.ReadOnly = false;
                        this.txtItemNum.Visible = true;
                        this.txtItemNum.Enabled = true;
                        this.txtItemNum.ReadOnly = false;
                        this.txtRemark.Enabled = true;
                        this.txtRemark.Visible = true;
                        this.txtRemark.ReadOnly = false;
                        this.ddlCon.Visible = true;
                        this.btnAddItem.Enabled = false;
                        this.btnDelItem.Enabled = true;
                        this.btnEditItem.Enabled = false;
                        this.btnRefuse.Enabled = true;
                        this.btnRefuse.Visible = false;
                        break;
                        #endregion
                }
                this.btnRefuse.Visible = false;
            }
        }
        /// <summary>
        /// 设置操作人员信息。
        /// </summary>
        /// <param name="oBorData"></param>
        /// <param name="OpMode"></param>
        private void SetOperator(string OpMode)
        {
            switch (OpMode)
            {
                case Shmzh.MM.Common.OP.New://新建。
                case Shmzh.MM.Common.OP.Red://红字。
                case Shmzh.MM.Common.OP.Bor://由批次进货单生成。
                case Shmzh.MM.Common.OP.NewAndPresent://新建并且提交。
                case Shmzh.MM.Common.OP.Edit://编辑。
                case Shmzh.MM.Common.OP.EditAndPresent://编辑并且提交。
                    this.InventoryProfit.AuthorCode = Master.CurrentUser.thisUserInfo.EmpCode;
                    this.InventoryProfit.AuthorName = Master.CurrentUser.thisUserInfo.EmpName;
                    this.InventoryProfit.AuthorLoginId = Master.CurrentUser.thisUserInfo.LoginName;
                    this.InventoryProfit.AuthorDept = Master.CurrentUser.thisUserInfo.DeptCode;
                    this.InventoryProfit.AuthorDeptName = Master.CurrentUser.thisUserInfo.DeptName;
                    break;
                case Shmzh.MM.Common.OP.FirstAudit://一级审批。
                    this.InventoryProfit.Assessor1 = Master.CurrentUser.thisUserInfo.EmpName;
                    break;
                case Shmzh.MM.Common.OP.SecondAudit://二级审批。
                    this.InventoryProfit.Assessor2 = Master.CurrentUser.thisUserInfo.EmpName;
                    break;
                case Shmzh.MM.Common.OP.ThirdAudit://三级审批。
                    this.InventoryProfit.Assessor3 = Master.CurrentUser.thisUserInfo.EmpName;
                    break;
                case Shmzh.MM.Common.OP.I://收料。
                    this.InventoryProfit.AcceptCode = Master.CurrentUser.thisUserInfo.EmpCode;
                    this.InventoryProfit.AcceptName = Master.CurrentUser.thisUserInfo.EmpName;
                    break;
            }
        }
        /// <summary>
        /// 设置单据状态。
        /// </summary>
        /// <param name="oBorData">BillOfReceiveData:	收料单实体。</param>
        /// <param name="OpMode">string:	操作类型。</param>
        private void SetEntryState(string OpMode)
        {
            var auditLevel = new SysSystem().GetAuditLevel(this.InventoryProfit.DocCode);
            switch(OpMode)
            {
                case Shmzh.MM.Common.OP.New:
                case Shmzh.MM.Common.OP.Edit:
                case Shmzh.MM.Common.OP.Red:
                    this.InventoryProfit.EntryState = DocStatus.New;
                    break;
                case Shmzh.MM.Common.OP.Submit:
                case Shmzh.MM.Common.OP.NewAndPresent:
                case Shmzh.MM.Common.OP.EditAndPresent:
                    this.InventoryProfit.EntryState = DocStatus.Present;
                    break;
                case Shmzh.MM.Common.OP.FirstAudit:
                    this.InventoryProfit.EntryState = auditLevel == 1 ? (this.DocAuditWebControl1.Audit1 == AuditResult.Passed ? DocStatus.TrdPass : DocStatus.FstNoPass) : (this.DocAuditWebControl1.Audit1 == AuditResult.Passed ? DocStatus.FstPass : DocStatus.FstNoPass);
                    break;
                case Shmzh.MM.Common.OP.SecondAudit:
                    this.InventoryProfit.EntryState = auditLevel == 2 ? (this.DocAuditWebControl1.Audit1 == AuditResult.Passed ? DocStatus.TrdPass : DocStatus.SecNoPass) : (this.DocAuditWebControl1.Audit1 == AuditResult.Passed ? DocStatus.SecPass : DocStatus.SecNoPass);
                    break;
                case Shmzh.MM.Common.OP.ThirdAudit:
                    this.InventoryProfit.EntryState = this.DocAuditWebControl1.Audit3 == AuditResult.Passed ? DocStatus.TrdPass : DocStatus.TrdNoPass;
                    break;
                case Shmzh.MM.Common.OP.I:
                    this.InventoryProfit.EntryState = DocStatus.Received;
                    break;
            }
        }
        /// <summary>
        /// 绑定仓库下拉列表。
        /// </summary>
        private void BindStorage()
        {
            var oStoData = new ItemSystem().GetStoAll();

            for (var i = 0; i < oStoData.Tables[StoData.STO_TABLE].Rows.Count; i++)
            {
                var olt = new ListItem(oStoData.Tables[StoData.STO_TABLE].Rows[i][StoData.DESCRIPTION_FIELD].ToString(), oStoData.Tables[StoData.STO_TABLE].Rows[i][StoData.CODE_FIELD].ToString());
                this.ddlStorage.Items.Add(olt);
            }
        }
        
        private void BindCon()
        {
            var oStoConData = new ItemSystem().GetStoConByStoCode(this.ddlStorage.SelectedValue);
            this.ddlCon.Items.Clear();
            for (var i = 0; i < oStoConData.Tables[StoConData.STOCON_TABLE].Rows.Count; i++)
            {
                var olt = new ListItem(oStoConData.Tables[StoConData.STOCON_TABLE].Rows[i][StoConData.DESCRIPTION_FIELD].ToString(), oStoConData.Tables[StoConData.STOCON_TABLE].Rows[i][StoConData.CODE_FIELD].ToString());
                this.ddlCon.Items.Add(olt);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.doc1.DocCode = DocType.INVENTRYPROFIT;
            this.DocAuditWebControl1.DocCode = DocType.INVENTRYPROFIT;
            ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
            if(!IsPostBack)
            {
                #region Check Right
                if(this.OP == MZHMM.Common.OP.New || this.OP == MZHMM.Common.OP.Edit)
                {
                    if(!Master.CurrentUser.HasRight(SysRight.InventoryProfitMaintain))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx",true);
                    }
                }
                else if(this.OP==MZHMM.Common.OP.FirstAudit)
                {
                    if(!Master.CurrentUser.HasRight(SysRight.InventoryProfitFirstAudit))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx", true);
                    }
                }
                else if(this.OP == MZHMM.Common.OP.SecondAudit)
                {
                    if (!Master.CurrentUser.HasRight(SysRight.InventoryProfitSecondAudit))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx", true);
                    }
                }
                else if(this.OP == MZHMM.Common.OP.ThirdAudit)
                {
                    if (!Master.CurrentUser.HasRight(SysRight.InventoryProfitThirdAudit))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx", true);
                    }
                }
                else if(this.OP == MZHMM.Common.OP.I)
                {
                    if(!Master.CurrentUser.HasRight(SysRight.StockIn))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx",true);
                    }
                }
                else if(this.OP == MZHMM.Common.OP.Red)
                {
                    if(!Master.CurrentUser.HasRight(SysRight.InventoryProfitMaintain))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx", true);
                    }
                }
                #endregion
                this.BindStorage();
                if( this.EntryNo != 0)
                {
                    this.InventoryProfit = new InventoryProfits().GetById(this.EntryNo);
                    this.InventoryProfitDetail = new InventoryProfitDetails().GetByEntryNo(this.EntryNo);

                    #region Check Status
                    if (this.OP == MZHMM.Common.OP.Edit)
                    {
                        if( this.InventoryProfit.EntryState!=DocStatus.New && 
                            this.InventoryProfit.EntryState!=DocStatus.Cancel&&
                            this.InventoryProfit.EntryState!=DocStatus.FstNoPass&&
                            this.InventoryProfit.EntryState!=DocStatus.SecNoPass&&
                            this.InventoryProfit.EntryState!=DocStatus.TrdNoPass)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许编辑！\");window.close();", true);
                            return;
                        }
                    }
                    else if(this.OP == MZHMM.Common.OP.FirstAudit)
                    {
                        if(this.InventoryProfit.EntryState != DocStatus.Present)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许编辑！\");window.close();", true);
                            return;
                        }
                    }
                    else if(this.OP == MZHMM.Common.OP.SecondAudit)
                    {
                        if(this.InventoryProfit.EntryState != DocStatus.FstPass)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许编辑！\");window.close();", true);
                            return;
                        }
                    }
                    else if(this.OP == MZHMM.Common.OP.ThirdAudit)
                    {
                        if(this.InventoryProfit.EntryState != DocStatus.SecPass)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许编辑！\");window.close();", true);
                            return;
                        }
                    }
                    else if(this.OP == MZHMM.Common.OP.I)
                    {
                        if(this.InventoryProfit.EntryState != DocStatus.TrdPass)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许收料！\");window.close();", true);
                            return;
                        }
                    }
                    else if(this.OP == MZHMM.Common.OP.Red)
                    {
                        if (this.InventoryProfit.EntryState != DocStatus.Received)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许红字！\");window.close();", true);
                            return;
                        }
                        else
                        {
                            if (this.InventoryProfit.ParentEntryNo > 0)
                            {
                                ClientScript.RegisterStartupScript( this.GetType(), "IncorrectRed", "alert(\"红字单据不能再冲红字！\");window.close();", true);
                                return;
                            }
                        }
                    }
                    #endregion

                    if(this.OP == MZHMM.Common.OP.Red)
                    {
                        this.InventoryProfit.ParentEntryNo = this.InventoryProfit.EntryNo;
                        this.InventoryProfit.EntryNo = 0;
                        this.InventoryProfit.Audit1 = string.Empty;
                        this.InventoryProfit.Audit2 = string.Empty;
                        this.InventoryProfit.Audit3 = string.Empty;
                        this.InventoryProfit.Assessor1 = string.Empty;
                        this.InventoryProfit.Assessor2 = string.Empty;
                        this.InventoryProfit.Assessor3 = string.Empty;
                        this.InventoryProfit.AuditDate1 = DateTime.MinValue;
                        this.InventoryProfit.AuditDate2 = DateTime.MinValue;
                        this.InventoryProfit.AuditDate3 = DateTime.MinValue;
                        this.InventoryProfit.AuditSuggest1 = string.Empty;
                        this.InventoryProfit.AuditSuggest2 = string.Empty;
                        this.InventoryProfit.AuditSuggest3 = string.Empty;
                        this.InventoryProfit.AuthorCode = Master.CurrentUser.EmpCode;
                        this.InventoryProfit.AuthorName = Master.CurrentUser.EmpName;
                        this.InventoryProfit.AuthorLoginId = Master.CurrentUser.LoginName;
                        this.InventoryProfit.AuthorDept = Master.CurrentUser.DeptCode;
                        this.InventoryProfit.AuthorDeptName = Master.CurrentUser.DeptName;
                        this.InventoryProfit.AcceptCode = string.Empty;
                        this.InventoryProfit.AcceptName = string.Empty;
                        this.InventoryProfit.AcceptDate = DateTime.MinValue;
                        this.InventoryProfit.EntryState = DocStatus.New;
                        this.InventoryProfit.PresentDate = DateTime.MinValue;
                        this.InventoryProfit.EntryDate = DateTime.Now;
                        this.InventoryProfit.CancelDate = DateTime.MinValue;
                        this.InventoryProfit.SubTotal = -this.InventoryProfit.SubTotal;
                        this.InventoryProfit.Remark = string.Empty;

                        //已经生成的红字单据。
                        var redObjs = new InventoryProfits().GetByParentEntryNo(this.InventoryProfit.ParentEntryNo);
                        if (redObjs.Count > 0)//之前已经生成过红字单据。
                        {
                            foreach (var redObj in redObjs)
                            {
                                var redObjDetails = new InventoryProfitDetails().GetByEntryNo(redObj.EntryNo);
                                foreach (var redObjDetail in redObjDetails)
                                {
                                    var findObj = this.InventoryProfitDetail.Find(item => item.ItemCode == redObjDetail.ItemCode && item.ConCode == redObjDetail.ConCode);
                                    if (findObj != null)
                                        this.InventoryProfitDetail.Remove(findObj);
                                }
                            }
                            if (this.InventoryProfitDetail.Count == 0)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "nothingRed", "alert('该单据已经被红冲完！');window.close();", true);
                                return;
                            }
                            else
                            {
                                foreach (var obj in this.InventoryProfitDetail)
                                {
                                    obj.EntryNo = 0;
                                    obj.ItemNum = -obj.ItemNum;
                                    obj.ItemMoney = -obj.ItemMoney;
                                }
                            }
                        }
                        else
                        {
                            foreach (var obj in this.InventoryProfitDetail)
                            {
                                obj.EntryNo = 0;
                                obj.ItemNum = -obj.ItemNum;
                                obj.ItemMoney = -obj.ItemMoney;
                            }
                        }
                    }

                    if (this.OP == MZHMM.Common.OP.Red)
                    {
                        this.doc1.DataBindNew();
                    }
                    else
                    {
                        this.doc1.DataBindUpdate();
                        this.doc1.EntryNo = this.InventoryProfit.EntryNo;
                        this.doc1.EntryCode = this.InventoryProfit.EntryCode;
                        this.doc1.EntryDate = this.InventoryProfit.EntryDate;
                    }
                    

                    this.ddlStorage.SelectedValue = this.InventoryProfit.StoCode;
                    this.BindCon();
                    this.txtRemark.Text = this.InventoryProfit.Remark;

                    this.DocAuditWebControl1.Audit1 = this.InventoryProfit.Audit1;
                    this.DocAuditWebControl1.Audit2 = this.InventoryProfit.Audit2;
                    this.DocAuditWebControl1.Audit3 = this.InventoryProfit.Audit3;
                    this.DocAuditWebControl1.AuditDate1 = this.InventoryProfit.AuditDate1.ToString();
                    this.DocAuditWebControl1.AuditDate2 = this.InventoryProfit.AuditDate2.ToString();
                    this.DocAuditWebControl1.AuditDate3 = this.InventoryProfit.AuditDate3.ToString();
                    this.DocAuditWebControl1.Auditor1 = this.InventoryProfit.Assessor1;
                    this.DocAuditWebControl1.Auditor2 = this.InventoryProfit.Assessor2;
                    this.DocAuditWebControl1.Auditor3 = this.InventoryProfit.Assessor3;
                    this.DocAuditWebControl1.AuditSuggest1 = this.InventoryProfit.AuditSuggest1;
                    this.DocAuditWebControl1.AuditSuggest2 = this.InventoryProfit.AuditSuggest2;
                    this.DocAuditWebControl1.AuditSuggest2 = this.InventoryProfit.AuditSuggest3;
                    this.lblAuthorName.Text = this.InventoryProfit.AuthorName;
                    this.lblAuthorDeptName.Text = this.InventoryProfit.AuthorDeptName;
                    this.txtAcceptName.Text = this.InventoryProfit.AcceptName;
                    this.txtAcceptDate.Text = this.InventoryProfit.AcceptDate == DateTime.MinValue
                                                  ? string.Empty
                                                  : this.InventoryProfit.AcceptDate.ToShortDateString();
                }
                else
                {
                    if (string.IsNullOrEmpty(Request["InventoryId"]))
                    {
                        this.InventoryProfit = null;
                        this.InventoryProfitDetail = null;
                        this.lblAuthorDeptName.Text = Master.CurrentUser.DeptName;
                        this.lblAuthorName.Text = Master.CurrentUser.EmpName;
                        this.doc1.DataBindNew();
                    }
                    else//从盘点结果导入。
                    {
                        var inventoryId = int.Parse(Request["InventoryId"]);
                        var inventory = new Inventorys().GetById(inventoryId);
                        if (inventory != null)
                        {
                            this.ddlStorage.SelectedValue = inventory.StoCode;
                            this.BindCon();
                        }
                        this.InventoryProfit = null;
                        this.InventoryProfitDetail = new InventoryProfitDetails().GetByInventoryId(inventoryId);
                        this.lblAuthorDeptName.Text = Master.CurrentUser.DeptName;
                        this.lblAuthorName.Text = Master.CurrentUser.EmpName;
                        this.doc1.DataBindNew();
                        if (this.InventoryProfitDetail.Count > 0)
                        {
                            for (var i = 0; i < this.InventoryProfitDetail.Count; i++)
                            {
                                this.InventoryProfitDetail[i].SerialNo = (short)i;
                            }
                        }
                    }
                }
            }

            this.SetEditMode(this.OP);//设定编辑区域的显示模式。
            
            DGModel_Items1.DataSource = this.InventoryProfitDetail;//数据源绑定。
            DGModel_Items1.DataBind();

            if (OperateRed)
            {
                this.btnAddItem.Enabled = false;
                this.btnEditItem.Enabled = false;
                this.btnDelItem.Enabled = false;
            }
        }

        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //没有内容
            if (this.InventoryProfitDetail.Count == 0 && (this.OP == MZHMM.Common.OP.New || this.OP == MZHMM.Common.OP.Edit || this.OP == MZHMM.Common.OP.Submit|| this.OP == MZHMM.Common.OP.I) )
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }
            if (CheckStorage() == false)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('仓库不统一!');", true);
                return;
            }
            //设定操作人员信息。
            this.SetOperator(this.OP);
            //设定单据状态。
            this.SetEntryState(this.OP);

            this.InventoryProfit.StoCode = this.ddlStorage.SelectedValue;
            this.InventoryProfit.StoName = this.ddlStorage.SelectedItem.Text;
            this.InventoryProfit.Remark = this.txtRemark.Text.Trim();

            switch (this.OP)
            {
                #region New Red
                case MZHMM.Common.OP.New:
                case MZHMM.Common.OP.Red:
                    using(var conn = new SqlConnection(ConnectionString.MM))
                    {
                        conn.Open();
                        var trans = conn.BeginTransaction();
                        this.InventoryProfit.SubTotal = this.InventoryProfitDetail.Sum(obj => obj.ItemMoney);
                        
                        if(new InventoryProfits().Insert(trans, this.InventoryProfit))
                        {
                            var da = new InventoryProfitDetails();
                            
                            foreach(var obj in this.InventoryProfitDetail)
                            {
                                obj.EntryNo = this.InventoryProfit.EntryNo;
                                if(!da.Insert(trans, obj))
                                {
                                    trans.Rollback();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
                                    return;
                                }
                            }
                            //TODOList
                            if (new DataAccess.Common.ToDoLists().Create(trans, 19, this.InventoryProfit.EntryNo, 1030, "T", Master.CurrentUser.LoginName))
                            {
                                trans.Commit();
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);

                            }
                            else
                            {
                                trans.Rollback();
                                ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
                            }
                        }
                        else
                        {
                            trans.Rollback();
                            ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);

                        }
                    }
                    break;
                #endregion
                #region Edit Submit
                case MZHMM.Common.OP.Submit:
                case MZHMM.Common.OP.Edit:
                    using (var conn = new SqlConnection(ConnectionString.MM))
                    {
                        conn.Open();
                        var trans = conn.BeginTransaction();
                        this.InventoryProfit.SubTotal = this.InventoryProfitDetail.Sum(obj => obj.ItemMoney);
                        
                        if (new InventoryProfits().Update(trans, this.InventoryProfit))
                        {
                            var da = new InventoryProfitDetails();
                            if(da.Delete(trans,this.InventoryProfit.EntryNo))
                            {
                                foreach (var obj in this.InventoryProfitDetail)
                                {
                                    if (!da.Insert(trans, obj))
                                    {
                                        trans.Rollback();
                                        ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
                                        return;
                                    }
                                }
                                //TODOList
                                if (new DataAccess.Common.ToDoLists().Create(trans, 19, this.InventoryProfit.EntryNo, 1030, "T", Master.CurrentUser.LoginName))
                                {
                                    trans.Commit();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);

                                }
                                else
                                {
                                    trans.Rollback();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
                            }
                        }
                        else
                        {
                            trans.Rollback();
                            ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
                        }
                    }
                    break;
                #endregion
                #region FirstAudit
                case MZHMM.Common.OP.FirstAudit:
                    if(this.DocAuditWebControl1.Audit1 !="Y" && this.DocAuditWebControl1.Audit1!="N")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                        return;
                    }
                    else
                    {
                        this.InventoryProfit.Audit1 = this.DocAuditWebControl1.Audit1;
                        this.InventoryProfit.AuditDate1 = DateTime.Now;
                        this.InventoryProfit.AuditSuggest1 = this.DocAuditWebControl1.AuditSuggest1;
                        using (var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (new InventoryProfits().Update(trans,this.InventoryProfit))
                            {
                                //TODOList
                                if (new DataAccess.Common.ToDoLists().Create(trans, 19, this.InventoryProfit.EntryNo, 1050, this.InventoryProfit.Audit1=="Y"?"T":"F", Master.CurrentUser.LoginName))
                                {
                                    trans.Commit();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);
                                }
                                else
                                {
                                    trans.Rollback();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"一级审批失败！\");", true);
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess","alert('一级审批失败！');", true);
                            }
                        }
                    }
                    break;
                #endregion
                #region SecondAudit
                case MZHMM.Common.OP.SecondAudit:
                    
                    if (this.DocAuditWebControl1.Audit2 != "Y" && this.DocAuditWebControl1.Audit2 != "N")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                        return;
                    }
                    else
                    {
                        this.InventoryProfit.Audit2 = this.DocAuditWebControl1.Audit1;
                        this.InventoryProfit.AuditDate2 = DateTime.Now;
                        this.InventoryProfit.AuditSuggest2 = this.DocAuditWebControl1.AuditSuggest1;
                        using (var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (new InventoryProfits().Update(trans, this.InventoryProfit))
                            {
                                //TODOList
                                if (new DataAccess.Common.ToDoLists().Create(trans, 19, this.InventoryProfit.EntryNo, 1060, this.InventoryProfit.Audit2=="Y"?"T":"F", Master.CurrentUser.LoginName))
                                {
                                    trans.Commit();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);
                                }
                                else
                                {
                                    trans.Rollback();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"二级审批失败！\");", true);
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess","alert('二级审批失败！');", true);
                            }
                        }
                    }
                    break;
                #endregion
                #region ThirdAudit
                case MZHMM.Common.OP.ThirdAudit:
                    if (this.DocAuditWebControl1.Audit3 != "Y" && this.DocAuditWebControl1.Audit3 != "N")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                        return;
                    }
                    else
                    {
                        this.InventoryProfit.Audit3 = this.DocAuditWebControl1.Audit3;
                        this.InventoryProfit.AuditDate3 = DateTime.Now;
                        this.InventoryProfit.AuditSuggest3 = this.DocAuditWebControl1.AuditSuggest3;
                        using (var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (new InventoryProfits().Update(this.InventoryProfit))
                            {
                                //TODOList
                                if (new DataAccess.Common.ToDoLists().Create(trans, 19, this.InventoryProfit.EntryNo, 1070, this.InventoryProfit.Audit3=="Y"?"T":"F", Master.CurrentUser.LoginName))
                                {
                                    trans.Commit();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);
                                }
                                else
                                {
                                    trans.Rollback();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"三级审批失败！\");", true);
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess",
                                                                    "alert('三级审批失败！');", true);
                            }
                        }
                    }
                    break;
                #endregion
                #region I
                case MZHMM.Common.OP.I:
                    using (var conn = new SqlConnection(ConnectionString.MM))
                    {
                        conn.Open();
                        var trans = conn.BeginTransaction();
                        this.InventoryProfit.EntryState = DocStatus.Received;
                        this.InventoryProfit.AcceptCode = Master.CurrentUser.EmpCode;
                        this.InventoryProfit.AcceptName = Master.CurrentUser.EmpName;
                        this.InventoryProfit.AcceptDate = DateTime.Now;

                        if(new InventoryProfits().Update(trans, this.InventoryProfit))
                        {
                            //明细记录入库。
                            var da = new InventoryProfitDetails();
                            foreach(var obj in this.InventoryProfitDetail)
                            {
                                if(!da.Receive(trans, obj))
                                {
                                    trans.Rollback();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "alert('收料失败！');", true);
                                    return;
                                }
                            }
                            //收发明细记录处理。
                            if(!new IOs().Insert(trans, this.InventoryProfit.EntryNo,this.InventoryProfit.DocCode))
                            {
                                trans.Rollback();
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "alert('收料失败！');", true);
                                return;
                            }
                            if (!new Stocks().DeleteZeroStock(trans))
                            {
                                trans.Rollback();
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "alert('收料失败！');", true);
                                return;
                            }
                            //TODOList
                            if (new DataAccess.Common.ToDoLists().Create(trans, 19, this.InventoryProfit.EntryNo, 1080, "T", Master.CurrentUser.LoginName))
                            {
                                trans.Commit();
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);
                                
                            }
                            else
                            {
                                trans.Rollback();
                                ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"收料失败！\");", true);
                            }
                        }
                        else
                        {
                            trans.Rollback();
                            ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "alert('收料失败！');", true);
                        }
                    }
                    break;
                #endregion
            }
        }

        protected void btnPresent_Click(object sender, EventArgs e)
        {
            //没有内容
            if (this.InventoryProfitDetail.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }
            if (CheckStorage() == false)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('仓库不统一!');", true);
                return;
            }
            //设定操作人员信息。
            this.SetOperator(this.OP);

            this.InventoryProfit.EntryState = DocStatus.Present;
            this.InventoryProfit.StoCode = this.ddlStorage.SelectedValue;
            this.InventoryProfit.StoName = this.ddlStorage.SelectedItem.Text;

            this.InventoryProfit.Remark = this.txtRemark.Text.Trim();
            using (var conn = new SqlConnection(ConnectionString.MM))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                var subTotal = this.InventoryProfitDetail.Sum(obj => obj.ItemMoney);

                this.InventoryProfit.SubTotal = subTotal;
                bool ret = false;
                if (this.OP == MZHMM.Common.OP.New || this.OP == MZHMM.Common.OP.Red)
                    ret = new InventoryProfits().Insert(trans, this.InventoryProfit);
                else if (this.OP == MZHMM.Common.OP.Edit || this.OP==MZHMM.Common.OP.Submit)
                    ret = new InventoryProfits().Update(trans, this.InventoryProfit);
                if (ret)
                {
                    var da = new InventoryProfitDetails();
                    if (this.OP == MZHMM.Common.OP.Edit || this.OP == MZHMM.Common.OP.Submit)
                    {
                        if (!da.Delete(trans, this.InventoryProfit.EntryNo))
                        {
                            trans.Rollback();
                            ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"马上提交失败1！\");", true);
                            return;
                        }
                    }
                    foreach (var obj in this.InventoryProfitDetail)
                    {
                        obj.EntryNo = this.InventoryProfit.EntryNo;
                        if (da.Insert(trans, obj))
                        {

                        }
                        else
                        {
                            trans.Rollback();
                            ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"马上提交失败2！\");", true);
                            return;
                        }
                    }
                    //TODOList
                    if (new DataAccess.Common.ToDoLists().Create(trans, 19, this.InventoryProfit.EntryNo, 1040, "T", Master.CurrentUser.LoginName))
                    {
                        trans.Commit();
                        ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);

                    }
                    else
                    {
                        trans.Rollback();
                        ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"马上提交失败3！\");", true);
                    }
                }
                else
                {
                    trans.Rollback();
                    ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"马上提交失败4！\");", true);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript( this.GetType(), "close", "window.close();", true);
        }

        protected void btnForItemCode_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text != "")
            {
                if (txtItemCode.Text != "-1")
                {
                    //
                    //设置物料名称，规格型号，单价控件为只读并灰掉单位控件
                    //
                    this.txtItemName.ReadOnly = true;
                    this.txtItemSpecial.ReadOnly = true;
                    this.txtItemPrice.ReadOnly = false;
                    this.ddlUnit.Enable = false;

                    var oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    //存在物料数据
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        try
                        {
                            this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        }
                        catch
                        {
                            try { this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###"); }
                            catch { this.txtItemPrice.Text = "0.000"; }
                        }
                        //度量单位
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                        try{
                            ddlCon.SelectedValue =
                                oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.DEFCON_FIELD].ToString();
                        }
                        catch{}
                    }
                    else
                    {
                        //
                        //不存在缺省为需要输入数据,弹出物料浏览界面,提供用户选择
                        //
                    }

                    // this.DistributeFee(this.TotalFee);
                }
                else
                {
                    //
                    //用户直接输入
                    //
                    this.txtItemName.ReadOnly = false;
                    this.txtItemSpecial.ReadOnly = false;
                    this.txtItemPrice.ReadOnly = false;
                    this.ddlUnit.Enable = true;
                    var oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        //度量单位
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }

                    //this.DistributeFee(this.TotalFee);
                }
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (DoCheck())
            {
                #region 新增
                if (btnAddItem.Text == "新增")
                {
                    var obj =
                        this.InventoryProfitDetail.Find(
                            item =>
                            item.ItemCode.ToUpper() == this.txtItemCode.Text.ToUpper() &&
                            item.ItemName.ToUpper() == this.txtItemName.Text.ToUpper() &&
                            item.ItemSpec.ToUpper() == this.txtItemSpecial.Text.ToUpper() &&
                            item.ConCode.ToString() == this.ddlCon.SelectedValue);
                    if (obj != null)
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('提醒：该物料在该架位已经存在！');", true);
                        return;
                    }
                    else
                    {
                        obj = new InventoryProfitDetailInfo();
                        obj.EntryNo = this.EntryNo;
                        obj.SerialNo = (short)(this.InventoryProfitDetail.Count);
                        obj.ItemCode = this.txtItemCode.Text;
                        obj.ItemName = this.txtItemName.Text;
                        obj.ItemSpec = this.txtItemSpecial.Text;
                        obj.ItemUnit = short.Parse(this.ddlUnit.SelectedValue);
                        obj.ItemUnitName = this.ddlUnit.SelectedText;
                        obj.ConCode = int.Parse(this.ddlCon.SelectedValue);
                        obj.ConName = this.ddlCon.SelectedItem.Text;
                        obj.StoCode = this.ddlStorage.SelectedValue;
                        obj.StoName = this.ddlStorage.SelectedItem.Text;
                        if (obj.StoCode == "00")//账外仓库
                            obj.ItemPrice = 0;
                        else
                            obj.ItemPrice = decimal.Parse(this.txtItemPrice.Text);
                        try
                        {
                            obj.CarryingAmount = decimal.Parse(this.txtCarryingAmount.Text);
                        }
                        catch
                        {
                            obj.CarryingAmount = 0;
                        }
                        try
                        {
                            obj.InventoryAmount = decimal.Parse(this.txtInventoryAmount.Text);
                        }
                        catch
                        {
                            obj.InventoryAmount = 0;
                        }
                        try
                        {
                            obj.ItemNum = decimal.Parse(this.txtItemNum.Text);
                        }
                        catch
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘赢数量不正确！');", true);
                            return;
                        }
                        if (obj.ItemNum <= 0)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘盈数量必须大于等于0！');", true);
                            return;
                        }
                        if ( obj.InventoryAmount-obj.CarryingAmount  != obj.ItemNum)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘赢数量必须等于盘点数量减去账面数量！');", true);
                            return;
                        }

                        obj.ItemMoney = obj.ItemPrice * obj.ItemNum;
                        
                        this.InventoryProfitDetail.Add(obj);
                    }
                }
                #endregion
                #region 更新
                else
                {
                    var currentSerialNo = short.Parse(txtItemSerial.Value);
                    var obj =
                        this.InventoryProfitDetail.Find(
                            item =>
                            item.ItemCode.ToUpper() == this.txtItemCode.Text.ToUpper() &&
                            item.ItemName.ToUpper() == this.txtItemName.Text.ToUpper() &&
                            item.ItemSpec.ToUpper() == this.txtItemSpecial.Text.ToUpper() &&
                            item.ConCode.ToString() == this.ddlCon.SelectedValue);
                    if (obj != null)
                    {
                        if (obj.SerialNo == currentSerialNo)
                        {
                            obj.ConCode = int.Parse(this.ddlCon.SelectedValue);
                            obj.ConName = this.ddlCon.SelectedItem.Text;
                            obj.StoCode = this.ddlStorage.SelectedValue;
                            obj.StoName = this.ddlStorage.SelectedItem.Text;
                            if (obj.StoCode == "00")
                                obj.ItemPrice = 0;
                            else
                                obj.ItemPrice = decimal.Parse(this.txtItemPrice.Text);
                            try
                            {
                                obj.CarryingAmount = decimal.Parse(this.txtCarryingAmount.Text);
                            }
                            catch
                            {
                                obj.CarryingAmount = 0;
                            }
                            try
                            {
                                obj.InventoryAmount = decimal.Parse(this.txtInventoryAmount.Text);
                            }
                            catch
                            {
                                obj.InventoryAmount = 0;
                            }
                            try
                            {
                                obj.ItemNum = decimal.Parse(this.txtItemNum.Text);
                            }
                            catch
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘赢数量不正确！');", true);
                                return;
                            }
                            if (obj.ItemNum <= 0)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘盈数量必须大于等于0！');", true);
                                return;
                            }
                            if (obj.InventoryAmount - obj.CarryingAmount != obj.ItemNum)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘赢数量必须等于盘点数量减去账面数量！');", true);
                                return;
                            }
                            obj.ItemMoney = obj.ItemPrice * obj.ItemNum;
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "NotUnique", "alert(\"已经存在重复记录！\")", true);
                            return;
                        }
                    }
                    else
                    {
                        obj = this.InventoryProfitDetail.Find(item => item.SerialNo == currentSerialNo);
                        if (obj != null)
                        {
                            obj.ItemCode = this.txtItemCode.Text;
                            obj.ItemName = this.txtItemNum.Text;
                            obj.ItemSpec = this.txtItemSpecial.Text;
                            obj.ItemUnit = short.Parse(this.ddlUnit.SelectedValue);
                            obj.ItemUnitName = this.ddlUnit.SelectedText;
                            obj.ConCode = int.Parse(this.ddlCon.SelectedValue);
                            obj.ConName = this.ddlCon.SelectedItem.Text;
                            obj.StoCode = this.ddlStorage.SelectedValue;
                            obj.StoName = this.ddlStorage.SelectedItem.Text;
                            if (obj.StoCode == "00")
                                obj.ItemPrice = 0;
                            else
                               obj.ItemPrice = decimal.Parse(this.txtItemPrice.Text);
                            obj.ItemNum = decimal.Parse(this.txtItemNum.Text);
                            obj.ItemMoney = obj.ItemNum * obj.ItemPrice;
                        }
                    }


                    txtItemSerial.Value = "-1";
                    btnAddItem.Text = "新增";
                    btnEditItem.Enabled = true;

                }
                #endregion
                #region 复位
                this.DGModel_Items1.DataSource = this.InventoryProfitDetail;
                this.DGModel_Items1.DataBind();
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtItemSpecial.Text = "";
                this.ddlUnit.SetItemSelected("-1");
                this.txtItemPrice.Text = "";

                this.txtItemNum.Text = "";
                this.ddlCon.SelectedIndex = 0;
                #endregion

                this.btnDelItem.Enabled = true;
            }
        }

        protected void btnDelItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
            {
                var obj = this.InventoryProfitDetail.Find(item => item.SerialNo == short.Parse(DGModel_Items1.SelectedID));
                if (obj != null)
                {
                    this.InventoryProfitDetail.Remove(obj);
                }
                DGModel_Items1.DataSource = this.InventoryProfitDetail;
                DGModel_Items1.DataBind();
            }
        }

        protected void btnEditItem_Click(object sender, EventArgs e)
        {
            //不等于-1表示已经处于编辑状态
            if (txtItemSerial.Value == "-1")
            {
                if (!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
                {
                    var obj = this.InventoryProfitDetail.Find(item => item.SerialNo == short.Parse(DGModel_Items1.SelectedID));

                    if (obj != null)
                    {
                        this.txtItemSerial.Value = obj.SerialNo.ToString();//顺序号。
                        this.txtItemCode.Text = obj.ItemCode;//物料编号。
                        this.txtItemName.Text = obj.ItemName;//物料名称。
                        this.txtItemSpecial.Text = obj.ItemSpec;//规格型号。
                        this.ddlUnit.SetItemSelected(obj.ItemUnit.ToString());//度量单位
                        this.txtItemPrice.Text = obj.ItemPrice.ToString();//单价。
                        this.txtItemNum.Text = obj.ItemNum.ToString();//实收数量。				
                        this.ddlCon.SelectedValue = obj.ConCode.ToString();
                        this.txtCarryingAmount.Text = obj.CarryingAmount.ToString();
                        this.txtInventoryAmount.Text = obj.InventoryAmount.ToString();
                        btnAddItem.Text = "更新";
                        btnAddItem.Enabled = true;
                        btnEditItem.Enabled = false;
                    }
                }
            }
        }

        protected void ddlStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ddlStorage.SelectedValue != "-1")
            {
                this.BindCon();
            }
        }

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                if (this.InventoryProfit.ParentEntryNo > 0)
                {
                    e.Item.Cells[8].ForeColor = Color.Red;
                    e.Item.Cells[9].ForeColor = Color.Red;
                }
            }
        }
    }
}