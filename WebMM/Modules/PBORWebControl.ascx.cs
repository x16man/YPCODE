namespace MZHMM.WebMM.Modules
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;

    /// <summary>
    ///	单据上物料部分内容用户控件。
    ///	提供了，单据上物料项的增加、修改、删除、显示功能。
    /// </summary>
    public partial class PBORWebControl : System.Web.UI.UserControl
    {
        #region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public    StorageDropdownlist ddlCon ;
        //private string tmpCode;
        private string _OP;
        private string SourceEntry;
        private int _SourceEntryNo;
        private int _SourceOrderNo;
        //private int _SourceDocCode;
        private string ItemCode;

        private decimal SubTotalItemMoney = 0;

        private decimal SubTotalItemSum = 0;

        private readonly SysSystem oSys = new SysSystem();

        private readonly PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        
        private int CurrentRow;
                    

        decimal Total_ItemMoney;
        decimal Temp_ItemMoney;
        decimal Temp_ItemFee;
        decimal Temp_ItemTax;
        decimal Temp_ItemDiscount;
        decimal Temp_TotalFee;
        decimal Temp_ItemSum;

        private decimal temp_num;
        private decimal temp_price;
        private decimal temp_money;
        private decimal temp_taxrate;
        private decimal temp_tax;
        private decimal temp_all;
        private decimal temp_ItemNum;

        private ItemData oItemData = new ItemData();

        private PBSDData oPBSDData = new PBSDData();

        private DataRow dr;

        //private int i;

        private int iRow;

        private int ret;

        /// <summary>
        /// 是否显示单价
        /// </summary>
        public bool IsDisplayPBORPrice
        {
            get
            {
                if (ViewState["IsDisplayPBORPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayPBORPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayPBORPrice"] = value;
            }
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

        #region 属性
        /// <summary>
        /// DataGrid的数据源。
        /// </summary>
        public DataTable thisTable
        {
            get
            {
                if (Session[MySession.BOR_DT] != null)
                    return (DataTable)Session[MySession.BOR_DT];
                else
                {
                    this.thisTable = new DataTable();

                    DataColumnCollection columns = this.thisTable.Columns;
                    columns.Add("NewCode");
                    columns.Add("ItemCode");
                    columns.Add("ItemName");
                    columns.Add("ItemSpecial");
                    columns.Add("ItemUnit");
                    columns.Add("ItemUnitName");
                    columns.Add("SourceEntry");
                    columns.Add("BatchCode");
                    columns.Add("TaxRate");
                    columns.Add("ItemPrice");
                    columns.Add("PlanNum");
                    columns.Add("ItemNum");
                    columns.Add("ItemMoney");
                    columns.Add("ItemSum");
                    columns.Add("SourceDocCode");
                    columns.Add("SourceSerialNo");
                    columns.Add("ItemTax");
                    columns.Add("ItemFee");
                    columns.Add("TaxCode");
                    columns.Add("ConCode");
                    columns.Add("ConName");
                    return thisTable;
                }

            }	
            set
            {
                Session[MySession.BOR_DT] = value;
            }
        }
        /// <summary>
        /// 收料单的备注属性。
        /// </summary>
        public string Remark
        {
            get 
            {	
                return this.txtRemark.Text;
            }
            set 
            {
                this.txtRemark.Text = value;
            }
        }
        /// <summary>
        /// 费用。
        /// </summary>
        public decimal TotalFee
        {
            get 
            {
                try{ return Convert.ToDecimal(this.txtFee.Text);}
                catch{return 0;}
            }
            set {this.txtFee.Text = value.ToString();}
        }
        /// <summary>
        /// 仓库。
        /// </summary>
        public string StoCode
        {
            get { return this.txtStoCode.Value;}
            set { this.txtStoCode.Value = value; }
        }
        /// <summary>
        /// 是否限制采购收料的物料项。
        /// </summary>
        /// <remarks>
        /// 前台页面用。
        /// </remarks>
        public string IsBorItemLimitString
        {
            get 
            {	
                
                if (oSys.IsBorItemLimit())
                {
                    return "Disabled";
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 是否限制采购收料的物料项。
        /// </summary>
        public bool IsBorItemLimit
        {
            get
            {
                return oSys.IsBorItemLimit();
            }
        }
        /// <summary>
        /// 是否限制采购收料数量的限制。
        /// </summary>
        public bool IsBorNumLimit
        {
            get
            {
                return oSys.IsBorNumLimit();
                //Session.SessionID
            }
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
        #endregion

        #region 私有方法
        /// <summary>
        /// 在静态表中检查该物料是否已经存在。
        /// </summary>
        /// <param name="strItemCode">string:	要检查的物料编号。</param>
        /// <param name="ItemName"></param>
        /// <param name="ItemSpec"></param>
        /// <param name="iTableRow"></param>
        /// <returns>int:	没有返回-1，有则返回所在行的行数。</returns>
        private int GetRowByItemCode(string strItemCode, string ItemName, string ItemSpec,int iTableRow)
        {
            ret = -1;
            for (var i = 0; i < this.thisTable.Rows.Count; i++)
            {
                if(this.thisTable.Rows[i][BillOfReceiveData.SOURCEENTRY_FIELD].ToString()=="-1"
                    &&this.thisTable.Rows[i][BillOfReceiveData.SOURCEDOCCODE_FIELD].ToString()=="-1"
                    &&this.thisTable.Rows[i][BillOfReceiveData.SOURCESERIALNO_FIELD].ToString()=="-1")//手工添加的数据
                {
                    if (strItemCode != "-1")//非OTI物料。
                    {
                        if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == strItemCode)
                                return i;
                    }
                    else//OTI物料的编号都为-1，所以要进行物料名称和规格型号的判断。
                    {
    //					for (int i=0; i < dt.Rows.Count; i++)
    //					{
                            if (this.thisTable.Rows[i][InItemData.ITEMNAME_FIELD].ToString() == ItemName &&
                                this.thisTable.Rows[i][InItemData.ITEMSPECIAL_FIELD].ToString() == ItemSpec)
                            {
                                return i;
                            }
    //					}							  
                    }
                }
                else
                {
                    ret = iTableRow;
                }
            }
            return ret;
            
        }
        /// <summary>
        /// 根据数据源获取行号。
        /// </summary>
        /// <param name="entryNo">string:	单据流水号。</param>
        /// <param name="DocCode">string:	单据类型编号。</param>
        /// <param name="SerialNo">string:	顺序号。</param>
        /// <returns>int:	匹配的行号。</returns>
        private int GetRowBySource(string entryNo, string DocCode, string SerialNo)
        {
            for (var i = 0; i < this.thisTable.Rows.Count; i++)
            {
                if (this.thisTable.Rows[i][BillOfReceiveData.SOURCEENTRY_FIELD].ToString() == entryNo
                    && this.thisTable.Rows[i][BillOfReceiveData.SOURCEDOCCODE_FIELD].ToString() == DocCode
                    && this.thisTable.Rows[i][BillOfReceiveData.SOURCESERIALNO_FIELD].ToString() == SerialNo)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 对数据进行校验.
        /// </summary>
        /// <returns>bool:	校验通过返回true，失败返回false。</returns>
        private bool DoCheck()
        {
            var retValue=true;
            try
            {
                //if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtReqNum.Text!="") && (ddlUnit.SelectedValue!="-1"))
                if ((txtItemCode.Text != "") && (txtItemName.Text != "") && (txtReqNum.Text != "") && (ddlUnit.SelectedValue != "-1"))
                {
                    var tmpDecimal=decimal.Parse(txtReqNum.Text);
                }
                else
                {
                    Page.RegisterStartupScript("DoCheck", "<script>alert(\"物料编号、物料名称、单位、申请数量不能为空！\");</script>");
                    retValue=false;
                }
            }
            catch(Exception )
            {
                Page.RegisterStartupScript( "DoCheck", "<script>alert(\"申请数量应为数字型！\");</script>");
                retValue=false;
            }
            return retValue;
        }
        /// <summary>
        /// 根据不同操作模式，设定编辑区域的显示方式。
        /// </summary>
        /// <param name="OpMode">string:	操作模式。</param>
        private void SetEditMode(string OpMode)
        {
            if(!Page.IsPostBack)
            {
                switch (OpMode)
                {
                    case OP.FirstAudit:
                        #region 一级审批
                        this.txtItemCode.Visible = true;
                        this.txtItemCode.Enabled = true;
                        this.txtItemCode.ReadOnly = false;
                        this.txtItemName.Visible = true;
                        this.txtItemName.Enabled = true;
                        this.txtItemName.ReadOnly = false;
                        this.txtFee.Visible = true;
                        this.txtFee.Enabled = true;
                        this.txtFee.ReadOnly = true;
                        this.txtItemSpecial.Visible = true;
                        this.txtItemSpecial.Enabled = true;
                        this.txtItemSpecial.ReadOnly = false;
                        this.ddlUnit.Visible = true;
                        this.ddlUnit.Enable = true;
                        //this.lblUnit.Visible=true; //20080418 物料单位名称
                        this.txtBatchCode.Visible = true;
                        this.txtBatchCode.Enabled = true;
                        this.txtBatchCode.ReadOnly = false;
                        this.txtItemPrice.Visible = true;
                        this.txtItemPrice.Enabled = true;
                        this.txtItemPrice.ReadOnly = false;
                        this.txtReqNum.Visible = true;
                        this.txtReqNum.Enabled = true;
                        this.txtReqNum.ReadOnly = false;
                    
                        this.txtItemNum.Visible = false;
                        this.txtRemark.Enabled = true;
                        this.txtRemark.Visible = true;
                        this.txtRemark.ReadOnly = true;
                        this.ddlCon.Visible = false;
                        this.btnAddItem.Enabled = false;
                        this.btnDelItem.Enabled = false;
                        this.btnEditItem.Enabled = false;

                        //tc_ItemName.Attributes.Add("class","tc_ItemName");
                        //tc_ItemSpecial.Attributes.Add("class","tc_ItemSpecial");
                        //tc_ConName.Attributes.Add("class","tc_ConName");
                        break;
                        #endregion
                    case OP.SecondAudit:
                        #region 二级审批
                        this.txtItemCode.Visible = true;
                        this.txtItemCode.Enabled = true;
                        this.txtItemCode.ReadOnly = false;
                        this.txtItemName.Visible = true;
                        this.txtItemName.Enabled = true;
                        this.txtItemName.ReadOnly = false;
                        this.txtFee.Visible = true;
                        this.txtFee.Enabled = true;
                        this.txtFee.ReadOnly = false;
                        this.txtItemSpecial.Visible = true;
                        this.txtItemSpecial.Enabled = true;
                        this.txtItemSpecial.ReadOnly = false;
                        this.ddlUnit.Visible = true;
                        this.ddlUnit.Enable = true;
                        //this.lblUnit.Visible=true; //20080418 物料单位名称
                      
                        this.txtBatchCode.Visible = true;
                        this.txtBatchCode.Enabled = true;
                        this.txtBatchCode.ReadOnly = false;
                        this.txtItemPrice.Visible = true;
                        this.txtItemPrice.Enabled = true;
                        this.txtItemPrice.ReadOnly = false;
                        this.txtReqNum.Visible = true;
                        this.txtReqNum.Enabled = true;
                        this.txtReqNum.ReadOnly = true;
                    
                        this.txtItemNum.Visible = false;
                        this.txtRemark.Enabled = true;
                        this.txtRemark.Visible = true;
                        this.txtRemark.ReadOnly = true;
                        this.ddlCon.Visible = false;
                        this.btnAddItem.Enabled = false;
                        this.btnDelItem.Enabled = false;
                        this.btnEditItem.Enabled = false;

                        //tc_ItemName.Attributes.Add("class","tc_ItemName");
                        //tc_ItemSpecial.Attributes.Add("class","tc_ItemSpecial");
                        //tc_ConName.Attributes.Add("class","tc_ConName");
                        break;
                        #endregion
                    case OP.ThirdAudit:
                        #region 三级审批
                        this.txtItemCode.Visible = true;
                        this.txtItemCode.Enabled = true;
                        this.txtItemCode.ReadOnly = false;
                        this.txtItemName.Visible = true;
                        this.txtItemName.Enabled = true;
                        this.txtItemName.ReadOnly = false;
                        this.txtFee.Visible = true;
                        this.txtFee.Enabled = true;
                        this.txtFee.ReadOnly = true;
                        this.txtItemSpecial.Visible = true;
                        this.txtItemSpecial.Enabled = true;
                        this.txtItemSpecial.ReadOnly = false;
                        this.ddlUnit.Visible = true;
                        this.ddlUnit.Enable = true;
                        //this.lblUnit.Visible=true; //20080418 物料单位名称
                        this.txtBatchCode.Visible = true;
                        this.txtBatchCode.Enabled = true;
                        this.txtBatchCode.ReadOnly = false;
                        this.txtItemPrice.Visible = true;
                        this.txtItemPrice.Enabled = true;
                        this.txtItemPrice.ReadOnly = false;
                        this.txtReqNum.Visible = true;
                        this.txtReqNum.Enabled = true;
                        this.txtReqNum.ReadOnly = false;
                    
                        this.txtItemNum.Visible = false;
                        this.txtRemark.Enabled = true;
                        this.txtRemark.Visible = true;
                        this.txtRemark.ReadOnly = true;
                        this.ddlCon.Visible = false;
                        this.btnAddItem.Enabled = false;
                        this.btnDelItem.Enabled = false;
                        this.btnEditItem.Enabled = false;

                        //tc_ItemName.Attributes.Add("class","tc_ItemName");
                        //tc_ItemSpecial.Attributes.Add("class","tc_ItemSpecial");
                        //tc_ConName.Attributes.Add("class","tc_ConName");
                        break;
                        #endregion
                    case OP.I:
                        #region 收料
                        this.txtItemCode.Visible = true;
                        this.txtItemCode.ReadOnly = true;
                        this.txtItemName.Visible = true;
                        this.txtItemName.ReadOnly = true;
                        this.txtFee.Visible = true;
                        this.txtFee.Enabled = true;
                        this.txtFee.ReadOnly = true;
                        this.txtItemSpecial.Visible = true;
                        this.txtItemSpecial.ReadOnly = true;
                        this.ddlUnit.Visible = true;
                        this.ddlUnit.Enable = false;
                        //this.lblUnit.Visible=true; //20080418 物料单位名称
                        this.txtBatchCode.Visible = true;
                        this.txtBatchCode.ReadOnly = true;
                        this.txtItemPrice.Visible = false;
                        this.txtReqNum.Visible = false;
                    
                        this.txtItemNum.Visible = true;
                        this.txtItemNum.Enabled = true;
                        this.txtRemark.Visible = true;
                        this.txtRemark.Enabled = true;
                        this.txtRemark.ReadOnly = true;
                        this.ddlCon.Visible = true;
                        this.ddlCon.Enable = true;
                        this.btnAddItem.Enabled = false;
                        this.btnDelItem.Enabled = false;
                        this.btnEditItem.Enabled = true;

                        //tc_ItemName.Attributes.Add("class","tc_ItemNameBorR");
                        //tc_ItemSpecial.Attributes.Add("class","tc_ItemSpecialBorR");
                        //tc_ConName.Attributes.Add("class","tc_ConNameBorR");
                        break;
                        #endregion
                    default:
                        #region 默认
                        this.txtItemCode.Visible = true;
                        this.txtItemCode.Enabled = true;
                        this.txtItemCode.ReadOnly = this.IsBorItemLimit;
                        this.txtItemName.Visible = true;
                        this.txtItemName.Enabled = true;
                        this.txtItemName.ReadOnly = this.IsBorItemLimit;
                        this.txtFee.Visible = true;
                        this.txtFee.Enabled = true;
                        this.txtFee.ReadOnly = false;
                        this.txtItemSpecial.Visible = true;
                        this.txtItemSpecial.Enabled = true;
                        this.txtItemSpecial.ReadOnly = this.IsBorItemLimit;
                        this.ddlUnit.Visible = true;
                        this.ddlUnit.Enable = !this.IsBorItemLimit;
                        //this.lblUnit.Visible=true; //20080418 物料单位名称
                        this.txtBatchCode.Visible = true;
                        this.txtBatchCode.Enabled = true;
                        this.txtBatchCode.ReadOnly = false;
                        this.txtItemPrice.Visible = true;
                        this.txtItemPrice.Enabled = true;
                        this.txtItemPrice.ReadOnly = false;
                        this.txtReqNum.Visible = true;
                        this.txtReqNum.Enabled = true;
                        this.txtReqNum.ReadOnly = false;
                        this.txtItemNum.Visible = false;
                        this.txtRemark.Enabled = true;
                        this.txtRemark.Visible = true;
                        this.txtRemark.ReadOnly = false;
                        this.ddlCon.Visible = false;
                        this.btnAddItem.Enabled = true;
                        this.btnDelItem.Enabled = true;
                        this.btnEditItem.Enabled = true;

                        //tc_ItemName.Attributes.Add("class","tc_ItemName");
                        //tc_ItemSpecial.Attributes.Add("class","tc_ItemSpecial");
                        //tc_ConName.Attributes.Add("class","tc_ConName");
                        break;
                        #endregion
                }
            }
        }
        /// <summary>
        ///费用分摊。 
        /// </summary>
        /// <param name="Total_Fee">decimal:	费用金额。</param>
        private void DistributeFee(decimal Total_Fee)
        {
            Total_ItemMoney = 0;
            Temp_TotalFee = 0;
            Temp_ItemTax =0;
            Temp_ItemDiscount = 0;
            Temp_ItemSum = 0;
            //总的物料金额。
            for (var i=0; i< this.thisTable.Rows.Count; i++)
            {
                try{	Temp_ItemMoney = Convert.ToDecimal(this.thisTable.Rows[i][InItemData.ITEMMONEY_FIELD].ToString());	}
                catch {	Temp_ItemMoney = 0;}
                Total_ItemMoney += Temp_ItemMoney;
            }
            //费用。
            for (var i=0; i< this.thisTable.Rows.Count; i++)
            {
                try{	
                    Temp_ItemMoney = Convert.ToDecimal(this.thisTable.Rows[i][InItemData.ITEMMONEY_FIELD].ToString());
                    Temp_ItemFee = Math.Round(Total_Fee * Temp_ItemMoney / Total_ItemMoney, 2);
                }
                catch { Temp_ItemMoney = 0; Temp_ItemFee = 0; }
                
                this.thisTable.Rows[i][BillOfReceiveData.ITEMFEE_FIELD] = Temp_ItemFee;
            }
            //总的费用。
            for (var i=0; i< this.thisTable.Rows.Count; i++)
            {
                try{	Temp_ItemFee = Convert.ToDecimal(this.thisTable.Rows[i][BillOfReceiveData.ITEMFEE_FIELD].ToString());	}
                catch {	Temp_ItemFee = 0;}
                Temp_TotalFee += Temp_ItemFee;
            }
            //分摊完所有费用。
            if (this.thisTable.Rows.Count > 0)
            {
                try{	Temp_ItemFee = Convert.ToDecimal(this.thisTable.Rows[0][BillOfReceiveData.ITEMFEE_FIELD].ToString());	}
                catch {	Temp_ItemFee = 0;}
                Temp_ItemFee += TotalFee - Temp_TotalFee;
                this.thisTable.Rows[0][BillOfReceiveData.ITEMFEE_FIELD] = Temp_ItemFee;
            }
            //重新计算总的金额。
            for (var i = 0; i< this.thisTable.Rows.Count; i++)
            {
                try{	Temp_ItemMoney = Convert.ToDecimal(this.thisTable.Rows[i][InItemData.ITEMMONEY_FIELD].ToString());	}
                catch{	Temp_ItemMoney = 0;	}
                try{	Temp_ItemFee = Convert.ToDecimal(this.thisTable.Rows[i][BillOfReceiveData.ITEMFEE_FIELD].ToString());	}
                catch{	Temp_ItemFee = 0;	}
                try{	Temp_ItemTax = Convert.ToDecimal(this.thisTable.Rows[i][BillOfReceiveData.ITEMTAX_FIELD].ToString());	}
                catch{	Temp_ItemTax =0;	}
                try{	Temp_ItemDiscount = Convert.ToDecimal(this.thisTable.Rows[i][BillOfReceiveData.ITEMDISCOUNT_FIELD].ToString());	}
                catch{	Temp_ItemDiscount = 0;	}
                Temp_ItemSum = Temp_ItemMoney + Temp_ItemFee + Temp_ItemTax + Temp_ItemDiscount;
                this.thisTable.Rows[i][BillOfReceiveData.ITEMSUM_FIELD] = Temp_ItemSum.ToString("F3");
            }
        }
        /// <summary>
        /// 根据是否要限制物料项以及物料数量来控制界面层元素。
        /// </summary>
        private void SetLimitLayout()
        {
            this.btnForItemCode.Enabled = !this.IsBorItemLimit;
        }
        /// <summary>
        /// 获取行序号。
        /// </summary>
        /// <param name="strSelectId">选中行的Id。</param>
        /// <returns></returns>
        private int GetRowIndex(string strSelectId)
        {
            string[] strvalue = strSelectId.Split(';');
            for (var i = 0; i < thisTable.Rows.Count; i++)
            {
                if (strvalue[0] == this.thisTable.Rows[i]["ItemCode"].ToString() &&
                    strvalue[1] == this.thisTable.Rows[i]["SourceEntry"].ToString() &&
                    strvalue[2] == this.thisTable.Rows[i]["SourceSerialNo"].ToString())
                {
                    return i;
                }
            }

            return -1;
        }
        
        #endregion
        
        #region 事件
        /// <summary>
        /// 页面Load事件。
        /// </summary>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (!string.IsNullOrEmpty(Request["Op"]))
            {
                this._OP = this.Request["Op"];
            }
            //模式设定。
            this.SetLimitLayout();
            this.SetEditMode(this._OP);//设定编辑区域的显示模式。

            this.txtItemPrice.Visible = IsDisplayPBORPrice;

            if (!this.IsPostBack)
            {
                //度量单位
                ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
            }
            switch (this._OP)
            {
                    #region 新增
                case OP.New:
                    //DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
                    if (!this.IsPostBack)
                    {
                        //定义表和数据结构
                        if(this.thisTable!=null) 
                            this.thisTable = null;
                        this.thisTable = (new BillOfReceiveData()).Tables[BillOfReceiveData.PBOR_TABLE];
                        DGModel_Items1.DataSource=this.thisTable;//数据源绑定。
                        DGModel_Items1.DataBind();
                        ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;//度量单位
                    }
                    else
                    {
                        DGModel_Items1.DataSource=this.thisTable;//数据源绑定。
                        DGModel_Items1.DataBind();
                    }
                    break;
                    #endregion
                    #region 由批量进货单生成收料单。
                case OP.Bor:
                    //DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
                    this.SourceEntry = this.Request["EntryNo"];
                    this._SourceEntryNo = int.Parse(this.SourceEntry.Split('|')[0]);
                    //this._SourceDocCode = int.Parse(this.SourceEntry.Split('|')[1]);

                    if (!this.IsPostBack)
                    {
                        if (this.thisTable != null) 
                            this.thisTable = null;
                        this.thisTable = (new BillOfReceiveData()).Tables[BillOfReceiveData.PBOR_TABLE];
                        PBRBData oPBRBData = new PurchaseSystem().GetPBRBByEntryNo(this._SourceEntryNo);
                        ItemCode = new SysSystem().GetSTAGInfo().ItemCode;
                        this._SourceOrderNo = int.Parse(oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.ORDERNO_FIELD].ToString());
                        PurchaseOrderData oPOData = new PurchaseSystem().GetPOByEntryNo(this._SourceOrderNo, ItemCode);

                        DataRow oDR = this.thisTable.NewRow();
                        oDR[BillOfReceiveData.SOURCEENTRY_FIELD] = this._SourceOrderNo;
                        oDR[BillOfReceiveData.SOURCEDOCCODE_FIELD] = DocType.PO;
                        oDR[BillOfReceiveData.SOURCESERIALNO_FIELD] = int.Parse(oPOData.Tables[PurchaseOrderData.PORD_TABLE].Rows[0][InItemData.SERIALNO_FIELD].ToString());
                        oDR[InItemData.ITEMCODE_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMCODE_FIELD];
                        oDR[InItemData.ITEMNAME_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMNAME_FIELD];
                        oDR[InItemData.ITEMSPECIAL_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMSPECIAL_FIELD];
                        oDR[InItemData.ITEMUNIT_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMUNIT_FIELD];
                        oDR[InItemData.ITEMUNITNAME_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][InItemData.ITEMUNITNAME_FIELD];
                        
                        oDR[BillOfReceiveData.BATCHCODE_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.BATCHCODE_FIELD];
                        oDR[BillOfReceiveData.PLANNUM_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.AMOUNTTO_FIELD];
                        oDR[BillOfReceiveData.CONCODE_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.CONCODE_FIELD];
                        oDR[BillOfReceiveData.CONNAME_FIELD] = oPBRBData.Tables[PBRBData.PBRB_TABLE].Rows[0][PBRBData.CONNAME_FIELD];
                        this.thisTable.Rows.Add(oDR);
                        
                        DGModel_Items1.DataSource = this.thisTable;//数据源绑定。
                        DGModel_Items1.DataBind();
                        ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;//度量单位
                    }
                    else
                    {
                        DGModel_Items1.DataSource = this.thisTable;//数据源绑定。
                        DGModel_Items1.DataBind();
                    }
                    break;
                    #endregion
                    #region 编辑
                case OP.Edit:
                    //DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
                    this.SetEditMode(this._OP);
                    
                    DGModel_Items1.DataSource=this.thisTable;				
                    DGModel_Items1.DataBind();
                    //tmpCode=DGModel_Items1.SelectedID;
                    break;
                    #endregion
                    #region 提交
                case OP.Submit:
                    //DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
                    this.SetEditMode(this._OP);
                    
                    DGModel_Items1.DataSource=this.thisTable;				
                    DGModel_Items1.DataBind();
                    //tmpCode=DGModel_Items1.SelectedID;
                    break;
                    #endregion
                    #region 一级审批
                case OP.FirstAudit:
                    //DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
                    
                    DGModel_Items1.DataSource=this.thisTable;				
                    DGModel_Items1.DataBind();
                    //tmpCode=DGModel_Items1.SelectedID;
                    break;
                    #endregion
                    #region 二级审批
                case OP.SecondAudit:
                    //DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
                    if(!this.IsPostBack)
                    {
                        //度量单位
                        ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
                    }
                    DGModel_Items1.DataSource=this.thisTable;				
                    DGModel_Items1.DataBind();
                    //tmpCode=DGModel_Items1.SelectedID;
                    break;
                    #endregion
                    #region 三级审批
                case OP.ThirdAudit:
                    //DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
                    
                    DGModel_Items1.DataSource=this.thisTable;				
                    DGModel_Items1.DataBind();
                    //tmpCode=DGModel_Items1.SelectedID;
                    break;
                    #endregion
                    #region 收料
                case OP.I:
                    //this.DGModel_Items1.ColumnsScheme = ColumnScheme.BORRECEIVE;
                    this.btnAddItem.Enabled = this.btnAddItem.Text != "新增";
                    if (!this.IsPostBack)
                    {
                        //度量单位
                        //this.ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
                        this.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
                    }
                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                    //tmpCode=DGModel_Items1.SelectedID;
                    break;
                    #endregion
                    #region 红字
                case OP.Red:
                    //DGModel_Items1.ColumnsScheme = ColumnScheme.BOR;
                    //this.SetEditMode(this._OP);
                    
                    DGModel_Items1.DataSource=this.thisTable;				
                    DGModel_Items1.DataBind();
                    //tmpCode=DGModel_Items1.SelectedID;
                    try
                    {
                        this.TotalFee = -decimal.Parse(this.thisTable.Rows[0]["TotalFee"].ToString());
                    }
                    catch
                    {
                        this.TotalFee = 0;
                    }
                    break;
                    #endregion
            }

            if (OperateRed)
            {
                this.btnAddItem.Enabled = false;
                this.btnEditItem.Enabled = false;
                this.btnDelItem.Enabled = false;
                txtFee.Attributes.Add("ReadOnly", "ReadOnly");
                txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            //
            //添加一行数据并且赋值
            //
            if (DoCheck())
            {
               
                if (this.txtItemCode.Text.Substring(0, 2) != this.StoCode)
                {
                   // this.Response.Write("<script>alert('提醒：当前仓库与物料编号不匹配！');</script>");
                    Page.RegisterStartupScript("Error", "<script>alert('提醒：当前仓库与物料编号不匹配!');</script>");
                    //return;
                }
                #region 新增
                if (btnAddItem.Text == "新增")
                {
                    CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text, -1);


                    if (CurrentRow == -1)//静态表中没有过该物料。
                    {
                        dr = this.thisTable.NewRow();
                        dr[InItemData.NEWCODE_FIELD] = this.hfNewCode.Value;
                        dr[InItemData.ITEMCODE_FIELD] = this.txtItemCode.Text;
                        dr[InItemData.ITEMNAME_FIELD] = this.txtItemName.Text;
                        dr[InItemData.ITEMSPECIAL_FIELD] = this.txtItemSpecial.Text;
                        dr[InItemData.ITEMUNIT_FIELD] = this.ddlUnit.SelectedValue;
                        dr[InItemData.ITEMUNITNAME_FIELD] = this.ddlUnit.SelectedText;
                        dr[InItemData.ITEMPRICE_FIELD] = this.txtItemPrice.Text;
                        dr[BillOfReceiveData.BATCHCODE_FIELD] = this.txtBatchCode.Text;
                        dr[BillOfReceiveData.PLANNUM_FIELD] = this.txtReqNum.Text;
                        dr[BillOfReceiveData.TAXRATE_FIELD] = "0";
                        dr[BillOfReceiveData.SOURCEENTRY_FIELD] = "-1";
                        dr[BillOfReceiveData.SOURCEDOCCODE_FIELD] = "-1";
                        dr[BillOfReceiveData.SOURCESERIALNO_FIELD] = "-1";
                        //金额
                        try { temp_num = Convert.ToDecimal(this.txtReqNum.Text); }
                        catch { temp_num = 0; }
                        try { temp_ItemNum = Convert.ToDecimal(this.txtItemNum.Text); }
                        catch { temp_ItemNum = 0; }
                        temp_price = decimal.Parse(this.txtItemPrice.Text);
                        temp_taxrate = 0;
                        temp_money = this._OP == OP.I ? Math.Round(temp_ItemNum * temp_price, 2) : Math.Round(temp_num * temp_price, 2);
                        temp_tax = Math.Round((temp_money * temp_taxrate), 2);
                        temp_all = Math.Round((temp_money + temp_tax), 2);

                        dr["ItemMoney"] = temp_money.ToString();
                        dr["ItemTax"] = temp_tax.ToString();
                        dr["ItemSum"] = temp_all.ToString();

                        this.thisTable.Rows.Add(dr);
                    }
                    else//静态表中已经存在该物料。
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_taxrate = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["TaxRate"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        temp_tax = Math.Round((temp_money * temp_taxrate), 2);
                        temp_all = Math.Round((temp_money + temp_tax), 2);
                        this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                        this.thisTable.Rows[CurrentRow]["ItemTax"] = temp_tax;
                        this.thisTable.Rows[CurrentRow]["ItemSum"] = temp_all;
                    }
                    //分摊费用。
                    this.DistributeFee(this.TotalFee);
                }
                #endregion
                #region 更新
                else
                {
                    iRow = int.Parse(txtItemSerial.Value);
                    dr = this.thisTable.Rows[iRow];
                    CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text, iRow);
                    if (CurrentRow == iRow || CurrentRow == -1)//没有重复物料。
                    {
                        dr["NewCode"] = hfNewCode.Value;
                        dr["ItemCode"] = txtItemCode.Text;
                        dr["ItemName"] = txtItemName.Text;
                        dr["ItemSpecial"] = txtItemSpecial.Text;
                        dr["ItemUnit"] = ddlUnit.SelectedValue;
                        dr["ItemUnitName"] = ddlUnit.SelectedText;
                        dr[BillOfReceiveData.BATCHCODE_FIELD] = this.txtBatchCode.Text;
                        dr[InItemData.ITEMPRICE_FIELD] = this.txtItemPrice.Text;
                        dr[BillOfReceiveData.PLANNUM_FIELD] = this.txtReqNum.Text;
                        dr[BillOfReceiveData.TAXRATE_FIELD] = 0;
                        dr[InItemData.ITEMNUM_FIELD] = this.txtItemNum.Text;
                        dr[BillOfReceiveData.CONCODE_FIELD] = this.ddlCon.SelectedValue;
                        dr[BillOfReceiveData.CONNAME_FIELD] = this.ddlCon.SelectedText;
                        if (this._OP == OP.I)//收料模式。
                        {
                            temp_num = decimal.Parse(this.txtItemNum.Text);
                            dr["ConCode"] = ddlCon.SelectedValue;
                            dr["ConName"] = ddlCon.SelectedText;
                        }
                        else
                        {
                            temp_num = decimal.Parse(this.txtReqNum.Text);
                        }
                        temp_price = decimal.Parse(this.txtItemPrice.Text);
                        temp_taxrate = 0;
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        temp_tax = Math.Round((temp_money * temp_taxrate), 2);
                        temp_all = Math.Round((temp_money + temp_tax), 2);

                        dr["ItemMoney"] = temp_money.ToString("0.##");
                        dr["ItemTax"] = temp_tax.ToString("0.##");
                        dr["ItemSum"] = temp_all.ToString("0.##");
                    }
                    else//修改后有重复物料，这种情况只会出现在对OTI物料的修改。
                    {
                        if (this._OP == OP.I)//收料模式。
                        {
                            temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(this.txtItemNum.Text);
                        }
                        else
                        {
                            temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(this.txtReqNum.Text);
                        }
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_taxrate = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["TaxRate"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        temp_tax = Math.Round((temp_money * temp_taxrate), 2);
                        temp_all = Math.Round((temp_money + temp_tax), 2);

                        this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                        this.thisTable.Rows[CurrentRow]["ItemTax"] = temp_tax;
                        this.thisTable.Rows[CurrentRow]["ItemSum"] = temp_all;
                        this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//删除原有行。
                    }
                    txtItemSerial.Value = "-1";
                    btnAddItem.Text = "新增";
                    btnEditItem.Enabled = true;
                    //btnAddItem.Enabled = false;
                    //分摊费用。
                    this.DistributeFee(this.TotalFee);
                }
                #endregion
                #region 复位
                this.DGModel_Items1.DataSource = this.thisTable;
                this.DGModel_Items1.DataBind();
                this.hfNewCode.Value = string.Empty;
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtItemSpecial.Text = "";
                this.txtReqNum.Text = "";
                this.ddlUnit.SetItemSelected("-1");
                this.txtItemPrice.Text = "";

                this.txtBatchCode.Text = "";
                this.txtItemNum.Text = "";
                this.ddlCon.SetItemSelected("-1");
                #endregion
                //分摊费用。
                this.DistributeFee(this.TotalFee);
                this.btnDelItem.Enabled = true;
            }
        }

        protected void btnDelItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
            {
                iRow = GetRowIndex(DGModel_Items1.SelectedID);

                if(iRow > -1)
                    this.thisTable.Rows.RemoveAt(iRow);

                DGModel_Items1.DataSource = this.thisTable;
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
                    iRow = GetRowIndex(DGModel_Items1.SelectedID);

                    if (iRow > -1)
                    {
                        this.txtItemSerial.Value = iRow.ToString();//顺序号。
                        this.hfNewCode.Value = this.thisTable.Rows[iRow][InItemData.NEWCODE_FIELD].ToString();//新编号。
                        this.txtItemCode.Text = this.thisTable.Rows[iRow][InItemData.ITEMCODE_FIELD].ToString();//物料编号。
                        this.txtItemName.Text = this.thisTable.Rows[iRow][InItemData.ITEMNAME_FIELD].ToString();//物料名称。
                        this.txtItemSpecial.Text = this.thisTable.Rows[iRow][InItemData.ITEMSPECIAL_FIELD].ToString();//规格型号。
                        this.ddlUnit.SetItemSelected(this.thisTable.Rows[iRow][InItemData.ITEMUNIT_FIELD].ToString());//度量单位
                        this.txtBatchCode.Text = this.thisTable.Rows[iRow][BillOfReceiveData.BATCHCODE_FIELD].ToString();//批号。
                        this.txtItemPrice.Text = this.thisTable.Rows[iRow][InItemData.ITEMPRICE_FIELD].ToString();//单价。
                        this.txtReqNum.Text = this.thisTable.Rows[iRow][BillOfReceiveData.PLANNUM_FIELD].ToString();//应收数量。

                        this.txtItemNum.Text = this.thisTable.Rows[iRow][InItemData.ITEMNUM_FIELD].ToString();//实收数量。				
                        this.ddlCon.SetItemSelected(this.thisTable.Rows[iRow][BillOfReceiveData.CONCODE_FIELD].ToString());//架位

                        btnAddItem.Text = "更新";
                        btnAddItem.Enabled = true;
                        btnEditItem.Enabled = false;
                    }
                }
            }
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
                    //
                    //需要从物料数据库中获取
                    //

                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    //存在物料数据
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        hfNewCode.Value = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.NEWCODE_FIELD].ToString();
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
                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

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

        protected void bntForEntryNo_Click(object sender, EventArgs e)
        {
            if (txtEntryNo.Value != "")
            {
                if (txtEntryNo.Value != "-1")
                {

                    oPBSDData = (new PurchaseSystem()).GetPBSDByList(txtEntryNo.Value);

                    for (var i = 0; i < oPBSDData.Tables[PBSDData.PBSD_VIEW].Rows.Count; i++)
                    {
                        dr = oPBSDData.Tables[PBSDData.PBSD_VIEW].Rows[i];
                        //判断该项是否存在。
                        CurrentRow = this.GetRowBySource(dr[InItemData.ENTRYNO_FIELD].ToString(), dr[DocBaseData.DOCCODE_FIELD].ToString(), dr[InItemData.SERIALNO_FIELD].ToString());
                        if (CurrentRow == -1)//如果不存在。
                        {
                            DataRow NewDr = this.thisTable.NewRow();
                            NewDr[BillOfReceiveData.SOURCEENTRY_FIELD] = dr[InItemData.ENTRYNO_FIELD];
                            NewDr[BillOfReceiveData.SOURCEDOCCODE_FIELD] = dr[DocBaseData.DOCCODE_FIELD];
                            NewDr[BillOfReceiveData.SOURCESERIALNO_FIELD] = dr[InItemData.SERIALNO_FIELD];
                            NewDr[InItemData.NEWCODE_FIELD] = dr[InItemData.NEWCODE_FIELD];
                            NewDr[InItemData.ITEMCODE_FIELD] = dr[InItemData.ITEMCODE_FIELD];
                            NewDr[InItemData.ITEMNAME_FIELD] = dr[InItemData.ITEMNAME_FIELD];
                            NewDr[InItemData.ITEMSPECIAL_FIELD] = dr[InItemData.ITEMSPECIAL_FIELD];
                            NewDr[InItemData.ITEMUNIT_FIELD] = dr[InItemData.ITEMUNIT_FIELD];
                            NewDr[InItemData.ITEMUNITNAME_FIELD] = dr[InItemData.ITEMUNITNAME_FIELD];
                            NewDr[BillOfReceiveData.BATCHCODE_FIELD] = dr[BillOfReceiveData.BATCHCODE_FIELD];
                            NewDr[InItemData.ITEMPRICE_FIELD] = dr[InItemData.ITEMPRICE_FIELD];
                            //NewDr[InItemData.ITEMNUM_FIELD] = dr[InItemData.ITEMNUM_FIELD];
                            NewDr[BillOfReceiveData.PLANNUM_FIELD] = dr[BillOfReceiveData.PLANNUM_FIELD];		//应收数量。
                            NewDr[BillOfReceiveData.TAXCODE_FIELD] = dr[BillOfReceiveData.TAXCODE_FIELD];		//税码。
                            NewDr[BillOfReceiveData.TAXRATE_FIELD] = dr[BillOfReceiveData.TAXRATE_FIELD];		//税率。
                            NewDr[InItemData.ITEMMONEY_FIELD] = dr[InItemData.ITEMMONEY_FIELD];					//金额。
                            NewDr[BillOfReceiveData.ITEMTAX_FIELD] = dr[BillOfReceiveData.ITEMTAX_FIELD];		//税额。
                            NewDr[BillOfReceiveData.ITEMSUM_FIELD] = dr[BillOfReceiveData.ITEMSUM_FIELD];		//单项总金额。

                            this.thisTable.Rows.Add(NewDr);
                        }
                    }

                    DistributeFee(this.TotalFee);

                }
            }
            DGModel_Items1.DataSource = this.thisTable;
            DGModel_Items1.DataBind();
        }

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Header:
                    SubTotalItemMoney = 0;
                    SubTotalItemSum = 0;
                    e.Item.Cells[11].Visible = e.Item.Cells[8].Visible = this._OP == OP.I;//架位=实收数=收料模式的时候。
                    e.Item.Cells[7].Visible = IsDisplayPBORPrice;//单价
                    e.Item.Cells[9].Visible = IsDisplayPBORPrice;//金额
                    e.Item.Cells[10].Visible = IsDisplayPBORPrice;//总金额
                    break;
                case ListItemType.AlternatingItem:
                case ListItemType.Item:
                    try
                    {
                        e.Item.Cells[14].Text = oPurchaseSystem.GetPO_ReqReasonCode(int.Parse(e.Item.Cells[12].Text), int.Parse(e.Item.Cells[13].Text));
                    }
                    catch(Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                    }
                    e.Item.Attributes.Add("id", e.Item.Cells[0].Text + ";" + e.Item.Cells[12].Text + ";" + e.Item.Cells[13].Text);
                    e.Item.Cells[11].Visible = e.Item.Cells[8].Visible = this._OP == OP.I;//架位=实收数=收料模式的时候。
                    e.Item.Attributes.Add("ondblclick", string.Format("window.open('../Analysis/DocRoute.aspx?EntryNo={0}&DocCode=6&SerialNo={1}&ItemCode={2}','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')",this.EntryNo,e.Item.ItemIndex, e.Item.Cells[0].Text));
                    try
                    {
                        SubTotalItemMoney += decimal.Parse(e.Item.Cells[9].Text);
                        e.Item.Cells[9].Text = decimal.Parse(e.Item.Cells[9].Text).ToString("F3");
                    }
                    catch(Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                        SubTotalItemMoney += 0;
                    }
                    try
                    {
                        SubTotalItemSum += decimal.Parse(e.Item.Cells[10].Text);
                        e.Item.Cells[10].Text = decimal.Parse(e.Item.Cells[10].Text).ToString("F3");
                    }
                    catch(Exception ex)
                    {
                        Logger.Error(ex.Message, ex);
                        SubTotalItemSum += 0;
                    }
                    e.Item.Cells[7].Visible = IsDisplayPBORPrice;
                    e.Item.Cells[9].Visible = IsDisplayPBORPrice;
                    e.Item.Cells[10].Visible = IsDisplayPBORPrice;
                    break;
                case ListItemType.Footer:
                    if (this._OP == OP.I)//收料模式。
                    {
                        e.Item.Cells[11].Visible = true;
                        e.Item.Cells[8].Visible = true;
                    }
                    else
                    {
                        e.Item.Cells[11].Visible = false;
                        e.Item.Cells[8].Visible = false;
                    }
                    e.Item.Cells[9].Text = SubTotalItemMoney.ToString("F3");
                    e.Item.Cells[10].Text = SubTotalItemSum.ToString("F3");
                    e.Item.Cells[7].Visible = IsDisplayPBORPrice;
                    e.Item.Cells[9].Visible = IsDisplayPBORPrice;
                    e.Item.Cells[10].Visible = IsDisplayPBORPrice;
                    if (!IsDisplayPBORPrice)
                        e.Item.Cells[7].Text = "";
                    break;
            }
        }

        protected void txtFee_TextChanged(object sender, EventArgs e)
        {
            DistributeFee(this.TotalFee);
            this.txtFee.Text = TotalFee.ToString("F3");
            this.DGModel_Items1.DataSource = this.thisTable;
            this.DGModel_Items1.DataBind();
        }
        #endregion
        
    }
}
