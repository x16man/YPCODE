using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using Shmzh.MM.Facade;
using System.Data;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace WebMM.Storage
{
    public partial class ClassifyBrowser : System.Web.UI.Page
    {
        private ItemSystem oItemSystem = new ItemSystem();

        private void Purview()
        {
            if (!Master.HasRight(SysRight.ClassfiyMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtoncopy.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.ClassfiyBrowser))
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
           
            DataGrid1.DataSource = oItemSystem.GetClassifyAll();
            this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0 ? true : false;
            try
            {
                DataGrid1.DataBind();
            }
            catch (Exception e)
            {
                if (e.Source == "System.Web" && DataGrid1.CurrentPageIndex >= 1)
                {
                    DataGrid1.CurrentPageIndex--;
                    DataGrid1.DataBind();
                }
            }			
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (Master.HasBrowseRight(SysRight.ClassfiyMaintain))
            {
                if (!oItemSystem.DeleteClassify(tb_SelectedArray.Value))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "msg", "alert('" + oItemSystem.Message + "');", true);
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
