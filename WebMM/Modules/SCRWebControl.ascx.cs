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
    using System.Web.UI;
	using MZHMM.WebMM.Modules;
    /// <summary>
	///	单据上物料部分内容用户控件。
	///	提供了，单据上物料项的增加、修改、删除、显示功能。
	/// </summary>
	public partial class SCRWebControl : System.Web.UI.UserControl
	{
		#region 成员变量
		//protected StorageDropdownlist ddlUnit=new StorageDropdownlist();
 //20080408 物料单位名称
//20080408 物料单位ID
		//public static DataTable dt;//定义了一静态的表,用以保存状态数据
		private string tmpCode;
		private string _OP;
		protected System.Web.UI.WebControls.TextBox txtTaxRate;
		//public DGModel_Items DGModel_Items1;
	    private int ret;
	    private int i;
	    private bool bret;
	    private int CurrentRow;
	    private int iRow;

	    private DataRow dr;

	    private ItemData oItemData = new ItemData();
		#endregion

		#region 属性
        /// <summary>
        /// 是否显示单价
        /// </summary>
        public bool IsDisplaySCRPrice
        {
            get
            {
                if (ViewState["IsDisplaySCRPrice"] != null)
                    return bool.Parse(ViewState["IsDisplaySCRPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplaySCRPrice"] = value;
            }
        }


		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.SCR_DT] != null)
					return (DataTable)Session[MySession.SCR_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.SCR_DT] = value;
			}
		}
		public System.Web.UI.WebControls.TextBox TxtRemark
		{
			get{return txtRemark;}
			set{txtRemark=value;}
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
				for (i=0; i < this.thisTable.Rows.Count; i++)
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
			bret=true;
			try
			{
				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtPlanNum.Text!="") &&  (ddlUnit.SelectedValue!="-1"))
				{
					decimal.Parse(txtPlanNum.Text);
					
				}
				else
				{
				    Page.RegisterStartupScript("DoCheck","<script>alert(\"物料编号、物料名称、单位、申请数量、要求日期不能为空！\");</script>");
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
		
	

		#region 事件
		/// <summary>
		/// 页面Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//this.DGModel_Items1.ColumnsScheme=ColumnScheme.SCR;
			// 在此处放置用户代码以初始化页面
            txtItemPrice.Visible = IsDisplaySCRPrice;
			if (!string.IsNullOrEmpty(this.Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//审批模式下，不允许进行单据内容的修改。
			if (this._OP ==OP.Submit||this._OP == OP.FirstAudit || this._OP == OP.SecondAudit || this._OP == OP.ThirdAudit)
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.txtRemark.Enabled = false;
				this.txtItemNum.Enabled=false;
			}
			else if(this._OP == "Discard")
			{
				this.txtItemCode.Visible = true;
				this.txtItemCode.ReadOnly = true;
				this.txtItemName.Visible = true;
				this.txtItemName.ReadOnly = true;
				this.txtItemSpecial.Visible = true;
				this.txtItemSpecial.ReadOnly = true;
				//this.ddlUnit.Visible = true;
				//this.ddlUnit.Enable = false;
					
				this.txtItemPrice.ReadOnly = true;		
				this.txtPlanNum.ReadOnly=true;
					
				this.txtItemNum.Visible = true;
				this.txtItemNum.Enabled = true;
				this.txtItemNum.ReadOnly=false;

				this.txtRemark.Visible = true;
				this.txtRemark.Enabled = true;
				this.txtRemark.ReadOnly = true;
					
									
				this.btnAddItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.btnEditItem.Enabled = true;
				this.txtItemNum.Enabled=true;
			}
			//DGModel_Items1.ColumnsScheme = ColumnScheme.SCR;
			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//初始化
			//DGModel_Items1.ShowPager=false;
			//DGModel_Items1.AllowPaging = false;

			if((!this.IsPostBack) && (this.Request["Op"].ToString()=="New"))
			{
				//定义表和数据结构
				if(this.thisTable!=null) this.thisTable = null;
				this.thisTable=new DataTable();

				DataColumnCollection columns = this.thisTable.Columns;
				columns.Add("ItemCode");
				columns.Add("ItemName");
				columns.Add("ItemSpecial");
				columns.Add("ItemUnit");
				columns.Add("ItemUnitName");
				columns.Add("ItemPrice");
				columns.Add("PlanNum");
				columns.Add("ItemNum");
				columns.Add("ItemMoney");
				
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
				tmpCode=DGModel_Items1.SelectedID;
			}
		}

        /*

		/// <summary>
		/// 页面UnLoad事件。
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//释放静态变量dt
			//this.thisTable=null;
		}
		*/
		

		/*
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
		}*/
		#endregion

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            //
            //添加一行数据并且赋值
            //
            if (DoCheck())
            {
                decimal temp_num, temp_price, temp_money;

                if (btnAddItem.Text == "新增")
                {
                    CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);

                    if (CurrentRow == -1)//静态表中没有过该物料。
                    {
                        dr = this.thisTable.NewRow();
                        dr["ItemCode"] = txtItemCode.Text;
                        dr["ItemName"] = txtItemName.Text;
                        dr["ItemSpecial"] = txtItemSpecial.Text;
                        dr["ItemUnit"] = ddlUnit.SelectedValue;
                        dr["ItemUnitName"] = ddlUnit.SelectedText;
                        dr["ItemPrice"] = txtItemPrice.Text;
                        dr["PlanNum"] = txtPlanNum.Text;
                        dr["ItemNum"] = this.txtItemNum.Text;


                        //金额
                        temp_num = decimal.Parse(txtPlanNum.Text);
                        temp_price = decimal.Parse(txtItemPrice.Text);
                        temp_money = temp_num * temp_price;

                        dr["ItemMoney"] = temp_money.ToString("0.##");


                        this.thisTable.Rows.Add(dr);
                    }
                    else//静态表中已经存在该物料。
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtPlanNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
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
                        dr["ItemCode"] = txtItemCode.Text;
                        dr["ItemName"] = txtItemName.Text;
                        dr["ItemSpecial"] = txtItemSpecial.Text;
                        dr["ItemUnit"] = ddlUnit.SelectedValue;
                        dr["ItemUnitName"] = ddlUnit.SelectedText;
                        dr["ItemPrice"] = txtItemPrice.Text;
                        dr["PlanNum"] = txtPlanNum.Text;

                        if (this._OP == OP.Discard)
                        {
                            if (decimal.Parse(this.txtItemNum.Text) > decimal.Parse(this.txtPlanNum.Text))
                            {
                                Page.RegisterStartupScript( "Error", "<script>alert('实废数量不应大于应废数量!');</script>");
                                this.btnAddItem.Enabled = true;
                                this.btnAddItem.Text = "更新";
                                return;
                            }
                            temp_num = decimal.Parse(txtItemNum.Text);
                            dr["ItemNum"] = txtItemNum.Text;
                        }
                        else
                        temp_num = decimal.Parse(txtPlanNum.Text);
                        temp_price = decimal.Parse(txtItemPrice.Text);
                        temp_money = temp_num * temp_price;
                        dr["ItemMoney"] = temp_money.ToString("0.##");


                    }
                    else//修改后有重复物料，这种情况只会出现在对OTI物料的修改。
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemNum"].ToString()) + Convert.ToDecimal(txtPlanNum.Text);
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

                txtItemCode.Text = "";
                txtItemName.Text = "";
                txtItemSpecial.Text = "";
                txtPlanNum.Text = "";
                txtItemNum.Text = "";
                ddlUnit.SetItemSelected("-1");

                txtItemPrice.Text = "";
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

                if (iRow > -1)
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

                        txtItemCode.Text = this.thisTable.Rows[iRow]["ItemCode"].ToString();
                        txtItemName.Text = this.thisTable.Rows[iRow]["ItemName"].ToString();
                        txtItemSpecial.Text = this.thisTable.Rows[iRow]["ItemSpecial"].ToString();
                        txtPlanNum.Text = this.thisTable.Rows[iRow]["PlanNum"].ToString();
                        txtItemNum.Text = this.thisTable.Rows[iRow]["ItemNum"].ToString();
                        txtItemPrice.Text = this.thisTable.Rows[iRow]["ItemPrice"].ToString();
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
                        btnAddItem.Enabled = true;
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
                    this.txtItemPrice.ReadOnly = true;
                    this.ddlUnit.Enable = false;
                    //
                    //需要从物料数据库中获取
                    //
                    oItemData = new ItemData();
                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    //存在物料数据
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
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
                    oItemData = new ItemData();
                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        //度量单位
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }
                }
            }
        }

       

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[5].Visible = IsDisplaySCRPrice;
                e.Item.Cells[8].Visible = IsDisplaySCRPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[5].Visible = IsDisplaySCRPrice;
                e.Item.Cells[8].Visible = IsDisplaySCRPrice;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[5].Visible = IsDisplaySCRPrice;
                e.Item.Cells[8].Visible = IsDisplaySCRPrice;
            }
        }
	}
}
