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
	public partial class WTOWWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
		//protected StorageDropdownlist ddlUnit=new StorageDropdownlist();
 //20080408 ���ϵ�λ����
//20080408 ���ϵ�λID
		//public static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
		private string tmpCode;
		private string _OP;
		//private string _StoCode;
		protected System.Web.UI.WebControls.TextBox txtTotalFee;
		//public DGModel_Items DGModel_Items1;
        private decimal StockNum;//�����
        private decimal PlanNum;//������
        private decimal ItemNum;//ʵ������
	    private int ret;
	    private int i;

        ItemSystem oItemSystem = new ItemSystem();

	    private int CurrentRow;

	    private ItemData oItemData = new ItemData();

	    private bool bret;
        StockData oStockData;
        decimal retValue = 0;
        string tempstr;

	    private DataRow dr;

	    private int iRow;

		#endregion

		#region ����
        // <summary>
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

		/// <summary>
		/// ��̬DataTable��
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.WTOW_DT] != null)
					return (DataTable)Session[MySession.WTOW_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.WTOW_DT] = value;
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
		/// ��;��š�
		/// </summary>
//		public string ReqReasonCode
//		{
//			get { return this.USPurpose.SelectedValue;}
//			set { this.USPurpose.SelectedValue = value;}
//		}
		/// <summary>
		/// ��;��
		/// </summary>
//		public string ReqReason
//		{
//			get { return this.USPurpose.SelectedText;}
//			set { this.USPurpose.SelectedText = value;}
//		}
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
//		/// <summary>
//		/// ���ݲֿ��š�������Ϣ��ȡ�����Ϣ��
//		/// </summary>
//		/// <param name="StoCode">string:	�ֿ��š�</param>
//		/// <param name="ItemCode">string:	���ϱ�š�</param>
//		/// <param name="ItemName">string:	�������ơ�</param>
//		/// <param name="ItemSpec">string:	����ͺš�</param>
//		/// <returns></returns>
//		private decimal GetStockNumByStoCodeAndItem(string StoCode,string ItemCode, string ItemName, string ItemSpec)
//		{
//			ItemSystem oItemSystem = new ItemSystem();
//			StockData oStockData;
//			decimal retValue = 0;
//			oStockData = oItemSystem.GetStockSumByStoCodeAndItem(StoCode,ItemCode,ItemName,ItemSpec);
//			if ( oStockData.Count > 0)
//			{
//				retValue = Convert.ToDecimal(oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString());
//			}
//			return retValue;
//		}
		/// <summary>
		///	��ȡ���ϵ��ܿ�档
		/// </summary>
		/// <param name="ItemCode">string:	���ϱ�š�</param>
		/// <param name="ItemName">string:	�������ơ�</param>
		/// <param name="ItemSpec">string:	����ͺš�</param>
		/// <returns>decimal:	�ܿ������</returns>
		private decimal GetStockSumByItem(string ItemCode, string ItemName, string ItemSpec)
		{
			
			oStockData = oItemSystem.GetStockSumByItem(ItemCode, ItemName, ItemSpec);
			if ( oStockData.Count > 0)
			{
				tempstr = oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString();
				retValue = Convert.ToDecimal(oStockData.Tables[StockData.WSTK_TABLE].Rows[0][StockData.ITEMNUM_FIELD].ToString());
			}
			return retValue;
		}
