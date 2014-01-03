using System;
using System.Data.SqlClient;
using Shmzh.Components.SystemComponent.DALFactory;
using Shmzh.Web.UI.Controls;
using Shmzh.Components.SystemComponent;
namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_OrgTypeList 的摘要说明。
	/// </summary>
	public partial class SYS_OrgTypeList : BasePage
    {
        #region Field
        /// <summary>
        /// 部门类型正在被使用的提示脚本。
        /// </summary>
	    private static readonly string ORGISUSING_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("OrgTypeIsUsing"));
        /// <summary>
        /// 部门类型。
        /// </summary>
	    private static readonly string ORGDELETEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING,
	                                                                          ConfigCommon.GetMessageValue(
	                                                                              "OrgTypeDeleteFailed"));
        #endregion

        #region private method
        /// <summary>
        /// 组织类型数据绑定方法。
        /// </summary>
        private void myDataBind()
		{
            var objs = DataProvider.OrgTypeProvider.GetAll() as ListBase<OrgTypeInfo>;
            dg_OrgType.DataSource = objs;
			dg_OrgType.DataBind();
        }
        #endregion

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private static void InitializeComponent()
		{    
		}
		#endregion

        #region Event
        /// <summary>
        /// 页面加载事件。
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
        /// ToolBar按钮的点击事件。
        /// </summary>
        /// <param name="item">ToolbarItem类型：触发事件的ToolbarItem。</param>
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
