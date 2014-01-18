namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using MZHMM.WebMM.Modules;
    using System.Web.UI;
	/// <summary>
	///	单据上物料部分内容用户控件。
	///	提供了，单据上物料项的增加、修改、删除、显示功能。
	/// </summary>
	public partial class PRTVWebControl : System.Web.UI.UserControl
	{
		#region 成员变量
		//protected StorageDropdownlist ddlUnit = new StorageDropdownlist();
 //20080408 物料单位名称
//20080408 物料单位ID
		public    StorageDropdownlist ddlCon ;
		public static DataTable dt;//定义了一静态的表,用以保存状态数据
		private string tmpCode;
		private string _OP;
		//public DGModel_Items DGModel_Items1;

        private decimal SubTotal = 0;
		#endregion

		#region 属性

        /// <summary>
        /// 是否显示单价
        /// </summary>
        public bool IsDisplayPRTVPrice
        {
            get
            {
                if (ViewState["IsDisplayPRTVPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayPRTVPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayPRTVPrice"] = value;
            }
        }

		/// <summary>
		/// DataGrid的数据源。
		/// </summary>
		public DataTable thisTable
		{
			get
			{
                if (Session[MySession.RTV_DT] != null)
                    return (DataTable)Session[MySession.RTV_DT];
                else
                {
                    this.thisTable = new DataTable();

                    DataColumnCollection columns = this.thisTable.Columns;
                    columns.Add("ItemCode");
                    columns.Add("ItemName");
                    columns.Add("ItemSpecial");
                    columns.Add("ItemUnit");
                    columns.Add("ItemUnitName");
                    columns.Add("BatchCode");
                    columns.Add("ItemPrice");
                    columns.Add("PlanNum");
                    columns.Add("ItemNum");
                    columns.Add("ItemMoney");
                    columns.Add("SourceEntry");
                    columns.Add("SourceDocCode");
                    columns.Add("SourceSerialNo");
                    columns.Add("TaxCode");
                    columns.Add("TaxRate");
                    columns.Add("ItemTax");
                    columns.Add("ItemSum");
                    return thisTable;
                }
			}	
			set
			{
				Session[MySession.RTV_DT] = value;
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

        //设置PKID并触发事件。
        public string PKID
        {
            set
            {
                this.txtEntryNo.Value = value;
                this.bntForEntryNo_Click(null, null);
            }
        }
		#endregion

		#region 私有方法
        /// <summary>
        /// 在静态表中检查该物料是否已经存在。
        /// </summary>
        /// <param name="ItemCode">string:	要检查的物料编号。</param>
        /// <returns>int:	没有返回-1，有则返回所在行的行数。</returns>
        private int GetRowByItemCode(string ItemCode)
        {
            int ret = -1;
            for (int i = 0; i < this.thisTable.Rows.Count; i++)
            {
                if (this.thisTable.Rows[i][BillOfReceiveData.SOURCEENTRY_FIELD].ToString() == "-1"
                    && this.thisTable.Rows[i][BillOfReceiveData.SOURCEDOCCODE_FIELD].ToString() == "-1"
                    && this.thisTable.Rows[i][BillOfReceiveData.SOURCESERIALNO_FIELD].ToString() == "-1")
                    if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode)
                    {
                        return i;
                    }
            }
            return ret;
        }
        private int GetRowBySource(string EntryNo, string DocCode, string SerialNo)
        {
            int ret = -1;
            for (int i = 0; i < this.thisTable.Rows.Count; i++)
            {
                if (this.thisTable.Rows[i][PRTVData.SOURCEENTRY_FIELD].ToString() == EntryNo
                    && this.thisTable.Rows[i][PRTVData.SOURCEDOCCODE_FIELD].ToString() == DocCode
                    && this.thisTable.Rows[i][PRTVData.SOURCESERIALNO_FIELD].ToString() == SerialNo)
                {
                    return i;
                }
            }
            return ret;
        }

        /// <summary>
        /// 对要编辑的数据进行校验，首先应退数不能超过收料单对应的数目，其次是退数不能超过应退数
        /// </summary>
        /// <returns>bool:	校验通过返回true，失败返回false。</returns>
        private bool DoCheck(decimal ItemRep)
        {
            bool ret = true;
            try
            {
                if ((txtItemCode.Text != "") && (txtItemName.Text != "") && (txtReqNum.Text != ""))
                {
                    decimal tmpDecimal = decimal.Parse(txtReqNum.Text);
                    if (tmpDecimal > ItemRep)
                        return false;
                    tmpDecimal = decimal.Parse(txtItemNum.Text);
                    if (tmpDecimal > ItemRep)
                        return false;
                }
                else
                {
                    ret = false;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// 根据不同操作模式，设定编辑区域的显示方式。
        /// </summary>
        /// <param name="OpMode">string:	操作模式。</param>
        private void SetEditMode(string OpMode)
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
                    this.txtItemSpecial.Visible = true;
                    this.txtItemSpecial.Enabled = true;
                    this.txtItemSpecial.ReadOnly = false;
                    this.ddlUnit.Visible = true;
                    this.ddlUnit.Enable = true;
                    this.txtBatchCode.Visible = true;
                    this.txtBatchCode.Enabled = true;
                    this.txtBatchCode.ReadOnly = false;
                    this.txtItemPrice.Visible = true;
                    this.txtItemPrice.Enabled = true;
                    this.txtItemPrice.ReadOnly = false;
                    this.txtReqNum.Visible = true;
                    this.txtReqNum.Enabled = true;
                    this.txtReqNum.ReadOnly = false;
                    this.txtTaxRate.Visible = true;
                    this.txtTaxRate.Enabled = true;
                    this.txtTaxRate.ReadOnly = false;
                    this.txtItemNum.Visible = false;
                    this.txtRemark.Enabled = true;
                    this.txtRemark.Visible = true;
                    this.txtRemark.ReadOnly = true;
                    this.ddlCon.Visible = false;
                    this.btnAddItem.Enabled = false;
                    this.btnDelItem.Enabled = false;
                    this.btnEditItem.Enabled = false;
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
                    this.txtItemSpecial.Visible = true;
                    this.txtItemSpecial.Enabled = true;
                    this.txtItemSpecial.ReadOnly = false;
                    this.ddlUnit.Visible = true;
                    this.ddlUnit.Enable = true;
                    this.txtBatchCode.Visible = true;
                    this.txtBatchCode.Enabled = true;
                    this.txtBatchCode.ReadOnly = false;
                    this.txtItemPrice.Visible = true;
                    this.txtItemPrice.Enabled = true;
                    this.txtItemPrice.ReadOnly = false;
                    this.txtReqNum.Visible = true;
                    this.txtReqNum.Enabled = true;
                    this.txtReqNum.ReadOnly = false;
                    this.txtTaxRate.Visible = true;
                    this.txtTaxRate.Enabled = true;
                    this.txtTaxRate.ReadOnly = false;
                    this.txtItemNum.Visible = false;
                    this.txtRemark.Enabled = true;
                    this.txtRemark.Visible = true;
                    this.txtRemark.ReadOnly = true;
                    this.ddlCon.Visible = false;
                    this.btnAddItem.Enabled = false;
                    this.btnDelItem.Enabled = false;
                    this.btnEditItem.Enabled = false;
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
                    this.txtItemSpecial.Visible = true;
                    this.txtItemSpecial.Enabled = true;
                    this.txtItemSpecial.ReadOnly = false;
                    this.ddlUnit.Visible = true;
                    this.ddlUnit.Enable = true;
                    this.txtBatchCode.Visible = true;
                    this.txtBatchCode.Enabled = true;
                    this.txtBatchCode.ReadOnly = false;
                    this.txtItemPrice.Visible = true;
                    this.txtItemPrice.Enabled = true;
                    this.txtItemPrice.ReadOnly = false;
                    this.txtReqNum.Visible = true;
                    this.txtReqNum.Enabled = true;
                    this.txtReqNum.ReadOnly = false;
                    this.txtTaxRate.Visible = true;
                    this.txtTaxRate.Enabled = true;
                    this.txtTaxRate.ReadOnly = false;
                    this.txtItemNum.Visible = false;
                    this.txtRemark.Enabled = true;
                    this.txtRemark.Visible = true;
                    this.txtRemark.ReadOnly = true;
                    this.ddlCon.Visible = false;
                    this.btnAddItem.Enabled = false;
                    this.btnDelItem.Enabled = false;
                    this.btnEditItem.Enabled = false;
                    break;
                    #endregion
                case OP.I:
                    #region 收料
                    this.txtItemCode.Visible = true;
                    this.txtItemCode.ReadOnly = true;
                    this.txtItemName.Visible = true;
                    this.txtItemName.ReadOnly = true;
                    this.txtItemSpecial.Visible = true;
                    this.txtItemSpecial.ReadOnly = true;
                    this.ddlUnit.Visible = true;
                    this.ddlUnit.Enable = false;
                    this.txtBatchCode.Visible = true;
                    this.txtBatchCode.ReadOnly = true;
                    this.txtItemPrice.Visible = false;
                    this.txtReqNum.Visible = false;
                    this.txtTaxRate.Visible = false;
                    this.txtItemNum.Visible = true;
                    this.txtItemNum.Enabled = true;
                    this.txtRemark.Visible = true;
                    this.txtRemark.Enabled = true;
                    this.txtRemark.ReadOnly = true;
                    this.ddlCon.Visible = false;
                    this.ddlCon.Enable = true;
                    this.btnAddItem.Enabled = false;
                    this.btnDelItem.Enabled = false;
                    this.btnEditItem.Enabled = true;
                    break;
                    #endregion
                default:
                    #region 默认
                    this.txtItemCode.Visible = true;
                    this.txtItemCode.Enabled = true;
                    this.txtItemCode.ReadOnly = false;
                    this.txtItemName.Visible = true;
                    this.txtItemName.Enabled = true;
                    this.txtItemName.ReadOnly = false;
                    this.txtItemSpecial.Visible = true;
                    this.txtItemSpecial.Enabled = true;
                    this.txtItemSpecial.ReadOnly = false;
                    this.ddlUnit.Visible = true;
                    this.ddlUnit.Enable = true;
                    this.txtBatchCode.Visible = true;
                    this.txtBatchCode.Enabled = true;
                    this.txtBatchCode.ReadOnly = false;
                    this.txtItemPrice.Visible = true;
                    this.txtItemPrice.Enabled = true;
                    this.txtItemPrice.ReadOnly = false;
                    this.txtReqNum.Visible = true;
                    this.txtReqNum.Enabled = true;
                    this.txtReqNum.ReadOnly = false;
                    this.txtTaxRate.Visible = true;
                    this.txtTaxRate.Enabled = true;
                    this.txtTaxRate.ReadOnly = false;
                    this.txtItemNum.Visible = false;
                    this.txtRemark.Enabled = true;
                    this.txtRemark.Visible = true;
                    this.txtRemark.ReadOnly = false;
                    this.ddlCon.Visible = false;
                    this.btnAddItem.Enabled = true;
                    this.btnDelItem.Enabled = true;
                    this.btnEditItem.Enabled = true;
                    break;
                    #endregion
            }
        }
		#endregion
		
		

		#region 事件
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (this.Request["Op"] != null && this.Request["Op"] != "")
			{
				this._OP = this.Request["Op"];
			}
			//模式设定。
			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//DGModel_Items1.ShowPager=false;
			//DGModel_Items1.AllowPaging = false;
			this.SetEditMode(this._OP);//设定编辑区域的显示模式。
			this.btnAddItem.Enabled = false;
			this.ddlCon.Visible = false;
            txtTaxRate.ReadOnly = true;

            txtItemPrice.Visible = IsDisplayPRTVPrice;

            switch (this._OP)
            {
                case OP.New:
                    #region 新增
                   if (!this.IsPostBack)
                    {
                        //定义表和数据结构
                        if (this.thisTable != null)
                            this.thisTable = null;
                        //dt = (new BillOfReceiveData()).Tables[BillOfReceiveData.PBOR_TABLE];
                        this.thisTable = (new PRTVData()).Tables[PRTVData.PRTV_TABLE];
                        DGModel_Items1.DataSource = this.thisTable;//数据源绑定。
                        DGModel_Items1.DataBind();
                        ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;//度量单位
                    }
                    else
                    {
                        DGModel_Items1.DataSource = this.thisTable;//数据源绑定。
                        DGModel_Items1.DataBind();
                    }
                    break;
                    #endregion
                case OP.Edit:
                    #region 编辑
                    this.SetEditMode(this._OP);
                    if (!this.IsPostBack)
                    {
                        ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;//度量单位。
                    }
                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                    tmpCode = DGModel_Items1.SelectedID;
                    break;
                    #endregion
                case OP.Submit:
                    #region 提交
                    this.SetEditMode(this._OP);
                    if (!this.IsPostBack)
                    {
                        ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;//度量单位。
                    }
                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                    tmpCode = DGModel_Items1.SelectedID;
                    break;
                    #endregion
                case OP.FirstAudit:
                    #region 一级审批
                    if (!this.IsPostBack)
                    {
                        //度量单位
                        ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
                    }
                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                    tmpCode = DGModel_Items1.SelectedID;
                    break;
                    #endregion
                case OP.SecondAudit:
                    #region 二级审批
                    if (!this.IsPostBack)
                    {
                        //度量单位
                        ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
                    }
                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                    tmpCode = DGModel_Items1.SelectedID;
                    break;
                    #endregion
                case OP.ThirdAudit:
                    #region 三级审批
                    if (!this.IsPostBack)
                    {
                        //度量单位
                        ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
                    }
                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                    tmpCode = DGModel_Items1.SelectedID;
                    break;
                    #endregion
                case OP.I:
                    #region 退货
                    if (!this.IsPostBack)
                    {
                        //度量单位
                        this.ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
                        this.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
                    }
                    txtTaxRate.ReadOnly = false;
                    ddlCon.Visible = false;
                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                    tmpCode = DGModel_Items1.SelectedID;
                    break;
                    #endregion
            }
		}

		/// <summary>
		/// 页面UnLoad事件。
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//释放静态变量dt
			//this.thisTable = null;
		}
		
		

		/// <summary>
		/// 设置操作按纽状态
		/// </summary>
		private void SetButtonStatus()
		{
			switch (this._OP)
			{
				case OP.New: 
				case OP.Edit:
					this.btnAddItem.Enabled = true;
					this.btnEditItem.Enabled = true;
					this.btnDelItem.Enabled = true;
					break;
				case OP.Submit:
				case OP.FirstAudit:
				case OP.SecondAudit:
				case OP.ThirdAudit:
				case OP.Red:
					this.btnAddItem.Enabled = false;
					this.btnEditItem.Enabled = false;
					this.btnDelItem.Enabled = false;
					break;
				case OP.O:
					this.btnAddItem.Enabled = false;
					this.btnEditItem.Enabled = true;
					this.btnDelItem.Enabled = false;
					break;
			}
		}
		#endregion

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            int iRow = int.Parse(txtItemSerial.Value);
            decimal ItemRep;
            if (this.thisTable.Rows[iRow][InItemData.ITEMNUM_FIELD] == DBNull.Value)
            {
                ItemRep = 0;
            }
            else
            {
                ItemRep = decimal.Parse(this.thisTable.Rows[iRow][PRTVData.PLANNUM_FIELD].ToString());
            }


            if (DoCheck(ItemRep))
            {
                decimal temp_num, temp_price, temp_money, temp_taxrate, temp_tax, temp_all;
                #region 更新


                DataRow dr = this.thisTable.Rows[iRow];
                if (this._OP == OP.I)
                {
                    temp_num = decimal.Parse(this.txtItemNum.Text);
                }
                else
                {
                    temp_num = decimal.Parse(this.txtReqNum.Text);
                   
                }
                temp_price = decimal.Parse(dr[InItemData.ITEMPRICE_FIELD].ToString());
                temp_taxrate = decimal.Parse(dr[PRTVData.TAXRATE_FIELD].ToString());
                
                temp_money = Math.Round((temp_num * temp_price), 2);
                temp_tax = Math.Round((temp_money * temp_taxrate), 2);
                temp_all = Math.Round((temp_money + temp_tax), 2);
                dr[BillOfReceiveData.PLANNUM_FIELD] = this.txtReqNum.Text;

                dr["ItemMoney"] = temp_money.ToString("0.##");
                dr["ItemTax"] = temp_tax.ToString("0.##");
                dr["ItemSum"] = temp_all.ToString("0.##");
                if (this._OP == OP.I)
                    dr[InItemData.ITEMNUM_FIELD] = this.txtItemNum.Text;
                else
                    dr[InItemData.ITEMNUM_FIELD] = this.txtReqNum.Text;

                txtItemSerial.Value = "-1";
                btnAddItem.Enabled = false;

                #endregion
                #region 复位
                this.DGModel_Items1.DataSource = this.thisTable;
                this.DGModel_Items1.DataBind();
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtItemSpecial.Text = "";
                this.txtReqNum.Text = "";
                this.ddlUnit.SetItemSelected("-1");
                this.txtItemPrice.Text = "";
                this.txtTaxRate.Text = "";
                this.txtBatchCode.Text = "";
                this.txtItemNum.Text = "";
                this.ddlCon.SetItemSelected("-1");
                #endregion
            }
            else
            {
                //Response.Write(@"<script>alert('数目超出范围')</script>");
                Page.RegisterStartupScript( "Error", "<script>alert('数目超出范围!');</script>");
                //this.txtReqNum.Text=dt.Rows[iRow][BillOfReceiveData.PLANNUM_FIELD].ToString();
                #region 复位
                this.DGModel_Items1.DataSource = this.thisTable;
                this.DGModel_Items1.DataBind();
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtItemSpecial.Text = "";
                this.txtReqNum.Text = "";
                this.ddlUnit.SetItemSelected("-1");
                this.txtItemPrice.Text = "";
                this.txtTaxRate.Text = "";
                this.txtBatchCode.Text = "";
                this.txtItemNum.Text = "";
                this.ddlCon.SetItemSelected("-1");
                #endregion
            }
        }

        private int GetRowIndex(string strItemcode)
        {
            for (int i = 0; i < thisTable.Rows.Count; i++)
            {
                if (strItemcode == this.thisTable.Rows[i]["ItemCode"].ToString())
                {
                    return i;
                }
            }

            return -1;
        }

        protected void btnDelItem_Click(object sender, EventArgs e)
        {
            if ((DGModel_Items1.SelectedID != null) && (DGModel_Items1.SelectedID != ""))
            {
                int iRow = GetRowIndex(DGModel_Items1.SelectedID);

                if(iRow  > -1)
                    this.thisTable.Rows.RemoveAt(iRow);

                DGModel_Items1.DataSource = this.thisTable;
                DGModel_Items1.DataBind();
            }
        }

        protected void btnEditItem_Click(object sender, EventArgs e)
        {
            //不等于-1表示已经处于编辑状态
            if (this.DGModel_Items1.SelectedID != null && this.DGModel_Items1.SelectedID != "")
            {
                int iRow = GetRowIndex(DGModel_Items1.SelectedID);

                if (iRow > -1)
                {
                    this.txtItemSerial.Value = iRow.ToString();//顺序号。
                    this.txtItemCode.Text = this.thisTable.Rows[iRow][InItemData.ITEMCODE_FIELD].ToString();//物料编号。
                    this.txtItemCode.Attributes.Add("ReadOnly", "ReadOnly");

                    this.txtItemName.Text = this.thisTable.Rows[iRow][InItemData.ITEMNAME_FIELD].ToString();//物料名称。
                    this.txtItemName.Attributes.Add("ReadOnly", "ReadOnly");

                    this.txtItemSpecial.Text = this.thisTable.Rows[iRow][InItemData.ITEMSPECIAL_FIELD].ToString();//规格型号。

                    this.txtItemSpecial.Attributes.Add("ReadOnly", "ReadOnly");

                    this.ddlUnit.SetItemSelected(this.thisTable.Rows[iRow][InItemData.ITEMUNIT_FIELD].ToString());//度量单位
                    ddlUnit.Enable = false;

                    this.txtBatchCode.Text = this.thisTable.Rows[iRow][BillOfReceiveData.BATCHCODE_FIELD].ToString();//批号。
                    txtBatchCode.Attributes.Add("ReadOnly", "ReadOnly");

                    this.txtItemPrice.Text = this.thisTable.Rows[iRow][InItemData.ITEMPRICE_FIELD].ToString();//单价。
                    txtItemPrice.Attributes.Add("ReadOnly", "ReadOnly");

                    this.txtReqNum.Text = this.thisTable.Rows[iRow][BillOfReceiveData.PLANNUM_FIELD].ToString();//应收数量。
                    this.txtTaxRate.Text = this.thisTable.Rows[iRow][BillOfReceiveData.TAXRATE_FIELD].ToString();//税率。
                    txtTaxRate.Attributes.Add("ReadOnly", "ReadOnly");

                    this.txtItemNum.Text = this.thisTable.Rows[iRow][InItemData.ITEMNUM_FIELD].ToString();//实收数量。				
                    this.ddlCon.SetItemSelected(this.thisTable.Rows[iRow][BillOfReceiveData.CONCODE_FIELD].ToString());//架位

                    this.btnAddItem.Enabled = true;
                }
            }
           
        }

        protected void btnForItemCode_Click(object sender, EventArgs e)
        {

        }

        protected void bntForEntryNo_Click(object sender, EventArgs e)
        {
            if (this.txtEntryNo.Value != "")
            {
                if (txtEntryNo.Value != "-1")
                {
                    RTVSDetailData oRTVSDetailData = new RTVSDetailData();
                    oRTVSDetailData = (new PurchaseSystem()).GetRTVSDetailByPKID(this.txtEntryNo.Value);

                    int CurrentRow;
                    for (int i = 0; i < oRTVSDetailData.Tables[RTVSDetailData.RTVSD_VIEW].Rows.Count; i++)
                    {
                        DataRow dr = oRTVSDetailData.Tables[RTVSDetailData.RTVSD_VIEW].Rows[i];
                        //判断该项是否存在。
                        CurrentRow = this.GetRowBySource(dr[InItemData.ENTRYNO_FIELD].ToString(), dr[DocBaseData.DOCCODE_FIELD].ToString(), dr[InItemData.SERIALNO_FIELD].ToString());
                        if (CurrentRow == -1)//如果不存在。
                        {
                            DataRow NewDr = this.thisTable.NewRow();
                            NewDr[PRTVData.SOURCEENTRY_FIELD] = dr[InItemData.ENTRYNO_FIELD];
                            NewDr[PRTVData.SOURCEDOCCODE_FIELD] = dr[DocBaseData.DOCCODE_FIELD];
                            NewDr[PRTVData.SOURCESERIALNO_FIELD] = dr[InItemData.SERIALNO_FIELD];
                            NewDr[InItemData.ITEMCODE_FIELD] = dr[InItemData.ITEMCODE_FIELD];
                            NewDr[InItemData.ITEMNAME_FIELD] = dr[InItemData.ITEMNAME_FIELD];
                            NewDr[InItemData.ITEMSPECIAL_FIELD] = dr[InItemData.ITEMSPECIAL_FIELD];
                            NewDr[InItemData.ITEMUNIT_FIELD] = dr[InItemData.ITEMUNIT_FIELD];
                            NewDr[InItemData.ITEMUNITNAME_FIELD] = dr[InItemData.ITEMUNITNAME_FIELD];
                            NewDr[InItemData.ITEMPRICE_FIELD] = dr[InItemData.ITEMPRICE_FIELD];
                            NewDr[InItemData.ITEMNUM_FIELD] = dr[InItemData.ITEMNUM_FIELD];
                            NewDr[PRTVData.PLANNUM_FIELD] = dr[RTVSDetailData.PLANNUM_FIELD];		//应收数量。
                            NewDr[PRTVData.TAXCODE_FIELD] = dr[RTVSDetailData.TAXCODE_FIELD];		//税码。
                            NewDr[PRTVData.TAXRATE_FIELD] = dr[RTVSDetailData.TAXRATE_FIELD];		//税率。
                            NewDr[InItemData.ITEMMONEY_FIELD] = dr[InItemData.ITEMMONEY_FIELD];		//金额。
                            NewDr[PRTVData.ITEMTAX_FIELD] = dr[RTVSDetailData.ITEMTAX_FIELD];		//税额。
                            NewDr[PRTVData.ITEMSUM_FIELD] = dr[RTVSDetailData.ITEMSUM_FIELD];		//单项总金额。

                            this.thisTable.Rows.Add(NewDr);
                        }
                    }

                }
            }
            DGModel_Items1.DataSource = this.thisTable;
            DGModel_Items1.DataBind();	
        }

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                SubTotal = 0;
                e.Item.Cells[5].Visible = IsDisplayPRTVPrice;
                e.Item.Cells[8].Visible = IsDisplayPRTVPrice;
               
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               
                SubTotal += decimal.Parse(e.Item.Cells[8].Text);
                e.Item.Cells[5].Visible = IsDisplayPRTVPrice;
                e.Item.Cells[8].Visible = IsDisplayPRTVPrice;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

                e.Item.Cells[8].Text = SubTotal.ToString(); 
                e.Item.Cells[5].Visible = IsDisplayPRTVPrice;
                e.Item.Cells[8].Visible = IsDisplayPRTVPrice;
                if (!IsDisplayPRTVPrice)
                    e.Item.Cells[7].Text = "";
            }
        }
	}
}
