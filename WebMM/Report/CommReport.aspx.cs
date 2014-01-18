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
	/// CommReport 的摘要说明。
	/// </summary>
	public partial class CommReport : System.Web.UI.Page
	{
		#region 成员变量
		private string ReportCode;

        /// <summary>
        /// 当前用户。
        /// </summary>
        public User CurrentUser
        {
            get { return Session["User"] as User; }
        }
		#endregion

		#region 属性
		/// <summary>
		/// 报表服务器地址。
		/// </summary>
		public string ReportServerURL
		{
			get { return System.Configuration.ConfigurationSettings.AppSettings["ReportServerUrl"].ToString(); }
		}
		#endregion

		#region 事件
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.ReportCode = this.Request["ReportCode"].ToString();
			this.RV_MyReport.ServerUrl = this.ReportServerURL;//设定报表服务器地址。
			switch (this.ReportCode)
			{
					#region 期初盘点报表
				case ReportType.StartMAIO_Report:
					this.Report_StartKCPD_Load();
					break;
					#endregion
					#region 期初盘点报表（账册）
				case ReportType.StartMAIOByCat_Report:
                    this.Report_StartKCPDByCat_Load();
					break;
					#endregion
					#region 仓库收发存报表
				case ReportType.StockSIOE_Report:
					this.Report_StockSIOE_Load();
					break;
					#endregion
					#region 期初盘点盘盈盘亏数据分布图表
				case ReportType.StartMAIO_Chart:
					this.Report_StartMAIOChart_Load();
					break;
					#endregion
					#region 期初盘点库存对照表。
				case ReportType.StartMAIO_Compare:
					this.Report_StartMAIOCompare_Load();
					break;
					#endregion
					#region 物料库存清单
				case ReportType.Stock_Report:
					this.Report_Stock_Load();
					break;
					#endregion
					#region 物料收发明细表
				case ReportType.Material_IO_Detail_Report:
					break;
					#endregion
					#region 收发汇总表
				case ReportType.ZBSIOETotal_Report:
					this.Report_ZBSIOETotal_Load();
					break;
					#endregion
					#region 材料收发存报表(赵雅芳).
				case ReportType.ZBGroupSIOETotal_Report:
					this.Report_ZBGroupSIOETotal_Load();
					break;
					#endregion
					#region 发出材料分级明细表
				case ReportType.Fin_OutFJHZB_Report:
					this.Report_Fin_OutFJHZB_Load();
					break;
					#endregion
					#region 发出材料分级汇总表
				case ReportType.Fin_OutFJHZB_Group_Report:
					this.Report_Fin_OutFJHZB_Group_Load();
					break;
					#endregion
					#region	 发票明细表。
				case ReportType.InvDetail_Report:
					this.Report_InvDetail_Load();
					break;
					#endregion
					#region 多余库存分析
				case ReportType.StockQuestion_Report:
					this.Report_StockQuestion_Load();
					break;
					#endregion
					#region 新版多余库存分析
				case ReportType.StockQuestionNew_Report:
					this.Report_StockQuestionNew_Load();
					break;
					#endregion
					#region 合同
				case ReportType.Contract_Report:
					this.Report_Contract_Load();
					break;
					#endregion
					#region 超期库存
				case ReportType.ExtendedStock_Report:
					this.Report_ExtendedStock_Load();
					break;
					#endregion
					#region 大宗物品采购跟踪.
				case ReportType.BigItemTrace_Report:
					this.Report_BigItemTrace_Load();
					break;
					#endregion
					#region 项目材料分析详细表.
				case ReportType.ProjectItemAnalysis_Report:
					this.Report_ProjectItemAnalysis_Load();
					break;
                #region 采购收料分析表
                case ReportType.ProjectStuffAnalysis_Report:
                    this.Report_ProjectStuffAnalysis_Load();
                    break;
                #endregion
					#endregion
					#region 低值易耗品的领用分布报表。
				case ReportType.LEECDist_Report:
					this.Report_LEECDist_Load();
					break;
					#endregion
			}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 期初库存盘点报表。
		/// </summary>
		private void Report_StartKCPD_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StartMAIO_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 期初库存盘点按分类报表。
		/// </summary>
		private void Report_StartKCPDByCat_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StartMAIOByCat_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 按仓库的收发存报表。
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
		/// 期初库存盘点数据分布图。
		/// </summary>
		private void Report_StartMAIOChart_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StartMAIO_ChartPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.False;
		}
		/// <summary>
		/// 期初库存盘点数据比较图。
		/// </summary>
		private void Report_StartMAIOCompare_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StartMAIO_ComparePath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.False;
		}
		/// <summary>
		/// 库存报表。
		/// </summary>
		private void Report_Stock_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.Stock_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 根据账本进行分类的材料收发存报表。
		/// </summary>
		private void Report_ZBSIOETotal_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.ZBSIOETotal_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 材料收发存标表(赵雅芳).
		/// </summary>
		private void Report_ZBGroupSIOETotal_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.ZBGroupSIOETotal_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 财务发出材料分级明细表。
		/// </summary>
		private void Report_Fin_OutFJHZB_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.Fin_OutFJHZB_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;

		}
		/// <summary>
		/// 财务发出材料分级汇总表。
		/// </summary>
		private void Report_Fin_OutFJHZB_Group_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.Fin_OutFJHZB_Group_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 发票明细内容报表。
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
		/// 多余库存分析。
		/// </summary>
		private void Report_StockQuestion_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StockQuestion_ReportPath;
			this.RV_MyReport.Toolbar =	Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 新版多余库存分析。
		/// </summary>
		private void Report_StockQuestionNew_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.StockQuestionNew_ReportPath;
			this.RV_MyReport.Toolbar =	Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 合同。
		/// </summary>
		private void Report_Contract_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.Contract_ReportPath;
			this.RV_MyReport.Toolbar =	Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 超期库存。
		/// </summary>
		private void Report_ExtendedStock_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.ExtendedStock_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 大宗物品采购跟踪分析报表。
		/// </summary>
		private void Report_BigItemTrace_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.BigItemTrace_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}
		/// <summary>
		/// 项目物料采购分析报表。
		/// </summary>
		private void Report_ProjectItemAnalysis_Load()
		{
			this.RV_MyReport.ReportPath = ReportPath.ProjectItemAnalysis_ReportPath;
			this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
			this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
		}

        /// <summary>
        /// 采购收料分析表。
        /// </summary>
        private void Report_ProjectStuffAnalysis_Load()
        {
            this.RV_MyReport.ReportPath = ReportPath.ProjectStuffAnalysis_ReportPath;
            this.RV_MyReport.Toolbar = Microsoft.ReportingServices.ReportViewer.multiState.True;
            this.RV_MyReport.Parameters = Microsoft.ReportingServices.ReportViewer.multiState.True;
        }

		/// <summary>
		/// 低值易耗品的领用分布报表。
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