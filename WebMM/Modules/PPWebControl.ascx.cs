using Shmzh.Components.SystemComponent.DALFactory;

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
	public partial class PPWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private string _OP;
        private decimal SubTotal;

        public string DeptCo { get; set; }

	    private int ret;

	    private bool bret;
	    private int i;

	    private ItemData oItemData = new ItemData();

	    private string strItemCode;

	    private int CurrentRow;

	    private int iRow;
	    private DataRow dr;
		#endregion

		#region ����

        /// <summary>
        /// �Ƿ���ʾ����
        /// </summary>
        public bool IsDisplayPPPrice
        {
            get
            {
                if (ViewState["IsDisplayPPPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayPPPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayPPPrice"] = value;
            }
        }

        public DataTable thisTable
        {
            get
            {
                if (Session[MySession.ORD_DT] != null)
                    return (DataTable)Session[MySession.ORD_DT];
                else
                    return null;
            }
            set
            {
                Session[MySession.ORD_DT] = value;
            }
        }

        /// <summary>
        /// �Ƿ��Ǻ��ֲ���
        /// </summary>
        public bool OperateRed
        {
            get
            {
                if (ViewState["OperateRed"] != null)
                    return bool.Parse(ViewState["OperateRed"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["OperateRed"] = value;
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
		#endregion

		#region ˽�з���
		/// <summary>
		/// ���徲̬���ݱ�����ݽṹ��
		/// </summary>
		private void CreateDataTable()
		{
			//���������ݽṹ
			if(this.thisTable!=null) 
				this.thisTable = null;

			this.thisTable = new DataTable();

			DataColumnCollection columns = this.thisTable.Columns;
			columns.Add("SourceEntry");			//Դ������ˮ�š�
			columns.Add("SourceDocCode");		//Դ�������͡�
		    columns.Add("NewCode");
			columns.Add("ItemCode");			//���ϱ�š�
			columns.Add("ItemName");			//�������ơ�
			columns.Add("ItemSpecial");			//����ͺš�
			columns.Add("ItemUnit");			//��λ��
			columns.Add("ItemUnitName");		//��λ���ơ�
			columns.Add("ItemPrice").DataType = typeof(System.Decimal);	//���ۡ�
			columns.Add("ItemNum").DataType=typeof(System.Decimal);//�ƻ�������
			columns.Add("ItemMoney").DataType = typeof(System.Decimal);//��
			columns.Add("ReqDept");//���벿�š�
			columns.Add("ReqDeptName");//���벿�����ơ�
			columns.Add("ReqReasonCode");//��;��š�
			columns.Add("ReqReason");//��;���ơ�
			columns.Add("ReqDate");//Ҫ�����ڡ�
            columns.Add("Proposer");//������
			columns.Add("Remark");//��ע��
		}
		/// <summary>
		/// �ھ�̬���м��������Ƿ��Ѿ����ڡ�
		/// </summary>
		/// <param name="ItemCode">string:	Ҫ�������ϱ�š�</param>
		/// <param name="ReqDept"></param>
		/// <param name="ItemName"></param>
		/// <param name="ItemSpec"></param>
		/// <param name="ReqReasonCode"></param>
		/// <returns>int:	û�з���-1�����򷵻������е�������</returns>
		private int GetRowByItemCode(string ReqDept,string ItemCode,string ReqReasonCode,string ItemName, string ItemSpec)
		{
			ret = -1;
			if (ItemCode != "-1")//��OTI���ϡ�
			{
				for (i = 0; i < this.thisTable.Rows.Count; i++)
				{
					if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode &&
						this.thisTable.Rows[i][PurchasePlanData.REQDEPT_FIELD].ToString() == ReqDept &&
						this.thisTable.Rows[i][PurchasePlanData.REQREASONCODE_FIELD].ToString() == ReqReasonCode)
					{
						return i;
					}
				}
			}
			else//OTI���ϵı�Ŷ�Ϊ-1������Ҫ�����������ƺ͹���ͺŵ��жϡ�
			{
				for (i=0; i < this.thisTable.Rows.Count; i++)
				{
					if (this.thisTable.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode &&
						this.thisTable.Rows[i][PurchasePlanData.REQDEPT_FIELD].ToString() == ReqDept &&
						this.thisTable.Rows[i][PurchasePlanData.REQREASONCODE_FIELD].ToString() == ReqReasonCode&&
						this.thisTable.Rows[i][InItemData.ITEMNAME_FIELD].ToString() == ItemName &&
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
			    if ((ddlReqDept.SelectedValue != "-1") && (txtItemCode.Text != "") && (txtItemName.Text != "") && (txtReqNum.Text != "") && (txtReqDate.Text != "") && (ddlUnit.SelectedValue != "-1"))
                {
                    decimal.Parse(txtReqNum.Text);
                    DateTime.Parse(txtReqDate.Text);
                }
				else
				{
					Page.RegisterStartupScript(  "DoCheck", "<script>alert(\"���벿�š����ϱ�š��������ơ���λ���������������ڲ���Ϊ�գ�\");</script>");
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
		
		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Unload += new System.EventHandler(this.Page_UnLoad);
        }
		#endregion

		#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsDisplayPPPrice)
            {
                txtItemPrice.Visible = false;
            }
            else
            {
                txtItemPrice.Visible = true;
            }
            if (OperateRed)
            {
                this.btnAddItem.Enabled = false;
                this.btnEditItem.Enabled = false;
                this.btnDelItem.Enabled = false;
            }

           
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//����ģʽ�£���������е������ݵ��޸ġ�
			if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.txtRemark.Enabled = false;

			    var DifferGXGZ = DataProvider.SettingProvider.GetByKey("DifferGXGZ");
                if(DifferGXGZ == null || DifferGXGZ.Value != "1")
                {
                    this.MzhDataGrid1.Visible = false;
                    this.titleGXGZ.Visible = false;
                    this.MzhDataGrid2.Visible = false;
                    this.DGModel_Items1.Visible = true;
                }
                else
                {
                    this.DGModel_Items1.Visible = false;
                    this.MzhDataGrid1.Visible = true;
                    this.titleGXGZ.Visible = true;
                    this.MzhDataGrid2.Visible = true;
                }
			}
			//������ģʽ��һ�ε���ҳ�档
			if((!this.IsPostBack) && (this.Request["Op"]=="New"))
			{
				//this.CreateDataTable();//�������ݱ�ṹ��
				DGModel_Items1.DataSource=this.thisTable;//�󶨡�
				DGModel_Items1.DataBind();
				//��ʼ��һЩ��
				//�����б�
				this.ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
                this.ddlReqDept.Module_Tag = (int)SDDLTYPE.AllDept;
			    ddlReqDept.DeptCo = this.DeptCo;
				this.ddlReqDept.UserCode = Session[MySession.UserLoginId].ToString();
				this.ddlReqDept.DocType = DocType.PP;

			}
			else
			{
				if(!this.IsPostBack)
				{
					//�����б�
					this.ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
					this.ddlReqDept.Module_Tag = (int)SDDLTYPE.AllDept;
                    ddlReqDept.DeptCo = this.DeptCo;
					this.ddlReqDept.UserCode = Session[MySession.UserLoginId].ToString();
					this.ddlReqDept.DocType = DocType.PP;
				}
                if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
                {
                    var DifferGXGZ = DataProvider.SettingProvider.GetByKey("DifferGXGZ");
                    if (DifferGXGZ == null || DifferGXGZ.Value != "1")
                    {
                        DGModel_Items1.DataSource = this.thisTable;
                        DGModel_Items1.DataBind();
                    }
                    else
                    {
                        var dv1 = new DataView(this.thisTable, "TopClassify<>'A'", string.Empty,
                                               DataViewRowState.CurrentRows);
                        var dv2 = new DataView(this.thisTable, "TopClassify='A'", string.Empty,
                                               DataViewRowState.CurrentRows);
                        this.MzhDataGrid1.DataSource = dv1;
                        this.MzhDataGrid2.DataSource = dv2;

                        this.MzhDataGrid1.DataBind();
                        this.MzhDataGrid2.DataBind();
                    }
                }
                else
                {
                    DGModel_Items1.DataSource=this.thisTable;				
				    DGModel_Items1.DataBind();
                }
				
			}
		}
		/// <summary>
		/// ҳ��UnLoad�¼���
		/// </summary>
		protected void Page_UnLoad(object sender, System.EventArgs e)
		{
			//�ͷž�̬����dt
            if(thisTable != null)
			    this.thisTable.Dispose();
		}
		#endregion

        protected void btnForItemCode_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text != "")
            {
                if (txtItemCode.Text != "-1")
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
                        {
                            this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        }
                        catch
                        {
                            try
                            {
                                this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.EVAPRICE_FIELD].ToString()).ToString("0.###");
                            }
                            catch
                            {
                                this.txtItemPrice.Text = "0.000";
                            }
                        }
                        //������λ
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
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
                        try
                        {
                            this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        }
                        catch
                        {
                            try
                            {
                                this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.EVAPRICE_FIELD].ToString()).ToString("0.###");
                            }
                            catch
                            {
                                this.txtItemPrice.Text = "0.000";
                            }
                        }
                        //������λ
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }
                }
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (DoCheck())
            {
                decimal temp_num, temp_price, temp_money;

                if (btnAddItem.Text == "����")
                {
                   
                    CurrentRow = GetRowByItemCode(this.ddlReqDept.SelectedValue, txtItemCode.Text, this.ddlPurpose.SelectedValue,
                                                    this.txtItemName.Text, this.txtItemSpecial.Text);

                    if (CurrentRow == -1)//��̬����û�й������ϡ�
                    {
                        dr = this.thisTable.NewRow();
                        dr[PurchasePlanData.REQDEPT_FIELD] = this.ddlReqDept.SelectedValue;
                        dr[PurchasePlanData.REQDEPTNAME_FIELD] = this.ddlReqDept.SelectedText;
                        dr[InItemData.NEWCODE_FIELD] = this.hfNewCode.Value;
                        dr[InItemData.ITEMCODE_FIELD] = this.txtItemCode.Text;
                        dr[InItemData.ITEMNAME_FIELD] = this.txtItemName.Text;
                        dr[InItemData.ITEMSPECIAL_FIELD] = this.txtItemSpecial.Text;
                        dr[InItemData.ITEMUNIT_FIELD] = this.ddlUnit.SelectedValue;
                        dr[InItemData.ITEMUNITNAME_FIELD] = this.ddlUnit.SelectedText;
                        dr[InItemData.ITEMPRICE_FIELD] = this.txtItemPrice.Text;
                        dr[InItemData.ITEMNUM_FIELD] = this.txtReqNum.Text;
                        dr[PurchasePlanData.REQREASONCODE_FIELD] = this.ddlPurpose.SelectedValue;
                        dr[PurchasePlanData.REQREASON_FIELD] = this.ddlPurpose.SelectedText;
                        //���
                        temp_num = decimal.Parse(this.txtReqNum.Text);
                        temp_price = decimal.Parse(this.txtItemPrice.Text);
                        temp_money = Math.Round((temp_num * temp_price), 2);

                        dr[InItemData.ITEMMONEY_FIELD] = temp_money.ToString("0.##");
                        dr[PurchasePlanData.REQDATE_FIELD] = this.txtReqDate.Text;
                        dr[InItemData.REMARK_FIELD] = this.txtRemark.Text;
                        dr["Proposer"] = "";
                        this.thisTable.Rows.Add(dr);
                    }
                    else//��̬�����Ѿ����ڸ����ϡ�
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD].ToString())
                                 + Convert.ToDecimal(this.txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD] = temp_num;
                        this.thisTable.Rows[CurrentRow][InItemData.ITEMMONEY_FIELD] = temp_money;
                    }
                }
                else//���¡�
                {
                    iRow = int.Parse(txtItemSerial.Value);
                    dr = this.thisTable.Rows[iRow];
                    CurrentRow = GetRowByItemCode(this.ddlReqDept.SelectedValue, txtItemCode.Text, this.ddlPurpose.SelectedValue,
                                                    this.txtItemName.Text, this.txtItemSpecial.Text);
                    if (CurrentRow == iRow || CurrentRow == -1)//û���ظ����ϡ�
                    {
                        dr[PurchasePlanData.REQDEPT_FIELD] = this.ddlReqDept.SelectedValue;
                        dr[PurchasePlanData.REQDEPTNAME_FIELD] = this.ddlReqDept.SelectedText;
                        dr[InItemData.NEWCODE_FIELD] = this.hfNewCode.Value;
                        dr[InItemData.ITEMCODE_FIELD] = this.txtItemCode.Text;
                        dr[InItemData.ITEMNAME_FIELD] = this.txtItemName.Text;
                        dr[InItemData.ITEMSPECIAL_FIELD] = this.txtItemSpecial.Text;
                        dr[InItemData.ITEMUNIT_FIELD] = this.ddlUnit.SelectedValue;
                        dr[InItemData.ITEMUNITNAME_FIELD] = this.ddlUnit.SelectedText;
                        dr[InItemData.ITEMPRICE_FIELD] = this.txtItemPrice.Text;
                        dr[InItemData.ITEMNUM_FIELD] = this.txtReqNum.Text;
                        temp_num = decimal.Parse(this.txtReqNum.Text);
                        temp_price = decimal.Parse(this.txtItemPrice.Text);
                        temp_money = temp_num * temp_price;
                        dr[InItemData.ITEMMONEY_FIELD] = temp_money.ToString("0.##");
                        dr[PurchasePlanData.REQREASONCODE_FIELD] = this.ddlPurpose.SelectedValue;
                        dr[PurchasePlanData.REQREASON_FIELD] = this.ddlPurpose.SelectedText;
                        dr[PurchasePlanData.REQDATE_FIELD] = this.txtReqDate.Text;
                        dr[InItemData.REMARK_FIELD] = this.txtRemark.Text;

                    }
                    else//�޸ĺ����ظ����ϣ��������ֻ������ڶ�OTI���ϵ��޸ġ�
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow][InItemData.ITEMNUM_FIELD] = temp_num;
                        this.thisTable.Rows[CurrentRow][InItemData.ITEMMONEY_FIELD] = temp_money;
                        this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//ɾ��ԭ���С�
                    }
                    txtItemSerial.Value = "-1";
                    btnAddItem.Text = "����";
                }
                this.DGModel_Items1.DataSource = this.thisTable;
                this.DGModel_Items1.DataBind();

                this.hfNewCode.Value = string.Empty;
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtItemSpecial.Text = "";
                this.txtReqNum.Text = "";
                this.ddlUnit.SetItemSelected("-1");
                this.ddlPurpose.SelectedValue = "-1";
                this.ddlPurpose.SelectedText = "";
                this.ddlReqDept.SetItemSelected("-1");
                this.txtReqDate.Text = "";
                this.txtItemPrice.Text = "";
                this.txtRemark.Text = "";
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

                if(iRow > -1)
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
                    //int iRow = int.Parse(DGModel_Items1.SelectedID);

                    iRow = -1;
                    strItemCode = DGModel_Items1.SelectedID;
                    for (i = 0; i < thisTable.Rows.Count; i++)
                    {
                        if (strItemCode == this.thisTable.Rows[i]["ItemCode"].ToString())
                        {
                            iRow = i;
                        }
                    }
                    if (iRow > -1)
                    {
                        txtItemSerial.Value = iRow.ToString();

                        this.ddlReqDept.SetItemSelected(this.thisTable.Rows[iRow][PurchasePlanData.REQDEPT_FIELD].ToString());
                        this.hfNewCode.Value = this.thisTable.Rows[iRow][InItemData.NEWCODE_FIELD].ToString();
                        this.txtItemCode.Text = this.thisTable.Rows[iRow][InItemData.ITEMCODE_FIELD].ToString();
                        this.txtItemName.Text = this.thisTable.Rows[iRow][InItemData.ITEMNAME_FIELD].ToString();
                        this.txtItemSpecial.Text = this.thisTable.Rows[iRow][InItemData.ITEMSPECIAL_FIELD].ToString();
                        this.ddlUnit.SetItemSelected(this.thisTable.Rows[iRow][InItemData.ITEMUNIT_FIELD].ToString());
                        this.txtItemPrice.Text = this.thisTable.Rows[iRow][InItemData.ITEMPRICE_FIELD].ToString();
                        this.txtReqNum.Text = this.thisTable.Rows[iRow][InItemData.ITEMNUM_FIELD].ToString();
                        this.ddlPurpose.SelectedValue = this.thisTable.Rows[iRow][PurchasePlanData.REQREASONCODE_FIELD].ToString();
                        this.ddlPurpose.SelectedText = this.thisTable.Rows[iRow][PurchasePlanData.REQREASON_FIELD].ToString();
                        this.txtReqDate.Text = this.thisTable.Rows[iRow][PurchasePlanData.REQDATE_FIELD].ToString();
                        this.txtRemark.Text = this.thisTable.Rows[iRow][InItemData.REMARK_FIELD].ToString();
                        //������λ

                        btnAddItem.Text = "����";
                    }
                }
            }
        }

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                SubTotal = 0;

                e.Item.Cells[8].Visible = IsDisplayPPPrice;
                e.Item.Cells[10].Visible = IsDisplayPPPrice;

            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('../Analysis/DocRoute.aspx?EntryNo=" + this.EntryNo.ToString() + "&DocCode=5&SerialNo=" + e.Item.ItemIndex.ToString() + "&ItemCode=" + e.Item.Cells[0].Text + "','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                
                try
                {
                    e.Item.Cells[8].Visible = IsDisplayPPPrice;
                    e.Item.Cells[10].Visible = IsDisplayPPPrice;
                    SubTotal += decimal.Parse(e.Item.Cells[10].Text);
                }
                catch
                {
                    SubTotal += 0;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)//�����ǰ����ҳ���
            {
                
                e.Item.HorizontalAlign = HorizontalAlign.Center;
               
                e.Item.HorizontalAlign = HorizontalAlign.Right;
                try
                {
                    e.Item.Cells[8].Visible = IsDisplayPPPrice;
                    e.Item.Cells[10].Visible = IsDisplayPPPrice;

                    if (!IsDisplayPPPrice)
                        e.Item.Cells[9].Text = "";
                    e.Item.Cells[10].Text = string.Format("{0:c}", SubTotal);
                }
                catch
                {
                    e.Item.Cells[10].Text = SubTotal.ToString();
                }
            }
        }
	
	}
}
