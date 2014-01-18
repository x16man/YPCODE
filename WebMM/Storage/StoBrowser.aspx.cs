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
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyEdit 的摘要说明。
	/// </summary>
	public partial class StoBrowser : System.Web.UI.Page
	{
        ItemSystem oItemSystem = new ItemSystem();

        private void Purview()
        {
            if (!Master.HasRight(SysRight.StoMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtoncopy.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }

            if (!Master.HasRight(SysRight.StoManagerBrowser))
            {
                toolbarButtonManager.Visible = false;
            }

            if (!Master.HasRight(SysRight.ConBrowser))
            {
                toolbarButtonCon.Visible = false;
            }
        }
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Storage;
            if (!this.IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.StoBrowser))
                {
                    return;
                }

                Purview();

                myDataBind();
            }
            else
                DataGrid1.AutoDataBind = myDataBind;
		}

		

		private void myDataBind()
		{
		
			
            DataGrid1.DataSource=oItemSystem.GetStoAll();
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
					DataGrid1.DataBind();
				}				
			}			
		}



    

		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
            if (Master.HasBrowseRight(SysRight.StoMaintain))
            {
               
                if (!oItemSystem.DeleteSto(tb_SelectedArray.Value))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "msg", "alert('" + oItemSystem.Message.Replace("\r\n","") + "');", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
           
		}

		

     
        protected void DataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            myDataBind();
        }

        protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            myDataBind();
        }

       


	}
}
