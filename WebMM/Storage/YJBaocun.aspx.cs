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
    /// YJBaocun 的摘要说明。
    /// </summary>
    public partial class YJBaocun : System.Web.UI.Page
    {
        DateTime BeginDate;
        DateTime EndDate;

        private ItemSystem oItemSystem = new ItemSystem();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (!this.IsPostBack)
            {
                if (!Master.HasBrowseRight(SysRight.YJBaocunMaintain))
                {
                    return;
                }
                this.AddYj.Attributes.Add("onclick", "return confirm('保存后会更改以前的数据,确定要保存吗?')");
                this.AddYj_Km1NoNull.Attributes.Add("onclick", "return confirm('确定要增量保存吗?')");
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
           // string BeginDatestr = BeginDate.ToString("yyyy-MM-dd");//将日期转换成yyyy-mm-dd格式
           // string EndDatestr = EndDate.ToString("yyyy-MM-dd");
           
            if (oItemSystem.YJKM(BeginDate, EndDate))
            {
                this.Label1.Text = "完全月结保存成功!";
            }
            else
            {
                this.Label1.Text = "完全月结保存失败!";
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
                this.Label1.Text = "增量月结保存成功!";
            }
            else
            {
                this.Label1.Text = "增量月结保存失败!";
            }
        }

        
    }
}
