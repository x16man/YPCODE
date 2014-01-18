namespace WebMM.Modules
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Web.UI.WebControls;
    using Shmzh.MM.Common;
	using MZHCommon.Database;
	using Infragistics.WebUI.UltraWebGrid;
	/// <summary>
	///	申购物料申购中的反馈信息用户Web组件.
	/// </summary>
	public partial class WUCFeedbackPurchase : System.Web.UI.UserControl
    {
        #region Field

	    private DataSet childData;
        #endregion
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
        
        private void BindMainData()
        {
            var oSQLServer = new SQLServer();
            var oHT = new Hashtable {{"@UserLoginId", this.UserLoginID}, {"@Type", "采购中..."}};
            this.rptPurchase.DataSource = oSQLServer.ExecSPReturnDS("FeedbackGetReqReasonByUserAndType", oHT);
            this.rptPurchase.DataBind();
        }
        private DataSet GetChildData()
        {
            var oSQLServer = new SQLServer();
            var oHT = new Hashtable { { "@UserLoginId", this.UserLoginID }, { "@Type", "采购中..." } };
            return oSQLServer.ExecSPReturnDS("FeedbackGetByUserAndType", oHT);
        }
        protected DataView GetChildDataByReqReasonCode(string code)
        {
            var obj = new DataView(this.childData.Tables[0],string.Format("ReqReasonCode='{0}'",code),"ItemCode ASC", DataViewRowState.CurrentRows);
            return obj;
        }
		protected void Page_Load(object sender, System.EventArgs e)
		{
		    this.childData = this.GetChildData();
			this.BindMainData();
		}
		
        //private void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        //{
        //    this.UltraWebGrid1.DisplayLayout.ViewType = ViewType.Hierarchical;
        //    this.UltraWebGrid1.DisplayLayout.HeaderStyleDefault.HorizontalAlign = HorizontalAlign.Center;

        //    this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReasonCode").Hidden = true;
        //    this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").Header.Caption = "用途";
        //    this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").CellStyle.HorizontalAlign =  HorizontalAlign.Left;
        //    this.UltraWebGrid1.Bands[0].Columns.FromKey("ReqReason").Width = new Unit("250px");
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("PKID").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("UserLoginId").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("UserLoginId").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("UserCode").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("UserName").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("EntryNo").Hidden = true;			
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("DocCode").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemSpec").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemUnitName").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemUnit").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("CreateDate").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("SerialNo").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ReqReasonCode").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ReqReason").Hidden = true;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("Selected").Hidden = true;			
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemCode").Header.Caption = "编号";
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemCode").CellStyle.HorizontalAlign = HorizontalAlign.Center;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemCode").Width = new Unit("80px");
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemName").Header.Caption = "名称";
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemName").CellStyle.HorizontalAlign = HorizontalAlign.Left;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemName").Width = new Unit("100px");
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemSpec").Header.Caption = "规格型号";
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemSpec").CellStyle.HorizontalAlign = HorizontalAlign.Left;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemSpec").Width = new Unit("100px");
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemUnitName").Header.Caption = "单位";
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemUnitName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemUnitName").Width = new Unit("50px");
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemNum").Header.Caption = "数量";
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemNum").CellStyle.HorizontalAlign = HorizontalAlign.Right;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("ItemNum").Width = new Unit("80px");
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("Message").Header.Caption = "反馈";
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("Message").CellStyle.HorizontalAlign = HorizontalAlign.Left;
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("Message").Width = new Unit("80px");
        //    this.UltraWebGrid1.Bands[1].Columns.FromKey("Message").Hidden = true;
        //}
	}
}
