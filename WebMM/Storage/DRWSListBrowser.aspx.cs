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
	/// <summary>
	/// DRWBrowser ��ժҪ˵����
	/// </summary>
	public partial class DRWSListBrowser : System.Web.UI.Page
	{
		#region ��Ա����

// MZHWEB.NET.Controls.MzhDataGrid DataGrid1;
		#endregion

		#region ����
		/// <summary>
		/// ���ű��
		/// </summary>
		private string DeptCode
		{
			get {return this.ViewState["DeptCode"].ToString();}
			set {this.ViewState["DeptCode"] = value;}
		}
		#endregion

		#region ˽�з���
		private void myDataBind()
		{
			ItemSystem oItemSystem = new ItemSystem();
			WDRWData oWDRWData = new WDRWData();
			oWDRWData = oItemSystem.GetWDRWSourceListByDeptCode(this.DeptCode);
			DataGrid1.DataSource = oWDRWData.Tables[WDRWData.WDS_VIEW];

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
		
		#region �¼�
		/// <summary>
		/// Page_Load�¼���
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if ( !this.IsPostBack )
			{
				if (!string.IsNullOrEmpty(this.Request["DeptCode"]))
				{
					this.DeptCode = this.Request["DeptCode"];

					this.myDataBind();
				}
				else
				{
				    this.DataGrid1.AutoDataBind = myDataBind;
				}
			}
		}
		#endregion
    }
}



