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
	///	���������ϲ��������û��ؼ���
	///	�ṩ�ˣ�����������������ӡ��޸ġ�ɾ������ʾ���ܡ�
	/// </summary>
	public partial class SCRWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
		//protected StorageDropdownlist ddlUnit=new StorageDropdownlist();
 //20080408 ���ϵ�λ����
//20080408 ���ϵ�λID
		//public static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
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

		#region ����
        /// <summary>
        /// �Ƿ���ʾ����
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

		#region ˽�з���
		/// <summary>
		/// �ھ�̬���м��������Ƿ��Ѿ����ڡ�
		/// </summary>
		/// <param name="ItemCode">string:	Ҫ�������ϱ�š�</param>
		/// <param name="ItemName"></param>
		/// <param name="ItemSpec"></param>
		/// <returns>int:	û�з���-1�����򷵻������е�������</returns>
		private int GetRowByItemCode(string ItemCode, string ItemName, string ItemSpec)
		{
			ret = -1;
			if (ItemCode != "-1")//��OTI���ϡ�
			{
				for (i = 0; i < this.thisTable.Rows.Count; i++)
				{
					if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode)
					{
						return i;
					}
				}
			}
			else//OTI���ϵı�Ŷ�Ϊ-1������Ҫ�����������ƺ͹���ͺŵ��жϡ�
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
		/// �����ݽ���У��.
		/// </summary>
		/// <returns>bool:	У��ͨ������true��ʧ�ܷ���false��</returns>
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
				    Page.RegisterStartupScript("DoCheck","<script>alert(\"���ϱ�š��������ơ���λ������������Ҫ�����ڲ���Ϊ�գ�\");</script>");
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
		
	

		#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//this.DGModel_Items1.ColumnsScheme=ColumnScheme.SCR;
			// �ڴ˴������û������Գ�ʼ��ҳ��
            txtItemPrice.Visible = IsDisplaySCRPrice;
			if (!string.IsNullOrEmpty(this.Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//����ģʽ�£���������е������ݵ��޸ġ�
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
			//��ʼ��
			//DGModel_Items1.ShowPager=false;
			//DGModel_Items1.AllowPaging = false;

			if((!this.IsPostBack) && (this.Request["Op"].ToString()=="New"))
			{
				//���������ݽṹ
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
				
				//��
				DGModel_Items1.DataSource=this.thisTable;				
				DGModel_Items1.DataBind();

				//��ʼ��һЩ��
				//������λ
				ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
			}
			else
			{
				if(!this.IsPostBack)
				{
					//������λ
					ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
				}
				DGModel_Items1.DataSource=this.thisTable;				
				DGModel_Items1.DataBind();
				tmpCode=DGModel_Items1.SelectedID;
			}
		}

        /*

		/// <summary>
		/// ҳ��UnLoad�¼���
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//�ͷž�̬����dt
			//this.thisTable=null;
		}
		*/
		

		/*
		/// <summary>
		/// ���ò�����Ŧ״̬
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
            //���һ�����ݲ��Ҹ�ֵ
            //
            if (DoCheck())
            {
                decimal temp_num, temp_price, temp_money;

                if (btnAddItem.Text == "����")
                {
                    CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);

                    if (CurrentRow == -1)//��̬����û�й������ϡ�
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


                        //���
                        temp_num = decimal.Parse(txtPlanNum.Text);
                        temp_price = decimal.Parse(txtItemPrice.Text);
                        temp_money = temp_num * temp_price;

                        dr["ItemMoney"] = temp_money.ToString("0.##");


                        this.thisTable.Rows.Add(dr);
                    }
                    else//��̬�����Ѿ����ڸ����ϡ�
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtPlanNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                    }
                }
                else//���¡�
                {
                    iRow = int.Parse(txtItemSerial.Value);
                    dr = this.thisTable.Rows[iRow];
                     CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
                    if (CurrentRow == iRow || CurrentRow == -1)//û���ظ����ϡ�
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
                                Page.RegisterStartupScript( "Error", "<script>alert('ʵ��������Ӧ����Ӧ������!');</script>");
                                this.btnAddItem.Enabled = true;
                                this.btnAddItem.Text = "����";
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
                    else//�޸ĺ����ظ����ϣ��������ֻ������ڶ�OTI���ϵ��޸ġ�
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemNum"].ToString()) + Convert.ToDecimal(txtPlanNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow]["ItemNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                        this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//ɾ��ԭ���С�
                    }

                    txtItemSerial.Value = "-1";
                    btnAddItem.Text = "����";

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
            //������-1��ʾ�Ѿ����ڱ༭״̬
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
                        //������λ
                        ddlUnit.SetItemSelected(this.thisTable.Rows[iRow]["ItemUnit"].ToString());
                        if (txtItemCode.Text == "-1")//OTI���ϡ�
                        {
                            this.txtItemName.ReadOnly = false;
                            this.txtItemSpecial.ReadOnly = false;
                            this.txtItemPrice.ReadOnly = false;
                            this.ddlUnit.Enable = true;
                        }
                        else//��OTI���ϡ�
                        {
                            this.txtItemName.ReadOnly = true;
                            this.txtItemSpecial.ReadOnly = true;
                            this.txtItemPrice.ReadOnly = true;
                            this.ddlUnit.Enable = false;
                        }
                        btnAddItem.Text = "����";
                        btnAddItem.Enabled = true;
                    }
                }
            }
        }

        protected void btnForItemCode_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text != "")
            {
                if (txtItemCode.Text != "-1")//-1��ʾ��OTI���ϡ����ơ�����ͺŵȶ������û���ʱָ���ġ�
                {
                    //
                    //�����������ƣ�����ͺţ����ۿؼ�Ϊֻ�����ҵ���λ�ؼ�
                    //
                    this.txtItemName.ReadOnly = true;
                    this.txtItemSpecial.ReadOnly = true;
                    this.txtItemPrice.ReadOnly = true;
                    this.ddlUnit.Enable = false;
                    //
                    //��Ҫ���������ݿ��л�ȡ
                    //
                    oItemData = new ItemData();
                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    //������������
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        //������λ
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }
                    else
                    {
                        //
                        //������ȱʡΪ��Ҫ��������,���������������,�ṩ�û�ѡ��
                        //
                    }
                }
                else
                {
                    //
                    //�û�ֱ������
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
                        //������λ
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
