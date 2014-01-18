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
	using Shmzh.Components.SystemComponent;
    using Shmzh.MM.Facade;
    using Shmzh.MM.Common;
	using MZHMM.WebMM.Storage;
    using SysRight = MZHMM.WebMM.Common.SysRight;
	/// <summary>
	/// 采购员输入的WEB表示层。
	/// </summary>
	public partial class PslpInput : System.Web.UI.Page
	{
		#region 成员变量
		private string op = "New";
		
        PslpData oPslpData = new PslpData();
        PurchaseSystem oPurchaseSystem = new PurchaseSystem();
	    private DataRow oDataRow;
      
		#endregion

		

		#region 事件

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "add":
                    PslpSubmit();
                    break;
                
            }
        }

	    /// <summary>
		/// 页面的Load事件处理。
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//根据不同的状态进行数据绑定。
			if(!Page.IsPostBack)
			{
                Master.SetTitleContent(this.Title);
                txtDescription.Attributes.Add("Readonly", "Readonly");
                txtCode.Attributes.Add("Readonly", "Readonly");
				if(Master.Op != "New" )
				{
				    
					if (!Master.HasBrowseRight(SysRight.BuyerMaintain))
					{
						
						return;
					}

                    this.toolbarButtonAdd.Visible = false;
				    
					oPslpData = ((IPslpSystem)oPurchaseSystem).GetPslpByCode(Master.Code);
					//赋值
					oDataRow = oPslpData.Tables[PslpData.PSLP_TABLE].Rows[0];
					this.txtCode.Text = oDataRow[PslpData.CODE_FIELD].ToString();					//采购员代码。
					this.txtDescription.Text = oDataRow[PslpData.DESCRIPTION_FIELD].ToString();		//采购员姓名。
				}
				else
				{
                    
                    if (!Master.HasBrowseRight(SysRight.BuyerMaintain))
					{
						return;
					}
				}
			}
		}
		
        public void PslpSubmit()
        {
            if(this.txtCode.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('请选择人员');", true);
                return;
            }
            oDataRow = oPslpData.Tables[PslpData.PSLP_TABLE].NewRow();
            //将页面上的数据压到DataRow中。
             oDataRow[PslpData.CODE_FIELD] = this.txtCode.Text;						//采购员代  码。
            oDataRow[PslpData.DESCRIPTION_FIELD] = this.txtDescription.Text;		//采购员名  称。

            oPslpData.Tables[PslpData.PSLP_TABLE].Rows.Add(oDataRow);

           if (Master.HasBrowseRight(SysRight.BuyerMaintain))
           {
               if (((IPslpSystem)oPurchaseSystem).GetPslpByCode(this.txtCode.Text).Tables[0].Rows.Count == 0)
               {
                   if (((IPslpSystem)oPurchaseSystem).AddPslp(oPslpData) == false)
                   {
                       Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oPurchaseSystem.Message);
                   }
               }
               else
               {
                   Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=已经存在此人员");
                   
                   //ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('已经存在此人员');", true);
               
                  // ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('已经存在此人员');", true);
                   return;
               }
              
           }
           Response.Redirect("PslpBrowser.aspx");
        }
        #endregion
	}
}
