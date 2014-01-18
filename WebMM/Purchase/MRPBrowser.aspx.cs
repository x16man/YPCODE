using System;
using System.Data;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
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
	/// MRPBrowser 的摘要说明。
	/// </summary>
	public partial class MRPBrowser : Page
	{
		#region 成员变量
		private PurchaseSystem oPurchaseSystem = new PurchaseSystem();
		#endregion

		#region 私有方法
		private void myDataBind()
		{
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.MRPBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPMRPAll(Master.CurrentUser.LoginName);
                }
                else if (Master.HasRight(SysRight.MRPBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPMRPByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.MRPBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPMRPBySQL(MzhToolbar1.SE_SQL);
                }
                else if (Master.HasRight(SysRight.MRPBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPMRPBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
                }
            }
            else
            {
                if (Master.HasRight(SysRight.MRPBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPMRPByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                }
                else if (Master.HasRight(SysRight.MRPBrowser))
                {
                    if(Master.AuthorCode != "")
                        DataGrid1.DataSource = oPurchaseSystem.GetPMRPByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                    else
                        DataGrid1.DataSource = oPurchaseSystem.GetPMRPByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.CurrentUser.EmpCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                }
            }

			this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0? true:false;
            this.DataGrid1.DataBind(); 
		}

        private void Purview()
        {
            this.toolbarButtonadd.Visible = this.toolbarButtonedit.Visible = this.toolbarButtondelete.Visible = Master.HasRight(SysRight.MRPMaintain);
            this.toolbarButtonPresent.Visible = Master.HasRight(SysRight.MRPPresent);
            this.toolbarButtonCancel.Visible = Master.HasRight(SysRight.MRPCancel);
            this.toolbarButtonFirstAudit.Visible = Master.HasRight(SysRight.MRPFirstAudit);
            this.toolbarButtonSecondAudit.Visible = Master.HasRight(SysRight.MRPSecondAudit);
        }
		#endregion
		
		#region 事件
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			Session[MySession.Help] = HelpCode.MRP;
            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.MRPBrowser))
                {
                    return;
                }
                Purview();
                this.myDataBind();
                DataGrid1.ShowFooter = false;// DataGrid1.Items.Count > 0;
            }
            else
            {
                this.DataGrid1.AutoDataBind = myDataBind;
            }
		}
        /// <summary>
		/// ItemDataBound事件。
		/// </summary>
        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int amountColumnIndex = 7;
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[amountColumnIndex].Visible = Master.DisplayMRPPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[amountColumnIndex].Visible = Master.DisplayMRPPrice;
                e.Item.Attributes.Add("ondblclick", "window.open('MRPDetail.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=550,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 550)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=no,location=no, status=no')");
                if (e.Item.Cells[2].Text == "新建" ||
                    e.Item.Cells[2].Text == "提交")
                {
                    e.Item.Cells[2].ForeColor = Color.Orange;
                }
                else if (e.Item.Cells[2].Text == "审批通过")
                {
                    e.Item.Cells[2].ForeColor = Color.Green;
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
                else
                {
                    e.Item.Cells[2].ForeColor = Color.Orange;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[amountColumnIndex].Visible = Master.DisplayMRPPrice;
            }
        }
        /// <summary>
        /// 删除按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_delete_Click(object sender, EventArgs e)
        {

            if (Master.HasRight(SysRight.MRPMaintain))
            {
                if (!oPurchaseSystem.DeletePMRP(int.Parse(tb_SelectedArray.Value)))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }
        /// <summary>
        /// 作废按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (Master.HasRight(SysRight.MRPCancel))
            {
                if (!oPurchaseSystem.CancelPMRP(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }
        /// <summary>
        /// 提交按钮事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (Master.HasRight(SysRight.MRPPresent))
            {
                if (!oPurchaseSystem.PresentPMRP(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Submit", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }
        /// <summary>
        /// 查询方案查询事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="sqlStatement"></param>
        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }
        #endregion
    }
}
