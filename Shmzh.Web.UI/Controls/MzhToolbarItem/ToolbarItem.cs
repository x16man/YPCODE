using System;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;


namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// Toobar空间的所有项的抽象基类。
	/// </summary>
	public abstract class ToolbarItem : WebControl, INamingContainer
	{
		#region members
		/// <summary>
		/// ToolbarItem的唯一ID。
		/// 可以在postback事件触发的时候被用来判断事件源对象。
		/// </summary>
		protected string m_itemId = String.Empty;
//	    protected string m_TableClass = "buttonTable";
//		protected string m_Cellpadding = "0";
//		protected string m_Cellspacing = "0";
		#endregion

		#region properties
		/// <summary>
		/// ToolbarItem的唯一ID。
		/// 可以在postback事件触发的时候被用来判断事件源对象。
		/// </summary>
		[Description("ToolbarItem的用户定义的唯一ID。")]
		public string ItemId
		{
			get { return m_itemId; }
			set {this.m_itemId = value; }
		}
        /// <summary>
        /// 是否导致激发验证。
        /// </summary>
        [DefaultValue(false), Themeable(false), Category("Behavior"), Description("是否导致激发验证。"),]
        public virtual bool CausesValidation
        {
            get
            {
                object b = ViewState["CausesValidation"];
                return ((b == null) ? true : (bool)b);
            }
            set
            {
                ViewState["CausesValidation"] = value;
            }
        }
        /// <summary>
        /// 当控件导致发时应验证的组。
        /// </summary>
        [DefaultValue(""), Themeable(false), Category("Behavior"), Description("当控件导致发时应验证的组。"),]
        public string ValidationGroup
        {
            get
            {
                var s = (string)ViewState["ValidationGroup"];
                return (s ?? String.Empty);
            }
            set
            {
                ViewState["ValidationGroup"] = value;
            }
        } 
        /// <summary>
        /// 在客户段onclick上执行的客户端脚本。
        /// </summary>
        [DefaultValue(""), Themeable(false), Category("Client Behavior"), Description("在客户段onclick上执行的客户端脚本。"),]
        public virtual string OnClientClick
        {
            get
            {
                var s = (string)ViewState["OnClientClick"];
                return s ?? String.Empty;
            }
            set
            {
                ViewState["OnClientClick"] = value;
            }
        }
        
		/// <summary>
		/// 判断控件当前是在设计模式还是不是。
		/// </summary>
		protected bool IsDesignMode
		{
			get { return System.Web.HttpContext.Current == null; }
		}
		#endregion

		#region initialization

		/// <summary>
		/// 空构造函数。
		/// </summary>
		protected ToolbarItem()
		{
		}

		/// <summary>
		/// 以一个特定的HTML标签来构造一个ToolbarItem。
		/// </summary>
		/// <param name="tag">Html tag of the item control.</param>
		protected ToolbarItem(HtmlTextWriterTag tag) : base(tag)
		{
		}

		#endregion

		#region rendering
		/// <summary>
		/// Adds table attributes to the rendered output.
		/// </summary>
		/// <param name="writer"></param>
//		protected override void AddAttributesToRender(HtmlTextWriter writer)
//		{
//			//<table id="btnTbl_File" class="buttonTable" cellpadding="0" unselectable="on" >
//			if (this.TagKey == HtmlTextWriterTag.Table)
//			{
//				writer.AddAttribute(HtmlTextWriterAttribute.Class, this.TableClass, true);
//				writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, this.Cellpadding);
//				writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, this.Cellspacing);
//				writer.AddAttribute("unselectable","on");
//			}
//			base.AddAttributesToRender(writer);
//		}
		/// <summary>
		/// 呈现ToolbarItem的左边栏。
		/// </summary>
		/// <param name="writer"></param>
//		protected void RenderLeftCap(HtmlTextWriter writer)
//		{
//			//<td class="leftCap" style="width:3px" unselectable="on">
//			writer.AddAttribute(HtmlTextWriterAttribute.Class ,"leftCap");
//			writer.AddStyleAttribute("width","3px");
//			writer.AddAttribute("unselectable", "on");
//			writer.RenderBeginTag(HtmlTextWriterTag.Td);
//			//<div style="width:3px;visibility:hidden;">
//			writer.AddStyleAttribute("width","3px");
//			writer.AddStyleAttribute("visibility", "hidden");
//			writer.AddAttribute("unselectable", "on");
//			writer.RenderBeginTag(HtmlTextWriterTag.Div);
//
//			writer.RenderEndTag();//</div>
//			writer.RenderEndTag();//</td>
//		}
		/// <summary>
		/// 呈现ToolbarItem的右边栏。
		/// </summary>
		/// <param name="writer"></param>
//		protected void RenderRightCap(HtmlTextWriter writer)
//		{
//			//<td class="rightCap" style="width:3px" unselectable="on">
//			//<td class="leftCap" style="width:3px" unselectable="on">
//			writer.AddAttribute(HtmlTextWriterAttribute.Class ,"rightCap");
//			writer.AddStyleAttribute("width","3px");
//			writer.AddAttribute("unselectable", "on");
//			writer.RenderBeginTag(HtmlTextWriterTag.Td);
//			//<div style="width:3px;visibility:hidden;" unselectable="on">
//			writer.AddStyleAttribute("width","3px");
//			writer.AddStyleAttribute("visibility", "hidden");
//			writer.AddAttribute("unselectable", "on");
//			writer.RenderBeginTag(HtmlTextWriterTag.Div);
//
//			writer.RenderEndTag();//</div>
//			writer.RenderEndTag();//</td>
//		}
		#endregion

	}
}
