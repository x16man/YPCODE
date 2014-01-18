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
	///	���������ϲ��������û��ؼ���
	///	�ṩ�ˣ�����������������ӡ��޸ġ�ɾ������ʾ���ܡ�
	/// </summary>
	public partial class ConChooserWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
		
        private string _OP;
		
        private int iRow;

	    private DataRow dr;
		#endregion

		#region ����
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
		/// ��ע���ԡ�
		/// </summary>
		#endregion

		#region ˽�з���
		/// <summary>
		/// �����ݽ���У��.
		/// </summary>
		/// <returns>bool:	У��ͨ������true��ʧ�ܷ���false��</returns>
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
                        Page.RegisterStartupScript(  "Error", "<script>alert('�����������˿����!');</script>");
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
                Page.RegisterStartupScript(  "Error", "<script>alert('��������ȷ����������!');</script>");
						
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
		
		

		#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}

			//����ģʽ�£���������е������ݵ��޸ġ�
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
		/// ���°�ť��
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
		/// �༭��ť��
		/// </summary>
		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			//������-1��ʾ�Ѿ����ڱ༭״̬
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
