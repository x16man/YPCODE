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
	///	���������ϲ��������û��ؼ���
	///	�ṩ�ˣ�����������������ӡ��޸ġ�ɾ������ʾ���ܡ�
	/// </summary>
	public partial class ItemsWebControl : UserControl
	{
		#region ��Ա����
		//protected StorageDropdownlist ddlUnit=new StorageDropdownlist();
 //20080408 ���ϵ�λ����
//20080408 ���ϵ�λID
		//private static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
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

		#region ����

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
		/// �������͡�
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
		/// ��ע���ԡ�
		/// </summary>
		public string Remark
		{
			get {return this.txtRemark.Text;}
			set {this.txtRemark.Text = value;}
		}
		/// <summary>
		/// ��̬���ݱ�
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
        /// ���ݱ��
        /// </summary>
	    public Shmzh.Web.UI.Controls.MzhDataGrid MyDataGrid
	    {
            get { return this.DGModel_Items1; }
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
		/// �����ݽ���У��.
		/// </summary>
		/// <returns>bool:	У��ͨ������true��ʧ�ܷ���false��</returns>
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
                            Page.RegisterStartupScript(  "ItemError", "<script>alert('���ϱ�š��������ơ���λ������������Ҫ�����ڲ���Ϊ��!');</script>");
                   
                            return false;
                        }
                    }
                     Convert.ToDateTime((txtReqDate.Text));
                    if(Convert.ToDecimal(txtReqNum.Text) <= 0)
                    {
                        Page.RegisterStartupScript( "ItemError", "<script>alert(\"����������Ҫ����0 !\");</script>");
                         bret = false;
                    }
                   
                }
                else
                {
                    //this.Response.Write("<script>alert(\"���ϱ�š��������ơ���λ������������Ҫ�����ڲ���Ϊ�գ�\");</script>");
                    Page.RegisterStartupScript("ItemError", "<script>alert(\"���ϱ�š��������ơ���λ������������Ҫ�����ڲ���Ϊ��!\");</script>");
                    bret = false;
                }
            }
            catch
            {
                Page.RegisterStartupScript( "ItemError", "<script>alert(\"������ϱ�š��������ơ���λ������������Ҫ��������д��ȷ!\");</script>");
                bret = false;
            }
            return bret;
		}
		#endregion

		#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
            //this.txtItemCode.Attributes.Add("onblur", "funBlur()");
            //this.txtItemCode.Attributes.Add("onkeypress", "funKeypress()");
            //this.btnSelect.OnClientClick = "window.open('../Storage/ItemQuery.aspx?DocCode="+this.DocCode+"','���ϲ�ѯ','toolbar = no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width =640,height = 440,left='+(window.screen.width - 640)/2+',top='+(window.screen.height - 440)/2+'')";
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
            //����ģʽ�£���������е������ݵ��޸ġ�
            if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
            {
                this.btnAddItem.Enabled = false;
                this.btnEditItem.Enabled = false;
                this.btnDelItem.Enabled = false;
                this.txtRemark.Enabled = false;
            }
            ////��ʼ��
            //DGModel_Items1.SelectedType = DGModel.SelectType.SingleSelect;
            //this.DGModel_Items1.AllowPaging = false;
            //DGModel_Items1.ShowPager = false;
            txtItemPrice.Visible = IsDisplayPrice;
            if ((!this.IsPostBack) && (this.Request["Op"].ToString() == "New"))
            {
                //���������ݽṹ
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
                //��
                DGModel_Items1.DataSource = this.thisTable;
                DGModel_Items1.DataBind();

                //��ʼ��һЩ��
                //������λ
                ddlUnit.Module_Tag = (int)SDDLTYPE.UNIT;
            }
            else
            {
                if (!this.IsPostBack)
                {
                    //������λ
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
                   
                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    //������������
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
                    oItemData = (new ItemSystem()).GetItemByCode(txtItemCode.Text);

                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.000");
                        //������λ
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }
                }
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            //���һ�����ݲ��Ҹ�ֵ
            //
            if (DoCheck())
            {
                
                if (btnAddItem.Text == "����")
                {
                    CurrentRow = GetRowByItemCode(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);

                    if (CurrentRow == -1)//��̬����û�й������ϡ�
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
                        //���
                        temp_num = decimal.Parse(txtReqNum.Text);
                        temp_price = decimal.Parse(txtItemPrice.Text);
                        temp_money = Math.Round((temp_num * temp_price), 2);

                        dr["ItemMoney"] = temp_money.ToString("0.##");

                        dr["ReqDate"] = txtReqDate.Text;
                        this.thisTable.Rows.Add(dr);
                    }
                    else//��̬�����Ѿ����ڸ����ϡ�
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow]["ItemNum"] = temp_num;
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
                    else//�޸ĺ����ظ����ϣ��������ֻ������ڶ�OTI���ϵ��޸ġ�
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
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
                }
            }
        }
        /// <summary>
        /// ɾ����ť��
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
