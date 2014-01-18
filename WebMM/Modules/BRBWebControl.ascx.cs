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
	public partial class BRBWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����

		//private static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
		private string tmpCode;
		private string _OP;
		//private int _ConCode;
		public DGModel_Items DGModel_Items1;

	    private bool ret;

	    private DateTime tmpDateTime;

	    private decimal Temp_Area;


	    private DateTime StartTime;
	    private DateTime EndTime;
	    private DateTime ImportTime;
	    private DateTime ExportTime;

        private ItemData oItemData = new ItemData();
        private ItemSystem oItemSystem = new ItemSystem();

	    private DataRow dr;

	    private int iRow;
		#endregion

		#region ����
		/// <summary>
		/// ��̬���ݱ�
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.BRB_DT] != null)
					return (DataTable)Session[MySession.BRB_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.BRB_DT] = value;
			}
		}
		/// <summary>
		/// ��λ��š�
		/// </summary>
		public int ConCode
		{
			get 
			{	if (this.txtConCode.Text.Length > 0)
					return Convert.ToInt32(this.txtConCode.Text);	
				else
					return -1;
			}
			set 
			{	
				this.txtConCode.Text = value.ToString();	
			}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// �����ݽ���У��.
		/// </summary>
		/// <returns>bool:	У��ͨ������true��ʧ�ܷ���false��</returns>
		private bool DoCheck()
		{
			ret=true;
			
			try
			{
				if( this.txtShipNo.Text.Trim() != "" && 
					this.txtStartTime.Text.Trim() !="" && 
					this.txtEndTime.Text.Trim() != "" && 
					this.txtImportTime.Text.Trim() != "" && 
					this.txtExportTime.Text.Trim() != "")
				{
					tmpDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + this.txtStartTime.Text);
					tmpDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + this.txtEndTime.Text);
					tmpDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + this.txtImportTime.Text);
					tmpDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + this.txtExportTime.Text);
				}
				else
				{
					this.Response.Write("<script>alert(\"����������ʱ�䡢�깤ʱ�䡢����ʱ�䡢����ʱ�䲻��Ϊ�գ�\");</script>");
					ret=false;
				}
			}
			catch
			{
				this.Response.Write("<script>alert(\"ʱ���ʽ����ȷ��\");</script>");
				ret=false;
			}
			return ret;
		}
		/// <summary>
		/// ��ȡ��λ�����
		/// </summary>
		/// <returns>decimal:	�����</returns>
		private decimal GetArea()
		{
			Temp_Area = new ItemSystem().GetStoConByCode(this.ConCode).Area;
			return Temp_Area;
		}
		/// <summary>
		/// ���������
		/// </summary>
		/// <returns>decimal:	�������</returns>
		private decimal CalcVolumn()
		{
			decimal StartHeight;//�鲵ǰҺλ��
			decimal EndHeight;//�鲵��Һλ��
			decimal Volumn;
		
			StartTime = Convert.ToDateTime((DateTime.Now.ToShortDateString() +" "+ this.txtStartTime.Text.Trim()));
			EndTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() +" "+ this.txtEndTime.Text.Trim());
			if (this.txtStartVolumn.Text.Trim().Length > 0)
			{
				StartHeight = Convert.ToDecimal(this.txtStartVolumn.Text.Trim());
			}
			else
			{
				StartHeight = new STAGData().GetPLCValue(this.ConCode, StartTime);
			}
			if (this.txtEndVolumn.Text.Trim().Length > 0)
			{
				EndHeight = Convert.ToDecimal(this.txtEndVolumn.Text.Trim());
			}
			else
			{
				EndHeight = new STAGData().GetPLCValue(this.ConCode, EndTime);
			}
			try
			{
				Volumn = Math.Round((EndHeight - StartHeight)*this.GetArea(),2);
			}
			catch
			{
				Volumn = 0;
			}
			return Volumn;
		}
		#endregion
		
		

		#region �¼�
		/// <summary>
		/// ҳ��Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.DGModel_Items1.ColumnsScheme = ColumnScheme.BRB;
			if (!string.IsNullOrEmpty(Request["Op"]))
			{
				this._OP = this.Request["Op"];
			}
			//����ģʽ�£���������е������ݵ��޸ġ�
			if (this._OP == "FirstAudit" || 
				this._OP == "SecondAudit" || 
				this._OP == "ThirdAudit")
			{
				this.btnAddItem.Enabled = false;
				this.btnEditItem.Enabled = false;
				this.btnDelItem.Enabled = false;
			}
			//DataGrid ��ѡ��ģʽ��
			DGModel_Items1.SelectedType = DGModel.SelectType.SingleSelect;
			//�Ƿ���ʾҳ�롣
			DGModel_Items1.ShowPager = false;
			DGModel_Items1.AllowPaging = false;

			if((!this.IsPostBack) && (this.Request["Op"] == "New"))
			{
				//���������ݽṹ
				if(this.thisTable!=null) this.thisTable = null;
				this.thisTable=new DataTable();

				DataColumnCollection columns = this.thisTable.Columns;
				columns.Add("ShipNo");
				columns.Add("StartTime");
				columns.Add("EndTime");
				columns.Add("ImportTime");
				columns.Add("ExportTime");
				columns.Add("ItemCode");
				columns.Add("ItemName");
				columns.Add("ItemSpecial");
				columns.Add("ItemUnit");
				columns.Add("ItemUnitName");
				columns.Add("StartVolumn");
				columns.Add("EndVolumn");
				columns.Add("ItemVolumn");
				columns.Add("ProductCat");
				columns.Add("DangerCat");
				//��
				DGModel_Items1.DataSource=this.thisTable;				
				DGModel_Items1.DataBind();
			}
			else
			{
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
			this.thisTable=null;
		}
         * */
		
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
				if(btnAddItem.Text=="����")
				{
					dr=this.thisTable.NewRow();
					//������
					
					

					oItemData = oItemSystem.GetItemByCode(new SysSystem().GetSTAGInfo().ItemCode);
					dr[InItemData.ITEMCODE_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD];
					dr[InItemData.ITEMNAME_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD];
					dr[InItemData.ITEMSPECIAL_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD];
					dr[InItemData.ITEMUNIT_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD];
					dr[InItemData.ITEMUNITNAME_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UnitName_Field];
					
					dr[PBRBData.SHIPNO_FIELD] = this.txtShipNo.Text;
					try
					{
						StartTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtStartTime.Text);
						EndTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtEndTime.Text);
						ImportTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtImportTime.Text);
						ExportTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtExportTime.Text);
					}
					catch 
					{
						this.Response.Write("<script>alert('��������ȷ��ʱ���ʽ��HH:MM:SS!');</script>");
						return;
					}
					dr[PBRBData.STARTTIME_FIELD] = StartTime;
					dr[PBRBData.ENDTIME_FIELD] = EndTime;
					dr[PBRBData.IMPORTTIME_FIELD] = ImportTime;
					dr[PBRBData.EXPORTTIME_FIELD] = ExportTime;

					if (this.txtStartVolumn.Text.Trim().Length > 0 )//������ֹ�����Һλֵ��
					{
						try
						{
							dr[PBRBData.STARTVOLUMN_FIELD] = Convert.ToDecimal(this.txtStartVolumn.Text.Trim());
						}
						catch 
						{
							this.Response.Write("<script>alert(\"��������ȷ��Һλֵ��\");</script>");
							return;
						}
					}
					else//���û���ֹ����룬����Ϊ�Ǵ�ָ����ж�ȡҺλֵ��
					{
						//TODO: ���Ӵ�ָ�����ȡָ��̶�ֵ��
						dr[PBRBData.STARTVOLUMN_FIELD] = new STAGData().GetPLCValue(this.ConCode,StartTime) ;	
					}
					if (this.txtEndVolumn.Text.Trim().Length > 0)//������ֹ�����Һλֵ��
					{
						try
						{
							dr[PBRBData.ENDVOLUMN_FIELD] = Convert.ToDecimal(this.txtEndVolumn.Text.Trim());
						}
						catch 
						{
							this.Response.Write("<script>alert(\"��������ȷ��Һλֵ��\");</script>");
							return;
						}
					}
					else
					{
						//TODO:	���Ӵ�ָ�����ȡָ��̶�ֵ��
						dr[PBRBData.ENDVOLUMN_FIELD] = new STAGData().GetPLCValue(this.ConCode, EndTime);;
					}
					//���������
					if (this.CalcVolumn() == 0)
					{
						this.Response.Write("<script>alert(\'�ü�λû���趨�������\');</script>");
						return;
					}
					else
					{
						dr[PBRBData.ITEMVOLUMN_FIELD] = this.CalcVolumn();
						this.thisTable.Rows.Add(dr);
					}
				}
				else//���¡�
				{
					iRow=int.Parse(txtItemSerial.Value);
					dr=this.thisTable.Rows[iRow];
					//������
				
					oItemData = oItemSystem.GetItemByCode(new SysSystem().GetSTAGInfo().ItemCode);
					dr[InItemData.ITEMCODE_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CODE_FIELD];
					dr[InItemData.ITEMNAME_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.CNNAME_FIELD];
					dr[InItemData.ITEMSPECIAL_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.SPECIAL_FIELD];
					dr[InItemData.ITEMUNIT_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UNITCODE_FIELD];
					dr[InItemData.ITEMUNITNAME_FIELD] = oItemData.Tables[ItemData.ITEM_TABLE].Rows[0][ItemData.UnitName_Field];
					
					dr[PBRBData.SHIPNO_FIELD] = this.txtShipNo.Text;
					try
					{
						StartTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtStartTime.Text);
						EndTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtEndTime.Text);
						ImportTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtImportTime.Text);
						ExportTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + this.txtExportTime.Text);
					}
					catch 
					{
						this.Response.Write("<script>alert('��������ȷ��ʱ���ʽ��HH:MM:SS!');</script>");
						return;
					}

					dr[PBRBData.STARTTIME_FIELD] = StartTime;
					dr[PBRBData.ENDTIME_FIELD] = EndTime;
					dr[PBRBData.IMPORTTIME_FIELD] = ImportTime;
					dr[PBRBData.EXPORTTIME_FIELD] = ExportTime;
					if (this.txtStartVolumn.Text.Trim().Length > 0 )//������ֹ�����Һλֵ��
					{
						try
						{
							dr[PBRBData.STARTVOLUMN_FIELD] = Convert.ToDecimal(this.txtStartVolumn.Text.Trim());
						}
						catch 
						{
							this.Response.Write("<script>alert(\"��������ȷ��Һλֵ��\");</script>");
							return;
						}
					}
					else//���û���ֹ����룬����Ϊ�Ǵ�ָ����ж�ȡҺλֵ��
					{
						//TODO: ���Ӵ�ָ�����ȡָ��̶�ֵ��
						dr[PBRBData.STARTVOLUMN_FIELD] = new STAGData().GetPLCValue(this.ConCode, StartTime);;	
					}
					if (this.txtEndVolumn.Text.Trim().Length > 0)//������ֹ�����Һλֵ��
					{
						try
						{
							dr[PBRBData.ENDVOLUMN_FIELD] = Convert.ToDecimal(this.txtEndVolumn.Text.Trim());
						}
						catch 
						{
							this.Response.Write("<script>alert(\"��������ȷ��Һλֵ��\");</script>");
							return;
						}
					}
					else
					{
						//TODO:	���Ӵ�ָ�����ȡָ��̶�ֵ��
						dr[PBRBData.ENDVOLUMN_FIELD] = new STAGData().GetPLCValue(this.ConCode, EndTime);;
					}
					dr[PBRBData.ITEMVOLUMN_FIELD] = this.CalcVolumn();
					
					txtItemSerial.Value="-1";
					btnAddItem.Text="����";
				}
				DGModel_Items1.DataSource=this.thisTable;
				DGModel_Items1.DataBind();				

				this.txtShipNo.Text="";
				this.txtStartTime.Text="";
				this.txtEndTime.Text="";
				this.txtImportTime.Text = "";
				this.txtExportTime.Text = "";
				this.txtStartVolumn.Text = "";
				this.txtEndVolumn.Text = "";
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
					iRow = int.Parse(DGModel_Items1.SelectedID);
	
					txtItemSerial.Value = iRow.ToString();

					this.txtShipNo.Text = this.thisTable.Rows[iRow][PBRBData.SHIPNO_FIELD].ToString();
					this.txtStartTime.Text = Convert.ToDateTime(this.thisTable.Rows[iRow][PBRBData.STARTTIME_FIELD].ToString()).ToShortTimeString();
					this.txtEndTime.Text = Convert.ToDateTime(this.thisTable.Rows[iRow][PBRBData.ENDTIME_FIELD].ToString()).ToShortTimeString();
					this.txtImportTime.Text = Convert.ToDateTime(this.thisTable.Rows[iRow][PBRBData.IMPORTTIME_FIELD].ToString()).ToShortTimeString();
					this.txtExportTime.Text = Convert.ToDateTime(this.thisTable.Rows[iRow][PBRBData.EXPORTTIME_FIELD].ToString()).ToShortTimeString();
					this.txtStartVolumn.Text = this.thisTable.Rows[iRow][PBRBData.STARTVOLUMN_FIELD].ToString();
					this.txtEndVolumn.Text = this.thisTable.Rows[iRow][PBRBData.ENDVOLUMN_FIELD].ToString();
					btnAddItem.Text="����";
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
		protected void btnForItemCode_Click(object sender, System.EventArgs e)
		{

		}   //End btnForItemCode_Click
		#endregion
	}
}
