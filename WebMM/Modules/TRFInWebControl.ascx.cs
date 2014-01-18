namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using MZHMM.Common;
	using MZHMM.Facade;
	using MZHMM.WebMM.Modules;
    using System.Web.UI;
	/// <summary>
	///	单据上物料部分内容用户控件。
	///	提供了，单据上物料项的增加、修改、删除、显示功能。
	/// </summary>
	public partial class TRFInWebControl : System.Web.UI.UserControl
	{
		#region 成员变量
		protected StorageDropdownlist ddlUnit = new StorageDropdownlist();
		public    StorageDropdownlist ddlCon ;
		//private static DataTable dt;//定义了一静态的表,用以保存状态数据
		private string tmpCode;
		private string _OP;
		protected System.Web.UI.WebControls.Button btnForItemCode;
		protected System.Web.UI.WebControls.TextBox txtEntryNo;
		protected System.Web.UI.WebControls.Button bntForEntryNo;
		public DGModel_Items DGModel_Items1;

	    private int ret;
	    private int i;
	    private bool bret;
	    private decimal temp_num;
	    private decimal temp_price;
	    private decimal temp_money;
	    private decimal temp_taxrate;
	    private decimal temp_tax;
	    private decimal temp_all;

	    private int iRow;

	    private int CurrentRow;

	    private DataRow dr;
	    private ItemData oItemData = new ItemData();


		#endregion

		#region 属性
		/// <summary>
		/// DataGrid的数据源。
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.TRFIN_DT] != null)
					return (DataTable)Session[MySession.TRFIN_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.TRFIN_DT] = value;
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
		#endregion

		#region 私有方法
		/// <summary>
		/// 在静态表中检查该物料是否已经存在。
		/// </summary>
		/// <param name="ItemCode">string:	要检查的物料编号。</param>
		/// <returns>int:	没有返回-1，有则返回所在行的行数。</returns>
		private int GetRowByItemCode(string ItemCode)
		{
			ret = -1;
			for (i = 0; i < this.thisTable.Rows.Count; i++)
			{
				if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode)
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
				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtReqNum.Text!="") && (ddlUnit.SelectedValue!="-1"))
				{
					decimal.Parse(txtReqNum.Text);
				}
				else
				{
					//this.Response.Write("<script>alert(\"物料编号、物料名称、单位、申请数量不能为空！\");</script>");
                    ScriptManager.RegisterStartupScript(this.btnAddItem, this.GetType(), "Error", "alert('物料编号、物料名称、单位、申请数量不能为空!');", true);
                    bret=false;
				}
			}
			catch
			{
				bret=false;
			}
			return bret;
		}
		
		/// <summary>
		/// 根据不同操作模式，设定编辑区域的显示方式。
		/// </summary>
		/// <param name="OpMode">string:	操作模式。</param>
		private void SetEditMode(string OpMode)
		{
			switch (OpMode)
			{			
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
					this.ddlCon.Visible = true;
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
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//模式设定。
			DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			DGModel_Items1.ShowPager=false;
			this.SetEditMode(this._OP);//设定编辑区域的显示模式。
			
			#region 收料
			this.DGModel_Items1.ColumnsScheme = ColumnScheme.TRFIn;
			if (this.btnAddItem.Text == "新增")
			{
				this.btnAddItem.Enabled = false;
			}
			else
			{
				this.btnAddItem.Enabled = true;
			}
			if(!this.IsPostBack)
			{
				//度量单位
				this.ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
				this.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;
			}
			DGModel_Items1.DataSource=this.thisTable;				
			DGModel_Items1.DataBind();
			tmpCode=DGModel_Items1.SelectedID;
			
			#endregion
		}

        /*
		/// <summary>
		/// 页面UnLoad事件。
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//释放静态变量dt
			this.thisTable=null;
		}*/
		
		/// <summary>
		/// 增加按钮。
		/// </summary>
		protected void btnAddItem_Click(object sender, System.EventArgs e)
		{
			//
			//添加一行数据并且赋值
			//
			if(DoCheck())
			{
				#region 更新
				
					iRow=int.Parse(txtItemSerial.Value);
					dr=this.thisTable.Rows[iRow];
					CurrentRow = GetRowByItemCode(txtItemCode.Text);
					if (CurrentRow == iRow || CurrentRow == -1)//没有重复物料。
					{
						dr["ItemCode"]=txtItemCode.Text;
						dr["ItemName"]=txtItemName.Text;
						dr["ItemSpecial"]=txtItemSpecial.Text;
						dr["ItemUnit"]=ddlUnit.SelectedValue;
						dr["ItemUnitName"]=ddlUnit.SelectedText;
						
						dr[InItemData.ITEMPRICE_FIELD] = this.txtItemPrice.Text;
						dr[WTRFData.PLANNUM_FIELD] = this.txtReqNum.Text;
						
						dr[InItemData.ITEMNUM_FIELD] = this.txtItemNum.Text;
						dr[WTRFData.CONCODE_FIELD] = this.ddlCon.SelectedValue;
						dr[WTRFData.CONNAME_FIELD] = this.ddlCon.SelectedText;
						if (this._OP == OP.I)//收料模式。
						{
							temp_num = decimal.Parse(this.txtItemNum.Text);
						}
						else
						{
							temp_num = decimal.Parse(this.txtReqNum.Text);
						}
						temp_price = decimal.Parse(this.txtItemPrice.Text);
						temp_taxrate = decimal.Parse(this.txtTaxRate.Text);
						temp_money = Math.Round((temp_num * temp_price),2);
						temp_tax = Math.Round((temp_money*temp_taxrate),2);
						temp_all = Math.Round((temp_money+temp_tax),2);

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
						temp_money = Math.Round((temp_num * temp_price),2);
						temp_tax = Math.Round((temp_money*temp_taxrate),2);
						temp_all = Math.Round((temp_money+temp_tax),2);

						this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
						this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
						this.thisTable.Rows[CurrentRow]["ItemTax"] = temp_tax;
						this.thisTable.Rows[CurrentRow]["ItemSum"] = temp_all;
						this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//删除原有行。
					}
					txtItemSerial.Value="-1";
					btnAddItem.Text="新增";
					btnAddItem.Enabled = false;
				
				#endregion
				
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
					iRow=int.Parse(DGModel_Items1.SelectedID);
	
					this.txtItemSerial.Value=iRow.ToString();//顺序号。
					this.txtItemCode.Text=this.thisTable.Rows[iRow][InItemData.ITEMCODE_FIELD].ToString();//物料编号。
					this.txtItemName.Text=this.thisTable.Rows[iRow][InItemData.ITEMNAME_FIELD].ToString();//物料名称。
					this.txtItemSpecial.Text=this.thisTable.Rows[iRow][InItemData.ITEMSPECIAL_FIELD].ToString();//规格型号。
					this.ddlUnit.SetItemSelected(this.thisTable.Rows[iRow][InItemData.ITEMUNIT_FIELD].ToString());//度量单位
					
					this.txtItemPrice.Text=this.thisTable.Rows[iRow][InItemData.ITEMPRICE_FIELD].ToString();//单价。
					this.txtReqNum.Text=this.thisTable.Rows[iRow][WTRFData.PLANNUM_FIELD].ToString();//应收数量。
					
					this.txtItemNum.Text = this.thisTable.Rows[iRow][InItemData.ITEMNUM_FIELD].ToString();//实收数量。				
					this.ddlCon.SetItemSelected(this.thisTable.Rows[iRow][WTRFData.CONCODE_FIELD].ToString());//架位

					this.btnAddItem.Text="更新";
					this.btnAddItem.Enabled = true;
				}
			}
		}
		/// <summary>
		/// 删除按钮。
		/// </summary>
		protected void btnDelItem_Click(object sender, System.EventArgs e)
		{
			if(!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
			{
				iRow=int.Parse(DGModel_Items1.SelectedID);

				this.thisTable.Rows.RemoveAt(iRow);

				DGModel_Items1.DataSource=this.thisTable;
				DGModel_Items1.DataBind();
			}
		}
		/// <summary>
		/// 文本绑定的隐藏按钮。
		/// </summary>
		private void btnForItemCode_Click(object sender, System.EventArgs e)
		{
			if (txtItemCode.Text!="") 
			{
				if(txtItemCode.Text!="-1")
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
					
					oItemData=(new ItemSystem()).GetItemByCode(txtItemCode.Text);
					
					//存在物料数据
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0)
					{
						txtItemCode.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
						txtItemName.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						txtItemSpecial.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						this.txtItemPrice.Text=decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
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
					oItemData=(new ItemSystem()).GetItemByCode(txtItemCode.Text);
					
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0)
					{
						txtItemCode.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
						txtItemName.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						txtItemSpecial.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						this.txtItemPrice.Text=decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
						//度量单位
						ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
					}
				}		
			}
		}   //End btnForItemCode_Click
			
		#endregion
	}
}
