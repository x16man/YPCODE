using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;


namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// ToolbarCalendar 的摘要说明。
	/// </summary>
	[ToolboxBitmap(typeof(ToolbarChooser),"Shmzh.Web.UI.Controls.ToolbarCalendar.bmp")]
	public class ToolbarChooser: ToolbarItem, IPostBackToolbarItem
	{
		#region 成员变量
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		protected string m_TableClass = "labelTable";
		/// <summary>
		/// Contained textbox control which is rendered to the client.
		/// </summary>
		protected TextBox textBox;

	    protected HiddenField hfValue;
		/// <summary>
		/// Raised if the item's text was changed.
		/// </summary>
		public event ItemEventHandler ItemSubmitted;
		protected string m_Cellpadding = "0";
		protected string m_Cellspacing = "0";
		private const string CHOOSER_SCRIPT_ID ="MzhWeb_Chooser_Script_1.00";
		private readonly string CHOOSER_SCRIPT = string.Format("<script src=\"{0}My97DatePicker/WdatePicker.js\" type=\"text/javascript\"></script>",ResourceRoot.URL);
		#endregion

		#region 属性
		/// <summary>
		/// ToolbarItem的css样式名。
		/// </summary>
		[Category("Toolbar"),Description("ToolbarItem的css样式名称。")]
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
		/// ToolbarTextBox的文本。
		/// </summary>
		[Category("Toolbar"),DefaultValue(""),Description("文本值"),Localizable(true)]
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
				textBox.Text = value; 
			}
		}
	    public string Value
	    {
	        get
	        {
	            this.EnsureChildControls();
	            return hfValue.Value;
	        }
            set
            {
                this.EnsureChildControls();
                hfValue.Value = value;
            }
	    }
		/// <summary>
		/// 是否可以更改控件中的文本。
		/// </summary>
		[Category("Toolbar"),DefaultValue("True"),Description("是否可以更改控件中的文本"),Localizable(true)]
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
        /// 是否只读，不能弹出日历。
        /// </summary>
	    [Category("Toolbar"), DefaultValue("False"), Description("是否只是显示不弹出日历选择。"), Localizable(true)]
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
		/// ToolbarItem的Cellpadding。
		/// </summary>
		[Category("Toolbar"),Description("ToolbarItem的Cellpadding。")]
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
		/// ToolbarItem的Cellpadding。
		/// </summary>
		[Category("Toolbar"),Description("ToolbarItem的Cellspacing。")]
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
        /// TextBox的列数。
        /// </summary>
        [Category("Appearance"),DefaultValue(10),Description("TextBox的列数")]
        public virtual int Columns
        {
            get
            {
                object o = ViewState["Columns"];
                return ((o == null) ? 50 : (int)o);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Columns", "无效的列数");
                }
                ViewState["Columns"] = value;
            }
        }
        /// <summary>
        /// TextBox的最大长度。
        /// </summary>
        [Category("Appearance"), DefaultValue(50), Description("TextBox的最大长度")]
        public virtual int MaxLength
        {
            get
            {
                object o = ViewState["MaxLength"];
                return ((o == null) ? 50 : (int)o);
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
        /// <summary>
        /// 弹出窗口的URL。
        /// </summary>
	    public string PopupUrl
	    {
            get
            {
                object o = ViewState["PopupUrl"];
                return ((o == null) ? string.Empty : o.ToString());
            }
            set
            {
                ViewState["PopupUrl"] = value;
            }
	    }
	    public int PopupWidth
	    {
            get
            {
                object o = ViewState["PopupWidth"];
                return ((o == null) ? 500 : (int)o);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                ViewState["PopupWidth"] = value;
            }
	    }
        public int PopupHeight
        {
            get
            {
                object o = ViewState["PopupHeight"];
                return ((o == null) ? 400 : (int)o);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                ViewState["PopupHeight"] = value;
            }
        }
		#endregion

		#region 构造函数
		public ToolbarChooser()
		{
            this.hfValue = new HiddenField();
			this.textBox = new TextBox{CssClass = "chooserTextBox",};
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
            var preTable = string.Format("<table class=\"{0}\" style=\"{1}\" title=\"{2}\" cellspacing=\"0\"	cellpadding=\"0\" unselectable=\"on\"><tbody><tr>", string.IsNullOrEmpty(this.CssClass) ? this.TableClass : this.CssClass, this.Style.Value, this.ToolTip);
			
            this.Controls.Add(new LiteralControl(preTable));
            this.Controls.Add(new LiteralControl("<td>"));
		    this.hfValue.ID = "hfValue";
            this.Controls.Add(hfValue);

            this.textBox.ID = "txtText";
		    this.textBox.SkinID = this.SkinID;
            this.Controls.Add(textBox);

			//Logger.Info("calendar");
			this.Controls.Add(new LiteralControl("</td><td>"));
			this.Controls.Add(new LiteralControl("<div class=\"chooserPicker\">"));
            if(this.ShowOnly)
                this.Controls.Add(new LiteralControl("<div class=\"chooserPickerIcon\"></div></div></td></tr></tbody></table>"));
            else
                this.Controls.Add(new LiteralControl(string.Format("<div id=\"{0}_icon"+"\" class=\"chooserPickerIcon\" onclick=\"chooserPopup(this.id,'{1}','{2}','{3}',{4},{5})\"></div></div></td></tr></tbody></table>",this.ClientID,this.hfValue.ClientID,this.textBox.ClientID,this.PopupUrl,this.PopupWidth,this.PopupHeight)));
		}
		#endregion

		#region rendering
        /// <summary>
        /// Prevents rendering of the control itself.
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }
        /// <summary>
        /// Prevents rendering of the control itself.
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
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
			//this.textBox.CopyBaseAttributes(this);
			
			base.RenderContents (writer);
            //Logger.Info("RenderContents");
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
