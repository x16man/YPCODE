using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemManagement.MZHUM
{
    public partial class Error : System.Web.UI.Page
    {
        #region property
        protected string StatusCode
        {
            get {
                return !string.IsNullOrEmpty(this.Request["StatusCode"]) ? this.Request["StatusCode"] : string.Empty;
            }
        }
        protected string ErrorString
        {
            get; set;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (this.StatusCode)
            {
                case "404":
                    this.ErrorString = "404错误！<br>您所要访问的URL不存在。";
                    break;
                case "403":
                    this.ErrorString = "403错误！<br>";
                    break;
                default:
                    this.ErrorString = Session["Error"] != null ? Session["Error"].ToString() : "没有任何错误信息！";
                    break;
            }
        }
    }
}
