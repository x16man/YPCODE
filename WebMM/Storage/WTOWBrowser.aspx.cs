using System;
using System.Data;
using System.Drawing;
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

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// DRWBrowser 的摘要说明。
	/// </summary>
	public partial class WTOWBrowser : Page
	{
		#region 成员变量

        ItemSystem oItemSystem = new ItemSystem();
		#endregion

		#region 私有方法
		private void myDataBind()
		{
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.WTOWBrowserByDept))
                {

                    DataGrid1.DataSource = oItemSystem.GetEntryAll(Master.CurrentUser.thisUserInfo.LoginName);
                }
                else if (Master.HasRight(SysRight.WTOWBrowser))
                {
                    DataGrid1.DataSource = oItemSystem.GetEntryByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.WTOWBrowserByDept))
                {
                    DataGrid1.DataSource = oItemSystem.GetEntryBySQL(MzhToolbar1.SE_SQL);
                }
                else if (Master.HasRight(SysRight.WTOWBrowser))
                {
                    DataGrid1.DataSource = oItemSystem.GetEntryBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
                }
            }
            else
            {
                if (Master.HasRight(SysRight.WTOWBrowserByDept))
                {
                    DataGrid1.DataSource = oItemSystem.GetEntryByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                }
                else if (Master.HasRight(SysRight.WTOWBrowser))
                {
                    DataGrid1.DataSource = oItemSystem.GetEntryByDeptAndAuthorAndAuditResult("", Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
               
                }
            }

			this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0? true:false;
			
			DataGrid1.DataBind();
		}
		#endregion
		
		#region 事件

        private void Purview()
        {
            if (!Master.HasRight(SysRight.WTOWMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.WTOWPresent))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.WTOWCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

            if (!Master.HasRight(SysRight.WTOWFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.WTOWSecondAudit))
            {
                this.toolbarButtonSecondAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.WTOWThirdAudit))
            {
                toolbarButtonThirdAudit.Visible = false;
            }


            if (!Master.HasRight(SysRight.WTOWRed))
            {
                toolbarButtonRed.Visible = false;
            }

            if (!Master.HasRight(SysRight.StockOut))
            {
                toolbarButtonDraw.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session[MySession.Help] = HelpCode.DRW;
            // 在此处放置用户代码以初始化页面

            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.WTOWBrowser))
                {
                    return;
                }

                Purview();
                myDataBind();
            }
            else
            {
                DataGrid1.AutoDataBind = myDataBind;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!oItemSystem.PresentWTOW(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
            {
                Response.Write("<script>alert('" + oItemSystem.Message + "');</script>");
            }
            tb_SelectedArray.Value = "";
            myDataBind();
        }

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            //Response.Write(sqlStatement);
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[7].Visible = Master.DisplayWTOWPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[7].Visible = Master.DisplayWTOWPrice;
                e.Item.Attributes.Add("ondblclick", "window.open('WTOWDetail.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=560,width=1000,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=yes,location=no, status=no')");

                if (e.Item.Cells[8].Text.Replace("&nbsp;", "") != "0")
                {
                    e.Item.Cells[1].ForeColor = Color.Red;
                    e.Item.Cells[2].ForeColor = Color.Red;
                    e.Item.Cells[3].ForeColor = Color.Red;
                    e.Item.Cells[4].ForeColor = Color.Red;
                    e.Item.Cells[5].ForeColor = Color.Red;
                    e.Item.Cells[6].ForeColor = Color.Red;
                    e.Item.Cells[7].ForeColor = Color.Red;
                    e.Item.Cells[8].ForeColor = Color.Red;


                }

                if (e.Item.Cells[2].Text == "新建" ||
                    e.Item.Cells[2].Text == "提交")
                {
                    e.Item.BackColor = Color.FromArgb(216, 244, 255);
                }
                else if (e.Item.Cells[2].Text == "审批通过")
                {
                    e.Item.BackColor = Color.FromArgb(181, 255, 136);
                }
                else if (e.Item.Cells[2].Text == "作废")
                {
                    e.Item.BackColor = Color.FromArgb(212, 208, 200);
                }
                else if (e.Item.Cells[2].Text == "部门通过" ||
                    e.Item.Cells[2].Text == "财务通过")
                {
                    e.Item.BackColor = Color.FromArgb(153, 204, 255);
                }
                else
                {
                    e.Item.BackColor = Color.FromArgb(201, 181, 196);
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[7].Visible = Master.DisplayWTOWPrice;
            }
        }
		#endregion

		#region 删除
        /// <summary>
		/// 删除按钮。
		/// </summary>
		protected void btn_delete_Click(object sender, EventArgs e)
		{
            if (!oItemSystem.DeleteWTOW(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
			{
				//Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
				//Page.RegisterStartupScript("delete","<script>alert('"+oItemSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
/*
		/// <summary>
		/// 提交按钮。
		/// </summary>
		private void btn_Submit_Click(object sender, EventArgs e)
		{
			ItemSystem oItemSystem = new ItemSystem();

			if( !oItemSystem.PresentWDRW(int.Parse(tb_SelectedArray.Text),Session[MySession.UserCode].ToString() ))
			{
				Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
			}
			tb_SelectedArray.Text="";
			myDataBind();	
		}
*/
		/// <summary>
		/// 作废按钮。
		/// </summary>
		protected void btn_cancel_Click(object sender, EventArgs e)
		{
            if (!oItemSystem.CancelWTOW(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
			{
				//Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
				//Page.RegisterStartupScript("cancel","<script>alert('"+oItemSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}


		

		

		#endregion
    }
}
