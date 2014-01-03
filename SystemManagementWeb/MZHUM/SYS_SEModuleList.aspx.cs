using System;
using ComponentArt.Web.UI;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SEModuleList : BasePage
    {
        #region Field
        private static readonly string SEMODULE_DELETE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEModuleDeleteFailed"));
        private static readonly string SEMODULE_DELETE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEModuleDeleteSuccess"));
        private static readonly string SECONTROL_DELETE_FAILED = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlDeleteFailed"));
        private static readonly string SECONTROL_DELETE_SUCCESS = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SEControlDeleteSuccess"));

        private ListBase<SEDataTypeInfo> DataTypes;
        private ListBase<SEControlTypeInfo> ControlTypes;
        #endregion

        #region property
        public short ProductCode
        {
            get { return short.Parse(this.hfProductCode.Value); }
            set { this.hfProductCode.Value = value.ToString();}
        }
        public string ModuleId
        {
            get { return this.hfModuleId.Value; }
            set { this.hfModuleId.Value = value;}
        }
        #endregion

        #region Method
        /// <summary>
        /// 绑定查询模块信息.
        /// </summary>
        private void BindModule()
        {
            this.tvModule.Nodes.Clear();

            var product = DataProvider.ProductProvider.GetByCode(this.ProductCode);
            var rootNode = new TreeViewNode {ID = "-1", Value = "-1", Text = product.ProductName, CssClass = "RootNode"};
            this.tvModule.Nodes.Add(rootNode);

            var objs = DataProvider.SEModuleProvider.GetByProduct(this.ProductCode);
            foreach (var obj in objs)
            {
                var oNode = new TreeViewNode
                                {
                                    ID = obj.Id,
                                    Value = obj.Id,
                                    Text = string.Format("{0}", obj.Name),
                                    ImageUrl = "Search.gif",
                                    ToolTip = string.Format("{0}",obj.Id),
                                };
                rootNode.Nodes.Add(oNode);
                rootNode.Expanded = true;
            }
            if(tvModule.Nodes.Count > 1)
            {
                this.ModuleId = tvModule.Nodes[1].Value;
            }
        }
        private void myDataBind()
        {
            var objs = DataProvider.SEControlProvider.GetAllByModuleId(this.ModuleId) as ListBase<SEControlInfo>;
            this.dg_SEControlInfo.DataSource = objs;
            this.dg_SEControlInfo.DataBind();
        }

        protected string GetDataTypeName(int id)
        {
            return this.DataTypes.Find(o => o.Id == id).Name;
        }
        protected string GetControlTypeName(int id)
        {
            return this.ControlTypes.Find(o => o.Id == id).Name;
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataTypes = DataProvider.SEDataTypeProvider.GetAll() as ListBase<SEDataTypeInfo>;
            this.ControlTypes = DataProvider.SEControlTypeProvider.GetAll() as ListBase<SEControlTypeInfo>;

            if(!IsPostBack)
            {
                if(!CurrentUser.HasRight(RightEnum.SEModule))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (!string.IsNullOrEmpty(Request["ProductCode"]))
                    this.ProductCode = short.Parse(Request["ProductCode"]);
                this.BindModule();
                this.myDataBind();
            }
            this.dg_SEControlInfo.AutoDataBind = myDataBind;
            
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindModule();
            this.myDataBind();
        }

        protected void MzhToolbar1_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            if(item.ItemId.ToUpper()=="DELETE")
            {
                if (!CurrentUser.HasRight(RightEnum.SEModule))
                {
                    this.SetNoRightInfo(true);
                    return;
                }
                if (this.dg_SEControlInfo.SelectedID.Length > 0)
                {
                    if (!DataProvider.SEControlProvider.Delete(int.Parse(this.dg_SEControlInfo.SelectedID)))
                    {
                        AddScript(SECONTROL_DELETE_FAILED);
                    }
                    else
                    {
                        AddScript(SECONTROL_DELETE_SUCCESS);
                        this.myDataBind();
                    }
                }
            }
        }

        protected void tvModule_NodeSelected(object sender, ComponentArt.Web.UI.TreeViewNodeEventArgs e)
        {
            this.ModuleId = e.Node.Value;
            this.myDataBind();
        }

        protected void MzhToolbar_Module_ItemPostBack(Shmzh.Web.UI.Controls.ToolbarItem item)
        {
            switch (item.ItemId.ToUpper())
            {
                case "DELETE":
                    if(!CurrentUser.HasRight(RightEnum.SEModule))
                    {
                        this.SetNoRightInfo(true);
                        return;
                    }
                    if(this.tvModule.SelectedNode == null)
                    {
                        AddScript("<script>alert('没有选中的查询模块！');</script>");
                    }
                    else
                    {
                        if (DataProvider.SEModuleProvider.Delete(this.ModuleId))
                        {
                            this.BindModule();
                            this.myDataBind();
                            this.ModuleId = string.Empty;
                            AddScript(SEMODULE_DELETE_SUCCESS_SCRIPT);
                        }
                        else
                        {
                            AddScript(SEMODULE_DELETE_FAILED_SCRIPT);
                        }
                    }
                    break;
            }
        }
        #endregion
    }
}
