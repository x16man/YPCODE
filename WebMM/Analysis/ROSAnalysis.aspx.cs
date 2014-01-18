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
using MZHCommon.Database;
//using MZHCommon.PageStyle;
using MZHMM.WebMM.Modules;
using Infragistics.WebUI.UltraWebGrid;
using Dundas.Charting.WebControl;
using NBoolean = NullableTypes.NullableBoolean;
using NByte = NullableTypes.NullableByte; 
using NInt16 = NullableTypes.NullableInt16;
using NInt32 = NullableTypes.NullableInt32;
using NInt64 = NullableTypes.NullableInt64;
using NSingle = NullableTypes.NullableSingle; 
using NDouble = NullableTypes.NullableDouble;
using NDecimal = NullableTypes.NullableDecimal;
using NString = NullableTypes.NullableString;
using NDateTime = NullableTypes.NullableDateTime;
namespace WebMM.Analysis
{
	/// <summary>
	/// WithDrawAnalysis 的摘要说明。
	/// </summary>
	public partial class ROSAnalysis : System.Web.UI.Page
	{
		#region 成员变量
		protected MZHCommon.Database.SQLServer MySQLServer = new SQLServer();
		private DataSet  WithDrawDS = new DataSet();
		private DataSet oData = new DataSet();
		#endregion

