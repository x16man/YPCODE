using Shmzh.Components.SystemComponent.DALFactory;

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
	public partial class PPWebControl : System.Web.UI.UserControl
	{
		#region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private string _OP;
        private decimal SubTotal;

        public string DeptCo { get; set; }

	    private int ret;

	    private bool bret;
	    private int i;

	    private ItemData oItemData = new ItemData();

	    private string strItemCode;

	    private int CurrentRow;

	    private int iRow;
	    private DataRow dr;
		#endregion

		#region 属性

        /// <summary>
        /// 是否显示单价
        /// </summary>
        public bool IsDisplayPPPrice
        {
            get
            {
                if (ViewState["IsDisplayPPPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayPPPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayPPPrice"] = value;
            }
        }

        public DataTable thisTable
        {
            get
            {
                if (Session[MySession.ORD_DT] != null)
                    return (DataTable)Session[MySession.ORD_DT];
                else
                    return null;
            }
            set
            {
                Session[MySession.ORD_DT] = value;
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
		/// 定义静态数据表的数据结构。
		/// </summary>
		private void CreateDataTable()
		{
			//定义表和数据结构
			if(this.thisTable!=null) 
				this.thisTable = null;

			this.thisTable = new DataTable();

			DataColumnCollection columns = this.thisTable.Columns;
			columns.Add("SourceEntry");			//源单据流水号。
			columns.Add("SourceDocCode");		//源单据类型。
		    columns.Add("NewCode");
			columns.Add("ItemCode");			//物料编号。
			columns.Add("ItemName");			//物料名称。
			columns.Add("ItemSpecial");			//规格型号。
			columns.Add("ItemUnit");			//单位。
			columns.Add("ItemUnitName");		//单位名称。
			columns.Add("ItemPrice").DataType = typeof(System.Decimal);	//单价。
			columns.Add("ItemNum").DataType=typeof(System.Decimal);//计划数量。
			columns.Add("ItemMoney").DataType = typeof(System.Decimal);//金额。
			columns.Add("ReqDept");//申请部门。
			columns.Add("ReqDeptName");//申请部门名称。
			columns.Add("ReqReasonCode");//用途编号。
			columns.Add("ReqReason");//用途名称。
			columns.Add("ReqDate");//要求日期。
            columns.Add("Proposer");//申请人
			columns.Add("Remark");//备注。
		}
		/// <summary>
		/// 在静态表中检查该物料是否已经存在。
		/// </summary>
		/// <param name="ItemCode">string:	要检查的物料编号。</param>
		/// <param name="ReqDept"></param>
		/// <param name="ItemName"></param>
		/// <param name="ItemSpec"></param>
		/// <param name="ReqReasonCode"></param>
		/// <returns>int:	没有返回-1，有则返回所在行的行数。</returns>
		private int GetRowByItemCode(string ReqDept,string ItemCode,string ReqReasonCode,string ItemName, string ItemSpec)
		{
			ret = -1;
			if (ItemCode != "-1")//非OTI物料。
			{
				for (i = 0; i < this.thisTable.Rows.Count; i++)
				{
					if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode &&
						this.thisTable.Rows[i][PurchasePlanData.REQDEPT_FIELD].ToString() == ReqDept &&
						this.thisTable.Rows[i][PurchasePlanData.REQREASONCODE_FIELD].ToString() == ReqReasonCode)
					{
						return i;
					}
				}
			}
			else//OTI物料的编号都为-1，所以要进行物料名称和规格型号的判断。
			{
				for (i=0; i < this.thisTable.Rows.Count; i++)
				{
					if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode &&
						this.thisTable.Rows[i][PurchasePlanData.REQDEPT_FIELD].ToString() == ReqDept &&
						this.thisTable.Rows[i][PurchasePlanData.REQREASONCODE_FIELD].ToString() == ReqReasonCode&&
						this.thisTable.Rows[i][InItemData.ITEMNAME_FIELD].ToString() == ItemName &&
						this.thisTable.Rows[i][InItemData.ITEMSPECIAL_FIELD].ToString() == ItemSpec)
					{
						return i;
					}
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
			    if ((ddlReqDept.SelectedValue != "-1") && (txtItemCode.Text != "") && (txtItemName.Text != "") && (txtReqNum.Text != "") && (txtReqDate.Text != "") && (ddlUnit.SelectedValue != "-1"))
                {
                    decimal.Parse(txtReqNum.Text);
                    DateTime.Parse(txtReqDate.Text);
                }
				else
				{
					Page.RegisterStartupScript(  "DoCheck", "<script>alert(\"申请部门、物料编号、物料名称、单位、数量、需求日期不能为空！\");</script>");
					bret=false;
				}
			}
			catch
			{
				bret=false;
			}
			return bret;
		}
		#endregion
		
		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Unload += new System.EventHandler(this.Page_UnLoad);
        }
		#endregion

		#region 事件
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsDisplayPPPrice)
            {
                txtItemPrice.Visible = false;
            }
            else
            {
                txtItemPrice.Visible = true;
            }
            if (OperateRed)
            {
                this.btnAddItem.Enabled = false;
                this.btnEditItem.Enabled = false;
                this.btnDelItem.Enabled = false;
            }

           
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//审批模式下，不允许进行单据内容的修改。
			if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.txtRemark.Enabled = false;

			    var DifferGXGZ = DataProvider.SettingProvider.GetByKey("DifferGXGZ");
                if(DifferGXGZ == null || DifferGXGZ.Value != "1")
                {
                    this.MzhDataGrid1.Visible = false;
                    this.titleGXGZ.Visible = false;
                    this.MzhDataGrid2.Visible = false;
                    this.DGModel_Items1.Visible = true;
                }
                else
                {
                    this.DGModel_Items1.Visible = false;
                    this.MzhDataGrid1.Visible = true;
                    this.titleGXGZ.Visible = true;
                    this.MzhDataGrid2.Visible = true;
                }
			}
			//以新增模式第一次调用页面。
			if((!this.IsPostBack) && (this.Request["Op"]=="New"))
			{
				//this.CreateDataTable();//定义数据表结构。
				DGModel_Items1.DataSource=this.thisTable;//绑定。
				DGModel_Items1.DataBind();
				//初始化一些项
				//下拉列表。
				this.ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
                this.ddlReqDept.Module_Tag = (int)SDDLTYPE.AllDept;
			    ddlReqDept.DeptCo = this.DeptCo;
				this.ddlReqDept.UserCode = Session[MySession.UserLoginId].ToString();
				this.ddlReqDept.DocType = DocType.PP;

			}
			else
			{
				if(!this.IsPostBack)
				{
					//下拉列表。
					this.ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
					this.ddlReqDept.Module_Tag = (int)SDDLTYPE.AllDept;
                    ddlReqDept.DeptCo = this.DeptCo;
					this.ddlReqDept.UserCode = Session[MySession.UserLoginId].ToString();
					this.ddlReqDept.DocType = DocType.PP;
				}
                if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
                {
                    var DifferGXGZ = DataProvider.SettingProvider.GetByKey("DifferGXGZ");
                    if (DifferGXGZ == null || DifferGXGZ.Value != "1")
                    {
                        DGModel_Items1.DataSource = this.thisTable;
                        DGModel_Items1.DataBind();
                    }
                    else
                    {
                        var dv1 = new DataView(this.thisTable, "TopClassify<>'A'", string.Empty,
                                               DataViewRowState.CurrentRows);
                        var dv2 = new DataView(this.thisTable, "TopClassify='A'", string.Empty,
                                               DataViewRowState.CurrentRows);
                        this.MzhDataGrid1.DataSource = dv1;
                        this.MzhDataGrid2.DataSource = dv2;

                        this.MzhDataGrid1.DataBind();
                        this.MzhDataGrid2.DataBind();
                    }
                }
                else
                {
                    DGModel_Items1.DataSource=this.thisTable;				
				    DGModel_Items1.DataBind();
                }
				
			}
		}
		/// <summary>
		/// 页面UnLoad事件。
		/// </summary>
		protected void Page_UnLoad(object sender, System.EventArgs e)
		{
			//释放静态变量dt
            if(thisTable != null)
			    this.thisTable.Dispose();
		}
		#endregion

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
                    this.txtItemPrice.ReadOnly = true;
                    this.ddlUnit.Enable = false;
                    //
                    //需要从物料数据库中获取
                    //
                   
                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    //存在物料数据
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        hfNewCode.Value =
                            oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.NEWCODE_FIELD].ToString();
                        txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        try
                        {
                            this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        }
                        catch
                        {
                            try
                            {
                                this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.EVAPRICE_FIELD].ToString()).ToString("0.###");
                            }
                            catch
                            {
                                this.txtItemPrice.Text = "0.000";
                            }
                        }
                        //度量单位
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }
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
                        try
                        {
                            this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        }
                        catch
                        {
                            try
                            {
                                this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.EVAPRICE_FIELD].ToString()).ToString("0.###");
                            }
                            catch
                            {
                                this.txtItemPrice.Text = "0.000";
                            }
                        }
                        //度量单位
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }
                }
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (DoCheck())
            {
                decimal temp_num, temp_price, temp_money;

                if (btnAddItem.Text == "新增")
                {
                   
                    CurrentRow = GetRowByItemCode(this.ddlReqDept.SelectedValue, txtItemCode.Text, this.ddlPurpose.SelectedValue,
                                                    this.txtItemName.Text, this.txtItemSpecial.Text);

                    if (CurrentRow == -1)//静态表中没有过该物料。
                    {
                        dr = this.thisTable.NewRow();
                        dr[PurchasePlanData.REQDEPT_FIELD] = this.ddlReqDept.SelectedValue;
                        dr[PurchasePlanData.REQDEPTNAME_FIELD] = this.ddlReqDept.SelectedText;
                        dr[InItemData.NEWCODE_FIELD] = this.hfNewCode.Value;
                        dr[InItemData.ITEMCODE_FIELD] = this.txtItemCode.Text;
                        dr[InItemData.ITEMNAME_FIELD] = this.txtItemName.Text;
                        dr[InItemData.ITEMSPECIAL_FIELD] = this.txtItemSpecial.Text;
                        dr[InItemData.ITEMUNIT_FIELD] = this.ddlUnit.SelectedValue;
                        dr[InItemData.ITEMUNITNAME_FIELD] = this.ddlUnit.SelectedText;
                        dr[InItemData.ITEMPRICE_FIELD] = this.txtItemPrice.Text;
                        dr[InItemData.ITEMNUM_FIELD] = this.txtReqNum.Text;
                        dr[PurchasePlanData.REQREASONCODE_FIELD] = this.ddlPurpose.SelectedValue;
                        dr[PurchasePlanData.REQREASON_FIELD] = this.ddlPurpose.SelectedText;
                        //金额
                        temp_num = decimal.Parse(this.txtReqNum.Text);
                        temp_price = decimal.Parse(this.txtItemPrice.Text);
                        temp_money = Math.Round((temp_num * temp_price), 2);

                        dr[InItemData.ITEMMONEY_FIELD] = temp_money.ToString("0.##");
                        dr[PurchasePlanData.REQDATE_FIELD] = this.txtReqDate.Text;
                        dr[InItemData.REMARK_FIELD] = this.txtRemark.Text;
                        dr["Proposer"] = "";
                        this.thisTable.Rows.Add(dr);
                    }
                    else//静态表中已经存在该物料。
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD].ToString())
                                 + Convert.ToDecimal(this.txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD] = temp_num;
                        this.thisTable.Rows[CurrentRow][InItemData.ITEMMONEY_FIELD] = temp_money;
                    }
                }
                else//更新。
                {
                    iRow = int.Parse(txtItemSerial.Value);
                    dr = this.thisTable.Rows[iRow];
                    CurrentRow = GetRowByItemCode(this.ddlReqDept.SelectedValue, txtItemCode.Text, this.ddlPurpose.SelectedValue,
                                                    this.txtItemName.Text, this.txtItemSpecial.Text);
                    if (CurrentRow == iRow || CurrentRow == -1)//没有重复物料。
                    {
                        dr[PurchasePlanData.REQDEPT_FIELD] = this.ddlReqDept.SelectedValue;
                        dr[PurchasePlanData.REQDEPTNAME_FIELD] = this.ddlReqDept.SelectedText;
                        dr[InItemData.NEWCODE_FIELD] = this.hfNewCode.Value;
                        dr[InItemData.ITEMCODE_FIELD] = this.txtItemCode.Text;
                        dr[InItemData.ITEMNAME_FIELD] = this.txtItemName.Text;
                        dr[InItemData.ITEMSPECIAL_FIELD] = this.txtItemSpecial.Text;
                        dr[InItemData.ITEMUNIT_FIELD] = this.ddlUnit.SelectedValue;
                        dr[InItemData.ITEMUNITNAME_FIELD] = this.ddlUnit.SelectedText;
                        dr[InItemData.ITEMPRICE_FIELD] = this.txtItemPrice.Text;
                        dr[InItemData.ITEMNUM_FIELD] = this.txtReqNum.Text;
                        temp_num = decimal.Parse(this.txtReqNum.Text);
                        temp_price = decimal.Parse(this.txtItemPrice.Text);
                        temp_money = temp_num * temp_price;
                        dr[InItemData.ITEMMONEY_FIELD] = temp_money.ToString("0.##");
                        dr[PurchasePlanData.REQREASONCODE_FIELD] = this.ddlPurpose.SelectedValue;
                        dr[PurchasePlanData.REQREASON_FIELD] = this.ddlPurpose.SelectedText;
                        dr[PurchasePlanData.REQDATE_FIELD] = this.txtReqDate.Text;
                        dr[InItemData.REMARK_FIELD] = this.txtRemark.Text;

                    }
                    else//修改后有重复物料，这种情况只会出现在对OTI物料的修改。
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD] = temp_num;
                        this.thisTable.Rows[CurrentRow][InItemData.ITEMMONEY_FIELD] = temp_money;
                        this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//删除原有行。
                    }
                    txtItemSerial.Value = "-1";
                    btnAddItem.Text = "新增";
                }
                this.DGModel_Items1.DataSource = this.thisTable;
                this.DGModel_Items1.DataBind();

                this.hfNewCode.Value = string.Empty;
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtItemSpecial.Text = "";
                this.txtReqNum.Text = "";
                this.ddlUnit.SetItemSelected("-1");
                this.ddlPurpose.SelectedValue = "-1";
                this.ddlPurpose.SelectedText = "";
                this.ddlReqDept.SetItemSelected("-1");
                this.txtReqDate.Text = "";
                this.txtItemPrice.Text = "";
                this.txtRemark.Text = "";
            }
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
                    //int iRow = int.Parse(DGModel_Items1.SelectedID);

                    iRow = -1;
                    strItemCode = DGModel_Items1.SelectedID;
                    for (i = 0; i < thisTable.Rows.Count; i++)
                    {
                        if (strItemCode == this.thisTable.Rows[i]["ItemCode"].ToString())
                        {
                            iRow = i;
                        }
                    }
                    if (iRow > -1)
                    {
                        txtItemSerial.Value = iRow.ToString();

                        this.ddlReqDept.SetItemSelected(this.thisTable.Rows[iRow][PurchasePlanData.REQDEPT_FIELD].ToString());
                        this.hfNewCode.Value = this.thisTable.Rows[iRow][InItemData.NEWCODE_FIELD].ToString();
                        this.txtItemCode.Text = this.thisTable.Rows[iRow][InItemData.ITEMCODE_FIELD].ToString();
                        this.txtItemName.Text = this.thisTable.Rows[iRow][InItemData.ITEMNAME_FIELD].ToString();
                        this.txtItemSpecial.Text = this.thisTable.Rows[iRow][InItemData.ITEMSPECIAL_FIELD].ToString();
                        this.ddlUnit.SetItemSelected(this.thisTable.Rows[iRow][InItemData.ITEMUNIT_FIELD].ToString());
                        this.txtItemPrice.Text = this.thisTable.Rows[iRow][InItemData.ITEMPRICE_FIELD].ToString();
                        this.txtReqNum.Text = this.thisTable.Rows[iRow][InItemData.ITEMNUM_FIELD].ToString();
                        this.ddlPurpose.SelectedValue = this.thisTable.Rows[iRow][PurchasePlanData.REQREASONCODE_FIELD].ToString();
                        this.ddlPurpose.SelectedText = this.thisTable.Rows[iRow][PurchasePlanData.REQREASON_FIELD].ToString();
                        this.txtReqDate.Text = this.thisTable.Rows[iRow][PurchasePlanData.REQDATE_FIELD].ToString();
                        this.txtRemark.Text = this.thisTable.Rows[iRow][InItemData.REMARK_FIELD].ToString();
                        //度量单位

                        btnAddItem.Text = "更新";
                    }
                }
            }
        }

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                SubTotal = 0;

                e.Item.Cells[8].Visible = IsDisplayPPPrice;
                e.Item.Cells[10].Visible = IsDisplayPPPrice;

            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('../Analysis/DocRoute.aspx?EntryNo=" + this.EntryNo.ToString() + "&DocCode=5&SerialNo=" + e.Item.ItemIndex.ToString() + "&ItemCode=" + e.Item.Cells[0].Text + "','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                
                try
                {
                    e.Item.Cells[8].Visible = IsDisplayPPPrice;
                    e.Item.Cells[10].Visible = IsDisplayPPPrice;
                    SubTotal += decimal.Parse(e.Item.Cells[10].Text);
                }
                catch
                {
                    SubTotal += 0;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
            {
                
                e.Item.HorizontalAlign = HorizontalAlign.Center;
               
                e.Item.HorizontalAlign = HorizontalAlign.Right;
                try
                {
                    e.Item.Cells[8].Visible = IsDisplayPPPrice;
                    e.Item.Cells[10].Visible = IsDisplayPPPrice;

                    if (!IsDisplayPPPrice)
                        e.Item.Cells[9].Text = "";
                    e.Item.Cells[10].Text = string.Format("{0:c}", SubTotal);
                }
                catch
                {
                    e.Item.Cells[10].Text = SubTotal.ToString();
                }
            }
        }
	
	}
}
