using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.Components.SelectEngine;
using MZHMM.Common;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.SYS
{
    public partial class SolutionManage : System.Web.UI.Page
    {
        private int moduleID;
        private int solutionID;
        private int i;
        private ListItem olt;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (!Master.HasBrowseRight(SysRight.SolutionMaintain))
                {
                    return;
                }

                ddlDataBind();
            }
        }

        private void BindData()
        {
            MzhDataGrid1.DataSource = (new SelectEngine().GetSolutionByUserAndModule(int.Parse(this.ddlModule.SelectedValue), Master.CurrentUser.thisUserInfo.LoginName).Tables[0]);
            MzhDataGrid1.DataBind();
        }

        private void ddlDataBind()
        {
            SEModuleData ds = new SelectEngine().GetModule();
            //DropDownList1.DataSource = ds.Tables[SEModuleData.SEMODULE_TABLE];
            //DropDownList1.DataTextField = SEModuleData.MODULE_NAME_FIELD;
            //DropDownList1.DataValueField = SEModuleData.MODULE_ID_FIELD;
            //DropDownList1.DataBind();
            ddlModule.Items.Clear();
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                olt = new ListItem(ds.Tables[SEModuleData.SEMODULE_TABLE].Rows[i][SEModuleData.MODULE_NAME_FIELD].ToString(), ds.Tables[SEModuleData.SEMODULE_TABLE].Rows[i][SEModuleData.MODULE_ID_FIELD].ToString());
                ddlModule.Items.Add(olt);
            }
            MzhDataGrid1.DataSource = (new SelectEngine().GetSolutionByUserAndModule(int.Parse(ds.Tables[0].Rows[0][SEModuleData.MODULE_ID_FIELD].ToString()), Master.CurrentUser.thisUserInfo.LoginName).Tables[0]);
            MzhDataGrid1.DataBind();

        }

        private void Solution_Delete()
        {
            if (!string.IsNullOrEmpty(MzhDataGrid1.SelectedID.ToString()))
            {
                solutionID = int.Parse(MzhDataGrid1.SelectedID.ToString());
                moduleID = 0;
                if (!string.IsNullOrEmpty(ddlModule.SelectedValue))
                    moduleID = int.Parse(ddlModule.SelectedValue);
                new SelectEngine().DeleteSolution(moduleID, Master.CurrentUser.thisUserInfo.LoginName, solutionID);
                BindData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Button1, this.GetType(), Guid.NewGuid().ToString(), "alert(\"请选中一条记录再进行操作！\");", true);
                
                //RegisterStartupScript(Guid.NewGuid().ToString(), "<script language=JavaScript>" + "alert('请选中一条记录再进行操作');" + "</script>");
                
            }
        }

        private void SetDafault()
        {
            if (!string.IsNullOrEmpty(MzhDataGrid1.SelectedID.ToString()))
            {
                solutionID = int.Parse(MzhDataGrid1.SelectedID.ToString());
                moduleID = 0;
                if (!string.IsNullOrEmpty(ddlModule.SelectedValue))
                    moduleID = int.Parse(ddlModule.SelectedValue);
                new SelectEngine().SetAsDefaultSolution(moduleID, Master.CurrentUser.thisUserInfo.LoginName, solutionID);
                BindData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Button1, this.GetType(), Guid.NewGuid().ToString(), "alert(\"请选中一条记录再进行操作！\");", true);
                
               // RegisterStartupScript(Guid.NewGuid().ToString(), "<script language=JavaScript>" + "alert('请选中一条记录再进行操作');" + "</script>");
                //ScriptManager.RegisterStartupScript(this.btn_delete, this.GetType(), "msg", "alert('" + oItemSystem.Message + "');", true);
            }
               
			
        }

        private void CancelDefault()
        {
            if (string.IsNullOrEmpty(MzhDataGrid1.SelectedID.ToString()))
            {
                //RegisterStartupScript(Guid.NewGuid().ToString(), "<script language=JavaScript>" + "alert('请选中一条记录再进行操作');" + "</script>");
                ScriptManager.RegisterStartupScript(this.Button1, this.GetType(), Guid.NewGuid().ToString(), "alert(\"请选中一条记录再进行操作！\");", true);
                return;
            }
            else
            {
                moduleID = 0;
                if (!string.IsNullOrEmpty(ddlModule.SelectedValue))
                    moduleID = int.Parse(ddlModule.SelectedValue);
                new SelectEngine().CancelDefaultSolution(moduleID, Master.CurrentUser.thisUserInfo.LoginName);
                BindData();
            }
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "delete":
                    Solution_Delete();
                    break;
                case "setdefault":
                    SetDafault();
                    break;
                case "canceldefault":
                    CancelDefault();
                    break;
                case "ddlmodule":
                    BindData();
                    break;
            }
        }

        protected void MzhDataGrid1_PageSizeChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void MzhDataGrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            BindData();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        
    }
}
