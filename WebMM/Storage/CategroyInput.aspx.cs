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
	public partial class CategroyInput : System.Web.UI.Page
	{

        private CategoryData ds = new CategoryData();

	    private ItemSystem oItemSystem;

	    private DataRow dr;

		protected void Page_Load(object sender, System.EventArgs e)
		{
		
			if(!Page.IsPostBack)
			{
                Master.SetTitleContent(this.Title);
				if(Master.Op !="New")
				{
                   
                    if (!Master.HasBrowseRight(SysRight.CategoryMaintain))
                    {
                        return;
                    }
					ds = (new ItemSystem()).QueryCategoryByCode(int.Parse(Master.Code));
					//赋值
					dr=ds.Tables[CategoryData.CATEGORIES_TABLE].Rows[0];
					txtCode.Text=dr[CategoryData.CODE_FIELD].ToString();
					txtDescription.Text=dr[CategoryData.DESCRIPTION_FIELD].ToString();
					txtStorageAcc.Text=dr[CategoryData.STORAGEACC_FIELD].ToString();
					txtReturnAcc.Text=dr[CategoryData.RETURNACC_FIELD].ToString();
					txtTransferAcc.Text=dr[CategoryData.TRANSFERACC_FIELD].ToString();
					txtSerial.Text=dr[CategoryData.SERIAL_FIELD].ToString();
					txtRemark.Text=dr[CategoryData.REMARK_FIELD].ToString();
					if(Master.Op =="Edit")	txtCode.Enabled=false;

                    this.toolbarButtonAdd.Visible = false;
                    this.toolbarButtonedit.Visible = true;
				}
				else
				{
                    if (!Master.HasBrowseRight(SysRight.CategoryMaintain))
                    {
                        return;
                    }

                    this.toolbarButtonAdd.Visible = true;
                    this.toolbarButtonedit.Visible = false;
                }
			}
		}


        private void CategroySubmit()
        {
            ds = new CategoryData();
            dr = ds.Tables[CategoryData.CATEGORIES_TABLE].NewRow();

            dr[CategoryData.CODE_FIELD] = txtCode.Text;
            dr[CategoryData.DESCRIPTION_FIELD] = txtDescription.Text;

            if (txtStorageAcc.Text.Trim().Length != 0) dr[CategoryData.STORAGEACC_FIELD] = txtStorageAcc.Text.Trim();
            if (txtTransferAcc.Text.Trim().Length != 0) dr[CategoryData.TRANSFERACC_FIELD] = txtTransferAcc.Text.Trim();
            if (txtReturnAcc.Text.Trim().Length != 0) dr[CategoryData.RETURNACC_FIELD] = txtReturnAcc.Text.Trim();
            if (txtRemark.Text.Trim().Length != 0) dr[CategoryData.REMARK_FIELD] = txtRemark.Text.Trim();

            if (txtSerial.Text.Trim().Length != 0) dr[CategoryData.SERIAL_FIELD] = txtSerial.Text.Trim();

            ds.Tables[CategoryData.CATEGORIES_TABLE].Rows.Add(dr);

            oItemSystem = new ItemSystem();

            //递交
            if (Master.Op == "Edit")
            {
                if (Master.HasRight(SysRight.CategoryMaintain))
                {
                    if (oItemSystem.EditCategory(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
                else
                {
                    Response.Redirect("../Common/NoRight.aspx");
                }
            }
            else
            {
                if (Master.HasRight(SysRight.CategoryMaintain))
                {
                    if (oItemSystem.AddCategory(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
                else
                {
                    Response.Redirect("../Common/NoRight.aspx");
                }
            }
            Response.Redirect("CategroyBrowser.aspx");
        }

	    protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CategroyBrowser.aspx");
		}

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "edit":
                    CategroySubmit();
                    break;
                case "add":
                    CategroySubmit();
                    break;

            }
        }
	}
}
