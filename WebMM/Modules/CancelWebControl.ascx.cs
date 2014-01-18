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

	/// <summary>
	///	���������ϲ��������û��ؼ���
	///	�ṩ�ˣ�����������������ӡ��޸ġ�ɾ������ʾ���ܡ�
	/// </summary>
	public partial class CancelWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
		//protected StorageDropdownlist ddlUnit=new StorageDropdownlist();
 //20080408 ���ϵ�λ����
//20080408 ���ϵ�λID
		//private static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
		private string tmpCode;
		private string _OP;
		//public DGModel_Items DGModel_Items1;
		public string PKIDList;
		public System.Web.UI.WebControls.TextBox txtRemark;

		private int ret;

		private int i;

		private string strPkid;
		private string strDoccode;
		private string strEntryNo;
		private string strSerialno;
		private string strItemCode;
		private string strItemName;
		private string strItemSpceial; 
		private string strItemUnit;
		private string strItemUnitName;
		private string strItemPrice;
		private string strItemNum;
		private string strItemMoney; 


		private DataColumnCollection columns;

		private bool bret;
		private decimal temp_num;
		private decimal temp_price;
		private decimal temp_money;
		private DataRow dr;
		private int iRow;

		private POSData oPOSData;

		private DataRowCollection tmp;
		private int CurrentRow;

		//private int j;
		#endregion
		
		#region ����
		/// <summary>
		/// �Ƿ���ʾ����
		/// </summary>
		public bool IsDisplayCancelPrice
		{
			get
			{
				if (ViewState["IsDisplayCancelPrice"] != null)
					return bool.Parse(ViewState["IsDisplayCancelPrice"].ToString());
				else
					return false;
			}
			set
			{
				ViewState["IsDisplayCancelPrice"] = value;
			}
		}

		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.Cancel_DT] != null)
					return (DataTable)Session[MySession.Cancel_DT];
				else
				{
					this.thisTable = new DataTable();

					columns = this.thisTable.Columns;
					columns.Add("PKID");
					columns.Add("ItemCode");
					columns.Add("ItemName");
					columns.Add("ItemSpecial");
					columns.Add("ItemUnit");
					columns.Add("ItemUnitName");
					columns.Add("ItemPrice");
					columns.Add("PlanNum");
					columns.Add("ItemNum");
					columns.Add("ItemMoney");
					columns.Add("ItemSum");
					columns.Add("SourceDocCode");
					columns.Add("SourceSerialNo");
					columns.Add("SourceEntry");
					return thisTable;
				}
			}	
			set
			{
				Session[MySession.Cancel_DT] = value;
			}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// �ھ�̬���м��������Ƿ��Ѿ����ڡ�
		/// </summary>
		private int GetRowByPKID(string PKID)
		{
			ret = -1;

			for(i=0; i<this.thisTable.Rows.Count;i++)
			{
				if(this.thisTable.Rows[i]["PKID"].ToString() == PKID)
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
				if(txtReqNum.Text!="")  
				{
					decimal.Parse(txtReqNum.Text);
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
		#endregion
		
		

	//	#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!string.IsNullOrEmpty(Request["Op"] ))
			{
				this._OP = this.Request["Op"];
			}
			//DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//��ʼ��
			//DGModel_Items1.ShowPager = false;
			DGModel_Items1.AllowPaging = false;
			txtItemPrice.Visible = IsDisplayCancelPrice;
			//this.DGModel_Items1.ColumnsScheme = ColumnScheme.Cancel;
			this.SetButtonStatus(this._OP);//�趨�༭�������ʾģʽ��
			if ((!this.IsPostBack) && (this._OP == OP.Affirm))
			{
				this.btnAddItem.Enabled = false;
				this.btnDelItem.Enabled = false;
				this.btnEditItem.Enabled = false;
			}
			if((!this.IsPostBack) && (this.Request["Op"]=="New"))
			{
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
			//this.thisTable = null;
		}*/

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


		#region 
		/// <summary>
		/// ���ò�����Ŧ״̬
		/// </summary>
		private void SetButtonStatus(string OpMode)
		{
			if(!Page.IsPostBack)
			{
				switch (OpMode)
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
			}
		}
		#endregion

		protected void btnAddItem_Click(object sender, EventArgs e)
		{
			//
			//����һ�����ݲ��Ҹ�ֵ
			//
			if (DoCheck())
			{
				
				iRow = int.Parse(txtItemSerial.Value);
				dr = this.thisTable.Rows[iRow];


				dr["ItemNum"] = txtReqNum.Text;

				temp_num = decimal.Parse(dr["ItemNum"].ToString());
				temp_price = decimal.Parse(dr["ItemPrice"].ToString());
				temp_money = temp_num * temp_price;
				dr["ItemMoney"] = temp_money.ToString("0.##");

				txtItemSerial.Value = "-1";


				DGModel_Items1.DataSource = this.thisTable;
				DGModel_Items1.DataBind();

				txtItemCode.Text = "";
				txtItemName.Text = "";
				txtItemSpecial.Text = "";
				txtReqNum.Text = "";
				ddlUnit.SetItemSelected("-1");
				txtItemPrice.Text = "";
			}
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
				if (!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
				{
					iRow = GetRowIndex(DGModel_Items1.SelectedID);
					txtItemSerial.Value = iRow.ToString();
					txtItemCode.Text = this.thisTable.Rows[iRow]["ItemCode"].ToString();
					txtItemCode.Enabled = false;
					txtItemName.Text = this.thisTable.Rows[iRow]["ItemName"].ToString();
					txtItemName.Enabled = false;
					txtItemSpecial.Text = this.thisTable.Rows[iRow]["ItemSpecial"].ToString();
					txtItemSpecial.Enabled = false;
					txtReqNum.Text = this.thisTable.Rows[iRow]["ItemNum"].ToString();
					txtItemPrice.Text = this.thisTable.Rows[iRow]["ItemPrice"].ToString();
					txtItemPrice.Enabled = false;
					//������λ
					ddlUnit.SetItemSelected(this.thisTable.Rows[iRow]["ItemUnit"].ToString());
				}
			}
		}

		protected void btnForItemCode_Click(object sender, EventArgs e)
		{
			if (txtPKID.Value != "")
			{
				if (txtPKID.Value != "-1")
				{
					//
					//��Ҫ�Ӳɹ�����������Դ�л�ȡ
					//
					
					oPOSData = (new PurchaseSystem()).GetPOSByPKIDs(txtPKID.Value);
					//��������
					if (oPOSData.Tables[POSData.VPOS_VIEW].Rows.Count > 0)
					{
						tmp = oPOSData.Tables[POSData.VPOS_VIEW].Rows;
						for (i = 0; i < tmp.Count; i++)
						{
							strPkid = tmp[i][POSData.PKID_FIELD].ToString();
							strDoccode = tmp[i][POSData.DOCCODE_FIELD].ToString();
							strEntryNo = tmp[i][POSData.ENTRYNO_FIELD].ToString();
							strSerialno = tmp[i][POSData.SERIALNO_FIELD].ToString();
							strItemCode = tmp[i][POSData.ITEMCODE_FIELD].ToString();
							strItemName = tmp[i][POSData.ITEMNAME_FIELD].ToString();
							strItemSpceial = tmp[i][POSData.ITEMSPECIAL_FIELD].ToString();
							strItemUnit = tmp[i][POSData.ITEMUNIT_FIELD].ToString();
							strItemUnitName = tmp[i][POSData.ITEMUNITNAME_FIELD].ToString();
							strItemPrice = tmp[i][POSData.ITEMPRICE_FIELD].ToString();
							strItemNum = tmp[i][POSData.ITEMNUM_FIELD].ToString();
							strItemMoney = tmp[i][POSData.ITEMMONEY_FIELD].ToString();
							CurrentRow = this.GetRowByPKID(strPkid);
							if (CurrentRow == -1)
							{
								dr = this.thisTable.NewRow();
								if (this._OP == "New")
								{
									//dr.ItemArray = tmp[i].ItemArray;
									
									dr["PKID"] = strPkid;
									dr[CancelData.SourceEntry_Field] = strEntryNo;
									dr[CancelData.SourceDocCode_Field] = strDoccode;
									dr[CancelData.SourceSerialNo_Field] = strSerialno;
									dr[CancelData.ItemCode_Field] = strItemCode;
									dr[CancelData.ItemName_Field] = strItemName;
									dr["ItemSpecial"] = strItemSpceial;
									dr[CancelData.ItemUnit_Field] = strItemUnit;
									dr[CancelData.ItemUnitName_Field] = strItemUnitName;
									dr[CancelData.ItemPrice_Field] = strItemPrice;
									dr[CancelData.ItemNum_Field] = strItemNum;
									dr[CancelData.ItemMoney_Field] = strItemMoney;
								   
								}
								if (this._OP == "Edit")
								{
									dr[CancelData.SourceEntry_Field] = tmp[i][POSData.ENTRYNO_FIELD];
									dr[CancelData.SourceDocCode_Field] = tmp[i][POSData.DOCCODE_FIELD];
									dr[CancelData.SourceSerialNo_Field] = tmp[i][POSData.SERIALNO_FIELD];
									dr[CancelData.ItemCode_Field] = tmp[i][POSData.ITEMCODE_FIELD];
									dr[CancelData.ItemName_Field] = tmp[i][POSData.ITEMNAME_FIELD];
									dr["ItemSpecial"] = tmp[i][POSData.ITEMSPECIAL_FIELD];
									dr[CancelData.ItemUnit_Field] = tmp[i][POSData.ITEMUNIT_FIELD];
									dr[CancelData.ItemUnitName_Field] = tmp[i][POSData.ITEMUNITNAME_FIELD];
									dr[CancelData.ItemPrice_Field] = tmp[i][POSData.ITEMPRICE_FIELD];
									dr[CancelData.ItemNum_Field] = tmp[i][POSData.ITEMNUM_FIELD];
									dr[CancelData.ItemMoney_Field] = tmp[i][POSData.ITEMMONEY_FIELD];
								}
								this.thisTable.Rows.Add(dr);
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
				}
			}
			DGModel_Items1.DataSource = this.thisTable;
			DGModel_Items1.DataBind();
		}

		protected void DGModel_Items1_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[5].Visible = IsDisplayCancelPrice;
				e.Item.Cells[7].Visible = IsDisplayCancelPrice;
			}
			else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				e.Item.Cells[5].Visible = IsDisplayCancelPrice;
				e.Item.Cells[7].Visible = IsDisplayCancelPrice;
			}
			else if (e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[5].Visible = IsDisplayCancelPrice;
				e.Item.Cells[7].Visible = IsDisplayCancelPrice;
			}
		}


		protected void btnForPOSData_Click(object sender, EventArgs e)
		{
			if (txtPKID.Value != "")
			{
				if (txtPKID.Value != "-1")
				{
					oPOSData = (new PurchaseSystem()).GetPOSByPKIDs(txtPKID.Value);
					//��������
					if (oPOSData.Tables[POSData.VPOS_VIEW].Rows.Count > 0)
					{
						tmp = oPOSData.Tables[POSData.VPOS_VIEW].Rows;

						for (int j = 0; j < tmp.Count; j++)
						{
							CurrentRow = this.GetRowByPKID(tmp[j][POSData.PKID_FIELD].ToString());
							if (CurrentRow == -1)
							{
								dr = this.thisTable.NewRow();
								if (this._OP == "New")
								{
									//dr.ItemArray = tmp[i].ItemArray;
									//for (int j = 0; j < dr.ItemArray.Length; j++)
									//{
									//    dr[j] = tmp[i][""]
									//}
									dr[PurchaseOrderData.SOURCEENTRY_FIELD] = tmp[j][POSData.ENTRYNO_FIELD];
									dr[PurchaseOrderData.SOURCEDOCCODE_FIELD] = tmp[j][POSData.DOCCODE_FIELD];
									dr[PurchaseOrderData.SOURCESERIALNO_FIELD] = tmp[j][POSData.SERIALNO_FIELD];
									dr[InItemData.ITEMCODE_FIELD] = tmp[j][POSData.ITEMCODE_FIELD];
									dr[InItemData.ITEMNAME_FIELD] = tmp[j][POSData.ITEMNAME_FIELD];
									dr[InItemData.ITEMSPECIAL_FIELD] = tmp[j][POSData.ITEMSPECIAL_FIELD];
									dr[InItemData.ITEMUNIT_FIELD] = tmp[j][POSData.ITEMUNIT_FIELD];
									dr[InItemData.ITEMUNITNAME_FIELD] = tmp[j][POSData.ITEMUNITNAME_FIELD];
									dr[InItemData.ITEMPRICE_FIELD] = tmp[j][POSData.ITEMPRICE_FIELD];
									dr[InItemData.ITEMNUM_FIELD] = tmp[j][POSData.ITEMNUM_FIELD];
									dr[InItemData.ITEMMONEY_FIELD] = tmp[j][POSData.ITEMMONEY_FIELD];
									dr["Proposer"] = tmp[j][POSData.PROPOSER_FIELD];

								}
								if (this._OP == "Edit")
								{
									dr[PurchaseOrderData.SOURCEENTRY_FIELD] = tmp[j][POSData.ENTRYNO_FIELD];
									dr[PurchaseOrderData.SOURCEDOCCODE_FIELD] = tmp[j][POSData.DOCCODE_FIELD];
									dr[PurchaseOrderData.SOURCESERIALNO_FIELD] = tmp[j][POSData.SERIALNO_FIELD];
									dr[InItemData.ITEMCODE_FIELD] = tmp[j][POSData.ITEMCODE_FIELD];
									dr[InItemData.ITEMNAME_FIELD] = tmp[j][POSData.ITEMNAME_FIELD];
									dr[InItemData.ITEMSPECIAL_FIELD] = tmp[j][POSData.ITEMSPECIAL_FIELD];
									dr[InItemData.ITEMUNIT_FIELD] = tmp[j][POSData.ITEMUNIT_FIELD];
									dr[InItemData.ITEMUNITNAME_FIELD] = tmp[j][POSData.ITEMUNITNAME_FIELD];
									dr[InItemData.ITEMPRICE_FIELD] = tmp[j][POSData.ITEMPRICE_FIELD];
									dr[InItemData.ITEMNUM_FIELD] = tmp[j][POSData.ITEMNUM_FIELD];
									dr[InItemData.ITEMMONEY_FIELD] = tmp[j][POSData.ITEMMONEY_FIELD];
									dr["Proposer"] = tmp[j][POSData.PROPOSER_FIELD];
								}
								this.thisTable.Rows.Add(dr);
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
				}
			}
			DGModel_Items1.DataSource = this.thisTable;
			DGModel_Items1.DataBind();
		}
	}
}
