using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_RightCatList ��ժҪ˵����
	/// </summary>
	public partial class SYS_RightCatList : BasePage
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	    /// <summary>
	    /// Ȩ�޷������ڱ�ʹ�õ���ʾ�ű���
	    /// </summary>
	    private static readonly string RIGHTCATEGORYISUSING_SCRIPT =
	        string.Format(ALERT_FORMATSTRING,
	                      ConfigCommon.GetMessageValue("RightCatIsUsing"));

	    /// <summary>
	    /// Ȩ�޷���ɾ��ʧ�ܵ���ʾ�ű���
	    /// </summary>
	    private static readonly string DELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                       ConfigCommon.GetMessageValue(
	                                                                           "RightCatDeleteFailed"));
        #endregion

        #region Property
        /// <summary>
        /// ��Ʒ��š�
        /// </summary>
        public short ProductCode
        {
            get { return short.Parse(this.txtProductCode.Text); }
            set { this.txtProductCode.Text = value.ToString(); }
        }
	    /// <summary>
	    /// ��Ʒ���ơ�
	    /// </summary>
	    public string ProductName
	    {
            get { return this.ViewState["ProductName"].ToString(); }
            set { this.ViewState["ProductName"] = value; }
	    }
        /// <summary>
        /// ��ѯ��־��
        /// </summary>
        public int SelectFlag
        {
            get { return int.Parse(ViewState["SelectFlag"].ToString()); }
            set { ViewState["SelectFlag"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// �󶨲�Ʒ�б�
        /// </summary>
        private void BindProduct()
        {
            this.toolbarDropdownList1.Items.Clear();
            var products = DataProvider.ProductProvider.GetAllAvalible();

            var oItem = new ListItem("--ȫ��--", "0");
            this.toolbarDropdownList1.Items.Add(oItem);
            foreach (ProductInfo obj in products)
            {
                oItem = new ListItem(obj.ProductName, obj.ProductCode.ToString());
                this.toolbarDropdownList1.Items.Add(oItem);
            }
        }
        /// <summary>
        /// ��Ȩ�޷�����Ϣ��DataGrid�ؼ���
        /// </summary>
        private void BindData()
        {
            if (this.SelectFlag == 2)
            {
                this.ProductCode = short.Parse(this.toolbarDropdownList1.SelectedValue);
            }
            var objs = DataProvider.RightCatProvider.GetAllByProductCode(this.ProductCode) as ListBase<RightCatInfo>;
            this.dg_RightCat.DataSource = objs;
            this.dg_RightCat.DataBind();

        }
        #endregion

        #region Event
        /// <summary>
        /// ҳ������¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
                if (!CurrentUser.HasRight(RightEnum.RightCatMaintain))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
			    this.SelectFlag = 1;
				if (string.IsNullOrEmpty(Request["productCode"]))
				{
					this.ProductCode = 0;
					BindProduct();
                } 
				else
				{
					this.ProductCode = short.Parse(Request["productCode"]);
				    this.ProductName = DataProvider.ProductProvider.GetByCode(this.ProductCode).ProductName;
				}
				this.BindData();
			}
            this.dg_RightCat.AutoDataBind = BindData;
		}
        
        /// <summary>
        /// Toolbar�����¼���
        /// </summary>
        /// <param name="item">�����¼���ToolbarItem��</param>
		protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
		{
			switch(item.ItemId.ToUpper())
			{
				case "DELETE":
					if(this.dg_RightCat.SelectedID .Length  > 0 )
					{
					    if (DataProvider.RightCatProvider.HasChildren(this.dg_RightCat.SelectedID))
					    {
					        AddScript(RIGHTCATEGORYISUSING_SCRIPT);
					    }
					    else
					    {
					        if (DataProvider.RightCatProvider.Delete(this.dg_RightCat.SelectedID))
					        {
					            this.BindData();
					        }
					        else
					        {
					            AddScript(DELETEFAILED_SCRIPT);
					        }
					    }
					}
					break;
				case "DDLPRODUCT":
			        this.SelectFlag = 2;
			        this.BindData();
					break;
			}
		}
        /// <summary>
        /// ˢ�°�ť�¼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
        #endregion
    }
}
