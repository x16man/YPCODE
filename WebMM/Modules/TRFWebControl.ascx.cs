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
	///		TRFWebControl ��ժҪ˵����
	/// </summary>
	public partial class TRFWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����
		protected StorageDropdownlist ddlUnit=new StorageDropdownlist();
		public static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
		private string tmpCode;
		private string _OP;
		
		public DGModel_Items DGModel_Items1;
	    private int ret;

	    private int i;

	    private bool bret;
	    private int CurrentRow;

	    private DataRow dr;

	    private int iRow;

	    private ItemData oItemData = new ItemData();
		#endregion

		#region ����
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.TRF_DT] != null)
					return (DataTable)Session[MySession.TRF_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.TRF_DT] = value;
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
		/// <returns>int:	û�з���-1�����򷵻������е�������</returns>
		private int GetRowByItemCode(string ItemCode)
		{
			ret = -1;
			for (i = 0; i < dt.Rows.Count; i++)
			{
				if (dt.Rows[i][InItemData.ITEMCODE_FIELD].ToString() == ItemCode)
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
				if((txtItemCode.Text!="") && (txtItemName.Text!="") && (txtPlanNum.Text!="") && (txtPlanNum.Text!="") && (ddlUnit.SelectedValue!="-1"))
				{
					
					decimal.Parse(txtPlanNum.Text);
					
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

		/// <summary>
		/// ���ݲ�ͬ����ģʽ���趨�༭�������ʾ��ʽ��
		/// </summary>
		/// <param name="OpMode">string:	����ģʽ��</param>
		private void SetEditMode(string OpMode)
		{
			switch (OpMode)
			{
				//����ģʽ�£���������е������ݵ��޸ġ�
				case OP.FirstAudit:					
				case OP.SecondAudit:					
				case OP.ThirdAudit:
				case OP.Submit:
					#region �����������ύ
					this.btnAddItem.Enabled = false;
					this.btnEditItem.Enabled = false;
					this.btnDelItem.Enabled = false;
					this.txtRemark.Enabled = false;
					#endregion
					break;
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
					this.btnEditItem.Enabled = false;
					break;
					#endregion
				case OP.O:
					#region ���� 
					this.txtItemCode.Visible = true;
					this.txtItemCode.ReadOnly = true;
					this.txtItemName.Visible = true;
					this.txtItemName.ReadOnly = true;
					this.txtItemSpecial.Visible = true;
					this.txtItemSpecial.ReadOnly = true;
					this.ddlUnit.Visible = true;
					this.ddlUnit.Enable = false;
					
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
					
					this.txtItemPrice.Visible = true;
					this.txtItemPrice.Enabled = true;
					this.txtItemPrice.ReadOnly = false;
					
					
					this.txtItemNum.Visible = false;
					this.txtRemark.Enabled = true;
					this.txtRemark.Visible = true;
					this.txtRemark.ReadOnly = false;
					
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
			if (!string.IsNullOrEmpty(this.Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			
			this.SetEditMode(this._OP);

			if(this._OP == OP.I)
				DGModel_Items1.ColumnsScheme = ColumnScheme.TRFIn;
			else
				DGModel_Items1.ColumnsScheme = ColumnScheme.TRF;
			


			DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			//��ʼ��
			DGModel_Items1.ShowPager=false;
			DGModel_Items1.AllowPaging = false;

			if((!this.IsPostBack) && (this.Request["Op"].ToString()=="New"))
			{
				//���������ݽṹ
				if(dt!=null) dt.Dispose();
				dt=new DataTable();

				DataColumnCollection columns = dt.Columns;
				columns.Add("ItemCode");
				columns.Add("ItemName");
				columns.Add("ItemSpecial");
				columns.Add("ItemUnit");
				columns.Add("ItemUnitName");
				columns.Add("ItemPrice");			
				columns.Add("PlanNum").DataType=typeof(System.Decimal);
				columns.Add("ItemNum");
				columns.Add("ItemMoney");
				columns.Add("ConName");
				//��
				
				DGModel_Items1.DataSource=dt;				
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
				DGModel_Items1.DataSource=dt;				
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
			dt.Dispose();
		}
		*/
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
				decimal temp_num,temp_price,temp_money;

				if(btnAddItem.Text=="����")
				{
					CurrentRow = GetRowByItemCode(txtItemCode.Text);

					if ( CurrentRow == -1)//��̬����û�й������ϡ�
					{
						dr=dt.NewRow();
						dr["ItemCode"] = txtItemCode.Text;
						dr["ItemName"] = txtItemName.Text;
						dr["ItemSpecial"] = txtItemSpecial.Text;
						dr["ItemUnit"] = ddlUnit.SelectedValue;
						dr["ItemUnitName"] = ddlUnit.SelectedText;
						dr["ItemPrice"] = txtItemPrice.Text;
						dr["PlanNum"] = txtPlanNum.Text;
						//���
						temp_num   = decimal.Parse(txtPlanNum.Text);
						temp_price = decimal.Parse(txtItemPrice.Text);
						temp_money = Math.Round((temp_num * temp_price),2);
					
						dr["ItemMoney"] = temp_money.ToString("0.##");

						
						dt.Rows.Add(dr);
					}
					else//��̬�����Ѿ����ڸ����ϡ�
					{
						temp_num = Convert.ToDecimal(dt.Rows[CurrentRow]["PlanNum"].ToString()) + Convert.ToDecimal(txtPlanNum.Text);
						temp_price = Convert.ToDecimal(dt.Rows[CurrentRow]["ItemPrice"].ToString());
						temp_money = Math.Round((temp_num * temp_price),2);
						dt.Rows[CurrentRow]["PlanNum"] = temp_num;
						dt.Rows[CurrentRow]["ItemMoney"] = temp_money;
					}
				}
				else
				{
					iRow=int.Parse(txtItemSerial.Value);
					dr=dt.Rows[iRow];

					dr["ItemCode"]=txtItemCode.Text;
					dr["ItemName"]=txtItemName.Text;
					dr["ItemSpecial"]=txtItemSpecial.Text;
					dr["ItemUnit"]=ddlUnit.SelectedValue;
					dr["ItemUnitName"]=ddlUnit.SelectedText;
					dr["ItemPrice"]=txtItemPrice.Text;
					dr["PlanNum"]=txtPlanNum.Text;
					dr["ItemNum"]=txtItemNum.Text;


					if(this._OP==OP.Discard)
					{
						if(decimal.Parse(this.txtItemNum.Text)>decimal.Parse(this.txtPlanNum.Text))
						{
                            Page.RegisterStartupScript( "Error", "<script>alert('ʵת������Ӧ����Ӧת����!');</script>");
                            this.btnAddItem.Enabled=true;
							this.btnAddItem.Text="����";
							return;
						}
						temp_num =decimal.Parse(txtItemNum.Text);	
						dr["ItemNum"] = txtItemNum.Text;
					}
					else
						temp_num   = decimal.Parse(txtPlanNum.Text);

					
					temp_price = decimal.Parse(txtItemPrice.Text);
					temp_money = temp_num * temp_price;
					dr["ItemMoney"] = temp_money.ToString("0.##");
					
					
					
					txtItemSerial.Value="-1";
					btnAddItem.Text="����";

				}
				DGModel_Items1.DataSource=dt;
				DGModel_Items1.DataBind();				

				txtItemCode.Text="";
				txtItemName.Text="";
				txtItemSpecial.Text="";
				txtPlanNum.Text="";
				txtItemNum.Text="";
				ddlUnit.SetItemSelected("-1");
				
				txtItemPrice.Text="";
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
				if (!string.IsNullOrEmpty(this.DGModel_Items1.SelectedID))
				{
					iRow=int.Parse(DGModel_Items1.SelectedID);
	
					txtItemSerial.Value=iRow.ToString();

					txtItemCode.Text=dt.Rows[iRow]["ItemCode"].ToString();
					txtItemName.Text=dt.Rows[iRow]["ItemName"].ToString();
					txtItemSpecial.Text=dt.Rows[iRow]["ItemSpecial"].ToString();
					txtPlanNum.Text=dt.Rows[iRow]["PlanNum"].ToString();
					txtItemNum.Text=dt.Rows[iRow]["ItemNum"].ToString();
					
					txtItemPrice.Text=dt.Rows[iRow]["ItemPrice"].ToString();
					//������λ
					ddlUnit.SetItemSelected(dt.Rows[iRow]["ItemUnit"].ToString());

					btnAddItem.Text="����";
					btnAddItem.Enabled=true;
					
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

				dt.Rows.RemoveAt(iRow);

				DGModel_Items1.DataSource=dt;
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
				}		
			}
		}   //End btnForItemCode_Click
		#endregion

		
	}
}
