using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;

namespace MZHMM.WebMM.Modules
{
	/// <summary>
	///	单据上物料部分内容用户控件。
	///	提供了，单据上物料项的增加、修改、删除、显示功能。
	/// </summary>
	public partial class ItemsWebControl : UserControl
	{
		#region 成员变量
		//protected StorageDropdownlist ddlUnit=new StorageDropdownlist();
 //20080408 物料单位名称
//20080408 物料单位ID
		//private static DataTable dt;//定义了一静态的表,用以保存状态数据
//		private string tmpCode;
		private string _OP;
		//protected TextBox txtTaxRate;
		//protected MagicAjax.UI.Controls.AjaxPanel AjaxPanel1;
		//public DGModel_Items DGModel_Items1;

	    private int ret;
	    private int i;

	    private DataColumnCollection columns;

        private ItemData oItemData = new ItemData();

	    private int iRow;

	    private bool bret;

	    private int CurrentRow;
	    private decimal temp_num;
	    private decimal temp_price;
	    private decimal temp_money;

	    private DataRow dr;

	 

		#endregion

		#region 属性

        public bool IsDisplayPrice
        {
            get
            {
                if (ViewState["IsDisplayPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayPrice"] = value;
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

		/// <summary>
		/// 单据类型。
		/// </summary>
		public int DocCode
		{
			get
			{
				if (this.txtDocCode.Value.Length > 0)
				{
					return Convert.ToInt16(this.txtDocCode.Value);
				}
				else
				{
					return 0;
				}
		
			}
			set
			{
				this.txtDocCode.Value = value.ToString();
			}
		}
		/// <summary>
		/// 备注属性。
		/// </summary>
		public string Remark
		{
			get {return this.txtRemark.Text;}
			set {this.txtRemark.Text = value;}
		}
		/// <summary>
		/// 静态数据表。
		/// </summary>
		public DataTable thisTable
		{
			get
			{
                if (Session[MySession.ROS_DT] != null)
                    return (DataTable)Session[MySession.ROS_DT];
                else
                {
                    this.thisTable = new DataTable();

                    columns = this.thisTable.Columns;
                    columns.Add("NewCode");
                    columns.Add("ItemCode");
                    columns.Add("ItemName");
                    columns.Add("ItemSpecial");
                    columns.Add("ItemUnit");
                    columns.Add("ItemUnitName");
                    columns.Add("ItemPrice");
                    columns.Add("ItemNum").DataType = typeof(Decimal);
                    columns.Add("ItemMoney");
                    columns.Add("ReqDate");


                    return thisTable;
                }
					
			}	
			set
			{
				Session[MySession.ROS_DT] = value;
			}
		}
        /// <summary>
        /// 数据表格。
        /// </summary>
	    public Shmzh.Web.UI.Controls.MzhDataGrid MyDataGrid
	    {
            get { return this.DGModel_Items1; }
	    }
		#endregion

		#region 私有方法
		/// <summary>
		/// 在静态表中检查该物料是否已经存在。
		/// </summary>
		/// <param name="ItemCode">string:	要检查的物料编号。</param>
		/// <param name="ItemName"></param>
		/// <param name="ItemSpec"></param>
		/// <returns>int:	没有返回-1，有则返回所在行的行数。</returns>
		private int GetRowByItemCode(string ItemCode, string ItemName, string ItemSpec)
		{
            ret = -1;
            if (ItemCode != "-1")//非OTI物料。
            {
                for (i = 0; i < this.thisTable.Rows.Count; i++)
                {
                    if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode)
                    {
                        return i;
                    }
                }
            }
            else//OTI物料的编号都为-1，所以要进行物料名称和规格型号的判断。
            {
                for (i = 0; i < this.thisTable.Rows.Count; i++)
                {
                    if (this.thisTable.Rows[i][InItemData.ITEMNAME_FIELD].ToString() == ItemName &&
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
            bret = true;
            try
            {
                if ((txtItemCode.Text != "") &&
                    (txtItemName.Text != "") &&
                    (txtReqNum.Text != "") &&
                    (txtReqDate.Text != "") &&
                    (ddlUnit.SelectedValue != "-1"))
                {
                    if (this.DocCode == 2)
                    {
                        if (txtItemCode.Text == "-1")
                        {
                            Page.RegisterStartupScript(  "ItemError", "<script>alert('物料编号、物料名称、单位、申请数量、要求日期不能为空!');</script>");
                   
                            return false;
                        }
                    }
                     Convert.ToDateTime((txtReqDate.Text));
                    if(Convert.ToDecimal(txtReqNum.Text) <= 0)
                    {
                        Page.RegisterStartupScript( "ItemError", "<script>alert(\"申请数量需要大于0 !\");</script>");
                         bret = false;
                    }
                   
                }
                else
                {
                    //this.Response.Write("<script>alert(\"物料编号、物料名称、单位、申请数量、要求日期不能为空！\");</script>");
                    Page.RegisterStartupScript("ItemError", "<script>alert(\"物料编号、物料名称、单位、申请数量、要求日期不能为空!\");</script>");
                    bret = false;
                }
            }
            catch
            {
                Page.RegisterStartupScript( "ItemError", "<script>alert(\"请把物料编号、物料名称、单位、申请数量、要求日期填写正确!\");</script>");
                bret = false;
            }
            return bret;
		}
		#endregion

		#region 事件
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected void Page_Load(object sender, EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            //this.txtItemCode.Attributes.Add("onblur", "funBlur()");
            //this.txtItemCode.Attributes.Add("onkeypress", "funKeypress()");
            //this.btnSelect.OnClientClick = "window.open('../Storage/ItemQuery.aspx?DocCode="+this.DocCode+"','物料查询','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')";
            if (!string.IsNullOrEmpty(Request["Op"]))
            {
                this._OP = this.Request["Op"];
            }
            //if (this._OP == OP.New ||
            //    this._OP == OP.Edit ||
            //    this._OP == OP.Submit)
            //{
            //    this.DGModel_Items1.ColumnsScheme = ColumnScheme.ROSAuthor;
            //}
            //审批模式下，不允许进行单据内容的修改。
            if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
            {
                this.btnAddItem.Enabled = false;
                this.btnEditItem.Enabled = false;
                this.btnDelItem.Enabled = false;
                this.txtRemark.Enabled = false;
            }
            ////初始化
            //DGModel_Items1.SelectedType = DGModel.SelectType.SingleSelect;
            //this.DGModel_Items1.AllowPaging = false;
            //DGModel_Items1.ShowPager = false;
            txtItemPrice.Visible = IsDisplayPrice;
            if ((!this.IsPostBack) && (this.Request["Op"].ToString() == "New"))
            {
                //定义表和数据结构
                if (this.thisTable != null)
                    this.thisTable = null;
                this.thisTable = new DataTable();

                columns = this.thisTable.Columns;
                columns.Add("NewCode");
                columns.Add("ItemCode");
                columns.Add("ItemName");
                columns.Add("ItemSpecial");
                columns.Add("ItemUnit");
                columns.Add("ItemUnitName");
                columns.Add("ItemPrice");
                columns.Add("ItemNum").DataType = typeof(Decimal);
                columns.Add("ItemMoney");
                columns.Add("ReqDate");
                //绑定
                DGModel_Items1.DataSource = this.thisTable;
                DGModel_Items1.DataBind();

                //初始化一些项
                //度量单位
                ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
            }
            else
            {
                if (!this.IsPostBack)
                {
                    //度量单位
                    ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
                }
                DGModel_Items1.DataSource = this.thisTable;
                DGModel_Items1.DataBind();
                //tmpCode=DGModel_Items1.SelectedID;
            }
		}

		
	#endregion

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
                    this.txtItemPrice.ReadOnly = false;
                    this.ddlUnit.Enable = true;
                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

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

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            //添加一行数据并且赋值
            //
            if (DoCheck())
            {
                
                if (btnAddItem.Text == "新增")
                {
                    CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);

                    if (CurrentRow == -1)//静态表中没有过该物料。
                    {
                        dr = this.thisTable.NewRow();
                        dr["NewCode"] = hfNewCode.Value;
                        dr["ItemCode"] = txtItemCode.Text;
                        dr["ItemName"] = txtItemName.Text;
                        dr["ItemSpecial"] = txtItemSpecial.Text;
                        dr["ItemUnit"] = ddlUnit.SelectedValue;
                        dr["ItemUnitName"] = ddlUnit.SelectedText;
                        dr["ItemPrice"] = txtItemPrice.Text;
                        dr["ItemNum"] = txtReqNum.Text;
                        //金额
                        temp_num = decimal.Parse(txtReqNum.Text);
                        temp_price = decimal.Parse(txtItemPrice.Text);
                        temp_money = Math.Round((temp_num * temp_price), 2);

                        dr["ItemMoney"] = temp_money.ToString("0.##");

                        dr["ReqDate"] = txtReqDate.Text;
                        this.thisTable.Rows.Add(dr);
                    }
                    else//静态表中已经存在该物料。
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow]["ItemNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                    }
                }
                else//更新。
                {
                    iRow = int.Parse(txtItemSerial.Value);
                    dr = this.thisTable.Rows[iRow];
                   
                    CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
                    if (CurrentRow == iRow || CurrentRow == -1)//没有重复物料。
                    {
                        dr["NewCode"] = hfNewCode.Value;
                        dr["ItemCode"] = txtItemCode.Text;
                        dr["ItemName"] = txtItemName.Text;
                        dr["ItemSpecial"] = txtItemSpecial.Text;
                        dr["ItemUnit"] = ddlUnit.SelectedValue;
                        dr["ItemUnitName"] = ddlUnit.SelectedText;
                        dr["ItemPrice"] = txtItemPrice.Text;
                        dr["ItemNum"] = txtReqNum.Text;

                        temp_num = decimal.Parse(txtReqNum.Text);
                        temp_price = decimal.Parse(txtItemPrice.Text);
                        temp_money = temp_num * temp_price;
                        dr["ItemMoney"] = temp_money.ToString("0.##");

                        dr["ReqDate"] = txtReqDate.Text;
                    }
                    else//修改后有重复物料，这种情况只会出现在对OTI物料的修改。
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow]["ItemNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                        this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//删除原有行。
                    }

                    txtItemSerial.Value = "-1";
                    btnAddItem.Text = "新增";

                }
                DGModel_Items1.DataSource = this.thisTable;
                DGModel_Items1.DataBind();
                hfNewCode.Value = string.Empty;
                txtItemCode.Text = "";
                txtItemName.Text = "";
                txtItemSpecial.Text = "";
                txtReqNum.Text = "";
                ddlUnit.SetItemSelected("-1");
                txtReqDate.Text = "";
                txtItemPrice.Text = "";
            }
        }

        private int GetRowIndex(string strItemcode)
        {
            for (i = 0; i < thisTable.Rows.Count; i++)
            {
                if (strItemcode == this.thisTable.Rows[i]["ItemCode"].ToString())
                {
                   return  i;
                }
            }

            return -1;
        }


        protected void btnEditItem_Click(object sender, EventArgs e)
        {
            if (txtItemSerial.Value == "-1")
            {
                if (!string .IsNullOrEmpty(this.DGModel_Items1.SelectedID))
                {

                    iRow = GetRowIndex(DGModel_Items1.SelectedID);

                    txtItemSerial.Value = iRow.ToString();
                    hfNewCode.Value = this.thisTable.Rows[iRow]["NewCode"].ToString();
                    txtItemCode.Text = this.thisTable.Rows[iRow]["ItemCode"].ToString();
                    txtItemName.Text = this.thisTable.Rows[iRow]["ItemName"].ToString();
                    txtItemSpecial.Text = this.thisTable.Rows[iRow]["ItemSpecial"].ToString();
                    txtReqNum.Text = Convert.ToDecimal(this.thisTable.Rows[iRow]["ItemNum"].ToString()).ToString("0.##");
                    txtReqDate.Text = Convert.ToDateTime(this.thisTable.Rows[iRow]["ReqDate"].ToString()).ToString("yyyy-MM-dd");
                    txtItemPrice.Text = Convert.ToDecimal(this.thisTable.Rows[iRow]["ItemPrice"].ToString()).ToString("0.000");
                    //度量单位
                    ddlUnit.SetItemSelected(this.thisTable.Rows[iRow]["ItemUnit"].ToString());
                    if (txtItemCode.Text == "-1")//OTI物料。
                    {
                        this.txtItemName.ReadOnly = false;
                        this.txtItemSpecial.ReadOnly = false;
                        this.txtItemPrice.ReadOnly = false;
                        this.ddlUnit.Enable = true;
                    }
                    else//非OTI物料。
                    {
                        this.txtItemName.ReadOnly = true;
                        this.txtItemSpecial.ReadOnly = true;
                        this.txtItemPrice.ReadOnly = true;
                        this.ddlUnit.Enable = false;
                    }
                    btnAddItem.Text = "更新";
                }
            }
        }
        /// <summary>
        /// 删除按钮。
        /// </summary>
        protected void btnDelItem_Click(object sender, EventArgs e)
        {
            if (!string .IsNullOrEmpty(DGModel_Items1.SelectedID))
            {
                
                iRow = GetRowIndex(DGModel_Items1.SelectedID);

                if (iRow > -1)
                {

                    this.thisTable.Rows.RemoveAt(iRow);
                }

                DGModel_Items1.DataSource = this.thisTable;
                DGModel_Items1.DataBind();
               
            }
        }

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[6].Visible = IsDisplayPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('../Analysis/DocRoute.aspx?EntryNo=" + this.EntryNo.ToString() + "&DocCode=1&SerialNo=" + e.Item.ItemIndex.ToString() + "&ItemCode=" + e.Item.Cells[0].Text + "','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                e.Item.Cells[6].Visible = IsDisplayPrice;
            }
        }
	}
}
