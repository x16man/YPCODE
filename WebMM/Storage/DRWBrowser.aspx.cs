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
	public partial class DRWBrowser : Page
	{
		#region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		
		//private int DocCode;
		//private string AuthorCode;
		//private int AuditResult;
		//private string AuthorDept;
		//private DateTime StartDate;
		//private DateTime EndDate;
        ItemSystem oItemSystem = new ItemSystem();
       
       
		#endregion

		#region 私有方法
        private void myDataBind()
		{
		    //如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.DRWBrowserByDept))
                {
                    DataGrid1.DataSource = oItemSystem.GetWDRWAll(Master.CurrentUser.thisUserInfo.LoginName);
                }
                else if (Master.HasRight(SysRight.DRWBrowser))
                {
                    DataGrid1.DataSource = oItemSystem.GetWDRWByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.DRWBrowserByDept))
                {
                    DataGrid1.DataSource = oItemSystem.GetWDRWBySQL(MzhToolbar1.SE_SQL);
                }
                 else if (Master.HasRight(SysRight.DRWBrowser))
                {
                    DataGrid1.DataSource = oItemSystem.GetWDRWBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
                }
            }
            else
            {
                if (Master.HasRight(SysRight.DRWBrowserByDept))
                {
                    DataGrid1.DataSource = oItemSystem.GetWDRWByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                }
                else if (Master.HasRight(SysRight.DRWBrowser))
                {
                    if(Master.AuthorCode != "")
                        DataGrid1.DataSource = oItemSystem.GetWDRWByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                    else
                        DataGrid1.DataSource = oItemSystem.GetWDRWByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.CurrentUser.EmpCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                    
                }
            }
			this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0? true:false;
			DataGrid1.DataBind();
		}

        private void Purview()
        {
            if (!Master.HasRight(SysRight.DRWMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.DRWPresent))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.DRWCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

            if (!Master.HasRight(SysRight.StockOut))
            {
                this.toolbarButtonDraw.Visible = false;
            }

            if (!Master.HasRight(SysRight.DRWFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }
            if(!Master.HasRight(SysRight.DRWSecondAudit))
            {
                this.toolbarButtonSecondAudit.Visible = false;
            }
            if (!Master.HasRight(SysRight.DRWRed))
            {
                this.toolbarButtonRed.Visible = false;
            }
        }
		#endregion
		
		#region 事件
		protected void Page_Load(object sender, EventArgs e)
		{
			Session[MySession.Help] = HelpCode.DRW;
			// 在此处放置用户代码以初始化页面

            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);
                this.DataGrid1.Columns[8].Visible = Master.DisplayDRWPrice;
                if (!Master.HasBrowseRight(SysRight.DRWBrowser))
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

		/// <summary>
		/// 删除按钮。
		/// </summary>
		protected void btn_delete_Click(object sender, EventArgs e)
		{

            if (!oItemSystem.DeleteWDRW(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
			{
				//Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
				//Page.RegisterStartupScript("delete","<script>alert('"+oItemSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}

		/// <summary>
		/// 作废按钮。
		/// </summary>
		protected void btn_cancel_Click(object sender, EventArgs e)
		{
			
            if (!oItemSystem.CancelWDRW(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
			{
                ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!oItemSystem.PresentWDRW(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.EmpCode))
            {
                Response.Write("<script>alert('" + oItemSystem.Message + "');</script>");
            }
            tb_SelectedArray.Value = "";
            myDataBind();
        }

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            Logger.Debug(sqlStatement);
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('DRWDetail.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=yes,location=no, status=no')");
                try
                {
                    if (e.Item.Cells[9].Text.Replace("&nbsp;", "") != "0")
                    {
                        e.Item.Cells[1].ForeColor = Color.Red;
                    }

                    if (e.Item.Cells[2].Text == "新建" || e.Item.Cells[2].Text == "提交")
                    {
                        e.Item.Cells[2].ForeColor = Color.Orange;
                    }
                    else if (e.Item.Cells[2].Text == "作废")
                    {
                        e.Item.Cells[2].ForeColor = Color.Gray;
                    }
                    else if (e.Item.Cells[2].Text == "审批通过")
                    {
                        e.Item.Cells[2].ForeColor = Color.Blue;
                    }
                    else if (e.Item.Cells[2].Text == "领料")
                    {
                        e.Item.Cells[2].ForeColor = Color.Green;
                    }
                    e.Item.Cells[8].Text = Convert.ToDecimal(e.Item.Cells[8].Text).ToString("0.00");

                }
                catch
                { }
            }
        }

		#endregion
    }
}
