using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;


namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// Composite control that renders a simple textbox.
	/// </summary>
	[ToolboxBitmap(typeof(ToolbarTextBox),"Shmzh.Web.UI.Controls.ToolbarTextBox.bmp")]
	public class ToolbarTextBox : ToolbarItem, IPostBackToolbarItem
	{

		#region members
		protected string m_Cellpadding = "0";
		protected string m_Cellspacing = "0";
		
		protected string m_TableClass = "labelTable";
		/// <summary>
		/// Contained textbox control which is rendered to the client.
		/// </summary>
		protected TextBox textBox;
		/// <summary>
		/// Raised if the item's text was changed.
		/// </summary>
		public event ItemEventHandler ItemSubmitted;
		#endregion

		#region properties
		/// <summary>
		/// 文本框的宽度。
		/// </summary>
		[Category("Toolbar")]
		[Description("ToolbarTextBox的宽度。")]
		public override Unit Width
		{	
			get {return this.textBox.Width;}
			set {this.textBox.Width = value;}
		}
		/// <summary>
		/// ToolbarItem的css样式名。
		/// </summary>
		[Category("Toolbar")]
		[Description("ToolbarItem的css样式名称。")]
		public string TableClass
		{
			get {return m_TableClass;}
			set {this.m_TableClass = value;}
		}
		/// <summary>
		/// ToolbarTextBox的文本。
		/// </summary>
		[DefaultValue("")]
		[Description("Item text")]
		[Localizable(true)]
		public string Text
		{
			get { return textBox.Text; }
			set { textBox.Text = value; }
		}
		/// <summary>
		/// Whether the control posts back to the
		/// server after being changed.
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue(false)]
		[Description("Whether the control performs an automatic PostBack if changed.")]
		public bool AutoPostBack
		{
			get { return textBox.AutoPostBack; }
			set { this.textBox.AutoPostBack = value; }
		}
		/// <summary>
		/// ToolbarItem的Cellpadding。
		/// </summary>
		[Category("Toolbar")]
		[Description("ToolbarItem的Cellpadding。")]
		public string Cellpadding
		{
			get {return m_Cellpadding;}
			set {m_Cellpadding = value;}
		}
		/// <summary>
		/// ToolbarItem的Cellpadding。
		/// </summary>
		[Category("Toolbar")]
		[Description("ToolbarItem的Cellspacing。")]
		public string Cellspacing
		{
			get {return m_Cellspacing;}
			set {m_Cellspacing = value;}
		}
        /// <summary>
        /// TextBox的列数。
        /// </summary>
        [Category("Appearance"), DefaultValue(10), Description("TextBox的列数")]
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
                    throw new ArgumentOutOfRangeException("Co" + "lumns", "无效的列数");
                }
                ViewState["Columns"] = value;
            }
        }
        /// <summary>
        /// TextBox的最大长度。
        /// </summary>
        [Category("Appearance"), DefaultValue(10), Description("TextBox的最大长度")]
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
        /// <summary>
        /// 是否可以更改控件中的文本。
        /// </summary>
        [Category("Toolbar"), DefaultValue("True"), Description("是否可以更改控件中的文本"), Localizable(true)]
        public bool ReadOnly
        {
            get
            {
                return this.textBox.Attributes["readonly"] != null && this.textBox.Attributes["readonly"] == "readonly";
            }
            set
            {
                if (value)
                    this.textBox.Attributes["readonly"] = "readonly";
                else
                    this.textBox.Attributes.Remove("readonly");
            }
        }
		#endregion

		#region intialization
		/// <summary>
		/// Inits the control.
		/// </summary>
		public ToolbarTextBox()
		{
			this.textBox = new TextBox {CssClass = "toolbarText"};
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

            var preTable = string.Format("<table class=\"{0}\" style=\"{1}\" title=\"{2}\" cellspacing=\"0\"	cellpadding=\"0\" unselectable=\"on\"><tbody><tr><td style=\"position:relative\">",this.TableClass,this.Style.Value,this.ToolTip);
            this.Controls.Add(new LiteralControl(preTable));
			this.Controls.Add(new LiteralControl("<td>"));
            this.textBox.ID = "text";
		    this.textBox.SkinID = this.SkinID;            		    
            this.Controls.Add(textBox);

			this.Controls.Add(new LiteralControl("</td></tr></tbody></table>"));
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
		    //this.textBox.CssClass = this.CssClass;
			this.textBox.ApplyStyle(this.ControlStyle);
			//this.textBox.CopyBaseAttributes(this);
			base.RenderContents (writer);
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
