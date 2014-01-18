namespace MZHMM.WebMM.Modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///	�������ҳ���ͳ�ƿ飬��Ӧ���ǵ��µ���Ϣ��
	///	��������
	///	�������ļ������
	///	�ɹ����뵥��
	///	�������󵥣�
	///	���ϵ���	
	/// </summary>
	public partial class StatModule : System.Web.UI.UserControl
	{
	    private BoundColumn dgCol = new BoundColumn();
		private void BindColumn()
		{
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = "����";
			dgCol.DataField = "AuthorDeptName";
			this.MzhDataGrid1.Columns.Add(dgCol);
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = "����ͨ��";
			dgCol.DataField = "PassedCount";
			this.MzhDataGrid1.Columns.Add(dgCol);
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = "������ͨ��";
			dgCol.DataField = "NoPassedCount";
			this.MzhDataGrid1.Columns.Add(dgCol);
			dgCol = new BoundColumn();
			dgCol.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			dgCol.HeaderText = "δ����";
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
