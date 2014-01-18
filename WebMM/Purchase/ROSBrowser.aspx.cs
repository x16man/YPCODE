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
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	//using MZHCommon.PageStyle;
	using MySys = Shmzh.Components.SystemComponent;
	using MZHCommon;
    using SysRight = MZHMM.WebMM.Common.SysRight;

	/// <summary>
	/// ROSBrowser 的摘要说明。
	/// </summary>
	public partial class ROSBrowser : System.Web.UI.Page
	{
		#region 成员变量
		
        //protected string action_new_hasRight;
        //private int DocCode;
        //private string AuthorCode;
        //private int AuditResult;
        //private string AuthorDept;
        //private DateTime StartDate;
        //private DateTime EndDate;

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
                if(Master.HasRight(SysRight.ROSBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetRequestOfStockAll(Master.CurrentUser.LoginName);
                }
                else if(Master.HasRight(SysRight.ROSBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetRequestOfStockByPerson(Master.CurrentUser.EmpCode);
                }

            }
            else if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.ROSBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetRequestOfStockBySQL(this.MzhToolbar1.SE_SQL);
                }
                else if (Master.HasRight(SysRight.ROSBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetRequestOfStockBySQL(Master.GetSql(this.MzhToolbar1.SE_SQL));
                }
            }
            else
            {

                if (Master.HasRight(SysRight.ROSBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetRequestOfStockByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                }
                else if (Master.HasRight(SysRight.ROSBrowser))
                {
                    if(Master.AuthorCode != "")
                        DataGrid1.DataSource = oPurchaseSystem.GetRequestOfStockByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                    else
                        DataGrid1.DataSource = oPurchaseSystem.GetRequestOfStockByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.CurrentUser.EmpCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                    
                }
            }
			//this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0? true:false;
			
			DataGrid1.DataBind();
					
		}

        private void Purview()
        {
            if (!Master.HasRight(SysRight.ROSMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.ROSPresent))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.ROSCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

            if (!Master.HasRight(SysRight.ROSFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.ROSSecondAudit))
            {
                this.toolbarButtonSecondAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.ROSThirdAudit))
            {
                this.toolbarButtonThirdAudit.Visible = false;
            }
            if(!Master.HasRight(SysRight.ROSWZAudit))
            {
                this.toolbarButtonWZAudit.Visible = false;
            }

        }
		#endregion
	
		#region 事件
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);
                this.DataGrid1.Columns[7].Visible = Master.DisplayRosPrice;
                if (!Master.HasBrowseRight(new int[] { SysRight.ROSBrowser, SysRight.ROSBrowserByDept }))
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


		#region DadaGrid事件 "绑定","换页","排序"
        /// <summary>
        /// 绑定。
        /// </summary>
        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('ROSDetail.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=no,location=no, status=no')");
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
                        e.Item.Cells[2].Text == "财务通过" ||
                        e.Item.Cells[2].Text == "物资通过")
                {
                    e.Item.Cells[2].ForeColor = Color.LightBlue;
                }
                else
                {
                    e.Item.Cells[2].ForeColor = Color.Orange;
                }
            }
        }
		#endregion

		


		

		

		#endregion

        protected void btn_delete_Click(object sender, EventArgs e)
        {
          
            if(Master.HasRight(SysRight.ROSMaintain))
            {
                if (!oPurchaseSystem.DeleteRequestOfStock(int.Parse(tb_SelectedArray.Value)))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

            if (Master.HasRight(SysRight.ROSCancel))
            {
                if (!oPurchaseSystem.CancelRequestOfStock(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (Master.HasRight(SysRight.ROSPresent))
            {
                if (!oPurchaseSystem.PresentRequestOfStock(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.EmpCode))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "Submit", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }


        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.MzhToolbar1.SE_SQL = sqlStatement;
             myDataBind();
        }

      

		
	}
}
