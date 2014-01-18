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
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	//using MZHCommon.PageStyle;
    using SysRight = MZHMM.WebMM.Common.SysRight;

	/// <summary>
	/// DRWBrowser 的摘要说明。
	/// </summary>
	public partial class RTSBrowser : System.Web.UI.Page
	{
		#region 成员变量
       
	    private ItemSystem oItemSystem = new ItemSystem();

		
		#endregion

		#region 私有方法
		private void myDataBind()
		{
			
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
			//DataGrid1.DataSource = oItemSystem.GetWRTSAll();
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL))
            {
                if (Master.HasRight(SysRight.RTSBrowserByDept))
                {
                    //Master.CurrentUser.thisUserInfo.DeptCode
                    DataGrid1.DataSource = oItemSystem.GetWRTSByDept(Master.CurrentUser.thisUserInfo.DeptCode);
                }
                else if (Master.HasRight(SysRight.RTSBrowser))
                {
                    DataGrid1.DataSource = oItemSystem.GetWRTSByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else
            {
                if (Master.HasRight(SysRight.RTSBrowserByDept))
                {
                    DataGrid1.DataSource = oItemSystem.GetWRTSBySQL(MzhToolbar1.SE_SQL);
                }
                else if (Master.HasRight(SysRight.RTSBrowser))
                {
                    DataGrid1.DataSource = oItemSystem.GetWRTSBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
                }
            }
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
        private void Purview()
        {
            if (!Master.HasRight(SysRight.RTSMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTSPresent))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTSCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTSFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTSSecondAudit))
            {
                this.toolbarButtonSecondeAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTSThirdAudit))
            {
                this.toolbarButtonThirdAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.StockIn))
            {
                this.toolbarButtoninItem.Visible = false;
            }
            
        }

		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			Session[MySession.Help] = HelpCode.RTS;
            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.RTSBrowser))
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
		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
		

            if (!oItemSystem.DeleteWRTS(int.Parse(tb_SelectedArray.Value)))
			{
				//Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
				//Page.RegisterStartupScript("delete","<script>alert('"+oItemSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
		/// <summary>
		/// 提交按钮。
		/// </summary>
		protected void btn_Submit_Click(object sender, System.EventArgs e)
		{

            if (!oItemSystem.PresentWRTS(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.EmpCode))
			{
				//Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
				//Page.RegisterStartupScript("Submit","<script>alert('"+oItemSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "Submit", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();	
		}
		/// <summary>
		/// 作废按钮。
		/// </summary>
		protected void btn_cancel_Click(object sender, System.EventArgs e)
		{


            if (!oItemSystem.CancelWRTS(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
			{
				//Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
				//Page.RegisterStartupScript("cancel","<script>alert('"+oItemSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
		
		#endregion

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            
            this.MzhToolbar1.SE_SQL = sqlStatement; 
            myDataBind();
        }

        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[7].Visible = Master.DisplayRTSPrice;
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[7].Visible = Master.DisplayRTSPrice;
                //				e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
                //				e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
                //				e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
                e.Item.Attributes.Add("ondblclick", "window.open('RTSDetail.aspx?EntryNo=" + e.Item.Cells[0].Text + "','browser','height=580,width=800,toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 380)/2+'')");
                //				e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
                //				e.Item.Attributes.Add("onclick","execClick(this)");

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
                e.Item.Cells[7].Visible = Master.DisplayRTSPrice;
            }
        }


	}
}
