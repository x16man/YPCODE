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
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyInput 的摘要说明。
	/// </summary>
	public partial class StoInput : System.Web.UI.Page
	{
	    private StoData ds;
	    private DataRow dr;
        ItemSystem oItemSystem = new ItemSystem();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Storage;
			
			if(!Page.IsPostBack) 
			{
                Master.SetTitleContent(this.Title);
				if(Master.Op != "New")//不是增加操作。
				{
                    if (!Master.HasBrowseRight(SysRight.StoMaintain))
					{
						return;
					}
					ds = new StoData();
					ds = (new ItemSystem()).GetStoByCode(Master.Code);
					//赋值
				    dr = ds.Tables[StoData.STO_TABLE].Rows[0];
					txtCode.Text = dr[StoData.CODE_FIELD].ToString();
					txtDescription.Text = dr[StoData.DESCRIPTION_FIELD].ToString();
                    OldDesc.Value = dr[StoData.DESCRIPTION_FIELD].ToString();
					txtStorageAcc.Text = dr[StoData.STOACC_FIELD].ToString();
					txtReturnAcc.Text = dr[StoData.RETURNACC_FIELD].ToString();
					txtTransferAcc.Text = dr[StoData.TRFACC_FIELD].ToString();
					txtAddress.Text = dr[StoData.ADDRESS_FIELD].ToString();
					txtRelation.Text = dr[StoData.RELATION_FIELD].ToString();
					if(Master.Op == "Edit")	txtCode.Enabled = false;
                    this.toolbarButtonedit.Visible = true;
                    this.toolbarButtonAdd.Visible = false;
				}
				else
				{
                    if (!Master.HasBrowseRight(SysRight.StoMaintain))
					{
						return;
					}
				    this.toolbarButtonedit.Visible = false;
				    this.toolbarButtonAdd.Visible = true;
				}
			}
		}

		private void StoSubmit()
		{
            ds = new StoData();
            dr = ds.Tables[StoData.STO_TABLE].NewRow();

            dr[StoData.CODE_FIELD] = txtCode.Text;
            dr[StoData.DESCRIPTION_FIELD] = txtDescription.Text;
            dr[StoData.LOCKED_FIELD] = "N";

            if (txtStorageAcc.Text.Trim().Length != 0) dr[StoData.STOACC_FIELD] = txtStorageAcc.Text.Trim();
            if (txtTransferAcc.Text.Trim().Length != 0) dr[StoData.TRFACC_FIELD] = txtTransferAcc.Text.Trim();
            if (txtReturnAcc.Text.Trim().Length != 0) dr[StoData.RETURNACC_FIELD] = txtReturnAcc.Text.Trim();
            if (txtAddress.Text.Trim().Length != 0) dr[StoData.ADDRESS_FIELD] = txtAddress.Text.Trim();
            if (txtRelation.Text.Trim().Length != 0) dr[StoData.RELATION_FIELD] = txtRelation.Text.Trim();



            ds.Tables[StoData.STO_TABLE].Rows.Add(dr);

           

            //递交
            if (Master.Op == "Edit")
            {
                if (Master.HasBrowseRight(SysRight.StoMaintain))
                {
                    if (oItemSystem.UpdateSto(ds,this.OldDesc.Value) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
               
            }
            else
            {
                if (Master.HasBrowseRight(SysRight.StoMaintain))
                {
                    if (oItemSystem.AddSto(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
               
            }
            Response.Redirect("StoBrowser.aspx");
		}

		

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "edit":
                    StoSubmit();
                    break;
                case "add":
                    StoSubmit();
                    break;

            }
        }
	}
}
