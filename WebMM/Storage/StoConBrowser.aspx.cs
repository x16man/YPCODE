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
	public partial class StoConBrowser : System.Web.UI.Page
	{

		//protected int Code;
        ItemSystem oItemSystem = new ItemSystem();
		public string StoCode//仓库编号。
		{
			set
			{
				ViewState["StoCode"] = value;
			}
			get
			{
				if(ViewState["StoCode"]!=null)
					return ViewState["StoCode"].ToString();
				else
					return "";

			}
		}

        private void Purview()
        {
            if (!Master.HasRight(SysRight.ConMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtoncopy.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }


        }


		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Storage;
            if (!this.IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.ConBrowser))
                {
                    return;
                }

                Purview();

                StoCode = Master.StoCode;
                myDataBind();
            }
            else
            {
                this.DataGrid1.AutoDataBind = myDataBind;
            }
		}

		


		private void myDataBind()
		{
			
			//初始化样式。
			DataGrid1.DataSource=oItemSystem.GetStoConByStoCode(StoCode);

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


       
       

	

        //private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        //{
        //    ((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
        //    myDataBind();	
        //}
	
		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
            if (Master.HasBrowseRight(SysRight.ConMaintain))
            {
               
                if (!oItemSystem.DeleteStoCon(tb_SelectedArray.Text))
                {
                    Response.Write("<script>alert('" + oItemSystem.Message + "');</script>");
                }
                tb_SelectedArray.Text = "";
                myDataBind();
            }
		}

		
	}
}
