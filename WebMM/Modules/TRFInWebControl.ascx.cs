namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using MZHMM.Common;
	using MZHMM.Facade;
	using MZHMM.WebMM.Modules;
    using System.Web.UI;
	/// <summary>
	///	���������ϲ��������û��ؼ���
	///	�ṩ�ˣ�����������������ӡ��޸ġ�ɾ������ʾ���ܡ�
	/// </summary>
	public partial class TRFInWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
		protected StorageDropdownlist ddlUnit = new StorageDropdownlist();
		public    StorageDropdownlist ddlCon ;
		//private static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
		private string tmpCode;
		private string _OP;
		protected System.Web.UI.WebControls.Button btnForItemCode;
		protected System.Web.UI.WebControls.TextBox txtEntryNo;
		protected System.Web.UI.WebControls.Button bntForEntryNo;
		public DGModel_Items DGModel_Items1;

	    private int ret;
	    private int i;
	    private bool bret;
	    private decimal temp_num;
	    private decimal temp_price;
	    private decimal temp_money;
	    private decimal temp_taxrate;
	    private decimal temp_tax;
	    private decimal temp_all;

	    private int iRow;

	    private int CurrentRow;

	    private DataRow dr;
	    private ItemData oItemData = new ItemData();


		#endregion

		#region ����
		/// <summary>
		/// DataGrid������Դ��
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.TRFIN_DT] != null)
					return (DataTable)Session[MySession.TRFIN_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.TRFIN_DT] = value;
			}
		}
		/// <summary>
		/// ���ϵ��ı�ע���ԡ�
		/// </summary>
		public string Remark
		{
			get 
			{	
				return this.txtRemark.Text;
			}
			set 
			{
				this.txtRemark.Text = value;
			}
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
				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtReqNum.Text!="") && (ddlUnit.SelectedValue!="-1"))
				{
					decimal.Parse(txtReqNum.Text);
				}
				else
				{
					//this.Response.Write("<script>alert(\"���ϱ�š��������ơ���λ��������������Ϊ�գ�\");</script>");
                    ScriptManager.RegisterStartupScript(this.btnAddItem, this.GetType(), "Error", "alert('���ϱ�š��������ơ���λ��������������Ϊ��!');", true);
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
		/// ���ݲ�ͬ����ģʽ���趨�༭�������ʾ��ʽ��
		/// </summary>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEditMode(string OpMode)
		{
			switch (OpMode)
			{			
				case OP.I:
					#region ����
					this.txtItemCode.Visible = true;
					this.txtItemCode.ReadOnly = true;
					this.txtItemName.Visible = true;
					this.txtItemName.ReadOnly = true;
					this.txtItemSpecial.Visible = true;
					this.txtItemSpecial.ReadOnly = true;
					this.ddlUnit.Visible = true;
					this.ddlUnit.Enable = false;
					this.txtBatchCode.Visible = true;
					this.txtBatchCode.ReadOnly = true;
					this.txtItemPrice.Visible = false;
					this.txtReqNum.Visible = false;
					this.txtTaxRate.Visible = false;
					this.txtItemNum.Visible = true;
					this.txtItemNum.Enabled = true;
					this.txtRemark.Visible = true;
					this.txtRemark.Enabled = true;
					this.txtRemark.ReadOnly = true;
					this.ddlCon.Visible = true;
					this.ddlCon.Enable = true;
					this.btnAddItem.Enabled = false;
					this.btnDelItem.Enabled = false;
					this.btnEditItem.Enabled = true;
					break;
					#endregion
				default:
					#region Ĭ��
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
					this.txtBatchCode.Visible = true;
					this.txtBatchCode.Enabled = true;
					this.txtBatchCode.ReadOnly = false;
					this.txtItemPrice.Visible = true;
					this.txtItemPrice.Enabled = true;
					this.txtItemPrice.ReadOnly = false;
					this.txtReqNum.Visible = true;
					this.txtReqNum.Enabled = true;
					this.txtReqNum.ReadOnly = false;
					this.txtTaxRate.Visible = true;
					this.txtTaxRate.Enabled = true;
					this.txtTaxRate.ReadOnly = false;
					this.txtItemNum.Visible = false;
					this.txtRemark.Enabled = true;
					this.txtRemark.Visible = true;
					this.txtRemark.ReadOnly = false;
					this.ddlCon.Visible = false;
					this.btnAddItem.Enabled = true;
					this.btnDelItem.Enabled = true;
					this.btnEditItem.Enabled = true;
					break;
					#endregion
			}
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
			//ģʽ�趨��
			DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			DGModel_Items1.ShowPager=false;
			this.SetEditMode(this._OP);//�趨�༭�������ʾģʽ��
			
			#region ����
			this.DGModel_Items1.ColumnsScheme = ColumnScheme.TRFIn;
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
			}
			DGModel_Items1.DataSource=this.thisTable;				
			DGModel_Items1.DataBind();
			tmpCode=DGModel_Items1.SelectedID;
			
			#endregion
		}

        /*
		/// <summary>
		/// ҳ��UnLoad�¼���
		/// </summary>
		private void Page_UnLoad(object sender, System.EventArgs e)
		{
			//�ͷž�̬����dt
			this.thisTable=null;
		}*/
		
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
				#region ����
				
					iRow=int.Parse(txtItemSerial.Value);
					dr=this.thisTable.Rows[iRow];
					CurrentRow = GetRowByItemCode(txtItemCode.Text);
					if (CurrentRow == iRow || CurrentRow == -1)//û���ظ����ϡ�
					{
						dr["ItemCode"]=txtItemCode.Text;
						dr["ItemName"]=txtItemName.Text;
						dr["ItemSpecial"]=txtItemSpecial.Text;
						dr["ItemUnit"]=ddlUnit.SelectedValue;
						dr["ItemUnitName"]=ddlUnit.SelectedText;
						
						dr[InItemData.ITEMPRICE_FIELD] = this.txtItemPrice.Text;
						dr[WTRFData.PLANNUM_FIELD] = this.txtReqNum.Text;
						
						dr[InItemData.ITEMNUM_FIELD] = this.txtItemNum.Text;
						dr[WTRFData.CONCODE_FIELD] = this.ddlCon.SelectedValue;
						dr[WTRFData.CONNAME_FIELD] = this.ddlCon.SelectedText;
						if (this._OP == OP.I)//����ģʽ��
						{
							temp_num = decimal.Parse(this.txtItemNum.Text);
						}
						else
						{
							temp_num = decimal.Parse(this.txtReqNum.Text);
						}
						temp_price = decimal.Parse(this.txtItemPrice.Text);
						temp_taxrate = decimal.Parse(this.txtTaxRate.Text);
						temp_money = Math.Round((temp_num * temp_price),2);
						temp_tax = Math.Round((temp_money*temp_taxrate),2);
						temp_all = Math.Round((temp_money+temp_tax),2);

						dr["ItemMoney"] = temp_money.ToString("0.##");
						dr["ItemTax"] = temp_tax.ToString("0.##");
						dr["ItemSum"] = temp_all.ToString("0.##");
					}
					else//�޸ĺ����ظ����ϣ��������ֻ������ڶ�OTI���ϵ��޸ġ�
					{
						if (this._OP == OP.I)//����ģʽ��
						{
							temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(this.txtItemNum.Text);
						}
						else
						{
							temp_num = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(this.txtReqNum.Text);
						}
						temp_price = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["ItemPrice"].ToString());
						temp_taxrate = Convert.ToDecimal(this.thisTable.Rows[CurrentRow]["TaxRate"].ToString());
						temp_money = Math.Round((temp_num * temp_price),2);
						temp_tax = Math.Round((temp_money*temp_taxrate),2);
						temp_all = Math.Round((temp_money+temp_tax),2);

						this.thisTable.Rows[CurrentRow]["PlanNum"] = temp_num;
						this.thisTable.Rows[CurrentRow]["ItemMoney"] = temp_money;
						this.thisTable.Rows[CurrentRow]["ItemTax"] = temp_tax;
						this.thisTable.Rows[CurrentRow]["ItemSum"] = temp_all;
						this.thisTable.Rows.Remove(this.thisTable.Rows[iRow]);//ɾ��ԭ���С�
					}
					txtItemSerial.Value="-1";
					btnAddItem.Text="����";
					btnAddItem.Enabled = false;
				
				#endregion
				
			}
		}
		/// <summary>
		/// �༭��ť��
		/// </summary>
		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			//������-1��ʾ�Ѿ����ڱ༭״̬
			if(txtItemSerial.Value == "-1")
			{
				if (!string.IsNullOrEmpty(this.DGModel_Items1.SelectedID))
				{
					iRow=int.Parse(DGModel_Items1.SelectedID);
	
					this.txtItemSerial.Value=iRow.ToString();//˳��š�
					this.txtItemCode.Text=this.thisTable.Rows[iRow][InItemData.ITEMCODE_FIELD].ToString();//���ϱ�š�
					this.txtItemName.Text=this.thisTable.Rows[iRow][InItemData.ITEMNAME_FIELD].ToString();//�������ơ�
					this.txtItemSpecial.Text=this.thisTable.Rows[iRow][InItemData.ITEMSPECIAL_FIELD].ToString();//����ͺš�
					this.ddlUnit.SetItemSelected(this.thisTable.Rows[iRow][InItemData.ITEMUNIT_FIELD].ToString());//������λ
					
					this.txtItemPrice.Text=this.thisTable.Rows[iRow][InItemData.ITEMPRICE_FIELD].ToString();//���ۡ�
					this.txtReqNum.Text=this.thisTable.Rows[iRow][WTRFData.PLANNUM_FIELD].ToString();//Ӧ��������
					
					this.txtItemNum.Text = this.thisTable.Rows[iRow][InItemData.ITEMNUM_FIELD].ToString();//ʵ��������				
					this.ddlCon.SetItemSelected(this.thisTable.Rows[iRow][WTRFData.CONCODE_FIELD].ToString());//��λ

					this.btnAddItem.Text="����";
					this.btnAddItem.Enabled = true;
				}
			}
		}
		/// <summary>
		/// ɾ����ť��
		/// </summary>
		protected void btnDelItem_Click(object sender, System.EventArgs e)
		{
			if(!string.IsNullOrEmpty(DGModel_Items1.SelectedID))
			{
				iRow=int.Parse(DGModel_Items1.SelectedID);

				this.thisTable.Rows.RemoveAt(iRow);

				DGModel_Items1.DataSource=this.thisTable;
				DGModel_Items1.DataBind();
			}
		}
		/// <summary>
		/// �ı��󶨵����ذ�ť��
		/// </summary>
		private void btnForItemCode_Click(object sender, System.EventArgs e)
		{
			if (txtItemCode.Text!="") 
			{
				if(txtItemCode.Text!="-1")
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
					
					oItemData=(new ItemSystem()).GetItemByCode(txtItemCode.Text);
					
					//������������
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0)
					{
						txtItemCode.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
						txtItemName.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						txtItemSpecial.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						this.txtItemPrice.Text=decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
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
					oItemData=(new ItemSystem()).GetItemByCode(txtItemCode.Text);
					
					if(oItemData.Tables[ItemData.ITEM_TABLE].Rows.Count>0)
					{
						txtItemCode.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD].ToString();
						txtItemName.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD].ToString();
						txtItemSpecial.Text=oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD].ToString();
						this.txtItemPrice.Text=decimal.Parse(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CSTPRICE_FIELD].ToString()).ToString("0.###");
						//������λ
						ddlUnit.SetItemSelected(oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD].ToString());
					}
				}		
			}
		}   //End btnForItemCode_Click
			
		#endregion
	}
}
