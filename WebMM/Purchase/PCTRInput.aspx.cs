using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MZHMM.Facade;
using MZHMM.Common;
using MZHMM.WebMM.Modules;

namespace MZHMM.WebMM.Purchase
{
	/// <summary>
	/// PCTRInput ��ժҪ˵����
	/// </summary>
	public partial class PCTRInput : System.Web.UI.Page
	{

		private string op = "New";
		public    System.Web.UI.WebControls.TextBox txtRemark;

		protected StorageDropdownlist ddlType = new StorageDropdownlist();
		protected StorageDropdownlist ddlPrv = new StorageDropdownlist();

		private string code;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Contract;
			// �ڴ˴������û������Գ�ʼ��ҳ��
			ddlPrv.Width = "100%";
			ddlType.Width = "100%";
			//��ȡ����Ĺ�Ӧ�̴���Ͳ�����ǡ�
			if (Request["Code"] != null && Request["Code"] != "")
			{
				code = Request["Code"];
				op = Request["Op"];
			}
			//���ݲ�ͬ��״̬�������ݰ󶨡�
			if(!Page.IsPostBack)
			{
				if(op!="New")
				{
					BindDataUpdate();
				}
				else
				{
					BindDataNew();
				}
			}
		}

		/// <summary>
		/// ����״̬�µ����ݰ󶨡�
		/// </summary>
		private void BindDataNew()
		{
			//���
			this.ddlType.Module_Tag= (int)SDDLTYPE.CTYP;
			//״̬
			this.ddlPrv.Module_Tag=(int)SDDLTYPE.VENDOR;
		}
		/// <summary>
		/// �༭״̬�µ����ݰ󶨡�
		/// </summary>
		private void BindDataUpdate()
		{
			PCTRData oPCTRData = new PCTRData();
			PCTRSystem oPCTRSystem = new PCTRSystem();
			oPCTRData = oPCTRSystem.GetPCTRByEntryNo(this.code);
			//��ֵ
			DataRow oDataRow = oPCTRData.Tables[PCTRData.PCTR_TABLE].Rows[0];
			
			this.txtOldEntryCode.Text = oDataRow[PCTRData.ENTRYCODE_FIELD].ToString();						
			this.txtEntryCode.Text=oDataRow[PCTRData.ENTRYCODE_FIELD].ToString();							
			this.txtEntryName.Text=oDataRow[PCTRData.ENTRYNAME_FIELD].ToString();							
			this.ddlType.Module_Tag = (int)SDDLTYPE.CTYP;
			this.ddlType.SelectedValue = oDataRow[PCTRData.TYPECODE_FIELD].ToString();					
			this.ddlPrv.Module_Tag = (int)SDDLTYPE.VENDOR;
			this.ddlPrv.SelectedValue = oDataRow[PCTRData.PRVCODE_FIELD].ToString();			
			
			if (oDataRow[PCTRData.ENTRYDATE_FIELD] != DBNull.Value)								
				this.txtEntryDate.Text = oDataRow[PCTRData.ENTRYDATE_FIELD].ToString();
			if (oDataRow[PCTRData.MANAGER_FIELD] != DBNull.Value)								
				this.txtManager.Text = oDataRow[PCTRData.MANAGER_FIELD].ToString();
			if (oDataRow[PCTRData.TOTALMONEY_FIELD] != DBNull.Value)							
				this.txtTotalMoney.Text = oDataRow[PCTRData.TOTALMONEY_FIELD].ToString();
			if (oDataRow[PCTRData.STAMPTAX_FIELD] != DBNull.Value)								
				this.txtStampTax.Text = oDataRow[PCTRData.STAMPTAX_FIELD].ToString();
			if (oDataRow[PCTRData.PAYMONEY_FIELD] != DBNull.Value)								
				this.txtPayMoney.Text = oDataRow[PCTRData.PAYMONEY_FIELD].ToString();
			if (oDataRow[PCTRData.LEFTMONEY_FIELD] != DBNull.Value)								
				this.txtLeftMoney.Text = oDataRow[PCTRData.LEFTMONEY_FIELD].ToString();
			if (oDataRow[PCTRData.STARTDATE_FIELD] != DBNull.Value)								
				this.txtStartDate.Text = oDataRow[PCTRData.STARTDATE_FIELD].ToString();
			if (oDataRow[PCTRData.ENDDATE_FIELD] != DBNull.Value)								
				this.txtEndDate.Text = oDataRow[PCTRData.ENDDATE_FIELD].ToString();
			if (oDataRow[PCTRData.CLEANDATE_FIELD] != DBNull.Value)								
				this.txtCleanDate.Text = oDataRow[PCTRData.CLEANDATE_FIELD].ToString();
			if (oDataRow[PCTRData.REMARK_FIELD] != DBNull.Value)								
				this.txtRemark.Text = oDataRow[PCTRData.REMARK_FIELD].ToString();
			//if(op=="Edit")	txtCode.Enabled=false;
		}

