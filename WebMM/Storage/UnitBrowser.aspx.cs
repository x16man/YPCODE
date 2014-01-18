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
using Shmzh.MM.Common;
//using MZHCommon.PageStyle;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyEdit 的摘要说明。
	/// </summary>
	public partial class UnitBrowser : System.Web.UI.Page
	{
        private ItemSystem oItemSystem = new ItemSystem();

        private void Purview()
        {

            if (!Master.HasRight(SysRight.UnitMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtoncopy.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }


        }
       
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Unit;
            if (!this.IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.UnitBrowser))
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

	


		private void myDataBind()
		{
			
			
			DataGrid1.DataSource=oItemSystem.QueryAllUnits();

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
            if (Master.HasBrowseRight(SysRight.UnitMaintain))
            {
                if (!oItemSystem.DeleteUnit(tb_SelectedArray.Value))
                {
                    //Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
                    //Page.RegisterStartupScript("delete", "<script>alert('" + oItemSystem.Message + "');</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + oItemSystem.Message + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
          
		}

	

        protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            myDataBind();
        }

        protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            myDataBind();
        }


	}
}
