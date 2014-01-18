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
using Infragistics.WebUI.UltraWebGrid;
using Dundas.Charting.WebControl;
using Shmzh.Components.SystemComponent;

namespace MZHMM.WebMM.Analysis
{
	/// <summary>
	/// StockAnalysis 的摘要说明。
	/// </summary>
	public partial class StockAnalysis : System.Web.UI.Page
	{
		protected MZHCommon.Database.SQLServer MySQLServer = new SQLServer();
		private DataSet  StockDS = new DataSet();
		protected DataSet oData;
		protected Hashtable oHT;

        private string strABC = "";
        private string strStockName = "";
        private string strCatName = "";


        /// <summary>
        /// 当前用户。
        /// </summary>
        public User CurrentUser
        {
            get { return Session["User"] as User; }
        }


		#region 属性		
		public string LayOut
		{
			get {return ViewState["LayOut"].ToString();}
			set {this.ViewState["LayOut"] = value;}
		}
		public string OrderString
		{
			get {return this.txtOrderString.Text;}
			set {this.txtOrderString.Text = value;}
		}
		public string GroupString
		{
			get {return this.txtGroupString.Text; }
			set {this.txtGroupString.Text = value;}
		}
		public string ABC
		{
			get 
			{
				if (this.Request["ABC"] != null && this.Request["ABC"] != "")
				{
					return this.Request["ABC"];
				}
				else
				{
					return "";
				}
			}
		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.LayOut = "1";
				this.OrderString="ABC,StoName,CatName";
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
			this.UltraWebGrid1.SortColumn += new Infragistics.WebUI.UltraWebGrid.SortColumnEventHandler(this.UltraWebGrid1_SortColumn);
			this.UltraWebGrid1.InitializeGroupByRow += new Infragistics.WebUI.UltraWebGrid.InitializeGroupByRowEventHandler(this.UltraWebGrid1_InitializeGroupByRow);
			this.UltraWebGrid1.ColumnMove += new Infragistics.WebUI.UltraWebGrid.ColumnMoveEventHandler(this.UltraWebGrid1_ColumnMove);

		}
		#endregion
		protected void UltraWebGrid1_DataBinding(object sender, System.EventArgs e)
		{
			Hashtable oHT = new Hashtable();
			oHT.Add("@LayOut", this.LayOut);
			oHT.Add("@ABC", this.ABC);
			StockDS = new DataSet();
            if(CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.StockAnalysisZero))
			    StockDS = MySQLServer.ExecSPReturnDS("Sto_StockGetGroupAnalysis",oHT);
            else
                StockDS = MySQLServer.ExecSPReturnDS("Sto_StockGetGroupAnalysisZero",oHT);
			this.StockDS.Tables[0].DefaultView.Sort = OrderString;
			this.UltraWebGrid1.DataSource = this.StockDS.Tables[0].DefaultView;
			//this.Response.Write(this.OrderString);
			//OrderString = "";
			oHT = new Hashtable();

