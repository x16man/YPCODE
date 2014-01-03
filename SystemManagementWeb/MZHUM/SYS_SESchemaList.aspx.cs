using System;
using ComponentArt.Web.UI;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace SystemManagement.MZHUM
{
    public partial class SYS_SESchemaList : BasePage
    {
        #region Field
        private static readonly string SESCHEMA_DELETE_FAILED_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SESchemaDeleteFailed"));
        private static readonly string SESCHEMA_DELETE_SUCCESS_SCRIPT = string.Format(ALERT_FORMATSTRING, ConfigCommon.GetMessageValue("SESchemaDeleteSuccess"));
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
            var objs = DataProvider.SESchemaProvider.GetByModuleAndUser(this.ModuleId, this.CurrentUser.LoginName) as ListBase<SESchemaInfo>;
            this.dg_SESchemaInfo.DataSource = objs;
            this.dg_SESchemaInfo.DataBind();
        }

        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["ProductCode"]))
                    this.ProductCode = short.Parse(Request["ProductCode"]);
                this.BindModule();
                this.myDataBind();
            }
            this.dg_SESchemaInfo.AutoDataBind = myDataBind;
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
                if (this.dg_SESchemaInfo.SelectedID.Length > 0)
                {
                    if (!DataProvider.SESchemaProvider.Delete(int.Parse(this.dg_SESchemaInfo.SelectedID)))
                    {
                        AddScript(SESCHEMA_DELETE_FAILED_SCRIPT);
                    }
                    else
                    {
                        AddScript(SESCHEMA_DELETE_SUCCESS_SCRIPT);
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
        #endregion
    }
}
