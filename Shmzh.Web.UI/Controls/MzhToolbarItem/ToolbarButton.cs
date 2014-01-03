using System;
using System.Drawing;
using System.Web.UI;
using System.ComponentModel;

namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// ToolbarButton 的摘要说明。
	/// </summary>
	[ToolboxBitmap(typeof(ToolbarButton),"Shmzh.Web.UI.Controls.ToolbarButton.bmp")]
	public class ToolbarButton : ToolbarItem,IPostBackDataHandler,IPostBackEventHandler,IPostBackToolbarItem
	{
#pragma warning disable 169
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore 169
		#region event declaration
		/// <summary>
		/// 当ToolbarButton被点击时触发事件。
		/// </summary>
		public event ItemEventHandler ItemSubmitted;

		#endregion

		#region 成员变量
		protected string m_LabelClass = "labelCell";
		protected string m_NakedLabelClass = "nakedLabelCell";
		protected string m_IconClass = "icon";
		protected bool m_HasIcon = true;
		protected bool m_IsShowText = true;
		protected string m_TableClass = "buttonTable";
		protected string m_Cellpadding = "0";
		protected string m_Cellspacing = "0";
		#endregion

		#region 属性
        /// <summary>
        /// 是否自动激发回送。
        /// </summary>
        [Category("Behavior"), Description("是否自动激发回送。"), DefaultValue(true)]
        public virtual bool AutoPostBack
        {
            get
            {
                object b = this.ViewState["AutoPostBack"];
                return ((b != null) && ((bool)b));
            }
            set
            {
                this.ViewState["AutoPostBack"] = value;
            }
        }
 		/// <summary>
		/// ToolbarLabel的文本。
		/// </summary>
        [
        Bindable(true),
        Localizable(true),
        Category("Appearance"),
        DefaultValue(""),
        ]
        public string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["Text"] = value;
            }
        }
		/// <summary>
		/// Label的样式名。
		/// </summary>
		public string LabelClass
		{
			get { return m_LabelClass; }
			set { m_LabelClass = value; }
		}
		
		/// <summary>
		/// 没有Icon时候的Label的样式名。
		/// </summary>
		public string NakedLabelClass
		{
			get { return m_NakedLabelClass; }
			set { m_NakedLabelClass = value; }
		}
		
		/// <summary>
		/// 按钮的Icon的样式。
		/// </summary>
		/// 图标的显示是通过指定背景图的位置来确定的。
		public string IconClass
		{
			get { return m_IconClass; }
			set { m_IconClass = value; }
		}
		
		/// <summary>
		/// 是否有图标。
		/// </summary>
		public bool HasIcon
		{
			get { return m_HasIcon; }
			set { m_HasIcon = value; }
		}
		
		public bool IsShowText
		{
			get { return m_IsShowText; }
			set { m_IsShowText = value; }
		}
		/// <summary>
		/// ToolbarItem的css样式名。
		/// </summary>
		[Category("Style")]
		[Description("ToolbarItem的css样式名称。")]
		public string TableClass
		{
			get {return m_TableClass;}
			set {this.m_TableClass = value;}
		}
		/// <summary>
		/// ToolbarItem的Cellpadding。
		/// </summary>
		[Category("Style")]
		[Description("ToolbarItem的Cellpadding。")]
		public string Cellpadding
		{
			get {return m_Cellpadding;}
			set {m_Cellpadding = value;}
		}
		/// <summary>
		/// ToolbarItem的Cellpadding。
		/// </summary>
		[Category("Style")]
		[Description("ToolbarItem的Cellspacing。")]
		public string Cellspacing
		{
			get {return m_Cellspacing;}
			set {m_Cellspacing = value;}
		}
		#endregion

        /// <summary>
        /// 指定如何生成客户端 JavaScript 以启动回发事件。
        /// </summary>
        /// <returns></returns>
        protected virtual PostBackOptions GetPostBackOptions()
        {
            var options = new PostBackOptions(this, String.Empty) {ClientSubmit = true};

            if (Page != null)
            {
                if (CausesValidation && Page.GetValidators(ValidationGroup).Count > 0)
                {
                    options.PerformValidation = true;
                    options.ValidationGroup = ValidationGroup;
                }
                options.AutoPostBack = this.AutoPostBack;
            }
            return options;
        }
		#region 构造函数
		public ToolbarButton():base(HtmlTextWriterTag.Table)
		{
			//
			// 
			//
		}
		#endregion

		#region prerender
        
		#endregion

		#region Rending
		/// <summary>
		/// 将ToolbarButton的HTML标签Table的onclick事件绑定到__dopostback()上。
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
            //Logger.Info("AddAttributesToRender."+this.ItemId);
            if (Page != null)
            {
                Page.VerifyRenderingInServerForm(this);
            }
			writer.AddAttribute(HtmlTextWriterAttribute.Class, string.IsNullOrEmpty(this.CssClass)?this.TableClass:this.CssClass, true);
			writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, this.Cellpadding);
			writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, this.Cellspacing);
            writer.AddAttribute(HtmlTextWriterAttribute.Style, this.Style.Value);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, this.ToolTip);
			writer.AddAttribute("unselectable","on");

            var options = GetPostBackOptions();

            var onClick = String.Empty;
            //Logger.Info(this.ItemId+"    this.Enabled:"+this.Enabled.ToString());

            if (this.Enabled )
			{
                onClick = Util.EnsureEndWithSemiColon(OnClientClick);
                if (this.HasAttributes)
                {
                    var userOnClick = Attributes["onclick"];
                    if (userOnClick != null) {
                        onClick += Util.EnsureEndWithSemiColon(userOnClick); 
                        Attributes.Remove("onclick");
                    } 
                }
                //Logger.Info(this.ItemId+"     this.AutoPostBack:"+this.AutoPostBack.ToString());
                
                if (this.AutoPostBack)
                {
                    //Logger.Info(this.ItemId+"    this causesValidation:"+this.CausesValidation.ToString());
                    if (Page != null)
                    {
                        var reference = Page.ClientScript.GetPostBackEventReference(options,false);
                        //if (this.CausesValidation)
                        //{
                        
                        //}
                        //else
                        //    reference = Page.ClientScript.GetPostBackEventReference(this, "");
                        //Logger.Info(this.ItemId+"    PostBack String :"+reference);
                    
                        if (reference != null)
                        {
                            onClick = Util.MergeScript(onClick, reference);
                        }
                    }
                }
			}
            if (Page != null)
            {
                Page.ClientScript.RegisterForEventValidation(options);
            }
            if (onClick.Length > 0)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, onClick);
            }
			base.AddAttributesToRender(writer);
		}
		/// <summary>
		/// 呈现一个按钮。
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// <remarks>button使用一个Table来模拟出来的。</remarks>
		/// <example>
		/// <table id="btnTbl_File" class="buttonTable" cellpadding="0" unselectable="on" onclick="alert('ok')">
		///		<tr>
		///			<td class="leftCap" style="width:3px" unselectable="on"><div style="width:3px;visibility:hidden;" unselectable="on"></div></td>
		///			<td class="buttonIconCell" unselectable="on"><div class="button" style="background-position:-1881px 0px" unselectable="on"></div></td>
		///			<td class="labelCell" unselectable="on">File</td>
		///			<td class="rightCap" style="width:3px" unselectable="on"><div style="width:3px;visibility:hidden;" unselectable="on"></div></td>
		///		</tr>
		///	</table>
		/// </example>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			this.RenderLeftCapCell(writer);//呈现左边栏。
			this.RenderIconCell(writer);
			this.RenderLabelCell(writer, this.HasIcon);
			this.RenderRightCapCell(writer);//呈现右边栏。
			base.RenderContents (writer);
		}
		/// <summary>
		/// 呈现图标。
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// <example>呈现结果：<code><td class="buttonIconCell" unselectable="on"><div class="button" unselectable="on"></div></td>。</code></example>
		protected void RenderIconCell(HtmlTextWriter writer)
		{
			if (!this.HasIcon) return;//如果没有图标则直接退出。
			writer.AddAttribute("class","buttonIconCell",true);
			writer.AddAttribute("unselectable","on",true);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			{
				writer.AddAttribute("class",string.Format("button {0}",this.IconClass),true);
				writer.AddAttribute("unselectable","on",true);
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
				writer.RenderEndTag();//</div>
			}
			writer.RenderEndTag();//</td>
		}
		/// <summary>
		/// 呈现文字。
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// <example><td class="labelCell" unselectable="on">文字</td></example>
		protected void RenderLabelCell(HtmlTextWriter writer,bool hasIcon)
		{
			if (!IsShowText) return;
			writer.AddAttribute(HtmlTextWriterAttribute.Class,hasIcon?LabelClass:NakedLabelClass,true);
			writer.AddAttribute("unselectable","on",true);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
				writer.Write(this.Text);
			writer.RenderEndTag();
		}
		/// <summary>
		/// 呈现ToolbarItem的左边栏。
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// /// <example><td class="leftCap" style="width:3px" unselectable="on"></example>
		protected void RenderLeftCapCell(HtmlTextWriter writer)
		{
			RenderCapCell(writer, "leftCap");
		}
		/// <summary>
		/// 呈现ToolbarItem的右边栏。
		/// </summary>
		/// <param name="writer"></param>
		/// <example><td class="rightCap" style="width:3px" unselectable="on"></example>
		protected void RenderRightCapCell(HtmlTextWriter writer)
		{
			RenderCapCell(writer, "rightCap");
		}
		/// <summary>
		/// 呈现button的左右两边栏。
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// <param name="capClass">css样式名。</param>
		/// <example><td class="capClass" style="width:3px" unselectable="on"></example>
		private void RenderCapCell(HtmlTextWriter writer, string capClass)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Class ,capClass);
			writer.AddStyleAttribute("width","3px");
			writer.AddAttribute("unselectable", "on");
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
				writer.AddStyleAttribute("width","3px");
				writer.AddStyleAttribute("visibility", "hidden");
				writer.AddAttribute("unselectable", "on");
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
				writer.RenderEndTag();
			writer.RenderEndTag();
		}
		#endregion

		#region IPostBackDataHandler 成员

		public void RaisePostDataChangedEvent()
		{
			//触发页面验证控件的行为。
			//Page.Validate();

			//bubble event
			if (this.ItemSubmitted != null) 
				ItemSubmitted(this);
		}

		public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			return false;//return false 则将不会触发RaisePostDataChangedEvent（）；
		}

		#endregion

		#region IPostBackEventHandler 成员

		public void RaisePostBackEvent(string eventArgument)
		{
            if (this.CausesValidation)
            {
                this.Page.Validate(this.ValidationGroup);
            }
            if (this.ItemSubmitted != null)
                ItemSubmitted(this);
		}

		#endregion
	}
}
