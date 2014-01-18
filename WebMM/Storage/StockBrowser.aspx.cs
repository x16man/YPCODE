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
//using MZHCommon.PageStyle;
using MZHMM.WebMM.Modules;
using Shmzh.MM.Common;
using MySys = Shmzh.Components.SystemComponent;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// 库存查询的页面后台代码。
	/// </summary>
	public partial class StockBrowser : System.Web.UI.Page
	{
		#region 成员变量
        //private string strSQL;
        ItemSystem oItemSystem = new ItemSystem();

		private int QRYModuleID
		{
			get{return QRYModule.STOCK;}
		}
	
		#endregion

		#region 私有函数
		private void myDataBind()
		{
            if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL))
            {
                DataGrid1.DataSource = oItemSystem.GetStockBySQL(MzhToolbar1.SE_SQL);
                DataGrid1.DataBind();                
            }
		}


		#endregion

		#region 事件
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!this.IsPostBack )
            {
                myDataBind();
            }
            DataGrid1.AutoDataBind = myDataBind;
            this.Title = Master.PurposeOp == "1" ? "库存查询" : Master.PurposeOp == "2" ? "辅料查询" : string.Empty;
		}

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }
		
		#endregion

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.##");
                }
                catch
                { }
            }
        }
		
	}
}
