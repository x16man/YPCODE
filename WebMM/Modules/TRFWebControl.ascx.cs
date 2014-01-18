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
	///		TRFWebControl 的摘要说明。
	/// </summary>
	public partial class TRFWebControl : System.Web.UI.UserControl
	{
		#region 成员变量
		protected StorageDropdownlist ddlUnit=new StorageDropdownlist();
		public static DataTable dt;//定义了一静态的表,用以保存状态数据
		private string tmpCode;
		private string _OP;
		
		public DGModel_Items DGModel_Items1;
	    private int ret;

	    private int i;

	    private bool bret;
	    private int CurrentRow;

	    private DataRow dr;

	    private int iRow;

	    private ItemData oItemData = new ItemData();
		#endregion

		#region 属性
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.TRF_DT] != null)
					return (DataTable)Session[MySession.TRF_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.TRF_DT] = value;
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
		/// <returns>int:	没有返回-1，有则返回所在行的行数。</returns>
		private int GetRowByItemCode(string ItemCode)
		{
			ret = -1;
			for (i = 0; i < dt.Rows.Count; i++)
			{
				if (dt.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode)
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
				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtPlanNum.Text!="") && (txtPlanNum.Text!="") && (ddlUnit.SelectedValue!="-1"))
				{
					
					decimal.Parse(txtPlanNum.Text);
					
				}
				else
				{
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
				//审批模式下，不允许进行单据内容的修改。
				case OP.FirstAudit:					
				case OP.SecondAudit:					
				case OP.ThirdAudit:
				case OP.Submit:
					#region 三级审批和提交
					this.btnAddItem.Enabled = false;
					this.btnEditItem.Enabled = false;
					this.btnDelItem.Enabled = false;
					this.txtRemark.Enabled = false;
					#endregion
					break;
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
					this.btnEditItem.Enabled = false;
					break;
					#endregion
				case OP.O:
					#region 发料 
					this.txtItemCode.Visible = true;
					this.txtItemCode.ReadOnly = true;
					this.txtItemName.Visible = true;
					this.txtItemName.ReadOnly = true;
					this.txtItemSpecial.Visible = true;
					this.txtItemSpecial.ReadOnly = true;
					this.ddlUnit.Visible = true;
					this.ddlUnit.Enable = false;
					
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
					
					this.txtItemPrice.Visible = true;
					this.txtItemPrice.Enabled = true;
					this.txtItemPrice.ReadOnly = false;
					
					
					this.txtItemNum.Visible = false;
					this.txtRemark.Enabled = true;
					this.txtRemark.Visible = true;
					this.txtRemark.ReadOnly = false;
					
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
			if (!string.IsNullOrEmpty(this.Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			
			this.SetEditMode(this._OP);

			if(this._OP == OP.I)
				DGModel_Items1.ColumnsScheme = ColumnScheme.TRFIn;
			else
				DGModel_Items1.ColumnsScheme = ColumnScheme.TRF;
			


			DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//初始化
			DGModel_Items1.ShowPager=false;
			DGModel_Items1.AllowPaging = false;

			if((!this.IsPostBack) && (this.Request["Op"].ToString()=="New"))
			{
				//定义表和数据结构
				if(dt!=null) dt.Dispose();
				dt=new DataTable();

				DataColumnCollection columns = dt.Columns;
				columns.Add("ItemCode");
				columns.Add("ItemName");
				columns.Add("ItemSpecial");
				columns.Add("ItemUnit");
				columns.Add("ItemUnitName");
				columns.Add("ItemPrice");			
				columns.Add("PlanNum").DataType=typeof(System.Decimal);
				columns.Add("ItemNum");
				columns.Add("ItemMoney");
				columns.Add("ConName");
				//绑定
				
				DGModel_Items1.DataSource=dt;				
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
				DGModel_Items1.DataSource=dt;				
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
			dt.Dispose();
		}
		*/
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
				decimal temp_num,temp_price,temp_money;

				if(btnAddItem.Text=="新增")
				{
					CurrentRow = GetRowByItemCode(txtItemCode.Text);

					if ( CurrentRow == -1)//静态表中没有过该物料。
					{
						dr=dt.NewRow();
						dr["ItemCode"] = txtItemCode.Text;
						dr["ItemName"] = txtItemName.Text;
						dr["ItemSpecial"] = txtItemSpecial.Text;
						dr["ItemUnit"] = ddlUnit.SelectedValue;
						dr["ItemUnitName"] = ddlUnit.SelectedText;
						dr["ItemPrice"] = txtItemPrice.Text;
						dr["PlanNum"] = txtPlanNum.Text;
						//金额
						temp_num   = decimal.Parse(txtPlanNum.Text);
						temp_price = decimal.Parse(txtItemPrice.Text);
						temp_money = Math.Round((temp_num * temp_price),2);
					
						dr["ItemMoney"] = temp_money.ToString("0.##");

						
						dt.Rows.Add(dr);
					}
					else//静态表中已经存在该物料。
					{
						temp_num = Convert.ToDecimal(dt.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtPlanNum.Text);
						temp_price = Convert.ToDecimal(dt.Rows[CurrentRow]["ItemPrice"].ToString());
						temp_money = Math.Round((temp_num * temp_price),2);
						dt.Rows[CurrentRow]["PlanNum"] = temp_num;
						dt.Rows[CurrentRow]["ItemMoney"] = temp_money;
					}
				}
				else
				{
					iRow=int.Parse(txtItemSerial.Value);
					dr=dt.Rows[iRow];

					dr["ItemCode"]=txtItemCode.Text;
					dr["ItemName"]=txtItemName.Text;
					dr["ItemSpecial"]=txtItemSpecial.Text;
					dr["ItemUnit"]=ddlUnit.SelectedValue;
					dr["ItemUnitName"]=ddlUnit.SelectedText;
					dr["ItemPrice"]=txtItemPrice.Text;
					dr["PlanNum"]=txtPlanNum.Text;
					dr["ItemNum"]=txtItemNum.Text;


					if(this._OP==OP.Discard)
					{
						if(decimal.Parse(this.txtItemNum.Text)>decimal.Parse(this.txtPlanNum.Text))
						{
                            Page.RegisterStartupScript( "Error", "<script>alert('实转数量不应大于应转数量!');</script>");
                            this.btnAddItem.Enabled=true;
							this.btnAddItem.Text="更新";
							return;
						}
						temp_num =decimal.Parse(txtItemNum.Text);	
						dr["ItemNum"] = txtItemNum.Text;
					}
					else
						temp_num   = decimal.Parse(txtPlanNum.Text);

					
					temp_price = decimal.Parse(txtItemPrice.Text);
					temp_money = temp_num * temp_price;
					dr["ItemMoney"] = temp_money.ToString("0.##");
					
					
					
					txtItemSerial.Value="-1";
					btnAddItem.Text="新增";

				}
				DGModel_Items1.DataSource=dt;
				DGModel_Items1.DataBind();				

				txtItemCode.Text="";
				txtItemName.Text="";
				txtItemSpecial.Text="";
				txtPlanNum.Text="";
				txtItemNum.Text="";
				ddlUnit.SetItemSelected("-1");
				
				txtItemPrice.Text="";
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
				if (!string.IsNullOrEmpty(this.DGModel_Items1.SelectedID))
				{
					iRow=int.Parse(DGModel_Items1.SelectedID);
	
					txtItemSerial.Value=iRow.ToString();

					txtItemCode.Text=dt.Rows[iRow]["ItemCode"].ToString();
					txtItemName.Text=dt.Rows[iRow]["ItemName"].ToString();
					txtItemSpecial.Text=dt.Rows[iRow]["ItemSpecial"].ToString();
					txtPlanNum.Text=dt.Rows[iRow]["PlanNum"].ToString();
					txtItemNum.Text=dt.Rows[iRow]["ItemNum"].ToString();
					
					txtItemPrice.Text=dt.Rows[iRow]["ItemPrice"].ToString();
					//度量单位
					ddlUnit.SetItemSelected(dt.Rows[iRow]["ItemUnit"].ToString());

					btnAddItem.Text="更新";
					btnAddItem.Enabled=true;
					
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

				dt.Rows.RemoveAt(iRow);

				DGModel_Items1.DataSource=dt;
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
				}		
			}
		}   //End btnForItemCode_Click
		#endregion

		
	}
}
