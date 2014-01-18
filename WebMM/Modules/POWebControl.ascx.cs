using Shmzh.Components.SystemComponent.DALFactory;

namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Web.UI.WebControls;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using System.Web.UI;
	/// <summary>
	///	单据上物料部分内容用户控件。
	///	提供了，单据上物料项的增加、修改、删除、显示功能。
	/// </summary>
	public partial class POWebControl : System.Web.UI.UserControl
	{
		#region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		//private string tmpCode;
		private string _OP;
		public string PKIDList;
		
		public System.Web.UI.WebControls.TextBox txtRemark;

	    private DataColumnCollection columns;

	    private int ret;
	    private int i;

	    private bool bret;

	    private decimal temp_num;
	    
        private decimal temp_price;

	    private decimal temp_money;

	    private int iRow;
	    private DataRow dr;

	    private POSData oPOSData;

        private readonly PurchaseSystem oPurchaseSystem = new PurchaseSystem();

	    private DataRowCollection tmp;

	    private int CurrentRow;
        #endregion

        #region 属性
        /// <summary>
        /// 是否允许任意添加物料。
        /// </summary>
	    public bool AllowFreeAddItem
	    {
	        get
	        {
                var obj = DataProvider.SettingProvider.GetByKey("AllowFreeAddItem");
                return obj != null && obj.Value != "0";
	        }
	    }
        /// <summary>
        /// 是否显示单价
        /// </summary>
        public bool IsDisplayPOPrice
        {
            get {
                return ViewState["IsDisplayPOPrice"] != null && bool.Parse(ViewState["IsDisplayPOPrice"].ToString());
            }
            set
            {
                ViewState["IsDisplayPOPrice"] = value;
            }
        }
        /// <summary>
        /// 单据号。
        /// </summary>
        public int EntryNo
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(Request["EntryNo"]) ? 0 : int.Parse(this.Request["EntryNo"]);
                }
                catch
                {
                    return 0;
                }
                
            }
        }
        
		public DataTable thisTable
		{
			get
			{
                if (Session[MySession.ORD_DT] != null)
                    return (DataTable)Session[MySession.ORD_DT];
                else
                {
                    this.thisTable = new DataTable();

                    columns = this.thisTable.Columns;
                    columns.Add("NewCode");
                    columns.Add("ItemCode");
                    columns.Add("ItemName");
                    columns.Add("ItemSpecial");
                    columns.Add("ItemUnitName");
                    columns.Add("ItemUnit");
                    columns.Add("ItemPrice");
                    columns.Add("ItemNum");
                    columns.Add("ItemMoney");
                    columns.Add("EntryNo");
                    columns.Add("SourceEntry");
                    columns.Add("SourceDocCode");
                    columns.Add("SourceSerialNo");
                    columns.Add("ItemLackNum");
                    columns.Add("Proposer");
                    return thisTable;
                }
			}	
			set
			{
				Session[MySession.ORD_DT] = value;
			}
		}

        /// <summary>
        /// 新增按钮的CssClass。
        /// </summary>
        public string NewBtnClass
        {
            get {
                return this.ViewState["NewBtnClass"] == null ? string.Empty : this.ViewState["NewBtnClass"].ToString();
            }
            set
            {
                this.ViewState["NewBtnClass"] = value;
            }
        }
		#endregion

		#region 私有方法
		/// <summary>
		/// 在静态表中检查该物料是否已经存在。
		/// </summary>
		private int GetRowByPKID(string pkid)
		{
			ret = -1;
		    var aa = pkid.Split('|');
		    var sourceEntry = aa[0];
		    var sourceSerialNo = aa[1];
		    var sourceDocCode = aa[2];

			for(i=0; i<this.thisTable.Rows.Count;i++)
			{
				if(this.thisTable.Rows[i]["SourceEntry"].ToString() == sourceEntry && 
                    this.thisTable.Rows[i]["SourceSerialNo"].ToString() == sourceSerialNo && 
                    this.thisTable.Rows[i]["SourceDocCode"].ToString() == sourceDocCode)
				{
					return i;
				}
			}
			return ret;
		}
		/// <summary>
		/// 对数据进行校验.
		/// </summary>
		/// <returns>bool:	校验通过返回true，失败返回false。</returns>
		private bool DoCheck()
		{
			bret=true;
			try
			{
				if(txtReqNum.Text!="")  
				{
                    if (this._OP != "Red")
                    {
                        if (decimal.Parse(txtReqNum.Text) > decimal.Parse("0"))
                        {
                            bret = true;
                        }
                        else
                        {
                            Page.RegisterStartupScript( "Error", "<script>alert('数量不能小于等于0!');</script>");
                            bret = false;
                        }
                    }
                    else
                    {
                        if (decimal.Parse(txtReqNum.Text) < decimal.Parse("0"))
                        {
                            bret = true;
                        }
                        else
                        {
                            Page.RegisterStartupScript("Error", "<script>alert('数量不能大于等于0!');</script>");
                            bret = false;
                        }
                    }
				}
				else
				{
                    Page.RegisterStartupScript( "Error", "<script>alert('数量不能为空!');</script>");
                   
					bret=false;
				}
			}
			catch
			{
                Page.RegisterStartupScript( "Error", "<script>alert('数量格式不正确!');</script>");
				bret=false;
			}
			return bret;
		}

        private int GetRowIndex(string strItemcode)
        {
            for (i = 0; i < thisTable.Rows.Count; i++)
            {
                if (strItemcode == this.thisTable.Rows[i]["ItemCode"].ToString())
                {
                    return i;
                }
            }

            return -1;
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
                    this.btnEditItem.Enabled = true;
                    this.btnDelItem.Enabled = true;
                    break;
                case OP.Submit:
                case OP.FirstAudit:
                case OP.SecondAudit:
                case OP.ThirdAudit:
                case OP.Red:
                    this.btnEditItem.Enabled = false;
                    this.btnDelItem.Enabled = false;
                    break;
                case OP.O:
                    this.btnEditItem.Enabled = true;
                    this.btnDelItem.Enabled = false;
                    break;
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
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
            txtItemPrice.Visible = IsDisplayPOPrice;
            //初始化
            if ((!this.IsPostBack) && ((this._OP == OP.Affirm) || (this._OP == OP.FirstAudit)))
			{
				this.btnAddItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.btnEditItem.Enabled = false;
                this.txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
                this.NewBtnClass = "display: none;visibility:hidded;";
			    this.btnItem.Visible = this.AllowFreeAddItem;
			}
			if((!this.IsPostBack) && (this.Request["Op"]=="New"))
			{
				//绑定
				DGModel_Items1.DataSource=this.thisTable;				
				DGModel_Items1.DataBind();
				//初始化一些项
				//度量单位
				ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
			}
			else
			{
				if(!this.IsPostBack)
				{
					//度量单位
					ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
				}
				DGModel_Items1.DataSource=this.thisTable;				
				DGModel_Items1.DataBind();
                //tmpCode=DGModel_Items1.SelectedID;
			}

            if (this._OP.ToUpper() == "RED")
            {
                this.NewBtnClass = "display: none;visibility:hidded;";
            }

		}
		
		/// <summary>
		/// 取消输入
		/// </summary>
		protected void btnCancelItem_Click(object sender, System.EventArgs e)
		{
			txtItemSerial.Value="-1";

			txtItemCode.Text="";
			txtItemName.Text="";
			txtItemSpecial.Text="";
			ddlUnit.SetItemSelected("-1");
			//txtItemUnit.Value="-1";  //20080418 物料单位ID初始化
			//lblUnit.Text="";	//20080418 物料单位名称初始化
			txtItemPrice.Text="";
			txtReqNum.Text="";

			SetButtonStatus();
		}
		
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            //
            //更新一行数据并且赋值
            //
            if (DoCheck())
            {
                
                iRow = int.Parse(txtItemSerial.Value);
                if (iRow > -1)
                {
                    dr = this.thisTable.Rows[iRow];


                    dr["ItemNum"] = txtReqNum.Text;

                    temp_num = decimal.Parse(dr["ItemNum"].ToString());
                    //temp_price = decimal.Parse(dr["ItemPrice"].ToString());
                    temp_price = decimal.Parse(this.txtItemPrice.Text);
                    dr["ItemPrice"] = temp_price;
                    temp_money = temp_num * temp_price;
                    dr["ItemMoney"] = temp_money.ToString("0.##");

                    txtItemSerial.Value = "-1";


                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                    hfNewCode.Value = string.Empty;
                    txtItemCode.Text = "";
                    txtItemName.Text = "";
                    txtItemSpecial.Text = "";
                    txtReqNum.Text = "";
                    ddlUnit.SetItemSelected("-1");
                    txtItemPrice.Text = "";
                }
                else
                {
                    dr = this.thisTable.NewRow();
                    dr["NewCode"] = hfNewCode.Value.Trim();
                    dr["ItemCode"] = txtItemCode.Text.Trim();
                    dr["ItemName"] = txtItemName.Text.Trim();
                    dr["ItemSpecial"] = txtItemSpecial.Text.Trim();
                    dr["ItemUnit"] = ddlUnit.SelectedValue;
                    dr["ItemUnitName"] = ddlUnit.SelectedText;
                    dr["ItemNum"] = txtReqNum.Text;
                    dr["SourceEntry"] = DBNull.Value;
                    dr["SourceDocCode"] = DBNull.Value;
                    dr["SourceSerialNo"] = DBNull.Value;

                    var num = decimal.Parse(dr["ItemNum"].ToString());
                    var price = decimal.Parse(this.txtItemPrice.Text);
                    dr["ItemPrice"] = price;
                    var money = num * price;
                    dr["ItemMoney"] = money.ToString("0.##");
                    txtItemSerial.Value = "-1";
                    hfNewCode.Value = string.Empty;
                    txtItemCode.Text = "";
                    txtItemName.Text = "";
                    txtItemSpecial.Text = "";
                    txtReqNum.Text = "";
                    ddlUnit.SetItemSelected("-1");
                    txtItemPrice.Text = "";
                    var isExists = false;
                    for (var i = 0; i < thisTable.Rows.Count; i++)
                    {
                        if (thisTable.Rows[i]["ItemCode"].ToString() == dr["ItemCode"].ToString() &&
                            thisTable.Rows[i]["SourceEntry"].ToString() == dr["SourceEntry"].ToString() &&
                            thisTable.Rows[i]["SourceDocCode"].ToString() == dr["SourceDocCode"].ToString() &&
                            thisTable.Rows[i]["SourceSerialNo"].ToString() == dr["SourceSerialNo"].ToString())
                        {
                            isExists = true;
                            break;
                        }
                    }
                    if(!isExists)
                        this.thisTable.Rows.Add(dr);
                    DGModel_Items1.DataSource = this.thisTable;
                    DGModel_Items1.DataBind();
                }
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
                if (!string.IsNullOrEmpty(this.DGModel_Items1.SelectedID))
                {
                    iRow = GetRowIndex(DGModel_Items1.SelectedID);

                    if (iRow > -1)
                    {
                        txtItemSerial.Value = iRow.ToString();
                        hfNewCode.Value = this.thisTable.Rows[iRow]["NewCode"].ToString();
                        txtItemCode.Text = this.thisTable.Rows[iRow]["ItemCode"].ToString();
                        txtItemCode.Enabled = false;
                        txtItemName.Text = this.thisTable.Rows[iRow]["ItemName"].ToString();
                        txtItemName.Enabled = false;
                        txtItemSpecial.Text = this.thisTable.Rows[iRow]["ItemSpecial"].ToString();
                        txtItemSpecial.Enabled = false;
                        txtReqNum.Text = this.thisTable.Rows[iRow]["ItemNum"].ToString();
                        txtItemPrice.Text = this.thisTable.Rows[iRow]["ItemPrice"].ToString();
                        //txtItemPrice.Enabled = false;
                        //度量单位
                        ddlUnit.SetItemSelected(this.thisTable.Rows[iRow]["ItemUnit"].ToString());
                    }
                }
            }

        }

        protected void btnForItemCode_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text != "")
            {
                if (txtItemCode.Text != "-1")//-1表示是OTI物料。名称、规格型号等都是由用户临时指定的。
                {
                    //
                    //设置物料名称，规格型号，单价控件为只读并灰掉单位控件
                    //
                    this.txtItemName.ReadOnly = true;
                    this.txtItemSpecial.ReadOnly = true;
                    //this.txtItemPrice.ReadOnly = true;
                    this.ddlUnit.Enable = false;
                    //
                    //需要从物料数据库中获取
                    //

                    var oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    //存在物料数据
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        hfNewCode.Value =
                            oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.NEWCODE_FIELD].ToString();
                        txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        try
                        { this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.000"); }
                        catch
                        {
                            try
                            { this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.EVAPRICE_FIELD].ToString()).ToString("0.000"); }
                            catch
                            {
                                this.txtItemPrice.Text = "0.000";
                            }
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
                }
                else
                {
                    //
                    //用户直接输入
                    //
                    this.txtItemName.ReadOnly = false;
                    this.txtItemSpecial.ReadOnly = false;
                    //this.txtItemPrice.ReadOnly = false;
                    this.ddlUnit.Enable = true;
                    var oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.000");
                        //度量单位
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }
                }
            }
        }
        protected void btnForPOSData_Click(object sender, EventArgs e)
        {
            if (txtPKID.Value != "")
            {
                if (txtPKID.Value != "-1")
                {
                    oPOSData = (new PurchaseSystem()).GetPOSByPKIDs(txtPKID.Value);
                    //存在数据
                    if (oPOSData.Tables[POSData.VPOS_VIEW].Rows.Count > 0)
                    {
                        tmp = oPOSData.Tables[POSData.VPOS_VIEW].Rows;

                        for (int j = 0; j < tmp.Count; j++)
                        {
                            CurrentRow = this.GetRowByPKID(tmp[j][POSData.PKID_FIELD].ToString());
                            if (CurrentRow == -1)
                            {
                                dr = this.thisTable.NewRow();
                                if (this._OP == "New")
                                {
                                    //dr.ItemArray = tmp[i].ItemArray;
                                    //for (int j = 0; j < dr.ItemArray.Length; j++)
                                    //{
                                    //    dr[j] = tmp[i][""]
                                    //}
                                    dr[PurchaseOrderData.SOURCEENTRY_FIELD] = tmp[j][POSData.ENTRYNO_FIELD];
                                    dr[PurchaseOrderData.SOURCEDOCCODE_FIELD] = tmp[j][POSData.DOCCODE_FIELD];
                                    dr[PurchaseOrderData.SOURCESERIALNO_FIELD] = tmp[j][POSData.SERIALNO_FIELD];
                                    dr[InItemData.NEWCODE_FIELD] = tmp[j][POSData.NEWCODE_FIELD];
                                    dr[InItemData.ITEMCODE_FIELD] = tmp[j][POSData.ITEMCODE_FIELD];
                                    dr[InItemData.ITEMNAME_FIELD] = tmp[j][POSData.ITEMNAME_FIELD];
                                    dr[InItemData.ITEMSPECIAL_FIELD] = tmp[j][POSData.ITEMSPECIAL_FIELD];
                                    dr[InItemData.ITEMUNIT_FIELD] = tmp[j][POSData.ITEMUNIT_FIELD];
                                    dr[InItemData.ITEMUNITNAME_FIELD] = tmp[j][POSData.ITEMUNITNAME_FIELD];
                                    dr[InItemData.ITEMPRICE_FIELD] = tmp[j][POSData.ITEMPRICE_FIELD];
                                    dr[InItemData.ITEMNUM_FIELD] = tmp[j][POSData.ITEMNUM_FIELD];
                                    dr[InItemData.ITEMMONEY_FIELD] = tmp[j][POSData.ITEMMONEY_FIELD];
                                    dr["Proposer"] = tmp[j][POSData.PROPOSER_FIELD];

                                }
                                if (this._OP == "Edit")
                                {
                                    dr[PurchaseOrderData.SOURCEENTRY_FIELD] = tmp[j][POSData.ENTRYNO_FIELD];
                                    dr[PurchaseOrderData.SOURCEDOCCODE_FIELD] = tmp[j][POSData.DOCCODE_FIELD];
                                    dr[PurchaseOrderData.SOURCESERIALNO_FIELD] = tmp[j][POSData.SERIALNO_FIELD];
                                    dr[InItemData.NEWCODE_FIELD] = tmp[j][POSData.NEWCODE_FIELD];
                                    dr[InItemData.ITEMCODE_FIELD] = tmp[j][POSData.ITEMCODE_FIELD];
                                    dr[InItemData.ITEMNAME_FIELD] = tmp[j][POSData.ITEMNAME_FIELD];
                                    dr[InItemData.ITEMSPECIAL_FIELD] = tmp[j][POSData.ITEMSPECIAL_FIELD];
                                    dr[InItemData.ITEMUNIT_FIELD] = tmp[j][POSData.ITEMUNIT_FIELD];
                                    dr[InItemData.ITEMUNITNAME_FIELD] = tmp[j][POSData.ITEMUNITNAME_FIELD];
                                    dr[InItemData.ITEMPRICE_FIELD] = tmp[j][POSData.ITEMPRICE_FIELD];
                                    dr[InItemData.ITEMNUM_FIELD] = tmp[j][POSData.ITEMNUM_FIELD];
                                    dr[InItemData.ITEMMONEY_FIELD] = tmp[j][POSData.ITEMMONEY_FIELD];
                                    dr["Proposer"] = tmp[j][POSData.PROPOSER_FIELD];
                                }
                                this.thisTable.Rows.Add(dr);
                            }
                        }
                    }
                    else
                    {
                        //
                        //不存在缺省为需要输入数据,弹出物料浏览界面,提供用户选择
                        //
                    }
                }
                else
                {
                    //
                    //用户直接输入
                    //
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
                    e.Item.Cells[6].Visible = IsDisplayPOPrice;
                    e.Item.Cells[7].Visible = IsDisplayPOPrice;
                    break;
                case ListItemType.AlternatingItem:
                case ListItemType.Item:
                    e.Item.Attributes.Add("ondblclick", string.Format("window.open('../Analysis/DocRoute.aspx?EntryNo={0}&DocCode=3&SerialNo={1}&ItemCode={2}','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')",this.EntryNo,e.Item.ItemIndex,e.Item.Cells[0].Text));
                    e.Item.Cells[6].Visible = IsDisplayPOPrice;
                    e.Item.Cells[7].Visible = IsDisplayPOPrice;
                    try
                    {
                        //Logger.Info(e.Item.Cells[9].Text);
                        string s;
                        switch (e.Item.Cells[10].Text)
                        {
                            case "1": //紧急申购单
                                s = oPurchaseSystem.GetROS_ReqReasonCode(int.Parse(e.Item.Cells[11].Text), int.Parse(e.Item.Cells[12].Text));
                                e.Item.Cells[13].Text = s;
                                break;
                            case "5"://采购计划
                                s = oPurchaseSystem.GetPP_ReqReasonCode(int.Parse(e.Item.Cells[11].Text), int.Parse(e.Item.Cells[12].Text));
                                e.Item.Cells[13].Text = s;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message, ex);   
                    }
                    break;
            }
        }

	    #endregion

	    
	}
}
