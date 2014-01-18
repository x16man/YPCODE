namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	using MZHMM.WebMM.Modules;
	using MZHCommon.Database;
    using System.Web.UI;
	/// <summary>
	///	单据上物料部分内容用户控件。
	///	提供了，单据上物料项的增加、修改、删除、显示功能。
	/// </summary>
	public partial class RTSWebControl : System.Web.UI.UserControl
	{
		#region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    private string _OP;
		public    StorageDropdownlist ddlCon ;

	    private int ret;
	    private int i;

	    private bool bret;

	    private decimal temp_num;
	    private decimal temp_price;
	    private decimal temp_money;
	    private int iRow;
	    private DataRow dr;
	    private ItemData oItemData = new ItemData();
	    private DataSet DS;
	    private Hashtable oHT = new Hashtable();
	    private DataRow NewDr;
		#endregion

		#region 属性
        /// <summary>
        /// 是否显示单价
        /// </summary>
        public bool IsDisplayRTSPrice
        {
            get
            {
                if (ViewState["IsDisplayRTSPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayRTSPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayRTSPrice"] = value;
            }
        }

		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.RTS_DT] != null)
					return (DataTable)Session[MySession.RTS_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.RTS_DT] = value;
			}
		}
		public string Remark
		{
			get{return txtRemark.Text;}
			set{txtRemark.Text = value;}
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
            //Logger.Debug(this.thisTable.Rows.Count);
		    
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
//				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtReqNum.Text!="") && (txtReqDate.Text!="") && (ddlUnit.SelectedValue!="-1"))
				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtReqNum.Text!="") && (ddlUnit.SelectedValue!="-1"))
				{
					decimal.Parse(txtReqNum.Text);
					//DateTime tmpDateTime=DateTime.Parse(txtReqDate.Text);
				}
				else
				{
					//this.Response.Write("<script>alert(\"物料编号、物料名称、单位、申请数量不能为空！\");</script>");
                    Page.RegisterStartupScript( "DoCheck", "<script>alert('物料编号、物料名称、单位、申请数量不能为空!');</script>");
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
			// 在此处放置用户代码以初始化页面

            this.txtItemPrice.Visible = IsDisplayRTSPrice;


			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.RTS;

			//审批模式下，不允许进行单据内容的修改。
			if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.txtRemark.Enabled = false;
			}
			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//初始化
			//DGModel_Items1.ShowPager=false;
			DGModel_Items1.AllowPaging = false;
			this.ddlCon.Visible  = false;


			switch(this._OP)
			{
				case OP.New:
					#region 新建
					if(!this.IsPostBack)
					{
						//定义表和数据结构
						if(this.thisTable!=null) this.thisTable = null;
						this.thisTable=new DataTable();

						DataColumnCollection columns = this.thisTable.Columns;
                        columns.Add("SerialNo");
						columns.Add("SourceEntry");
						columns.Add("SourceDocCode");
						columns.Add("SourceSerialNo");
						columns.Add("ItemCode");
						columns.Add("ItemName");
						columns.Add("ItemSpecial");
						columns.Add("ItemUnit");
						columns.Add("ItemUnitName");
						columns.Add("ItemPrice");
						columns.Add("PlanNum").DataType = typeof(System.Decimal);
						columns.Add("ItemNum").DataType=typeof(System.Decimal);
						columns.Add("ItemMoney");
                        columns.Add("ConName");
                        columns.Add("ConCode");
						//绑定
						

						//初始化一些项
						//度量单位
						ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
					}
					DGModel_Items1.DataSource=this.thisTable;				
					DGModel_Items1.DataBind();
					break;
					#endregion
				case OP.I:
					#region 收料
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

                        //定义表和数据结构
                        if (this.thisTable == null)
                        {
                            this.thisTable = new DataTable();

                            DataColumnCollection columns = this.thisTable.Columns;
                            columns.Add("SerialNo");
                            columns.Add("SourceEntry");
                            columns.Add("SourceDocCode");
                            columns.Add("SourceSerialNo");
                            columns.Add("ItemCode");
                            columns.Add("ItemName");
                            columns.Add("ItemSpecial");
                            columns.Add("ItemUnit");
                            columns.Add("ItemUnitName");
                            columns.Add("ItemPrice");
                            columns.Add("PlanNum").DataType = typeof(System.Decimal);
                            columns.Add("ItemNum").DataType = typeof(System.Decimal);
                            columns.Add("ItemMoney");
                            columns.Add("ConName");
                            columns.Add("ConCode");
                        }
					}
					//this.DGModel_Items1.ColumnsScheme = ColumnScheme.RTSRECEIVE;
					DGModel_Items1.DataSource=this.thisTable;				
					DGModel_Items1.DataBind();
			        this.ddlCon.Visible  = true;
                    this.btnAddItem.Enabled = false;
                    this.btnDelItem.Enabled = false;
                    this.btnEditItem.Enabled = true;

					break;
					#endregion
				default:
					#region 其它
					if(!this.IsPostBack)
					{
						//度量单位
						ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
					}
					DGModel_Items1.DataSource=this.thisTable;				
					DGModel_Items1.DataBind();

			        break;
					#endregion
			}
		}
       
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
				
				if (this.btnAddItem.Text == "更新")
				{
					iRow=int.Parse(txtItemSerial.Value);
					dr=this.thisTable.Rows[iRow];

					if (this._OP == OP.I)//收料模式。
					{
						dr["ItemNum"] = txtItemNum.Text;
						temp_num   = decimal.Parse(txtItemNum.Text);
					}
					else
					{
						dr["ItemNum"] = 0;
						dr["PlanNum"] = decimal.Parse(txtReqNum.Text);
						temp_num   = decimal.Parse(txtReqNum.Text);
					}
					temp_price = decimal.Parse(txtItemPrice.Text);
					temp_money = temp_num * temp_price;
					dr["ItemMoney"] = temp_money.ToString("0.##");

					txtItemSerial.Value="-1";
                    btnAddItem.Text = "新增";
                    btnAddItem.Enabled = false;

				}
				DGModel_Items1.DataSource=this.thisTable;
				DGModel_Items1.DataBind();				

				txtItemCode.Text="";
				txtItemName.Text="";
				txtItemSpecial.Text="";
				txtReqNum.Text="";
				ddlUnit.SetItemSelected("-1");
				txtItemPrice.Text="";
				txtItemNum.Text = "";
				this.ddlCon.SetItemSelected("-1");
			}
		}

		/// <summary>
		/// 编辑按钮。
		/// </summary>
		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			//不等于-1表示已经处于编辑状态
			if(txtItemSerial.Value=="-1")
			{
				if (!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
				{
					iRow = GetRowIndex(DGModel_Items1.SelectedID);

                    if (iRow > -1)
                    {
                        txtItemSerial.Value = iRow.ToString();

                        txtItemCode.Text = this.thisTable.Rows[iRow]["ItemCode"].ToString();
                        txtItemName.Text = this.thisTable.Rows[iRow]["ItemName"].ToString();
                        txtItemSpecial.Text = this.thisTable.Rows[iRow]["ItemSpecial"].ToString();
                        //txtReqNum.Text=dt.Rows[iRow]["ItemNum"].ToString();
                        this.txtItemNum.Text = this.thisTable.Rows[iRow]["ItemNum"].ToString();
                        txtReqNum.Text = this.thisTable.Rows[iRow]["PlanNum"].ToString();
                        //txtReqDate.Text=dt.Rows[iRow]["ReqDate"].ToString();
                        txtItemPrice.Text = this.thisTable.Rows[iRow]["ItemPrice"].ToString();
                        //度量单位
                        ddlUnit.SetItemSelected(this.thisTable.Rows[iRow]["ItemUnit"].ToString());
                        //this.ddlCon.SetItemSelected(this.thisTable.Rows[iRow][BillOfReceiveData.CONCODE_FIELD].ToString());//架位

                        this.btnAddItem.Text = "更新";
                        this.btnAddItem.Enabled = true;
                        this.btnDelItem.Enabled = false;
                    }
				}
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
			if(!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
			{
                Logger.Debug(string.Format("selectedId is {0}",DGModel_Items1.SelectedID));
				iRow=int.Parse(DGModel_Items1.SelectedID);
                Logger.Debug(iRow);
                Logger.Debug(string.Format("table's count is {0}",this.thisTable.Rows.Count));
				this.thisTable.Rows.RemoveAt(iRow);

				DGModel_Items1.DataSource=this.thisTable;
				DGModel_Items1.DataBind();
			}
		}
		/// <summary>
		/// 文本绑定的隐藏按钮。
		/// </summary>
		protected void btnForItemCode_Click(object sender, System.EventArgs e)
		{
			if (txtItemCode.Text!="") 
			{
				if(txtItemCode.Text!="-1")
				{
					//
					//需要从物料数据库中获取
					//
					oItemData=(new ItemSystem()).GetItemByCode(txtItemCode.Text);
					
					//存在物料数据
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0)
					{
						txtItemName.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						txtItemSpecial.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						this.txtItemPrice.Text=decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
						this.txtItemCode.Text =oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
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
				}		
			}
		}   //End btnForItemCode_Click
		#endregion
		/// <summary>
		/// 选择了领料单以后生成的内部退货单明细。
		/// </summary>
		protected void bntForEntryNo_Click(object sender, System.EventArgs e)
		{
			if (txtEntryNo.Text!="") 
			{
				this.thisTable.Rows.Clear();
				if(txtEntryNo.Text!="-1")
				{
				    DS = new DataSet();
					oHT = new Hashtable();
					oHT.Add("@EntryNo",int.Parse(this.txtEntryNo.Text));
					DS = new SQLServer().ExecSPReturnDS("Sto_RTSGetSourceDetailByEntryNo",oHT);

					for(i=0;i<DS.Tables[0].Rows.Count;i++)
					{
						dr = DS.Tables[0].Rows[i];
						
						NewDr = this.thisTable.NewRow();
						NewDr["SourceEntry"] = dr["SourceEntry"];
						NewDr["SourceDocCode"] = dr["SourceDocCode"];
						NewDr["SourceSerialNo"] = dr["SourceSerialNo"];
						NewDr["ItemCode"] = dr["ItemCode"];
						NewDr["ItemName"] = dr["ItemName"];
						NewDr["ItemSpecial"] = dr["ItemSpecial"] ;
						NewDr["ItemUnit"] = dr["ItemUnit"];
						NewDr["ItemUnitName"] = dr["ItemUnitName"];
						NewDr["PlanNum"] = dr["PlanNum"];
						NewDr["ItemNum"] = dr["ItemNum"];
						NewDr["ItemPrice"] = dr["ItemPrice"];
						NewDr["ItemMoney"] = dr["ItemMoney"];

						this.thisTable.Rows.Add(NewDr);
					}

				}
			}
			DGModel_Items1.DataSource=this.thisTable;
			DGModel_Items1.DataBind();	
		}

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
             if (e.Item.ItemType == ListItemType.Header)
            {
               
                if (_OP == OP.I)
                {
                    //e.Item.Cells[0].Visible = false;//序号
                    //e.Item.Cells[1].Visible = true;//编号
                    //e.Item.Cells[2].Visible = true;//名称
                    //e.Item.Cells[3].Visible = true;//规格型号
                    //e.Item.Cells[4].Visible = true;//计量单位
                    e.Item.Cells[5].Visible = true;//请领数
                    e.Item.Cells[6].Visible = true;//实发数
                    //e.Item.Cells[7].Visible = true;//单价
                }
                else
                {
                    //e.Item.Cells[0].Visible = true;
                    //e.Item.Cells[1].Visible = true;
                    //e.Item.Cells[2].Visible = true;
                    //e.Item.Cells[3].Visible = true;
                    //e.Item.Cells[4].Visible = true;
                    e.Item.Cells[5].Visible = true;
                    e.Item.Cells[6].Visible = false;
                    //e.Item.Cells[7].Visible = false;
                }

                e.Item.Cells[7].Visible = IsDisplayRTSPrice;//单价
                e.Item.Cells[8].Visible = IsDisplayRTSPrice;//总价


            }
             else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
             {
                 if(_OP == OP.New || _OP == OP.Edit)
                 {
                     e.Item.Cells[0].Text = e.Item.ItemIndex.ToString();
                 }
                 if (_OP == OP.I)
                 {
                     //e.Item.Cells[0].Visible = false;
                     //e.Item.Cells[1].Visible = false;
                     //e.Item.Cells[2].Visible = false;
                     //e.Item.Cells[3].Visible = false;
                     //e.Item.Cells[4].Visible = false;
                     //e.Item.Cells[5].Visible = false;
                     e.Item.Cells[6].Visible = true;
                     //e.Item.Cells[7].Visible = true;
                 }
                 else
                 {
                     //e.Item.Cells[0].Visible = true;
                     //e.Item.Cells[1].Visible = true;
                     //e.Item.Cells[2].Visible = true;
                     //e.Item.Cells[3].Visible = true;
                     //e.Item.Cells[4].Visible = true;
                     //e.Item.Cells[5].Visible = true;
                     e.Item.Cells[6].Visible = false;
                     //e.Item.Cells[7].Visible = false;
                 }

                 e.Item.Cells[7].Visible = IsDisplayRTSPrice;
                 e.Item.Cells[8].Visible = IsDisplayRTSPrice;
             }
             else if (e.Item.ItemType == ListItemType.Footer)
             {
                 e.Item.Cells[7].Visible = IsDisplayRTSPrice;
                 e.Item.Cells[8].Visible = IsDisplayRTSPrice;
             }
        
       }
	}
}
