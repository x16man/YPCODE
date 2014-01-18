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
using Shmzh.Web.UI.Controls;
using MZHMM.WebMM.Modules;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyEdit 的摘要说明。
	/// </summary>
	public partial class PurposeBrowser : System.Web.UI.Page
	{

        ItemSystem oItemSystem = new ItemSystem();
        #region Private method
        #endregion

        private void Purview()
        {
            if (!Master.HasRight(SysRight.PurposeMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtoncopy.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }


        }
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Session[MySession.Help] = HelpCode.Purpose;
            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.PurposeBrowser))
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
			//如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL))
            {
                if (this.tbiIncludeDisable.Checked)
                    DataGrid1.DataSource = oItemSystem.GetPurposeAll();
                else
                {
                    DataGrid1.DataSource = oItemSystem.GetPurposeAvalible();
                }
            }
			else
                DataGrid1.DataSource = oItemSystem.GetPurposeBySQL(MzhToolbar1.SE_SQL);
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
					try
					{
						DataGrid1.DataBind();
					}
					catch
					{
						DataGrid1.CurrentPageIndex = 0;
						DataGrid1.DataBind();
					}
				}				
			}			
		}

		protected void btn_delete_Click(object sender, System.EventArgs e)
		{
            if (Master.HasBrowseRight(SysRight.PurposeMaintain))
            {
               
                if (!oItemSystem.DeletePurpose(tb_SelectedArray.Text))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "msg", "alert('" + oItemSystem.Message + "')", true);
                }
                tb_SelectedArray.Text = "";
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


        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string sqlStatement)
        {
            this.MzhToolbar1.SE_SQL = sqlStatement;
            myDataBind();
        }

	    protected void MzhToolbar1_OnItemPostBack(ToolbarItem item)
	    {
	        myDataBind();
	    }
	}
}
