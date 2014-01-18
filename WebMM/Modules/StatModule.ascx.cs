namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///	各个浏览页面的统计块，反应的是当月的信息。
	///	库存浏览：
	///	物料主文件浏览：
	///	采购申请单：
	///	物料需求单：
	///	领料单：	
	/// </summary>
	public partial class StatModule : System.Web.UI.UserControl
	{
	    private BoundColumn dgCol = new BoundColumn();
		private void BindColumn()
		{
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = "部门";
			dgCol.DataField = "AuthorDeptName";
			this.MzhDataGrid1.Columns.Add(dgCol);
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = "审批通过";
			dgCol.DataField = "PassedCount";
			this.MzhDataGrid1.Columns.Add(dgCol);
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = "审批不通过";
			dgCol.DataField = "NoPassedCount";
			this.MzhDataGrid1.Columns.Add(dgCol);
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = "未审批";
			dgCol.DataField = "ToDoCount";
			this.MzhDataGrid1.Columns.Add(dgCol);
			dgCol = new BoundColumn();
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.BindColumn();

		}

		
	}
}
