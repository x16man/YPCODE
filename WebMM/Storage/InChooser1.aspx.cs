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
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Modules;
//using MZHCommon.PageStyle;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyEdit 的摘要说明。
	/// </summary>
	public partial class InChooser1 : System.Web.UI.Page
	{
		#region 成员变量

		protected int DocCode;
		protected int EntryNo;
		protected string SerialNoList;
		protected string ItemCodeList;
		protected string ItemNumList;
		private static DataTable ReceiveDT;
		private bool IsTODO = false;
		#endregion

		#region 私有方法
		private void myDataBind()
		{
			if(ReceiveDT.Rows.Count > 0)
			{
				Col2List MyCol2List = new Col2List(ReceiveDT);
				SerialNoList = MyCol2List.GetList();
				ItemCodeList = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);
				ItemNumList = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
				ItemSystem oItemSystem = new ItemSystem();
				
				this.UCStockChoice.thisTable = oItemSystem.GetStockChoice(this.DocCode,EntryNo,SerialNoList,ItemCodeList,ItemNumList).Tables[StockChoiceData.StockChoice_Table];
				try
				{
					this.UCStockChoice.DataBind();
				}
				catch(Exception e)
				{
					if(e.Source=="System.Web" )
					{
						this.UCStockChoice.DataBind();
					}	
				}
			}
		}
		#endregion

		#region 事件
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (this.Request["EntryNo"] != null && this.Request["EntryNo"].ToString() != "")
			{
				EntryNo = int.Parse(this.Request["EntryNo"].ToString());
			}
			if (this.Request["DocCode"] != null && this.Request["DocCode"].ToString() != "")
			{
				DocCode = int.Parse(this.Request["DocCode"].ToString());
			}
			if (this.Request["IsTODO"] != null && this.Request["IsTODO"].ToString() != "")
			{
				this.IsTODO = true;
			}
			if (!this.IsPostBack)
			{
				if (Session[MySession.ReceiveDt] != null)
				{
					ReceiveDT = (DataTable)Session[MySession.ReceiveDt];
				}
				this.myDataBind();
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

		}
		#endregion
		/// <summary>
		/// 数据绑定事件。
		/// </summary>
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemIndex<0) return;
			e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
			e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
			e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
			//e.Item.Attributes.Add("ondblclick","window.open('CategroyDetails.aspx?Code=" + e.Item.Cells[0].Text +"')");
			e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
			e.Item.Attributes.Add("onclick","execClick(this)");
		}

		/// <summary>
		/// 换页事件。
		/// </summary>
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			myDataBind();	
		}
		/// <summary>
		/// 确定按钮事件。
		/// </summary>
		protected void btnYes_Click(object sender, System.EventArgs e)
		{
			string SerialNoList;
			string ItemNumList;
			string PKIDList;
			string ItemDrawNumList;
			string UserCode;
			string UserName;
			string UserLoginId;
			string TgtStoCode;
			string TgtStoName;
		
			string ItemCodeList;
			string ConCodeList;
			string ConNameList;
			bool ret;

			Col2List MyCol2List = new Col2List(ReceiveDT);	
			SerialNoList = MyCol2List.GetList();
			ItemNumList = MyCol2List.GetList(InItemData.ITEMNUM_FIELD);
	
			ItemCodeList = MyCol2List.GetList(InItemData.ITEMCODE_FIELD);
			

			MyCol2List = new Col2List(this.UCStockChoice.thisTable);
			ConCodeList = MyCol2List.GetList(StockData.CONCODE_FIELD);
			ConNameList = MyCol2List.GetList(StockData.CONNAME_FIELD);
			PKIDList = MyCol2List.GetList(StockData.PKID_FIELD);
			ItemDrawNumList = MyCol2List.GetList(StockData.ITEMNUM_FIELD);
			UserCode = Session[MySession.UserCode].ToString();
			UserName = Session[MySession.UserName].ToString();
			UserLoginId = Session[MySession.UserLoginId].ToString();

			TgtStoCode = this.Request["TgtStoCode"].Trim();
			TgtStoName = this.Request["TgtStoName"].Trim();
			ItemSystem oItemSystem = new ItemSystem();
			ret = oItemSystem.TransDrawInStock(this.EntryNo,TgtStoCode,TgtStoName,SerialNoList,ItemCodeList,ConCodeList,ConNameList,UserCode,UserName,UserLoginId);
			if (ret == false)
			{
                Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
			}
			else
			{
				if (this.IsTODO)
				{
					this.Response.Write("<script>window.close();</script>");
				}
				else
				{
					Response.Redirect("TransBrowser.aspx");
				}
			}
		}
		#endregion

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
