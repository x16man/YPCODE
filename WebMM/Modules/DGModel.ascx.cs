namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	//using MZHCommon.PageStyle;
    using log4net;

	/// <summary>
	///		DataGrid模板基类。
	///		本模板实现的功能如下：
	///		1.DataGrid的单选，多选。
	///		2.DataGrid通用样式绑定(样式在web.config文件中指定)。
	///		3.DataGrid的翻页功能。
	///		4.DataGrid一些常用属性设定(包括是否分页，分页行数，是否显示页眉、页导航)。
	///		
	///		运行本模板所需的其它文件：
	///		CommonStyle.cs
	///		DataGridSelect.ascx
	///		DataGrid.js
	///		
	///		如何应用本模板：
	///		1.创建一个用户控件继承DGModel基类。
	///		2.删除PageLoad和窗体生成代码。
	///		3.重载InitDataGridColumns()如下例：
	///		protected override void InitDataGridColumns()
	///		{
	///			switch(ColumnsScheme)
	///			{
	///				case "custom":
	///					break;
	///				default:
	///				{
	///					//绑定列
	///					BoundColumn dgCol=new BoundColumn();
	///					dgCol.HeaderStyle.Width=new Unit(50);
	///					dgCol.Visible=false;
	///					dgCol.HeaderText = "PKID";
	///					dgCol.DataField = "PKID";
	///					DataGrid1.Columns.Add(dgCol);
	///					
	///					TemplateColumn dgCol2=new TemplateColumn();
	///					dgCol2.HeaderStyle.Width=new Unit(80);
	///					dgCol2.HeaderText = "标题";
	///					//模板列，模板在TitleTemplate.ascx文件中
	///					dgCol2.ItemTemplate=this.LoadTemplate("TitleTemplate.ascx");
	///					//排序
	///					dgCol2.SortExpression="Title";
	///					//dgCol2.DataFormatString="{0:d}";
	///					DataGrid1.Columns.Add(dgCol2);
	///				}
	///			}
	///		}
	///		4.如果设置单选或多选，可重载ItemDataBound，如下例：
	///		protected override void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
	///		{
	///			//双击某一行，弹出相应页面
	///			e.Item.Attributes.Add("ondblclick","window.open('myPage.aspx?PKID=" + e.Item.Cells[0].Text +"')");
	///		}
	///		5.可重载的其它函数DataBind()：在模板中绑定数据源，这样就不用每次传DataSource进去。
	/// </summary>
	public partial class DGModel : System.Web.UI.UserControl
	{
        public Shmzh.Web.UI.Controls.MzhDataGrid DataGrid1 = new Shmzh.Web.UI.Controls.MzhDataGrid();

        private static readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        

		public string ColumnsScheme="Default";

		public enum SelectType{None,SingleSelect,MultiSelect};

		//protected System.Web.UI.Control uc;

		private System.Web.UI.HtmlControls.HtmlInputHidden TmpSortExpression=new HtmlInputHidden();

		//static private string TmpSortExpression;

		protected DataView dataView1;

		//public CommonStyle.StyleScheme DgStyleScheme;

		public string SelectedID
		{
			get
			{
				return DataGrid1.SelectedID;
			}
            //set
            //{
            //    ((DataGridSelect)uc).SelectedID=value;
            //}			
		}

		public string SelectedArray
		{
			get
			{
				return DataGrid1.SelectedArray;
			}
            //set
            //{
            //    ((DataGridSelect)uc).SelectedArray=value;
            //}
			
		}

		public string SelectedStream
		{
			get
			{
				return this.DataGrid1.SelectedStream;
			}
            //set
            //{
            //    ((DataGridSelect)uc).SelectedStream=value;
            //}
			
		}

		protected SelectType _selectedType=SelectType.None;
		public SelectType SelectedType
		{
			get
			{
				return _selectedType;
			}
			set
			{
				_selectedType=value;
				if(_selectedType!=SelectType.None)
				{
					//uc = this.LoadControl("DataGridSelect.ascx");
                   // this.DataGrid1.SelectType = _selectedType;
                    if (value == SelectType.SingleSelect)
                    {
                        this.DataGrid1.SelectType = Shmzh.Web.UI.Controls.MzhDataGrid.SelectMode.SingleSelect;

                    }
                    else if (value == SelectType.MultiSelect)
                    {
                        this.DataGrid1.SelectType = Shmzh.Web.UI.Controls.MzhDataGrid.SelectMode.MultiSelect;
                    }
				}
			}
		}

		protected object _dataSource;
		public object DataSource
		{
			get
			{
				return _dataSource;
			}
			set
			{
				_dataSource=value;
				if(_dataSource.GetType().BaseType.ToString()=="System.Data.DataSet")
				{
					dataView1 = new DataView(((DataSet)_dataSource).Tables[0]);
				}
				else
				{
					dataView1 = new DataView((DataTable)_dataSource);
				}
			}
		}

		protected int _pageSize;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize=value;
			}
		}

		protected bool _allowSorting=true;	
		public bool AllowSorting
		{
			get
			{
				return _allowSorting;
			}
			set
			{
				_allowSorting=value;
			}
		}

		protected bool _allowPaging=true;	
		public bool AllowPaging
		{
			get
			{
				return _allowPaging;
			}
			set
			{
				_allowPaging=value;
			}
		}

		protected bool _showPager=true;
	
		public bool ShowPager
		{
			get
			{
				return _showPager;
			}
			set
			{
				_showPager=value;
			}
		}

		protected bool _showHeader=true;
		public bool ShowHeader
		{
			get
			{
				return _showHeader;
			}
			set
			{
				_showHeader=value;
			}
		}

		protected bool _showFooter=false;
		public bool ShowFooter
		{
			get
			{
				return _showFooter;
			}
			set
			{
				_showFooter=value;
			}
		}

		virtual protected void Page_Load(object sender, System.EventArgs e)
		{
			this.Controls.Add(TmpSortExpression);
			this.Controls.Add(DataGrid1);
			if(_selectedType!=SelectType.None)
			{
				DataGrid1.Attributes.Add("name","MzhMultiSelectDataGrid");
				if(_selectedType==SelectType.MultiSelect)
				{
					//((DataGridSelect)uc).IsMultiSelect=true;
                    this.DataGrid1.SelectType = Shmzh.Web.UI.Controls.MzhDataGrid.SelectMode.MultiSelect;
				}
				else
				{
                    //((DataGridSelect)uc).IsMultiSelect=false;
                     this.DataGrid1.SelectType = Shmzh.Web.UI.Controls.MzhDataGrid.SelectMode.SingleSelect;
				}
				//this.Controls.Add(uc);
			}
			if(DataGrid1.Columns.Count<=0)
			{
				InitDataGridColumns();
			}
            //设置样式
            DataGrid1.HignLightCSS = "m-grid-row-over";
            DataGrid1.CssClass  = "datagrid";
            //DataGrid1.CSSClassForPagerButtonJump  = "m-grid-pager-button-jump";
            //DataGrid1.BorderColor = Color.FromKnownColor("#0099CC");
            DataGrid1.SelectedCSS = "m-grid-row-selected";
            DataGrid1.CellPadding = 3;
            DataGrid1.CellSpacing = 1;
            DataGrid1.BorderWidth = new Unit(1, UnitType.Pixel);
           // DataGrid1.hi
            //DataGrid1.CSSClassForPagerInputPage = "m-grid-pager-input-page";
           // DataGrid1.selectedc = Color.Blue;
            DataGrid1.Width = new Unit(100, UnitType.Percentage);

			DataGrid1.AutoGenerateColumns=false;
			DataGrid1.AllowPaging=_allowPaging;
			DataGrid1.PagerStyle.Visible=_showPager;
			DataGrid1.ShowHeader=_showHeader;
			DataGrid1.ShowFooter=_showFooter;
			//DataGrid1.ShowFooter=true;
            DataGrid1.MultiPageShowMode = Shmzh.Web.UI.Controls.MzhDataGrid.PagerShowMode.DropListMode;
          
			DataGrid1.AllowSorting=_allowSorting;
			DataGrid1.Width=new Unit("100%");
            if (_pageSize > 0)
            {
                DataGrid1.PageSize = _pageSize;

            }
            else
            {

                DataGrid1.PageSize = 100;
            }
				
			DataBind();
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
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
		}
		#endregion
		
		virtual protected void InitDataGridColumns()
		{
		}
		
		virtual protected void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{}

		virtual new public void DataBind()
		{
			dataView1.Sort=TmpSortExpression.Value;
			DataGrid1.DataSource=dataView1;
			try
			{
				DataGrid1.DataBind();
			}
			catch(Exception e)
			{
                Logger.Info(e.Message);
                //if(e.Source=="System.Web") 
                //{
                //    DataGrid1.CurrentPageIndex--;
                //    DataGrid1.DataBind();
                //}				
			}
		}

		protected void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			DataBind();
		}

		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(TmpSortExpression.Value==e.SortExpression)
			{				
				TmpSortExpression.Value = e.SortExpression+" desc";
			}
			else
			{				
				TmpSortExpression.Value = e.SortExpression;
			}			
			DataBind();
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			ItemDataBound(sender,e);
		}

		virtual protected void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
		}
	}
}
