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
    /// YJBaocun ��ժҪ˵����
    /// </summary>
    public partial class YJBaocun : System.Web.UI.Page
    {
        DateTime BeginDate;
        DateTime EndDate;

        private ItemSystem oItemSystem = new ItemSystem();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (!this.IsPostBack)
            {
                if (!Master.HasBrowseRight(SysRight.YJBaocunMaintain))
                {
                    return;
                }
                this.AddYj.Attributes.Add("onclick", "return confirm('�����������ǰ������,ȷ��Ҫ������?')");
                this.AddYj_Km1NoNull.Attributes.Add("onclick", "return confirm('ȷ��Ҫ����������?')");
            }
            
        }

    

    

        protected void AddYj_Click(object sender, System.EventArgs e)
        {
            BeginDate = Convert.ToDateTime(this.drplYear.SelectedValue + "-" + this.drpMonth.SelectedValue + "-01");
            if (BeginDate == new DateTime(2012, 8, 1))
            {
                EndDate = new DateTime(2012, 8, 26);
            }
            else if (BeginDate == new DateTime(2012, 12, 1))
            {
                BeginDate = new DateTime(2012,11,26);
                EndDate = new DateTime(2012,12,29);
            }
            else if (BeginDate == new DateTime(2013, 1, 1))
            {
                BeginDate = new DateTime(2012, 12, 29);
                EndDate = new DateTime(2013, 1, 26);
            }
            else if (BeginDate > new DateTime(2012, 8, 1))
            {
                EndDate = Convert.ToDateTime(this.drplYear.SelectedValue + "-" + this.drpMonth.SelectedValue + "-26");
                BeginDate = EndDate.AddMonths(-1);
            }
            else
            {
                EndDate = BeginDate.AddMonths(1);
            }
           // string BeginDatestr = BeginDate.ToString("yyyy-MM-dd");//������ת����yyyy-mm-dd��ʽ
           // string EndDatestr = EndDate.ToString("yyyy-MM-dd");
           
            if (oItemSystem.YJKM(BeginDate, EndDate))
            {
                this.Label1.Text = "��ȫ�½ᱣ��ɹ�!";
            }
            else
            {
                this.Label1.Text = "��ȫ�½ᱣ��ʧ��!";
            }
        }

        protected void AddYj_Km1NoNull_Click(object sender, EventArgs e)
        {
            BeginDate = Convert.ToDateTime(this.drplYear.SelectedValue + "-" + this.drpMonth.SelectedValue + "-01");
            if (BeginDate == new DateTime(2012, 8, 1))
            {
                EndDate = new DateTime(2012, 8, 26);
            }
            else if (BeginDate == new DateTime(2012, 12, 1))
            {
                BeginDate = new DateTime(2012, 11, 26);
                EndDate = new DateTime(2012, 12, 29);
            }
            else if (BeginDate == new DateTime(2013, 1, 1))
            {
                BeginDate = new DateTime(2012, 12, 29);
                EndDate = new DateTime(2013, 1, 26);
            }
            else if (BeginDate > new DateTime(2012, 8, 1))
            {
                EndDate = Convert.ToDateTime(this.drplYear.SelectedValue + "-" + this.drpMonth.SelectedValue + "-26");
                BeginDate = EndDate.AddMonths(-1);
            }
            else
            {
                EndDate = BeginDate.AddMonths(1);
            }
            if (oItemSystem.YJKMNotNull(BeginDate, EndDate))
            {
                this.Label1.Text = "�����½ᱣ��ɹ�!";
            }
            else
            {
                this.Label1.Text = "�����½ᱣ��ʧ��!";
            }
        }

        
    }
}
