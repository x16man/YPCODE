namespace MZHMM.WebMM.Modules
{
    using System;
    using System.Data;
    using Shmzh.MM.Common;
    using Shmzh.MM.Facade;

    /// <summary>
    ///		DocWebControl ��ժҪ˵����
    /// </summary>
    public partial class DocWebControl : System.Web.UI.UserControl
    {
        #region"��Ա����"
        public StorageDropdownlist ddlYear = new StorageDropdownlist();
        public StorageDropdownlist ddlMonth = new StorageDropdownlist();

        private BillOfDocumentData oBOD = new BillOfDocumentData();

        private DataRow dr;
        #endregion
        #region"����"
        /// <summary>
        /// �������ͱ�š�
        /// </summary>
        public int DocCode
        {
            get { return int.Parse(txtDocCode.Value); }
            set { txtDocCode.Value = value.ToString(); }
        }
        /// <summary>
        /// �����������ơ�
        /// </summary>
        public string DocName
        {
            get { return lblTitle.Text; }
        }
        /// <summary>
        /// �����ĵ���š�
        /// </summary>
        public string DocNo
        {
            get { return lblDocNo.Text; }
        }
        /// <summary>
        /// ������ˮ�š�
        /// </summary>
        public int EntryNo
        {
            get { return int.Parse(txtEntryNo.Value); }
            set { this.txtEntryNo.Value = value.ToString(); }
        }
        /// <summary>
        /// ���ݱ�š�
        /// </summary>
        public string EntryCode
        {
            get { return lblEntryCode.Text; }
            set { this.lblEntryCode.Text = value; }
        }
        /// <summary>
        /// �������ڡ�
        /// </summary>
        public DateTime EntryDate
        {
            get { return Convert.ToDateTime(lblDate.Text); }
            set { this.lblDate.Text = String.Format("{0:yyyy-MM-dd}", value); }
        }
        /// <summary>
        /// �ɹ��ƻ�����ݡ�
        /// </summary>
        public int PlanYear
        {
            get { return Convert.ToInt32(this.ddlYear.SelectedValue); }
            set { this.ddlYear.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// �ɹ��ƻ����·ݡ�
        /// </summary>
        public int PlanMonth
        {
            get { return Convert.ToInt32(this.ddlMonth.SelectedValue); }
            set { this.ddlMonth.SelectedValue = value.ToString(); }
        }
        #endregion
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
           
        }
        /// <summary>
        /// �½�����ʱ�������ݰ󶨡�
        /// </summary>
        public void DataBindNew()
        {

            oBOD = new BillOfDocumentData();

            oBOD = (new PurchaseSystem()).GetDocEntryByCode(int.Parse(txtDocCode.Value));

            dr = oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0];

            //�������ơ�
            lblTitle.Text = dr[BillOfDocumentData.DOCNAME_FIELD].ToString();
            //�����ĵ���š�
            if (dr[BillOfDocumentData.DOCNO_FIELD] != DBNull.Value)
            {
                lblDocNo.Text = dr[BillOfDocumentData.DOCNO_FIELD].ToString();
            }
            else
            {
                lblDocNo.Text = "";
            }
            //������ˮ�š�
            txtEntryNo.Value = dr[BillOfDocumentData.NEXTNO_FIELD].ToString();
            //���ݱ�š�
            if (dr[BillOfDocumentData.CODERULE_FIELD] != DBNull.Value)
            {
                lblEntryCode.Text = dr[BillOfDocumentData.CODERULE_FIELD].ToString() + txtEntryNo.Value;
            }
            else
            {
                lblEntryCode.Text = txtEntryNo.Value;
            }
            //�������ڡ�
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
        /// �޸ĵ���ʱ�������ݰ󶨡�
        /// </summary>
        public void DataBindUpdate()
        {
            oBOD = new BillOfDocumentData();
            oBOD = (new PurchaseSystem()).GetDocEntryByCode(int.Parse(txtDocCode.Value));

            dr = oBOD.Tables[BillOfDocumentData.SBOD_TABLE].Rows[0];

            //�������ơ�
            lblTitle.Text = dr[BillOfDocumentData.DOCNAME_FIELD].ToString();
            //�����ĵ���š�
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
//			//������ˮ�š�
//			txtEntryNo.Value=dr[BillOfDocumentData.NEXTNO_FIELD].ToString();
//			//���ݱ�š�
//			if (dr[BillOfDocumentData.CODERULE_FIELD]!=DBNull.Value)
//			{
//				lblEntryCode.Text=dr[BillOfDocumentData.CODERULE_FIELD].ToString() + txtEntryNo.Value;
//			}
//			else
//			{
//				lblEntryCode.Text=txtEntryNo.Value;
//			}
//			//�������ڡ�
//			lblDate.Text=DateTime.Now.Date.ToString("yyyy-MM-dd");
        }
        
    }
}
