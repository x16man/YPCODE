using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
//using MZHCommon.PageStyle;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Modules;
using Shmzh.Web.UI.Controls;
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
	public partial class PINBrowser : Page
	{
		#region 成员变量
		protected Button btn_delete;
		protected Button btn_cancel;
		protected Button btn_Submit;

        private PurchaseSystem oPurchaseSystem = new PurchaseSystem();


        string DocCode;
        string EntryNo;

		
		#endregion

		#region 私有方法
		/// <summary>
		/// 数据绑定到DataGrid。
		/// </summary>
		private void myDataBind()
		{
			
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL))
				//DataGrid1.DataSource=oPurchaseSystem.GetBRByState(DocStatus.TrdPass);
                DataGrid1.DataSource = oPurchaseSystem.GetInDataByStoManagerWithTODO(Master.CurrentUser.thisUserInfo.EmpCode);
			else
                DataGrid1.DataSource = oPurchaseSystem.GetBRBySQL(MzhToolbar1.SE_SQL);
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
	
		#region 事件
        private void Purview()
        {
            if (!Master.HasRight(SysRight.StockIn))
            {
                this.toolbarButtonBOR.Visible = false;
            }
        }
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			Session[MySession.Help] = HelpCode.IN;

			if(!IsPostBack)
			{

                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.StockInBrowse))
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

                DocCode = e.Item.Cells[0].Text.ToString().Split('|')[1];
                EntryNo = e.Item.Cells[0].Text.ToString().Split('|')[0];

                switch (int.Parse(DocCode))
                {
                    case DocType.BOR:
                        e.Item.Attributes.Add("ondblclick", "window.open('PBORDetail.aspx?Op=View&EntryNO=" + EntryNo + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                    case DocType.RTV:
                        e.Item.Attributes.Add("ondblclick", "window.open('PRTVDetail.aspx?Op=View&EntryNo=" + EntryNo + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                    case DocType.TRF:
                        e.Item.Attributes.Add("ondblclick", "window.open('WTRFDetail.aspx?Op=View&EntryNo=" + EntryNo + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                    case DocType.INVENTRYPROFIT:
                        e.Item.Attributes.Add("ondblclick", "window.open('../Storage/InventoryProfitDetail.aspx?OP=View&EntryNo=" + EntryNo + "','browser','height=600,width=900,left='+(window.screen.width - 900)/2+',top='+(window.screen.height - 600)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                }
                //				e.Item.Attributes.Add("onmousedown","execMouseDown(this)");
                //				e.Item.Attributes.Add("onclick","execClick(this)");
            }
        }
		
	}
}
