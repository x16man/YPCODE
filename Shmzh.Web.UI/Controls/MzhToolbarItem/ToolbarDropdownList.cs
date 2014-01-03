namespace Shmzh.Web.UI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    /// <summary>
	/// Composite control that renders a simple textbox.
	/// </summary>
	//[ToolboxBitmap(typeof(ToolbarTextBox),"Shmzh.Web.UI.Controls.ToolbarTextBox.bmp")]
    public class ToolbarDropdownList : ToolbarItem, IPostBackToolbarItem
	{

		#region members
		protected string m_Cellpadding = "0";
		protected string m_Cellspacing = "0";
		
		protected string m_TableClass = "labelTable";
		
		
		/// <summary>
		/// Raised if the item's text was changed.
		/// </summary>
		public event ItemEventHandler ItemSubmitted;
        private DropDownList dropdownList;
		#endregion

		#region properties
		/// <summary>
		/// 获取或设置内含的DropdownList控件的宽度。
		/// </summary>
		[Category("Toolbar")]
		[Description("获取或设置内含的DropdownList控件的宽度。")]
		public override Unit Width
		{	
			get {return this.dropdownList.Width;}
			set {this.dropdownList.Width = value;}
		}
		/// <summary>
		/// 获取或设置DropdownList控件的外围Table的CSS样式。
		/// </summary>
		[Category("Toolbar")]
		[Description("获取或设置DropdownList控件的外围Table的CSS样式。")]
		public string TableClass
		{
			get {return this.m_TableClass;}
			set {this.m_TableClass = value;}
		}
		/// <summary>
		/// 获取ToolbarDropdownList控件中索引最小的选中项。
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue("")]
		[Description("获取ToolbarDropdownList控件中索引最小的选中项。")]
		[Localizable(true)]
		public ListItem SelectedItem
		{
			get { return dropdownList.SelectedItem; }
		}
		/// <summary>
		/// 获取ToolbarDropdownList控件选定项的值，或选择列表控件中包含指定值的项。
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue("")]
		[Description("获取列表控件选定项的值，或选择列表控件中包含指定值的项。")]
		[Localizable(true)]
		public string SelectedValue
		{
			get { return dropdownList.SelectedValue;}
			set { dropdownList.SelectedValue = value;}
		}
		/// <summary>
		/// 获取或设置ToolbarDropdownList控件中的选定项的索引。
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue("")]
		[Description("获取或设置ToolbarDropdownList控件中的选定项的索引。")]
		[Localizable(true)]
		public int SelectedIndex
		{
			get {return dropdownList.SelectedIndex;}
			set {dropdownList.SelectedIndex = value;}
		}
		/// <summary>
		/// 获取或设置一个值，该值指示当用户更改列表的选定内容时是否自动产生向服务器的回发。
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue(false)]
		[Description("获取或设置一个值，该值指示当用户更改列表的选定内容时是否自动产生向服务器的回发。")]
		public bool AutoPostBack
		{
			get { return dropdownList.AutoPostBack; }
			set { this.dropdownList.AutoPostBack = value; }
		}
		/// <summary>
		/// 获取或设置DropdownList控件的外围Table的CellPadding。
		/// </summary>
		[Category("Toolbar")]
		[Description("获取或设置DropdownList控件的外围Table的CellPadding。")]
		public string Cellpadding
		{
			get {return m_Cellpadding;}
			set {m_Cellpadding = value;}
		}
		/// <summary>
		/// 获取或设置DropdownList控件的外围Table的CellSpacing。
		/// </summary>
		[Category("Toolbar")]
		[Description("获取或设置DropdownList控件的外围Table的CellPadding。")]
		public string Cellspacing
		{
			get {return m_Cellspacing;}
			set {m_Cellspacing = value;}
		}
		/// <summary>
		/// 获取或设置一个值，该值指示是否启用DropdownList服务器控件。
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue("True")]
		[Description("获取或设置一个值，该值指示是否启用DropdownList服务器控件。")]
		[Localizable(true)]
		public override bool Enabled
		{
			get {return dropdownList.Enabled;}
			set {dropdownList.Enabled = value;}
		}
		/// <summary>
		/// 获取或设置一个值，该值指示服务器控件是否作为UI呈现在页面上。
		/// </summary>
        //[Category("Toolbar")]
        //[DefaultValue("True")]
        //[Description("获取或设置一个值，该值指示服务器控件是否作为UI呈现在页面上。")]
        //[Localizable(true)]
        //public override bool Visible
        //{
        //    get { return dropdownList.Visible; }
        //    set { dropdownList.Visible = value; }
        //}
		/// <summary>
		/// 获取列表控件项的集合。
		/// </summary>
		[Category("Toolbar")]
		[Description("获取列表控件项的集合。")]
		[Localizable(true)]
		public ListItemCollection Items
		{
			get {return dropdownList.Items;}
		}
		/// <summary>
		/// 内部的下拉列表服务器控件。
		/// </summary>
		public DropDownList InternalDropDownList
		{
			get {return dropdownList;}
		}
		#endregion

		#region intialization
		/// <summary>
		/// Inits the control.
		/// </summary>
		public ToolbarDropdownList()
		{
			this.dropdownList = new DropDownList
			                        {
			                            CssClass = "toolbarSelect",
			                        };
		    this.dropdownList.SelectedIndexChanged+=dropdownList_SelectedIndexChanged;
		}
		/// <summary>
		/// Adds the internal TextBox control to the item's
		/// <c>Controls</c> collection.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
            //if (!IsDesignMode)
            //{
                string preTable = string.Format("<table class=\"{0}\" style=\"{1}\" title=\"{2}\" cellspacing=\"0\"	cellpadding=\"0\" unselectable=\"on\"><tbody><tr><td style=\"position:relative\">", string.IsNullOrEmpty(this.CssClass) ? this.TableClass : this.CssClass, this.Style.Value, this.ToolTip);
                this.Controls.Add(new LiteralControl(preTable));
                this.Controls.Add(new LiteralControl("<td>"));
            //}
		    this.dropdownList.ID = "ddl";
		    this.dropdownList.SkinID = this.SkinID;
			this.Controls.Add(dropdownList);
			
            //if (!IsDesignMode)
            //{
                this.Controls.Add(new LiteralControl("</td></tr></tbody></table>"));
            //}
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
		    this.dropdownList.Enabled = this.Enabled;
            this.dropdownList.CausesValidation = this.CausesValidation;
            this.dropdownList.ValidationGroup = this.ValidationGroup;
			//this.dropdownList.ApplyStyle(this.ControlStyle);
			this.dropdownList.CopyBaseAttributes(this);
			base.RenderContents (writer);
		}
		#endregion

		#region event handling

		/// <summary>
		/// Bubbles a SelectedIndex changed event of the contained DropdownList.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dropdownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ItemSubmitted !=null) ItemSubmitted(this);
		}
		#endregion

		
	}
}
