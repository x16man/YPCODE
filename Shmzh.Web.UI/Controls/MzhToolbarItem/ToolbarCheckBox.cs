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
	public class ToolbarCheckBox : ToolbarItem, IPostBackToolbarItem
	{
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
		#region members
		protected string m_Cellpadding = "0";
		protected string m_Cellspacing = "0";
		
		protected string m_TableClass = "labelTable";
		/// <summary>
		/// Contained textbox control which is rendered to the client.
		/// </summary>
		protected CheckBox checkBox;
		/// <summary>
		/// Raised if the item's text was changed.
		/// </summary>
		public event ItemEventHandler ItemSubmitted;
		#endregion

		#region properties
		/// <summary>
		/// CheckBox的宽度。
		/// </summary>
		[Category("Toolbar")]
		[Description("ToolbarCheckBox的宽度。")]
		public override Unit Width
		{	
			get {return this.checkBox.Width;}
			set {this.checkBox.Width = value;}
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
			get { return checkBox.Text; }
			set { checkBox.Text = value; }
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
			get { return checkBox.AutoPostBack; }
			set { this.checkBox.AutoPostBack = value; }
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
		/// 获取或设置一个值，该值指示是否已选中CheckBox控件。
		/// </summary>
		[Category("Toolbar")]
		[Description("获取或设置一个值，该值指示是否已选中CheckBox控件。")]
		public bool Checked
		{
			get {return checkBox.Checked;}
			set {checkBox.Checked = value;}
		}
		#endregion

		#region intialization
		/// <summary>
		/// Inits the control.
		/// </summary>
		public ToolbarCheckBox()
		{
			this.checkBox = new CheckBox
			                    {
			                        CssClass = "toolbarCheckBox",
			                    };
		    //Logger.Info(string.Format("checkBox's CausesValidation is :{0}", this.CausesValidation));
		    this.checkBox.CheckedChanged +=checkBox_CheckedChanged;
		}
		/// <summary>
		/// Adds the internal TextBox control to the item's
		/// <c>Controls</c> collection.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
            string preTable = string.Format("<table class=\"{0}\" style=\"{1}\" title=\"{2}\" cellspacing=\"0\"	cellpadding=\"0\" unselectable=\"on\"><tbody><tr><td style=\"position:relative\">", string.IsNullOrEmpty(this.CssClass) ? this.TableClass : this.CssClass, this.Style.Value, this.ToolTip);
			this.Controls.Add(new LiteralControl(preTable));
			this.Controls.Add(new LiteralControl("<td>"));
            this.checkBox.ID = "check";
		    this.checkBox.SkinID = this.SkinID;
            this.Controls.Add(checkBox);
			
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
		    this.checkBox.Enabled = this.Enabled;
            this.checkBox.CausesValidation = this.CausesValidation;
            this.checkBox.ValidationGroup = this.ValidationGroup;
			this.checkBox.ApplyStyle(this.ControlStyle);
			this.checkBox.CopyBaseAttributes(this);
			base.RenderContents (writer);
		}

		#endregion


		#region event handling

		/// <summary>
		/// Bubbles a Checked change event of the contained checkbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			if (this.ItemSubmitted != null) ItemSubmitted(this);
		}
		#endregion

		
	}
}
