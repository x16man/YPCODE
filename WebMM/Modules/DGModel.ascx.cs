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
	///		DataGridģ����ࡣ
	///		��ģ��ʵ�ֵĹ������£�
	///		1.DataGrid�ĵ�ѡ����ѡ��
	///		2.DataGridͨ����ʽ��(��ʽ��web.config�ļ���ָ��)��
	///		3.DataGrid�ķ�ҳ���ܡ�
	///		4.DataGridһЩ���������趨(�����Ƿ��ҳ����ҳ�������Ƿ���ʾҳü��ҳ����)��
	///		
	///		���б�ģ������������ļ���
	///		CommonStyle.cs
	///		DataGridSelect.ascx
	///		DataGrid.js
	///		
	///		���Ӧ�ñ�ģ�壺
	///		1.����һ���û��ؼ��̳�DGModel���ࡣ
	///		2.ɾ��PageLoad�ʹ������ɴ��롣
	///		3.����InitDataGridColumns()��������
	///		protected override void InitDataGridColumns()
	///		{
	///			switch(ColumnsScheme)
	///			{
	///				case "custom":
	///					break;
	///				default:
	///				{
	///					//����
	///					BoundColumn dgCol=new BoundColumn();
	///					dgCol.HeaderStyle.Width=new Unit(50);
	///					dgCol.Visible=false;
	///					dgCol.HeaderText = "PKID";
	///					dgCol.DataField = "PKID";
	///					DataGrid1.Columns.Add(dgCol);
	///					
	///					TemplateColumn dgCol2=new TemplateColumn();
	///					dgCol2.HeaderStyle.Width=new Unit(80);
	///					dgCol2.HeaderText = "����";
	///					//ģ���У�ģ����TitleTemplate.ascx�ļ���
	///					dgCol2.ItemTemplate=this.LoadTemplate("TitleTemplate.ascx");
	///					//����
	///					dgCol2.SortExpression="Title";
	///					//dgCol2.DataFormatString="{0:d}";
	///					DataGrid1.Columns.Add(dgCol2);
	///				}
	///			}
	///		}
	///		4.������õ�ѡ���ѡ��������ItemDataBound����������
	///		protected override void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
	///		{
	///			//˫��ĳһ�У�������Ӧҳ��
	///			e.Item.Attributes.Add("ondblclick","window.open('myPage.aspx?PKID=" + e.Item.Cells[0].Text +"')");
	///		}
	///		5.�����ص���������DataBind()����ģ���а�����Դ�������Ͳ���ÿ�δ�DataSource��ȥ��
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
            //������ʽ
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
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
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
