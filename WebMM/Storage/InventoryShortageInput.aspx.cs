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
    public partial class InventoryShortageInput : System.Web.UI.Page
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        #endregion

        #region Property
        public InventoryShortageInfo InventoryShortage
        {
            get
            {
                if (Session["InventoryShortageInfo"] == null)
                    Session["InventoryShortageInfo"] = new InventoryShortageInfo(){DocCode = (short)this.doc1.DocCode,DocName = doc1.DocName,DocNo = doc1.DocNo,EntryDate = DateTime.Now};
                return Session["InventoryShortageInfo"] as InventoryShortageInfo;
            }
            set { Session["InventoryShortageInfo"] = value; }
        }
            
        public List<InventoryShortageDetailInfo> InventoryShortageDetail
        {
            get
            {
                if (Session["InventoryShortageDetailInfos"] == null)
                {
                    Session["InventoryShortageDetailInfos"] = new List<InventoryShortageDetailInfo>();
                }
                return Session["InventoryShortageDetailInfos"] as List<InventoryShortageDetailInfo>;
            }
            set { Session["InventoryShortageDetailInfos"] = value; }
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
        /// <summary>
        /// 是否是从待办事宜处调用进入。
        /// </summary>
        /// <remarks>
        /// 因为需要根据不同进入的页面，操作完成后要进行刷新。
        /// </remarks>
        private bool IsFromTodo
        {
            get
            {
                return this.Request["TODO"] == null ? false : true;
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
                ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"请选择仓库！\");", true);
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
                ClientScript.RegisterStartupScript( this.GetType(), "DoCheck", "alert(\"单价、数量应为数字型！\");", true);
                retValue = false;
            }
            return retValue;
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
                        this.editRow.Visible = false;
                        this.editRowHeader.Visible = false;
                        this.btnRefuse.Visible = false;
                        this.btnPresent.Visible = false;
                        break;
                    case Shmzh.MM.Common.OP.View:
                        this.editRow.Visible = false;
                        this.editRowHeader.Visible = false;
                        this.btnRefuse.Visible = false;
                        this.btnSave.Visible = false;
                        this.btnCancel.Text = "关闭";
                        this.btnPresent.Visible = false;
                        break;
                    case Shmzh.MM.Common.OP.O:
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
                        this.btnAddItem.Enabled = false;
                        this.btnDelItem.Enabled = false;
                        this.btnEditItem.Enabled = true;
                        this.btnPresent.Visible = false;
                        this.txtStoManager.Text = Master.CurrentUser.EmpName;
                        this.txtDrawDate.Text = DateTime.Today.ToShortDateString();
                        this.btnSave.Text = OPName.O;
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
                        this.btnAddItem.Enabled = true;
                        this.btnDelItem.Enabled = true;
                        this.btnEditItem.Enabled = true;
                        this.btnRefuse.Enabled = true;
                        this.btnRefuse.Visible = false;
                        break;
                    case Shmzh.MM.Common.OP.Red:
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
                    this.InventoryShortage.AuthorCode = Master.CurrentUser.thisUserInfo.EmpCode;
                    this.InventoryShortage.AuthorName = Master.CurrentUser.thisUserInfo.EmpName;
                    this.InventoryShortage.AuthorLoginId = Master.CurrentUser.thisUserInfo.LoginName;
                    this.InventoryShortage.AuthorDept = Master.CurrentUser.thisUserInfo.DeptCode;
                    this.InventoryShortage.AuthorDeptName = Master.CurrentUser.thisUserInfo.DeptName;
                    break;
                case Shmzh.MM.Common.OP.FirstAudit://一级审批。
                    this.InventoryShortage.Assessor1 = Master.CurrentUser.thisUserInfo.EmpName;
                    break;
                case Shmzh.MM.Common.OP.SecondAudit://二级审批。
                    this.InventoryShortage.Assessor2 = Master.CurrentUser.thisUserInfo.EmpName;
                    break;
                case Shmzh.MM.Common.OP.ThirdAudit://三级审批。
                    this.InventoryShortage.Assessor3 = Master.CurrentUser.thisUserInfo.EmpName;
                    break;
                case Shmzh.MM.Common.OP.O://发料。
                    this.InventoryShortage.StoManagerCode = Master.CurrentUser.thisUserInfo.EmpCode;
                    this.InventoryShortage.StoManager = Master.CurrentUser.thisUserInfo.EmpName;
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
            var auditLevel = new SysSystem().GetAuditLevel(this.InventoryShortage.DocCode);
            switch(OpMode)
            {
                case Shmzh.MM.Common.OP.New:
                case Shmzh.MM.Common.OP.Edit:
                case Shmzh.MM.Common.OP.Red:
                    this.InventoryShortage.EntryState = DocStatus.New;
                    break;
                case Shmzh.MM.Common.OP.Submit:
                case Shmzh.MM.Common.OP.NewAndPresent:
                case Shmzh.MM.Common.OP.EditAndPresent:
                    this.InventoryShortage.EntryState = DocStatus.Present;
                    break;
                case Shmzh.MM.Common.OP.FirstAudit:
                    this.InventoryShortage.EntryState = auditLevel == 1 ? (this.DocAuditWebControl1.Audit1 == AuditResult.Passed ? DocStatus.TrdPass : DocStatus.FstNoPass) : (this.DocAuditWebControl1.Audit1 == AuditResult.Passed ? DocStatus.FstPass : DocStatus.FstNoPass);
                    break;
                case Shmzh.MM.Common.OP.SecondAudit:
                    this.InventoryShortage.EntryState = auditLevel == 2 ? (this.DocAuditWebControl1.Audit1 == AuditResult.Passed ? DocStatus.TrdPass : DocStatus.SecNoPass) : (this.DocAuditWebControl1.Audit1 == AuditResult.Passed ? DocStatus.SecPass : DocStatus.SecNoPass);
                    break;
                case Shmzh.MM.Common.OP.ThirdAudit:
                    this.InventoryShortage.EntryState = this.DocAuditWebControl1.Audit3 == AuditResult.Passed ? DocStatus.TrdPass : DocStatus.TrdNoPass;
                    break;
                case Shmzh.MM.Common.OP.O:
                    this.InventoryShortage.EntryState = DocStatus.Drawed;
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

        /// <summary>
        /// 检查仓库发料的前提条件。
        /// </summary>
        /// <param name="dt">DataTable:	领料单数据表。</param>
        /// <returns>bool:	符合条件返回true,不符合返回false.</returns>
        private bool CheckOutCondition(List<InventoryShortageDetailInfo> objs)
        {
            decimal StockNum, ItemNum;//库存数、发出数。
            string ItemCode, ItemName, ItemSpec;

            for (int i = 0; i < objs.Count; i++)
            {
                StockNum = objs[i].CurrentStockNum;
                ItemNum = objs[i].ItemNum;
                
                ItemCode = objs[i].ItemCode;
                ItemName = objs[i].ItemName;
                ItemSpec = objs[i].ItemSpec;
                //求相同物料累计的发出数。
                for (int j = i + 1; j < objs.Count; j++)
                {
                    if (ItemCode == "-1")//OTI物料。
                    {
                        if (ItemCode == objs[j].ItemCode &&
                            ItemName == objs[j].ItemName &&
                            ItemSpec == objs[j].ItemSpec)//有相同的物料。
                        {
                            try
                            { ItemNum += objs[j].ItemNum; }
                            catch
                            { }
                        }
                    }
                    else//正常物料。
                    {
                        if (ItemCode == objs[j].ItemCode)//有相同的物料。
                        {
                            try
                            { ItemNum += objs[j].ItemNum; }
                            catch
                            { }
                        }
                    }
                }//end of for( j);
                if (StockNum < ItemNum)
                {
                    return false;
                }
            }//end of for (i)
            return true;
        }
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.doc1.DocCode = DocType.INVENTORYSHORTAGE;
            this.DocAuditWebControl1.DocCode = DocType.INVENTORYSHORTAGE;
            ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
            if(!IsPostBack)
            {
                #region Check Right
                if (this.OP == Shmzh.MM.Common.OP.New || this.OP == Shmzh.MM.Common.OP.Edit)
                {
                    if(!Master.CurrentUser.HasRight(SysRight.InventoryShortageMaintain))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx",true);
                    }
                }
                else if (this.OP == Shmzh.MM.Common.OP.FirstAudit)
                {
                    if(!Master.CurrentUser.HasRight(SysRight.InventoryShortageFirstAudit))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx", true);
                    }
                }
                else if (this.OP == Shmzh.MM.Common.OP.SecondAudit)
                {
                    if (!Master.CurrentUser.HasRight(SysRight.InventoryShortageSecondAudit))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx", true);
                    }
                }
                else if (this.OP == Shmzh.MM.Common.OP.ThirdAudit)
                {
                    if (!Master.CurrentUser.HasRight(SysRight.InventoryShortageThirdAudit))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx", true);
                    }
                }
                else if (this.OP == Shmzh.MM.Common.OP.I)
                {
                    if(!Master.CurrentUser.HasRight(SysRight.StockIn))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx",true);
                    }
                }
                else if (this.OP == Shmzh.MM.Common.OP.Red)
                {
                    if(!Master.CurrentUser.HasRight(SysRight.InventoryShortageMaintain))
                    {
                        this.Response.Redirect("../Common/NoRight.aspx", true);
                    }
                }
                #endregion
                this.BindStorage();
                if( this.EntryNo != 0)
                {
                    this.InventoryShortage = new InventoryShortages().GetById(this.EntryNo);
                    this.InventoryShortageDetail = new InventoryShortageDetails().GetByEntryNo(this.EntryNo);

                    #region Check Status
                    if (this.OP == Shmzh.MM.Common.OP.Edit)
                    {
                        if( this.InventoryShortage.EntryState!=DocStatus.New && 
                            this.InventoryShortage.EntryState!=DocStatus.Cancel&&
                            this.InventoryShortage.EntryState!=DocStatus.FstNoPass&&
                            this.InventoryShortage.EntryState!=DocStatus.SecNoPass&&
                            this.InventoryShortage.EntryState!=DocStatus.TrdNoPass)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许编辑！\");window.close();", true);
                            return;
                        }
                    }
                    else if (this.OP == Shmzh.MM.Common.OP.FirstAudit)
                    {
                        if(this.InventoryShortage.EntryState != DocStatus.Present)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许编辑！\");window.close();", true);
                            return;
                        }
                    }
                    else if (this.OP == Shmzh.MM.Common.OP.SecondAudit)
                    {
                        if(this.InventoryShortage.EntryState != DocStatus.FstPass)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许编辑！\");window.close();", true);
                            return;
                        }
                    }
                    else if (this.OP == Shmzh.MM.Common.OP.ThirdAudit)
                    {
                        if(this.InventoryShortage.EntryState != DocStatus.SecPass)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许编辑！\");window.close();", true);
                            return;
                        }
                    }
                    else if (this.OP == Shmzh.MM.Common.OP.O)
                    {
                        if(this.InventoryShortage.EntryState != DocStatus.TrdPass)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许发料！\");window.close();", true);
                            return;
                        }
                    }
                    else if (this.OP == Shmzh.MM.Common.OP.Red)
                    {
                        if (this.InventoryShortage.EntryState != DocStatus.Drawed)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "IncorrectStatus", "alert(\"该状态下不允许红字！\");window.close();", true);
                            return;
                        }
                        else
                        {
                            if (this.InventoryShortage.ParentEntryNo > 0)
                            {
                                ClientScript.RegisterStartupScript( this.GetType(), "IncorrectRed", "alert(\"红字单据不能再冲红字！\");window.close();", true);
                                return;
                            }
                        }
                    }
                    #endregion

                    if (this.OP == Shmzh.MM.Common.OP.Red)
                    {
                        this.InventoryShortage.ParentEntryNo = this.InventoryShortage.EntryNo;
                        this.InventoryShortage.EntryNo = 0;
                        this.InventoryShortage.Audit1 = string.Empty;
                        this.InventoryShortage.Audit2 = string.Empty;
                        this.InventoryShortage.Audit3 = string.Empty;
                        this.InventoryShortage.Assessor1 = string.Empty;
                        this.InventoryShortage.Assessor2 = string.Empty;
                        this.InventoryShortage.Assessor3 = string.Empty;
                        this.InventoryShortage.AuditDate1 = DateTime.MinValue;
                        this.InventoryShortage.AuditDate2 = DateTime.MinValue;
                        this.InventoryShortage.AuditDate3 = DateTime.MinValue;
                        this.InventoryShortage.AuditSuggest1 = string.Empty;
                        this.InventoryShortage.AuditSuggest2 = string.Empty;
                        this.InventoryShortage.AuditSuggest3 = string.Empty;
                        this.InventoryShortage.AuthorCode = Master.CurrentUser.EmpCode;
                        this.InventoryShortage.AuthorName = Master.CurrentUser.EmpName;
                        this.InventoryShortage.AuthorLoginId = Master.CurrentUser.LoginName;
                        this.InventoryShortage.AuthorDept = Master.CurrentUser.DeptCode;
                        this.InventoryShortage.AuthorDeptName = Master.CurrentUser.DeptName;
                        this.InventoryShortage.StoManagerCode = string.Empty;
                        this.InventoryShortage.StoManager = string.Empty;
                        this.InventoryShortage.DrawDate = DateTime.MinValue;
                        this.InventoryShortage.EntryState = DocStatus.New;
                        this.InventoryShortage.PresentDate = DateTime.MinValue;
                        this.InventoryShortage.EntryDate = DateTime.Now;
                        this.InventoryShortage.CancelDate = DateTime.MinValue;
                        this.InventoryShortage.SubTotal = -this.InventoryShortage.SubTotal;
                        this.InventoryShortage.Remark = string.Empty;

                        //已经生成的红字单据。
                        var redObjs = new InventoryShortages().GetByParentEntryNo(this.InventoryShortage.ParentEntryNo);
                        if (redObjs.Count > 0)//之前已经生成过红字单据。
                        {
                            foreach (var redObj in redObjs)
                            {
                                var redObjDetails = new InventoryShortageDetails().GetByEntryNo(redObj.EntryNo);
                                foreach (var redObjDetail in redObjDetails)
                                {
                                    var findObj = this.InventoryShortageDetail.Find(item => item.ItemCode == redObjDetail.ItemCode );
                                    if (findObj != null)
                                        this.InventoryShortageDetail.Remove(findObj);
                                }
                            }
                            if (this.InventoryShortageDetail.Count == 0)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "nothingRed", "alert('该单据已经被红冲完！');window.close();", true);
                                return;
                            }
                            else
                            {
                                foreach (var obj in this.InventoryShortageDetail)
                                {
                                    obj.EntryNo = 0;
                                    obj.ItemNum = -obj.ItemNum;
                                    obj.ItemMoney = -obj.ItemMoney;
                                }
                            }
                        }
                        else
                        {
                            foreach (var obj in this.InventoryShortageDetail)
                            {
                                obj.EntryNo = 0;
                                obj.ItemNum = -obj.ItemNum;
                                obj.ItemMoney = -obj.ItemMoney;
                            }
                        }
                    }

                    if (this.OP == Shmzh.MM.Common.OP.Red)
                    {
                        this.doc1.DataBindNew();
                    }
                    else
                    {
                        this.doc1.DataBindUpdate();
                        this.doc1.EntryNo = this.InventoryShortage.EntryNo;
                        this.doc1.EntryCode = this.InventoryShortage.EntryCode;
                        this.doc1.EntryDate = this.InventoryShortage.EntryDate;
                    }
                    

                    this.ddlStorage.SelectedValue = this.InventoryShortage.StoCode;
                    this.txtRemark.Text = this.InventoryShortage.Remark;

                    this.DocAuditWebControl1.Audit1 = this.InventoryShortage.Audit1;
                    this.DocAuditWebControl1.Audit2 = this.InventoryShortage.Audit2;
                    this.DocAuditWebControl1.Audit3 = this.InventoryShortage.Audit3;
                    this.DocAuditWebControl1.AuditDate1 = this.InventoryShortage.AuditDate1.ToString();
                    this.DocAuditWebControl1.AuditDate2 = this.InventoryShortage.AuditDate2.ToString();
                    this.DocAuditWebControl1.AuditDate3 = this.InventoryShortage.AuditDate3.ToString();
                    this.DocAuditWebControl1.Auditor1 = this.InventoryShortage.Assessor1;
                    this.DocAuditWebControl1.Auditor2 = this.InventoryShortage.Assessor2;
                    this.DocAuditWebControl1.Auditor3 = this.InventoryShortage.Assessor3;
                    this.DocAuditWebControl1.AuditSuggest1 = this.InventoryShortage.AuditSuggest1;
                    this.DocAuditWebControl1.AuditSuggest2 = this.InventoryShortage.AuditSuggest2;
                    this.DocAuditWebControl1.AuditSuggest2 = this.InventoryShortage.AuditSuggest3;
                    this.lblAuthorName.Text = this.InventoryShortage.AuthorName;
                    this.lblAuthorDeptName.Text = this.InventoryShortage.AuthorDeptName;
                    this.txtStoManager.Text = this.InventoryShortage.StoManager;
                    this.txtDrawDate.Text = this.InventoryShortage.DrawDate == DateTime.MinValue
                                                  ? string.Empty
                                                  : this.InventoryShortage.DrawDate.ToShortDateString();
                }
                else
                {
                    if (string.IsNullOrEmpty(Request["InventoryId"]))
                    {
                        this.InventoryShortage = null;
                        this.InventoryShortageDetail = null;
                        this.lblAuthorDeptName.Text = Master.CurrentUser.DeptName;
                        this.lblAuthorName.Text = Master.CurrentUser.EmpName;
                        this.doc1.DataBindNew();
                    }
                    else//由盘点结果来生成盘亏单。 
                    {
                        var inventoryId = int.Parse(Request["InventoryId"]);
                        var inventory = new Inventorys().GetById(inventoryId);
                        if (inventory != null)
                        {
                            this.ddlStorage.SelectedValue = inventory.StoCode;
                        }
                        this.InventoryShortage = null;
                        this.InventoryShortageDetail = new InventoryShortageDetails().GetByInventoryId(inventoryId);
                        if (this.InventoryShortageDetail.Count > 0)
                        {
                            for (var i = 0; i < this.InventoryShortageDetail.Count; i++)
                            {
                                this.InventoryShortageDetail[i].SerialNo = (short)i;
                            }
                        }
                        this.lblAuthorDeptName.Text = Master.CurrentUser.DeptName;
                        this.lblAuthorName.Text = Master.CurrentUser.EmpName;
                        this.doc1.DataBindNew();
                    }
                }
            }

            this.SetEditMode(this.OP);//设定编辑区域的显示模式。
            
            
            

            
            DGModel_Items1.DataSource = this.InventoryShortageDetail;//数据源绑定。
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
            if (this.InventoryShortageDetail.Count == 0 && (this.OP == Shmzh.MM.Common.OP.New || this.OP == Shmzh.MM.Common.OP.Edit || this.OP == Shmzh.MM.Common.OP.Submit || this.OP == Shmzh.MM.Common.OP.O))
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }
            //设定操作人员信息。
            this.SetOperator(this.OP);
            //设定单据状态。
            this.SetEntryState(this.OP);

            this.InventoryShortage.StoCode = this.ddlStorage.SelectedValue;
            this.InventoryShortage.StoName = this.ddlStorage.SelectedItem.Text;
            this.InventoryShortage.Remark = this.txtRemark.Text.Trim();

            switch (this.OP)
            {
                #region New Red
                case Shmzh.MM.Common.OP.New:
                case Shmzh.MM.Common.OP.Red:
                    using(var conn = new SqlConnection(ConnectionString.MM))
                    {
                        conn.Open();
                        var trans = conn.BeginTransaction();
                        this.InventoryShortage.SubTotal = this.InventoryShortageDetail.Sum(obj => obj.ItemMoney);
                        
                        if(new InventoryShortages().Insert(trans, this.InventoryShortage))
                        {
                            var da = new InventoryShortageDetails();
                            
                            foreach(var obj in this.InventoryShortageDetail)
                            {
                                obj.EntryNo = this.InventoryShortage.EntryNo;
                                if(!da.Insert(trans, obj))
                                {
                                    trans.Rollback();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
                                    return;
                                }
                            }
                            //TODOList
                            if (new Shmzh.MM.DataAccess.Common.ToDoLists().Create(trans, 20, this.InventoryShortage.EntryNo, 1090, "T", Master.CurrentUser.LoginName))
                            {
                                trans.Commit();
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);

                            }
                            else
                            {
                                trans.Rollback();
                                ClientScript.RegisterStartupScript(this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
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
                case Shmzh.MM.Common.OP.Submit:
                case Shmzh.MM.Common.OP.Edit:
                    using (var conn = new SqlConnection(ConnectionString.MM))
                    {
                        conn.Open();
                        var trans = conn.BeginTransaction();
                        this.InventoryShortage.SubTotal = this.InventoryShortageDetail.Sum(obj => obj.ItemMoney);
                        
                        if (new InventoryShortages().Update(trans, this.InventoryShortage))
                        {
                            var da = new InventoryShortageDetails();
                            if(da.Delete(trans,this.InventoryShortage.EntryNo))
                            {
                                foreach (var obj in this.InventoryShortageDetail)
                                {
                                    if (!da.Insert(trans, obj))
                                    {
                                        trans.Rollback();
                                        break;
                                    }
                                }
                                //TODOList
                                if (new Shmzh.MM.DataAccess.Common.ToDoLists().Create(trans, 20, this.InventoryShortage.EntryNo, 1100, "T", Master.CurrentUser.LoginName))
                                {
                                    trans.Commit();
                                    ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);

                                }
                                else
                                {
                                    trans.Rollback();
                                    ClientScript.RegisterStartupScript(this.GetType(), "saveFailed", "alert(\"保存失败！\");", true);
                                }
                            }
                            else
                            {
                                trans.Rollback();
                            }
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                    break;
                #endregion
                #region FirstAudit
                case Shmzh.MM.Common.OP.FirstAudit:
                    if(this.DocAuditWebControl1.Audit1 !="Y" && this.DocAuditWebControl1.Audit1!="N")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                        return;
                    }
                    else
                    {
                        this.InventoryShortage.Audit1 = this.DocAuditWebControl1.Audit1;
                        this.InventoryShortage.AuditDate1 = DateTime.Now;
                        this.InventoryShortage.AuditSuggest1 = this.DocAuditWebControl1.AuditSuggest1;
                        using (var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (new InventoryShortages().Update(trans,this.InventoryShortage))
                            {
                                //TODOList
                                if (new Shmzh.MM.DataAccess.Common.ToDoLists().Create(trans, 20, this.InventoryShortage.EntryNo, 1110, this.InventoryShortage.Audit1=="Y"?"T":"F", Master.CurrentUser.LoginName))
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
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess",
                                                                    "alert('一级审批失败！');", true);
                            }
                        }
                    }
                    break;
                #endregion
                #region SecondAudit
                case Shmzh.MM.Common.OP.SecondAudit:
                    
                    if (this.DocAuditWebControl1.Audit2 != "Y" && this.DocAuditWebControl1.Audit2 != "N")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                        return;
                    }
                    else
                    {
                        this.InventoryShortage.Audit2 = this.DocAuditWebControl1.Audit1;
                        this.InventoryShortage.AuditDate2 = DateTime.Now;
                        this.InventoryShortage.AuditSuggest2 = this.DocAuditWebControl1.AuditSuggest1;
                        using (var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (new InventoryShortages().Update(trans, this.InventoryShortage))
                            {
                                //TODOList
                                if (new Shmzh.MM.DataAccess.Common.ToDoLists().Create(trans, 20, this.InventoryShortage.EntryNo, 1120, this.InventoryShortage.Audit2=="Y"?"T":"F", Master.CurrentUser.LoginName))
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
                                ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess",
                                                                    "alert('二级审批失败！');", true);
                            }
                        }
                    }
                    break;
                #endregion
                #region ThirdAudit
                case Shmzh.MM.Common.OP.ThirdAudit:
                    if (this.DocAuditWebControl1.Audit3 != "Y" && this.DocAuditWebControl1.Audit3 != "N")
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('请确认审批通过或是不通过!');", true);
                        return;
                    }
                    else
                    {
                        this.InventoryShortage.Audit3 = this.DocAuditWebControl1.Audit3;
                        this.InventoryShortage.AuditDate3 = DateTime.Now;
                        this.InventoryShortage.AuditSuggest3 = this.DocAuditWebControl1.AuditSuggest3;
                        using (var conn = new SqlConnection(ConnectionString.MM))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (new InventoryShortages().Update(this.InventoryShortage))
                            {
                                //TODOList
                                if (new Shmzh.MM.DataAccess.Common.ToDoLists().Create(trans, 20, this.InventoryShortage.EntryNo, 1130, this.InventoryShortage.Audit3=="Y"?"T":"F", Master.CurrentUser.LoginName))
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
                                ClientScript.RegisterStartupScript(this.GetType(), "saveSuccess",
                                                                    "alert('三级审批失败！');", true);
                            }
                        }
                    }
                    break;
                #endregion
                #region O
                case Shmzh.MM.Common.OP.O:
                    if (this.InventoryShortage.ParentEntryNo > 0)
                    {
                        var ret = new InventoryShortages().DrawOutStock(this.InventoryShortage.EntryNo, "", "", "", "", Master.CurrentUser.EmpCode, Master.CurrentUser.EmpName, Master.CurrentUser.LoginName);
                        if (ret == false)
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"发料失败！\");", true);
                            return;
                        }
                        else 
                        {
                            ClientScript.RegisterStartupScript( this.GetType(), "saveSuccess", "window.close();window.opener.refresh();", true);
                            return;
                        }
                    }
                    else
                    {
                        if (this.CheckOutCondition(this.InventoryShortageDetail))
                        {
                            if (this.IsFromTodo)
                            {
                                this.Response.Redirect("ConChooser.aspx?DocCode=20&EntryNo=" + this.doc1.EntryNo.ToString() + "&Op=" + Shmzh.MM.Common.OP.O + "&TODO=Y");
                            }
                            else
                            {
                                this.Response.Redirect("Conchooser.aspx?DocCode=20&EntryNo=" + this.doc1.EntryNo.ToString() + "&Op=" + Shmzh.MM.Common.OP.O);
                            }
                        }
                    }
                    break;
                #endregion
            }
        }

        protected void btnPresent_Click(object sender, EventArgs e)
        {
            //没有内容
            if (this.InventoryShortageDetail.Count == 0)
            {
                ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('没有物料内容!');", true);
                return;
            }
            
            //设定操作人员信息。
            this.SetOperator(this.OP);

            this.InventoryShortage.EntryState = DocStatus.Present;
            this.InventoryShortage.StoCode = this.ddlStorage.SelectedValue;
            this.InventoryShortage.StoName = this.ddlStorage.SelectedItem.Text;

            this.InventoryShortage.Remark = this.txtRemark.Text.Trim();
            using (var conn = new SqlConnection(ConnectionString.MM))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                var subTotal = this.InventoryShortageDetail.Sum(obj => obj.ItemMoney);

                this.InventoryShortage.SubTotal = subTotal;
                bool ret = false;
                if (this.OP == Shmzh.MM.Common.OP.New || this.OP == Shmzh.MM.Common.OP.Red)
                    ret = new InventoryShortages().Insert(trans, this.InventoryShortage);
                else if (this.OP == Shmzh.MM.Common.OP.Edit || this.OP == Shmzh.MM.Common.OP.Submit)
                    ret = new InventoryShortages().Update(trans, this.InventoryShortage);
                if (ret)
                {
                    var da = new InventoryShortageDetails();
                    if (this.OP == Shmzh.MM.Common.OP.Edit || this.OP == Shmzh.MM.Common.OP.Submit)
                    {
                        if (!da.Delete(trans, this.InventoryShortage.EntryNo))
                        {
                            trans.Rollback();
                            ClientScript.RegisterStartupScript( this.GetType(), "saveFailed", "alert(\"马上提交失败1！\");", true);
                            return;
                        }
                    }
                    foreach (var obj in this.InventoryShortageDetail)
                    {
                        obj.EntryNo = this.InventoryShortage.EntryNo;
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
                    if (new Shmzh.MM.DataAccess.Common.ToDoLists().Create(trans, 20, this.InventoryShortage.EntryNo, 1100, "T", Master.CurrentUser.LoginName))
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
                        this.InventoryShortageDetail.Find(
                            item =>
                            item.ItemCode.ToUpper() == this.txtItemCode.Text.ToUpper() &&
                            item.ItemName.ToUpper() == this.txtItemName.Text.ToUpper() &&
                            item.ItemSpec.ToUpper() == this.txtItemSpecial.Text.ToUpper());
                    if (obj != null)
                    {
                        ClientScript.RegisterStartupScript( this.GetType(), "Error", "alert('提醒：该物料在该单据中已经存在！');", true);
                        return;
                    }
                    else
                    {
                        obj = new InventoryShortageDetailInfo();
                        obj.EntryNo = this.EntryNo;
                        obj.SerialNo = (short)(this.InventoryShortageDetail.Count);
                        obj.ItemCode = this.txtItemCode.Text;
                        obj.ItemName = this.txtItemName.Text;
                        obj.ItemSpec = this.txtItemSpecial.Text;
                        obj.ItemUnit = short.Parse(this.ddlUnit.SelectedValue);
                        obj.ItemUnitName = this.ddlUnit.SelectedText;
                        var stocks = new Stocks().GetStockSumByStoCodeAndItem(this.ddlStorage.SelectedValue, obj.ItemCode, obj.ItemName, obj.ItemSpec);
                        if (stocks.Tables.Count > 0 && stocks.Tables[0].Rows.Count > 0)
                        {
                            obj.CurrentStockNum = decimal.Parse(stocks.Tables[0].Rows[0]["ItemNum"].ToString());
                        }

                        if (this.ddlStorage.SelectedValue == "00")//账外仓库
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
                            this.ClientScript.RegisterStartupScript(this.GetType(),"IncorrectItemNum","alert('盘亏数量不正确！');",true);
                            return;
                        }
                        if (obj.ItemNum <= 0)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘亏数量必须大于等于0！');", true);
                            return;
                        }
                        if (obj.CarryingAmount - obj.InventoryAmount != obj.ItemNum)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘亏数量必须等于账面数量减去盘点数量！');", true);
                            return;
                        }
                        obj.ItemMoney = obj.ItemPrice * obj.ItemNum;
                        
                        this.InventoryShortageDetail.Add(obj);
                    }
                }
                #endregion
                #region 更新
                else
                {
                    var currentSerialNo = short.Parse(txtItemSerial.Value);
                    var obj =
                        this.InventoryShortageDetail.Find(
                            item =>
                            item.ItemCode.ToUpper() == this.txtItemCode.Text.ToUpper() &&
                            item.ItemName.ToUpper() == this.txtItemName.Text.ToUpper() &&
                            item.ItemSpec.ToUpper() == this.txtItemSpecial.Text.ToUpper());
                    if (obj != null)
                    {
                        if (obj.SerialNo == currentSerialNo)
                        {
                            if (this.ddlStorage.SelectedValue == "00")
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
                                this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘亏数量不正确！');", true);
                                return;
                            }
                            if (obj.ItemNum <= 0)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘亏数量必须大于等于0！');", true);
                                return;
                            }
                            if (obj.CarryingAmount - obj.InventoryAmount != obj.ItemNum)
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "IncorrectItemNum", "alert('盘亏数量必须等于账面数量减去盘点数量！');", true);
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
                        obj = this.InventoryShortageDetail.Find(item => item.SerialNo == currentSerialNo);
                        if (obj != null)
                        {
                            obj.ItemCode = this.txtItemCode.Text;
                            obj.ItemName = this.txtItemNum.Text;
                            obj.ItemSpec = this.txtItemSpecial.Text;
                            obj.ItemUnit = short.Parse(this.ddlUnit.SelectedValue);
                            obj.ItemUnitName = this.ddlUnit.SelectedText;
                            if (this.ddlStorage.SelectedValue == "00")
                                obj.ItemPrice = 0;
                            else
                               obj.ItemPrice = decimal.Parse(this.txtItemPrice.Text);
                            obj.ItemNum = decimal.Parse(this.txtItemNum.Text);
                            obj.ItemMoney = obj.ItemNum * obj.ItemPrice;
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
                        }
                    }


                    txtItemSerial.Value = "-1";
                    btnAddItem.Text = "新增";
                    btnEditItem.Enabled = true;

                }
                #endregion
                #region 复位
                this.DGModel_Items1.DataSource = this.InventoryShortageDetail;
                this.DGModel_Items1.DataBind();
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtItemSpecial.Text = "";
                this.ddlUnit.SetItemSelected("-1");
                this.txtItemPrice.Text = "";

                this.txtItemNum.Text = "";
                #endregion

                this.btnDelItem.Enabled = true;
            }
        }

        protected void btnDelItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
            {
                var obj = this.InventoryShortageDetail.Find(item => item.SerialNo == short.Parse(DGModel_Items1.SelectedID));
                if (obj != null)
                {
                    this.InventoryShortageDetail.Remove(obj);
                }
                DGModel_Items1.DataSource = this.InventoryShortageDetail;
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
                    var obj = this.InventoryShortageDetail.Find(item => item.SerialNo == short.Parse(DGModel_Items1.SelectedID));

                    if (obj != null)
                    {
                        this.txtItemSerial.Value = obj.SerialNo.ToString();//顺序号。
                        this.txtItemCode.Text = obj.ItemCode;//物料编号。
                        this.txtItemName.Text = obj.ItemName;//物料名称。
                        this.txtItemSpecial.Text = obj.ItemSpec;//规格型号。
                        this.ddlUnit.SetItemSelected(obj.ItemUnit.ToString());//度量单位
                        this.txtItemPrice.Text = obj.ItemPrice.ToString();//单价。
                        this.txtItemNum.Text = obj.ItemNum.ToString();//实收数量。		
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
            
        }

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var item = e.Item.DataItem as InventoryShortageDetailInfo;
                if (item != null)
                {
                    if (item.CurrentStockNum < item.ItemNum)
                    {
                        e.Item.ForeColor = Color.Red;
                    }
                }
                if (this.InventoryShortage.ParentEntryNo > 0)
                {
                    e.Item.Cells[9].ForeColor = Color.Red;
                    e.Item.Cells[10].ForeColor = Color.Red;
                }
            }
        }
    }
}