//		/// <summary>
//		/// ����������Դ�������Ƿ��Ѿ����ڼ�¼��
//		/// </summary>
//		/// <param name="EntryNo">string:	Դ������ˮ�š�</param>
//		/// <param name="DocCode">string:	Դ�������ͺš�</param>
//		/// <param name="SerialNo">string:	Դ����˳��š�</param>
//		/// <returns>int:	��¼��DataTable�е��кš�-1��ʾû�С�</returns>
//		private int GetRowBySource(string EntryNo, string DocCode, string SerialNo)
//		{
//			int ret = -1;
//			for (int i = 0; i< this.thisTable.Rows.Count; i++)
//			{
//				if (this.thisTable.Rows[i][WDRWData.SOURCEENTRY_FIELD].ToString() == EntryNo &&
//					this.thisTable.Rows[i][WDRWData.SOURCEDOCCODE_FIELD].ToString() == DocCode &&
//					this.thisTable.Rows[i][WDRWData.SOURCESERIALNO_FIELD].ToString() == SerialNo)
//				{
//					return i;
//				}
//			}
//			return ret;
//		}
		/// <summary>
		/// �����ݽ���У��.
		/// </summary>
		/// <returns>bool:	У��ͨ������true��ʧ�ܷ���false��</returns>
		private bool DoCheck()
		{
		    bret=true;
			try
			{
				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtReqNum.Text!="") && (ddlUnit.SelectedValue!="-1"))
				{
					decimal.Parse(txtReqNum.Text);
					if(txtItemNum.Text!="")
						decimal.Parse(txtItemNum.Text);
				}
				else
				{
					Page.RegisterStartupScript("DoCheck","<script>alert(\"���ϱ�š��������ơ���λ��������������Ϊ�գ�\");</script>");
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
        /// �Ƿ���ʾ����
        /// </summary>
        public bool IsDisplayWTOWPrice
        {
            get
            {
                if (ViewState["IsDisplayWTOWPrice"] != null)
                    return bool.Parse(ViewState["IsDisplayWTOWPrice"].ToString());
                else
                    return false;
            }
            set
            {
                ViewState["IsDisplayWTOWPrice"] = value;
            }
        }
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
            this.txtItemPrice.Visible = IsDisplayWTOWPrice;
//			this.USPurpose.Width = "90%";
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!string.IsNullOrEmpty(this.Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
            this.txtItemPrice.Visible = IsDisplayWTOWPrice;
//			this.USPurpose.Flag = 1;
			//�½����޸�״̬�¡�
			if (!this.IsPostBack)
			{
				switch (this._OP)
				{
					case OP.New:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.WTOWAuthor;
//						this.USPurpose.Disabled = false;
						break;
					case OP.Edit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.WTOWAuthor;
//						this.USPurpose.Disabled = false;
						break;
					case OP.Submit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.WTOWAuthor;
//						this.USPurpose.Disabled = true;
						break;
					case OP.FirstAudit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.WTOW;
//						this.USPurpose.Disabled = true;
						break;
					case OP.SecondAudit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.WTOW;
//						this.USPurpose.Disabled = true;
						break;
					case OP.ThirdAudit:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.WTOW;
//						this.USPurpose.Disabled = true;
						break;
					case OP.O:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.WTOW;
//						this.USPurpose.Disabled = true;
						break;
					case OP.Red:
						//this.DGModel_Items1.ColumnsScheme = ColumnScheme.WTOWAuthor;
//						this.USPurpose.Disabled = true;
						break;
				}
			}

			

			//����ģʽ�£���������е������ݵ��޸ġ�
			if (this._OP == OP.FirstAudit || this._OP == OP.SecondAudit || this._OP == OP.ThirdAudit  )
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
                this.txtRemark.ReadOnly = true;
			}
			//����ģʽ�¡�
			if (this._OP == OP.O)
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
			}
			else
				this.txtItemNum.ReadOnly = true;

            if (OperateRed == true)
            {
                this.btnAddItem.Enabled = false;
                this.btnEditItem.Enabled = false;
                this.btnDelItem.Enabled = false;
                txtRemark.Attributes.Add("ReadOnly", "ReadOnly");
                this.btnWWBrowser.Disabled = true;
            }

			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//��ʼ��
			//DGModel_Items1.ShowPager=false;

            if ((!this.IsPostBack) && (this.Request["Op"].ToString() == "New"))
			{
				//���������ݽṹ
				if(this.thisTable!=null) this.thisTable.Dispose();
				this.thisTable=new DataTable();

				DataColumnCollection columns = this.thisTable.Columns;
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
		}
        /*
		/// <summary>
		/// ҳ��UnLoad�¼���
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//�ͷž�̬����dt
			this.thisTable.Dispose();
		}*/
		
		/// <summary>
		/// �ı��󶨵����ذ�ť��
		/// </summary>
		protected void btnForItemCode_Click(object sender, System.EventArgs e)
		{
			if (txtItemCode.Text!="") 
			{
				if(txtItemCode.Text!="-1")
				{
					//�����������ƣ�����ͺţ����ۿؼ�Ϊֻ�����ҵ���λ�ؼ�
					this.txtItemName.ReadOnly = true;
					this.txtItemSpecial.ReadOnly = true;
					this.txtItemPrice.ReadOnly = true;
					this.ddlUnit.Enable = false;
					//��Ҫ���������ݿ��л�ȡ
					oItemData = new ItemSystem().GetItemByCode(this.txtItemCode.Text);
					//������������
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
						//lblUnit.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UnitName_Field].ToString();	//20080418 ��ȡ���ϵ�λ����
						//txtItemUnit.Value=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString();  //20080418 ��ȡ���ϵ�λID
						//						if (this.txtItemCode.Text == new SysSystem().GetSTAGInfo().ItemCode)//�����Һ����
//						{
//							//��ʼ��������������������ΪSTAG����ConCode1��Ӧ���е���������
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
					oItemData=(new ItemSystem()).GetItemByCode(txtItemCode.Text);
					
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0)
					{
						txtItemName.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						txtItemSpecial.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						this.txtItemPrice.Text=decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
						//������λ
						ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
						//lblUnit.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UnitName_Field].ToString();	//20080418  ��ȡ���ϵ�λ����
						//txtItemUnit.Value=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString();  //20080418 ��ȡ���ϵ�λID
					}
				}		
			}
			//Page.RegisterStartupScript("addblock","<script>function addblockfun(){ if(document.readyState==\"complete\"){ SetControlStatus(\"TableControl\",\"StaticInput\",\"Tableadd\");}}document.onreadystatechange=addblockfun;</script>");
		}   //End btnForItemCode_Click

		/// <summary>
		/// ȡ���½��������
		/// </summary>
		protected void btnCancelItem_Click(object sender, System.EventArgs e)
		{
			txtItemSerial.Value="-1";
	
			txtItemCode.Text="";
			txtItemName.Text="";
			txtItemSpecial.Text="";
			ddlUnit.SetItemSelected("-1");
			//txtItemUnit.Value="-1";  //20080418 ���ϵ�λID��ʼ��
			//lblUnit.Text="";	//20080418 ���ϵ�λ���Ƴ�ʼ��
			txtItemPrice.Text="";
			txtReqNum.Text="";
			txtItemNum.Text="";

			btnAddItem.Text="����";
			SetButtonStatus();
			//Page.RegisterStartupScript("addblock","<script>function addblockfun(){ if(document.readyState==\"complete\"){ SetControlStatus(\"TableControl\",\"StaticInput\",\"TableaddHidden\");}}document.onreadystatechange=addblockfun;</script>");	
		}

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
                case OP.O://
                    //���һ�����ݲ��Ҹ�ֵ
                    //
                    if (DoCheck())
                    {
                        decimal temp_num, temp_price, temp_money;

                        //				if (this.txtItemCode.Text.Substring(0,2) != this.StoCode)
                        //				{
                        //					this.Response.Write("<script>alert('���ѣ���ǰ�ֿ������ϱ�Ų�ƥ�䣡');</script>");
                        //				}
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
                                dr["StockNum"] = this.GetStockSumByItem(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
                                //dr["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode, txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
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
                                dr["ItemCode"] = txtItemCode.Text;
                                dr["ItemName"] = txtItemName.Text;
                                dr["ItemSpecial"] = txtItemSpecial.Text;
                                dr["ItemUnit"] = ddlUnit.SelectedValue;
                                dr["ItemUnitName"] = ddlUnit.SelectedText;
                                //dr["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode, txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
                                dr["StockNum"] = this.GetStockSumByItem(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
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

                        txtItemCode.Text = "";
                        txtItemName.Text = "";
                        txtItemSpecial.Text = "";
                        txtReqNum.Text = "";
                        this.txtItemNum.Text = "";
                        ddlUnit.SetItemSelected("-1");
                        //txtReqDate.Text="";
                        txtItemPrice.Text = "";
                    }
					this.btnAddItem.Enabled = false;
					this.btnEditItem.Enabled = true;
					this.btnDelItem.Enabled = false;
					break;
			}
		}
		#endregion

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            //
            //���һ�����ݲ��Ҹ�ֵ
            //
            if (DoCheck())
            {
                decimal temp_num, temp_price, temp_money;

                //				if (this.txtItemCode.Text.Substring(0,2) != this.StoCode)
                //				{
                //					this.Response.Write("<script>alert('���ѣ���ǰ�ֿ������ϱ�Ų�ƥ�䣡');</script>");
                //				}
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
                        dr["StockNum"] = this.GetStockSumByItem(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
                        //dr["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode, txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
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
                        dr["ItemCode"] = txtItemCode.Text;
                        dr["ItemName"] = txtItemName.Text;
                        dr["ItemSpecial"] = txtItemSpecial.Text;
                        dr["ItemUnit"] = ddlUnit.SelectedValue;
                        dr["ItemUnitName"] = ddlUnit.SelectedText;
                        //dr["StockNum"] = this.GetStockNumByStoCodeAndItem(this.StoCode, txtItemCode.Text,this.txtItemName.Text, this.txtItemSpecial.Text);
                        dr["StockNum"] = this.GetStockSumByItem(txtItemCode.Text, this.txtItemName.Text, this.txtItemSpecial.Text);
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
                    iRow = GetRowIndex(DGModel_Items1.SelectedID);

                    this.txtItemSerial.Value = iRow.ToString();

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

        protected void btnForItemCode_Click1(object sender, EventArgs e)
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
                    //ItemData oItemData = new ItemData();
                    oItemData = new ItemSystem().GetItemByCode(this.txtItemCode.Text);
                    //������������
                    if (oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count > 0)
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
                            try { this.txtItemPrice.Text = decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.EVAPRICE_FIELD].ToString()).ToString("0.###"); }
                            catch { this.txtItemPrice.Text = "0.000"; }
                        }

                        this.ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
                        //						if (this.txtItemCode.Text == new SysSystem().GetSTAGInfo().ItemCode)//�����Һ����
                        //						{
                        //							//��ʼ��������������������ΪSTAG����ConCode1��Ӧ���е���������
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
                    //ItemData oItemData = new ItemData();
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
            if (e.Item.ItemType == ListItemType.Header)
            {
                if(_OP == OP.New || _OP == OP.Edit || _OP == OP.Submit  ||  _OP == OP.Red)
                {
                    e.Item.Cells[7].Visible = false;
                    e.Item.Cells[8].Visible = false;
                }
                else
                {
                    if (IsDisplayWTOWPrice)
                    {
                        e.Item.Cells[7].Visible = true;
                        e.Item.Cells[8].Visible = true;
                    }
                    else
                    {
                        e.Item.Cells[7].Visible = false;
                        e.Item.Cells[8].Visible = false;
                    }
                }
                StockNum = 0;
                PlanNum = 0;
                ItemNum = 0;
              
            }
            else if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (_OP == OP.New || _OP == OP.Edit || _OP == OP.Submit || _OP == OP.Red)
                {
                    e.Item.Cells[7].Visible = false;
                    e.Item.Cells[8].Visible = false;
                }
                else
                {
                    if (IsDisplayWTOWPrice)
                    {
                        e.Item.Cells[7].Visible = true;
                        e.Item.Cells[8].Visible = true;
                    }
                    else
                    {
                        e.Item.Cells[7].Visible = false;
                        e.Item.Cells[8].Visible = false;
                    }
                }

          
                try
                {
                    StockNum = decimal.Parse(e.Item.Cells[4].Text);
                }
                catch
                {
                    StockNum = 0;
                }

                 try
                {
                    PlanNum = decimal.Parse(e.Item.Cells[5].Text);
                }
                catch
                {
                    PlanNum = 0;
                }

                 try
                {
                    ItemNum = decimal.Parse(e.Item.Cells[6].Text);
                }
                catch
                {
                    ItemNum = 0;
                }

                if ( ( StockNum < PlanNum && (this._OP == OP.New || this._OP == OP.Edit) ) || 
							(StockNum < ItemNum && this._OP == OP.O )
							)
						{
							e.Item.BackColor = Color.Red;
						}
            }
            
        }
		
	}
}