		/// <summary>
		/// ҳ���ύ�¼�����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			PCTRData oPCTRData = new PCTRData();

			DataRow oDataRow = oPCTRData.Tables[PCTRData.PCTR_TABLE].NewRow();
			//��ҳ���ϵ�����ѹ��DataRow�С�
			if (op == "Edit")//����Ǳ༭״̬�����OldEntryno��ֵ��
			{
				oDataRow[PCTRData.ENTRYNO_FIELD] = this.code;	
			}
			else
			{
				//��д����Ϣ
				oDataRow[PCTRData.AUTHORDATE_FIELD] = System.DateTime.Now.ToShortDateString();	
				if (Session["USERCODE"] != null)
					oDataRow[PCTRData.AUTHORCODE_FIELD] = Session["USERCODE"];
				if (Session["USERNAME"] != null)
					oDataRow[PCTRData.AUTHORNAME_FIELD] = Session["USERNAME"];
				if (Session["USERDEPTCODE"] != null)
					oDataRow[PCTRData.AUTHORDEPT_FIELD] = Session["USERDEPTCODE"];
				if (Session["USERCODE"] != null)
					oDataRow[PCTRData.AUTHORDEPTNAME_FIELD] = Session["USERDEPTNAME"];
			}
			oDataRow[PCTRData.ENTRYCODE_FIELD] = this.txtEntryCode.Text;				
			oDataRow[PCTRData.ENTRYNAME_FIELD] = this.txtEntryName.Text;				

			oDataRow[PCTRData.TYPECODE_FIELD] = this.ddlType.SelectedValue;				
			oDataRow[PCTRData.PRVCODE_FIELD] = this.ddlPrv.SelectedValue;		
			oDataRow[PCTRData.TYPENAME_FIELD] = this.ddlType.SelectedText;
			oDataRow[PCTRData.PRVNAME_FIELD] = this.ddlPrv.SelectedText;

			if (this.txtEntryDate.Text != null && this.txtEntryDate.Text != "")	
				oDataRow[PCTRData.ENTRYDATE_FIELD] = this.txtEntryDate.Text;
			if (this.txtManager.Text != null && this.txtManager.Text != "")		
				oDataRow[PCTRData.MANAGER_FIELD] = this.txtManager.Text;
			if (this.txtTotalMoney.Text != null && this.txtTotalMoney.Text != "")		
				oDataRow[PCTRData.TOTALMONEY_FIELD] = this.txtTotalMoney.Text;
			if (this.txtStampTax.Text != null && this.txtStampTax.Text != "")			
				oDataRow[PCTRData.STAMPTAX_FIELD] = this.txtStampTax.Text;
			if (this.txtPayMoney.Text != null && this.txtPayMoney.Text != "")			
				oDataRow[PCTRData.PAYMONEY_FIELD] = this.txtPayMoney.Text;
			if (this.txtLeftMoney.Text != null && this.txtLeftMoney.Text != "")
				oDataRow[PCTRData.LEFTMONEY_FIELD] = this.txtLeftMoney.Text;
			if (this.txtStartDate.Text != null && this.txtStartDate.Text != "")	
				oDataRow[PCTRData.STARTDATE_FIELD] = this.txtStartDate.Text;
			if (this.txtEndDate.Text != null && this.txtEndDate.Text != "")		
				oDataRow[PCTRData.ENDDATE_FIELD] = this.txtEndDate.Text;
			if (this.txtCleanDate.Text != null && this.txtCleanDate.Text != "")	
				oDataRow[PCTRData.CLEANDATE_FIELD] = this.txtCleanDate.Text;
			if (this.txtRemark.Text != null && this.txtRemark.Text != "")		
				oDataRow[PCTRData.REMARK_FIELD] = this.txtRemark.Text;

			oPCTRData.Tables[PCTRData.PCTR_TABLE].Rows.Add(oDataRow);

			PCTRSystem oPCTRSystem = new PCTRSystem();
			//�ύ��
			if (op=="Edit")
			{
				if (oPCTRSystem.UpdatePCTR(oPCTRData) == false)
				{
					Response.Redirect("../ErrorPage.aspx?ErrorInfo="+oPCTRSystem.Message);
				}
			}
			else
			{
//				if (oPCTRSystem.AddPCTR(oPCTRData) == false)
//				{
//					Response.Redirect("../ErrorPage.aspx?ErrorInfo="+oPCTRSystem.Message);
//				}
			}
			Response.Redirect("PCTRBrowser.aspx");
		}


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
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
