using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
//using MZHCommon.PageStyle;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Modules;
using Shmzh.Web.UI.Controls;
using MZHCommon;
using SysRight = MZHMM.WebMM.Common.SysRight;

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
	/// <summary>
	/// 采购收料付款明细单的浏览界面。
	/// </summary>
	public partial class PPAYBrowser : Page
	{
		#region 成员变量
        private PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        PPAYData oData;
		#endregion

		#region 私有方法
		private void myDataBind()
		{

            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if(Master.HasRight(SysRight.PayBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPayByDept(Master.CurrentUser.thisUserInfo.DeptCode);
                }
                else if(Master.HasRight(SysRight.PayBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPayByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if(Master.HasRight(SysRight.PayBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPayBySQL(MzhToolbar1.SE_SQL);
                }
                else if(Master.HasRight(SysRight.PayBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPayBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
                }
            }

			this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0? true:false;
			DataGrid1.DataBind();
		}
		#endregion
		
		#region 事件
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//Session[MySession.Help] = HelpCode.MRP;

            if (!IsPostBack)
            {
                if (!Master.HasBrowseRight(SysRight.PayBrowser))
                {
                    return;
                }

                this.myDataBind();
            }
            else
            {
                DataGrid1.AutoDataBind = myDataBind;
            }
		}
		#endregion

        #region 方法
        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				//				e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
				//				e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
				//				e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
				e.Item.Attributes.Add("ondblclick","window.open('PPAYDetail.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text +"','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes, resizable=yes,location=no, status=no')");
				//				e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
				//				e.Item.Attributes.Add("onclick","execClick(this)");
			}
        }

		/// <summary>
		/// 删除按钮。
		/// </summary>
		protected void btn_delete_Click(object sender, EventArgs e)
		{
			
            oData = oPurchaseSystem.GetPayByEntryNo(int.Parse(tb_SelectedArray.Value));

			if( !oPurchaseSystem.Delete(oData))
			{
				ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
		/// <summary>
		/// 提交按钮。
		/// </summary>
		protected void btn_Submit_Click(object sender, EventArgs e)
		{
		
            oData = oPurchaseSystem.GetPayByEntryNo(int.Parse(tb_SelectedArray.Value));

			if( !oPurchaseSystem.Present(oData))
			{
				//Response.Write("<script>alert('"+oPurchaseSystem.Message+"');</script>");
				//Page.RegisterStartupScript("Submit","<script>alert('"+oPurchaseSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "Submit", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();	
		}
		/// <summary>
		/// 作废按钮。
		/// </summary>
		protected void btn_cancel_Click(object sender, EventArgs e)
		{
			
            oData = oPurchaseSystem.GetPayByEntryNo(int.Parse(tb_SelectedArray.Value));

			if( !oPurchaseSystem.Cancel(oData))
			{
				ClientScript.RegisterStartupScript( this.GetType(), "Submit", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}


        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }

		#endregion
    }
}
