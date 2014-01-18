#region Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved
/*
* ----------------------------------------------------------------------*
*                          MZH, Inc.			                        *
*              Copyright (c) 2004-2005 All Rights reserved              *
*                                                                       *
*                                                                       *
* This file and its contents are protected by China and					*
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved


namespace MZHMM.WebMM.Purchase
{
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
	using Shmzh.Components.SystemComponent;
    using Shmzh.Components.SelectEngine;
	using MZHMM.Common;
	using MZHMM.Facade;
	using MZHCommon.PageStyle;
	using MySys = Shmzh.Components.SystemComponent;
	using MZHCommon;
	/// <summary>
	/// ROSBrowser 的摘要说明。
	/// </summary>
	public partial class Audit3Browser : System.Web.UI.Page
	{
		#region 成员变量
		protected System.Web.UI.WebControls.Button btn_delete;
		protected System.Web.UI.WebControls.Button btn_cancel;
		protected System.Web.UI.WebControls.Button btn_Submit;
		protected User myUser;
		//protected string action_new_hasRight;
//		private int DocCode;
//		private string AuthorCode;
//		private int AuditResult;
//		private string AuthorDept;
//		private DateTime StartDate;
//		private DateTime EndDate;

        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

        //SelectEngine oSelectEngine = new SelectEngine();

	    private string DocCode;
	    private string EntryNo;

	    private string strSQL;

		/// <summary>
		/// 当前的查询模块ID。
		/// </summary>
		protected int QRYModuleID
		{
			get{return QRYModule.ROS;}
		}
		/// <summary>
		/// 当前的用户。
		/// </summary>
		protected string UserLoginId
		{
			get
			{
				if (this.Session[MySession.UserLoginId] != null && 
					this.Session[MySession.UserLoginId].ToString() != "")
				{
					return this.Session[MySession.UserLoginId].ToString();
				}
				else
				{
					return null;
				}
			}
		}
		protected string SQL
		{
			get 
			{
				return this.txtSQL.Text;
			}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 数据绑定到DataGrid。
		/// </summary>
		private void myDataBind()
		{
			
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
			if (this.SQL == MyParm.NON_SQL )
				DataGrid1.DataSource=oPurchaseSystem.GetAudit3DataByToAudit(this.UserLoginId);
			else if (this.SQL != MyParm.NON_SQL )
				DataGrid1.DataSource = oPurchaseSystem.GetAudit3DataBySQL(this.SQL);
			try
			{
				DataGrid1.DataBind();
			}
			catch(Exception e)
			{
				if(e.Source=="System.Web" && DataGrid1.CurrentPageIndex>=1)
				{
					DataGrid1.CurrentPageIndex--;
					try
					{
						DataGrid1.DataBind();
					}
					catch
					{
						DataGrid1.CurrentPageIndex = 0;
						DataGrid1.DataBind();
					}
				}				
			}		
		}

		#endregion
	
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
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

		}
		#endregion
	
		#region 事件
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
		    if(!IsPostBack)
			{
				this.ddlQrySolution.UserCode = Session[MySession.UserLoginId].ToString();
				this.ddlQrySolution.AutoPostBack = false;
				this.ddlQrySolution.QRYModuleID = QRYModuleID;
				this.ddlQrySolution.Module_Tag = (int)SDDLTYPE.QRYSLT;

				strSQL = new SelectEngine().GetDefaultSelectSqlByUserAndModule(QRYModuleID,Session[MySession.UserLoginId].ToString());
				if(!string.IsNullOrEmpty(strSQL))
					this.txtSQL.Text = strSQL;
				else
					this.txtSQL.Text = MyParm.NON_SQL;
				myDataBind();	
			}
		}


		#region DadaGrid事件 "绑定","换页","排序"
		/// <summary>
		/// 绑定。
		/// </summary>
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
//				e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
//				e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
//				e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
			    EntryNo = e.Item.Cells[0].Text.Split("|".ToCharArray())[0].ToString();
				DocCode = (e.Item.Cells[0].Text.Split("|".ToCharArray()))[1].ToString();
				switch (DocCode)
				{
					case "1"://采购申请单。
						e.Item.Attributes.Add("ondblclick",String.Format("window.open('ROSDetail.aspx?Op=View&EntryNo={0}','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=no,location=no, status=no')",EntryNo));
						break;
					case "5"://采购计划。
						e.Item.Attributes.Add("ondblclick",String.Format("window.open('PPReport.aspx?Op=View&EntryNo={0}','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes, scrollbars=yes, resizable=yes,location=no, status=no')",EntryNo));
						break;
					case "7"://采购退货单。
						e.Item.Attributes.Add("ondblclick",String.Format("window.open('PRTVDetail.aspx?EntryNo={0}','browser','height=560,width=850,left='+(window.screen.width - 850)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')",EntryNo));
						break;
					case "16"://维外加工申请单。
						e.Item.Attributes.Add("ondblclick",String.Format("window.open('../Storage/WTOWDetail.aspx?Op=View&EntryNo={0}','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')",EntryNo));
						break;
				}
//				e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
//				e.Item.Attributes.Add("onclick","execClick(this)");
				if (e.Item.Cells[3].Text == "新建" || 
					e.Item.Cells[3].Text == "提交" )
				{
					e.Item.BackColor =	Color.FromArgb(216,244,255);
				}
				else if (e.Item.Cells[3].Text == "审批通过")
				{
					e.Item.BackColor =	Color.FromArgb(181,255,136);
				}
				else if (e.Item.Cells[3].Text == "作废")
				{
					e.Item.BackColor =	Color.FromArgb(212,208,200);
				}
				else if (e.Item.Cells[3].Text == "部门通过" ||
						e.Item.Cells[3].Text =="财务通过")
				{
					e.Item.BackColor = Color.FromArgb(153,204,255);
				}
				else
				{
					e.Item.BackColor =	Color.FromArgb(201,181,196);
				}
			}
		}
		/// <summary>
		/// 换页。
		/// </summary>
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			myDataBind();
		}
		/// <summary>
		/// 排序。
		/// </summary>
		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.myDataBind();
		}
		#endregion

		#region 搜索控件用到的按钮事件

		/// <summary>
		/// 隐藏查询按钮事件。
		/// </summary>
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{

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

			this.myDataBind();
		}
		
		/// <summary>
		/// 将保存的方案更新到下拉列表框,此为隐藏按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnResetDS_Click(object sender, System.EventArgs e)
		{
			this.ddlQrySolution.UserCode = Session[MySession.UserLoginId].ToString();
			this.ddlQrySolution.AutoPostBack = false;
			this.ddlQrySolution.QRYModuleID = QRYModuleID;
			this.ddlQrySolution.Module_Tag = (int)SDDLTYPE.QRYSLT;
			this.ddlQrySolution.myBindData();
			this.btnSelect.Visible = true;
		}

		#endregion

		#endregion

		
	}
}
