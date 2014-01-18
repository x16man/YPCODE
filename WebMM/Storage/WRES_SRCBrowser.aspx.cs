using System;
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

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// DRWBrowser ��ժҪ˵����
	/// </summary>
	public partial class WRES_SRCBrowser : Page
	{
		#region ��Ա����

        ItemSystem oItemSystem = new ItemSystem();
        //SelectEngine oSelectEngine = new SelectEngine();

		#endregion

		#region ����
		public string UserLoginId
		{
            get { return Master.CurrentUser.thisUserInfo.LoginName; }
		}
		public int EntryNo
		{
			get {return Convert.ToInt32(this.tb_SelectedArray.Value);}
		}
		#endregion
		#region ˽�з���
		private void myDataBind()
		{
			
			//����û�û���趨Ĭ�ϵĲ�ѯ������������ģ��Ĭ�ϵĲ�ѯ������
			
			DataGrid1.DataSource=oItemSystem.GetWTOWValidData();
			
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
		protected void Page_Load(object sender, EventArgs e)
		{
			Session[MySession.Help] = HelpCode.DRW;
			// �ڴ˴������û������Գ�ʼ��ҳ��

			if(!IsPostBack)
			{
				myDataBind();	
			}
            else
		    {
		        this.DataGrid1.AutoDataBind = myDataBind;
		    }
		}

        /*
		/// <summary>
		/// ɾ����ť��
		/// </summary>
		private void btn_delete_Click(object sender, EventArgs e)
		{
		

			if(!oItemSystem.DeleteWINW(this.EntryNo, this.UserLoginId))
			{
				Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
			}
            tb_SelectedArray.Value = "";
			myDataBind();
		}
      
                /// <summary>
                /// �ύ��ť��
                /// </summary>
                private void btn_Submit_Click(object sender, EventArgs e)
                {
                    ItemSystem oItemSystem = new ItemSystem();

                    if( !oItemSystem.PresentWDRW(int.Parse(tb_SelectedArray.Text),Session[MySession.UserCode].ToString() ))
                    {
                        Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
                    }
                    tb_SelectedArray.Text="";
                    myDataBind();	
                }

                /// <summary>
                /// ���ϰ�ť��
                /// </summary>
                private void btn_cancel_Click(object sender, EventArgs e)
                {
                    if( !oItemSystem.CancelWINW(this.EntryNo ,this.UserLoginId)	)
                    {
                        Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
                    }
                    tb_SelectedArray.Value = "";
                    myDataBind();
                }*/




        #endregion
    }
}
