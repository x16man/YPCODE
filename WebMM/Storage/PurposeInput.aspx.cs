using System;
using System.Data;
using Shmzh.MM.Facade;
using Shmzh.MM.Common;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyInput 的摘要说明。
	/// </summary>
	public partial class PurposeInput : System.Web.UI.Page
	{
        ItemSystem oItemSystem = new ItemSystem();
	    private ClassifyData ds;

	    private DataView dv;

	    private PurposeData dsdata;

	    private DataRow dr;

		private void myDataBind()
		{
			ds = new ClassifyData();
			//ds = new ItemSystem().GetClassifyAll();
            ds = new ItemSystem().GetClassifyAvalible();
			dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "ParentID <> '无'";
			dllUsingClassify.DataSource = dv;
			dllUsingClassify.DataTextField = ClassifyData.DESCRIPTION_FIELD;
			dllUsingClassify.DataValueField = ClassifyData.CODE_FIELD;
			dllUsingClassify.DataBind();
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Session[MySession.Help] = HelpCode.Purpose;
			
			if(!Page.IsPostBack) 
			{
			    Master.SetTitleContent(this.Title);
				myDataBind();
				if(Master.Op != "New")//不是增加操作。
				{
                    if (!Master.HasBrowseRight(SysRight.PurposeMaintain))
					{
						return;
					}
                    dsdata = new PurposeData();
                    dsdata = (new ItemSystem()).GetPurposeByCode(Master.Code);
					//赋值
                    dr = dsdata.Tables[PurposeData.USE_TABLE].Rows[0];
					txtOldCode.Value = dr[PurposeData.OLDCODE_FIELD].ToString();
					txtCode.Text = dr[PurposeData.CODE_FIELD].ToString();
					txtDescription.Text = dr[PurposeData.DESCRIPTION_FIELD].ToString();
					txtTargetAcc.Text = dr[PurposeData.TARGETACC_FIELD].ToString();
					txtProjectCode.Text = dr[PurposeData.PROJECT_CODE_FIELD].ToString();
					this.txtthisYear.Text = dr[PurposeData.thisYear_Field].ToString();
                    try
                    {
                        this.dllUsingClassify.SelectedValue = dr[PurposeData.CLASSIFY_FIELD].ToString();
                    }
                    catch { }
					if (dr[PurposeData.ENABLE_FIELD].ToString() == "1")
					{
						chkEnable.Checked = true;
					}
					else
					{
						chkEnable.Checked = false;
					}
					if (dr[PurposeData.FLAG_FIELD].ToString() == "1")
					{
						this.chkFlag.Checked = true;
					}
					else
					{
						this.chkFlag.Checked = false;
					}
					if(Master.Op == "Edit")	txtCode.Enabled = false;

                    this.toolbarButtonAdd.Visible = false;
                    this.toolbarButtonedit.Visible = true;
				}
				else
				{
                    if (!Master.HasBrowseRight(SysRight.PurposeMaintain))
					{
						return;
					}
					this.txtthisYear.Text = DateTime.Today.Year.ToString();
                    this.toolbarButtonAdd.Visible = true;
                    this.toolbarButtonedit.Visible = false;
				}
			}
		}

		private void PurposeSubmit()
		{
            dsdata = new PurposeData();
            dr = dsdata.Tables[PurposeData.USE_TABLE].NewRow();

            dr[PurposeData.OLDCODE_FIELD] = txtOldCode.Value;
            dr[PurposeData.CODE_FIELD] = txtCode.Text;
            dr[PurposeData.DESCRIPTION_FIELD] = txtDescription.Text.Trim();
            dr[PurposeData.CLASSIFY_FIELD] = dllUsingClassify.SelectedValue.Trim();
            if (txtProjectCode.Text.Trim().Length != 0)
                dr[PurposeData.PROJECT_CODE_FIELD] = txtProjectCode.Text.Trim();
            else
                dr[PurposeData.PROJECT_CODE_FIELD] = txtCode.Text;

            if (txtTargetAcc.Text.Trim().Length != 0)
                dr[PurposeData.TARGETACC_FIELD] = txtTargetAcc.Text.Trim();
            if (this.chkEnable.Checked)
            {
                dr[PurposeData.ENABLE_FIELD] = 1;
            }
            else
            {
                dr[PurposeData.ENABLE_FIELD] = 0;
            }
            if (this.chkFlag.Checked)
            {
                dr[PurposeData.FLAG_FIELD] = 1;
            }
            else
            {
                dr[PurposeData.FLAG_FIELD] = 0;
            }
            try
            {
                
                if (this.txtthisYear.Text != "")
                    dr[PurposeData.thisYear_Field] = int.Parse(this.txtthisYear.Text);
            }
            catch
            { }
            dr[PurposeData.LOCKED_FIELD] = "N";

            dsdata.Tables[PurposeData.USE_TABLE].Rows.Add(dr);

          

            //递交
            if (Master.Op == "Edit")
            {
                if (Master.HasBrowseRight(SysRight.PurposeMaintain))
                {
                    if (oItemSystem.UpdatePurpose(dsdata) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
                //else
                //{
                //    Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + this.AlertMessage);
                //}
            }
            else
            {
                if (Master.HasBrowseRight(SysRight.PurposeMaintain))
                {
                    if (oItemSystem.AddPurpose(dsdata) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
                //else
                //{
                //    Response.Redirect("../ErrorPage.aspx?ErrorInfo=" + this.AlertMessage);
                //}
            }
            Response.Redirect("PurposeBrowser.aspx");
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("PurposeBrowser.aspx");
		}

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "edit":
                    PurposeSubmit();
                    break;
                case "add":
                    PurposeSubmit();
                    break;

            }
        }

	}
}
