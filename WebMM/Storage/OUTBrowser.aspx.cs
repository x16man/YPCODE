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
	public partial class OUTBrowser : System.Web.UI.Page
	{
		#region 成员变量
		protected System.Web.UI.WebControls.Button btn_delete;
		protected System.Web.UI.WebControls.Button btn_cancel;
		protected System.Web.UI.WebControls.Button btn_Submit;
       
        string EntryNo;
        string DocCode;

        ItemSystem oItemSystem = new ItemSystem();
		#endregion

		#region 私有方法
		private void myDataBind()
		{
			
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL))
                DataGrid1.DataSource = oItemSystem.GetOutDataByStoManagerWithTODO(Master.CurrentUser.thisUserInfo.EmpCode);
			else
                DataGrid1.DataSource = oItemSystem.GetWDRWBySQL(MzhToolbar1.SE_SQL);
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
            if (!Master.HasRight(SysRight.StockOut))
            {
                this.toolbarButtonOut.Visible = false;
            }
        }

		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			Session[MySession.Help] = HelpCode.OUT;
            if (!IsPostBack)
            {

                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.StockOutBorwse))
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

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            //Response.Write(sqlStatement);
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }

		#endregion

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //				e.Item.Attributes.Add("id",e.Item.Cells[0].Text);
                //				e.Item.Attributes.Add("onmouseover","execMouseOver(this)");
                //				e.Item.Attributes.Add("onmouseout","execMouseOut(this)");
                //e.Item.Attributes.Add("ondblclick","window.open('DRWDetail.aspx?EntryNo=" + e.Item.Cells[0].Text +"','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");

                DocCode = e.Item.Cells[0].Text.ToString().Split('|')[1];
                EntryNo = e.Item.Cells[0].Text.ToString().Split('|')[0];

                //e.Item.Attributes.Add("ondblclick", "window.open('DRWDetail.aspx?EntryNo=" + EntryNo + "','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");

                switch (DocCode)
                {
                    case "4":
                        e.Item.Attributes.Add("ondblclick", "window.open('DRWDetail.aspx?Op=View&EntryNo=" + EntryNo + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                    case "8":
                        e.Item.Attributes.Add("ondblclick", "window.open('RTSDetail.aspx?Op=View&EntryNo=" + EntryNo + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                    case "10":
                        e.Item.Attributes.Add("ondblclick", "window.open('WTRFDetail.aspx?Op=View&EntryNo=" + EntryNo + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                    case "7":
                        e.Item.Attributes.Add("ondblclick", "window.open('../Purchase/PRTVDetail.aspx?Op=View&EntryNo=" + EntryNo + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                }
                //				e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
                //				e.Item.Attributes.Add("onclick","execClick(this)");
            }
        }
		
	}
}
