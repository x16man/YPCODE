using System;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.ComponentModel;
using Shmzh.Web.UI.Designer;
using System.Reflection;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.DALFactory;

namespace Shmzh.Web.UI.Controls
{
    /// <summary>
    /// Renders a toolbar control which acts as a container
    /// for <see cref="ToolbarItem"/> objects.
    /// </summary>
    [ParseChildren(true, "Items")]
    [PersistChildren(true)]
    [Designer(typeof(ToolbarDesigner))]
    [ToolboxData("<{0}:MzhToolbar runat=server></{0}:MzhToolbar>")]
    [ToolboxBitmap(typeof(MzhToolbar),"Shmzh.Web.UI.MzhToolbar.bmp")]
    [DefaultEvent("ItemPostBack")]
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand,Name = "FullTrust")]
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand,Name = "FullTrust")]
    public class MzhToolbar : WebControl, INamingContainer
    {
        #region members
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// ToolbarItem ���ϡ�
        /// </summary>
        protected ToolbarItemCollection m_items;
        private const string TOOLBAR_SCRIPT_ID ="MzhWeb_Toolbar_Script_1.00";
        private readonly string TOOLBAR_SCRIPT = string.Format("<script src=\"{0}Toolbar.js\"></script>",ResourceRoot.URL);
        private const string QueryItem_Width = "95%";
        #endregion

        #region ����
        /// <summary>
        /// Contains the items which were assigned to the toolbar.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ToolbarItemCollection Items
        {
            get { return this.m_items; }
        }
        
        /// <summary>
        /// ��ѯģ��ID��
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.Attribute)]
        public string SEModuleID
        {
            get
            {
                object s = ViewState["SEModuleID"];
                return ((s == null) ? string.Empty : s.ToString());
            }
            set
            {
                ViewState["SEModuleID"] = value;
            }
        }

        /// <summary>
        /// CheckBoxList�����з���
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.Attribute)]
        public RepeatDirection CheckBoxListRepeatDirection
        {
            get
            {
                object s = ViewState["CheckBoxListRepeatDirection"];
                return ((s == null) ? RepeatDirection.Horizontal : (RepeatDirection) s);
            }
            set
            {
                ViewState["CheckBoxListRepeatDirection"] = value;
            }
        }
        
        /// <summary>
        /// CheckBoxList�ĵ������ȡ�
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.Attribute)]
        public int CheckBoxListRepeatColumns
        {
            get
            {
                object s = ViewState["CheckBoxListRepeatColumns"];
                return ((s == null) ? 0 : (int)s);
            }
            set
            {
                ViewState["CheckBoxListRepeatColumns"] = value;
            }
        }
        /// <summary>
        /// ��ѯ���򲿷��Ƿ�չ����
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.Attribute)]
        public bool IsExpanded
        {
            get
            {
                object s = ViewState["IsExpanded"];
                return ((s == null) ? false : (bool)s);
            }
            set
            {
                ViewState["IsExpanded"] = value;
            }
        }
        /// <summary>
        /// ��ѯ�����SQL��
        /// </summary>
        public string SE_SQL
        {
            get
            {
                object s = ViewState["SE_SQL"];
                return ((s == null) ? string.Empty : s.ToString());
            }
            set
            {
                ViewState["SE_SQL"] = value;
            }
        }
        /// <summary>
        /// ��ǰ��¼�û���
        /// </summary>
        public User CurrentUser
        {
            get { return this.Page.Session["User"] as User; }
        }
        /// <summary>
        /// �Ƿ��������ѯ������
        /// </summary>
        public bool AllowSaveSchema
        {
            get 
            { 
                var s = ViewState["AllowSaveSchema"];
                return ((s == null) || bool.Parse(ViewState["AllowSaveSchema"].ToString()));
            }
            set { ViewState["AllowSaveSchema"] = value; }
        }
        #endregion

        #region item event

        /// <summary>
        /// Raised if an item of the toolbar that posts back to
        /// the server is being clicked.
        /// </summary>
        public event ItemEventHandler ItemPostBack;
        /// <summary>
        /// ��ѯ�����ѯ�¼���
        /// </summary>
        public event SEQueryEventHandler SEQuery_Click;
        /// <summary>
        /// ��ѯ���淽�������¼���
        /// </summary>
        public event SESaveEventHandler SESave_Click;
        #endregion

        #region intialization

        /// <summary>
        /// Inits the control.
        /// </summary>
        public MzhToolbar() : base("div")
        {
            //register event handler to synchronize the controls collection
            //with the items
            this.m_items = new ToolbarItemCollection();
            m_items.ItemAdded += items_ItemAdded;
            m_items.ItemRemoved += items_ItemRemoved;
            m_items.ItemsCleared += items_ItemsCleared;
        }
        #endregion

        #region rendering
        /// <summary>
        /// Adds table attributes to the rendered output.
        /// </summary>
        /// <param name="writer"></param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            //<div class="paneToolbar clearfix" style="margin:0pt;height:auto;">
            writer.AddAttribute(HtmlTextWriterAttribute.Class,"paneToolbar clearfix",true);
            //writer.AddStyleAttribute("margin","0pt");
            //writer.AddStyleAttribute("height","auto");
            base.AddAttributesToRender(writer);
        }
        /// <summary>
        /// Creates the table content with all items of the toolbar.
        /// </summary>
        /// <returns></returns>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            //Logger.Info("RenderContents");
            this.RenderToolbar(writer);
        }
        /// <summary>
        /// ����Toolbar��������װ��
        /// </summary>
        /// <param name="writer"></param>
        protected void RenderToolbar(HtmlTextWriter writer)
        {
            //Logger.Info("RenderToolbar");
            //<div class="paneToolbarLeftCap">
            writer.AddAttribute(HtmlTextWriterAttribute.Class,"paneToolbarLeftCap",true);
            writer.RenderBeginTag("div");
            writer.RenderEndTag();//</div>
            //<div class="toolbar" style="height:auto; visibility:visible;">
            writer.AddAttribute(HtmlTextWriterAttribute.Class,"toolbar clearfix");
            //writer.AddStyleAttribute("height","auto");
            writer.AddStyleAttribute("visibility","visible");
            writer.RenderBeginTag("div");
            //Render Toolbar Item.
            foreach(ToolbarItem item in this.m_items)
            {
                RenderToolbarItem(item,writer);
            }
            writer.RenderEndTag();//</div>

            //<div class="paneToolbarRightCap">
            writer.AddAttribute(HtmlTextWriterAttribute.Class,"paneToolbarRightCap",true);
            writer.RenderBeginTag("div");
            writer.RenderEndTag();//</div>
            
            //Rend Search Engin
            this.RenderSearchEngin(writer);
        }
        /// <summary>
        /// �����������档
        /// </summary>
        /// <param name="writer"></param>
        protected void RenderSearchEngin(HtmlTextWriter writer)
        {
            foreach (Control obj in this.Controls)
            {
                if (obj.ID == "QueryContainer")
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "QueryContainer");
                    foreach (Control obj1 in obj.Controls)
                    {
                        if (obj1.ID == "hfToggleState" && ((HiddenField)obj1).Value == "1")
                        {
                            if (((HiddenField)obj1).Value == "1")
                            {
                                writer.AddAttribute(HtmlTextWriterAttribute.Style, "display:none;");
                            }
                            else
                            {
                                writer.AddAttribute(HtmlTextWriterAttribute.Style, "display:block;");
                            }
                        }
                    }
                    writer.RenderBeginTag("div");
                    foreach (Control childControl in obj.Controls)
                    {
                        childControl.RenderControl(writer);
                    }

                    writer.RenderEndTag();

                }
            }
            writer.Write(this.GenerateToggleScript());
            writer.Write(this.GenerateSaveScript());
        }
        /// <summary>
        /// ����ToolbarItem.
        /// </summary>
        /// <param name="item">ToolbarItem</param>
        /// <param name="writer">HtmlWriter</param>
        protected void RenderToolbarItem(ToolbarItem item, HtmlTextWriter writer)
        {
            if (item.ItemId == "SEToggle")
            {
                foreach (Control obj in this.Controls)
                {
                    if (obj.ID == "QueryContainer")
                    {
                        foreach (Control obj1 in obj.Controls)
                        {
                            if (obj1.ID == "hfToggleState" && ((HiddenField)obj1).Value == "1")
                            {
                                ((ToolbarButton)item).IconClass = ((HiddenField)obj1).Value == "1" ? "expand" : "collapse";
                            }
                        }
                    }
                }
            }
            item.RenderControl(writer);
        }
        #endregion

        #region event handlers
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!string.IsNullOrEmpty(this.SEModuleID))
            {
                Logger.Debug(this.SEModuleID);
                if(AllowSaveSchema)
                {
                    var schemas = DataProvider.SESchemaProvider.GetByModuleAndUser(this.SEModuleID,this.CurrentUser.LoginName);
                    if(schemas.Count > 0)
                    {
                        //�ָ�����
                        var separator = new ToolbarSeparator();
                        this.Items.Add(separator);
                        //��ѯ����
                        var lblObj = new ToolbarLabel {ID = "tbiLblSESchema", Text = "��ѯ����"};
                        this.Items.Add(lblObj);

                        var ddlSESchema = new ToolbarDropdownList {ID = "tbiddlSESchema", AutoPostBack = true};
                        foreach(var schema in schemas)
                        {
                            ddlSESchema.InternalDropDownList.Items.Add(new ListItem(schema.SchemaName,schema.WhereClause));
                        
                            if (schema.IsDefault)
                            {
                                ddlSESchema.InternalDropDownList.Items[ddlSESchema.InternalDropDownList.Items.Count -1].Selected = true;
                                if (this.SEQuery_Click != null)
                                {
                                    var module = DataProvider.SEModuleProvider.GetById(this.SEModuleID);
                                    this.SE_SQL = string.Format("{0} {1} {2}", module.SQL, module.Where,schema.WhereClause);
                                }
                            }
                        }
                        ddlSESchema.InternalDropDownList.SelectedIndexChanged += InternalDropDownList_SelectedIndexChanged;
                        this.Items.Add(ddlSESchema);
                    }
                }
                
                //��ѯ�ֶΡ�
                var controls = (ListBase<SEControlInfo>) DataProvider.SEControlProvider.GetAllAvalibleByModuleId(this.SEModuleID);
                controls.Sort("SerialNo");
                if (controls.Count > 0)
                {
                    var toggleItem = new ToolbarButton
                    {
                        ID = "btnToggle",
                        CssClass = "buttonTable-Right",
                        ItemId = "SEToggle",
                        IconClass = "collapse",
                        OnClientClick = "toggle(this);",
                        Text = "�߼���ѯ",
                        //Text = "Advanced Search",
                        IsShowText = true,
                        ToolTip = "���չ����������ѯ����"
                    };
                    if (this.IsExpanded)
                        toggleItem.IconClass = "collapse";

                    this.Items.Add(toggleItem);
                    //��ѯ�����������
                    var queryContainer = new Panel { ID = "QueryContainer", };
                    this.Controls.Add(queryContainer);
                    //��¼չ��/������״̬����������
                    var toggleState = new HiddenField { ID = "hfToggleState", Value = "1" };
                    if (this.IsExpanded) toggleState.Value = "0";

                    var schemaName = new HiddenField { ID = "hfSchemaName", Value = "" };
                    queryContainer.Controls.Add(toggleState);
                    queryContainer.Controls.Add(schemaName);

                    //����һ��Table��
                    var layoutTable = new Table { ID = "QueryTableLayOut", Width = new Unit(QueryItem_Width), CssClass = "QueryTableLayOut" };
                    queryContainer.Controls.Add(layoutTable);
                    int trCount;
                    if (controls.Count % 3 == 0)
                        trCount = controls.Count/3;
                    else
                    {
                        trCount = controls.Count/3 + 1;
                    }
                    for (var i = 0; i < trCount;i++ )
                    {
                        var tr = new TableRow();
                        layoutTable.Rows.Add(tr);
                        tr.Cells.Add(new TableCell { Width = new Unit(60, UnitType.Pixel), CssClass = "querycell" });
                        tr.Cells.Add(new TableCell { Width = new Unit(150, UnitType.Pixel), CssClass = "querycell" });
                        tr.Cells.Add(new TableCell { Width = new Unit(60, UnitType.Pixel), CssClass = "querycell" });
                        tr.Cells.Add(new TableCell { Width = new Unit(150, UnitType.Pixel), CssClass = "querycell" });
                        tr.Cells.Add(new TableCell { Width = new Unit(60, UnitType.Pixel), CssClass = "querycell" });
                        tr.Cells.Add(new TableCell { Width = new Unit(150, UnitType.Pixel), CssClass = "querycell" });
                        tr.Cells.Add(new TableCell{CssClass = "queryCommand"});
                    }
                    for (var i = 0; i < controls.Count;i++ )
                    {
                        var labelObj = new Label
                        {
                            ID = string.Format("lbl{0}#{1}", controls[i].FieldName, controls[i].Id),
                            Text = controls[i].LabelName + "��",
                        };
                        layoutTable.Rows[i/3].Cells[i%3*2].Controls.Add(labelObj);
                        switch ((ControlTypeEnum)controls[i].ControlTypeId)
                        {
                            #region TextBox
                            case ControlTypeEnum.TextBox:
                                var txtObj = new TextBox
                                {
                                    ID = string.Format("{0}#{1}#{2}#{3}#{4}", controls[i].TableName, controls[i].FieldName, controls[i].DataTypeId, controls[i].Operator, controls[i].Id),
                                    Text = string.Empty,
                                    EnableViewState = true,
                                    TextMode = TextBoxMode.SingleLine,
                                    SkinID = this.SkinID,
                                    Width = new Unit(QueryItem_Width),
                                    CssClass = "textbox"
                                    
                                };
                                layoutTable.Rows[i / 3].Cells[i % 3*2 + 1].Controls.Add(txtObj);
                                break;
                            #endregion
                            #region CheckBox
                            case ControlTypeEnum.CheckBox:
                                var chkObj = new CheckBoxList
                                                 {
                                                     ID =
                                                         string.Format("{0}#{1}#{2}#{3}#{4}", controls[i].TableName,
                                                                       controls[i].FieldName, controls[i].DataTypeId,
                                                                       controls[i].Operator, controls[i].Id),
                                                     DataTextField = controls[i].DataTextField,
                                                     DataValueField = controls[i].DataValueField,
                                                     RepeatColumns = this.CheckBoxListRepeatColumns,
                                                     RepeatDirection = this.CheckBoxListRepeatDirection,
                                                     SkinID = this.SkinID,
                                                     CssClass = "checkbox",
                                                     DataSource = this.GetMethodResult(controls[i])
                                                 };
                                chkObj.DataBind();
                                layoutTable.Rows[i / 3].Cells[i % 3*2+ 1].Controls.Add(chkObj);
                                break;
                            #endregion
                            #region DropDownList
                            case ControlTypeEnum.DropDownList:
                                var ddlObj = new DropDownList
                                                 {
                                                     ID =
                                                         string.Format("{0}#{1}#{2}#{3}#{4}", controls[i].TableName,
                                                                       controls[i].FieldName, controls[i].DataTypeId,
                                                                       controls[i].Operator, controls[i].Id),
                                                     DataTextField = controls[i].DataTextField,
                                                     DataValueField = controls[i].DataValueField,
                                                     SkinID = this.SkinID,
                                                     Width = new Unit(QueryItem_Width),
                                                     CssClass = "dropdownlist",
                                                     DataSource = this.GetMethodResult(controls[i])
                                                 };
                                ddlObj.DataBind();
                                ddlObj.Items.Insert(0, new ListItem("-----δѡ��-----", "-1"));
                                layoutTable.Rows[i / 3].Cells[i % 3 * 2 + 1].Controls.Add(ddlObj);
                                break;
                            #endregion
                            #region Calendar
                            case ControlTypeEnum.Calendar:
                                var startDateObj = new ToolbarCalendar
                                {
                                    ID = string.Format("{0}#{1}#{2}#{3}#{4}#MoreThan", controls[i].TableName, controls[i].FieldName, controls[i].DataTypeId, controls[i].Operator, controls[i].Id),
                                    SkinID = this.SkinID,
                                    TableClass = "calendarTable",
                                    ReadOnly = true,
                                    
                                };
                                startDateObj.Attributes.Add("style","display:inline;");
                                
                                var endDateObj = new ToolbarCalendar
                                {
                                    ID = string.Format("{0}#{1}#{2}#{3}#{4}#LessThan", controls[i].TableName, controls[i].FieldName, controls[i].DataTypeId, controls[i].Operator, controls[i].Id),
                                    SkinID = this.SkinID,
                                    TableClass = "calendarTable",
                                    ReadOnly = true,
                                };
                                endDateObj.Attributes.Add("style","display:inline;");
                                layoutTable.Rows[i/3].Cells[i%3*2 + 1].Wrap = false;
                                layoutTable.Rows[i/3].Cells[i%3*2 + 1].Width = 200;
                                layoutTable.Rows[i / 3].Cells[i % 3 * 2 + 1].Controls.Add(startDateObj);
                                layoutTable.Rows[i / 3].Cells[i % 3 * 2 + 1].Controls.Add(new Label { ID = string.Format("link-{0}", controls[i].FieldName), Text = "��", });
                                layoutTable.Rows[i / 3].Cells[i % 3 * 2 + 1].Controls.Add(endDateObj);
                                
                                break;
                            #endregion
                            #region Vender
                            case ControlTypeEnum.Vender:
                                var venderObj = new ToolbarChooser
                                                    {
                                                        ID =
                                                            string.Format("{0}#{1}#{2}#{3}#{4}",
                                                                          controls[i].TableName,
                                                                          controls[i].FieldName, controls[i].DataTypeId,
                                                                          controls[i].Operator, controls[i].Id),
                                                        SkinID = this.SkinID,
                                                        PopupUrl =
                                                            ConfigurationManager.AppSettings["VenderChooserUrl"],
                                                        PopupWidth = 590,
                                                        PopupHeight = 400,
                                                    };
                                layoutTable.Rows[i / 3].Cells[i % 3 * 2 + 1].Controls.Add(venderObj);
                                break;
                            #endregion

                            #region Purpose
                            case ControlTypeEnum.Purpose:
                                var purposeObj = new ToolbarChooser
                                                     {
                                                         ID =
                                                             string.Format("{0}#{1}#{2}#{3}#{4}",
                                                                           controls[i].TableName,
                                                                           controls[i].FieldName, controls[i].DataTypeId,
                                                                           controls[i].Operator, controls[i].Id),
                                                         SkinID = this.SkinID,
                                                         PopupUrl =
                                                             ConfigurationManager.AppSettings["PurposeChooserUrl"],
                                                         PopupWidth = 500,
                                                         PopupHeight = 400,
                                                     };
                                layoutTable.Rows[i / 3].Cells[i % 3 * 2 + 1].Controls.Add(purposeObj);
                                break;
                            #endregion
                            #region Classify
                            case ControlTypeEnum.Classify:
                                var classifyObj = new ToolbarChooser
                                                      {
                                                          ID =
                                                              string.Format("{0}#{1}#{2}#{3}#{4}",
                                                                            controls[i].TableName,
                                                                            controls[i].FieldName,
                                                                            controls[i].DataTypeId,
                                                                            controls[i].Operator, controls[i].Id),
                                                          SkinID = this.SkinID,
                                                          PopupUrl =
                                                              ConfigurationManager.AppSettings["ClassifyChooserUrl"],
                                                          PopupWidth = 500,
                                                          PopupHeight = 400,
                                                      };
                                layoutTable.Rows[i / 3].Cells[i % 3 * 2 + 1].Controls.Add(classifyObj);
                                break;
                            #endregion 
                        }
                    }

                    var btnQuery = new Button { ID = "btnQuery", Text = "����" };
                    btnQuery.Click += btnQuery_Click;
                    
                    layoutTable.Rows[0].Cells[6].Controls.Add(btnQuery);
                    if(AllowSaveSchema)
                    {
                        var btnSave = new Button
                                          {
                                              ID = "btnSave",
                                              Text = "����",
                                              OnClientClick = "if(!saveSchema()) return;",
                                              UseSubmitBehavior = false
                                          };
                        btnSave.Click += btnSave_Click;
                    
                        layoutTable.Rows[0].Cells[6].Controls.Add(btnSave);
                    }

                }
            }
        }

        void InternalDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //���SQL��
            var seModule = DataProvider.SEModuleProvider.GetById(this.SEModuleID);
            var sql = string.Format("{0} {1} {2}", seModule.SQL, seModule.Where, ((DropDownList)sender).SelectedValue);

           if(this.SEQuery_Click!=null)
           {
               this.SEQuery_Click(sender, e, sql);
           }
        }
        /// <summary>
        /// ��ѯ�����ı��档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSave_Click(object sender, EventArgs e)
        {
            var whereClause = this.GenerateWhereClause();
            if(this.SESave_Click == null)
            {
                if (!string.IsNullOrEmpty(whereClause))
                {
                    var obj = new SESchemaInfo();
                    foreach (Control oCtrl in this.Controls)
                    {
                        if (oCtrl.ID == "QueryContainer")
                        {
                            foreach (Control obj1 in oCtrl.Controls)
                            {
                                if (obj1.ID == "hfSchemaName")
                                {
                                    obj.SchemaName = ((HiddenField) obj1).Value;
                                    obj.ModuleId = this.SEModuleID;
                                    obj.CreateTime = DateTime.Now;
                                    obj.UserCode = this.CurrentUser.LoginName;
                                    obj.WhereClause = whereClause;
                                    if (!DataProvider.SESchemaProvider.Insert(obj))
                                    {
                                        Logger.Error("��ѯ��������ʧ�ܣ�");
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(),"NoCondition","<script>alert('��ָ����ѯ����');</script>");
                }
            }
            else
            {
                SESave_Click(sender, e, whereClause);
            }
        }
        /// <summary>
        /// ��ѯ�����ѯ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnQuery_Click(object sender, EventArgs e)
        {
            //���SQL��
            var seModule = DataProvider.SEModuleProvider.GetById(this.SEModuleID);
            var sql = string.Format(" {0} {1} ",seModule.SQL,seModule.Where);
           
            if(this.SEQuery_Click != null)
            {
                string fullSQL;
                var whereClause = this.GenerateWhereClause();
                if(string.IsNullOrEmpty(whereClause.Trim()))
                {
                    fullSQL = string.Empty;
                }
                else
                {
                    fullSQL = sql + this.GenerateWhereClause();
                }
                this.SE_SQL = fullSQL;
                SEQuery_Click(sender, e, fullSQL);
            }
        }
        /// <summary>
        /// ��PreRender�¼���ʱ��,��ҳ����ע��JS�ű���.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender (e);

            if (!Page.ClientScript.IsClientScriptBlockRegistered(TOOLBAR_SCRIPT_ID))
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),TOOLBAR_SCRIPT_ID, TOOLBAR_SCRIPT);
        }
        /// <summary>
        /// Adds a new item to the internal <c>Controls</c>
        /// collection.
        /// </summary>
        /// <param name="item"></param>
        protected void items_ItemAdded(ToolbarItem item)
        {
            
            this.Controls.Add(item);

            if (item is IPostBackToolbarItem)
            {
                ((IPostBackToolbarItem)item).ItemSubmitted += Items_ItemSubmitted;
            }
        }

        /// <summary>
        /// Removes an item from the internal <c>Controls</c>
        /// collection.
        /// </summary>
        /// <param name="item"></param>
        protected void items_ItemRemoved(ToolbarItem item)
        {
            this.Controls.Remove(item);
        }

        /// <summary>
        /// Removes all controls from the internal control collection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void items_ItemsCleared(object sender, EventArgs e)
        {
            this.Controls.Clear();
        }

        /// <summary>
        /// Handles toolbar item events.
        /// </summary>
        /// <param name="item">ToolbarItem</param>
        protected void Items_ItemSubmitted(ToolbarItem item)
        {     
            //bubble event
            if (ItemPostBack != null) ItemPostBack(item);
        }

        #endregion

        #region private method
        /// <summary>
        /// ���ݲ�ѯ�ؼ���ָ���ķ��䷽������ȡ���ݼ���
        /// </summary>
        /// <param name="obj">��ѯ������ָ���Ĳ�ѯ��ؼ���</param>
        /// <returns></returns>
        private object GetMethodResult(SEControlInfo obj)
        {
            //����������ݰ󶨡�
            if (!string.IsNullOrEmpty(obj.Assembly) &&
                !string.IsNullOrEmpty(obj.ObjType) &&
                !string.IsNullOrEmpty(obj.Method))
            {
               var assemblyPath = AppDomain.CurrentDomain.BaseDirectory + "Bin\\" + obj.Assembly;
               var assembly = Assembly.LoadFrom(assemblyPath);
               // var assembly = Assembly.Load(obj.Assembly);
                if (assembly != null)
                {
                    var objType = assembly.GetType(obj.ObjType);
                    if (objType != null)
                    {
                        var methodName = obj.Method.Substring(0, obj.Method.IndexOf('('));
                        var method = objType.GetMethod(methodName);
                        if (method != null)
                        {
                            var parms = method.GetParameters();
                            var argumentString = obj.Method.Substring(obj.Method.IndexOf('(') + 1, obj.Method.Length - obj.Method.IndexOf('(') - 2);
                            var arguments = string.IsNullOrEmpty(argumentString) ? null : argumentString.Split(',');
                            var args = new object[parms.Length];

                            if (parms.Length > 0 && arguments != null && parms.Length == arguments.Length)
                            {
                                for (var j = 0; j < arguments.Length; j++)
                                {
                                    //�Է��������е�Ԥ�����������ֵ�滻��
                                    if (arguments[j] == PreDefinedArgument.CompanyCode)
                                        arguments[j] = ((User)Page.Session["User"]).Company;
                                    else if (arguments[j] == PreDefinedArgument.DeptCode)
                                        arguments[j] = ((User)Page.Session["User"]).DeptCode;
                                    else if (arguments[j] == PreDefinedArgument.LoginName)
                                        arguments[j] = ((User)Page.Session["User"]).LoginName;
                                    //����������ڲ���ת���ɶ�Ӧ��ֵ���͡�(Ŀǰֻ֧��ֵ���Ͳ�����)
                                    var inArgumentType = parms[j].ParameterType;
                                    var parseMethod = inArgumentType.GetMethod("Parse", new[] {typeof (string)});
                                    args[j] = parseMethod==null?arguments[j]:parseMethod.Invoke(null, new[] { arguments[j] });
                                }
                            }
                            try
                            {
                                if(method.IsStatic)//��̬������
                                {
                                    return objType.InvokeMember(method.Name, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, args);
                                }
                                //�Ǿ�̬������
                                var instance = assembly.CreateInstance(obj.ObjType);
                                var srcObj = objType.InvokeMember(method.Name, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, instance, args);
                                return srcObj;
                            }
                            catch(Exception ex)
                            {
                                Logger.Error(ex.Message);
                                return null;
                            }
                        }
                        Logger.Warn(string.Format("δ�ܻ�ȡ������{0}", methodName));
                        return null;
                    }
                    Logger.Warn(string.Format("δ�ܻ�ȡ�ࣺ{0}", obj.ObjType));
                    return null;
                }
                //Logger.Warn(string.Format("δ�ܼ��أ�{0}װ�伯��", assemblyPath));
                Logger.Warn(string.Format("δ�ܼ��أ�{0}װ�伯��", obj.Assembly));
                return null;
            }
            return null;
        }

        /// <summary>
        /// ����Toggle�Ľű���
        /// </summary>
        /// <returns></returns>
        private string GenerateToggleScript()
        {
            var sb = new StringBuilder();
            //Logger.Info(string.Format("SEModuleID:{0}",this.SEModuleID));
            if(!string.IsNullOrEmpty(this.SEModuleID))
            {
                sb.Append("\r\n<script type=\"text/javascript\">");
                sb.Append("\tfunction toggle(elm)");
                sb.Append("\t{");
                //sb.Append("\t\talert('ok');");
                sb.Append("\t\t$(\".QueryContainer\").toggle();");
                sb.Append("\t\t$(elm).find(\".buttonIconCell div\").toggleClass(\"expand\").toggleClass(\"collapse\");");
                sb.Append("\t\tvar toggleField = document.getElementById(\""+this.ClientID+"_hfToggleState\");");
                sb.Append("\t\ttoggleField.value = toggleField.value == \"1\" ? \"0\" : \"1\";");
                sb.Append("\t}\r\n");
                sb.Append("</script>\r\n");
            }
            return sb.ToString();
        }
        /// <summary>
        /// ������������ĵ�����������ű���
        /// </summary>
        /// <returns></returns>
        private string GenerateSaveScript()
        {
            var sb = new StringBuilder();
            if(!string.IsNullOrEmpty(this.SEModuleID))
            {
                sb.Append("\r\n<script type=\"text/javascript\">");
                sb.Append("\tfunction saveSchema()");
                sb.Append("\t{");
                sb.Append("\t\t var name = prompt(\"�������ѯ��������:\",\" \");");
                sb.Append("\t\t if(name) document.getElementById(\"" + this.ClientID + "_hfSchemaName\").value=name;");
                sb.Append("\t\t return name;");
                sb.Append("\t}\r\n");
                sb.Append("</script>\r\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// ���ɲ�ѯ��WhereClause���ֵ�SQL��䡣
        /// </summary>
        /// <returns></returns>
        private string GenerateWhereClause()
        {
            var solutionWhereClause = string.Empty;
            foreach (Control obj in this.Controls)
            {
                if (obj.ID == "QueryContainer")
                {
                    foreach (Control octrl in obj.Controls)
                    {
                        if (octrl.ID == "QueryTableLayOut")
                        {
                            foreach (Control oRow in octrl.Controls)
                            {
                                foreach (Control oCell in oRow.Controls)
                                {
                                    foreach (Control field in oCell.Controls)
                                    {
                                        var whereClause = string.Empty;
                                        var ss = field.ID.Split('#');

                                        #region �ı���

                                        if (field is TextBox) //�ı���
                                        {
                                            var fieldControl = (TextBox) field;
                                            switch (ss[3].ToUpper().Trim())
                                            {
                                                case "=":
                                                    switch ((DataTypeEnum) int.Parse(ss[2]))
                                                    {
                                                        case DataTypeEnum.Int:
                                                            whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                              ? string.Empty
                                                                              : string.Format(" {0}.{1} = {2}", ss[0],
                                                                                              ss[1],
                                                                                              DeleteKeyWord(fieldControl.Text));
                                                            break;
                                                        case DataTypeEnum.String:
                                                        case DataTypeEnum.DateTime:
                                                            whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                              ? string.Empty
                                                                              : string.Format(" {0}.{1} = '{2}'", ss[0],
                                                                                              ss[1],
                                                                                              DeleteKeyWord(fieldControl.Text));
                                                            break;
                                                    }
                                                    break;
                                                case "LIKE":
                                                    whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                      ? string.Empty
                                                                      : string.Format(" {0}.{1} Like '%{2}%'", ss[0],
                                                                                      ss[1],
                                                                                      DeleteKeyWord(fieldControl.Text));
                                                    break;
                                                default:
                                                    switch ((DataTypeEnum) int.Parse(ss[2]))
                                                    {
                                                        case DataTypeEnum.Int:
                                                            whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                              ? string.Empty
                                                                              : string.Format(" {0}.{1} = {2}", ss[0],
                                                                                              ss[1],
                                                                                              DeleteKeyWord(fieldControl.Text));
                                                            break;
                                                        case DataTypeEnum.String:
                                                        case DataTypeEnum.DateTime:
                                                            whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                              ? string.Empty
                                                                              : string.Format(" {0}.{1} = '{2}'", ss[0],
                                                                                              ss[1],
                                                                                              DeleteKeyWord(fieldControl.Text));
                                                            break;
                                                    }
                                                    break;
                                            }

                                            solutionWhereClause += string.IsNullOrEmpty(whereClause)
                                                                       ? string.Empty
                                                                       : string.IsNullOrEmpty(solutionWhereClause)
                                                                             ? whereClause
                                                                             : " And " + whereClause;
                                        }
                                            #endregion
                                            #region ����

                                        else if (field is ToolbarCalendar) //����
                                        {
                                            var fieldControl = (ToolbarCalendar) field;

                                            if (ss[5].ToLower() == "morethan")
                                                whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                  ? string.Empty
                                                                  : string.Format(" {0}.{1} >= '{2}'", ss[0], ss[1],
                                                                                  DeleteKeyWord(fieldControl.Text));
                                            else if (ss[5].ToLower() == "lessthan")
                                                whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                  ? string.Empty
                                                                  : string.Format(" {0}.{1} <= '{2}'", ss[0], ss[1],
                                                                                  DateTime.Parse(DeleteKeyWord(fieldControl.Text)).
                                                                                      AddDays(
                                                                                      1).
                                                                                      ToShortDateString());
                                            solutionWhereClause += string.IsNullOrEmpty(whereClause)
                                                                       ? string.Empty
                                                                       : string.IsNullOrEmpty(solutionWhereClause)
                                                                             ? whereClause
                                                                             : " And " + whereClause;
                                        }
                                            #endregion
                                            #region �����б�

                                        else if (field is DropDownList) //�����б�
                                        {
                                            var fieldControl = (DropDownList) field;
                                            if (fieldControl.SelectedValue != "-1")
                                            {
                                                switch ((DataTypeEnum) int.Parse(ss[2]))
                                                {
                                                    case DataTypeEnum.Int:
                                                        whereClause = string.Format(" {0}.{1} = {2}", ss[0], ss[1],
                                                                                    fieldControl.SelectedValue);
                                                        break;
                                                    case DataTypeEnum.String:
                                                    case DataTypeEnum.DateTime:
                                                        whereClause = string.Format(" {0}.{1} = '{2}'", ss[0], ss[1],
                                                                                    fieldControl.SelectedValue);
                                                        break;
                                                }
                                            }
                                            solutionWhereClause += string.IsNullOrEmpty(whereClause)
                                                                       ? string.Empty
                                                                       : string.IsNullOrEmpty(solutionWhereClause)
                                                                             ? whereClause
                                                                             : " And " + whereClause;
                                        }
                                            #endregion
                                            #region  ��ѡ��

                                        else if (field is CheckBoxList) //
                                        {
                                            var fieldControl = (CheckBoxList) field;
                                            var inScope = string.Empty;
                                            foreach (ListItem oItem in fieldControl.Items)
                                            {
                                                if (oItem.Selected)
                                                {
                                                    switch ((DataTypeEnum) int.Parse(ss[2]))
                                                    {
                                                        case DataTypeEnum.Int:
                                                            inScope +=
                                                                string.Format(inScope.Length == 0 ? "{0}" : ",{0}",
                                                                              oItem.Value);
                                                            break;
                                                        case DataTypeEnum.String:
                                                        case DataTypeEnum.DateTime:
                                                            inScope +=
                                                                string.Format(inScope.Length == 0 ? "'{0}'" : ",'{0}'",
                                                                              oItem.Value);
                                                            break;
                                                    }
                                                }
                                            }
                                            if (!string.IsNullOrEmpty(inScope))
                                            {
                                                whereClause = string.Format(" {0}.{1} In ({2}) ", ss[0], ss[1], inScope);
                                                solutionWhereClause += string.IsNullOrEmpty(solutionWhereClause)
                                                                           ? whereClause
                                                                           : " And " + whereClause;
                                            }
                                        }

                                        #endregion
                                        #region Chooser
                                        else if(field is ToolbarChooser)//ѡ��ؼ�
                                        {
                                            var fieldControl = (ToolbarChooser) field;
                                            switch ((DataTypeEnum) int.Parse(ss[2]))
                                            {
                                                case DataTypeEnum.Int:
                                                    whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                      ? string.Empty
                                                                      : string.Format("{0}.{1} = {2}", ss[0], ss[1],
                                                                                        fieldControl.Value);
                                                    break;
                                                case DataTypeEnum.String:
                                                    whereClause = string.IsNullOrEmpty(fieldControl.Text.Trim())
                                                                      ? string.Empty
                                                                      : string.Format("{0}.{1} = '{2}'", ss[0], ss[1],
                                                                                        fieldControl.Value);
                                                    break;
                                            }
                                            solutionWhereClause += string.IsNullOrEmpty(whereClause)
                                                                       ? string.Empty
                                                                       : string.IsNullOrEmpty(solutionWhereClause)
                                                                             ? whereClause
                                                                             : " And " + whereClause;
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
            }
            return solutionWhereClause;
        }
        /// <summary>
        /// �����û�����������ַ���
        /// </summary>
        /// <param name="inputString">�û�������ַ�����</param>
        /// <returns>�����Ժ���ַ�����</returns>
        private static string DeleteKeyWord(string inputString)
        {
            inputString = inputString.Trim();
            inputString = inputString.Replace("'", "");
            inputString = inputString.Replace(">", "");
            inputString = inputString.Replace("<", "");
            inputString = inputString.Replace("=", "");
            inputString = inputString.Replace("!", "");
            inputString = inputString.Replace("+", "");
            //inputString = inputString.Replace("/", "");
            //inputString = inputString.Replace("(", "");
            //inputString = inputString.Replace(")", "");
            //inputString = inputString.Replace("|", "");
            inputString = inputString.Replace("exec", "");
            inputString = inputString.Replace("xp_", "");
            inputString = inputString.Replace("sp_", "");
            inputString = inputString.Replace("declare", "");
            inputString = inputString.Replace("cmd", "");
            inputString = inputString.Replace("Union", "");
            inputString = inputString.Replace("//", "");
            inputString = inputString.Replace("..", "");
            inputString = inputString.Replace("Ox", "");
            inputString = inputString.Replace("--", "");
            //inputString = inputString.Replace(";", "");
            //inputString = inputString.Replace("\"", "");
            inputString = inputString.Replace("or", "");
            inputString = inputString.Replace("&", "");
            inputString = inputString.Replace("*", "");
            inputString = inputString.Replace("select", "");
            inputString = inputString.Replace("insert", "");
            inputString = inputString.Replace("delete", "");
            inputString = inputString.Replace("count", "");
            inputString = inputString.Replace("drop table", "");
            inputString = inputString.Replace("update", "");
            inputString = inputString.Replace("truncate", "");
            inputString = inputString.Replace("asc", "");
            inputString = inputString.Replace("mid", "");
            inputString = inputString.Replace("char", "");
            inputString = inputString.Replace("xp_cmdshell", "");
            inputString = inputString.Replace("master", "");
            inputString = inputString.Replace("net", "");
            inputString = inputString.Replace("localgroup", "");
            inputString = inputString.Replace("administrators", "");
            inputString = inputString.Replace("and", "");
            inputString = inputString.Replace("user", "");
            return inputString; 
        }

        #endregion
    }
    /// <summary>
    /// ��ѯ�ؼ�����ö�١�
    /// </summary>
    internal enum ControlTypeEnum
    {
        TextBox=1,
        CheckBox,
        DropDownList,
        Calendar,
        Vender,//��Ӧ��ѡ��
        Purpose,//��;ѡ��
        Classify,//��;���ࡣ
    }
    /// <summary>
    /// ��ѯ�ؼ���������ö�١�
    /// </summary>
    internal enum DataTypeEnum
    {
        String=1,Int,DateTime
    }
    /// <summary>
    /// ��ѯ�ؼ��е�Ԥ���������
    /// </summary>
    internal static class PreDefinedArgument
    {
        internal static string LoginName = "@LoginName";
        internal static string CompanyCode = "@CompanyCode";
        internal static string DeptCode = "@DeptCode";
    }
}
