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
		/// ��ȡ�������ں���DropdownList�ؼ��Ŀ�ȡ�
		/// </summary>
		[Category("Toolbar")]
		[Description("��ȡ�������ں���DropdownList�ؼ��Ŀ�ȡ�")]
		public override Unit Width
		{	
			get {return this.dropdownList.Width;}
			set {this.dropdownList.Width = value;}
		}
		/// <summary>
		/// ��ȡ������DropdownList�ؼ�����ΧTable��CSS��ʽ��
		/// </summary>
		[Category("Toolbar")]
		[Description("��ȡ������DropdownList�ؼ�����ΧTable��CSS��ʽ��")]
		public string TableClass
		{
			get {return this.m_TableClass;}
			set {this.m_TableClass = value;}
		}
		/// <summary>
		/// ��ȡToolbarDropdownList�ؼ���������С��ѡ���
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue("")]
		[Description("��ȡToolbarDropdownList�ؼ���������С��ѡ���")]
		[Localizable(true)]
		public ListItem SelectedItem
		{
			get { return dropdownList.SelectedItem; }
		}
		/// <summary>
		/// ��ȡToolbarDropdownList�ؼ�ѡ�����ֵ����ѡ���б�ؼ��а���ָ��ֵ���
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue("")]
		[Description("��ȡ�б�ؼ�ѡ�����ֵ����ѡ���б�ؼ��а���ָ��ֵ���")]
		[Localizable(true)]
		public string SelectedValue
		{
			get { return dropdownList.SelectedValue;}
			set { dropdownList.SelectedValue = value;}
		}
		/// <summary>
		/// ��ȡ������ToolbarDropdownList�ؼ��е�ѡ�����������
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue("")]
		[Description("��ȡ������ToolbarDropdownList�ؼ��е�ѡ�����������")]
		[Localizable(true)]
		public int SelectedIndex
		{
			get {return dropdownList.SelectedIndex;}
			set {dropdownList.SelectedIndex = value;}
		}
		/// <summary>
		/// ��ȡ������һ��ֵ����ֵָʾ���û������б��ѡ������ʱ�Ƿ��Զ�������������Ļط���
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue(false)]
		[Description("��ȡ������һ��ֵ����ֵָʾ���û������б��ѡ������ʱ�Ƿ��Զ�������������Ļط���")]
		public bool AutoPostBack
		{
			get { return dropdownList.AutoPostBack; }
			set { this.dropdownList.AutoPostBack = value; }
		}
		/// <summary>
		/// ��ȡ������DropdownList�ؼ�����ΧTable��CellPadding��
		/// </summary>
		[Category("Toolbar")]
		[Description("��ȡ������DropdownList�ؼ�����ΧTable��CellPadding��")]
		public string Cellpadding
		{
			get {return m_Cellpadding;}
			set {m_Cellpadding = value;}
		}
		/// <summary>
		/// ��ȡ������DropdownList�ؼ�����ΧTable��CellSpacing��
		/// </summary>
		[Category("Toolbar")]
		[Description("��ȡ������DropdownList�ؼ�����ΧTable��CellPadding��")]
		public string Cellspacing
		{
			get {return m_Cellspacing;}
			set {m_Cellspacing = value;}
		}
		/// <summary>
		/// ��ȡ������һ��ֵ����ֵָʾ�Ƿ�����DropdownList�������ؼ���
		/// </summary>
		[Category("Toolbar")]
		[DefaultValue("True")]
		[Description("��ȡ������һ��ֵ����ֵָʾ�Ƿ�����DropdownList�������ؼ���")]
		[Localizable(true)]
		public override bool Enabled
		{
			get {return dropdownList.Enabled;}
			set {dropdownList.Enabled = value;}
		}
		/// <summary>
		/// ��ȡ������һ��ֵ����ֵָʾ�������ؼ��Ƿ���ΪUI������ҳ���ϡ�
		/// </summary>
        //[Category("Toolbar")]
        //[DefaultValue("True")]
        //[Description("��ȡ������һ��ֵ����ֵָʾ�������ؼ��Ƿ���ΪUI������ҳ���ϡ�")]
        //[Localizable(true)]
        //public override bool Visible
        //{
        //    get { return dropdownList.Visible; }
        //    set { dropdownList.Visible = value; }
        //}
		/// <summary>
		/// ��ȡ�б�ؼ���ļ��ϡ�
		/// </summary>
		[Category("Toolbar")]
		[Description("��ȡ�б�ؼ���ļ��ϡ�")]
		[Localizable(true)]
		public ListItemCollection Items
		{
			get {return dropdownList.Items;}
		}
		/// <summary>
		/// �ڲ��������б�������ؼ���
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