		#region 属性	
		/// <summary>
		/// 层次样式
		/// </summary>
		public string LayOut
		{
			get {return ViewState["LayOut"].ToString();}
			set {this.ViewState["LayOut"] = value;}
		}
		/// <summary>
		/// 排序串
		/// </summary>
		public string OrderString
		{
			get {return this.txtOrderString.Text;}
			set {this.txtOrderString.Text = value;}
		}
		/// <summary>
		/// 分组串
		/// </summary>
		public string GroupString
		{
			get {return this.txtGroupString.Text; }
			set {this.txtGroupString.Text = value;}
		}
        /// <summary>
        /// 开始日期 
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return DateTime.Parse(((Shmzh.Web.UI.Controls.ToolbarCalendar)this.WebPanel1.FindControl("WebDateChooser_StartDate")).Text);
                //return Convert.ToDateTime(((Infragistics.WebUI.WebSchedule.WebDateChooser)this.WebPanel1.FindControl("WebDataChooser_StartDate")).Value.ToString());
            }
            set
            {
                ((Shmzh.Web.UI.Controls.ToolbarCalendar)this.WebPanel1.FindControl("WebDateChooser_StartDate")).Text = value.ToString("yyyy-MM-dd");
                //((Infragistics.WebUI.WebSchedule.WebDateChooser)this.WebPanel1.FindControl("WebDateChooser_StartDate")).Value = value;
            }
        }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return DateTime.Parse(((Shmzh.Web.UI.Controls.ToolbarCalendar)this.WebPanel1.FindControl("WebDateChooser_EndDate")).Text);
                //return Convert.ToDateTime(((Infragistics.WebUI.WebSchedule.WebDateChooser)this.WebPanel1.FindControl("WebDateChooser_EndDate")).Value.ToString());
            }
            set
            {
                ((Shmzh.Web.UI.Controls.ToolbarCalendar)this.WebPanel1.FindControl("WebDateChooser_EndDate")).Text = value.ToString("yyyy-MM-dd");
                //((Infragistics.WebUI.WebSchedule.WebDateChooser)this.WebPanel1.FindControl("WebDateChooser_EndDate")).Value = value;
            }
        }
		/// <summary>
		/// 审批标记。
		/// </summary>
		public int Flag
		{
			get 
			{
				return Convert.ToInt32(((System.Web.UI.WebControls.DropDownList)this.WebPanel1.FindControl("ddlFlag")).SelectedValue);
			}
			set
			{
				System.Web.UI.WebControls.DropDownList myDropDownList;
				myDropDownList = (System.Web.UI.WebControls.DropDownList)this.WebPanel1.FindControl("ddlFlag");
				for(int i=0; i< myDropDownList.Items.Count; i++)
				{
					if (myDropDownList.Items[i].Value == value.ToString())
					{
						myDropDownList.Items[i].Selected = true;
					}
				}
			}
		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.LayOut = "2";
				this.StartDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
				this.EndDate = this.StartDate.AddMonths(1);
				if (!string.IsNullOrEmpty(this.Request["Flag"]))
				{
					this.Flag = Convert.ToInt32(this.Request["Flag"]);
				}
				this.OrderString="Classify,AuthorDeptName,ReqReason";
				this.UltraWebGrid1.DataBind();
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
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.UltraWebGrid1.GroupColumn += new Infragistics.WebUI.UltraWebGrid.GroupColumnEventHandler(this.UltraWebGrid1_GroupColumn);
			this.UltraWebGrid1.InitializeRow += new Infragistics.WebUI.UltraWebGrid.InitializeRowEventHandler(this.UltraWebGrid1_InitializeRow);
			this.UltraWebGrid1.UnGroupColumn += new Infragistics.WebUI.UltraWebGrid.UnGroupColumnEventHandler(this.UltraWebGrid1_UnGroupColumn);
			this.UltraWebGrid1.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UltraWebGrid1_InitializeLayout);
			this.UltraWebGrid1.InitializeGroupByRow += new Infragistics.WebUI.UltraWebGrid.InitializeGroupByRowEventHandler(this.UltraWebGrid1_InitializeGroupByRow);
			this.UltraWebGrid1.ColumnMove += new Infragistics.WebUI.UltraWebGrid.ColumnMoveEventHandler(this.UltraWebGrid1_ColumnMove);

		}
		#endregion

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.ExpandableDefault = Expandable.Yes;
			this.UltraWebGrid1.DisplayLayout.AllowColumnMovingDefault = AllowColumnMoving.OnServer;
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.OutlookGroupBy;
			this.UltraWebGrid1.DisplayLayout.GroupByBox.Hidden = false;
			this.UltraWebGrid1.Bands[0].GroupByColumnsHidden = GroupByColumnsHidden.No;
			this.UltraWebGrid1.DisplayLayout.Strings.GroupByBoxPrompt= "请将需要分级显示的字段拖放到这里。";
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.VerticalAlign = VerticalAlign.Middle;
			this.UltraWebGrid1.DisplayLayout.GroupByRowStyleDefault.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "[caption]:[value]          总金额 [sum:ItemMoney] 元         共有 [count] 条记录";
			this.UltraWebGrid1.DisplayLayout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Classify").HeaderText = "用途分类";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Classify").Width = new Unit("100 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Classify").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").HeaderText = "用途";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").Width = new Unit("100 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").HeaderText = "部门";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").Width = new Unit("100px");	
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").HeaderText = "金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Width = new Unit("120 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").CellStyle.HorizontalAlign = HorizontalAlign.Right;			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Format = "c";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Footer.Total = SummaryInfo.Sum;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Footer.Style.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("Classify").MergeCells = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").MergeCells = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("AuthorDeptName").MergeCells = true;
		}

		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			Hashtable oHT = new Hashtable();
			oHT.Add("@LayOut", this.LayOut);
			oHT.Add("@StartDate", this.StartDate);
			oHT.Add("@EndDate", this.EndDate);
			oHT.Add("@Flag", this.Flag);

			WithDrawDS = new DataSet();
			WithDrawDS = MySQLServer.ExecSPReturnDS("Analysis_GetROSGroup",oHT);
			this.WithDrawDS.Tables[0].DefaultView.Sort = OrderString;
			this.UltraWebGrid1.DataSource = this.WithDrawDS.Tables[0].DefaultView;

			oHT = new Hashtable();
			oHT.Add("@LayOut", LayOut);
			oHT.Add("@ReqReason", "");
			oHT.Add("@AuthorDeptName", "");
			oHT.Add("@StartDate",this.StartDate);
			oHT.Add("@EndDate",this.EndDate);
			oHT.Add("@Classify", "");
			oHT.Add("@Flag",this.Flag);
			oData =	new SQLServer().ExecSPReturnDS("Analysis_ROSGetGroupByLayOutAndDate",oHT); 
			this.Chart1.DataSource = oData.Tables[0];
			switch (this.LayOut )
			{
				case "1":
					this.Chart1.Series["Default"].ValueMemberX = "Classify";
					break;
				case "2":
					this.Chart1.Series["Default"].ValueMemberX = "Classify";
					break;
				case "3":
					this.Chart1.Series["Default"].ValueMemberX = "ReqReason";
					break;
				case "4":
					this.Chart1.Series["Default"].ValueMemberX = "ReqReason";
					break;
				case "5":
					this.Chart1.Series["Default"].ValueMemberX = "AuthorDeptName";
					break;
				case "6":
					this.Chart1.Series["Default"].ValueMemberX = "AuthorDeptName";
					break;
			}
			
			this.Chart1.Series["Default"].XValueType = ChartValueTypes.String;
			this.Chart1.Series["Default"].ValueMembersY = "ItemMoney";
			this.Chart1.Series["Default"].YValueType = ChartValueTypes.Double;
			this.Chart1.ImageType = ChartImageType.Png;
			this.Chart1.Legends["Default"].LegendStyle = LegendStyle.Column;
			this.Chart1.Legends["Default"].Docking = LegendDocking.Bottom;
			this.Chart1.Legends["Default"].Alignment = StringAlignment.Near;
			this.Chart1.Series["Default"].Type = SeriesChartType.Pie;
			this.Chart1.Titles[0].Href = ""; 
			this.Chart1.Series["Default"].Label = "#PERCENT";
			this.Chart1.Series["Default"].LegendText = "#VALX: #VAL{C} 元: #PERCENT ";
			this.Chart1.Series["Default"].ToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			this.Chart1.Series["Default"].LegendToolTip = "#VALX: #VAL{C} 元: #PERCENT";
			
		}

		private void UltraWebGrid1_ColumnMove(object sender, Infragistics.WebUI.UltraWebGrid.ColumnEventArgs e)
		{
			if (e.Column.BaseColumnName != "ItemMoney")
			{
				OrderString = "";
				for (int i= 0 ;i < this.UltraWebGrid1.Bands[0].Columns.Count;i++)
				{
					if (this.UltraWebGrid1.Bands[0].Columns[i].BaseColumnName != "ItemMoney")
					{
						OrderString += this.UltraWebGrid1.Bands[0].Columns[i].BaseColumnName+",";
					}
				}													   
				OrderString = OrderString.Substring(0,OrderString.Length -1);
				switch (OrderString)
				{
					case "Classify,ReqReason,AuthorDeptName":
						this.LayOut = "1";
						break;
					case "Classify,AuthorDeptName,ReqReason":
						this.LayOut = "2";
						break;
					case "ReqReason,Classify,AuthorDeptName":
						this.LayOut = "3";
						break;
					case "ReqReason,AuthorDeptName,Classify":
						this.LayOut = "4";
						break;
					case "AuthorDeptName,Classify,ReqReason":
						this.LayOut = "5";
						break;
					case "AuthorDeptName,ReqReason,Classify":
						this.LayOut = "6";
						break;
				}
				this.UltraWebGrid1.Bands[0].SortedColumns.Clear();
				this.UltraWebGrid1.DataBind();
			}
		}

		private void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
			if (e.Row.Cells.FromKey("ItemMoney") != null)
			{
				e.Row.Cells.FromKey("ItemMoney").TargetURL	="@[_blank]ROSDetails.aspx?"
															+"ClassifyName="+Server.UrlEncode(e.Row.Cells.FromKey("Classify").Value.ToString())
															+"&ReqReason="+Server.UrlEncode(e.Row.Cells.FromKey("ReqReason").Value.ToString())
															+"&AuthorDeptName="+Server.UrlEncode(e.Row.Cells.FromKey("AuthorDeptName").Value.ToString())
															+"&StartDate="+this.StartDate.ToShortDateString()
															+"&EndDate="+this.EndDate.ToShortDateString()
															+"&Flag="+this.Flag.ToString();
			}
		}

		private void UltraWebGrid1_GroupColumn(object sender, Infragistics.WebUI.UltraWebGrid.ColumnEventArgs e)
		{
			if (e.Column.BaseColumnName != "ItemMoney")
			{
				if(this.GroupString == "")	
				{
					this.GroupString += e.Column.BaseColumnName;
				}
				else
				{
					this.GroupString += ","+e.Column.BaseColumnName;
				}
				string[] GroupColumn;
				GroupColumn = this.GroupString.Split(",".ToCharArray());
				int index;
				for (int i=GroupColumn.Length -1; i>=0; i--)
				{
					index = this.OrderString.IndexOf(GroupColumn[i],0);
					if (index >= 0)
					{
						this.OrderString = this.OrderString.Replace(GroupColumn[i],"");
						this.OrderString = GroupColumn[i]+","+this.OrderString;
					}
				}
				while (this.OrderString.IndexOf(",,",0,this.OrderString.Length) > 0)
				{
					this.OrderString = this.OrderString.Replace(",,",",");
				}
				
				if (this.OrderString.Substring(this.OrderString.Length-1,1)==",")
				{
					this.OrderString = this.OrderString.Substring(0,this.OrderString.Length - 1);
				}

				switch (OrderString)
				{
					case "Classify,ReqReason,AuthorDeptName":
						this.LayOut = "1";
						break;
					case "Classify,AuthorDeptName,ReqReason":
						this.LayOut = "2";
						break;
					case "ReqReason,Classify,AuthorDeptName":
						this.LayOut = "3";
						break;
					case "ReqReason,AuthorDeptName,Classify":
						this.LayOut = "4";
						break;
					case "AuthorDeptName,Classify,ReqReason":
						this.LayOut = "5";
						break;
					case "AuthorDeptName,ReqReason,Classify":
						this.LayOut = "6";
						break;
				}
				this.UltraWebGrid1.Bands[0].Columns.Clear();
				this.UltraWebGrid1.DataBind();
				for (int i=0; i< GroupColumn.Length; i++)
				{
					this.UltraWebGrid1.Bands[0].Columns.FromKey(GroupColumn[i]).IsGroupByColumn = true;
				}
				//由于分组后，系统自动会将分组字段排序，这样原来的排序，就会被打乱。所以，进行手工再排序。
				//				foreach (UltraGridColumn ugc in this.UltraWebGrid1.Bands[0].SortedColumns)//除掉非分组字段。
				//				{
				//					if (!ugc.IsGroupByColumn)
				//					{
				//						this.UltraWebGrid1.Bands[0].SortedColumns.Remove(ugc,true);
				//					}
				//				}
				for (int i = this.UltraWebGrid1.Bands[0].SortedColumns.Count -1; i>=0; i--)
				{
					if (!this.UltraWebGrid1.Bands[0].SortedColumns[i].IsGroupByColumn)
					{
						this.UltraWebGrid1.Bands[0].SortedColumns.RemoveAt(i);
					}
				}
				string[] OrderColumn;
				OrderColumn = this.OrderString.Split(",".ToCharArray());
				for (int i=0; i< OrderColumn.Length; i++)
				{
					if (!this.UltraWebGrid1.Bands[0].SortedColumns.Exists(OrderColumn[i]))
					{
						this.UltraWebGrid1.Bands[0].Columns.FromKey(OrderColumn[i]).SortIndicator = SortIndicator.Ascending;
						this.UltraWebGrid1.Bands[0].SortedColumns.Add(this.UltraWebGrid1.Bands[0].Columns.FromKey(OrderColumn[i]),true);
					}
				}
			}
		}

		private void UltraWebGrid1_InitializeGroupByRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
			e.Row.Expand(true);
		}

		private void UltraWebGrid1_UnGroupColumn(object sender, Infragistics.WebUI.UltraWebGrid.ColumnEventArgs e)
		{
			this.GroupString = this.GroupString.Replace(e.Column.BaseColumnName,"");//从GroupString中取出。
			this.GroupString = this.GroupString.Replace(",,",",");
			if (this.GroupString.Length > 0 && this.GroupString.Substring(this.GroupString.Length -1,1) ==",")
			{
				GroupString = GroupString.Substring(0,GroupString.Length -1);
			}
			if (this.GroupString.Length > 0 && this.GroupString.Substring(0,1) ==",")
			{
				GroupString = GroupString.Substring(1,GroupString.Length -1);
			}
			string[] OrderColumn;
			string NewOrderString = "";
			OrderColumn = this.OrderString.Split(",".ToCharArray());
			//取消Group后需要重新组织OrderString。
			for (int i=0; i< OrderColumn.Length; i++)	 //首先处理GroupColumn。
			{
				if (this.UltraWebGrid1.Bands[0].Columns.FromKey(OrderColumn[i]).IsGroupByColumn )
				{
					if (NewOrderString.Length == 0)
						NewOrderString = OrderColumn[i];
					else
						NewOrderString +=","+OrderColumn[i];
				}
			}
			if (NewOrderString.Length ==0)//没有GroupColumn。
			{
				//OrderString 不变 。
			}
			else
			{
				int index = NewOrderString.IndexOf(",",0);
				if (index > 0)//有两个GroupColumn。
				{
					NewOrderString += ","+e.Column.BaseColumnName;
				}
				else//还有一个是GroupColumn。
				{
					NewOrderString = NewOrderString+","+OrderString.Replace(NewOrderString,"");
					while (NewOrderString.IndexOf(",,",0) >0 )
					{
						NewOrderString = NewOrderString.Replace(",,",",");
					}
					if (NewOrderString.Substring(NewOrderString.Length -1,1) ==",")
					{
						NewOrderString = NewOrderString.Substring(0,NewOrderString.Length -1);
					}
				}
				OrderString = NewOrderString;
			}
			OrderColumn = OrderString.Split(",".ToCharArray());
			switch (OrderString)
			{
				case "Classify,ReqReason,AuthorDeptName":
					this.LayOut = "1";
					break;
				case "Classify,AuthorDeptName,ReqReason":
					this.LayOut = "2";
					break;
				case "ReqReason,Classify,AuthorDeptName":
					this.LayOut = "3";
					break;
				case "ReqReason,AuthorDeptName,Classify":
					this.LayOut = "4";
					break;
				case "AuthorDeptName,Classify,ReqReason":
					this.LayOut = "5";
					break;
				case "AuthorDeptName,ReqReason,Classify":
					this.LayOut = "6";
					break;
			}
			this.UltraWebGrid1.Bands[0].Columns.Clear();
			this.UltraWebGrid1.DataBind();
			string[] GroupColumn;
			if (this.GroupString.Length > 0)
			{
				GroupColumn = this.GroupString.Split(",".ToCharArray());
				for (int i=0; i<GroupColumn.Length; i++)
				{
					this.UltraWebGrid1.Bands[0].Columns.FromKey(GroupColumn[i]).IsGroupByColumn = true;
				}
			}
			//			foreach (UltraGridColumn ugc in this.UltraWebGrid1.Bands[0].SortedColumns)//除掉非分组字段。
			//			{
			//				if (!ugc.IsGroupByColumn)
			//				{
			//					this.UltraWebGrid1.Bands[0].SortedColumns.Remove(ugc,true);
			//				}
			//			}
			for (int i = this.UltraWebGrid1.Bands[0].SortedColumns.Count -1; i>=0; i--)
			{
				if (!this.UltraWebGrid1.Bands[0].SortedColumns[i].IsGroupByColumn)
				{
					this.UltraWebGrid1.Bands[0].SortedColumns.RemoveAt(i);
				}
			}
			for (int i=0; i< OrderColumn.Length; i++)
			{
				if (!this.UltraWebGrid1.Bands[0].SortedColumns.Exists(OrderColumn[i]))
				{
					this.UltraWebGrid1.Bands[0].Columns.FromKey(OrderColumn[i]).SortIndicator = SortIndicator.Ascending;
					this.UltraWebGrid1.Bands[0].SortedColumns.Add(this.UltraWebGrid1.Bands[0].Columns.FromKey(OrderColumn[i]),true);
				}
			}
		}

		protected void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.UltraWebGrid1.DataBind();	
		}

		protected void btnHREF_Click(object sender, System.EventArgs e)
		{
			this.GroupString="";
			this.UltraWebGrid1.Bands[0].Columns.Clear();
			this.UltraWebGrid1.Bands[0].SortedColumns.Clear();
			switch(this.OrderString)
			{
				case "Classify,ReqReason,AuthorDeptName":
					this.LayOut = "1";
					//this.Chart1.Series["Default"].ValueMemberX = "ABC";
					break;
				case "Classify,AuthorDeptName,ReqReason":
					this.LayOut = "2";
					//this.Chart1.Series["Default"].ValueMemberX = "ABC";
					break;
				case "ReqReason,Classify,AuthorDeptName":
					this.LayOut = "3";
					//this.Chart1.Series["Default"].ValueMemberX = "StoName";
					break;
				case "ReqReason,AuthorDeptName,Classify":
					this.LayOut = "4";
					//this.Chart1.Series["Default"].ValueMemberX = "StoName";
					break;
				case "AuthorDeptName,Classify,ReqReason":
					this.LayOut = "5";
					//this.Chart1.Series["Default"].ValueMemberX = "CatName";
					break;
				case "AuthorDeptName,ReqReason,Classify":
					this.LayOut = "6";
					//this.Chart1.Series["Default"].ValueMemberX = "CatName";
					break;
			}
			this.UltraWebGrid1.DataBind();
		}
	}
}
