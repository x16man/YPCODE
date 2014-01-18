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
using Shmzh.MM.Facade;
//using MZHCommon.PageStyle;
using Shmzh.MM.Common;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyEdit 的摘要说明。
	/// </summary>
	public partial class CategroyBrowser : System.Web.UI.Page
	{
        
        ItemSystem oItemSystem = new ItemSystem();
	    
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Category;
            if (!this.IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.CategoryBrowser))
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

        private void Purview()
        {
            if (!Master.HasRight(SysRight.CategoryMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtoncopy.Visible = false;
                this.toolbarButtondelete.Visible = false;
           }


        }
	

		private void myDataBind()
		{
			
			
			DataGrid1.DataSource=oItemSystem.QueryAllCategories();
          
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

	

		

		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
            if (Master.HasBrowseRight(SysRight.CategoryMaintain))
            {
                if (!oItemSystem.DeleteCategory(tb_SelectedArray.Value))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "msg", "alert('" + oItemSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }

        protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            myDataBind();
        }

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                e.Item.Attributes.Add("ondblclick", "window.open('CategroyDetails.aspx?Code=" + e.Item.Cells[0].Text + "','browser','height=350,width=550,left='+(window.screen.width - 550)/2+',top='+(window.screen.height - 260)/2+',toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no')");
			
        }

        protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            myDataBind();
        }

      

       

	}
}
