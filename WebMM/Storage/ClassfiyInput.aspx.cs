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
	/// CategroyInput 的摘要说明。
	/// </summary>
	public partial class ClassfiyInput : System.Web.UI.Page
	{
        ItemSystem oItemSystem = new ItemSystem();
	    private ClassifyData ds;
	    private DataView dv;
	    private DataRow dr;

        private void myDataBind()
		{
			ds = new ClassifyData();
			ds = new ItemSystem().GetClassifyAll();
			dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "ParentID = '无'";
			dllParentClassify.DataSource = dv;
			dllParentClassify.DataTextField = ClassifyData.CODE_FIELD;
			dllParentClassify.DataValueField = ClassifyData.CODE_FIELD;
			dllParentClassify.DataBind();
			dllParentClassify.Items.Add(new ListItem("无","无"));
			dllParentClassify.Items.FindByValue("无").Selected = true;
	
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
					if (!Master.HasBrowseRight(SysRight.ClassfiyMaintain))
					{
						return;
					}
					ds = new ClassifyData();
					ds = (new ItemSystem()).GetClassifyByCode(Master.Code);
					//赋值
					dr = ds.Tables[ClassifyData.CLASSFIY_TABLE].Rows[0];
					txtOldCode.Value = dr[ClassifyData.OLDCODE_FIELD].ToString();
					txtCode.Text = dr[ClassifyData.CODE_FIELD].ToString();
					txtDescription.Text = dr[ClassifyData.DESCRIPTION_FIELD].ToString();
					dllParentClassify.SelectedValue = dr[ClassifyData.PARENT_CODE_FIELD].ToString();
					if (dr[PurposeData.ENABLE_FIELD].ToString() == "1")
					{
						chkEnable.Checked = true;
					}
					else
					{
						chkEnable.Checked = false;
					}
                    this.toolbarButtonAdd.Visible = false;
                    this.toolbarButtonedit.Visible = true;
				}
				else
				{
                    if (!Master.HasBrowseRight(SysRight.ClassfiyMaintain))
					{
						return;
					}
                    this.toolbarButtonAdd.Visible = true;
                    this.toolbarButtonedit.Visible = false;
				}
			}
		}

        private void ClassfiySubmit()
        {
            ds = new ClassifyData();
            dr = ds.Tables[ClassifyData.CLASSFIY_TABLE].NewRow();

            dr[ClassifyData.OLDCODE_FIELD] = txtOldCode.Value;
            dr[ClassifyData.CODE_FIELD] = txtCode.Text.ToString().Trim();
            dr[ClassifyData.DESCRIPTION_FIELD] = txtDescription.Text.Trim();
            dr[ClassifyData.PARENT_CODE_FIELD] = dllParentClassify.SelectedValue.ToString().Trim();
            if (this.chkEnable.Checked)
            {
                dr[ClassifyData.ENABLE_FIELD] = 1;
            }
            else
            {
                dr[ClassifyData.ENABLE_FIELD] = 0;
            }

            dr[ClassifyData.LOCKED_FIELD] = "N";

            ds.Tables[ClassifyData.CLASSFIY_TABLE].Rows.Add(dr);

            

            //递交
            if (Master.Op == "Edit")
            {
                if (Master.HasBrowseRight(SysRight.ClassfiyMaintain))
                {
                    if (oItemSystem.UpdateClassify(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
            }
            else
            {
                if (Master.HasBrowseRight(SysRight.ClassfiyMaintain))
                {
                    if (oItemSystem.AddClassify(ds) == false)
                    {
                        Response.Redirect("../Common/ErrorPage.aspx?ErrorInfo=" + oItemSystem.Message);
                    }
                }
               
            }
            Response.Redirect("ClassifyBrowser.aspx");
        }
		
            /*
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ClassifyBrowser.aspx");
		}*/

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "edit":
                    ClassfiySubmit();
                    break;
                case "add":
                    ClassfiySubmit();
                    break;

            }
        }
	}
}
