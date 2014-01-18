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
	//using MZHCommon.PageStyle;
    using System.Web.UI;

	/// <summary>
	///	单据上物料部分内容用户控件。
	///	提供了，单据上物料项的增加、修改、删除、显示功能。
	/// </summary>
	public partial class WINWWebControl : System.Web.UI.UserControl
	{
        //private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		#region 成员变量
		private decimal TotalResMoney;
		//protected StorageDropdownlist ddlUnit;
		
		private string tmpCode;
		private string _OP;
		//public DGModel_Items DGModel_Items1;
		protected System.Web.UI.WebControls.Button btnCancelItem;
		protected System.Web.UI.WebControls.Button btnCancelWres;
		//protected StorageDropdownlist ddlResUnit;
		protected System.Web.UI.WebControls.Label lblResUnit; //20080408 物料单位名称
		protected HtmlInputHidden txtItemResUnit;//20080408 物料单位ID

	    private int i;
	    private int ret;
	    private bool bret;
	    private decimal ItemMoney;
	    private decimal ItemNum;
	    private decimal TotalItemMoney;
        private decimal SubTotalFee;

	    private int CurrentRow;

	    private decimal temp_num;
	    private decimal temp_price;
	    private decimal temp_money;

	    private ItemData oItemData = new ItemData();

        
        decimal TotalMoney;
       
        decimal ItemFee;
        decimal TempTotalFee;

	    private int iRow;

	    private DataRow dr;

	    private string WTOW_EntryNos;

	    private int PSerialNo;

	    private WINWData oWINWData = new WINWData();

	    private int SourceEntryNo;
	    private int SourceDocCode;
	    private int SourceSerialNo;

	    private DataRow oRow;
	    
	   
		#endregion

		#region 属性

        /// <summary>
        /// 是否显示单价
        /// </summary>
        public bool IsDisplayWINWPrice
        {
            get
            {
                if (ViewState["IsDisplayWINWPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayWINWPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayWINWPrice"] = value;
            }
        }

		public string Op
		{
			get 
			{
				if (this.Request["OP"] != null && this.Request["OP"].ToString() != "")
				{
					return this.Request["OP"].ToString();
				}
				else
				{
					return "View";
				}
			}
		}
		/// <summary>
		/// 委外加工收料表收料子表。
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.WDIW_DT] != null)
					return (DataTable)Session[MySession.WDIW_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.WDIW_DT] = value;
			}
		}
		/// <summary>
		/// 委外加工收料表消耗子表。
		/// </summary>
		public DataTable WRESTable
		{
			get 
			{
				if (Session[MySession.WRES_DT] != null)
					return (DataTable)Session[MySession.WRES_DT];
				else
					return null;
			}
			set
			{
				Session[MySession.WRES_DT] = value;
			}
		}
		/// <summary>
		/// 备注属性。
		/// </summary>
		public string Remark
		{
			get {return this.txtRemark.Text;}
			set { this.txtRemark.Text = value;}
		}
		/// <summary>
		/// 加工费用。
		/// </summary>
		public decimal TotalFee
		{
			get 
			{
				try
				{
					return Convert.ToDecimal(this.txtTotalFee.Text);
				}
				catch
				{
					return 0;
				}
			}
			set{ this.txtTotalFee.Text = value.ToString(); }
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 在收料静态表中检查该物料是否已经存在。
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
					if (this.thisTable.Rows[i][WINWData.ItemCode_Field].ToString() == ItemCode)
					{
						return i;
					}
				}
			}
			else//OTI物料的编号都为-1，所以要进行物料名称和规格型号的判断。
			{
				for (i=0; i < this.thisTable.Rows.Count; i++)
				{
					if (this.thisTable.Rows[i][WINWData.ItemName_Field].ToString() == ItemName &&
						this.thisTable.Rows[i][WINWData.ItemSpec_Field].ToString() == ItemSpec)
					{
						return i;
					}
				}							  
			}

			return ret;
		}

       
		/// <summary>
		/// 根据数据来源来查找是否已经存在记录。
		/// </summary>
        /// <param name="SourceEntryNo">int:	源单据流水号。</param>
        /// <param name="SourceDocCode">int:	源单据类型号。</param>
        /// <param name="SourceSerialNo">int:	源单据顺序号。</param>
		/// <returns>int:	记录在消耗表中的行号。-1表示没有。</returns>
		private int GetRowBySource(int SourceEntryNo, int SourceDocCode, int SourceSerialNo)
		{
			ret = -1;
			for (int i = 0; i< this.WRESTable.Rows.Count; i++)
			{
				if (this.WRESTable.Rows[i][WINWData.SourceEntryNo_Field].ToString() == SourceEntryNo.ToString() &&
					this.WRESTable.Rows[i][WINWData.SourceDocCode_Field].ToString() == SourceDocCode.ToString() &&
					this.WRESTable.Rows[i][WINWData.SouceSerialNo_Field].ToString() == SourceSerialNo.ToString())
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
				if((txtItemCode.Text != "") && (txtItemName.Text != "") && (txtReqNum.Text != "") && (ddlUnit.SelectedValue != "-1"))
				{
					if(txtItemNum.Text != "")
						decimal.Parse(txtItemNum.Text);
				}
				else
				{
					//this.Response.Write("<script>alert(\"物料编号、物料名称、单位、应收数量不能为空！\");</script>");
					Page.RegisterStartupScript("DoCheck","<script>alert(\"物料编号、物料名称、单位、应收数量不能为空！\");</script>");
                    //Page.RegisterStartupScript(this.btnAddItem, this.GetType(), "DoCheck", "alert(\"物料编号、物料名称、单位、应收数量不能为空！\");", true);
					//Page.RegisterStartupScript("Status","<script>function addblockfun(){ if(document.readyState==\"complete\"){document.getElementById(\"TableControl_Items\").className = \"Tableadd\";}}document.onreadystatechange=addblockfun;</script>");
					bret = false;
				}
			}
			catch
			{
				bret = false;
			}
			return bret;
		}
		/// <summary>
		/// 消耗表数据修改检验。
		/// </summary>
		/// <returns>bool:	校验通过返回true，失败返回false。</returns>
		private bool DoCheckRes()
		{
			bret = true;
			try
			{
				 Convert.ToDecimal(this.txtResNum.Text);
			}
			catch
			{
				//this.Response.Write("<script>alert(\"消耗数量不能为空！\");</script>");
				Page.RegisterStartupScript("DoCheckRes","<script>alert(\"消耗数量不能为空！\");</script>");
                //ScriptManager.RegisterStartupScript(this.btnAddItem, this.GetType(), "DoCheckRes", "alert(\"消耗数量不能为空！\");", true);
				//Page.RegisterStartupScript("Status","<script>function addblockfun(){ if(document.readyState==\"complete\"){document.getElementById(\"TableControl_Wres\").className = \"Tableadd\";}}document.onreadystatechange=addblockfun;</script>");
				bret = false;
			}
			return bret;
		}
		/// <summary>
		/// 计算成品的原材料成本。
		/// </summary>
		/// <param name="PSerialNo">int:	对应的产品序号。</param>
		/// <returns>decimal:	原材料成本。</returns>
		private decimal CalcItemMoney(int PSerialNo)
		{
			ItemMoney = 0;
			for (int i = 0; i< this.WRESTable.Rows.Count; i++)
			{
				if (Convert.ToInt16(this.WRESTable.Rows[i][WINWData.PSerialNo_Field].ToString()) == PSerialNo)
				{
					ItemMoney += Convert.ToDecimal(this.WRESTable.Rows[i][WINWData.ResMoney_Field].ToString());
				}
			}
			return ItemMoney;
		}
		
		/// <summary>
		/// 重新计算所有产品的原材料成本以及单价。
		/// </summary>
		private void CalcItemMoney()
		{
			ItemNum = 0;
           // Logger.Info("CalcItemMoney:thisTable.Rows.Count=" + thisTable.Rows.Count);
			for (int i=0; i< this.thisTable.Rows.Count; i++)
			{
				this.thisTable.Rows[i][WINWData.ItemMoney_Field] = this.CalcItemMoney(i);
				if (this.Op == OP.I)
				{
					try
					{
						ItemNum = Convert.ToDecimal(this.thisTable.Rows[i][WINWData.ItemNum_Field].ToString());
					}
					catch
					{
					    ItemNum = 0;
					}
				}
				else
				{
					try
					{
						ItemNum = Convert.ToDecimal(this.thisTable.Rows[i][WINWData.PlanNum_Field].ToString());
					}
					catch
					{
                        ItemNum = 0;
					    
					}
				}
				try
				{
					this.thisTable.Rows[i][WINWData.ItemPrice_Field] = Math.Round(Convert.ToDecimal(this.thisTable.Rows[i][WINWData.ItemMoney_Field].ToString())/ItemNum,3);
				}
				catch
				{
                   // Logger.Info("CalcItemMoney="+ex.Message);
				    //this.thisTable.Rows[i][WINWData.ItemPrice_Field] = 0;
				    
				}
			}
		}
		/// <summary>
		/// 计算产品的总的原材料成本。
		/// </summary>
		/// <returns>decimal:	总的原材料成本。</returns>
		private decimal CalcPrdTotalItemMoney()
		{
			TotalItemMoney = 0;
			for (i=0; i< this.thisTable.Rows.Count; i++)
			{
				TotalItemMoney += Convert.ToDecimal(this.thisTable.Rows[i][WINWData.ItemMoney_Field].ToString());
			}
			return TotalItemMoney;
		}
		/// <summary>
		/// 计算产品分摊的总的加工费用。
		/// </summary>
		/// <returns>decimal:	总的加工费用。</returns>
		private decimal CalcPrdTotalFee()
		{
            SubTotalFee = 0;
			for (i=0; i< this.thisTable.Rows.Count; i++)
			{
                SubTotalFee += Convert.ToDecimal(this.thisTable.Rows[i][WINWData.ItemFee_Field].ToString());
			}
            return SubTotalFee;
		}
		/// <summary>
		/// 分摊加工费用。
		/// </summary>
        private void CalcItemFee()
		{
			//decimal TotalMoney;
			//decimal ItemMoney;
			//decimal ItemFee;
			//decimal TempTotalFee;

			if (!string.IsNullOrEmpty(this.txtTotalFee.Text))
			{
                SubTotalFee = Convert.ToDecimal(this.txtTotalFee.Text);
                if (SubTotalFee < 0) SubTotalFee = 0;
			}
			TotalMoney = this.CalcPrdTotalItemMoney();
			if (TotalMoney > 0)
			{
				for (i = 0; i< this.thisTable.Rows.Count; i++)
				{
					ItemMoney = Convert.ToDecimal(this.thisTable.Rows[i][WINWData.ItemMoney_Field].ToString());
					ItemFee = Math.Round(TotalFee*ItemMoney/TotalMoney,2);
					this.thisTable.Rows[i][WINWData.ItemFee_Field] = ItemFee;
				}
				TempTotalFee = this.CalcPrdTotalFee();
				if (TempTotalFee != TotalFee && this.thisTable.Rows.Count > 0)//如果产生差额，由第一个产品来承担。
				{
					//此处暂不考虑产生的差额大于分摊费用的情况。几乎不可能。
					this.thisTable.Rows[0][WINWData.ItemFee_Field] = Convert.ToDecimal(this.thisTable.Rows[0][WINWData.ItemFee_Field].ToString()) - (TempTotalFee - TotalFee);
				}
			}
		}
		/// <summary>
		/// 计算产品成本。
		/// </summary>
		private void CalcItemSum()
		{
			//decimal ItemMoney = 0;
			//decimal ItemFee = 0;
			for (i= 0; i< this.thisTable.Rows.Count; i++)
			{
				try
				{
					ItemMoney = Convert.ToDecimal(this.thisTable.Rows[i][WINWData.ItemMoney_Field].ToString());
				}
				catch
				{
					ItemMoney = 0;
				}
				try
				{
					ItemFee = Convert.ToDecimal(this.thisTable.Rows[i][WINWData.ItemFee_Field].ToString());
				}
				catch
				{
					ItemFee = 0;
				}

				this.thisTable.Rows[i][WINWData.ItemSum_Field] = ItemMoney + ItemFee;
			}
		}
		/// <summary>
		/// 计算产品的原材料成本、单价、加工费用、总成本等。
		/// </summary>
		private void Calc_Product_Price_Money_Fee_Sum()
		{
           // Logger.Info("CalcItemMoney");
			this.CalcItemMoney();//包括了单价。
            //Logger.Info("CalcItemFee");
			this.CalcItemFee();
           // Logger.Info("CalcItemSum");
			this.CalcItemSum();
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
            else
                this._OP = "";

            this.txtItemPrice.Visible = IsDisplayWINWPrice;
            txtResPrice.Visible = IsDisplayWINWPrice;

            //if (this._OP == "View")
            //{
            //    CommonStyle.InitDataGridStyle(this.DGModel_WRES1,false,CommonStyle.StyleScheme.Printer);
            //}
            //else
            //{
            //    CommonStyle.InitDataGridStyle(this.DGModel_WRES1,false,CommonStyle.StyleScheme.HotMail);
            //}
			this.TotalResMoney = 0;
			//if (!this.IsPostBack)
            //{
            //    switch (this._OP)
            //    {
            //        case OP.New:
            //            this.DGModel_Items1.ColumnsScheme = ColumnScheme.WINWAuthor;
            //            break;
            //        case OP.Edit:
            //            this.DGModel_Items1.ColumnsScheme = ColumnScheme.WINWAuthor;
            //            break;
            //        case OP.Submit:
            //            this.DGModel_Items1.ColumnsScheme = ColumnScheme.WINWAuthor;
            //            break;
            //        case OP.FirstAudit:
            //            this.DGModel_Items1.ColumnsScheme = ColumnScheme.WINW;
            //            break;
            //        case OP.SecondAudit:
            //            this.DGModel_Items1.ColumnsScheme = ColumnScheme.WINW;
            //            break;
            //        case OP.ThirdAudit:
            //            this.DGModel_Items1.ColumnsScheme = ColumnScheme.WINW;
            //            break;
            //        case OP.I:
            //            this.DGModel_Items1.ColumnsScheme = ColumnScheme.WINW;
            //            break;
            //        case OP.Red:
            //            this.DGModel_Items1.ColumnsScheme = ColumnScheme.WINWAuthor;
            //            break;
            //    }
            //}
			//审批模式下，不允许进行单据内容的修改。
			if (this._OP == OP.FirstAudit || this._OP == OP.SecondAudit || this._OP == OP.ThirdAudit || this._OP ==OP.Submit || this._OP == OP.Red )
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.txtRemark.Enabled = false;
				this.txtItemCode.ReadOnly = true;
				this.txtItemName.ReadOnly = true;
				this.txtItemSpecial.ReadOnly = true;
				this.txtReqNum.ReadOnly = true;
				this.txtItemPrice.ReadOnly = true;
				this.txtItemNum.ReadOnly = true;
				this.ddlUnit.Enable = false;
				this.btnWWBrowser.Disabled = true;
				this.btnResUpdate.Enabled = false;
				this.btnresDelete.Enabled = false;
				this.btnResEdit.Enabled = false;
				this.txtResNum.ReadOnly = true;
			}
			//发料模式下。
			if (this._OP == OP.I)
			{
				this.btnAddItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.txtRemark.ReadOnly = true;
				this.txtItemCode.ReadOnly = true;
				this.txtItemName.ReadOnly = true;
				this.txtItemSpecial.ReadOnly = true;
				this.ddlUnit.Enable = false;
				this.txtItemPrice.ReadOnly = true;
				this.txtReqNum.ReadOnly = true;
				this.btnWWBrowser.Disabled = true;
				this.btnResUpdate.Enabled = false;
				this.btnresDelete.Enabled = false;
				this.btnResEdit.Enabled = false;
				this.txtResNum.ReadOnly = true;
                txtTotalFee.ReadOnly = true;
			}
			else
				this.txtItemNum.ReadOnly = true;
			//this.DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//初始化
			//this.DGModel_Items1.ShowPager = false;

            if ((!this.IsPostBack) && (this._OP == "New"))
			{
				//定义表和数据结构
				if(this.thisTable != null) 
					this.thisTable.Dispose();
				this.thisTable = new DataTable();
				this.thisTable.Columns.Add("ItemCode").DataType = typeof(System.String);
				this.thisTable.Columns.Add("ItemName").DataType = typeof(System.String);
				this.thisTable.Columns.Add("ItemSpecial").DataType = typeof(System.String);
				this.thisTable.Columns.Add("ItemUnit").DataType = typeof(System.Int16);
				this.thisTable.Columns.Add("ItemUnitName").DataType = typeof(System.String);
				this.thisTable.Columns.Add("ItemPrice").DataType = typeof(System.Decimal);
				this.thisTable.Columns.Add("PlanNum").DataType = typeof(System.Decimal);
				this.thisTable.Columns.Add("ItemNum").DataType = typeof(System.Decimal);
				this.thisTable.Columns.Add("ItemFee").DataType = typeof(System.Decimal);
				this.thisTable.Columns.Add("ItemMoney").DataType = typeof(System.Decimal);
				this.thisTable.Columns.Add("ItemSum").DataType = typeof(System.Decimal);
				if(this.WRESTable != null) 
					this.WRESTable.Dispose();
				this.WRESTable = new DataTable();
				this.WRESTable.Columns.Add("ResSerialNo").DataType = typeof(System.Int16);
				this.WRESTable.Columns.Add("SourceEntryNo").DataType = typeof(System.Int32);
				this.WRESTable.Columns.Add("SourceDocCode").DataType = typeof(System.Int16);
				this.WRESTable.Columns.Add("SourceSerialNo").DataType = typeof(System.Int16);
				this.WRESTable.Columns.Add("PSerialNo").DataType = typeof(System.Int16);
				this.WRESTable.Columns.Add("ResCode").DataType = typeof(System.String);
				this.WRESTable.Columns.Add("ResName").DataType = typeof(System.String);
				this.WRESTable.Columns.Add("ResSpecial").DataType = typeof(System.String);
				this.WRESTable.Columns.Add("ResUnit").DataType = typeof(System.Int16);
				this.WRESTable.Columns.Add("ResUnitName").DataType = typeof(System.String);
				this.WRESTable.Columns.Add("ResPrice").DataType = typeof(System.Decimal);
				this.WRESTable.Columns.Add("ResNum").DataType = typeof(System.Decimal);
				this.WRESTable.Columns.Add("ResMoney").DataType = typeof(System.Decimal);
				//绑定
				this.DGModel_Items1.DataSource = this.thisTable;				
				this.DGModel_Items1.DataBind();
				this.DGModel_WRES1.DataSource = this.WRESTable;
				this.DGModel_WRES1.DataBind();
				//初始化一些项
				//度量单位
				ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
				ddlResUnit.Module_Tag = (int)SDDLTYPE.UNIT;
			}
			else
			{
				if(!this.IsPostBack)
				{
					//度量单位
					this.ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
					this.ddlResUnit.Module_Tag = (int)SDDLTYPE.UNIT;
				}
				this.DGModel_Items1.DataSource = this.thisTable;				
				this.DGModel_Items1.DataBind();
				this.DGModel_WRES1.DataSource = this.WRESTable;
				this.DGModel_WRES1.DataBind();
				tmpCode = this.DGModel_Items1.SelectedID;
			}
		}

		/// <summary>
		/// 页面UnLoad事件。
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//释放静态变量dt
			//this.thisTable.Dispose();
			//this.WRESTable.Dispose();
		}
		/// <summary>
		/// 增加按钮。
		/// </summary>
		protected void btnAddItem_Click(object sender, System.EventArgs e)
		{
			//
			//添加一行数据并且赋值
			//
            try
            {
                if (DoCheck())
                {
                    if (btnAddItem.Text == "新增")
                    {
                        CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);

                        if (CurrentRow == -1)//静态表中没有过该物料。
                        {
                            if (thisTable.Rows.Count >= 1)
                            {
                                Page.RegisterStartupScript( "Error", "<script>alert('提醒：只能有一条物料信息!');</script>");
                                return;
                            }
                            else
                            {
                                dr = this.thisTable.NewRow();
                                dr["ItemCode"] = this.txtItemCode.Text;
                                dr["ItemName"] = this.txtItemName.Text;
                                dr["ItemSpecial"] = this.txtItemSpecial.Text;
                                dr["ItemUnit"] = Convert.ToInt16(this.ddlUnit.SelectedValue);
                                dr["ItemUnitName"] = this.ddlUnit.SelectedText;
                                //dr["ItemUnit"] = txtItemUnit.Value;  //20080418 物料单位ID
                                //dr["ItemUnitName"] = lblUnit.Text;	//20080418 物料单位名称
                                //dr["StockNum"] = this.GetStockSumByItem(txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
                                //dr["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode, txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
                                dr["ItemPrice"] = Convert.ToDecimal(this.txtItemPrice.Text);
                                dr["PlanNum"] = Convert.ToDecimal(this.txtReqNum.Text);
                                dr["ItemNum"] = 0;
                                //金额
                                temp_num = decimal.Parse(txtReqNum.Text);
                                temp_price = decimal.Parse(txtItemPrice.Text);
                                temp_money = temp_num * temp_price;
                                dr["ItemMoney"] = temp_money;
                                dr["ItemSum"] = temp_money;
                                this.thisTable.Rows.Add(dr);
                            }
                        }
                        else//静态表中已经存在该物料。
                        {
                            //temp_num = Convert.ToDecimal(dt.Rows[CurrentRow]["ItemNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                            temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                            temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                            temp_money = temp_num * temp_price;
                            this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
                            this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                        }
                    }
                    else //更新
                    {
                        iRow = int.Parse(txtItemSerial.Value);
                        dr = this.thisTable.Rows[iRow];
                        CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
                        if (CurrentRow == iRow || CurrentRow == -1)//没有重复物料。
                        {
                            dr["ItemCode"] = this.txtItemCode.Text;
                            dr["ItemName"] = this.txtItemName.Text;
                            dr["ItemSpecial"] = this.txtItemSpecial.Text;
                            dr["ItemUnit"] = Convert.ToInt16(this.ddlUnit.SelectedValue);
                            dr["ItemUnitName"] = this.ddlUnit.SelectedText;
                            //dr["ItemUnit"] = txtItemUnit.Value;  //20080418 物料单位ID
                            //dr["ItemUnitName"] = lblUnit.Text;	//20080418 物料单位名称

                            //dr["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode, txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
                            //dr["StockNum"] = this.GetStockSumByItem(txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
                            dr["ItemPrice"] = Convert.ToDecimal(this.txtItemPrice.Text);
                            dr["PlanNum"] = Convert.ToDecimal(this.txtReqNum.Text);
                            if (this.txtItemNum.Text != "" && this.txtItemNum.Text != null)
                                dr["ItemNum"] = Convert.ToDecimal(this.txtItemNum.Text);

                            temp_num = decimal.Parse(txtReqNum.Text);
                            temp_price = decimal.Parse(txtItemPrice.Text);
                            temp_money = temp_num * temp_price;
                            dr["ItemMoney"] = temp_money;
                        }
                        else//修改后有重复物料，这种情况只会出现在对OTI物料的修改。
                        {
                            temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                            temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                            temp_money = Math.Round((temp_num * temp_price), 2);
                            this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
                            this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                            this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//删除原有行。
                        }
                        this.txtItemSerial.Value = "-1";
                        this.btnAddItem.Text = "新增";
                        this.btnEditItem.Enabled = true;
                        SetButtonStatus();

                        //Page.RegisterStartupScript("addblock","<script>function addblockfun(){ if(document.readyState==\"complete\"){document.getElementById(\"TableControl_Items\").className = \"TableaddHidden\";}}document.onreadystatechange=addblockfun;document.getElementById(\"btnenterinput\").value='确认';</script>");
                        if (this._OP == OP.I)
                        {
                            this.btnAddItem.Enabled = false;
                        }
                    }
                    //Logger.Info("Calc_Product_Price_Money_Fee_Sum:start=" + DateTime.Now.ToString());
                    this.Calc_Product_Price_Money_Fee_Sum();//重新计算成本。
                   // Logger.Info("Calc_Product_Price_Money_Fee_Sum:end="+DateTime.Now.ToString());
                    this.DGModel_Items1.DataSource = this.thisTable;
                    this.DGModel_Items1.DataBind();
                    this.DGModel_WRES1.DataSource = this.WRESTable;
                    this.DGModel_WRES1.DataBind();
                    txtItemCode.Text = "";
                    txtItemName.Text = "";
                    txtItemSpecial.Text = "";
                    txtReqNum.Text = "";
                    this.txtItemNum.Text = "";
                    ddlUnit.SetItemSelected("-1");
                    //txtItemUnit.Value="-1";  //20080418 还原物料单位ID默认值
                    //lblUnit.Text="";	//20080418 还原物料单位名称默认值

                    //txtReqDate.Text="";
                    txtItemPrice.Text = "";
                }
            }
            catch
            {
               // Logger.Error(ex.Message);
            }
		}

		/// <summary>
		/// 编辑按钮。
		/// </summary>
		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			//不等于-1表示已经处于编辑状态
			if(txtItemSerial.Value == "-1")
			{
				if (!string.IsNullOrEmpty(this.DGModel_Items1.SelectedID))
				{
					//iRow=int.Parse(DGModel_Items1.SelectedID);
                    iRow = GetRowIndex(DGModel_Items1.SelectedID);
                    
                    if(iRow > -1)
                    {

					    this.txtItemSerial.Value=iRow.ToString();

					    this.txtItemCode.Text=this.thisTable.Rows[iRow]["ItemCode"].ToString();
					    this.txtItemName.Text=this.thisTable.Rows[iRow]["ItemName"].ToString();
					    this.txtItemSpecial.Text=this.thisTable.Rows[iRow]["ItemSpecial"].ToString();
    					
					    if (this.thisTable.Rows[iRow]["ItemNum"] != null && this.thisTable.Rows[iRow]["ItemNum"].ToString() != "")
					    {
						    this.txtItemNum.Text = Convert.ToDecimal(this.thisTable.Rows[iRow]["ItemNum"].ToString()).ToString("0.##");
					    }

					    this.txtReqNum.Text = Convert.ToDecimal(this.thisTable.Rows[iRow]["PlanNum"].ToString()).ToString("0.##");
					    this.txtItemPrice.Text=Convert.ToDecimal(this.thisTable.Rows[iRow]["ItemPrice"].ToString()).ToString("0.000");
					    //度量单位
                        this.ddlUnit.SetItemSelected(this.thisTable.Rows[iRow]["ItemUnit"].ToString());
                        //this.txtItemUnit.Value=this.thisTable.Rows[iRow]["ItemUnit"].ToString();  //20080418 获取物料单位ID
                        //this.lblUnit.Text=this.thisTable.Rows[iRow]["ItemUnitName"].ToString();;	//20080418 获取物料单位名称

					    this.btnAddItem.Text="更新";
    					
					    btnAddItem.Enabled = true;

					    btnEditItem.Enabled=false;
					    btnDelItem.Enabled=false;



					    //Page.RegisterStartupScript("addblock","<script>function addblockfun(){ if(document.readyState==\"complete\"){document.getElementById(\"TableControl_Items\").className = \"Tableadd\";}}document.onreadystatechange=addblockfun;document.getElementById(\"btnenterinput\").value='更新';</script>");
                    }
                }
			}
			else
			{
				//Page.RegisterStartupScript("addblock","<script>function addblockfun(){ if(document.readyState==\"complete\"){document.getElementById(\"TableControl_Items\").className = \"Tableadd\";}}document.onreadystatechange=addblockfun;document.getElementById(\"btnenterinput\").value='更新';</script>");
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

		/// <summary>
		/// 删除按钮。
		/// </summary>
		protected void btnDelItem_Click(object sender, System.EventArgs e)
		{
			if(!string.IsNullOrEmpty(this.DGModel_Items1.SelectedID))
			{
                iRow = GetRowIndex(DGModel_Items1.SelectedID);
                if (iRow > -1)
                {
                    this.thisTable.Rows.RemoveAt(iRow);
                    this.Calc_Product_Price_Money_Fee_Sum();//重新计算成本。
                }
				this.DGModel_Items1.DataSource = this.thisTable;
				this.DGModel_Items1.DataBind();
			}
		}
		/// <summary>
		/// 消耗列表更新按钮事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnResUpdate_Click(object sender, System.EventArgs e)
		{
			if(DoCheckRes())
			{
				//decimal temp_num,temp_price,temp_money;
				iRow = int.Parse(this.txtResSerial.Value);

                if (iRow > -1)
                {
                    dr = this.WRESTable.Rows[iRow];

                    if (!string.IsNullOrEmpty(this.txtPSerialNo.Text))
                    {
                        dr["PSerialNo"] = Convert.ToInt16(this.txtPSerialNo.Text);
                    }
                    else
                    {
                        dr["PSerialNo"] = 0;
                    }
                    if (!string.IsNullOrEmpty(this.txtResNum.Text))
                        dr["ResNum"] = Convert.ToDecimal(this.txtResNum.Text);

                    temp_num = Convert.ToDecimal(dr["ResNum"].ToString());
                    temp_price = Convert.ToDecimal(dr["ResPrice"].ToString());
                    temp_money = Math.Round(temp_num * temp_price, 2);
                    dr["ResMoney"] = temp_money;

                    this.txtItemSerial.Value = "-1";
                    if (this._OP == OP.I)
                    {
                        this.btnAddItem.Enabled = false;
                    }
                    this.Calc_Product_Price_Money_Fee_Sum();//重新计算成本。
                    this.DGModel_Items1.DataSource = this.thisTable;
                    this.DGModel_Items1.DataBind();
                    this.DGModel_WRES1.DataSource = this.WRESTable;
                    this.DGModel_WRES1.DataBind();
                    //复位。
                    this.txtPSerialNo.Text = "";
                    this.txtResCode.Text = "";
                    this.txtResName.Text = "";
                    this.txtResSpecial.Text = "";
                    this.txtResNum.Text = "";
                    this.txtResPrice.Text = "";
                    this.ddlResUnit.SetItemSelected("-1");
                    //txtItemResUnit.Value = "-1";  //20080418 物料单位ID初始化
                    //lblResUnit.Text = "";	//20080418 物料单位名称初始化

                    SetResButtonStatus();
                }
			}
		}
		/// <summary>
		///  消耗列表删除按钮事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnresDelete_Click(object sender, System.EventArgs e)
		{
			if(!string.IsNullOrEmpty(this.DGModel_WRES1.SelectedID))
			{
				iRow = int.Parse(this.DGModel_WRES1.SelectedID);

				this.WRESTable.Rows.RemoveAt(iRow);
				this.Calc_Product_Price_Money_Fee_Sum();//重新计算成本。
				this.DGModel_WRES1.DataSource=this.WRESTable;
				this.DGModel_WRES1.DataBind();
				this.DGModel_Items1.DataSource = this.thisTable;
				this.DGModel_Items1.DataBind();
			}
		}
		/// <summary>
		///  消耗列表编辑按钮事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnResEdit_Click(object sender, System.EventArgs e)
		{
			//不等于-1表示已经处于编辑状态
            if (!string.IsNullOrEmpty(this.DGModel_WRES1.SelectedID))
            {
                iRow = int.Parse(DGModel_WRES1.SelectedID);

                if (iRow > -1)
                {
                    this.txtResSerial.Value = iRow.ToString();

                    this.txtResCode.Text = this.WRESTable.Rows[iRow]["ResCode"].ToString();
                    this.txtResName.Text = this.WRESTable.Rows[iRow]["ResName"].ToString();
                    this.txtResSpecial.Text = this.WRESTable.Rows[iRow]["ResSpecial"].ToString();

                    if (this.WRESTable.Rows[iRow]["ResNum"] != null && this.WRESTable.Rows[iRow]["ResNum"].ToString() != "")
                    {
                        this.txtResNum.Text = Convert.ToDecimal(this.WRESTable.Rows[iRow]["ResNum"].ToString()).ToString("0.##");
                    }

                    //this.txtReqNum.Text = Convert.ToDecimal(this.thisTable.Rows[iRow]["PlanNum"].ToString()).ToString("0.##");
                    this.txtResPrice.Text = Convert.ToDecimal(this.WRESTable.Rows[iRow]["ResPrice"].ToString()).ToString("0.000");
                    //度量单位
                    this.ddlResUnit.SetItemSelected(this.WRESTable.Rows[iRow]["ResUnit"].ToString());
                    // txtItemResUnit.Value = this.WRESTable.Rows[iRow]["ResUnit"].ToString();  //20080418 获取物料单位ID
                    // lblResUnit.Text = this.WRESTable.Rows[iRow]["ResUnitName"].ToString();	//20080418 获取物料单位名称
                    try
                    {
                        ddlResUnit.SelectedValue = WRESTable.Rows[iRow]["ResUnit"].ToString();
                    }
                    catch { }
                    this.btnResUpdate.Text = "更新";
                    this.btnResUpdate.Enabled = true;

                    btnResEdit.Enabled = false;
                    btnresDelete.Enabled = false;



                }

                //Page.RegisterStartupScript("addblock","<script>function addblockfun(){ if(document.readyState==\"complete\"){document.getElementById(\"TableControl_Wres\").className = \"Tableadd\";}}document.onreadystatechange=addblockfun;document.getElementById(\"btnenterinput\").value='更新';</script>");
            }
			
		}
		/// <summary>
		/// 物料编号绑定的隐藏按钮。
		/// </summary>
		protected void btnForItemCode_Click(object sender, System.EventArgs e)
		{
			if (txtItemCode.Text!="") 
			{
				if(txtItemCode.Text!="-1")
				{
					//设置物料名称，规格型号，单价控件为只读并灰掉单位控件
					this.txtItemName.ReadOnly = true;
					this.txtItemSpecial.ReadOnly = true;
					this.txtItemPrice.ReadOnly = true;
					this.ddlUnit.Enable = false;
					//需要从物料数据库中获取
					oItemData = new ItemSystem().GetItemByCode(this.txtItemCode.Text);
					//存在物料数据
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0 )
					{
						this.txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
						this.txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						this.txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						
						try  
						{
							this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
						}
						catch
						{
							try {this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.EVAPRICE_FIELD].ToString()).ToString("0.###");}
							catch {this.txtItemPrice.Text = "0.000";}
						}

                        this.ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
						//lblUnit.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UnitName_Field].ToString();	//20080418 获取物料单位名称
						//txtItemUnit.Value=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString();  //20080418 获取物料单位ID

//						if (this.txtItemCode.Text == new SysSystem().GetSTAGInfo().ItemCode)//如果是液铝。
//						{
//							//初始化申领数量。申领数量为STAG表中ConCode1对应池中的总数量。
//							StockData oStockData;
//							string ItemCode;
//							int ConCode;
//							ItemCode = new SysSystem().GetSTAGInfo().ItemCode;
//							ConCode = new SysSystem().GetSTAGInfo().ConCode1;
//							oStockData = new ItemSystem().GetStockSumByItemCodeAndConCode(ItemCode, ConCode);
//							if ( oStockData.Count > 0 )
//							{
//								this.txtReqNum.Text = Convert.ToDecimal(oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString()).ToString("0.##");
//							}
//						}
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
					oItemData=(new ItemSystem()).GetItemByCode(txtItemCode.Text);
					
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0)
					{
						txtItemName.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						txtItemSpecial.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						this.txtItemPrice.Text=decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
						//度量单位
						ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                        //lblUnit.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UnitName_Field].ToString();	//20080418  获取物料单位名称
                        //txtItemUnit.Value = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString();  //20080418 获取物料单位ID
					}
				}		
			}
			//Page.RegisterStartupScript("addblock","<script>function addblockfun(){ if(document.readyState==\"complete\"){document.getElementById(\"TableControl_Items\").className = \"Tableadd\";}}document.onreadystatechange=addblockfun;</script>");
		}   //End btnForItemCode_Click

		/// <summary>
		/// 有单据增加按钮事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnForPKID_Click(object sender, System.EventArgs e)
		{
			//txtPKIDs 中的内容是由弹出窗体，传回来的委外加工申请单的EntryNo。
			if (this.txtPKIDs.Text != null || this.txtPKIDs.Text != "")
			{
			   
				WTOW_EntryNos = this.txtPKIDs.Text;
				if (!string.IsNullOrEmpty(this.DGModel_Items1.SelectedID ))
				{
					PSerialNo = Convert.ToInt32(this.DGModel_Items1.SelectedID);
				}
				else
				{
					PSerialNo = -1;
				}				
				oWINWData = new ItemSystem().GetWTOWValidDataByEntryNos(WTOW_EntryNos, PSerialNo);			
				
				for (int i=0; i< oWINWData.Tables[WINWData.WRES_TABLE].Rows.Count; i++)
				{
					SourceEntryNo = Convert.ToInt32(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.SourceEntryNo_Field].ToString());
					SourceDocCode = Convert.ToInt16(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.SourceDocCode_Field].ToString());
					SourceSerialNo = Convert.ToInt16(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.SouceSerialNo_Field].ToString());
					oRow = this.WRESTable.NewRow();
					CurrentRow = this.GetRowBySource(SourceEntryNo, SourceDocCode, SourceSerialNo);
					if (CurrentRow == -1)//没有重复。
					{
						oRow["SourceEntryNo"] = SourceEntryNo;
						oRow["SourceDocCode"] = SourceDocCode;
						oRow["SourceSerialNo"] = SourceSerialNo;
						if (PSerialNo == -1)
							oRow["PSerialNo"] = 0;
						else
							oRow["PSerialNo"] = PSerialNo;
						
						oRow["ResCode"] = oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResCode_Field].ToString();
						oRow["ResName"] = oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResName_Field].ToString();
						oRow["ResSpecial"] = oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResSpecial_Field].ToString();
						oRow["ResUnit"] = Convert.ToInt16(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResUnit_Field].ToString());
						oRow["ResUnitName"] = oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResUnitName_Field].ToString();
						oRow["ResPrice"] = Convert.ToDecimal(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResPrice_Field].ToString());
						oRow["ResNum"] = Convert.ToDecimal(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResNum_Field].ToString());
						oRow["ResMoney"] = Convert.ToDecimal(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResMoney_Field].ToString());
						this.WRESTable.Rows.Add(oRow);
					}
					else
					{	if (PSerialNo == -1)
							this.WRESTable.Rows[CurrentRow][WINWData.PSerialNo_Field] = 0;
						else
							this.WRESTable.Rows[CurrentRow][WINWData.PSerialNo_Field] = PSerialNo;
						this.WRESTable.Rows[CurrentRow][WINWData.ResCode_Field] = oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResCode_Field].ToString();
						this.WRESTable.Rows[CurrentRow][WINWData.ResName_Field] = oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResName_Field].ToString();
						this.WRESTable.Rows[CurrentRow][WINWData.ResSpecial_Field] = oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResSpecial_Field].ToString();
						this.WRESTable.Rows[CurrentRow][WINWData.ResUnit_Field] = Convert.ToInt16(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResUnit_Field].ToString());
						this.WRESTable.Rows[CurrentRow][WINWData.ResUnitName_Field] = oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResUnitName_Field].ToString();
						this.WRESTable.Rows[CurrentRow][WINWData.ResPrice_Field] = Convert.ToDecimal(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResPrice_Field].ToString());
						this.WRESTable.Rows[CurrentRow][WINWData.ResNum_Field] = Convert.ToDecimal(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResNum_Field].ToString());
						this.WRESTable.Rows[CurrentRow][WINWData.ResMoney_Field] = Convert.ToDecimal(oWINWData.Tables[WINWData.WRES_TABLE].Rows[i][WINWData.ResMoney_Field].ToString());
					}
				}
				this.Calc_Product_Price_Money_Fee_Sum();
				this.DGModel_WRES1.DataSource = this.WRESTable;
				this.DGModel_Items1.DataSource = this.thisTable;
				this.DGModel_Items1.DataBind();
				this.DGModel_WRES1.DataBind();
			}
		}

        /// <summary>
        /// 加工费用改变。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtTotalFee_TextChanged(object sender, System.EventArgs e)
        {
            this.Calc_Product_Price_Money_Fee_Sum();
            this.DGModel_Items1.DataSource = this.thisTable;
            this.DGModel_WRES1.DataSource = this.WRESTable;
            this.DGModel_Items1.DataBind();
            this.DGModel_WRES1.DataBind();
        }

        /// <summary>
        /// 取消新建项的输入
        /// </summary>
        private void btnCancelItem_Click(object sender, System.EventArgs e)
        {
            txtItemSerial.Value = "-1";

            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtItemSpecial.Text = "";
            ddlUnit.SetItemSelected("-1");
            //txtItemUnit.Value="-1";  //20080418 物料单位ID初始化
            //lblUnit.Text="";	//20080418 物料单位名称初始化

            txtItemPrice.Text = "";
            txtReqNum.Text = "";
            txtItemNum.Text = "";

            this.btnAddItem.Text = "新增";
            SetButtonStatus();
        }


        /// <summary>
        /// 取消新建项的输入
        /// </summary>
        private void btnCancelWres_Click(object sender, System.EventArgs e)
        {
            txtPSerialNo.Text = "";
            txtResCode.Text = "";
            txtResName.Text = "";
            txtResSpecial.Text = "";
            //ddlResUnit.SetItemSelected("-1");
            txtItemResUnit.Value = "-1";  //20080418 物料单位ID初始化
            lblResUnit.Text = "";	//20080418 物料单位名称初始化

            txtResPrice.Text = "";
            txtResNum.Text = "";

            SetResButtonStatus();
        }

		#endregion
		
		
		
		/// <summary>
		/// 设置操作按纽状态
		/// </summary>
		private void SetResButtonStatus()
		{
			switch (this._OP)
			{
				case OP.New: 
				case OP.Edit:
					this.btnResEdit.Enabled=true;
					this.btnresDelete.Enabled=true;
					break;
				case OP.Submit:
				case OP.FirstAudit:
				case OP.SecondAudit:
				case OP.ThirdAudit:
				case OP.Red:
					this.btnResEdit.Enabled=false;
					this.btnresDelete.Enabled=false;
					break;
				case OP.O:
					this.btnResEdit.Enabled=true;
					this.btnresDelete.Enabled=false;
					break;
			}
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

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[6].Visible = IsDisplayWINWPrice;
                e.Item.Cells[8].Visible = IsDisplayWINWPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[6].Visible = IsDisplayWINWPrice;
                e.Item.Cells[8].Visible = IsDisplayWINWPrice;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[6].Visible = IsDisplayWINWPrice;
                e.Item.Cells[8].Visible = IsDisplayWINWPrice;
            }
        }
        /// <summary>
        /// 原材料消耗表的数据绑定。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DGModel_WRES1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            e.Item.Attributes.Add("id", e.Item.ItemIndex.ToString());
            if (e.Item.ItemType == ListItemType.Header)
            {
                TotalResMoney = 0;
                e.Item.Cells[5].Visible = IsDisplayWINWPrice;
                e.Item.Cells[7].Visible = IsDisplayWINWPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    this.TotalResMoney += decimal.Parse(e.Item.Cells[7].Text);
                }
                catch
                {
                    this.TotalResMoney += 0;
                }
                //try//price。
                //{

                //    e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.000");
                //}
                //catch
                //{
                //    e.Item.Cells[5].Text = "0";
                //}
                try//消耗数。
                {
                    e.Item.Cells[5].Visible = IsDisplayWINWPrice;
                    e.Item.Cells[7].Visible = IsDisplayWINWPrice;

                    //e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.###");
                }
                catch
                {
                    e.Item.Cells[6].Text = "0";
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)//如果当前项是页脚项。
            {
                e.Item.HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[6].Text = "合  计";
                e.Item.HorizontalAlign = HorizontalAlign.Right;
                //e.Item.Cells[7].Text = string.Format("{0:0.00}", this.TotalResMoney);

                e.Item.Cells[7].Text = this.TotalResMoney.ToString();
                if (!IsDisplayWINWPrice)
                    e.Item.Cells[6].Text = "";
                e.Item.Cells[5].Visible = IsDisplayWINWPrice;
                e.Item.Cells[7].Visible = IsDisplayWINWPrice;
            }
        }

       
	}
}
