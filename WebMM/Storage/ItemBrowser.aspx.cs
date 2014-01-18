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

namespace WebMM.Storage
{
    public partial class ItemBrowser : System.Web.UI.Page
    {
        //private string strSQL;
        ItemSystem oItemSystem = new ItemSystem();
       
        private void Purview()
        {
            if (!Master.HasRight(SysRight.ItemMaintain))
            {
                this.toolbarButtonadd.Visible = false;
                this.toolbarButtonedit.Visible = false;
                this.toolbarButtoncopy.Visible = false;
                this.toolbarButtondelete.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session[MySession.Help] = HelpCode.Item;
            if (!IsPostBack)
            {
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.ItemBrowse))
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

        #region 私有方法
        private void myDataBind()
        {
            //如果用户没有设定默认的查询方案，则启用模块默认的查询方案。
            if (string.IsNullOrEmpty(this.MzhToolbar1.SE_SQL))
                DataGrid1.DataSource = oItemSystem.GetItemsNums(100);
            else
                DataGrid1.DataSource = oItemSystem.GetItemsBySQL(MzhToolbar1.SE_SQL);
            //this.DataGrid1.AllowPaging = ((DataSet)DataGrid1.DataSource).Tables[0].Rows.Count > 0 ? true : false;
            try
            {
                DataGrid1.DataBind();
            }
            catch (Exception e)
            {
                if (e.Source == "System.Web" && DataGrid1.CurrentPageIndex >= 1)
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
        #endregion

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if(!Master.HasMaintainRight(SysRight.CstPrice,false))
                    e.Item.Cells[8].Visible = false;
            }
            else if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (!Master.HasMaintainRight(SysRight.CstPrice, false))
                    e.Item.Cells[8].Visible = false;
                 e.Item.Attributes.Add("ondblclick", "window.open('ItemDetails.aspx?Code=" + e.Item.Cells[0].Text + "','browser','height=500,width=800,toolbar=no,menubar=yes,scrollbars=no, resizable=no,location=no, status=no,left='+(window.screen.width - 800)/2+',top='+(window.screen.height - 380)/2+'')");
            }
            else if(e.Item.ItemType == ListItemType.Footer)
            {
                if (!Master.HasMaintainRight(SysRight.CstPrice, false))
                    e.Item.Cells[8].Visible = false;
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

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (Master.HasRight(SysRight.ItemMaintain))
            {
                if (!oItemSystem.DeleteItem(tb_SelectedArray.Value))
                {
                    ClientScript.RegisterStartupScript( this.GetType(), "msg", "alert('" + oItemSystem.Message + ")", true);
                }
                tb_SelectedArray.Value = "";
                myDataBind();
            }
        }

        protected void MzhToolbar1_OnSEQuery_Click(object sender, EventArgs e, string strsqlParameter)
        {
            MzhToolbar1.SE_SQL = strsqlParameter;
            myDataBind();
        }
    }
}
