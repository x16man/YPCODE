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
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	//using MZHCommon.PageStyle;
	/// <summary>
	/// MRPBrowser 的摘要说明。
	/// </summary>
	public partial class PBSADetail : System.Web.UI.Page
	{
		#region 成员变量
		//private string Entry;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
		#endregion

		#region 私有方法
		private void myDataBind()
		{
			
			
			
			DataTable dt = oPurchaseSystem.GetPBSDByList(Master.EntryNo.ToString()).Tables[0];
            DataGrid1.DataSource = oPurchaseSystem.GetPBSDByList(Master.EntryNo.ToString());
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
		
		#region 事件
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if(!this.IsPostBack)
            {
                this.myDataBind();
            }
            else
            {
                this.DataGrid1.AutoDataBind = myDataBind;
            }
			   
		}
		#endregion

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                e.Item.Cells[4].Text = Convert.ToDecimal(e.Item.Cells[4].Text).ToString("0.000");
                e.Item.Cells[5].Text = Convert.ToDecimal(e.Item.Cells[5].Text).ToString("0.##");
                e.Item.Cells[6].Text = Convert.ToDecimal(e.Item.Cells[6].Text).ToString("0.00");
            }
        }
	}
}
