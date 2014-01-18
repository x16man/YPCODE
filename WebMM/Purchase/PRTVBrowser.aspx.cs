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
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;
	//using MZHCommon.PageStyle;
	using MZHCommon;
    using SysRight = MZHMM.WebMM.Common.SysRight;

	/// <summary>
	/// ROSBrowser ��ժҪ˵����
	/// </summary>
	public partial class PRTVBrowser : System.Web.UI.Page
	{
		#region ��Ա����
		PurchaseSystem oPurchaseSystem = new PurchaseSystem();

		#endregion

		#region ˽�з���
		/// <summary>
		/// ���ݰ󶨵�DataGrid��
		/// </summary>
		private void myDataBind()
		{
			
			//����û�û���趨Ĭ�ϵĲ�ѯ������������ģ��Ĭ�ϵĲ�ѯ������
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if(Master.HasRight(SysRight.RTVBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPRTVByDept(Master.CurrentUser.thisUserInfo.DeptCode);
                }
                else if(Master.HasRight(SysRight.RTVBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPRTVByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }
            }
            else if (!string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL) && Master.AuthorCode == "" && Master.AuthorDept == "")
            {
                if(Master.HasRight(SysRight.RTVBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPRTVBySQL(MzhToolbar1.SE_SQL);
                }
                else if(Master.HasRight(SysRight.RTVBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPRTVBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
                }
            }
            else
            {
                if(Master.HasRight(SysRight.RTVBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.getPRTVByDeptAndAuthorAndAuditResult(Master.AuthorDept, Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
                }
                else if(Master.HasRight(SysRight.RTVBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.getPRTVByDeptAndAuthorAndAuditResult("", Master.AuthorCode, Master.AuditResult, Master.StartDate, Master.EndDate);
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

        private void Purview()
        {
            if (!Master.HasRight(SysRight.RTVMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTVPresent))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTVCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

          

            if (!Master.HasRight(SysRight.RTVFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTVSecondAudit))
            {
                this.toolbarButtonSecondAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.RTVThirdAudit))
            {
                this.toolbarButtonThirdAudit.Visible = false;
            }


            if (!Master.HasRight(SysRight.StockOut))
            {
                this.toolbarButtonDrawItem.Visible = false;
            }



        }
		#endregion
	
	
	
		#region �¼�
		/// <summary>
		/// Page_Load�¼���
		/// </summary>
		/// <summary>
		/// Page_Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			Session[MySession.Help] = HelpCode.RTV;

            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.RTVBrowser))
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


		#region DadaGrid�¼� "��","��ҳ","����"
        protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            myDataBind();
        }

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[8].Visible = Master.DisplayPRTVPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[8].Visible = Master.DisplayPRTVPrice;
                e.Item.Attributes.Add("ondblclick", "window.open('PRTVDetail.aspx?EntryNo=" + e.Item.Cells[0].Text + "','browser','height=560,width=850,left='+(window.screen.width - 850)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");

                if (e.Item.Cells[2].Text == "�½�" ||
                    e.Item.Cells[2].Text == "�ύ")
                {
                    e.Item.BackColor = Color.FromArgb(216, 244, 255);
                }
                else if (e.Item.Cells[2].Text == "����ͨ��")
                {
                    e.Item.BackColor = Color.FromArgb(181, 255, 136);
                }
                else if (e.Item.Cells[2].Text == "����")
                {
                    e.Item.BackColor = Color.FromArgb(212, 208, 200);
                }
                else if (e.Item.Cells[2].Text == "����ͨ��" ||
                    e.Item.Cells[2].Text == "����ͨ��")
                {
                    e.Item.BackColor = Color.FromArgb(153, 204, 255);
                }
                else if (e.Item.Cells[2].Text == "����")
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
                e.Item.Cells[8].Visible = Master.DisplayPRTVPrice;
            }
        }

        protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            myDataBind();
        }
		#endregion

		/// <summary>
		/// ������ɾ����ťclicked�¼���
		/// </summary>
		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
			
            if (!oPurchaseSystem.DeletePRTV(int.Parse(tb_SelectedArray.Value),Master.CurrentUser.thisUserInfo.EmpCode))
			{
				ClientScript.RegisterStartupScript( this.GetType(), "delete", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
		/// <summary>
		/// �������ύ��ťclicked�¼���
		/// </summary>
		protected void btn_Submit_Click(object sender, System.EventArgs e)
		{


            if (!oPurchaseSystem.PresentPRTV(int.Parse(tb_SelectedArray.Value),Master.CurrentUser.thisUserInfo.LoginName, Master.CurrentUser.thisUserInfo.EmpCode))
			{
                ClientScript.RegisterStartupScript(this.GetType(), "Submit", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();	
		}
		/// <summary>
		/// ���������ϰ�ťclicked�¼���
		/// </summary>
		protected void btn_cancel_Click(object sender, System.EventArgs e)
		{


            if (!oPurchaseSystem.CancelPRTV(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName, Master.CurrentUser.thisUserInfo.EmpCode))
			{
				//Response.Write("<script>alert('"+oPurchaseSystem.Message+"');</script>");
				 //Page.RegisterStartupScript("cancel","<script>alert('"+oPurchaseSystem.Message+"');</script>");
                ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oPurchaseSystem.Message + "');", true);
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}


        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            //Response.Write(sqlStatement);
            MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }

		#endregion

      
		
	}
}
