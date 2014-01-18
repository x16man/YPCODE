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
    using Shmzh.MM.Facade;
    using Shmzh.MM.Common;

	/// <summary>
	/// CategroyEdit 的摘要说明。
	/// </summary>
	public partial class PslpBrowser : System.Web.UI.Page
	{
		#region 成员变量
		protected int Code;
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
		#endregion

		#region 私有方法
		/// <summary>
		/// 数据绑定到DataGrid。
		/// </summary>
		private void myDataBind()
		{
			
			DataGrid1.DataSource = ((IPslpSystem)oPurchaseSystem).GetPslpAll();
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
		#endregion

		

		#region 事件
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if(!this.IsPostBack)
            {
                if(Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);
                if (!Master.HasRight(MZHMM.WebMM.Common.SysRight.BuyerMaintain))
                {
                    this.toolbarButtonadd.Visible = false;
                    this.toolbarButtondelete.Visible = false;
                }
                myDataBind();
            }
            else
            {
                this.DataGrid1.AutoDataBind = myDataBind;
            }
			
			
		}
		
		
		
		#endregion

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
               case "delete":
                    ((IPslpSystem) oPurchaseSystem).DeletePslp(DataGrid1.SelectedID);
                    myDataBind();
                    break;
              
            }
        }
	}
}