			oHT.Add("@LayOut", LayOut);
			oHT.Add("@ABC",this.ABC);
			oHT.Add("@StoName","");
			oHT.Add("@CatName","");
            if (CurrentUser.HasRight(MZHMM.WebMM.Common.SysRight.StockAnalysisZero))
			    oData =	new SQLServer().ExecSPReturnDS("Sto_StockGetGroupByLayOut",oHT); 
            else
                oData = new SQLServer().ExecSPReturnDS("Sto_StockGetGroupByLayOutZero", oHT); 
			this.Chart1.DataSource = oData.Tables[0];
			switch (this.LayOut )
			{
				case "1":
					if (this.ABC.Length == 0)
						this.Chart1.Series["Default"].ValueMemberX = "ABC";
					else
						this.Chart1.Series["Default"].ValueMemberX = "StoName";
					break;
				case "2":
					this.Chart1.Series["Default"].ValueMemberX = "ABC";
					break;
				case "3":
					this.Chart1.Series["Default"].ValueMemberX = "StoName";
					break;
				case "4":
					this.Chart1.Series["Default"].ValueMemberX = "StoName";
					break;
				case "5":
					this.Chart1.Series["Default"].ValueMemberX = "CatName";
					break;
				case "6":
					this.Chart1.Series["Default"].ValueMemberX = "CatName";
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

		private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UltraWebGrid1.DisplayLayout.ExpandableDefault = Expandable.Yes;
			this.UltraWebGrid1.DisplayLayout.AllowColumnMovingDefault = AllowColumnMoving.OnServer;
			//this.UltraWebGrid1.DisplayLayout.FrameStyle.Width = new Unit("100%");
			this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.OutlookGroupBy;
			this.UltraWebGrid1.DisplayLayout.GroupByBox.Hidden = false;
			this.UltraWebGrid1.Bands[0].GroupByColumnsHidden = GroupByColumnsHidden.No;
			this.UltraWebGrid1.DisplayLayout.Strings.GroupByBoxPrompt= "请将需要分级显示的字段拖放到这里。";
			//this.UltraWebGrid1.DisplayLayout.GroupByRowStyleDefault.Width = new Unit("100%");			
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.VerticalAlign = VerticalAlign.Middle;
			this.UltraWebGrid1.DisplayLayout.GroupByRowStyleDefault.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.DisplayLayout.GroupByRowDescriptionMaskDefault = "[caption]:[value]          总金额 [sum:ItemMoney] 元         共有 [count] 条记录";
			this.UltraWebGrid1.DisplayLayout.ColFootersVisibleDefault = ShowMarginInfo.Yes;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ABC").HeaderText = "ABC";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ABC").Width = new Unit("80 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ABC").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("StoName").HeaderText = "仓库名称";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("StoName").Width = new Unit("100 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("StoName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("CatName").HeaderText = "物料分类";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("CatName").Width = new Unit("150");	
			this.UltraWebGrid1.Bands[0].Columns.FromKey("CatName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").HeaderText = "金额";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Width = new Unit("120 px");
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").CellStyle.HorizontalAlign = HorizontalAlign.Right;			
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Format = "c";
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Footer.Total = SummaryInfo.Sum;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ItemMoney").Footer.Style.HorizontalAlign = HorizontalAlign.Right;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("ABC").MergeCells = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("StoName").MergeCells = true;
			this.UltraWebGrid1.Bands[0].Columns.FromKey("CatName").MergeCells = true;
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
					case "ABC,StoName,CatName":
						this.LayOut = "1";
						break;
					case "ABC,CatName,StoName":
						this.LayOut = "2";
						break;
					case "StoName,ABC,CatName":
						this.LayOut = "3";
						break;
					case "StoName,CatName,ABC":
						this.LayOut = "4";
						break;
					case "CatName,ABC,StoName":
						this.LayOut = "5";
						break;
					case "CatName,StoName,ABC":
						this.LayOut = "6";
						break;
				}
				this.UltraWebGrid1.Bands[0].SortedColumns.Clear();
				this.UltraWebGrid1.DataBind();
			}
		}

		private void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
            if (e.Row.Cells.FromKey("ABC").Value == null)
                strABC = "";
            else
                strABC = e.Row.Cells.FromKey("ABC").Value.ToString();

            if (e.Row.Cells.FromKey("StoName").Value == null)
                strStockName = "";
            else
                strStockName = e.Row.Cells.FromKey("StoName").Value.ToString();

            if (e.Row.Cells.FromKey("CatName").Value == null)
                strCatName = "";
            else
                strCatName = e.Row.Cells.FromKey("CatName").Value.ToString();

            e.Row.Cells.FromKey("ItemMoney").TargetURL = "@[_blank]StockDetail.aspx?ABC=" + strABC + "&StoName=" + Server.UrlEncode(strStockName) + "&CatName=" + Server.UrlEncode(strCatName);
			//e.Row.Cells.FromKey("ItemMoney").TargetURL="@[_blank]StockDetail.aspx?ABC="+e.Row.Cells.FromKey("ABC").Value.ToString()+"&StoName="+Server.UrlEncode(e.Row.Cells.FromKey("StoName").Value.ToString())+"&CatName="+Server.UrlEncode(e.Row.Cells.FromKey("CatName").Value.ToString());
		}

		protected void btnHref_Click(object sender, System.EventArgs e)
		{
			this.GroupString="";
			this.UltraWebGrid1.Bands[0].Columns.Clear();
			this.UltraWebGrid1.Bands[0].SortedColumns.Clear();
			switch(this.OrderString)
			{
				case "ABC,StoName,CatName":
					this.LayOut = "1";
					this.Chart1.Series["Default"].ValueMemberX = "ABC";
					break;
				case "ABC,CatName,StoName":
					this.LayOut = "2";
					this.Chart1.Series["Default"].ValueMemberX = "ABC";
					break;
				case "StoName,ABC,CatName":
					this.LayOut = "3";
					this.Chart1.Series["Default"].ValueMemberX = "StoName";
					break;
				case "StoName,CatName,ABC":
					this.LayOut = "4";
					this.Chart1.Series["Default"].ValueMemberX = "StoName";
					break;
				case "CatName,ABC,StoName":
					this.LayOut = "5";
					this.Chart1.Series["Default"].ValueMemberX = "CatName";
					break;
				case "CatName,StoName,ABC":
					this.LayOut = "6";
					this.Chart1.Series["Default"].ValueMemberX = "CatName";
					break;
			}
			this.UltraWebGrid1.DataBind();
		}
		/// <summary>
		/// 字段分组事件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// 由于库存的显示是有层次的，所以和字段排序的关系非常密切。
		/// 在缺省情况下，向GroupBox区域拖放字段，系统会自动对该字段进行单字段排序的。
		/// 由于库存的显示是要三个字段进行同时排序的。所以，默认情况，会打乱原来正常的顺序。
		/// 从帮助中得知在   SortColumn 事件中， SortColumnEventArgs 对象有个Cancel属性。
		/// 一旦，将其设为True，好象什么缺省的排序行为会被取消。试过了，好象没起作用。作罢。
		/// （有时间再试试这个属性在什么情况下起作用）。于是，将精力再次放到GroupRow的事件上，
		/// 只有在设定了分组字段后，再人为的按照OrderColumn字段的顺序，重新排一边。
		/// 问题OK了。都快哭了。昨晚我可是折腾到2点啊。真是五味杂陈啊。都快抽光一盒烟了，
		/// 就差以头撞墙了。顺便再补充一句，CustomSort 是要向Band的SortedColumns中增加字段，
		/// 而且，字段必须是事先指定好   SortIndicator 的，就是ASC，DESC啊。我就是没有设这个
		/// 属性，所以绕了一个弯路。气人啊，Infragistics的本地帮助＆Sample，都太草草了。
		/// 谁让家里没装宽带啊。
		/// </remarks>
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
					case "ABC,StoName,CatName":
						this.LayOut = "1";
						break;
					case "ABC,CatName,StoName":
						this.LayOut = "2";
						break;
					case "StoName,ABC,CatName":
						this.LayOut = "3";
						break;
					case "StoName,CatName,ABC":
						this.LayOut = "4";
						break;
					case "CatName,ABC,StoName":
						this.LayOut = "5";
						break;
					case "CatName,StoName,ABC":
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
		private void UltraWebGrid1_SortColumn(object sender, Infragistics.WebUI.UltraWebGrid.SortColumnEventArgs e)
		{
			//e.Cancel = true;
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
				case "ABC,StoName,CatName":
					this.LayOut = "1";
					break;
				case "ABC,CatName,StoName":
					this.LayOut = "2";
					break;
				case "StoName,ABC,CatName":
					this.LayOut = "3";
					break;
				case "StoName,CatName,ABC":
					this.LayOut = "4";
					break;
				case "CatName,ABC,StoName":
					this.LayOut = "5";
					break;
				case "CatName,StoName,ABC":
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


	
	}
}
