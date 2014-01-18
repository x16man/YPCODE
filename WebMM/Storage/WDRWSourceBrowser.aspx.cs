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
	using MZHMM.WebMM.Modules;
	using MZHCommon.Database;
	/// <summary>
	/// MRPBrowser 的摘要说明。
	/// </summary>
	public partial class WDRWSourceBrowser : System.Web.UI.Page
	{
		#region 成员变量

	    private Hashtable oHT;
	    private DataSet DS;
		#endregion

		#region 属性
		/// <summary>
		/// 当前的用户名。
		/// </summary>
		public string UserID
		{
			get {return User.Identity.Name;}
		}
		/// <summary>
		/// 当前部门编号。
		/// </summary>
		public string DeptCode
		{
			get {return this.Request["DeptCode"].ToString();}
		}
		#endregion

		#region 私有方法
		private void myDataBind()
		{
			//PurchaseSystem oPurchaseSystem = new PurchaseSystem();
			oHT = new Hashtable();
			//oHT.Add("@DeptCode",this.DeptCode);
			oHT.Add("@UserID", this.UserID);

			DS = new SQLServer().ExecSPReturnDS("Sto_RTSGetSourceByUser",oHT);
			//DataSet DS = new SQLServer().ExecSPReturnDS("Sto_RTSGetSourceByDept",oHT);
			
			this.DataGrid1.DataSource = DS.Tables[0].DefaultView;
			try
			{
				this.DataGrid1.DataBind();
			}
			catch(Exception e)
			{
				if(e.Source=="System.Web" && this.DataGrid1.CurrentPageIndex>=1)
				{
					this.DataGrid1.CurrentPageIndex--;
					try
					{
						this.DataGrid1.DataBind();
					}
					catch
					{
						this.DataGrid1.CurrentPageIndex = 0;
						this.DataGrid1.DataBind();
					}
				}				
			}		
		}
		#endregion
		
		#region 事件
		/// <summary>
		/// Page_Load事件。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.Page.IsPostBack)
			{
				this.myDataBind();
			}
			else
			{
			    this.DataGrid1.AutoDataBind = myDataBind;
			}
		}
		#endregion

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("ondblclick", "window.open('DRWDetail.aspx?Op=View&EntryNo=" + e.Item.Cells[0].Text + "','browser','height=560,width=800,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 560)/2+',toolbar=no,menubar=yes,scrollbars=yes, resizable=yes,location=no, status=no')");
            }
        }
	}
}
