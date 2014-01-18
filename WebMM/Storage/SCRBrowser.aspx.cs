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
* penalties.  Any violations of this copyright will be pSCRecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2004-2005 MZH, Inc. All Rights Reserved


namespace MZHMM.WebMM.Item
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
    using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// SCRBrowser 的摘要说明。
	/// </summary>
	public partial class SCRBrowser : System.Web.UI.Page
	{
		#region 成员变量
        ItemSystem oItemSystem = new ItemSystem();
        #endregion

		#region 私有方法
		/// <summary>
		/// 数据绑定到DataGrid。
		/// </summary>
		private void myDataBind()
		{
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL))
            {
                if (Master.HasRight(SysRight.SCRBrowserByDept))
                {
                    DataGrid1.DataSource = oItemSystem.GetWSCRAll(Master.CurrentUser.thisUserInfo.LoginName);
                }
                else if (Master.HasRight(SysRight.SCRBrowser))
                {
                    DataGrid1.DataSource =  oItemSystem.GetWSCRByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else
            {
                if (Master.HasRight(SysRight.SCRBrowserByDept))
                {
                    DataGrid1.DataSource = oItemSystem.GetWSCRBySQL(MzhToolbar1.SE_SQL);
                }
                else if (Master.HasRight(SysRight.SCRBrowser))
                {
                    DataGrid1.DataSource = oItemSystem.GetWSCRBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
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
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.DataGrid1.PageIndexChanged+=new DataGridPageChangedEventHandler(DataGrid1_PageIndexChanged);

		}
		#endregion
	
		#region 事件

        private void Purview()
        {
            if (!Master.HasRight(SysRight.SCRMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.SCRPresent))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.SCRCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

            if (!Master.HasRight(SysRight.SCRFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.SCRSecondAudit))
            {
                this.toolbarButtonSecondAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.SCRThirdAudit))
            {
                this.toolbarButtonThirdAudit.Visible = false;
            }
        }

		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面


            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.SCRBrowser))
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

		/// <summary>
		/// 隐含的删除按钮clicked事件。
		/// </summary>
		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
			
            if (!oItemSystem.DeleteWSCR(int.Parse(tb_SelectedArray.Value)))
			{
				ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
		/// <summary>
		/// 隐含的提交按钮clicked事件。
		/// </summary>
		protected void btn_Submit_Click(object sender, System.EventArgs e)
		{

            if (!oItemSystem.PresentWSCR(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.EmpCode))
			{
				//Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
				//Page.RegisterStartupScript("Submit","<script>alert('"+oItemSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "Submit", "alert('" + oItemSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();	
		}
		/// <summary>
		/// 隐含的作废按钮clicked事件。
		/// </summary>
		protected void btn_cancel_Click(object sender, System.EventArgs e)
		{


            if (!oItemSystem.CancelWSCR(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
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
                e.Item.Cells[6].Visible = Master.DisplaySCRPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[6].Visible = Master.DisplaySCRPrice;
                //				e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
                //				e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
                //				e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
                e.Item.Attributes.Add("ondblclick", "window.open('SCRDetail.aspx?EntryNo=" + e.Item.Cells[0].Text + "','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");

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
                else if (e.Item.Cells[2].Text == "领料")
                {
                    e.Item.BackColor = Color.FromArgb(193, 108, 255);
                }
                else
                {
                    e.Item.BackColor = Color.FromArgb(201, 181, 196);
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[6].Visible = Master.DisplaySCRPrice;
            }
        }
	}
}
