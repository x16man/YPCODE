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
	using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// PPBrowser ��ժҪ˵����
	/// </summary>
	public partial class PPBrowser : System.Web.UI.Page
	{
		#region ��Ա����

        //private string strSQL;

        PurchaseSystem oPurchaseSystem = new PurchaseSystem();

		#endregion

		#region ˽�з���
		private void myDataBind()
		{
			
			//����û�û���趨Ĭ�ϵĲ�ѯ������������ģ��Ĭ�ϵĲ�ѯ������
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL))
            {
                if(Master.HasRight(SysRight.PPBrowserByDept))
                {
				    DataGrid1.DataSource=oPurchaseSystem.GetPPAll(Master.CurrentUser.thisUserInfo.LoginName);
                }
                else if (Master.HasRight(SysRight.PPBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPPByPerson(Master.CurrentUser.thisUserInfo.EmpCode);
                }

            }
			else
            {
                if (Master.HasRight(SysRight.PPBrowserByDept))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPPBySQL(MzhToolbar1.SE_SQL);
                }
                else if (Master.HasRight(SysRight.PPBrowser))
                {
                    DataGrid1.DataSource = oPurchaseSystem.GetPPBySQL(Master.GetSql(MzhToolbar1.SE_SQL));
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
					try
					{
						DataGrid1.DataBind();
					}
					catch
					{
						DataGrid1.CurrentPageIndex = 0;
						DataGrid1.DataBind();
					}
				}				
			}	
		}
		#endregion

        #region Ȩ���ж�
        private void Purview()
        {
            if (!Master.HasRight(SysRight.PPMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.PPPresent))
            {
                this.toolbarButtonPresent.Visible = false;
            }

            if (!Master.HasRight(SysRight.PPCancel))
            {
                this.toolbarButtonCancel.Visible = false;
            }

            if (!Master.HasRight(SysRight.PPFirstAudit))
            {
                this.toolbarButtonFirstAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.PPSecondAudit))
            {
                this.toolbarButtonSecondAudit.Visible = false;
            }

            if (!Master.HasRight(SysRight.PPThirdAudit))
            {
                this.toolbarButtonThirdAudit.Visible = false;
            }
        }
		#endregion

		#region �¼�
		/// <summary>
		/// Page_Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			Session[MySession.Help] = HelpCode.PP;
            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.PPBrowser))
                {
                    return;
                }

                Purview();
                myDataBind();
            }
            else
            {
                this.DataGrid1.AutoDataBind = myDataBind;
            }
		}
		
		protected void Button1_Click(object sender, System.EventArgs e)
		{
            ClientScript.RegisterStartupScript( this.GetType(), "Button1", "window.history.go(-2);", true);
		}

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (Master.HasRight(SysRight.PPMaintain))
            {
                if (!oPurchaseSystem.DeletePP(int.Parse(tb_SelectedArray.Value)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "delete", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

            if (Master.HasRight(SysRight.PPCancel))
            {
                if (!oPurchaseSystem.CancelPP(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "cancel", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }

        protected void btn_present_Click(object sender, EventArgs e)
        {

            if (Master.HasRight(SysRight.PPPresent))
            {
                if (!oPurchaseSystem.PresentPP(int.Parse(tb_SelectedArray.Value), Master.CurrentUser.thisUserInfo.LoginName))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "present", "alert('" + oPurchaseSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            if (sqlStatement != "")
            {
                this.MzhToolbar1.SE_SQL = sqlStatement;
                myDataBind();
            }
        }
		
        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[4].Visible = Master.DisplayPPPrice;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[4].Visible = Master.DisplayPPPrice;
                e.Item.Attributes.Add("ondblclick", "window.open('PPReport.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes, resizable=yes,location=no, status=no')");
                try
                { e.Item.Cells[4].Text = Convert.ToDecimal((e.Item.Cells[4].Text)).ToString("0.00"); }
                catch
                { }
                if (e.Item.Cells[2].Text == "�½�" ||
                    e.Item.Cells[2].Text == "�ύ")
                {
                    e.Item.Cells[2].ForeColor = Color.Orange;
                }
                else if (e.Item.Cells[2].Text == "����ͨ��")
                {
                    e.Item.Cells[2].ForeColor = Color.Green;
                }
                else if (e.Item.Cells[2].Text == "����")
                {
                    e.Item.Cells[2].ForeColor = Color.Gray;
                }
                else if (e.Item.Cells[2].Text == "����ͨ��" ||
                    e.Item.Cells[2].Text == "����ͨ��")
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
                e.Item.Cells[4].Visible = Master.DisplayPPPrice;
            }
        }
        #endregion
    }
}
