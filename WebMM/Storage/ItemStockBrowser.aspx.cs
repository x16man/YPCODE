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

namespace MZHMM.WebMM.Storage
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
	using MZHMM.Common;
	using MZHMM.Facade;
	//using MZHCommon.PageStyle;
    //using Shmzh.Components.SelectEngine;
	/// <summary>
	/// DRWBrowser 的摘要说明。
	/// </summary>
	public partial class ItemStockBrowser : System.Web.UI.Page
	{
		#region 成员变量

		private int QRYModuleID
		{
			get{return QRYModule.DRW;}
		}

		#endregion

		#region 私有方法
		private void myDataBind()
		{
			ItemSystem oItemSystem = new ItemSystem();
			//CommonStyle.InitDataGridStyle(this.DataGrid1);
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
			
			DataGrid1.DataSource=oItemSystem.GetWDRWAll(Session[MySession.UserLoginId].ToString());
			
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
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.DRW;
			// 在此处放置用户代码以初始化页面

			if(!IsPostBack)
			{
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
				e.Item.Attributes.Add("ondblclick","window.open('DRWDetail.aspx?EntryNo=" + e.Item.Cells[0].Text +"','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
				//				e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
				//				e.Item.Attributes.Add("onclick","execClick(this)");
				e.Item.Cells[7].Text = Convert.ToDecimal(e.Item.Cells[7].Text).ToString("0.00");
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

				
		#endregion
		
		


	}
}
