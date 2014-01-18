namespace MZHMM.WebMM.Analysis
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Shmzh.Components.SystemComponent;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	using Infragistics.WebUI.UltraWebGrid;
	/// <summary>
	///		WUC_DocStat 的摘要说明。
	/// </summary>
	public partial class WUC_DocStat : System.Web.UI.UserControl
	{
		private int DocCode;
		//protected Infragistics.WebUI.WebSchedule.WebDateChooser wdcStartDate;
		//protected Infragistics.WebUI.WebSchedule.WebDateChooser wdcEndDate;
		private string UserLoginID;
		#region 属性
		public DateTime StartDate
		{
			get 
			{
                if (wdcStartDate.Text != "")
                    return DateTime.Parse(this.wdcStartDate.Text);
                else
                    return System.DateTime.Now;
				//return Convert.ToDateTime(this.dateStartDate.SelectedDate);
			}
			set 
			{
				this.wdcStartDate.Text = value.ToString("yyyy-MM-dd");
				//this.dateStartDate.SelectedDate = value.ToShortDateString();
			}
		}
		public DateTime EndDate
		{
			get 
			{
                if (wdcEndDate.Text != "")
				    return DateTime.Parse(this.wdcEndDate.Text
                        );
                else
                    return System.DateTime.Now;
				//return Convert.ToDateTime(this.dateEndDate.SelectedDate);
			}
			set 
			{
                this.wdcEndDate.Text = value.ToString("yyyy-MM-dd");
				//this.dateEndDate.SelectedDate = value.ToShortDateString();
			}
		}
		#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (this.Request["DocCode"] != null)
			{
				this.DocCode = Convert.ToInt16(this.Request["DocCode"].ToString());
				//this.Response.Write(this.DocCode.ToString());
			}
			if (this.Session[MySession.UserLoginId] != null)
			{
				this.UserLoginID = this.Session[MySession.UserLoginId].ToString();
			}
			if (!this.IsPostBack)
			{
				this.StartDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
				this.EndDate = this.StartDate.AddMonths(1);
				this.UltraWebGrid1.DataBind();
				this.UltraWebGrid1.Bands[0].Key = "Parent";
				this.UltraWebGrid1.Bands[1].Key = "Child";
			}
			
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.UltraWebGrid1.InitializeRow += new Infragistics.WebUI.UltraWebGrid.InitializeRowEventHandler(this.UltraWebGrid1_InitializeRow);
			this.UltraWebGrid1.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UltraWebGrid1_InitializeLayout);
			this.UltraWebGrid1.InitializeGroupByRow += new Infragistics.WebUI.UltraWebGrid.InitializeGroupByRowEventHandler(this.UltraWebGrid1_InitializeGroupByRow);

		}
		#endregion

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			//this.UltraWebGrid1.Width = new Unit("100%");
			this.UltraWebGrid1.DisplayLayout.Strings.NoDataMessage = "本月还没有数据。";
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Hierarchical;
			//this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;
			//this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").IsGroupByColumn = true;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign =   HorizontalAlign.Center;

			this.UltraWebGrid1.Bands[0].Columns.FromKey("DocCode").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("DocName").Hidden = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDept").Hidden = true;
			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").Header.Caption = "部门";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").CellStyle.HorizontalAlign = HorizontalAlign.Left;

			//this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ToDoCount").Header.Caption = "待审批数目";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ToDoCount").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ToDoCount").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ToDoSubTotal").Header.Caption = "待审批金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ToDoSubTotal").Format = "0.00";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ToDoSubTotal").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("NoCount").Header.Caption = "审批不通过数目";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("NoCount").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("NoCount").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("NoSubTotal").Header.Caption = "审批不通过金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("NoSubTotal").Format = "0.00";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("NoSubTotal").CellStyle.HorizontalAlign = HorizontalAlign.Right;			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("YesCount").Header.Caption = "审批通过数目";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("YesCount").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("YesCount").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("YesSubTotal").Header.Caption = "审批通过金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("YesSubTotal").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("YesSubTotal").Format = "0.00";
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////
			this.UltraWebGrid1.Bands[1].Columns.FromKey("DocCode").Hidden = true;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("DocName").Hidden = true;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("AuthorDept").Hidden = true;
			
			this.UltraWebGrid1.Bands[1].Columns.FromKey("AuthorDeptName").Header.Caption = "部门";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("AuthorDeptName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("AuthorCode").Hidden = true;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("AuthorName").Header.Caption = "制单";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("AuthorName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("ToDoCount").Header.Caption = "待审批数目";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("ToDoCount").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("ToDoCount").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("ToDoSubTotal").Header.Caption = "待审批金额";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("ToDoSubTotal").Format = "0.00";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("ToDoSubTotal").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("NoCount").Header.Caption = "审批不通过数目";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("NoCount").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("NoCount").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("NoSubTotal").Header.Caption = "审批不通过金额";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("NoSubTotal").Format = "0.00";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("NoSubTotal").CellStyle.HorizontalAlign = HorizontalAlign.Right;			
			this.UltraWebGrid1.Bands[1].Columns.FromKey("YesCount").Header.Caption = "审批通过数目";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("YesCount").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("YesCount").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("YesSubTotal").Header.Caption = "审批通过金额";
			this.UltraWebGrid1.Bands[1].Columns.FromKey("YesSubTotal").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[1].Columns.FromKey("YesSubTotal").Format = "0.00";
			
			switch(this.DocCode)
			{
				case DocType.ROS:
					this.lblTitle.Text = "紧急申购统计";
					//this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "本月 [caption]:<A HREF='../purchase/ROSBrowser.aspx?DocCode=1&AuthorDept=[avg:AuthorDept]'> [value]</A> 审批通过： <A HREF='../purchase/ROSBrowser.aspx?DocCode=1&AuthorDept=[avg:AuthorDept]&AuditResult=1'>[sum:YesCount] 张 合计 [sum:YesSubTotal]元</A> 待审批： <A HREF='../purchase/ROSBrowser.aspx?DocCode=1&AuthorDept=[avg:AuthorDept]&AuditResult=0'>[sum:ToDoCount] 张 合计 [sum:ToDoSubTotal]元</A> 审批不通过： <A HREF='../purchase/ROSBrowser.aspx?DocCode=1&AuthorDept=[avg:AuthorDept]&AuditResult=-1'>[sum:NoCount]张  合计 [sum:NoSubTotal]元</A>";
					break;
				case DocType.MRP:
					this.lblTitle.Text = "计划需求统计";
					//this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "本月 [caption]:<A HREF='../purchase/MRPBrowser.aspx?DocCode=2&AuthorDept=[avg:AuthorDept]'> [value]</A> 审批通过： <A HREF='../purchase/MRPBrowser.aspx?DocCode=2&AuthorDept=[avg:AuthorDept]&AuditResult=1'>[sum:YesCount] 张 合计 [sum:YesSubTotal]元</A> 待审批： <A HREF='../purchase/MRPBrowser.aspx?DocCode=2&AuthorDept=[avg:AuthorDept]&AuditResult=0'>[sum:ToDoCount] 张 合计 [sum:ToDoSubTotal]元</A> 审批不通过： <A HREF='../purchase/MRPBrowser.aspx?DocCode=2&AuthorDept=[avg:AuthorDept]&AuditResult=-1'>[sum:NoCount]张  合计 [sum:NoSubTotal]元</A>";
					break;
				case DocType.PO:
					this.lblTitle.Text = "采购订单统计";
					//this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "本月 [caption]:<A HREF='../purchase/POBrowser.aspx?DocCode=3&AuthorDept=[avg:AuthorDept]'> [value]</A> 审批通过： <A HREF='../purchase/POBrowser.aspx?DocCode=3&AuthorDept=[avg:AuthorDept]&AuditResult=1'>[sum:YesCount] 张 合计 [sum:YesSubTotal]元</A> 待审批： <A HREF='../purchase/POBrowser.aspx?DocCode=3&AuthorDept=[avg:AuthorDept]&AuditResult=0'>[sum:ToDoCount] 张 合计 [sum:ToDoSubTotal]元</A> 审批不通过： <A HREF='../purchase/POBrowser.aspx?DocCode=3&AuthorDept=[avg:AuthorDept]&AuditResult=-1'>[sum:NoCount]张  合计 [sum:NoSubTotal]元</A>";
					break;
				case DocType.BOR:
					this.lblTitle.Text = "采购收料统计";
					//this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "本月 [caption]:<A HREF='../purchase/PBORBrowser.aspx?DocCode=6&AuthorDept=[avg:AuthorDept]'> [value]</A> 审批通过： <A HREF='../purchase/PBORBrowser.aspx?DocCode=6&AuthorDept=[avg:AuthorDept]&AuditResult=1'>[sum:YesCount] 张 合计 [sum:YesSubTotal]元</A> 待审批： <A HREF='../purchase/PBORBrowser.aspx?DocCode=6&AuthorDept=[avg:AuthorDept]&AuditResult=0'>[sum:ToDoCount] 张 合计 [sum:ToDoSubTotal]元</A> 审批不通过： <A HREF='../purchase/PBORBrowser.aspx?DocCode=6&AuthorDept=[avg:AuthorDept]&AuditResult=-1'>[sum:NoCount]张  合计 [sum:NoSubTotal]元</A>";
					break;
				case DocType.RTV:
					this.lblTitle.Text = "采购退货统计";
					//this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "本月 [caption]:<A HREF='../purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept=[avg:AuthorDept]'> [value]</A> 审批通过： <A HREF='../purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept=[avg:AuthorDept]&AuditResult=1'>[sum:YesCount] 张 合计 [sum:YesSubTotal]元</A> 待审批： <A HREF='../purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept=[avg:AuthorDept]&AuditResult=0'>[sum:ToDoCount] 张 合计 [sum:ToDoSubTotal]元</A> 审批不通过： <A HREF='../purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept=[avg:AuthorDept]&AuditResult=-1'>[sum:NoCount]张  合计 [sum:NoSubTotal]元</A>";
					break;
				case DocType.DRW:
					this.lblTitle.Text = "领料单统计";
					//this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "本月 [caption]:<A HREF='../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept=[avg:AuthorDept]'> [value]</A> 审批通过： <A HREF='../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept=[avg:AuthorDept]&AuditResult=1'>[sum:YesCount] 张 合计 [sum:YesSubTotal]元</A> 待审批： <A HREF='../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept=[avg:AuthorDept]&AuditResult=0'>[sum:ToDoCount] 张 合计 [sum:ToDoSubTotal]元</A> 审批不通过： <A HREF='../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept=[avg:AuthorDept]&AuditResult=-1'>[sum:NoCount]张  合计 [sum:NoSubTotal]元</A>";
					break;
				case DocType.WTOW:
					this.lblTitle.Text = "委外加工申请统计";
					//this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "本月 [caption]:<A HREF='../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept=[avg:AuthorDept]'> [value]</A> 审批通过： <A HREF='../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept=[avg:AuthorDept]&AuditResult=1'>[sum:YesCount] 张 合计 [sum:YesSubTotal]元</A> 待审批： <A HREF='../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept=[avg:AuthorDept]&AuditResult=0'>[sum:ToDoCount] 张 合计 [sum:ToDoSubTotal]元</A> 审批不通过： <A HREF='../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept=[avg:AuthorDept]&AuditResult=-1'>[sum:NoCount]张  合计 [sum:NoSubTotal]元</A>";
					break;
				case DocType.WINW:
					this.lblTitle.Text = "委外加工收料统计";
					//this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "本月 [caption]:<A HREF='../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept=[avg:AuthorDept]'> [value]</A> 审批通过： <A HREF='../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept=[avg:AuthorDept]&AuditResult=1'>[sum:YesCount] 张 合计 [sum:YesSubTotal]元</A> 待审批： <A HREF='../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept=[avg:AuthorDept]&AuditResult=0'>[sum:ToDoCount] 张 合计 [sum:ToDoSubTotal]元</A> 审批不通过： <A HREF='../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept=[avg:AuthorDept]&AuditResult=-1'>[sum:NoCount]张  合计 [sum:NoSubTotal]元</A>";
					break;
			}
		}

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			SQLServer oSQLServer = new SQLServer();
			Hashtable oHT = new Hashtable();
			oHT.Add("@DocCode", DocCode);
			oHT.Add("@StartDate", StartDate);
			oHT.Add("@EndDate", EndDate);
			oHT.Add("@UserLoginID", UserLoginID);
			DataSet oData = new DataSet();
			oData = oSQLServer.ExecSPReturnDS("Analysis_GetDocStatGroup",oHT,oData,"Parent");
			oData = oSQLServer.ExecSPReturnDS("Analysis_GetDocStat",oHT,oData,"Child");
			try 
			{
					oData.Relations.Add("PC",
					oData.Tables["Parent"].Columns["AuthorDept"],
					oData.Tables["Child"].Columns["AuthorDept"]);
			}
			catch 
			{
				
			}
			if (oData.Tables.Count>0)
			{
				this.UltraWebGrid1.DataSource = oData.Tables["Parent"].DefaultView;
			}

		}

		private void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
			if (e.Row.Band.Key == "Parent")
			{
				e.Row.Expand(true);
			}
			switch(this.DocCode)
			{
				case DocType.ROS:
					if (e.Row.Band.Key == "Child")
					{
						//e.Row.Cells.FromKey("AuthorName").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						e.Row.Cells.FromKey("AuthorName").TargetURL = String.Format("../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode={0}&StartDate={1}&EndDate={2}&AuthorDept={3}",
																					e.Row.Cells.FromKey("AuthorCode").Text,
																					this.StartDate.ToShortDateString(),
																					this.EndDate.ToShortDateString(),
                                                                                    e.Row.ParentRow.Cells.FromKey("AuthorDept").Text);
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							//e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
                            e.Row.Cells.FromKey("ToDoCount").TargetURL = String.Format("../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode={0}&AuditResult=0&StartDate={1}&EndDate={2}&AuthorDept={3}",
																					e.Row.Cells.FromKey("AuthorCode").Text,
																					this.StartDate.ToShortDateString(),
																					this.EndDate.ToShortDateString(),
                                                                                    e.Row.ParentRow.Cells.FromKey("AuthorDept").Text); ;
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString()+"&AuthorDept="+e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
                            e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=-1" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
                            e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=-1" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
                            e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=1" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
                            e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=1" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
						}
					}
					else
					{
						e.Row.Cells.FromKey("AuthorDeptName").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/ROSBrowser.aspx?DocCode=1&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					break;
				case DocType.MRP:
					if (e.Row.Band.Key == "Child")
					{
						e.Row.Cells.FromKey("AuthorName").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();;
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					else
					{
						e.Row.Cells.FromKey("AuthorDeptName").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();;
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/MRPBrowser.aspx?DocCode=2&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					break;
				case DocType.PO:
					if (e.Row.Band.Key == "Child")
					{
						e.Row.Cells.FromKey("AuthorName").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					else
					{
						e.Row.Cells.FromKey("AuthorDeptName").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/POBrowser.aspx?DocCode=3&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					break;
				case DocType.DRW:
					if (e.Row.Band.Key == "Child")
					{
                        e.Row.Cells.FromKey("AuthorName").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
                            e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=0" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
                            e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=0" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
                            e.Row.Cells.FromKey("NoCount").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=-1" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
                            e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=-1" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
                            e.Row.Cells.FromKey("YesCount").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=1" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
                            e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorCode=" + e.Row.Cells.FromKey("AuthorCode").Text + "&AuditResult=1" + "&StartDate=" + this.StartDate.ToShortDateString() + "&EndDate=" + this.EndDate.ToShortDateString() + "&AuthorDept=" + e.Row.ParentRow.Cells.FromKey("AuthorDept").Text;
						}
					}
					else
					{
						e.Row.Cells.FromKey("AuthorDeptName").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Storage/DRWBrowser.aspx?DocCode=4&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					break;
				case DocType.BOR:
					if (e.Row.Band.Key == "Child")
					{
						e.Row.Cells.FromKey("AuthorName").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					else
					{
						e.Row.Cells.FromKey("AuthorDeptName").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/PBORBrowser.aspx?DocCode=6&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					break;
				case DocType.RTV:
					if (e.Row.Band.Key == "Child")
					{
						e.Row.Cells.FromKey("AuthorName").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					else
					{
						e.Row.Cells.FromKey("AuthorDeptName").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Purchase/PRTVBrowser.aspx?DocCode=7&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					break;
				case DocType.WTOW:
					if (e.Row.Band.Key == "Child")
					{
						e.Row.Cells.FromKey("AuthorName").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					else
					{
						e.Row.Cells.FromKey("AuthorDeptName").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Storage/WTOWBrowser.aspx?DocCode=16&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					break;
				case DocType.WINW:
					if (e.Row.Band.Key == "Child")
					{
						e.Row.Cells.FromKey("AuthorName").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorCode="+e.Row.Cells.FromKey("AuthorCode").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					else
					{
						e.Row.Cells.FromKey("AuthorDeptName").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						if (e.Row.Cells.FromKey("ToDoCount").Text != "0")
						{
							e.Row.Cells.FromKey("ToDoCount").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("ToDoSubTotal").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=0"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("NoCount").Text != "0")
						{
							e.Row.Cells.FromKey("NoCount").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("NoSubTotal").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=-1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
						if (e.Row.Cells.FromKey("YesCount").Text != "0")
						{
							e.Row.Cells.FromKey("YesCount").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
							e.Row.Cells.FromKey("YesSubTotal").TargetURL = "../Storage/WINWBrowser.aspx?DocCode=17&AuthorDept="+e.Row.Cells.FromKey("AuthorDept").Text+"&AuditResult=1"+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
						}
					}
					break;
				}
			
		}

		private void UltraWebGrid1_InitializeGroupByRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
			e.Row.Expand(true);
		}

		protected void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.UltraWebGrid1.DataBind();
			this.UltraWebGrid1.Bands[0].Key = "Parent";
			this.UltraWebGrid1.Bands[1].Key = "Child";
		}

		
	}
}
