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
	/// POBrowser ��ժҪ˵����
	/// </summary>
	public partial class POBrowser : Page
	{
		#region ��Ա����
		protected Button btn_present;
		
        
        private PurchaseSystem oPurchaseSystem = new PurchaseSystem();
        #endregion

		#region ˽�з���
		private void myDataBind()
		{
			
			//����û�û���趨Ĭ�ϵĲ�ѯ������������ģ��Ĭ�ϵĲ�ѯ������
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.POBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPOAll(Master.CurrentUser.thisUserInfo.LoginName);
                }
                else if (Master.HasRight(SysRight.POBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPOByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if (Master.HasRight(SysRight.POBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPOBySQl(MzhToolbar1.SE_SQL);
                }
                else if (Master.HasRight(SysRight.POBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPOBySQl(Master.GetSql(MzhToolbar1.SE_SQL));
                }
            }
            else
            {
                if (Master.HasRight(SysRight.POBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPOByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                }
                else  if (Master.HasRight(SysRight.POBrowser))
                {
                    if(Master.AuthorCode != "")
                        DataGrid1.DataSource = oPurchaseSystem.GetPOByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                    else
                        DataGrid1.DataSource = oPurchaseSystem.GetPOByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.CurrentUser.EmpCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                    
                }
                
            }
			this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0? true:false;
            DataGrid1.DataBind();
					
		}

        private void Purview()
        {
            if (!Master.HasRight(SysRight.POMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.POAssign))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.POCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

            if (!Master.HasRight(SysRight.POFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.POConfirm))
            {
                this.toolbarButtonConfirm.Visible = false;
            }

            if (!Master.HasRight(SysRight.POCancelOpera))
            {
                this.toolbarButtonCancelOpera.Visible = false;
            }


        }
		#endregion

		#region �¼�

		protected void Page_Load(object sender, EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			Session[MySession.Help] = HelpCode.PO;

            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);
                this.DataGrid1.Columns[8].Visible = Master.DisplayPOPrice; 

                if (!Master.HasBrowseRight(SysRight.POBrowser))
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

	    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('PODetail.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=yes,location=no, status=no')");
                if (e.Item.Cells[9].Text != "0")
                {
                    e.Item.Cells[1].ForeColor = Color.Red;
                }
                if (e.Item.Cells[2].Text == "�½�" ||
                e.Item.Cells[2].Text == "�ύ")
                {
                    e.Item.Cells[2].ForeColor = Color.Orange;
                }
                else if (e.Item.Cells[2].Text == "ȷ��")
                {
                    e.Item.Cells[2].ForeColor = Color.Green;
                }
                else if (e.Item.Cells[2].Text == "����")
                {
                    e.Item.Cells[2].ForeColor = Color.Gray;
                }
                else if (e.Item.Cells[2].Text == "����ͨ��")
                {
                    e.Item.Cells[2].ForeColor = Color.LightBlue;
                }
                else if (e.Item.Cells[2].Text == "ָ��")
                {
                    e.Item.Cells[2].ForeColor = Color.Orange;
                }
                else if (e.Item.Cells[2].Text == "�ܾ�")
                {
                    e.Item.Cells[2].ForeColor = Color.Purple;
                }
                else
                {
                    e.Item.Cells[2].ForeColor = Color.Orange;
                }
            }
            
        }

    	/// <summary>
		/// �ɹ��������ϡ�
		/// </summary>
		protected void btn_cancel_Click(object sender, EventArgs e)
		{
            if (Master.HasRight(SysRight.POCancel))
            {
                if (!oPurchaseSystem.CancelPO(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
		}
		/// <summary>
		/// �ɹ�������ɾ����
		/// </summary>
		protected void btn_delete_Click(object sender, EventArgs e)
		{
            if (Master.HasRight(SysRight.POMaintain))
            {
                if (!oPurchaseSystem.DeletePO(int.Parse(tb_SelectedArray.Value)))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
		}
		/// <summary>
		/// �ɹ������Ĳɹ�Աȷ�ϡ�
		/// </summary>
		protected void btn_distribute_Click(object sender, EventArgs e)
		{
//			PurchaseSystem oPurchaseSystem = new PurchaseSystem();
//
//			if( !oPurchaseSystem.AffirmPO(int.Parse(tb_SelectedArray.Text),Session[MySession.UserLoginId].ToString() ))
//			{
//				Response.Write("<script>alert('"+oPurchaseSystem.Message+"');</script>");
//			}
//			tb_SelectedArray.Text="";
//			myDataBind();	
		}

		/// <summary>
		/// ָ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_Submit_Click(object sender, EventArgs e)
		{
            if (Master.HasRight(SysRight.POAssign))
            {
                if (!oPurchaseSystem.PresentPO(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.EmpCode))
                {
                    //Response.Write("<script>alert('"+oPurchaseSystem.Message+"');</script>");
                    // Page.RegisterStartupScript("Submit","<script>alert('"+oPurchaseSystem.Message+"');</script>");
                    ClientScript.RegisterStartupScript( this.GetType(), "Submit", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
		}
		
	

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			//this.Response.Write("<script>window.history.go(-2);</script>");
			// Page.RegisterStartupScript("Button1","<script>window.history.go(-2);</script
            ClientScript.RegisterStartupScript( this.GetType(), "Button1", "window.history.go(-2);", true);
		}

		#endregion 

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }

	}
}