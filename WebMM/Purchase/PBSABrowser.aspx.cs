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
	/// <summary>
	/// MRPBrowser ��ժҪ˵����
	/// </summary>
	public partial class PBSABrowser : System.Web.UI.Page
	{
		#region ��Ա����

        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
		#endregion

		#region ����
		public string PrvCode
		{
			get {return this.Request["PrvCode"];}
		}
		#endregion

		#region ˽�з���
		private void myDataBind()
		{
			
			
			this.DataGrid1.DataSource = oPurchaseSystem.GetPBSAEntryByPrvCode(PrvCode);
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
		
		#region �¼�
		/// <summary>
		/// Page_Load�¼���
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
    }
}
