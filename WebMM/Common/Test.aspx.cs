using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MZHMM.WebMM.Common
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dllUsingClassify.Items.Add(new ListItem("1","1"));
                this.dllUsingClassify.Items.Add(new ListItem("2", "2"));
               
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
           
        }

        protected void dllUsingClassify_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
