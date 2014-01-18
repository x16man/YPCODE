using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shmzh.MM.Common;
using MZHCommon.Database;
using MZHMM.WebMM.Modules;
using Shmzh.MM.Facade;
using MZHMM.WebMM.Purchase;
using System.Collections;
using MZHMM.WebMM.Common;

namespace WebMM.SYS
{
    public partial class AdminTools : System.Web.UI.Page
    {
        #region 属性
        /// <summary>
        /// 采购订单的编号。
        /// </summary>
        protected int Order_EntryNo
        {

            get { return int.Parse(this.txtEnyNo.Text); }
        }

        /// </summary>
        // 采购订单的供应商编号。
        /// </summary>

        protected string Order_PrvCode
        {
            get { return this.txtVendorCode.Text; }
        }

        protected string Order_PrvCode2
        {
            get { return this.txtVendorCode2.Text; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Master.HasBrowseRight(SysRight.AdminTool))
            {
                return;
            }
        }

        protected void btnChangeOrderVendor1_Click(object sender, EventArgs e)
        {
            try
            {
                MZHCommon.Database.SQLServer oSQLServer = new MZHCommon.Database.SQLServer();
                System.Collections.Hashtable oHT = new Hashtable();
                oHT.Add("@EntryNo", this.Order_EntryNo);
                oHT.Add("@VendorCode", this.Order_PrvCode);

                if (oSQLServer.ExecSP("Pur_OrderChangeVendor", oHT))
                {
                    //this.Response.Write("<script>alert('订单供应商修改成功！');</script>");
                    //Page.RegisterStartupScript("Yes", "<script>alert('订单供应商修改成功！');</script>");
                    ClientScript.RegisterStartupScript( this.GetType(), "Yes", "alert('订单供应商修改成功!');", true);
								
                }
                else
                {
                    //this.Response.Write("<script>alert('订单修改供应商失败！');</script>");
                    //Page.RegisterStartupScript("No", "<script>alert('订单修改供应商失败！');</script>");
                    ClientScript.RegisterStartupScript( this.GetType(), "No", "alert('订单修改供应商失败');", true);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript( this.GetType(), "No", "alert('订单修改供应商失败');", true);
               // Page.RegisterStartupScript("No", "<script>alert('订单修改供应商失败！');</script>");
            }
        }
    }
}
