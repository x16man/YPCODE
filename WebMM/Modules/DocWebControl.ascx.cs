namespace MZHMM.WebMM.Modules
{
    using System;
    using System.Data;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;

    /// <summary>
    ///		DocWebControl 的摘要说明。
    /// </summary>
    public partial class DocWebControl : System.Web.UI.UserControl
    {
        #region"成员变量"
        public StorageDropdownlist ddlYear = new StorageDropdownlist();
        public StorageDropdownlist ddlMonth = new StorageDropdownlist();

        private BillOfDocumentData oBOD = new BillOfDocumentData();

        private DataRow dr;
        #endregion
        #region"属性"
        /// <summary>
        /// 单据类型编号。
        /// </summary>
        public int DocCode
        {
            get { return int.Parse(txtDocCode.Value); }
            set { txtDocCode.Value = value.ToString(); }
        }
        /// <summary>
        /// 单据类型名称。
        /// </summary>
        public string DocName
        {
            get { return lblTitle.Text; }
        }
        /// <summary>
        /// 单据文档编号。
        /// </summary>
        public string DocNo
        {
            get { return lblDocNo.Text; }
        }
        /// <summary>
        /// 单据流水号。
        /// </summary>
        public int EntryNo
        {
            get { return int.Parse(txtEntryNo.Value); }
            set { this.txtEntryNo.Value = value.ToString(); }
        }
        /// <summary>
        /// 单据编号。
        /// </summary>
        public string EntryCode
        {
            get { return lblEntryCode.Text; }
            set { this.lblEntryCode.Text = value; }
        }
        /// <summary>
        /// 单据日期。
        /// </summary>
        public DateTime EntryDate
        {
            get { return Convert.ToDateTime(lblDate.Text); }
            set { this.lblDate.Text = String.Format("{0:yyyy-MM-dd}", value); }
        }
        /// <summary>
        /// 采购计划的年份。
        /// </summary>
        public int PlanYear
        {
            get { return Convert.ToInt32(this.ddlYear.SelectedValue); }
            set { this.ddlYear.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// 采购计划的月份。
        /// </summary>
        public int PlanMonth
        {
            get { return Convert.ToInt32(this.ddlMonth.SelectedValue); }
            set { this.ddlMonth.SelectedValue = value.ToString(); }
        }
        #endregion
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
           
        }
        /// <summary>
        /// 新建单据时进行数据绑定。
        /// </summary>
        public void DataBindNew()
        {

            oBOD = new BillOfDocumentData();

            oBOD = (new PurchaseSystem()).GetDocEntryByCode(int.Parse(txtDocCode.Value));

            dr = oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0];

            //单据名称。
            lblTitle.Text = dr[BillOfDocumentData.DOCNAME_FIELD].ToString();
            //单据文档编号。
            if (dr[BillOfDocumentData.DOCNO_FIELD] != DBNull.Value)
            {
                lblDocNo.Text = dr[BillOfDocumentData.DOCNO_FIELD].ToString();
            }
            else
            {
                lblDocNo.Text = "";
            }
            //单据流水号。
            txtEntryNo.Value = dr[BillOfDocumentData.NEXTNO_FIELD].ToString();
            //单据编号。
            if (dr[BillOfDocumentData.CODERULE_FIELD] != DBNull.Value)
            {
                lblEntryCode.Text = dr[BillOfDocumentData.CODERULE_FIELD].ToString() + txtEntryNo.Value;
            }
            else
            {
                lblEntryCode.Text = txtEntryNo.Value;
            }
            //单据日期。
            lblDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            this.ddlYear.Module_Tag = (int)SDDLTYPE.YEAR;
            this.ddlMonth.Module_Tag = (int)SDDLTYPE.MONTH;
            DateTime date = DateTime.Now;
            if (DateTime.Now.Day > 25)
                date = DateTime.Now.AddMonths(1);

            this.ddlYear.SelectedText = date.Year.ToString();
            this.ddlYear.SelectedValue = date.Year.ToString();
            this.ddlMonth.SelectedText = date.Month.ToString();
            this.ddlMonth.SelectedValue = date.Month.ToString();
            if (this.DocCode == DocType.PP)
            {
                this.lblDate.Visible = false;
                this.lblYear.Visible = true;
                this.lblMonth.Visible = true;
                this.ddlYear.Visible = true;
                this.ddlMonth.Visible = true;
            }
            else
            {
                this.lblDate.Visible = true;
                this.lblYear.Visible = false;
                this.lblMonth.Visible = false;
                this.ddlYear.Visible = false;
                this.ddlMonth.Visible = false;
            }
        }
        /// <summary>
        /// 修改单据时进行数据绑定。
        /// </summary>
        public void DataBindUpdate()
        {
            oBOD = new BillOfDocumentData();
            oBOD = (new PurchaseSystem()).GetDocEntryByCode(int.Parse(txtDocCode.Value));

            dr = oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0];

            //单据名称。
            lblTitle.Text = dr[BillOfDocumentData.DOCNAME_FIELD].ToString();
            //单据文档编号。
            if (dr[BillOfDocumentData.DOCNO_FIELD] != DBNull.Value)
            {
                lblDocNo.Text = dr[BillOfDocumentData.DOCNO_FIELD].ToString();
            }
            else
            {
                lblDocNo.Text = "";
            }
            this.ddlYear.Module_Tag = (int)SDDLTYPE.YEAR;
            this.ddlMonth.Module_Tag = (int)SDDLTYPE.MONTH;
            if (this.DocCode == DocType.PP)
            {
                this.lblDate.Visible = false;
                this.lblYear.Visible = true;
                this.lblMonth.Visible = true;
                this.ddlYear.Visible = true;
                this.ddlMonth.Visible = true;
            }
            else
            {
                this.lblDate.Visible = true;
                this.lblYear.Visible = false;
                this.lblMonth.Visible = false;
                this.ddlYear.Visible = false;
                this.ddlMonth.Visible = false;
            }
//			//单据流水号。
//			txtEntryNo.Value=dr[BillOfDocumentData.NEXTNO_FIELD].ToString();
//			//单据编号。
//			if (dr[BillOfDocumentData.CODERULE_FIELD]!=DBNull.Value)
//			{
//				lblEntryCode.Text=dr[BillOfDocumentData.CODERULE_FIELD].ToString() + txtEntryNo.Value;
//			}
//			else
//			{
//				lblEntryCode.Text=txtEntryNo.Value;
//			}
//			//单据日期。
//			lblDate.Text=DateTime.Now.Date.ToString("yyyy-MM-dd");
        }
        
    }
}
