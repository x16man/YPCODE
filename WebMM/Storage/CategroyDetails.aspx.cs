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
using Shmzh.MM.Common;
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace MZHMM.WebMM.Storage
{
	/// <summary>
	/// CategroyDetails 的摘要说明。
	/// </summary>
	public partial class CategroyDetails : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	    private CategoryData ds;
	
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!this.IsPostBack)
			{
                if (Master.ReqTitle == "")
                    Master.SetTitleContent(this.Title);

                if (!Master.HasBrowseRight(SysRight.CategoryBrowser))
                {
                    return;
                }

				ds = new CategoryData();
				ds = (new ItemSystem()).QueryCategoryByCode(int.Parse(Master.Code));
				//赋值
				DataRow dr=ds.Tables[CategoryData.CATEGORIES_TABLE].Rows[0];
				txtCode.Text=dr[CategoryData.CODE_FIELD].ToString();
				txtDescription.Text=dr[CategoryData.DESCRIPTION_FIELD].ToString();
				txtStorageAcc.Text=dr[CategoryData.STORAGEACC_FIELD].ToString();
				txtReturnAcc.Text=dr[CategoryData.RETURNACC_FIELD].ToString();
				txtTransferAcc.Text=dr[CategoryData.TRANSFERACC_FIELD].ToString();
				txtSerial.Text=dr[CategoryData.SERIAL_FIELD].ToString();
				txtRemark.Text=dr[CategoryData.REMARK_FIELD].ToString();
			}
		}
    }
}
