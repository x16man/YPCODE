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
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using Shmzh.Components.SystemComponent;

namespace MZHMM.WebMM.Report
{
	/// <summary>
	/// CommReport ��ժҪ˵����
	/// </summary>
	public partial class CommReport : System.Web.UI.Page
	{
		#region ��Ա����
		private string ReportCode;

        /// <summary>
        /// ��ǰ�û���
        /// </summary>
        public User CurrentUser
        {
            get { return Session["User"] as User; }
        }
		#endregion

		#region ����
		/// <summary>
		/// �����������ַ��
		/// </summary>
		public string ReportServerURL
		{
			get { return System.Configuration.ConfigurationSettings.AppSettings["ReportServerUrl"].ToString(); }
		}
		#endregion

		#region �¼�
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.ReportCode = this.Request["ReportCode"].ToString();
			this.RV_MyReport.ServerUrl = this.ReportServerURL;//�趨�����������ַ��
			switch (this.ReportCode)
			{
					#region �ڳ��̵㱨��
				case ReportType.StartMAIO_Report:
					this.Report_StartKCPD_Load();
					break;
					#endregion
					#region �ڳ��̵㱨���˲ᣩ
				case ReportType.StartMAIOByCat_Report:
                    this.Report_StartKCPDByCat_Load();
					break;
					#endregion
					#region �ֿ��շ��汨��
				case ReportType.StockSIOE_Report:
					this.Report_StockSIOE_Load();
					break;
					#endregion
					#region �ڳ��̵���ӯ�̿����ݷֲ�ͼ��
				case ReportType.StartMAIO_Chart:
					this.Report_StartMAIOChart_Load();
					break;
					#endregion
					#region �ڳ��̵�����ձ�
				case ReportType.StartMAIO_Compare:
					this.Report_StartMAIOCompare_Load();
					break;
					#endregion
					#region ���Ͽ���嵥
				case ReportType.Stock_Report:
					this.Report_Stock_Load();
					break;
					#endregion
					#region �����շ���ϸ��
				case ReportType.Material_IO_Detail_Report:
					break;
					#endregion
					#region �շ����ܱ�
				case ReportType.ZBSIOETotal_Report:
					this.Report_ZBSIOETotal_Load();
					break;
					#endregion
					#region �����շ��汨��(���ŷ�).
				case ReportType.ZBGroupSIOETotal_Report:
					this.Report_ZBGroupSIOETotal_Load();
					break;
					#endregion
					#region �������Ϸּ���ϸ��
				case ReportType.Fin_OutFJHZB_Report:
					this.Report_Fin_OutFJHZB_Load();
					break;
					#endregion
					#region �������Ϸּ����ܱ�
				case ReportType.Fin_OutFJHZB_Group_Report:
					this.Report_Fin_OutFJHZB_Group_Load();
					break;
					#endregion
					#region	 ��Ʊ��ϸ��
				case ReportType.InvDetail_Report:
					this.Report_InvDetail_Load();
					break;
					#endregion
					#region ���������
				case ReportType.StockQuestion_Report:
					this.Report_StockQuestion_Load();
					break;
					#endregion
					#region �°���������
				case ReportType.StockQuestionNew_Report:
					this.Report_StockQuestionNew_Load();
					break;
					#endregion
					#region ��ͬ
				case ReportType.Contract_Report:
					this.Report_Contract_Load();
					break;
					#endregion
					#region ���ڿ��
				case ReportType.ExtendedStock_Report:
					this.Report_ExtendedStock_Load();
					break;
					#endregion
					#region ������Ʒ�ɹ�����.
				case ReportType.BigItemTrace_Report:
					this.Report_BigItemTrace_Load();
					break;
					#endregion
					#region ��Ŀ���Ϸ�����ϸ��.
				case ReportType.ProjectItemAnalysis_Report:
					this.Report_ProjectItemAnalysis_Load();
					break;
                #region �ɹ����Ϸ�����
                case ReportType.ProjectStuffAnalysis_Report:
                    this.Report_ProjectStuffAnalysis_Load();
                    break;
                #endregion
					#endregion
					#region ��ֵ�׺�Ʒ�����÷ֲ�����
				case ReportType.LEECDist_Report:
					this.Report_LEECDist_Load();
					break;
					#endregion
			}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// �ڳ�����̵㱨��
		/// </summary>
		private void Report_StartKCPD_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StartMAIO_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// �ڳ�����̵㰴���౨��
		/// </summary>
		private void Report_StartKCPDByCat_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StartMAIOByCat_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// ���ֿ���շ��汨��
		/// </summary>
		private void Report_StockSIOE_Load()
		{
            if(CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.StockAnalysisZero))
    			this.RV_MyReport.ReportPath = ReportPath.StockSIOE_ReportPath;
            else
                this.RV_MyReport.ReportPath = ReportPath.StockSIOE_ReportZeroPath;

			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// �ڳ�����̵����ݷֲ�ͼ��
		/// </summary>
		private void Report_StartMAIOChart_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StartMAIO_ChartPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.False;
		}
		/// <summary>
		/// �ڳ�����̵����ݱȽ�ͼ��
		/// </summary>
		private void Report_StartMAIOCompare_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StartMAIO_ComparePath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.False;
		}
		/// <summary>
		/// ��汨��
		/// </summary>
		private void Report_Stock_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.Stock_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// �����˱����з���Ĳ����շ��汨��
		/// </summary>
		private void Report_ZBSIOETotal_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.ZBSIOETotal_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// �����շ�����(���ŷ�).
		/// </summary>
		private void Report_ZBGroupSIOETotal_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.ZBGroupSIOETotal_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// ���񷢳����Ϸּ���ϸ��
		/// </summary>
		private void Report_Fin_OutFJHZB_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.Fin_OutFJHZB_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;

		}
		/// <summary>
		/// ���񷢳����Ϸּ����ܱ�
		/// </summary>
		private void Report_Fin_OutFJHZB_Group_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.Fin_OutFJHZB_Group_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// ��Ʊ��ϸ���ݱ���
		/// </summary>
		private void Report_InvDetail_Load()
		{
			int EntryNo;
			string InvoiceNo;
			EntryNo = Convert.ToInt32(this.Request["ID"].ToString());
			
			BillOfReceiveData oBORData = new PurchaseSystem().GetBRByEntryNo(EntryNo);
			InvoiceNo = oBORData.Tables[BillOfReceiveData.PBOR_TABLE].Rows[0][BillOfReceiveData.INVOICENO_FIELD].ToString();

			this.RV_MyReport.ReportPath = ReportPath.InvDetail_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.SetQueryParameter("InvoiceNo",InvoiceNo);
		}
		/// <summary>
		/// �����������
		/// </summary>
		private void Report_StockQuestion_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StockQuestion_ReportPath;
			this.RV_MyReport.Toolbar =	Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// �°�����������
		/// </summary>
		private void Report_StockQuestionNew_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StockQuestionNew_ReportPath;
			this.RV_MyReport.Toolbar =	Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// ��ͬ��
		/// </summary>
		private void Report_Contract_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.Contract_ReportPath;
			this.RV_MyReport.Toolbar =	Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// ���ڿ�档
		/// </summary>
		private void Report_ExtendedStock_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.ExtendedStock_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// ������Ʒ�ɹ����ٷ�������
		/// </summary>
		private void Report_BigItemTrace_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.BigItemTrace_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// ��Ŀ���ϲɹ���������
		/// </summary>
		private void Report_ProjectItemAnalysis_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.ProjectItemAnalysis_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}

        /// <summary>
        /// �ɹ����Ϸ�����
        /// </summary>
        private void Report_ProjectStuffAnalysis_Load()
        {
            this.RV_MyReport.ReportPath = ReportPath.ProjectStuffAnalysis_ReportPath;
            this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
            this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
        }

		/// <summary>
		/// ��ֵ�׺�Ʒ�����÷ֲ�����
		/// </summary>
		private void Report_LEECDist_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.LEECDist_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		#endregion
		
	}

}