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
	/// PCTRBrowser ��ժҪ˵����
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
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// ���ݰ󶨵�DataGrid��
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
		/// ���ݰ󶨡�
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
		/// ��ҳ��
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			myDataBind();	
		}
		/// <summary>
		/// �ɹ���ͬɾ����
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
