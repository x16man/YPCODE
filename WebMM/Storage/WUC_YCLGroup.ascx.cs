namespace WebMM.Storage
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Infragistics.WebUI.UltraWebGrid;
	using MZHCommon.Database;
	/// <summary>
	///		WUC_YCLGroup ��ժҪ˵����
	/// </summary>
	public partial class WUC_YCLGroup : System.Web.UI.UserControl
	{
		private DataSet oData;

        Hashtable oHT = new Hashtable();
		#region ����
		/// <summary>
		/// ��ʼ���ڡ�
		/// </summary>
		public DateTime StartDate
		{
			get {	return (DateTime)this.ddlStartDate.Value;	}
			set {	this.ddlStartDate.Value = value;			}
		}
		/// <summary>
		/// �������ڡ�
		/// </summary>
		public DateTime EndDate
		{
			get	{	return (DateTime)this.ddlEndDate.Value;}
			set {	this.ddlEndDate.Value = value;}

		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)
			{
				if (this.Request["StartDate"] == null)
				{
					this.StartDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
				}
				else
				{
					this.StartDate = Convert.ToDateTime(this.Request["StartDate"]);
				}
				if (this.Request["EndDate"] == null)
				{
					this.EndDate = this.StartDate.AddMonths(1);
				}
				else
				{
					this.EndDate = Convert.ToDateTime(this.Request["EndDate"]);
				}
				this.UG_YCLGroup.DataBind();
			}
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
			this.UG_YCLGroup.InitializeRow += new Infragistics.WebUI.UltraWebGrid.InitializeRowEventHandler(this.UG_YCLGroup_InitializeRow);
			this.UG_YCLGroup.InitializeLayout += new Infragistics.WebUI.UltraWebGrid.InitializeLayoutEventHandler(this.UG_YCLGroup_InitializeLayout);

		}
		#endregion

		private void UG_YCLGroup_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
		{
			this.UG_YCLGroup.DisplayLayout.ViewType = ViewType.Flat;
			this.UG_YCLGroup.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;

			this.UG_YCLGroup.Bands[0].Columns.FromKey("ItemCode").Header.Caption = "���";
			this.UG_YCLGroup.Bands[0].Columns.FromKey("ItemName").Header.Caption = "����";
			this.UG_YCLGroup.Bands[0].Columns.FromKey("StartItemNum").Header.Caption = "�ڳ�";
			this.UG_YCLGroup.Bands[0].Columns.FromKey("InItemNum").Header.Caption = "����";
			this.UG_YCLGroup.Bands[0].Columns.FromKey("OutItemNum").Header.Caption = "����";
			this.UG_YCLGroup.Bands[0].Columns.FromKey("EndItemNum").Header.Caption = "���";

			this.UG_YCLGroup.Bands[0].Columns.FromKey("ItemCode").CellStyle.HorizontalAlign = HorizontalAlign.Center;
			this.UG_YCLGroup.Bands[0].Columns.FromKey("ItemName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
			this.UG_YCLGroup.Bands[0].Columns.FromKey("StartItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLGroup.Bands[0].Columns.FromKey("InItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLGroup.Bands[0].Columns.FromKey("OutItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
			this.UG_YCLGroup.Bands[0].Columns.FromKey("EndItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;

			this.UG_YCLGroup.Bands[0].Columns.FromKey("ItemCode").Width = new Unit("80px");
			this.UG_YCLGroup.Bands[0].Columns.FromKey("ItemName").Width = new Unit("120px");
			this.UG_YCLGroup.Bands[0].Columns.FromKey("StartItemNum").Width = new Unit("80px");
			this.UG_YCLGroup.Bands[0].Columns.FromKey("InItemNum").Width = new Unit("80px");
			this.UG_YCLGroup.Bands[0].Columns.FromKey("OutItemNum").Width = new Unit("80px");
			this.UG_YCLGroup.Bands[0].Columns.FromKey("EndItemNum").Width = new Unit("80px");
		}

		protected void UG_YCLGroup_DataBinding(object sender, System.EventArgs e)
		{
			oHT = new Hashtable();
			oHT.Add("@StartDate", this.StartDate);
			oHT.Add("@EndDate", this.EndDate);

			oData = new SQLServer().ExecSPReturnDS("Sto_YCLGetGroupByDate",oHT);
			this.UG_YCLGroup.DataSource = oData.Tables[0].DefaultView;
		}

		private void UG_YCLGroup_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
		{
			e.Row.Cells.FromKey("ItemCode").TargetURL = "?ItemCode="+e.Row.Cells.FromKey("ItemCode").Value.ToString()+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
			e.Row.Cells.FromKey("ItemName").TargetURL = "?ItemCode="+e.Row.Cells.FromKey("ItemCode").Value.ToString()+"&StartDate="+this.StartDate.ToShortDateString()+"&EndDate="+this.EndDate.ToShortDateString();
		}
	}
}
