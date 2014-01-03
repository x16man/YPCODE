using System.Data.SqlClient;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
	/// <summary>
	/// SYS_OrgTypeEdit 的摘要说明。
	/// </summary>
	public partial class SYS_OrgTypeEdit : BasePage
    {
        #region Field
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    private static readonly string NONUNIQUECODE_SCRIPT = string.Format(ALERT_FORMATSTRING,ConfigCommon.GetMessageValue("OrgTypeCodeNonUnique"));
	    private static readonly string INSERTSUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("OrgTypeInsertSuccess"));
	    private static readonly string INSERTFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("OrgTypeInsertFailed"));
	    private static readonly string UPDATESUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("OrgTypeUpdateSuccess"));
        private static readonly string UPDATEFAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("OrgTypeUpdateFailed"));
        
#pragma warning restore 169
        #endregion

        #region Property
        /// <summary>
        /// 操作模式。
        /// </summary>
        string OP
        {
            get { return this.ViewState["OP"].ToString(); }
            set { this.ViewState["OP"] = value; }
        }
        /// <summary>
        /// 组织类型编号。
        /// </summary>
        string Code
        {
            get { return this.ViewState["Code"].ToString(); }
            set { this.ViewState["Code"] = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// 复位。
        /// </summary>
        private void Reset()
        {
            this.tb_code.Enabled = true;
            this.tb_code.Text = string.Empty;
            this.tb_cnname.Text = string.Empty;
            this.tb_enname.Text = string.Empty;
            this.tb_level.Text = string.Empty;
            this.chkIsValid.Checked = true;
        }
        /// <summary>
        /// 绑定数据到控件。
        /// </summary>
        private void MyDataBind()
        {
            var obj = DataProvider.OrgTypeProvider.GetByCode(this.Code);
            tb_code.Text = obj.Code;
            tb_code.Enabled = false;
            tb_cnname.Text = obj.CnName;
            tb_enname.Text = obj.EnName;
            tb_level.Text = obj.Level.ToString();
            this.chkIsValid.Checked = obj.IsValid == "Y" ? true : false;
        }
        /// <summary>
        /// 保存。
        /// </summary>
        private void Save()
        {
            var obj = new OrgTypeInfo
                          {
                              Code = this.tb_code.Text.Trim(),
                              CnName = this.tb_cnname.Text.Trim(),
                              EnName = this.tb_enname.Text.Trim(),
                              Level = short.Parse(this.tb_level.Text.Trim()),
                              IsValid = (this.chkIsValid.Checked ? "Y" : "N")
                          };
            var obj1 = new TB_SYSORGTPInfo
                           {
                               TypeId = 0,
                               ClassOrder = obj.Level,
                               TypeName = obj.CnName,
                               Enable = this.chkIsValid.Checked
                           };

            if (this.OP == "Add")
            {
                if (DataProvider.OrgTypeProvider.IsExistCode(obj.Code))
                {
                    AddScript(NONUNIQUECODE_SCRIPT);
                }
                else
                {
                    if (isSynchronization() && !DataProvider.TB_SYSORGTPProvider.IsExistName(obj.CnName))
                    {
                        using (var conn = new SqlConnection(ConnectionString.PubData))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (DataProvider.OrgTypeProvider.Insert(obj, trans))
                            {
                                if (DataProvider.TB_SYSORGTPProvider.Insert(obj1,trans))
                                {
                                    AddScript(INSERTSUCCESS_SCRIPT);
                                    AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                                    this.tb_code.Enabled = false;
                                    trans.Commit();
                                }
                                else
                                {
                                    AddScript(INSERTFAILED_SCRIPT);
                                    trans.Rollback();
                                }
                            }
                            else
                            {
                                AddScript(INSERTFAILED_SCRIPT);
                                trans.Rollback();
                            }
                        }
                    }
                    else
                    {
                        if (DataProvider.OrgTypeProvider.Insert(obj))
                        {
                            AddScript(INSERTSUCCESS_SCRIPT);
                            AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                            this.tb_code.Enabled = false;
                        }
                        else
                        {
                            AddScript(INSERTFAILED_SCRIPT);
                        }
                    }
                }
            }
            else
            {
                if(isSynchronization())
                {
                    var oldObj = DataProvider.OrgTypeProvider.GetByCode(this.tb_code.Text.Trim());
                    var oldObj1 = DataProvider.TB_SYSORGTPProvider.GetByTypeName(oldObj.CnName);
                    if(oldObj1 == null)//工作流中不存在，需要执行Insert操作。
                    {
                        var newObj1 = new TB_SYSORGTPInfo
                                          {
                                              TypeId = 0,
                                              ClassOrder = obj.Level,
                                              TypeName = obj.CnName,
                                              Enable = this.chkIsValid.Checked
                                          };
                        using(var conn = new SqlConnection(ConnectionString.PubData))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if(DataProvider.OrgTypeProvider.Update(obj, trans) && DataProvider.TB_SYSORGTPProvider.Insert(newObj1, trans))
                            {
                                AddScript(UPDATESUCCESS_SCRIPT);
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                                tb_code.Enabled = false;
                                trans.Commit();
                            }
                            else
                            {
                                AddScript(UPDATEFAILED_SCRIPT);
                                tb_code.Enabled = false;
                                trans.Rollback();
                            }
                        }

                    }
                    else//工作流中已经存在，需要执行Update操作。
                    {
                        oldObj1.ClassOrder = obj.Level;
                        oldObj1.TypeName = obj.CnName;
                        oldObj1.Enable = this.chkIsValid.Checked;
                        using (var conn = new SqlConnection(ConnectionString.PubData))
                        {
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            if (DataProvider.OrgTypeProvider.Update(obj, trans) && DataProvider.TB_SYSORGTPProvider.Update(oldObj1, trans))
                            {
                                AddScript(UPDATESUCCESS_SCRIPT);
                                AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                                tb_code.Enabled = false;
                                trans.Commit();
                            }
                            else
                            {
                                AddScript(UPDATEFAILED_SCRIPT);
                                tb_code.Enabled = false;
                                trans.Rollback();
                            }
                        }
                    }
                }
                else
                {
                    if (DataProvider.OrgTypeProvider.Update(obj))
                    {
                        AddScript(UPDATESUCCESS_SCRIPT);
                        AddScript("refresh", REFRESHPARENTANDCLOSE_SCRIPT);
                        tb_code.Enabled = false;
                    }
                    else
                    {
                        AddScript(UPDATEFAILED_SCRIPT);
                        tb_code.Enabled = false;
                    }
                }
                
                
            }
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
            if (!IsPostBack)
            {
                if (!CurrentUser.HasRight(RightEnum.OrgTypeMaintain))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!string.IsNullOrEmpty(Request["code"]))
                {
                    this.OP = "Edit";
                    Code = Request["code"];
                    this.MyDataBind();
                }
                else
                {
                    this.OP = "Add";
                }
            }
            this.tbiAdd.Visible = false;
        }
        /// <summary>
        /// Toolbar的回送事件。
        /// </summary>
        /// <param name="item">ToolbarItem类型：触发事件的ToolbarItem。</param>
        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId)
            {
                case "Add":
                    this.OP = "Add";
                    this.Reset();
                    break;
                case "Save":
                    this.Save();
                    break;
            }
        }
        #endregion
    }
}
