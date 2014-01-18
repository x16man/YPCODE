using MZHMM.WebMM.Common;

namespace WebMM.Modules
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Drawing;
	using MZHCommon.Database;
    using System.Web.UI.WebControls;
    using Shmzh.MM.Common;
	/// <summary>
	///	未完全付款的采购发票反馈信息用户Web组件.
	/// </summary>
	public partial class WUCNoPayed : System.Web.UI.UserControl
	{
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Property
        private DataSet childData;
        public string itemstly = "";

	    public Shmzh.Components.SystemComponent.User CurrentUser
	    {
            get { return Page.Session["User"] as Shmzh.Components.SystemComponent.User; }
	    }

        /// <summary>
        /// 用户。
        /// </summary>
        public string UserLoginID
        {
            get
            {
                return this.Session[MySession.UserLoginId] != null ? this.Session[MySession.UserLoginId].ToString() : null;
            }
        }
        #endregion

        

        private void BindMainData()
        {
            var oSQLServer = new SQLServer();
            var oHT = new Hashtable { { "@Year", DateTime.Today.Year }, { "@Month", DateTime.Today.Month }, { "@Flag", 1 } };

            DataSet ds = oSQLServer.ExecSPReturnDS("Pur_PayedAndunPayedGroupbyBuyerName", oHT);

            if (CurrentUser.HasRight(SysRight.WUCNOPayedAll))
                this.rptNOPayedDraw.DataSource = ds;
            else
            {
                this.rptNOPayedDraw.DataSource = new DataView(ds.Tables[0], string.Format("buyercode='{0}'", CurrentUser.EmpCode), "buyercode asc", DataViewRowState.CurrentRows);
            }
            this.rptNOPayedDraw.DataBind();
        }
        private DataSet GetChildData()
        {
            var oSQLServer = new SQLServer();
            var oHT = new Hashtable { { "@Year", DateTime.Today.Year }, { "@Month", DateTime.Today.Month }, { "@Flag", 1 } };
            return oSQLServer.ExecSPReturnDS("Pur_PayedAndunPayed", oHT);
        }
        protected DataView GetChildDataByBuyerCode(string code)
        {
            var obj = new DataView(this.childData.Tables[0], string.Format("buyercode='{0}'", code), "", DataViewRowState.CurrentRows);
            return obj;
        }
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {

                    this.childData = this.GetChildData();
                    this.dgNoPayed.Visible = false;
                    if (this.CurrentUser.HasRight(SysRight.TodoWUCNoPayed))
                    {
                        this.BindMainData();
                        //this.BindNoPayedInvoice();
                        
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("WUCNoPayedPage_Load=" + ex.Message);
                }
            }
        }

        private void BindNoPayedInvoice()
        {
            var oSQLServer = new SQLServer();
            var oHT = new Hashtable { { "@Year", DateTime.Today.Year }, { "@Month", DateTime.Today.Month }, { "@Flag", 1 } };
            var oData = new DataSet();
            oData = oSQLServer.ExecSPReturnDS("Pur_PayedAndunPayed", oHT, oData, "NoPayed");

            this.dgNoPayed.DataSource = oData.Tables["NoPayed"].DefaultView;
            this.dgNoPayed.DataBind();
        }

        protected void dgNoPayed_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.Cells[3].Text == "-1")
            {
                e.Item.Style.Add("color:", Color.Gray.ToString());
            }
            else
            {
                e.Item.Style.Add("color", Color.Black.ToString());
            }
        }

        protected void rptDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptDetail_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DataRowView dr = e.Item.DataItem as DataRowView;
                    if (dr != null)
                    {
                        if (dr["Flag"].ToString() == "1")
                        {
                            itemstly = "color:" + ColorTranslator.ToHtml(Color.Gray) + "";
                        }
                        else
                        {
                            itemstly = "color:" + ColorTranslator.ToHtml(Color.Black) + "";
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Logger.Error("WUCNoPayedrptDetail_ItemCreated=" + ex.Message);
            }

        }
	}
}
