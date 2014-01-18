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
using MZHMM.Facade;
using MZHMM.Common;
using MZHCommon.PageStyle;

namespace MZHMM.WebMM.Purchase
{
	/// <summary>
	/// PCTRBrowser 的摘要说明。
	/// </summary>
	public class PCTRBrowser : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btn_delete;
		protected System.Web.UI.WebControls.TextBox tb_SelectedArray;
        protected Shmzh.Web.UI.Controls.MzhDataGrid DataGrid1;

		protected int Code;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Contract;
			myDataBind();	
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
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// 数据绑定到DataGrid。
		/// </summary>
		private void myDataBind()
		{
			PCTRSystem oPCTRSystem = new PCTRSystem();
			CommonStyle.InitDataGridStyle(this.DataGrid1);
			DataGrid1.DataSource=oPCTRSystem.GetPCTRAll();
			this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0? true:false;
			try
			{
				DataGrid1.DataBind();
			}
			catch(Exception e)
			{
				if(e.Source=="System.Web" && DataGrid1.CurrentPageIndex>=1)
				{
					DataGrid1.CurrentPageIndex--;
					DataGrid1.DataBind();
				}				
			}		
		}
		/// <summary>
		/// 数据绑定。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemIndex<0) return;
//			e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
//			e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
//			e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
			e.Item.Attributes.Add("ondblclick","window.open('CategroyDetails.aspx?Code=" + e.Item.Cells[0].Text +"')");
//			e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
//			e.Item.Attributes.Add("onclick","execClick(this)");
		}
		/// <summary>
		/// 换页。
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			myDataBind();	
		}
		/// <summary>
		/// 采购合同删除。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_delete_Click(object sender, System.EventArgs e)
		{
			PCTRSystem oPCTRSystem = new PCTRSystem();

			if( !oPCTRSystem.DeletePCTR(tb_SelectedArray.Text) )
			{
				Response.Write("<script>alert('"+oPCTRSystem.Message+"');</script>");
			}
			tb_SelectedArray.Text="";
			myDataBind();
		}

	}
}
