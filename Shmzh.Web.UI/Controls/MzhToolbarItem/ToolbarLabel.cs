using System;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;

namespace Shmzh.Web.UI.Controls
{
	/// <summary>
	/// Renders a simple label.
	/// </summary>
	[ToolboxBitmap(typeof(ToolbarLabel),"Shmzh.Web.UI.Controls.ToolbarLabel.bmp")]
	public class ToolbarLabel : ToolbarItem
	{
		#region 成员变量
		protected string m_TableClass = "labelTable";
		protected string m_Cellpadding = "0";
		protected string m_Cellspacing = "0";
		protected string m_LabelClass = "labelCell";
		#endregion

		#region 属性
		/// <summary>
		/// ToolbarLabel的文本。
		/// </summary>
		[Description("Rendered text")]
		[DefaultValue("")]
		[Localizable(true)]
		public string Text
		{
			get
			{ 
				var text = (string)this.ViewState["ItemText"];
				return text ?? String.Empty;
			}
			set { ViewState["ItemText"] = value; }
		}
		/// <summary>
		/// Label的样式名。
		/// </summary>
		public string LabelClass
		{
			get {return m_LabelClass;}
			set {m_LabelClass = value;}
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
		#endregion

		#region 构造函数
		/// <summary>
		/// 空构造函数。
		/// </summary>
		public ToolbarLabel() : base(HtmlTextWriterTag.Table)
		{
		}
		
		#endregion

		#region Rending
		/// <summary>
		/// 将ToolbarButton的HTML标签Table的onclick事件绑定到__dopostback()上。
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Class, this.TableClass, true);
			writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, this.Cellpadding);
			writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, this.Cellspacing);
            writer.AddAttribute(HtmlTextWriterAttribute.Style, this.Style.Value);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, this.ToolTip);
			writer.AddAttribute("unselectable","on");

			base.AddAttributesToRender(writer);
		}
		/// <summary>
		/// Renders the item's <see cref="Text"/> to the client.
		/// </summary>
		/// <param name="writer"></param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			RenderLabelCell(writer);			
			base.RenderContents (writer);
		}
		/// <summary>
		/// 呈现文字。
		/// </summary>
		/// <param name="writer">HtmlTextWriter</param>
		/// <example><td class="labelCell" unselectable="on">文字</td></example>
		protected void RenderLabelCell(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Class,LabelClass,true);
			writer.AddAttribute("unselectable","on",true);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
				writer.Write(this.Text);
			writer.RenderEndTag();
		}
		#endregion

	}
}
