namespace Shmzh.Web.UI.Controls
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.Drawing;
    /// <summary>
    /// ToolbarCalendar ��ժҪ˵����
    /// </summary>
    [ToolboxBitmap(typeof(ToolbarCalendar),"Shmzh.Web.UI.Controls.ToolbarCalendar.bmp")]
    public class ToolbarCalendar: ToolbarItem, IPostBackToolbarItem
    {
        #region ��Ա����
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected string m_TableClass = "labelTable";
        /// <summary>
        /// Contained textbox control which is rendered to the client.
        /// </summary>
        protected TextBox textBox;
        /// <summary>
        /// Raised if the item's text was changed.
        /// </summary>
        public event ItemEventHandler ItemSubmitted;
        protected string m_Cellpadding = "0";
        protected string m_Cellspacing = "0";
        private const string CALENDAR_SCRIPT_ID ="MzhWeb_Calendar_Script_1.00";
        private readonly string CALENDAR_SCRIPT = string.Format("<script src=\"{0}My97DatePicker/WdatePicker.js\" type=\"text/javascript\"></script>",ResourceRoot.URL);
        #endregion

        #region ����
        /// <summary>
        /// ToolbarItem��css��ʽ����
        /// </summary>
        [Category("Toolbar"),Description("ToolbarItem��css��ʽ���ơ�")]
        public string TableClass
        {
            get 
            {
                this.EnsureChildControls();
                return m_TableClass;
            }
            set 
            {
                this.EnsureChildControls();
                this.m_TableClass = value;
            }
        }
        /// <summary>
        /// ToolbarTextBox���ı���
        /// </summary>
        [Category("Toolbar"),DefaultValue(""),Description("�ı�ֵ"),Localizable(true)]
        public string Text
        {
            get 
            {
                this.EnsureChildControls();
                return textBox.Text; 
            }
            set 
            { 
                this.EnsureChildControls();
                try
                {
                    var tempdate = DateTime.Parse(value);
                    textBox.Text = tempdate.ToString("yyyy-MM-dd");
                }
                catch
                {

                    textBox.Text = "";
                }
            }
        }
        public TextBox InnerTextBox
        {
            get { return this.textBox; }
        }
        /// <summary>
        /// �Ƿ���Ը��Ŀؼ��е��ı���
        /// </summary>
        [Category("Toolbar"),DefaultValue("True"),Description("�Ƿ���Ը��Ŀؼ��е��ı�"),Localizable(true)]
        public bool ReadOnly
        {
            get
            {
                return this.textBox.Attributes["readonly"] != null && this.textBox.Attributes["readonly"] == "readonly";
            }
            set {
                if (value)
                    this.textBox.Attributes["readonly"] = "readonly";
                else
                    this.textBox.Attributes.Remove("readonly");
            }
        }
        /// <summary>
        /// �Ƿ�ֻ�������ܵ���������
        /// </summary>
        [Category("Toolbar"), DefaultValue("False"), Description("�Ƿ�ֻ����ʾ����������ѡ��"), Localizable(true)]
        public bool ShowOnly
        {
            get
            {
                object o = ViewState["showOnly"];
                return ((o == null) ? false : (bool)o);
            }
            set
            {
                ViewState["showOnly"] = value;
            }
        }
        /// <summary>
        /// Whether the control posts back to the
        /// server after being changed.
        /// </summary>
        [Category("Toolbar"),DefaultValue(false),Description("Whether the control performs an automatic PostBack if changed.")]
        public bool AutoPostBack
        {
            get 
            {
                this.EnsureChildControls();
                return textBox.AutoPostBack; 
            }
            set 
            { 
                this.EnsureChildControls();
                this.textBox.AutoPostBack = value; 
            }
        }
        /// <summary>
        /// ToolbarItem��Cellpadding��
        /// </summary>
        [Category("Toolbar"),Description("ToolbarItem��Cellpadding��")]
        public string Cellpadding
        {
            get 
            {
                this.EnsureChildControls();
                return m_Cellpadding;
            }
            set 
            {
                this.EnsureChildControls();
                m_Cellpadding = value;
            }
        }
        /// <summary>
        /// ToolbarItem��Cellpadding��
        /// </summary>
        [Category("Toolbar"),Description("ToolbarItem��Cellspacing��")]
        public string Cellspacing
        {
            get 
            {
                this.EnsureChildControls();
                return m_Cellspacing;
            }
            set 
            {
                this.EnsureChildControls();
                m_Cellspacing = value;
            }
        }
        /// <summary>
        /// TextBox��������
        /// </summary>
        [Category("Appearance"),DefaultValue(10),Description("TextBox������")]
        public virtual int Columns
        {
            get
            {
                object o = ViewState["Columns"];
                return ((o == null) ? 10 : (int)o);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Columns", "��Ч������");
                }
                ViewState["Columns"] = value;
            }
        }
        /// <summary>
        /// TextBox����󳤶ȡ�
        /// </summary>
        [Category("Appearance"), DefaultValue(10), Description("TextBox����󳤶�")]
        public virtual int MaxLength
        {
            get
            {
                object o = ViewState["MaxLength"];
                return ((o == null) ? 10 : (int)o);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                ViewState["MaxLength"] = value;
            }
        }
        public virtual string OnClientPropertyChange
        {
            get 
            { 
                object o = ViewState["OnClientPropertyChange"];
                return ((o == null) ? string.Empty : o.ToString());
            }
            set { ViewState["OnClientPropertyChange"] = value; }
        }
        public virtual string OnClientInput
        {
            get 
            { 
                object o = ViewState["OnClientInput"];
                return ((o == null) ? string.Empty : o.ToString());
            }
            set { ViewState["OnClientInput"] = value; }
        }
        #endregion

        #region ���캯��
        public ToolbarCalendar()
        {
            this.textBox = new TextBox{CssClass = "calendarDate"};
            this.textBox.TextChanged += textBox_TextChanged;
        }
        /// <summary>
        /// Adds the internal TextBox control to the item's
        /// <c>Controls</c> collection.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit (e);
            this.textBox.ID = "Date";
            this.textBox.SkinID = this.SkinID;
            this.Controls.Add(textBox);
        }
        #endregion

        #region rendering
        /// <summary>
        /// Prevents rendering of the control itself.
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            var preTable =
                string.Format(
                    "<table class=\"{0}\" style=\"{1}\" title=\"{2}\" cellspacing=\"0\" cellpadding=\"0\" unselectable=\"on\"><tbody><tr><td>",
                    this.TableClass, this.Style.Value,
                    this.ToolTip);
            var literalCtrlPreTable = new LiteralControl(preTable);
            //this.Controls.Add(literalCtrlPreTable);
            //this.Controls.Add(new LiteralControl("<td>"));
            literalCtrlPreTable.RenderControl(writer);

        }
        /// <summary>
        /// Prevents rendering of the control itself.
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            var endTable = string.Format("</td><td><div class=\"datePicker\">{0}",
                                         this.ShowOnly
                                             ? "<div class=\"datePickerIcon\"></div></div></td></tr></tbody></table>"
                                             : "<div class=\"datePickerIcon\" onclick=\"WdatePicker({el:$dp.$('" +
                                               this.textBox.ClientID + "')})\"></div></div></td></tr></tbody></table>");
            if (this.ShowOnly)
                endTable = "</td></tr></table>";
            else
                string.Format("</td><td><div class=\"datePicker\">{0}",
                                         this.ShowOnly
                                             ? "<div class=\"datePickerIcon\"></div></div></td></tr></tbody></table>"
                                             : "<div class=\"datePickerIcon\" onclick=\"WdatePicker({el:$dp.$('" +
                                               this.textBox.ClientID + "')})\"></div></div></td></tr></tbody></table>");
            var literalCtrlEndTable = new LiteralControl(endTable);
            literalCtrlEndTable.RenderControl(writer);
        }
        /// <summary>
        /// ��PreRender�¼���ʱ��,��ҳ����ע��JS�ű���.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender (e);

            if (!Page.ClientScript.IsClientScriptBlockRegistered(CALENDAR_SCRIPT_ID))
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),CALENDAR_SCRIPT_ID, CALENDAR_SCRIPT);
        }
        /// <summary>
        /// Renders the contained textbox control.
        /// </summary>
        /// <param name="writer"></param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            this.textBox.Enabled = this.Enabled;
            this.textBox.CausesValidation = this.CausesValidation;
            this.textBox.ValidationGroup = this.ValidationGroup;
            this.textBox.Columns = this.Columns;
            this.textBox.MaxLength = this.MaxLength;
            this.textBox.ApplyStyle(this.ControlStyle);

            if (!string.IsNullOrEmpty(this.OnClientPropertyChange))
            {
                this.textBox.Attributes.Add("onpropertychange",this.OnClientPropertyChange);
            }
            if (!string.IsNullOrEmpty(this.OnClientInput))
            {
                this.textBox.Attributes.Add("oninput",this.OnClientInput);
            }
            if(this.ShowOnly)
            {
                this.textBox.CssClass += " showOnly";
                
            }
            //base.RenderContents (writer);
            this.textBox.RenderControl(writer);
        }
        #endregion

        #region event handling
        /// <summary>
        /// Bubbles a text change event of the contained textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.ItemSubmitted != null) ItemSubmitted(this);
        }

        #endregion
    }
}
    