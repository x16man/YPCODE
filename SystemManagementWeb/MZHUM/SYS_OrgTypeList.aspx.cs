using System;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Web.UI.Controls;
using Shmzh.Components.SystemComponent;
namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_OrgTypeList ��ժҪ˵����
	/// </summary>
	public partial class SYS_OrgTypeList : BasePage
    {
        #region Field
        /// <summary>
        /// �����������ڱ�ʹ�õ���ʾ�ű���
        /// </summary>
	    private static readonly string ORGISUSING_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("OrgTypeIsUsing"));
        /// <summary>
        /// �������͡�
        /// </summary>
	    private static readonly string ORGDELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                          ConfigCommon.GetMessageValue(
	                                                                              "OrgTypeDeleteFailed"));
        #endregion

        #region private method
        /// <summary>
        /// ��֯�������ݰ󶨷�����
        /// </summary>
        private void myDataBind()
		{
            var objs = DataProvider.OrgTypeProvider.GetAll() as ListBase<OrgTypeInfo>;
            dg_OrgType.DataSource = objs;
			dg_OrgType.DataBind();
        }
        #endregion

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private static void InitializeComponent()
		{    
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
				if(!CurrentUser.HasRight(RightEnum.OrgTypeMaintain))
				{
					this.SetNoRightInfo(true);
				}
				else
				{
					myDataBind();
				}
			}
            this.dg_OrgType.AutoDataBind = myDataBind;
		}
        /// <summary>
        /// ToolBar��ť�ĵ���¼���
        /// </summary>
        /// <param name="item">ToolbarItem���ͣ������¼���ToolbarItem��</param>
		protected void MzhToolbar1_ItemPostBack(ToolbarItem item)
        {
            switch (item.ItemId.ToLower())
            {
                case "delete":
                    if (!CurrentUser.HasRight(RightEnum.OrgTypeMaintain))
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    if (DataProvider.OrgTypeProvider.IsUsed(this.dg_OrgType.SelectedID))
                    {
                        AddScript(ORGISUSING_SCRIPT);
                        return;
                    }
                    if(isSynchronization())
                    {
                        var obj = DataProvider.OrgTypeProvider.GetByCode(this.dg_OrgType.SelectedID);
                        var obj1 = DataProvider.TB_SYSORGTPProvider.GetByTypeName(obj.CnName);
                        if(obj1 != null)
                        {
                            using (var conn = new SqlConnection(ConnectionString.PubData))
                            {
                                conn.Open();
                                var trans = conn.BeginTransaction();
                                if(DataProvider.OrgTypeProvider.Delete(obj, trans) && DataProvider.TB_SYSORGTPProvider.Delete(obj1,trans))
                                    trans.Commit();
                                else
                                {
                                    trans.Rollback();
                                    AddScript(ORGDELETEFAILED_SCRIPT);
                                }
                                    
                                myDataBind();
                                break;
                            }
                        }
                    }
                    
                    if (!DataProvider.OrgTypeProvider.Delete(this.dg_OrgType.SelectedID))
                    {
                        AddScript(ORGDELETEFAILED_SCRIPT);
                    }
                    myDataBind();
                    break;
            }
        }
        #endregion

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myDataBind();
        }

        
    }
}
