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
	public partial class ConChooserWebControl : System.Web.UI.UserControl
	{
		#region 成员变量
		
        private string _OP;
		
        private int iRow;

	    private DataRow dr;
		#endregion

		#region 属性
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.CONCHOOSER_DT] != null)
					return (DataTable)Session[MySession.CONCHOOSER_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.CONCHOOSER_DT] = value;
			}
		}
		/// <summary>
		/// 备注属性。
		/// </summary>
		#endregion

		#region 私有方法
		/// <summary>
		/// 对数据进行校验.
		/// </summary>
		/// <returns>bool:	校验通过返回true，失败返回false。</returns>
		private bool DoCheck()
		{
			bool ret=true;
			try
			{
				if(this.txtItemNum.Text != "" && this.txtStockNum.Text != "")
				{
					decimal Temp_StockNum = Convert.ToDecimal(this.txtStockNum.Text);
					decimal Temp_ItemNum  = Convert.ToDecimal(this.txtItemNum.Text);
					if (Temp_ItemNum > Temp_StockNum)
					{
                        Page.RegisterStartupScript(  "Error", "<script>alert('发料数超出了库存数!');</script>");
						ret = false;
					}
				}
				else
				{
					ret=false;
				}
			}
			catch
			{
                Page.RegisterStartupScript(  "Error", "<script>alert('请输入正确的数据类型!');</script>");
						
				ret=false;
			}
			return ret;
		}

        private int GetRowIndex(string strItemcode)
        {
            for (int i = 0; i < thisTable.Rows.Count; i++)
            {
                if (strItemcode == this.thisTable.Rows[i]["PKID"].ToString())
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

			//审批模式下，不允许进行单据内容的修改。
			if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
			}
			DGModel_Items1.AllowPaging = false;
			DGModel_Items1.DataSource = this.thisTable;				
			DGModel_Items1.DataBind();
		}
        

        

		/// <summary>
		/// 更新按钮。
		/// </summary>
		protected void btnAddItem_Click(object sender, System.EventArgs e)
		{
			if(DoCheck())
			{
                iRow = GetRowIndex(DGModel_Items1.SelectedID);

                
				dr = this.thisTable.Rows[iRow];

				dr["ItemNum"] = this.txtItemNum.Text;

				this.txtItemSerial.Value = "-1";
				this.btnAddItem.Enabled = false;
				
				this.DGModel_Items1.DataSource = this.thisTable;
				this.DGModel_Items1.DataBind();				

				this.txtItemCode.Text="";
				this.txtItemName.Text="";
				this.txtItemSpecial.Text="";
				this.txtUnit.Text = "";
				this.txtStockNum.Text="";
				this.txtItemNum.Text = "";
				this.txtCon.Text = "";
				this.txtAcceptDate.Text="";
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
	
					this.txtItemSerial.Value = iRow.ToString();

					this.txtItemCode.Text = this.thisTable.Rows[iRow][StockChoiceData.ItemCode_Field].ToString();
					this.txtItemName.Text = this.thisTable.Rows[iRow][StockChoiceData.ItemName_Field].ToString();
					this.txtItemSpecial.Text = this.thisTable.Rows[iRow][StockChoiceData.ItemSpec_Field].ToString();
					this.txtUnit.Text = this.thisTable.Rows[iRow][StockChoiceData.ItemUnitName_Field].ToString();
					this.txtStockNum.Text = Convert.ToDecimal(this.thisTable.Rows[iRow][StockChoiceData.StockNum_Field].ToString()).ToString("0.##");
					if (this.thisTable.Rows[iRow]["ItemNum"] != null && this.thisTable.Rows[iRow]["ItemNum"].ToString() != "")
					{
						this.txtItemNum.Text = Convert.ToDecimal(this.thisTable.Rows[iRow][StockChoiceData.ItemNum_Field].ToString()).ToString("0.##");
					}
					this.txtCon.Text = this.thisTable.Rows[iRow][StockChoiceData.ConName_Field].ToString();
					this.txtCon.Enabled = true;
					this.txtAcceptDate.Text = this.thisTable.Rows[iRow][StockChoiceData.AcceptDate_Field].ToString();

					this.btnAddItem.Enabled = true;
				}
			}

		}
		#endregion
	}
}
