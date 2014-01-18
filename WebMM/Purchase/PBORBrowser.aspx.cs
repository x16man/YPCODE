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


namespace MZHMM.WebMM.Purchase
{
	/// <summary>
	/// ROSBrowser 的摘要说明。
	/// </summary>
	public partial class PBORBrowser : Page
	{
		#region 成员变量
	    private PurchaseSystem oPurchaseSystem = new PurchaseSystem();
		#endregion

		#region 私有方法
		/// <summary>
		/// 数据绑定到DataGrid。
		/// </summary>
		private void myDataBind()
		{
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.BORBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetBRAll(Master.CurrentUser.thisUserInfo.LoginName);
                }
                else if (Master.HasRight(SysRight.BORBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetEntryByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.BORBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetBRBySQL(MzhToolbar1.SE_SQL);
                }
                else if (Master.HasRight(SysRight.BORBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetBRBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
                }
            }
            else
            {
                if(Master.AuthorCode != "")
                    DataGrid1.DataSource = oPurchaseSystem.GetBRByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                else
                    DataGrid1.DataSource = oPurchaseSystem.GetBRByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.CurrentUser.EmpCode, Master.AuditResult, Master.StartDate, Master.EndDate);
            }
            DataGrid1.DataBind();
		}

        private void Purview()
        {
            if (!Master.HasRight(SysRight.BORMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.BORPresent))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.BORCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

            if (!Master.HasRight(SysRight.BORFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.BORCancelOpera))
            {
                this.toolbarButtonRed.Visible = false;
            }

            if (!Master.HasRight(SysRight.BORInvDetail))
            {
                toolbarButtonInvDetail.Visible = false;
            }

            if (!Master.HasRight(SysRight.BORUpdateInvoice))
            {
                toolbarButtonUpdateInvDetail.Visible = false;
            }
        }
		#endregion
	
		#region 事件

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                this.DataGrid1.Columns[8].Visible = Master.DisplayBORPrice;
                if (!Master.HasBrowseRight(SysRight.BORBrowser))
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
		/// 隐含的删除按钮clicked事件。
		/// </summary>
		protected void btn_delete_Click(object sender, EventArgs e)
		{
            if (!oPurchaseSystem.DeleteBR(int.Parse(tb_SelectedArray.Value)))
			{
                ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
		/// <summary>
		/// 隐含的提交按钮clicked事件。
		/// </summary>
		protected void btn_Submit_Click(object sender, EventArgs e)
		{
            if (!oPurchaseSystem.PresentBR(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.EmpCode))
			{
                ClientScript.RegisterStartupScript( this.GetType(), "Submit", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();	
		}
		/// <summary>
		/// 隐含的作废按钮clicked事件。
		/// </summary>
		protected void btn_cancel_Click(object sender, EventArgs e)
		{
            if (!oPurchaseSystem.CancelBR(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
			{
                ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
		
		protected void btn_Fin_Click(object sender, System.EventArgs e)
		{

            if (!oPurchaseSystem.PayBR(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
			{
                ClientScript.RegisterStartupScript( this.GetType(), "Fin", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}

		#endregion

		protected void Button1_Click(object sender, System.EventArgs e)
		{
            ClientScript.RegisterStartupScript(this.GetType(), "Button1", "window.history.go(-2);", true);
		}

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('PBORDetail.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=600,width=950,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=no,location=no, status=no')");
               
                //ParentNo.
                if (e.Item.Cells[9].Text.Replace("&nbsp;","") != "0" && !string.IsNullOrEmpty(e.Item.Cells[9].Text.Replace("&nbsp;","")))
                {
                    e.Item.Cells[1].ForeColor = e.Item.Cells[8].ForeColor = Color.Red;
                    
                }

                if (e.Item.Cells[2].Text == "新建" ||
                    e.Item.Cells[2].Text == "提交")
                {
                    e.Item.Cells[2].ForeColor = Color.Orange;
                }
                else if (e.Item.Cells[2].Text == "审批通过")
                {
                    e.Item.Cells[2].ForeColor = Color.Blue;
                }
                else if (e.Item.Cells[2].Text == "作废")
                {
                    e.Item.Cells[2].ForeColor = Color.Gray;
                }
                else if (e.Item.Cells[2].Text == "部门通过" ||
                    e.Item.Cells[2].Text == "财务通过")
                {
                    e.Item.Cells[2].ForeColor = Color.LightBlue;
                }
                else if (e.Item.Cells[2].Text == "收料")
                {
                    e.Item.Cells[2].ForeColor = Color.Green;
                }
                else
                {
                    e.Item.Cells[2].ForeColor = Color.Purple;
                }
            }
        }

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }
	}
}
