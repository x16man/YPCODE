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
	public partial class PCBRWebControl : System.Web.UI.UserControl
	{
		#region ��Ա����

		//private static DataTable dt;//������һ��̬�ı�,���Ա���״̬����
		private string tmpCode;
		private string _OP;
		private decimal _TotalVolumn;
		protected System.Web.UI.WebControls.TextBox txtTaxRate;
		public DGModel_Items DGModel_Items1;

	    private DataColumnCollection columns;

	    private PurchaseSystem oPurchaseSystem;

	    private CITMData oCITMData;
	    private DataTable temp;

	    private DataRow dr;
	    private int i;

	    private decimal Temp_VolumnItem;
        private decimal Temp_ThicknessItem;
        private decimal Temp_DensityItem;
        private decimal Temp_SolidItem;
        private STAGData oSTAGData;
        private SysSystem oSysSystem = new SysSystem();

	    private int iRow;
		#endregion

		#region ����
		/// <summary>
		/// ʵ�������
		/// </summary>
		public decimal TotalVolumn
		{
			set { this._TotalVolumn = value; }
		}
		/// <summary>
		/// ��̬���ݱ�
		/// </summary>
		public DataTable thisTable
		{
			get
			{
				if (Session[MySession.CBR_DT] != null)
					return (DataTable)Session[MySession.CBR_DT];
				else
					return null;
			}	
			set
			{
				Session[MySession.CBR_DT] = value;
			}
		}
		/// <summary>
		/// ��ע���ԡ�
		/// </summary>
		public string Remark
		{
			get {	return this.txtRemark.Text;}
			set {	this.txtRemark.Text = value;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// �����ݽ���У��.
		/// </summary>
		/// <returns>bool:	У��ͨ������true��ʧ�ܷ���false��</returns>
		private bool DoCheck()
		{
			bool ret=true;
			try
			{
				if((txtCitmValue.Text==""))
				{
					ret=false;
				}

			}
			catch
			{
				ret=false;
			}
			return ret;
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

			//��ʼ��
			DGModel_Items1.SelectedType=DGModel.SelectType.SingleSelect;
			DGModel_Items1.ShowPager=false;
			DGModel_Items1.AllowPaging = false;
			DGModel_Items1.ColumnsScheme = ColumnScheme.PCBR;

			if((!this.IsPostBack) && (this.Request["Op"].ToString()=="New"))
			{
				//���������ݽṹ
				if(this.thisTable!=null) 
					this.thisTable = null;
				this.thisTable=new DataTable();

				columns = this.thisTable.Columns;
				columns.Add("CitmCode").DataType = typeof(System.Int32);
				columns.Add("CitmName").DataType = typeof(System.String);
				columns.Add("CitmUnit").DataType = typeof(System.String);
				columns.Add("CitmValue").DataType = typeof(System.String);

				
				oPurchaseSystem = new PurchaseSystem();
				oCITMData = oPurchaseSystem.GetCITMByRepCode(DocType.CBR);
				temp = oCITMData.Tables[CITMData.CITM_TABLE];
				for(i=0;i<temp.Rows.Count;i++)
				{
					dr = this.thisTable.NewRow();
					dr["CitmCode"] = temp.Rows[i][CITMData.CODE_FIELD].ToString();
					dr["CitmName"] = temp.Rows[i][CITMData.DESCRIPTION_FIELD].ToString();
					dr["CitmUnit"] = temp.Rows[i][CITMData.UNIT_FIELD].ToString();
					if (temp.Rows[i][CITMData.CODE_FIELD].ToString() == "1")
					{
						dr["CitmValue"] = this._TotalVolumn;
					}
					this.thisTable.Rows.Add(dr);
				}
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
			this.thisTable = null;
		}*/
		
		/// <summary>
		/// ���Ӱ�ť��
		/// </summary>
		protected void btnAddItem_Click(object sender, System.EventArgs e)
		{
			
			oSTAGData = oSysSystem.GetSTAGInfo();
						
			if(DoCheck())
			{
				iRow = int.Parse(txtItemSerial.Value);
				dr = this.thisTable.Rows[iRow];
				dr["CitmValue"] = txtCitmValue.Text;
				//��������걸�ˣ��ͽ����Զ�����Һ�����۹�����
				if (!string.IsNullOrEmpty(thisTable.Rows[oSTAGData.VolumnItem - 1]["CitmValue"].ToString()) && 
					!string.IsNullOrEmpty(this.thisTable.Rows[oSTAGData.ThicknessItem - 1]["CitmValue"].ToString()) && 
					!string.IsNullOrEmpty(this.thisTable.Rows[oSTAGData.DensityItem - 1]["CitmValue"].ToString()))
				{
					try
					{
						Temp_VolumnItem = Convert.ToDecimal(this.thisTable.Rows[oSTAGData.VolumnItem - 1]["CitmValue"].ToString());
						Temp_ThicknessItem = Convert.ToDecimal(this.thisTable.Rows[oSTAGData.ThicknessItem - 1]["CitmValue"].ToString());
						Temp_DensityItem = Convert.ToDecimal(this.thisTable.Rows[oSTAGData.DensityItem - 1]["CitmValue"].ToString());
						Temp_SolidItem = Math.Round((Temp_VolumnItem*Temp_ThicknessItem*Temp_DensityItem)/(decimal)(7.8*2),2);
						this.thisTable.Rows[oSTAGData.SolidItem - 1]["CitmValue"]  = Temp_SolidItem;
					}
					catch
					{

					}
				}
				txtItemSerial.Value = "-1";
				DGModel_Items1.DataSource = this.thisTable;
				DGModel_Items1.DataBind();	
				
                txtCitmCode.Text= "";
				txtCitmName.Text = "";
				txtCitmUnit.Text = "";
				txtCitmValue.Text = "";
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
					iRow=int.Parse(DGModel_Items1.SelectedID);
	
					txtItemSerial.Value=iRow.ToString();

					txtCitmCode.Text = this.thisTable.Rows[iRow]["CitmCode"].ToString();
					txtCitmCode.Enabled = false;
					txtCitmName.Text = this.thisTable.Rows[iRow]["CitmName"].ToString();
					txtCitmName.Enabled = false;
					txtCitmUnit.Text = this.thisTable.Rows[iRow]["CitmUnit"].ToString();
					txtCitmUnit.Enabled = false;
					txtCitmValue.Text = this.thisTable.Rows[iRow]["CitmValue"].ToString();
				}
			}

		}
		/// <summary>
		/// ɾ����ť��
		/// </summary>
		protected void btnDelItem_Click(object sender, System.EventArgs e)
		{
			txtCitmCode.Text= "";
			txtCitmName.Text = "";
			txtCitmUnit.Text = "";
			txtCitmValue.Text = "";
			txtItemSerial.Value="-1";
		}
		#endregion
	}
}
