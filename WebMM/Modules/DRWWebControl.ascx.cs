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
	public partial class DRWWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
		//protected StorageDropdownlist ddlUnit;
 //20080408 ���ϵ�λ����
//20080408 ���ϵ�λID
		protected StorageDropdownlist ddlStorage;
		//public static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
		private string tmpCode;
		private string _OP;
		//private string _StoCode;
		protected MZHMM.WebMM.Modules.USWebControl USPurpose;
		//public DGModel_Items DGModel_Items1;

        decimal StockNum;
        decimal PlanNum;
        decimal ItemNum;

	    private string tempstr;

	    private int ret;

	    private int i;
       // decimal SubTotal;

	    private int CurrentRow;

        ItemSystem oItemSystem = new ItemSystem();

        WDRWData oWDRWData = new WDRWData();
      
        StockData oStockData;
        private decimal retValue = 0;

	    private decimal tmpDecimal;

	    private string PKIDs;

	    private bool bret;

	    private DataRow oDR;

	    private decimal temp_num;
	    private decimal temp_price;
	    private decimal temp_money;

	    private DataRow dr;

	    private DataRow NewRow;

	    private int iRow;

        private ItemData oItemData = new ItemData();
	    private string temp_StoCode;
	    private string temp_StoName;

	    private string ItemCode;
	    private int ConCode;



		#endregion

		#region ����
        /// <summary>
        /// �Ƿ���ʾ����
        /// </summary>
        public bool IsDisplayDRWPrice
        {
            get
            {
                if (ViewState["IsDisplayDRWPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayDRWPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayDRWPrice"] = value;
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
                    if (string.IsNullOrEmpty(Request["EntryNo"]))
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
		/// ��̬DataTable��
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.DRW_DT] != null)
					return (DataTable)Session[MySession.DRW_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.DRW_DT] = value;
			}
		}
		/// <summary>
		/// ��ע���ԡ�
		/// </summary>
		public string Remark
		{
			get {return this.txtRemark.Text;}
			set { this.txtRemark.Text = value;}
		}
		/// <summary>
		/// �ֿ��š�
		/// </summary>
		public string StoCode
		{
			get { return this.ddlStorage.SelectedValue; }
			set { this.ddlStorage.SelectedValue = value; }
		}
		public string StoName
		{
			get {return this.ddlStorage.SelectedText;}
			set {this.ddlStorage.SelectedText = value;}
		}
		/// <summary>
		/// ��;��š�
		/// </summary>
		public string ReqReasonCode
		{
			get { return this.USPurpose.SelectedValue;}
			set { this.USPurpose.SelectedValue = value;}
		}
		/// <summary>
		/// ��;��
		/// </summary>
		public string ReqReason
		{
			get { return this.USPurpose.SelectedText;}
			set { this.USPurpose.SelectedText = value;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// �ھ�̬���м��������Ƿ��Ѿ����ڡ�
		/// </summary>
		/// <param name="ItemCode">string:	Ҫ�������ϱ�š�</param>
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
		/// ���ݲֿ��š�������Ϣ��ȡ�����Ϣ��
		/// </summary>
		/// <param name="StoCode">string:	�ֿ��š�</param>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ItemName">string:	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns></returns>
		private decimal GetStockNumByStoCodeAndItem(string StoCode,string ItemCode, string ItemName, string ItemSpec)
		{
			oItemSystem = new ItemSystem();
			
			retValue = 0;
			oStockData = oItemSystem.GetStockSumByStoCodeAndItem(StoCode,ItemCode,ItemName,ItemSpec);
			if ( oStockData.Count > 0)
			{
				retValue = Convert.ToDecimal(oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString());
			}
			return retValue;
		}
		/// <summary>
		///	��ȡ���ϵ��ܿ�档
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ItemName">string:	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns>decimal:	�ܿ������</returns>
		private decimal GetStockSumByItem(string ItemCode, string ItemName, string ItemSpec)
		{
			
			retValue = 0;
		    tempstr = "";
			oStockData = oItemSystem.GetStockSumByItem(ItemCode, ItemName, ItemSpec);
			if ( oStockData.Count > 0)
			{
				tempstr = oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString();
				retValue = Convert.ToDecimal(oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString());
			}
			return retValue;
		}
		/// <summary>
		/// ����������Դ�������Ƿ��Ѿ����ڼ�¼��
		/// </summary>
		/// <param name="EntryNo">string:	Դ������ˮ�š�</param>
		/// <param name="DocCode">string:	Դ�������ͺš�</param>
		/// <param name="SerialNo">string:	Դ����˳��š�</param>
		/// <returns>int:	��¼��DataTable�е��кš�-1��ʾû�С�</returns>
		private int GetRowBySource(string EntryNo, string DocCode, string SerialNo)
		{
			ret = -1;
			for (i = 0; i< this.thisTable.Rows.Count; i++)
			{
				if (this.thisTable.Rows[i][WDRWData.SOURCEENTRY_FIELD].ToString() == EntryNo &&
					this.thisTable.Rows[i][WDRWData.SOURCEDOCCODE_FIELD].ToString() == DocCode &&
					this.thisTable.Rows[i][WDRWData.SOURCESERIALNO_FIELD].ToString() == SerialNo)
				{

					return i;
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
//				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtReqNum.Text!="") && (txtReqDate.Text!="") && (ddlUnit.SelectedValue!="-1"))
				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtReqNum.Text!="") && (ddlUnit.SelectedValue!="-1"))
				{
				    if(txtItemNum.Text!="")
						tmpDecimal = decimal.Parse(txtItemNum.Text);
				}
				else
				{
                    Page.RegisterStartupScript("errow", "<script>alert(\"���ϱ�š��������ơ���λ��������������Ϊ�գ�\");</script>");
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

		#region ��������
		/// <summary>
		/// ����Һ������ָ����Һ���أ��Զ�����������ϸ��
		/// </summary>
		/// <param name="ConCode">int:	Һ���غš�</param>
		public void SetDrawDetail(int ConCode)
		{
			oStockData = new ItemSystem().GetStockByConCode(ConCode);
			for (i = 0; i< oStockData.Count; i++)
			{
				oDR = this.thisTable.NewRow();
				oDR["ItemCode"] = oStockData.Tables[StockData.WSTK_TABLE].Rows[i][StockData.ITEMCODE_FIELD];
				oDR["ItemName"] = oStockData.Tables[StockData.WSTK_TABLE].Rows[i][StockData.ITEMNAME_FIELD];
				oDR["ItemSpecial"] = oStockData.Tables[StockData.WSTK_TABLE].Rows[i][StockData.ITEMSPEC_FIELD];
				oDR["ItemUnit"] = oStockData.Tables[StockData.WSTK_TABLE].Rows[i][StockData.ITEMUNIT_FIELD];
				oDR["ItemUnitName"] = oStockData.Tables[StockData.WSTK_TABLE].Rows[i][StockData.ITEMUNITNAME_FIELD];
				oDR["ItemPrice"] = oStockData.Tables[StockData.WSTK_TABLE].Rows[i][StockData.ITEMPRICE_FIELD];
				oDR["PlanNum"] = oStockData.Tables[StockData.WSTK_TABLE].Rows[i][StockData.ITEMNUM_FIELD];
				oDR["ItemMoney"] = oStockData.Tables[StockData.WSTK_TABLE].Rows[i][StockData.ITEMMONEY_FIELD];
				this.thisTable.Rows.Add(oDR);
			}
		}
		#endregion
		
		

		#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.ddlStorage.Module_Tag = (int)SDDLTYPE.STORAGE;
			}
			//this.ddlStorage.Width = "100%";
			this.ddlStorage.AutoPostBack = true;
            txtItemPrice.Visible = IsDisplayDRWPrice;
			//this.USPurpose.Width = "90%";
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!string.IsNullOrEmpty(Request["Op"] ))
			{
				this._OP = this.Request["Op"];
			}
			//this.USPurpose.Flag = 1;
			//�½����޸�״̬�¡�
			if (!this.IsPostBack)
			{
				switch (this._OP)
				{
					case OP.New:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAWAuthor;
						this.USPurpose.Disabled = true;
						break;
					case OP.Edit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAWAuthor;
						this.USPurpose.Disabled = true;
						break;
					case OP.Submit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAWAuthor;
						this.USPurpose.Disabled = false;
						break;
					case OP.FirstAudit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAW;
						this.USPurpose.Disabled = false;
						break;
					case OP.SecondAudit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAW;
						this.USPurpose.Disabled = false;
						break;
					case OP.ThirdAudit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAW;
						this.USPurpose.Disabled = false;
						break;
					case OP.O:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAW;
						this.USPurpose.Disabled = false;
						break;
					case OP.Red:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.DRAWAuthor;
						this.USPurpose.Disabled = false;
						break;
				}
			}
			//����ģʽ�£���������е������ݵ��޸ġ�
			if (this._OP == OP.FirstAudit || this._OP == OP.SecondAudit || this._OP == OP.ThirdAudit  || this._OP == OP.Red || this._OP == OP.O)
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
                this.ddlStorage.Enable = false;
				
			}
			//����ģʽ�¡�
			if (this._OP == OP.O)
			{
				this.btnAddItem.Enabled = false;
				this.btnDelItem.Enabled = false;
                this.btnEditItem.Enabled = true;
				this.txtRemark.ReadOnly = true;
				this.txtItemCode.ReadOnly = true;
				this.txtItemName.ReadOnly = true;
				this.txtItemSpecial.ReadOnly = true;
				this.ddlUnit.Enable = false;
				this.txtItemPrice.ReadOnly = true;
				this.txtReqNum.ReadOnly = true;
				this.btnWWBrowser.Disabled = true;
                txtItemNum.ReadOnly = false;
			}
			else
				this.txtItemNum.ReadOnly = true;
			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//��ʼ��
			//DGModel_Items1.ShowPager=false;

			if(!this.IsPostBack && (this.Request["Op"] == OP.New && (this.Request["PKIDs"] ==null || this.Request["PKIDs"] == "")))
			{
				//���������ݽṹ
				if(this.thisTable!=null) this.thisTable.Dispose();
				this.thisTable=new DataTable();

				DataColumnCollection columns = this.thisTable.Columns;
				columns.Add(WDRWData.SourceEntry_Field);
				columns.Add(WDRWData.SourceDocCode_Field);
				columns.Add(WDRWData.SourceSerialNo_Field);
			    columns.Add("NewCode");
				columns.Add("ItemCode");
				columns.Add("ItemName");
				columns.Add("ItemSpecial");
				columns.Add("ItemUnit");
				columns.Add("ItemUnitName");
				columns.Add("StockNum");
				columns.Add("ItemPrice");
				columns.Add("PlanNum").DataType = typeof(System.Decimal);
				columns.Add("ItemNum").DataType=typeof(System.Decimal);
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


            if (OperateRed == true)
            {
                this.btnAddItem.Enabled = false;
                this.btnEditItem.Enabled = false;
                this.btnDelItem.Enabled = false;
                ddlStorage.Enable = false;
                btnWWBrowser.Visible = false;
                txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
            }
		}

        /*
		/// <summary>
		/// ҳ��UnLoad�¼���
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//�ͷž�̬����dt
			//this.thisTable.Dispose();
		}*/
		
		protected override bool OnBubbleEvent(object Sender,EventArgs e)
		{
			try
			{
				if (((System.Web.UI.WebControls.DropDownList)Sender).ClientID == this.ddlStorage.ClientID)
				{
					if (this.ddlStorage.SelectedValue != "-1")					
					{
						if (this.thisTable.Rows.Count > 0)//�����̬�����м�¼����Ҫˢ�µ�ǰ����ֶε�ֵ��
						{
							for (i = 0; i< this.thisTable.Rows.Count; i++)
							{
								//TODO: StoCode.
								StockNum = this.GetStockNumByStoCodeAndItem(this.StoCode,
									this.thisTable.Rows[i]["ItemCode"].ToString(),
									this.thisTable.Rows[i]["ItemName"].ToString(),
									this.thisTable.Rows[i]["ItemSpecial"].ToString());
								this.thisTable.Rows[i]["StockNum"] = StockNum;
							}
						}
						this.DGModel_Items1.DataBind();
					}
				}
			}
			catch
			{}
			return true;
		}

		
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

        protected void btnAddItem_Click1(object sender, EventArgs e)
        {
            //
            //���һ�����ݲ��Ҹ�ֵ
            //
            if (DoCheck())
            {
                 //TODO: StoCode.
                if (this.txtItemCode.Text.Substring(0, 2) != this.StoCode)
                {
                    Page.RegisterStartupScript("Error", "<script>alert('���ѣ���ǰ�ֿ������ϱ�Ų�ƥ��!');</script>");
                }
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
                        //dr["StockNum"] = this.GetStockSumByItem(txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
                        dr["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode, txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
                        dr["ItemPrice"] = txtItemPrice.Text;
                        dr["PlanNum"] = txtReqNum.Text;
                        dr["ItemNum"] = 0;
                        //���
                        temp_num = decimal.Parse(txtReqNum.Text);
                        temp_price = decimal.Parse(txtItemPrice.Text);
                        temp_money = Math.Round((temp_num * temp_price), 2);

                        dr["ItemMoney"] = temp_money.ToString("0.##");

                        //dr["ReqDate"]=txtReqDate.Text;
                        this.thisTable.Rows.Add(dr);

                    }
                    else//��̬�����Ѿ����ڸ����ϡ�
                    {
                        //temp_num = Convert.ToDecimal(dt.Rows[CurrentRow]["ItemNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        //dt.Rows[CurrentRow]["ItemNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                    }
                }
                else
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
                        dr["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode, txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
                        dr["ItemPrice"] = txtItemPrice.Text;
                        dr["PlanNum"] = txtReqNum.Text;
                        if (txtItemNum.Text != "")
                            dr["ItemNum"] = txtItemNum.Text;

                        temp_num = decimal.Parse(txtReqNum.Text);
                        temp_price = decimal.Parse(txtItemPrice.Text);
                        temp_money = temp_num * temp_price;
                        dr["ItemMoney"] = temp_money.ToString("0.##");
                    }
                    else//�޸ĺ����ظ����ϣ��������ֻ������ڶ�OTI���ϵ��޸ġ�
                    {
                        temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtReqNum.Text);
                        temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
                        temp_money = Math.Round((temp_num * temp_price), 2);
                        this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
                        this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
                        this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//ɾ��ԭ���С�
                    }
                    txtItemSerial.Value = "-1";
                    btnAddItem.Text = "����";
                    if (this._OP == OP.O)
                    {
                        this.btnAddItem.Enabled = false;
                    }
                }
                DGModel_Items1.DataSource = this.thisTable;
                DGModel_Items1.DataBind();

                hfNewCode.Value = string.Empty;
                txtItemCode.Text = "";
                txtItemName.Text = "";
                txtItemSpecial.Text = "";
                txtReqNum.Text = "";
                this.txtItemNum.Text = "";
                ddlUnit.SetItemSelected("-1");
                //txtReqDate.Text="";
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
                 {
                     this.thisTable.Rows.RemoveAt(iRow);
                 }

                DGModel_Items1.DataSource = this.thisTable;
                DGModel_Items1.DataBind();
            }
        }

        protected void btnEditItem_Click(object sender, EventArgs e)
        {
            //������-1��ʾ�Ѿ����ڱ༭״̬
            if (txtItemSerial.Value == "-1")
            {
                if (!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
                {
                    iRow = GetRowIndex(DGModel_Items1.SelectedID);

                    this.txtItemSerial.Value = iRow.ToString();
                    this.hfNewCode.Value = this.thisTable.Rows[iRow]["NewCode"].ToString();
                    this.txtItemCode.Text = this.thisTable.Rows[iRow]["ItemCode"].ToString();
                    this.txtItemName.Text = this.thisTable.Rows[iRow]["ItemName"].ToString();
                    this.txtItemSpecial.Text = this.thisTable.Rows[iRow]["ItemSpecial"].ToString();
                    //txtReqNum.Text=dt.Rows[iRow]["ItemNum"].ToString();
                    if (this.thisTable.Rows[iRow]["ItemNum"] != null && this.thisTable.Rows[iRow]["ItemNum"].ToString() != "")
                    {
                        this.txtItemNum.Text = Convert.ToDecimal(this.thisTable.Rows[iRow]["ItemNum"].ToString()).ToString("0.###");
                    }

                    this.txtReqNum.Text = Convert.ToDecimal(this.thisTable.Rows[iRow]["PlanNum"].ToString()).ToString("0.###");
                    //txtReqDate.Text=dt.Rows[iRow]["ReqDate"].ToString();
                    this.txtItemPrice.Text = Convert.ToDecimal(this.thisTable.Rows[iRow]["ItemPrice"].ToString()).ToString("0.000");
                    //������λ
                    this.ddlUnit.SetItemSelected(this.thisTable.Rows[iRow]["ItemUnit"].ToString());

                    this.btnAddItem.Text = "����";
                    this.btnAddItem.Enabled = true;
                }
            }
        }

        protected void btnForPKID_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPKIDs.Value))
            {
                PKIDs = this.txtPKIDs.Value;
               
                oWDRWData = oItemSystem.GetWDRWSourceDetailByPKIDs(PKIDs);
                //������;��
                if (oWDRWData.SourceDetailCount > 0)
                {
                    if (string.IsNullOrEmpty(USPurpose.SelectedValue))
                    {
                        this.USPurpose.SelectedValue = oWDRWData.Tables[WDRWData.WDSD_VIEW].Rows[0][WDRWData.REQREASONCODE_FIELD].ToString();
                        this.USPurpose.SelectedText = oWDRWData.Tables[WDRWData.WDSD_VIEW].Rows[0][WDRWData.REQREASON_FIELD].ToString();
                    }
                }
                for (i = 0; i < oWDRWData.SourceDetailCount; i++)
                {
                    dr = oWDRWData.Tables[WDRWData.WDSD_VIEW].Rows[i];
                    //�жϸ����Ƿ���ڡ�
                    CurrentRow = this.GetRowBySource(dr[WDRWData.SourceEntry_Field].ToString(), dr[WDRWData.SourceDocCode_Field].ToString(), dr[WDRWData.SourceSerialNo_Field].ToString());
                    if (CurrentRow == -1)//��������ڡ�
                    {
                        NewRow = this.thisTable.NewRow();
                        NewRow[WDRWData.SourceEntry_Field] = dr[WDRWData.SourceEntry_Field].ToString();
                        NewRow[WDRWData.SourceDocCode_Field] = dr[WDRWData.SourceDocCode_Field].ToString();
                        NewRow[WDRWData.SourceSerialNo_Field] = dr[WDRWData.SourceSerialNo_Field].ToString();
                        NewRow[InItemData.NEWCODE_FIELD] = dr[InItemData.NEWCODE_FIELD];
                        NewRow[InItemData.ITEMCODE_FIELD] = dr[InItemData.ITEMCODE_FIELD];
                        NewRow[InItemData.ITEMNAME_FIELD] = dr[InItemData.ITEMNAME_FIELD];
                        NewRow[InItemData.ITEMSPECIAL_FIELD] = dr[InItemData.ITEMSPECIAL_FIELD];
                        NewRow[InItemData.ITEMUNIT_FIELD] = dr[InItemData.ITEMUNIT_FIELD];
                        NewRow[InItemData.ITEMUNITNAME_FIELD] = dr[InItemData.ITEMUNITNAME_FIELD];
                        NewRow[WDRWData.PLANNUM_FIELD] = dr[WDRWData.PLANNUM_FIELD];
                        //TODO: StoCode.
                        NewRow["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode,
                                                                              dr[InItemData.ITEMCODE_FIELD].ToString(),
                                                                              dr[InItemData.ITEMNAME_FIELD].ToString(),
                                                                              dr[InItemData.ITEMSPECIAL_FIELD].ToString());
                        NewRow[InItemData.ITEMPRICE_FIELD] = dr[InItemData.ITEMPRICE_FIELD];
                        NewRow[InItemData.ITEMMONEY_FIELD] = dr[InItemData.ITEMMONEY_FIELD];
                        this.thisTable.Rows.Add(NewRow);
                    }
                }
            }
            this.DGModel_Items1.DataSource = this.thisTable;
            this.DGModel_Items1.DataBind();
        }

        protected void btnForItemCode_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text != "")
            {
                if (txtItemCode.Text != "-1")
                {
                    //�����������ƣ�����ͺţ����ۿؼ�Ϊֻ�����ҵ���λ�ؼ�
                    this.txtItemName.ReadOnly = true;
                    this.txtItemSpecial.ReadOnly = true;
                    this.txtItemPrice.ReadOnly = true;
                    this.ddlUnit.Enable = false;
                    //��Ҫ���������ݿ��л�ȡ
                    oItemData = new ItemSystem().GetItemByCode(this.txtItemCode.Text);
                    //������������
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
                    {
                        this.hfNewCode.Value = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.NEWCODE_FIELD].ToString();
                        this.txtItemCode.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
                        this.txtItemName.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
                        this.txtItemSpecial.Text = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
                        if (this.StoCode == "-1")//����ֿ⻹Ϊ�գ�����������������òֿ⡣
                        {
                            temp_StoCode = this.txtItemCode.Text.Substring(0, 2);
                            temp_StoName = new ItemSystem().GetStoByCode(this.txtItemCode.Text.Substring(0, 2)).Tables[StoData.STO_TABLE].Rows[0][StoData.DESCRIPTION_FIELD].ToString();
                            //this.StoCode = temp_StoCode;
                            //this.StoName = temp_StoName;
                            this.ddlStorage.SetItemSelected(temp_StoCode);
                        }

                        try { this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###"); }
                        catch
                        {
                            try { this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.EVAPRICE_FIELD].ToString()).ToString("0.###"); }
                            catch { this.txtItemPrice.Text = "0.000"; }
                        }

                        this.ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());

                        if (this.txtItemCode.Text == new SysSystem().GetSTAGInfo().ItemCode)//�����Һ����
                        {
                            //��ʼ��������������������ΪSTAG����ConCode1��Ӧ���е���������
                           ItemCode = new SysSystem().GetSTAGInfo().ItemCode;
                            ConCode = new SysSystem().GetSTAGInfo().ConCode1;
                            oStockData = new ItemSystem().GetStockSumByItemCodeAndConCode(ItemCode, ConCode);
                            if (oStockData.Count > 0)
                            {
                                this.txtReqNum.Text = Convert.ToDecimal(oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString()).ToString("0.##");
                            }
                        }
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
                        this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
                        //������λ
                        ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                    }
                }
            }
        }

        protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Header)
            //{
            //    if (_OP == OP.New || _OP == OP.Edit || _OP == OP.Submit || _OP == OP.Red)
            //    {
            //        e.Item.Cells[7].Visible = true;
            //    }
            //    else
            //    {
            //        e.Item.Cells[7].Visible = false;
            //    }

            //}
            //else 
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[8].Visible = IsDisplayDRWPrice;
                e.Item.Cells[9].Visible = IsDisplayDRWPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('../Analysis/DocRoute.aspx?EntryNo=" + this.EntryNo.ToString() + "&DocCode=4&SerialNo=" + e.Item.ItemIndex.ToString() + "&ItemCode=" + e.Item.Cells[0].Text + "','browser','scrollbars=yes, resizable=yes,height=600,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,location=no, status=no')");
                try
                {
                    e.Item.Cells[8].Visible = IsDisplayDRWPrice;
                    e.Item.Cells[9].Visible = IsDisplayDRWPrice;
                    StockNum = decimal.Parse(e.Item.Cells[5].Text); 
                }
                catch
                { 
                    StockNum = 0; 
                }
                try
                {
                    PlanNum = decimal.Parse(e.Item.Cells[6].Text); 
                }
                catch
                { 
                    PlanNum = 0; 
                }
                try
                {
                    ItemNum = decimal.Parse(e.Item.Cells[7].Text); 
                }
                catch
                { 
                    ItemNum = 0; 
                }

                if ((StockNum < PlanNum && (this._OP == "New" || this._OP == "Edit")) ||
                             (StockNum < ItemNum && this._OP == "Out")
                           )
                {
                    e.Item.BackColor = Color.Red;
                }

                //if (_OP == OP.New || _OP == OP.Edit || _OP == OP.Submit || _OP == OP.Red)
                //{
                //    e.Item.Cells[7].Visible = true;
                //}
                //else
                //{
                //    e.Item.Cells[7].Visible = false;
                //}

                //try
                //{
                //    SubTotal += decimal.Parse(e.Item.Cells[8].Text);
                //}
                //catch
                //{
                //    SubTotal += 0;
                //}

                //try
                //{
                //    e.Item.Cells[8].Text = string.Format("{0:c}", SubTotal);
                //}
               // catch { }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[8].Visible = IsDisplayDRWPrice;
                e.Item.Cells[9].Visible = IsDisplayDRWPrice;
            }
           

        }



       

      
		
	}
}
