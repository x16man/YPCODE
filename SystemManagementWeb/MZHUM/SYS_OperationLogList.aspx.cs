using System;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Components.SystemComponent.Enum;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// ������־�б�ҳ�档
	/// </summary>
	public partial class SYS_OperationLogList : BasePage
    {
        #region Field
        #pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore 169
        #endregion

        #region Property
        /// <summary>
        /// ��ѯ��־��
        /// </summary>
        public int SelectFlag
        {
            get { return int.Parse(ViewState["SelectFlag"].ToString()); }
            set { ViewState["SelectFlag"] = value; }
        }
        /// <summary>
        /// �������͡�
        /// </summary>
	    public string OpType
	    {
            get { return Request["OpType"]; }
	    }
	    public short ProductCode
	    {
	        get {
	            return string.IsNullOrEmpty(Request["ProductCode"]) ? short.Parse(this.tbiProduct.SelectedValue) : short.Parse(Request["ProductCode"]);
	        }
	    }
	    public DateTime BeginTime
	    {
            get
            {
                if(string.IsNullOrEmpty(this.tbiBeginTime.Text))
                    return new DateTime(2009,1,1);
                else
                    return DateTime.Parse(this.tbiBeginTime.Text);
            }
            set { this.tbiBeginTime.Text = value.ToShortDateString(); }
	    }
	    public DateTime EndTime
	    {
            get
            {
                if (string.IsNullOrEmpty(this.tbiEndTime.Text))
                    return DateTime.Today;
                else
                    return DateTime.Parse(this.tbiEndTime.Text);
            }
            set { this.tbiEndTime.Text = value.ToShortDateString(); }
	    }
        #endregion

        #region Method
        /// <summary>
        /// �󶨲�Ʒ�������б�
        /// </summary>
	    private void BindProduct()
	    {
	        var objs = DataProvider.ProductProvider.GetAllAvalible();
            this.tbiProduct.Items.Clear();
            foreach(var obj in objs)
            {
                this.tbiProduct.Items.Add(new ListItem(obj.ProductName,obj.ProductCode.ToString()));   
            }
	    }
        /// <summary>
        /// ���ݰ󶨷�����
        /// </summary>
        private void myDataBind()
        {
            ListBase<OperationLogInfo> objs;
            if(this.SelectFlag == 1)
            {
                if(this.OpType == OpTypeEnum.UserOperation)
                    objs = (ListBase<OperationLogInfo>)DataProvider.OperationLogProvider.GetTop100(this.OpType);
                else
                {
                    objs = (ListBase<OperationLogInfo>)DataProvider.OperationLogProvider.GetTop100(this.OpType,this.ProductCode);
                }
            }
            else
            {
                if (this.OpType == OpTypeEnum.UserOperation)
                {
                    if(string.IsNullOrEmpty(this.tbiOpDesc.Text))
                        objs = (ListBase<OperationLogInfo>)DataProvider.OperationLogProvider.GetByTimeAndOpType(this.BeginTime, this.EndTime.AddDays(1), this.OpType);
                    else
                        objs = (ListBase<OperationLogInfo>)DataProvider.OperationLogProvider.GetByTimeAndOpTypeAndOpDesc(this.BeginTime, this.EndTime.AddDays(1), this.OpType, this.tbiOpDesc.Text);
                    
                }
                else
                {
                    if (string.IsNullOrEmpty(this.tbiOpDesc.Text))
                        objs = (ListBase<OperationLogInfo>)DataProvider.OperationLogProvider.GetByTimeAndOpTypeAndProductCode(this.BeginTime, this.EndTime.AddDays(1),this.OpType,this.ProductCode);
                    else
                        objs = (ListBase<OperationLogInfo>)DataProvider.OperationLogProvider.GetByTimeAndOpTypeAndProductCodeAndOpDesc(this.BeginTime, this.EndTime.AddDays(1), this.OpType,this.ProductCode, this.tbiOpDesc.Text);
                    
                }
            }
            this.dg_OperationLog.DataSource = objs;
            this.dg_OperationLog.DataBind();
        }
        #endregion

        #region Event
        /// <summary>
        /// ҳ��ļ����¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
                if (this.OpType.ToUpper() == OpTypeEnum.UserOperation.ToUpper() || !string.IsNullOrEmpty(this.Request["ProductCode"]))
                {
                    this.tbiProduct.Visible = false;
                }
			    if(!CurrentUser.HasRight(RightEnum.OperationLogView))
				{
                    this.SetNoRightInfo(true);
                    return;
				}
			    this.SelectFlag = 1;
			    this.BindProduct();
                this.myDataBind();

			}
            this.dg_OperationLog.AutoDataBind = this.myDataBind;
		}
        /// <summary>
        /// Toolbar�¼���
        /// </summary>
        /// <param name="item">�����¼���ToolbarItem��</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "query":
                    if(string.IsNullOrEmpty(this.tbiBeginTime.Text) && string.IsNullOrEmpty(this.tbiEndTime.Text) && string.IsNullOrEmpty(this.tbiOpDesc.Text))
                    {
                        this.SelectFlag = 1;
                    }
                    else
                    {
                        this.SelectFlag = 2;
                    }
                    this.myDataBind();
                    break;
            }
        }
        
        /// <summary>
        /// ˢ�°�ť�¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    
        protected void btnRefresh_Click(object sender, System.EventArgs e)
        {
            this.myDataBind();
        }
        #endregion
    }
}
