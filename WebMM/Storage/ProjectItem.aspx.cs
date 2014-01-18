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
using Shmzh.MM.Facade;
using Shmzh.MM.Common;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// ProjectItem ��ժҪ˵����
	/// </summary>
	public partial class ProjectItem : System.Web.UI.Page
	{
		#region ��Ա����
        private Shmzh.MM.Common.RealDrawItemData realItemData;
		private decimal sumMoney = 0;
		#endregion
		
		#region ����
		/// <summary>
		/// ��Ŀ��ص��������ϡ�
		/// </summary>
		public RealDrawItemData RealItemData
		{
			get {return this.realItemData;}
			set {this.realItemData = value;}
		}
		/// <summary>
		/// ��Ŀ��š�
		/// </summary>
		public string ProjectCode
		{
			get {return this.Request["ProjectCode"];}
		}
		/// <summary>
		/// ��Ŀ���ơ�
		/// </summary>
		public string ProjectName
		{
			get {return this.Request["ProjectName"];}
		}
		/// <summary>
		/// �ܽ�
		/// </summary>
		public decimal SumMoney
		{
			get {return this.sumMoney;}
			set {this.sumMoney = value;}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// DataGrid�����ݰ󶨡�
		/// </summary>
		private void myDataBind()
		{
			this.RealItemData = new ItemSystem().GetByProjectCode(this.ProjectCode);
			this.DataGrid1.DataSource = this.RealItemData;
			this.DataGrid1.DataBind();
		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
            if(!this.IsPostBack)
            {
                Master.SetTitleContent(ProjectName);
                myDataBind();
            }
            else
            {
                this.DataGrid1.AutoDataBind = myDataBind;
            }
			// �ڴ˴������û������Գ�ʼ��ҳ��
		}

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                SumMoney = 0;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    this.SumMoney += decimal.Parse(e.Item.Cells[6].Text);
                }
                catch
                { }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[6].Text = this.SumMoney.ToString("n2");
            }
        }
	}
}
