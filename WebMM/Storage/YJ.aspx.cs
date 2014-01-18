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
using SysRight = MZHMM.WebMM.Common.SysRight;

namespace WebMM.Storage
{
	/// <summary>
	/// YJ 的摘要说明。
	/// </summary>
	public partial class YJ : System.Web.UI.Page
	{
	    private ItemSystem oItemSystem = new ItemSystem();
        int Year;
        int Month;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if (!Master.HasBrowseRight(SysRight.YJMaintain))
            {
                return;
            }

		}

        protected void btnYJ_Click(object sender, EventArgs e)
        {
           
            Year = Convert.ToInt32(this.ddlYear.SelectedValue);
            Month = Convert.ToInt32(this.ddlMonth.SelectedValue);

          

            if (oItemSystem.YJ(Year, Month) == true)
            {
                this.lblReturn.Text = this.ddlYear.SelectedValue + "年" + this.ddlMonth.SelectedValue + "月 月结成功!";
            }
            else
            {
                this.lblReturn.Text = this.ddlYear.SelectedValue + "年" + this.ddlMonth.SelectedValue + "月 月结失败!";
            }
        }

		

	}
}
