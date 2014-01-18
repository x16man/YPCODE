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
	public partial class StoManagerBrowser : System.Web.UI.Page
	{

		//protected string StoCode;
        ItemSystem oItemSystem = new ItemSystem();

        private void Purview()
        {
            if (!Master.HasRight(SysRight.StoManagerMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }
        }

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Storage;
		
			this.txtStoCode.Value = Master.StoCode;
            if (!this.IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.StoManagerBrowser))
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
			DataGrid1.DataSource=oItemSystem.GetStoManagerByStoCode(Master.StoCode);

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

		
		/// <summary>
		/// 删除按钮的操作。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
            if (Master.HasBrowseRight(SysRight.StoManagerMaintain))
            {
              
                if (!oItemSystem.DeleteStoManager(tb_SelectedArray.Value))
                {
                    //Response.Write("<script>alert('"+oItemSystem.Message+"');</script>");
                    //Page.RegisterStartupScript("delete", "<script>alert('" + oItemSystem.Message + "');</script>");
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


	}
}
