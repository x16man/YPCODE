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
	/// YJ ��ժҪ˵����
	/// </summary>
	public partial class YJ : System.Web.UI.Page
	{
	    private ItemSystem oItemSystem = new ItemSystem();
        int Year;
        int Month;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
                this.lblReturn.Text = this.ddlYear.SelectedValue + "��" + this.ddlMonth.SelectedValue + "�� �½�ɹ�!";
            }
            else
            {
                this.lblReturn.Text = this.ddlYear.SelectedValue + "��" + this.ddlMonth.SelectedValue + "�� �½�ʧ��!";
            }
        }

		

	}
}
