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
using MZHCommon.PageStyle;
using MZHMM.Common;
using Shmzh.Components.SelectEngine;
namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyEdit 的摘要说明。
	/// </summary>
	public partial class YCLBrowser : System.Web.UI.Page
	{
		protected MZHMM.WebMM.Modules.StorageDropdownlist ddlQrySolution;

		protected int Code;
		private int QRYModuleID
		{
			get{return QRYModule.YCL;}
		}	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Category;
			if (!this.IsPostBack)
			{
				this.ddlQrySolution.UserCode = Session[MySession.UserLoginId].ToString();
				this.ddlQrySolution.AutoPostBack = false;
				this.ddlQrySolution.QRYModuleID = QRYModuleID;
				this.ddlQrySolution.Module_Tag = (int)SDDLTYPE.QRYSLT;

				string strSQL = new SelectEngine().GetDefaultSelectSqlByUserAndModule(QRYModuleID,Session[MySession.UserLoginId].ToString());
				if(strSQL != null && strSQL !="")
					this.txtSQL.Text = strSQL;
				else
					this.txtSQL.Text = MyParm.NON_SQL;

				myDataBind();	
			}
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

		}
		#endregion

		private void myDataBind()
		{
			ItemSystem oItemSystem=new ItemSystem();
			CommonStyle.InitDataGridStyle(this.DataGrid1,false);
			if (this.txtSQL.Text != MyParm.NON_SQL)
				DataGrid1.DataSource = oItemSystem.GetYCLALL();
			else
				DataGrid1.DataSource=oItemSystem.GetYCLALL();

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

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemIndex<0) return;
			e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
			e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
			e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
			//e.Item.Attributes.Add("ondblclick","window.open('CategroyDetails.aspx?Code=" + e.Item.Cells[0].Text +"','browser','height=260,width=550,left='+(window.screen.width - 550)/2+',top='+(window.screen.height - 260)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
			e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
			e.Item.Attributes.Add("onclick","execClick(this)");
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			myDataBind();	
		}

		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
			ItemSystem oItemSystem=new ItemSystem();
			if(!oItemSystem.DeleteYCL(int.Parse(tb_SelectedArray.Text)))
			{
				Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
			}
			tb_SelectedArray.Text="";
			myDataBind();
		}

		private void btn_refresh_Click(object sender, System.EventArgs e)
		{
			myDataBind();
		}

		#region 搜索控件用到的按钮事件

		/// <summary>
		/// 隐藏查询按钮事件。
		/// </summary>
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			this.DataGrid1.CurrentPageIndex=0;
			myDataBind();
		}

		/// <summary>
		/// 确定按钮的提交事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSelect_Click(object sender, System.EventArgs e)
		{
			int solutionID = 0;
			string strSQL = "";
			if (ddlQrySolution.SelectedValue !=null && ddlQrySolution.SelectedValue !="")
				solutionID = int.Parse(this.ddlQrySolution.SelectedValue);
			strSQL= new SelectEngine().GetSelectSQLBySolutionID(solutionID);
			//this.Response.Write(strSQL);
			if(strSQL !=null && strSQL !="")
				this.txtSQL.Text = strSQL;
			this.DataGrid1.CurrentPageIndex=0;
			this.myDataBind();
		}
		
		/// <summary>
		/// 将保存的方案更新到下拉列表框,此为隐藏按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnResetDS_Click(object sender, System.EventArgs e)
		{
			this.ddlQrySolution.UserCode = Session[MySession.UserLoginId].ToString();
			this.ddlQrySolution.AutoPostBack = false;
			this.ddlQrySolution.QRYModuleID = QRYModuleID;
			this.ddlQrySolution.Module_Tag = (int)SDDLTYPE.QRYSLT;
			this.ddlQrySolution.myBindData();
			this.btnSelect.Visible = true;
		}

		#endregion

	}
}
