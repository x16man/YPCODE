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
	/// 仓库架位的输入。
	/// </summary>
	public partial class StoConInput : System.Web.UI.Page
	{
	    private StoConData ds;

	    private DataRow dr;

        ItemSystem oItemSystem = new ItemSystem();
        /// <summary>
        /// 仓库编号.
        /// </summary>
        public string StoCode
        {
            get { return this.ViewState["StoCode"].ToString(); }
            set { this.ViewState["StoCode"] = value; }
        }

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack) 
			{
				if(Master.Op != "New")
				{
                    if (!Master.HasBrowseRight(SysRight.ConMaintain))
					{
						//this.Response.Write(this.AlertMessage);
						//this.Response.Write("<script>window.history.go(-1);</script>");
						//Page.RegisterStartupScript("op_New",this.AlertMessage+" <script>window.history.go(-1);</script>");
						return;
					}
					ds = new StoConData();
					ds = (new ItemSystem()).GetStoConByCode(int.Parse(Master.Code));
					//赋值
					dr = ds.Tables[StoConData.STOCON_TABLE].Rows[0];
					this.txtStoCode.Text = dr[StoConData.STOCODE_FIELD].ToString();
					this.txtCode.Value = dr[StoConData.CODE_FIELD].ToString();
                    StoCode = txtStoCode.Text;
					this.txtDescription.Text = dr[StoConData.DESCRIPTION_FIELD].ToString();
					this.txtStoArea.Text = dr[StoConData.AREA_FIELD].ToString();
                    this.toolbarButtonAdd.Visible = false;
                    this.toolbarButtonedit.Visible = true;
				}
				else
				{
                    if (!Master.HasBrowseRight(SysRight.ConMaintain))
					{
					    return;
					}
                    StoCode = Master.StoCode;
					this.txtStoCode.Text = Master.StoCode;
                    this.toolbarButtonAdd.Visible = true;
                    this.toolbarButtonedit.Visible = false;
				}
			}
		}

		private void StoConSubmit()
		{
            ds = new StoConData();
            dr = ds.Tables[StoConData.STOCON_TABLE].NewRow();
            if (Master.Op == "Edit")
            {
                dr[StoConData.CODE_FIELD] = txtCode.Value;
            }
            dr[StoConData.DESCRIPTION_FIELD] = txtDescription.Text;
            dr[StoConData.STOCODE_FIELD] = this.txtStoCode.Text;
            if (this.txtStoArea.Text.Trim() != "")
                dr[StoConData.AREA_FIELD] = this.txtStoArea.Text;
            else
                dr[StoConData.AREA_FIELD] = "0";
            dr[StoConData.STATUS_FIELD] = INV_CD.ALL_CODE;//全部。
            dr[StoConData.LOCKED_FIELD] = "N";//是否锁定。
            ds.Tables[StoConData.STOCON_TABLE].Rows.Add(dr);

          

            //递交
            if (Master.Op == "Edit")
            {
                if (Master.HasBrowseRight(SysRight.ConMaintain))
                {
                    if (oItemSystem.UpdateStoCon(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
                
            }
            else
            {
                if (Master.HasBrowseRight(SysRight.ConMaintain))
                {
                    if (oItemSystem.AddStoCon(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
              
            }
            Response.Redirect("StoConBrowser.aspx?StoCode=" + StoCode.ToString());
		}

		

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
            Response.Redirect("StoConBrowser.aspx?StoCode=" + StoCode.ToString());
		}

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "edit":
                    StoConSubmit();
                    break;
                case "add":
                    StoConSubmit();
                    break;

            }
        }
	}
}
