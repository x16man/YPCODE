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
	///	���������ϲ��������û��ؼ���
	///	�ṩ�ˣ�����������������ӡ��޸ġ�ɾ������ʾ���ܡ�
	/// </summary>
	public partial class RTSWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
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

		#region ����
        /// <summary>
        /// �Ƿ���ʾ����
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

		#region ˽�з���
		/// <summary>
		/// �ھ�̬���м��������Ƿ��Ѿ����ڡ�
		/// </summary>
		/// <param name="ItemCode">string:	Ҫ�������ϱ�š�</param>
		/// <returns>int:	û�з���-1�����򷵻������е�������</returns>
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
		/// �����ݽ���У��.
		/// </summary>
		/// <returns>bool:	У��ͨ������true��ʧ�ܷ���false��</returns>
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
					//this.Response.Write("<script>alert(\"���ϱ�š��������ơ���λ��������������Ϊ�գ�\");</script>");
                    Page.RegisterStartupScript( "DoCheck", "<script>alert('���ϱ�š��������ơ���λ��������������Ϊ��!');</script>");
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
			// �ڴ˴������û������Գ�ʼ��ҳ��

            this.txtItemPrice.Visible = IsDisplayRTSPrice;


			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.RTS;

			//����ģʽ�£���������е������ݵ��޸ġ�
			if (this._OP == "FirstAudit" || this._OP == "SecondAudit" || this._OP == "ThirdAudit")
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.txtRemark.Enabled = false;
			}
			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//��ʼ��
			//DGModel_Items1.ShowPager=false;
			DGModel_Items1.AllowPaging = false;
			this.ddlCon.Visible  = false;


			switch(this._OP)
			{
				case OP.New:
					#region �½�
					if(!this.IsPostBack)
					{
						//���������ݽṹ
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
						//��
						

						//��ʼ��һЩ��
						//������λ
						ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
					}
					DGModel_Items1.DataSource=this.thisTable;				
					DGModel_Items1.DataBind();
					break;
					#endregion
				case OP.I:
					#region ����
					if (this.btnAddItem.Text == "����")
					{
						this.btnAddItem.Enabled = false;
					}
					else
					{
						this.btnAddItem.Enabled = true;
					}
					if(!this.IsPostBack)
					{
						//������λ
						this.ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
						this.ddlCon.Module_Tag = (int)SDDLTYPE.CONTAINER;

                        //���������ݽṹ
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
					#region ����
					if(!this.IsPostBack)
					{
						//������λ
						ddlUnit.Module_Tag=(int)SDDLTYPE.UNIT;
					}
					DGModel_Items1.DataSource=this.thisTable;				
					DGModel_Items1.DataBind();

			        break;
					#endregion
			}
		}
       
		/// <summary>
		/// ���Ӱ�ť��
		/// </summary>
		protected void btnAddItem_Click(object sender, System.EventArgs e)
		{
			//
			//���һ�����ݲ��Ҹ�ֵ
			//
			if(DoCheck())
			{
				
				if (this.btnAddItem.Text == "����")
				{
					iRow=int.Parse(txtItemSerial.Value);
					dr=this.thisTable.Rows[iRow];

					if (this._OP == OP.I)//����ģʽ��
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
                    btnAddItem.Text = "����";
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
                        //������λ
                        ddlUnit.SetItemSelected(this.thisTable.Rows[iRow]["ItemUnit"].ToString());
                        //this.ddlCon.SetItemSelected(this.thisTable.Rows[iRow][BillOfReceiveData.CONCODE_FIELD].ToString());//��λ

                        this.btnAddItem.Text = "����";
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
		/// ɾ����ť��
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
		/// �ı��󶨵����ذ�ť��
		/// </summary>
		protected void btnForItemCode_Click(object sender, System.EventArgs e)
		{
			if (txtItemCode.Text!="") 
			{
				if(txtItemCode.Text!="-1")
				{
					//
					//��Ҫ���������ݿ��л�ȡ
					//
					oItemData=(new ItemSystem()).GetItemByCode(txtItemCode.Text);
					
					//������������
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0)
					{
						txtItemName.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						txtItemSpecial.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						this.txtItemPrice.Text=decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
						this.txtItemCode.Text =oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
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
				}		
			}
		}   //End btnForItemCode_Click
		#endregion
		/// <summary>
		/// ѡ�������ϵ��Ժ����ɵ��ڲ��˻�����ϸ��
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
                    //e.Item.Cells[0].Visible = false;//���
                    //e.Item.Cells[1].Visible = true;//���
                    //e.Item.Cells[2].Visible = true;//����
                    //e.Item.Cells[3].Visible = true;//����ͺ�
                    //e.Item.Cells[4].Visible = true;//������λ
                    e.Item.Cells[5].Visible = true;//������
                    e.Item.Cells[6].Visible = true;//ʵ����
                    //e.Item.Cells[7].Visible = true;//����
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

                e.Item.Cells[7].Visible = IsDisplayRTSPrice;//����
                e.Item.Cells[8].Visible = IsDisplayRTSPrice;//�ܼ�


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
