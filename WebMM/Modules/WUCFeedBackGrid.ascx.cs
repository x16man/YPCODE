
namespace WebMM.Modules
{
    using System.Data;
	using System.Collections;
    using MZHCommon.Database;

    /// <summary>
	///	�����ϵķ�����Ϣ�û�Web�����
	/// </summary>
	public partial class WUCFeedBackGrid : System.Web.UI.UserControl
    {
        #region Field
        private DataSet childData;
        #endregion

        #region Property
        public Shmzh.Components.SystemComponent.User CurrentUser
		{
			get {
			    return Page.Session["User"] as Shmzh.Components.SystemComponent.User;
			}
        }
        #endregion

        #region method
        private void BindMainData()
        {
            var oSQLServer = new SQLServer();
            var oHT = new Hashtable {{"@UserLoginId", this.CurrentUser.LoginName}, {"@Type", "������..."}};
            this.rptDraw.DataSource = oSQLServer.ExecSPReturnDS("FeedbackGetReqReasonByUserAndType", oHT);
            this.rptDraw.DataBind();
        }
        private DataSet GetChildData()
        {
            var oSQLServer = new SQLServer();
            var oHT = new Hashtable { { "@UserLoginId", this.CurrentUser.LoginName }, { "@Type", "������..." } };

            return oSQLServer.ExecSPReturnDS("FeedbackGetByUserAndType", oHT);
        }
        protected DataView GetChildDataByReqReasonCode(string code)
        {
            var obj = new DataView(this.childData.Tables[0], string.Format("ReqReasonCode='{0}'", code), "ItemCode ASC", DataViewRowState.CurrentRows);
            return obj;
        }
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
		{
            this.childData = this.GetChildData();
			this.BindMainData();
		}
	}
}
