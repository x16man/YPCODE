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
//using Shmzh.Components.SelectEngine;

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

namespace MZHMM.WebMM.Project
{
	/// <summary>
	/// DRWBrowser ��ժҪ˵����
	/// </summary>
	public partial class ProjectItem : Page
	{
		#region ��Ա����
		private decimal subTotal = 0;
		#endregion

		#region ����
		protected string PrjCode
		{
			get {return this.Request["PNo"];}
		}
		#endregion

		#region ˽�з���
		/// <summary>
		/// DataGrid���ݰ󶨡�
		/// </summary>
		private void myDataBind()
		{
			ItemSystem oItemSystem = new ItemSystem();
			//����û�û���趨Ĭ�ϵĲ�ѯ������������ģ��Ĭ�ϵĲ�ѯ������
			this.DataGrid1.DataSource = oItemSystem.GetProjectItemByPrjCode(this.PrjCode);
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
		
		#region �¼�
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myDataBind();
            }
            else
            {
                this.DataGrid1.AutoDataBind = myDataBind;
            }
        }

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    this.subTotal += decimal.Parse(e.Item.Cells[7].Text);
                }
                catch
                {
                    this.subTotal += 0;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[7].Text = this.subTotal.ToString();
            }
        }
	    #endregion
	}
}
