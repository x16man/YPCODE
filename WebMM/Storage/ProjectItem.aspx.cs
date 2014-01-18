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
	/// ProjectItem 的摘要说明。
	/// </summary>
	public partial class ProjectItem : System.Web.UI.Page
	{
		#region 成员变量
        private Shmzh.MM.Common.RealDrawItemData realItemData;
		private decimal sumMoney = 0;
		#endregion
		
		#region 属性
		/// <summary>
		/// 项目相关的领用物料。
		/// </summary>
		public RealDrawItemData RealItemData
		{
			get {return this.realItemData;}
			set {this.realItemData = value;}
		}
		/// <summary>
		/// 项目编号。
		/// </summary>
		public string ProjectCode
		{
			get {return this.Request["ProjectCode"];}
		}
		/// <summary>
		/// 项目名称。
		/// </summary>
		public string ProjectName
		{
			get {return this.Request["ProjectName"];}
		}
		/// <summary>
		/// 总金额。
		/// </summary>
		public decimal SumMoney
		{
			get {return this.sumMoney;}
			set {this.sumMoney = value;}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// DataGrid的数据绑定。
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
			// 在此处放置用户代码以初始化页面
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
