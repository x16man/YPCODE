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
using MZHMM.WebMM.Modules;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyInput 的摘要说明。
	/// </summary>
	public partial class StoManagerInput : System.Web.UI.Page
	{

        ItemSystem oItemSystem = new ItemSystem();

	    private StoManagerData oStoManagerData;

	    private DataRow oDataRow;

        /// <summary>
        /// 仓库编号.
        /// </summary>
        public string StoCode
        {
            get { return this.ViewState["StoCode"].ToString(); }
            set { this.ViewState["StoCode"] = value; }
        }

		protected void Page_Load(object sender, System.EventArgs e)
		{
			
		    ddlSto.Width = new Unit("50%");
            ddlUser.Width = new Unit("50%");
			if(!Page.IsPostBack) 
			{
                Master.SetTitleContent(this.Title);
				if(Master.Op =="Edit")
				{
                    if (!Master.HasBrowseRight(SysRight.StoManagerMaintain))
					{
						return;
					}
					BindDataUpdate();
                    this.toolbarButtonAdd.Visible = false;
                    this.toolbarButtonedit.Visible = true;
				}
				else
				{
                    if (!Master.HasBrowseRight(SysRight.StoManagerMaintain))
					{
						return;
					}
                    this.StoCode = Master.StoCode;
					BindDataNew();
                    this.toolbarButtonAdd.Visible = true;
                    this.toolbarButtonedit.Visible = false;
				}
			}
		}
		private void BindDataNew()
		{
			//仓库。
			this.ddlSto.Module_Tag= (int)SDDLTYPE.STORAGE;
			this.ddlSto.SelectedValue = this.StoCode;
            this.ddlSto.Enable = false;
           
			//this.ddlSto.Enable = false;
			//用户。
			this.ddlUser.Module_Tag=(int)SDDLTYPE.USER;
		}
		private void BindDataUpdate()
		{
			oStoManagerData = new StoManagerData();
			oStoManagerData = oItemSystem.GetStoManagerByPKID(int.Parse(Master.Code));
			oDataRow = oStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows[0];

			this.ddlSto.Module_Tag = (int)SDDLTYPE.STORAGE;
			this.ddlSto.SelectedValue = oDataRow[StoManagerData.STOCODE_FIELD].ToString();					//仓库。
            this.ddlSto.Enable = false;
			this.StoCode = oDataRow[StoManagerData.STOCODE_FIELD].ToString();
			//this.ddlSto.Enable = false;
			this.ddlUser.Module_Tag = (int)SDDLTYPE.USER;
			this.ddlUser.SelectedValue = oDataRow[StoManagerData.USERCODE_FIELD].ToString();				//管理员。
		}

		
		private void StoManagerSubmit()
		{
            oStoManagerData = new StoManagerData();
            oDataRow = oStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].NewRow();

            if (Master.Op == "Edit")
                oDataRow[StoManagerData.PKID_FIELD] = Master.Code;
            oDataRow[StoManagerData.STOCODE_FIELD] = this.ddlSto.SelectedValue.ToString();
            oDataRow[StoManagerData.USERCODE_FIELD] = this.ddlUser.SelectedValue.ToString();


            oStoManagerData.Tables[StoManagerData.STOMANAGER_TABLE].Rows.Add(oDataRow);

           

            //递交
            if (Master.Op == "Edit")
            {
                if (Master.HasBrowseRight(SysRight.StoManagerMaintain))
                {
                    if (oItemSystem.UpdateStoManager(oStoManagerData) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                    else
                    {
                        Response.Redirect("StoManagerBrowser.aspx?StoCode=" + this.StoCode);
                    }
                }
                
            }
            else
            {
                if (Master.HasBrowseRight(SysRight.StoManagerMaintain))
                {
                    if (oItemSystem.AddStoManager(oStoManagerData) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                    else
                    {
                        Response.Redirect("StoManagerBrowser.aspx?StoCode=" + this.StoCode);
                    }
                }
               
            }
		}

		

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("StoManagerBrowser.aspx?StoCode="+this.ddlSto.SelectedValue);
		}

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "edit":
                    StoManagerSubmit();
                    break;
                case "add":
                    StoManagerSubmit();
                    break;
            }
        }
	}
}
